using System;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using System.Runtime.CompilerServices;
using System.Windows.Forms;
using JSystem.Perform;
using JSystem.Device;
using Serilizer;
using System.Collections.Generic;

namespace JSystem.Station
{
    public class StationBase
    {
        public EStationState State { get; protected set; } = EStationState.STOP;

        public string Name;

        public int Step { get; protected set; } = 0;

        private StationAxis[] _axes;

        public StationAxis[] Axes
        {
            get
            {
                if (_axes == null)
                {
                    _axes = JsonSerializer.Deserilize<StationInfo>($"{AppDomain.CurrentDomain.BaseDirectory}Config/{Name}.json").AxesInfo;
                    foreach (StationAxis axis in _axes)
                    {
                        axis.OnGetDevice = GetDevice;
                        axis.OnSaveParam = SaveParam;
                    }
                }
                return _axes;
            }
        }

        private DataModel _model = new DataModel();

        public DataModel Model
        {
            set
            {
                StationInfo info = JsonSerializer.Deserilize<StationInfo>($"{AppDomain.CurrentDomain.BaseDirectory}Config/{Name}.json");
                PointInfo[] pointsInfo = new PointInfo[info.PointsName.Length];
                for (int i = 0; i < info.PointsName.Length; i++)
                {
                    pointsInfo[i] = new PointInfo
                    {
                        Name = info.PointsName[i],
                        Pos = new double[info.AxesInfo.Length]
                    };
                    double[] pos = value.PointsInfo?.FirstOrDefault((p) => p.Name == pointsInfo[i].Name)?.Pos;
                    if (pos == null) continue;
                    int length = pos.Length > pointsInfo[i].Pos.Length ? pointsInfo[i].Pos.Length : pos.Length;
                    Array.Copy(pos, pointsInfo[i].Pos, length);
                }
                _model = value;
                _model.PointsInfo = pointsInfo;
            }
            get
            {
                return _model;
            }
        }

        public StationView View;

        public Control DebugForm;

        public Action<string, string> OnAddSN;

        public Queue<string> SNQueue = new Queue<string>();

        public Queue<DateTime> TimeQueue = new Queue<DateTime>();

        public Func<string, int> OnGetStep;

        public Func<string, EStationState> OnGetState;

        public Func<bool> OnStart;

        public Func<bool, bool> OnPause;

        public Func<bool, bool> OnStop;

        public Func<string, DeviceBase> OnGetDevice;

        public Action<string, bool> OnSetOut;

        public Func<string, bool> OnGetIn;

        public Func<string, bool, bool> OnGetEdgeSignal;

        public virtual void Run() { }

        public virtual void End() { State = EStationState.END; }

        public virtual void JumpStep(int step) { Step = step; }

        public virtual void Start()
        {
            if (State != EStationState.PAUSE && State != EStationState.RESETED)
                return;
            State = EStationState.RUNNING;
        }

        public virtual void Stop()
        {
            for (int i = 0; i < Axes.Length; i++)
                Axes[i].EndMove();
            State = EStationState.STOP;
        }

        public virtual void Pause()
        {
            for (int i = 0; i < Axes.Length; i++)
                Axes[i].EndMove();
            State = EStationState.PAUSE;
        }

        public virtual bool Reset()
        {
            SNQueue.Clear();
            TimeQueue.Clear();
            return true;
        }

        /// <summary>
        /// 多轴回原
        /// </summary>
        /// <param name="isHome">true是回原，false是不回原</param>
        /// <param name="isAsyn"></param>
        /// <param name="timeOut"></param>
        /// <returns></returns>
        protected bool GoHome(bool[] isHome, bool isAsyn = false, int timeOut = 60000)
        {
            if (isHome == null || isHome.Length < Axes.Length)
            {
                AddLog($"isHome数组长度小于AxesInfo", true);
                return false;
            }
            bool ret = true;
            int idx = 0;
            Task[] taskPool = new Task[isHome.Where(b => b == true).Count()];
            for (int i = 0; i < Axes.Length; i++)
            {
                if (!isHome[i]) continue;
                taskPool[idx] = new Task((j) =>
                {
                    if (!GoHome(Axes[(int)j].Name, isAsyn, timeOut))
                        ret = false;
                }, i);
                taskPool[idx].Start();
                idx++;
            }
            Task.WaitAll(taskPool);
            return ret;
        }

