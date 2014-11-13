using System;
using System.Collections.Generic;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.Sql
{
    partial class SqlDumper
    {
        private void Where(NameWithSchema table, string[] cols, object[] vals)
        {
            Put(" ^where ");
            bool was = false;
            for (int i = 0; i < cols.Length; i++)
            {
                if (was) Put(" ^and ");
                if (vals[i].IsNullOrDbNull()) Put("%i ^is ^null", cols[i]);
                else Put("%i=%v", cols[i], vals[i]);
                was = true;
            }
        }

        public virtual void TruncateTable(NameWithSchema name)
        {
            Put("^delete ^from %f;&n", name);
        }

        public void UpdateData(TableInfo table, SingleTableDataScript script, LinkedDatabaseInfo linkedInfo)
        {
            if (script == null) return;
            int delcnt = 0, inscnt = 0, updrows = 0, updflds = 0;

            string linkedInfoStr = linkedInfo != null ? linkedInfo.ToString() : "";

            foreach (var del in script.Deletes)
            {
                Put("^delete ^from %s%f", linkedInfoStr, table.FullName);
                Where(table.FullName, del.CondCols, del.CondValues);
                Put(";&n");
                delcnt++;
            }
            foreach (var upd in script.Updates)
            {
                Put("^update %s%f ^set ", linkedInfoStr, table.FullName);
                for (int i = 0; i < upd.Columns.Length; i++)
                {
                    if (i > 0) Put(", ");
                    Put("%i=%v", upd.Columns[i], new ValueTypeHolder(upd.Values[i], table.Columns[upd.Columns[i]].CommonType));
                }
                Where(table.FullName, upd.CondCols, upd.CondValues);
                Put(";&n");
                updrows++;
                updflds += upd.Values.Length;
            }
            ColumnInfo autoinc = null;
            if (table != null) autoinc = table.FindAutoIncrementColumn();
            bool isIdentityInsert = false;
            foreach (var ins in script.Inserts)
            {
                if (autoinc != null)
                {
                    if (Array.IndexOf(ins.Columns, autoinc.Name) >= 0)
                    {
                        if (!isIdentityInsert) AllowIdentityInsert(table.FullName, true);
                        isIdentityInsert = true;
                    }
                    else
                    {
                        if (isIdentityInsert) AllowIdentityInsert(table.FullName, false);
                        isIdentityInsert = false;
                    }
                }
                var vals = new List<ValueTypeHolder>();
                var insColumns = new List<string>();
                for (int i = 0; i < ins.Columns.Length; i++)
                {
                    var col = table.Columns[ins.Columns[i]];
                    if (col != null)
                    {
                        insColumns.Add(ins.Columns[i]);
                        vals.Add(new ValueTypeHolder(ins.Values[i], col.CommonType));
                    }
                }
                if (insColumns.Count > 0)
                {
                    Put("^insert ^into %s%f (%,i) ^values (%,v);&n", linkedInfoStr, table.FullName, insColumns, vals);
                }
                inscnt++;
            }
            if (isIdentityInsert) AllowIdentityInsert(table.FullName, false);
        }

        public void UpdateData(MultiTableUpdateScript script, LinkedDatabaseInfo linkedInfo)
        {
            if (script == null) return;
            string linkedInfoStr = linkedInfo != null ? linkedInfo.ToString() : "";
            int updrows = 0, updflds = 0;
            foreach (var upd in script.Updates)
            {
                Put("^update %s%f ^set ", linkedInfoStr, upd.Table);
                for (int i = 0; i < upd.Columns.Length; i++)
                {
                    if (i > 0) Put(", ");
                    Put("%i=%v", upd.Columns[i], upd.Values[i]);
                }
                Where(upd.Table, upd.CondCols, upd.CondValues);
                Put(";&n");
                updrows++;
                updflds += upd.Values.Length;
            }
        }
    }
}
