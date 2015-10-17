﻿using DbShell.Common;
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

        public static string ExpressionColumnRegex = @"\{([^\}]+)\}";

        public string LogName => _dbsh.Alias ?? TargetTable.ToString();

        public TargetEntitySqlModel(DataSyncSqlModel dataSyncSqlModel, Target dbsh, IShellContext context)
        {
            this._dataSyncSqlModel = dataSyncSqlModel;
            this._dbsh = dbsh;
            TargetTable = new NameWithSchema(context.Replace(dbsh.TableSchema), context.Replace(dbsh.TableName));
            SqlAlias = _dbsh.Alias ?? "dst_" + _dataSyncSqlModel.Entities.Count;

            foreach (var col in dbsh.Columns)
            {
                var targetCol = new TargetNoRefColumnSqlModel(col);
                TargetColumns.Add(targetCol);

                foreach (string alias in ExtractColumnSources(col))
                {
                    var source = dataSyncSqlModel.SourceGraphModel[alias];
                    RequiredSourceColumns.Add(source);
                    if (col.IsKey) KeySourceColumns.Add(source);
                    //targetCol.Sources.Add(source);
                }
            }

            foreach (var fk in dbsh.References)
            {
                string replaced = context.Replace(fk.Target);
                var fullName = StructuredIdentifier.Parse(replaced);
                var entity = _dataSyncSqlModel.Entities.FirstOrDefault(x => x.Match(fullName));
                if (entity == null) throw new Exception($"DBSH-00000 Target entity {replaced} not found");
                RefEntities[fk] = entity;

                foreach (var col in fk.Columns)
                {
                    TargetColumns.Add(new TargetRefColumnSqlModel(fk, col, entity));
                }

                foreach (var col in entity.KeySourceColumns)
                {
                    RequiredSourceColumns.Add(col);
                    if (fk.IsKey) KeySourceColumns.Add(col);
                }
            }

            _dbsh.LifetimeHandler.AddTargetColumns(this);

            if (!KeySourceColumns.Any())
            {
                throw new Exception($"DBSH-00000 Entity {dbsh.TableName} has no source for key");
            }

            SourceJoinModel = new SourceJoinSqlModel(this, dataSyncSqlModel.SourceGraphModel);

            RequiresGrouping = DetectGrouping();
        }

        public DmlfSource GetRefSource(DmlfFromItem from, SourceJoinSqlModel joinModel)
        {
            var res = from.FindSourceWithAlias(SqlAlias);
            if (res != null) return res;
            res = new DmlfSource
            {
                Alias = SqlAlias,
                TableOrView = TargetTable,
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
                });
            }

            from.Relations.Add(rel);

            return res;
        }

        public bool Match(StructuredIdentifier name)
        {
            if (name.Count == 1)
            {
                if (_dbsh.Alias == name.First) return true;
                if (_dbsh.Alias == null && TargetTable.Name == name.First) return true;
            }
            if (name.Count == 2)
            {
                if (_dbsh.Alias != null) return false;
                return TargetTable.Schema == name[0] && TargetTable.Name == name[1];
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
            res.TargetTable = TargetTable;
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

            CreateKeyNotNullCondition(res.Select);

            var existSelect = new DmlfSelect();
            existSelect.SingleFrom.Source = new DmlfSource
            {
                TableOrView = TargetTable,
                Alias = "tested",
            };
            existSelect.SelectAll = true;
            CreateKeyCondition(existSelect, "tested");
            CreateLifetimeConditions(existSelect, "tested");

            res.Select.AddAndCondition(new DmlfNotExistCondition { Select = existSelect });

            return res;
        }

        private void CreateKeyNotNullCondition(DmlfCommandBase cmd)
        {
            foreach (var column in TargetColumns.Where(x => x.IsKey))
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
                    TableOrView = TargetTable,
                }
            });
            CreateKeyCondition(res, "target");
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
                TableOrView = TargetTable,
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
                    TableOrView = TargetTable,
                }
            });
            CreateKeyCondition(cmd, "target");
            CreateLifetimeConditions(cmd, "target");

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
                TableOrView = TargetTable,
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
            return res;
        }

        private void CreateLifetimeConditions(DmlfCommandBase res, string targetEntityAlias)
        {
            _dbsh.LifetimeHandler.CreateLifetimeConditions(res, targetEntityAlias, this);
        }

        private void RunCore(SqlScriptCompiler cmp)
        {
            if (_dbsh.LifetimeHandler.CreateMarkRelived)
            {
                var update = CompileMarkRelived();
                if (update != null)
                {
                    cmp.StartTimeMeasure("OP");
                    cmp.PutSmallTitleComment( "MARK RELIVED");
                    update.GenSql(cmp.Dumper);
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
                    cmp.PutSmallTitleComment( "MARK DELETED");
                    update.GenSql(cmp.Dumper);
                    cmp.EndCommand();
                    cmp.PutLogMessage(this, LogOperationType.MarkDeleted, "@rows rows marked as deleted", "OP");
                }
            }

            if (_dbsh.LifetimeHandler.CreateMarkUpdated)
            {
                var update = CompileMarkUpdated();
                if (update != null)
                {
                    cmp.StartTimeMeasure("OP");
                    cmp.PutSmallTitleComment( "MARK UPDATED");
                    update.GenSql(cmp.Dumper);
                    cmp.EndCommand();
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
                    insert.GenSql(cmp.Dumper);
                    cmp.EndCommand();
                    cmp.PutLogMessage(this, LogOperationType.Insert, "@rows rows inserted", "OP");
                }
            }

            if (_dbsh.LifetimeHandler.CreateUpdate)
            {
                var update = CompileUpdate();
                if (update != null)
                {
                    cmp.StartTimeMeasure("OP");
                    cmp.PutSmallTitleComment("UPDATE");
                    update.GenSql(cmp.Dumper);
                    cmp.EndCommand();
                    cmp.PutLogMessage(this, LogOperationType.Update, "@rows rows updated", "OP");
                }
            }

            if (_dbsh.LifetimeHandler.CreateDelete)
            {
                var delete = CompileDelete();
                if (delete != null)
                {
                    cmp.StartTimeMeasure("OP");
                    cmp.PutSmallTitleComment("DELETE");
                    delete.GenSql(cmp.Dumper);
                    cmp.EndCommand();
                    cmp.PutLogMessage(this, LogOperationType.Delete, "@rows rows deleted", "OP");
                }
            }
        }

        public void Run(SqlScriptCompiler cmp)
        {
            cmp.PutMainTitleComment($"Synchronize entity {SqlAlias} (table {TargetTable})");

            cmp.StartTimeMeasure("TABLE");

            cmp.PutBeginTryCatch(this);
            cmp.Put("&>");
            RunCore(cmp);
            cmp.Put("&<");
            cmp.PutEndTryCatch(this);

            cmp.PutLogMessage(this, LogOperationType.TableSynchronized, "table synchronized", "TABLE");
        }

        //public void Run(DbConnection conn, IDatabaseFactory factory)
        //{
        //    var so = new ConnectionSqlOutputStream(conn, null, factory.CreateDialect());
        //    var dmp = factory.CreateDumper(so, new SqlFormatProperties());
        //    var compiler = new SqlScriptCompiler(dmp);
        //    Run(compiler);
        //}
    }
}
