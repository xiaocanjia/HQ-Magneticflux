using System;
using JSystem.Perform;
using JSystem.Station;
using JSystem.Device;
using JSystem.IO;
using JSystem.User;
using JSystem.Param;
using JSystem.Project;
using Serilizer;

namespace JSystem
{
    public class SysController
    {
        public EDeviceState CurrState = EDeviceState.UNINIT;

        public Action<EDeviceState> OnUpdateState;

        public SysManagers SysMgrs;

        public ProjectManager ProjectMgr;

        public LoginManager LoginMgr;

        public StationManager StationMgr;

        public DeviceManager DeviceMgr;

        public IOManager IOMgr;

        public ParamManager ParamMgr;

        public Action OnInitUI;

        public Action<bool> OnSetEnable;

        public SysController()
        {
            try
            {
                IOMgr = new IOManager();
                SysMgrs = new SysManagers();
                LoginMgr = new LoginManager();
                ParamMgr = new ParamManager();
                ProjectMgr = new ProjectManager();
                StationMgr = new StationManager();
                DeviceMgr = new DeviceManager();
                RegisterEvents();
            }
            catch (Exception ex)
            {
                LogManager.Instance.AddLog(ex.Message);
            }
        }

        public bool Init()
        {
            if (CurrState == EDeviceState.INITING)
                return false;
            OnUpdateState(EDeviceState.INITING);
            LogManager.Instance.AddLog("开始初始化");
            if (!DeviceMgr.Init())
            {
                OnUpdateState(EDeviceState.EMERGENCY);
                LogManager.Instance.AddLog("设备未全部连接");
                return false;
            }
            if (!StationMgr.Reset())
            {
                OnUpdateState(EDeviceState.EMERGENCY);
                LogManager.Instance.AddLog("初始化失败");
                return false;
            }
            OnUpdateState(EDeviceState.INITED);
            LogManager.Instance.AddLog("初始化完成");
            return true;
        }

        public bool Start()
        {
            if (CurrState == EDeviceState.RUN)
                return true;
            if (CurrState == EDeviceState.UNINIT)
            {
                LogManager.Instance.AddLog("请先初始化");
                return false;
            }
            if (IOMgr.CheckDoorIsOpen())
            {
                LogManager.Instance.AddLog("请先清除报警");
                return false;
            }
            if (!StationMgr.Start())
                return false;
            IOMgr.Start();
            OnSetEnable?.Invoke(false);
            OnUpdateState(EDeviceState.RUN);
            return true;
        }

        public bool Pause(bool isNormal)
        {
            if (CurrState == EDeviceState.PAUSE)
                return true;
            if (!StationMgr.Pause())
                return false;
            IOMgr.Stop();
            OnSetEnable?.Invoke(true);
            if (isNormal)
                OnUpdateState(EDeviceState.PAUSE);
            else
                OnUpdateState(EDeviceState.PAUSEALARM);
            return true;
        }

        public bool Stop(bool isNormal)
        {
            if (StationMgr == null || !StationMgr.Stop())
                return false;
            IOMgr.Stop();
            OnSetEnable?.Invoke(true);
            if (isNormal)
                OnUpdateState(EDeviceState.UNINIT);
            else
                OnUpdateState(EDeviceState.PAUSEALARM);
            return true;
        }
        
        public void UnInit()
        {
            IOMgr.UnInit();
            DeviceMgr.UnInit();
            StationMgr?.End();
            Stop(true);
        }

        private bool SaveProject(string filePath)
        {
            try
            {
                SysMgrs.DeviceList = DeviceMgr.DeviceList;
                SysMgrs.Models = StationMgr.Models;
                SysMgrs.ParamsArray = ParamMgr.ParamsArray;
                JsonSerializer.Serilize(SysMgrs, filePath);
                return true;
            }
            catch (Exception ex)
            {
                LogManager.Instance.AddLog($"项目文件保存失败：{ex.Message}", true);
                return false;
            }
        }

        private bool LoadProject(string filePath)
        {
            try
            {
                Stop(true);
                SysMgrs = JsonSerializer.Deserilize<SysManagers>(filePath);
                DeviceMgr.DeviceList = SysMgrs.DeviceList ?? DeviceMgr.DeviceList;
                StationMgr.Models = SysMgrs.Models ?? StationMgr.Models;
                ParamMgr.ParamsArray = SysMgrs.ParamsArray ?? ParamMgr.ParamsArray;
                OnInitUI?.Invoke();
                return true;
            }
            catch (Exception ex)
            {
                LogManager.Instance.AddLog($"项目文件加载失败：{ex.Message}", true);
                return false;
            }
        }

        public void RegisterEvents()
        {
            IOMgr.OnInit = Init;
            IOMgr.OnStart = Start;
            IOMgr.OnStop = Stop;
            IOMgr.OnPause = Pause;
            IOMgr.OnGetDevice = DeviceMgr.GetDevice;
            DeviceMgr.OnSetOut = IOMgr.SetOut;
            StationMgr.OnStart = Start;
            StationMgr.OnStop = Stop;
            StationMgr.OnPause = Pause;
            StationMgr.OnGetDevice = DeviceMgr.GetDevice;
            StationMgr.OnGetIn = IOMgr.GetIn;
            StationMgr.OnSetOut = IOMgr.SetOut;
            StationMgr.OnGetEdgeSignal = IOMgr.GetEdgeSignal;
            ProjectMgr.OnLoadProject = LoadProject;
            ProjectMgr.OnSaveProject = SaveProject;
            LoginMgr.OnSetUserRight += IOMgr.SetUserRight;
            LoginMgr.OnSetUserRight += StationMgr.SetUserRight;
            LoginMgr.OnSetUserRight += DeviceMgr.SetUserRight;
            LoginMgr.OnSetUserRight += ProjectMgr.SetUserRight;
            LoginMgr.OnSetUserRight += ParamMgr.SetUserRight;
            StationMgr.RegisterEvents();
        }
    }
}
