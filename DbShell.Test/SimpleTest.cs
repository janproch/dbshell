using System;
using DbShell.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbShell.Test
{
    [TestClass]
    public class SimpleTest
    {
        [TestMethod]
        [DeploymentItem("simple.xaml")]
        public void TestXamlReader()
        {
            var runner = new ShellRunner();
            runner.LoadFile("simple.xaml");
            runner.Run();
        }

        [TestMethod]
        [DeploymentItem("simple2.xaml")]
        public void TestXamlReader2()
        {
            var runner = new ShellRunner();
            runner.LoadFile("simple2.xaml");
            runner.Run();
        }
    }
}
