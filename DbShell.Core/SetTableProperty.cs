using DbShell.Common;
using DbShell.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
#if !NETCOREAPP1_1
using System.Windows.Markup;
#endif
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Utility;

namespace DbShell.Core
{
    /// <summary>
    /// Job, which sets table property
    /// </summary>
#if !NETCOREAPP1_1
    [ContentProperty("Value")]
#endif
    public class SetTableProperty : RunnableBase
    {
        /// <summary>
        /// Name of property
        /// </summary>
        [XamlProperty]
        public string Name { get; set; }

        /// <summary>
        /// Table, which property should be set
        /// </summary>
        [XamlProperty]
        public string Table { get; set; }

        /// <summary>
        /// Regular expression. All matched tables will be processed.
        /// </summary>
        [XamlProperty]
        public string Tables { get; set; }

        /// <summary>
        /// Value, which will be set
        /// </summary>
        [XamlProperty]
        public string Value { get; set; }

        protected override void DoRun(IShellContext context)
        {
            var db = GetDatabaseStructure(context);
            if (Table != null && Tables != null) throw new Exception("DBSH-00085 SetTableProperty: both of Table and tables attribute is set");
            if (Table == null && Tables == null) throw new Exception("DBSH-00086 SetTableProperty: none of Table and tables attribute is set");

            string value = context.Replace(Value);
            if (Table != null)
            {
                var table = db.FindTableLike(Table);
                if (table != null)
                {
                    table.Properties[Name] = value;
                }
            }
            if (Tables != null)
            {
                foreach (var table in db.Tables)
                {
                    if (Regex.Match(table.Name, Tables).Success)
                    {
                        table.Properties[Name] = value;
                    }
                }
            }
        }
    }
}
