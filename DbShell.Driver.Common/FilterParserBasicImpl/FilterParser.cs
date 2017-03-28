using DbShell.Driver.Common.DmlFramework;
using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

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

        DateTime Now = DateTime.Now;

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

            if (_options.ParseTime)
            {
                _keywords.Add("THIS");
                _keywords.Add("NEXT");
                _keywords.Add("WEEK");
                _keywords.Add("YEAR");
                _keywords.Add("MONTH");
                _keywords.Add("YESTERDAY");
                _keywords.Add("TODAY");
                _keywords.Add("TOMORROW");
                _keywords.Add("HOUR");

                new List<string>
                {
                    "JAN","FEB","MAR","APR","MAY","JUN","JUL","AUG","SEP","OCT","NOV","DEC"
                }.ForEach(x => _keywords.Add(x));
                new List<string>
                {
                    "MON","TUE","WED","THU","FRI","SAT","SUN"
                }.ForEach(x => _keywords.Add(x));
            }

            if (_options.ParseLogical)
            {
                _keywords.Add("TRUE");
                _keywords.Add("FALSE");
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
            for (int i = 0; i < keywords.Length; i++)
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
            result = ParseDateTimeElement();
            if (result != null) return result;
            result = ParseLogicalElement();
            if (result != null) return result;

            IsError = true;
            return null;
        }

        private double? ParseNumberCore(bool allowString = true)
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

        /// <summary>
        /// Returns the first day of the week that the specified
        /// date is in using the current culture. 
        /// </summary>
        public static DateTime GetFirstDayOfWeek(DateTime dayInWeek)
        {
            return DateTimeTool.GetFirstDayOfWeek(dayInWeek);
        }

        /// <summary>
        /// Returns the first day of the week that the specified date 
        /// is in. 
        /// </summary>
        public static DateTime GetFirstDayOfWeek(DateTime dayInWeek, CultureInfo cultureInfo)
        {
            return DateTimeTool.GetFirstDayOfWeek(dayInWeek, cultureInfo);
        }

        public DateTime ParseDate(string term, out bool isYear)
        {
            var m1 = Regex.Match(term, @"(\d\d\d\d)-(\d?\d)-(\d?\d)");
            if (m1.Success)
            {
                isYear = true;
                return new DateTime(Int32.Parse(m1.Groups[1].Value), Int32.Parse(m1.Groups[2].Value), Int32.Parse(m1.Groups[3].Value));
            }
            var m2 = Regex.Match(term, @"(\d?\d)\.(\d?\d)\.(\d\d\d\d)?");
            if (m2.Success)
            {
                isYear = !String.IsNullOrEmpty(m2.Groups[3].Value);
                return new DateTime(isYear ? Int32.Parse(m2.Groups[3].Value) : DateTime.Now.Year, Int32.Parse(m2.Groups[2].Value), Int32.Parse(m2.Groups[1].Value));
            }
            var m3 = Regex.Match(term, @"(\d?\d)\/(\d?\d)\/(\d\d\d\d)?");
            if (m3.Success)
            {
                isYear = !String.IsNullOrEmpty(m3.Groups[3].Value);
                return new DateTime(isYear ? Int32.Parse(m3.Groups[3].Value) : DateTime.Now.Year, Int32.Parse(m3.Groups[1].Value), Int32.Parse(m3.Groups[2].Value));
            }
            isYear = true;
            return Now.Date;
        }

        public DmlfConditionBase DateCondition(string date)
        {
            bool isYear;
            var dt = ParseDate(date, out isYear);

            return DateTimeIntervalCondition(dt, dt + TimeSpan.FromDays(1));

            //TODO: make option to allow this
            //if (isYear)
            //{
            //    AddDateTimeIntervalCondition(dt, dt + TimeSpan.FromDays(1));
            //    return;
            //}
            //var cond = new DmlfAndCondition();

            //cond.Conditions.Add(new DmlfEqualCondition
            //    {
            //        LeftExpr = new DmlfFuncCallExpression("MONTH", ColumnValue),
            //        RightExpr = new DmlfLiteralExpression {Value = dt.Month},
            //    });
            //cond.Conditions.Add(new DmlfEqualCondition
            //{
            //    LeftExpr = new DmlfFuncCallExpression("DAY", ColumnValue),
            //    RightExpr = new DmlfLiteralExpression { Value = dt.Day },
            //});

            //Conditions.Add(cond);
        }

        private DmlfConditionBase TrueCondition()
        {
            return new DmlfEqualCondition { LeftExpr = _columnValue, RightExpr = new DmlfLiteralExpression { Value = 1 } };
        }

        private DmlfConditionBase FalseCondition()
        {
            return new DmlfEqualCondition { LeftExpr = _columnValue, RightExpr = new DmlfLiteralExpression { Value = 0 } };
        }

        private DmlfConditionBase ParseLogicalElement()
        {
            if (!_options.ParseLogical) return null;

            if (TestKeywords("TRUE")) return TrueCondition();
            if (TestKeywords("FALSE")) return FalseCondition();
            if (CurrentToken?.TokenType == FilterTokenType.BIT && CurrentToken?.Data == "1")
            {
                Next();
                return TrueCondition();
            }
            if (CurrentToken?.TokenType == FilterTokenType.BIT && CurrentToken?.Data == "0")
            {
                Next();
                return FalseCondition();
            }
            return null;
        }

        private DmlfConditionBase ParseDateTimeElement()
        {
            if (!_options.ParseTime) return null;

            if (TestKeywords("LAST", "HOUR")) { var h1 = new DateTime(Now.Year, Now.Month, Now.Day, Now.Hour, 0, 0); return DateTimeIntervalCondition(h1 - TimeSpan.FromHours(1), h1); }
            if (TestKeywords("THIS", "HOUR")) { var h1 = new DateTime(Now.Year, Now.Month, Now.Day, Now.Hour, 0, 0); return DateTimeIntervalCondition(h1, h1 + TimeSpan.FromHours(1)); }
            if (TestKeywords("NEXT", "HOUR")) { var h1 = new DateTime(Now.Year, Now.Month, Now.Day, Now.Hour, 0, 0); return DateTimeIntervalCondition(h1 + TimeSpan.FromHours(1), h1 + TimeSpan.FromHours(2)); }

            if (TestKeywords("YESTERDAY")) { return DateTimeIntervalCondition(Now.Date - TimeSpan.FromDays(1), Now.Date); }
            if (TestKeywords("TODAY")) { return DateTimeIntervalCondition(Now.Date, Now.Date + TimeSpan.FromDays(1)); }
            if (TestKeywords("TOMORROW")) { return DateTimeIntervalCondition(Now.Date + TimeSpan.FromDays(1), Now.Date + TimeSpan.FromDays(2)); }


            if (TestKeywords("LAST", "WEEK")) { var d1 = GetFirstDayOfWeek(Now.Date); return DateTimeIntervalCondition(d1 - TimeSpan.FromDays(7), d1); }
            if (TestKeywords("THIS", "WEEK")) { var d1 = GetFirstDayOfWeek(Now.Date); return DateTimeIntervalCondition(d1, d1 + TimeSpan.FromDays(7)); }
            if (TestKeywords("NEXT", "WEEK")) { var d1 = GetFirstDayOfWeek(Now.Date); return DateTimeIntervalCondition(d1 + TimeSpan.FromDays(7), d1 + TimeSpan.FromDays(14)); }

            if (TestKeywords("LAST", "MONTH")) { var d1 = new DateTime(Now.Year, Now.Month, 1); return DateTimeIntervalCondition(d1.AddMonths(-1), d1); }
            if (TestKeywords("THIS", "MONTH")) { var d1 = new DateTime(Now.Year, Now.Month, 1); return DateTimeIntervalCondition(d1, d1.AddMonths(1)); }
            if (TestKeywords("NEXT", "MONTH")) { var d1 = new DateTime(Now.Year, Now.Month, 1); return DateTimeIntervalCondition(d1.AddMonths(1), d1.AddMonths(2)); }


            if (TestKeywords("LAST", "YEAR")) { var d1 = new DateTime(Now.Year, 1, 1); return DateTimeIntervalCondition(d1.AddYears(-1), d1); }
            if (TestKeywords("THIS", "YEAR")) { var d1 = new DateTime(Now.Year, 1, 1); return DateTimeIntervalCondition(d1, d1.AddYears(1)); }
            if (TestKeywords("NEXT", "YEAR")) { var d1 = new DateTime(Now.Year, 1, 1); return DateTimeIntervalCondition(d1.AddYears(1), d1.AddYears(2)); }

            if (TestKeywords("TODAY")) return DateTimeIntervalCondition(Now.Date, Now.Date + TimeSpan.FromDays(1));

            if (TestKeywords("JAN")) return MonthCondition(1);
            if (TestKeywords("FEB")) return MonthCondition(2);
            if (TestKeywords("MAR")) return MonthCondition(3);
            if (TestKeywords("APR")) return MonthCondition(4);
            if (TestKeywords("MAY")) return MonthCondition(5);
            if (TestKeywords("JUN")) return MonthCondition(6);
            if (TestKeywords("JUL")) return MonthCondition(7);
            if (TestKeywords("AUG")) return MonthCondition(8);
            if (TestKeywords("SEP")) return MonthCondition(9);
            if (TestKeywords("OCT")) return MonthCondition(10);
            if (TestKeywords("NOV")) return MonthCondition(11);
            if (TestKeywords("DEC")) return MonthCondition(12);

            if (TestKeywords("MON")) return DayOfWeekCondition(DayOfWeek.Monday);
            if (TestKeywords("TUE")) return DayOfWeekCondition(DayOfWeek.Tuesday);
            if (TestKeywords("WED")) return DayOfWeekCondition(DayOfWeek.Wednesday);
            if (TestKeywords("THU")) return DayOfWeekCondition(DayOfWeek.Thursday);
            if (TestKeywords("FRI")) return DayOfWeekCondition(DayOfWeek.Friday);
            if (TestKeywords("SAT")) return DayOfWeekCondition(DayOfWeek.Saturday);
            if (TestKeywords("SUN")) return DayOfWeekCondition(DayOfWeek.Sunday);

            if (CurrentToken?.TokenType == FilterTokenType.YEAR)
            {
                var d1 = new DateTime(Int32.Parse(CurrentToken.Data), 1, 1);
                Next();
                return DateTimeIntervalCondition(d1, d1.AddYears(1));
            }
            //if (CurrentToken?.TokenType == FilterTokenType.DATE)
            //{
            //    var cond = DateCondition(CurrentToken.Data);
            //    Next();
            //    return cond;
            //}
            if (CurrentToken?.TokenType == FilterTokenType.HOUR_ANY_MINUTE)
            {
                var cond = HourAnyMinuteCondition(CurrentToken.Data);
                Next();
                return cond;
            }
            if (CurrentToken?.TokenType == FilterTokenType.FLOW_MONTH)
            {
                var cond = FlowMonthCondition(CurrentToken.Data);
                Next();
                return cond;
            }
            if (CurrentToken?.TokenType == FilterTokenType.FLOW_DAY)
            {
                var cond = FlowDayCondition(CurrentToken.Data);
                Next();
                return cond;
            }
            if (CurrentToken?.TokenType == FilterTokenType.YEAR_MONTH)
            {
                var cond = YearMonthCondition(CurrentToken.Data);
                Next();
                return cond;
            }

            string opname = null;

            if (CurrentToken?.TokenType == FilterTokenType.DATE)
            {
                opname = "=";
            }
            else if (CurrentToken?.TokenType == FilterTokenType.OPERATOR && NextToken?.TokenType == FilterTokenType.DATE)
            {
                opname = CurrentToken.Data;
                Next();
            }

            if (opname != null)
            {
                bool isYear;
                DateTime date = ParseDate(CurrentToken.Data, out isYear);
                Next();

                if (CurrentToken?.TokenType == FilterTokenType.TIME_SECOND_FRACTION)
                {
                    var time = ParseTime(CurrentToken.Data);
                    Next();
                    return DateTimeRelation(date + time, opname);
                }

                DateTime dateBegin = date, dateEnd = date + TimeSpan.FromDays(1);

                if (CurrentToken?.TokenType == FilterTokenType.TIME_MINUTE
                    || CurrentToken?.TokenType == FilterTokenType.TIME_SECOND)
                {
                    TimeSpan timeBegin, timeEnd;
                    ParseTimeCore(CurrentToken.Data, out timeBegin, out timeEnd);
                    dateBegin = date + timeBegin;
                    dateEnd = date + timeEnd;
                    Next();
                }

                switch (opname)
                {
                    case "=":
                        return DateTimeIntervalCondition(dateBegin, dateEnd);
                    case "<>":
                        return Negate(DateTimeIntervalCondition(dateBegin, dateEnd));
                    case "<":
                        return DateTimeRelation(dateBegin, "<");
                    case "<=":
                        return DateTimeRelation(dateEnd, "<");
                    case ">":
                        return DateTimeRelation(dateEnd, ">=");
                    case ">=":
                        return DateTimeRelation(dateBegin, ">=");
                }
            }

            return null;
        }

        public DmlfConditionBase DateTimeRelation(DateTime value, string relation)
        {
            return new DmlfRelationCondition
            {
                LeftExpr = _columnValue,
                RightExpr = new DmlfLiteralExpression { Value = value },
                Relation = relation,
            };
        }

        private void ParseTimeCore(string term, out TimeSpan begin, out TimeSpan end)
        {
            var m1 = Regex.Match(term, @"(\d?\d):(\d?\d):(\d?\d)\.(\d*)");
            if (m1.Success)
            {
                int hours = Int32.Parse(m1.Groups[1].Value);
                int minutes = Int32.Parse(m1.Groups[2].Value);
                int seconds = Int32.Parse(m1.Groups[3].Value);
                int fraction = 0;
                if (m1.Groups[4].Value.Length > 0)
                {
                    fraction = Int32.Parse(m1.Groups[4].Value) * (int)Math.Pow(10, 7 - m1.Groups[4].Value.Length);
                }
                var res = new TimeSpan(hours, minutes, seconds);
                begin = end = new TimeSpan(res.Ticks + fraction);
                return;
            }
            var m2 = Regex.Match(term, @"(\d?\d):(\d?\d):(\d?\d)");
            if (m2.Success)
            {
                int hours = Int32.Parse(m2.Groups[1].Value);
                int minutes = Int32.Parse(m2.Groups[2].Value);
                int seconds = Int32.Parse(m2.Groups[3].Value);
                begin = new TimeSpan(hours, minutes, seconds);
                end = new TimeSpan(hours, minutes, seconds + 1);
                return;
            }
            var m3 = Regex.Match(term, @"(\d?\d):(\d?\d)");
            if (m3.Success)
            {
                int hours = Int32.Parse(m3.Groups[1].Value);
                int minutes = Int32.Parse(m3.Groups[2].Value);
                begin = new TimeSpan(hours, minutes, 0);
                end = new TimeSpan(hours, minutes + 1, 0);
                return;
            }

            begin = end = Now.TimeOfDay;
        }

        public TimeSpan ParseTime(string term)
        {
            TimeSpan begin, end;
            ParseTimeCore(term, out begin, out end);
            return begin;
        }

        public TimeSpan ParseTimeEnd(string term)
        {
            TimeSpan begin, end;
            ParseTimeCore(term, out begin, out end);
            return end;
        }


        private DmlfConditionBase DateTimeIntervalCondition(DateTime begin, DateTime end)
        {
            var and = new DmlfAndCondition();
            and.Conditions.Add(new DmlfRelationCondition
            {
                LeftExpr = _columnValue,
                Relation = ">=",
                RightExpr = new DmlfLiteralExpression { Value = StringTool.DateTimeToIsoStringExact(begin) }
            });
            and.Conditions.Add(new DmlfRelationCondition
            {
                LeftExpr = _columnValue,
                Relation = "<",
                RightExpr = new DmlfLiteralExpression { Value = StringTool.DateTimeToIsoStringExact(end) }
            });
            return and;
        }

        public DmlfConditionBase MonthCondition(int month)
        {
            return new DmlfEqualCondition
            {
                LeftExpr = new DmlfMonthExpression { Argument = _columnValue },
                RightExpr = new DmlfLiteralExpression { Value = month },
            };
        }

        public DmlfConditionBase DayCondition(int day)
        {
            return new DmlfEqualCondition
            {
                LeftExpr = new DmlfDayOfMonthExpression { Argument = _columnValue },
                RightExpr = new DmlfLiteralExpression { Value = day },
            };
        }

        public DmlfConditionBase DayOfWeekCondition(DayOfWeek day)
        {
            return new DmlfEqualCondition
            {
                LeftExpr = new DmlfDayOfWeekExpression { Argument = _columnValue },
                RightExpr = new DmlfDayOfWeekLiteralExpression { Value = day },
            };
        }

        public DmlfConditionBase FlowMonthCondition(string term)
        {
            int month = Int32.Parse(term.Substring(0, term.Length - 1));
            return DateTimeIntervalCondition(new DateTime(Now.Year, month, 1), new DateTime(Now.Year, month, 1).AddMonths(1));
            //TODO: make option to allow thiif (TestKeywords("   "))   return  AddMonthCondition(Int32.Parse(term.Substring(0, term.Length - 1))
        }

        public DmlfConditionBase FlowDayCondition(string term)
        {
            int day = Int32.Parse(term.Substring(0, term.Length - 1));
            return DateTimeIntervalCondition(new DateTime(Now.Year, Now.Month, day), new DateTime(Now.Year, Now.Month, day).AddDays(1));
            //TODO: make option to allow this
            //AddDayCondition(Int32.Parse(term.Substring(0, term.Length - 1)));
        }

        public DmlfConditionBase HourAnyMinuteCondition(string term)
        {
            var m = Regex.Match(term, @"(\d?\d):\*");
            if (m.Success)
            {
                return new DmlfEqualCondition
                {
                    LeftExpr = new DmlfFuncCallExpression("DATEPART", new DmlfSqlValueExpression { Value = "HOUR" }, _columnValue),
                    RightExpr = new DmlfLiteralExpression { Value = m.Groups[1].Value },
                };
            }
            return null;
        }

        public DmlfConditionBase YearMonthCondition(string term)
        {
            var m = Regex.Match(term, @"(\d\d\d\d)\-(\d?\d)");
            if (m.Success)
            {
                var cond = new DmlfAndCondition();

                cond.Conditions.Add(new DmlfEqualCondition
                {
                    LeftExpr = new DmlfFuncCallExpression("MONTH", _columnValue),
                    RightExpr = new DmlfLiteralExpression { Value = Int32.Parse(m.Groups[2].Value) },
                });
                cond.Conditions.Add(new DmlfEqualCondition
                {
                    LeftExpr = new DmlfFuncCallExpression("YEAR", _columnValue),
                    RightExpr = new DmlfLiteralExpression { Value = Int32.Parse(m.Groups[1].Value) },
                });

                return cond;
            }
            return null;
        }

    }
}
