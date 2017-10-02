#if !NETSTANDARD2_0

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
        private List<XmlReadInstructions> _instructions;
        private IEnumerator<Record> _enumerator;

        internal class Record
        {
            internal XmlNode Node;
            internal XmlReadInstructions Instruction;
            internal Dictionary<string, int> ColDict;
        }

        public XmlDocumentReader(XmlDocument doc, TableInfo rowFormat, List<XmlReadInstructions> instructions)
            : base(rowFormat)
        {
            _doc = doc;
            _rowFormat = rowFormat;
            _instructions = instructions;
            _enumerator = GetRecords().GetEnumerator();
        }

        public void Dispose()
        {
            if (Disposing != null) Disposing();
            Disposing = null;
        }

        public event Action Disposing;

        private IEnumerable<Record> GetRecords()
        {
            foreach(var instruction in _instructions)
            {
                var nodeList = _doc.SelectNodes(instruction.XPath);
                var colDict = new Dictionary<string, int>();
                foreach(var col in instruction.Columns)
                {
                    colDict[col.Name] = _rowFormat.Columns.IndexOfIf(x => x.Name == col.Name);
                }

                for(int i = 0; i < nodeList.Count; i++)
                {
                    yield return new Record
                    {
                        Instruction = instruction,
                        Node = nodeList[i],
                        ColDict = colDict,
                    };
                }
            }
        }

        public bool Read()
        {
            if (_enumerator.MoveNext())
            {
                var current = _enumerator.Current;

                for (int i = 0; i < _values.Length; i++) _values[i] = null;

                foreach(var col in current.Instruction.Columns)
                {
                    int index = current.ColDict[col.Name];

                    SeekValue(index);
                    var elem = current.Node.SelectSingleNode(col.XPath);
                    if (elem != null) SetString(elem.InnerText);
                }
                return true;
            }
            return false;
        }

        public bool NextResult()
        {
            return false;
        }
    }
}

#endif