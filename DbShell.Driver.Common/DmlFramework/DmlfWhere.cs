using DbShell.Driver.Common.AbstractDb;

namespace DbShell.Driver.Common.DmlFramework
{
    public class DmlfWhere : DmlfBase
    {
        public DmlfConditionBase Condition;

        public override void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            if (Condition != null)
            {
                dmp.Put("&n^where &>");
                Condition.GenSql(dmp, handler);
                dmp.Put("&<");
            }
        }
    }
}