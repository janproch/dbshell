using DbShell.Driver.Common.AbstractDb;

namespace DbShell.Driver.Common.DmlFramework
{
    public class DmlfSortOrderItem : DmlfExpressionHolder
    {
        public DmlfSortOrderType OrderType;

        public override void GenSql(ISqlDumper dmp)
        {
            Expr.GenSql(dmp);
            dmp.Put(" ");
            OrderType.GenSql(dmp);
        }
    }
}