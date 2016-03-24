using DbShell.Driver.Common.CommonDataLayer;
using DotSpatial.Data;
using DotSpatial.Projections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Spatial.Model
{
    public class ShapeFileModel
    {
        public Shapefile Shape;
        public DataFormatSettings DataFormat;

        public static ShapeFileModel OpenFile(string file, ProjectionInfo projection)
        {
            var res = new ShapeFileModel();
            res.Shape = Shapefile.OpenFile(file);
            if (projection != null) res.Shape.Reproject(projection);
            return res;
        }

        public ICdlReader CreateVertexReader()
        {
            return new ShapeFileVertexReader(this);
        }

        public ICdlReader CreateDataReader()
        {
            return new ShapeFileDataReader(Shape.DataTable);
        }
    }
}
