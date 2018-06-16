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
        private bool _closeWriter;
        private string _rowElementName;

        public XmlWriterImpl(System.Xml.XmlWriter writer, bool closeWriter, DataFormatSettings dataFormat, bool useAttributes, string rowElementName)
        {
            _writer = writer;
            _dataFormat = dataFormat;
            _formatter = new CdlValueFormatter(_dataFormat ?? new DataFormatSettings());
            _useAttributes = useAttributes;
            _closeWriter = closeWriter;
            _rowElementName = rowElementName;
        }

        public void Dispose()
        {
            if (Disposing != null)
            {
                Disposing();
                Disposing = null;
            }
            if (_closeWriter)
            {
                XmlWriter.CloseWriter(_writer);
            }
        }

        public void Write(ICdlRecord row)
        {
            _writer.WriteStartElement(_rowElementName ?? "Row");
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
