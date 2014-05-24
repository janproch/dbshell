using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;

namespace DbShell.Driver.Common.DmlFramework
{
    public class DmlfUpdateField : DmlfExpressionHolder
    {
        public string TargetColumn { get; set; }

        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            dmp.Put("%i = ", TargetColumn);
            Expr.GenSql(dmp, handler);
        }

    }
}
