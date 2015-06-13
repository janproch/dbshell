using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.CommonDataLayer;

namespace DbShell.Driver.Common.ChangeSet
{
    public class ChangeSetCompiledDeleteItem : ChangeSetCompiledConditionItem
    {
        public ChangeSetCompiledDeleteItem(ChangeSetCompiledModel changeSet, ChangeSetDeleteItem item)
            : base(changeSet, item)
        {
            if (item.TargetTable == changeSet.BaseTable)
            {
                CanBeUsed = true;
                CompileConditions(item.Conditions);
            }
        }
    }
}
