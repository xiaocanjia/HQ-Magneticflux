using System;
using System.Threading;
using System.Collections.Generic;
using System.Threading.Tasks;
using JSystem.Perform;
using MeasResult;
using JSystem.Device;
using HalconDotNet;

namespace JSystem.Station
{
    public class StationManager
    {
        private EStationState _state = EStationState.STOP;

        public List<StationBase> StationList { get; private set; } = new List<StationBase>();

        public DataModel[] Models
        {
            get
            {
                DataModel[] models = new DataModel[StationList.Count];
                for (int i = 0; i < StationList.Count; i++)
                    models[i] = StationList[i].Model;
                return models;
            }
            set
            {
                for (int i = 0; i < StationList.Count; i++)
                    StationList[i].Model = value[i];
            }
        }

        public Action<string> OnSetUserRight;

        public Func<bool> OnStart;

        public Func<bool, bool> OnPause;

        public Func<bool, bool> OnStop;

        public Action<double> OnSetCT;

        public Action<string, bool> OnSetOut;

        public Func<string, bool> OnGetIn;

        public Func<string, bool, bool> OnGetEdgeSignal;

        public Func<string, DeviceBase> OnGetDevice;
        
        public StationManager()
        {
            try
            {
                StationList.Add(new ReadSNStation());
                StationList.Add(new TestStation());
                StationList.Add(new NGStation());
                new Task(AxisStateMonitor).Start();
                foreach (StationBase station in StationList)
                {
                    Task task = new Task(station.Run);
                    task.Start();
                }
            }
            catch (Exception ex)
            {
                LogManager.Instance.AddLog($"请检查配置文件的类型是否存在  {ex.Message}");
            }
        }

        public void SetUserRight(string right)
        {
            foreach (StationBase station in StationList)
                station.View.SetEnable(right != "操作员");
        }

        public void RegisterEvents()
        {
            foreach (StationBase station in StationList)
            {
                station.OnAddSN = AddSN;
                station.OnGetStep = GetStep;
                station.OnPause = OnPause;
                station.OnStart = OnStart;
                station.OnStop = OnStop;
                station.OnGetIn = OnGetIn;
                station.OnSetOut = OnSetOut;
                station.OnGetEdgeSignal = OnGetEdgeSignal;
                station.OnGetDevice = OnGetDevice;
            }
        }

        public bool Reset()
        {
            try
            {
                if (StationList == null || StationList.Count == 0)
                    return false;
                LogManager.Instance.AddLog($"开始复位");
                _state = EStationState.RESETING;
                bool ret = true;
                Task[] taskPool = new Task[StationList.Count];
                for (int i = 0; i < StationList.Count; i++)
                {
                    StationList[i].SNQueue.Clear();
                    taskPool[i] = new Task((idx) =>
                    {
                        if (!StationList[(int)idx].Reset())
                            ret = false;
                    }, i);
                    taskPool[i].Start();
                }
                Task.WaitAll(taskPool);
                _state = ret ? EStationState.RESETED : EStationState.STOP;
                LogManager.Instance.AddLog($"复位结束");
                return ret;
            }
            catch (Exception ex)
            {
                LogManager.Instance.AddLog($"工站复位异常：{ex.Message}");
                return false;
            }
        }

        public bool Start()
        {
            try
            {
                if (_state != EStationState.PAUSE && _state != EStationState.RESETED)
                {
                    LogManager.Instance.AddLog($"机台未复位");
                    return false;
                }
                if (StationList == null || StationList.Count == 0)
                    return false;
                foreach (StationBase station in StationList)
                    station.Start();
                LogManager.Instance.AddLog($"设备已启动");
                _state = EStationState.RUNNING;
                return true;
            }
            catch (Exception ex)
            {
                LogManager.Instance.AddLog($"工站启动异常：{ex.Message}");
                return false;
            }
        }

        public bool Pause()
        {
            try
            {
                if (StationList == null || StationList.Count == 0)
                    return false;
                foreach (StationBase station in StationList)
                    station.Pause();
                _state = EStationState.PAUSE;
                LogManager.Instance.AddLog($"设备已暂停");
                return true;
            }
            catch (Exception ex)
            {
                LogManager.Instance.AddLog($"工站暂停异常：{ex.Message}");
                return false;
            }
        }

        public bool Stop()
        {
            try
            {
                if (StationList == null || StationList.Count == 0)
                    return true;
                foreach (StationBase station in StationList)
                    station.Stop();
                _state = EStationState.STOP;
                LogManager.Instance.AddLog($"已停止运行");
                return true;
            }
            catch (Exception ex)
            {
                LogManager.Instance.AddLog($"工站停止异常：{ex.Message}");
                return false;
            }
        }

        public bool End()
        {
            foreach (StationBase station in StationList)
                station.End();
            _state = EStationState.END;
            return true;
        }

        private void AxisStateMonitor()
        {
            while (_state != EStationState.END)
            {
                Thread.Sleep(100);
                foreach (StationBase station in StationList)
                {
                    if (station.Axes == null)
                        continue;
                    foreach (StationAxis axis in station.Axes)
                    {
                        axis.UpdateState();
                        if (_state != EStationState.RUNNING || !axis.IsAlarm) continue;
                        OnStop?.Invoke(false);
                        LogManager.Instance.AddLog($"{station.Name}工站{axis.Name}轴驱动器报警，已停止");
                    }
                }
            }
        }

        private int GetStep(string stationName)
        {
            StationBase station = StationList.Find((s) => s.Name == stationName);
            if (station == null)
            {
                OnStop?.Invoke(false);
                LogManager.Instance.AddLog($"不存在{stationName}");
                return -1;
            }
            return station.Step;
        }

        private void AddSN(string stationName, string sn)
        {
            StationBase station = StationList.Find((s) => s.Name == stationName);
            if (station == null)
            {
                OnStop?.Invoke(false);
                LogManager.Instance.AddLog($"不存在{stationName}");
                return;
            }
            station.SNQueue.Enqueue(sn);
        }
    }
}
