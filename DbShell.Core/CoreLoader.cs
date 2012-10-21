using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.SqlServer;

namespace DbShell.Core
{
    public static class CoreLoader
    {
        /// <summary>
        /// initializes core
        /// </summary>
        public static void Load()
        {
            SqlServerDatabaseFactory.Initialize();
        }
    }
}
