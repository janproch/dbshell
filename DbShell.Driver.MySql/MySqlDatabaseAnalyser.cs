using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace DbShell.Driver.MySql
{
    public class MySqlDatabaseAnalyser : DatabaseAnalyser
    {
        private DateTime _last = DateTime.Now;

        Dictionary<string, TableInfo> _tablesByName = new Dictionary<string, TableInfo>();
        Dictionary<string, ViewInfo> _viewByName = new Dictionary<string, ViewInfo>();

        private void Timer(string msg)
        {
            var now = DateTime.Now;
            Debug.WriteLine("{0:0.00}", (now - _last).TotalMilliseconds);
            Debug.WriteLine(msg);
            _last = now;
        }

        protected override void DoGetModifications()
        {
            var existingTables = new HashSet<string>();
            using (var cmd = Connection.CreateCommand())
            {
                cmd.CommandText = CreateQuery("table_modifications.sql", DatabaseObjectType.Table);
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string modify = reader.SafeString("ALTER_TIME");
                        string name = reader.SafeString("TABLE_NAME");
                        existingTables.Add(name);
                        var fullName = new NameWithSchema(null, name);
                        var obj = Structure.FindTable(fullName);

                        if (obj == null)
                        {
                            var item = new DatabaseChangeItem
                            {
                                Action = DatabaseChangeAction.Add,
                                ObjectType = DatabaseObjectType.Table,
                                NewName = fullName,
                            };
                            ChangeSet.Items.Add(item);
                        }
                        else
                        {
                            if (obj.ModifyInfo == null || obj.ModifyInfo != modify)
                            {
                                var item = new DatabaseChangeItem
                                {
                                    Action = DatabaseChangeAction.Change,
                                    ObjectType = DatabaseObjectType.Table,
                                    OldName = ((NamedObjectInfo)obj).FullName,
                                    NewName = fullName,
                                };
                                ChangeSet.Items.Add(item);
                            }
                        }
                    }
                }
            }
            AddDeletedObjects(Structure.Tables, existingTables);
        }

        private void AddDeletedObjects<T>(IEnumerable<T> items, HashSet<string> existingObjects)
            where T : NamedObjectInfo
        {
            foreach (var obj in items)
            {
                if (!existingObjects.Contains(obj.FullName.Name))
                {
                    var item = new DatabaseChangeItem
                    {
                        Action = DatabaseChangeAction.Remove,
                        ObjectType = obj.ObjectType,
                        OldName = obj.FullName,
                    };
                    ChangeSet.Items.Add(item);
                }
            }
        }

        private string CreateFilterExpression(DatabaseObjectType objectType)
        {
            List<string> res = null;
            if (objectType == DatabaseObjectType.Table && FilterOptions.TableFilter != null)
            {
                if (res == null) res = new List<string>();
                res.AddRange(FilterOptions.TableFilter);
            }
            if (objectType == DatabaseObjectType.View && FilterOptions.ViewFilter != null)
            {
                if (res == null) res = new List<string>();
                res.AddRange(FilterOptions.ViewFilter);
            }
            if (objectType == DatabaseObjectType.StoredProcedure && FilterOptions.StoredProcedureFilter != null)
            {
                if (res == null) res = new List<string>();
                res.AddRange(FilterOptions.StoredProcedureFilter);
            }
            if (objectType == DatabaseObjectType.Function && FilterOptions.FunctionFilter != null)
            {
                if (res == null) res = new List<string>();
                res.AddRange(FilterOptions.FunctionFilter);
            }
            if (objectType == DatabaseObjectType.Trigger && FilterOptions.TriggerFilter != null)
            {
                if (res == null) res = new List<string>();
                res.AddRange(FilterOptions.TriggerFilter);
            }
            if (res != null)
            {
                if (res.Count == 0) return " is null";
                return " in (" + res.Select(x => $"'{x}'").CreateDelimitedText(",") + ")";
            }
            return " is not null";
        }

        private string CreateQuery(string resFileName, DatabaseObjectType objectType)
        {
            string res = MySqlDatabaseFactory.LoadEmbeddedResource(resFileName);
            if (res.Contains("=[OBJECT_NAME_CONDITION]")) res = res.Replace(" =[OBJECT_NAME_CONDITION]", CreateFilterExpression(objectType));
            res = res.Replace("#DATABASE#", DatabaseName);
            return res;
        }

        protected override void DoRunAnalysis()
        {
            foreach (var table in Structure.Tables)
            {
                _tablesByName[table.Name] = table;
            }

            foreach (var view in Structure.Views)
            {
                _viewByName[view.Name] = view;
            }

            if (FilterOptions.AnyTables && IsTablesPhase)
            {
                Timer("tables...");
                try
                {
                    using (var cmd = Connection.CreateCommand())
                    {
                        cmd.CommandText = CreateQuery("tables.sql", DatabaseObjectType.Table);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string tname = reader.SafeString("TABLE_NAME");
                                string modify= reader.SafeString("ALTER_TIME");

                                if (_tablesByName.TryGetValue(tname, out var table))
                                {
                                    table.FullName = new NameWithSchema(null, tname);
                                    table.ModifyInfo = modify;
                                }
                                else
                                {
                                    table = new TableInfo(Structure)
                                    {
                                        FullName = new NameWithSchema(null, tname),
                                        ModifyInfo = modify,
                                    };
                                    Structure.Tables.Add(table);
                                    _tablesByName[tname] = table;
                                }
                            }
                        }
                    }
                }
                catch (Exception err)
                {
                    AddErrorReport("Error loading tables", err);
                }

                Timer("columns...");

                try
                {
                    using (var cmd = Connection.CreateCommand())
                    {
                        string sql = CreateQuery("columns.sql", DatabaseObjectType.Table);
                        cmd.CommandText = sql;
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string tname = reader.SafeString("TABLE_NAME");
                                if (!_tablesByName.ContainsKey(tname)) continue;
                                var table = _tablesByName[tname];
                                var col = new ColumnInfo(table);
                                col.Name = reader.SafeString("COLUMN_NAME");
                                col.NotNull = reader.SafeString("IS_NULLABLE") == "NO";
                                col.DataType = reader.SafeString("DATA_TYPE");
                                col.Length= reader.SafeString("CHARACTER_MAXIMUM_LENGTH").SafeIntParse(); 
                                col.Precision = reader.SafeString("NUMERIC_PRECISION").SafeIntParse();
                                col.Scale = reader.SafeString("NUMERIC_SCALE").SafeIntParse();
                                col.DefaultValue = reader.SafeString("COLUMN_DEFAULT");
                                col.CommonType = AnalyseType(col.DataType, col.Length, col.Precision, col.Scale);
                                table.Columns.Add(col);
                                if (String.IsNullOrWhiteSpace(col.DefaultValue)) col.DefaultValue = null;
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
                    Timer("primary keys...");
                    using (var cmd = Connection.CreateCommand())
                    {
                        cmd.CommandText = CreateQuery("primary_keys.sql", DatabaseObjectType.Table);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string table = reader.SafeString("TABLE_NAME");
                                string cnt = reader.SafeString("CONSTRAINT_NAME");
                                string column = reader.SafeString("COLUMN_NAME");
                                if (!_tablesByName.ContainsKey(table)) continue;
                                var t = _tablesByName[table];
                                t.Columns[column].PrimaryKey = true;

                                if (t.PrimaryKey == null)
                                {
                                    t.PrimaryKey = new PrimaryKeyInfo(t);
                                    t.PrimaryKey.ConstraintName = cnt;
                                }
                                t.PrimaryKey.Columns.Add(new ColumnReference { RefColumn = t.Columns[column] });
                            }
                        }
                    }
                }
                catch (Exception err)
                {
                    AddErrorReport("Error loading primary keys", err);
                }

                try
                {
                    Timer("foreign keys...");
                    using (var cmd = Connection.CreateCommand())
                    {
                        cmd.CommandText = CreateQuery("foreign_keys.sql", DatabaseObjectType.Table);
                        using (var reader = cmd.ExecuteReader())
                        {
                            while (reader.Read())
                            {
                                string fktable = reader.SafeString("TABLE_NAME");
                                string fkcolumn = reader.SafeString("COLUMN_NAME");

                                string pktable = reader.SafeString("REFERENCED_TABLE_NAME");
                                string pkcolumn = reader.SafeString("REFERENCED_COLUMN_NAME");

                                string deleteAction = reader.SafeString("DELETE_RULE");
                                string updateAction = reader.SafeString("UPDATE_RULE");

                                string cname = reader.SafeString("CONSTRAINT_NAME");

                                if (!_tablesByName.ContainsKey(fktable) || !_tablesByName.ContainsKey(pktable)) continue;

                                var fkt = _tablesByName[fktable];
                                var pkt = _tablesByName[pktable];
                                var fk = fkt.ForeignKeys.Find(f => f.ConstraintName == cname);
                                if (fk == null)
                                {
                                    fk = new ForeignKeyInfo(fkt) { ConstraintName = cname, RefTable = pkt };
                                    fkt.ForeignKeys.Add(fk);
                                    fk.OnDeleteAction = ForeignKeyActionExtension.FromSqlName(deleteAction);
                                    fk.OnUpdateAction = ForeignKeyActionExtension.FromSqlName(updateAction);
                                }
                                fk.Columns.Add(new ColumnReference
                                {
                                    RefColumn = fkt.Columns[fkcolumn]
                                });
                                fk.RefColumns.Add(new ColumnReference
                                {
                                    RefColumn = pkt.Columns[pkcolumn]
                                });
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

        public static DbTypeBase AnalyseType(string dt, int len, int prec, int scale)
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
                    return new DbTypeString
                    {
                        Length = len,
                        IsBinary = true,
                    };
                case "tinyint":
                    return new DbTypeInt
                    {
                        Bytes = 1
                    };
                case "mediumint":
                    return new DbTypeInt
                    {
                        Bytes = 3
                    };
                case "datetime":
                    return new DbTypeDatetime
                    {
                        SubType = DbDatetimeSubType.Datetime,
                    };
                case "time":
                    return new DbTypeDatetime
                    {
                        SubType = DbDatetimeSubType.Time,
                    };
                case "year":
                    return new DbTypeDatetime
                    {
                        SubType = DbDatetimeSubType.Year,
                    };
                case "date":
                    return new DbTypeDatetime
                    {
                        SubType = DbDatetimeSubType.Date,
                    };
                case "decimal":
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
                case "integer":
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
                    return new DbTypeText()
                    {
                        IsUnicode = false,
                    };
                case "ntext":
                    return new DbTypeText()
                    {
                        IsUnicode = true,
                    };
                case "xml":
                    return new DbTypeXml();
            }
            return new DbTypeGeneric { Sql = dt };
        }


    }
}
