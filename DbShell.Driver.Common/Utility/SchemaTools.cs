using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Structure;

#if !NETSTANDARD2_0

namespace DbShell.Driver.Common.Utility
{
    public static class SchemaTools
    {
        public static DataTable CreateEmptySchema()
        {
            DataTable schema = new DataTable();

            schema.Columns.Add(SchemaTableColumn.ColumnName, typeof(String));
            schema.Columns.Add(SchemaTableColumn.ColumnOrdinal, typeof(Int32));
            schema.Columns.Add(SchemaTableColumn.ColumnSize, typeof(Int32));
            schema.Columns.Add(SchemaTableColumn.NumericPrecision, typeof(Int32));
            schema.Columns.Add(SchemaTableColumn.NumericScale, typeof(Int32));
            schema.Columns.Add(SchemaTableColumn.DataType, typeof(Type));
            schema.Columns.Add(SchemaTableColumn.ProviderType, typeof(Int32));
            schema.Columns.Add(SchemaTableColumn.IsLong, typeof(Boolean));
            schema.Columns.Add(SchemaTableColumn.AllowDBNull, typeof(Boolean));
            schema.Columns.Add(SchemaTableOptionalColumn.IsReadOnly, typeof(Boolean));
            schema.Columns.Add(SchemaTableOptionalColumn.IsRowVersion, typeof(Boolean));
            schema.Columns.Add(SchemaTableColumn.IsUnique, typeof(Boolean));
            schema.Columns.Add(SchemaTableColumn.IsKey, typeof(Boolean));
            schema.Columns.Add(SchemaTableOptionalColumn.IsAutoIncrement, typeof(Boolean));
            schema.Columns.Add(SchemaTableColumn.BaseSchemaName, typeof(String));
            schema.Columns.Add(SchemaTableOptionalColumn.BaseCatalogName, typeof(String));
            schema.Columns.Add(SchemaTableColumn.BaseTableName, typeof(String));
            schema.Columns.Add(SchemaTableColumn.BaseColumnName, typeof(String));

            return schema;
        }

        public static DataTable SchemaFromStructure(this TableInfo tableStruct)
        {
            DataTable schema = CreateEmptySchema();
            int index = 1;
            foreach (var col in tableStruct.Columns)
            {
                DataRow row = schema.NewRow();

                row[SchemaTableColumn.ColumnName] = col.Name;
                row[SchemaTableColumn.ColumnOrdinal] = index;
                row[SchemaTableColumn.ColumnSize] = 0;
                row[SchemaTableColumn.NumericPrecision] = 0;
                row[SchemaTableColumn.NumericScale] = 0;
                row[SchemaTableColumn.DataType] = col.CommonType.DotNetType;
                row[SchemaTableColumn.ProviderType] = (int)TypeTool.GetProviderType(col.CommonType.DotNetType);
                row[SchemaTableColumn.IsLong] = false;
                row[SchemaTableColumn.AllowDBNull] = true;
                row[SchemaTableOptionalColumn.IsReadOnly] = false;
                row[SchemaTableOptionalColumn.IsRowVersion] = false;
                row[SchemaTableColumn.IsUnique] = false;
                row[SchemaTableColumn.IsKey] = false;
                row[SchemaTableOptionalColumn.IsAutoIncrement] = false;
                row[SchemaTableColumn.BaseSchemaName] = "";
                row[SchemaTableOptionalColumn.BaseCatalogName] = "";
                row[SchemaTableColumn.BaseTableName] = "";
                row[SchemaTableColumn.BaseColumnName] = col.Name;

                schema.Rows.Add(row);

                index++;
            }
            return schema;
        }
    }
}

#endif