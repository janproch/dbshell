using DbShell.Driver.Common.CommonDataLayer;
using DotSpatial.Data;
using DotSpatial.Projections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Structure;

namespace DbShell.Spatial.Model
{
    public class ShapeFileModel
    {
        public Shapefile Shape;
        public DataFormatSettings DataFormat;
        public bool AddFileIdentifier;
        public string File;

        public static ShapeFileModel OpenFile(string file, ProjectionInfo projection)
        {
            var res = new ShapeFileModel();
            res.File = file;
            res.Shape = Shapefile.OpenFile(file);
            if (projection != null) res.Shape.Reproject(projection);
            return res;
        }

        public ICdlReader CreateVertexReader()
        {
            return new ShapeFileVertexReader(this, AddFileIdentifier);
        }

        public ICdlReader CreateDataReader()
        {
            return new ShapeFileDataReader(this, AddFileIdentifier);
        }

        public void Close()
        {
            Shape.Close();
        }

        public TableInfo GetDataStructure()
        {
            return ShapeFileDataReader.GetTableInfo(Shape.DataTable, AddFileIdentifier);
        }
    }
}
