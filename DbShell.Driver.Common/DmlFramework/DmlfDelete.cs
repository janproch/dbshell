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

        public override void GenSql(ISqlDumper dmp)
        {
            dmp.Put("^delete ");
            if (TopRecords != null) dmp.Put("^top(%s) ", TopRecords);

            if (dmp.Factory.DialectCaps.AllowDeleteFrom)
            {
                if (DeleteTarget != null) DeleteTarget.GenSqlRef(dmp);
                GenerateFrom(dmp);
            }
            else
            {
                dmp.Put("^from ");
                if (DeleteTarget != null) DeleteTarget.GenSqlRef(dmp);
            }

            if (Where != null) Where.GenSql(dmp);
        }

        public override void ForEachChild(Action<IDmlfNode> action)
        {
            base.ForEachChild(action);
            if (DeleteTarget != null) DeleteTarget.ForEachChild(action);
        }
    }
}
