using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.RelatedDataSync.SqlModel;
using DbShell.Driver.Common.Utility;

namespace DbShell.RelatedDataSync
{
    public class Run : DataSyncItemBase
    {
        [XamlProperty]
        public bool UseTransaction { get; set; }

        protected override void DoRun(IShellContext context)
        {
            var model = GetModel(context);
            var sqlModel = new DataSyncSqlModel(model, context);

            var connection = GetConnectionProvider(context);
            using (var conn = connection.Connect())
            {
                sqlModel.Run(conn, connection.Factory, context, UseTransaction);
            }
        }
    }
}
