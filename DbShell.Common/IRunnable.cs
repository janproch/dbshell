using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Common
{
    /// <summary>
    /// is aiable to be run from Db Shell
    /// </summary>
    public interface IRunnable
    {
        /// <summary>
        /// Runs job
        /// </summary>
        void Run();
    }
}
