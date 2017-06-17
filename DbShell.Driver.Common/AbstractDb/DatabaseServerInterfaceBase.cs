using DbShell.Driver.Common.Structure;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace DbShell.Driver.Common.AbstractDb
{
    public abstract class DatabaseServerInterfaceBase : IDatabaseServerInterface
    {
        public DbConnection Connection { get; set; }
        public abstract DatabaseServerVersion GetVersion();
        public abstract List<DatabaseOverviewInfo> GetDatabaseList(bool includeDetails, LinkedDatabaseInfo linkedInfo = null);
    }
}
