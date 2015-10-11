using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.DmlFramework;

namespace DbShell.RelatedDataSync.SqlModel
{
    public class TargetColumnSqlModel
    {
        public string Name;

        public List<SourceColumnSqlModel> Sources = new List<SourceColumnSqlModel>();
        private TargetColumn _dbsh;

        public TargetColumnSqlModel(TargetColumn dbsh)
        {
            _dbsh = dbsh;
            Name = dbsh.Name;
        }

        public DmlfExpression CreateSourceExpression(SourceJoinSqlModel sourceJoinModel)
        {
            switch (_dbsh.RealValueType)
            {
                case TargetColumnValueType.Source:
                    var entity = sourceJoinModel[_dbsh.SourceName].Entities.First();
                    return new DmlfColumnRefExpression
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
            }
            throw new Exception("DBSH-00000 Cannot create expression");
        }

        public bool IsKey
        {
            get { return _dbsh.IsKey; }
        }
    }
}
