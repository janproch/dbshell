using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Text;
using System.Threading;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Interfaces;

namespace DbShell.Core.Utility
{
    public class TableWriter : ICdlWriter
    {
        public event Action Disposing;

        private IConnectionProvider _connectionProvider;
        private NameWithSchema _name;
        private TableInfo _inputRowFormat;
        private Thread _thread;
        private CdlDataQueue _queue;
        private IBulkInserter _inserter;
        private DbConnection _connection;
        private IShellContext _context;
        private LinkedDatabaseInfo _linkedInfo;

        public TableWriter(IShellContext context, IConnectionProvider connection, NameWithSchema name, TableInfo inputRowFormat, CopyTableTargetOptions options, TableInfo destinationTableOverride = null, LinkedDatabaseInfo linkedInfo = null, DataFormatSettings sourceDataFormat = null)
        {
            _connectionProvider = connection;
            _linkedInfo = linkedInfo;
            _name = name;
            _inputRowFormat = inputRowFormat;
            _queue = new CdlDataQueue(inputRowFormat);
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
            _inserter.MessageLogger = _context;
            _inserter.ServiceProvider = context.ServiceProvider;

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
