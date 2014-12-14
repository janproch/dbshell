using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;

namespace DbShell.DataSet
{
    public class Lookup : DataSetItemBase
    {
        [XamlProperty]
        public string Table { get; set; }

        [XamlProperty]
        public string Column { get; set; }

        protected override void DoRun(IShellContext context)
        {
            GetModel(context).DefineLookup(Table, new[] {Column});
        }
    }

}
