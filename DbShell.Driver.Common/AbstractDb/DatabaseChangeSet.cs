using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.AbstractDb
{
    public enum DatabaseChangeAction
    {
        Add,
        Remove,
        Change
    }

    public class DatabaseChangeItem
    {
        public DatabaseChangeAction Action;
        public DatabaseObjectType ObjectType;
        public string ObjectId;
        public NameWithSchema OldName;
        public NameWithSchema NewName;
    }

    public class DatabaseChangeSet
    {
        public List<DatabaseChangeItem> Items = new List<DatabaseChangeItem>();

        public DatabaseAnalyserFilterOptions CreateFilter()
        {
            var res = new DatabaseAnalyserFilterOptions();
            res.SetEmptyFilter();

            foreach(var item in Items)
            {
                switch (item.Action)
                {
                    case DatabaseChangeAction.Add:
                    case DatabaseChangeAction.Change:
                        res[item.ObjectType].Add(item.ObjectId);
                        break;
                }
            }

            return res;
        }
    }
}
