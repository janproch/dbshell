using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.DataSet.DataSetModels
{
    public class UndefinedReferenceReport
    {
        public string Table;
        public string Column;
        public HashSet<int> KeyValues = new HashSet<int>();
        public int RefCount;
    }
}
