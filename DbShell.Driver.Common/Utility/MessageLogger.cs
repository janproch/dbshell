using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Driver.Common.Utility
{
    public interface IMessageLogger
    {
        void Trace(string msg, params object[] args);
        void Warning(object msg, params object[] args);
        void Info(object get, params object[] args);
    }

    public class NopMessageLogger : IMessageLogger
    {
        public static readonly NopMessageLogger Instance = new NopMessageLogger();

        public void Trace(string msg, params object[] args)
        {
        }

        public void Warning(object msg, params object[] args)
        {
        }

        public void Info(object msg, params object[] args)
        {
        }
    }
}
