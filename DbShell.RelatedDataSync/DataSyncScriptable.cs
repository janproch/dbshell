using DbShell.Common;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.RelatedDataSync
{
    public abstract class DataSyncScriptable : DataSyncItemBase
    {
        [XamlProperty]
        public bool UseTransaction { get; set; }

        public abstract string GenerateSql(IDatabaseFactory factory, IShellContext context);
    }
}
