using DbShell.Core.Utility;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Interfaces;
using DbShell.Driver.Common.Structure;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.Xml
{
    public class XmlWriter : ElementBase, ITabularDataTarget
    {
        public string File { get; set; }
        public bool UseAttributes { get; set; }

        ICdlWriter ITabularDataTarget.CreateWriter(TableInfo inputRowFormat, CopyTableTargetOptions options, IShellContext context, DataFormatSettings sourceDataFormat)
        {
            var impl = new XmlWriterImpl(File, inputRowFormat.Name, sourceDataFormat, UseAttributes);
            return impl;
        }

        TableInfo ITabularDataTarget.GetRowFormat(IShellContext context)
        {
            return null;
        }

        bool ITabularDataTarget.IsAvailableRowFormat(IShellContext context)
        {
            return false;
        }
    }
}
