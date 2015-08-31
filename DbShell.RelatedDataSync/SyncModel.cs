using DbShell.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Driver.Common.Utility;

namespace DbShell.RelatedDataSync
{
    public class SyncModel : DataSyncItemBase
    {
        public List<Source> Sources { get; private set; } = new List<Source>();

        public List<Target> Targets { get; private set; } = new List<Target>();

        protected override void DoRun(IShellContext context)
        {
            context.SetVariable(GetSyncModelVariableName(context), this);
        }
    }
}
