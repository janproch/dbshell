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
        public string Value { get; set; }

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
                Context.SetVariable(Context.Replace(Name), Context.Replace(Value));
            }
            if (Expression != null)
            {
                Context.SetVariable(Context.Replace(Name), Context.Evaluate(Expression));
            }
            if (Expression == null && Value == null)
            {
                Context.SetVariable(Context.Replace(Name), null);
            }
        }
    }
}
