using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;

namespace DbShell.Driver.Common.AbstractDb
{
    public abstract class SimpleDatabaseAnalyserBase : DatabaseAnalyser
    {
        protected DateTime _last = DateTime.Now;

        protected Dictionary<NameWithSchema, TableInfo> _tablesByName = new Dictionary<NameWithSchema, TableInfo>();
        protected Dictionary<NameWithSchema, ViewInfo> _viewByName = new Dictionary<NameWithSchema, ViewInfo>();

        protected void Timer(string msg)
        {
            var now = DateTime.Now;
            Debug.WriteLine("{0:0.00}", (now - _last).TotalMilliseconds);
            Debug.WriteLine(msg);
            _last = now;
        }

        protected virtual string ToColumnCase(string columnName) => columnName;
        protected bool MultipleSchema => Factory.DialectCaps.MultipleSchema;

        protected void FillByNameDictionaries()
        {
            foreach (var table in Structure.Tables)
            {
                _tablesByName[table.FullName] = table;
            }

            foreach (var view in Structure.Views)
            {
                _viewByName[view.FullName] = view;
            }
        }

        protected string CreateFilterExpression(DatabaseObjectType objectType, bool removeIdPrefix = true)
        {
            if (FilterOptions == null) return " is not null";
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
                return " in (" + res.Select(x => removeIdPrefix ? $"'{x.Substring(x.IndexOf(':') + 1)}'" : x).CreateDelimitedText(",") + ")";
            }
            return " is not null";
        }

