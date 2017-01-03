using System.Collections.Generic;
using System.Xml;
using System.Linq;
using DbShell.Driver.Common.DbDiff;
using DbShell.Driver.Common.Utility;
using System;
using DbShell.Driver.Common.CommonTypeSystem;
using System.Runtime.Serialization;

namespace DbShell.Driver.Common.Structure
{
    /// <summary>
    /// Information abou table structure
    /// </summary>
    [DataContract]
    public class TableInfo : ColumnListInfo
    {
        public TableInfo(DatabaseInfo database)
            : base(database)
        {
        }

        private List<ForeignKeyInfo> _foreignKeys = new List<ForeignKeyInfo>();

        private List<IndexInfo> _indexes = new List<IndexInfo>();

        private List<UniqueInfo> _uniques = new List<UniqueInfo>();

        private List<CheckInfo> _checks = new List<CheckInfo>();

        /// <summary>
        /// Table primary key
        /// </summary>
        [XmlSubElem]
        [DataMember]
        public PrimaryKeyInfo PrimaryKey { get; set; }

        /// <summary>
        /// List of table foreign keys
        /// </summary>
        [XmlCollection(typeof(ForeignKeyInfo))]
        [DataMember]
        public List<ForeignKeyInfo> ForeignKeys { get { return _foreignKeys; } }

        public TableInfo CreateColumnSubset(IEnumerable<int> columnSubset)
        {
            if (columnSubset != null)
            {
                var ts = new TableInfo(OwnerDatabase);
                foreach (int colindex in columnSubset)
                {
                    var src = Columns[colindex];
                    ts.Columns.Add(new ColumnInfo(ts)
                    {
                        Name = src.Name,
                        DataType = src.DataType,
                        NotNull = src.NotNull,
                        CommonType = src.CommonType,
                    });
                }
                return ts;
            }
            return this;
        }

        [XmlCollection(typeof(IndexInfo))]
        [DataMember]
        public List<IndexInfo> Indexes { get { return _indexes; } }

        [XmlCollection(typeof(UniqueInfo))]
        [DataMember]
        public List<UniqueInfo> Uniques { get { return _uniques; } }

