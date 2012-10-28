using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;

namespace DbShell.Core
{
    public class File : ElementBase, ITabularDataSource, ITabularDataTarget
    {
        public string Name { get; set; }

        private string GetName()
        {
            return Context.Replace(Name);
        }

        private ITabularDataSource CreateSource()
        {
            string name = GetName();
            if (name.ToLower().EndsWith(".cdl")) return new CdlFile {Connection = Connection, Context = Context, Name = name};
            throw new Exception("DBSH-00000 Unknown soruce file type:" + name);
        }

        private ITabularDataTarget CreateTarget()
        {
            string name = GetName();
            if (name.ToLower().EndsWith(".cdl")) return new CdlFile { Connection = Connection, Context = Context, Name = name };
            throw new Exception("DBSH-00000 Unknown target file type:" + name);
        }

        TableInfo ITabularDataSource.GetRowFormat()
        {
            return CreateSource().GetRowFormat();
        }

        ICdlReader ITabularDataSource.CreateReader()
        {
            return CreateSource().CreateReader();
        }

        bool ITabularDataTarget.AvailableRowFormat
        {
            get { return CreateTarget().AvailableRowFormat; }
        }

        ICdlWriter ITabularDataTarget.CreateWriter(TableInfo rowFormat, CopyTableTargetOptions options)
        {
            return CreateTarget().CreateWriter(rowFormat, options);
        }

        TableInfo ITabularDataTarget.GetRowFormat()
        {
            return CreateTarget().GetRowFormat();
        }

        public override string ToString()
        {
            return String.Format("[File {0}]", GetName());
        }
    }
}
