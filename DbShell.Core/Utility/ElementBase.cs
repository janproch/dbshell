using System;
using System.Collections.Generic;
using System.ComponentModel;
using DbShell.Common;
using DbShell.Driver.Common.Structure;

namespace DbShell.Core.Utility
{
    public class ElementBase : IShellElement
    {
        [TypeConverter(typeof (ConnectionTypeConverter))]
        public IConnectionProvider Connection { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IShellContext Context { get; set; }

        public virtual void EnumChildren(Action<IShellElement> enumFunc)
        {
            
        }

        protected void YieldChild(Action<IShellElement> enumFunc, object value)
        {
            var obj = value as IShellElement;
            if (obj != null) enumFunc(obj);
        }

        protected DatabaseInfo GetDatabaseStructure()
        {
            return Context.GetDatabaseStructure(Connection);
        }
    }
}
