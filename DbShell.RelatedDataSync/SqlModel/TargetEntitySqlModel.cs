using DbShell.Common;
using DbShell.Driver.Common.DmlFramework;
using DbShell.Driver.Common.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Data.Common;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Sql;
using System.Text.RegularExpressions;
using System.IO;

namespace DbShell.RelatedDataSync.SqlModel
{
    public class TargetEntitySqlModel
    {
        private DataSyncSqlModel _dataSyncSqlModel;
        private Target _dbsh;
        public NameWithSchema TargetTable;
        public HashSet<SourceColumnSqlModel> RequiredSourceColumns = new HashSet<SourceColumnSqlModel>();
        public HashSet<SourceColumnSqlModel> KeySourceColumns = new HashSet<SourceColumnSqlModel>();
        public List<TargetColumnSqlModelBase> TargetColumns = new List<TargetColumnSqlModelBase>();
        public Dictionary<TargetReference, TargetEntitySqlModel> RefEntities = new Dictionary<TargetReference, TargetEntitySqlModel>();
        public SourceJoinSqlModel SourceJoinModel;
        public string SqlAlias;
        public bool RequiresGrouping;
        public TableInfo Structure;

        public static string ExpressionColumnRegex = @"\{([^\}]+)\}";

        public string LogName => _dbsh.Alias ?? TargetTable.ToString();
        public ColumnInfo FindColumnInfo(string name) => Structure?.Columns?.FirstOrDefault(x => x.Name == name);
        public DataSyncSqlModel DataSync => _dataSyncSqlModel;

        public TargetEntitySqlModel(DataSyncSqlModel dataSyncSqlModel, Target dbsh, IShellContext context)
        {
            this._dataSyncSqlModel = dataSyncSqlModel;
            this._dbsh = dbsh;
            TargetTable = new NameWithSchema(context.Replace(dbsh.TableSchema), context.Replace(dbsh.TableName));
            Structure = dataSyncSqlModel.TargetStructure.FindTableLike(TargetTable.Schema, TargetTable.Name);
            SqlAlias = _dbsh.Alias ?? "dst_" + _dataSyncSqlModel.Entities.Count;

            foreach (var col in dbsh.Columns)
            {
                var targetCol = new TargetNoRefColumnSqlModel(col, FindColumnInfo(col.Name));
                TargetColumns.Add(targetCol);

                foreach (string alias in ExtractColumnSources(col))
                {
                    SourceColumnSqlModel source = null;
                    if (dataSyncSqlModel.SourceGraphModel == null)
                    {
                        // flat sync
                        if (!String.IsNullOrEmpty(dbsh.PrimarySource))
                        {
                            var tableSource = DataSync.FlatSources.FirstOrDefault(x => x.Match(Dbsh.PrimarySource));
                            if (tableSource != null)
                            {
                                source = tableSource.Columns.FirstOrDefault(x => x.Alias == alias);
                            }
                        }
                    }
                    else
                    {
                        source = dataSyncSqlModel.SourceGraphModel[alias];
                        //targetCol.Sources.Add(source);
                    }
                    RequiredSourceColumns.Add(source);
                    if (col.IsKey) KeySourceColumns.Add(source);
                }
            }
        }

        private NameWithSchema TargetTableSqlName
        {
            get
            {
                if (!String.IsNullOrEmpty(_dbsh.FullTableNameVariable)) return new NameWithSchema($"###({_dbsh.FullTableNameVariable})###");
                return TargetTable;
            }
        }

        public void AddReference(TargetReference fk, TargetEntitySqlModel targetEntity)
        {
            RefEntities[fk] = targetEntity;

            foreach (var col in fk.Columns)
            {
                TargetColumns.Add(new TargetRefColumnSqlModel(fk, col, targetEntity, FindColumnInfo(col.BaseName)));
            }

            foreach (var col in targetEntity.KeySourceColumns)
            {
                RequiredSourceColumns.Add(col);
                if (fk.IsKey) KeySourceColumns.Add(col);
            }
        }

