using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.RelatedDataSync.SqlModel;
using DbShell.Driver.Common.Utility;
using System.Data.SqlClient;

namespace DbShell.RelatedDataSync
{
    public class Run : DataSyncItemBase
    {
        [XamlProperty]
        public bool UseTransaction { get; set; }

        protected override void DoRun(IShellContext context)
        {
            var model = GetModel(context);
            var sqlModel = new DataSyncSqlModel(model, context, true);

            var connection = GetConnectionProvider(context);
            using (var conn = connection.Connect())
            {
                var sqlconn = conn as SqlConnection;
                if (sqlconn != null)
                {
                    sqlconn.InfoMessage += (s, e) =>
                    {
                        foreach (SqlError error in e.Errors)
                        {
                            context.OutputMessage(error.Message);
                        }
                    };
                }
                sqlModel.Run(conn, connection.Factory, context, UseTransaction);
            }
        }
    }
}
