using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.DbDiff;
using DbShell.Driver.Common.Sql;
using DbShell.Driver.Common.Structure;
using DbShell.EngineProviders.Test;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;
using Xunit.Abstractions;

namespace DbShell.Test.DbEngineTests
{
    public class AlterProcessorTests : DatabaseTestBase
    {
        private ITestOutputHelper _output;

        public AlterProcessorTests(ITestOutputHelper output)
        {
            _output = output;
        }

        private void Title(string title)
        {
            _output.WriteLine("");
            _output.WriteLine($"************ {title} ************");
        }

        [Theory]
        [ClassData(typeof(DatabaseEngineGenerator))]
        public void AlterTable_SingleOps(string engine)
        {
            Initialize(engine);

            Title("add column");
            TestTableDiff("album", table => table.AddColumn("test1", "int", new DbTypeInt()));

            Title("remove column");
            TestTableDiff("AlbumCopy", table => table.Columns.Remove(table.FindColumn("artistid")));

            Title("rename column");
            TestTableDiff("album", table => table.FindColumn("test1").Name = "test2");

            Title("remove identity flag");
            TestTableDiff("AlbumCopy", table => table.FindColumn("albumid").AutoIncrement = false);

            Title("add identity flag");
            TestTableDiff("AlbumCopy", table => table.FindColumn("albumid").AutoIncrement = true);
        }

        [Theory]
        [ClassData(typeof(DatabaseEngineGenerator))]
        public void AlterTable_Combinations(string engine)
        {
            Initialize(engine);

            Title("add column and remove identity");
            TestTableDiff("album", table =>
            {
                table.AddColumn("test1", "int", new DbTypeInt());
                table.FindColumn("albumid").AutoIncrement = false;
            });

            Title("remove column and add identity");
            TestTableDiff("album", table =>
            {
                table.Columns.Remove(table.FindColumn("test1"));
                table.FindColumn("albumid").AutoIncrement = false;
            });
        }

        private void TestTableDiff(string tableName, Action<TableInfo> mangle)
        {
            var dbinfo = FullAnalyse();
            var table = dbinfo.FindTableLike(tableName);
            var alteredTableInfo = table.CloneTable();
            mangle(alteredTableInfo);

            var caps = DatabaseFactory.DumperCaps;
            var opts = new DbDiffOptions();
            AlterPlan plan = DbDiffTool.PlanAlterTable(table, alteredTableInfo, opts, dbinfo);
            plan.AddLogicalDependencies(caps, opts);
            plan.Transform(caps, opts);

            string sql = GenerateScriptForPlan(plan);
            _output.WriteLine(sql);

            RunPlan(plan);

            var newStructure = FullAnalyse();
            var newTableInfo = newStructure.FindTableLike(tableName);
            AssertEqual(alteredTableInfo, newTableInfo);
        }

        private string GenerateScriptForPlan(AlterPlan plan)
        {
            return GenerateSqlScript(dmp => plan.CreateRunner().Run(dmp, new DbDiffOptions()));
        }

        private void RunPlan(AlterPlan plan)
        {
            RunScript(dmp => plan.CreateRunner().Run(dmp, new DbDiffOptions()));
        }

        private void AssertEqual(TableInfo alteredTableInfo, TableInfo newTableInfo)
        {
            Assert.Equal(alteredTableInfo.ColumnCount, newTableInfo.ColumnCount);
            for (int i = 0; i < alteredTableInfo.ColumnCount; i++)
            {
                var colExpected = alteredTableInfo.Columns[i];
                var colReal = newTableInfo.Columns[i];

                Assert.Equal(colExpected.Name, colReal.Name);
                Assert.Equal(colExpected.NotNull, colReal.NotNull);
                Assert.Equal(colExpected.CommonTypeCode, colReal.CommonTypeCode);
                //Assert.Equal(colExpected.DataType.ToLower(), colReal.DataType.ToLower());
                Assert.Equal(colExpected.AutoIncrement, colReal.AutoIncrement);
            }
        }
    }
}
