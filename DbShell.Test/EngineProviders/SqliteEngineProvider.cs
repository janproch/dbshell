using Microsoft.Data.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.IO;
using System.Text;

namespace DbShell.Test.EngineProviders
{
    public class SqliteEngineProvider : IDatabaseEngineProvider
    {
        public string SqliteFile = $"dbshelltest_{(long)(DateTime.Now - new DateTime(2000, 1, 1)).TotalMilliseconds}.sqlite";

        public string ProviderConnectionString => $"sqlite://Data Source={SqliteFile}";

        public void CreateDatabase()
        {
            if (File.Exists("dbshelltest.sqlite"))
                File.Delete("dbshelltest.sqlite");

            using (var db = OpenConnection())
            {
                EngineProviderFactory.RunEmbeddedScript(this, "CreateTestData_sqlite.sql");
            }
        }

        public DbConnection OpenConnection()
        {
            var conn = new SqliteConnection($"Data Source={SqliteFile}");
            conn.Open();
            return conn;
        }
    }
}
