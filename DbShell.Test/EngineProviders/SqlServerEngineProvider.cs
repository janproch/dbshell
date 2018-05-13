using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Text;

namespace DbShell.Test.EngineProviders
{
    public class SqlServerEngineProvider : IDatabaseEngineProvider
    {
        public const string ConnectionString = @"Data Source=localhost\SQLEXPRESS;Integrated Security=SSPI";
        public const string DatabaseName = "DbShellTest";

        public string ProviderConnectionString => "sqlserver://" + GetConnectionString(true);

        protected string GetConnectionString(bool specifyDatabase)
        {
            string conns = ConnectionString;
            if (specifyDatabase) conns += ";Initial Catalog=" + DatabaseName;
            return conns;
        }

        public DbConnection OpenConnection(bool specifyDatabase)
        {
            string conns = GetConnectionString(specifyDatabase);
            var conn = new SqlConnection(conns);
            conn.Open();
            return conn;
        }

        public void CreateDatabase()
        {
            // force close LINQ SQL connection
            SqlConnection.ClearAllPools();

            string dbname = DatabaseName;

            using (var conn = OpenConnection(false))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = String.Format(
                        @"
IF EXISTS(SELECT name FROM sys.databases WHERE name='{0}') 
BEGIN
  ALTER DATABASE {0} SET SINGLE_USER WITH ROLLBACK IMMEDIATE;
  USE master;
  DROP DATABASE {0};
END
USE master;
CREATE DATABASE {0}",
                        dbname);
                    cmd.ExecuteNonQuery();
                }
            }

            SqlConnection.ClearAllPools();

            EngineProviderFactory.RunEmbeddedScript(this, "CreateTestData_mssql.sql");
        }

        public DbConnection OpenConnection()
        {
            return OpenConnection(true);
        }
    }
}
