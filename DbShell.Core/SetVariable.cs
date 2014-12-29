using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Utility;

namespace DbShell.Core
{
    /// <summary>
    /// Used for global setting variable.
    /// </summary>
    public class SetVariable : RunnableBase
    {
        /// <summary>
        /// Gets or sets the name of variable.
        /// </summary>
        /// <value>
        /// The variable name.
        /// </value>
        [XamlProperty]
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the variable value.
        /// </summary>
        /// <value>
        /// The variable value.
        /// </value>
        [XamlProperty]
        public object Value { get; set; }

        /// <summary>
        /// Gets or sets the expression.
        /// </summary>
        /// <value>
        /// The expression.
        /// </value>
        [XamlProperty]
        public string Expression { get; set; }

        protected override void DoRun(IShellContext context)
        {
            if (Value != null && Expression != null) throw new Exception("DBSH-00006 Both Value and Expression is set");
            if (Value != null)
            {
                if (Value is string)
                {
                    context.SetVariable(context.Replace(Name), context.Replace(Value.ToString()));
                }
                else
                {
                    context.SetVariable(context.Replace(Name), Value);
                }
            }
            if (Expression != null)
            {
                context.SetVariable(context.Replace(Name), context.Evaluate(Expression));
            }
            if (Expression == null && Value == null)
            {
                context.SetVariable(context.Replace(Name), null);
            }
        }

        //public override void EnumChildren(Action<Common.IShellElement> enumFunc)
        //{
        //    base.EnumChildren(enumFunc);
        //    YieldChild(enumFunc, Value);
        //}
    }
}
