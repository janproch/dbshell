using DbShell.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Windows.Markup;

namespace DbShell.Core
{
    [ContentProperty("Value")]
    public class SetTableProperty : RunnableBase
    {
        public string Name { get; set; }
        public string Table { get; set; }
        public string Tables { get; set; }
        public string Value { get; set; }

        protected override void DoRun()
        {
            var db = GetDatabaseStructure();
            if (Table != null && Tables != null) throw new Exception("DBSH-00000 SetTableProperty: both of Table and tables attribute is set");
            if (Table == null && Tables == null) throw new Exception("DBSH-00000 SetTableProperty: none of Table and tables attribute is set");

            if (Table != null)
            {
                var table = db.FindTable(Table);
                if (table != null)
                {
                    table.Properties[Name] = Value;
                }
            }
            if (Tables != null)
            {
                foreach (var table in db.Tables)
                {
                    if (Regex.Match(table.Name, Tables).Success)
                    {
                        table.Properties[Name] = Value;
                    }
                }
            }
        }
    }
}
