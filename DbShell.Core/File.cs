using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Core
{
    /// <summary>
    /// Object representing file
    /// </summary>
    public class File : ElementBase, ITabularDataSource, ITabularDataTarget
    {
        [XamlProperty]
        public string Name { get; set; }

        private string GetName(IShellContext context)
        {
            return context.Replace(Name);
        }

        DataFormatSettings ITabularDataSource.GetSourceFormat(IShellContext context)
        {
            return null;
        }

        private ITabularDataSource CreateSource(IShellContext context)
        {
            string name = GetName(context);
            if (name.ToLower().EndsWith(".cdl")) return new CdlFile {Connection = Connection, Name = name};
#if !NETSTANDARD1_5
            if (name.ToLower().EndsWith(".csv")) return new CsvFile { Connection = Connection, Name = name };
            if (name.ToLower().EndsWith(".xml")) return new XmlReader { Connection = Connection, File = name, AnalyseColumns = true };
#endif
            throw new Exception("DBSH-00002 Unknown soruce file type:" + name);
        }

        private ITabularDataTarget CreateTarget(IShellContext context)
        {
            string name = GetName(context);
            if (name.ToLower().EndsWith(".cdl")) return new CdlFile { Connection = Connection, Name = name };
#if !NETSTANDARD1_5
            if (name.ToLower().EndsWith(".csv")) return new CsvFile { Connection = Connection, Name = name };
#endif
            //if (name.ToLower().EndsWith(".html") || name.ToLower().EndsWith(".htm"))
            //{
            //    return new Razor { Connection = Connection, Context = Context, Name = name };
            //}
            throw new Exception("DBSH-00003 Unknown target file type:" + name);
        }

        TableInfo ITabularDataSource.GetRowFormat(IShellContext context)
        {
            return CreateSource(context).GetRowFormat(context);
        }

        ICdlReader ITabularDataSource.CreateReader(IShellContext context)
        {
            return CreateSource(context).CreateReader(context);
        }

        bool ITabularDataTarget.IsAvailableRowFormat(IShellContext context)
        {
            return CreateTarget(context).IsAvailableRowFormat(context);
        }

        ICdlWriter ITabularDataTarget.CreateWriter(TableInfo rowFormat, CopyTableTargetOptions options, IShellContext context, DataFormatSettings sourceDataFormat)
        {
            return CreateTarget(context).CreateWriter(rowFormat, options, context, sourceDataFormat);
        }

        TableInfo ITabularDataTarget.GetRowFormat(IShellContext context)
        {
            return CreateTarget(context).GetRowFormat(context);
        }

        public override string ToString()
        {
            return String.Format("[File {0}]", Name);
        }

        public override string ToStringCtx(IShellContext context)
        {
            return String.Format("[File {0}]", context.Replace(Name));
        }
    }
}
