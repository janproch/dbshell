using System;
using System.Data;
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
                if (tp == "varchar") return new DbTypeString { Length = size };
                if (tp == "nvarchar") return new DbTypeString { Length = size, IsUnicode = true };
                if (tp == "text") return new DbTypeText();
                if (tp == "ntext") return new DbTypeText { IsUnicode = true };
            }
            catch { }
            return TypeTool.GetDatAdminType((Type)row["DataType"]);
        }

        public static TableInfo SchemaTableToInfo(DataTable schemaTable)
        {
            var res = new TableInfo(new DatabaseInfo());
            var pk = new PrimaryKeyInfo(res);
            foreach (DataRow row in schemaTable.Rows.SortedByKey<DataRow, int>(row => Int32.Parse(row["ColumnOrdinal"].ToString())))
            {
                if (row.SafeBool("IsHidden", false)) continue;

                var col = new ColumnInfo(res);
                col.Name = row.SafeString("ColumnName");
                col.NotNull = !(bool)row["AllowDBNull"];
                col.DataType = row["DataTypeName"].SafeToString();
                col.CommonType = ReaderDataType(row);

                string schema = row.SafeString("BaseSchemaName");
                string table = row.SafeString("BaseTableName");
                if (table != null && res.FullName == null) res.FullName = new NameWithSchema(schema, table);
                if (row.SafeBool("IsAutoIncrement", false)) col.CommonType.SetAutoincrement(true);

                if (row.SafeBool("IsKey", false))
                {
                    pk.Columns.Add(new ColumnReference { RefColumn = col });
                }
                res.Columns.Add(col);
            }
            if (pk.Columns.Count > 0) res.PrimaryKey = pk;
            return res;

        }

        public static TableInfo GetTableInfo(this IDataReader reader)
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
