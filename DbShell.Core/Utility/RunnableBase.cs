using System;
using DbShell.Driver.Common.Interfaces;
using Microsoft.Extensions.Logging;

namespace DbShell.Core.Utility
{
    public abstract class RunnableBase : ElementBase, IRunnable
    {
        protected abstract void DoRun(IShellContext context);

        void IRunnable.Run(IShellContext context)
        {
            if (Connection != null)
            {
                string connection = context.Replace(Connection);
                context = context.CreateChildContext();
                context.SetDefaultConnection(connection);
            }

            DoRun(context);
        }
    }
}
