using System;
using System.Text;
using System.Threading;

namespace JSystem.Device
{
    public class ScanningGun : SerialComm
    {
        public string Command = "start";

        public int MaxLength = 27;

        public ScanningGun()
        {
            View = new ScanningGunView(this);
            StatusPanel = new DevStatusPanel(this);
        }

        public ScanningGun(string name) : this()
        {
            Name = name;
        }
        
        public string ReadSN(int timeOut = 1000)
        {
            ClearBuffer();
            WriteCommand(Command);
            DateTime start = DateTime.Now;
            string sn = "";
            while (true)
            {
                Thread.Sleep(10);
                if (_bufferList.Count >= MaxLength)
                {
                    sn = Encoding.ASCII.GetString(_bufferList.ToArray());
                    sn = sn.Substring(0, MaxLength);
                    return sn;
                }
                if (DateTime.Now.Subtract(start).TotalMilliseconds > timeOut)
                    return "";
            }
        }
    }
}

