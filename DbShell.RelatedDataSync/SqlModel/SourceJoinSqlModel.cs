using DbShell.Driver.Common.DmlFramework;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.RelatedDataSync.SqlModel
{
    public class SourceJoinSqlModel : SourceGraphSqlModelBase
    {
        private TargetEntitySqlModel _targetEntitySqlModel;
        public DmlfFromItem SourceToRefsJoin;
        private List<SourceEntitySqlModel> _processedEntities = new List<SourceEntitySqlModel>();
        private List<SourceEntitySqlModel> _entityQueue = new List<SourceEntitySqlModel>();
        private SourceGraphSqlModel _sourceGraph;
        public SourceEntitySqlModel PrimarySource;

        public SourceJoinSqlModel(TargetEntitySqlModel targetEntitySqlModel, SourceGraphSqlModel sourceGraph)
        {
            _targetEntitySqlModel = targetEntitySqlModel;
            _sourceGraph = sourceGraph;

            SourceToRefsJoin = new DmlfFromItem();


            //foreach (var column in _targetEntitySqlModel.RequiredSourceColumns)
            //{
            //    if (Columns.ContainsKey(column.Alias)) continue;

            //    Columns[column.Alias] = new SourceColumnSqlModel
            //    {
            //        Alias = column.Alias,
            //    };

            //    bool addedEntity = false;
            //    foreach (var ent in column.Entities)
            //    {
            //        if (ent.SingleKeyColumn == column.Alias)
            //        {
            //            AddEntity(ent);
            //            addedEntity = true;
            //            break;
            //        }
            //    }
            //    if (addedEntity) continue;

            //    AddEntity(column.Entities.First());
            //}

            if (_sourceGraph == null)
            {
                // flat variant
                PrimarySource = _targetEntitySqlModel.DataSync.FlatSources.FirstOrDefault(x => x.Match(_targetEntitySqlModel.Dbsh.PrimarySource));
                if (PrimarySource == null)
                {
                    throw new IncorrectRdsDefinitionException($"DBSH-00000 Source not found for entity {_targetEntitySqlModel.LogName}");
                }
                SourceToRefsJoin.Source = PrimarySource.QuerySource;
                foreach (var col in PrimarySource.Columns)
                {
                    Columns[col.Alias] = col;
                }
            }
            else
            {
                _entityQueue.AddRange(_sourceGraph.Entities);

                DetectPrimarySource();

                DetectUnusedEntities();

                RebuildEntityList();
                //queue.Add(_targetEntitySqlModel.KeySourceColumns.First().Entities.First());
                //foreach (var ent in _targetEntitySqlModel.RequiredSourceColumns.SelectMany(x => x.Entities))
                //{
                //    if (queue.Contains(ent)) continue;
                //    queue.Add(ent);
                //}

                if (!_entityQueue.Any() && targetEntitySqlModel.Dbsh.Columns.Any(x => x.IsKey))
                {
                    throw new IncorrectRdsDefinitionException($"LGM-00000 None of source entities is used in {_targetEntitySqlModel.LogName} (try to set source column)");
                }

                if (_entityQueue.Any())
                {
                    CreateSourceJoin();
                    AddRefsToJoin();
                }

                foreach (var col in Columns.Values) col.CompileFilter();
            }
        }

        private void CreateSourceJoin()
        {
            var ent0 = PopEntityFromQueue();

            SourceToRefsJoin.Source = ent0.QuerySource;
            _processedEntities.Add(ent0);

            while (_entityQueue.Any())
            {
                var ent = PopEntityFromQueue();

                var relation = new DmlfRelation
                {
                    JoinType = PrimarySource == null ? DmlfJoinType.Outer : DmlfJoinType.Left,
                    Reference = ent.QuerySource,
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
                                        Source = ent.QuerySource,
                                    }
                                },
                                RightExpr = new DmlfColumnRefExpression
                                {
                                    Column = new DmlfColumnRef
                                    {
                                        ColumnName = ent2.GetColumnName(column.Alias),
                                        Source = ent2.QuerySource,
                                    }
                                },
                            });
                        }
                    }
                }

                SourceToRefsJoin.Relations.Add(relation);
                _processedEntities.Add(ent);
            }
        }

        private void AddRefsToJoin()
        {
            foreach(var fk in _targetEntitySqlModel.RefEntities.Values)
            {
                fk.GetRefSource(SourceToRefsJoin, this);
            }
        }

        private void DetectPrimarySource()
        {
            PrimarySource = null;

            if (!String.IsNullOrWhiteSpace(_targetEntitySqlModel.Dbsh.PrimarySource))
            {
                if (_sourceGraph != null)
                {
                    PrimarySource = _sourceGraph.Entities.FirstOrDefault(x => x.Match(_targetEntitySqlModel.Dbsh.PrimarySource));
                    if (PrimarySource == null)
                    {
                        throw new Exception($"DBSH-00216 Primary source {_targetEntitySqlModel.Dbsh.PrimarySource} for target {_targetEntitySqlModel.TargetTable} not found");
                    }
                }
            }
            else
            {
                foreach (var entity in _sourceGraph.Entities)
                {
                    var keyColumns = entity.KeyColumns;
                    keyColumns = keyColumns.Where(x => x.Entities.Count == 1).ToList();
                    if (!keyColumns.Any()) continue;
                    if (_targetEntitySqlModel.KeySourceColumns.Any(x => keyColumns.Any(y => y.Alias == x.Alias)))
                    {
                        PrimarySource = entity;
                        // primary source is found
                        return;
                    }
                }
            }
        }

        private void DetectUnusedEntities()
        {
            for (;;)
            {
                RebuildEntityList();

                var removable = new List<SourceEntitySqlModel>();
                foreach (var ent in Entities)
                {
                    if (PrimarySource != null && ent.SqlAlias == PrimarySource.SqlAlias)
                    {
                        continue;
                    }

                    if (PrimarySource != null)
                    {
                        if (ent.Columns.Any(x => _targetEntitySqlModel.RequiredSourceColumns.Any(y => y.Alias == x.Alias && x.Entities.Count < 2)))
                        {
                            // entity contains any needed columns, which is not present in other entity
                            continue;
                        }
                    }
                    else
                    {
                        if (ent.Columns.Any(x => _targetEntitySqlModel.RequiredSourceColumns.Any(y => y.Alias == x.Alias)))
                        {
                            // entity contains any needed columns
                            continue;
                        }
                    }

                    var keycols = ent.Columns.Where(x => x.Entities.Count >= 2).ToList();
                    if (keycols.Count > 1)
                    {
                        continue;
                    }

                    //if (keycols.Count == 1)
                    //{
                    //    if (keycols[0].Entities.Count > 2)
                    //    {
                    //        continue;
                    //    }
                    //}

                    removable.Add(ent);
                }

                if (!removable.Any()) break;

                var removed = removable.First();
                _entityQueue.RemoveAll(x => x.SqlAlias == removed.SqlAlias);
            }
        }

        private bool EntityHasKey(SourceEntitySqlModel entity)
        {
            return _targetEntitySqlModel.KeySourceColumns.Any(x => entity.Columns.Any(y => y.Alias == x.Alias));
            //return _targetEntitySqlModel.TargetColumns.Where(x => x.IsKey).Any(x => x.Sources.Any(y => entity.Columns.Any(z => z.Alias == y.Alias)));

        }

        private SourceEntitySqlModel FindEntityFromQueue()
        {
            SourceEntitySqlModel res = null;

            if (PrimarySource != null) res = _entityQueue.FirstOrDefault(x => x.SqlAlias == PrimarySource.SqlAlias);
            if (res != null) return res;
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
            if (res == null)
            {
                throw new Exception("DBSH-00000 Internal error - PopEntityFromQueue() = null");
            }
            _entityQueue.Remove(res);
            return res;
        }

        private void RebuildEntityList()
        {
            Entities.Clear();
            Columns.Clear();
            _entityQueue.ForEach(AddEntity);
        }

        private void AddEntity(SourceEntitySqlModel sourceEntity)
        {
            var src = new SourceEntitySqlModel(sourceEntity.Dbsh, _sourceGraph.DataSync);
            Entities.Add(src);
            src.SqlAlias = sourceEntity.SqlAlias;
            src.QuerySource = sourceEntity.QuerySource;
            src.TableName = sourceEntity.TableName;
            src.IsExternal = sourceEntity.IsExternal;
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
                Columns[alias].FilterType = colItem.FilterType;
                if (!String.IsNullOrEmpty(colItem.Filter))
                {
                    Columns[alias].Filters.Add(colItem.Filter);
                }
                src.Columns.Add(Columns[alias]);
            }
        }

        public override string ToString()
        {
            return Entities.Select(x => $"{x.TableName} {x.SqlAlias}").CreateDelimitedText(",");
        }
    }
}
