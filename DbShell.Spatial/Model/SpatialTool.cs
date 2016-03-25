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
            return GetProjection(name);
        }

        public static ProjectionInfo GetProjection(string name)
        {
            if (name == null) return null;
            var projection = KnownCoordinateSystems.Geographic.World.GetProjection(name);
            if (projection == null)
            {
                try { projection = ProjectionInfo.FromProj4String(name); }
                catch { projection = null; }
            }
            if (projection == null)
            {
                try { projection = ProjectionInfo.FromEsriString(name); }
                catch { projection = null; }
            }
            if (projection == null)
            {
                int ivalue;
                if (Int32.TryParse(name, out ivalue))
                {
                    try { projection = ProjectionInfo.FromEpsgCode(ivalue); }
                    catch { projection = null; }
                }
            }
            return projection;
        }
    }
}
