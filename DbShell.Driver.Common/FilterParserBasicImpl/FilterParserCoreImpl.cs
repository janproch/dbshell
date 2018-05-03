using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.DmlFramework;

namespace DbShell.Driver.Common.FilterParserBasicImpl
{
    public static class FilterParserCoreImpl
    {
        public static DmlfConditionBase ParseFilterExpression(FilterParserType type, DmlfExpression columnValue, string expression, ParserOptions options)
        {
            var opts = new FilterParseOptions();
            switch (type)
            {
                case FilterParserType.String:
                    opts.ParseString = true;
                    break;
                case FilterParserType.Number:
                    opts.ParseNumber = true;
                    break;
                case FilterParserType.DateTime:
                    opts.ParseTime = true;
                    break;
                case FilterParserType.Logical:
                    opts.ParseLogical = true;
                    break;
                default:
                    throw new Exception("DBSH-00000 Unexpected filter parser type:" + type);
            }
            var parser = new DmlfFilterParser(expression, columnValue, opts);
            parser.Run();
            return parser.Result;
        }

        public static ObjectFilterConditionBase ParseObjectFilter(string expression)
        {
            var parser = new ObjectFilterParser(expression);
            parser.Run();
            return parser.Result;
        }
    }
}
