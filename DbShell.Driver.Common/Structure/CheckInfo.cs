using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.Structure
{
    public class CheckInfo : ConstraintInfo
    {
        [XmlElem]
        public string Definition { get; set; }

        public CheckInfo(TableInfo table)
            : base(table)
        {
        }

        public override DatabaseObjectType ObjectType
        {
            get { return DatabaseObjectType.Check; }
        }

        public override void SetDummyTable(NameWithSchema name)
        {
            var table = new TableInfo(null);
            table.FullName = name;
            table.Checks.Add(this);
        }

        public override void Assign(DatabaseObjectInfo source)
        {
            base.Assign(source);
            var src = (CheckInfo) source;
            Definition = src.Definition;
        }

        public CheckInfo CloneCheck(TableInfo ownTable = null)
        {
            var res = new CheckInfo(ownTable ?? OwnerTable);
            res.Assign(this);
            return res;
        }

        public override DatabaseObjectInfo CloneObject(DatabaseObjectInfo owner)
        {
            return CloneCheck(owner as TableInfo);
        }
    }
}
