using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.Structure
{
    /// <summary>
    /// Information about database structure
    /// </summary>
    public class DatabaseInfo : IExplicitXmlPersistent
    {
        private List<TableInfo> _tables = new List<TableInfo>();
        private List<ViewInfo> _views = new List<ViewInfo>();
        private List<FunctionInfo> _functions = new List<FunctionInfo>();
        private List<StoredProcedureInfo> _storedProcedures = new List<StoredProcedureInfo>();

        /// <summary>
        /// List of tables
        /// </summary>
        [XmlCollection(typeof(TableInfo))]
        public List<TableInfo> Tables { get { return _tables; } }

        [XmlCollection(typeof(ViewInfo))]
        public List<ViewInfo> Views { get { return _views; } }

        [XmlCollection(typeof(StoredProcedureInfo))]
        public List<StoredProcedureInfo> StoredProcedures { get { return _storedProcedures; } }

        [XmlCollection(typeof(FunctionInfo))]
        public List<FunctionInfo> Functions { get { return _functions; } }

        [XmlElem]
        public string DefaultSchema { get; set; }

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

        public TableInfo GetTable(NameWithSchema table)
        {
            return _tables.FirstOrDefault(t => t.FullName == table);
        }

        public ViewInfo GetView(NameWithSchema table)
        {
            return _views.FirstOrDefault(v => v.FullName == table);
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

        private bool? _isSingleSchema;

        /// <summary>
        /// all database objects have DefaultSchema schema
        /// </summary>
        public bool IsSingleSchema
        {
            get
            {
                if (_isSingleSchema == null)
                {
                    _isSingleSchema = DetectSingleSchema();
                }
                return _isSingleSchema.Value;
            }
        }

        private bool DetectSingleSchema()
        {
            if (Tables.Any(o => o.Schema != DefaultSchema)) return false;
            if (Views.Any(o => o.Schema != DefaultSchema)) return false;
            if (StoredProcedures.Any(o => o.Schema != DefaultSchema)) return false;
            if (Functions.Any(o => o.Schema != DefaultSchema)) return false;
            return true;
        }

        //public ColumnInfo FindColumn(string table, string column)
        //{
        //    var tbl = FindTable(table);
        //    if (tbl == null) return null;
        //    return tbl.Columns.FirstOrDefault(c => String.Compare(c.Name, column, true) == 0);
        //}
        public DatabaseObjectInfo FindObjectById(string id)
        {
            DatabaseObjectInfo res;

            res = Tables.FirstOrDefault(o => o.ObjectId == id);
            if (res != null) return res;

            res = Views.FirstOrDefault(o => o.ObjectId == id);
            if (res != null) return res;

            res = StoredProcedures.FirstOrDefault(o => o.ObjectId == id);
            if (res != null) return res;

            res = Functions.FirstOrDefault(o => o.ObjectId == id);
            if (res != null) return res;

            return null;
        }

        public DatabaseObjectInfo RemoveObjectById(string id)
        {
            var tres = Tables.FirstOrDefault(o => o.ObjectId == id);
            if (tres != null)
            {
                Tables.Remove(tres);
                return tres;
            }

            var vres = Views.FirstOrDefault(o => o.ObjectId == id);
            if (vres != null)
            {
                Views.Remove(vres);
                return vres;
            }

            var pres = StoredProcedures.FirstOrDefault(o => o.ObjectId == id);
            if (pres != null)
            {
                StoredProcedures.Remove(pres);
                return pres;
            }

            var fres = Functions.FirstOrDefault(o => o.ObjectId == id);
            if (fres != null)
            {
                Functions.Remove(fres);
                return fres;
            }

            return null;
        }

        public void Assign(DatabaseInfo source)
        {
            foreach (var obj in source.Tables) Tables.Add(obj.Clone(this));
            foreach (var obj in source.Views) Views.Add(obj.Clone(this));
            foreach (var obj in source.StoredProcedures) StoredProcedures.Add(obj.Clone(this));
            foreach (var obj in source.Functions) Functions.Add(obj.Clone(this));
            DefaultSchema = source.DefaultSchema;
            AfterLoadLink();
        }

        public void SaveToXml(XmlElement xml)
        {
            this.SavePropertiesCore(xml);
        }

        public void LoadFromXml(XmlElement xml)
        {
            this.LoadPropertiesCore(xml);
            AfterLoadLink();
        }

        private void AfterLoadLink()
        {
            foreach (var obj in Tables) obj.AfterLoadLink();
            foreach (var obj in Views) obj.AfterLoadLink();
            foreach (var obj in StoredProcedures) obj.AfterLoadLink();
            foreach (var obj in Tables) obj.AfterLoadLink();
        }

        public DatabaseInfo Clone()
        {
            var res = new DatabaseInfo();
            res.Assign(this);
            return res;
        }
    }
}
