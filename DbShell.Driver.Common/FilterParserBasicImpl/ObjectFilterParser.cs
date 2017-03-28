using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Driver.Common.FilterParserBasicImpl
{
    public class ObjectFilterParser : ParserBase<ObjectFilterConditionBase>
    {
        public ObjectFilterParser(string expression)
            : base(expression)
        {
            _options = new FilterParseOptions
            {
                ParseObject = true,
            };
        }

        protected override ObjectFilterConditionBase ParseBody() => ParseList();

        private ObjectFilterConditionBase ParseList()
        {
            var res = new ObjectFilterOrCondition();
            while (!EndOfInput && !IsError)
            {
                res.Conditions.Add(ParseFactor());
                if (CurrentToken?.TokenType == FilterTokenType.COMMA)
                {
                    Next();
                    continue;
                }
                if (EndOfInput) break;
                IsError = true;
                break;
            }
            return res;
        }

        private ObjectFilterConditionBase ParseFactor()
        {
            var res = new ObjectFilterAndCondition();
            while (!EndOfInput && !IsError && CurrentToken?.TokenType != FilterTokenType.COMMA)
            {
                res.Conditions.Add(ParseElement());
            }
            return res;
        }

        private ObjectFilterConditionBase Negate(ObjectFilterConditionBase condition)
        {
            return new ObjectFilterNotCondition { Condition = condition };
        }

        private ObjectFilterConditionBase ParseElement()
        {
            var context = ObjectFilterContextEnum.Name;

            if (CurrentToken?.TokenType == FilterTokenType.OBJECT_CONTEXT)
            {
                switch (CurrentToken?.Data)
                {
                    case "@":
                        context = ObjectFilterContextEnum.Schema;
                        break;
                    case "#":
                        context = ObjectFilterContextEnum.Content;
                        break;
                }
                Next();
            }

            string opname = "+";

            if (CurrentToken?.TokenType == FilterTokenType.OPERATOR)
            {
                opname = CurrentToken?.Data;
                Next();
            }

            if (CurrentToken?.TokenType != FilterTokenType.STRING)
            {
                IsError = true;
                return null;
            }

            string filter = CurrentToken?.Data;
            Next();

            switch (opname)
            {
                case "+":
                    return new ObjectFilterContainsTextCondition
                    {
                        Context = context,
                        Filter = filter,
                    };
                case "~":
                    return Negate(new ObjectFilterContainsTextCondition
                    {
                        Context = context,
                        Filter = filter,
                    });
                case "^":
                    return new ObjectFilterStartsWithCondition
                    {
                        Context = context,
                        Filter = filter,
                    };
                case "!^":
                    return Negate(new ObjectFilterStartsWithCondition
                    {
                        Context = context,
                        Filter = filter,
                    });
                case "$":
                    return new ObjectFilterEndsWithCondition
                    {
                        Context = context,
                        Filter = filter,
                    };
                case "!$":
                    return Negate(new ObjectFilterEndsWithCondition
                    {
                        Context = context,
                        Filter = filter,
                    });
                case "=":
                    return new ObjectFilterEqualsCondition
                    {
                        Context = context,
                        Filter = filter,
                    };
                case "<>":
                    return Negate(new ObjectFilterEqualsCondition
                    {
                        Context = context,
                        Filter = filter,
                    });
            }
            return null;
        }
    }
}
