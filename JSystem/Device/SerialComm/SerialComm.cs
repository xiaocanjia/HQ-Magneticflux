using System;
using System.IO.Ports;
using System.Collections.Generic;
using Newtonsoft.Json;
using JLogging;
using System.Text;

namespace JSystem.Device
{
    public class SerialComm : DeviceBase
    {
        private SerialPort _port;

        public string PortName = "COM1";

        public int BaudRate = 115200;

        public int DataBits = 8;

        public StopBits StopBits = StopBits.One;

        public Parity Parity = Parity.None;

        protected List<byte> _bufferList = new List<byte>();

        protected int _maxBytes = 4096;

        [JsonIgnore]
        public bool IsDisplay = false;

        [JsonIgnore]
        public bool IsHex = false;

        [JsonIgnore]
        public Action<string> OnDispMsg;

        public SerialComm()
        {
        }

        public SerialComm(string name)
        {
            View = new SerialCommView(this);
            StatusPanel = new DevStatusPanel(this);
            Name = name;
        }

        public override bool Connect()
        {
            try
            {
                if (!IsEnable) return true;
                _port = new SerialPort
                {
                    PortName = PortName,
                    BaudRate = BaudRate,
                    DataBits = DataBits,
                    StopBits = StopBits,
                    Parity = Parity
                };
                _port.DataReceived += PortDataReceived;
                _port.RtsEnable = true;
                _port.DtrEnable = true;
                _port.Open();
                return true;
            }
            catch
            {
                return false;
            }
        }

        public virtual void WriteCommand(string cmd)
        {
            if (!CheckConnection())
                return;
            _port?.Write(cmd);
        }

        public virtual void WriteCommand(byte[] cmd)
        {
            if (!CheckConnection())
                return;
            _port?.Write(cmd, 0, cmd.Length);
        }

        public List<byte> ReadBuffer()
        {
            return _bufferList;
        }

        public void ClearBuffer()
        {
            if (!IsEnable || !CheckConnection())
                return;
            _bufferList.Clear();
            _port?.DiscardInBuffer();
        }

        public override void DisConnect()
        {
            _port?.Close();
            _port?.Dispose();
            _bufferList.Clear();
        }

        public override bool CheckConnection()
        {
            bool isConnect = _port == null ? false : _port.IsOpen;
            OnUpdateStatus?.Invoke(isConnect);
            return isConnect;
        }

        private void PortDataReceived(object sender, SerialDataReceivedEventArgs e)
        {
            try
            {
                if (_port.BytesToRead == 0)
                    return;
                if (_bufferList.Count > _maxBytes)
                    _bufferList.Clear();
                byte[] dataBytes = new byte[_port.BytesToRead];
                _port.Read(dataBytes, 0, dataBytes.Length);
                _bufferList.AddRange(dataBytes);
                if (!IsDisplay) return;
                string msg = "";
                if (IsHex)
                    foreach (byte b in dataBytes) msg += b.ToString("X2") + " ";
                else
                    msg = Encoding.Default.GetString(dataBytes).Replace('\0', ' ').Replace('\r', ' ').Replace('\n', ' ') + " ";
                OnDispMsg?.Invoke("收->" + msg);
            }
            catch (Exception ex)
            {
                LoggingIF.Log(ex.Message, LogLevels.Error);
            }
        }
    }
}
