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
using DbShell.Driver.Common.Utility;

namespace DbShell.RelatedDataSync.SqlModel
{
    public class DataSyncSqlModel
    {
        public List<TargetEntitySqlModel> Entities = new List<TargetEntitySqlModel>();
        public List<SourceEntitySqlModel> FlatSources = new List<SourceEntitySqlModel>();
        public SourceGraphSqlModel SourceGraphModel;
        private bool _allowExternalSources;
        private List<SourceEntitySqlModel> _externalSources = new List<SourceEntitySqlModel>();
        public string ProviderString { get; private set; }
        public DatabaseInfo TargetStructure;
        public List<ParameterModel> Parameters = new List<ParameterModel>();

        SyncModel _model;
        public DataSyncSqlModel(SyncModel model, IShellContext context, bool allowExternalSources, string providerString)
        {
            _model = model;
            _allowExternalSources = allowExternalSources;

            foreach(var param in model.Parameters)
            {
                Parameters.Add(new ParameterModel
                {
                    DataType = context.Replace(param.DataType),
                    DefaultValue = context.Replace(param.DefaultValue),
                    Name = context.Replace(param.Name),
                });
            }

            ProviderString = providerString;
            TargetStructure = context.GetDatabaseStructure(providerString);

            if (_model.IsFlatSync)
            {
                foreach (var src in _model.Sources)
                {
                    var entity = new SourceEntitySqlModel(src, this);
                    entity.LoadFlatColumns();
                    FlatSources.Add(entity);
                    entity.SqlAlias = src.Alias ?? "src_" + FlatSources.Count;
                    entity.InitializeQuerySource(src.DataSource, context, src.SourceTableVariable, src.SourceQueryVariable);
                    entity.MaterializeIfNeeded();
                }
            }
            else
            {
                SourceGraphModel = new SourceGraphSqlModel(model, context, this);
                foreach(var col in SourceGraphModel.Columns.Values)
                {
                    col.CompileFilter();
                }
            }
            foreach (var entity in model.Targets)
            {
                Entities.Add(new TargetEntitySqlModel(this, entity, context));
            }
            foreach (var fk in model.TargetReferences)
            {
                var sourceReplaced = context.Replace(fk.Source);
                var sourceEntity = FindTarget(sourceReplaced);
                string targetReplaced = context.Replace(fk.Target);
                var targetEntity = FindTarget(targetReplaced);
                if (sourceEntity == null) throw new Exception($"DBSH-00000 Source entity {sourceReplaced} not found");
                if (targetEntity == null) throw new Exception($"DBSH-00219 Target entity {targetReplaced} not found");

                sourceEntity.AddReference(fk, targetEntity);
            }

            PartialSortEntitiesByRefs();

            foreach (var entity in Entities)
            {
                entity.CreateJoinModel();
            }

            foreach (var entity in Entities)
            {
                entity.TestCorrectness();
            }
        }

        private void PartialSortEntitiesByRefs()
        {
            var newList = new List<TargetEntitySqlModel>();
            var queue = new List<TargetEntitySqlModel>(Entities);
            while (queue.Any())
            {
                TargetEntitySqlModel nextEntity = null;
                foreach (var elem in queue)
                {
                    if (elem.RefEntities.Values.All(x => newList.Contains(x)))
                    {
                        nextEntity = elem;
                        break;
                    }
                }
                if (nextEntity == null)
                {
                    throw new Exception($"DBSH-00000 Cycle in entity references, {queue.Select(x => x.LogName).CreateDelimitedText(",")} ");
                }
                newList.Add(nextEntity);
                queue.Remove(nextEntity);
            }

            Entities = newList;
        }

        public SyncModel Dbsh
        {
            get { return _model; }
        }

        private IEnumerable<SourceEntitySqlModel> EnumSources()
        {
            if (SourceGraphModel != null) return SourceGraphModel.Entities;
            return FlatSources;
        }

        private void DumpScript(SqlScriptCompiler cmp, bool useTransaction)
        {
            cmp.PutCommonProlog(useTransaction, _model.SqlPrologBeforeBeginTransaction, _model.SqlPrologAfterBeginTransaction);

            foreach (var source in EnumSources())
            {
                source.PutMaterialize(cmp);
            }

            foreach (var ent in Entities)
            {
                if (!ent.IncludeInSync) continue;
                ent.RunRound1(cmp, useTransaction);
            }

            var reverted = new List<TargetEntitySqlModel>(Entities);
            reverted.Reverse();

            foreach (var ent in reverted)
            {
                if (!ent.IncludeInSync) continue;
                ent.RunRound2Reverted(cmp, useTransaction);
            }

            foreach (var source in EnumSources())
            {
                source.PutDropMaterialized(cmp);
            }

            cmp.PutCommonEpilog(useTransaction, _model.SqlEpilogBeforeCommitTransaction, _model.SqlEpilogAfterCommitTransaction);
        }

