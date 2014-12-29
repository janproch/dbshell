using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Markup;
using DbShell.Common;
using DbShell.Core.RazorModels;
using DbShell.Core.Utility;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;
using log4net;

namespace DbShell.Core
{
    /// <summary>
    /// Job, which can be used for export any model (eg. database structure) to text file using razor template
    /// </summary>
    /// <example>
    /// This example exports database structure into HTML document.
    /// <code>
    /// <![CDATA[
    /// <Razor 
    ///   xmlns="http://schemas.dbshell.com/core"
    ///   Template="DatabaseDoc.cshtml"
    ///   File="DatabaseDoc.html"
    ///   Model="{Database}"
    /// />
    /// ]]>
    /// </code>
    /// </example>
    public class Razor : TemplateHolderBase
    {
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Gets or sets the file nme.
        /// </summary>
        /// <value>
        /// Name of output file.
        /// </value>
        [XamlProperty]
        public string File { get; set; }

        /// <summary>
        /// Gets or sets the model. If Model has type String, it is evaluated as expression. Use Model="{Database}" for database structure
        /// </summary>
        /// <value>
        /// The model expression or model value for razor template engine. It can be also of type <see cref="IModelProvider"/>
        /// </value>
        [XamlProperty]
        public object Model { get; set; }

        protected override void DoRun(IShellContext context)
        {
            object model = null;
            IModelProvider provider = null;
            if (Model is string)
            {
                model = context.Evaluate((string) Model);
                if (model is IModelProvider)
                {
                    provider = (IModelProvider) model;
                    model = provider.GetModel(context);
                }
            }
            else if (Model is IModelProvider)
            {
                provider = (IModelProvider)Model;
                model = provider.GetModel(context);
            }
            else
            {
                model = Model;
            }

            _log.InfoFormat("DBSH-00074 Apply template {0}=>{1}", TemplateFile ?? "(inline template)", File);

            string templateData = LoadTemplate(context);

            try
            {
                string fn = context.ResolveFile(context.Replace(File), ResolveFileMode.Output);
                context.OutputMessage("Generating file " + fn);
                using (var sw = new StreamWriter(fn))
                {
                    RazorScripting.ParseRazor(templateData, sw.Write, model, 
                        provider != null ? provider.InitializeTemplate : (Action<IRazorTemplate, IShellContext>) null);
                }
            }
            catch (RazorEngine.Templating.TemplateCompilationException err)
            {
                _log.ErrorFormat("DBSH-00075 Error compiling template {0}", TemplateFile);
                foreach (var error in err.Errors)
                {
                    _log.Error(error.ToString());
                }
                throw;
            }
        }

        //public override void EnumChildren(Action<IShellElement> enumFunc)
        //{
        //    base.EnumChildren(enumFunc);
        //    YieldChild(enumFunc, Model);
        //}
    }
}
