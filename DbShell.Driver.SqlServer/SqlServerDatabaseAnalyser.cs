using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.SqlServer
{
    public class SqlServerDatabaseAnalyser : DatabaseAnalyser
    {
        private Dictionary<NameWithSchema, TableInfo> _tables = new Dictionary<NameWithSchema, TableInfo>();

        private SqlConnection Connection
        {
            get { return (SqlConnection) _conn; }
        }

        protected override void DoRun()
        {
            var dialect = SqlServerDatabaseFactory.Instance.CreateDialect();
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
                col.CommonType = AnalyseType(col.DataType, col.Length, col.Precision, col.Scale);
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

            // load code text
            var objs = new Dictionary<NameWithSchema, string>();
            using (var cmd = Connection.CreateCommand())
            {
                cmd.CommandText = SqlServerDatabaseFactory.LoadEmbeddedResource("loadsqlcode.sql");
                using (var reader = cmd.ExecuteReader())
                {
                    NameWithSchema lastName = null;
                    while (reader.Read())
                    {
                        var name = new NameWithSchema(reader.SafeString("OBJ_SCHEMA"), reader.SafeString("OBJ_NAME"));
                        string text = reader.SafeString("CODE_TEXT") ?? "";
                        if (lastName != null && name == lastName)
                        {
                            objs[name] += text;
                        }
                        else
                        {
                            lastName = name;
                            objs[name] = text;
                        }
                    }
                }
            }

            // load views
            using (var cmd = Connection.CreateCommand())
            {
                cmd.CommandText = SqlServerDatabaseFactory.LoadEmbeddedResource("loadviews.sql");
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var name = new NameWithSchema(reader.SafeString("Schema"), reader.SafeString("Name"));
                        var view = new ViewInfo(Result);
                        view.FullName = name;
                        if (objs.ContainsKey(name)) view.QueryText = objs[name];
                        Result.Views.Add(view);
                    }
                }
            }

            var programmables = new Dictionary<NameWithSchema, ProgrammableInfo>();

            // load procedures and functions
            using (var cmd = Connection.CreateCommand())
            {
                cmd.CommandText = "SELECT ROUTINE_SCHEMA, ROUTINE_NAME, ROUTINE_TYPE FROM INFORMATION_SCHEMA.ROUTINES";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var name = new NameWithSchema(reader.SafeString("ROUTINE_SCHEMA"), reader.SafeString("ROUTINE_NAME"));
                        ProgrammableInfo info = null;
                        switch (reader.SafeString("ROUTINE_TYPE"))
                        {
                            case "PROCEDURE":
                                info = new StoredProcedureInfo(Result);
                                break;
                            case "FUNCTION":
                                info = new FunctionInfo(Result);
                                break;
                        }
                        if (info == null) continue;
                        programmables[name] = info;
                        info.FullName = name;
                        if (objs.ContainsKey(name)) info.SqlText = objs[name];
                        if (info is StoredProcedureInfo) Result.StoredProcedures.Add((StoredProcedureInfo) info);
                        if (info is FunctionInfo) Result.Functions.Add((FunctionInfo) info);
                    }
                }
            }

            // load parameters
            using (var cmd = Connection.CreateCommand())
            {
                cmd.CommandText = "SELECT SPECIFIC_SCHEMA, SPECIFIC_NAME, PARAMETER_MODE, IS_RESULT, PARAMETER_NAME, DATA_TYPE FROM INFORMATION_SCHEMA.PARAMETERS ORDER BY ORDINAL_POSITION";
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var name = new NameWithSchema(reader.SafeString("SPECIFIC_SCHEMA"), reader.SafeString("SPECIFIC_NAME"));
                        if (!programmables.ContainsKey(name)) continue;
                        var prg = programmables[name];
                        if (reader.SafeString("IS_RESULT") == "YES")
                        {
                            var func = prg as FunctionInfo;
                            if (func == null) continue;
                            func.ResultType = reader.SafeString("DATA_TYPE");
                            continue;
                        }
                        var arg = new ParameterInfo(prg);
                        prg.Parameters.Add(arg);
                        arg.DataType = reader.SafeString("DATA_TYPE");
                        arg.Name = reader.SafeString("PARAMETER_NAME");
                        arg.IsOutput = reader.SafeString("PARAMETER_MODE") == "OUT";
                    }
                }
            }

            // load view structure
            foreach (var view in Result.Views)
            {
                using (var cmd = Connection.CreateCommand())
                {
                    cmd.CommandText = "SELECT * FROM " + dialect.QuoteFullName(view.FullName);
                    try
                    {
                        using (var reader = cmd.ExecuteReader(CommandBehavior.SchemaOnly | CommandBehavior.KeyInfo))
                        {
                            var queryInfo = reader.GetQueryResultInfo();
                            view.QueryInfo = queryInfo;
                        }
                    }
                    catch (Exception err)
                    {
                        view.QueryInfo = null;
                    }
                }
            }

            // load default schema
            using (var cmd = Connection.CreateCommand())
            {
                cmd.CommandText = "SELECT SCHEMA_NAME()";
                Result.DefaultSchema = cmd.ExecuteScalar().ToString();
            }

            Result.FixPrimaryKeys();
        }

        private DbTypeBase AnalyseType(string dt, int len, int prec, int scale)
        {
            switch (dt)
            {
                case "binary":
                    return new DbTypeString
                        {
                            Length = len,
                            IsBinary = true,
                        };
                case "image":
                    return new DbTypeBlob();
                case "timestamp":
                    return new DbTypeString();
                case "varbinary":
                    return new DbTypeString
                        {
                            Length = len,
                            IsBinary = true,
                            IsVarLength = true,
                        };
                case "bit":
                    return new DbTypeLogical();
                case "tinyint":
                    return new DbTypeInt
                        {
                            Bytes = 1
                        };
                case "datetime":
                    return new DbTypeDatetime
                        {
                            SubType = DbDatetimeSubType.Datetime,
                        };
                case "datetime2":
                    return new DbTypeDatetime
                        {
                            SubType = DbDatetimeSubType.Datetime,
                        };
                case "datetimeoffset":
                    return new DbTypeDatetime
                        {
                            SubType = DbDatetimeSubType.Datetime,
                            HasTimeZone = true,
                        };
                case "date":
                    return new DbTypeDatetime
                        {
                            SubType = DbDatetimeSubType.Date,
                        };
                case "time":
                    return new DbTypeDatetime
                        {
                            SubType = DbDatetimeSubType.Time,
                        };
                case "smalldatetime":
                    return new DbTypeDatetime
                        {
                            SubType = DbDatetimeSubType.Datetime,
                        };
                case "decimal":
                    return new DbTypeNumeric
                        {
                            Precision = prec,
                            Scale = scale,
                        };
                case "numeric":
                    return new DbTypeNumeric
                        {
                            Precision = prec,
                            Scale = scale,
                        };
                case "float":
                    return new DbTypeFloat();
                case "uniqueidentifier":
                    return new DbTypeGuid();
                case "smallint":
                    return new DbTypeInt
                        {
                            Bytes = 2
                        };
                case "int":
                    return new DbTypeInt
                        {
                            Bytes = 4
                        };
                case "bigint":
                    return new DbTypeInt
                        {
                            Bytes = 8
                        };
                case "real":
                    return new DbTypeFloat();
                case "char":
                    return new DbTypeString
                        {
                            Length = len,
                        };
                case "nchar":
                    return new DbTypeString
                        {
                            Length = len,
                            IsUnicode = true,
                        };
                case "varchar":
                    return new DbTypeString
                        {
                            Length = len,
                            IsVarLength = true,
                        };
                case "nvarchar":
                    return new DbTypeString
                        {
                            Length = len,
                            IsVarLength = true,
                            IsUnicode = true,
                        };
                case "text":
                    return new DbTypeText();
                case "ntext":
                    return new DbTypeText();
                case "xml":
                    return new DbTypeXml();
                case "money":
                    return new DbTypeNumeric();
                case "smallmoney":
                    return new DbTypeNumeric();
                case "sql_variant":
                    return new DbTypeText();
            }
            return new DbTypeGeneric {Sql = dt};
        }
    }
}
