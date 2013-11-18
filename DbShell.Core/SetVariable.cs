using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Core.Utility;

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
        public string Name { get; set; }

        /// <summary>
        /// Gets or sets the variable value.
        /// </summary>
        /// <value>
        /// The variable value.
        /// </value>
        public object Value { get; set; }

        /// <summary>
        /// Gets or sets the expression.
        /// </summary>
        /// <value>
        /// The expression.
        /// </value>
        public string Expression { get; set; }

        protected override void DoRun()
        {
            if (Value != null && Expression != null) throw new Exception("DBSH-00006 Both Value and Expression is set");
            if (Value != null)
            {
                if (Value is string)
                {
                    Context.SetVariable(Replace(Name), Replace(Value.ToString()));
                }
                else
                {
                    Context.SetVariable(Replace(Name), Value);
                }
            }
            if (Expression != null)
            {
                Context.SetVariable(Replace(Name), Context.Evaluate(Expression));
            }
            if (Expression == null && Value == null)
            {
                Context.SetVariable(Replace(Name), null);
            }
        }

        public override void EnumChildren(Action<Common.IShellElement> enumFunc)
        {
            base.EnumChildren(enumFunc);
            YieldChild(enumFunc, Value);
        }
    }
}
