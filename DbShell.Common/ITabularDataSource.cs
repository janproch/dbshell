using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;

namespace DbShell.Common
{
    /// <summary>
    /// Represents source holding table data (eg. table, CSV file)
    /// </summary>
    public interface ITabularDataSource
    {
        /// <summary>
        /// Gets table structure of row
        /// </summary>
        /// <returns></returns>
        TableInfo GetRowFormat(IShellContext context);
        /// <summary>
        /// Creates the reader
        /// </summary>
        /// <returns></returns>
        ICdlReader CreateReader(IShellContext context);
    }
}
