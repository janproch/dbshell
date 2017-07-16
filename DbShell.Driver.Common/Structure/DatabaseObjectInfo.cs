using System;
using System.Collections.Generic;
using DbShell.Driver.Common.Utility;
using System.Runtime.Serialization;

namespace DbShell.Driver.Common.Structure
{
    public enum DatabaseObjectType
    {
        Database,
        Table,
        View,
        StoredProcedure,
        Function,
        PrimaryKey,
        Parameter,
        Column,
        ForeignKey,
        Index,
        Unique,
        Check,
        Trigger,
        Schema,
    }

    [DataContract]
    public abstract class DatabaseObjectInfo
    {
        public DatabaseInfo OwnerDatabase { get; internal set; }
        public PropertyBag Properties { get; private set; }
        public abstract DatabaseObjectType ObjectType { get; }

        [XmlAttrib("id")]
        public string ObjectId { get; set; }

        [XmlAttrib("groupid")]
        public string GroupId { get; set; }

        [XmlAttrib("created")]
        public DateTime? CreateDate { get; set; }

        [XmlAttrib("modified")]
        public DateTime? ModifyDate { get; set; }

        public DatabaseObjectInfo(DatabaseInfo database)
        {
            GroupId = Guid.NewGuid().ToString();
            OwnerDatabase = database;
            Properties = new PropertyBag();
        }

        public virtual void Assign(DatabaseObjectInfo source)
        {
            foreach (var item in source.Properties)
            {
                Properties.Add(item.Key, item.Value);
            }
            ObjectId = source.ObjectId;
            GroupId = source.GroupId;
            CreateDate = source.CreateDate;
            ModifyDate = source.ModifyDate;
        }

        public virtual void AfterLoadLink()
        {
        }

        public virtual void AddAllObjects(List<DatabaseObjectInfo> res)
        {
            res.Add(this);
        }

        public virtual DatabaseObjectInfo CloneObject(DatabaseObjectInfo owner)
        {
            throw new Exception(String.Format("DBSH-00211 Object {0} is not cloneable", GetType().FullName));
        }

        public LinkedDatabaseInfo GetLinkedInfo()
        {
            if (OwnerDatabase != null) return OwnerDatabase.LinkedInfo;
            return null;
        }

        //public DatabaseObjectInfo CloneObject()
        //{
        //    var tbl = this as TableInfo;
        //    if (tbl != null) tbl.Clone();
        //    var col = this as ColumnInfo;
        //    if (col != null) col.Clone();
        //    var cnt = this as IConstraint;
        //    if (cnt != null) return Constraint.CreateCopy(cnt);
        //    var spe = this as ISpecificthisectStructure;
        //    if (spe != null) return new SpecificthisectStructure(spe);
        //    var sch = this as ISchemaStructure;
        //    if (sch != null) return new SchemaStructure(sch);
        //    var dom = this as IDomainStructure;
        //    if (dom != null) return new DomainStructure(dom);
        //    var dbs = this as IDatabaseStructure;
        //    if (dbs != null) return new DatabaseStructure(dbs);
        //    return null;
        //}
        public abstract FullDatabaseRelatedName GetName();
    }
}