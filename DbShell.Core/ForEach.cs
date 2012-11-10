using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;

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
        /// Gets or sets the name of property, which is filled with iterating expression
        /// </summary>
        /// <value>
        /// The property name
        /// </value>
        public string Property { get; set; }

        /// <summary>
        /// Gets or sets the source of list data
        /// </summary>
        /// <value>
        /// Data source, eg. Tables collection
        /// </value>
        public IListProvider Source { get; set; }

        protected override void DoRun()
        {
            try
            {
                Context.EnterScope();
                foreach (var item in Source.GetList())
                {
                    Context.SetVariable(Property, item);
                    foreach (var command in Commands)
                    {
                        command.Run();
                    }
                }
            }
            finally
            {
                Context.LeaveScope();
            }
        }

        public override void EnumChildren(Action<IShellElement> enumFunc)
        {
            base.EnumChildren(enumFunc);

            YieldChild(enumFunc, Source);
        }
    }
}
