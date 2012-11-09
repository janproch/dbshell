using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Windows.Markup;
using DbShell.Common;
using DbShell.Core.Utility;

namespace DbShell.Core
{
    [ContentProperty("Commands")]
    public abstract class RunnableContainer : RunnableBase
    {
        public RunnableContainer()
        {
            Commands = new List<IRunnable>();
        }

        public List<IRunnable> Commands { get; set; }

        public override void EnumChildren(Action<IShellElement> enumFunc)
        {
            base.EnumChildren(enumFunc);
            foreach (var item in Commands) YieldChild(enumFunc, item);
        }

        protected void RunContainer()
        {
            foreach(var item in Commands)
            {
                item.Run();
            }
        }
    }
}
