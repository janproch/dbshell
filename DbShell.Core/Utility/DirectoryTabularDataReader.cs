using DbShell.Driver.Common.CommonDataLayer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;

namespace DbShell.Core.Utility
{
    public class DirectoryTabularDataReader : CdlRecordProxy, ICdlReader
    {
        private IShellContext _context;
        private string[] _files;
        private string _propertyName;
        private ITabularDataSource _source;
        private int _currentIndex = -1;
        private ICdlReader _currentFileReader;

        public DirectoryTabularDataReader(IShellContext context, ITabularDataSource source, string propertyName, string[] files)
        {
            this._context = context;
            this._source = source;
            this._propertyName = propertyName;
            this._files = files;

            NextRefReader();
        }

        private bool NextRefReader()
        {
            _currentFileReader = null;
            RefObject = null;

            if (_currentIndex + 1 >= _files.Length) return false;
            _currentIndex++;

            using (var childCtx = _context.CreateChildContext())
            {
                childCtx.SetVariable(_context.Replace(_propertyName), _files[_currentIndex]);
                _currentFileReader = _source.CreateReader(childCtx);
                RefObject = _currentFileReader;
            }
            return true;
        }

        public event Action Disposing;

        public void Cancel()
        {
        }

        public void Dispose()
        {
            if (Disposing != null)
            {
                Disposing();
                Disposing = null;
            }
        }

        public bool NextResult()
        {
            return false;
        }

        public bool Read()
        {
            if (_currentFileReader == null)
            {
                return false;
            }
            if (!_currentFileReader.Read())
            {
                if (!NextRefReader()) return false;
                return _currentFileReader.Read();
            }
            return true;
        }
    }
}
