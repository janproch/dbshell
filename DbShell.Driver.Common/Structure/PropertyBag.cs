using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Driver.Common.Structure
{
    public class PropertyBag : Dictionary<string, string>
    {
        public new string this[string name]
        {
            get
            {
                if (ContainsKey(name)) return base[name];
                return null;
            }
            set
            {
                base[name] = value;
            }
        }
    }
}
