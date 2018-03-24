using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.Interfaces
{
    /// <summary>
    /// Defines column mapping for <see cref="DbShell.Core.CopyTable"/> operation
    /// </summary>
    public interface IColumnMapping
    {
        /// <summary>
        /// Gets the names and types of destination columns.
        /// </summary>
        /// <returns>The output columns</returns>
        ColumnInfo[] GetOutputColumns(TableInfo inputTable, IShellContext context);

        /// <summary>
        /// Processes mapping in source row for given column
        /// </summary>
        /// <param name="column">Processed column index (index to array retured by GetOutputColumns()).</param>
        /// <param name="rowNumber">number of processed row (1-based index)</param>
        /// <param name="record">The source record.</param>
        /// <param name="writer">The target writer.</param>
        void ProcessMapping(int column, int rowNumber, ICdlRecord record, ICdlValueWriter writer, IShellContext context);
    }
}
