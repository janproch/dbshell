using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Driver.Common.Utility
{
    public enum LogSeverity
    {
        Info,
        Error,
    }

    public class LogRecord
    {
        public LogSeverity Severity;
        public string Message;
    }
}
