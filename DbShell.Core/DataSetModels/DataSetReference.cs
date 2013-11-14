using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Core.DataSetModels
{
    public class DataSetReference
    {
        public DataSetClass BaseClass;
        public DataSetClass ReferencedClass;
        public string BindingColumn;
        public bool Mandatory;
        public bool Load;
    }
}
