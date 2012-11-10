using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.SqlServer
{
    public class SqlServerDatabaseAnalyser : DatabaseAnalyser
    {
        Dictionary<NameWithSchema, TableInfo> _tables = new Dictionary<NameWithSchema, TableInfo>();

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
                var tname = new NameWithSchema(row.SafeString("TABLE_SCHEMA"), row.SafeString("TABLE_NAME"));
                if (!_tables.ContainsKey(tname)) continue;
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

            using (var cmd = Connection.CreateCommand())
            {
                cmd.CommandText = SqlServerDatabaseFactory.LoadEmbeddedResource("identity_columns.sql");
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string table = reader.SafeString("TableName");
                        string schema = reader.SafeString("SchemaName");
                        string column = reader.SafeString("ColumnName");
                        var t = _tables[new NameWithSchema(schema, table)];
                        t.Columns[column].AutoIncrement = true;
                    }
                }
            }

            using (var cmd = Connection.CreateCommand())
            {
                cmd.CommandText = SqlServerDatabaseFactory.LoadEmbeddedResource("primary_keys.sql");
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string table = reader.SafeString("TableName");
                        string schema = reader.SafeString("SchemaName");
                        string column = reader.SafeString("ColumnName");
                        var t = _tables[new NameWithSchema(schema, table)];
                        t.Columns[column].PrimaryKey = true;
                    }
                }
            }

            using (var cmd = Connection.CreateCommand())
            {
                cmd.CommandText = SqlServerDatabaseFactory.LoadEmbeddedResource("foreign_keys.sql");
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string fktable = reader.SafeString("FK_Table");
                        string fkcolumn = reader.SafeString("FK_Column");
                        string fkschema = reader.SafeString("FK_Schema");

                        string pktable = reader.SafeString("PK_Table");
                        if (String.IsNullOrEmpty(pktable)) pktable = reader.SafeString("IX_Table");
                        string pkcolumn = reader.SafeString("PK_Column");
                        if (String.IsNullOrEmpty(pkcolumn)) pkcolumn = reader.SafeString("IX_Column");
                        string pkschema = reader.SafeString("PK_Schema");
                        if (String.IsNullOrEmpty(pkschema)) pkschema = reader.SafeString("IX_Schema");

                        string cname = reader.SafeString("Constraint_Name");

                        var fkt = _tables[new NameWithSchema(fkschema, fktable)];
                        var pkt = _tables[new NameWithSchema(pkschema, pktable)];
                        var fk = fkt.ForeignKeys.Find(f => f.ConstraintName == cname);
                        if (fk == null)
                        {
                            fk = new ForeignKeyInfo(fkt) {ConstraintName = cname, RefTable = pkt};
                            fk.Columns.Add(new ColumnReference
                                {
                                    RefColumn = fkt.Columns[fkcolumn]
                                });
                            fk.RefColumns.Add(new ColumnReference
                                {
                                    RefColumn = pkt.Columns[pkcolumn]
                                });
                            fkt.ForeignKeys.Add(fk);
                        }
                        ;
                    }
                }
            }

            Result.FixPrimaryKeys();
        }
    }
}
