using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Driver.Common.ChangeSet
{
    public class ChangeSetDeleteItem : ChangeSetItem
    {
        public List<ChangeSetCondition> Conditions = new List<ChangeSetCondition>();
    }
}
