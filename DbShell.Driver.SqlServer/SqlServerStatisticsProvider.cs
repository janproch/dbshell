using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Statistics;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.SqlServer
{
    public class SqlServerStatisticsProvider : IStatisticsProvider
    {
        public TableSizes GetTableSizes(DbConnection conn, LinkedDatabaseInfo linkedInfo)
        {
            var res = new TableSizes();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = SqlServerLinkedServer.ReplaceLinkedServer(SqlServerDatabaseFactory.LoadEmbeddedResource("rowcounts.sql"), linkedInfo);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string table = reader.SafeString("Table");
                        string schema = reader.SafeString("Schema");
                        int rowcount = Int32.Parse(reader.SafeString("RowCount") ?? "0");
                        res.RowCount[new NameWithSchema(schema, table)] = rowcount;
                    }
                }
            }
            return res;
        }
    }
}
