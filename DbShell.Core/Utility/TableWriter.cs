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
        private IShellContext _context;
        private LinkedDatabaseInfo _linkedInfo;

        public TableWriter(IShellContext context, IConnectionProvider connection, NameWithSchema name, TableInfo rowFormat, CopyTableTargetOptions options, TableInfo destinationTableOverride = null, LinkedDatabaseInfo linkedInfo = null, DataFormatSettings sourceDataFormat = null)
        {
            _connectionProvider = connection;
            _linkedInfo = linkedInfo;
            _name = name;
            _rowFormat = rowFormat;
            _queue = new CdlDataQueue(rowFormat);
            _context = context;

            _inserter = connection.Factory.CreateBulkInserter();
            _inserter.SourceDataFormat = sourceDataFormat;
            _connection = _connectionProvider.Connect();
            _inserter.Connection = _connection;
            _inserter.Factory = connection.Factory;
            _inserter.LinkedInfo = _linkedInfo;
            var db = context.GetDatabaseStructure(connection.ProviderString);
            _inserter.DestinationTable = destinationTableOverride ?? db.FindTableLike(_name.Schema, _name.Name);
            _inserter.CopyOptions = options;
            _inserter.Log += _inserter_Log;

            _thread = new Thread(Run);
            _thread.Start();
        }

        void _inserter_Log(Driver.Common.Utility.LogRecord obj)
        {
            _context.OutputMessage(obj.Message);
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
