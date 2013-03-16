using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using Antlr.Runtime;
using DbShell.Driver.Common.DmlFramework;

public class DbShellFilterAntlrParser : Antlr.Runtime.Parser
{
    public DmlfOrCondition Condition = new DmlfOrCondition();
    public DmlfExpression ColumnValue;
    string _errors = null;
    private Stack<object> _stack = new Stack<object>();

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
        Conditions[Condition.Conditions.Count - 1] = new DmlfNotCondition {Expr = Conditions[Condition.Conditions.Count - 1]};
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

    public string Errors { get { return _errors; } }

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
