using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Sql;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Sqlite;
using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.IO;
using System.Linq;
using System.Text;

namespace DbShell.LocalDb.LocalDbModels
{
    public class DataSetModel
    {
        private string _file;

        public Dictionary<string, DataSetClass> Classes = new Dictionary<string, DataSetClass>();
        public DatabaseInfo LocalStructure;
        public DatabaseInfo TargetStructure;

        public DataSetModel(string file, DatabaseInfo targetStructure)
        {
            _file = file;
            TargetStructure = targetStructure;

            LoadModel();
        }

        protected SQLiteConnection OpenConnection()
        {
            var conn = new SQLiteConnection("Synchronous=Full;Data Source=" + _file);
            conn.Open();
            return conn;
        }

        public IDatabaseFactory DatabaseFactory
        {
            get { return SqliteDatabaseFactory.Instance; }
        }

        public object ExecuteScalar(SQLiteConnection conn, string sql)
        {
            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = sql;
                return cmd.ExecuteScalar();
            }
        }

        public string FormatSql(string format, params string[] args)
        {
            var sw = new StringWriter();
            var sqlo = new SqlOutputStream(SqliteDatabaseFactory.Instance.CreateDialect(), sw, new SqlFormatProperties());
            var dmp = SqliteDatabaseFactory.Instance.CreateDumper(sqlo, new SqlFormatProperties());
            return dmp.Format(format, args);
        }

        public object ExecuteScalarFormat(SQLiteConnection conn, string format, params string[] args)
        {
            return ExecuteScalar(conn, FormatSql(format, args));
        }

        private void LoadModel()
        {
            LoadStructure();
            using (var conn = OpenConnection())
            {
                foreach (var table in LocalStructure.Tables)
                {
                    int rowCount = (int)ExecuteScalarFormat(conn, "select count(*) from %i", table.Name);
                    var cls = new DataSetClass
                    {
                        Name = table.Name,
                        RowCount = rowCount,
                    };
                    Classes[cls.Name] = cls;
                }
            }
        }

        private void LoadStructure()
        {
            var analyser = DatabaseFactory.CreateAnalyser();
            using (var conn = OpenConnection())
            {
                analyser.Connection = conn;
                analyser.FullAnalysis();
                LocalStructure = analyser.Structure;
            }
        }
    }
}
