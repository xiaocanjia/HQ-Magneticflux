using System.Threading;

namespace JSystem.Device
{
    public class BleBluetooth : SerialComm
    {
        public string GuidTx = "";

        public string GuidRx = "";

        public BleBluetooth()
        {
            View = new BleBluetoothView(this);
            StatusPanel = new DevStatusPanel(this);
        }

        public BleBluetooth(string name) : this()
        {
            Name = name;
        }

        public override bool Connect()
        {
            try
            {
                bool ret = base.Connect();
                WriteCommand($"AT+CHTX{GuidTx}");
                Thread.Sleep(100);
                WriteCommand($"AT+CHRX{GuidRx}");
                Thread.Sleep(100);
                return ret;
            }
            catch
            {
                return false;
            }
        }

        /// <summary>
        /// BT-Bluetooth
        /// </summary>
        /// <param name="mac"></param>
        public void ConnectBT(string mac)
        {
            WriteCommand($"AT+CON{mac}");
        }

        public void DisConnectBT()
        {
            WriteCommand($"AT+DISCON");
            Thread.Sleep(100);
            WriteCommand($"AT+RESET");
            Thread.Sleep(100);
        }
    }
}

