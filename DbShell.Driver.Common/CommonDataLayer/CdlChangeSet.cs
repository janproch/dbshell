using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.CommonDataLayer
{
    public class CdlChangeSet
    {
        public class RowValuesBase
        {
            public class Item
            {
                public string Column;
                public object Value;
            }

            public List<Item> ChangedItems = new List<Item>();
        }

        public class UpdatedRowValues : RowValuesBase
        {
            public object[] UpdateKey; // if NULL, it is insert

            private string _updateKeyString;

            public string UpdateKeyString
            {
                get
                {
                    if (_updateKeyString == null && UpdateKey != null)
                    {
                        _updateKeyString = GetPkString(UpdateKey);
                    }
                    return _updateKeyString;
                }
            }

            public UpdatedRowValues Clone()
            {
                var res = new UpdatedRowValues();
                res.ChangedItems.AddRange(ChangedItems);
                res.UpdateKey = UpdateKey;
                return res;
            }

            public Dictionary<NameWithSchema, object[]> ReferencedTablesKeys = new Dictionary<NameWithSchema, object[]>();
        }

        public class InsertedRowValues : RowValuesBase
        {
            public int InsertIndex;

            public InsertedRowValues Clone()
            {
                var res = new InsertedRowValues();
                res.ChangedItems.AddRange(ChangedItems);
                res.InsertIndex = InsertIndex;
                return res;
            }
        }

        public List<object[]> DeletedRows = new List<object[]>();
        public List<UpdatedRowValues> UpdatedRows = new List<UpdatedRowValues>();
        public List<InsertedRowValues> InsertedRows = new List<InsertedRowValues>();

        public CdlChangeSet Clone()
        {
            var res = new CdlChangeSet();
            res.DeletedRows.AddRange(DeletedRows);
            foreach(var values in UpdatedRows) res.UpdatedRows.Add(values.Clone());
            return res;
        }

        public static string GetPkString(object[] pkVal)
        {
            return String.Join("||", pkVal.Select(o => o.SafeToString()).ToArray());
        }
 
        public static Dictionary<string, CdlRow> CreateTableDict(CdlTable table, int[] pk)
        {
            var dct = new Dictionary<string, CdlRow>();
            foreach (var row in table.Rows)
            {
                var pkVal = row.GetValuesByCols(pk);
                dct[GetPkString(pkVal)] = row;
            }
            return dct;
        }

        public UpdatedRowValues FindValuesByKey(object[] key)
        {
            string skey = GetPkString(key);
            foreach (var values in UpdatedRows)
            {
                if (values.UpdateKey != null && values.UpdateKeyString == skey)
                {
                    return values;
                }
            }
            return null;
        }


        //public void SaveToSql(ISqlDumper dmp, NameWithSchema tableName, string[] columnPaths,
        //    NameWithSchema[] tableNames, string[] columnNames, int[] primaryKey)
        //{
        //    foreach (var pkVal in DeletedRows)
        //    {
        //        dmp.Put("^delete ^from %f where ", tableName);
        //        for (int i = 0; i < primaryKey.Length; i++)
        //        {
        //            if (i > 0) dmp.Put(" ^and ");
        //            dmp.Put("%i = %v", columnNames[primaryKey[i]], pkVal[i]);
        //        }
        //        dmp.Put(";&n");
        //    }
        //    foreach (var change in ChangedRows)
        //    {
        //        if (change.UpdateKey == null) continue;
        //        var tables = new HashSet<string>();
        //        foreach(var item in change.ChangedItems)
        //        {
        //            int index = columnPaths.IndexOfEx(item.Column);
        //            if (index<0) continue;
        //            if ()
        //        }
        //    }
        //}
        public bool HasChanges()
        {
            return UpdatedRows.Count > 0 || DeletedRows.Count > 0;
        }
    }
}
