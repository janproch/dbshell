using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Utility;
using DbShell.Driver.Common.Structure;

namespace DbShell.DataSet
{
    public class Lookup : DataSetItemBase
    {
        [XamlProperty]
        public string Schema { get; set; }

        [XamlProperty]
        public string Table { get; set; }

        [XamlProperty]
        public string Column { get; set; }

        protected override void DoRun(IShellContext context)
        {
            GetModel(context).DefineLookup(new NameWithSchema(context.Replace(Schema), context.Replace(Table)), new[] {Column});
        }
    }

}
