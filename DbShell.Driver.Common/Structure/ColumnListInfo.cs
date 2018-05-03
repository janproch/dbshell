using DbShell.Driver.Common.Utility;
using System.Collections.Generic;
using System.Runtime.Serialization;

namespace DbShell.Driver.Common.Structure
{
    [DataContract]
    public abstract class ColumnListInfo : NamedObjectInfo
    {
        private List<ColumnInfo> _columns = new List<ColumnInfo>();

        [XmlCollection(typeof (ColumnInfo))]
        [DataMember]
        public List<ColumnInfo> Columns
        {
            get { return _columns; }
        }

        public int ColumnCount
        {
            get { return Columns.Count; }
        }

        public ColumnListInfo(DatabaseInfo database)
            : base(database)
        {
        }

        public override void Assign(DatabaseObjectInfo source)
        {
            base.Assign(source);
            var src = (ColumnListInfo) source;
            foreach (var col in src.Columns) Columns.Add(col.CloneColumn((TableInfo) this));
        }
    }
}