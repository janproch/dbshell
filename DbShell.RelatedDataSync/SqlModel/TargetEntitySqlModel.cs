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

                foreach(var col in fk.Columns)
                {
                    TargetColumns.Add(new TargetRefColumnSqlModel(fk, col, entity));
                }

                foreach (var col in entity.KeySourceColumns)
                {
                    RequiredSourceColumns.Add(col);
                    if (fk.IsKey) KeySourceColumns.Add(col);
                }
            }

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
                    RightExpr = new DmlfColumnRefExpression
                    {
                        Column = new DmlfColumnRef
                        {
                            ColumnName = keycol.Name,
                            Source = res,
                        }
                    }
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
                    LeftExpr = new DmlfColumnRefExpression
                    {
                        Column = new DmlfColumnRef
                        {
                            Source = new DmlfSource { Alias = targetEntityAlias },
                            ColumnName = column.Name,
                        }
                    },

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

        private DmlfUpdate CompileUpdate()
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
            foreach (var column in TargetColumns.Where(x => !x.IsKey && !x.IsRestriction))
            {
                res.Columns.Add(new DmlfUpdateField
                {
                    TargetColumn = column.Name,
                    Expr = column.CreateSourceExpression(SourceJoinModel, false),
                });
            }
            if (!res.Columns.Any()) return null;
            return res;
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
            return res;
        }

        public void Run(ISqlDumper dmp)
        {
            var insert = CompileInsert();
            if (insert != null)
            {
                insert.GenSql(dmp);
                dmp.EndCommand();
            }

            var update = CompileUpdate();
            if (update != null)
            {
                update.GenSql(dmp);
                dmp.EndCommand();
            }

            var delete = CompileDelete();
            if (delete != null)
            {
                delete.GenSql(dmp);
                dmp.EndCommand();
            }
        }

        public void Run(DbConnection conn, IDatabaseFactory factory)
        {
            var so = new ConnectionSqlOutputStream(conn, null, factory.CreateDialect());
            var dmp = factory.CreateDumper(so, new SqlFormatProperties());
            Run(dmp);
        }
    }
}
