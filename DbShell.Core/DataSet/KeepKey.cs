using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Core.DataSet
{
    public class KeepKey : DataSetItemBase
    {
        public string Table { get; set; }

        protected override void DoRun()
        {
            Model.KeepKey(Replace(Table));
        }
    }
}
