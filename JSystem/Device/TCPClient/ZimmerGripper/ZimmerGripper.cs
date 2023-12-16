using System;

namespace JSystem.Device
{
    public class ZimmerGripper : ModbusTcp
    {
        private readonly int AddrWrite = 2049;  //端口1的起始地址

        private readonly int Interval = 16;  //两个端口之间的寄存器地址间隔

        public bool IsOn { get; private set; } = false;

        public bool IsOff { get; private set; } = true;

        public ZimmerGripper()
        {
            View = new ZimmerGripperView(this);
            StatusPanel = new DevStatusPanel(this);
        }

        public ZimmerGripper(string name) : this()
        {
            Name = name;
        }

        public void SwitchGripper(int channel, bool isOn, ushort pos, byte tolerance = 0xff, byte force = 0x01)
        {
            if (!CheckConnection()) return;
            ushort[] data = { 0x0001, 0x6400, pos, BitConverter.ToUInt16(new byte[] { tolerance, force }, 0) };
            WriteHoldingRegisters((ushort)(AddrWrite + channel * Interval), data);
            data[0] = (ushort)(isOn ? 0x0200 : 0x0100);
            WriteHoldingRegisters((ushort)(AddrWrite + channel * Interval), data);
        }

        public ushort[] GetStatus(int channel)
        {
            ushort[] input = ReadHoldingRegisters((ushort)(2 + channel * 16), 3);
            IsOn = ((input[0] >> 10) & 1) == 1;
            IsOff = ((input[0] >> 8) & 1) == 1;
            return input;
        }
    }
}
