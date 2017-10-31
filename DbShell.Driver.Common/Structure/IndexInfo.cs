using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Utility;
using System.Runtime.Serialization;

namespace DbShell.Driver.Common.Structure
{
    public enum DbIndexType
    {
        Normal,
        Clustered,
        Xml,
        Spatial,
        Fulltext
    }

    [DataContract]
    public class IndexInfo : ColumnsConstraintInfo
    {
        [XmlAttrib("is_unique")]
        [DataMember]
        public bool IsUnique { get; set; }

        [XmlAttrib("index_type")]
        [DataMember]
        public DbIndexType IndexType { get; set; }

        public IndexInfo(TableInfo table)
            : base(table)
        {
        }

        public override DatabaseObjectType ObjectType
        {
            get { return DatabaseObjectType.Index; }
        }

        public override void Assign(DatabaseObjectInfo source)
        {
            base.Assign(source);
            var src = (IndexInfo) source;
            IsUnique = src.IsUnique;
            IndexType = src.IndexType;
        }

        public override void SetDummyTable(NameWithSchema name)
        {
            var table = new TableInfo(null);
            table.FullName = name;
            table.Indexes.Add(this);
        }

        public IndexInfo CloneIndex(TableInfo ownTable = null)
        {
            var res = new IndexInfo(ownTable ?? OwnerTable);
            res.Assign(this);
            return res;
        }

        public override DatabaseObjectInfo CloneObject(DatabaseObjectInfo owner)
        {
            return CloneIndex(owner as TableInfo);
        }
    }
}
