using System;
using System.Collections.Generic;
using System.Linq;

namespace DbShell.Driver.Common.Structure
{
    public class DatabaseInfo
    {
        private List<TableInfo> _tables = new List<TableInfo>();

        public List<TableInfo> Tables { get { return _tables; } }

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

        //public ColumnInfo FindColumn(string table, string column)
        //{
        //    var tbl = FindTable(table);
        //    if (tbl == null) return null;
        //    return tbl.Columns.FirstOrDefault(c => String.Compare(c.Name, column, true) == 0);
        //}
    }
}
