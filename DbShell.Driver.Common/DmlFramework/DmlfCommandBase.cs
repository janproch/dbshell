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

        protected void GenerateFrom(ISqlDumper dmp)
        {
            dmp.Put("&n^from &>");

            bool wasfromItem = false;
            foreach (var fromItem in From)
            {
                if (wasfromItem) dmp.Put(",&n");
                fromItem.GenSql(dmp);
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
                    ((DmlfAndCondition) Where.Condition).Conditions.Add(cond);
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

        public bool IsSingleFromTable
        {
            get { return From.Count == 1 && !From[0].Relations.Any() && From[0].Source.IsSimpleSource; }
        }

        public void SimplifyFromAliases()
        {
            if (IsSingleFromTable)
            {
                var source = From[0].Source;
                ReplaceSimpleSource(source, null);
            }
            else
            {
                var sources = new HashSet<DmlfSource>();
                From.ForEach(x => x.GetSimpleSources(sources));

                var usedAliases = new HashSet<string>();

                foreach (var source in sources)
                {
                    if (sources.Count(x => x.TableOrView == source.TableOrView) == 1)
                    {
                        // use table name as qualifier, remove alias
                        ReplaceSimpleSource(source, null);
                    }
                    else
                    {
                        var aliasBase = DmlfSource.GetAliasBase(source.TableOrView.Name);
                        string alias = DmlfSource.AllocateAlias(usedAliases, aliasBase);
                        ReplaceSimpleSource(source, alias);
                    }
                }
            }
        }

        public override void ForEachChild(Action<IDmlfNode> action)
        {
            base.ForEachChild(action);
            if (Where != null) Where.ForEachChild(action);
            From.ForEach(x => x.ForEachChild(action));
        }

        public void ReplaceSimpleSource(DmlfSource source, string newAlias)
        {
            source = source.GetSimpleSourceCopy();
            ForEachChild(x =>
                {
                    var src = x as DmlfSource;
                    if (src != null && src == source)
                    {
                        src.Alias = newAlias;
                    }
                });
        }
    }
}
