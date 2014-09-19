using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;

namespace DbShell.Core
{
    public class FilesProvider : ElementBase, IListProvider
    {
        public string Filter { get; set; }

        public IEnumerable GetList(IShellContext context)
        {
            string path = Path.GetDirectoryName(Filter);
            string filter = Path.GetFileName(Filter);
            return Directory.GetFiles(path, filter);
        }
    }
}
