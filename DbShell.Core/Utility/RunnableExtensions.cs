using DbShell.Core.Runtime;
using DbShell.Driver.Common.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.Core.Utility
{
    public static class RunnableExtensions
    {
        public static void Run(this IRunnable runnable, IServiceProvider serviceProvider)
        {
            using (var context = new ShellContext(serviceProvider))
            {
                runnable.Run(context);
            }
        }
    }
}
