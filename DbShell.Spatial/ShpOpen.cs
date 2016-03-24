using DbShell.Common;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Spatial.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Spatial
{
    public class ShpOpen : ShpRunnableBase
    {
        /// <summary>
        /// file name of Excel file
        /// </summary>
        [XamlProperty]
        public string File { get; set; }

        /// <summary>
        /// data format
        /// </summary>
        [XamlProperty]
        public DataFormatSettings DataFormat { get; set; }

        /// <summary>
        /// Target projection
        /// </summary>
        [XamlProperty]
        public string Projection { get; set; }

        protected override void DoRun(IShellContext context)
        {
            string file = context.ResolveFile(context.Replace(File), ResolveFileMode.Input);
            var model = ShapeFileModel.OpenFile(file, SpatialTool.GetProjection(Projection, context));
            model.DataFormat = DataFormat;
            context.SetVariable(GetShpVariableName(context), model);
        }
    }

}
