using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;

namespace DbShell.Core
{
    /// <summary>
    /// Basic column mapping. Maps directly input column to output column, no transformation is performed.
    /// </summary>
    public class MapColumn : ElementBase, IColumnMapping
    {
        /// <summary>
        /// Gets or sets the column name.
        /// </summary>
        /// <value>
        /// The name of source column.
        /// </value>
        [XamlProperty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the name of output column. By default, it is the same as Name.
        /// </summary>
        /// <value>
        /// The name of output column.
        /// </value>
        [XamlProperty]
        public string OutputName { get; set; }

        void IColumnMapping.ProcessMapping(int column, int rowNumber, ICdlRecord record, ICdlValueWriter writer, IShellContext context)
        {
            record.ReadValue(record.GetOrdinal(Name));
            record.WriteTo(writer);
        }

        ColumnInfo[] IColumnMapping.GetOutputColumns(TableInfo inputTable, IShellContext context)
        {
            var column = inputTable.Columns[Name].CloneColumn();
            column.Name = OutputName ?? Name;
            return new[] {column};
        }
    }
}
