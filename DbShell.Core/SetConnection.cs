using DbShell.Core.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using DbShell.Driver.Common.Interfaces;

namespace DbShell.Core
{
    public class SetConnection : RunnableBase
    {
        public string DefaultConnection { get; set; }

        protected override void DoRun(IShellContext context)
        {
            context.SetDefaultConnection(context.Replace(DefaultConnection));
        }
    }
}
