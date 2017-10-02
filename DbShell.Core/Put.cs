using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
#if !NETSTANDARD2_0
using System.Windows.Markup;
#endif
using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Utility;

namespace DbShell.Core
{
    /// <summary>
    /// Action for putting objects into collections
    /// </summary>
#if !NETSTANDARD2_0
    [ContentProperty("Value")]
#endif
    public class Put : RunnableBase
    {
        /// <summary>
        /// expression (or variable name) to obtain collection
        /// </summary>
        [XamlProperty]
        public string Collection { get; set; }

        /// <summary>
        /// key of added element (only for dictionary)
        /// </summary>
        [XamlProperty]
        public string Key { get; set; }

        /// <summary>
        /// value to be appended
        /// </summary>
        [XamlProperty]
        public object Value { get; set; }

        /// <summary>
        /// expression to obtain value to be appended
        /// </summary>
        [XamlProperty]
        public string ValueExpression { get; set; }

        protected override void DoRun(IShellContext context)
        {
            object collection = context.Evaluate(Collection);

            var value = Value;
            if (value == null) value = context.Evaluate(ValueExpression);

            var dct = collection as IDictionary;
            if (dct != null && Key != null) dct[Key] = value;
            var lst = collection as IList;
            if (lst != null) lst.Add(value);
        }

        //public override void EnumChildren(Action<Common.IShellElement> enumFunc)
        //{
        //    base.EnumChildren(enumFunc);

        //    YieldChild(enumFunc, Collection);
        //    YieldChild(enumFunc, Value);
        //}
    }
}
