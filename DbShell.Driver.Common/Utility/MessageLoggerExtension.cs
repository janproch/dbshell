using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Driver.Common.Utility
{
    public static class MessageLoggerExtension
    {
        public static LogMessageRecord LogMessage(this IMessageLogger logger, LogLevel level, string message)
        {
            LogMessageRecord rec = new LogMessageRecord(level, message);
            logger?.LogMessage(rec);
            return rec; ;
        }
        public static LogMessageRecord LogMessage(this IMessageLogger logger, string category, LogLevel level, string format, params object[] args)
        {
            string msg = format;
            if (args.Length > 0) msg = String.Format(format, args);
            var rec = new LogMessageRecord { Category = category, Message = msg, Level = level };
            logger?.LogMessage(rec);
            return rec;
        }
        public static LogMessageRecord LogMessageDetail(this IMessageLogger logger, string category, LogLevel level, string message, string detail)
        {
            var rec = new LogMessageRecord { Category = category, Message = message, Detail = detail, Level = level };
            logger?.LogMessage(rec);
            return rec;
        }
        public static LogMessageRecord LogMessageEx(this IMessageLogger logger, LogMessageRecord rec)
        {
            logger.LogMessage(rec);
            return rec;
        }
        public static LogMessageRecord Trace(this IMessageLogger logger, string message)
        {
            return logger.LogMessage(LogLevel.Trace, message);
        }
        public static LogMessageRecord Trace(this IMessageLogger logger, string message, params object[] args)
        {
            return logger.LogMessage(LogLevel.Trace, String.Format(message, args));
        }

        public static LogMessageRecord Debug(this IMessageLogger logger, string message)
        {
            return logger.LogMessage(LogLevel.Debug, message);
        }
        public static LogMessageRecord Debug(this IMessageLogger logger, string message, params object[] args)
        {
            return logger.LogMessage(LogLevel.Debug, String.Format(message, args));
        }

        public static LogMessageRecord Info(this IMessageLogger logger, string message)
        {
            return logger.LogMessage(LogLevel.Information, message);
        }
        public static LogMessageRecord Info(this IMessageLogger logger, string message, params object[] args)
        {
            return logger.LogMessage(LogLevel.Information, String.Format(message, args));
        }

        public static LogMessageRecord Warning(this IMessageLogger logger, string message)
        {
            return logger.LogMessage(LogLevel.Warning, message);
        }
        public static LogMessageRecord Warning(this IMessageLogger logger, string message, params object[] args)
        {
            return logger.LogMessage(LogLevel.Warning, String.Format(message, args));
        }

        public static LogMessageRecord Error(this IMessageLogger logger, string message)
        {
            return logger.LogMessage(LogLevel.Error, message);
        }
        public static LogMessageRecord Error(this IMessageLogger logger, string message, params object[] args)
        {
            return logger.LogMessage(LogLevel.Error, String.Format(message, args));
        }
    }
}
