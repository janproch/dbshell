using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.RelatedDataSync.SqlModel
{
    public class SourceColumnSqlModel
    {
        public string Alias;

        public List<SourceEntitySqlModel> Entities = new List<SourceEntitySqlModel>();
        public List<SourceColumn> DbshColumns = new List<SourceColumn>();
    }
}
