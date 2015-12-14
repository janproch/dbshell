using DbShell.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Core.Utility
{
    public static class MiscTool
    {
        public static string ToStringCtx(this object o, IShellContext context)
        {
            var elem = o as ElementBase;
            if (elem != null) return elem.ToStringCtx(context);
            return o?.ToString();
        }

    }
}
