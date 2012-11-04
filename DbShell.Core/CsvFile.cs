using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;

namespace DbShell.Core
{
    /// <summary>
    /// CSV data file
    /// </summary>
    public class CsvFile : ElementBase, ITabularDataSource, ITabularDataTarget
    {
        /// <summary>
        /// File name (should have .csv extension)
        /// </summary>
        public string Name { get; set; }

        char _delimiter = ',';
        public char Delimiter
        {
            get { return _delimiter; }
            set { _delimiter = value; }
        }

        char _quote = '"';
        public char Quote
        {
            get { return _quote; }
            set { _quote = value; }
        }

        string _endOfLine = "\r\n";
        public string EndOfLine
        {
            get { return _endOfLine; }
            set { _endOfLine = value; }
        }

        char _escape = '"';
        public char Escape
        {
            get { return _escape; }
            set { _escape = value; }
        }

        char _comment = '#';
        public char Comment
        {
            get { return _comment; }
            set { _comment = value; }
        }

        bool _hasHeaders = true;
        public bool HasHeaders
        {
            get { return _hasHeaders; }
            set { _hasHeaders = value; }
        }

        bool _trimSpaces = true;
        public bool TrimSpaces
        {
            get { return _trimSpaces; }
            set { _trimSpaces = value; }
        }

        CsvQuotingMode _quotingMode = CsvQuotingMode.OnlyIfNecessary;
        public CsvQuotingMode QuotingMode
        {
            get { return _quotingMode; }
            set { _quotingMode = value; }
        }


        private string GetName()
        {
            return Context.Replace(Name);
        }

        TableInfo ITabularDataSource.GetRowFormat()
        {
            throw new NotImplementedException();
        }

        ICdlReader ITabularDataSource.CreateReader()
        {
            throw new NotImplementedException();
        }

        bool ITabularDataTarget.AvailableRowFormat
        {
            get { return false; }
        }

        ICdlWriter ITabularDataTarget.CreateWriter(TableInfo rowFormat, CopyTableTargetOptions options)
        {
            var fw = new StreamWriter(GetName());
            var writer = new CsvWriter(fw, Delimiter, Quote, Escape, Comment, QuotingMode, EndOfLine);
            if (HasHeaders)
            {
                writer.WriteRow(rowFormat.Columns.Select(c => c.Name));
            }
            return writer;
        }

        TableInfo ITabularDataTarget.GetRowFormat()
        {
            throw new NotImplementedException();
        }
    }
}
