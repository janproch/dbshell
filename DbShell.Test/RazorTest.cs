using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Core.Runtime;
using DbShell.Driver.Common.Utility;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbShell.Test
{
    [TestClass]
    public class RazorTest
    {
        [TestMethod]
        [DeploymentItem("dbdocs.xaml")]
        [DeploymentItem("DatabaseDoc.cshtml")]
        public void DbDocs()
        {
            using (var runner = new ShellRunner())
            {
                runner.LoadFile("dbdocs.xaml");
                runner.Run();
            }
        }

        [TestMethod]
        [DeploymentItem("querytofiles.xaml")]
        public void QueryToFiles()
        {
            using (var runner = new ShellRunner())
            {
                runner.LoadFile("querytofiles.xaml");
                runner.Run();
                Assert.AreEqual("Rock", System.IO.File.ReadAllText("genre1.txt"));
            }
        }

        [TestMethod]
        [DeploymentItem("querytohtml.xaml")]
        [DeploymentItem("TableData.cshtml")]
        public void QueryToHtml()
        {
            using (var runner = new ShellRunner())
            {
                runner.LoadFile("querytohtml.xaml");
                runner.Run();
            }
        }

        //[TestMethod]
        //public void EncodePassword()
        //{
        //    string pwdEnc = XmlTool.SafeEncodeString("");
        //}
    }
}