        protected bool GoHome(string axisName, bool isAsyn = false, int timeOut = 60000)
        {
            try
            {
                DateTime start = DateTime.Now;
                StationAxis axis = GetAxisByName(axisName);
                if (axis == null) return false;
                AddLog($"{axisName}轴开始回原");
                axis.GoHome();
                if (isAsyn) return true;
                while (true)
                {
                    Thread.Sleep(100);
                    if (axis.IsEmergencyStop || axis.IsAlarm || State != EStationState.RESETING)
                    {
                        AddLog($"{axisName}轴回原失败，请检查急停按钮开关是否按下以及驱动器是否报警", true);
                        return false;
                    }
                    if (axis.CheckIsInPos(0.0))
                    {
                        Thread.Sleep(500);  //由于有可能只经过原点但是还没有真正回原结束，所以要延迟500毫秒以后再监控一次坐标
                        if (axis.CheckIsInPos(0.0))
                        {
                            AddLog($"{axisName}轴回原完成");
                            return true;
                        }
                    }
                    if (DateTime.Now.Subtract(start).TotalMilliseconds > timeOut)
                    {
                        AddLog($"{axisName}轴回原超时，请重新尝试，并联系工程师解决");
                        return false;
                    }
                }
            }
            catch (Exception ex)
            {
                Stop();
                AddLog($"移动到固定点位出现异常，请检查是否pos长度小于轴数：{ex.Message}", true);
                return false;
            }
        }

        /// <summary>
        /// 移动到固定点位（默认同步）
        /// </summary>
        /// <param name="pos"></param>
        /// <param name="speed"></param>
        /// <param name="isAsyn">false：同步，true：异步</param>
        /// <param name="timeOut">超时，单位：毫秒</param>
        /// <returns>false表示移动失败</returns>
        protected bool MoveToPos(double[] pos, string name = "", double speed = -1, bool isAsyn = false, int timeOut = 60000)
        {
            if (name != "") AddLog($"移动到{name}");
            if (pos == null || pos.Length < Axes.Length)
            {
                AddLog($"pos数组长度小于AxesInfo", true);
                OnStop?.Invoke(false);
                return false;
            }
            bool ret = true;
            int idx = 0;
            Task[] taskPool = new Task[pos.Where(p => !double.IsNaN(p)).Count()];
            for (int i = 0; i < Axes.Length; i++)
            {
                if (double.IsNaN(pos[i])) continue;
                taskPool[idx] = new Task((j) =>
                {
                    if (!MoveToPos(Axes[(int)j].Name, pos[(int)j], speed, isAsyn, timeOut))
                        ret = false;
                }, i);
                taskPool[idx].Start();
                idx++;
            }
            Task.WaitAll(taskPool);
            return ret;
        }

        public bool MoveToPos(string axisName, double pos, double speed = -1, bool isAsyn = false, int timeOut = 60000)
        {
            try
            {
                StationAxis axis = GetAxisByName(axisName);
                if (axis == null)
                {
                    AddLog($"{Name}不存在{axisName}轴");
                    OnStop?.Invoke(false);
                    return false;
                }
                if (double.IsNaN(pos)) return true;
                AddLog($"{axisName}轴移动到{pos}");
            MOVE:
                while (State == EStationState.PAUSE)
                    Thread.Sleep(100);
                if (State != EStationState.MANUAL && State != EStationState.RUNNING && State != EStationState.RESETING) return false;
                if (!axis.AbsMove(pos, speed))
                {
                    AddLog($"{axisName}轴运动失败，请检查轴卡是否断连");
                    DialogResult ret = View.DispAlarm($"{axisName}轴运动失败，请检查轴卡是否断连");
                    if (ret == DialogResult.Retry)
                        goto MOVE;
                    else if (ret == DialogResult.Abort)
                        return false;
                }
                if (isAsyn) return true;                    //异步直接结束
                DateTime start = DateTime.Now;
                while (!axis.CheckIsInPos(pos))        //不用是否停止来判断是因为有些轴卡并没有可以判断是否停止的函数
                {
                    Thread.Sleep(10);
                    if (State == EStationState.PAUSE) goto MOVE;
                    else if (State != EStationState.MANUAL && State != EStationState.RUNNING && State != EStationState.RESETING)
                        return false;
                    if (DateTime.Now.Subtract(start).TotalMilliseconds > timeOut)
                    {
                        OnStop?.Invoke(false);
                        AddLog("运动超时，请检查是否到达限位，并联系工程师");
                        return false;
                    }
                }
                return true;
            }
            catch (Exception ex)
            {
                Stop();
                AddLog($"移动到固定点位出现异常：{ex.Message}", true);
                return false;
            }
        }

