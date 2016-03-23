using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;
using DotSpatial.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Spatial.Model
{
    public class ShapeFileVertexReader : ArrayDataRecord, ICdlReader
    {
        public event Action Disposing;
        private ShapeFileModel _model;

        struct ShapeFilePosition
        {
            internal int Shape;
            internal int Part;
            internal int Vertex;
            internal double X;
            internal double Y;
        }

        IEnumerator<ShapeFilePosition> _enumerator;

        public ShapeFileVertexReader(ShapeFileModel model)
            : base(GetStructure())
        {
            _model = model;
        }

        private Shapefile Shape => _model.Shape;

        public static TableInfo GetStructure()
        {
            var res = new TableInfo(null);
            res.AddColumn("ShapeId", "int", new DbTypeInt());
            res.AddColumn("PartId", "int", new DbTypeInt());
            res.AddColumn("VertexId", "int", new DbTypeInt());
            res.AddColumn("X", "float", new DbTypeFloat());
            res.AddColumn("Y", "float", new DbTypeFloat());
            return res;
        }

        public void Dispose()
        {
            if (Disposing != null)
            {
                Disposing();
                Disposing = null;
            }
        }

        public bool NextResult()
        {
            return false;
        }

        private IEnumerable<ShapeFilePosition> EnumPositions()
        {
            for (int shapeIndex = 0; shapeIndex < Shape.ShapeIndices.Count; shapeIndex++)
            {
                var indices = Shape.ShapeIndices[shapeIndex];
                int partId = 0;

                foreach (var part in indices.Parts)
                {
                    for (int vertex = 0; vertex < part.NumVertices; vertex++)
                    {
                        double x = Shape.Vertex[(part.StartIndex + vertex) * 2];
                        double y = Shape.Vertex[(part.StartIndex + vertex) * 2 + 1];

                        yield return new ShapeFilePosition
                        {
                            Shape = shapeIndex,
                            Part = partId,
                            Vertex = vertex,
                            X = x,
                            Y = y,
                        };
                    }
                    partId++;
                }
            }
        }

        public bool Read()
        {
            if (_enumerator == null)
            {
                _enumerator = EnumPositions().GetEnumerator();
            }
            if (_enumerator.MoveNext())
            {
                _values[0] = _enumerator.Current.Shape;
                _values[1] = _enumerator.Current.Part;
                _values[2] = _enumerator.Current.Vertex;
                _values[3] = _enumerator.Current.X;
                _values[4] = _enumerator.Current.Y;
                return true;
            }
            return false;
        }
    }
}
