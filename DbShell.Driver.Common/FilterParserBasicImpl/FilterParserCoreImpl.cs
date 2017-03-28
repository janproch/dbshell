using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.DmlFramework;

namespace DbShell.Driver.Common.FilterParserBasicImpl
{
    public class FilterParserCoreImpl : IFilterParserCore
    {
        public DmlfConditionBase ParseFilterExpression(FilterParserTool.ExpressionType type, DmlfExpression columnValue, string expression, ParserOptions options)
        {
            var opts = new FilterParseOptions();
            switch (type)
            {
                case FilterParserTool.ExpressionType.String:
                    opts.ParseString = true;
                    break;
                case FilterParserTool.ExpressionType.Number:
                    opts.ParseNumber = true;
                    break;
                case FilterParserTool.ExpressionType.DateTime:
                    opts.ParseTime = true;
                    break;
                case FilterParserTool.ExpressionType.Logical:
                    opts.ParseLogical = true;
                    break;
            }
            var parser = new FilterParser(expression, columnValue, opts);
            parser.Run();
            return parser.Result;
        }

        public ObjectFilterConditionBase ParseObjectFilter(string expression)
        {
            throw new NotImplementedException();
        }
    }
}
