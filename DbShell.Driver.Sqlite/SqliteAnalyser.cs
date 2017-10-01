using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;
using System.Diagnostics;
using System.Text.RegularExpressions;

namespace DbShell.Driver.Sqlite
{
    public class SqliteAnalyser : SimpleDatabaseAnalyserBase
    {
        protected override void DoRunAnalysis()
        {
            FillByNameDictionaries();

            if (FilterOptions.AnyTables && IsTablesPhase)
            {
                var tables = DoLoadTableList("select name, sql as hash from sqlite_master where type='table' and name " + CreateFilterExpression(DatabaseObjectType.Table), "hash", "name");

                Timer("columns...");

                try
                {
                    foreach (string table in tables)
                    {
                        var fname = new NameWithSchema(null, table);
                        if (!_tablesByName.ContainsKey(fname)) continue;
                        var tableInfo = _tablesByName[fname];
                        using (var cmd = Connection.CreateCommand())
                        {
                            cmd.CommandText = $"pragma table_info('{table}')";
                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    var col = new ColumnInfo(tableInfo);
                                    col.Name = reader.SafeString("name");
                                    col.DataType = reader.SafeString("type");
                                    col.NotNull = reader.SafeString("notnull") == "1";
                                    if (reader.SafeString("pk") == "1")
                                    {
                                        if (tableInfo.PrimaryKey == null)
                                        {
                                            tableInfo.PrimaryKey = new PrimaryKeyInfo(tableInfo);
                                            tableInfo.PrimaryKey.ConstraintName = $"PK_{table}";
                                        }
                                        tableInfo.PrimaryKey.Columns.Add(new ColumnReference
                                        {
                                            RefColumn = col,
                                        });
                                    }
                                    col.CommonType = AnalyseType(col.DataType);
                                    tableInfo.Columns.Add(col);
                                }
                            }
                        }
                    }
                }
                catch (Exception err)
                {
                    AddErrorReport("Error loading columns", err);
                }

                try
                {
                    Timer("foreign keys...");

                    foreach (string table in tables)
                    {
                        var fname = new NameWithSchema(null, table);
                        if (!_tablesByName.ContainsKey(fname)) continue;
                        var tableInfo = _tablesByName[fname];
                        using (var cmd = Connection.CreateCommand())
                        {
                            cmd.CommandText = $"pragma foreign_key_list('{table}')";
                            using (var reader = cmd.ExecuteReader())
                            {
                                while (reader.Read())
                                {
                                    int id = reader.SafeString("id").SafeIntParse();
                                    int seq = reader.SafeString("seq").SafeIntParse();
                                    string refTableName = reader.SafeString("table");
                                    string fromColumn = reader.SafeString("from");
                                    string toColumn = reader.SafeString("to");
                                    string onUpdate = reader.SafeString("on_update");
                                    string onDelete = reader.SafeString("on_delete");

                                    string cname = $"FK_{table}_{id}";

                                    var refTable = _tablesByName[new NameWithSchema(null, refTableName)];

                                    var fk = tableInfo.ForeignKeys.Find(f => f.ConstraintName == cname);

                                    if (fk == null)
                                    {
                                        fk = new ForeignKeyInfo(tableInfo) { ConstraintName = cname, RefTable = refTable };
                                        tableInfo.ForeignKeys.Add(fk);
                                        fk.OnDeleteAction = ForeignKeyActionExtension.FromSqlName(onDelete);
                                        fk.OnUpdateAction = ForeignKeyActionExtension.FromSqlName(onUpdate);
                                    }
                                    fk.Columns.Add(new ColumnReference
                                    {
                                        RefColumn = tableInfo.Columns[fromColumn]
                                    });
                                    fk.RefColumns.Add(new ColumnReference
                                    {
                                        RefColumn = refTable.Columns[toColumn]
                                    });
                                }
                            }
                        }
                    }
                }
                catch (Exception err)
                {
                    AddErrorReport("Error loading foreign keys", err);
                }
            }
        }


        protected override void DoGetModifications()
        {
            DoGetModificationsCore("select name, sql as hash from sqlite_master where type='table'", "hash", "name");
        }

        public DbTypeBase AnalyseType(string typeName)
        {
            string dt = typeName.ToLower();

            int len = 0;
            var mlen = Regex.Match(dt, @"\(([\d]+)\)");
            if (mlen.Success) len = Int32.Parse(mlen.Groups[1].Value);

            int precision = 0, scale = 0;
            var mreal = Regex.Match(dt, @"\(([\d]+)\s*\,\s*([\d]+)\)");
            if (mreal.Success)
            {
                precision = Int32.Parse(mreal.Groups[1].Value);
                scale = Int32.Parse(mreal.Groups[2].Value);
            }

            if (dt.Contains("int"))
            {
                return new DbTypeInt();
            }
            if (dt.Contains("date"))
            {
                return new DbTypeDatetime();
            }
            if (dt.Contains("nvarchar"))
            {
                return new DbTypeString
                {
                    IsVarLength = true,
                    IsUnicode = true,
                    Length = len,
                };
            }
            if (dt.Contains("varchar"))
            {
                return new DbTypeString
                {
                    IsVarLength = true,
                    IsUnicode = false,
                    Length = len,
                };
            }
            if (dt.Contains("nchar"))
            {
                return new DbTypeString
                {
                    IsVarLength = false,
                    IsUnicode = true,
                    Length = len,
                };
            }
            if (dt.Contains("char"))
            {
                return new DbTypeString
                {
                    IsVarLength = false,
                    IsUnicode = false,
                    Length = len,
                };
            }
            if (dt.Contains("float"))
            {
                return new DbTypeFloat();
            }
            if (dt.Contains("decimal"))
            {
                return new DbTypeNumeric
                {
                    Precision = precision,
                    Scale = scale,
                };
            }
            if (dt.Contains("numeric"))
            {
                return new DbTypeNumeric
                {
                    Precision = precision,
                    Scale = scale,
                };
            }
            return new DbTypeGeneric { Sql = typeName };
        }
    }
}

