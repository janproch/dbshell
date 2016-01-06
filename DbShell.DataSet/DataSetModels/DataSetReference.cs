using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.DataSet.DataSetModels
{
    public class DataSetReference
    {
        public DataSetClass BaseClass;
        public DataSetClass ReferencedClass;
        public string BindingColumn;
        public bool Mandatory;
        // base class of reference is inserted before target class is inserted, following UPDATE must be done
        public bool BackReference;
        //public bool Load;
    }
}
