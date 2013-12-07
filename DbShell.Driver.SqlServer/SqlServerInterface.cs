using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.SqlServer
{
    public class SqlServerInterface : DatabaseServerInterfaceBase
    {
        public override DatabaseServerVersion GetVersion()
        {
            using (var cmd = Connection.CreateCommand())
            {
                cmd.CommandText = "SELECT SERVERPROPERTY('productversion') as VersionNumber, @@VERSION as VersionDesc";
                using (var reader = cmd.ExecuteReader())
                {
                    if (reader.Read())
                    {
                        string name = reader.GetString(0);
                        string desc = reader.GetString(1);
                        var res = new DatabaseServerVersion(name);
                        var lines = desc.Split('\n');
                        res.Description = lines[0].Trim();
                        switch (res.V1)
                        {
                            case 7:
                                res.SellingName = "SQL Server 7";
                                break;
                            case 8:
                                res.SellingName = "2000";
                                break;
                            case 9:
                                res.SellingName = "2005";
                                break;
                            case 10:
                                res.SellingName = "2008/2008 R2";
                                break;
                            case 11:
                                res.SellingName = "2012";
                                break;
                        }
                        return res;
                    }
                }
            }
            return null;
        }

        public override List<string> GetDatabaseList()
        {
            var res = new List<string>();
            Connection.ChangeDatabase("master");
            using (var cmd = Connection.CreateCommand())
            {
                cmd.CommandText = "SELECT * FROM sysdatabases";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        res.Add(reader["name"].SafeToString());
                    }
                }
            }
            res.Sort();
            return res;
        }
    }
}
