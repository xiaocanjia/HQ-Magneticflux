using System;
using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;

namespace JSystem.Device
{
    public class DeviceManager
    {
        private List<DeviceBase> _deviceList = new List<DeviceBase>();

        public List<DeviceBase> DeviceList
        {
            get { return _deviceList; }
            set
            {
                for (int i = 0; i < _deviceList.Count; i++)
                {
                    _deviceList[i].DisConnect();
                    _deviceList[i] = value.FindLast((d) => d.Name == _deviceList[i].Name && d.GetType() == _deviceList[i].GetType()) ?? _deviceList[i];
                }
            }
        }
        
        public Action<string> OnSetUserRight;

        public Action<string, bool> OnSetOut;

        private bool _isMonitor = false;

        public DeviceManager()
        {
            _deviceList.Add(new Board("HY轴卡1"));
            _deviceList.Add(new Board("HY轴卡2"));
            _deviceList.Add(new MesSys("Mes系统"));
            _deviceList.Add(new Board("华亚IO卡"));
            _deviceList.Add(new ScanningGun("扫码枪1"));
            _deviceList.Add(new ScanningGun("扫码枪2"));
            _deviceList.Add(new ScanningGun("扫码枪3"));
            _deviceList.Add(new ScanningGun("扫码枪4"));
            _deviceList.Add(new MagneticFlux("磁通计1"));
            _deviceList.Add(new MagneticFlux("磁通计2"));
        }

        public DeviceBase GetDevice(string name)
        {
            return _deviceList.Find((device) => device.Name == name);
        }

        public bool Init()
        {
            bool ret = true;
            foreach (DeviceBase device in _deviceList)
            {
                if (device.CheckConnection())
                    continue;
                if (!device.Connect())
                {
                    ret &= false;
                    continue;
                }
            }
            new Task(DevicesMonitor).Start();
            _isMonitor = true;
            return ret;
        }

        public void UnInit()
        {
            _isMonitor = false;
            foreach (DeviceBase device in _deviceList)
                device.DisConnect();
        }

        private void DevicesMonitor()
        {
            while (_isMonitor)
            {
                Thread.Sleep(500);
                foreach (DeviceBase device in DeviceList)
                {
                    if (!_isMonitor) return;
                    device.CheckConnection();
                }
            }
        }

        public void SetUserRight(string right)
        {
            foreach (DeviceBase device in _deviceList)
                device.SetUserRight(right);
        }
    }
}
