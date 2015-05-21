using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Driver.Common.ChangeSet
{
    public class ChangeSetInsertItem : ChangeSetItem
    {
        public List<ChangeSetValue> Values = new List<ChangeSetValue>();
    }
}
