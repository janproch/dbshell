using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;

namespace DbShell.Core
{
    /// <summary>
    /// Returns list of tables (list of <see cref="DbShell.Driver.Common.Structure.TableInfo"/>) of curent database structure
    /// </summary>
    public class TablesProvider : ElementBase, IListProvider
    {
        IEnumerable IListProvider.GetList(IShellContext context)
        {
            var db = GetDatabaseStructure(context);
            return db.Tables;
        }
    }
}
