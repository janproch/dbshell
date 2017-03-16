using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.DmlFramework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DbShell.Driver.Common.Utility
{
    public enum FilterLineTransformation
    {
        IsOneOf,
        IsNotOneOf,
        BeginsWithOneOf,
        EndsWithOneOf,
        ContainsOneOf,
        None
    }


    public interface IFilterParserCore
    {
        DmlfConditionBase ParseFilterExpression(FilterParserTool.ExpressionType type, DmlfExpression columnValue, string expression, ParserOptions options);
        ObjectFilterConditionBase ParseObjectFilter(string expression);
    }

    public class ParserOptions
    {
        public string CollateSpec;
    }

    public static class FilterParserTool
    {
        public static IFilterParserCore ParserCore;

        public const string LineTransformPrefix = "$LINE_TRANSFORM$=";

        public enum ExpressionType
        {
            None,
            Number,
            String,
            DateTime,
            Logical,
        };

        public static ExpressionType GetExpressionType(DbTypeBase type)
        {
            if (type != null)
            {
                switch (type.Code)
                {
                    case DbTypeCode.Int:
                    case DbTypeCode.Numeric:
                    case DbTypeCode.Float:
                        return ExpressionType.Number;
                    case DbTypeCode.Text:
                    case DbTypeCode.String:
                    case DbTypeCode.Guid:
                        return ExpressionType.String;
                    case DbTypeCode.Datetime:
                        return ExpressionType.DateTime;
                    case DbTypeCode.Logical:
                        return ExpressionType.Logical;
                }
            }
            return ExpressionType.None;
        }

        public static FilterLineTransformation GetExpressionTransformation(string expression)
        {
            if (expression != null && expression.StartsWith(LineTransformPrefix))
            {
                string[] exprs = expression.Split(new char[] { '\n' }, 2);
                string tran = exprs[0].Trim().Substring(LineTransformPrefix.Length);
                return (FilterLineTransformation)Enum.Parse(typeof(FilterLineTransformation), tran);
            }
            return FilterLineTransformation.None;
        }

        public static DmlfConditionBase ParseFilterExpression(DbTypeBase type, DmlfExpression columnValue, string expression, ParserOptions options = null)
        {
            return ParseFilterExpression(GetExpressionType(type), columnValue, expression, options);
        }

        private static void WantParserCore()
        {
            if (ParserCore == null) throw new Exception("DBSH-00000 FilterParser corenot initialized");
        }

        public static DmlfConditionBase ParseFilterExpression(ExpressionType type, DmlfExpression columnValue, string expression, ParserOptions options = null)
        {
            WantParserCore();

            if (expression == null) return null;
            expression = TransformExpression(expression);
            var res = ParserCore.ParseFilterExpression(type, columnValue, expression, options);
            if (res != null) res = res.SimplifyCondition();
            return res;
        }

        private static string TransformExpression(string expression)
        {
            var tran = GetExpressionTransformation(expression);
            switch (tran)
            {
                case FilterLineTransformation.IsOneOf:
                    return TrasnformLines(expression, line => String.Format("='{0}'", line));
                case FilterLineTransformation.IsNotOneOf:
                    return TrasnformLines(expression, line => String.Format("<>'{0}'", line), true);
                case FilterLineTransformation.ContainsOneOf:
                    return TrasnformLines(expression, line => String.Format("'{0}'", line));
                case FilterLineTransformation.BeginsWithOneOf:
                    return TrasnformLines(expression, line => String.Format("^'{0}'", line));
                case FilterLineTransformation.EndsWithOneOf:
                    return TrasnformLines(expression, line => String.Format("$'{0}'", line));
            }
            return expression;
        }

        private static string TrasnformLines(string expression, Func<string, string> func, bool singleLine = false)
        {
            var sb = new StringBuilder();
            bool first = true;
            foreach (string line in expression.Split('\n'))
            {
                if (String.IsNullOrWhiteSpace(line)) continue;
                string item = func(line.Trim());
                if (!first)
                {
                    if (singleLine)
                    {
                        sb.Append(item + " ");
                    }
                    else
                    {
                        sb.AppendLine(item);
                    }
                }
                first = false;
            }
            return sb.ToString();
        }

        public static string GetTrasformExpression(FilterLineTransformation tran, string lines)
        {
            return LineTransformPrefix + tran.ToString() + "\n" + lines;
        }

        public static string GetValueTestExpression(object value, string dateResolution = null)
        {
            if (value != null)
            {
                if (value is DateTime)
                {
                    if (dateResolution == "day")
                    {
                        return ((DateTime)value).ToString("yyyy-MM-dd", CultureInfo.InvariantCulture);
                    }
                    return StringTool.DateTimeToStringExact((DateTime)value);
                }
                if (value is bool)
                {
                    return (bool)value ? "TRUE" : "FALSE";
                }
                return "=\"" + value.ToString() + "\"";
            }
            return "NULL";
        }

        public static ObjectFilterConditionBase ParseObjectFilter(string expression)
        {
            WantParserCore();

            return ParserCore.ParseObjectFilter(expression);
        }

    }
}
