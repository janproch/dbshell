using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using DbShell.Common;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;

namespace DbShell.Core.Utility
{
    public class TableWriter : ICdlWriter
    {
        public event Action Disposing;

        private IConnectionProvider _connectionProvider;
        private NameWithSchema _name;
        private TableInfo _rowFormat;
        private Thread _thread;
        private CdlDataQueue _queue;
        private IBulkInserter _inserter;
        private DbConnection _connection;

        public TableWriter(IConnectionProvider connection, NameWithSchema name, TableInfo rowFormat)
        {
            _connectionProvider = connection;
            _name = name;
            _rowFormat = rowFormat;
            _queue = new CdlDataQueue(rowFormat);

            _inserter = connection.Factory.CreateBulkInserter();
            _connection = _connectionProvider.Connect();
            _inserter.Connection = _connection;
            _inserter.DestinationTable = rowFormat;
            _inserter.DestinationTable.FullName = name;

            _thread = new Thread(Run);
            _thread.Start();
        }

        private void Run()
        {
            try
            {
                var adapter = new CdlDataQueueAdapter(_queue);
                _inserter.Run(adapter);
            }
            finally
            {
                _queue.CloseReading();
            }
        }

        public void Write(ICdlRecord row)
        {
            _queue.PutRecord(row);
        }

        public void Dispose()
        {
            _queue.PutEof();
            _queue.CloseWriting();

            _thread.Join();

            if (Disposing != null)
            {
                Disposing();
                Disposing = null;
            }
        }
    }
}
