using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.Statistics
{
    public class TableSizes
    {
        public Dictionary<NameWithSchema, int> RowCount = new Dictionary<NameWithSchema, int>();
    }
}
