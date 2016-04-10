using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.DmlFramework;
using DbShell.Driver.Common.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.RelatedDataSync.SqlModel
{
    public class FilterJoinSqlModel
    {
        private SourceGraphSqlModel _sourceGraph;
        private SourceEntitySqlModel _rootEntity;
        private bool _isValid;
        private List<SourceEntitySqlModel> _entitiesOnTheSameServer = new List<SourceEntitySqlModel>();
        private List<SourceEntitySqlModel> _linkedEntities = new List<SourceEntitySqlModel>();
        private List<SourceEntitySqlModel> _filteredEntities = new List<SourceEntitySqlModel>();
        private IDatabaseFactory _factory;

        private FilterJoinSqlModel(SourceEntitySqlModel rootModel, SourceGraphSqlModel sourceGraphModel, IDatabaseFactory factory)
        {
            _sourceGraph = sourceGraphModel;
            _rootEntity = rootModel;
            _factory = factory;

            FillEntitiesOnTheSameServer();

            BuildLinkedEntities();

            bool hasFilter = _linkedEntities.Any(x => x.Dbsh.Columns.Any(y => y.Filter != null));

            if (!hasFilter)
            {
                _isValid = false;
                return;
            }

            _filteredEntities.AddRange(_linkedEntities);
            DetectUnusedEntities();
        }

        private void FillEntitiesOnTheSameServer()
        {
            if (_rootEntity.Dbsh.DataSource is DbShell.Core.Utility.TableOrView)
            {
                _isValid = true;
                var rootTable = (DbShell.Core.Utility.TableOrView)_rootEntity.Dbsh.DataSource;
                string connection = rootTable.Connection;

                foreach (var otherEnt in _sourceGraph.Entities)
                {
                    var otherTable = otherEnt.Dbsh?.DataSource as DbShell.Core.Utility.TableOrView;
                    if (otherTable == null) continue;
                    if (otherTable == rootTable) continue;
                    if (otherTable.Connection != rootTable.Connection) continue;

                    _entitiesOnTheSameServer.Add(otherEnt);
                }
            }
        }

        private DbShell.Core.Utility.TableOrView EntityTable(SourceEntitySqlModel entity)
        {
            return (DbShell.Core.Utility.TableOrView)entity.Dbsh.DataSource;
        }

        private NameWithSchema EntityFullName(SourceEntitySqlModel entity)
        {
            return EntityTable(entity).GetFullName(null);
        }

        private string EntityAlias(SourceEntitySqlModel entity)
        {
            return "src_" + _filteredEntities.IndexOf(entity);
        }

        private void BuildLinkedEntities()
        {
            _linkedEntities.Add(_rootEntity);

            for (;;)
            {
                bool added = false;

                foreach (var ent1 in _linkedEntities)
                {
                    foreach (var col in ent1.Columns)
                    {
                        foreach (var ent2 in col.Entities)
                        {
                            if (ent2 == ent1) continue;
                            // prevent duplicate records in because of left joins
                            if (ent2.SingleKeyColumnNameOrAlias != col.Alias) continue;

                            if (!_linkedEntities.Contains(ent2))
                            {
                                added = true;
                                _linkedEntities.Add(ent2);
                                break;
                            }
                        }
                        if (added) break;
                    }
                    if (added) break;
                }

                if (!added) break;
            }
        }

        private void DetectUnusedEntities()
        {
            for (;;)
            {
                var removable = new List<SourceEntitySqlModel>();
                foreach (var ent in _filteredEntities)
                {
                    if (ent == _rootEntity)
                    {
                        // root entity is needed
                        continue;
                    }

                    if (ent.Dbsh.Columns.Any(x => x.Filter != null))
                    {
                        // entity has filter - is needed
                        continue;
                    }

                    var keycols = ent.Columns.Where(x => x.Entities.Count >= 2).ToList();
                    if (keycols.Count > 1)
                    {
                        continue;
                    }

                    if (keycols.Count == 1)
                    {
                        if (keycols[0].Entities.Count > 2)
                        {
                            continue;
                        }
                    }

                    removable.Add(ent);
                }

                if (!removable.Any()) break;

                var removed = removable.First();
                _filteredEntities.RemoveAll(x => x.SqlAlias == removed.SqlAlias);
            }
        }

        public static FilterJoinSqlModel Create(SourceEntitySqlModel rootTable, SourceGraphSqlModel sourceGraphModel, IDatabaseFactory factory)
        {
            var res = new FilterJoinSqlModel(rootTable, sourceGraphModel, factory);
            if (res._isValid) return res;
            return null;
        }

        private DmlfSelect BuildSelect()
        {
            var select = new DmlfSelect();
            var from = select.SingleFrom;
            from.Source = new DmlfSource
            {
                TableOrView = EntityFullName(_rootEntity),
                Alias = EntityAlias(_rootEntity),
            };

            var added = new List<SourceEntitySqlModel>();
            added.Add(_rootEntity);

            foreach (var entity in _filteredEntities)
            {
                if (added.Contains(entity)) continue;
                var relation = new DmlfRelation
                {
                    JoinType = DmlfJoinType.Left,
                    Reference = new DmlfSource
                    {
                        TableOrView = EntityFullName(entity),
                        Alias = EntityAlias(entity),
                    },
                };


                foreach (var column in entity.Columns)
                {
                    foreach (var ent2 in added)
                    {
                        if (ent2.Columns.Any(x => x.Alias == column.Alias))
                        {
                            relation.Conditions.Add(new DmlfEqualCondition
                            {
                                LeftExpr = new DmlfColumnRefExpression
                                {
                                    Column = new DmlfColumnRef
                                    {
                                        ColumnName = entity.GetColumnName(column.Alias),
                                        Source = new DmlfSource { Alias = EntityAlias(entity) },
                                    }
                                },
                                RightExpr = new DmlfColumnRefExpression
                                {
                                    Column = new DmlfColumnRef
                                    {
                                        ColumnName = ent2.GetColumnName(column.Alias),
                                        Source = new DmlfSource { Alias = EntityAlias(ent2) },
                                    }
                                },
                            });
                        }
                    }
                }

                from.Relations.Add(relation);
            }

            foreach(var col in _rootEntity.Dbsh.Columns)
            {
                select.Columns.Add(DmlfResultField.BuildFromColumn(col.Name, new DmlfSource { Alias = EntityAlias(_rootEntity) }));
            }

            foreach(var entity in _filteredEntities)
            {
                foreach(var col in entity.Dbsh.Columns)
                {
                    if (col.Filter == null) continue;
                    var orCond = new DmlfOrCondition();
                    orCond.Conditions.Add(SourceColumnSqlModel.CompileSingleFilter(col, EntityAlias(entity)));
                    if (entity.SingleKeyColumnOriginalName != null)
                    {
                        orCond.Conditions.Add(new DmlfIsNullCondition
                        {
                            Expr = new DmlfColumnRefExpression
                            {
                                Column = new DmlfColumnRef
                                {
                                    ColumnName = entity.SingleKeyColumnOriginalName,
                                    Source = new DmlfSource { Alias = EntityAlias(entity) },
                                }
                            }
                        });
                    }
                    select.AddAndCondition(orCond);
                }
            }

            return select;
        }

        public DbShell.Core.Query DataSource
        {
            get
            {
                var select = BuildSelect();
                string sql = select.ToSql(_factory);
                return new DbShell.Core.Query
                {
                    Connection = EntityTable(_rootEntity).Connection,
                    Text = sql,
                };
            }
        }
    }
}
