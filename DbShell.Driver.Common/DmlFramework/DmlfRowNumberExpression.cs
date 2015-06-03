using System.Xml;
using DbShell.Driver.Common.AbstractDb;

namespace DbShell.Driver.Common.DmlFramework
{
    public class DmlfRowNumberExpression : DmlfExpression
    {
        public DmlfSortOrderCollection OrderBy = new DmlfSortOrderCollection();

        public DmlfRowNumberExpression()
        {
        }

        public DmlfRowNumberExpression(XmlElement xml)
        {
        }

        public override void GenSql(ISqlDumper dmp)
        {
            dmp.Put(" ^row_number() ^over (^order ^by ");
            bool was = false;
            foreach (var col in OrderBy)
            {
                if (was) dmp.Put(", ");
                col.GenSql(dmp);
                was = true;
            }
            dmp.Put(")");
        }

        protected override string GetTypeName()
        {
            return "row_number";
        }
    }
}