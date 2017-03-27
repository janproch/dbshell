using DbShell.Driver.Common.DmlFramework;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace DbShell.Driver.Common.FilterParserBasicImpl
{
    public class FilterParser
    {
        private string _expression;
        private FilterTokenizer _tokenizer;
        private HashSet<string> _keywords = new HashSet<string>();
        private DmlfExpression _columnValue;

        private List<FilterToken> _tokens;
        private int _currentTokenIndex;
        private FilterParseOptions _options;

        public DmlfConditionBase Result;
        public bool IsError;


        public FilterParser(string expression, DmlfExpression columnValue, FilterParseOptions options)
        {
            _expression = expression;
            _columnValue = columnValue;
            _options = options;

            _keywords.Add("NOT");
            _keywords.Add("NULL");

            if (_options.ParseString)
            {
                _keywords.Add("EMPTY");
            }
        }

        private bool EndOfInput => _currentTokenIndex >= _tokens.Count;

        private FilterToken CurrentToken => _currentTokenIndex >= _tokens.Count ? null : _tokens[_currentTokenIndex];
        private FilterToken NextToken => _currentTokenIndex + 1 >= _tokens.Count ? null : _tokens[_currentTokenIndex + 1];

        public void Run()
        {
            _tokenizer = new FilterTokenizer(_expression, _keywords, _options);
            _tokenizer.Run();
            _tokens = _tokenizer.Result;
            IsError = _tokenizer.IsError;
            Result = ParseList();
            if (IsError) Result = null;
        }

        private DmlfOrCondition ParseList()
        {
            var res = new DmlfOrCondition();
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

        private DmlfAndCondition ParseFactor()
        {
            var res = new DmlfAndCondition();
            while (!EndOfInput && !IsError && CurrentToken?.TokenType != FilterTokenType.COMMA)
            {
                res.Conditions.Add(ParseElement());
            }
            return res;
        }

        private bool TestKeywords(params string[] keywords)
        {
            for(int i = 0; i < keywords.Length; i++)
            {
                if (i + _currentTokenIndex >= _tokens.Count) return false;
                if (_tokens[i + _currentTokenIndex].TokenType != FilterTokenType.KEYWORD) return false;
                if (_tokens[i + _currentTokenIndex].Data != keywords[i]) return false;
            }
            Next(keywords.Length);
            return true;
        }

        private void Next(int count = 1)
        {
            _currentTokenIndex += count;
        }

        private bool TestOperator(string opname)
        {
            if (CurrentToken?.TokenType == FilterTokenType.OPERATOR && CurrentToken.Data == opname)
            {
                Next();
                return true;
            }
            return false;
        }

        private DmlfConditionBase Negate(DmlfConditionBase cond)
        {
            return new DmlfNotCondition
            {
                Expr = cond,
            };
        }

        private DmlfConditionBase ParseElement()
        {
            if (TestKeywords("NOT", "NULL")) return new DmlfIsNotNullCondition { Expr = _columnValue };
            if (TestKeywords("NULL")) return new DmlfIsNullCondition { Expr = _columnValue };
            if (TestKeywords("EMPTY"))
            {
                return new DmlfEqualCondition
                {
                    LeftExpr = new DmlfFuncCallExpression("LTRIM", new DmlfFuncCallExpression("RTRIM", _columnValue)),
                    RightExpr = new DmlfStringExpression { Value = "" }
                };
            }
            if (TestKeywords("NOT", "EMPTY"))
            {
                return new DmlfRelationCondition
                {
                    LeftExpr = new DmlfFuncCallExpression("LTRIM", new DmlfFuncCallExpression("RTRIM", _columnValue)),
                    RightExpr = new DmlfStringExpression { Value = "" },
                    Relation = "<>"
                };
            }

            DmlfConditionBase result;
            result = ParseStringElement();
            if (result != null) return result;
            result = ParseNumberElement();
            if (result != null) return result;

            IsError = true;
            return null;
        }

        private double ?ParseNumberCore(bool allowString = true)
        {
            if (CurrentToken?.TokenType == FilterTokenType.NUMBER)
            {
                double value = Double.Parse(CurrentToken.Data, CultureInfo.InvariantCulture);
                Next();
                return value;
            }
            if (CurrentToken?.TokenType == FilterTokenType.STRING && allowString)
            {
                double value = Double.Parse(CurrentToken.Data, CultureInfo.InvariantCulture);
                Next();
                return value;
            }
            return null;
        }

        private DmlfExpression ParseNumber()
        {
            if (CurrentToken?.TokenType == FilterTokenType.MINUS)
            {
                Next();
                double? value = ParseNumberCore();
                if (!value.HasValue)
                {
                    IsError = true;
                    return new DmlfLiteralExpression { Value = 0 };
                }
                return new DmlfLiteralExpression { Value = -value.Value };
            }
            {
                double? value = ParseNumberCore();
                if (value.HasValue)
                {
                    return new DmlfLiteralExpression { Value = value.Value };
                }
                return null;
            }
        }

        private bool IsNumberBeginning(FilterTokenType? type)
        {
            return type == FilterTokenType.STRING || type == FilterTokenType.NUMBER || type == FilterTokenType.MINUS;
        }

        private DmlfConditionBase ParseNumberElement()
        {
            if (!_options.ParseNumber) return null;

            if (CurrentToken?.TokenType == FilterTokenType.OPERATOR && IsNumberBeginning(NextToken?.TokenType))
            {
                string opname = CurrentToken.Data;
                Next();
                var number = ParseNumber();

                switch (opname)
                {
                    case "=":
                    case "<>":
                    case ">":
                    case ">=":
                    case "<":
                    case "<=":
                        return new DmlfRelationCondition
                        {
                            LeftExpr = _columnValue,
                            RightExpr = number,
                            Relation = opname,
                        };
                }

                return null;
            }


            if (IsNumberBeginning(CurrentToken?.TokenType))
            {
                var number = ParseNumber();

                if (CurrentToken?.TokenType == FilterTokenType.MINUS)
                {
                    Next();
                    var number2 = ParseNumber();
                    if (number2 == null)
                    {
                        IsError = true;
                        return null;
                    }
                    return new DmlfBetweenCondition
                    {
                        Expr = _columnValue,
                        LowerBound = number,
                        UpperBound = number2,
                    };
                }

                return new DmlfEqualCondition
                {
                    LeftExpr = _columnValue,
                    RightExpr = number,
                };
            }

            return null;
        }

        private DmlfConditionBase ParseStringElement()
        {
            if (!_options.ParseString) return null;

            if (CurrentToken?.TokenType == FilterTokenType.OPERATOR && NextToken?.TokenType == FilterTokenType.STRING)
            {
                string opname = CurrentToken.Data;
                string value = NextToken.Data;
                Next(2);
                switch (opname)
                {
                    case "=":
                    case "<>":
                    case ">":
                    case ">=":
                    case "<":
                    case "<=":
                        return new DmlfRelationCondition
                        {
                            LeftExpr = _columnValue,
                            RightExpr = new DmlfStringExpression { Value = value },
                            Relation = opname,
                        };
                    case "+":
                        return new DmlfContainsTextCondition
                        {
                            Expr = _columnValue,
                            Value = value,
                        };
                    case "~":
                        return Negate(new DmlfContainsTextCondition
                        {
                            Expr = _columnValue,
                            Value = value,
                        });
                    case "^":
                        return new DmlfStartsWithCondition
                        {
                            Expr = _columnValue,
                            Value = value,
                        };
                    case "!^":
                        return Negate(new DmlfStartsWithCondition
                        {
                            Expr = _columnValue,
                            Value = value,
                        });
                    case "$":
                        return new DmlfEndsWithCondition
                        {
                            Expr = _columnValue,
                            Value = value,
                        };
                    case "!$":
                        return Negate(new DmlfEndsWithCondition
                        {
                            Expr = _columnValue,
                            Value = value,
                        });
                }
            }

            if (CurrentToken?.TokenType == FilterTokenType.STRING)
            {
                string value = CurrentToken.Data;
                Next();
                return new DmlfContainsTextCondition
                {
                    Expr = _columnValue,
                    Value = value,
                };
            }

            return null;
        }
    }
}
