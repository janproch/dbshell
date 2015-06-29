using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.CommonDataLayer
{
    public class CdlDataColumnInfo
    {
        public NameWithSchema TableName;
        public string TableColumnName;

        public bool MatchTableName(NameWithSchema tableName)
        {
            if (tableName == null) return false;
            if (TableName == null) return false;
            if (TableName.Schema == null) return System.String.Compare(TableName.Name ?? "", tableName.Name ?? "", System.StringComparison.OrdinalIgnoreCase) == 0;
            return String.Compare(TableName.Schema ?? "", tableName.Schema ?? "", System.StringComparison.OrdinalIgnoreCase) == 0
                   && System.String.Compare(TableName.Name ?? "", tableName.Name ?? "", System.StringComparison.OrdinalIgnoreCase) == 0;
        }
    }
}
