using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.Structure
{
    public class PrimaryKeyInfo : ColumnsConstraintInfo
    {
        [XmlElem]
        public string ConstraintName { get; set; }

        public PrimaryKeyInfo(TableInfo table)
            :base(table)
        {
            
        }

        public override DatabaseObjectType ObjectType
        {
            get { return DatabaseObjectType.PrimaryKey; }
        }

        public PrimaryKeyInfo Clone(TableInfo ownTable = null)
        {
            var res = new PrimaryKeyInfo(ownTable ?? OwnerTable);
            res.Assign(this);
            return res;
        }

        protected override void Assign(DatabaseObjectInfo source)
        {
            base.Assign(source);
            var src = (PrimaryKeyInfo) source;
            ConstraintName = src.ConstraintName;
        }

    }
}