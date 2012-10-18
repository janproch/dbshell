using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;

namespace DbShell.Core
{
    public class CopyTable : ElementBase, IRunnable
    {
        public ITabularDataSource Source { get; set; }
        public ITabularDataTarget Target { get; set; }

        void IRunnable.Run(IShellContext context)
        {
            var table = Source.GetRowFormat();
            using (var reader = Source.CreateReader())
            {
                using (var writer = Target.CreateWriter(table))
                {
                    while (reader.Read())
                    {
                        writer.Write(reader);
                    }
                }
            }
        }
    }
}
