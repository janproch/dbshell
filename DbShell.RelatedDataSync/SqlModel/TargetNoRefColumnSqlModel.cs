using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.DmlFramework;

namespace DbShell.RelatedDataSync.SqlModel
{
    public class TargetNoRefColumnSqlModel : TargetColumnSqlModelBase
    {
        //public List<SourceColumnSqlModel> Sources = new List<SourceColumnSqlModel>();

        private TargetColumn _dbsh;

        public TargetNoRefColumnSqlModel(TargetColumn dbsh)
        {
            _dbsh = dbsh;
        }

        public override bool IsKey => _dbsh.IsKey;
        public override string Name => _dbsh.Name;

        private DmlfExpression CreateAggregate(DmlfExpression expr)
        {
            var res = new DmlfFuncCallExpression
            {
                FuncName = "MAX",
            };
            res.Arguments.Add(expr);
            return res;
        }

        public override DmlfExpression CreateSourceExpression(SourceJoinSqlModel sourceJoinModel, bool aggregate)
        {
            switch (_dbsh.RealValueType)
            {
                case TargetColumnValueType.Source:
                    var entity = sourceJoinModel[_dbsh.SourceName].Entities.First();
                    var res = new DmlfColumnRefExpression
                    {
                        Column = new DmlfColumnRef
                        {
                            ColumnName = entity.GetColumnName(sourceJoinModel[_dbsh.SourceName].Alias),
                            Source = new DmlfSource
                            {
                                Alias = entity.SqlAlias,
                            }
                        }
                    };
                    if (aggregate) return CreateAggregate(res);
                    return res;
            }
            throw new Exception("DBSH-00000 Cannot create expression");
        }
    }
}
