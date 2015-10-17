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
        [XamlProperty]
        public List<Source> Sources { get; private set; } = new List<Source>();

        [XamlProperty]
        public List<Target> Targets { get; private set; } = new List<Target>();

        [XamlProperty]
        public List<LogHandlerBase> LogHandlers { get; private set; } = new List<LogHandlerBase>();

        protected override void DoRun(IShellContext context)
        {
            context.SetVariable(GetSyncModelVariableName(context), this);
        }
    }
}
