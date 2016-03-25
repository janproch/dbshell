using DbShell.Common;
using DbShell.Core.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Spatial.Model;
using DotSpatial.Projections;

namespace DbShell.Spatial
{
    public class ShpVertexReader : ShpElementBase, ITabularDataSource
    {
        public ICdlReader CreateReader(IShellContext context)
        {
            return GetModel(context).CreateVertexReader();
        }

        public TableInfo GetRowFormat(IShellContext context)
        {
            return ShapeFileVertexReader.GetStructure(GetModel(context).AddFileIdentifier);
        }

        public DataFormatSettings GetSourceFormat(IShellContext context)
        {
            return GetModel(context).DataFormat;
        }
    }
}
