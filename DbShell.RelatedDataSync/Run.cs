using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.RelatedDataSync.SqlModel;

namespace DbShell.RelatedDataSync
{
    public class Run : DataSyncItemBase
    {
        protected override void DoRun(IShellContext context)
        {
            var model = GetModel(context);
            var sqlModel = new DataSyncSqlModel(model, context);
            sqlModel.Run();
        }
    }
}
