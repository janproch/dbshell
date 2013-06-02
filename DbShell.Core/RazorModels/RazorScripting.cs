using System;
using DbShell.Common;
using DbShell.Core.Runtime;
using RazorEngine.Templating;

namespace DbShell.Core.RazorModels
{
    public static class RazorScripting
    {
        private static bool _initialized;

        public static void ParseRazor(string templateData, Action<string> write, object model, Action<IRazorTemplate> initializeTemplate = null)
        {
            if (!_initialized)
            {
                Initialize();
                _initialized = true;
            }
            var ctx = new ShellContext(null);
            if (InitializeContext != null) InitializeContext(ctx);
            Action<ITemplate> func = initializeTemplate != null ? (tpl =>
                {
                    ((IRazorTemplate) tpl).Reset();
                    ((IRazorTemplate) tpl).Context = ctx;
                    initializeTemplate((IRazorTemplate) tpl);
                }) : (Action<ITemplate>)null;
            RazorEngine.Razor.Parse(templateData, write, model, null, func);
        }

        private static void Initialize()
        {
            RazorEngine.Razor.SetTemplateBase(typeof(RazorTemplate<>));
        }

        public static event Action<IShellContext> InitializeContext;
    }
}
