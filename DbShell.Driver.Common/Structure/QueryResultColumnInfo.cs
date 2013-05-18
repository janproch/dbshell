using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.DmlFramework;

namespace DbShell.Driver.Common.Structure
{
    public class QueryResultColumnInfo
    {
        public string Name { get; set; }

        public string DataType { get; set; }

        /// <summary>
        /// Portable data type
        /// </summary>
        public DbTypeBase CommonType { get; set; }

        public bool IsAliased { get; set; }

        public bool IsHidden { get; set; }

        public bool IsReadOnly { get; set; }

        public bool IsKey { get; set; }

        public bool NotNull { get; set; }

        public bool AutoIncrement { get; set; }

        public string BaseServerName { get; set; }
        public string BaseCatalogName { get; set; }
        public string BaseColumnName { get; set; }
        public string BaseSchemaName { get; set; }
        public string BaseTableName { get; set; }

        public ColumnInfo FindOriginalColumn(DatabaseInfo db, NameWithSchema baseName)
        {
            string name = IsAliased ? BaseColumnName : Name;
            if (name == null) return null;

            // determine original table name
            TableInfo table = null;
            if (!String.IsNullOrEmpty(BaseTableName))
            {
                table = db.FindTable(String.IsNullOrWhiteSpace(BaseSchemaName) ? null : BaseSchemaName, BaseTableName);
            }
            else
            {
                if (baseName != null) table = db.FindTable(baseName.Schema, baseName.Name);
            }
            if (table == null) return null;

            var tableCol = table.FindColumn(name);
            return tableCol;
        }
    }
}
