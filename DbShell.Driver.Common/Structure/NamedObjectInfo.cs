using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.Structure
{
    public abstract class NamedObjectInfo : DatabaseObjectInfo
    {
        public NameWithSchema FullName { get; set; }

        [XmlAttrib("name")]
        public string Name
        {
            get
            {
                if (FullName != null) return FullName.Name;
                return null;
            }
            set
            {
                if (FullName != null) FullName = new NameWithSchema(FullName.Schema, value);
                else FullName = new NameWithSchema(value);
            }
        }

        [XmlAttrib("schema")]
        public string Schema
        {
            get
            {
                if (FullName != null) return FullName.Schema;
                return null;
            }
            set
            {
                if (FullName != null) FullName = new NameWithSchema(value, FullName.Name);
                else FullName = new NameWithSchema(value, null);
            }
        }

        public NamedObjectInfo(DatabaseInfo database)
            : base(database)
        {
        }

        protected override void Assign(DatabaseObjectInfo source)
        {
            base.Assign(source);
            var src = (NamedObjectInfo) source;
            FullName = src.FullName;
        }
    }
}