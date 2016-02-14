using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.DmlFramework
{
    public class DmlfInsertSelect : DmlfBase
    {
        [XmlElem]
        public NameWithSchema TargetTable { get; set; }

        [XmlSubElem]
        public LinkedDatabaseInfo LinkedInfo { get; set; }

        [XmlCollection(typeof (string))]
        public List<string> TargetColumns { get; set; }

        [XmlSubElem]
        public DmlfSelect Select { get; set; }

        public DmlfInsertSelect()
        {
            TargetColumns = new List<string>();
        }

        public override void GenSql(AbstractDb.ISqlDumper dmp)
        {
            dmp.Put("^insert ^into %l%f (%,i)&n", LinkedInfo, TargetTable, TargetColumns);
            Select.GenSql(dmp);
        }
    }
}
