using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Driver.Common.Utility
{
    public static class MessageLoggerExtension
    {
        public static void LogMessage(this IMessageLogger logger, MessageLogLevel level, string message)
        {
            if (logger == null) return;
            LogMessageRecord rec = new LogMessageRecord(level, message);
            logger.LogMessage(rec);
        }
        public static void LogMessage(this IMessageLogger logger, string category, MessageLogLevel level, string format, params object[] args)
        {
            if (logger == null) return;
            string msg = format;
            if (args.Length > 0) msg = String.Format(format, args);
            logger.LogMessage(new LogMessageRecord { Category = category, Message = msg, Level = level });
        }
        public static void LogMessageDetail(this IMessageLogger logger, string category, MessageLogLevel level, string message, string detail)
        {
            if (logger == null) return;
            logger.LogMessage(new LogMessageRecord { Category = category, Message = message, Detail = detail, Level = level });
        }
        public static void LogMessageEx(this IMessageLogger logger, LogMessageRecord rec)
        {
            logger.LogMessage(rec);
        }
        public static void Trace(this IMessageLogger logger, string message)
        {
            logger.LogMessage(MessageLogLevel.Trace, message);
        }
        public static void Trace(this IMessageLogger logger, string message, params object[] args)
        {
            logger.LogMessage(MessageLogLevel.Trace, String.Format(message, args));
        }

        public static void Debug(this IMessageLogger logger, string message)
        {
            logger.LogMessage(MessageLogLevel.Debug, message);
        }
        public static void Debug(this IMessageLogger logger, string message, params object[] args)
        {
            logger.LogMessage(MessageLogLevel.Debug, String.Format(message, args));
        }

        public static void Info(this IMessageLogger logger, string message)
        {
            logger.LogMessage(MessageLogLevel.Info, message);
        }
        public static void Info(this IMessageLogger logger, string message, params object[] args)
        {
            logger.LogMessage(MessageLogLevel.Info, String.Format(message, args));
        }

        public static void Warning(this IMessageLogger logger, string message)
        {
            logger.LogMessage(MessageLogLevel.Warning, message);
        }
        public static void Warning(this IMessageLogger logger, string message, params object[] args)
        {
            logger.LogMessage(MessageLogLevel.Warning, String.Format(message, args));
        }

        public static void Error(this IMessageLogger logger, string message)
        {
            logger.LogMessage(MessageLogLevel.Error, message);
        }
        public static void Error(this IMessageLogger logger, string message, params object[] args)
        {
            logger.LogMessage(MessageLogLevel.Error, String.Format(message, args));
        }
    }
}
