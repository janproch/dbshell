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
        [XmlCollection(typeof (QueryResultColumnInfo))]
        public List<QueryResultColumnInfo> Columns { get; set; } 

        public QueryResultInfo()
        {
            Columns = new List<QueryResultColumnInfo>();
        }

        public TableInfo ToTableInfo(bool includeHiddenColumns = false)
        {
            var res = new TableInfo(new DatabaseInfo());
            var pk = new PrimaryKeyInfo(res);

            var tableNames = Columns.Select(x => x.BaseTableName).Where(x => x != null).Distinct().ToList();
            var schemaNames = Columns.Select(x => x.BaseSchemaName).Where(x => x != null).Distinct().ToList();

            if (tableNames.Count == 1 && schemaNames.Count <= 1)
            {
                res.FullName = new NameWithSchema(schemaNames.FirstOrDefault(), tableNames.Single());
            }

            foreach (var column in Columns)
            {
                if (column.IsHidden && !includeHiddenColumns) continue;

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

        public QueryResultInfo Clone()
        {
            var res = new QueryResultInfo();
            res.Assign(this);
            return res;
        }

        private void Assign(QueryResultInfo source)
        {
            foreach(var item in source.Columns)
            {
                Columns.Add(item.Clone());
            }
        }
    }
}
