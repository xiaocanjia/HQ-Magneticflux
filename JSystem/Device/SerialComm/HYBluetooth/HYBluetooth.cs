using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace JSystem.Device
{
    public class HYBluetooth : SerialComm
    {
        public string GuidTx = "";

        public string GuidRx = "";

        public HYBluetooth()
        {
            View = new SerialCommView(this);
            StatusPanel = new DevStatusPanel(this);
        }

        public HYBluetooth(string name) : this()
        {
            Name = name;
        }

        /// <summary>
        /// BT-Bluetooth
        /// </summary>
        /// <param name="mac"></param>
        public void ConnectBT(string mac)
        {
            base.WriteCommand(GetCommand(0x03, Encoding.Default.GetBytes(mac.Replace(":", "")).Concat(new byte[] { 0x0D, 0x0A }).ToArray()));
        }

        public void DisConnectBT()
        {
            base.WriteCommand(GetCommand(0x04, new byte[0]));
        }

        public override void WriteCommand(byte[] data)
        {
            base.WriteCommand(GetCommand(0x05, data));
        }

        private byte[] GetCommand(byte type, byte[] data)
        {
            List<byte> cmd = new List<byte>();
            cmd.Add(0x48);
            cmd.Add(0x59);
            cmd.Add((byte)(data.Length + 4));
            cmd.Add(type);
            cmd.AddRange(data);
            return cmd.ToArray();
        }
    }
}

