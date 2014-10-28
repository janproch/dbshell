using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.DmlFramework
{
    public class DmlfDelete : DmlfCommandBase
    {
        public int? TopRecords;

        [XmlSubElem]
        public DmlfSource DeleteTarget { get; set; }

        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            dmp.Put("^delete ");
            if (TopRecords != null) dmp.Put("^top(%s) ", TopRecords);
            if (DeleteTarget != null) DeleteTarget.GenSqlRef(dmp, handler);

            GenerateFrom(dmp, handler);

            if (Where != null) Where.GenSql(dmp, handler);
        }
    }
}
