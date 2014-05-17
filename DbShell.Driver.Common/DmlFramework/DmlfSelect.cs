using System;
using System.Collections.Generic;
using System.Xml;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Sql;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.DmlFramework
{
    public class DmlfSelect : DmlfBase
    {
        [XmlCollection(typeof (DmlfResultField))]
        public DmlfResultFieldCollection Columns { get; set; }

        [XmlSubElem]
        public List<DmlfFromItem> From { get; set; }

        [XmlSubElem]
        public DmlfSortOrderCollection OrderBy { get; set; }

        [XmlSubElem]
        public DmlfWhere Where { get; set; }

        [XmlElem]
        public int? TopRecords { get; set; }

        [XmlElem]
        public int? LimitCount { get; set; }

        [XmlElem]
        public int Offset { get; set; }

        [XmlElem]
        public bool SelectAll { get; set; }

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
            From = new List<DmlfFromItem>();
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
            if (SelectAll)
            {
                dmp.Put("* ");
            }
            else
            {
                Columns.GenSql(dmp, handler);
            }
            dmp.Put("&n^from &>");

            bool wasfromItem = false;
            foreach (var fromItem in From)
            {
                if (wasfromItem) dmp.Put(",&n");
                fromItem.GenSql(dmp, handler);
                wasfromItem = true;
            }
            dmp.Put("&<");

            if (Where != null) Where.GenSql(dmp, handler);
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

        public void AddAndCondition(DmlfConditionBase cond)
        {
            if (cond == null) return;
            if (Where == null) Where = new DmlfWhere();
            if (Where.Condition != null)
            {
                if (Where.Condition is DmlfAndCondition)
                {
                    ((DmlfAndCondition) Where.Condition).Conditions.Add(cond);
                }
                else
                {
                    var and = new DmlfAndCondition();
                    and.Conditions.Add(Where.Condition);
                    and.Conditions.Add(cond);
                    Where.Condition = and;
                }
            }
            else
            {
                Where.Condition = cond;
            }
        }
    }

    public class DmlfExpressionHolderCollection<T> : DmlfList<T>
        where T : DmlfExpressionHolder
    {
        public bool IsMultiTable()
        {
            DmlfSource lastsrc = null;
            foreach (var col in this)
            {
                if (col.Source != null)
                {
                    if (lastsrc != null && col.Source != lastsrc) return true;
                    lastsrc = col.Source;
                }
            }
            return false;
        }

        public int GetColumnIndex(DmlfColumnRef col)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Column == col) return i;
            }
            return -1;
        }

        public int GetExpressionIndex(DmlfExpression expr)
        {
            for (int i = 0; i < Count; i++)
            {
                if (this[i].Expr == expr) return i;
            }
            return -1;
        }
    }

    public class DmlfResultFieldCollection : DmlfExpressionHolderCollection<DmlfResultField>
    {
        public List<DmlfColumnRef> GetPrimaryKey(DmlfSource src)
        {
            var res = new List<DmlfColumnRef>();
            foreach (var fld in this)
            {
                var col = fld.Column;
                if (col != null && fld.ResultInfo != null && fld.ResultInfo.IsKey && col.Source == src) res.Add(col);
            }
            return res;
        }

        public List<string> GetBaseColumns()
        {
            var res = new List<string>();
            foreach (var col in this)
            {
                if (col.Source != DmlfSource.BaseTable) continue;
                if (col.Column == null) continue;
                res.Add(col.Column.ColumnName);
            }
            return res;
        }

        /// <summary>
        /// normaliuze DmlfColumnRef.Source property to DmlfSource.BaseTable, if it denotes base table
        /// </summary>
        public void NormalizeBaseTables()
        {
            foreach (var fld in this)
            {
                var col = fld.Column;
                if (col == null) continue;
                if (col.Source == null || col.Source.Alias == "basetbl") col.Source = DmlfSource.BaseTable;
            }
        }

        //public void SplitVisible(out DmlfResultFieldCollection visCols, out DmlfResultFieldCollection hidCols)
        //{
        //    visCols = new DmlfResultFieldCollection();
        //    hidCols = new DmlfResultFieldCollection();
        //    foreach (var fld in this)
        //    {
        //        if (fld.DisplayInfo.Style == ColumnDisplayInfo.UsageStyle.Value) visCols.Add(fld);
        //        else hidCols.Add(fld);
        //    }
        //}
    }

    public class DmlfExpressionHolder : DmlfBase
    {
        public DmlfExpression Expr { get; set; }

        public override void SaveToXml(XmlElement xml)
        {
            base.SaveToXml(xml);
            if (Expr != null) Expr.SaveToXml(xml.AddChild("Expr"));
        }

        public override void LoadFromXml(XmlElement xml)
        {
            base.LoadFromXml(xml);
            var xe = xml.FindElement("Expr");
            if (xe != null) Expr = DmlfExpression.Load(xe);
        }

        public override string ToString()
        {
            if (Expr != null) return Expr.ToString();
            return "(null)";
        }

        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            Expr.GenSql(dmp, handler);
        }

        public DmlfColumnRef Column
        {
            get
            {
                var ce = Expr as DmlfColumnRefExpression;
                if (ce != null) return ce.Column;
                return null;
            }
        }

        public DmlfSource Source
        {
            get
            {
                var col = Column;
                if (col != null) return col.Source;
                return null;
            }
        }
    }

    public class DmlfResultField : DmlfExpressionHolder
    {
        public DmlfResultField()
        {
            //DisplayInfo = new ColumnDisplayInfo();
        }

        private string m_alias;
        [XmlElem]
        public string Alias
        {
            get { return m_alias; }
            set
            {
                m_alias = value;
                if (m_alias.IsEmpty()) m_alias = null;
            }
        }
        //[XmlSubElem]
        //public ColumnDisplayInfo DisplayInfo { get; set; }

        public QueryResultColumnInfo ResultInfo { get; set; }

        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            Expr.GenSql(dmp, handler);
            if (m_alias != null)
            {
                dmp.Put(" ^as %i", m_alias);
            }
        }

        public static DmlfResultField BuildFromColumn(string colname)
        {
            return BuildFromColumn(colname, null);
        }

        public static DmlfResultField BuildFromColumn(string colname, DmlfSource src)
        {
            return new DmlfResultField
            {
                Expr = new DmlfColumnRefExpression
                {
                    Column = new DmlfColumnRef
                    {
                        ColumnName = colname,
                        Source = src,
                    }
                },
            };
        }

        public string HeaderTitle
        {
            get
            {
                if (m_alias != null) return m_alias;
                var col = Column;
                if (col != null) return col.ColumnName;
                return "";
            }
        }
    }

    public class DmlfFromItem : DmlfBase
    {
        public DmlfFromItem()
        {
            Relations = new DmlfRelationCollection();
        }

        /// <summary>
        /// can be null (implicit source), than Handler.GetStructure(null) must be implemented
        /// </summary>
        [XmlSubElem]
        public DmlfSource Source { get; set; }
        [XmlCollection(typeof(DmlfRelation), "Relations")]
        public DmlfRelationCollection Relations { get; set; }

        /// <summary>
        /// finds column in joined tables
        /// </summary>
        /// <param name="expr">column expression</param>
        /// <returns>column reference or null, if not found</returns>
        public DmlfColumnRef FindColumn(string expr)
        {
            return null;
        }

        public override void ForEachChild(Action<IDmlfNode> action)
        {
            base.ForEachChild(action);
            if (Source != null) Source.ForEachChild(action);
            if (Relations != null) Relations.ForEachChild(action);
        }

        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            var src = Source;
            if (src == null) src = handler.BaseTable;
            src.GenSqlDef(dmp, handler);
            dmp.Put(" ");
            Relations.GenSql(dmp, handler);
        }

        public DmlfSource FindSourceWithAlias(string alias)
        {
            if (Source != null && Source.Alias == alias) return Source;
            return Relations.FindSourceWithAlias(alias);
        }

        public IEnumerable<DmlfSource> GetAllSources()
        {
            if (Source != null) yield return Source;
            else yield return DmlfSource.BaseTable;
            foreach (var rel in Relations)
            {
                if (rel.Reference != null)
                {
                    yield return rel.Reference;
                }
            }
        }
    }

    public enum DmlfSortOrderType { Ascending, Descendning }

    public class DmlfSortOrderItem : DmlfExpressionHolder
    {
        public DmlfSortOrderType OrderType;

        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            Expr.GenSql(dmp, handler);
            dmp.Put(" ");
            OrderType.GenSql(dmp);
        }
    }

    public class DmlfSortOrderCollection : DmlfExpressionHolderCollection<DmlfSortOrderItem>
    {
        public static DmlfSortOrderCollection BuildFromExpression(DmlfExpression expr)
        {
            return new DmlfSortOrderCollection
            {
                new DmlfSortOrderItem
                {
                    Expr = expr,
                    OrderType = DmlfSortOrderType.Ascending
                }
            };
        }
    }

    public class DmlfWhere : DmlfBase
    {
        public DmlfConditionBase Condition;

        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            if (Condition != null)
            {
                dmp.Put("&n^where &>");
                Condition.GenSql(dmp, handler);
                dmp.Put("&<");
            }
        }
    }
}
