using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Interfaces;
using DbShell.Core.Utility;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Utility;
using Microsoft.Extensions.Logging;

namespace DbShell.Core
{
    /// <summary>
    /// Command used for printing value
    /// </summary>
    public class Echo : RunnableBase, ISingleValueDbShellObject
    {
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
            context.GetLogger<Echo>().LogInformation(text);
            context.Info(text);
        }

        object ISingleValueDbShellObject.SingleValue
        {
            get => Message;
            set => Message = value?.ToString();
        }
    }
}
