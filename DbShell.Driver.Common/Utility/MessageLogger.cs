using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DbShell.Driver.Common.Utility
{
    public class LogMessageRecord
    {
        public LogLevel Level { get; set; }
        public string Message { get; set; }
        public DateTime Created { get; set; }
        public string ThreadName { get; set; }
        public string Detail { get; set; }
        public string Category { get; set; }
        public int? Number { get; set; }
        public int Line { get; set; }
        public string Procedure { get; set; }
        public string ProcessId { get; set; }

        private bool _isSentToSystemLogger;

        //public Dictionary<string, string> CustomData { get; set; }

        public LogMessageRecord()
        {
            ThreadName = Thread.CurrentThread.ManagedThreadId.ToString();
            Created = DateTime.Now;
            Detail = "";
            //CustomData = new Dictionary<string, string>();
        }

        public LogMessageRecord(LogLevel level, string message)
            : this()
        {
            Level = level;
            Message = message;
        }

        public void SendToSystemLogger(ILogger logger)
        {
            if (_isSentToSystemLogger) return;
            _isSentToSystemLogger = true;
            logger.Log(Level, 0, this, null, (msg, err) => msg.Message);
        }
    }

    public interface IMessageLogger
    {
        void LogMessage(LogMessageRecord message);
    }

    public class NopMessageLogger : IMessageLogger
    {
        public static readonly NopMessageLogger Instance = new NopMessageLogger();

        public void LogMessage(LogMessageRecord message)
        {
        }
    }
}
