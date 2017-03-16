using DbShell.Driver.Common.Utility;
using System.Runtime.Serialization;

namespace DbShell.Driver.Common.Structure
{
    [DataContract]
    public class ColumnReference
    {
        public ColumnInfo RefColumn { get; set; }

        public string Name
        {
            get
            {
                if (RefColumn == null) return null;
                return RefColumn.Name;
            }
        }

        private string _refColumnName;

        [XmlAttrib("name")]
        [DataMember]
        public string RefColumnName
        {
            get
            {
                if (RefColumn != null) return RefColumn.Name;
                return _refColumnName;
            }
            set
            {
                _refColumnName = value;
                RefColumn = null;
            }
        }

        [XmlAttrib("is_descending")]
        [DataMember]
        public bool IsDescending { get; set; }

        [XmlAttrib("is_included")]
        [DataMember]
        public bool IsIncluded { get; set; }

        public ColumnReference Clone()
        {
            var res = new ColumnReference();
            res.Assign(this);
            return res;
        }

        private void Assign(ColumnReference src)
        {
            RefColumnName = src.RefColumnName;
            IsDescending = src.IsDescending;
            IsIncluded = src.IsIncluded;
        }

        public void AfterLoadLink(TableInfo table)
        {
            if (_refColumnName != null)
            {
                RefColumn = table.Columns.Find(c => c.Name == _refColumnName);
                _refColumnName = null;
            }
        }
    }
}