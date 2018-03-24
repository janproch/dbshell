using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DbShell.Driver.Common.Interfaces;
using DbShell.Core.Utility;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Core
{
    /// <summary>
    /// Table in database
    /// </summary>
    public class Table : TableOrView
    {
        protected override TableInfo GetRowFormat(IShellContext context)
        {
            var fullName = GetFullName(context);
            var db = GetDatabaseStructure(context);
            var table = db.FindTableLike(fullName.Schema, fullName.Name);
            if (table == null)
            {
                throw new Exception(String.Format("DBSH-00007 Table {0} not found", fullName));
            }
            return table;
        }

        public override string ToString()
        {
            return String.Format("[Table {0}]", Name);
        }

        public override string ToStringCtx(IShellContext context)
        {
            return String.Format("[Table {0}]", context.Replace(Name));
        }

        protected override string XamlExtensionName => "Table";
    }
}
