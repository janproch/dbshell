using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using Antlr.Runtime;
using DbShell.Driver.Common.DmlFramework;

public class DbShellFilterAntlrParser : Antlr.Runtime.Parser
{
    public DmlfOrCondition Condition = new DmlfOrCondition();
    public DmlfExpression ColumnValue;
    string _errors = null;
    private Stack<object> _stack = new Stack<object>();

    public DateTime Now = DateTime.Now;

    public List<DmlfConditionBase> Conditions
    {
        get { return ((DmlfAndCondition) Condition.Conditions.Last()).Conditions; }
    }

    public DbShellFilterAntlrParser(ITokenStream input, RecognizerSharedState state)
        : base(input, state)
    {
        AddAndCondition();
    }

    public void AddAndCondition()
    {
        var and = new DmlfAndCondition();
        Condition.Conditions.Add(and);
    }

    public void AddEqualCondition(string term)
    {
        Conditions.Add(new DmlfEqualCondition
            {
                LeftExpr = ColumnValue,
                RightExpr = new DmlfStringExpression {Value = term},
            });
    }

    public void AddLikeCondition(bool prefix, string term, bool postfix)
    {
        Conditions.Add(new DmlfLikeCondition
        {
            LeftExpr = ColumnValue,
            RightExpr = new DmlfStringExpression { Value = (prefix ? "%" : "") + term + (postfix ? "%" : "") },
        });
    }

    public void NegateLastCondition()
    {
        Conditions[Conditions.Count - 1] = new DmlfNotCondition {Expr = Conditions[Conditions.Count - 1]};
    }

    public void AddNumberRelation(string number, string relation)
    {
        Conditions.Add(new DmlfRelationCondition
            {
                LeftExpr = ColumnValue,
                RightExpr = new DmlfLiteralExpression {Value = Decimal.Parse(number, CultureInfo.InvariantCulture)},
                Relation = relation,
            });
    }

    public void AddStringRelation(string term, string relation)
    {
        Conditions.Add(new DmlfRelationCondition
        {
            LeftExpr = ColumnValue,
            RightExpr = new DmlfStringExpression { Value = term },
            Relation = relation,
        });
    }

    public void AddDateTimeRelation(DateTime value, string relation)
    {
        Conditions.Add(new DmlfRelationCondition
        {
            LeftExpr = ColumnValue,
            RightExpr = new DmlfStringExpression { Value = value.ToString("s") },
            Relation = relation,
        });
    }

    public override void EmitErrorMessage(string msg)
    {
        base.EmitErrorMessage(msg);
        if (_errors != null)
        {
            _errors += "; " + msg;
        }
        else
        {
            _errors = msg;
        }
    }

    public string ExtractString(string term)
    {
        if (String.IsNullOrEmpty(term)) return term;
        char ch = term[0];
        if (term.Length >= 2 && (ch == '\'' || ch == '"') && term[term.Length - 1] == ch)
        {
            return term.Substring(1, term.Length - 2).Replace("" + ch + ch, "" + ch);
        }
        return term;
    }

    public void AddDateTimeIntervalCondition(DateTime left, DateTime right)
    {
        var and = new DmlfAndCondition();
        and.Conditions.Add(new DmlfRelationCondition
            {
                LeftExpr = ColumnValue, Relation = ">=", RightExpr = new DmlfLiteralExpression {Value = left.ToString("s")}
            });
        and.Conditions.Add(new DmlfRelationCondition
        {
            LeftExpr = ColumnValue,
            Relation = "<",
            RightExpr = new DmlfLiteralExpression { Value = right.ToString("s") }
        });
        Conditions.Add(and);

        //Conditions.Add(new DmlfBetweenCondition
        //    {
        //        Expr = ColumnValue,
        //        LowerBound = new DmlfLiteralExpression {Value = left.ToString("s")},
        //        UpperBound = new DmlfLiteralExpression {Value = right.ToString("s")},
        //    });
    }

