using DbShell.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.RelatedDataSync.SqlModel
{
    public class DataSyncSqlModel
    {
        private List<EntitySqlModel> _entities = new List<EntitySqlModel>();

        SyncModel _model;
        public DataSyncSqlModel(SyncModel model, IShellContext context)
        {
            _model = model;
            foreach(var entity in model.Targets)
            {
                _entities.Add(new EntitySqlModel(this, entity, context));
            }
        }

        public void Run()
        {
        }
    }
}
