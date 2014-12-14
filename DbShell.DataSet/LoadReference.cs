using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;

namespace DbShell.DataSet
{
    public class LoadReference : DataSetItemBase
    {
        [XamlProperty]
        public string Table { get; set; }
        [XamlProperty]
        public string Column { get; set; }
        [XamlProperty]
        public string RefTable { get; set; }

        protected override void DoRun(IShellContext context)
        {
            string table = context.Replace(Table);
            string column = context.Replace(Column);
            string refTable = context.Replace(RefTable);

            GetModel(context).LoadReference(table, column, refTable);
        }
    }
}
