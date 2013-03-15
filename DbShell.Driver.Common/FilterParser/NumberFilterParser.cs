using DbShell.Driver.Common.DmlFramework;

namespace DbShell.Driver.Common.FilterParser
{
    public class NumberFilterParser : FilterParser
    {
        private static string[] _numberOperators = {"=", "<", ">", "-", "<>", "!-", ">=", "<="};

        public NumberFilterParser(string expression, DmlfExpression columnValue, bool allowDecimals)
            : base(expression, columnValue, new FilterTokenizer(expression, allowDecimals, _numberOperators))
        {
        }

        public override DmlfConditionBase Parse()
        {
            return ParseList();
        }

        private DmlfConditionBase ParseList()
        {
            var res = new DmlfOrCondition();
            res.Conditions.Add(ParseFactor());
            while (Tokenizer.Current == FilterTokenizer.Token.Comma)
            {
                Tokenizer.NextToken();
                res.Conditions.Add(ParseFactor());
            }
            return res;
        }

        private DmlfConditionBase ParseFactor()
        {
            return null;
            //if (Tokenizer.IsOperator("-") .Current == FilterTokenizer.Token.Number)
        }
    }
}
