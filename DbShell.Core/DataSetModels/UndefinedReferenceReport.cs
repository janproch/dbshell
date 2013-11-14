using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Core.DataSetModels
{
    public class UndefinedReferenceReport
    {
        public string Table;
        public string Column;
        public HashSet<int> KeyValues = new HashSet<int>();
        public int RefCount;
    }
}
