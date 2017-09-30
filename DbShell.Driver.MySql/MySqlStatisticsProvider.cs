using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Statistics;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.MySql
{
    public class MySqlStatisticsProvider : IStatisticsProvider
    {
        public TableSizes GetTableSizes(DbConnection conn, LinkedDatabaseInfo linkedInfo)
        {
            var res = new TableSizes();
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = "show table status";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string table = reader.SafeString("Name");
                        string engine = reader.SafeString("Engine");

                        var resItem = new TableSizesItem
                        {
                            RowCount = reader.SafeString("Rows").SafeIntParse(),
                            DataLengthKB = reader.SafeString("Data_length").SafeIntParse() / 1024,
                            IndexLengthKB = reader.SafeString("Index_length").SafeIntParse() / 1024,
                        };
                        resItem.TotalSpaceKB = resItem.IndexLengthKB + resItem.DataLengthKB;
                        res.Items[new NameWithSchema(null, table)] = resItem;
                    }
                }
            }
            return res;
        }
    }
}
