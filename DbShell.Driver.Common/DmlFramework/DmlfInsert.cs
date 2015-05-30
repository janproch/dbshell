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
        public DmlfSource InsertTarget { get; set; }

        [XmlCollection(typeof (DmlfUpdateField))]
        public DmlfUpdateFieldCollection Columns { get; set; }

        [XmlElem]
        public NameWithSchema IdentityInsertTable { get; set; }

        public DmlfInsert()
        {
            Columns = new DmlfUpdateFieldCollection();
        }

        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            if (IdentityInsertTable != null)
            {
                dmp.AllowIdentityInsert(IdentityInsertTable, true);
            }

            dmp.Put("^insert ^into  ");
            if (InsertTarget != null) InsertTarget.GenSqlDef(dmp, handler);

            dmp.Put(" (%,i) ^ values (", Columns.Select(x => x.TargetColumn));
            for (int i = 0; i < Columns.Count; i++)
            {
                if (i > 0) dmp.WriteRaw(", ");
                Columns[i].Expr.GenSql(dmp, handler);
            }
            dmp.Put(")");
            dmp.EndCommand();

            if (IdentityInsertTable != null)
            {
                dmp.AllowIdentityInsert(IdentityInsertTable, false);
            }
        }
    }
}
