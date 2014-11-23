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
        DbDiffAction m_actions;
        DatabaseInfo m_src;
        DatabaseInfo m_dst;
        AlterPlan m_plan;
        internal DbDiffOptions m_options;
        internal IDatabaseFactory _factory;
        Dictionary<string, DatabaseObjectInfo> srcGroupIds = new Dictionary<string, DatabaseObjectInfo>();
        Dictionary<string, DatabaseObjectInfo> dstGroupIds = new Dictionary<string, DatabaseObjectInfo>();

        HashSet<string> alteredObjects = new HashSet<string>();
        //Dictionary<string, IAbstractObjectStructure> AlteredSourceObjects = new Dictionary<string, IAbstractObjectStructure>();
        //Dictionary<string, IAbstractObjectStructure> AlteredTargetObjects = new Dictionary<string, IAbstractObjectStructure>();

        internal Dictionary<string, DbDiffAction> IdToAction = new Dictionary<string, DbDiffAction>();

        public event Action<DbDiffAction> ChangedAction;

        public DatabaseDiff(DatabaseInfo src, DatabaseInfo dst, DbDiffOptions options, IDatabaseFactory factory)
        {
            _factory = factory;
            m_src = src.CloneDatabase();
            m_dst = dst.CloneDatabase();
            m_actions = new DbDiffAction(this);
            //m_actions = new DiffActionDatabase(this, m_src, m_dst);
            m_options = options;
            RebuildGroupIdDictionary();
            if (m_src.GroupId != m_dst.GroupId) CreatePairing();
            CreateActions();
        }

        public DatabaseInfo Source { get { return m_src; } }
        public DatabaseInfo Target { get { return m_dst; } }
        public AlterPlan Plan { get { return m_plan; } }

        public DbDiffAction Actions { get { return m_actions; } }

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
            srcGroupIds.Clear();
            dstGroupIds.Clear();
            foreach (DatabaseObjectInfo obj in m_src.GetAllObjects())
            {
                srcGroupIds[obj.GroupId] = obj;
            }
            foreach (DatabaseObjectInfo obj in m_dst.GetAllObjects())
            {
                dstGroupIds[obj.GroupId] = obj;
            }
        }

        public void CallChangedAction(DbDiffAction action)
        {
            if (ChangedAction != null) ChangedAction(action);
        }
    }
}
