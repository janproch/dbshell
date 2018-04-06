using DbShell.All;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace DbShell.Test
{
    public static class TestUtility
    {
        private static void ConfigureServices(IServiceCollection services)
        {
            services.AddLogging();
            services.AddDbShell();
        }

        public static IServiceProvider BuildServiceProvider()
        {
            var services = new ServiceCollection();
            ConfigureServices(services);
            var serviceProvider = services.BuildServiceProvider();
            return serviceProvider;
        }

        public static bool FileCompareCdlContent(string srcFileName, string dstFileName)
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

        public static bool FileCompare(string srcFileName, string dstFileName)
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

    }
}
