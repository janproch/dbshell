using DbShell.Common;
using DotSpatial.Projections;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Spatial.Model
{
    public static class SpatialTool
    {
        public static ProjectionInfo GetProjection(string name, IShellContext context)
        {
            if (name == null) return null;
            name = context.Replace(name);
            if (name == null) return null;
            return KnownCoordinateSystems.Geographic.World.GetProjection(name);
        }
    }
}
