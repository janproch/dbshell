using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;

namespace DbShell.Html
{
    public class HtmlWriter : ICdlWriter
    {
        private TextWriter _stream;
        private ICdlValueFormatter _formatter;

        public HtmlWriter(TextWriter stream, IEnumerable<string> header)
        {
            _stream = stream;
            _formatter = new CdlValueFormatter(new DataFormatSettings());

            _stream.Write(@"<!DOCTYPE HTML PUBLIC '-//W3C//DTD HTML 4.01
<html>
 <head>
  <meta http-equiv='content-type' content='text/html; charset=utf-8'>
  <meta name='generator' content='DB Shell, http://dbshell.com'>
  <style>
table {
    border: solid 1px #e8eef4;
    border-collapse: collapse;
}

table td {
    padding: 5px;
    border: solid 1px #e8eef4;
}

table th {
    padding: 6px 5px;
    text-align: left;
    background-color: #e8eef4;
    border: solid 1px #e8eef4;
}

body {
    font-size: .85em;
    font-family: 'Trebuchet MS', Verdana, Helvetica, Sans-Serif;
}

p, ul {
    margin-bottom: 20px;
    line-height: 1.6em;
}

h1 {
    font-size: 1.5em;
    color: #000;
    font-size: 2em;
}
  </style>
 </head>
 <body>
 <table>
<tr>
");
            foreach(var col in header)
            {
                _stream.WriteLine("<th>{0}</th>", HttpUtility.HtmlEncode(col));
            }
            _stream.Write("</tr>");
        }


        #region IDisposable Members

        public void Dispose()
        {
            _stream.Write("</table></html>");
            if (Disposing != null)
            {
                Disposing();
                Disposing = null;
            }
            _stream.Dispose();
        }

        #endregion

        public event Action Disposing;
        public void Write(ICdlRecord row)
        {
            _stream.Write("<tr>");
            for (int i = 0; i < row.FieldCount; i++)
            {
                row.ReadValue(i);
                _formatter.ReadFrom(row);
                string value = _formatter.GetText();
                _stream.WriteLine("<td>{0}</td>", HttpUtility.HtmlEncode(value));
            }
            _stream.Write("</tr>");
        }

        public void Write(IEnumerable<string> row )
        {
            _stream.Write("<tr>");
            foreach(string value in row)
            {
                _stream.WriteLine("<td>{0}</td>", HttpUtility.HtmlEncode(value));
            }
            _stream.Write("</tr>");
        }
    }
}
