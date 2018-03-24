#if !NETSTANDARD2_0

using System;
using System.Collections.Generic;
using System.Linq;
using DbShell.Driver.Common.Interfaces;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Structure;
using RazorEngine.Templating;

namespace DbShell.Core.RazorModels
{
    /// <summary>
    /// class normalizing names usable in razor templates
    /// </summary>
    /// <typeparam name="TModel"></typeparam>
    public abstract class RazorTemplate<TModel> : TemplateBase<TModel>, IRazorTemplate
    {
        private ISqlDumper _sql;

        public ISqlDumper Sql
        {
            get
            {
                if (_sql == null) throw new Exception("DBSH-00108 Razor:Sql not set");
                return _sql;
            }
            set { _sql = value; }
        }

        private ITabularDataSource _tabularData;

        public ITabularDataSource TabularData
        {
            get
            {
                if (_tabularData == null) throw new Exception("DBSH-00109 Razor:TabularData not set");
                return _tabularData;
            }
            set { _tabularData = value; }
        }

        public IEnumerable<DataRowModel> Rows
        {
            get
            {
                using (var reader = TabularData.CreateReader(Context))
                {
                    while (reader.Read())
                    {
                        yield return new DataRowModel(reader);
                    }
                }
            }
        }

        private List<ColumnModel> _columns;

        public List<ColumnModel> Columns
        {
            get
            {
                if (_columns == null)
                {
                    if (_tabularData != null)
                    {
                        var fmt = _tabularData.GetRowFormat(Context);
                        Columns = new List<ColumnModel>(fmt.Columns.Select(c => new TableColumnModel(c)));
                    }
                    if (_columns == null) throw new Exception("DBSH-00110 Razor:Columns not set");
                }
                return _columns;
            }
            set { _columns = value; }
        }

        public string Schema { get; set; }
        public string Name { get; set; }
        public IShellContext Context { get; set; }

        public NameWithSchema FullName
        {
            get
            {
                if (Name != null || Schema != null) return new NameWithSchema(Schema, Name);
                return null;
            }
        }

        public void Reset()
        {
            Name = null;
            Schema = null;
            Context = null;
            _columns = null;
            _sql = null;
            _tabularData = null;
        }
    }
}

#endif