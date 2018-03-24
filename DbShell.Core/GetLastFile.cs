using DbShell.Driver.Common.Interfaces;
using DbShell.Core.Utility;
using DbShell.Driver.Common.Utility;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DbShell.Core
{
    public class GetLastFile : RunnableBase
    {
        /// <summary>
        /// variable name filled with last file name
        /// </summary>
        [XamlProperty]
        public string Variable { get; set; }

        /// <summary>
        /// file filter to match
        /// </summary>
        [XamlProperty]
        public string Filter { get; set; }

        /// <summary>
        /// regex to filter full file name path
        /// </summary>
        [XamlProperty]
        public string FilenameRegex { get; set; }

        protected override void DoRun(IShellContext context)
        {
            DateTime? maxDate = null;
            string maxFile = null;

            string path = Path.GetDirectoryName(Filter);
            string filter = Path.GetFileName(Filter);

            foreach (string file in Directory.GetFiles(path, filter))
            {
                if (!String.IsNullOrEmpty(FilenameRegex))
                {
                    if (!Regex.Match(file, FilenameRegex).Success)
                    {
                        continue;
                    }
                }

                var lastWrite = System.IO.File.GetLastWriteTime(file);

                if (maxDate == null || lastWrite > maxDate.Value)
                {
                    maxDate = lastWrite;
                    maxFile = file;
                }
            }

            context.SetVariable(context.Replace(Variable), maxFile);
        }
    }
}
