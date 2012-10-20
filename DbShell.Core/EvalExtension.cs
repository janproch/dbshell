using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;

namespace DbShell.Core
{
    public class EvalExtension : MarkupExtension
    {
        public string Expression;

        public EvalExtension(string expression)
        {
            Expression = expression;
        }

        public override object ProvideValue(IServiceProvider serviceProvider)
        {
            var provideValueTarget = serviceProvider.GetService(typeof(IProvideValueTarget)) as IProvideValueTarget;

            return Expression;
        }
    }
}
