using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DbShell.Common;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.SqlServer;
using DbShell.Driver.Common.Utility;

namespace DbShell.Core
{
    public class ConnectionProvider : IConnectionProvider
    {
        private readonly string _connectionString;
        private readonly IDatabaseFactory _factory;
        private readonly string _provider;

        public ConnectionProvider(string provider, string connectionString)
        {
            _connectionString = connectionString;
            _provider = provider;
            _factory = FactoryProvider.FindFactory(_provider);

            if (_factory == null)
            {
                throw new Exception("DBSH-00001 Unknown connection provider:" + provider);
            }
        }

        public DbConnection Connect()
        {
            DbConnection connection = _factory.CreateConnection(_connectionString);
            connection.Open();
            return connection;
        }

        public IDatabaseFactory Factory
        {
            get { return _factory; }
        }

        public string ProviderString
        {
            get { return _provider + "://" + _connectionString; }
        }

        /// <summary>
        /// Returns a <see cref="System.String" /> that represents this instance.
        /// </summary>
        /// <returns>
        /// A <see cref="System.String" /> that represents this instance.
        /// </returns>
        public override string ToString()
        {
            return ((IConnectionProvider)this).ProviderString;
        }

        public static ConnectionProvider FromString(string s)
        {
            string provider, connString;
            if (ConnectionStringTool.SplitProviderString(s, out provider, out connString))
            {
                return new ConnectionProvider(provider, connString);
            }
            return null;
        }
    }
}
