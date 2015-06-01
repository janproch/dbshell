using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using DbShell.Driver.Common.DmlFramework;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.ChangeSet
{
    public class ChangeSetDeleteItem : ChangeSetItem
    {
        [XmlCollection(typeof (ChangeSetCondition))]
        public List<ChangeSetCondition> Conditions { get; set; }

        [XmlElem]
        public bool DeleteReferencesCascade { get; set; }

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
                newItem.Conditions.AddRange(GetPrefixedConditions(Conditions, fk.ConstraintName));
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

        public void GetCommands(DmlfBatch res, DatabaseInfo db)
        {
            if (DeleteReferencesCascade)
            {
                var refs = GenerateCascadeDeletions(db);
                foreach (var item in refs)
                {
                    item.GetCommands(res, db);
                }
            }

            var cmd = new DmlfDelete();
            cmd.DeleteTarget = new DmlfSource
            {
                TableOrView = TargetTable,
                LinkedInfo = LinkedInfo,
                Alias = "basetbl",
            };
            cmd.From.Add(new DmlfFromItem
            {
                Source = cmd.DeleteTarget,
            });
            if (!GetConditions(cmd, this, Conditions, db)) return;
            res.Commands.Add(cmd);
        }
    }
}
