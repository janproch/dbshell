using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;

namespace DbShell.Core
{
    public class CopyTable : ElementBase, IRunnable
    {
        public ITabularDataSource Source { get; set; }
        public ITabularDataTarget Target { get; set; }

        void IRunnable.Run(IShellContext context)
        {
            string data = Source.GetData();
            Target.PutData(data);
        }
    }
}
