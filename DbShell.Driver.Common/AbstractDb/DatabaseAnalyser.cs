using System;
using System.Data.Common;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.AbstractDb
{
    public abstract class DatabaseAnalyser : IDisposable
    {
        protected DbConnection _conn;
        protected string _dbname;
        DatabaseInfo _result;

        public void Run(DbConnection conn, string dbname)
        {
            _conn = conn;
            _dbname = dbname;
            _result = new DatabaseInfo();
            DoRun();
            _result.Tables.Sort((a, b) => String.Compare(a.FullName.ToString(), b.FullName.ToString(), true));
        }

        protected abstract void DoRun();

        public DatabaseInfo Result { get { return _result; } }

        public virtual void Dispose()
        {
        }
    }
}
