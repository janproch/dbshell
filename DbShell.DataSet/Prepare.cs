using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;

namespace DbShell.DataSet
{
    public class Prepare : DataSetItemBase
    {
        protected override void DoRun(IShellContext context)
        {
            using (var conn = GetConnectionProvider(context).Connect())
            {
                GetModel(context).Prepare(conn);
            }
        }
    }
}
