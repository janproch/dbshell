using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;

namespace DbShell.Spatial
{
    public class ShpClose : ShpRunnableBase
    {
        protected override void DoRun(IShellContext context)
        {
            GetModel(context).Close();
        }
    }
}
