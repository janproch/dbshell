using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DbShell.Core.Utility;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;
using DbShell.Driver.Common.Interfaces;

namespace DbShell.Core
{
    /// <summary>
    /// View in database
    /// </summary>
    public class View : TableOrView
    {
        protected override TableInfo GetRowFormat(IShellContext context)
        {
            var fullName = GetFullName(context);
            var db = GetDatabaseStructure(context);
            var view = db.FindViewLike(fullName.Schema, fullName.Name);
            if (view == null)
            {
                throw new Exception(String.Format("DBSH-00091 View {0} not found", fullName));
            }
            if (view.QueryInfo == null)
            {
                throw new Exception(String.Format("DBSH-00092 View {0} has not result info, probably view contains errors", fullName));
            }
            return view.QueryInfo.ToTableInfo();
        }

        public override string ToString()
        {
            return String.Format("[View {0}]", Name);
        }

        public override string ToStringCtx(IShellContext context)
        {
            return String.Format("[View {0}]", context.Replace(Name));
        }

        protected override string XamlExtensionName => "View";
    }
}
