using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;
using OfficeOpenXml;

namespace DbShell.Excel.ExcelModels
{
    public class ExcelModel
    {
        private ExcelPackage _package;
        private bool _openedForWrite;
        private string _file;

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

        private void DoCreateFile(string file)
        {
            if (File.Exists(_file)) File.Delete(_file);
            _openedForWrite = true;
            _file = file;
            _package = new ExcelPackage();
        }

        private void DoOpenFile(string file)
        {
            _package = new ExcelPackage();
            using (var fs = File.OpenRead(file))
            {
                _package.Load(fs);
            }
        }

        private ExcelWorksheet GetSheet(string sheetName)
        {
            return _package.Workbook.Worksheets[sheetName];
        }

        private ExcelWorksheet CreateSheet(TableInfo rowFormat, string sheetName)
        {
            var sheet = _package.Workbook.Worksheets.Add(sheetName);

            for (int i = 0; i < rowFormat.ColumnCount; i++)
            {
                sheet.Cells[1, i + 1].Value = rowFormat.Columns[i].Name;
            }
            return sheet;
        }

        public ICdlWriter CreateWriter(TableInfo rowFormat, string sheetName)
        {
            var sheet = CreateSheet(rowFormat, sheetName);
            return new ExcelWriter(rowFormat, sheet, DataFormat);
        }

        private TableInfo GetSheetStructure(ExcelWorksheet sheet)
        {
            var res = new TableInfo(null);

            int rows = sheet.Dimension.Rows;
            int columns = sheet.Dimension.Columns;

            var usedNames = new HashSet<string>();
            for (int i = 1; i <= columns; i++)
            {
                usedNames.Add("column_" + i);
            }
            for (int i = 1; i <= columns; i++)
            {
                object value = sheet.GetValue(1, i);
                string name = value.SafeToString();
                if (String.IsNullOrEmpty(name) || usedNames.Contains(name)) name = "column_" + i;
                usedNames.Add(name);
                res.Columns.Add(new ColumnInfo(res) { CommonType = new DbTypeString { Length = -1 }, DataType = "nvarchar", Name = name });
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
            ExcelWorksheet sheet = _package.Workbook.Worksheets[index];
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
            var sheet = _package.Workbook.Worksheets[index];
            var ts = GetSheetStructure(sheet);
            return new ExcelReader(ts, sheet);
        }

        public string[] GetSheetNames()
        {
            return _package.Workbook.Worksheets.Select(x => x.Name).ToArray();
        }

        public void Close()
        {
            if (_openedForWrite)
            {
                _package.SaveAs(new FileInfo(_file));
            }
            _package.Dispose();
        }
    }
}
