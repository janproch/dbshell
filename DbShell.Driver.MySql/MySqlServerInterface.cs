using DbShell.Driver.Common.AbstractDb;
using System;
using System.Collections.Generic;
using System.Text;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.MySql
{
    public class MySqlServerInterface : DatabaseServerInterfaceBase
    {
        public override List<DatabaseOverviewInfo> GetDatabaseList(bool includeDetails, LinkedDatabaseInfo linkedInfo = null)
        {
            using (var cmd = Connection.CreateCommand())
            {
                cmd.CommandText = "show databases";
                using (var reader = cmd.ExecuteReader())
                {
                    var res = new List<DatabaseOverviewInfo>();
                    while (reader.Read())
                    {
                        var item = new DatabaseOverviewInfo();
                        item.Name = reader["Database"].SafeToString();
                        res.Add(item);
                    }
                    return res;
                }
            }
        }
    }
}
