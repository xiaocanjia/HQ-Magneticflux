using System;
using System.Linq;

namespace JSystem.Device
{
    public class ModbusTcp : TCPClient
    {
        private readonly int TimeOut = 2000;

        public byte SlaveAddr = 1;

        private byte[] _header = { 0x00, 0x00, 0x00, 0x00 };

        private readonly object _lock = new object();

        public ModbusTcp()
        {
            View = new ModbusTcpView(this);
            StatusPanel = new DevStatusPanel(this);
        }
        
        public ModbusTcp(string name) : this()
        {
            Name = name;
        }
        
        public byte[] ReadCoils(ushort addr, ushort count)
        {
            byte[] bAddr = BitConverter.GetBytes(addr);
            byte[] bLength = BitConverter.GetBytes(count);
            byte[] ret = SendCommand(_header.Concat(new byte[] { 0x00, 0x06, SlaveAddr, 0x01, bAddr[1], bAddr[0], bLength[1], bLength[0] }).ToArray());
            if (ret == null) return null;
            return ret.Skip(9).ToArray();
        }

        public bool WriteCoils(ushort addr, byte[] data)
        {
            byte[] bAddr = BitConverter.GetBytes(addr);
            int len = data.Length;
            byte[] bLength = BitConverter.GetBytes(len);
            byte[] buffer = _header.Concat(new byte[] { 0x00, (byte)(7 + len * 2), SlaveAddr, 0x0F, bAddr[1], bAddr[0], bLength[1], bLength[0] }).ToArray();
            buffer.Concat(data);
            if (SendCommand(buffer) != null)
                return true;
            return false;
        }

        /// <summary>
        /// 保持寄存器可以读和写，每个寄存器是16位，输入寄存器是只允许读的
        /// </summary>
        /// <param name="addr"></param>
        /// <param name="count"></param>
        /// <returns></returns>
        public bool WriteHoldingRegisters(ushort addr, ushort[] data)
        {
            byte[] bAddr = BitConverter.GetBytes(addr);
            int len = data.Length;
            byte[] bLength = BitConverter.GetBytes(len);
            byte[] buffer = _header.Concat(new byte[] { 0x00, (byte)(7 + len * 2), SlaveAddr, 0x10, bAddr[1], bAddr[0], bLength[1], bLength[0], (byte)(len * 2) }).ToArray();
            for (int i = 0; i < len; i++)
            {
                byte[] bData = BitConverter.GetBytes(data[i]);
                buffer = buffer.Concat(bData.Reverse()).ToArray();
            }
            if (SendCommand(buffer) != null)
                return true;
            return false;
        }

        public ushort[] ReadHoldingRegisters(ushort addr, ushort count)
        {
            byte[] bAddr = BitConverter.GetBytes(addr);
            byte[] bLength = BitConverter.GetBytes(count);
            byte[] ret = SendCommand(_header.Concat(new byte[] { 0x00, 0x06, SlaveAddr, 0x03, bAddr[1], bAddr[0], bLength[1], bLength[0] }).ToArray());
            if (ret == null) return null;
            ushort[] data = new ushort[ret[8] / 2];
            for (int i = 0; i < ret[8] / 2; i++)
                data[i] = BitConverter.ToUInt16(new byte[] { ret[10 + i * 2], ret[9 + i * 2] }, 0);
            return data;
        }

        private byte[] SendCommand(byte[] data)
        {
            lock(_lock)
            {
                WriteData(data);
                DateTime start = DateTime.Now;
                byte retLength = 0;
                while (true)
                {
                    if (retLength == 0 && ReadBuffer().Count >= 6)
                        retLength = ReadBuffer()[5];
                    if (ReadBuffer().Count >= 6 + retLength)
                    {
                        byte[] ret = ReadBuffer().ToArray();
                        ClearBuffer();
                        return ret;
                    }
                    if (DateTime.Now.Subtract(start).TotalMilliseconds > TimeOut)
                    {
                        ClearBuffer();
                        return null;
                    }
                }
            }
        }
    }
}