        public void CreateJoinModel()
        {
            _dbsh.LifetimeHandler.AddTargetColumns(this);

            //if (!KeySourceColumns.Any())
            //{
            //    throw new Exception($"DBSH-00220 Entity {dbsh.TableName} has no source for key");
            //}

            SourceJoinModel = new SourceJoinSqlModel(this, _dataSyncSqlModel.SourceGraphModel);

            RequiresGrouping = DetectGrouping();
        }

        public DmlfSource GetRefSource(DmlfFromItem from, SourceJoinSqlModel joinModel)
        {
            var res = from.FindSourceWithAlias(SqlAlias);
            if (res != null) return res;
            res = new DmlfSource
            {
                Alias = SqlAlias,
                TableOrView = TargetTableSqlName,
            };
            var rel = new DmlfRelation
            {
                JoinType = DmlfJoinType.Left,
                Reference = res,
            };

            foreach (var keycol in TargetColumns.Where(x => x.IsKey || x.IsRestriction))
            {
                rel.Conditions.Add(new DmlfEqualCondition
                {
                    LeftExpr = keycol.CreateSourceExpression(joinModel, false),
                    RightExpr = keycol.CreateTargetExpression(res),
                    CollateSpec = keycol.UseCollate(joinModel) ? "DATABASE_DEFAULT" : null,
                });
            }

            from.Relations.Add(rel);

            return res;
        }

        public bool Match(string name)
        {
            if (name == _dbsh.Alias) return true;

            var sident = StructuredIdentifier.Parse(name);

            if (sident.Count == 1)
            {
                if (_dbsh.Alias == sident.First) return true;
                if (_dbsh.Alias == null && TargetTable.Name == sident.First) return true;
            }
            if (sident.Count == 2)
            {
                if (_dbsh.Alias != null) return false;
                return TargetTable.Schema == sident[0] && TargetTable.Name == sident[1];
            }
            return false;
        }

        private bool DetectGrouping()
        {
            // if primary source is not defined, group=TRUE
            if (SourceJoinModel.PrimarySource == null) return true;
            // if primary source has not key, group=TRUE
            if (!SourceJoinModel.PrimarySource.KeyColumns.Any()) return true;

            // all columns is source key must be in entity key
            foreach (var col in SourceJoinModel.PrimarySource.KeyColumns)
            {
                if (!KeySourceColumns.Any(x => x.Alias == col.Alias)) return true;
            }

            // source key is covered by this key => grouping is not required
            return false;
        }

        public Target Dbsh
        {
            get { return _dbsh; }
        }

        private IEnumerable<string> ExtractColumnSources(TargetColumn col)
        {
            if (col.RealValueType == TargetColumnValueType.Source)
            {
                yield return col.Source;
            }
            if (col.RealValueType == TargetColumnValueType.Expression)
            {
                foreach (Match m in Regex.Matches(col.Expression, ExpressionColumnRegex))
                {
                    yield return m.Groups[1].Value;
                }
            }
        }

        private DmlfInsertSelect CompileInsert()
        {
            var res = new DmlfInsertSelect();
            res.TargetTable = TargetTableSqlName;
            res.Select = new DmlfSelect();
            res.Select.From.Add(SourceJoinModel.SourceToRefsJoin);

            foreach (var col in TargetColumns)
            {
                res.TargetColumns.Add(col.Name);
                var expr = col.CreateSourceExpression(SourceJoinModel, RequiresGrouping && !col.IsKey && !col.IsRestriction);
                res.Select.Columns.Add(new DmlfResultField
                {
                    Expr = expr,
                });
            }

            if (RequiresGrouping)
            {
                res.Select.GroupBy = new DmlfGroupByCollection();
                foreach (var col in TargetColumns.Where(x => x.IsKey))
                {
                    var expr = col.CreateSourceExpression(SourceJoinModel, false);
                    res.Select.GroupBy.Add(new DmlfGroupByItem
                    {
                        Expr = expr,
                    });
                }
            }

            CreateNotNullConditions(res.Select);

            var existSelect = new DmlfSelect();
            existSelect.SingleFrom.Source = new DmlfSource
            {
                TableOrView = TargetTableSqlName,
                Alias = "tested",
            };
            existSelect.SelectAll = true;
            CreateKeyCondition(existSelect, "tested");
            CreateLifetimeConditions(existSelect, "tested");
            CreateFilterConditions(res.Select);

            res.Select.AddAndCondition(new DmlfNotExistCondition { Select = existSelect });

            return res;
        }

