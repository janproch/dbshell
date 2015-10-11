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

namespace DbShell.RelatedDataSync.SqlModel
{
    public class TargetEntitySqlModel
    {
        private DataSyncSqlModel _dataSyncSqlModel;
        private Target _entity;
        public NameWithSchema TargetTable;
        public HashSet<SourceColumnSqlModel> RequiredSourceColumns = new HashSet<SourceColumnSqlModel>();
        public HashSet<SourceColumnSqlModel> KeySourceColumns = new HashSet<SourceColumnSqlModel>();
        public List<TargetColumnSqlModel> TargetColumns = new List<TargetColumnSqlModel>();
        public SourceJoinSqlModel SourceJoinModel;

        public TargetEntitySqlModel(DataSyncSqlModel dataSyncSqlModel, Target entity, IShellContext context)
        {
            this._dataSyncSqlModel = dataSyncSqlModel;
            this._entity = entity;
            TargetTable = new NameWithSchema(context.Replace(entity.TableSchema), context.Replace(entity.TableName));

            foreach (var col in entity.Columns)
            {
                var targetCol = new TargetColumnSqlModel(col);
                TargetColumns.Add(targetCol);

                foreach (string alias in ExtractColumnSources(col))
                {
                    var source = dataSyncSqlModel.SourceGraphModel[alias];
                    RequiredSourceColumns.Add(source);
                    if (col.IsKey) KeySourceColumns.Add(source);
                    targetCol.Sources.Add(source);
                }
            }

            if (!KeySourceColumns.Any())
            {
                throw new Exception($"DBSH-00000 Entity {entity.TableName} has no source for key");
            }

            SourceJoinModel = new SourceJoinSqlModel(this);

        }

        private IEnumerable<string> ExtractColumnSources(TargetColumn col)
        {
            if (col.RealValueType == TargetColumnValueType.Source)
            {
                yield return col.SourceName;
            }
        }

        private DmlfInsertSelect CompileInsert()
        {
            var res = new DmlfInsertSelect();
            res.TargetTable = TargetTable;
            res.Select = new DmlfSelect();
            res.Select.From.Add(SourceJoinModel.SourceJoin);

            foreach (var col in TargetColumns)
            {
                res.TargetColumns.Add(col.Name);
                res.Select.Columns.Add(new DmlfResultField
                {
                    Expr = col.CreateSourceExpression(SourceJoinModel),
                });
            }

            var existSelect = new DmlfSelect();
            existSelect.SingleFrom.Source = new DmlfSource
            {
                TableOrView = TargetTable,
                Alias = "tested",
            };
            existSelect.SelectAll = true;
            foreach (var column in TargetColumns.Where(x => x.IsKey))
            {
                var cond = new DmlfEqualCondition
                {
                    // target columns
                    LeftExpr = new DmlfColumnRefExpression
                    {
                        Column = new DmlfColumnRef
                        {
                            Source = new DmlfSource { Alias = "tested" },
                            ColumnName = column.Name,
                        }
                    },

                    // source column
                    RightExpr = column.CreateSourceExpression(SourceJoinModel),
                };
                existSelect.AddAndCondition(cond);
            }

            res.Select.AddAndCondition(new DmlfNotExistCondition { Select = existSelect });

            return res;
        }

        public void Run(ISqlDumper dmp)
        {
            var insert = CompileInsert();
            insert.GenSql(dmp);
            dmp.EndCommand();
        }

        public void Run(DbConnection conn, IDatabaseFactory factory)
        {
            var so = new ConnectionSqlOutputStream(conn, null, factory.CreateDialect());
            var dmp = factory.CreateDumper(so, new SqlFormatProperties());
            Run(dmp);
        }
    }
}
