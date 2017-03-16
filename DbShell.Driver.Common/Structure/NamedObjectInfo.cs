using DbShell.Driver.Common.Utility;
using System.Runtime.Serialization;

namespace DbShell.Driver.Common.Structure
{
    [DataContract]
    public abstract class NamedObjectInfo : DatabaseObjectInfo, IFullNamedObject
    {
        /// <summary>
        /// Full name of object (with schema)
        /// </summary>
        public NameWithSchema FullName { get; set; }

        /// <summary>
        /// Name (without schema)
        /// </summary>
        [XmlAttrib("name")]
        [DataMember]
        public string Name
        {
            get
            {
                if (FullName != null) return FullName.Name;
                return null;
            }
            set
            {
                if (FullName != null) FullName = new NameWithSchema(FullName.Schema, value);
                else FullName = new NameWithSchema(value);
            }
        }

        /// <summary>
        /// Schema name
        /// </summary>
        [XmlAttrib("schema")]
        [DataMember]
        public string Schema
        {
            get
            {
                if (FullName != null) return FullName.Schema;
                return null;
            }
            set
            {
                if (FullName != null) FullName = new NameWithSchema(value, FullName.Name);
                else FullName = new NameWithSchema(value, null);
            }
        }

        public NamedObjectInfo(DatabaseInfo database)
            : base(database)
        {
        }

        public override void Assign(DatabaseObjectInfo source)
        {
            base.Assign(source);
            var src = (NamedObjectInfo) source;
            FullName = src.FullName;
        }

        public override string ToString()
        {
            return FullName.ToString();
        }
    }
}