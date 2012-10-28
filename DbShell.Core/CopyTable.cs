using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Driver.Common.AbstractDb;
using log4net;

namespace DbShell.Core
{
    public class CopyTable : ElementBase, IRunnable
    {
        private static ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

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

            _log.InfoFormat("Copy table data {0}=>{1}", Source, Target);

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
