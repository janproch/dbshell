using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.DmlFramework
{
    public class DmlfInsert : DmlfBase
    {
        [XmlSubElem]
        public NameWithSchema InsertTarget { get; set; }

        [XmlCollection(typeof (DmlfUpdateField))]
        public DmlfUpdateFieldCollection Columns { get; set; }

        public DmlfInsert()
        {
            Columns = new DmlfUpdateFieldCollection();
        }

        public override void GenSql(ISqlDumper dmp)
        {
            dmp.Put("^insert ^into  %f ", InsertTarget);
            dmp.Put("(%,i) ^ values (", Columns.Select(x => x.TargetColumn));
            for (int i = 0; i < Columns.Count; i++)
            {
                if (i > 0) dmp.WriteRaw(", ");
                Columns[i].Expr.GenSql(dmp);
            }
            dmp.Put(")");
            dmp.EndCommand();
        }
    }
}
