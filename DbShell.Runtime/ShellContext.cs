using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;

namespace DbShell.Runtime
{
    public class ShellContext : IShellContext, IDisposable
    {
        public IConnectionProvider ConnectionProvider { get; set; }
        public string CurrentDirectory { get; set; }

        /// <summary>
        /// Performs application-defined tasks associated with freeing, releasing, or resetting unmanaged resources.
        /// </summary>
        /// <filterpriority>2</filterpriority>
        public void Dispose()
        {
        }
    }
}
