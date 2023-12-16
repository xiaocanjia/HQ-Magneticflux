using System;
using System.Net;
using System.Net.Sockets;
using System.Threading;
using System.Collections.Generic;
using Newtonsoft.Json;
using JLogging;

namespace JSystem.Device
{
    public class TCPClient : DeviceBase
    {
        private byte[] _buffer;

        protected int _maxLength = 4096;

        private List<byte> _bufferList = new List<byte>();

        protected Socket _socket = null;

        private readonly ManualResetEvent TimeoutObject = new ManualResetEvent(false);

        public string IP = "127.0.0.1";

        public int Port = 8088;

        [JsonIgnore]
        public Action<byte[]> OnDispMsg;

        public TCPClient()
        {
            View = new TCPClientView(this);
            StatusPanel = new DevStatusPanel(this);
        }

        public TCPClient(string name) : this()
        {
            Name = name;
        }

        public override bool Connect()
        {
            try
            {
                if (!IsEnable) return true;
                _buffer = new byte[_maxLength];
                _socket = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
                TimeoutObject.Reset();
                IPEndPoint remoteEndPoint = new IPEndPoint(IPAddress.Parse(IP), Port);
                _socket.BeginConnect(remoteEndPoint, CallBackMethod, new object());
                if (!TimeoutObject.WaitOne(100, false))
                    return false;
                _socket.BeginReceive(_buffer, 0, _maxLength, SocketFlags.None, new AsyncCallback(ReceiveMessage), _socket);
                return true;
            }
            catch
            {
                return false;
            }
        }

        public override void DisConnect()
        {
            _socket?.Close();
        }

        public override bool CheckConnection()
        {
            bool isConnect = !(_socket == null || !_socket.Connected || (_socket.Poll(1000, SelectMode.SelectRead) && _socket.Available == 0));
            OnUpdateStatus?.Invoke(isConnect);
            return isConnect;
        }

        /// <summary>
        /// 接收某一个客户端的消息
        /// </summary>
        /// <param name="ar"></param>
        private void ReceiveMessage(IAsyncResult ar)
        {
            try
            {
                if (!CheckConnection())
                    return;
                int length = _socket.EndReceive(ar);
                byte[] data = new byte[length];
                Array.Copy(_buffer, data, length);
                OnDispMsg?.Invoke(data);
                _bufferList.AddRange(data);
                //接收下一个消息(因为这是一个递归的调用，所以这样就可以一直接收消息）异步
                _socket.BeginReceive(_buffer, 0, _buffer.Length, SocketFlags.None, new AsyncCallback(ReceiveMessage), _socket);
            }
            catch (Exception ex)
            {
                LoggingIF.Log(ex.Message);
            }
        }

        public bool WriteData(byte[] data)
        {
            if (!CheckConnection())
                return false;
            _socket?.Send(data);
            return true;
        }

        public List<byte> ReadBuffer()
        {
            return _bufferList;
        }

        public void ClearBuffer()
        {
            _bufferList.Clear();
        }

        private void CallBackMethod(IAsyncResult asyncresult)
        {
            TimeoutObject.Set();
        }
    }
}
