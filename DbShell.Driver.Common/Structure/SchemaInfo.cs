using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.Structure
{
    public class SchemaInfo : DatabaseObjectInfo
    {
        public SchemaInfo(DatabaseInfo database)
            : base(database)
        {
        }

        [XmlAttrib("name")]
        public string Name { get; set; }

        public override DatabaseObjectType ObjectType
        {
            get { return DatabaseObjectType.Schema; }
        }

        public SchemaInfo CloneSchema(DatabaseInfo ownerDb = null)
        {
            var res = new SchemaInfo(ownerDb ?? OwnerDatabase);
            res.Assign(this);
            return res;
        }

        public override DatabaseObjectInfo CloneObject(DatabaseObjectInfo owner)
        {
            return CloneSchema(owner as DatabaseInfo);
        }

        public override void Assign(DatabaseObjectInfo source)
        {
            base.Assign(source);
            var src = (SchemaInfo) source;
            Name = src.Name;
        }

        public override FullDatabaseRelatedName GetName()
        {
            return new FullDatabaseRelatedName
            {
                ObjectType = DatabaseObjectType.Schema,
                SubName = Name,
            };
        }
    }
}