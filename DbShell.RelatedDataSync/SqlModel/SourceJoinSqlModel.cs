using DbShell.Driver.Common.DmlFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.RelatedDataSync.SqlModel
{
    public class SourceJoinSqlModel : SourceGraphSqlModelBase
    {
        private TargetEntitySqlModel _targetEntitySqlModel;
        public DmlfFromItem SourceJoin;
        private List<SourceEntitySqlModel> _processedEntities = new List<SourceEntitySqlModel>();
        private List<SourceEntitySqlModel> _entityQueue = new List<SourceEntitySqlModel>();

        public SourceJoinSqlModel(TargetEntitySqlModel targetEntitySqlModel)
        {
            _targetEntitySqlModel = targetEntitySqlModel;

            SourceJoin = new DmlfFromItem();


            foreach (var column in _targetEntitySqlModel.RequiredSourceColumns)
            {
                if (Columns.ContainsKey(column.Alias)) continue;

                Columns[column.Alias] = new SourceColumnSqlModel
                {
                    Alias = column.Alias,
                };

                bool addedEntity = false;
                foreach (var ent in column.Entities)
                {
                    if (ent.SingleKeyColumn == column.Alias)
                    {
                        AddEntity(ent);
                        addedEntity = true;
                        break;
                    }
                }
                if (addedEntity) continue;

                AddEntity(column.Entities.First());
            }

            _entityQueue.AddRange(Entities);
            //queue.Add(_targetEntitySqlModel.KeySourceColumns.First().Entities.First());
            //foreach (var ent in _targetEntitySqlModel.RequiredSourceColumns.SelectMany(x => x.Entities))
            //{
            //    if (queue.Contains(ent)) continue;
            //    queue.Add(ent);
            //}

            var ent0 = PopEntityFromQueue();

            SourceJoin.Source = new DmlfSource
            {
                Alias = ent0.SqlAlias,
                TableOrView = ent0.TableName,
            };
            _processedEntities.Add(ent0);

            while (_entityQueue.Any())
            {
                var ent = PopEntityFromQueue();

                var relation = new DmlfRelation
                {
                    JoinType = DmlfJoinType.Left,
                    Reference = new DmlfSource
                    {
                        Alias = ent.SqlAlias,
                        TableOrView = ent.TableName,
                    }
                };

                foreach (var column in ent.Columns)
                {
                    foreach (var ent2 in _processedEntities)
                    {
                        if (ent2.Columns.Any(x => x.Alias == column.Alias))
                        {
                            relation.Conditions.Add(new DmlfEqualCondition
                            {
                                LeftExpr = new DmlfColumnRefExpression
                                {
                                    Column = new DmlfColumnRef
                                    {
                                        ColumnName = ent.GetColumnName(column.Alias),
                                        Source = new DmlfSource
                                        {
                                            Alias = ent.SqlAlias,
                                        }
                                    }
                                },
                                RightExpr = new DmlfColumnRefExpression
                                {
                                    Column = new DmlfColumnRef
                                    {
                                        ColumnName = ent2.GetColumnName(column.Alias),
                                        Source = new DmlfSource
                                        {
                                            Alias = ent2.SqlAlias,
                                        }
                                    }
                                },
                            });
                        }
                    }
                }

                SourceJoin.Relations.Add(relation);
                _processedEntities.Add(ent);
            }
        }

        private bool EntityHasKey(SourceEntitySqlModel entity)
        {
            return _targetEntitySqlModel.TargetColumns.Where(x => x.IsKey).Any(x => x.Sources.Any(y => entity.Columns.Any(z => z.Alias == y.Alias)));
        }

        private SourceEntitySqlModel FindEntityFromQueue()
        {
            SourceEntitySqlModel res;
            var processedColumns = new HashSet<string>(_processedEntities.SelectMany(x => x.Columns).Select(x => x.Alias).Distinct());
            res = _entityQueue.FirstOrDefault(x => EntityHasKey(x) && x.Columns.Any(y => processedColumns.Contains(y.Alias)));
            if (res != null) return res;
            res = _entityQueue.FirstOrDefault(x => x.Columns.Any(y => processedColumns.Contains(y.Alias)));
            if (res != null) return res;
            res = _entityQueue.FirstOrDefault(x => EntityHasKey(x));
            if (res != null) return res;
            res = _entityQueue.FirstOrDefault();
            return res;
        }


        private SourceEntitySqlModel PopEntityFromQueue()
        {
            var res = FindEntityFromQueue();
            _entityQueue.Remove(res);
            return res;
        }

        private void AddEntity(SourceEntitySqlModel sourceEntity)
        {
            var src = new SourceEntitySqlModel(sourceEntity.Dbsh);
            Entities.Add(src);
            src.SqlAlias = sourceEntity.SqlAlias;
            src.TableName = sourceEntity.TableName;
            foreach (var colItem in sourceEntity.Dbsh.Columns)
            {
                string alias = colItem.AliasOrName;
                if (!Columns.ContainsKey(alias))
                {
                    Columns[alias] = new SourceColumnSqlModel
                    {
                        Alias = alias,
                    };
                }
                Columns[alias].DbshColumns.Add(colItem);
                Columns[alias].Entities.Add(src);
                src.Columns.Add(Columns[alias]);
            }
        }
    }
}
