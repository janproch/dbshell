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
using DbShell.Driver.Common.FilterParser;

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
        public LinkedDatabaseInfo TargetLinkedInfo;

        public static string ExpressionColumnRegex = @"\{([^\}]+)\}";

        public string LogName => _dbsh.Alias ?? TargetTable.ToString();
        public ColumnInfo FindColumnInfo(string name) => Structure?.Columns?.FirstOrDefault(x => x.Name == name);
        public DataSyncSqlModel DataSync => _dataSyncSqlModel;

        public TargetEntitySqlModel(DataSyncSqlModel dataSyncSqlModel, Target dbsh, IShellContext context)
        {
            this._dataSyncSqlModel = dataSyncSqlModel;
            this._dbsh = dbsh;
            TargetTable = new NameWithSchema(context.Replace(dbsh.TableSchema), context.Replace(dbsh.TableName));
            string findSchema = dbsh.TableSchema;
            if (findSchema != null && findSchema.StartsWith(NameWithSchema.NoQuotePrefix)) findSchema = null;
            Structure = dataSyncSqlModel.TargetStructure.FindTableLike(findSchema, TargetTable.Name);
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

            if (!String.IsNullOrEmpty(_dbsh.Connection))
            {
                var ctxConn = new NormalizedDatabaseConnectionInfo(new DatabaseConnectionInfoHolder { ProviderString = context.GetDefaultConnection() });
                var tableConn = new NormalizedDatabaseConnectionInfo(new DatabaseConnectionInfoHolder { ProviderString = context.Replace(_dbsh.Connection), LinkedInfo = _dbsh.LinkedInfo });

                if (ctxConn != tableConn)
                {
                    if (ctxConn.ServerConnectionString == tableConn.ServerConnectionString)
                    {
                        TargetLinkedInfo = tableConn.GetLinkedInfo();
                    }
                    else
                    {
                        throw new IncorrectRdsDefinitionException($"DBSH-00000 RDS target must be reachable by database or linked server: ({TargetTable})");
                    }
                }
            }
        }

        public void TestCorrectness()
        {
            if (IncludeInSync)
            {
                foreach (var fk in RefEntities.Values)
                {
                    if (!fk.TargetColumns.Any(x => x.IsKey) && !fk.TargetColumns.Any(x => x.IsRestriction))
                    {
                        throw new IncorrectRdsDefinitionException($"DBSH-00000 Table {fk.TargetTable} must have key or restriction, because it is referenced from {TargetTable}");
                    }
                }
            }
        }

        public bool IncludeInSync
        {
            get { return TargetColumns.Any(x => x.IsKey); }
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
                LinkedInfo = TargetLinkedInfo,
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
            res.LinkedInfo = TargetLinkedInfo;
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
                foreach (var col in TargetColumns.Where(x => x.IsKey || (x.IsRestriction && x.IsReference)))
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
                LinkedInfo = TargetLinkedInfo,
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
                var colFilterCondition = col.FilterCondition;

                // process additional condition
                var additional = _dbsh.AdditionalFilters.FirstOrDefault(x => x.Column == col.Alias);
                if (additional != null)
                {
                    var type = SourceColumnSqlModel.DetectFilterType(additional.FilterType, col.DbshColumns);

                    var entity = col.Entities.First();
                    var expr = new DmlfColumnRefExpression
                    {
                        Column = new DmlfColumnRef
                        {
                            ColumnName = entity.GetColumnName(col.Alias),
                            Source = entity.QuerySource,
                        }
                    };

                    var additionalCondition = FilterParser.ParseFilterExpression(type, expr, additional.Filter);

                    if (colFilterCondition != null)
                    {
                        var andCondition = new DmlfAndCondition();
                        andCondition.Conditions.Add(additionalCondition);
                        andCondition.Conditions.Add(colFilterCondition);
                        colFilterCondition = andCondition;
                    }
                    else
                    {
                        colFilterCondition = additionalCondition;
                    }
                }

                if (colFilterCondition != null)
                {
                    var orCond = new DmlfOrCondition();

                    if (col.Entities.Count == 1)
                    {
                        var entity = col.Entities.Single();
                        if (entity.SingleKeyColumnNameOrAlias != null)
                        {
                            var expr = new DmlfColumnRefExpression
                            {
                                Column = new DmlfColumnRef
                                {
                                    ColumnName = entity.GetColumnName(entity.SingleKeyColumnNameOrAlias),
                                    Source = entity.QuerySource,
                                }
                            };
                            orCond.Conditions.Add(new DmlfIsNullCondition
                            {
                                Expr = expr,
                            });
                        }
                    }

                    if (orCond.Conditions.Any())
                    {
                        orCond.Conditions.Add(colFilterCondition);
                        cmd.AddAndCondition(orCond);
                    }
                    else
                    {
                        cmd.AddAndCondition(colFilterCondition);
                    }
                }
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

        internal void CreateRestrictionCondition(DmlfCommandBase cmd, string targetEntityAlias, bool includeReferenceRestrictions = true)
        {
            CreateTargetColumsnCondition(cmd, targetEntityAlias, x => x.IsRestriction && (includeReferenceRestrictions || !x.IsReference));
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
                    LinkedInfo = TargetLinkedInfo,
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
                LinkedInfo = TargetLinkedInfo,
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
                    LinkedInfo = TargetLinkedInfo,
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
                if (column.CannotBeCompared) continue;

                orCondition.Conditions.Add(new DmlfNotEqualWithNullTestCondition
                {
                    LeftExpr = column.CreateCompareExpression(column.CreateSourceExpression(SourceJoinModel, false)),
                    RightExpr = column.CreateCompareExpression(column.CreateTargetExpression("target")),
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
                LinkedInfo = TargetLinkedInfo,
            };
            var existSelect = new DmlfSelect();
            res.AddAndCondition(new DmlfNotExistCondition
            {
                Select = existSelect,
            });
            existSelect.SelectAll = true;
            existSelect.From.Add(SourceJoinModel.SourceToRefsJoin);
            CreateKeyCondition(existSelect, "target");
            CreateRestrictionCondition(res, "target", false);
            CreateLifetimeConditions(res, "target");
            CreateReferenceRestrictionsCodition(res, "target");

            CreateFilterConditions(existSelect);
            return res;
        }

        private void CreateReferenceRestrictionsCodition(DmlfCommandBase res, string targetEntityAlias)
        {
            var builder = new ReferenceRestrictionJoinBuilder();
            builder.FindReferences(this, "target");
            builder.AddReferenceJoins(res);

            //int restrIndex = 1;
            //foreach (var fkPair in this.RefEntities)
            //{
            //    if (!fkPair.Key.IsRestriction) continue;

            //    // reference restriction - compile additional EXIST clause
            //    var existRestr = new DmlfSelect();
            //    string testedAlias = "tested_" + restrIndex;

            //    existRestr.SingleFrom.Source = new DmlfSource
            //    {
            //        TableOrView = fkPair.Value.TargetTableSqlName,
            //        Alias = testedAlias,
            //        LinkedInfo = fkPair.Value.TargetLinkedInfo,
            //    };
            //    if (fkPair.Value.SourceJoinModel.SourceToRefsJoin.Source != null)
            //    {
            //        existRestr.From.Add(fkPair.Value.SourceJoinModel.SourceToRefsJoin);
            //    }

            //    existRestr.SelectAll = true;
            //    fkPair.Value.CreateKeyCondition(existRestr, testedAlias);
            //    fkPair.Value.CreateLifetimeConditions(existRestr, testedAlias);

            //    foreach (var col in TargetColumns)
            //    {
            //        if (col.UnderlyingReference != fkPair.Key) continue;

            //        var refColumn = new DmlfColumnRefExpression
            //        {
            //            Column = new DmlfColumnRef
            //            {
            //                Source = new DmlfSource { Alias = testedAlias },
            //                ColumnName = col.RefColumnName,
            //            }
            //        };

            //        existRestr.AddAndCondition(new DmlfEqualCondition
            //        {
            //            LeftExpr = col.CreateTargetExpression("target"),
            //            RightExpr = refColumn,
            //            CollateSpec = col.UseCollate(SourceJoinModel) ? "DATABASE_DEFAULT" : null,
            //        });
            //    }

            //    res.AddAndCondition(new DmlfExistCondition
            //    {
            //        Select = existRestr,
            //    });

            //    restrIndex++;
            //}
        }

        internal void CreateLifetimeConditions(DmlfCommandBase res, string targetEntityAlias)
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
