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
    }
}