using DbShell.Driver.Common.AbstractDb;

namespace DbShell.Driver.Common.DmlFramework
{
    public class DmlfWhere : DmlfBase
    {
        public DmlfConditionBase Condition;

        public override void GenSql(ISqlDumper dmp)
        {
            if (Condition != null)
            {
                dmp.Put("&n^where &>");
                Condition.GenSql(dmp);
                dmp.Put("&<");
            }
        }

        public override void ForEachChild(System.Action<IDmlfNode> action)
        {
            base.ForEachChild(action);
            if (Condition != null) Condition.ForEachChild(action);
        }
    }
}