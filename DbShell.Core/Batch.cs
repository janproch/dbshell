using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;

namespace DbShell.Core
{
    /// <summary>
    /// Wrapper for more commands implementing <see cref="IRunnable"/>
    /// </summary>
    public class Batch : RunnableContainer
    {
        protected override void DoRun(IShellContext context)
        {
            RunContainer(context);
        }
    }
}
