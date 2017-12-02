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
        public int DataLengthKB;
        public int IndexLengthKB;

        public override int GetHashCode()
        {
            unchecked
            {
                return RowCount + TotalSpaceKB + UsedSpaceKB + UnusedSpaceKB + DataLengthKB + IndexLengthKB;
            }
        }

        public override bool Equals(object obj)
        {
            if (obj is TableSizesItem other)
            {
                return RowCount == other.RowCount
                    && TotalSpaceKB == other.TotalSpaceKB
                    && UsedSpaceKB == other.UsedSpaceKB
                    && UnusedSpaceKB == other.UnusedSpaceKB
                    && DataLengthKB == other.DataLengthKB
                    && IndexLengthKB == other.IndexLengthKB;
            }
            return base.Equals(obj);
        }
    }

    public class TableSizes
    {
        public Dictionary<NameWithSchema, TableSizesItem> Items = new Dictionary<NameWithSchema, TableSizesItem>();

        public bool HasDifferences(TableSizes tablesSizes)
        {
            if (tablesSizes == null) return true;
            return !tablesSizes.Items.OrderBy(x => x.Key.ToString()).SequenceEqual(Items.OrderBy(x => x.Key.ToString()));
            //return !RowCount.SequenceEqual(tablesSizes.RowCount);
        }
    }
}
