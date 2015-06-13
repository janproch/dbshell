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
        public NameWithSchema BaseTable;
        public DatabaseInfo Db;

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


        public void Recompile(List<CdlDataColumnInfo> columnInfos, NameWithSchema baseTable, DatabaseInfo db)
        {
            ColumnInfos = columnInfos;
            BaseTable = baseTable;
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

        public int FindColumnIndex(NameWithSchema table, string column)
        {
            if (ColumnInfos == null) return -1;
            return ColumnInfos.FindIndex(x => x.TableName == table && x.TableColumnName == column);
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
            Recompile(ColumnInfos, BaseTable, Db);
        }

        public bool HasChanges()
        {
            return ChangeSet.HasChanges();
        }

        public void ClearCompiled()
        {
            ColumnInfos = null;
            BaseTable = null;
            Db = null;

            Deletes.Clear();
            Updates.Clear();
        }

        private int[] GetTableKey(NameWithSchema tableName)
        {
            var table = Db.FindTable(tableName);
            if (table == null) return null;
            var pk = table.PrimaryKey;
            if (pk == null)
            {
                var res =
                    table.Columns
                    .Where(x => DbTypeBase.IsComparable(x.CommonType))
                    .Select(col => ColumnInfos.FindIndex(x => x.TableName == table.FullName && x.TableColumnName == col.Name))
                    .ToList();

                if (res.Any(x => x == -1)) return null;
                if (!res.Any()) return null;

                return res.ToArray();
            }
            else
            {
                var res = pk.Columns.Select(col => ColumnInfos.FindIndex(x => x.TableName == table.FullName && x.TableColumnName == col.RefColumnName)).ToList();
                if (res.Any(x => x == -1)) return null;
                if (!res.Any()) return null;

                return res.ToArray();
            }
        }

        private int[] GetUpdateKey(int columnIndex, out NameWithSchema tableName)
        {
            tableName = null;
            if (ColumnInfos == null || Db == null) return null;
            var colinfo = ColumnInfos[columnIndex];
            if (colinfo == null || colinfo.TableName == null) return null;
            tableName = colinfo.TableName;
            return GetTableKey(tableName);
        }

        private int[] GetDeleteKey(out NameWithSchema tableName)
        {
            tableName = BaseTable;
            if (BaseTable == null) return null;
            return GetTableKey(tableName);
        }

        public bool CanBeUpdated(CdlRow row, int columnIndex)
        {
            NameWithSchema tableName;
            var pk = GetUpdateKey(columnIndex, out tableName);
            if (pk == null) return false;
            return row.GetValuesByCols(pk).All(x => x != null);
        }

        //private ChangeSetCompiledUpdateItem FindUpdate(NameWithSchema tableName, int[] pk, object[] values)
        //{
        //    return Updates.FirstOrDefault(x => x.MatchKey(tableName, pk, values));
        //}

        private ChangeSetCompiledUpdateItem FindUpdate(CdlRow row)
        {
            return Updates.FirstOrDefault(x => x.EvalCondition(row));
        }

        public void UpdateValue(CdlRow row, int columnIndex, object value)
        {
            NameWithSchema tableName;
            var pk = GetUpdateKey(columnIndex, out tableName);
            if (pk == null) return;
            var values = row.GetValuesByCols(pk);
            //var update = FindUpdate(tableName, pk, values);
            var update = FindUpdate(row);

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

        private void FillConditions(List<ChangeSetCondition> conditions, int[] pk, object[] values)
        {
            for (int i = 0; i < pk.Length; i++)
            {
                conditions.Add(new ChangeSetCondition
                {
                    Column = ColumnInfos[i].TableColumnName,
                    Expression = values[i] == null ? "NULL" : String.Format("= \"{0}\"", values[i]),
                });
            }
        }

        public void DeleteRow(CdlRow row)
        {
            var delete = Deletes.FirstOrDefault(x => x.EvalCondition(row));
            if (delete != null) return;

            NameWithSchema tableName;
            var pk = GetDeleteKey(out tableName);
            if (pk == null) return;
            var values = row.GetValuesByCols(pk);

            var item = new ChangeSetDeleteItem
                {
                    TargetTable = tableName,
                };
            FillConditions(item.Conditions, pk, values);
            ChangeSet.Deletes.Add(item);
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


        public void ApplyOnRow(CdlRow row)
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
                if (item.EvalCondition(row)) row.RowState = CdlRowState.Deleted;
            }
        }

        public void ApplyOnTable(CdlTable table)
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

        public void ApplyAddedRowsOnTable(CdlTable table)
        {
            foreach (var item in ChangeSet.Inserts)
            {
                if (item.TargetTable != BaseTable) continue;
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
    }
}
