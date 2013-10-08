using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.DmlFramework;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.Structure
{
    public class QueryResultInfo
    {
        public List<QueryResultColumnInfo> Columns = new List<QueryResultColumnInfo>();

        public TableInfo ToTableInfo()
        {
            var res = new TableInfo(new DatabaseInfo());
            var pk = new PrimaryKeyInfo(res);

            string table = null, schema = null;
            foreach (var column in Columns)
            {
                if (column.BaseTableName != null)
                {
                    if (table == null)
                    {
                        table = column.BaseTableName;
                    }
                    else if (table != column.BaseTableName)
                    {
                        table = null;
                        schema = null;
                        break;
                    }
                }
                if (column.BaseSchemaName != null)
                {
                    if (schema == null)
                    {
                        schema = column.BaseSchemaName;
                    }
                    else if (schema != column.BaseSchemaName)
                    {
                        table = null;
                        schema = null;
                        break;
                    }
                }
            }

            if (table != null) res.FullName = new NameWithSchema(schema, table);

            foreach (var column in Columns)
            {
                if (column.IsHidden) continue;

                var col = new ColumnInfo(res)
                    {
                        Name = column.Name,
                        NotNull = column.NotNull,
                        CommonType = column.CommonType.Clone(),
                        DataType = column.DataType,
                        AutoIncrement = column.AutoIncrement,
                        PrimaryKey = column.IsKey,
                    };
                if (col.CommonType is DbTypeString) col.Length = column.Size;

                if (column.AutoIncrement && col.CommonType != null)
                {
                    col.CommonType.SetAutoincrement(true);
                }

                if (column.IsKey && res.FullName != null)
                {
                    pk.Columns.Add(new ColumnReference {RefColumn = col});
                }
                res.Columns.Add(col);
            }
            if (pk.Columns.Count > 0) res.PrimaryKey = pk;
            return res;
        }
    }
}
