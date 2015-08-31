using DbShell.Common;
using DbShell.Driver.Common.DmlFramework;
using DbShell.Driver.Common.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.RelatedDataSync.SqlModel
{
    public class EntitySqlModel
    {
        private DataSyncSqlModel _dataSyncSqlModel;
        private Target _entity;
        public NameWithSchema TargetTable;
        public List<EntityColumn> Columns = new List<EntityColumn>();

        public EntitySqlModel(DataSyncSqlModel dataSyncSqlModel, Target entity, IShellContext context)
        {
            this._dataSyncSqlModel = dataSyncSqlModel;
            this._entity = entity;
            TargetTable = new NameWithSchema(context.Replace(entity.TableSchema), context.Replace(entity.TableName));

            foreach(var col in entity.Columns)
            {

            }
        }

        private DmlfInsertSelect CompileInsert()
        {
            var res = new DmlfInsertSelect();
            res.TargetTable = TargetTable;
            return res;
        }
    }
}
