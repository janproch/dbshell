using DbShell.Driver.Common.Interfaces;
using DbShell.Driver.Common.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.Xml
{
    public class CloseWriter : OutputXmlRunnableBase
    {
        protected override void DoRun(IShellContext context)
        {
            var model = GetModel(context);
            XmlWriter.CloseWriter(model);
        }
    }
}
