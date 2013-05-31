using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Windows.Markup;
using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Driver.Common.Structure;
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
    [ContentProperty("TemplateData")]
    public class Razor : RunnableBase
    {
        private static readonly ILog _log = LogManager.GetLogger(System.Reflection.MethodBase.GetCurrentMethod().DeclaringType);

        /// <summary>
        /// Gets or sets the file nme.
        /// </summary>
        /// <value>
        /// Name of output file.
        /// </value>
        public string File { get; set; }

        /// <summary>
        /// Gets or sets the template file.
        /// </summary>
        /// <value>
        /// File name of Razor template (cshtml file)
        /// </value>
        public string TemplateFile { get; set; }

        /// <summary>
        /// Inlined template data
        /// </summary>
        public string TemplateData { get; set; }

        /// <summary>
        /// Gets or sets the model. If Model has type String, it is evaluated as expression. Use Model="{Database}" for database structure
        /// </summary>
        /// <value>
        /// The model expression or model value for razor template engine. It can be also of type <see cref="IModelProvider"/>
        /// </value>
        public object Model { get; set; }

        protected override void DoRun()
        {
            object model = null;
            if (Model is string)
            {
                model = Context.Evaluate((string) Model);
                if (model is IModelProvider)
                {
                    model = ((IModelProvider)model).GetModel();
                }
            }
            else if (Model is IModelProvider)
            {
                model = ((IModelProvider) Model).GetModel();
            }
            else
            {
                model = Model;
            }

            _log.InfoFormat("DBSH-00074 Apply template {0}=>{1}", TemplateFile ?? "(inline template)", File);
            string templateData = TemplateData;

            if (templateData == null)
            {
                using (var sr = new StreamReader(Context.ResolveFile(TemplateFile, ResolveFileMode.Template)))
                {
                    templateData = sr.ReadToEnd();
                }
            }
            try
            {
                string fn = Context.ResolveFile(Context.Replace(File), ResolveFileMode.Output);
                using (var sw = new StreamWriter(fn))
                {
                    RazorEngine.Razor.Parse(templateData, sw.Write, model);
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

        public override void EnumChildren(Action<IShellElement> enumFunc)
        {
            base.EnumChildren(enumFunc);
            YieldChild(enumFunc, Model);
        }
    }
}
