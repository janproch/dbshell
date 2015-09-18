using DbShell.Driver.Common.AbstractDb;

namespace DbShell.Driver.Common.DmlFramework
{
    public class DmlfHaving : DmlfBase
    {
        public DmlfConditionBase Condition;

        public override void GenSql(ISqlDumper dmp)
        {
            if (Condition != null)
            {
                dmp.Put("&n^having &>");
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