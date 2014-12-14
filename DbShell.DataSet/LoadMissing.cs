using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;

namespace DbShell.DataSet
{
    public class LoadMissing : DataSetItemBase
    {
        [XamlProperty]
        public string Table { get; set; }

        protected override void DoRun(IShellContext context)
        {
            GetModel(context).LoadMissing(context.Replace(Table));
        }
    }
}
