using DbShell.Driver.Common.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.DataSet.DataSetModels
{
    public class UndefinedReferenceReport
    {
        public NameWithSchema Table;
        public string Column;
        public HashSet<string> KeyValues = new HashSet<string>();
        public int RefCount;
    }
}
