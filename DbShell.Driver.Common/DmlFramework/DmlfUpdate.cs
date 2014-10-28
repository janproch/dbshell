using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.DmlFramework
{
    public class DmlfUpdate : DmlfCommandBase
    {
        public int? TopRecords;

        [XmlCollection(typeof(DmlfUpdateField))]
        public DmlfUpdateFieldCollection Columns { get; set; }

        [XmlSubElem]
        public DmlfSource UpdateTarget { get; set; }

        public DmlfUpdate()
        {
            Columns = new DmlfUpdateFieldCollection();
        }

        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            dmp.Put("^update ");
            if (TopRecords != null) dmp.Put("^top(%s) ", TopRecords);
            if (UpdateTarget != null) UpdateTarget.GenSqlRef(dmp, handler);
            dmp.Put("&n^set ");
            Columns.GenSql(dmp, handler);

            GenerateFrom(dmp, handler);
            if (Where != null) Where.GenSql(dmp, handler);
        }

    }
}
