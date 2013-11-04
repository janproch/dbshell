using System;
using System.Data.Common;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.AbstractDb
{
    public abstract class DatabaseAnalyser : IDisposable
    {
        protected DbConnection _conn;
        protected string _dbname;
        public DatabaseInfo Structure;
        public DatabaseChangeSet ChangeSet;
        public DatabaseAnalyserFilterOptions FilterOptions;

        public void FullAnalysis()
        {
            CheckInput();
            if (Structure != null) throw new Exception("DBSH-00000 Structure must not be filled");
            if (ChangeSet != null) throw new Exception("DBSH-00000 ChangeSet must not be filled");
            Structure = new DatabaseInfo();
            DoRunAnalysis();
            Structure.Tables.Sort((a, b) => System.String.Compare(a.FullName.ToString(), b.FullName.ToString(), System.StringComparison.OrdinalIgnoreCase));
        }

        public void IncrementalAnalysis()
        {
            CheckInput();
            if (Structure == null) throw new Exception("DBSH-00000 Structure required");
            if (ChangeSet == null) throw new Exception("DBSH-00000 ChangeSet required");
            if (FilterOptions != null) throw new Exception("DBSH-00000 FilterOptions must not be filled");
            FilterOptions = ChangeSet.CreateFilter();

            foreach(var item in ChangeSet.Items)
            {
                switch (item.Action)
                {
                    case DatabaseChangeAction.Remove:
                        Structure.RemoveObjectById(item.ObjectId);
                        break;
                    case DatabaseChangeAction.Change:
                        if (item.ObjectType == DatabaseObjectType.Table)
                        {
                            var tbl = Structure.FindObjectById(item.ObjectId) as TableInfo;
                            if (tbl != null)
                            {
                                tbl.Columns.Clear();
                                tbl.ForeignKeys.Clear();
                                tbl.PrimaryKey = null;
                            }
                        }
                        else
                        {
                            Structure.RemoveObjectById(item.ObjectId);
                        }
                        break;
                }
            }

            DoRunAnalysis();
            Structure.Tables.Sort((a, b) => System.String.Compare(a.FullName.ToString(), b.FullName.ToString(), System.StringComparison.OrdinalIgnoreCase));
        }

        private void CheckInput()
        {
            if (_conn == null) throw new Exception("DBSH-00000 DatabaseAnalyse.Connection is null");
            if (_dbname == null)
            {
                _dbname = _conn.Database;
            }
        }

        public void GetModifications()
        {
            CheckInput();
            if (Structure == null) throw new Exception("DBSH-00000 Structure required");
            if (ChangeSet != null) throw new Exception("DBSH-00000 ChangeSet must not be filled");
            ChangeSet = new DatabaseChangeSet();
            DoGetModifications();
        }

        public DbConnection Connection
        {
            get { return _conn; }
            set { _conn = value; }
        }

        public string DatabaseName
        {
            get { return _dbname; }
            set { _dbname = value; }
        }

        protected abstract void DoRunAnalysis();
        protected abstract void DoGetModifications();

        public virtual void Dispose()
        {
        }
    }
}