        protected void AddDeletedObjectsByName<T>(IEnumerable<T> items, HashSet<string> existingObjects, string objectIdPrefix)
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
                        ObjectId = $"{objectIdPrefix}:{obj.Schema}.{obj.Name}",
                    };
                    ChangeSet.Items.Add(item);
                }
            }
        }

        protected void AddDeletedObjectsById<T>(IEnumerable<T> items, HashSet<string> existingObjects)
            where T : NamedObjectInfo
        {
            foreach (var obj in items)
            {
                if (!existingObjects.Contains(obj.ObjectId))
                {
                    var item = new DatabaseChangeItem
                    {
                        Action = DatabaseChangeAction.Remove,
                        ObjectId = obj.ObjectId,
                        ObjectType = obj.ObjectType,
                        OldName = obj.FullName,
                    };
                    ChangeSet.Items.Add(item);
                }
            }
        }

        protected void DoGetModificationsCore(string sql, string modifyColumn, string nameColumn, string schemaColumn = null, string idColumn = null)
        {
            var existingTables = new HashSet<string>();
            using (var cmd = Connection.CreateCommand())
            {
                cmd.CommandText = sql;
                using (var reader = cmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        string modify = reader.SafeString(modifyColumn);
                        string name = reader.SafeString(nameColumn);
                        string schema = schemaColumn != null ? reader.SafeString(schemaColumn) : null;
                        string objectId = idColumn != null ? reader.SafeString(idColumn) : null;
                        existingTables.Add(name);
                        var fullName = new NameWithSchema(schema, name);
                        var obj = Structure.FindTable(fullName);

                        if (obj == null)
                        {
                            var item = new DatabaseChangeItem
                            {
                                Action = DatabaseChangeAction.Add,
                                ObjectType = DatabaseObjectType.Table,
                                ObjectId = objectId ?? $"table:{schema}.{name}",
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
                                    ObjectId = objectId ?? $"table:{schema}.{name}",
                                };
                                ChangeSet.Items.Add(item);
                            }
                        }
                    }
                }
            }
            if (idColumn != null) AddDeletedObjectsById(Structure.Tables, existingTables);
            else AddDeletedObjectsByName(Structure.Tables, existingTables, "table");
        }

        protected List<(string schema, string name, string modify)> DoLoadTableList(string sql, string modifyColumn, string nameColumn, string schemaColumn = null)
        {
            var res = new List<(string schema, string name, string modify)>();
            Timer("tables...");
            try
            {
                using (var cmd = Connection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string tschema = schemaColumn != null ? reader.SafeString(schemaColumn) : null;
                            string tname = reader.SafeString(nameColumn);
                            string modify = reader.SafeString(modifyColumn);
                            var fname = new NameWithSchema(tschema, tname);

                            if (_tablesByName.TryGetValue(fname, out var table))
                            {
                                table.FullName = new NameWithSchema(tschema, tname);
                                table.ModifyInfo = modify;
                            }
                            else
                            {
                                table = new TableInfo(Structure)
                                {
                                    FullName = fname,
                                    ModifyInfo = modify,
                                    ObjectId = $"table:{tschema}.{tname}",
                                };
                                Structure.Tables.Add(table);
                                _tablesByName[fname] = table;
                            }
                            res.Add((tschema, tname, modify));
                        }
                    }
                }
            }
            catch (Exception err)
            {
                AddErrorReport("Error loading tables", err);
            }

            return res;
        }

        protected void DoLoadColumnsFromInformationSchema(string sql)
        {
            Timer("columns...");
            try
            {
                using (var cmd = Connection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string tschema = MultipleSchema ? reader.SafeString(ToColumnCase("table_schema")) : null;
                            string tname = reader.SafeString(ToColumnCase("table_name"));
                            var fname = new NameWithSchema(tschema, tname);
                            if (!_tablesByName.ContainsKey(fname)) continue;
                            var table = _tablesByName[fname];
                            var col = new ColumnInfo(table);
                            col.Name = reader.SafeString(ToColumnCase("column_name"));
                            col.NotNull = reader.SafeString(ToColumnCase("is_nullable")) == "NO";
                            col.DataType = reader.SafeString(ToColumnCase("data_type"));
                            int length = reader.SafeString(ToColumnCase("character_maximum_length")).SafeIntParse();
                            int precision = reader.SafeString(ToColumnCase("numeric_precision")).SafeIntParse();
                            int scale = reader.SafeString(ToColumnCase("numeric_scale")).SafeIntParse();

                            var dt = col.DataType.ToLower();
                            if (dt.Contains("char") || dt.Contains("binary"))
                            {
                                if (length > 0) col.DataType += $"({length})";
                                if (length < 0) col.DataType += $"(max)";
                            }
                            if (dt.Contains("num") || dt.Contains("dec"))
                            {
                                col.DataType += $"({precision},{scale})";
                            }

                            col.DefaultValue = reader.SafeString(ToColumnCase("column_default"));
                            col.CommonType = AnalyseType(col, length, precision, scale);
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
        }

        protected void DoLoadPrimaryKeysFromInformationSchema(string sql)
        {
            Timer("primary keys...");
            try
            {
                using (var cmd = Connection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string table = reader.SafeString(ToColumnCase("table_name"));
                            string schema = MultipleSchema ? reader.SafeString(ToColumnCase("table_schema")) : null;
                            string cname = reader.SafeString(ToColumnCase("constraint_name"));
                            string cschema = MultipleSchema ? reader.SafeString(ToColumnCase("constraint_schema")) : null;
                            string column = reader.SafeString(ToColumnCase("column_name"));
                            var fname = new NameWithSchema(schema, table);
                            if (!_tablesByName.ContainsKey(fname)) continue;
                            var t = _tablesByName[fname];
                            t.ColumnByName(column).PrimaryKey = true;

                            if (t.PrimaryKey == null)
                            {
                                t.PrimaryKey = new PrimaryKeyInfo(t);
                                t.PrimaryKey.ConstraintName = cname;
                            }
                            t.PrimaryKey.Columns.Add(new ColumnReference { RefColumn = t.ColumnByName(column) });
                        }
                    }
                }
            }
            catch (Exception err)
            {
                AddErrorReport("Error loading primary keys", err);
            }
        }

        protected virtual DbTypeBase AnalyseType(ColumnInfo col, int len, int prec, int scale)
        {
            return new DbTypeString();
        }

        protected void DoLoadForeignKeysFromInformationSchema(string sql)
        {
            try
            {
                Timer("foreign keys...");
                using (var cmd = Connection.CreateCommand())
                {
                    cmd.CommandText = sql;
                    using (var reader = cmd.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            string fktable = reader.SafeString(ToColumnCase("TABLE_NAME"));
                            string fkschema = MultipleSchema ? reader.SafeString(ToColumnCase("TABLE_SCHEMA")) : null;
                            string fkcolumn = reader.SafeString(ToColumnCase("COLUMN_NAME"));

                            string pktable = reader.SafeString(ToColumnCase("REFERENCED_TABLE_NAME"));
                            string pkschema = MultipleSchema ? reader.SafeString(ToColumnCase("REFERENCED_TABLE_SCHEMA")) : null;
                            string pkcolumn = reader.SafeString(ToColumnCase("REFERENCED_COLUMN_NAME"));

                            string deleteAction = reader.SafeString(ToColumnCase("DELETE_RULE"));
                            string updateAction = reader.SafeString(ToColumnCase("UPDATE_RULE"));

                            string cname = reader.SafeString(ToColumnCase("CONSTRAINT_NAME"));

                            var fnameFk = new NameWithSchema(fkschema, fktable);
                            var fnamePk = new NameWithSchema(pkschema, pktable);

                            if (!_tablesByName.ContainsKey(fnameFk) || !_tablesByName.ContainsKey(fnamePk)) continue;

                            var fkt = _tablesByName[fnameFk];
                            var pkt = _tablesByName[fnamePk];
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
                                RefColumn = fkt.ColumnByName(fkcolumn)
                            });
                            fk.RefColumns.Add(new ColumnReference
                            {
                                RefColumn = pkt.ColumnByName(pkcolumn)
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
}
