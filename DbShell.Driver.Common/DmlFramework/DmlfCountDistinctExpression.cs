using System.Xml;
using DbShell.Driver.Common.AbstractDb;

namespace DbShell.Driver.Common.DmlFramework
{
    public class DmlfCountDistinctExpression : DmlfExpression
    {
        public DmlfExpression Argument;

        public DmlfCountDistinctExpression(DmlfExpression arg)
        {
            Argument = arg;
        }

        public DmlfCountDistinctExpression()
        {
        }

        public DmlfCountDistinctExpression(XmlElement xml)
        {
            LoadFromXml(xml);
        }

        public override int GetHashCode()
        {
            return Argument.GetHashCode();
        }

        public override bool DmlfEquals(DmlfBase obj)
        {
            var o = (DmlfCountDistinctExpression) obj;
            if (!Argument.DmlfEquals(o.Argument)) return false;
            return true;
        }

        public override void GenSql(ISqlDumper dmp)
        {
            dmp.Put("^count(^distinct ");
            Argument.GenSql(dmp);
            dmp.Put(")");
        }

        protected override string GetTypeName()
        {
            return "count_distinct";
        }
    }
}