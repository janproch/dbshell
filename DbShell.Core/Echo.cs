using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Utility;
using log4net;

namespace DbShell.Core
{
    /// <summary>
    /// Command used for printing value
    /// </summary>
    public class Echo : RunnableBase
    {
        private static ILog _log = LogManager.GetLogger(typeof(Echo));

        /// <summary>
        /// Gets or sets the message to be printed.
        /// </summary>
        /// <value>
        /// The printed message.
        /// </value>
        [XamlProperty]
        public string Message { get; set; }

        protected override void DoRun(IShellContext context)
        {
            string text = context.Replace(Message);
            _log.Info(text);
            context.OutputMessage(text);
        }
    }
}
