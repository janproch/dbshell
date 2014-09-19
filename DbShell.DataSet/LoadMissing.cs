using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;

namespace DbShell.DataSet
{
    public class LoadMissing : DataSetItemBase
    {
        public string Table { get; set; }

        protected override void DoRun(IShellContext context)
        {
            GetModel(context).LoadMissing(context.Replace(Table));
        }
    }
}
