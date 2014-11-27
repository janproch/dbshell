using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.DbDiff
{
    public partial class DatabaseDiff
    {
        DbDiffAction _actions;
        DatabaseInfo _src;
        DatabaseInfo _dst;
        AlterPlan _plan;
        internal DbDiffOptions _options;
        internal IDatabaseFactory _factory;
        Dictionary<string, DatabaseObjectInfo> _srcGroupIds = new Dictionary<string, DatabaseObjectInfo>();
        Dictionary<string, DatabaseObjectInfo> _dstGroupIds = new Dictionary<string, DatabaseObjectInfo>();

        HashSet<string> alteredObjects = new HashSet<string>();
        //Dictionary<string, IAbstractObjectStructure> AlteredSourceObjects = new Dictionary<string, IAbstractObjectStructure>();
        //Dictionary<string, IAbstractObjectStructure> AlteredTargetObjects = new Dictionary<string, IAbstractObjectStructure>();

        internal Dictionary<string, DbDiffAction> IdToAction = new Dictionary<string, DbDiffAction>();

        public event Action<DbDiffAction> ChangedAction;

        public DatabaseDiff(DatabaseInfo src, DatabaseInfo dst, DbDiffOptions options, IDatabaseFactory factory)
        {
            _factory = factory;
            _src = src.CloneDatabase();
            _dst = dst.CloneDatabase();
            _actions = new DbDiffAction(this);
            //m_actions = new DiffActionDatabase(this, m_src, m_dst);
            _options = options;
            RebuildGroupIdDictionary();
            if (_src.GroupId != _dst.GroupId) CreatePairing();
            CreateActions();
        }

        public DatabaseInfo Source { get { return _src; } }
        public DatabaseInfo Target { get { return _dst; } }
        public AlterPlan Plan { get { return _plan; } }

        public DbDiffAction Actions { get { return _actions; } }

        public DbDiffOptions Options
        {
            get { return _options; }
        }

        internal void AddAlteredObject(DatabaseObjectInfo obj)
        {
            if (obj.GroupId != null) alteredObjects.Add(obj.GroupId);
        }

        public bool IsAltered(DatabaseObjectInfo obj)
        {
            return alteredObjects.Contains(obj.GroupId);
        }

        private void RebuildGroupIdDictionary()
        {
            _srcGroupIds.Clear();
            _dstGroupIds.Clear();
            foreach (DatabaseObjectInfo obj in _src.GetAllObjects())
            {
                _srcGroupIds[obj.GroupId] = obj;
            }
            foreach (DatabaseObjectInfo obj in _dst.GetAllObjects())
            {
                _dstGroupIds[obj.GroupId] = obj;
            }
        }

        public void CallChangedAction(DbDiffAction action)
        {
            if (ChangedAction != null) ChangedAction(action);
        }
    }
}