    public void AddDateTimeNotIntervalCondition(DateTime left, DateTime right)
    {
        Conditions.Add(new DmlfNotCondition
        {
            Expr = new DmlfBetweenCondition
                {
                    Expr = ColumnValue,
                    LowerBound = new DmlfLiteralExpression { Value = left.ToString("s") },
                    UpperBound = new DmlfLiteralExpression { Value = right.ToString("s") },
                }
        });
    }

    public void AddIsNullCondition()
    {
        Conditions.Add(new DmlfIsNullCondition {Expr = ColumnValue});
    }

    public void AddIsNotNullCondition()
    {
        Conditions.Add(new DmlfIsNotNullCondition { Expr = ColumnValue });
    }

    public void AddIsEmptyCondition()
    {
        Conditions.Add(new DmlfEqualCondition
            {
                LeftExpr = new DmlfFuncCallExpression("LTRIM", new DmlfFuncCallExpression("RTRIM", ColumnValue)),
                RightExpr = new DmlfStringExpression {Value = ""}
            });
    }

    public void AddIsNotEmptyCondition()
    {
        Conditions.Add(new DmlfRelationCondition
        {
            LeftExpr = new DmlfFuncCallExpression("LTRIM", new DmlfFuncCallExpression("RTRIM", ColumnValue)),
            RightExpr = new DmlfStringExpression { Value = "" },
            Relation = "<>"
        });
    }

    public TimeSpan ParseTime(string term)
    {
        var m = Regex.Match(term, @"(\d?\d):(\d?\d)(:(\d?\d)(\.\d?\d?\d)?)?");
        if (m.Success)
        {
            int hours = Int32.Parse(m.Groups[1].Value);
            int minutes = Int32.Parse(m.Groups[2].Value);
            int seconds = 0;
            if (!String.IsNullOrEmpty(m.Groups[4].Value)) seconds = Int32.Parse(m.Groups[4].Value);
            int ms = 0;
            if (!String.IsNullOrEmpty(m.Groups[5].Value))
            {
                int f = Int32.Parse(m.Groups[5].Value);
                switch (m.Groups[5].Value.Length)
                {
                    case 1:
                        ms = f * 100;
                        break;
                    case 2:
                        ms = f * 10;
                        break;
                    case 3:
                        ms = f * 1;
                        break;
                }
            }
            return new TimeSpan(0, hours, minutes, seconds, ms);
        }
        return Now.TimeOfDay;
    }

