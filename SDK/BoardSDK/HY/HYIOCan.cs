using System;
using System.Net.Sockets;
using FileHelper;
using System.Net;
using System.Text;
using System.Threading;
using System.Text.RegularExpressions;

namespace BoardSDK
{
    public class HYIOCan : IBoard
    {
        protected Socket _socket = null;

        private string _filePath = "";

        private bool[] _isOn;

        private double[] _times;

        private readonly ManualResetEvent TimeoutObject = new ManualResetEvent(false);

        private readonly object _lock = new object();

        private IPEndPoint _remoteEndPoint;

        public bool Connect(string filePath)
        {
            try
            {
                _filePath = filePath;
                string IP = GetCfgValue("DeviceConfig", "IP");
                int port = Convert.ToInt32(GetCfgValue("DeviceConfig", "Port"));
                int axesCount = Convert.ToInt32(GetCfgValue("DeviceConfig", "AxesCount"));
                TimeoutObject.Reset();
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
                _remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), port);
                _socket.ReceiveTimeout = 1000;
                _socket.BeginConnect(_remoteEndPoint, CallBackMethod, new object());
                if (!TimeoutObject.WaitOne(2000, false))
                    return false;
                _isOn = new bool[axesCount];
                _times = new double[axesCount];
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private string GetCfgValue(string section, string key)
        {
            return IniHelper.INIGetStringValue(_filePath, section, key, "");
        }

        public bool Disconnect()
        {
            try
            {
                _socket?.Close();
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool CheckConnect()
        {
            if (_socket == null) return false;
            return _socket.Connected;
        }

        public bool GetIn(int axisIdx, int IOIdx)
        {
            try
            {
                byte[] ret = SendCmd(new byte[] { 0x48, 0x59, 0x07, 0x00, (byte)(0x11 + axisIdx), 0x01, 0x09 });
                return (ret[10 - IOIdx / 8] & (1 << (IOIdx % 8))) == 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool GetOut(int axisIdx, int IOIdx)
        {
            try
            {
                byte[] ret = SendCmd(new byte[] { 0x48, 0x59, 0x07, 0x00, (byte)(0x21 + axisIdx), 0x01, 0x09 });
                return (ret[10 - IOIdx / 8] & (1 << (IOIdx % 8))) == 0;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        public bool SetOut(int axisIdx, int IOIdx, bool value)
        {
            try
            {
                byte[] ret = SendCmd(new byte[] { 0x48, 0x59, 0x0C, 0x00, (byte)(0x11 + axisIdx), 0x09, 0x49, 0x01, (byte)IOIdx, (byte)(value ? 0x01 : 0x00), 0x00, 0x00 });
                return true;
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        private byte[] IntToByte(int value)
        {
            byte[] buffer = new byte[4];
            buffer[0] = (byte)((value >> 24) & 0xFF);
            buffer[1] = (byte)((value >> 16) & 0xFF);
            buffer[2] = (byte)((value >> 8) & 0xFF);
            buffer[3] = (byte)((value >> 0) & 0xFF);
            return buffer;
        }

        private byte[] UIntToByte(uint value)
        {
            byte[] buffer = new byte[2];
            buffer[0] = (byte)((value >> 8) & 0xFF);
            buffer[1] = (byte)((value >> 0) & 0xFF);
            return buffer;
        }

        private void CallBackMethod(IAsyncResult asyncresult)
        {
            TimeoutObject.Set();
        }

        private byte[] SendCmd(byte[] data)
        {
            lock (_lock)
            {
                try
                {
                    _socket.Send(data);
                    byte[] buffer = new byte[1024];
                    int length = _socket.Receive(buffer, buffer.Length, SocketFlags.None);
                    byte[] ret = new byte[length];
                    Array.Copy(buffer, ret, length);
                    return ret;
                }
                catch (Exception ex)
                {
                    throw ex;
                }
            }
        }

        public bool ClearAlarm(int axis)
        {
            throw new NotImplementedException();
        }

        public bool SetAxisServoEnabled(int axis, bool isOn)
        {
            throw new NotImplementedException();
        }

        public bool GoHome(int axis, double homeVelL, double homeVelH, double homeAcc, double homeDcc, uint homeMode, uint homeDir)
        {
            throw new NotImplementedException();
        }

        public bool CheckIsStop(int axis)
        {
            throw new NotImplementedException();
        }

        public byte GetAxisState(int axis)
        {
            throw new NotImplementedException();
        }

        public double GetActPos(int axis)
        {
            throw new NotImplementedException();
        }

        public double GetCmdPos(int axis)
        {
            throw new NotImplementedException();
        }

        public bool AbsMove(int axis, double moveVelL, double moveVelH, double moveAcc, double moveDcc, double pos)
        {
            throw new NotImplementedException();
        }

        public bool RelMove(int axis, double moveVelL, double moveVelH, double moveAcc, double moveDcc, double dist)
        {
            throw new NotImplementedException();
        }

        public bool JogMove(int axis, bool isPositive, double moveVelL, double moveVelH, double moveAcc, double moveDcc)
        {
            throw new NotImplementedException();
        }

        public bool Stop(int axis)
        {
            throw new NotImplementedException();
        }

        public bool InstancyStop(int axis)
        {
            throw new NotImplementedException();
        }
    }
}
