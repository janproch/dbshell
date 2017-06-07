#if !NETSTANDARD1_5
using Antlr.Runtime;
using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

public class ObjectFilterAntlrParser : Antlr.Runtime.Parser
{
    public ObjectFilterOrCondition Condition = new ObjectFilterOrCondition();
    string _errors = null;
    private Stack<object> _stack = new Stack<object>();

    public DateTime Now = DateTime.Now;

    public List<ObjectFilterConditionBase> Conditions
    {
        get { return ((ObjectFilterAndCondition)Enumerable.Last(Condition.Conditions)).Conditions; }
    }

    public ObjectFilterAntlrParser(ITokenStream input, RecognizerSharedState state)
        : base(input, state)
    {
        AddAndCondition();
    }

    public void AddAndCondition()
    {
        var and = new ObjectFilterAndCondition();
        Condition.Conditions.Add(and);
    }

    public void AddStringTestCondition<T>(string term)
    where T : ObjectFilterStringTextCondition, new()
    {
        var cond = new T
        {
            Filter = term,
            Context = ObjectFilterContextEnum.Name,
        };
        Conditions.Add(cond);
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

    public void SetLastConditionContext(ObjectFilterContextEnum context)
    {
        var negateCond = Conditions[Conditions.Count - 1] as ObjectFilterNotCondition;
        ObjectFilterStringTextCondition stringCond;
        if (negateCond != null)
        {
            stringCond = negateCond.Condition as ObjectFilterStringTextCondition;
        }
        else
        {
            stringCond = Conditions[Conditions.Count - 1] as ObjectFilterStringTextCondition;
        }
        if (stringCond != null) stringCond.Context = context;
    }

    public void NegateLastCondition()
    {
        Conditions[Conditions.Count - 1] = new ObjectFilterNotCondition { Condition = Conditions[Conditions.Count - 1] };
    }
}
#endif