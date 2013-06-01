﻿using System;
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
    /// Table in database
    /// </summary>
    public class Table : TableOrView
    {
        protected override TableInfo GetRowFormat()
        {
            var fullName = GetFullName();
            var db = GetDatabaseStructure();
            var table = db.FindTable(fullName.Schema, fullName.Name);
            if (table == null)
            {
                throw new Exception(String.Format("DBSH-00007 Table {0} not found", fullName));
            }
            return table;
        }

        public override string ToString()
        {
            return String.Format("[Table {0}]", GetFullName());
        }
    }
}
