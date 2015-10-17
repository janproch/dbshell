using DbShell.Common;
using DbShell.Driver.Common.AbstractDb;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Sql;
using System.IO;

namespace DbShell.RelatedDataSync.SqlModel
{
    public class DataSyncSqlModel
    {
        public List<TargetEntitySqlModel> Entities = new List<TargetEntitySqlModel>();
        public SourceGraphSqlModel SourceGraphModel;

        SyncModel _model;
        public DataSyncSqlModel(SyncModel model, IShellContext context)
        {
            _model = model;
            SourceGraphModel = new SourceGraphSqlModel(model, context);
            foreach (var entity in model.Targets)
            {
                Entities.Add(new TargetEntitySqlModel(this, entity, context));
            }
        }

        public SyncModel Dbsh
        {
            get { return _model; }
        }

        private void RunScript(DbConnection conn, IDatabaseFactory factory, Action<ISqlDumper> prolog, Action<ISqlDumper> epilog)
        {
            var sw = new StringWriter();
            var so = new SqlOutputStream(factory.CreateDialect(), sw, new SqlFormatProperties());
            so.OverrideCommandDelimiter(";");
            var dmp = factory.CreateDumper(so, new SqlFormatProperties());
            if (prolog != null) prolog(dmp);

            dmp.Put("^declare @importDate ^datetime;&n");
            dmp.Put("^set @importDate = ^dateadd(dd, 0, ^datediff(dd, 0, @importDateTime));&n");

            foreach (var ent in Entities)
            {
                WriteHeader(dmp, $"Synchronize entity {ent.SqlAlias} (table {ent.TargetTable})");
                ent.Run(dmp);
            }
            if (epilog != null) epilog(dmp);

            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = sw.ToString();
                cmd.ExecuteNonQuery();
            }
        }

        public void Run(DbConnection conn, IDatabaseFactory factory)
        {
            RunScript(conn, factory, dmp =>
             {
                 dmp.Put("^declare @importDateTime ^datetime;&n");
                 dmp.Put("^^set @importDateTime = ^getdate();&n");
             },
            dmp => { });
        }

        public void CreateProcedure(DbConnection conn, IDatabaseFactory factory, NameWithSchema name)
        {
            RunScript(conn, factory,
                dmp =>
                {
                    dmp.Put("^create ^procedure %f (@importDateTime ^datetime = ^null) ^as &n", name);
                    dmp.Put("^begin&>&n");
                    dmp.Put("^if (@importDateTime ^is ^null) ^set @importDateTime = ^getdate();&n");
                },
                dmp =>
                {
                    dmp.Put("&<&n^end&n");
                });
        }

        private const string SEPARATOR =
            "------------------------------------------------------------------------------------------------";

        public static void WriteSeparatorTitle(ISqlDumper dmp, string title)
        {
            dmp.Put("&n");
            string s = "-- " + title + " ";
            while (s.Length < SEPARATOR.Length) s += "-";
            dmp.Put(s);
            dmp.Put("&n");
        }

        public static void WriteSeparator(ISqlDumper dmp)
        {
            dmp.Put(SEPARATOR);
            dmp.Put("&n");
        }

        public static void WriteHeader(ISqlDumper dmp, string msg)
        {
            dmp.Put("&n");
            WriteSeparator(dmp);
            dmp.Put("-- %s &n", msg);
            WriteSeparator(dmp);
            dmp.Put("&n");
        }

    }
}
