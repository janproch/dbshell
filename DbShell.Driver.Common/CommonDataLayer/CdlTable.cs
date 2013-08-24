using System;
using System.Collections.Generic;
using System.Linq;
using DbShell.Driver.Common.DmlFramework;
using DbShell.Driver.Common.Sql;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.CommonDataLayer
{
    public class CdlTable : IInMemoryTable<CdlRow>
    {
        private TableInfo m_structure;
        private CdlValueConvertor m_convertor;
        private CdlValueConvertor m_defConvertor;

        //private ColumnDisplayInfoCollection m_columnDisplay;

        public TableInfo Structure
        {
            get { return m_structure; }
        }

        public CdlRowCollection Rows { get; private set; }

        public DmlfResultFieldCollection ResultFields { get; set; }

        //public ColumnDisplayInfoCollection ColumnDisplay
        //{
        //    get { return m_columnDisplay; }
        //    set
        //    {
        //        m_columnDisplay = value;
        //        RealColumnsEx = null;
        //        if (m_columnDisplay != null)
        //        {
        //            RealColumnsEx = new List<DmlfColumnRef>();
        //            for (int i = 0; i < Math.Min(m_columnDisplay.Count, m_structure.Columns.Count); i++)
        //            {
        //                RealColumnsEx.Add(new DmlfColumnRef { Source = m_columnDisplay[i].BaseTable, ColumnName = ColumnDisplay[i].BaseColumnName });
        //            }
        //        }
        //    }
        //}
        //// readundant information, for more comfortable work
        //public List<DmlfColumnRef> RealColumnsEx { get; private set; }

        IRowCollection<CdlRow> IInMemoryTable<CdlRow>.Rows
        {
            get { return this.Rows; }
        }

        public event CdlRowEventHandler AddedRow;
        public event CdlRowEventHandler RemovedRow;

        public CdlTable(TableInfo structure)
        {
            m_structure = structure.Clone();
            Rows = new CdlRowCollection(this);
            m_defConvertor = new CdlValueConvertor(new DataFormatSettings());
        }

        public CdlTable(InMemoryTable table)
        {
            m_structure = table.Structure.Clone();
            Rows = new CdlRowCollection(this);
            foreach (var row in table.Rows) Rows.AddInternal(new CdlRow(this, row, CdlRowState.Unchanged, m_structure));
            m_defConvertor = new CdlValueConvertor(new DataFormatSettings());
        }

        internal CdlValueConvertor CdlConvertor
        {
            get { return m_convertor ?? m_defConvertor; }
            set { m_convertor = value; }
        }

        public CdlRow NewRow()
        {
            return new CdlRow(this, null, CdlRowState.Detached, m_structure);
        }

        internal void NotifyAddedRow(CdlRow row)
        {
            if (AddedRow != null) AddedRow(this, new CdlRowEventArgs {Row = row});
        }

        internal void NotifyRemovedRow(CdlRow row)
        {
            if (RemovedRow != null) RemovedRow(this, new CdlRowEventArgs {Row = row});
        }

        public CdlRow AddRow(ICdlRecord record)
        {
            var row = new CdlRow(this, new ArrayDataRecord(record), CdlRowState.Unchanged, m_structure);
            Rows.AddInternal(row);
            return row;
        }

        internal void AddRowInternal(ArrayDataRecord rec)
        {
            Rows.AddInternal(new CdlRow(this, rec, CdlRowState.Unchanged, m_structure));
        }

        public CdlTable Filter(Func<CdlRow, bool> filter)
        {
            CdlTable res = new CdlTable(m_structure);
            res.m_convertor = m_convertor;
            foreach (var row in Rows)
            {
                if (filter(row)) res.AddRow(row);
            }
            return res;
        }

        public InMemoryTable ToInMemoryTable()
        {
            return InMemoryTable.FromEnumerable(m_structure,
                                                from row in Rows
                                                where row.RowState != CdlRowState.Detached && row.RowState != CdlRowState.Deleted
                                                select row
                );
        }

        public void RunScript(SingleTableDataScript script)
        {
            foreach (var del in script.Deletes)
            {
                CdlRow row = this.FindRow(del.CondCols, del.CondValues);
                if (row != null) Rows.Remove(row);
            }
            foreach (var upd in script.Updates)
            {
                CdlRow row = this.FindRow(upd.CondCols, upd.CondValues);
                if (row != null) row[upd.Columns] = upd.Values;
            }
            foreach (var ins in script.Inserts)
            {
                CdlRow row = NewRow();
                row[ins.Columns] = ins.Values;
                Rows.Add(row);
            }
        }

        private DmlfColumnRef[] GetBaseWhereCols()
        {
            if (ResultFields != null)
            {
                return ResultFields.GetPrimaryKey(DmlfSource.BaseTable).ToArray();
            }
            else
            {
                var pk = Structure.PrimaryKey;
                return DmlfColumnRef.BuildFromArray(pk != null ? pk.Columns.GetNames() : Structure.Columns.GetNames(), null);
            }
        }

        public SingleTableDataScript GetBaseModifyScript()
        {
            SingleTableDataScript res = new SingleTableDataScript();
            DmlfColumnRef[] wherecols = GetBaseWhereCols();
            foreach (var row in Rows)
            {
                if (row.RowState == CdlRowState.Unchanged) continue;
                // modified rows in multitable views are solved in GetLinkedDataScript()
                if (row.RowState == CdlRowState.Modified && ResultFields != null && ResultFields.IsMultiTable()) continue;
                string[] changed = row.GetChangedColumns(false);
                string[] changedNotNull = row.GetChangedColumns(true);
                if (changed.Length == 0 && row.RowState != CdlRowState.Deleted) continue;
                switch (row.RowState)
                {
                    case CdlRowState.Added:
                        res.Insert(changedNotNull, row.GetValuesByCols(changedNotNull));
                        break;
                    case CdlRowState.Modified:
                        res.Update(wherecols.GetNames(), row.Original.GetValuesByCols(wherecols, ResultFields), changed, row[changed]);
                        break;
                    case CdlRowState.Deleted:
                        res.Delete(wherecols.GetNames(), row.Original.GetValuesByCols(wherecols, ResultFields));
                        break;
                }
            }
            return res;
        }

        public MultiTableUpdateScript GetLinkedDataScript(NameWithSchema basetable)
        {
            var res = new MultiTableUpdateScript();
            if (ResultFields == null || !ResultFields.IsMultiTable()) return res;
            var pks = new Dictionary<DmlfSource, List<DmlfColumnRef>>();

            foreach (var row in Rows)
            {
                if (row.RowState != CdlRowState.Modified) continue;
                var changed = row.GetChangedColumnRefs();
                if (changed.Length == 0) continue;
                var tbls = new List<DmlfSource>();
                foreach (var ch in changed)
                {
                    if (!tbls.Contains(ch.Source)) tbls.Add(ch.Source);
                }
                foreach (var src in tbls)
                {
                    if (pks.ContainsKey(src)) continue;
                    pks[src] = ResultFields.GetPrimaryKey(src);
                }

                foreach (var src in tbls)
                {
                    var cols = new List<DmlfColumnRef>();
                    foreach (var ch in changed)
                    {
                        if (ch.Source != src) continue;
                        cols.Add(ch);
                    }
                    var pk = pks[src];
                    res.Update(src == DmlfSource.BaseTable ? basetable : src.TableOrView,
                               (from c in pk select c.ColumnName).ToArray(),
                               row.Original.GetValuesByCols(pk.ToArray(), ResultFields),
                               (from c in cols select c.ColumnName).ToArray(),
                               row.GetValuesByCols(cols.ToArray()));
                }
            }

            return res;
        }

        public void RevertAllChanges()
        {
            foreach (var row in Rows)
            {
                row.RevertChanges();
            }
            for (int i = 0; i < Rows.Count;)
            {
                var row = Rows[i];
                if (row.RowState == CdlRowState.Added) Rows.RemoveAt(i);
                else i++;
            }
        }

        //public TColumnDisplay<ColumnInfo> GetColumnDisplay()
        //{
        //    var res = new TColumnDisplay<ColumnInfo>();
        //    var pk = Structure.PrimaryKey;
        //    var pkcols = new List<string>();
        //    if (pk != null) pkcols = new List<string>(pk.Columns.GetNames());
        //    if (ResultFields == null)
        //    {
        //        for (int i = 0; i < Structure.Columns.Count; i++)
        //        {
        //            var col = Structure.Columns[i];
        //            var di = new ColumnDisplayInfo { IsPrimaryKey = pkcols.Contains(col.Name) };
        //            res.AddColumn(col.Name, i, col);
        //        }
        //    }
        //    else
        //    {
        //        for (int i = 0; i < Math.Min(Structure.Columns.Count, ResultFields.Count); i++)
        //        {
        //            var col = Structure.Columns[i];
        //            res.AddColumn(ResultFields[i], i, col);
        //        }
        //    }
        //    return res;
        //}

        public CdlTable GetFirstRows(int count)
        {
            var res = new CdlTable(Structure);
            for (int i = 0; i < Math.Min(count, Rows.Count); i++)
            {
                res.AddRow(Rows[i]);
            }
            return res;
        }

        public void AddChangesToChangeSet(CdlChangeSet changeSet, string[] colNames, int[] pk)
        {
            foreach (var row in Rows)
            {
                switch (row.RowState)
                {
                    case CdlRowState.Unchanged:
                        continue;
                    case CdlRowState.Added:
                        {
                            var values = new CdlChangeSet.InsertedRowValues();
                            for (int i = 0; i < colNames.Length; i++)
                            {
                                if (!row.IsChanged(i)) continue;
                                values.ChangedItems.Add(new CdlChangeSet.RowValuesBase.Item
                                    {
                                        Column = colNames[i],
                                        Value = row[i],
                                    });
                            }
                            changeSet.InsertedRows.Add(values);
                        }
                        break;
                    case CdlRowState.Modified:
                        {
                            if (pk == null) throw new Exception("DBSH-00093 PK required");
                            object[] pkVals = row.Original.GetValuesByCols(pk);
                            var values = changeSet.FindValuesByKey(pkVals);
                            if (values == null)
                            {
                                values = new CdlChangeSet.UpdatedRowValues
                                    {
                                        UpdateKey = pkVals,
                                    };
                            }
                            for (int i = 0; i < colNames.Length; i++)
                            {
                                if (!row.IsChanged(i)) continue;
                                values.ChangedItems.Add(new CdlChangeSet.RowValuesBase.Item
                                    {
                                        Column = colNames[i],
                                        Value = row[i],
                                    });
                            }
                            changeSet.UpdatedRows.Add(values);
                        }
                        break;
                    case CdlRowState.Deleted:
                        {
                            if (pk == null) throw new Exception("DBSH-00094 PK required");
                            object[] pkVals = row.Original.GetValuesByCols(pk);
                            changeSet.DeletedRows.Add(pkVals);
                        }
                        break;
                }
            }
        }

        public void ApplyChangesFromChangeSet(CdlChangeSet changeSet, bool removeFromChangeSet, string[] colNames, int[] pk)
        {
            var dct = CdlChangeSet.CreateTableDict(this, pk);

            foreach (var pkVal in changeSet.DeletedRows.ToArray())
            {
                string key = CdlChangeSet.GetPkString(pkVal);
                if (dct.ContainsKey(key))
                {
                    dct[key].RowState = CdlRowState.Deleted;
                    if (removeFromChangeSet) changeSet.DeletedRows.Remove(pkVal);
                }
            }

            foreach (var change in changeSet.UpdatedRows.ToArray())
            {
                if (change.UpdateKey != null)
                {
                    string key = CdlChangeSet.GetPkString(change.UpdateKey);
                    if (dct.ContainsKey(key))
                    {
                        var row = dct[key];
                        foreach (var item in change.ChangedItems.ToArray())
                        {
                            int index = colNames.IndexOfEx(item.Column);
                            if (index >= 0)
                            {
                                row[index] = item.Value;
                                if (removeFromChangeSet) change.ChangedItems.Remove(item);
                            }
                        }
                        if (removeFromChangeSet && change.ChangedItems.Count == 0)
                        {
                            changeSet.UpdatedRows.Remove(change);
                        }
                    }
                }
            }
        }

        public void ApplyAddedRowsFromChangeSet(CdlChangeSet changeSet, bool removeFromChangeSet, string[] colNames)
        {
            foreach(var change in changeSet.InsertedRows.ToArray())
            {
                var row = NewRow();
                Rows.Add(row);
                foreach (var item in change.ChangedItems.ToArray())
                {
                    int index = colNames.IndexOfEx(item.Column);
                    if (index >= 0)
                    {
                        row[index] = item.Value;
                        if (removeFromChangeSet) change.ChangedItems.Remove(item);
                    }
                }
                if (removeFromChangeSet && change.ChangedItems.Count == 0)
                {
                    changeSet.InsertedRows.Remove(change);
                }
            }
        }
    }
}
