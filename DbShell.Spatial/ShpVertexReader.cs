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
    public class ShpVertexReader : ElementBase, ITabularDataSource
    {
        /// <summary>
        /// File name
        /// </summary>
        [XamlProperty]
        public string FileName { get; set; }

        /// <summary>
        /// Target projection
        /// </summary>
        [XamlProperty]
        public string Projection { get; set; }


        private ShapeFileModel GetModel(IShellContext context)
        {
            return new ShapeFileModel(context.Replace(FileName), SpatialTool.GetProjection(Projection, context));
        }

        public ICdlReader CreateReader(IShellContext context)
        {
            return new ShapeFileVertexReader(GetModel(context));
        }

        public TableInfo GetRowFormat(IShellContext context)
        {
            return ShapeFileVertexReader.GetStructure();
        }

        public DataFormatSettings GetSourceFormat(IShellContext context)
        {
            throw new NotImplementedException();
        }
    }
}
