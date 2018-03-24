using System;
using System.Collections.Generic;
using System.Xml;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.DmlFramework
{
    public abstract class DmlfBase : IDmlfNode, IExplicitXmlPersistent
    {
        #region IDmlfNode Members

        public virtual void ForEachChild(Action<IDmlfNode> action)
        {
            action(this);
        }

        #endregion

        #region IExplicitXmlPersistent Members

        public virtual void SaveToXml(XmlElement xml)
        {
            this.SaveProperties(xml);
        }

        public virtual void LoadFromXml(XmlElement xml)
        {
            this.LoadProperties(xml);
        }

        #endregion

        public virtual void GenSql(ISqlDumper dmp)
        {
            throw new NotImplementedError("DBSH-00072");
        }

        public virtual bool DmlfEquals(DmlfBase obj)
        {
            return base.Equals(obj);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != GetType()) return false;
            return DmlfEquals((DmlfBase) obj);
        }

        public static bool operator ==(DmlfBase a, DmlfBase b)
        {
            if ((object) a == null || (object) b == null) return (object) a == null && (object) b == null;
            return a.Equals(b);
        }

        public static bool operator !=(DmlfBase a, DmlfBase b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            return this.ToSql(GenericDatabaseFactory.InternalInstance);
        }

        public virtual string GetIdentifier()
        {
            var res = ToString();
            res = res.Replace(" ", "_");
            res = res.Replace(".", "_");
            res = res.Replace("-", "_");
            res = res.Replace("(SOURCE)", "basetbl");
            return res;
        }

        public static HashSet<T> ExtractNodes<T>(IDmlfNode node)
            where T : class, IDmlfNode
        {
            var res = new HashSet<T>();
            ExtractNodes(node, res);
            return res;
        }

        private static void ExtractNodes<T>(IDmlfNode node, HashSet<T> res)
            where T : class, IDmlfNode
        {
            node.ForEachChild(child =>
                {
                    var add = child as T;
                    if (add != null) res.Add(add);
                });
        }
    }
}