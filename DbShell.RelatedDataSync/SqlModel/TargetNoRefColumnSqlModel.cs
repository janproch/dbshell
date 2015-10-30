using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.DmlFramework;
using System.Text.RegularExpressions;

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
        public override bool IsRestriction => _dbsh.IsRestriction;
        public override string Name => _dbsh.Name;
        public override bool Update => _dbsh.Update;
        public override bool Insert => _dbsh.Insert;
        public override bool Compare => _dbsh.Compare;

        public override DmlfExpression CreateSourceExpression(SourceJoinSqlModel sourceJoinModel, bool aggregate)
        {
            switch (_dbsh.RealValueType)
            {
                case TargetColumnValueType.Source:
                    var entity = sourceJoinModel[_dbsh.Source].Entities.First();
                    return
                        GetExprOrAggregate(new DmlfColumnRefExpression
                        {
                            Column = new DmlfColumnRef
                            {
                                ColumnName = entity.GetColumnName(sourceJoinModel[_dbsh.Source].Alias),
                                Source = entity.QuerySource,
                            }
                        }, aggregate);
                case TargetColumnValueType.Value:
                    return new DmlfLiteralExpression
                    {
                        Value = _dbsh.Value,
                    };
                case TargetColumnValueType.Expression:
                    if (Regex.Match(_dbsh.Expression, TargetEntitySqlModel.ExpressionColumnRegex).Success)
                    {
                        string expr = Regex.Replace(
                            _dbsh.Expression, 
                            TargetEntitySqlModel.ExpressionColumnRegex, 
                            m => GetColumnExpression(sourceJoinModel, m.Groups[1].Value, aggregate));

                        return new DmlfSqlValueExpression
                        {
                            Value = expr,
                        };

                        //return GetExprOrAggregate(new DmlfSqlValueExpression
                        //{
                        //    Value = expr,
                        //}, aggregate);
                    }
                    else
                    {
                        return new DmlfSqlValueExpression
                        {
                            Value = _dbsh.Expression,
                        };
                    }
                case TargetColumnValueType.Special:
                    switch (_dbsh.SpecialValue)
                    {
                        case TargetColumnSpecialValue.Null:
                            return new DmlfLiteralExpression
                            {
                                Value = null,
                            };
                        case TargetColumnSpecialValue.CurrentDateTime:
                            return new DmlfFuncCallExpression
                            {
                                FuncName = "GETDATE",
                            };
                        case TargetColumnSpecialValue.CurrentDate:
                            return new DmlfSqlValueExpression
                            {
                                Value = "DATEADD(dd, 0, DATEDIFF(dd, 0, GETDATE()))",
                            };
                        case TargetColumnSpecialValue.CurrentUtcDateTime:
                            return new DmlfFuncCallExpression
                            {
                                FuncName = "GETUTCDATE",
                            };
                        case TargetColumnSpecialValue.CurrentUtcDate:
                            return new DmlfSqlValueExpression
                            {
                                Value = "DATEADD(dd, 0, DATEDIFF(dd, 0, GETUTCDATE()))",
                            };
                        case TargetColumnSpecialValue.NewGUID:
                            return new DmlfFuncCallExpression
                            {
                                FuncName = "NEWID",
                            };
                        case TargetColumnSpecialValue.ImportDateTime:
                            {
                                return SqlScriptCompiler.ImportDateTimeExpression;
                            }
                        case TargetColumnSpecialValue.ImportDate:
                            return new DmlfSqlValueExpression
                            {
                                Value = SqlScriptCompiler.ImportDateVariableName,
                            };
                    }
                    break;

            }
            throw new Exception("DBSH-00221 Cannot create expression");
        }

        private string GetColumnExpression(SourceJoinSqlModel sourceJoinModel, string colname, bool aggregate)
        {
            var entity = sourceJoinModel[colname].Entities.First();
            string res = $"[{entity.SqlAlias}].[{entity.GetColumnName(sourceJoinModel[colname].Alias)}]";
            if (aggregate) res = $"MAX({res})";
            return res;
        }
    }
}
