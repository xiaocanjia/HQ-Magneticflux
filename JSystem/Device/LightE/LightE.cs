using System;
using System.IO;
using Newtonsoft.Json;
using System.Linq;
using System.Text;
using System.Diagnostics;
using System.Threading;
using System.Threading.Tasks;

namespace JSystem.Device
{
    public class LightE : DeviceBase
    {
        private int _hDevice;                       //控制器句柄

        private bool _isConnected = false;

        public string CurrSN = "";

        public string ConfigPath = "";

        public string CalibPath = "";

        public int chnCount = 0;

        public int ReadCount = 10;

        public int TimeOut = 10000;

        private object m_CaptureObj = new object();
        
        [JsonIgnore]
        public Action OnDispHeight;

        public double[] HeightArr { get; private set; }

        public LightE()
        {
            LEConfocalDLL.LE_InitDLL();     //初始化传感器DLL 
            View = new LightEView(this);
            StatusPanel = new DevStatusPanel(this);
        }

        public LightE(string name) : this()
        {
            Name = name;
        }

        public override bool Connect()
        {
            try
            {
                if (!IsEnable)
                    return true;
                if (!File.Exists(ConfigPath) || !File.Exists(CalibPath))
                    return false;
                LEConfocalDLL.LE_SelectDeviceType(2);                                                           //选择需使用的控制器类型接口，当前选择USB2代控制器
                char[] sn = new char[32];
                Array.Copy(CurrSN.Trim('\0').ToCharArray(), sn, CurrSN.Trim('\0').ToCharArray().Length);
                int ret = LEConfocalDLL.LE_Open(sn, ref _hDevice);
                if (ret != 1) return false;
                ret += LEConfocalDLL.LE_LoadDeviceConfigureFromFile(new StringBuilder(ConfigPath), _hDevice); //载入控制器配置文件，该文件必须路径正确且与当前使用控制器序号匹配
                ret += LEConfocalDLL.LE_LoadLWCalibrationData(new StringBuilder(CalibPath), _hDevice);
                chnCount = LEConfocalDLL.LE_GetChannels(_hDevice);
                HeightArr = new double[chnCount];
                _isConnected = ret > 0;
                if (ret > 0)
                    new Task(DataMonitor).Start();
                return _isConnected;
            }
            catch
            {
                return false;
            }
        }

        public override void DisConnect()
        {
            LEConfocalDLL.LE_Close(ref _hDevice);
            _isConnected = false;
        }

        public override bool CheckConnection()
        {
            OnUpdateStatus?.Invoke(_isConnected);
            return _isConnected;
        }

        private void DataMonitor()
        {
            int readCount = 5;
            if (Monitor.TryEnter(m_CaptureObj, 1000))
            {
                while (_isConnected)
                {
                    int iSta = 0;
                    int currCount = 0;
                    double[][] rawData = new double[chnCount][];
                    //开始采集数据
                    for (int i = 0; i < chnCount; ++i)
                    {
                        rawData[i] = new double[readCount];
                        iSta = LEConfocalDLL.LE_SetChannelGetAllValues(rawData[i], readCount, _hDevice, i + 1);
                    }
                    iSta = LEConfocalDLL.LE_StartGetChannelsValues(_hDevice);
                    Stopwatch sw = new Stopwatch();
                    sw.Restart();
                    //检测当前采集任务是否采集完成循环,测试临时注释while循环
                    while (currCount < readCount)
                    {
                        iSta = LEConfocalDLL.LE_GetCapturedPoints(ref currCount, _hDevice);
                        Thread.Sleep(10);
                        if (sw.Elapsed.TotalMilliseconds > TimeOut)
                            break;
                    }
                    sw.Stop();
                    int sta = LEConfocalDLL.LE_GetDeviceStatus(_hDevice);
                    LEConfocalDLL.LE_StopGetPoints(_hDevice);
                    for (int i = 0; i < chnCount; i++)
                        HeightArr[i] = rawData[i].Average() / 1000.0;
                    OnDispHeight?.Invoke();
                }
                Monitor.Exit(m_CaptureObj);
            }
        }
    }
}
