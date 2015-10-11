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

        public void Run(DbConnection conn, IDatabaseFactory factory)
        {
            foreach (var ent in Entities)
            {
                ent.Run(conn, factory);
            }
        }

        public void CreateProcedure(DbConnection conn, IDatabaseFactory factory, NameWithSchema name)
        {
            var sw = new StringWriter();
            var so = new SqlOutputStream(factory.CreateDialect(), sw, new SqlFormatProperties());
            so.OverrideCommandDelimiter(";\n");
            var dmp = factory.CreateDumper(so, new SqlFormatProperties());

            dmp.Put("^create ^procedure %f ^as &n", name);
            dmp.Put("^begin&n");
            foreach (var ent in Entities)
            {
                ent.Run(dmp);
            }
            dmp.Put("^end&n");

            using (var cmd = conn.CreateCommand())
            {
                cmd.CommandText = sw.ToString();
                cmd.ExecuteNonQuery();
            }
        }
    }
}
