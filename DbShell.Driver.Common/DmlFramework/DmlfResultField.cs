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

        private string _alias;
        [XmlElem]
        public string Alias
        {
            get { return _alias; }
            set
            {
                _alias = value;
                if (_alias.IsEmpty()) _alias = null;
            }
        }
        //[XmlSubElem]
        //public ColumnDisplayInfo DisplayInfo { get; set; }

        public QueryResultColumnInfo ResultInfo { get; set; }

        public override void GenSql(ISqlDumper dmp)
        {
            Expr.GenSql(dmp);
            if (_alias != null)
            {
                dmp.Put(" ^as %i", _alias);
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
                if (_alias != null) return _alias;
                var col = Column;
                if (col != null) return col.ColumnName;
                return "";
            }
        }
    }
}