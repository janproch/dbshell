using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.Structure
{
    public class PrimaryKeyInfo : ColumnsConstraintInfo
    {
        public PrimaryKeyInfo(TableInfo table)
            :base(table)
        {
            
        }

        public override DatabaseObjectType ObjectType
        {
            get { return DatabaseObjectType.PrimaryKey; }
        }

        public PrimaryKeyInfo ClonePrimaryKey(TableInfo ownTable = null)
        {
            var res = new PrimaryKeyInfo(ownTable ?? OwnerTable);
            res.Assign(this);
            return res;
        }

        public override DatabaseObjectInfo CloneObject(DatabaseObjectInfo owner)
        {
            return ClonePrimaryKey(owner as TableInfo);
        }

        public override void Assign(DatabaseObjectInfo source)
        {
            base.Assign(source);
            var src = (PrimaryKeyInfo) source;
        }

        public override void SetDummyTable(NameWithSchema name)
        {
            var table = new TableInfo(null);
            table.FullName = name;
            table.PrimaryKey = this;
        }
    }
}