using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Interfaces;
using DbShell.Core.Utility;
using DbShell.Driver.Common.Utility;

namespace DbShell.Core
{
    public class FilesProvider : ElementBase, IListProvider
    {
        [XamlProperty]
        public string Filter { get; set; }

        public IEnumerable GetList(IShellContext context)
        {
            string path = Path.GetDirectoryName(Filter);
            string filter = Path.GetFileName(Filter);
            return Directory.GetFiles(path, filter);
        }
    }
}
