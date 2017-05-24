using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.Statistics
{
    public class TableSizesItem
    {
        public int RowCount;
        public int TotalSpaceKB;
        public int UsedSpaceKB;
        public int UnusedSpaceKB;
    }

    public class TableSizes
    {
        public Dictionary<NameWithSchema, TableSizesItem> Items = new Dictionary<NameWithSchema, TableSizesItem>();

        //public bool HasDifferences(TableSizes tablesSizes)
        //{
        //    return !RowCount.SequenceEqual(tablesSizes.RowCount);
        //}
    }
}
