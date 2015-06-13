using DbShell.Driver.Common.DmlFramework;

namespace DbShell.Driver.Common.ChangeSet
{
    public class ChangeSetCompiledCondition
    {
        public int ColumnIndex;
        public DmlfConditionBase Expression;
    }
}