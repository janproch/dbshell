using System.Collections.Generic;
using System.Linq;

namespace DbShell.Driver.Common.Structure
{
    public static class ColumnInfoExtension
    {
        public static string[] GetNames(this IEnumerable<ColumnInfo> cols)
        {
            return new List<string>(from c in cols select c.Name).ToArray();
        }
        public static string[] GetNames(this IEnumerable<ColumnReference> refs)
        {
            return new List<string>(from c in refs select c.RefColumn.Name).ToArray();
        }
    }
}