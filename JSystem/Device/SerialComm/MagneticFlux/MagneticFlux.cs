using System;
using System.Threading;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace JSystem.Device
{
    public class MagneticFlux : SerialComm
    {
        readonly byte[] ReadRange = new byte[] { 0x01, 0x00, 0x08, 0xFF, 0x52, 0x44, 0x44, 0x50, 0x48, 0x52, 0x47, 0x52, 0xD2, 0x0D }; //读量程

        readonly byte[] ReadUnit = new byte[] { 0x01, 0x00, 0x08, 0xFF, 0x52, 0x44, 0x44, 0x55, 0x4E, 0x49, 0x54, 0xA1, 0xEC, 0x0D };  //读单位

        readonly byte[] ZeroAdjustment = new byte[] { 0x01, 0x00, 0x0B, 0xFF, 0x57, 0x52, 0x54, 0x41, 0x44, 0x4A, 0x4E, 0x3D, 0x4F, 0x4E, 0xF2, 0x33, 0x0D }; //归零

        readonly byte[] EncoderZeroing = new byte[] { 0x01, 0x00, 0x0B, 0xFF, 0x57, 0x52, 0x54, 0x48, 0x42, 0x53, 0x57, 0x3D, 0x4F, 0x4E, 0x10, 0xE8, 0x0D }; //积分器清零

        readonly byte[] RefreshData = new byte[] { 0x01, 0x00, 0x0E, 0xFF, 0x57, 0x52, 0x54, 0x52, 0x45, 0x46, 0x52, 0x45, 0x53, 0x48, 0x3D, 0x4F, 0x4E, 0x81, 0x5D, 0x0D }; // 刷新

        readonly byte[] ReadRealTimeValue = new byte[] { 0x01, 0x00, 0x0A, 0xFF, 0x52, 0x44, 0x44, 0x4D, 0x56, 0x41, 0x4C, 0x55, 0x45, 0x25, 0xC5, 0x0D };//实时值读取

        readonly byte[] ReadSaveValue = new byte[] { 0x01, 0x00, 0x0A, 0xFF, 0x52, 0x44, 0x44, 0x4D, 0x41, 0x58, 0x56, 0x41, 0x4C, 0x74, 0xA7, 0x0D };//保存值读取

        readonly byte[] ActivelyUploadOn = new byte[] { 0x01, 0x00, 0x0B, 0xFF, 0x57, 0x52, 0x54, 0x54, 0x56, 0x41, 0x4C, 0x3D, 0x4F, 0x4E, 0x2C, 0xBC, 0x0D }; // 实时上传开

        readonly byte[] ActivelyUploadOff = new byte[] { 0x01, 0x00, 0x0C, 0xFF, 0x57, 0x52, 0x54, 0x54, 0x56, 0x41, 0x4C, 0x3D, 0x4F, 0x46, 0x46, 0x32, 0x4D, 0x0D };// 实时上传关

        private double _currValue = 0.0;

        private bool _isOn = true;

        [JsonIgnore]
        public Action<double> OnUpdateDisp;
        
        public MagneticFlux()
        {
            View = new MagneticFluxView(this);
            StatusPanel = new DevStatusPanel(this);
        }

        public MagneticFlux(string name) : this()
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

        public bool SetUnit(string Text)
        {
            if (Text != "")
            {
                byte[] mWb = new byte[] { 0x01, 0x00, 0x0C, 0xFF, 0x57, 0x52, 0x54, 0x55, 0x4E, 0x49, 0x54, 0x3D, 0x6D, 0x57, 0x62, 0x66, 0x7F, 0x0D };
                byte[] mVs = new byte[] { 0x01, 0x00, 0x0C, 0xFF, 0x57, 0x52, 0x54, 0x55, 0x4E, 0x49, 0x54, 0x3D, 0x6D, 0x56, 0x73, 0x57, 0x5E, 0x0D };
                switch (Text)
                {
                    case "mWb":
                        WriteCommand(mWb);
                        break;
                    case "mVs":
                        WriteCommand(mVs);
                        break;
                }
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool SetRange(string Text)
        {
            try
            {
                if (Text != "")
                {
                    byte[] TwomWb = new byte[] { 0x01, 0x00, 0x0D, 0xFF, 0x57, 0x52, 0x54, 0x50, 0x48, 0x52, 0x47, 0x3D, 0x32, 0x6D, 0x57, 0x62, 0x42, 0x03, 0x0D };
                    byte[] TwentymWb = new byte[] { 0x01, 0x00, 0x0E, 0xFF, 0x57, 0x52, 0x54, 0x50, 0x48, 0x52, 0x47, 0x3D, 0x32, 0x30, 0x6D, 0x57, 0x62, 0x70, 0xFE, 0x0D };
                    byte[] TwoHundredmWb = new byte[] { 0x01, 0x00, 0x0F, 0xFF, 0x57, 0x52, 0x54, 0x50, 0x48, 0x52, 0x47, 0x3D, 0x32, 0x30, 0x30, 0x6D, 0x57, 0x62, 0xD0, 0xEE };
                    byte[] TwoWb = new byte[] { 0x01, 0x00, 0x0C, 0xFF, 0x57, 0x52, 0x54, 0x50, 0x48, 0x52, 0x47, 0x3D, 0x32, 0x57, 0x62, 0xCE, 0xB5, 0x0D };

                    byte[] TwomVs = new byte[] { 0x01, 0x00, 0x0D, 0xFF, 0x57, 0x52, 0x54, 0x50, 0x48, 0x52, 0x47, 0x3D, 0x32, 0x6D, 0x56, 0x73, 0x73, 0x22, 0x0D };
                    byte[] TwentymVs = new byte[] { 0x01, 0x00, 0x0E, 0xFF, 0x57, 0x52, 0x54, 0x50, 0x48, 0x52, 0x47, 0x3D, 0x32, 0x30, 0x6D, 0x56, 0x73, 0x41, 0xDF, 0x0D };
                    byte[] TwoHundredmVs = new byte[] { 01, 0x00, 0x0F, 0xFF, 0x57, 0x52, 0x54, 0x50, 0x48, 0x52, 0x47, 0x3D, 0x32, 0x30, 0x30, 0x6D, 0x56, 0x73, 0xE1, 0xCF };
                    byte[] TwoVs = new byte[] { 0x01, 0x00, 0x0C, 0xFF, 0x57, 0x52, 0x54, 0x50, 0x48, 0x52, 0x47, 0x3D, 0x32, 0x56, 0x73, 0xFF, 0x94, 0x0D };
                    switch (Text)
                    {
                        case "2mWb":
                            WriteCommand(TwomWb);
                            break;
                        case "20mWb":
                            WriteCommand(TwentymWb);
                            break;
                        case "200mWb":
                            WriteCommand(TwoHundredmWb);
                            break;
                        case "2Wb":
                            WriteCommand(TwoWb);
                            break;
                        case "2mVs":
                            WriteCommand(TwomVs);
                            break;
                        case "20mVs":
                            WriteCommand(TwentymVs);
                            break;
                        case "200mVs":
                            WriteCommand(TwoHundredmVs);
                            break;
                        case "2Vs":
                            WriteCommand(TwoVs);
                            break;
                        default:
                            return false;
                    }
                    return true;
                }
                else
                {
                    return false;
                }
            }
            catch
            {
                return false;
            }
        }

        private void Monitor()
        {
            while (_isOn)
            {
                try
                {
                    WriteCommand(ReadSaveValue);
                    Thread.Sleep(150);
                    byte[] buffer = _bufferList.ToArray();
                    string ret = Encoding.ASCII.GetString(_bufferList.ToArray());
                    _bufferList.Clear();
                    if (!ret.Contains("="))
                        _currValue = 0.0;
                    else
                        _currValue = Convert.ToDouble(ret.Substring(ret.IndexOf("=") + 1, 7));
                    OnUpdateDisp?.Invoke(_currValue);
                }
                catch
                {
                    OnUpdateDisp?.Invoke(0.0);
                }
            }
        }

        public bool ClearZero()
        {
            try
            {
                WriteCommand(EncoderZeroing);
                return true;
            }
            catch (Exception ex)
            {
                return false;
            }
        }

        public double GetCurrValue()
        {
            return _currValue;
        }
    }
}
