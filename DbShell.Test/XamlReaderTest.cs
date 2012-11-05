using DbShell.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbShell.Test
{
    [TestClass]
    public class XamlReaderTest
    {
        [TestMethod]
        [DeploymentItem("xamltest1.xaml")]
        public void XamlReader1()
        {
            using (var runner = new ShellRunner())
            {
                runner.LoadFile("xamltest1.xaml");
            }
        }

        [TestMethod]
        [DeploymentItem("xamltest2.xaml")]
        public void XamlReader2()
        {
            using (var runner = new ShellRunner())
            {
                runner.LoadFile("xamltest2.xaml");
            }
        }
    }
}