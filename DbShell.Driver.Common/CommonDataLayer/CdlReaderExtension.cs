using System;
using System.Collections.Generic;
using DbShell.Driver.Common.DmlFramework;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.CommonDataLayer
{
    public static class CdlReaderExtension
    {
        public static CdlTable ToBinaryTable(this ICdlReader reader, int? maximumRecords)
        {
            //TableInfo ts = reader.GetTableInfo();
            CdlTable dt = new CdlTable(reader.Structure);
            int allow_recs = maximumRecords != null ? maximumRecords.Value : -1;
            while (reader.Read() && (maximumRecords == null || allow_recs > 0))
            {
                dt.AddRow(reader);
                allow_recs--;
            }
            return dt;
        }

        public static CdlTable ToBinaryTable(this ICdlReader reader)
        {
            return ToBinaryTable(reader, null);
        }

        public static string[] GetFieldNames(this ICdlRecord record)
        {
            string[] res = new string[record.FieldCount];
            for (int i = 0; i < res.Length; i++) res[i] = record.GetName(i);
            return res;
        }

        public static object[] GetValues(this ICdlRecord record)
        {
            object[] values = new object[record.FieldCount];
            record.GetValues(values);
            return values;
        }

        public static object[] GetValuesByCols(this ICdlRecord record, string[] cols)
        {
            object[] values = new object[cols.Length];
            for (int i = 0; i < cols.Length; i++) values[i] = record.GetValue(cols[i]);
            return values;
        }

        public static object[] GetValuesByCols(this ICdlRecord record, int[] cols)
        {
            object[] values = new object[cols.Length];
            for (int i = 0; i < cols.Length; i++) values[i] = record.GetValue(cols[i]);
            return values;
        }

        public static object[] GetValuesByCols(this ICdlRecord record, DmlfColumnRef[] cols, DmlfResultFieldCollection result)
        {
            if (result == null) return record.GetValuesByCols(cols.GetNames());
            object[] values = new object[cols.Length];
            for (int i = 0; i < cols.Length; i++)
            {
                int index = result.GetColumnIndex(cols[i]);
                values[i] = record.GetValue(index);
            }
            return values;
        }

        public static object GetValue(this ICdlRecord record, int ordinal)
        {
            record.ReadValue(ordinal);
            return record.GetValue();
        }

        public static object GetValue(this ICdlRecord record, string colName)
        {
            return record.GetValue(record.GetOrdinal(colName));
        }

        public static IEnumerable<ICdlRecord> EnumRows(this ICdlReader reader)
        {
            while (reader.Read())
            {
                yield return reader;
            }
        }

        public static void RunForEachRecordAndDispose(this ICdlReader reader, bool allowDirectCall, Action<ICdlRecord, int> func)
        {
            if (allowDirectCall)
            {
                try
                {
                    int index = 0;
                    while (reader.Read())
                    {
                        func(reader, index);
                        index++;
                    }
                }
                finally
                {
                    reader.Dispose();
                }
            }
            else
            {
                List<ArrayDataRecord> cache = new List<ArrayDataRecord>();
                try
                {
                    while (reader.Read())
                    {
                        cache.Add(new ArrayDataRecord(reader));
                    }
                }
                finally
                {
                    reader.Dispose();
                }
                int index = 0;
                foreach (var rec in cache)
                {
                    func(rec, index);
                    index++;
                }
            }
        }

        //public static int GetValues(this ICdlRecord record, object[] values)
        //{
        //    int cnt = Math.Min(values.Length, record.FieldCount);
        //    for (int i = 0; i < cnt; i++)
        //    {
        //        values[i] = record.GetValue(i);
        //    }
        //    return cnt;
        //}
    }
}