        /// <summary>
        /// 连续运动
        /// </summary>
        /// <param name="axesName"></param>
        /// <param name="dir">1：正方向，-1：负方向，0：不运动</param>
        /// <param name="during"></param>
        /// <param name="speed"></param>
        /// <returns></returns>
        protected bool JogMove(string axesName, int dir, double speed = -1)
        {
            try
            {
                StationAxis axis = GetAxisByName(axesName);
                if (axis == null) return false;
                if (dir == 0)
                {
                    axis.EndMove();
                    AddLog($"{axesName}轴连续运动停止");
                    return true;
                }
                AddLog($"{axesName}轴连续运动");
                axis.JogMove(dir == 1, speed);
                return true;
            }
            catch (Exception ex)
            {
                AddLog($"{axesName}轴连续移动失败：{ex.Message}");
                return false;
            }
        }

        /// <summary>
        /// 检查是否停止
        /// </summary>
        /// <param name="axisName"></param>
        /// <returns></returns>
        protected bool CheckIsStop(string axisName)
        {
            StationAxis axis = GetAxisByName(axisName);
            if (axis == null) return false;
            return axis.CheckIsStop();
        }

        protected StationAxis GetAxisByName(string name)
        {
            var list = Axes.Where(axis => axis.Name == name).ToList();
            if (list == null || list.Count == 0)
            {
                OnStop?.Invoke(false);
                AddLog($"{Name}没有{name}轴");
                return null;
            }
            return list[0];
        }

        protected bool GetIn(string name, bool isOn, int timeout = 0)
        {
            try
            {
                DateTime start = DateTime.Now;
                while (true)
                {
                    if (State == EStationState.PAUSE)
                    {
                        start = DateTime.Now;
                        continue;
                    }
                    else if (State != EStationState.MANUAL && State != EStationState.RUNNING && State != EStationState.RESETING)
                        return false;
                    if (OnGetIn(name) == isOn) return true;
                    if (DateTime.Now.Subtract(start).TotalMilliseconds > timeout)
                    {
                        if (timeout != 0)
                        {
                            AddLog($"{name}信号检测超时，请检查感应器是否有异常");
                            DialogResult ret = View.DispAlarm($"{name}信号检测超时，请检查感应器是否有异常");
                            if (ret == DialogResult.Retry)
                                return false;
                            else if (ret == DialogResult.Ignore)
                                return true;
                        }
                        return false;
                    }
                    Thread.Sleep(10);
                }
            }
            catch (Exception ex)
            {
                OnStop?.Invoke(false);
                AddLog(ex.Message, true);
                return false;
            }
        }

        protected bool Delay(int timeOut)
        {
            try
            {
                DateTime start = DateTime.Now;
                while (true)
                {
                    Thread.Sleep(5);
                    if (State == EStationState.PAUSE)
                    {
                        start = DateTime.Now;
                        continue;
                    }
                    else if (State != EStationState.MANUAL && State != EStationState.RUNNING && State != EStationState.RESETING)
                        return false;
                    if (DateTime.Now.Subtract(start).TotalMilliseconds > timeOut)
                        return true;
                }
            }
            catch (Exception ex)
            {
                OnStop?.Invoke(false);
                AddLog(ex.Message, true);
                return false;
            }
        }

        protected void SetOut(string name, bool value)
        {
            try
            {
                OnSetOut(name, value);
                AddLog($"信号{name}设置为{value}");
            }
            catch (Exception ex)
            {
                OnStop?.Invoke(false);
                AddLog(ex.Message, true);
            }
        }

        protected double[] GetPos(string posName)
        {
            double[] pos = new double[Axes.Length];
            var list = Model.PointsInfo.Where(posInfo => posInfo.Name == posName).ToList();
            if (list == null || list.Count == 0)
            {
                AddLog($"列表中没有{posName}");
                return null;
            }
            for (int i = 0; i < Axes.Length; i++)
                pos[i] = list[0].Pos[i];
            return pos;
        }

        public void SwitchManual(bool isManual)
        {
            State = isManual ? EStationState.MANUAL : EStationState.STOP;
        }

        public void AddLog(string log, bool isError = false, [CallerFilePath] string filePath = "",
            [CallerMemberName] string caller = "", [CallerLineNumber] int lineNum = 0)
        {
            LogManager.Instance.AddLog(Name + "\t" + log, isError, filePath, caller, lineNum);
        }

        protected DeviceBase GetDevice(string name)
        {
            return OnGetDevice?.Invoke(name);
        }

        private void SaveParam()
        {
            StationInfo info = JsonSerializer.Deserilize<StationInfo>($"{AppDomain.CurrentDomain.BaseDirectory}Config/{Name}.json");
            info.AxesInfo = Axes;
            JsonSerializer.Serilize(info, $"{AppDomain.CurrentDomain.BaseDirectory}Config/{Name}.json");
        }
    }
}
