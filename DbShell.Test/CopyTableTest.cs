using System;
using System.IO;
using DbShell.Runtime;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace DbShell.Test
{
    [TestClass]
    public class CopyTableTest
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

            Assert.IsTrue(FileCompare("test1.cdl", "test2.cdl"));
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

            Assert.IsTrue(FileCompareCdlContent("test1.cdl", "test2.cdl"));
        }

        [TestMethod]
        [DeploymentItem("copytable_columnmap.xaml")]
        public void CopyTableColumnMapTest()
        {
            using (var runner = new ShellRunner())
            {
                runner.LoadFile("copytable_columnmap.xaml");
                runner.Run();
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
