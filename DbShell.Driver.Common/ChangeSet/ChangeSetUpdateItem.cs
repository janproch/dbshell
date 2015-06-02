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
    public class ChangeSetUpdateItem : ChangeSetItem
    {
        [XmlCollection(typeof (ChangeSetCondition))]
        public List<ChangeSetCondition> Conditions { get; set; }

        [XmlCollection(typeof (ChangeSetValue))]
        public List<ChangeSetValue> Values { get; set; }

        [XmlElem]
        public bool UpdateReferences { get; set; }

        [XmlElem]
        public bool DisableReferencedForeignKeys { get; set; }

        public ChangeSetUpdateItem()
        {
            Conditions = new List<ChangeSetCondition>();
            Values = new List<ChangeSetValue>();
        }

        public List<ChangeSetUpdateItem> GenerateCascadeUpdates(DatabaseInfo db)
        {
            var res = new List<ChangeSetUpdateItem>();
            GenerateCascadeUpdates(db, res);
            res.Reverse();
            return res;
        }

        private void GenerateCascadeUpdates(DatabaseInfo db, List<ChangeSetUpdateItem> res)
        {
            if (!IsUpdatingPk(db)) return;
            var table = db.FindTable(TargetTable);
            if (table == null) return;
            foreach (var fk in table.GetReferences())
            {
                var newItem = new ChangeSetUpdateItem
                    {
                        LinkedInfo = LinkedInfo,
                        TargetTable = fk.OwnerTable.FullName,
                    };
                newItem.Conditions.AddRange(GetPrefixedConditions(Conditions, fk.ConstraintName));
                res.Add(newItem);

                for (int i = 0; i < fk.Columns.Count; i++)
                {
                    string pkcol = fk.RefColumns[i].RefColumnName;
                    var val = Values.FirstOrDefault(x => x.Column == pkcol);
                    if (val == null) continue;

                    newItem.Values.Add(new ChangeSetValue
                        {
                            Column = fk.Columns[i].RefColumnName,
                            Value = val.Value,
                        });
                }
            }
        }

        public bool IsUpdatingPk(DatabaseInfo db)
        {
            var table = db.FindTable(TargetTable);
            if (table == null) return false;
            if (table.PrimaryKey == null) return false;
            return Values.Any(x => table.PrimaryKey.Columns.Any(y => System.String.Compare(x.Column, y.RefColumnName, System.StringComparison.OrdinalIgnoreCase) == 0));
        }

        public bool IsDuplicatingIdentity(DatabaseInfo db, ChangeSetModel model)
        {
            if (!UpdateReferences && !model.UpdateReferences) return false;
            if (!IsUpdatingPk(db)) return false;
            var table = db.FindTable(TargetTable);
            if (table == null) return false;
            var autoinc = table.FindAutoIncrementColumn();
            return autoinc != null && Values.Any(x => x.Column == autoinc.Name);
        }

        public void GetInsertCommands(DmlfBatch res, DatabaseInfo db, ChangeSetModel model)
        {
            var table = db.FindTable(TargetTable);
            if (table == null) return;

            if (IsDuplicatingIdentity(db, model))
            {
                res.AllowIdentityInsert(table.FullName, true);
                var insert = new DmlfInsertSelect
                    {
                        TargetTable = table.FullName,
                    };
                insert.Select = new DmlfSelect();
                insert.Select.SingleFrom = new DmlfFromItem
                    {
                        Source = new DmlfSource
                            {
                                TableOrView = table.FullName,
                                Alias = "basetbl",
                            }
                    };

                GetConditions(insert.Select, this, Conditions, db);

                foreach (var col in table.Columns)
                {
                    var valcol = Values.FirstOrDefault(x => x.Column == col.Name);
                    insert.TargetColumns.Add(col.Name);
                    if (valcol == null)
                    {
                        insert.Select.Columns.Add(DmlfResultField.BuildFromColumn(col.Name, insert.Select.SingleFrom.Source));
                    }
                    else
                    {
                        insert.Select.Columns.Add(new DmlfResultField
                            {
                                Expr = new DmlfLiteralExpression
                                    {
                                        Value = valcol.Value,
                                    }
                            });
                    }
                }
                res.Commands.Add(insert);
                res.AllowIdentityInsert(table.FullName, false);
            }
        }

        public void GetDeleteCommands(DmlfBatch res, DatabaseInfo db, ChangeSetModel model)
        {
            var table = db.FindTable(TargetTable);
            if (table == null) return;

            if (IsDuplicatingIdentity(db, model))
            {
                var del = new DmlfDelete();
                del.DeleteTarget = new DmlfSource
                    {
                        TableOrView = table.FullName,
                        Alias = "basetbl",
                    };
                del.SingleFrom = new DmlfFromItem
                    {
                        Source = del.DeleteTarget
                    };
                GetConditions(del, this, Conditions, db);

                res.Commands.Add(del);
            }
        }

        public void GetCommands(DmlfBatch res, DatabaseInfo db, ChangeSetModel model)
        {
            var table = db.FindTable(TargetTable);
            if (table == null) return;

            if ((UpdateReferences || model.UpdateReferences) && IsUpdatingPk(db))
            {
                var refs = GenerateCascadeUpdates(db);
                foreach (var item in refs)
                {
                    item.GetCommands(res, db, model);
                }
            }

            if (!IsDuplicatingIdentity(db, model))
            {
                var cmd = new DmlfUpdate();
                cmd.UpdateTarget = new DmlfSource
                    {
                        TableOrView = TargetTable,
                        LinkedInfo = LinkedInfo,
                        Alias = "basetbl",
                    };
                cmd.From.Add(new DmlfFromItem
                    {
                        Source = cmd.UpdateTarget,
                    });
                if (GetConditions(cmd, this, Conditions, db))
                {
                    GetValues(cmd.Columns, Values, table);
                    res.Commands.Add(cmd);
                }
            }
        }
    }
}
