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

        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            dmp.Put("(");
            Select.GenSql(dmp, handler);
            dmp.Put(")");
        }
    }
}