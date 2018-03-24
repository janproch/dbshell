using System;
using System.Collections.Generic;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Utility;
using DbShell.Driver.Common.Interfaces;

namespace DbShell.Core.Utility
{
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
