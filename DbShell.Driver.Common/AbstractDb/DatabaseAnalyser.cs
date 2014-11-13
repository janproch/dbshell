using System;
using System.Data.Common;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.AbstractDb
{
    [Flags]
    public enum DatabaseAnalysePhase
    {
        None = 0,
        Tables = 1,
        Functions = 2,
        Views = 4,
        Settings = 8,
        Finish = 16,

        All = Tables | Functions | Views | Settings | Finish,
    }

    public abstract class DatabaseAnalyser : IDisposable
    {
        protected DbConnection _conn;
        protected string _dbname;
        public DatabaseInfo Structure;
        public DatabaseChangeSet ChangeSet;
        public DatabaseAnalyserFilterOptions FilterOptions;
        public DatabaseServerVersion ServerVersion;
        public DatabaseAnalysePhase Phase = DatabaseAnalysePhase.All;
        private string _linkedServerName;

        public void FullAnalysis()
        {
            CheckInput();
            if (Structure != null) throw new Exception("DBSH-00126 Structure must not be filled");
            if (ChangeSet != null) throw new Exception("DBSH-00127 ChangeSet must not be filled");
            Structure = new DatabaseInfo();
            if (FilterOptions == null) FilterOptions = new DatabaseAnalyserFilterOptions();
            DoRunAnalysis();
            SortStructureItems();
        }

        private void SortStructureItems()
        {
            Structure.Tables.Sort((a, b) => System.String.Compare(a.FullName.ToString(), b.FullName.ToString(), System.StringComparison.OrdinalIgnoreCase));
            Structure.Views.Sort((a, b) => System.String.Compare(a.FullName.ToString(), b.FullName.ToString(), System.StringComparison.OrdinalIgnoreCase));
            Structure.StoredProcedures.Sort((a, b) => System.String.Compare(a.FullName.ToString(), b.FullName.ToString(), System.StringComparison.OrdinalIgnoreCase));
            Structure.Functions.Sort((a, b) => System.String.Compare(a.FullName.ToString(), b.FullName.ToString(), System.StringComparison.OrdinalIgnoreCase));
            Structure.Triggers.Sort((a, b) => System.String.Compare(a.FullName.ToString(), b.FullName.ToString(), System.StringComparison.OrdinalIgnoreCase));
        }

        public void IncrementalAnalysis()
        {
            CheckInput();
            if (Structure == null) throw new Exception("DBSH-00128 Structure required");
            if (ChangeSet == null) throw new Exception("DBSH-00129 ChangeSet required");
            if (FilterOptions != null) throw new Exception("DBSH-00130 FilterOptions must not be filled");
            FilterOptions = ChangeSet.CreateFilter();

            foreach (var item in ChangeSet.Items)
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
                                tbl.Indexes.Clear();
                                tbl.Uniques.Clear();
                                tbl.Checks.Clear();
                                tbl.PrimaryKey = null;
                                tbl.FullName = item.NewName;
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
            SortStructureItems();
        }

        private void CheckInput()
        {
            if (_conn == null) throw new Exception("DBSH-00131 DatabaseAnalyse.Connection is null");
            if (_dbname == null)
            {
                _dbname = _conn.Database;
            }
        }

        public void GetModifications()
        {
            CheckInput();
            if (Structure == null) throw new Exception("DBSH-00132 Structure required");
            if (ChangeSet != null) throw new Exception("DBSH-00133 ChangeSet must not be filled");
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

        public string LinkedServerName
        {
            get { return _linkedServerName; }
            set { _linkedServerName = value; }
        }

        protected abstract void DoRunAnalysis();
        protected abstract void DoGetModifications();

        public virtual void Dispose()
        {
        }

        public bool IsTablesPhase
        {
            get { return (Phase & DatabaseAnalysePhase.Tables) != 0; }
        }

        public bool IsViewsPhase
        {
            get { return (Phase & DatabaseAnalysePhase.Views) != 0; }
        }

        public bool IsFunctionsPhase
        {
            get { return (Phase & DatabaseAnalysePhase.Functions) != 0; }
        }

        public bool IsSettingsPhase
        {
            get { return (Phase & DatabaseAnalysePhase.Settings) != 0; }
        }
    }
}
