using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;
using log4net;

namespace DbShell.Core
{
    public abstract class RunnableBase : ElementBase, IRunnable
    {
        private static ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected abstract void DoRun();

        /// <summary>
        /// Gets or sets the list of required files.
        /// </summary>
        /// <value>
        /// The ';' delimited list of required files.
        /// </value>
        public string Requires { get; set; }

        void IRunnable.Run()
        {
            if (Requires != null)
            {
                foreach (string file in Requires.Split(';'))
                {
                    if (String.IsNullOrEmpty(file)) continue;
                    _log.InfoFormat("DBSH-00005 Including file {0}", file);
                    Context.IncludeFile(file, this);
                }
            }

            DoRun();
        }
    }
}