    public DateTime ParseDate(string term)
    {
        bool isYear;
        return ParseDate(term, out isYear);
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
            isYear = !String.IsNullOrEmpty(m1.Groups[3].Value);
            return new DateTime(isYear ? Int32.Parse(m2.Groups[3].Value) : DateTime.Now.Year, Int32.Parse(m2.Groups[2].Value), Int32.Parse(m2.Groups[1].Value));
        }
        var m3 = Regex.Match(term, @"(\d?\d)\/(\d?\d)(\/\d\d\d\d)?");
        if (m3.Success)
        {
            isYear = !String.IsNullOrEmpty(m1.Groups[3].Value);
            return new DateTime(isYear ? Int32.Parse(m3.Groups[3].Value) : DateTime.Now.Year, Int32.Parse(m3.Groups[1].Value), Int32.Parse(m3.Groups[2].Value));
        }
        isYear = true;
        return Now.Date;
    }

    public void AddDateCondition(string date)
    {
        bool isYear;
        var dt = ParseDate(date, out isYear);

        AddDateTimeIntervalCondition(dt, dt + TimeSpan.FromDays(1));

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

    public string Errors { get { return _errors; } }

    public void AddMonthCondition(int month)
    {
        Conditions.Add(new DmlfEqualCondition
            {
                LeftExpr = new DmlfFuncCallExpression("MONTH", ColumnValue),
                RightExpr = new DmlfLiteralExpression {Value = month},
            });
    }

    public void AddDayCondition(int day)
    {
        Conditions.Add(new DmlfEqualCondition
        {
            LeftExpr = new DmlfFuncCallExpression("DAY", ColumnValue),
            RightExpr = new DmlfLiteralExpression { Value = day },
        });
    }

    public void AddDayOfWeekCondition(int day)
    {
        Conditions.Add(new DmlfEqualCondition
            {
                LeftExpr = new DmlfFuncCallExpression("DATEPART", new DmlfSqlValueExpression {Value = "WEEKDAY"}, ColumnValue),
                RightExpr = new DmlfLiteralExpression { Value = day },
            });
    }

    public void AddFlowMonthCondition(string term)
    {
        int month = Int32.Parse(term.Substring(0, term.Length - 1));
        AddDateTimeIntervalCondition(new DateTime(Now.Year, month, 1), new DateTime(Now.Year, month, 1).AddMonths(1));
        //TODO: make option to allow this
        //AddMonthCondition(Int32.Parse(term.Substring(0, term.Length - 1)));
    }

    public void AddFlowDayCondition(string term)
    {
        int day = Int32.Parse(term.Substring(0, term.Length - 1));
        AddDateTimeIntervalCondition(new DateTime(Now.Year, Now.Month, day), new DateTime(Now.Year, Now.Month, day).AddDays(1));
        //TODO: make option to allow this
        //AddDayCondition(Int32.Parse(term.Substring(0, term.Length - 1)));
    }

    public void AddAnyMinuteCondition(string term)
    {
        var m = Regex.Match(term, @"(\d?\d):\*");
        if (m.Success)
        {
            Conditions.Add(new DmlfEqualCondition
            {
                LeftExpr = new DmlfFuncCallExpression("DATEPART", new DmlfSqlValueExpression { Value = "HOUR" }, ColumnValue),
                RightExpr = new DmlfLiteralExpression { Value = m.Groups[1].Value },
            });

        }
    }

    public void AddYearMonthCondition(string term)
    {
        var m = Regex.Match(term, @"(\d\d\d\d)\-(\d?\d)");
        if (m.Success)
        {
            var cond = new DmlfAndCondition();

            cond.Conditions.Add(new DmlfEqualCondition
                {
                    LeftExpr = new DmlfFuncCallExpression("MONTH", ColumnValue),
                    RightExpr = new DmlfLiteralExpression {Value = Int32.Parse(m.Groups[2].Value)},
                });
            cond.Conditions.Add(new DmlfEqualCondition
                {
                    LeftExpr = new DmlfFuncCallExpression("YEAR", ColumnValue),
                    RightExpr = new DmlfLiteralExpression {Value = Int32.Parse(m.Groups[1].Value)},
                });

            Conditions.Add(cond);
        }
    }

    /// <summary>
    /// Returns the first day of the week that the specified
    /// date is in using the current culture. 
    /// </summary>
    public static DateTime GetFirstDayOfWeek(DateTime dayInWeek)
    {
        CultureInfo defaultCultureInfo = CultureInfo.CurrentCulture;
        return GetFirstDayOfWeek(dayInWeek, defaultCultureInfo);
    }

    /// <summary>
    /// Returns the first day of the week that the specified date 
    /// is in. 
    /// </summary>
    public static DateTime GetFirstDayOfWeek(DateTime dayInWeek, CultureInfo cultureInfo)
    {
        DayOfWeek firstDay = cultureInfo.DateTimeFormat.FirstDayOfWeek;
        DateTime firstDayInWeek = dayInWeek.Date;
        while (firstDayInWeek.DayOfWeek != firstDay)
            firstDayInWeek = firstDayInWeek.AddDays(-1);

        return firstDayInWeek;
    }

    public void Push(object o)
    {
        _stack.Push(o);
    }

    public T Pop<T>()
    {
        return (T)_stack.Pop();
    }

    public object Pop()
    {
        return _stack.Pop();
    }
}
