using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;

namespace DbShell.Core
{
    /// <summary>
    /// Enumerates items of collection
    /// </summary>
    /// <example>
    /// <ForEach>
    /// </ForEach>
    /// </example>
    public class ForEach : RunnableContainer, IRunnable
    {
        public string Property { get; set; }

        public IListProvider Source { get; set; }

        void IRunnable.Run()
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
            Context.LeaveScope();
        }

        public override void EnumChildren(Action<IShellElement> enumFunc)
        {
            base.EnumChildren(enumFunc);

            YieldChild(enumFunc, Source);
        }
    }
}
