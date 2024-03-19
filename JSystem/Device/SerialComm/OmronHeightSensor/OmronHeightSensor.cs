using System;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JSystem.Device
{
    public class OmronHeightSensor : SerialComm
    {
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
                    _bufferList.Clear();
                    WriteCommand("SR,01,519\r\n");
                    Thread.Sleep(50);
                    byte[] buffer = _bufferList.ToArray();
                    string[] ret = Encoding.ASCII.GetString(buffer).Replace("\r\n", "").Split(',');
                    if (ret.Length == 4 && ret[0] != "ER")
                        _currValue = Convert.ToDouble(ret[3].Trim());
                    else
                        _currValue = 0;
                }
                catch
                {
                    _currValue = 0;
                }
                OnUpdateDisp?.Invoke(_currValue);
            }
        }
        
        public void ChangeBank(string Bank)
        {
            byte[] WriteBank = new byte[] { 0x53, 0x57, 0xA3, 0xAC, 0x30, 0x31, 0xA3, 0xAC, 0x31, 0x30, 0x37, 0xA3, 0xAC, Encoding.UTF8.GetBytes(Bank)[0], 0x0D, 0x0A };//写入Bank
            WriteCommand(WriteBank);
        }

        public double GetCurrHeight()
        {
            return _currValue;
        }
    }
}
