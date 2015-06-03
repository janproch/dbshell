using DbShell.Driver.Common.AbstractDb;

namespace DbShell.Driver.Common.DmlFramework
{
    public class DmlfSubSelectExpression : DmlfExpression
    {
        public DmlfSelect Select { get; set; }

        protected override string GetTypeName()
        {
            return "subselect";
        }

        public override void GenSql(ISqlDumper dmp)
        {
            dmp.Put("(");
            Select.GenSql(dmp);
            dmp.Put(")");
        }
    }
}