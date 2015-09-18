using System;
using System.Collections.Generic;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Sql;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.DmlFramework
{
    public class DmlfSelect : DmlfCommandBase
    {
        [XmlCollection(typeof (DmlfResultField))]
        public DmlfResultFieldCollection Columns { get; set; }

        [XmlSubElem]
        public DmlfSortOrderCollection OrderBy { get; set; }

        [XmlSubElem]
        public DmlfGroupByCollection GroupBy { get; set; }

        [XmlSubElem]
        public DmlfHaving Having { get; set; }

        [XmlElem]
        public int? TopRecords { get; set; }

        [XmlElem]
        public int? LimitCount { get; set; }

        [XmlElem]
        public int Offset { get; set; }

        [XmlElem]
        public bool SelectAll { get; set; }

        [XmlElem]
        public bool Distinct { get; set; }

        [XmlElem]
        public NameWithSchema SelectIntoTable { get; set; }

        public DmlfSelect()
        {
            Columns = new DmlfResultFieldCollection();
        }

        ///// <summary>
        ///// adds primary key information to query definition, or marks columns as read only, of no PK is available
        ///// </summary>
        ///// <param name="handler">used for obtain table structures with PKs</param>
        //public void CompleteUpdatingInfo(IDmlfHandler handler)
        //{
        //    var pks = new Dictionary<DmlfSource, PrimaryKeyInfo>();
        //    var required_pks = new Dictionary<DmlfSource, PrimaryKeyInfo>();
        //    // list of columns
        //    var usedcols = new HashSetEx<DmlfColumnRef>();

        //    foreach (var col in Columns)
        //    {
        //        var di = col.DisplayInfo;
        //        if (di == null) continue;
        //        var tbl = col.Source;
        //        if (tbl == null) tbl = handler.BaseTable;
        //        if (tbl == null) continue;
        //        var cr = col.Expr as DmlfColumnRefExpression;
        //        if (cr == null)
        //        {
        //            di.IsReadOnly = true;
        //            continue;
        //        }
        //        if (!pks.ContainsKey(tbl))
        //        {
        //            pks[tbl] = null;
        //            if (handler != null)
        //            {
        //                var ts = handler.GetStructure(tbl.TableOrView);
        //                if (ts != null)
        //                {
        //                    pks[tbl] = ts.PrimaryKey;
        //                }
        //            }
        //        }
        //        var pk = pks[tbl];
        //        if (pk == null)
        //        {
        //            // no primary key, is readonly
        //            di.IsReadOnly = true;
        //            continue;
        //        }
        //        var pkcols = new List<string>(pk.Columns.GetNames());
        //        if (pkcols.Contains(cr.Column.ColumnName))
        //        {
        //            di.IsPrimaryKey = true;
        //        }
        //        usedcols.Add(new DmlfColumnRef { Source = tbl, ColumnName = cr.Column.ColumnName });
        //        if (di.Style == ColumnDisplayInfo.UsageStyle.Value)
        //        {
        //            required_pks[tbl] = pk;
        //        }
        //        if (di.Style == ColumnDisplayInfo.UsageStyle.Lookup)
        //        {
        //            di.IsReadOnly = true;
        //        }
        //    }

        //    // add missing primary key columns as hidden columns
        //    foreach (var pkt in required_pks)
        //    {
        //        foreach (string col in pkt.Value.Columns.GetNames())
        //        {
        //            var key = new DmlfColumnRef { Source = pkt.Key, ColumnName = col };
        //            if (usedcols.Contains(key)) continue;
        //            usedcols.Add(key);
        //            var nc = new DmlfResultField
        //            {
        //                DisplayInfo = new ColumnDisplayInfo
        //                {
        //                    IsPrimaryKey = true,
        //                    Style = ColumnDisplayInfo.UsageStyle.Hidden,
        //                },
        //                Expr = new DmlfColumnRefExpression
        //                {
        //                    Column = new DmlfColumnRef
        //                    {
        //                        Source = pkt.Key,
        //                        ColumnName = col,
        //                    }
        //                }
        //            };
        //            Columns.Add(nc);
        //        }
        //    }
        //}

        public override void GenSql(ISqlDumper dmp)
        {
            dmp.Put("^select ");
            if (TopRecords != null)
            {
                dmp.Put("^top %s ", TopRecords);
            }
            if (Distinct)
            {
                dmp.Put(" ^distinct ");
            }
            if (SelectAll)
            {
                dmp.Put("* ");
            }
            else
            {
                Columns.GenSql(dmp);
            }

            if (SelectIntoTable != null)
            {
                dmp.Put("&n^into %f ", SelectIntoTable);
            }

            GenerateFrom(dmp);

            if (Where != null) Where.GenSql(dmp);
            if (GroupBy != null && GroupBy.Count > 0)
            {
                dmp.Put("&n^group ^by ");
                GroupBy.GenSql(dmp);
            }
            if (Having != null) Having.GenSql(dmp);
            if (OrderBy != null && OrderBy.Count > 0)
            {
                dmp.Put(" ^order ^by ");
                OrderBy.GenSql(dmp);
            }
            if (LimitCount != null)
            {
                dmp.Put(" ^limit %s ^offset %s", LimitCount, Offset);
            }
        }

        //public void GenSqlCount(ISqlDumper dmp, IDmlfHandler handler)
        //{
        //    dmp.Put("^select ^count(*) ");
        //    From.GenSql(dmp, handler);
        //}

        private string GetUniqueName(HashSet<string> used, string baseName)
        {
            if (!used.Contains(baseName)) return baseName;
            int index = 2;
            while (used.Contains(baseName + "_" + index)) index++;
            return baseName + "_" + index;
        }

        public void MakeUniqueResultAliases()
        {
            var used = new HashSet<string>();
            foreach (var col in Columns)
            {
                string name = col.GetResultName();
                if (name == null || used.Contains(name))
                {
                    col.Alias = GetUniqueName(used, name ?? "COLUMN");
                    used.Add(col.Alias);
                }
                else
                {
                    used.Add(name);
                }
            }
        }

        public override void ForEachChild(Action<IDmlfNode> action)
        {
            base.ForEachChild(action);
            Columns.ForEach(x=>x.ForEachChild(action));
            if (OrderBy != null) OrderBy.ForEach(x => x.ForEachChild(action));
            if (GroupBy != null) GroupBy.ForEach(x => x.ForEachChild(action));
        }
    }
}
