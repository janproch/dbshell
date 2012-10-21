using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.SqlServer;

namespace DbShell.Core
{
    public class ConnectionProvider : IConnectionProvider
    {
        private string _connectionString;
        private IDatabaseFactory _factory;
        private string _provider;

        public ConnectionProvider(string provider, string connectionString)
        {
            _connectionString = connectionString;
            _provider = provider;
            _factory = FactoryProvider.FindFactory(_provider);

            if (_factory == null)
            {
                throw new Exception("DBSH-00000 Unknown connection provider:" + provider);
            }

            //switch (provider.ToLower())
            //{
            //    case "sqlserver":
            //        _factory = SqlServerDatabaseFactory.Instance;
            //        break;
            //    default:
                    
            //}
        }

        DbConnection IConnectionProvider.Connect()
        {
            DbConnection connection = _factory.CreateConnection(_connectionString);
            connection.Open();
            return connection;
        }

        IDatabaseFactory IConnectionProvider.Factory
        {
            get { return _factory; }
        }
    }
}
