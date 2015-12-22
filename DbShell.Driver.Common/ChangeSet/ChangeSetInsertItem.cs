using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.DmlFramework;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.ChangeSet
{
    public class ChangeSetInsertItem : ChangeSetItem
    {
        [XmlCollection(typeof (ChangeSetValue))]
        public List<ChangeSetValue> Values { get; set; }

        public ChangeSetInsertItem()
        {
            Values = new List<ChangeSetValue>();
        }

        public void GetCommands(DmlfBatch res, DatabaseInfo db, IDialectDataAdapter dda, ICdlValueConvertor converter)
        {
            var cmd = new DmlfInsert();
            cmd.InsertTarget = TargetTable;

            var table = db.FindTable(TargetTable);
            if (table == null) return;

            var autoinc = table.FindAutoIncrementColumn();
            bool isAutoInc = autoinc != null && Values.Any(x => x.Column == autoinc.Name);

            GetValues(cmd.Columns, Values, table, dda, converter);

            if (isAutoInc)
            {
                res.AllowIdentityInsert(table.FullName, true);
            }

            res.Commands.Add(cmd);

            if (isAutoInc)
            {
                res.AllowIdentityInsert(table.FullName, false);
            }
        }

        public void UpdateValue(string column, object value)
        {
            var val = Values.FirstOrDefault(x => x.Column == column);

            if (value == RevertedValue)
            {
                Values.Remove(val);
            }
            else
            {
                if (val == null)
                {
                    val = new ChangeSetValue();
                    Values.Add(val);
                }
                val.Column = column;
                val.Value = value;
            }
        }
    }
}
