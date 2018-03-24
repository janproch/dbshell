using DbShell.Core.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using DbShell.Driver.Common.Interfaces;
using Microsoft.Extensions.Logging;

namespace DbShell.Core
{
    public class Include : RunnableBase
    {
        public string File { get; set; }

        protected override void DoRun(IShellContext context)
        {
            string file = context.Replace(File);
            context.GetLogger<RunnableBase>().LogInformation("DBSH-00005 Including file {file}", file);
            context.IncludeFile(context.ResolveFile(File, ResolveFileMode.DbShell));
        }
    }
}
