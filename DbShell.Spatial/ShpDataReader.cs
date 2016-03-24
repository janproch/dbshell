using DbShell.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;
using DbShell.Spatial.Model;

namespace DbShell.Spatial
{
    public class ShpDataReader : ShpElementBase, ITabularDataSource
    {
        public ICdlReader CreateReader(IShellContext context)
        {
            var model = GetModel(context);
            return model.CreateDataReader();
        }

        public TableInfo GetRowFormat(IShellContext context)
        {
            return ShapeFileDataReader.GetTableInfo(GetModel(context).Shape.DataTable);
        }

        public DataFormatSettings GetSourceFormat(IShellContext context)
        {
            return GetModel(context).DataFormat;
        }
    }
}
