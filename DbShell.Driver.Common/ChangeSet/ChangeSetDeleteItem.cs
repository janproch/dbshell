using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.ChangeSet
{
    public class ChangeSetDeleteItem : ChangeSetItem
    {
        [XmlCollection(typeof (ChangeSetCondition))]
        public List<ChangeSetCondition> Conditions { get; set; }

        public ChangeSetDeleteItem()
        {
            Conditions = new List<ChangeSetCondition>();
        }

        private void DoGenerateCascadeDeletions(DatabaseInfo db, List<ChangeSetDeleteItem> res)
        {
            var table = db.FindTable(TargetTable);
            if (table == null) return;
            foreach (var fk in table.GetReferences())
            {
                var newItem = new ChangeSetDeleteItem
                    {
                        LinkedInfo = LinkedInfo,
                        TargetTable = fk.OwnerTable.FullName,
                    };
                foreach (var cond in Conditions)
                {
                    var col = StructuredIdentifier.Parse(cond.Column);
                    var newcol = fk.ConstraintName/col;
                    newItem.Conditions.Add(new ChangeSetCondition
                        {
                            Column = newcol.ToString(),
                            Expression = cond.Expression,
                        });
                }
                res.Add(newItem);
                newItem.DoGenerateCascadeDeletions(db, res);
            }
        }

        public List<ChangeSetDeleteItem> GenerateCascadeDeletions(DatabaseInfo db)
        {
            var res = new List<ChangeSetDeleteItem>();
            DoGenerateCascadeDeletions(db, res);
            res.Reverse();
            return res;
        }
    }
}
