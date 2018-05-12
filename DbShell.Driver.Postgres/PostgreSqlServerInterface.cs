using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.Driver.Postgres
{
    public class PostgreSqlServerInterface : DatabaseServerInterfaceBase
    {
        public override List<DatabaseOverviewInfo> GetDatabaseList(bool includeDetails, LinkedDatabaseInfo linkedInfo = null)
        {
            using (var cmd = Connection.CreateCommand())
            {
                cmd.CommandText = "SELECT datname FROM pg_database WHERE datistemplate = false";
                using (var reader = cmd.ExecuteReader())
                {
                    var res = new List<DatabaseOverviewInfo>();
                    while (reader.Read())
                    {
                        var item = new DatabaseOverviewInfo();
                        item.Name = reader["datname"].SafeToString();
                        res.Add(item);
                    }
                    return res;
                }
            }
        }

        public override void DropDatabase(string dbName)
        {
            using (var cmd = Connection.CreateCommand())
            {
                cmd.CommandText = $"select pg_terminate_backend(pg_stat_activity.pid) from pg_stat_activity where pg_stat_activity.datname = '{dbName}';DROP DATABASE \"{dbName}\"";
                cmd.ExecuteNonQuery();
            }
        }
    }
}
