using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.Structure
{
    public abstract class ProgrammableInfo : NamedObjectInfo
    {
        [XmlElem]
        public string SqlText { get; set; }

        private List<ParameterInfo> _parameters = new List<ParameterInfo>();

        [XmlCollection(typeof(ParameterInfo))]
        public List<ParameterInfo> Parameters { get { return _parameters; } }

        public ProgrammableInfo(DatabaseInfo database)
            : base(database)
        {
        }

        protected override void Assign(DatabaseObjectInfo source)
        {
            base.Assign(source);
            var src = (ProgrammableInfo)source;
            SqlText = src.SqlText;
            foreach(var par in src.Parameters)
            {
                Parameters.Add(par.Clone(this));
            }
        }
    }
}
