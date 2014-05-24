using System;
using System.Collections.Generic;
using DbShell.Driver.Common.AbstractDb;

namespace DbShell.Driver.Common.DmlFramework
{
    public class DmlfList<T> : List<T>, IDmlfNode
        where T : IDmlfNode
    {
        public IDmlfHandler Handler { get; private set; }
        #region IDmlfNode Members

        public virtual void ForEachChild(Action<IDmlfNode> action)
        {
            action(this);
            foreach (var item in this) action(item);
        }

        #endregion

        public virtual void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            dmp.Put("&>");
            bool was = false;
            foreach (var item in this)
            {
                if (was) dmp.Put(",&n");
                else dmp.Put("&n");
                item.GenSql(dmp, handler);
                was = true;
            }
            dmp.Put("&<");
        }
    }
}