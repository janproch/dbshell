using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;

namespace DbShell.Driver.SqlServer.Test
{
    public class DatabaseTestBase
    {
        public SqlConnection OpenConnection()
        {
            var conn = new SqlConnection(ConfigurationManager.ConnectionStrings["Database"].ConnectionString);
            conn.Open();
            return conn;
        }

        public void InitDatabase()
        {
            // force close LINQ SQL connection
            SqlConnection.ClearAllPools();

            string dbname = ConfigurationManager.AppSettings["Database"];

            using (var conn = OpenConnection())
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
        }

        public static string LoadEmbeddedResource(string name)
        {
            using (Stream s = typeof(DatabaseTestBase).Assembly.GetManifestResourceStream("DataLibrary.MsSql.Tests." + name))
            {
                if (s == null)
                    throw new InvalidOperationException("Could not find embedded resource");
                using (var sr = new StreamReader(s))
                {
                    return sr.ReadToEnd();
                }
            }
        }
    }
}
