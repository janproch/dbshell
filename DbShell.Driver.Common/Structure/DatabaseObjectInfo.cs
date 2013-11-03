using System;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.Structure
{
    public enum DatabaseObjectType
    {
        Table,
        View,
        Procedure,
        Function,
        PrimaryKey,
        Parameter,
        Column,
        ForeignKey
    }

    public abstract class DatabaseObjectInfo
    {
        public DatabaseInfo OwnerDatabase { get; private set; }
        public PropertyBag Properties { get; private set; }
        public abstract DatabaseObjectType ObjectType { get; }

        [XmlAttrib("id")]
        public string ObjectId { get; set; }

        [XmlAttrib("created")]
        public DateTime? CreateDate { get; set; }

        [XmlAttrib("modified")]
        public DateTime? ModifyDate { get; set; }

        public DatabaseObjectInfo(DatabaseInfo database)
        {
            OwnerDatabase = database;
            Properties = new PropertyBag();
        }

        protected virtual void Assign(DatabaseObjectInfo source)
        {
            foreach (var item in source.Properties)
            {
                Properties.Add(item.Key, item.Value);
            }
        }

        public virtual void AfterLoadLink()
        {
        }
    }
}