using System;
using System.Collections.Generic;
using System.Linq;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.ChangeSet
{
    public class ChangeSetCompiledModel
    {
        public List<ChangeSetCompiledDeleteItem> Deletes = new List<ChangeSetCompiledDeleteItem>();
        public List<ChangeSetCompiledUpdateItem> Updates = new List<ChangeSetCompiledUpdateItem>();
        public ChangeSetModel ChangeSet = new ChangeSetModel();

        public List<CdlDataColumnInfo> ColumnInfos;
        public DatabaseInfo Db;

        public class KeyItem
        {
            public string Name;
            public int Index = -1;
        }

        public ChangeSetCompiledModel()
        {
        }

        public event Action ChangedChangeSet;

        public void DispatchChanged()
        {
            if (_freezeCount > 0)
            {
                _updatedWhenFrozen = true;
                return;
            }
            if (ChangedChangeSet != null) ChangedChangeSet();
        }


        public void Recompile(List<CdlDataColumnInfo> columnInfos, DatabaseInfo db)
        {
            ColumnInfos = columnInfos;
            Db = db;

            Updates.Clear();
            Deletes.Clear();

            foreach (var src in ChangeSet.Updates)
            {
                Updates.Add(new ChangeSetCompiledUpdateItem(this, src));
            }

            foreach (var src in ChangeSet.Deletes)
            {
                Deletes.Add(new ChangeSetCompiledDeleteItem(this, src));
            }
        }

        private void RecompileItem(ChangeSetUpdateItem item)
        {
            int index = Updates.FindIndex(x => x.Item == item);
            if (index >= 0) Updates[index] = new ChangeSetCompiledUpdateItem(this, item);
            else Updates.Add(new ChangeSetCompiledUpdateItem(this, item));
        }

        private void RecompileItem(ChangeSetDeleteItem item)
        {
            int index = Deletes.FindIndex(x => x.Item == item);
            if (index >= 0) Deletes[index] = new ChangeSetCompiledDeleteItem(this, item);
            else Deletes.Add(new ChangeSetCompiledDeleteItem(this, item));
        }

        public int FindColumnIndex(NameWithSchema tableName, string columnName)
        {
            if (ColumnInfos == null) return -1;

            int index1 = ColumnInfos.FindIndex(x => x.TableName == tableName && x.TableColumnName == columnName);
            if (index1 >= 0) return index1;
            foreach (var colcand in ColumnInfos)
            {
                if (colcand.TableName == null) continue;
                var tcand = Db.FindTable(colcand.TableName);
                if (tcand == null) continue;
                var ccand = tcand.FindColumn(colcand.TableColumnName);
                if (ccand == null) continue;
                var fks = ccand.GetForeignKeys().Where(x => x.Columns.Count == 1).ToList();
                if (!fks.Any()) continue;
                var fk = fks.First();
                if (fk.RefTableFullName == tableName && fk.RefColumns[0].RefColumnName == columnName)
                {
                    return ColumnInfos.IndexOf(colcand);
                }
            }
            return -1;
        }

        public ColumnInfo FindColumnInfo(NameWithSchema table, string column)
        {
            if (Db == null) return null;
            var tinfo = Db.FindTable(table);
            if (tinfo == null) return null;
            return tinfo.FindColumn(column);
        }

        public void Clear()
        {
            ChangeSet = new ChangeSetModel();
            Recompile(ColumnInfos, Db);
        }

        public bool HasChanges()
        {
            return ChangeSet.HasChanges();
        }

        public void ClearCompiled()
        {
            ColumnInfos = null;
            Db = null;

            Deletes.Clear();
            Updates.Clear();
        }

        private KeyItem[] GetTableKey(NameWithSchema tableName)
        {
            var table = Db.FindTable(tableName);
            if (table == null) return null;
            var pk = table.PrimaryKey;
            if (pk == null)
            {
                var res =
                    table.Columns
                        .Where(x => DbTypeBase.IsComparable(x.CommonType))
                        .Select(col =>
                                new KeyItem
                                    {
                                        Index = ColumnInfos.FindIndex(x => x.TableName == table.FullName && x.TableColumnName == col.Name),
                                        Name = col.Name,
                                    })
                        .ToList();

                if (res.Any(x => x.Index == -1)) return null;
                if (!res.Any()) return null;

                return res.ToArray();
            }
            else
            {
                var res = pk.Columns.Select(col => new KeyItem {Name = col.RefColumnName, Index = FindColumnIndex(table.FullName, col.RefColumnName)}).ToList();
                if (res.Any(x => x.Index == -1)) return null;
                if (!res.Any()) return null;

                return res.ToArray();
            }
        }

        private KeyItem[] GetUpdateKey(int columnIndex, out NameWithSchema tableName)
        {
            tableName = null;
            if (ColumnInfos == null || Db == null) return null;
            var colinfo = ColumnInfos[columnIndex];
            if (colinfo == null || colinfo.TableName == null) return null;
            tableName = colinfo.TableName;
            return GetTableKey(tableName);
        }

        private KeyItem[] GetDeleteKey(NameWithSchema tableName)
        {
            if (tableName == null) return null;
            return GetTableKey(tableName);
        }

        public bool CanBeUpdated(CdlRow row, int columnIndex)
        {
            NameWithSchema tableName;
            var pk = GetUpdateKey(columnIndex, out tableName);
            if (pk == null) return false;
            return row.GetValuesByCols(pk.Select(x => x.Index).ToArray()).All(x => x != null);
        }

        //private ChangeSetCompiledUpdateItem FindUpdate(NameWithSchema tableName, int[] pk, object[] values)
        //{
        //    return Updates.FirstOrDefault(x => x.MatchKey(tableName, pk, values));
        //}

        private ChangeSetCompiledUpdateItem FindUpdate(NameWithSchema tableName, CdlRow row)
        {
            return Updates.FirstOrDefault(x => x.Item.TargetTable == tableName && x.EvalCondition(row));
        }

        public void UpdateValue(CdlRow row, int columnIndex, object value)
        {
            NameWithSchema tableName;
            var pk = GetUpdateKey(columnIndex, out tableName);
            if (pk == null) return;
            var values = row.GetValuesByCols(pk.Select(x => x.Index).ToArray());
            //var update = FindUpdate(tableName, pk, values);
            var update = FindUpdate(tableName, row);

            ChangeSetUpdateItem updsource;
            if (update == null)
            {
                updsource = new ChangeSetUpdateItem
                    {
                        TargetTable = tableName,
                    };
                FillConditions(updsource.Conditions, pk, values);
                ChangeSet.Updates.Add(updsource);
            }
            else
            {
                updsource = (ChangeSetUpdateItem) update.Item;
            }
            updsource.UpdateValue(ColumnInfos[columnIndex].TableColumnName, value);
            RecompileItem(updsource);
            DispatchChanged();
        }

        private void FillConditions(List<ChangeSetCondition> conditions, KeyItem[] pk, object[] values)
        {
            for (int i = 0; i < pk.Length; i++)
            {
                conditions.Add(new ChangeSetCondition
                {
                    Column = pk[i].Name,
                    Expression = values[i] == null ? "NULL" : String.Format("= \"{0}\"", values[i]),
                });
            }
        }

        public void DeleteRow(NameWithSchema tableName, CdlRow row)
        {
            var delete = Deletes.FirstOrDefault(x => x.EvalCondition(row));
            if (delete != null) return;

            var pk = GetDeleteKey(tableName);
            if (pk == null) return;
            var values = row.GetValuesByCols(pk.Select(x => x.Index).ToArray());

            var item = new ChangeSetDeleteItem
                {
                    TargetTable = tableName,
                };
            FillConditions(item.Conditions, pk, values);
            ChangeSet.Deletes.Add(item);
            RecompileItem(item);
            DispatchChanged();
        }

        public void BatchDeleteRows(NameWithSchema tableName, bool clearOtherDeletes, List<ChangeSetCondition> conditions = null)
        {
            if (clearOtherDeletes)
            {
                Deletes.Clear();
                ChangeSet.Deletes.Clear();
            }
            var item = new ChangeSetDeleteItem
                {
                    TargetTable = tableName,
                };
            if (conditions != null) item.Conditions.AddRange(conditions);
            ChangeSet.Deletes.Add(item);
            RecompileItem(item);
            DispatchChanged();
        }

        public void BatchUpdateRows(int columnIndex, object value, List<ChangeSetCondition> conditions = null)
        {
            NameWithSchema tableName;
            GetUpdateKey(columnIndex, out tableName);
            if (tableName == null) return;
            var item = new ChangeSetUpdateItem
                {
                    TargetTable = tableName,
                };
            if (conditions != null) item.Conditions.AddRange(conditions);
            ChangeSet.Updates.Add(item);
            item.UpdateValue(ColumnInfos[columnIndex].TableColumnName, value);
            RecompileItem(item);
            DispatchChanged();
        }

        private int _freezeCount = 0;
        private bool _updatedWhenFrozen = false;

        public void BeginUpdate()
        {
            if (_freezeCount == 0) _updatedWhenFrozen = false;
            _freezeCount++;
        }

        public void EndUpdate()
        {
            _freezeCount--;
            if (_updatedWhenFrozen && _freezeCount == 0)
            {
                DispatchChanged();
                _updatedWhenFrozen = false;
            }
        }


        public void ApplyOnRow(NameWithSchema tableName, CdlRow row)
        {
            foreach (var item in Updates)
            {
                if (item.EvalCondition(row))
                {
                    foreach (var value in item.Values)
                    {
                        row[value.Column] = value.Value;
                    }
                }
            }

            foreach (var item in Deletes)
            {
                if (item.Item.TargetTable == tableName && item.EvalCondition(row)) row.RowState = CdlRowState.Deleted;
            }
        }

        public void ApplyOnTable(NameWithSchema tableName, CdlTable table)
        {
            foreach (var item in Updates)
            {
                foreach (var row in table.Rows)
                {
                    if (item.EvalCondition(row))
                    {
                        foreach (var value in item.Values)
                        {
                            row[value.Column] = value.Value;
                        }
                    }
                }
            }

            foreach (var item in Deletes)
            {
                foreach (var row in table.Rows)
                {
                    if (item.EvalCondition(row)) row.RowState = CdlRowState.Deleted;
                }
            }
        }

        public void ApplyAddedRowsOnTable(NameWithSchema tableName, CdlTable table)
        {
            foreach (var item in ChangeSet.Inserts)
            {
                if (item.TargetTable != tableName) continue;
                var row = table.NewRow();
                table.Rows.Add(row);
                foreach (var value in item.Values)
                {
                    int index = FindColumnIndex(item.TargetTable, value.Column);
                    if (index >= 0)
                    {
                        row[index] = value.Value;
                    }
                }
            }
        }

        public ChangeSetInsertItem AddRow(NameWithSchema tableName)
        {
            var insert = new ChangeSetInsertItem
                {
                    TargetTable = tableName,
                };
            ChangeSet.Inserts.Add(insert);
            DispatchChanged();
            return insert;
        }

        public bool HasInserts(NameWithSchema tableName)
        {
            return ChangeSet.Inserts.Any(x => x.TargetTable == tableName);
        }

        private ChangeSetInsertItem FindInsert(NameWithSchema tableName, int addedIndex)
        {
            int currentIndex = 0;
            foreach (var insert in ChangeSet.Inserts)
            {
                if (insert.TargetTable != tableName) continue;
                if (currentIndex == addedIndex) return insert;
                currentIndex++;
            }
            return null;
        }

        public void UpdateAddedValue(NameWithSchema tableName, int addedIndex, string column, object value)
        {
            var insert = FindInsert(tableName, addedIndex);
            if (insert != null)
            {
                insert.UpdateValue(column, value);
                DispatchChanged();
            }
        }

        public void DeleteAddedRow(NameWithSchema tableName, int addedIndex)
        {
            var insert = FindInsert(tableName, addedIndex);
            if (insert != null)
            {
                ChangeSet.Inserts.Remove(insert);
                DispatchChanged();
            }
        }

        public int InsertCount(NameWithSchema tableName)
        {
            return ChangeSet.Inserts.Count(x => x.TargetTable == tableName);
        }

        public void RevertRowChanges(NameWithSchema tableName, CdlRow row)
        {
            Updates.RemoveAll(x => x.EvalCondition(row));
            Deletes.RemoveAll(x => x.Item.TargetTable == tableName && x.EvalCondition(row));
            DispatchChanged();
        }
    }
}
