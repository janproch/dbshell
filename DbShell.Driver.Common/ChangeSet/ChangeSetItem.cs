using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.ChangeSet
{
    public abstract class ChangeSetItem
    {
        public NameWithSchema TargetTable;
    }
}
