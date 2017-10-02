using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading;

namespace DbShell.Driver.Common.Utility
{
    public class NeutralCultureObject : IDisposable
    {
        CultureInfo old, oldui;
        public NeutralCultureObject()
        {
#if !NETSTANDARD2_0
            old = Thread.CurrentThread.CurrentCulture;
            oldui = Thread.CurrentThread.CurrentUICulture;
            Thread.CurrentThread.CurrentCulture = CultureInfo.InvariantCulture;
            Thread.CurrentThread.CurrentUICulture = CultureInfo.InvariantCulture;
#endif
        }
        public void Close() { Dispose(); }
        public void Dispose()
        {
#if !NETSTANDARD2_0
            Thread.CurrentThread.CurrentCulture = old;
            Thread.CurrentThread.CurrentUICulture = oldui;
#endif
        }
    }
}
