using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.SqlServer
{
    public class SqlServerLinkedServer
    {
        public string Name;

        public static List<SqlServerLinkedServer> GetLinkedServers(DbConnection conn)
        {
            var res = new List<SqlServerLinkedServer>();
            using (var reader = conn.RunOneSqlCommandReader("exec sp_linkedservers"))
            {
                foreach (DataRow row in reader.ToDataTable().Rows)
                {
                    res.Add(new SqlServerLinkedServer
                        {
                            Name = row["SRV_NAME"].SafeToString(),
                        });
                }
            }
            return res;
        }
    }
}
