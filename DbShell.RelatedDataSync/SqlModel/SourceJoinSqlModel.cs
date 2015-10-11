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

            var queue = new List<SourceEntitySqlModel>(Entities);
            //queue.Add(_targetEntitySqlModel.KeySourceColumns.First().Entities.First());
            //foreach (var ent in _targetEntitySqlModel.RequiredSourceColumns.SelectMany(x => x.Entities))
            //{
            //    if (queue.Contains(ent)) continue;
            //    queue.Add(ent);
            //}

            var ent0 = queue.First();
            queue.RemoveAt(0);

            SourceJoin.Source = new DmlfSource
            {
                Alias = ent0.SqlAlias,
                TableOrView = ent0.TableName,
            };

            while (queue.Any())
            {
                // TODO - add items from queue
            }
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
