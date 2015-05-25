using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.DmlFramework;
using DbShell.Driver.Common.Sql;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.ChangeSet
{
    public class ChangeSetModel
    {
        [XmlCollection(typeof(ChangeSetInsertItem))]
        public List<ChangeSetInsertItem> Inserts { get; set; }

        [XmlCollection(typeof(ChangeSetUpdateItem))]
        public List<ChangeSetUpdateItem> Updates { get; set; }

        [XmlCollection(typeof(ChangeSetDeleteItem))]
        public List<ChangeSetDeleteItem> Deletes { get; set; }

        public ChangeSetModel()
        {
            Inserts = new List<ChangeSetInsertItem>();
            Updates = new List<ChangeSetUpdateItem>();
            Deletes = new List<ChangeSetDeleteItem>();
        }

        //public void SaveToXml(XmlElement xml)
        //{
        //    foreach (var elem in Inserts)
        //    {
        //        elem.SaveToXml(xml.AddChild("Insert"));
        //    }
        //    foreach (var elem in Updates)
        //    {
        //        elem.SaveToXml(xml.AddChild("Update"));
        //    }
        //    foreach (var elem in Deletes)
        //    {
        //        elem.SaveToXml(xml.AddChild("Delete"));
        //    }
        //}

        //private void DumpTarget(ISqlDumper dmp, ChangeSetItem item)
        //{
        //    string linkedInfoStr = item.LinkedInfo != null ? item.LinkedInfo.ToString() : "";
        //    dmp.Put("%s%f", linkedInfoStr, item.TargetTable);
        //}

        //private void DumpWhere(ISqlDumper dmp, ChangeSetItem item, List<ChangeSetCondition> conditions, DatabaseInfo db)
        //{
        //    dmp.Put("^ where ");
        //    bool wasCond = false;
        //    foreach(var cond in conditions)
        //    {
        //        if (wasCond) dmp.Put(" ^and ");
        //        wasCond = true;
        //        DumpCondition(dmp, item, cond, db);
        //    }
        //}

        private bool GetConditions(DmlfCommandBase cmd, ChangeSetItem item, List<ChangeSetCondition> conditions, DatabaseInfo db)
        {
            foreach (var cond in conditions)
            {
                if (!GetCondition(cmd, item, cond, db)) return false;
            }
            return true;
        }

        private bool GetCondition(DmlfCommandBase cmd, ChangeSetItem item, ChangeSetCondition cond, DatabaseInfo db)
        {
            var table = db.FindTable(item.TargetTable);
            if (table == null) return false;
            var column = table.FindColumn(cond.Column);
            if (column == null) return false;
            var colexpr = new DmlfColumnRefExpression
                {
                    Column = new DmlfColumnRef
                        {
                            ColumnName = column.Name,
                            Source = new DmlfSource
                                {
                                    LinkedInfo = item.LinkedInfo,
                                    TableOrView = item.TargetTable,
                                }
                        }
                };
            cmd.AddAndCondition(FilterParser.FilterParser.ParseFilterExpression(column.CommonType, colexpr, cond.Expression));
            return true;
        }

        private void GetValues(DmlfUpdateFieldCollection fields, List<ChangeSetValue> values, TableInfo table)
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

        public List<DmlfBase> GetCommands(DatabaseInfo db)
        {
            var res = new List<DmlfBase>();

            foreach (var ins in Inserts)
            {
                var cmd = new DmlfInsert();
                cmd.InsertTarget = new DmlfSource
                    {
                        TableOrView = ins.TargetTable,
                        LinkedInfo = ins.LinkedInfo,
                    };

                var table = db.FindTable(ins.TargetTable);
                if (table == null) continue;

                var autoinc = table.FindAutoIncrementColumn();
                if (autoinc != null && ins.Values.Any(x => x.Column == autoinc.Name)) cmd.IdentityInsertTable = table.FullName;

                GetValues(cmd.Columns, ins.Values, table);

                res.Add(cmd);
            }

            foreach (var upd in Updates)
            {
                var cmd = new DmlfUpdate();
                cmd.UpdateTarget = new DmlfSource
                    {
                        TableOrView = upd.TargetTable,
                        LinkedInfo = upd.LinkedInfo,
                    };
                cmd.From.Add(new DmlfFromItem
                    {
                        Source = cmd.UpdateTarget,
                    });
                if (!GetConditions(cmd, upd, upd.Conditions, db)) continue;

                var table = db.FindTable(upd.TargetTable);
                if (table == null) continue;

                GetValues(cmd.Columns, upd.Values, table);
                res.Add(cmd);
            }

            foreach (var del in Deletes)
            {
                var cmd = new DmlfDelete();
                cmd.DeleteTarget = new DmlfSource
                    {
                        TableOrView = del.TargetTable,
                        LinkedInfo = del.LinkedInfo,
                    };
                cmd.From.Add(new DmlfFromItem
                {
                    Source = cmd.DeleteTarget,
                });
                if (!GetConditions(cmd, del, del.Conditions, db)) continue;
                res.Add(cmd);
            }

            return res;
        }

        public void DumpSql(ISqlDumper dmp, DatabaseInfo db)
        {
            var commands = GetCommands(db);
            commands.ForEach(x =>
                {
                    x.GenSql(dmp, new DmlfHandler());
                    dmp.EndCommand();
                });
        }

        //public void LoadFromXml(XmlElement xml)
        //{
        //    Inserts.Clear();
        //    Updates.Clear();
        //    Deletes.Clear();

        //    foreach(XmlElement xitem in xml.SelectNodes("Insert"))
        //    {
        //        var item = new ChangeSetInsertItem();
        //        item.LoadFromXml(xitem);
        //        Inserts.Add(item);
        //    }
        //}
    }
}