        private void CreateFilterConditions(DmlfCommandBase cmd)
        {
            foreach(var col in SourceJoinModel.Columns.Values)
            {
                if (col.FilterCondition != null) cmd.AddAndCondition(col.FilterCondition);
            }
        }

        private void CreateNotNullConditions(DmlfCommandBase cmd)
        {
            foreach (var column in TargetColumns.Where(x => x.IsKey || (x.Info?.NotNull ?? false)))
            {
                var cond = new DmlfIsNotNullCondition
                {
                    Expr = column.CreateSourceExpression(SourceJoinModel, false),
                };
                cmd.AddAndCondition(cond);
            }
        }

        private void CreateTargetColumsnCondition(DmlfCommandBase cmd, string targetEntityAlias, Func<TargetColumnSqlModelBase, bool> useThisColumns)
        {
            foreach (var column in TargetColumns.Where(useThisColumns))
            {
                var cond = new DmlfEqualCondition
                {
                    // target columns
                    LeftExpr = column.CreateTargetExpression(targetEntityAlias),

                    // source column
                    RightExpr = column.CreateSourceExpression(SourceJoinModel, false),

                    CollateSpec = column.UseCollate(SourceJoinModel) ? "DATABASE_DEFAULT" : null,
                };
                cmd.AddAndCondition(cond);
            }

        }

        private void CreateKeyCondition(DmlfCommandBase cmd, string targetEntityAlias)
        {
            CreateTargetColumsnCondition(cmd, targetEntityAlias, x => x.IsKey || x.IsRestriction);
        }

        private void CreateRestrictionCondition(DmlfCommandBase cmd, string targetEntityAlias)
        {
            CreateTargetColumsnCondition(cmd, targetEntityAlias, x => x.IsRestriction);
        }

        private DmlfUpdate CompileMarkRelived()
        {
            var res = new DmlfUpdate();
            res.UpdateTarget = new DmlfSource { Alias = "target" };
            res.From.Add(SourceJoinModel.SourceToRefsJoin);
            res.From.Add(new DmlfFromItem
            {
                Source = new DmlfSource
                {
                    Alias = "target",
                    TableOrView = TargetTableSqlName,
                }
            });
            CreateKeyCondition(res, "target");
            CreateFilterConditions(res);
            _dbsh.LifetimeHandler.CreateReliveConditions(res, "target", this);
            _dbsh.LifetimeHandler.CreateReliveUpdateFields(res, "target", this);
            return res;
        }

        private DmlfUpdate CompileMarkDeleted()
        {
            var res = new DmlfUpdate();
            res.UpdateTarget = new DmlfSource { Alias = "target" };
            res.SingleFrom.Source = new DmlfSource
            {
                Alias = "target",
                TableOrView = TargetTableSqlName,
            };
            var existSelect = new DmlfSelect();
            res.AddAndCondition(new DmlfNotExistCondition
            {
                Select = existSelect,
            });
            existSelect.SelectAll = true;
            existSelect.From.Add(SourceJoinModel.SourceToRefsJoin);
            CreateKeyCondition(existSelect, "target");
            CreateRestrictionCondition(res, "target");
            CreateLifetimeConditions(res, "target");
            CreateFilterConditions(existSelect);
            _dbsh.LifetimeHandler.CreateSetDeletedUpdateFields(res, "target", this);
            return res;
        }

