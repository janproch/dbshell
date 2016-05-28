using DbShell.Core.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbShell.Test
{
    [TestClass]
    public class XamlReaderTest
    {
        [TestMethod]
        [DeploymentItem("Basics/xamltest1.xaml")]
        public void XamlReader1()
        {
            using (var runner = new ShellRunner())
            {
                runner.LoadFile("xamltest1.xaml");
            }
        }

        [TestMethod]
        [DeploymentItem("Basics/xamltest2.xaml")]
        public void XamlReader2()
        {
            using (var runner = new ShellRunner())
            {
                runner.LoadFile("xamltest2.xaml");
            }
        }
    }
}