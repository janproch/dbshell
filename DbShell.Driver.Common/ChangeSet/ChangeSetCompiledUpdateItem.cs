using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Driver.Common.ChangeSet
{
    public class ChangeSetCompiledUpdateItem : ChangeSetCompiledConditionItem
    {
        public List<ChangeSetCompiledValue> Values = new List<ChangeSetCompiledValue>();

        public ChangeSetCompiledUpdateItem(ChangeSetCompiledModel changeSet, ChangeSetUpdateItem item)
            : base(changeSet, item)
        {
            CanBeUsed = true;
            CompileConditions(item.Conditions);
            if (!CanBeUsed) return;
            foreach (var value in item.Values)
            {
                int column = FindColumnIndex(value.Column);
                if (column < 0) continue;
                Values.Add(new ChangeSetCompiledValue
                    {
                        Column = column,
                        Value = value.Value,
                    });
            }
        }
    }
}
