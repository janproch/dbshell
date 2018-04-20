using DbShell.Core.Utility;
using DbShell.Driver.Common.Interfaces;
using DbShell.Driver.Common.Structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.Core
{
    public class CopyAllTables : RunnableBase
    {
        public string SourceConnection { get; set; }
        public string TargetConnection { get; set; }
        public bool DisableConstraints { get; set; } = false;

        protected override void DoRun(IShellContext context)
        {
            var sourceProvider = ConnectionProvider.FromString(context.ServiceProvider, context.Replace(SourceConnection));
            var targetProvider = ConnectionProvider.FromString(context.ServiceProvider, context.Replace(TargetConnection));

            DatabaseInfo db;
            using (var conn = sourceProvider.Connect())
            {
                var analyser = sourceProvider.Factory.CreateAnalyser();
                analyser.Connection = conn;
                analyser.FullAnalysis();
                db = analyser.Structure;
            }

            foreach (var table in db.Tables)
            {
                var copy = new CopyTable
                {
                    Source = new Table { Name = table.Name, Connection = SourceConnection },
                    Target = new Table { Name = table.Name, Connection = TargetConnection },
                    DisableConstraints = DisableConstraints,
                };
                copy.Run(context.CreateChildContext());
            }
        }
    }
}
