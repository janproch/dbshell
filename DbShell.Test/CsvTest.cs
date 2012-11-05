using System;
using DbShell.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbShell.Test
{
    [TestClass]
    public class CsvTest
    {
        [TestMethod]
        [DeploymentItem("csvexport.xaml")]
        [DeploymentItem("Album.cdl")]
        public void CsvExport()
        {
            using (var runner = new ShellRunner())
            {
                runner.LoadFile("csvexport.xaml");
                runner.Run();
            }
        }

        [TestMethod]
        [DeploymentItem("csvimport.xaml")]
        [DeploymentItem("Album.cdl")]
        public void CsvImport()
        {
            using (var runner = new ShellRunner())
            {
                runner.LoadFile("csvimport.xaml");
                runner.Run();
                Assert.IsTrue(TestUtility.FileCompare("Album.csv", "Album2.csv"));
            }
        }
    }
}
