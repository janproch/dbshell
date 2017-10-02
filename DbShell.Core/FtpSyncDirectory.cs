#if !NETSTANDARD2_0

using DbShell.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using System.Net;
using DbShell.Driver.Common.Utility;
using System.IO;

namespace DbShell.Core
{
    public class FtpSyncDirectory : RunnableBase
    {
        [XamlProperty]
        public string FtpDirectory { get; set; }

        [XamlProperty]
        public string Login { get; set; }

        [XamlProperty]
        public string Password { get; set; }

        [XamlProperty]
        public string PasswordEncoded { get; set; }

        [XamlProperty]
        public bool PassiveMode { get; set; }

        [XamlProperty]
        public string LocalDirectory { get; set; }

        protected override void DoRun(IShellContext context)
        {
            FtpWebRequest request = (FtpWebRequest)WebRequest.Create(FtpDirectory);
            //request.Method = WebRequestMethods.Ftp.ListDirectoryDetails;
            request.Method = WebRequestMethods.Ftp.ListDirectory;

            string pwd = Password;
            if (!String.IsNullOrEmpty(PasswordEncoded)) pwd = XmlTool.SafeDecodeString(PasswordEncoded);

            //request.KeepAlive = false;
            //request.UseBinary = true;
            request.UsePassive = PassiveMode;
            request.Credentials = new NetworkCredential(Login, pwd);

            var files = new List<string>();

            using (FtpWebResponse response = (FtpWebResponse)request.GetResponse())
            {
                var responseStream = response.GetResponseStream();
                using (var reader = new StreamReader(responseStream))
                {
                    while (!reader.EndOfStream)
                    {
                        string line = reader.ReadLine()?.Trim();
                        if (String.IsNullOrEmpty(line)) continue;
                        if (line == "." || line == "..") continue;
                        files.Add(line);
                    }
                }
            }

            foreach (string file in files)
            {
                FtpWebRequest requestLength = (FtpWebRequest)WebRequest.Create(FtpDirectory + file);
                requestLength.UsePassive = PassiveMode;
                requestLength.Credentials = new NetworkCredential(Login, pwd);
                requestLength.Method = WebRequestMethods.Ftp.GetFileSize;

                long ftpSize;
                using (FtpWebResponse response = (FtpWebResponse)requestLength.GetResponse())
                {
                    ftpSize = response.ContentLength;
                    response.Close();
                }

                long localSize = 0;
                string localFile = Path.Combine(LocalDirectory, file);
                if (System.IO.File.Exists(localFile)) localSize = new FileInfo(localFile).Length;

                if (localSize != ftpSize)
                {
                    context.OutputMessage($"Downloading file {file}, size={ftpSize}");

                    FtpWebRequest requestFile = (FtpWebRequest)WebRequest.Create(FtpDirectory + file);
                    requestFile.UsePassive = PassiveMode;
                    requestFile.Credentials = new NetworkCredential(Login, pwd);
                    requestFile.Method = WebRequestMethods.Ftp.DownloadFile;

                    using (var response = requestFile.GetResponse())
                    {
                        using (Stream stream = response.GetResponseStream())
                        {
                            using (BinaryWriter writer = new BinaryWriter(System.IO.File.Open(localFile, FileMode.Create)))
                            {
                                int bytesRead = 0;
                                byte[] buffer = new byte[1024];

                                while (true)
                                {
                                    bytesRead = stream.Read(buffer, 0, buffer.Length);
                                    if (bytesRead == 0) break;
                                    writer.Write(buffer, 0, bytesRead);
                                }
                            }
                        }
                    }
                }
                else
                {
                    context.OutputMessage($"Skipping file {file}");
                }
            }
        }
    }
}

#endif