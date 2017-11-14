using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Utility;
using System.Runtime.Serialization;

namespace DbShell.Driver.Common.Structure
{
    [DataContract]
    public class ParameterInfo : DatabaseObjectInfo
    {
        public ProgrammableInfo Programmable;

        /// <summary>
        /// Parameter name
        /// </summary>
        [XmlAttrib("name")]
        [DataMember]
        public string Name { get; set; }

        /// <summary>
        /// Data type
        /// </summary>
        [XmlAttrib("datatype")]
        [DataMember]
        public string DataType { get; set; }

        /// <summary>
        /// Data type
        /// </summary>
        [XmlAttrib("is_output")]
        [DataMember]
        public bool IsOutput { get; set; }

        public ParameterInfo(ProgrammableInfo programmable)
            : base(programmable != null ? programmable.OwnerDatabase : null)
        {
            Programmable = programmable;
        }

        public override DatabaseObjectType ObjectType
        {
            get { return DatabaseObjectType.Parameter; }
        }

        public ParameterInfo Clone(ProgrammableInfo owner)
        {
            var res = new ParameterInfo(owner);
            res.Assign(this);
            return res;
        }

        public override void Assign(DbShell.Driver.Common.Structure.DatabaseObjectInfo source)
        {
            base.Assign(source);
            var src = (ParameterInfo) source;
            Name = src.Name;
            DataType = src.DataType;
            IsOutput = src.IsOutput;
        }

        public override FullDatabaseRelatedName GetName()
        {
            return new FullDatabaseRelatedName
                {
                    ObjectName = Programmable != null ? Programmable.FullName : null,
                    ObjectType = DatabaseObjectType.Parameter,
                    SubName = Name,
                };
        }
    }
}
