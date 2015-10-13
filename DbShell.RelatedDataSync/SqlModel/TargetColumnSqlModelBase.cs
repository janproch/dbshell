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
    }
}
