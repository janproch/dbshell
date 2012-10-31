using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Common
{
    /// <summary>
    /// Defines job, which is run in DB Shell batch
    /// </summary>
    public interface IRunnable
    {
        /// <summary>
        /// Runs job
        /// </summary>
        void Run();
    }
}
