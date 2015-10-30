using System;
using System.Configuration;
using System.Data.SqlClient;
using System.IO;
using DbShell.Core.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbShell.Test
{
    public class DatabaseTestBase
    {
        public SqlConnection OpenConnection(bool specifyDatabase)
        {
            string conns = ConfigurationManager.ConnectionStrings["Database"].ConnectionString;
            if (specifyDatabase) conns += ";Initial Catalog=" + ConfigurationManager.AppSettings["Database"];
            var conn = new SqlConnection(conns);
            conn.Open();
            return conn;
        }

        protected ShellRunner CreateRunner()
        {
            var runner = new ShellRunner();
            runner.Context.SetDefaultConnection("sqlserver://" + ConfigurationManager.ConnectionStrings["Database"].ConnectionString + ";Initial Catalog=" +
                                                ConfigurationManager.AppSettings["Database"]);
            return runner;
        }

        public void InitDatabase()
        {
            // force close LINQ SQL connection
            SqlConnection.ClearAllPools();

            string dbname = ConfigurationManager.AppSettings["Database"];

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
        }

        public void RunScript(string sql)
        {
            using (var conn = OpenConnection(true))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public void RunEmbeddedScript(string name)
        {
            using (var conn = OpenConnection(true))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = LoadEmbeddedResource(name);
                    cmd.ExecuteNonQuery();
                }
            }
        }

        public string LoadEmbeddedResource(string name)
        {
            using (Stream s = GetType().Assembly.GetManifestResourceStream(GetType().Namespace + "." + name))
            {
                if (s == null)
                    throw new InvalidOperationException("Could not find embedded resource");
                using (var sr = new StreamReader(s))
                {
                    return sr.ReadToEnd();
                }
            }
        }

        public object ExecuteScalar(string sql)
        {
            using (var conn = OpenConnection(true))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    return cmd.ExecuteScalar();
                }
            }
        }

        public void AssertIsNotNull(string sql)
        {
            object value = ExecuteScalar(sql);
            Assert.IsTrue(value != null && value != DBNull.Value);
        }

        public void AssertIsNull(string sql)
        {
            object value = ExecuteScalar(sql);
            Assert.IsTrue(value == null || value == DBNull.Value);
        }

        public void AssertIsValue(string svalue, string sql)
        {
            object value = ExecuteScalar(sql);
            Assert.IsTrue(value?.ToString() == svalue);
        }

        public void AssertExists(string sql)
        {
            string existSql = $"select case when exists({sql}) then 1 else 0 end";
            AssertIsValue("1", existSql);
        }
    }
}
