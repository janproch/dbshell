using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Antlr.Runtime;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.DmlFramework;

namespace DbShell.Driver.Common.FilterParser
{
    public class FilterParser
    {
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

        public static DmlfConditionBase ParseFilterExpression(DbTypeBase type, DmlfExpression columnValue, string expression)
        {
            switch (GetExpressionType(type))
            {
                case ExpressionType.Number:
                    return ParseNumber(columnValue, expression);
                case ExpressionType.String:
                    return ParseString(columnValue, expression);
            }
            return new DmlfEqualCondition
            {
                LeftExpr = columnValue,
                RightExpr = new DmlfStringExpression { Value = expression },
            };
        }
    }
}
