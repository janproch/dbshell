using DbShell.Core.Utility;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Interfaces;
using DbShell.Driver.Common.Structure;
using System;
using System.Collections.Generic;
using System.Text;
using System.Xml;

namespace DbShell.Xml
{
    public class XmlWriter : OutputXmlElementBase, ITabularDataTarget
    {
        public string File { get; set; }
        public bool UseAttributes { get; set; }
        public string RowElementName;

        ICdlWriter ITabularDataTarget.CreateWriter(TableInfo inputRowFormat, CopyTableTargetOptions options, IShellContext context, DataFormatSettings sourceDataFormat)
        {
            var writer = GetModel(context);
            bool closeWriter = false;
            if (writer == null)
            {
                closeWriter = true;
                writer = CreateWriter(context.ResolveFile(context.Replace(File), ResolveFileMode.Output));
            }
            var impl = new XmlWriterImpl(writer, closeWriter, sourceDataFormat, UseAttributes, RowElementName);
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

        public static System.Xml.XmlWriter CreateWriter(string file)
        {
            var settings = new System.Xml.XmlWriterSettings
            {
                Indent = true,
            };
            var writer = System.Xml.XmlWriter.Create(file, settings);
            writer.WriteStartDocument();
            writer.WriteStartElement("Database");
            return writer;
        }

        public static void CloseWriter(System.Xml.XmlWriter writer)
        {
            writer.WriteEndElement();
            writer.WriteEndDocument();
            writer.Dispose();
        }
    }
}
