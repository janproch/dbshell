using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;
using Microsoft.Office.Interop.Excel;

namespace DbShell.Excel.ExcelModels
{
    public class ExcelModel
    {
        private Application _app;
        private Workbook _workbook;
        private bool _usedFirstSheet;
        private bool _openedForWrite;
        private string _file;
        private bool _createdWindow;

        private ExcelModel()
        {
            _app = new Application();
            _app.Visible = false;
        }

        public DataFormatSettings DataFormat;

        public static ExcelModel OpenFile(string file)
        {
            var res = new ExcelModel();
            res.DoOpenFile(file);
            return res;
        }

        public static ExcelModel CreateFile(string file)
        {
            var res = new ExcelModel();
            res.DoCreateFile(file);
            return res;
        }

        public static ExcelModel CreateNewWindow()
        {
            var res = new ExcelModel();
            res.DoCreateWindow();
            return res;
        }

        private void DoCreateWindow()
        {
            _workbook = _app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            _createdWindow = true;
        }

        private void DoCreateFile(string file)
        {
            _workbook = _app.Workbooks.Add(XlWBATemplate.xlWBATWorksheet);
            _openedForWrite = true;
            _file = file;
            if (File.Exists(_file)) File.Delete(_file);
        }

        private void DoOpenFile(string file)
        {
            _workbook = _app.Workbooks.Open(file);
        }

        private Worksheet GetSheet(string sheetName)
        {
            return (from Worksheet x in _workbook.Sheets where x.Name == sheetName select x).Single();
        }

        private Worksheet CreateSheet(TableInfo rowFormat, string sheetName)
        {
            Worksheet sheet;
            if (_usedFirstSheet) sheet = _workbook.Sheets.Add();
            else sheet = _workbook.Sheets[1];
            sheet.Name = sheetName;
            _usedFirstSheet = true;

            for (int i = 0; i < rowFormat.ColumnCount; i++)
            {
                ((Range) sheet.Cells[1, i + 1]).Value2 = rowFormat.Columns[i].Name;
            }
            return sheet;
        }

        public ICdlWriter CreateWriter(TableInfo rowFormat, string sheetName)
        {
            var sheet = CreateSheet(rowFormat, sheetName);
            return new ExcelWriter(rowFormat, sheet, DataFormat);
        }

        private TableInfo GetSheetStructure(Worksheet sheet)
        {
            var res = new TableInfo(null);
            var range = sheet.UsedRange.Columns;
            var usedNames = new HashSet<string>();
            for (int i = 1; i <= range.Count; i++)
            {
                usedNames.Add("column_" + i);
            }
            for (int i = 1; i <= range.Count; i++)
            {
                object value = ((Range) range.Cells[1, i]).Value2;
                string name = value.SafeToString();
                if (String.IsNullOrEmpty(name) || usedNames.Contains(name)) name = "column_" + i;
                usedNames.Add(name);
                res.Columns.Add(new ColumnInfo(res) { CommonType = new DbTypeString { Length = -1 }, DataType = "nvarchar", Length = -1, Name = name });

            }
            return res;
        }

        public TableInfo GetSheetStructure(string sheetName)
        {
            var sheet = GetSheet(sheetName);
            return GetSheetStructure(sheet);
        }

        public TableInfo GetSheetStructure(int index)
        {
            Worksheet sheet = _workbook.Sheets[index];
            return GetSheetStructure(sheet);
        }

        public ExcelReader CreateReader(string sheetName)
        {
            var sheet = GetSheet(sheetName);
            var ts = GetSheetStructure(sheet);
            return new ExcelReader(ts, sheet);
        }

        public ExcelReader CreateReader(int index)
        {
            var sheet = _workbook.Sheets[index];
            var ts = GetSheetStructure(sheet);
            return new ExcelReader(ts, sheet);
        }

        public string[] GetSheetNames()
        {
            return (from Worksheet sheet in _workbook.Sheets select sheet.Name).ToArray();
        }

        public void Close()
        {
            if (_openedForWrite)
            {
                _workbook.SaveAs(_file);
            }
            if (_createdWindow)
            {
                _app.Visible = true;
            }
            else
            {
                _workbook.Close();
                _app.Quit();
            }
        }
    }
}
