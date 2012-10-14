namespace DbShell.Driver.Common.Structure
{
    public abstract class DatabaseObjectInfo
    {
        public DatabaseInfo OwnerDatabase { get; private set; }

        public DatabaseObjectInfo(DatabaseInfo database)
        {
            OwnerDatabase = database;
        }

        protected virtual void Assign(DatabaseObjectInfo source)
        {
        }
    }
}