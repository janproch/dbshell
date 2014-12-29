using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;

namespace DbShell.Common
{
    /// <summary>
    /// Represents target accepting table data (eg. table, CSV file)
    /// </summary>
    public interface ITabularDataTarget
    {
        /// <summary>
        /// Gets a value indicating whether target has fixed row format (eg. table) or not (eg. created CSV file or newly created table)
        /// </summary>
        /// <value>
        ///   <c>true</c> if available row format; otherwise, <c>false</c>.
        /// </value>
        bool IsAvailableRowFormat(IShellContext context);
        ICdlWriter CreateWriter(TableInfo rowFormat, CopyTableTargetOptions options, IShellContext context, DataFormatSettings sourceDataFormat);
        TableInfo GetRowFormat(IShellContext context);
    }
}
