using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.DmlFramework;

namespace DbShell.Driver.Common.FilterParser
{
    public class FilterParser
    {
        protected readonly FilterTokenizer Tokenizer;
        protected readonly DmlfExpression ColumnValue;
        protected readonly string Expression;

        public FilterParser(string expression, DmlfExpression columnValue, FilterTokenizer tokenizer)
        {
            Tokenizer = tokenizer;
            ColumnValue = columnValue;
            Expression = expression;
        }

        public static DmlfConditionBase ParseFilterExpression(DbTypeBase type, DmlfExpression columnValue, string expression)
        {
            FilterParser parser = null;
            if (type != null)
            {
                switch (type.Code)
                {
                    case DbTypeCode.Int:
                        parser = new NumberFilterParser(expression, columnValue, false);
                        break;
                }
            }
            if (parser == null) parser = new FilterParser(expression, columnValue, FilterTokenizer.Mode.None);
            return parser.Parse();
        }

        public virtual DmlfConditionBase Parse()
        {
            return new DmlfEqualCondition
            {
                LeftExpr = ColumnValue,
                RightExpr = new DmlfStringExpression { Value = Expression },
            };
        }
    }
}
