using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.DmlFramework
{
    public class DmlfBatch : DmlfBase
    {
        public List<DmlfBase> Commands = new List<DmlfBase>();

        public override void ForEachChild(Action<IDmlfNode> action)
        {
            base.ForEachChild(action);
            Commands.ForEach(action);
        }

        public override void GenSql(AbstractDb.ISqlDumper dmp)
        {
            Commands.ForEach(x =>
                {
                    x.GenSql(dmp);
                    dmp.EndCommand();
                });
        }

        public void AllowIdentityInsert(NameWithSchema tableName, bool allow)
        {
            Commands.Add(new DmlfAllowIdentityInsert
                {
                    TableName = tableName,
                    AllowIdentityInsert = allow,
                });
        }

        public void DisableConstraint(NameWithSchema tableName, string constraintName, bool disable)
        {
            Commands.Add(new DmlfDisableConstraint
                {
                    TableName = tableName,
                    ConstraintName = constraintName,
                    Disable = disable
                });
        }
    }
}
