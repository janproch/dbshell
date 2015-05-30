using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.DmlFramework
{
    public abstract class DmlfCommandBase : DmlfBase
    {
        [XmlSubElem]
        public List<DmlfFromItem> From { get; set; }

        [XmlSubElem]
        public DmlfWhere Where { get; set; }

        protected DmlfCommandBase()
        {
            From = new List<DmlfFromItem>();
        }

        protected void GenerateFrom(ISqlDumper dmp, IDmlfHandler handler)
        {
            dmp.Put("&n^from &>");

            bool wasfromItem = false;
            foreach (var fromItem in From)
            {
                if (wasfromItem) dmp.Put(",&n");
                fromItem.GenSql(dmp, handler);
                wasfromItem = true;
            }
            dmp.Put("&<");
        }

        public void AddAndCondition(DmlfConditionBase cond)
        {
            if (cond == null) return;
            if (Where == null) Where = new DmlfWhere();
            if (Where.Condition != null)
            {
                if (Where.Condition is DmlfAndCondition)
                {
                    ((DmlfAndCondition)Where.Condition).Conditions.Add(cond);
                }
                else
                {
                    var and = new DmlfAndCondition();
                    and.Conditions.Add(Where.Condition);
                    and.Conditions.Add(cond);
                    Where.Condition = and;
                }
            }
            else
            {
                Where.Condition = cond;
            }
        }

        public DmlfFromItem SingleFrom
        {
            get
            {
                if (From.Count == 0) From.Add(new DmlfFromItem());
                if (From.Count > 1) throw new Exception("DBSH-00158 internal error");
                return From[0];
            }
            set
            {
                From.Clear();
                From.Add(value);
            }
        }
    }
}
