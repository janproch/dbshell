using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Driver.Common.AbstractDb;

namespace DbShell.Core
{
    public class CopyTable : ElementBase, IRunnable
    {
        public ITabularDataSource Source { get; set; }
        public ITabularDataTarget Target { get; set; }

        public bool CleanTarget { get; set; }

        void IRunnable.Run()
        {
            var options = new CopyTableTargetOptions
                {
                    TruncateBeforeCopy = CleanTarget,
                };

            var table = Source.GetRowFormat();
            using (var reader = Source.CreateReader())
            {
                using (var writer = Target.CreateWriter(table, options))
                {
                    while (reader.Read())
                    {
                        writer.Write(reader);
                    }
                }
            }
        }

        public override void EnumChildren(Action<IShellElement> enumFunc)
        {
            base.EnumChildren(enumFunc);

            YieldChild(enumFunc, Source);
            YieldChild(enumFunc, Target);
        }
    }
}
