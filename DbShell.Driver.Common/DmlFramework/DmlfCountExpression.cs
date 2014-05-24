using System.Xml;
using DbShell.Driver.Common.AbstractDb;

namespace DbShell.Driver.Common.DmlFramework
{
    public class DmlfCountExpression : DmlfExpression
    {
        public DmlfCountExpression() { }
        public DmlfCountExpression(XmlElement xml)
        {
            LoadFromXml(xml);
        }

        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            dmp.Put("^count(*)");
        }

        public override string ToString()
        {
            return "COUNT(*)";
        }

        protected override string GetTypeName()
        {
            return "count";
        }

        public override int GetHashCode()
        {
            return 0;
        }
    }
}