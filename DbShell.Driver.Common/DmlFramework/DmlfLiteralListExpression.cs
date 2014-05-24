using System.Collections.Generic;
using DbShell.Driver.Common.AbstractDb;

namespace DbShell.Driver.Common.DmlFramework
{
    public class DmlfLiteralListExpression : DmlfExpression
    {
        public List<object> Values = new List<object>();

        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            dmp.Put("(%,v)", Values);
        }

        protected override string GetTypeName()
        {
            return "lit_list";
        }

    }
}