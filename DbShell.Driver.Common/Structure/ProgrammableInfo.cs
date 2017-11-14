using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Utility;
using System.Runtime.Serialization;

namespace DbShell.Driver.Common.Structure
{
    public abstract class ProgrammableInfo : SpecificObjectInfo
    {
        private List<ParameterInfo> _parameters = new List<ParameterInfo>();

        [XmlCollection(typeof(ParameterInfo))]
        [DataMember]
        public List<ParameterInfo> Parameters { get { return _parameters; } }

        public ProgrammableInfo(DatabaseInfo database)
            : base(database)
        {
        }

        public override void Assign(DatabaseObjectInfo source)
        {
            base.Assign(source);
            var src = (ProgrammableInfo)source;
            foreach(var par in src.Parameters)
            {
                Parameters.Add(par.Clone(this));
            }
        }
    }
}
