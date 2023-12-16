using System;
using System.Diagnostics;
using Newtonsoft.Json;
using System.Collections.Generic;

namespace JSystem.Device
{
    public class Cmd : DeviceBase
    {
        private bool _isConnected = false;

        private Process _process;
        
        private List<string> _bufferList = new List<string>();
        
        [JsonIgnore]
        public Action<string> OnDispMsg;

        public Cmd()
        {
            View = new CmdView(this);
            StatusPanel = new DevStatusPanel(this);
        }

        public Cmd(string name) : this()
        {
            Name = name;
        }

        public override bool Connect()
        {
            try
            {
                _process = new Process();
                _process.StartInfo.CreateNoWindow = true;
                _process.StartInfo.UseShellExecute = false;
                _process.StartInfo.WindowStyle = ProcessWindowStyle.Hidden;
                _process.StartInfo.FileName = "cmd.exe";
                _process.StartInfo.RedirectStandardInput = true;
                _process.StartInfo.RedirectStandardError = true;
                _process.StartInfo.RedirectStandardOutput = true;
                _process.OutputDataReceived += OutputDataReceived;
                _process.ErrorDataReceived += ErrorDataReceived;
                _process.Start();
                _process.BeginOutputReadLine();
                _process.BeginErrorReadLine();
                _isConnected = true;
                return true;
            }
            catch
            {
                return false;
            }
        }

        private void ErrorDataReceived(object sender, DataReceivedEventArgs e)
        {
            _bufferList.Add(e.Data);
            OnDispMsg(e.Data);
        }

        private void OutputDataReceived(object sender, DataReceivedEventArgs e)
        {
            if (e.Data != null)
            {
                _bufferList.Add(e.Data);
                OnDispMsg(e.Data);
            }
        }

        public override void DisConnect()
        {
            try
            {
                _process?.CancelErrorRead();
                _process?.CancelOutputRead();
                _process?.Close();
                _process?.Dispose();
                _isConnected = false;
            }
            catch
            {
            }
        }

        public override bool CheckConnection()
        {
            OnUpdateStatus?.Invoke(_isConnected);
            return _isConnected;
        }

        private List<string> ReadBuffer()
        {
            return _bufferList;
        }

        public void WriteCommand(string cmd)
        {
            if (!_isConnected)
                return;
            _process.StandardInput.WriteLine(cmd);
            _process.StandardInput.AutoFlush = true;
        }

        public void ClearBuffer()
        {
            _bufferList.Clear();
        }
    }
}
