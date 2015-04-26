using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Driver.Common.Sql;

namespace DbShell.DataSet
{
    public class Import : DataSetItemBase
    {
        protected override void DoRun(IShellContext context)
        {
            context.OutputMessage("DBSH-00152 Importing dataset");

            using (var conn = GetConnectionProvider(context).Connect())
            {
                GetModel(context).ImportIntoDatabase(conn);
            }
        }
    }
}
