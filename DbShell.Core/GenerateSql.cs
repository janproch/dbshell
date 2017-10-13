using DbShell.Core.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using DbShell.Common;
using DbShell.Driver.Common.Utility;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Sql;
using System.IO;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Core.NetCore.SqlGenerator;
using DbShell.Driver.Common;

namespace DbShell.Core.NetCore
{
    public class GenerateSqlTableOptions
    {
        public bool AllTables { get; set; }
        public List<NameWithSchema> TableFilter { get; set; } = new List<NameWithSchema>();

        public bool DropTables { get; set; }
        public bool DropReferences { get; set; }
        public bool CheckIfTableExists { get; set; }

        public bool CreateTables { get; set; }
        public bool CreateReferences { get; set; }
        public bool CreateForeignKeys { get; set; }
        public bool CreateIndexes { get; set; }

        public bool Insert { get; set; }
        public bool SkipAutoincrementColumn { get; set; }
        public bool DisableConstraints { get; set; }
        public bool OmitNulls { get; set; }

        public bool Truncate { get; set; }
    }

    public class GenerateSqlObjectOptions
    {
        public bool AllObjects { get; set; }
        public List<NameWithSchema> ObjectFilter { get; set; } = new List<NameWithSchema>();

        public bool CheckExists { get; set; }
        public bool Drop { get; set; }
        public bool Create { get; set; }
    }

    public class GenerateSql : RunnableBase
    {
        public string OutputFile { get; set; }
        public int FileSizeLimit { get; set; }
        public ICancelableProcessCallback Cancellable { get; set; }

        public GenerateSqlTableOptions TableOptions { get; set; } = new GenerateSqlTableOptions();
        public GenerateSqlObjectOptions ViewOptions { get; set; } = new GenerateSqlObjectOptions();
        public GenerateSqlObjectOptions StoredProcedureOptions { get; set; } = new GenerateSqlObjectOptions();
        public GenerateSqlObjectOptions FunctionOptions { get; set; } = new GenerateSqlObjectOptions();

        protected override void DoRun(IShellContext context)
        {
            var db = GetDatabaseStructure(context);
            var provider = GetConnectionProvider(context);
            string file = context.ResolveFile(OutputFile, ResolveFileMode.Output);

            using (var sw = new StreamWriter(file))
            {
                var model = new SqlGeneratorModel(provider, sw, this, db, Cancellable);
                model.Run();
            }
        }
    }
}
