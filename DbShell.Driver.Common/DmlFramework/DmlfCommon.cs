using System;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.DmlFramework
{
    public enum DmlfJoinType { Inner, Outer, Left, Right, CrossApply, OuterApply }
    public enum DmlfBinaryOperator { Inner, Outer, Left, Right }
    public enum DmlfSortOrderType { Ascending, Descending }

    //public interface IDmlfHandler
    //{
    //    TableInfo GetStructure(NameWithSchema name);
    //    DmlfSource BaseTable { get; }
    //    object GetValue(string variable);
    //}

    public interface IDmlfNamespace
    {
        object GetValue(string variable);
    }

    public class DmlfSingleValueNamespace : IDmlfNamespace
    {
        public object Value;

        public DmlfSingleValueNamespace(object value)
        {
            Value = value;
        }

        public object GetValue(string variable)
        {
            return Value;
        }
    }

    public interface IDmlfNode
    {
        void ForEachChild(Action<IDmlfNode> action);
        void GenSql(ISqlDumper dmp);
    }
}
