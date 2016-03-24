using DbShell.Driver.Common.Structure;
using System.Data;

namespace DbShell.Driver.Common.Utility
{
    public static class DataTableExtension
    {
        public static int GetOrdinal(this DataColumnCollection cols, string name)
        {
            int i = 0;
            foreach (DataColumn col in cols)
            {
                if (col.ColumnName.ToUpper() == name.ToUpper()) return i;
                i++;
            }
            return -1;
        }

        public static int SafeOrdinal(this DataTable table, params string[] fieldVariants)
        {
            foreach (string field in fieldVariants)
            {
                int ord = table.Columns.GetOrdinal(field);
                if (ord >= 0) return ord;
            }
            return -1;
        }

        public static TableInfo GetTableInfo(this DataColumnCollection columns)
        {
            TableInfo res = new TableInfo(null);
            foreach (DataColumn col in columns.SortedByKey<DataColumn, int>(col => col.Ordinal))
            {
                var commonType = TypeTool.GetCommonType(col.DataType);
                var colInfo = res.AddColumn(col.ColumnName, commonType.ToString(), TypeTool.GetCommonType(col.DataType));
                colInfo.NotNull = !col.AllowDBNull;
                res.Columns.Add(colInfo);
            }
            return res;
        }

        public static DataTable SelectNewTable(this DataTable src, string cond, string sort)
        {
            DataRow[] rows = src.Select(cond, sort);
            DataTable res = src.Clone();
            foreach (DataRow row in rows) res.ImportRow(row);
            return res;
        }

        //public static CdlTable ToBinaryTable(this DataTable table)
        //{
        //    var ts = table.Columns.GetTableInfo("table");
        //    CdlTable res = new CdlTable(ts);
        //    foreach (DataRow row in table.Rows)
        //    {
        //        res.AddRow(new DataRecordAdapter(new DataRowAdapter(row), ts));
        //    }
        //    return res;
        //}
    }
}
