using System;
using System.Collections.Generic;
using System.ComponentModel;
using DbShell.Common;

namespace DbShell.Core.Utility
{
    public class ElementBase : IShellElement
    {
        [TypeConverter(typeof (ConnectionTypeConverter))]
        public IConnectionProvider Connection { get; set; }

        public virtual void EnumChildren(Action<IShellElement> enumFunc)
        {
            
        }

        protected void YieldChild(Action<IShellElement> enumFunc, object value)
        {
            var obj = value as IShellElement;
            if (obj != null) enumFunc(obj);
        }
    }
}
