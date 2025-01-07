using System;
using System.IO;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using JSystem.Param;
using JSystem.Perform;
using Serilizer;
using JSystem.Device;

namespace JSystem.IO
{
    public class IOManager
    {
        public Action<string> OnSetUserRight;

        private bool _isStart = false;

        public Func<bool> OnInit;

        public Func<bool> OnStart;

        public Func<bool, bool> OnStop;

        public Func<bool, bool> OnPause;

        public Func<int, bool> OnSwitchScene;

        private bool _isMonitor = true;

        public IOsParam IOsParams { private set; get; }

        public Func<string, DeviceBase> OnGetDevice;

        public IOManager()
        {
            string cfgPath = AppDomain.CurrentDomain.BaseDirectory + "Config\\IOParam.json";
            if (!File.Exists(cfgPath))
                throw new Exception("IOParam.json不存在");
            IOsParams = JsonSerializer.Deserilize<IOsParam>(cfgPath);
            new Task(MonitorIO).Start();
        }

        public void Start()
        {
            _isStart = true;
        }

        public void Stop()
        {
            _isStart = false;
        }

        public void UnInit()
        {
            _isMonitor = false;
        }

        public void SetUserRight(string right)
        {
            OnSetUserRight(right);
        }

        public void SetOut(string name, bool isOn)
        {
            DOParam Do = IOsParams.DOsParam.FirstOrDefault((d) => d.Name == name);
            if (Do == null)
                throw new Exception($"未能找到名称为{name}的输出信号");
            if (OnGetDevice == null) return;
            ((Board)OnGetDevice(Do.BoardName)).SetOut(Do.AxisIndex, Do.PointIndex, isOn);
        }

        public bool GetOut(string name)
        {
            DOParam Do = IOsParams.DOsParam.FirstOrDefault((d) => d.Name == name);
            if (Do == null)
                throw new Exception($"未能找到名称为{name}的输出信号");
            if (OnGetDevice == null) return false;
            return ((Board)OnGetDevice(Do.BoardName)).GetOut(Do.AxisIndex, Do.PointIndex);
        }

        public bool GetIn(string name)
        {
            DIParam Di = IOsParams.DIsParam.FirstOrDefault((d) => d.Name == name);
            if (Di == null)
                throw new Exception($"未能找到名称为{name}的输入信号");
            if (OnGetDevice == null) return false;
            return ((Board)OnGetDevice(Di.BoardName)).GetIn(Di.AxisIndex, Di.PointIndex);
        }

        public bool GetEdgeSignal(string name, bool isRising)
        {
            DIParam Di = IOsParams.DIsParam.FirstOrDefault((d) => d.Name == name);
            if (Di == null)
                throw new Exception($"未能找到名称为{name}的输入信号");
            if (OnGetDevice == null) return false;
            bool di = ((Board)OnGetDevice(Di.BoardName)).GetIn(Di.AxisIndex, Di.PointIndex);
            bool ret = isRising ? (!Di.State && di) : (Di.State && !di);
            Di.State = di;
            return ret;
        }

        private void MonitorIO()
        {
            while (_isMonitor)
            {
                Thread.Sleep(10);
                if (OnGetDevice == null)
                    continue;
                if (GetEdgeSignal("复位按钮", true) )
                    OnInit?.Invoke();
                if (GetEdgeSignal("启动按钮", true))
                    OnStart?.Invoke();
                if (GetEdgeSignal("暂停按钮", true))
                    OnPause?.Invoke(true);
                if (!_isStart) continue;
                if (!GetIn("急停按钮"))
                {
                    LogManager.Instance.AddLog($"急停被按下");
                    OnStop?.Invoke(false);
                }
                if (CheckDoorIsOpen())
                {
                    OnPause?.Invoke(true);
                    SetOut("蜂鸣器", true);
                }
            }
        }

        public bool CheckDoorIsOpen()
        {
            if (!ParamManager.GetBoolParam("禁用安全门") && (!GetIn("前门禁") || !GetIn("后门禁") || !GetIn("左门禁") || !GetIn("右门禁")))
            {
                LogManager.Instance.AddLog("检查到安全门被打开");
                return true;
            }
            return false;
        }
    }
}
