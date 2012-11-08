using System;
using System.IO;
using DbShell.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbShell.Test
{
    [TestClass]
    public class CopyTableTest
    {
        [TestMethod]
        [DeploymentItem("copytable_tabletocdl.xaml")]
        public void TableToCdl()
        {
            using (var runner = new ShellRunner())
            {
                runner.LoadFile("copytable_tabletocdl.xaml");
                runner.Run();
            }
        }

        [TestMethod]
        [DeploymentItem("copytable_cdltocdl.xaml")]
        public void CdlToCdl()
        {
            using (var runner = new ShellRunner())
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
            using (var runner = new ShellRunner())
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
            using (var runner = new ShellRunner())
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
            using (var runner = new ShellRunner())
            {
                runner.LoadFile("copyalltables.xaml");
                runner.Run();
            }
        }
    }
}
