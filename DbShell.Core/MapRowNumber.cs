﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.Structure;

namespace DbShell.Core
{
    /// <summary>
    /// Maps output column to row number
    /// </summary>
    public class MapRowNumber : ElementBase, IColumnMapping
    {
        /// <summary>
        /// Gets or sets the name of output column.
        /// </summary>
        /// <value>
        /// The name of output column.
        /// </value>
        [XamlProperty]
        public string Name { get; set; }

        ColumnInfo[] IColumnMapping.GetOutputColumns(TableInfo inputTable)
        {
            var column = new ColumnInfo(new TableInfo(null)) { CommonType = new DbTypeInt(), Name = Name, DataType = "nvarchar", Length = -1 };
            return new[] { column };
        }

        void IColumnMapping.ProcessMapping(int column, int rowNumber, ICdlRecord record, ICdlValueWriter writer)
        {
            writer.SetInt32(rowNumber);
        }
    }
}
