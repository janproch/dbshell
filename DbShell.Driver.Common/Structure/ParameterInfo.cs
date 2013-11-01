using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.Structure
{
    public class ParameterInfo : DatabaseObjectInfo
    {
        public ProgrammableInfo Programmable;

        /// <summary>
        /// Parameter name
        /// </summary>
        [XmlAttrib("name")]
        public string Name { get; set; }

        /// <summary>
        /// Data type
        /// </summary>
        [XmlAttrib("datatype")]
        public string DataType { get; set; }

        /// <summary>
        /// Data type
        /// </summary>
        [XmlAttrib("is_output")]
        public bool IsOutput { get; set; }

        public ParameterInfo(ProgrammableInfo programmable)
            : base(programmable != null ? programmable.OwnerDatabase : null)
        {
            
        }

        public override DatabaseObjectType ObjectType
        {
            get { return DatabaseObjectType.Parameter; }
        }
    }
}
