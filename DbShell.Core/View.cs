using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Core
{
    /// <summary>
    /// View in database
    /// </summary>
    public class View : TableOrView
    {
        protected override TableInfo GetRowFormat()
        {
            var fullName = GetFullName();
            var db = GetDatabaseStructure();
            var view = db.FindView(fullName.Schema, fullName.Name);
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
            return String.Format("[View {0}]", GetFullName());
        }
    }
}
