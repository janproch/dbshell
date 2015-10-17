using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.DmlFramework;

namespace DbShell.RelatedDataSync.SqlModel
{
    public class TargetRefColumnSqlModel : TargetColumnSqlModelBase
    {
        private TargetReference _fk;
        private TargetReferenceColumn _col;
        private TargetEntitySqlModel _targetSqlModel;

        public TargetRefColumnSqlModel(TargetReference fk, TargetReferenceColumn col, TargetEntitySqlModel targetSqlModel)
        {
            _col = col;
            _fk = fk;
            _targetSqlModel = targetSqlModel;
        }

        public override bool IsKey => _fk.IsKey;
        public override string Name => _col.BaseName;
        public override bool Update => _fk.Update;
        public override bool Insert => _fk.Insert;
        public override bool Compare => _fk.Compare;

        public override DmlfExpression CreateSourceExpression(SourceJoinSqlModel sourceJoinModel, bool aggregate)
        {
            return new DmlfColumnRefExpression
            {
                Column = new DmlfColumnRef
                {
                    ColumnName = _col.RefName,
                    Source = _targetSqlModel.GetRefSource(sourceJoinModel.SourceToRefsJoin, sourceJoinModel),
                }
            };
        }
    }
}
