using DbShell.Driver.Common.AbstractDb;

namespace DbShell.Driver.Common.DmlFramework
{
    public class DmlfSortOrderItem : DmlfExpressionHolder
    {
        public DmlfSortOrderType OrderType;

        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            Expr.GenSql(dmp, handler);
            dmp.Put(" ");
            OrderType.GenSql(dmp);
        }
    }
}