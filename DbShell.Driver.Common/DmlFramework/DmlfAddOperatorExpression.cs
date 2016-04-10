using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;

namespace DbShell.Driver.Common.DmlFramework
{
    public class DmlfAddOperatorExpression : DmlfExpression
    {
        public List<DmlfExpression> Items = new List<DmlfExpression>();

        public override void ForEachChild(Action<IDmlfNode> action)
        {
            base.ForEachChild(action);
            Items.ForEach(action);
        }

        public override void GenSql(ISqlDumper dmp)
        {
            dmp.Put("(");
            bool was = false;
            foreach(var item in Items)
            {
                if (was) dmp.Put("+");
                item.GenSql(dmp);
                was = true;
            }
            dmp.Put(")");
        }

        protected override string GetTypeName() => "add_op";
    }
}
