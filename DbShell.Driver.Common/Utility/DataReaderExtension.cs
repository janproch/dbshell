using System;
using System.Data;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.Utility
{
    public static class DataReaderExtension
    {
        public static DataTable DataTableFromStructure(TableInfo tableStruct)
        {
            DataTable table = new DataTable();
            foreach (var col in tableStruct.Columns)
            {
                DataColumn column = new DataColumn(col.Name, col.CommonType.DotNetType);
                table.Columns.Add(column);
            }
            return table;
        }

        public static DataTable ToDataTable(this IDataReader reader, int? maximumRecords)
        {
            TableInfo ts = reader.GetTableInfo();
            DataTable dt = DataTableFromStructure(ts);
            int allow_recs = maximumRecords != null ? maximumRecords.Value : -1;
            while (reader.Read() && (maximumRecords == null || allow_recs > 0))
            {
                DataRow row = dt.NewRow();
                for (int i = 0; i < ts.Columns.Count; i++)
                {
                    try
                    {
                        row[i] = reader[i];
                    }
                    catch (Exception)
                    {
                        row[i] = DBNull.Value;
                    }
                }
                dt.Rows.Add(row);
                allow_recs--;
            }
            return dt;
        }

        public static DataTable ToDataTable(this IDataReader reader)
        {
            return ToDataTable(reader, null);
        }

        public static DbTypeBase ReaderDataType(DataRow row)
        {
            try
            {
                string tp = row["DataTypeName"].SafeToString();
                if (tp == "xml") return new DbTypeXml();
                int size = row.SafeString("ColumnSize").SafeIntParse();
                if (tp == "varchar") return new DbTypeString {Length = size};
                if (tp == "nvarchar") return new DbTypeString {Length = size, IsUnicode = true};
                if (tp == "text") return new DbTypeText();
                if (tp == "ntext") return new DbTypeText {IsUnicode = true};
            }
            catch
            {
            }
            var clrType = row["DataType"] as Type;
            if (clrType != null) return clrType.GetCommonType();
            return new DbTypeString();
        }

        public static QueryResultInfo SchemaTableToInfo(DataTable schemaTable)
        {
            var res = new QueryResultInfo();
            foreach (DataRow row in schemaTable.Rows.SortedByKey<DataRow, int>(row => Int32.Parse(row["ColumnOrdinal"].ToString())))
            {
                var col = new QueryResultColumnInfo();
                int size = row.SafeString("ColumnSize").SafeIntParse();
                col.Name = row.SafeString("ColumnName");
                col.NotNull = !(bool)row["AllowDBNull"];
                col.DataType = row["DataTypeName"].SafeToString();
                col.Size = size;
                col.CommonType = ReaderDataType(row);

                col.BaseColumnName = row.SafeString("BaseColumnName");
                col.BaseSchemaName = row.SafeString("BaseSchemaName");
                col.BaseTableName = row .SafeString("BaseTableName");
                col.BaseServerName = row.SafeString("BaseServerName");
                col.BaseCatalogName = row.SafeString("BaseCatalogName");
                if (row.SafeBool("IsAutoIncrement", false))
                {
                    col.CommonType.SetAutoincrement(true);
                    col.AutoIncrement = true;
                }
                if (row.SafeBool("IsKey", false)) col.IsKey = true;
                if (row.SafeBool("IsHidden", false)) col.IsHidden = true;
                if (row.SafeBool("IsReadOnly", false)) col.IsReadOnly = true;
                if (row.SafeBool("IsAliased", false)) col.IsAliased = true;
                res.Columns.Add(col);
            }
            return res;
        }

        public static QueryResultInfo GetQueryResultInfo(this IDataReader reader)
        {
            DataTable columns;
            try
            {
                columns = reader.GetSchemaTable();
            }
            catch
            {
                return null;
            }
            if (columns == null) return null;
            return SchemaTableToInfo(columns);
        }

        public static TableInfo GetTableInfo(this IDataReader reader, bool includeHiddeColumns = false)
        {
            var info = reader.GetQueryResultInfo();
            if (info != null) return info.ToTableInfo(includeHiddeColumns);
            return null;
        }

        public static string[] GetFieldNames(this IDataRecord record)
        {
            string[] res = new string[record.FieldCount];
            for (int i = 0; i < res.Length; i++) res[i] = record.GetName(i);
            return res;
        }

        public static object[] GetValues(this IDataRecord record)
        {
            object[] values = new object[record.FieldCount];
            record.GetValues(values);
            return values;
        }

        public static object[] GetValuesByCols(this IDataRecord record, string[] cols)
        {
            object[] values = new object[cols.Length];
            for (int i = 0; i < cols.Length; i++) values[i] = record[cols[i]];
            return values;
        }

        public static string SafeString(this IDataRecord record, string field)
        {
            try
            {
                int ord = record.GetOrdinal(field);
                if (ord >= 0) return record[ord].SafeToString();
                return null;
            }
            catch
            {
                return null;
            }
        }

        public static string SafeString(this IDataRecord record, params string[] fieldVariants)
        {
            foreach (string field in fieldVariants)
            {
                try
                {
                    int ord = record.GetOrdinal(field);
                    if (ord >= 0) return record[ord].SafeToString();
                }
                catch
                {
                    continue;
                }
            }
            return null;
        }

        public static string SafeString(this IDataRecord record, int ord)
        {
            if (ord < 0) return null;
            return record[ord].SafeToString();
        }
    }
}