        [XmlCollection(typeof(CheckInfo))]
        [DataMember]
        public List<CheckInfo> Checks { get { return _checks; } }

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
                res.AddRange(Indexes);
                res.AddRange(Uniques);
                res.AddRange(Checks);
                return res;
            }
        }

        public override void Assign(DatabaseObjectInfo source)
        {
            base.Assign(source);
            var src = (TableInfo)source;
            if (src.PrimaryKey != null) PrimaryKey = src.PrimaryKey.ClonePrimaryKey(this);
            foreach (var fk in src.ForeignKeys)
            {
                ForeignKeys.Add(fk.CloneForeignKey(this));
            }
            foreach (var ix in src.Indexes)
            {
                Indexes.Add(ix.CloneIndex(this));
            }
            foreach (var ix in src.Uniques)
            {
                Uniques.Add(ix.CloneUnique(this));
            }
            foreach (var ch in src.Checks)
            {
                Checks.Add(ch.CloneCheck(this));
            }
        }

        public override void AfterLoadLink()
        {
            base.AfterLoadLink();

            if (PrimaryKey != null) PrimaryKey.AfterLoadLink();
            foreach (var fk in ForeignKeys)
            {
                fk.AfterLoadLink();
            }
            foreach (var ix in Indexes)
            {
                ix.AfterLoadLink();
            }
            foreach (var uq in Uniques)
            {
                uq.AfterLoadLink();
            }
            foreach (var ch in Checks)
            {
                ch.AfterLoadLink();
            }
        }

        public override void AddAllObjects(List<DatabaseObjectInfo> res)
        {
            base.AddAllObjects(res);
            if (PrimaryKey != null) PrimaryKey.AddAllObjects(res);
            foreach (var x in ForeignKeys) x.AddAllObjects(res);
            foreach (var x in Columns) x.AddAllObjects(res);
            foreach (var x in Indexes) x.AddAllObjects(res);
            foreach (var x in Uniques) x.AddAllObjects(res);
            foreach (var x in Checks) x.AddAllObjects(res);
        }

        public void DropReferencesTo(NameWithSchema fullName)
        {
            ForeignKeys.RemoveIf(cnt => cnt.RefTable.FullName == fullName);
        }

        public ConstraintInfo FindConstraint(ConstraintInfo cnt)
        {
            if (cnt is PrimaryKeyInfo) return PrimaryKey;
            if (cnt is ForeignKeyInfo) return ForeignKeys.FirstOrDefault(x => x.ConstraintName == cnt.ConstraintName);
            if (cnt is IndexInfo) return Indexes.FirstOrDefault(x => x.ConstraintName == cnt.ConstraintName);
            if (cnt is UniqueInfo) return Uniques.FirstOrDefault(x => x.ConstraintName == cnt.ConstraintName);
            if (cnt is CheckInfo) return Checks.FirstOrDefault(x => x.ConstraintName == cnt.ConstraintName);
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
            var indexInfo = cnt as IndexInfo;
            if (indexInfo != null)
            {
                var ixnew = indexInfo.CloneIndex(this);
                if (!reuseGrouId) ixnew.GroupId = Guid.NewGuid().ToString();
                Indexes.Add(ixnew);
            }
            var uniqueInfo = cnt as UniqueInfo;
            if (uniqueInfo != null)
            {
                var uqnew = uniqueInfo.CloneUnique(this);
                if (!reuseGrouId) uqnew.GroupId = Guid.NewGuid().ToString();
                Uniques.Add(uqnew);
            }
            var checkInfo = cnt as CheckInfo;
            if (checkInfo != null)
            {
                var chnew = checkInfo.CloneCheck(this);
                if (!reuseGrouId) chnew.GroupId = Guid.NewGuid().ToString();
                Checks.Add(chnew);
            }
        }

        public void AddColumn(ColumnInfo col, bool reuseGrouId = false)
        {
            var cnew = col.CloneColumn(this);
            if (!reuseGrouId) cnew.GroupId = Guid.NewGuid().ToString();
            Columns.Add(col);
        }

        public ColumnInfo AddColumn(string columnName, string dataType, DbTypeBase commonType)
        {
            var newColumn = new ColumnInfo(this)
            {
                Name = columnName,
                DataType = dataType,
                CommonType = commonType,
            };
            Columns.Add(newColumn);
            return newColumn;
        }

        public void DropColumn(ColumnInfo column)
        {
            Columns.RemoveAll(c => c.Name == column.Name);
        }

        public void DropConstraint(ConstraintInfo cnt)
        {
            if (cnt is PrimaryKeyInfo) PrimaryKey = null;
            if (cnt is ForeignKeyInfo) ForeignKeys.RemoveAll(x => x.ConstraintName == cnt.ConstraintName);
            if (cnt is IndexInfo) Indexes.RemoveAll(x => x.ConstraintName == cnt.ConstraintName);
            if (cnt is UniqueInfo) Uniques.RemoveAll(x => x.ConstraintName == cnt.ConstraintName);
            if (cnt is CheckInfo) Checks.RemoveAll(x => x.ConstraintName == cnt.ConstraintName);
        }

        public ColumnInfo FindOrCreateColumn(ColumnInfo col)
        {
            var res = FindColumn(col.Name);
            if (res == null)
            {
                res = col.CloneColumn(this);
                res.GroupId = Guid.NewGuid().ToString();
                Columns.Add(res);
            }
            return res;
        }

        public override FullDatabaseRelatedName GetName()
        {
            return new FullDatabaseRelatedName
            {
                ObjectName = FullName,
                ObjectType = DatabaseObjectType.Table,
            };
        }

        public void RunNameTransformation(INameTransformation nameTransform)
        {
            FullName = nameTransform.RenameObject(FullName, "table");
            foreach (var col in Columns)
            {
                col.Name = nameTransform.RenameColumn(FullName, col.Name);
            }
            foreach (var cnt in Constraints)
            {
                cnt.ConstraintName = nameTransform.RenameConstraint(cnt);
            }
        }

    }
}
