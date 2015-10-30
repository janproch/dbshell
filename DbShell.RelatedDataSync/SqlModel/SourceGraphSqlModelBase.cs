using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.RelatedDataSync.SqlModel
{
    public abstract class SourceGraphSqlModelBase
    {
        public List<SourceEntitySqlModel> Entities = new List<SourceEntitySqlModel>();
        public Dictionary<string, SourceColumnSqlModel> Columns = new Dictionary<string, SourceColumnSqlModel>();

        public SourceColumnSqlModel this[string alias]
        {
            get
            {
                if (!Columns.ContainsKey(alias)) throw new Exception($"DBSH-00215 Source alias not found: {alias}");
                return Columns[alias];
            }
        }
    }
}
