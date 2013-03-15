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

    public DbShellFilterAntlrParser(ITokenStream input, RecognizerSharedState state)
        : base(input, state)
    {
    }

    public void AddEqualCondition(string term)
    {
        Condition.Conditions.Add(new DmlfEqualCondition
            {
                LeftExpr = ColumnValue,
                RightExpr = new DmlfStringExpression {Value = term},
            });
    }

    public void AddNumberRelation(string number, string relation)
    {
        Condition.Conditions.Add(new DmlfRelationCondition
            {
                LeftExpr = ColumnValue,
                RightExpr = new DmlfLiteralExpression {Value = Decimal.Parse(number, CultureInfo.InvariantCulture)},
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
