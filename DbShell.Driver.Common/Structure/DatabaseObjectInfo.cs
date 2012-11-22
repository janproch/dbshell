namespace DbShell.Driver.Common.Structure
{
    public abstract class DatabaseObjectInfo
    {
        public DatabaseInfo OwnerDatabase { get; private set; }
        public PropertyBag Properties { get; private set; }

        public DatabaseObjectInfo(DatabaseInfo database)
        {
            OwnerDatabase = database;
            Properties = new PropertyBag();
        }

        protected virtual void Assign(DatabaseObjectInfo source)
        {
            foreach (var item in source.Properties)
            {
                Properties.Add(item.Key, item.Value);
            }
        }
    }
}