        public TargetEntitySqlModel FindTarget(string name)
        {
            var entity = Entities.FirstOrDefault(x => x.Match(name));
            return entity;
        }

        //private void RunScript(DbConnection conn, IDatabaseFactory factory, Action<SqlScriptCompiler> prolog, Action<SqlScriptCompiler> epilog, IShellContext context, string procname, bool useTransaction)
        //{
        //    var cmp = new SqlScriptCompiler(factory, this, context, name.ToString());

        //    var sw = new StringWriter();
        //    var so = new SqlOutputStream(factory.CreateDialect(), sw, new SqlFormatProperties());
        //    so.OverrideCommandDelimiter(";");
        //    var dmp = factory.CreateDumper(so, new SqlFormatProperties());
        //    var cmp = new SqlScriptCompiler(dmp, this, context, procname);

        //    if (prolog != null) prolog(cmp);

        //    DumpScript(cmp, useTransaction);

        //    if (epilog != null) epilog(cmp);

        //    using (var cmd = conn.CreateCommand())
        //    {
        //        cmd.CommandText = sw.ToString();
        //        cmd.ExecuteNonQuery();
        //    }
        //}

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
                foreach (var col in exSource.Dbsh.Columns)
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
                    AllowBulkCopy = _model.AllowBulkCopy,
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

        public void Run(DbConnection conn, IDatabaseFactory factory, IShellContext context, bool useTransaction, List<ParameterModel> pars, Dictionary<string, string> parValues)
        {
            FillExternalSources(conn, factory, context);
            var cmp = new SqlScriptCompiler(factory, this, context, null);
            cmp.PutScriptProlog(useTransaction, pars, parValues);
            DumpScript(cmp, useTransaction);
            ExecuteScript(conn, cmp.GetCompiledSql());
            FreeExternalSources(conn, factory, context);
        }

        public void CreateProcedure(DbConnection conn, IDatabaseFactory factory, NameWithSchema name, IShellContext context, bool useTransaction, bool overwriteExisting, List<ParameterModel> pars)
        {
            string sql = GenerateCreateProcedure(factory, name, context, useTransaction, overwriteExisting, pars, null);
            ExecuteScript(conn, sql);
        }

        private void ExecuteScript(DbConnection conn, string sql)
        {
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                cmd.CommandTimeout = 3600;
                cmd.ExecuteNonQuery();
            }
        }

        private string GenerateCreateProcedureCore(IDatabaseFactory factory, NameWithSchema name, IShellContext context, bool useTransaction, string createKeyword, List<ParameterModel> pars, string editorInfo)
        {
            var cmp = new SqlScriptCompiler(factory, this, context, name.ToString());
            cmp.PutProcedureHeader(name, useTransaction, createKeyword, pars);
            DumpScript(cmp, useTransaction);
            cmp.PutProcedureFooter();
            cmp.PutEditorInfo(editorInfo);
            return cmp.GetCompiledSql();
        }

        public string GenerateCreateProcedure(IDatabaseFactory factory, NameWithSchema name, IShellContext context, bool useTransaction, bool overwriteExisting, List<ParameterModel> pars, string editorInfo)
        {
            if (overwriteExisting)
            {
                string sqlCore = GenerateCreateProcedureCore(factory, name, context, useTransaction, "", pars, editorInfo);
                var cmp = new SqlScriptCompiler(factory, this, context, name.ToString());
                cmp.CreateOrAlterProcedure(name, sqlCore);
                return cmp.GetCompiledSql();
            }
            else
            {
                return GenerateCreateProcedureCore(factory, name, context, useTransaction, "create", pars, editorInfo);
            }
        }

        public string GenerateScript(IDatabaseFactory factory, IShellContext context, bool useTransaction, List<ParameterModel> pars, Dictionary<string, string> parValues)
        {
            var cmp = new SqlScriptCompiler(factory, this, context, null);

            cmp.PutScriptProlog(useTransaction, pars, parValues);
            DumpScript(cmp, useTransaction);

            return cmp.GetCompiledSql();
        }
    }
}
