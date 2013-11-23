using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace DbShell.Driver.Common.Utility
{
    public enum MessageLogLevel
    {
        All = 0,
        Trace = 10,
        Debug = 20,
        Info = 30,
        Warning = 40,
        Error = 50,
        Fatal = 60,
        Off = 100
    };

    public class LogMessageRecord
    {
        [XmlElem]
        public MessageLogLevel Level { get; set; }
        [XmlElem]
        public string Message { get; set; }
        [XmlElem]
        public DateTime Created { get; set; }
        [XmlElem]
        public string ThreadName { get; set; }
        [XmlElem]
        public string Detail { get; set; }
        [XmlElem]
        public string Category { get; set; }

        public Dictionary<string, string> CustomData { get; set; }

        public LogMessageRecord()
        {
            ThreadName = Thread.CurrentThread.ManagedThreadId.ToString();
            Created = DateTime.Now;
            Detail = "";
            CustomData = new Dictionary<string, string>();
        }

        public LogMessageRecord(MessageLogLevel level, string message)
            : this()
        {
            Level = level;
            Message = message;
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
