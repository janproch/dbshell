using System;
using System.IO;
using DbShell.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbShell.Test
{
    [TestClass]
    public class SimpleTest
    {
        private bool FileCompareCdlContent(string srcFileName, string dstFileName)
        {
            const int BUFFER_SIZE = 1 << 16;

            FileInfo src = new FileInfo(srcFileName);
            FileInfo dst = new FileInfo(dstFileName);

            using (BinaryReader srcStream = new BinaryReader(src.OpenRead()),
                dstStream = new BinaryReader(dst.OpenRead()))
            {
                srcStream.ReadString();
                dstStream.ReadString();

                byte[] srcBuf = new byte[BUFFER_SIZE];
                byte[] dstBuf = new byte[BUFFER_SIZE];
                int len;
                while ((len = srcStream.Read(srcBuf, 0, srcBuf.Length)) > 0)
                {
                    int len2 = dstStream.Read(dstBuf, 0, dstBuf.Length);
                    if (len != len2) return false;
                    for (int i = 0; i < len; i++)
                        if (srcBuf[i] != dstBuf[i])
                            return false;
                }
                return true;
            }
        }

        private bool FileCompare(string srcFileName, string dstFileName)
        {
            const int BUFFER_SIZE = 1 << 16;

            FileInfo src = new FileInfo(srcFileName);
            FileInfo dst = new FileInfo(dstFileName);
            if (src.Length != dst.Length)
                return false;

            using (Stream srcStream = src.OpenRead(),
                dstStream = dst.OpenRead())
            {
                byte[] srcBuf = new byte[BUFFER_SIZE];
                byte[] dstBuf = new byte[BUFFER_SIZE];
                int len;
                while ((len = srcStream.Read(srcBuf, 0, srcBuf.Length)) > 0)
                {
                    dstStream.Read(dstBuf, 0, dstBuf.Length);
                    for (int i = 0; i < len; i++)
                        if (srcBuf[i] != dstBuf[i])
                            return false;
                }
                return true;
            }
        }

        [TestMethod]
        [DeploymentItem("simple1.xaml")]
        public void TestXamlReader()
        {
            using (var runner = new ShellRunner())
            {
                runner.LoadFile("simple1.xaml");
            }
        }
    
        [TestMethod]
        [DeploymentItem("simple2.xaml")]
        public void TestXamlReader2()
        {
            using (var runner = new ShellRunner())
            {
                runner.LoadFile("simple2.xaml");
            }
        }

        [TestMethod]
        [DeploymentItem("copytable1.xaml")]
        public void CopyTable1Test()
        {
            using (var runner = new ShellRunner())
            {
                runner.LoadFile("copytable1.xaml");
                runner.Run();
            }
        }

        [TestMethod]
        [DeploymentItem("copytable2.xaml")]
        public void CopyTable2Test()
        {
            using (var runner = new ShellRunner())
            {
                runner.LoadFile("copytable2.xaml");
                runner.Run();
            }

            Assert.IsTrue(FileCompare("test1.cdl", "test2.cdl"));
        }

        [TestMethod]
        [DeploymentItem("copytable3.xaml")]
        public void CopyTable3Test()
        {
            using (var runner = new ShellRunner())
            {
                runner.LoadFile("copytable3.xaml");
                runner.Run();
            }

            Assert.IsTrue(FileCompareCdlContent("test1.cdl", "test2.cdl"));
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
