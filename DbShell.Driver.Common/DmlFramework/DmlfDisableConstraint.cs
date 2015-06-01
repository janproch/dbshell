using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.DmlFramework
{
    public class DmlfDisableConstraint : DmlfBase
    {
        [XmlElem]
        public NameWithSchema TableName { get; set; }

        [XmlElem]
        public string ConstraintName { get; set; }

        [XmlElem]
        public bool Disable { get; set; }

        public override void GenSql(AbstractDb.ISqlDumper dmp, IDmlfHandler handler)
        {
            dmp.PutCmd("^alter ^table %f %k ^constraint %i", TableName, Disable ? "nocheck" : "check", ConstraintName);
        }
    }
}
