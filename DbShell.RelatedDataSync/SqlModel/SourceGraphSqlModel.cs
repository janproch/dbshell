using DbShell.Common;
using DbShell.Driver.Common.DmlFramework;
using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.RelatedDataSync.SqlModel
{
    public class SourceGraphSqlModel : SourceGraphSqlModelBase
    {
        private SyncModel _model;
        private DataSyncSqlModel _dataSync;

        public DataSyncSqlModel DataSync => _dataSync;

        public SourceGraphSqlModel(SyncModel model, IShellContext context, DataSyncSqlModel dataSync)
        {
            _model = model;

            if (!model.Sources.Any())
            {
                throw new IncorrectRdsDefinitionException("LGM-00000 There are no available sources entities. Try to add source.");
            }

            foreach (var item in model.Sources)
            {
                var src = new SourceEntitySqlModel(item, dataSync);
                Entities.Add(src);
                src.SqlAlias = item.Alias ?? "src_" + Entities.Count;
                src.InitializeQuerySource(item.DataSource, context, context.Replace(item.SourceTableVariable), context.Replace(item.SourceQueryVariable));
                src.MaterializeIfNeeded();

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
                    if (!String.IsNullOrEmpty(colItem.Filter))
                    {
                        Columns[alias].Filters.Add(colItem.Filter);
                        if (colItem.FilterType != FilterParserTool.ExpressionType.None)
                        {
                            Columns[alias].FilterType = colItem.FilterType;
                        }
                    }
                }
            }
        }
    }
}
