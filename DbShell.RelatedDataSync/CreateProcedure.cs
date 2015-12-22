using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.RelatedDataSync.SqlModel;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;
using DbShell.Driver.Common.AbstractDb;

namespace DbShell.RelatedDataSync
{
    public class CreateProcedure: DataSyncScriptable
    {
        [XamlProperty]
        /// procedure name
        public string ProcName { get; set; }

        [XamlProperty]
        /// procedure schema
        public string ProcSchema { get; set; }

        [XamlProperty]
        public bool OverwriteExisting { get; set; }

        protected override void DoRun(IShellContext context)
        {
            var model = GetModel(context);
            var sqlModel = new DataSyncSqlModel(model, context, false, context.Replace(GetProviderString(context)));

            var connection = GetConnectionProvider(context);
            using (var conn = connection.Connect())
            {
                sqlModel.CreateProcedure(conn, connection.Factory, new NameWithSchema(context.Replace(ProcSchema), context.Replace(ProcName)), context, UseTransaction, OverwriteExisting, sqlModel.Parameters);
            }
        }

        public override string GenerateSql(IDatabaseFactory factory, IShellContext context)
        {
            var model = GetModel(context);
            var sqlModel = new DataSyncSqlModel(model, context, false, context.Replace(GetProviderString(context)));
            return sqlModel.GenerateCreateProcedure(factory, new NameWithSchema(context.Replace(ProcSchema), context.Replace(ProcName)), context, UseTransaction, OverwriteExisting, sqlModel.Parameters);
        }
    }
}

