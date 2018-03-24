using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Utility;
using DbShell.Driver.Common.Structure;

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

        public override void DropDatabase(string dbName)
        {
            using (var cmd = Connection.CreateCommand())
            {
                cmd.CommandText = $"ALTER DATABASE [{dbName}] SET SINGLE_USER WITH ROLLBACK IMMEDIATE;USE master;DROP DATABASE [{dbName}]";
                cmd.ExecuteNonQuery();
            }
        }

        public override void RenameDatabase(string oldName, string newName)
        {
            using (var cmd = Connection.CreateCommand())
            {
                cmd.CommandText = $"EXEC sp_renamedb '{oldName}', '{newName}'";
                cmd.ExecuteNonQuery();
            }
        }

        public override List<DatabaseOverviewInfo> GetDatabaseList(bool includeDetails, LinkedDatabaseInfo linkedInfo = null)
        {

            if (includeDetails)
            {
                try
                {
                    using (var cmd = Connection.CreateCommand())
                    {
                        cmd.CommandText = SqlServerLinkedServer.ReplaceLinkedServer(SqlServerDatabaseFactory.LoadEmbeddedResource("databasesizes.sql"), linkedInfo);
                        using (var reader = cmd.ExecuteReader())
                        {
                            var res = new List<DatabaseOverviewInfo>();
                            while (reader.Read())
                            {
                                var item = new DatabaseOverviewInfo();
                                item.Name = reader["DatabaseName"].SafeToString();
                                item.RowSizeKB = long.Parse(reader["RowSizeKB"].SafeToString());
                                item.LogSizeKB = long.Parse(reader["LogSizeKB"].SafeToString());
                                item.Collation = reader["Collation"].SafeToString();
                                item.RecoveryModel = reader["RecoveryModel"].SafeToString();
                                bool isSnapshot = reader["SnapshotIsolation"].SafeToString() == "1";
                                bool isReadCommitedSnapshot = reader["IsReadCommitedSnapshot"].SafeToString()?.ToLower() == "true";

                                if (isSnapshot)
                                {
                                    if (isReadCommitedSnapshot) item.Concurrency = "High";
                                    else item.Concurrency = "Middle";
                                }
                                else
                                {
                                    item.Concurrency = "Low";
                                }

                                res.Add(item);
                            }
                            return res;
                        }
                    }
                }
                catch (Exception err)
                {
                    // use variant without details
                    ServiceProvider.LogError<SqlServerInterface>(err, "Error fetching database details");
                }
            }

            using (var cmd = Connection.CreateCommand())
            {
                cmd.CommandText = SqlServerLinkedServer.ReplaceLinkedServer("SELECT name FROM [SERVER].sys.databases order by name", linkedInfo);
                using (var reader = cmd.ExecuteReader())
                {
                    var res = new List<DatabaseOverviewInfo>();
                    while (reader.Read())
                    {
                        var item = new DatabaseOverviewInfo();
                        item.Name = reader["name"].SafeToString();
                        res.Add(item);
                    }
                    return res;
                }
            }
        }
    }
}
