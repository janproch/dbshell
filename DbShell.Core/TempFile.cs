using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Interfaces;
using DbShell.Core.Utility;
using DbShell.Driver.Common.Utility;
using Microsoft.Extensions.Logging;

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
        [XamlProperty]
        public string Variable { get; set; }

        protected override void DoRun(IShellContext context)
        {
            string file = Path.GetTempFileName();
            context.SetVariable(context.Replace(Variable), file);
            context.AddDisposableItem(new TempFileHolder
            {
                File = file,
                Context = context,
            });
        }

        private class TempFileHolder : IDisposable
        {
            internal string File;
            internal IShellContext Context;

            public void Dispose()
            {
                try
                {
                    System.IO.File.Delete(File);
                }
                catch (Exception err)
                {
                    Context.GetLogger<TempFile>().LogError(0, err, "DBSH-00000 Error deleting temporary file");
                }
            }
        }
    }
}
