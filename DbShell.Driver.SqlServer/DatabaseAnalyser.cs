using System;
using System.Collections.Generic;
using System.Text;
using System.Data.SqlClient;
using System.Data;
using DataLibrary.Structure;
using DataLibrary.Linq;
using DataLibrary.Utility;

namespace DataLibrary.MsSql
{
    public class DatabaseAnalyser : DataLibrary.Analyser.DatabaseAnalyser
    {
        Dictionary<NameWithSchema, TableInfo> _tables = new Dictionary<NameWithSchema, TableInfo>();

        public DatabaseAnalyser(SqlConnection conn, string dbname)
            : base(conn, dbname)
        {
        }

        SqlConnection Connection
        {
            get { return (SqlConnection)_conn; }
        }

        protected override void DoRun()
        {
            var tables = Connection.GetSchema("Tables");
            var columns = new List<DataRow>();
            foreach (DataRow row in Connection.GetSchema("Columns").Rows) columns.Add(row);
            columns = new List<DataRow>(columns.SortedByKey<DataRow, int>(c => c.SafeInt("ORDINAL_POSITION")));

            foreach (DataRow row in tables.Rows)
            {
                if (row.SafeString("TABLE_TYPE") != "BASE TABLE") continue;
                var table = new TableInfo(Result);
                table.FullName = new NameWithSchema(row.SafeString("TABLE_SCHEMA"), row.SafeString("TABLE_NAME"));
                Result.Tables.Add(table);
                _tables[table.FullName] = table;
            }

            foreach (DataRow row in columns)
            {
                if (row.SafeString("TABLE_TYPE") != "BASE TABLE") continue;
                var tname = new NameWithSchema(row.SafeString("TABLE_SCHEMA"), row.SafeString("TABLE_NAME"));
                var table = _tables[tname];
                var col = new ColumnInfo(table);
                col.Name = row.SafeString("COLUMN_NAME");
                col.NotNull = row.SafeString("IS_NULLABLE") == "NO";
                col.DataType = row.SafeString("DATA_TYPE");
                col.Length = row.SafeInt("CHARACTER_MAXIMUM_LENGTH");
                col.Precision = row.SafeInt("NUMERIC_PRECISION");
                col.Scale = row.SafeInt("NUMERIC_SCALE");
                col.DefaultValue = row.SafeString("COLUMN_DEFAULT");
                table.Columns.Add(col);
            }
        }
    }
}
