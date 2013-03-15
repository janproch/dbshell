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

        public static DmlfConditionBase ParseFilterExpression(DbTypeBase type, DmlfExpression columnValue, string expression)
        {
            if (type != null)
            {
                switch (type.Code)
                {
                    case DbTypeCode.Int:
                    case DbTypeCode.Numeric:
                    case DbTypeCode.Float:
                        return ParseNumber(columnValue, expression);
                }
            }
            return new DmlfEqualCondition
            {
                LeftExpr = columnValue,
                RightExpr = new DmlfStringExpression { Value = expression },
            };
        }
    }
}
