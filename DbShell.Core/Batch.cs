using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Markup;
using DbShell.Common;
using DbShell.Core.Utility;

namespace DbShell.Core
{
    [ContentProperty("Items")]
    public class Batch : ElementBase, IRunnable
    {
        public Batch()
        {
            Items = new List<IRunnable>();
        }

        public List<IRunnable> Items { get; set; }

        void IRunnable.Run(IShellContext context)
        {
            foreach(var item in Items)
            {
                item.Run(context);
            }
        }

        public override void EnumChildren(Action<IShellElement> enumFunc)
        {
            base.EnumChildren(enumFunc);
            foreach (var item in Items) YieldChild(enumFunc, item);
        }
    }
}
