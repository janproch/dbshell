using System;
using System.Configuration;
using System.IO;
using DbShell.Core.Runtime;
using DbShell.Driver.Common.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbShell.Test
{
    [TestClass]
    public class CopyTableTest : DatabaseTestBase
    {
        [TestMethod]
        [DeploymentItem("copytable_tabletocdl.xaml")]
        public void TableToCdl()
        {
            InitDatabase();
            RunEmbeddedScript("CreateTestData.sql");
            using (var runner = CreateRunner())
            {
                runner.LoadFile("copytable_tabletocdl.xaml");
                runner.Run();
            }
        }

        [TestMethod]
        [DeploymentItem("copytable_cdltocdl.xaml")]
        public void CdlToCdl()
        {
            InitDatabase();
            RunEmbeddedScript("CreateTestData.sql");
            using (var runner = CreateRunner())
            {
                runner.LoadFile("copytable_cdltocdl.xaml");
                runner.Run();
            }

            Assert.IsTrue(TestUtility.FileCompare("test1.cdl", "test2.cdl"));
        }

        [TestMethod]
        [DeploymentItem("copytable_tabletotable.xaml")]
        public void TableToTable()
        {
            InitDatabase();
            RunEmbeddedScript("CreateTestData.sql");
            using (var runner = CreateRunner())
            {
                runner.LoadFile("copytable_tabletotable.xaml");
                runner.Run();
            }

            Assert.IsTrue(TestUtility.FileCompareCdlContent("test1.cdl", "test2.cdl"));
        }

        [TestMethod]
        [DeploymentItem("copytable_columnmap.xaml")]
        public void CopyTableColumnMapTest()
        {
            InitDatabase();
            RunEmbeddedScript("CreateTestData.sql");
            using (var runner = CreateRunner())
            {
                runner.LoadFile("copytable_columnmap.xaml");
                runner.Run();
                using (var sr = new StreamReader("test.csv"))
                {
                    sr.ReadLine();
                    string line = sr.ReadLine().Trim();
                    Assert.AreEqual("1,4,AlbumId=1", line);
                }
            }
        }

        [TestMethod]
        [DeploymentItem("copyalltables.xaml")]
        public void CopyAllTablesTest()
        {
            InitDatabase();
            RunEmbeddedScript("CreateTestData.sql");
            using (var runner = CreateRunner())
            {
                runner.LoadFile("copyalltables.xaml");
                runner.Run();
            }
        }

        private void TestValue(string table, string idcol, string idval, string column, string value)
        {
            using (var conn = OpenConnection(true))
            {
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = String.Format("SELECT [{0}] FROM [{1}] WHERE [{2}] = '{3}'", column, table, idcol, idval);
                    string realVal = cmd.ExecuteScalar().SafeToString();
                    Assert.AreEqual(value, realVal);
                }
            }
        }

        [TestMethod]
        [DeploymentItem("mapped_import.xaml")]
        [DeploymentItem("ImportedData.csv")]
        public void MappedImportTest()
        {
            InitDatabase();
            RunEmbeddedScript("CreateTestData.sql");
            using (var runner = CreateRunner())
            {
                runner.LoadFile("mapped_import.xaml");
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

    }
}
