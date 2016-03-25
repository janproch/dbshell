using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Driver.Common.Utility;
using DbShell.Spatial.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Spatial
{
    public abstract class ShpElementBase : ElementBase
    {
        /// <summary>
        /// SHP variable name
        /// </summary>
        [XamlProperty]
        public string Name { get; set; }

        public ShapeFileModel ModelOverride;

        protected ShapeFileModel GetModel(IShellContext context)
        {
            if (ModelOverride != null) return ModelOverride;
            return (ShapeFileModel)context.GetVariable(GetShpVariableName(context));
        }

        protected string GetShpVariableName(IShellContext context)
        {
            if (String.IsNullOrEmpty(Name)) return "DefaultShp";
            return context.Replace(Name);
        }
    }
}
