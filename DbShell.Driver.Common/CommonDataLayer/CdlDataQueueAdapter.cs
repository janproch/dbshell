using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.CommonDataLayer
{
    public class CdlDataQueueAdapter : CdlRecordProxy, ICdlReader
    {
        private readonly CdlDataQueue _queue;

        public CdlDataQueueAdapter(CdlDataQueue queue)
        {
            _queue = queue;
        }

        public override Structure.TableInfo Structure
        {
            get { return _queue.Format; }
        }

        public bool Read()
        {
            if (!_queue.IsEof)
            {
                var row = _queue.GetRecord();
                RefObject = row;
                return true;
            }
            RefObject = null;
            return false;
        }

        public void Cancel() { }

        public bool NextResult()
        {
            return false;
        }

        public event Action Disposing;

        public void Dispose()
        {
            try
            {
                _queue.CloseReading();

            }
            finally
            {
                if (Disposing != null)
                {
                    Disposing();
                    Disposing = null;
                }
            }
        }
    }
}
