namespace DbShell.Driver.Common.DmlFramework
{
    public class DmlfExpressionHolderCollection<T> : DmlfList<T>
        where T : DmlfExpressionHolder
    {
        public bool IsMultiTable()
        {
            DmlfSource lastsrc = null;
            foreach (var col in this)
            {
                if (col.Source != null)
                {
                    if (lastsrc != null && col.Source != lastsrc) return true;
                    lastsrc = col.Source;
                }
            }
            return false;
        }

        public int GetColumnIndex(DmlfColumnRef col)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Column == col) return i;
            }
            return -1;
        }

        public int GetExpressionIndex(DmlfExpression expr)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Expr == expr) return i;
            }
            return -1;
        }
    }
}