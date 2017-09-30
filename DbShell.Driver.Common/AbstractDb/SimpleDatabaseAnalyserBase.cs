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

        protected Dictionary<string, TableInfo> _tablesByName = new Dictionary<string, TableInfo>();
        protected Dictionary<string, ViewInfo> _viewByName = new Dictionary<string, ViewInfo>();

        protected void Timer(string msg)
        {
            var now = DateTime.Now;
            Debug.WriteLine("{0:0.00}", (now - _last).TotalMilliseconds);
            Debug.WriteLine(msg);
            _last = now;
        }

        protected void FillByNameDictionaries()
        {
            foreach (var table in Structure.Tables)
            {
                _tablesByName[table.Name] = table;
            }

            foreach (var view in Structure.Views)
            {
                _viewByName[view.Name] = view;
            }
        }

        protected string CreateFilterExpression(DatabaseObjectType objectType)
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
                return " in (" + res.Select(x => $"'{x.Substring(x.IndexOf(':') + 1)}'").CreateDelimitedText(",") + ")";
            }
            return " is not null";
        }

        protected void AddDeletedObjects<T>(IEnumerable<T> items, HashSet<string> existingObjects, string objectIdPrefix)
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
                        ObjectId = $"{objectIdPrefix}:{obj.Name}",
                    };
                    ChangeSet.Items.Add(item);
                }
            }
        }

        protected void DoGetModificationsCore(string sql, string modifyColumn, string nameColumn)
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
                        existingTables.Add(name);
                        var fullName = new NameWithSchema(null, name);
                        var obj = Structure.FindTable(fullName);

                        if (obj == null)
                        {
                            var item = new DatabaseChangeItem
                            {
                                Action = DatabaseChangeAction.Add,
                                ObjectType = DatabaseObjectType.Table,
                                ObjectId = $"table:{name}",
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
                                    ObjectId = $"table:{name}",
                                };
                                ChangeSet.Items.Add(item);
                            }
                        }
                    }
                }
            }
            AddDeletedObjects(Structure.Tables, existingTables, "table");
        }

        protected List<string> DoLoadTableList(string sql, string modifyColumn, string nameColumn)
        {
            var tables = new List<string>();
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
                            string tname = reader.SafeString(nameColumn);
                            string modify = reader.SafeString(modifyColumn);

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
                                    ObjectId = $"table:{tname}",
                                };
                                Structure.Tables.Add(table);
                                _tablesByName[tname] = table;
                            }
                            tables.Add(tname);
                        }
                    }
                }
            }
            catch (Exception err)
            {
                AddErrorReport("Error loading tables", err);
            }

            return tables;
        }

    }
}
