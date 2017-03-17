using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;
using log4net;
using DbShell.Driver.Common.Utility;

namespace DbShell.Core
{
    /// <summary>
    /// generates temporary file name
    /// </summary>
    public class TempFile : RunnableBase
    {
        private static readonly ILog _log = LogManager.GetLogger(typeof(TempFile));

        /// <summary>
        /// variable name filled with temp file name
        /// </summary>
        [XamlProperty]
        public string Variable { get; set; }

        protected override void DoRun(IShellContext context)
        {
            string file = Path.GetTempFileName();
            context.SetVariable(context.Replace(Variable), file);
            context.AddDisposableItem(new TempFileHolder
            {
                File = file,
            });
        }

        private class TempFileHolder : IDisposable
        {
            internal string File;

            public void Dispose()
            {
                try
                {
                    System.IO.File.Delete(File);
                }
                catch (Exception err)
                {
                    _log.Error("DBSH-00000 Error deleting temporary file", err);
                }
            }
        }
    }
}
