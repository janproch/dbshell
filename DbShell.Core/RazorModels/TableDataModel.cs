using System.Collections.Generic;
using DbShell.Driver.Common.Interfaces;
using DbShell.Driver.Common.Structure;

namespace DbShell.Core.RazorModels
{
    //public class TableDataModel
    //{
    //    private ITabularDataSource _table;
    //    private TableInfo _structure;

    //    public TableDataModel(ITabularDataSource table)
    //    {
    //        _table = table;
    //    }

    //    public IEnumerable<DataRowModel> Rows
    //    {
    //        get
    //        {
    //            using (var reader = _table.CreateReader())
    //            {
    //                while (reader.Read())
    //                {
    //                    yield return new DataRowModel(reader);
    //                }
    //            }
    //        }
    //    }

    //    private void WantStructure()
    //    {
    //        if (_structure != null) return;
    //        _structure = _table.GetRowFormat();
    //    }

    //    public List<ColumnInfo> Columns
    //    {
    //        get
    //        {
    //            WantStructure();
    //            return _structure.Columns;
    //        }
    //    }

    //    public string TableName
    //    {
    //        get
    //        {
    //            WantStructure();
    //            return _structure.Name;
    //        }
    //    }
    //}
}
