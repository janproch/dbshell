using System;
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
            PutCmd("^delete ^from %f", name);
        }

        public void UpdateData(TableInfo table, SingleTableDataScript script)
        {
            if (script == null) return;
            int delcnt = 0, inscnt = 0, updrows = 0, updflds = 0;

            foreach (var del in script.Deletes)
            {
                Put("^delete ^from %f", table.FullName);
                Where(table.FullName, del.CondCols, del.CondValues);
                EndCommand();
                delcnt++;
            }
            foreach (var upd in script.Updates)
            {
                Put("^update %f ^set ", table.FullName);
                for (int i = 0; i < upd.Columns.Length; i++)
                {
                    if (i > 0) Put(", ");
                    Put("%i=%v", upd.Columns[i], new ValueTypeHolder(upd.Values[i], table.Columns[upd.Columns[i]].CommonType));
                }
                Where(table.FullName, upd.CondCols, upd.CondValues);
                EndCommand();
                updrows++;
                updflds += upd.Values.Length;
            }
            ColumnInfo autoinc = table.FindAutoIncrementColumn();
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
                var vals = new ValueTypeHolder[ins.Columns.Length];
                for (int i = 0; i < ins.Columns.Length; i++)
                {
                    vals[i] = new ValueTypeHolder(ins.Values[i], table.Columns[ins.Columns[i]].CommonType);
                }
                PutCmd("^insert ^into %f (%,i) ^values (%,v)", table.FullName, ins.Columns, vals);
                inscnt++;
            }
            if (isIdentityInsert) AllowIdentityInsert(table.FullName, false);
        }

        public void UpdateData(MultiTableUpdateScript script)
        {
            if (script == null) return;
            int updrows = 0, updflds = 0;
            foreach (var upd in script.Updates)
            {
                Put("^update %f ^set ", upd.Table);
                for (int i = 0; i < upd.Columns.Length; i++)
                {
                    if (i > 0) Put(", ");
                    Put("%i=%v", upd.Columns[i], upd.Values[i]);
                }
                Where(upd.Table, upd.CondCols, upd.CondValues);
                EndCommand();
                updrows++;
                updflds += upd.Values.Length;
            }
        }
    }
}
