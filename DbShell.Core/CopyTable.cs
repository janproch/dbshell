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
    /// <summary>
    /// Process, which copies table data (possibly with structure)
    /// </summary>
    public class CopyTable : ElementBase, IRunnable
    {
        private static ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);


        /// <summary>
        /// Source of copy operation
        /// </summary>
        /// <value>
        /// Table or data file
        /// </value>
        public ITabularDataSource Source { get; set; }

        /// <summary>
        /// Target of data operation
        /// </summary>
        /// <value>
        /// Table or data file
        /// </value>
        public ITabularDataTarget Target { get; set; }

        /// <summary>
        /// Gets or sets a value indicating whether clean target table before copying
        /// </summary>
        /// <value>
        ///   <c>true</c> if clean target; otherwise, <c>false</c>. Default is <c>false</c>
        /// </value>
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
