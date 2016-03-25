using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Core.Utility
{
    public static class XmlFlatAnalyser
    {
        public static XmlReader AnalyseFile(string file)
        {
            var res = new XmlReader
            {
                File = file,
            };

            return res;
        }
    }
}
