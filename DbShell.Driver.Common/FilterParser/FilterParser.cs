﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Antlr.Runtime;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.DmlFramework;

namespace DbShell.Driver.Common.FilterParser
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

    public class FilterParser
    {
        public const string LineTransformPrefix = "$LINE_TRANSFORM$=";

        public enum ExpressionType
        {
            Number,
            String,
            DateTime,
            None,
        };

        private static DmlfConditionBase ParseNumber(DmlfExpression columnValue, string expression)
        {
            var lexer = new NumberFilterLexer(new ANTLRReaderStream(new StringReader(expression)));
            var tokens = new CommonTokenStream(lexer);
            var parser = new NumberFilterParser(tokens);
            parser.ColumnValue = columnValue;
            try
            {
                parser.expr();
            }
            catch
            {
                return null;
            }
            if (parser.Errors != null) return null;
            return parser.Condition;
        }

        private static DmlfConditionBase ParseString(DmlfExpression columnValue, string expression)
        {
            var lexer = new StringFilterLexer(new ANTLRReaderStream(new StringReader(expression)));
            var tokens = new CommonTokenStream(lexer);
            var parser = new StringFilterParser(tokens);
            parser.ColumnValue = columnValue;
            try
            {
                parser.expr();
            }
            catch
            {
                return null;
            }
            if (parser.Errors != null) return null;
            return parser.Condition;
        }

        private static DmlfConditionBase ParseDateTime(DmlfExpression columnValue, string expression)
        {
            var lexer = new DateTimeFilterLexer(new ANTLRReaderStream(new StringReader(expression)));
            var tokens = new CommonTokenStream(lexer);
            var parser = new DateTimeFilterParser(tokens);
            parser.ColumnValue = columnValue;
            try
            {
                parser.expr();
            }
            catch
            {
                return null;
            }
            if (parser.Errors != null) return null;
            return parser.Condition;
        }

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
                }
            }
            return ExpressionType.None;
        }

        public static FilterLineTransformation GetExpressionTransformation(string expression)
        {
            if (expression != null && expression.StartsWith(LineTransformPrefix))
            {
                string[] exprs = expression.Split(new char[] {'\n'}, 2);
                string tran = exprs[0].Trim().Substring(LineTransformPrefix.Length);
                return (FilterLineTransformation) Enum.Parse(typeof (FilterLineTransformation), tran);
            }
            return FilterLineTransformation.None;
        }

        public static DmlfConditionBase ParseFilterExpression(DbTypeBase type, DmlfExpression columnValue, string expression)
        {
            expression = TransformExpression(expression);

            switch (GetExpressionType(type))
            {
                case ExpressionType.Number:
                    return ParseNumber(columnValue, expression);
                case ExpressionType.String:
                    return ParseString(columnValue, expression);
                case ExpressionType.DateTime:
                    return ParseDateTime(columnValue, expression);
            }
            return new DmlfEqualCondition
            {
                LeftExpr = columnValue,
                RightExpr = new DmlfStringExpression { Value = expression },
            };
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
    }
}
