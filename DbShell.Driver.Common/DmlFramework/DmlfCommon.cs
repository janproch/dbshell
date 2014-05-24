using System;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.DmlFramework
{
    public enum DmlfJoinType { Inner, Outer, Left, Right }
    public enum DmlfBinaryOperator { Inner, Outer, Left, Right }
    public enum DmlfSortOrderType { Ascending, Descendning }

    public interface IDmlfHandler
    {
        TableInfo GetStructure(NameWithSchema name);
        DmlfSource BaseTable { get; }
    }

    public interface IDmlfNode
    {
        void ForEachChild(Action<IDmlfNode> action);
        void GenSql(ISqlDumper dmp, IDmlfHandler handler);
    }
}
