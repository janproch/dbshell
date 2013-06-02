using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Core.Utility;
using log4net;

namespace DbShell.Core
{
    /// <summary>
    /// Command used for printing value
    /// </summary>
    public class Echo : RunnableBase
    {
        private static ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Gets or sets the message to be printed.
        /// </summary>
        /// <value>
        /// The printed message.
        /// </value>
        public string Message { get; set; }

        protected override void DoRun()
        {
            string text = Replace(Message);
            _log.Info(text);
            Context.OutputMessage(text);
        }
    }
}
