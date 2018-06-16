using DbShell.Driver.Common.CommonDataLayer;
using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.Xml
{
    internal class XmlWriterImpl : ICdlWriter
    {
        public event Action Disposing;
        System.Xml.XmlWriter _writer;
        private ICdlValueFormatter _formatter;
        private DataFormatSettings _dataFormat;
        private bool _useAttributes;

        public XmlWriterImpl(string file, string rootName, DataFormatSettings dataFormat, bool useAttributes)
        {
            var settings = new System.Xml.XmlWriterSettings
            {
                Indent = true,
            };
            _writer = System.Xml.XmlWriter.Create(file, settings);
            _writer.WriteStartDocument();
            _writer.WriteStartElement(String.IsNullOrEmpty(rootName) ? "Data" : rootName);
            _dataFormat = dataFormat;
            _formatter = new CdlValueFormatter(_dataFormat ?? new DataFormatSettings());
            _useAttributes = useAttributes;
        }

        public void Dispose()
        {
            if (Disposing != null)
            {
                Disposing();
                Disposing = null;
            }
            _writer.WriteEndElement();
            _writer.WriteEndDocument();
            _writer.Dispose();
        }

        public void Write(ICdlRecord row)
        {
            _writer.WriteStartElement("Row");
            for(int i = 0; i < row.FieldCount; i++)
            {
                string name = row.GetName(i);
                row.ReadValue(i);
                _formatter.ReadFrom(row);
                string value = _formatter.GetText();

                if (_useAttributes)
                {
                    _writer.WriteAttributeString(name, value);
                }
                else
                {
                    _writer.WriteStartElement(name);
                    _writer.WriteString(value);
                    _writer.WriteEndElement();
                }
            }
            _writer.WriteEndElement();
        }
    }
}