        private DmlfUpdate CompileUpdateCore(Func<TargetColumnSqlModelBase, bool> compareColumn, Func<TargetColumnSqlModelBase, bool> updateColumn, Action<DmlfUpdate> createUpdateSpecialColumns, CompareColumnContext compareContext, UpdateColumnContext updateContext)
        {
            var cmd = new DmlfUpdate();
            cmd.UpdateTarget = new DmlfSource { Alias = "target" };
            cmd.From.Add(SourceJoinModel.SourceToRefsJoin);
            cmd.From.Add(new DmlfFromItem
            {
                Source = new DmlfSource
                {
                    Alias = "target",
                    TableOrView = TargetTableSqlName,
                }
            });
            CreateKeyCondition(cmd, "target");
            CreateLifetimeConditions(cmd, "target");
            CreateFilterConditions(cmd);

            createUpdateSpecialColumns(cmd);

            foreach (var column in TargetColumns)
            {
                bool? update = _dbsh.LifetimeHandler.UpdateColumn(column.Name, updateContext);
                if (update == null) update = updateColumn(column);
                if (!update.Value) continue;
                cmd.Columns.Add(new DmlfUpdateField
                {
                    TargetColumn = column.Name,
                    Expr = column.CreateSourceExpression(SourceJoinModel, false),
                });
            }

            var orCondition = new DmlfOrCondition();
            foreach (var column in TargetColumns)
            {
                bool? compare = _dbsh.LifetimeHandler.CompareColumn(column.Name, compareContext);

                if (compare == null) compare = compareColumn(column);
                if (!compare.Value) continue;

                orCondition.Conditions.Add(new DmlfNotEqualWithNullTestCondition
                {
                    LeftExpr = column.CreateSourceExpression(SourceJoinModel, false),
                    RightExpr = column.CreateTargetExpression("target"),
                    CollateSpec = column.UseCollate(SourceJoinModel) ? "DATABASE_DEFAULT" : null,
                });
            }
            if (orCondition.Conditions.Any()) cmd.AddAndCondition(orCondition);

            if (!cmd.Columns.Any()) return null;
            return cmd;
        }

        private DmlfUpdate CompileUpdate()
        {
            return CompileUpdateCore(x => x.Compare, x => !x.IsKey && !x.IsRestriction && x.Update,
                cmd => { }, CompareColumnContext.Update, UpdateColumnContext.Update);
        }

        private DmlfUpdate CompileMarkUpdated()
        {
            return CompileUpdateCore(x => x.Compare, x => false,
                cmd =>
                {
                    _dbsh.LifetimeHandler.CreateSetUpdatedUpdateFields(cmd, "target", this);
                }, CompareColumnContext.MarkUpdated, UpdateColumnContext.MarkUpdated);
        }

        private DmlfDelete CompileDelete()
        {
            var res = new DmlfDelete();
            res.DeleteTarget = new DmlfSource { Alias = "target" };
            res.SingleFrom.Source = new DmlfSource
            {
                Alias = "target",
                TableOrView = TargetTableSqlName,
            };
            var existSelect = new DmlfSelect();
            res.AddAndCondition(new DmlfNotExistCondition
            {
                Select = existSelect,
            });
            existSelect.SelectAll = true;
            existSelect.From.Add(SourceJoinModel.SourceToRefsJoin);
            CreateKeyCondition(existSelect, "target");
            CreateRestrictionCondition(res, "target");
            CreateLifetimeConditions(res, "target");
            CreateFilterConditions(existSelect);
            return res;
        }

        private void CreateLifetimeConditions(DmlfCommandBase res, string targetEntityAlias)
        {
            _dbsh.LifetimeHandler.CreateLifetimeConditions(res, targetEntityAlias, this);
        }

