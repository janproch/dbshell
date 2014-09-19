using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;

namespace DbShell.DataSet
{
    public class KeepKey : DataSetItemBase
    {
        public string Table { get; set; }

        protected override void DoRun(IShellContext context)
        {
            GetModel(context).KeepKey(context.Replace(Table));
        }
    }
}
