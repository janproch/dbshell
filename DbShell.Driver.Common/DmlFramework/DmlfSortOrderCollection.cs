namespace DbShell.Driver.Common.DmlFramework
{
    public class DmlfSortOrderCollection : DmlfExpressionHolderCollection<DmlfSortOrderItem>
    {
        public static DmlfSortOrderCollection BuildFromExpression(DmlfExpression expr)
        {
            return new DmlfSortOrderCollection
                {
                    new DmlfSortOrderItem
                        {
                            Expr = expr,
                            OrderType = DmlfSortOrderType.Ascending
                        }
                };
        }
    }
}