        private void RunCoreRound1(SqlScriptCompiler cmp)
        {
            if (_dbsh.LifetimeHandler.CreateMarkRelived)
            {
                var update = CompileMarkRelived();
                if (update != null)
                {
                    cmp.StartTimeMeasure("OP");
                    cmp.PutSmallTitleComment("MARK RELIVED");
                    cmp.GenCommandSql(update);
                    cmp.EndCommand();
                    cmp.PutLogMessage(this, LogOperationType.MarkRelived, "@rows rows marked as relived", "OP");
                }
            }

            if (_dbsh.LifetimeHandler.CreateMarkDeleted)
            {
                var update = CompileMarkDeleted();
                if (update != null)
                {
                    cmp.StartTimeMeasure("OP");
                    cmp.PutSmallTitleComment("MARK DELETED");
                    cmp.GenCommandSql(update);
                    cmp.PutLogMessage(this, LogOperationType.MarkDeleted, "@rows rows marked as deleted", "OP");
                }
            }

            if (_dbsh.LifetimeHandler.CreateMarkUpdated)
            {
                var update = CompileMarkUpdated();
                if (update != null)
                {
                    cmp.StartTimeMeasure("OP");
                    cmp.PutSmallTitleComment("MARK UPDATED");
                    cmp.GenCommandSql(update);
                    cmp.PutLogMessage(this, LogOperationType.MarkUpdated, "@rows rows marked as updated", "OP");
                }
            }

            if (_dbsh.LifetimeHandler.CreateInsert)
            {
                var insert = CompileInsert();
                if (insert != null)
                {
                    cmp.StartTimeMeasure("OP");
                    cmp.PutSmallTitleComment("INSERT");
                    bool isIdentity = Structure != null && Structure.Columns.Any(x => x.AutoIncrement && insert.TargetColumns.Contains(x.Name));
                    if (isIdentity) cmp.GenCommandSql(dmp => dmp.AllowIdentityInsert(insert.TargetTable, true));
                    cmp.GenCommandSql(insert);
                    cmp.PutLogMessage(this, LogOperationType.Insert, "@rows rows inserted", "OP");
                    if (isIdentity) cmp.GenCommandSql(dmp => dmp.AllowIdentityInsert(insert.TargetTable, false));
                }
            }

            if (_dbsh.LifetimeHandler.CreateUpdate)
            {
                var update = CompileUpdate();
                if (update != null)
                {
                    cmp.StartTimeMeasure("OP");
                    cmp.PutSmallTitleComment("UPDATE");
                    cmp.GenCommandSql(update);
                    cmp.PutLogMessage(this, LogOperationType.Update, "@rows rows updated", "OP");
                }
            }
        }

        private void RunCoreRound2Reverted(SqlScriptCompiler cmp)
        {
            if (_dbsh.LifetimeHandler.CreateDelete)
            {
                var delete = CompileDelete();
                if (delete != null)
                {
                    cmp.StartTimeMeasure("OP");
                    cmp.PutSmallTitleComment("DELETE");
                    cmp.GenCommandSql(delete);
                    cmp.PutLogMessage(this, LogOperationType.Delete, "@rows rows deleted", "OP");
                }
            }
        }

        private void RunCore(SqlScriptCompiler cmp, bool useTransaction, Action<SqlScriptCompiler> doRun, int round)
        {
            cmp.PutMainTitleComment($"Synchronize entity {SqlAlias} (table {TargetTable}) - round {round}");

            cmp.StartTimeMeasure("TABLE");

            cmp.PutBeginTryCatch(this);
            cmp.Put("&>");
            doRun(cmp);
            cmp.Put("&<");
            cmp.PutEndTryCatch(this, useTransaction);

            cmp.PutLogMessage(this, LogOperationType.TableSynchronized, $"table synchronized - round {round}", "TABLE");
        }

        public void RunRound1(SqlScriptCompiler cmp, bool useTransaction)
        {
            if (
                   !_dbsh.LifetimeHandler.CreateMarkRelived
                && !_dbsh.LifetimeHandler.CreateMarkDeleted
                && !_dbsh.LifetimeHandler.CreateMarkUpdated
                && !_dbsh.LifetimeHandler.CreateInsert
                && !_dbsh.LifetimeHandler.CreateUpdate
                )
            {
                return;
            }

            RunCore(cmp, useTransaction, RunCoreRound1, 1);
        }

        public void RunRound2Reverted(SqlScriptCompiler cmp, bool useTransaction)
        {
            if (!_dbsh.LifetimeHandler.CreateDelete)
            {
                return;
            }

            RunCore(cmp, useTransaction, RunCoreRound2Reverted, 2);
        }

        //public void Run(DbConnection conn, IDatabaseFactory factory)
        //{
        //    var so = new ConnectionSqlOutputStream(conn, null, factory.CreateDialect());
        //    var dmp = factory.CreateDumper(so, new SqlFormatProperties());
        //    var compiler = new SqlScriptCompiler(dmp);
        //    Run(compiler);
        //}

        public override string ToString()
        {
            return LogName;
        }
    }
}
