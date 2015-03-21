using System;
using System.Configuration;
using System.IO;
using DbShell.Core.Runtime;
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
        }

    }
}
