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

        public ShapeFileModel(string file, ProjectionInfo projection)
        {
            Shape = Shapefile.OpenFile(file);
            if (projection != null) Shape.Reproject(projection);
        }
    }
}
