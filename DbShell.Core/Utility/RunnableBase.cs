using System;
using DbShell.Common;
using log4net;

namespace DbShell.Core.Utility
{
    public abstract class RunnableBase : ElementBase, IRunnable
    {
        private static ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        protected abstract void DoRun(IShellContext context);

        /// <summary>
        /// Gets or sets the list of required files.
        /// </summary>
        /// <value>
        /// The ';' delimited list of required files.
        /// </value>
        public string Requires { get; set; }

        void IRunnable.Run(IShellContext context)
        {
            if (Connection != null)
            {
                context = context.CreateChildContext();
                context.SetDefaultConnection(Connection);
            }
            if (Requires != null)
            {
                foreach (string file in Requires.Split(';'))
                {
                    if (String.IsNullOrEmpty(file)) continue;
                    _log.InfoFormat("DBSH-00005 Including file {0}", file);
                    context.IncludeFile(context.ResolveFile(file, ResolveFileMode.DbShell));
                }
            }

            DoRun(context);
        }
    }
}
