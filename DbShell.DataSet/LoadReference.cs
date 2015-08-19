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
    public class LoadReference : DataSetItemBase
    {
        [XamlProperty]
        public string Schema { get; set; }
        [XamlProperty]
        public string Table { get; set; }
        [XamlProperty]
        public string Column { get; set; }
        [XamlProperty]
        public string RefSchema { get; set; }
        [XamlProperty]
        public string RefTable { get; set; }

        protected override void DoRun(IShellContext context)
        {
            GetModel(context).LoadReference(
                new NameWithSchema(context.Replace(Schema), context.Replace(Table)),
                context.Replace(Column), 
                new NameWithSchema(context.Replace(RefSchema), context.Replace(RefTable)));
        }
    }
}
