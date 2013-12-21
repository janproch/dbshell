using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.Sql;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Sqlite
{
    public class SqliteStorage : ICdlWriter
    {
        public event Action Disposing;
        private SQLiteConnection _conn;
        private string _file;
        private TableInfo _table;
        public const string TABLE_NAME = "_data";
        private int _rowCount;
        private SQLiteTransaction _tran;

        public SqliteStorage(TableInfo table)
        {
            _file = Path.GetTempFileName();
            _table = table;
            _conn = new SQLiteConnection("Synchronous=Full;Data Source=" + _file);
            _conn.Open();
            string sql = String.Format("create table {0} ({1})", TABLE_NAME, ColumnsText);
            _conn.ExecuteNonQuery(sql);
        }

        private string ColumnsText
        {
            get
            {
                var sb = new StringBuilder();
                for (int i = 0; i < _table.Columns.Count; i++)
                {
                    if (i > 0) sb.Append(",");
                    sb.AppendFormat("f{0},c{0}", i);
                }
                return sb.ToString();
            }
        }

        public TableInfo Structure
        {
            get { return _table; }
        }

        public int RowCount
        {
            get { return _rowCount; }
        }

        public void Dispose()
        {
            _conn.Close();
            System.IO.File.Delete(_file);

            if (Disposing != null)
            {
                Disposing();
                Disposing = null;
            }
        }

        private void WantTransaction()
        {
            if (_tran == null)
            {
                _tran = _conn.BeginTransaction();
            }
        }

        public void Write(ICdlRecord row)
        {
            WantTransaction();

            var sb = new StringBuilder();
            sb.AppendFormat("insert into {0} ({1}) values (", TABLE_NAME, ColumnsText);

            for (int i = 0; i < row.FieldCount; i++)
            {
                row.ReadValue(i);
                if (i > 0) sb.Append(",");
                sb.Append((int) row.GetFieldType());
                sb.Append(",");
                string sqldata;
                StorageTool.GetValueAsSqlLiteral(row, out sqldata);
                sb.Append(sqldata);
            }
            sb.Append(")");

            using (var inscmd = _conn.CreateCommand())
            {
                inscmd.Transaction = _tran;
                inscmd.CommandText = sb.ToString();
                inscmd.ExecuteNonQuery();
                _rowCount++;
            }
        }

        //private string CreateQuery(int start = 0, int? count = null)
        //{
        //    var sb = new StringBuilder();
        //    sb.AppendFormat("select {0} from {1} order by rowid", ColumnsText, TABLE_NAME);
        //    if (count != null) sb.AppendFormat(" limit {0},{1}", start, count);
        //    return sb.ToString();
        //}

        public CdlTable LoadTableData(string query)
        {
            var table = new CdlTable(_table);
            using (var selcmd = _conn.CreateCommand())
            {
                selcmd.CommandText = query;
                using (var reader = selcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        var row = new ArrayDataRecord(_table);
                        for (int i = 0; i < _table.ColumnCount; i++)
                        {
                            row.SeekValue(i);
                            var type = (TypeStorage) reader.GetInt32(i*2);
                            StorageTool.ReadValue(reader, i*2 + 1, type, row);
                        }
                        table.AddRowInternal(row);
                    }
                }
            }
            return table;
        }

        public IEnumerable<ICdlRecord> EnumRows(ArrayDataRecord record, string query)
        {
            using (var selcmd = _conn.CreateCommand())
            {
                selcmd.CommandText = query;
                using (var reader = selcmd.ExecuteReader())
                {
                    while (reader.Read())
                    {
                        for (int i = 0; i < _table.ColumnCount; i++)
                        {
                            record.SeekValue(i);
                            var type = (TypeStorage) reader.GetInt32(i*2);
                            StorageTool.ReadValue(reader, i*2 + 1, type, record);
                        }
                        yield return record;
                    }
                }
            }
        }

        public ICdlReader CreateReader(string query)
        {
            var reader = new CdlStorageReader(Structure);
            reader.SetEnumerator(EnumRows(reader, query));
            return reader;
        }

        public void Flush()
        {
            if (_tran != null)
            {
                _tran.Commit();
                _tran = null;
            }
        }

        public object ExecuteScalar(string sql)
        {
            using (var cmd = _conn.CreateCommand())
            {
                cmd.CommandText = sql;
                var res = cmd.ExecuteScalar();
                return res;
            }
        }
    }
}
