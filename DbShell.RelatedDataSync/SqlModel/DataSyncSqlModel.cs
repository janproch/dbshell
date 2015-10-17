using DbShell.Common;
using DbShell.Driver.Common.AbstractDb;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Sql;
using System.IO;

namespace DbShell.RelatedDataSync.SqlModel
{
    public class DataSyncSqlModel
    {
        public List<TargetEntitySqlModel> Entities = new List<TargetEntitySqlModel>();
        public SourceGraphSqlModel SourceGraphModel;

        SyncModel _model;
        public DataSyncSqlModel(SyncModel model, IShellContext context)
        {
            _model = model;
            SourceGraphModel = new SourceGraphSqlModel(model, context);
            foreach (var entity in model.Targets)
            {
                Entities.Add(new TargetEntitySqlModel(this, entity, context));
            }
        }

        public SyncModel Dbsh
        {
            get { return _model; }
        }

        private void RunScript(DbConnection conn, IDatabaseFactory factory, Action<SqlScriptCompiler> prolog, Action<SqlScriptCompiler> epilog, IShellContext context, string procname)
        {
            var sw = new StringWriter();
            var so = new SqlOutputStream(factory.CreateDialect(), sw, new SqlFormatProperties());
            so.OverrideCommandDelimiter(";");
            var dmp = factory.CreateDumper(so, new SqlFormatProperties());
            var cmp = new SqlScriptCompiler(dmp, this, context, procname);

            if (prolog != null) prolog(cmp);

            cmp.PutCommonProlog();

            foreach (var ent in Entities)
            {
                ent.Run(cmp);
            }
            cmp.PutCommonEpilog();

            if (epilog != null) epilog(cmp);

            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = sw.ToString();
                cmd.ExecuteNonQuery();
            }
        }

        public void Run(DbConnection conn, IDatabaseFactory factory, IShellContext context)
        {
            RunScript(conn, factory, cmp => cmp.PutScriptProlog(), cmp => { }, context, null);
        }

        public void CreateProcedure(DbConnection conn, IDatabaseFactory factory, NameWithSchema name, IShellContext context)
        {
            RunScript(conn, factory, cmp => cmp.PutProcedureHeader(name), cmd => cmd.PutProcedureFooter(), context, name.ToString());
        }

    }
}
