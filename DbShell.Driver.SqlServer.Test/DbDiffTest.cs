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
        private static string TransformSql(string sql)
        {
            sql = sql.Replace("GO", ";");
            sql = sql.Replace("\r", " ");
            sql = sql.Replace("\n", " ");
            sql = sql.Replace(";;", ";");
            sql = sql.Replace(" ", "");
            return sql;
        }

        private void TestDiff(Action<DatabaseInfo> mangle, string expectedResult)
        {
            var db1 = new DatabaseInfo();
            var t1 = new TableInfo(db1)
                {
                    Name = "t1",
                    Schema = "dbo",
                };
            t1.Columns.Add(new ColumnInfo(t1)
                {
                    Name = "c1",
                    DataType = "int",
                    NotNull = true,
                    CommonType = new DbTypeInt(),
                });
            t1.Columns.Add(new ColumnInfo(t1)
                {
                    Name = "c2",
                    DataType = "int",
                    NotNull = true,
                    CommonType = new DbTypeInt(),
                });

            var ix = new IndexInfo(t1);
            ix.Columns.Add(new ColumnReference { RefColumn = t1.Columns[0] });
            ix.ConstraintName = "ix1";
            t1.Indexes.Add(ix);

            var pk = new PrimaryKeyInfo(t1);
            pk.Columns.Add(new ColumnReference {RefColumn = t1.Columns[0]});
            pk.ConstraintName = "pk_t1";
            t1.PrimaryKey = pk;

            db1.Tables.Add(t1);

            var v1 = new ViewInfo(db1)
                {
                    Name = "v1",
                    Schema = "dbo",
                    CreateSql = "create view v1 as select * from t1",
                };
            db1.Views.Add(v1);


            var db2 = db1.CloneDatabase();
            mangle(db2);
            var plan = new AlterPlan(db1);
            DbDiffTool.AlterDatabase(plan, db1, db2, new DbDiffOptions());
            var caps = SqlServerDatabaseFactory.Instance.DumperCaps;
            plan.AddLogicalDependencies(caps, new DbDiffOptions());
            plan.Transform(caps, new DbDiffOptions());

            var runner = plan.CreateRunner();
            var sw = new StringWriter();
            var sqlo = new SqlOutputStream(SqlServerDatabaseFactory.Instance.CreateDialect(), sw, new SqlFormatProperties());
            var dmp = SqlServerDatabaseFactory.Instance.CreateDumper(sqlo, new SqlFormatProperties());
            runner.Run(dmp, new DbDiffOptions());
            string sql = sw.ToString();
            Assert.IsNotNull(sql);
            Assert.AreEqual(TransformSql(expectedResult), TransformSql(sql));
        }

        [TestMethod]
        public void AddColumnTest()
        {
            TestDiff(db =>
                {
                    var t1 = db.FindTableLike("t1");
                    t1.Columns.Add(new ColumnInfo(t1)
                        {
                            Name = "c3",
                            DataType = "int",
                            NotNull = true,
                            CommonType = new DbTypeInt(),
                        });
                }, "ALTER TABLE [dbo].[t1] ADD [c3] INT NOT NULL");
        }

        [TestMethod]
        public void DropColumnTest()
        {

            TestDiff(db =>
                {
                    var t1 = db.FindTableLike("t1");
                    t1.Columns.RemoveAll(c => c.Name == "c2");
                }, "ALTER TABLE [dbo].[t1] DROP COLUMN [c2]");
        }

        [TestMethod]
        public void DropViewTest()
        {
            TestDiff(db =>
                {
                    var v1 = db.FindViewLike("v1");
                    db.AlterProcessor.DropView(v1, true);
                }, "DROP VIEW [dbo].[v1]");
        }

        [TestMethod]
        public void DropTableTest()
        {
            TestDiff(db =>
                {
                    var t1 = db.FindTableLike("t1");
                    db.AlterProcessor.DropTable(t1, true);
                }, "DROP TABLE [dbo].[t1]");
        }

        [TestMethod]
        public void ChangeColumnTest()
        {
            TestDiff(db =>
                {
                    var t1 = db.FindTableLike("t1");
                    t1.Columns["c2"].NotNull = false;
                }, "ALTER TABLE [dbo].[t1] ALTER COLUMN [c2] INT NULL");
        }

        [TestMethod]
        public void RenameColumn()
        {
            TestDiff(db =>
                {
                    var t1 = db.FindTableLike("t1");
                    t1.Columns["c1"].Name = "c1new";
                }, "EXECUTE sp_rename '[dbo].[t1].[c1]', 'c1new', 'COLUMN'");
        }

        [TestMethod]
        public void RenameView()
        {
            TestDiff(db =>
                {
                    var v1 = db.FindViewLike("v1");
                    v1.Name = "v1new";
                }, "EXECUTE sp_rename '[dbo].[v1]', 'v1new', 'OBJECT'");
        }

        [TestMethod]
        public void ChangeViewSchema()
        {
            TestDiff(db =>
                {
                    var v1 = db.FindViewLike("v1");
                    v1.Schema = "dbonew";
                }, "EXECUTE sp_changeobjectowner '[dbo].[v1]', 'dbonew'");
        }

        [TestMethod]
        public void RenameTable()
        {
            TestDiff(db =>
                {
                    var t1 = db.FindTableLike("t1");
                    t1.Name = "t1new";
                }, "EXECUTE sp_rename '[dbo].[t1]', 't1new', 'OBJECT'");
        }

        [TestMethod]
        public void ChangeTableSchema()
        {
            TestDiff(db =>
                {
                    var t1 = db.FindTableLike("t1");
                    t1.Schema = "dbonew";
                }, "EXECUTE sp_changeobjectowner '[dbo].[t1]', 'dbonew'");
        }

        [TestMethod]
        public void ChangePkColumnTest()
        {
            const string sql = @"
DROP INDEX [ix1] ON [dbo].[t1]
GO
ALTER TABLE [dbo].[t1] DROP CONSTRAINT [pk_t1]
GO
ALTER TABLE [dbo].[t1] ALTER COLUMN [c1] FLOAT NOT NULL
GO
ALTER TABLE [dbo].[t1] ADD CONSTRAINT [pk_t1] PRIMARY KEY ([c1])
GO
CREATE INDEX [ix1] on [dbo].[t1] ([c1] ASC)";
            TestDiff(db =>
                {
                    var t1 = db.FindTableLike("t1");
                    t1.Columns["c1"].DataType = "float";
                }, sql);
        }

        [TestMethod]
        public void ChangeIdentityTest()
        {
            SqlDumper.TempTableNameOverride = "TMP0";
            string sql = @"
ALTER TABLE [dbo].[t1] DROP CONSTRAINT [pk_t1]
GO
DROP INDEX [ix1] ON [dbo].[t1]
GO
EXECUTE sp_rename '[dbo].[t1]', 'TMP0', 'OBJECT'
GO
CREATE TABLE [dbo].[t1] ( 
    [c1] INT IDENTITY NOT NULL, 
    [c2] INT NOT NULL, 
    CONSTRAINT [pk_t1] PRIMARY KEY ([c1])
)
GO
CREATE INDEX [ix1] on [dbo].[t1] ([c1] ASC)
GO
SET IDENTITY_INSERT [dbo].[t1] ON;
INSERT INTO [dbo].[t1] ([c1], [c2]) select [c1] AS [c1], [c2] AS [c2] FROM [dbo].[TMP0]
GO
SET IDENTITY_INSERT [dbo].[t1] OFF;
DROP TABLE [TMP0]";
            TestDiff(db =>
                {
                    var t1 = db.FindTableLike("t1");
                    t1.Columns["c1"].AutoIncrement = true;
                }, sql);
        }

        [TestMethod]
        public void CreateTableTest()
        {
            TestDiff(db =>
                {
                    var t2 = new TableInfo(db);
                    t2.Name = "t2";
                    t2.Schema = "dbo";
                    var c1 = new ColumnInfo(t2);
                    c1.Name = "c1";
                    c1.DataType = "int";
                    t2.Columns.Add(c1);
                    db.Tables.Add(t2);
                }, "CREATE TABLE [dbo].[t2] ([c1] INT NULL) ");
        }
    }
}

