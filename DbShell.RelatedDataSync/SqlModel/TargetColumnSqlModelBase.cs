using DbShell.Driver.Common.DmlFramework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.RelatedDataSync.SqlModel
{
    public abstract class TargetColumnSqlModelBase
    {
        public abstract DmlfExpression CreateSourceExpression(SourceJoinSqlModel sourceJoinModel, bool aggregate);
        public abstract string Name { get; }
        public abstract bool IsKey { get; }
        public virtual bool IsRestriction => false;
        public virtual bool Update => true;
        public virtual bool Insert => true;
        public virtual bool Compare => true;

        public DmlfExpression CreateTargetExpression(DmlfSource targetSource)
        {
            return new DmlfColumnRefExpression
            {
                Column = new DmlfColumnRef
                {
                    Source = targetSource,
                    ColumnName = Name,
                }
            };
        }

        public DmlfExpression CreateTargetExpression(string targetEntityAlias)
        {
            return CreateTargetExpression(new DmlfSource { Alias = targetEntityAlias });
        }
    }
}
