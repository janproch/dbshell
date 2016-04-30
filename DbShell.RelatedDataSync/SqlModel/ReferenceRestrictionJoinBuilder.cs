using DbShell.Driver.Common.DmlFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.RelatedDataSync.SqlModel
{
    public class ReferenceRestrictionJoinBuilder
    {
        public class QueueItem
        {
            public string BaseAlias;
            public string RefAlias;

            public TargetEntitySqlModel BaseEntity;
            public TargetEntitySqlModel RefEntity;

            public TargetReference Fk;
        }

        private List<QueueItem> _queue = new List<QueueItem>();

        public void FindReferences(TargetEntitySqlModel entity, string baseAlias)
        {
            foreach (var fkPair in entity.RefEntities)
            {
                if (!fkPair.Key.IsRestriction) continue;

                string refAlias = "refrestr_" + _queue.Count;

                _queue.Add(new QueueItem
                {
                    Fk = fkPair.Key,
                    BaseEntity = entity,
                    RefEntity = fkPair.Value,
                    BaseAlias = baseAlias,
                    RefAlias = refAlias,
                });

                if (_queue.Any(x => x.BaseEntity == fkPair.Value)) throw new Exception("DBSH-00000 cycle in references");
                FindReferences(fkPair.Value, refAlias);
            }
        }

        public void AddReferenceJoins(DmlfCommandBase command)
        {
            foreach (var qitem in _queue)
            {
                var relation = new DmlfRelation
                {
                    JoinType = DmlfJoinType.Inner,
                    Reference = new DmlfSource
                    {
                        Alias = qitem.RefAlias,
                        TableOrView = qitem.RefEntity.TargetTable,
                    },
                };

                foreach (var col in qitem.BaseEntity.TargetColumns)
                {
                    if (col.UnderlyingReference != qitem.Fk) continue;

                    var refColumn = new DmlfColumnRefExpression
                    {
                        Column = new DmlfColumnRef
                        {
                            Source = new DmlfSource { Alias = qitem.RefAlias },
                            ColumnName = col.RefColumnName,
                        }
                    };

                    relation.Conditions.Add(new DmlfEqualCondition
                    {
                        LeftExpr = col.CreateTargetExpression(qitem.BaseAlias),
                        RightExpr = refColumn,
                        CollateSpec = col.UseCollate(qitem.BaseEntity.SourceJoinModel) ? "DATABASE_DEFAULT" : null,
                    });
                }

                command.SingleFrom.Relations.Add(relation);

                qitem.RefEntity.CreateLifetimeConditions(command, qitem.RefAlias);
                qitem.RefEntity.CreateRestrictionCondition(command, qitem.RefAlias, false);
            }
        }
    }
}
