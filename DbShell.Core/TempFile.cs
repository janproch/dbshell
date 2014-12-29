using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;

namespace DbShell.Core
{
    /// <summary>
    /// generates temporary file name
    /// </summary>
    public class TempFile : RunnableBase
    {
        /// <summary>
        /// variable name filled with temp file name
        /// </summary>
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
                System.IO.File.Delete(File);
            }
        }
    }
}
