using System.Collections.Generic;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.Structure
{
    public class ColumnList : List<ColumnInfo>
    {
        public int GetIndex(string name)
        {
            return this.IndexOfIf(c => c.Name == name);
        }

        public ColumnInfo this[string name]
        {
            get
            {
                int index = GetIndex(name);
                if (index < 0) return null;
                return this[index];
            }
        }
    }
}