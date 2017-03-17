using System;
using System.Collections.Generic;
#if !NETCOREAPP1_1
using System.Windows.Markup;
#endif
using DbShell.Common;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Utility;

namespace DbShell.Core.Utility
{
#if !NETCOREAPP1_1
    [ContentProperty("Commands")]
#endif
    public abstract class RunnableContainer : RunnableBase
    {
        public RunnableContainer()
        {
            Commands = new List<IRunnable>();
        }

        [XamlProperty]
        public List<IRunnable> Commands { get; set; }

        //public override void EnumChildren(Action<IShellElement> enumFunc)
        //{
        //    base.EnumChildren(enumFunc);
        //    foreach (var item in Commands) YieldChild(enumFunc, item);
        //}

        protected void RunContainer(IShellContext context)
        {
            foreach(var item in Commands)
            {
                item.Run(context);
            }
        }
    }
}
