using System;
using System.Collections.Generic;
using System.Linq;
using System.Xml;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.DbDiff;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.Structure
{
    /// <summary>
    /// Information about database structure
    /// </summary>
    public class DatabaseInfo : DatabaseObjectInfo, IExplicitXmlPersistent
    {
        public static readonly DatabaseInfo Empty = new DatabaseInfo();

        private List<TableInfo> _tables = new List<TableInfo>();
        private List<ViewInfo> _views = new List<ViewInfo>();
        private List<FunctionInfo> _functions = new List<FunctionInfo>();
        private List<TriggerInfo> _triggers = new List<TriggerInfo>();
        private List<StoredProcedureInfo> _storedProcedures = new List<StoredProcedureInfo>();
        private List<SchemaInfo> _schemas = new List<SchemaInfo>();

        public DatabaseInfo()
            : base(null)
        {
        }

        /// <summary>
        /// List of tables
        /// </summary>
        [XmlCollection(typeof (TableInfo))]
        public List<TableInfo> Tables
        {
            get { return _tables; }
        }

        [XmlCollection(typeof (ViewInfo))]
        public List<ViewInfo> Views
        {
            get { return _views; }
        }

        [XmlCollection(typeof (StoredProcedureInfo))]
        public List<StoredProcedureInfo> StoredProcedures
        {
            get { return _storedProcedures; }
        }

        [XmlCollection(typeof (FunctionInfo))]
        public List<FunctionInfo> Functions
        {
            get { return _functions; }
        }

        [XmlCollection(typeof(TriggerInfo))]
        public List<TriggerInfo> Triggers
        {
            get { return _triggers; }
        }

        [XmlCollection(typeof(SchemaInfo))]
        public List<SchemaInfo> Schemas
        {
            get { return _schemas; }
        }

        [XmlElem]
        public string DefaultSchema { get; set; }

        private T FindObjectLike<T>(IEnumerable<T> objs, string name)
            where T : NamedObjectInfo
        {
            if (name != null && name.Contains("."))
            {
                var fullName = NameWithSchema.Parse(name);
                return FindObjectLike(objs, fullName.Schema, fullName.Name);
            }
            return objs.FirstOrDefault(t => String.Compare(t.Name, name, true) == 0);
        }

        private T FindObjectLike<T>(IEnumerable<T> objs, string schema, string name)
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

        public TableInfo FindTableLike(string table)
        {
            return FindObjectLike(_tables, table);
        }

        public TableInfo FindTable(NameWithSchema fullName)
        {
            return Tables.FirstOrDefault(t => t.FullName == fullName);
        }

        public TableInfo FindTable(TableInfo table)
        {
            return FindTableLike(table.Name);
        }

        public TableInfo FindTableLike(string schema, string table)
        {
            return FindObjectLike(_tables, schema, table);
        }

        public ViewInfo FindViewLike(string view)
        {
            return FindObjectLike(_views, view);
        }

        public ViewInfo FindView(NameWithSchema fullName)
        {
            return _views.FirstOrDefault(v => v.FullName == fullName);
        }

        public ViewInfo FindView(ViewInfo view)
        {
            return FindView(view.FullName);
        }

        public ViewInfo FindViewLike(string schema, string view)
        {
            return FindObjectLike(_views, schema, view);
        }

        public ColumnInfo FindColumn(ColumnInfo column)
        {
            return FindTable(column.OwnerTable.FullName).Columns.First(c => c.Name == column.Name);
        }

        public ProgrammableInfo FindProgrammableLike(string name, bool procedure = true, bool function = true)
        {
            if (procedure)
            {
                var res = FindObjectLike(_storedProcedures, name);
                if (res != null) return res;
            }
            if (function)
            {
                var res = FindObjectLike(_functions, name);
                if (res != null) return res;
            }
            return null;
        }

        public ProgrammableInfo FindProgrammableLike(string schema, string name, bool procedure = true, bool function = true)
        {
            if (procedure)
            {
                var res = FindObjectLike(_storedProcedures, schema, name);
                if (res != null) return res;
            }
            if (function)
            {
                var res = FindObjectLike(_functions, schema, name);
                if (res != null) return res;
            }
            return null;
        }

        public StoredProcedureInfo FindStoredProcedure(NameWithSchema fullName)
        {
            return StoredProcedures.FirstOrDefault(x => x.FullName == fullName);
        }

        public FunctionInfo FindFunction(NameWithSchema fullName)
        {
            return Functions.FirstOrDefault(x => x.FullName == fullName);
        }

        public TriggerInfo FindTrigger(NameWithSchema fullName)
        {
            return Triggers.FirstOrDefault(x => x.FullName == fullName);
        }

        public StoredProcedureInfo FindStoredProcedure(StoredProcedureInfo obj)
        {
            return FindStoredProcedure(obj.FullName);
        }

        public FunctionInfo FindFunction(FunctionInfo obj)
        {
            return FindFunction(obj.FullName);
        }

        public TriggerInfo FindTrigger(TriggerInfo obj)
        {
            return FindTrigger(obj.FullName);
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
            if (Triggers.Any(o => o.Schema != DefaultSchema)) return false;
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

            res = Triggers.FirstOrDefault(o => o.ObjectId == id);
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

            var rres = Triggers.FirstOrDefault(o => o.ObjectId == id);
            if (rres != null)
            {
                Triggers.Remove(rres);
                return rres;
            }

            return null;
        }

        public void AssignPhaseData(DatabaseObjectInfo source, DatabaseAnalysePhase phase)
        {
            var src = (DatabaseInfo)source;

            if ((phase & DatabaseAnalysePhase.Tables) != 0)
            {
                Tables.Clear();
                foreach (var obj in src.Tables) Tables.Add(obj.CloneTable(this));
            }
            if ((phase & DatabaseAnalysePhase.Views) != 0)
            {
                Views.Clear();
                foreach (var obj in src.Views) Views.Add(obj.CloneView(this));
            }
            if ((phase & DatabaseAnalysePhase.Functions) != 0)
            {
                StoredProcedures.Clear();
                Functions.Clear();
                Triggers.Clear();
                foreach (var obj in src.StoredProcedures) StoredProcedures.Add(obj.CloneStoredProcedure(this));
                foreach (var obj in src.Functions) Functions.Add(obj.CloneFunction(this));
                foreach (var obj in src.Triggers) Triggers.Add(obj.CloneTrigger(this));
            }
            if ((phase & DatabaseAnalysePhase.Settings) != 0)
            {
                Schemas.Clear();
                foreach (var obj in src.Schemas) Schemas.Add(obj.CloneSchema(this));
                DefaultSchema = src.DefaultSchema;
            }
        }


        public override void Assign(DatabaseObjectInfo source)
        {
            base.Assign(source);
            AssignPhaseData(source, DatabaseAnalysePhase.All);
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

        public override DatabaseObjectType ObjectType
        {
            get { return DatabaseObjectType.Database; }
        }

        public override void AfterLoadLink()
        {
            foreach (var obj in Tables) obj.AfterLoadLink();
            foreach (var obj in Views) obj.AfterLoadLink();
            foreach (var obj in StoredProcedures) obj.AfterLoadLink();
            foreach (var obj in Functions) obj.AfterLoadLink();
            foreach (var obj in Triggers) obj.AfterLoadLink();
            foreach (var obj in Schemas) obj.AfterLoadLink();
        }

        public DatabaseInfo CloneDatabase()
        {
            var res = new DatabaseInfo();
            res.Assign(this);
            return res;
        }

        public override DatabaseObjectInfo CloneObject(DatabaseObjectInfo owner)
        {
            return CloneDatabase();
        }

        public override void AddAllObjects(List<DatabaseObjectInfo> res)
        {
            base.AddAllObjects(res);
            foreach (var x in Tables) x.AddAllObjects(res);
            foreach (var x in Views) x.AddAllObjects(res);
            foreach (var x in StoredProcedures) x.AddAllObjects(res);
            foreach (var x in Functions) x.AddAllObjects(res);
            foreach (var x in Triggers) x.AddAllObjects(res);
            foreach (var x in Schemas) x.AddAllObjects(res);
        }

        public List<DatabaseObjectInfo> GetAllObjects()
        {
            var res = new List<DatabaseObjectInfo>();
            AddAllObjects(res);
            return res;
        }

        public DatabaseObjectInfo FindByGroupId(string groupid)
        {
            foreach (var obj in GetAllObjects())
            {
                if (obj.GroupId == groupid) return obj;
            }
            return null;
        }

        public T FindByGroupId<T>(T obj) where T : DatabaseObjectInfo
        {
            return (T) FindByGroupId(obj.GroupId);
        }

        public TableInfo AddTable(NameWithSchema name)
        {
            var res = new TableInfo(this);
            res.FullName = name;
            Tables.Add(res);
            return res;
        }

        public TableInfo AddTable(TableInfo table, bool reuseGroupId)
        {
            var res = table.CloneTable(this);
            if (!reuseGroupId) res.GroupId = Guid.NewGuid().ToString();
            Tables.Add(res);
            return res;
        }

        public TableInfo FindOrCreateTable(NameWithSchema name)
        {
            var res = FindTable(name);
            if (res == null) res = AddTable(name);
            return res;
        }

        public ConstraintInfo FindOrCreateConstraint(ConstraintInfo cnt)
        {
            var t = FindOrCreateTable(cnt.OwnerTable.FullName);
            var res = t.FindConstraint(cnt);
            if (res == null)
            {
                t.AddConstraint(cnt);
            }
            return res;
        }

        public ColumnInfo FindOrCreateColumn(ColumnInfo col)
        {
            var t = FindOrCreateTable(col.OwnerTable.FullName);
            return t.FindOrCreateColumn(col);
        }

        public SpecificObjectInfo FindOrCreateSpecificObject(SpecificObjectInfo obj)
        {
            var res = FindSpecificObject(obj);
            if (res == null) res = AddSpecificObject(obj, false);
            return res;
        }

        private SpecificObjectInfo AddSpecificObject(SpecificObjectInfo obj, bool reuseGroupId)
        {
            var res = obj.CloneSpecificObject(this);
            if (!reuseGroupId) res.GroupId = Guid.NewGuid().ToString();
            switch (obj.ObjectType)
            {
                case DatabaseObjectType.View:
                    Views.Add((ViewInfo) res);
                    break;
                case DatabaseObjectType.StoredProcedure:
                    StoredProcedures.Add((StoredProcedureInfo) res);
                    break;
                case DatabaseObjectType.Function:
                    Functions.Add((FunctionInfo) res);
                    break;
                case DatabaseObjectType.Trigger:
                    Triggers.Add((TriggerInfo)res);
                    break;
            }
            return res;
        }

        private SpecificObjectInfo FindSpecificObject(SpecificObjectInfo obj)
        {
            return
                (SpecificObjectInfo) FindStoredProcedure(obj.FullName)
                ?? (SpecificObjectInfo) FindFunction(obj.FullName)
                ?? (SpecificObjectInfo) FindView(obj.FullName)
                ?? (SpecificObjectInfo) FindTrigger(obj.FullName);
        }

        public void AddObject(DatabaseObjectInfo obj, bool reuseGrouId)
        {
            var col = obj as ColumnInfo;
            if (col != null)
            {
                var t = FindOrCreateTable(col.OwnerTable.FullName);
                t.AddColumn(col, reuseGrouId);
                return;
            }
            var cnt = obj as ConstraintInfo;
            if (cnt != null)
            {
                var t = FindOrCreateTable(col.OwnerTable.FullName);
                t.AddConstraint(cnt, reuseGrouId);
                return;
            }
            var tbl = obj as TableInfo;
            if (tbl != null)
            {
                AddTable(tbl, reuseGrouId);
                return;
            }
            var spe = obj as SpecificObjectInfo;
            if (spe != null)
            {
                AddSpecificObject(spe, reuseGrouId);
                return;
            }
            //var sch = obj as ISchemaStructure;
            //if (sch != null)
            //{
            //    AddSchema(sch, reuseGrouId);
            //    return;
            //}
            //var dom = obj as IDomainStructure;
            //if (dom != null)
            //{
            //    AddDomain(dom, reuseGrouId);
            //    return;
            //}
        }

        public List<SpecificObjectInfo> GetAllSpecificObjects()
        {
            var res = new List<SpecificObjectInfo>();
            res.AddRange(Views);
            res.AddRange(StoredProcedures);
            res.AddRange(Functions);
            res.AddRange(Triggers);
            return res;
        }

        public IAlterProcessor AlterProcessor
        {
            get { return new DatabaseInfoAlterProcessor(this); }
        }

        public ConstraintInfo FindConstraint(ConstraintInfo constraint)
        {
            return FindTable(constraint.OwnerTable.FullName).Constraints.First(c => c.ConstraintName == constraint.ConstraintName);
        }
    }
}
