using System;
using System.Configuration;
using System.IO;
using DbShell.Core.Runtime;
using DbShell.Driver.Common.Utility;
using DbShell.Core.Utility;
using Xunit;
using DbShell.Xml;
using DbShell.Core;
using DbShell.All;
using System.Collections.Generic;
using System.Collections;
using DbShell.EngineProviders.Test;

namespace DbShell.Test
{
    public class CopyTableTest : DatabaseTestBase
    {
        [Theory]
        [ClassData(typeof(DatabaseEngineGenerator))]
        public void TableToCdl(string engine)
        {
            Initialize(engine);

            using (var runner = CreateRunner())
            {
                runner.LoadFile("CopyTable/copytable_tabletocdl.dbsh");
                runner.Run();
            }
        }

        [Theory]
        [ClassData(typeof(DatabaseEngineGenerator))]
        public void CdlToCdl(string engine)
        {
            Initialize(engine);

            using (var runner = CreateRunner())
            {
                runner.LoadFile("CopyTable/copytable_cdltocdl.dbsh");
                runner.Run();
            }

            Assert.True(TestUtility.FileCompare("test1.cdl", "test2.cdl"));
            Assert.True(TestUtility.FileCompare("test1.csv", "test2.csv"));
        }

        [Theory]
        [ClassData(typeof(DatabaseEngineGenerator))]
        public void TableToTable(string engine)
        {
            Initialize(engine);
            
            using (var runner = CreateRunner())
            {
                runner.LoadFile("CopyTable/copytable_tabletotable.dbsh");
                runner.Run();
            }

            Assert.True(TestUtility.FileCompareCdlContent("test1.cdl", "test2.cdl"));
        }

        [Theory]
        [ClassData(typeof(DatabaseEngineGenerator))]
        public void CopyTableColumnMapTest(string engine)
        {
            Initialize(engine);

            using (var runner = CreateRunner())
            {
                runner.LoadFile("CopyTable/copytable_columnmap.dbsh");
                runner.Run();
                using (var sr = new StreamReader("test.csv"))
                {
                    sr.ReadLine();
                    string line = sr.ReadLine().Trim();
                    Assert.Equal("1,1,AlbumId=1", line);
                }
            }
        }

        [Theory]
        [ClassData(typeof(DatabaseEngineGenerator))]
        public void CopyAllTablesTest(string engine)
        {
            Initialize(engine);

            using (var runner = CreateRunner())
            {
                runner.LoadFile("CopyTable/copyalltables.dbsh");
                runner.Run();
            }
        }

        private void TestValue(string table, string idcol, string idval, string column, string value)
        {
            var dialect = DatabaseFactory.CreateDialect();
            using (var conn = OpenConnection())
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = String.Format("SELECT {0} FROM {1} WHERE {2} = '{3}'", 
                        dialect.QuoteIdentifier(column), dialect.QuoteIdentifier(table), dialect.QuoteIdentifier(idcol), idval);
                    string realVal = cmd.ExecuteScalar().SafeToString();
                    Assert.Equal(value, realVal);
                }
            }
        }

        [Theory]
        [ClassData(typeof(DatabaseEngineGenerator))]
        public void MappedImportTest(string engine)
        {
            Initialize(engine);

            using (var runner = CreateRunner())
            {
                runner.LoadFile("CopyTable/mapped_import.dbsh");
                runner.Run();
            }
            
            // bulk copy
            TestValue("ImportedData", "ID_IMPORTED", "1", "Data1", "a1");
            TestValue("ImportedData", "ID_IMPORTED", "3", "Data3", "c3");
            TestValue("ImportedData", "ID_IMPORTED", "4", "Data1", "a3");
            TestValue("ImportedData", "ID_IMPORTED", "6", "Data3", "c2");

            // inserts
            TestValue("ImportedData", "ID_IMPORTED", "7", "Data1", "a1");
            TestValue("ImportedData", "ID_IMPORTED", "9", "Data3", "c3");
            TestValue("ImportedData", "ID_IMPORTED", "10", "Data1", "a3");
            TestValue("ImportedData", "ID_IMPORTED", "12", "Data3", "c2");
        }

        [Theory]
        [ClassData(typeof(DatabaseEngineGenerator))]
        public void XmlImportTest(string engine)
        {
            Initialize(engine);

            var instructions = XmlTableAnalyser.AnalyseFile("CopyTable/importedxml4.xml", true);

            using (var runner = CreateRunner())
            {
                runner.LoadFile("CopyTable/copytable_xmltocsv.dbsh");
                runner.Run();

                string output1 = System.IO.File.ReadAllText("outputcsv1.csv");
                Assert.Equal("sub,attr,x,y,z\r\nA,a1,x1,y1,z1\r\nA,a2,x2,y2,z2\r\nB,a3,x3,y3,z3\r\nB,a4,x4,y4,z4\r\n", output1);

                string output2 = System.IO.File.ReadAllText("outputcsv2.csv");
                Assert.Equal("x,y,z,x2,y2,z2\r\nx1,y1,z1,(NULL),(NULL),(NULL)\r\nx2,y2,z2,(NULL),(NULL),(NULL)\r\n(NULL),(NULL),(NULL),x3,y3,z3\r\n(NULL),(NULL),(NULL),x4,y4,z4\r\n", output2);

                string output3 = System.IO.File.ReadAllText("outputcsv3.csv");
                Assert.Equal("x\r\nx1\r\nx2\r\nx3\r\n", output3);

                string output4 = System.IO.File.ReadAllText("outputcsv4.csv");
                Assert.Equal("x,y,z\r\nxval,yval,zval\r\n", output4);
            }
        }

        [Theory]
        [ClassData(typeof(DatabaseEngineGenerator))]
        public void CopyDatabaseTest(string engine)
        {
            Initialize(engine);

            RunScript("DELETE FROM Album");
            RunScript("DELETE FROM Genre");

            var copyAll = new CopyAllTables
            {
                SourceConnection = "sqlite://Data Source=CopyTable/SqliteTestData.locdb",
                TargetConnection = ProviderConnectionString,
                DisableConstraints = true,
            };

            copyAll.Run();

            AssertIsValue("31", "select count(*) from Genre");
            AssertIsValue("10", "select count(*) from Album");
        }
    }
}
