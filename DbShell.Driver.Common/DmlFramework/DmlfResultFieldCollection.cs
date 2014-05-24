using System.Collections.Generic;

namespace DbShell.Driver.Common.DmlFramework
{
    public class DmlfResultFieldCollection : DmlfExpressionHolderCollection<DmlfResultField>
    {
        public List<DmlfColumnRef> GetPrimaryKey(DmlfSource src)
        {
            var res = new List<DmlfColumnRef>();
            foreach (var fld in this)
            {
                var col = fld.Column;
                if (col != null && fld.ResultInfo != null && fld.ResultInfo.IsKey && col.Source == src) res.Add(col);
            }
            return res;
        }

        public List<string> GetBaseColumns()
        {
            var res = new List<string>();
            foreach (var col in this)
            {
                if (col.Source != DmlfSource.BaseTable) continue;
                if (col.Column == null) continue;
                res.Add(col.Column.ColumnName);
            }
            return res;
        }

        /// <summary>
        /// normaliuze DmlfColumnRef.Source property to DmlfSource.BaseTable, if it denotes base table
        /// </summary>
        public void NormalizeBaseTables()
        {
            foreach (var fld in this)
            {
                var col = fld.Column;
                if (col == null) continue;
                if (col.Source == null || col.Source.Alias == "basetbl") col.Source = DmlfSource.BaseTable;
            }
        }

        //public void SplitVisible(out DmlfResultFieldCollection visCols, out DmlfResultFieldCollection hidCols)
        //{
        //    visCols = new DmlfResultFieldCollection();
        //    hidCols = new DmlfResultFieldCollection();
        //    foreach (var fld in this)
        //    {
        //        if (fld.DisplayInfo.Style == ColumnDisplayInfo.UsageStyle.Value) visCols.Add(fld);
        //        else hidCols.Add(fld);
        //    }
        //}
    }
}