using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.RelatedDataSync.SqlModel;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.RelatedDataSync
{
    public class CreateProcedure: DataSyncItemBase
    {
        [XamlProperty]
        /// procedure name
        public string ProcName { get; set; }

        [XamlProperty]
        /// procedure schema
        public string ProcSchema { get; set; }

        [XamlProperty]
        public bool UseTransaction { get; set; }

        protected override void DoRun(IShellContext context)
        {
            var model = GetModel(context);
            var sqlModel = new DataSyncSqlModel(model, context);

            var connection = GetConnectionProvider(context);
            using (var conn = connection.Connect())
            {
                sqlModel.CreateProcedure(conn, connection.Factory, new NameWithSchema(context.Replace(ProcSchema), context.Replace(ProcName)), context, UseTransaction);
            }
        }
    }
}

