using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.DbDiff;
using DbShell.Driver.Common.Sql;
using DbShell.Driver.Common.Structure;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbShell.Driver.SqlServer.Test
{
    [TestClass]
    public class DbDiffTest
    {
        private void TestDiff(Action<DatabaseInfo> mangle, string expectedResult)
        {
            var db1 = new DatabaseInfo();
            var t1 = new TableInfo(db1)
                {
                    Name = "t1",
                };
            t1.Columns.Add(new ColumnInfo(t1)
                {
                    Name = "c1",
                    DataType = "int",
                    CommonType = new DbTypeInt(),
                });
            t1.Columns.Add(new ColumnInfo(t1)
            {
                Name = "c2",
                DataType = "int",
                CommonType = new DbTypeInt(),
            });
            db1.Tables.Add(t1);
            var db2 = db1.CloneDatabase();
            mangle(db2);
            var plan = new AlterPlan();
            DbDiffTool.AlterDatabase(plan, db1, db2, new DbDiffOptions());
            var runner = plan.CreateRunner();
            var sw = new StringWriter();
            var sqlo = new SqlOutputStream(SqlServerDatabaseFactory.Instance.CreateDialect(), sw, new SqlFormatProperties());
            var dmp = SqlServerDatabaseFactory.Instance.CreateDumper(sqlo, new SqlFormatProperties());
            runner.Run(dmp, new DbDiffOptions());
            string sql = sw.ToString();
            Assert.AreEqual(expectedResult, sql);

        }

        [TestMethod]
        public void SimpleDiffTest()
        {
            TestDiff(db =>
                {
                    var t1 = db.FindTableLike("t1");
                    t1.Columns.Add(new ColumnInfo(t1)
                        {
                            Name = "c3",
                            DataType = "int",
                            CommonType = new DbTypeInt(),
                        });
                }, "ALTER TABLE [t1] ADD [c3] INT NULL");

            TestDiff(db =>
            {
                var t1 = db.FindTableLike("t1");
                t1.Columns.RemoveAll(c => c.Name == "c2");
            }, "ALTER TABLE [t1] DROP COLUMN [c2]");
        }
    }
}
