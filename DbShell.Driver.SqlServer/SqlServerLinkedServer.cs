using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DbShell.Driver.Common.Structure;
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
                int nameIndex = reader.GetOrdinal("SRV_NAME");
                while (reader.Read())
                {
                    res.Add(new SqlServerLinkedServer
                    {
                        Name = reader.GetString(nameIndex),
                    });
                }
            }
            return res;
        }

        public List<string> GetDatabases(DbConnection conn)
        {
            var res = new List<string>();
            using (var reader = conn.RunOneSqlCommandReader(String.Format("select name from [{0}].master.sys.databases", Name)))
            {
                int nameIndex = reader.GetOrdinal("name");
                while (reader.Read())
                {
                    res.Add(reader.GetString(nameIndex));
                }
            }
            return res;
        }

        public static string ReplaceLinkedServer(string sql, LinkedDatabaseInfo linkedInfo)
        {
            if (sql == null) return null;

            string linkedServerSpec = "";
            if (linkedInfo != null && linkedInfo.LinkedServerName != null)
            {
                linkedServerSpec = String.Format("[{0}].[{1}].", linkedInfo.LinkedServerName, linkedInfo.LinkedDatabaseName);
            }
            return sql.Replace("[SERVER].", linkedServerSpec);
        }

        public static string ReplaceLinkedServer(string sql, string server, string database)
        {
            return ReplaceLinkedServer(sql, new LinkedDatabaseInfo(server, database));
        }
    }
}
