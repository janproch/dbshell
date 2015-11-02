using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.RelatedDataSync.SqlModel;
using DbShell.Driver.Common.Utility;
using System.Data.SqlClient;
using DbShell.Driver.Common.AbstractDb;

namespace DbShell.RelatedDataSync
{
    public class Run : DataSyncScriptable
    {
        protected override void DoRun(IShellContext context)
        {
            var model = GetModel(context);
            var sqlModel = new DataSyncSqlModel(model, context, true, context.Replace(GetProviderString(context)));

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

        public override string GenerateSql(IDatabaseFactory factory, IShellContext context)
        {
            var model = GetModel(context);
            var sqlModel = new DataSyncSqlModel(model, context, true, context.Replace(GetProviderString(context)));
            return sqlModel.GenerateScript(factory, context, UseTransaction);
        }
    }
}
