using DbShell.Driver.Common.CommonDataLayer;

namespace DbShell.Driver.Common.Utility
{
    public static class InMemoryTableExtension
    {
        public static RowType FindRow<RowType>(this IInMemoryTable<RowType> table, string[] pkcols, object[] pkvals)
            where RowType : class, ICdlRecord
        {
            foreach (var row in table.Rows)
            {
                if (CdlTool.EqualRecords(row.GetValuesByCols(pkcols), pkvals)) return row;
            }
            return null;
        }
    }
}
