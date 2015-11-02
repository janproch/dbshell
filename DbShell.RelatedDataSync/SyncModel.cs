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
        public List<TargetReference> TargetReferences { get; private set; } = new List<TargetReference>();

        [XamlProperty]
        public List<LogHandlerBase> LogHandlers { get; private set; } = new List<LogHandlerBase>();

        [XamlProperty]
        public string SqlPrologBeforeBeginTransaction { get; set; }

        [XamlProperty]
        public string SqlPrologAfterBeginTransaction { get; set; }

        [XamlProperty]
        public string SqlEpilogBeforeCommitTransaction { get; set; }

        [XamlProperty]
        public string SqlEpilogAfterCommitTransaction { get; set; }

        protected override void DoRun(IShellContext context)
        {
            context.SetVariable(GetSyncModelVariableName(context), this);
        }
    }
}
