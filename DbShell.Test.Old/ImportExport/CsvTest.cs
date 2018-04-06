using System;
using DbShell.Core.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbShell.Test
{
    [TestClass]
    public class CsvTest
    {
        [TestMethod]
        [DeploymentItem("ImportExport/csvexport.xaml")]
        [DeploymentItem("ImportExport/Album.cdl")]
        public void CsvExport()
        {
            using (var runner = new ShellRunner())
            {
                runner.LoadFile("csvexport.xaml");
                runner.Run();
            }
        }

        [TestMethod]
        [DeploymentItem("ImportExport/csvimport.xaml")]
        [DeploymentItem("ImportExport/Album.cdl")]
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
