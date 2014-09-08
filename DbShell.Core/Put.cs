using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Core.Utility;

namespace DbShell.Core
{
    /// <summary>
    /// Action for putting objects into collections
    /// </summary>
    public class Put : RunnableBase
    {
        /// <summary>
        /// collection, into which element is appended
        /// </summary>
        [XamlProperty]
        public object Collection { get; set; }

        /// <summary>
        /// expression to obtain collection
        /// </summary>
        [XamlProperty]
        public string CollectionExpression { get; set; }

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

        protected override void DoRun()
        {
            var collection = Collection;
            if (collection == null) collection = Context.Evaluate(CollectionExpression);

            var value = Value;
            if (value == null) value = Context.Evaluate(ValueExpression);

            var dct = collection as IDictionary;
            if (dct != null && Key != null) dct[Key] = value;
            var lst = collection as IList;
            if (lst != null) lst.Add(value);
        }

        public override void EnumChildren(Action<Common.IShellElement> enumFunc)
        {
            base.EnumChildren(enumFunc);

            YieldChild(enumFunc, Collection);
            YieldChild(enumFunc, Value);
        }
    }
}
