using DbShell.Driver.Common.Structure;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.RelatedDataSync.SqlModel
{
    public class SourceEntitySqlModel
    {
        public NameWithSchema TableName;

        public List<SourceColumnSqlModel> Columns = new List<SourceColumnSqlModel>();
        private Source _dbsh;
        public string SqlAlias;

        public SourceEntitySqlModel(Source dbsh)
        {
            this._dbsh = dbsh;
        }

        public Source Dbsh
        {
            get { return _dbsh; }
        }

        public string SingleKeyColumn
        {
            get
            {
                var res = _dbsh.Columns.Where(x => x.IsKey).Select(x => x.AliasOrName).ToList();
                if (res.Count == 1) return res[0];
                return null;
            }
        }
    }
}
