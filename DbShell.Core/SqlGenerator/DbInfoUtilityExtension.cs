using DbShell.Driver.Common.Structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.Core.NetCore.SqlGenerator
{
    public static class DbInfoUtilityExtension
    {
        public static TableInfo WithoutReferences(this TableInfo table)
        {
            table = table.CloneTable();
            table.ForeignKeys.Clear();
            return table;
        }

        public static TableInfo WithoutIndexes(this TableInfo table)
        {
            table = table.CloneTable();
            table.Indexes.Clear();
            return table;
        }
    }
}
