using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.DmlFramework;
using DbShell.Driver.Common.FilterParserBasicImpl;
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

    public enum FilterParserType
    {
        None,
        Number,
        String,
        DateTime,
        Logical,
        Object,
    };

    //public interface IFilterParserCore
    //{
    //    DmlfConditionBase ParseFilterExpression(FilterParserTool.ExpressionType type, DmlfExpression columnValue, string expression, ParserOptions options);
    //    ObjectFilterConditionBase ParseObjectFilter(string expression);
    //}

    public class ParserOptions
    {
        public string CollateSpec;
    }

    public static class FilterParserTool
    {
        public const string LineTransformPrefix = "$LINE_TRANSFORM$=";

        public static FilterParserType GetExpressionType(DbTypeBase type)
        {
            if (type != null)
            {
                switch (type.Code)
                {
                    case DbTypeCode.Int:
                    case DbTypeCode.Numeric:
                    case DbTypeCode.Float:
                        return FilterParserType.Number;
                    case DbTypeCode.Text:
                    case DbTypeCode.String:
                    case DbTypeCode.Guid:
                    case DbTypeCode.Generic:
                        return FilterParserType.String;
                    case DbTypeCode.Datetime:
                        return FilterParserType.DateTime;
                    case DbTypeCode.Logical:
                        return FilterParserType.Logical;
                }
            }
            return FilterParserType.None;
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

        public static DmlfConditionBase ParseFilterExpression(FilterParserType type, DmlfExpression columnValue, string expression, ParserOptions options = null)
        {
            if (expression == null) return null;
            expression = TransformExpression(expression);
            var res = FilterParserCoreImpl.ParseFilterExpression(type, columnValue, expression, options);
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
            return FilterParserCoreImpl.ParseObjectFilter(expression);
        }

    }
}
