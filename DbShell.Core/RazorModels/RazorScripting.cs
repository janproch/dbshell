using System;
using DbShell.Common;
using DbShell.Core.Runtime;
using RazorEngine.Templating;

namespace DbShell.Core.RazorModels
{
    public static class RazorScripting
    {
        private static bool _initialized;

        public static void ParseRazor(string templateData, Action<string> write, object model, Action<IRazorTemplate, IShellContext> initTemplate = null)
        {
            if (!_initialized)
            {
                Initialize();
            }
            var ctx = new ShellContext(null);
            if (InitializeContext != null) InitializeContext(ctx);
            Action<ITemplate> func = tpl =>
                {
                    var rtpl = (IRazorTemplate) tpl;
                    rtpl.Reset();
                    rtpl.Context = ctx;
                    if (initTemplate != null) initTemplate(rtpl, ctx);
                    if (InitializeTemplate != null) InitializeTemplate(rtpl);
                };
            RazorEngine.Razor.Parse(templateData, write, model, null, func);
        }

        public static void Initialize(Type templateType = null)
        {
            _initialized = true;
            RazorEngine.Razor.SetTemplateBase(templateType ?? typeof(RazorTemplate<>));
        }

        public static event Action<IShellContext> InitializeContext;
        public static event Action<IRazorTemplate> InitializeTemplate;
    }
}
