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
        private bool _allowExternalSources;
        private List<SourceEntitySqlModel> _externalSources = new List<SourceEntitySqlModel>();

        SyncModel _model;
        public DataSyncSqlModel(SyncModel model, IShellContext context, bool allowExternalSources)
        {
            _model = model;
            _allowExternalSources = allowExternalSources;
            SourceGraphModel = new SourceGraphSqlModel(model, context, this);
            foreach (var entity in model.Targets)
            {
                Entities.Add(new TargetEntitySqlModel(this, entity, context));
            }
        }

        public SyncModel Dbsh
        {
            get { return _model; }
        }

        private void DumpScript(SqlScriptCompiler cmp, bool useTransaction)
        {
            cmp.PutCommonProlog(useTransaction);

            foreach (var source in SourceGraphModel.Entities)
            {
                source.PutMaterialize(cmp);
            }

            foreach (var ent in Entities)
            {
                ent.Run(cmp);
            }

            foreach (var source in SourceGraphModel.Entities)
            {
                source.PutDropMaterialized(cmp);
            }

            cmp.PutCommonEpilog(useTransaction);
        }

        private void RunScript(DbConnection conn, IDatabaseFactory factory, Action<SqlScriptCompiler> prolog, Action<SqlScriptCompiler> epilog, IShellContext context, string procname, bool useTransaction)
        {
            var sw = new StringWriter();
            var so = new SqlOutputStream(factory.CreateDialect(), sw, new SqlFormatProperties());
            so.OverrideCommandDelimiter(";");
            var dmp = factory.CreateDumper(so, new SqlFormatProperties());
            var cmp = new SqlScriptCompiler(dmp, this, context, procname);

            if (prolog != null) prolog(cmp);

            DumpScript(cmp, useTransaction);

            if (epilog != null) epilog(cmp);

            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = sw.ToString();
                cmd.ExecuteNonQuery();
            }
        }

        public void AddExternalSource(SourceEntitySqlModel sourceEntity)
        {
            if (!_allowExternalSources) throw new Exception("DBSH-00214 External sources not supported in this context");
            _externalSources.Add(sourceEntity);
        }

        private void FillExternalSources(DbConnection conn, IDatabaseFactory factory, IShellContext context)
        {
            if (!_externalSources.Any()) return;

            var sw = new StringWriter();
            var so = new ConnectionSqlOutputStream(conn, null, factory.CreateDialect());
            var dmp = factory.CreateDumper(so, new SqlFormatProperties());

            foreach (var exSource in _externalSources)
            {
                var tbl = new TableInfo(null) { FullName = exSource.ExternalDataName };
                foreach(var col in exSource.Dbsh.Columns)
                {
                    tbl.Columns.Add(new ColumnInfo(tbl)
                    {
                        Name = col.Name,
                        DataType = col.DataType ?? "nvarchar(500)",
                    });
                }
                dmp.CreateTable(tbl);

                var copyTable = new DbShell.Core.CopyTable
                {
                    Source = exSource.Dbsh.DataSource,
                    Target = new DbShell.Core.Table
                    {
                        Name = exSource.ExternalDataName.Name,
                        StructureOverride = tbl,
                    },
                };
                var runnable = (IRunnable)copyTable;
                runnable.Run(context);
            }
        }

        private void FreeExternalSources(DbConnection conn, IDatabaseFactory factory, IShellContext context)
        {
            if (!_externalSources.Any()) return;

            var sw = new StringWriter();
            var so = new ConnectionSqlOutputStream(conn, null, factory.CreateDialect());
            var dmp = factory.CreateDumper(so, new SqlFormatProperties());

            foreach (var exSource in _externalSources)
            {
                var tbl = new TableInfo(null) { FullName = exSource.ExternalDataName };
                dmp.DropTable(tbl, false);
            }
        }

        public void Run(DbConnection conn, IDatabaseFactory factory, IShellContext context, bool useTransaction)
        {
            FillExternalSources(conn, factory, context);
            RunScript(conn, factory, cmp => { cmp.PutScriptProlog(); }, cmp => { }, context, null, useTransaction);
            FreeExternalSources(conn, factory, context);
        }

        public void CreateProcedure(DbConnection conn, IDatabaseFactory factory, NameWithSchema name, IShellContext context, bool useTransaction)
        {
            RunScript(conn, factory, cmp => cmp.PutProcedureHeader(name), cmd => cmd.PutProcedureFooter(), context, name.ToString(), useTransaction);
        }

        public string GenerateScript(IDatabaseFactory factory, IShellContext context, bool useTransaction)
        {
            var sw = new StringWriter();
            var so = new SqlOutputStream(factory.CreateDialect(), sw, new SqlFormatProperties());
            so.OverrideCommandDelimiter(";");
            var dmp = factory.CreateDumper(so, new SqlFormatProperties());
            var cmp = new SqlScriptCompiler(dmp, this, context, null);

            cmp.PutScriptProlog();
            DumpScript(cmp, useTransaction);

            return sw.ToString();
        }
    }
}
