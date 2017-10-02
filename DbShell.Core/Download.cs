#if !NETSTANDARD2_0

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Driver.Common.Utility;

namespace DbShell.Core
{
    /// <summary>
    /// Writes string or binary data to file or to variable
    /// </summary>
    public class Download : RunnableBase
    {
        /// <summary>
        /// Gets or sets the file name
        /// </summary>
        [XamlProperty]
        public string File { get; set; }

        /// <summary>
        /// URL to be downloaded
        /// </summary>
        [XamlProperty]
        public string Url { get; set; }

        protected override void DoRun(IShellContext context)
        {
            string file = context.ResolveFile(context.Replace(File), ResolveFileMode.Output);
            string url = context.Replace(Url);
            context.OutputMessage("Downloading from URL " + url);
            using (var client = new WebClient())
            {
                client.DownloadFile(url, file);
            }
        }
    }
}

#endif