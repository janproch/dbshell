using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.DmlFramework;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.ChangeSet
{
    public abstract class ChangeSetItem
    {
        [XmlElem]
        public NameWithSchema TargetTable { get; set; }

        [XmlSubElem]
        public LinkedDatabaseInfo LinkedInfo { get; set; }

        protected static List<ChangeSetCondition> GetPrefixedConditions(List<ChangeSetCondition> conditions, string prefix)
        {
            return (from cond in conditions
                    let col = StructuredIdentifier.Parse(cond.Column)
                    let newcol = prefix/col
                    select new ChangeSetCondition
                        {
                            Column = newcol.ToString(), Expression = cond.Expression,
                        }).ToList();
        }

        protected static bool GetConditions(DmlfCommandBase cmd, ChangeSetItem item, List<ChangeSetCondition> conditions, DatabaseInfo db)
        {
            foreach (var cond in conditions)
            {
                if (!GetCondition(cmd, item, cond, db)) return false;
            }
            return true;
        }

        protected static bool GetCondition(DmlfCommandBase cmd, ChangeSetItem item, ChangeSetCondition cond, DatabaseInfo db)
        {
            var source = new DmlfSource
            {
                Alias = "basetbl",
                LinkedInfo = item.LinkedInfo,
                TableOrView = item.TargetTable,
            };
            var colref = cmd.SingleFrom.GetColumnRef(source, item.TargetTable, StructuredIdentifier.Parse(cond.Column), db, DmlfJoinType.Inner);
            if (colref == null) return false;

            //var table = db.FindTable(item.TargetTable);
            //if (table == null) return false;
            //var column = table.FindColumn(cond.Column);
            //if (column == null) return false;

            var colexpr = new DmlfColumnRefExpression
            {
                Column = colref
            };
            var column = colref.FindSourceColumn(db);

            cmd.AddAndCondition(FilterParser.FilterParser.ParseFilterExpression(column != null ? column.CommonType : new DbTypeString(), colexpr, cond.Expression));
            return true;
        }

        protected static void GetValues(DmlfUpdateFieldCollection fields, List<ChangeSetValue> values, TableInfo table)
        {
            foreach (var col in values)
            {
                var colinfo = table.FindColumn(col.Column);
                if (colinfo == null) continue;
                fields.Add(new DmlfUpdateField
                {
                    TargetColumn = colinfo.Name,
                    Expr = new DmlfLiteralExpression
                    {
                        Value = col.Value,
                    }
                });
            }
        }
    }
}
