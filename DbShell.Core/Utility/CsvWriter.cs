using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.CommonDataLayer;

namespace DbShell.Core.Utility
{
    public class CsvWriter : ICdlWriter
    {
        private TextWriter _stream;
        private char _delimiter = ',';
        private char _quote = '"';
        private char _escape = '"';
        private char _comment = '#';
        private string _lineEnds = "\r\n";
        private CsvQuotingMode _qmode;
        private ICdlValueFormatter _formatter;
        private string[] _dataRecord;

        public CsvWriter(TextWriter stream, char delimiter, char quote, char escape, char comment, CsvQuotingMode qmode, string lineEnds)
        {
            _stream = stream;
            _lineEnds = lineEnds;
            _delimiter = delimiter;
            _quote = quote;
            _escape = escape;
            _comment = comment;
            _qmode = qmode;
            _formatter = new CdlValueFormatter(new DataFormatSettings());
        }

        public void WriteRow(IEnumerable<string> cols)
        {
            bool wascol = false;
            foreach (string col in cols)
            {
                if (wascol) _stream.Write(_delimiter);
                bool quote = false;
                switch (_qmode)
                {
                    case CsvQuotingMode.Always:
                        quote = true;
                        break;
                    case CsvQuotingMode.AlwaysExceptNumbers:
                        if (col != null)
                        {
                            foreach (char ch in col)
                            {
                                if (ch <= '0' || ch >= '9')
                                {
                                    quote = true;
                                    break;
                                }
                            }
                        }
                        else
                        {
                            quote = true;
                        }
                        break;
                    case CsvQuotingMode.OnlyIfNecessary:
                        if (col != null)
                        {
                            foreach (char ch in col)
                            {
                                if (ch <= ' ' || ch == _delimiter || ch == _quote || ch == _escape || ch == _comment)
                                {
                                    quote = true;
                                    break;
                                }
                            }
                        }
                        break;
                }
                if (quote)
                {
                    _stream.Write(_quote);
                    foreach (char ch in col)
                    {
                        if (ch == _quote) _stream.Write(_escape);
                        _stream.Write(ch);
                    }
                    _stream.Write(_quote);
                }
                else
                {
                    _stream.Write(col);
                }
                wascol = true;
            }
            _stream.Write(_lineEnds);
        }

        #region IDisposable Members

        public void Dispose()
        {
            if (Disposing != null)
            {
                Disposing();
                Disposing = null;
            }
            _stream.Dispose();
        }

        #endregion

        void ICdlWriter.Write(ICdlRecord row)
        {
            if (_dataRecord == null)
            {
                _dataRecord = new string[row.FieldCount];
            }
            for (int i = 0; i < _dataRecord.Length; i++)
            {
                row.ReadValue(i);
                _formatter.ReadFrom(row);
                _dataRecord[i] = _formatter.GetText();
            }
            WriteRow(_dataRecord);
        }

        public event Action Disposing;

    }
}
