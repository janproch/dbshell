using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.DbDiff
{
    public class DbSourceTarget
    {
        DatabaseInfo m_src;
        DatabaseInfo m_dst;

        public DatabaseInfo Source { get { return m_src; } }
        public DatabaseInfo Target { get { return m_dst; } }

        public DbSourceTarget(DatabaseInfo src, DatabaseInfo dst)
        {
            m_src = src;
            m_dst = dst;
        }
    }

    public class DbObjectPairing : DbSourceTarget
    {
        Dictionary<string, DatabaseObjectInfo> srcGroupIds = new Dictionary<string, DatabaseObjectInfo>();
        Dictionary<string, DatabaseObjectInfo> dstGroupIds = new Dictionary<string, DatabaseObjectInfo>();

        public DbObjectPairing(DatabaseInfo src, DatabaseInfo dst)
            : base(src, dst)
        {
            srcGroupIds.Clear();
            dstGroupIds.Clear();
            foreach (var obj in Source.GetAllObjects())
            {
                srcGroupIds[obj.GroupId] = obj;
            }
            foreach (var obj in Target.GetAllObjects())
            {
                dstGroupIds[obj.GroupId] = obj;
            }
        }

        public bool IsPaired(DatabaseObjectInfo obj)
        {
            return srcGroupIds.ContainsKey(obj.GroupId) && dstGroupIds.ContainsKey(obj.GroupId);
        }

        public T FindPair<T>(T obj)
            where T : DatabaseObjectInfo
        {
            var src = srcGroupIds.Get(obj.GroupId, null);
            var dst = dstGroupIds.Get(obj.GroupId, null);
            if (src == obj) return (T)dst;
            if (dst == obj) return (T)src;
            return null;
        }

    }
}
