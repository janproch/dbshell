using DbShell.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.RelatedDataSync.SqlModel
{
    public class SourceGraphSqlModel : SourceGraphSqlModelBase
    {
        private SyncModel _model;

        public SourceGraphSqlModel(SyncModel model, IShellContext context)
        {
            _model = model;

            foreach (var item in model.Sources)
            {
                var src = new SourceEntitySqlModel(item);
                Entities.Add(src);
                src.SqlAlias = "src_" + Entities.Count;
                var tableOrView = item.DataSource as DbShell.Core.Utility.TableOrView;
                if (tableOrView != null) src.TableName = tableOrView.GetFullName(context);
                foreach (var colItem in item.Columns)
                {
                    string alias = colItem.AliasOrName;
                    if (!Columns.ContainsKey(alias))
                    {
                        Columns[alias] = new SourceColumnSqlModel
                        {
                            Alias = alias,
                        };
                    }
                    Columns[alias].DbshColumns.Add(colItem);
                    Columns[alias].Entities.Add(src);
                    src.Columns.Add(Columns[alias]);
                }
            }
        }
    }
}
