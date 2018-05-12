using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DbShell.Test.EngineProviders
{
    public class MySqlEngineProvider : IDatabaseEngineProvider
    {
        public const string ConnectionString = @"Data Source=localhost;Uid=root;Password=Password123";
        public const string DatabaseName = "DbShellTest";

        private string FullConnectionString => $"{ConnectionString};Database={DatabaseName}";

        public string ProviderConnectionString => $"mysql://{FullConnectionString}";

        public void CreateDatabase()
        {
            using (var conn = new MySqlConnection(ConnectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = $"DROP DATABASE IF EXISTS `{DatabaseName}`; CREATE DATABASE {DatabaseName};";
                    cmd.ExecuteNonQuery();
                }
            }

            EngineProviderFactory.RunEmbeddedScript(this, "CreateTestData_mysql.sql");
        }

        public DbConnection OpenConnection()
        {
            var conn = new MySqlConnection(FullConnectionString);
            conn.Open();
            return conn;
        }
    }
}
