using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbShell.Test
{
    [TestClass]
    public class RazorTest
    {
        [TestMethod]
        [DeploymentItem("dbdocs.xaml")]
        [DeploymentItem("dbdocs.cshtml")]
        public void DbDocs()
        {
            using (var runner = new ShellRunner())
            {
                runner.LoadFile("dbdocs.xaml");
                runner.Run();
            }
        }
    }
}
