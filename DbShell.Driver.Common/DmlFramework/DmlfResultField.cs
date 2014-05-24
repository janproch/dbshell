using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.DmlFramework
{
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
}