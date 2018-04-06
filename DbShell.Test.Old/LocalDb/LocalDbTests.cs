using DbShell.LocalDb;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;

namespace DbShell.Test.LocalDb
{
    [TestClass]
    public class LocalDbTests : DatabaseTestBase
    {
        public LocalDbTests()
        {
            new TransformData();
        }

        public void InitLocalDatabase(params string[] initSql)
        {
            if (File.Exists("test.locdb"))
            {
                File.Delete("test.locdb");
            }
            using (var conn = OpenLocalConnection())
            {
                foreach (string item in initSql)
                {
                    using (var cmd = conn.CreateCommand())
                    {
                        cmd.CommandText = item;
                        cmd.ExecuteNonQuery();
                    }
                }
            }
        }

        private SQLiteConnection OpenLocalConnection()
        {
            var conn = new SQLiteConnection("Synchronous=Full;Data Source=test.locdb");
            conn.Open();
            return conn;
        }

        public object ExecuteLocalScalar(string sql)
        {
            using (var conn = OpenLocalConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sql;
                    return cmd.ExecuteScalar();
                }
            }
        }

        public void AssertIsLocalValue(string svalue, string sql)
        {
            object value = ExecuteLocalScalar(sql);
            Assert.IsTrue(value?.ToString() == svalue);
        }

        [DeploymentItem("LocalDb/transform_exe.xaml")]
        [DeploymentItem("LocalDb/transform_concat2.exe")]
        [DeploymentItem("LocalDb/SQLite.Interop.dll")]
        [TestMethod]
        public void LocalDbTransform()
        {
            InitLocalDatabase("create table tran_test (id, value)", "insert into tran_test values (1, 'x')", "insert into tran_test values (2, 'y');");
            using (var runner = CreateRunner())
            {
                runner.LoadFile("transform_exe.xaml");
                runner.Run();
            }
            AssertIsLocalValue("x_x", "select value from tran_test where id=1");
            AssertIsLocalValue("y_y", "select value from tran_test where id=2");
        }
    }
}
