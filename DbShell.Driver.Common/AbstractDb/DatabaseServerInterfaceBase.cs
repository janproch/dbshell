using DbShell.Driver.Common.Structure;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;

namespace DbShell.Driver.Common.AbstractDb
{
    public class DatabaseServerInterfaceBase : IDatabaseServerInterface
    {
        public DbConnection Connection { get; set; }

        public virtual DatabaseServerVersion GetVersion()
        {
            return new DatabaseServerVersion(Connection.ServerVersion);
        }
        public virtual List<DatabaseOverviewInfo> GetDatabaseList(bool includeDetails, LinkedDatabaseInfo linkedInfo = null)
        {
            return new List<DatabaseOverviewInfo>();
        }
    }
}
