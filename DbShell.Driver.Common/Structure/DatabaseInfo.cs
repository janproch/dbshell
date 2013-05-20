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


        private T FindObject<T>(IEnumerable<T> objs, string name )
            where T : NamedObjectInfo
        {
            return objs.FirstOrDefault(t => String.Compare(t.Name, name, true) == 0);
        }

        private T FindObject<T>(IEnumerable<T> objs, string schema, string name)
            where T : NamedObjectInfo
        {
            if (schema == null)
            {
                return objs.FirstOrDefault(t => String.Compare(t.Name, name, true) == 0);
            }
            else
            {
                return objs.FirstOrDefault(t => String.Compare(t.Name, name, true) == 0 && String.Compare(t.Schema, schema, true) == 0);
            }
        }

        public TableInfo FindTable(string table)
        {
            return FindObject(_tables, table);
        }

        public TableInfo FindTable(string schema, string table)
        {
            return FindObject(_tables, schema, table);
        }

        public ViewInfo FindView(string view)
        {
            return FindObject(_views, view);
        }

        public ViewInfo FindView(string schema, string view)
        {
            return FindObject(_views, schema, view);
        }

        public ProgrammableInfo FindProgrammable(string name, bool procedure = true, bool function = true)
        {
            if (procedure)
            {
                var res = FindObject(_storedProcedures, name);
                if (res != null) return res;
            }
            if (function)
            {
                var res = FindObject(_functions, name);
                if (res != null) return res;
            }
            return null;
        }

        public ProgrammableInfo FindProgrammable(string schema, string name, bool procedure = true, bool function = true)
        {
            if (procedure)
            {
                var res = FindObject(_storedProcedures, schema, name);
                if (res != null) return res;
            }
            if (function)
            {
                var res = FindObject(_functions, schema, name);
                if (res != null) return res;
            }
            return null;
        }

        //public ColumnInfo FindColumn(string table, string column)
        //{
        //    var tbl = FindTable(table);
        //    if (tbl == null) return null;
        //    return tbl.Columns.FirstOrDefault(c => String.Compare(c.Name, column, true) == 0);
        //}
    }
}
