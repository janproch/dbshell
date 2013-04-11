using System;
using System.Collections.Generic;
using System.Linq;

namespace DbShell.Driver.Common.Structure
{
    /// <summary>
    /// Information about database structure
    /// </summary>
    public class DatabaseInfo
    {
        private List<TableInfo> _tables = new List<TableInfo>();
        private List<ViewInfo> _views = new List<ViewInfo>();
        private List<FunctionInfo> _functions = new List<FunctionInfo>();
        private List<StoredProcedureInfo> _storedProcedures = new List<StoredProcedureInfo>();

        /// <summary>
        /// List of tables
        /// </summary>
        public List<TableInfo> Tables { get { return _tables; } }

        public List<ViewInfo> Views { get { return _views; } }

        public List<StoredProcedureInfo> StoredProcedures { get { return _storedProcedures; } }

        public List<FunctionInfo> Functions { get { return _functions; } }


        public TableInfo FindTable(string table)
        {
            return _tables.FirstOrDefault(t => String.Compare(t.Name, table, true) == 0);
        }

        public TableInfo FindTable(string schema, string table)
        {
            if (schema == null)
            {
                return _tables.FirstOrDefault(t => String.Compare(t.Name, table, true) == 0);
            }
            else
            {
                return _tables.FirstOrDefault(t => String.Compare(t.Name, table, true) == 0 && String.Compare(t.Schema, schema, true) == 0);
            }
        }

        public ViewInfo FindView(string view)
        {
            return _views.FirstOrDefault(t => String.Compare(t.Name, view, true) == 0);
        }

        public ViewInfo FindView(string schema, string view)
        {
            if (schema == null)
            {
                return _views.FirstOrDefault(t => String.Compare(t.Name, view, true) == 0);
            }
            else
            {
                return _views.FirstOrDefault(t => String.Compare(t.Name, view, true) == 0 && String.Compare(t.Schema, schema, true) == 0);
            }
        }

        //public ColumnInfo FindColumn(string table, string column)
        //{
        //    var tbl = FindTable(table);
        //    if (tbl == null) return null;
        //    return tbl.Columns.FirstOrDefault(c => String.Compare(c.Name, column, true) == 0);
        //}
    }
}
