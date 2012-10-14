using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.Structure
{
    public abstract class NamedObjectInfo : DatabaseObjectInfo
    {
        public NameWithSchema FullName { get; set; }

        [XmlAttrib("name")]
        public string Name { get { return FullName.Name; } }
        [XmlAttrib("schema")]
        public string Schema { get { return FullName.Schema; } }

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