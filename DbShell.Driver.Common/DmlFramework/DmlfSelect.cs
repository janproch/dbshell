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

        public DmlfFromItem SingleFrom
        {
            get
            {
                if (From.Count == 0) From.Add(new DmlfFromItem());
                if (From.Count > 1) throw new Exception("DBSH-00000 internal error");
                return From[0];
            }
            set
            {
                From.Clear();
                From.Add(value);
            }
        }

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

        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
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
                Columns.GenSql(dmp, handler);
            }

            if (SelectIntoTable != null)
            {
                dmp.Put("&n^into %f ", SelectIntoTable);
            }

            GenerateFrom(dmp, handler);

            if (Where != null) Where.GenSql(dmp, handler);
            if (GroupBy != null && GroupBy.Count > 0)
            {
                dmp.Put("&n^group ^by ");
                GroupBy.GenSql(dmp, handler);
            }
            if (OrderBy != null && OrderBy.Count > 0)
            {
                dmp.Put(" ^order ^by ");
                OrderBy.GenSql(dmp, handler);
            }
            if (LimitCount != null)
            {
                dmp.Put(" ^limit %s,%s", Offset, LimitCount);
            }
        }

        //public void GenSqlCount(ISqlDumper dmp, IDmlfHandler handler)
        //{
        //    dmp.Put("^select ^count(*) ");
        //    From.GenSql(dmp, handler);
        //}
    }

}
