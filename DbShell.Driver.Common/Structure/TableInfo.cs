using System.Collections.Generic;
using System.Xml;
using System.Linq;
using DbShell.Driver.Common.Utility;
using System;

namespace DbShell.Driver.Common.Structure
{
    /// <summary>
    /// Information abou table structure
    /// </summary>
    public class TableInfo : ColumnListInfo
    {
        public TableInfo(DatabaseInfo database)
            : base(database)
        {
        }

        private List<ForeignKeyInfo> _foreignKeys = new List<ForeignKeyInfo>();

        /// <summary>
        /// Table primary key
        /// </summary>
        [XmlSubElem]
        public PrimaryKeyInfo PrimaryKey { get; set; }

        /// <summary>
        /// List of table foreign keys
        /// </summary>
        [XmlCollection(typeof(ForeignKeyInfo))]
        public List<ForeignKeyInfo> ForeignKeys { get { return _foreignKeys; } }

        public TableInfo CloneTable(DatabaseInfo ownerDb = null)
        {
            var res = new TableInfo(ownerDb ?? OwnerDatabase);
            res.Assign(this);
            return res;
        }

        public override DatabaseObjectInfo CloneObject(DatabaseObjectInfo owner)
        {
            return CloneTable(owner as DatabaseInfo);
        }

        public ColumnInfo FindAutoIncrementColumn()
        {
            foreach (var col in Columns)
            {
                if (col.AutoIncrement) return col;
            }
            return null;
        }

        /// <summary>
        /// Gets list of referenced tables
        /// </summary>
        /// <returns></returns>
        public List<ForeignKeyInfo> GetReferences()
        {
            var res = new List<ForeignKeyInfo>();
            foreach (var table in OwnerDatabase.Tables)
            {
                foreach (var fk in table.ForeignKeys)
                {
                    if (fk.RefTable == this) res.Add(fk);
                }
            }
            return res;
        }

        public void SaveToXml(XmlElement xml)
        {
            this.SaveProperties(xml);
        }

        public void LoadFromXml(XmlElement xml)
        {
            this.LoadProperties(xml);
        }

        public override string ToString()
        {
            if (FullName != null) return FullName.ToString();
            return Name;
        }

        public ColumnInfo FindColumn(string column)
        {
            return Columns.FirstOrDefault(c => String.Compare(c.Name, column, true) == 0);
        }

        public override DatabaseObjectType ObjectType
        {
            get { return DatabaseObjectType.Table; }
        }

        public List<ConstraintInfo> Constraints
        {
            get
            {
                var res = new List<ConstraintInfo>();
                if (PrimaryKey != null) res.Add(PrimaryKey);
                res.AddRange(ForeignKeys);
                return res;
            }
        }

        public override void Assign(DatabaseObjectInfo source)
        {
            base.Assign(source);
            var src = (TableInfo) source;
            if (src.PrimaryKey != null) PrimaryKey = src.PrimaryKey.ClonePrimaryKey(this);
            foreach(var fk in src.ForeignKeys)
            {
                ForeignKeys.Add(fk.CloneForeignKey(this));
            }
        }

        public override void AfterLoadLink()
        {
            base.AfterLoadLink();

            if (PrimaryKey!=null) PrimaryKey.AfterLoadLink();
            foreach (var fk in ForeignKeys)
            {
                fk.AfterLoadLink();
            }
        }

        public override void AddAllObjects(List<DatabaseObjectInfo> res)
        {
            base.AddAllObjects(res);
            if (PrimaryKey != null) PrimaryKey.AddAllObjects(res);
            foreach (var x in ForeignKeys) x.AddAllObjects(res);
            foreach (var x in Columns) x.AddAllObjects(res);
        }

        public void DropReferencesTo(NameWithSchema fullName)
        {
            ForeignKeys.RemoveIf(cnt => cnt.RefTable.FullName == fullName);
        }

        public ConstraintInfo FindConstraint(ConstraintInfo cnt)
        {
            if (cnt is PrimaryKeyInfo) return PrimaryKey;
            if (cnt is ForeignKeyInfo) return ForeignKeys.FirstOrDefault(x => x.ConstraintName == cnt.ConstraintName);
            return null;
        }

        public void AddConstraint(ConstraintInfo cnt, bool reuseGrouId = false)
        {
            var primaryKeyInfo = cnt as PrimaryKeyInfo;
            if (primaryKeyInfo != null)
            {
                PrimaryKey = primaryKeyInfo.ClonePrimaryKey(this);
                if (!reuseGrouId) PrimaryKey.GroupId = Guid.NewGuid().ToString();
            }
            var foreignKeyInfo = cnt as ForeignKeyInfo;
            if (foreignKeyInfo != null)
            {
                var fknew = foreignKeyInfo.CloneForeignKey(this);
                if (!reuseGrouId) fknew.GroupId = Guid.NewGuid().ToString();
                ForeignKeys.Add(fknew);
            }
        }

        public void AddColumn(ColumnInfo col, bool reuseGrouId = false)
        {
            var cnew = col.CloneColumn(this);
            if (!reuseGrouId) cnew.GroupId = Guid.NewGuid().ToString();
            Columns.Add(col);
        }

        public void DropColumn(ColumnInfo column)
        {
            Columns.RemoveAll(c => c.Name == column.Name);
        }

        public void DropConstraint(ConstraintInfo cnt)
        {
            if (cnt is PrimaryKeyInfo) PrimaryKey = null;
            if (cnt is ForeignKeyInfo) ForeignKeys.RemoveAll(x => x.ConstraintName == cnt.ConstraintName);
        }
    }
}
