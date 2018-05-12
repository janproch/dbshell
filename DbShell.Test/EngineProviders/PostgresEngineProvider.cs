using MySql.Data.MySqlClient;
using Npgsql;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Text;

namespace DbShell.Test.EngineProviders
{
    public class PostgresEngineProvider : IDatabaseEngineProvider
    {
        public const string ConnectionString = @"Server=localhost;Uid=postgres;Password=Password123";
        public const string DatabaseName = "dbshelltest";

        private string FullConnectionString => $"{ConnectionString};Database={DatabaseName}";

        public string ProviderConnectionString => $"postgres://{FullConnectionString}";

        public void CreateDatabase()
        {
            using (var conn = new NpgsqlConnection(ConnectionString))
            {
                conn.Open();
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = string.Format(@"SELECT
 pg_terminate_backend(pg_stat_activity.pid)
FROM
 pg_stat_activity
WHERE
 pg_stat_activity.datname = '{0}'; DROP DATABASE IF EXISTS {0}; CREATE DATABASE {0};", DatabaseName);
                    cmd.ExecuteNonQuery();
                }
            }

            EngineProviderFactory.RunEmbeddedScript(this, "CreateTestData_postgres.sql");
        }

        public DbConnection OpenConnection()
        {
            var conn = new NpgsqlConnection(FullConnectionString);
            conn.Open();
            return conn;
        }
    }
}
