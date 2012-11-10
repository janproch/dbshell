using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;

namespace DbShell.Core.Utility
{
    public class DynamicConnectionProvider : ElementBase, IConnectionProvider
    {
        private IConnectionProvider _provider;
        private string _providerString;

        public DynamicConnectionProvider(string providerString)
        {
            _providerString = providerString;
        }

        private void WantProvider()
        {
            if (_provider == null)
            {
                string s = Context.Replace(_providerString);
                _provider = ConnectionProvider.FromString(s);
                if (_provider == null) throw new Exception(String.Format("DBSH-00062 cannot create connection provider from string {0}", s));
            }
        }

        public System.Data.Common.DbConnection Connect()
        {
            WantProvider();
            return _provider.Connect();
        }

        public Driver.Common.AbstractDb.IDatabaseFactory Factory
        {
            get
            {
                WantProvider();
                return _provider.Factory;
            }
        }
    }
}
