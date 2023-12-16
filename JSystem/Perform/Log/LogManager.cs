using System;
using JLogging;
using System.Runtime.CompilerServices;

namespace JSystem.Perform
{
    public class LogManager
    {
        private static LogManager _instance;

        public static LogManager Instance => _instance ?? (_instance = new LogManager());

        public Action<string> OnAddLog;
        
        private readonly object _lock = new object();
        
        public LogManager()
        {
        }

        public void AddLog(string msg, bool isError = false, [CallerFilePath] string filePath = "",
            [CallerMemberName] string caller = "", [CallerLineNumber] int lineNum = 0)
        {
            lock(_lock)
            {
                LoggingIF.Log(msg, isError ? LogLevels.Error : LogLevels.Info, filePath, caller, lineNum);
                OnAddLog?.Invoke(DateTime.Now.ToString("HH:mm:ss:fff  ") + msg.ToString() + "\r\n");
            }
        }
    }
}
