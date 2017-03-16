using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using Antlr.Runtime;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.DmlFramework;
using DbShell.Driver.Common.Utility;

namespace DbShell.FilterParser.Antlr
{
    public class FilterParserAntlrCore : IFilterParserCore
    {
        private static DmlfConditionBase ParseNumber(DmlfExpression columnValue, string expression, Action<DbShellFilterAntlrParser> initParser = null)
        {
            var lexer = new NumberFilterLexer(new ANTLRReaderStream(new StringReader(expression)));
            var tokens = new CommonTokenStream(lexer);
            var parser = new NumberFilterParser(tokens);
            if (initParser != null) initParser(parser);
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

        private static DmlfConditionBase ParseString(DmlfExpression columnValue, string expression, Action<DbShellFilterAntlrParser> initParser = null)
        {
            var lexer = new StringFilterLexer(new ANTLRReaderStream(new StringReader(expression)));
            var tokens = new CommonTokenStream(lexer);
            var parser = new StringFilterParser(tokens);
            if (initParser != null) initParser(parser);
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

        private static DmlfConditionBase ParseDateTime(DmlfExpression columnValue, string expression, Action<DbShellFilterAntlrParser> initParser = null)
        {
            var lexer = new DateTimeFilterLexer(new ANTLRReaderStream(new StringReader(expression)));
            var tokens = new CommonTokenStream(lexer);
            var parser = new DateTimeFilterParser(tokens);
            if (initParser != null) initParser(parser);
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

        private static DmlfConditionBase ParseLogical(DmlfExpression columnValue, string expression, Action<DbShellFilterAntlrParser> initParser = null)
        {
            var lexer = new LogicalFilterLexer(new ANTLRReaderStream(new StringReader(expression)));
            var tokens = new CommonTokenStream(lexer);
            var parser = new LogicalFilterParser(tokens);
            if (initParser != null) initParser(parser);
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


        public DmlfConditionBase ParseFilterExpression(FilterParserTool.ExpressionType type, DmlfExpression columnValue, string expression, ParserOptions options)
        {
            Action<DbShellFilterAntlrParser> initParser = null;

            if (options?.CollateSpec != null) initParser = x => x.CollateSpec = options?.CollateSpec;

            switch (type)
            {
                case FilterParserTool.ExpressionType.Number:
                    return ParseNumber(columnValue, expression);
                case FilterParserTool.ExpressionType.String:
                    return ParseString(columnValue, expression);
                case FilterParserTool.ExpressionType.DateTime:
                    return ParseDateTime(columnValue, expression);
                case FilterParserTool.ExpressionType.Logical:
                    return ParseLogical(columnValue, expression);
            }
            return new DmlfEqualCondition
                {
                    LeftExpr = columnValue,
                    RightExpr = new DmlfStringExpression {Value = expression},
                };
        }

        public ObjectFilterConditionBase ParseObjectFilter(string expression)
        {
            var lexer = new ObjectFilterLexer(new ANTLRReaderStream(new StringReader(expression)));
            var tokens = new CommonTokenStream(lexer);
            var parser = new ObjectFilterParser(tokens);
            try
            {
                parser.expr();
            }
            catch
            {
                return null;
            }
            return parser.Condition;
        }

        public static void Initialize()
        {
            FilterParserTool.ParserCore = new FilterParserAntlrCore();
        }
    }
}
