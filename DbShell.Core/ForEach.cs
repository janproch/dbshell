using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Utility;

namespace DbShell.Core
{
    /// <summary>
    /// Enumerates items of collection
    /// </summary>
    /// <example>
    /// This example exports all table to CSV file.
    /// <code>
    /// <![CDATA[
    /// <ForEach Source="{Tables}" Property="Table">
    ///     <CopyTable Soruce="{Table ${Table.Name}}" Target="{File ${Table.Name}.csv}" />
    /// </ForEach>
    /// ]]>
    /// </code>
    /// </example>
    public class ForEach : RunnableContainer
    {
        /// <summary>
        /// Gets or sets the name of property, which is filled with iterating expression.
        /// </summary>
        /// <value>
        /// The property name. If property is not set, items of collection must provide named properties.
        /// </value>
        [XamlProperty]
        public string Property { get; set; }

        /// <summary>
        /// Gets or sets the source of list data
        /// </summary>
        /// <value>
        /// Data source, eg. Tables collection
        /// </value>
        [XamlProperty]
        public IListProvider Source { get; set; }

        [XamlProperty]
        /// if true, then when exception occurs, continues with next item
        public bool ContinueOnErrors { get; set; } = false;

        protected override void DoRun(IShellContext context)
        {
            var childContext = context.CreateChildContext();
            childContext.CreateScope();
            foreach (var item in Source.GetList(context))
            {
                if (Property == null)
                {
                    bool processed = false;
                    var dct = item as Dictionary<string, object>;
                    if (dct != null)
                    {
                        foreach (var tuple in dct)
                        {
                            childContext.SetVariable(tuple.Key, tuple.Value);
                        }
                        processed = true;
                    }
                    var record = item as ICdlRecord;
                    if (record != null)
                    {
                        for (int i = 0; i < record.FieldCount; i++)
                        {
                            childContext.SetVariable(record.GetName(i), record.GetValue(i));
                        }
                        processed = true;
                    }
                    if (!processed) throw new Exception("DBSH-00077 Property is not set and Items collection doesn't return property names");
                }
                else
                {
                    childContext.SetVariable(Property, item);
                }
                try
                {
                    foreach (var command in Commands)
                    {
                        command.Run(childContext);
                    }
                }
                catch (Exception err)
                {
                    if (!ContinueOnErrors) throw;
                    context.OutputMessage(err.Message);
                }
            }
        }

        //public override void EnumChildren(Action<IShellElement> enumFunc)
        //{
        //    base.EnumChildren(enumFunc);

        //    YieldChild(enumFunc, Source);
        //}
    }
}
