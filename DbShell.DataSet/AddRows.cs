using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;

namespace DbShell.DataSet
{
    public class AddRows : DataSetItemBase
    {
        public string Table { get; set; }
        public string Condition { get; set; }

        protected override void DoRun(IShellContext context)
        {
            using (var conn = GetConnectionProvider(context).Connect())
            {
                GetModel(context).AddRows(conn, context.Replace(Table), context.Replace(Condition));
            }
        }
    }
}
