using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.DmlFramework
{
    public class DmlfAllowIdentityInsert : DmlfBase
    {
        [XmlElem]
        public NameWithSchema TableName { get; set; }

        [XmlElem]
        public bool AllowIdentityInsert { get; set; }

        public override void GenSql(ISqlDumper dmp)
        {
            dmp.AllowIdentityInsert(TableName, AllowIdentityInsert);
        }
    }
}
