using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

#if !NETCOREAPP1_1
namespace DbShell.Driver.Sqlite
{
    public class SqliteAnalyser : DatabaseAnalyser
    {
        protected override void DoRunAnalysis()
        {
            var tablesByName = new Dictionary<string, TableInfo>();

            foreach (DataRow row in Connection.GetSchema("Tables").Rows)
            {
                string tname = row["TABLE_NAME"].SafeToString();
                string type = row["TABLE_TYPE"].SafeToString();
                if (type != "table") continue;
                if (String.IsNullOrEmpty(tname)) continue;
                var tbl = new TableInfo(Structure);
                tablesByName[tname] = tbl;
                Structure.Tables.Add(tbl);
                tbl.FullName = new NameWithSchema(tname);
            }

            foreach (DataRow row in Connection.GetSchema("Columns").Rows)
            {
                string tname = row["TABLE_NAME"].SafeToString();
                string cname = row["COLUMN_NAME"].SafeToString();
                if (String.IsNullOrEmpty(tname) || String.IsNullOrEmpty(cname)) continue;
                if (!tablesByName.ContainsKey(tname)) continue;
                var tbl = tablesByName[tname];
                var col = new ColumnInfo(tbl);
                col.Name = cname;
                tbl.Columns.Add(col);
            }

            //foreach (var table in Structure.Tables)
            //{
            //    if (table.PrimaryKey == null)
            //    {
            //        var rowid = new ColumnInfo(table);
            //        rowid.Name = "rowid";
            //        rowid.NotNull = true;
            //        rowid.DataType = "int";
            //        rowid.CommonType = new DbTypeInt();
            //        rowid.PrimaryKey = true;
            //        table.Columns.Insert(0, rowid);
            //        table.PrimaryKey = new PrimaryKeyInfo(table);
            //        table.PrimaryKey.Columns.Add(new ColumnReference { RefColumn = rowid });
            //    }
            //}
        }

        protected override void DoGetModifications()
        {
            throw new NotImplementedError("DBSH-00164");
        }
    }
}
#endif
