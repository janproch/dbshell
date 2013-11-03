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

        public TableInfo Clone(DatabaseInfo ownerDb = null)
        {
            var res = new TableInfo(ownerDb ?? OwnerDatabase);
            res.Assign(this);
            return res;
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

        protected override void Assign(DatabaseObjectInfo source)
        {
            base.Assign(source);
            var src = (TableInfo) source;
            if (src.PrimaryKey != null) PrimaryKey = src.PrimaryKey.Clone(this);
            foreach(var fk in src.ForeignKeys)
            {
                ForeignKeys.Add(fk.Clone(this));
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
    }
}
