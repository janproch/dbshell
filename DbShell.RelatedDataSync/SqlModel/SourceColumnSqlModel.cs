using DbShell.Driver.Common.DmlFramework;
using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.RelatedDataSync.SqlModel
{
    public class SourceColumnSqlModel
    {
        public string Alias;

        public List<SourceEntitySqlModel> Entities = new List<SourceEntitySqlModel>();
        public List<SourceColumn> DbshColumns = new List<SourceColumn>();
        public List<string> Filters = new List<string>();
        public FilterParserTool.ExpressionType FilterType = FilterParserTool.ExpressionType.None;

        public DmlfConditionBase FilterCondition;

        public static FilterParserTool.ExpressionType DetectFilterType(FilterParserTool.ExpressionType type, IEnumerable<SourceColumn> columns)
        {
            if (type == FilterParserTool.ExpressionType.None)
            {
                string dataType = columns.Select(x => x.DataType).FirstOrDefault(x => !String.IsNullOrEmpty(x)) ?? "";
                dataType = dataType.ToLower();
                if (dataType.Contains("date") || dataType.Contains("time")) type = FilterParserTool.ExpressionType.DateTime;
                else if (dataType.Contains("int") || dataType.Contains("float") || dataType.Contains("num") || dataType.Contains("dec")) type = FilterParserTool.ExpressionType.Number;
                else if (dataType.Contains("bit") || dataType.Contains("bool") || dataType.Contains("log")) type = FilterParserTool.ExpressionType.Logical;
                else type = FilterParserTool.ExpressionType.String;
            }
            return type;
        }

        public void CompileFilter()
        {
            if (!Filters.Any()) return;

            var type = DetectFilterType(FilterType, DbshColumns);

            var entity = Entities.First();
            var expr = new DmlfColumnRefExpression
            {
                Column = new DmlfColumnRef
                {
                    ColumnName = entity.GetColumnName(Alias),
                    Source = entity.QuerySource,
                }
            };

            var andCondition = new DmlfAndCondition();

            foreach (var filter in Filters)
            {
                var cond = FilterParserTool.ParseFilterExpression(type, expr, filter);
                andCondition.Conditions.Add(cond);
            }

            if (andCondition.Conditions.Count == 1)
            {
                FilterCondition = andCondition.Conditions[0];
            }
            else
            {
                FilterCondition = andCondition;
            }
        }

        public static DmlfConditionBase CompileSingleFilter(SourceColumn column, string tableAlias)
        {
            var expr = new DmlfColumnRefExpression
            {
                Column = new DmlfColumnRef
                {
                    ColumnName = column.Name,
                    Source = new DmlfSource { Alias = tableAlias },
                }
            };

            var type = DetectFilterType(column.FilterType, new[] { column });
            var cond = FilterParserTool.ParseFilterExpression(type, expr, column.Filter);
            return cond;
        }
    }
}
