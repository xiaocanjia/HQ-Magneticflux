using System;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace JSystem.Device
{
    public class OmronHeightSensor : SerialComm
    {
        readonly byte[] ReadValue = new byte[] { 0x53, 0x52, 0x2C, 0x30, 0x31, 0x2C, 0x35, 0x31, 0x39, 0x43, 0x52, 0x4C, 0x46, 0x0D, 0x0A }; //读值

        private double _currValue = 0.0;

        private bool _isOn = true;

        [JsonIgnore]
        public Action<double> OnUpdateDisp;
        
        public OmronHeightSensor()
        {
            View = new OmronHeightSensorView(this);
            StatusPanel = new DevStatusPanel(this);
        }

        public OmronHeightSensor(string name) : this()
        {
            Name = name;
        }

        public override bool Connect()
        {
            if (!base.Connect())
                return false;
            _isOn = true;
            new Task(Monitor).Start();
            return true;
        }

        public override void DisConnect()
        {
            _isOn = false;
            base.DisConnect();
        }

        private void Monitor()
        {
            while (_isOn)
            {
                try
                {
                    WriteCommand(ReadValue);
                    Thread.Sleep(150);
                    byte[] buffer = _bufferList.ToArray();
                    _bufferList.Clear();
                    string ret = Encoding.ASCII.GetString(_bufferList.ToArray());
                    if (ret == "")
                        _currValue = 0.0;
                    else
                        _currValue = Convert.ToDouble(ret);
                    OnUpdateDisp?.Invoke(_currValue);
                }
                catch
                {
                    OnUpdateDisp?.Invoke(0.0);
                }
            }
        }

        public void ChangeBank(string Bank)
        {
            byte[] WriteBank = new byte[] { 0x53 ,0x57, 0xA3, 0xAC, 0x30, 0x31, 0xA3, 0xAC, 0x31, 0x30, 0x37, 0xA3, 0xAC, Encoding.UTF8.GetBytes(Bank)[0], 0x0D, 0x0A };//写入Bank
            WriteCommand(WriteBank);
        }

        public double GetCurrValue()
        {
            return _currValue;
        }
    }
}
