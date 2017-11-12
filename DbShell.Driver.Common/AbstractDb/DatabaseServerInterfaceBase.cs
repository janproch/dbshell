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
        public IDatabaseFactory Factory { get; set; }

        public virtual DatabaseServerVersion GetVersion()
        {
            return new DatabaseServerVersion(Connection.ServerVersion);
        }
        public virtual List<DatabaseOverviewInfo> GetDatabaseList(bool includeDetails, LinkedDatabaseInfo linkedInfo = null)
        {
            return new List<DatabaseOverviewInfo>();
        }

        public virtual void CreateDatabase(string dbName)
        {
            using (var cmd = Connection.CreateCommand())
            {
                var dialect = Factory?.CreateDialect();
                cmd.CommandText = "CREATE DATABASE " + (dialect.QuoteIdentifier(dbName) ?? dbName);
                cmd.ExecuteNonQuery();
            }
        }

        public virtual void DropDatabase(string dbName)
        {
            using (var cmd = Connection.CreateCommand())
            {
                var dialect = Factory?.CreateDialect();
                cmd.CommandText = "DROP DATABASE " + (dialect.QuoteIdentifier(dbName) ?? dbName);
                cmd.ExecuteNonQuery();
            }
        }

        public virtual void RenameDatabase(string oldName, string newName)
        {
            using (var cmd = Connection.CreateCommand())
            {
                var dialect = Factory?.CreateDialect();
                cmd.CommandText = "RENAME DATABASE " + (dialect.QuoteIdentifier(oldName) ?? oldName) + " TO " + (dialect.QuoteIdentifier(newName) ?? newName);
                cmd.ExecuteNonQuery();
            }
        }
    }
}
