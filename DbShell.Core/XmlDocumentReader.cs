using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Xml;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Core
{
    internal class XmlDocumentReader : ArrayDataRecord, ICdlReader
    {
        private XmlDocument _doc;
        private TableInfo _rowFormat;
        private List<XmlColumn> _columns;
        private XmlNodeList _nodes;
        private int _currentIndex = -1;

        public XmlDocumentReader(XmlDocument doc, TableInfo rowFormat, List<XmlColumn> columns, string xpath)
            : base(rowFormat)
        {
            _doc = doc;
            _rowFormat = rowFormat;
            _columns = columns;
            _nodes = doc.SelectNodes(xpath);
        }

        public void Dispose()
        {
            if (Disposing != null) Disposing();
            Disposing = null;
        }

        public event Action Disposing;

        public bool Read()
        {
            if (_currentIndex + 1 >= _nodes.Count)
            {
                return false;
            }
            _currentIndex++;
            for (int i = 0; i < _columns.Count; i++)
            {
                SeekValue(i);
                var elem = _nodes[_currentIndex].SelectSingleNode(_columns[i].XPath);
                if (elem != null) SetString(elem.InnerText);
                else SetNull();
            }
            return true;
        }

        public bool NextResult()
        {
            return false;
        }
    }
}
