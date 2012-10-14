using System;
using System.Collections.Generic;
using System.Xml;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.DmlFramework
{
    public enum DmlfJoinType { Inner, Outer, Left, Right }
    public enum DmlfBinaryOperator { Inner, Outer, Left, Right }

    public interface IDmlfHandler
    {
        TableInfo GetStructure(NameWithSchema name);
        DmlfSource BaseTable { get; }
    }

    public interface IDmlfNode
    {
        void ForEachChild(Action<IDmlfNode> action);
        void GenSql(ISqlDumper dmp, IDmlfHandler handler);
    }

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

        public virtual void GenSql(ISqlDumper dmp, IDmlfHandler handler)
        {
            throw new NotImplementedError("DBM-00000");
        }

        public virtual bool DmlfEquals(DmlfBase obj)
        {
            return base.Equals(obj);
        }

        public override bool Equals(object obj)
        {
            if (obj == null) return false;
            if (obj.GetType() != GetType()) return false;
            return DmlfEquals((DmlfBase)obj);
        }
        public static bool operator ==(DmlfBase a, DmlfBase b)
        {
            if ((object)a == null || (object)b == null) return (object)a == null && (object)b == null;
            return a.Equals(b);
        }
        public static bool operator !=(DmlfBase a, DmlfBase b)
        {
            return !(a == b);
        }

        public override string ToString()
        {
            return this.ToSql(GenericDatabaseFactory.Instance, null);
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
    }

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

    public class DmlfHandler : IDmlfHandler
    {
        public Dictionary<NameWithSchema, TableInfo> Tables = new Dictionary<NameWithSchema, TableInfo>();
        public TableInfo BaseStructure;
        public DatabaseInfo Database;

        #region IDmlfHandler Members

        public virtual TableInfo GetStructure(NameWithSchema name)
        {
            if (name == null && BaseStructure != null) return BaseStructure;
            var res = Tables.Get(name);
            if (res != null) return res;
            //if (Database != null && name != null) return Database.GetTable(name).InvokeLoadStructure(TableInfoMembers.ColumnNames | TableInfoMembers.PrimaryKey);
            //if (Database != null && BaseTable != null && BaseTable.TableOrView != null) return Database.GetTable(BaseTable.TableOrView).InvokeLoadStructure(TableInfoMembers.ColumnNames | TableInfoMembers.PrimaryKey);
            return null;
        }

        public DmlfSource BaseTable { get; set; }

        #endregion
    }
}
