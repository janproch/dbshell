using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;

namespace DbShell.Core
{
    public class TablesProvider : ElementBase, IListProvider
    {
        IEnumerable IListProvider.GetList()
        {
            var db = GetDatabaseStructure();
            return db.Tables;
        }
    }
}
