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

        public class DeleteWrapper
        {
            public List<ChangeSetDeleteItem> Items = new List<ChangeSetDeleteItem>();
            public TableInfo Table;
            public List<NameWithSchema> Refs;

            public override string ToString()
            {
                return String.Format("{0} [{1}]", Table.Name, Refs.Select(x => x.Name).CreateDelimitedText(","));
            }
        }

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
                if (res.Any(x => x.TargetTable == fk.OwnerTable.FullName))
                {
                    // prevent cycling
                    continue;
                }
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

        /// <summary>
        /// Generates the cascade deletions.
        /// </summary>
        /// <param name="db">The db.</param>
        /// <returns></returns>
        public List<ChangeSetDeleteItem> GenerateCascadeDeletions(DatabaseInfo db)
        {
            var res = new List<ChangeSetDeleteItem>();
            DoGenerateCascadeDeletions(db, res);

            var dct = new Dictionary<NameWithSchema, DeleteWrapper>();
            var queue = new List<DeleteWrapper>();
            foreach (var item in res)
            {
                DeleteWrapper wrap;
                if (!dct.ContainsKey(item.TargetTable))
                {
                    wrap = new DeleteWrapper();
                    dct[item.TargetTable] = wrap;
                    wrap.Table = db.FindTable(item.TargetTable);
                    wrap.Refs = wrap.Table.GetReferences().Select(x => x.OwnerTable.FullName).ToList();
                    wrap.Refs.RemoveAll(x => x == wrap.Table.FullName);
                    queue.Add(wrap);
                }
                else
                {
                    wrap = dct[item.TargetTable];
                }
                wrap.Items.Add(item);
            }
            queue.Reverse();

            var resWrappers = new List<DeleteWrapper>();

            while (queue.Any())
            {
                DeleteWrapper selected = null;
                foreach (var wrap in queue)
                {
                    if (wrap.Refs.All(x => resWrappers.Any(y => y.Table.FullName == x)))
                    {
                        selected = wrap;
                        break;
                    }
                }
                if (selected == null)
                {
                    // omit partial ordering, if order is not possible
                    selected = queue.First();
                }
                queue.Remove(selected);
                resWrappers.Add(selected);
            }

            return resWrappers.SelectMany(x => x.Items).ToList();
        }

        public void GetCommands(DmlfBatch res, DatabaseInfo db, ChangeSetModel model, bool allowCascade = true)
        {
            if (allowCascade && (DeleteReferencesCascade || model.DeleteReferencesCascade))
            {
                var refs = GenerateCascadeDeletions(db);
                foreach (var item in refs)
                {
                    item.GetCommands(res, db, model, false);
                }
            }

            if (model.DeleteReferencesCascade && model.DeleteSkipList != null && model.DeleteSkipList.Contains(TargetTable)) return;
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
