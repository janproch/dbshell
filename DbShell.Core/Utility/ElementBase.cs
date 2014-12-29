using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Xml;
using DbShell.Common;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Core.Utility
{
    public class ElementBase //: IShellElement
    {
        ///// <summary>
        ///// Gets or sets the connection.
        ///// </summary>
        ///// <value>
        ///// The connection in format sqlserver://connection_string for SQL Server
        ///// </value>
        //[TypeConverter(typeof (ConnectionTypeConverter))]
        //[XamlProperty]
        //public IConnectionProvider Connection
        //{
        //    get
        //    {
        //        if (_connection != null) return _connection;
        //        if (Context != null) return Context.DefaultConnection;
        //        return null;
        //    }
        //    set { _connection = value; }
        //}

        //public IConnectionProvider OwnConnection
        //{
        //    get { return _connection; }
        //    set { _connection = value; }
        //}

        //private IConnectionProvider _connection;

        //[DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        //public IShellContext Context { get; set; }

        ///// <summary>
        ///// Enumerates all child elements
        ///// </summary>
        ///// <param name="enumFunc">Function called for each child</param>
        //public virtual void EnumChildren(Action<IShellElement> enumFunc)
        //{
        //    if (Connection != this) YieldChild(enumFunc, Connection);
        //}

        //protected void YieldChild(Action<IShellElement> enumFunc, object value)
        //{
        //    var obj = value as IShellElement;
        //    if (obj != null) enumFunc(obj);
        //}

        [XamlProperty]
        public string Connection { get; set; }

        protected IConnectionProvider GetConnectionProvider(IShellContext context)
        {
            string providerString = GetProviderString(context);
            string providerStringReplaced = context.Replace(providerString);
            var conn = ConnectionProvider.FromString(providerStringReplaced);
            if (conn == null)
            {
                throw new Exception("DBSH-00000 Connection not defined, provider string:" + providerString);
            }
            return conn;
        }

        protected string GetProviderString(IShellContext context)
        {
            string providerString = Connection ?? context.GetDefaultConnection();
            if (providerString == null)
            {
                throw new Exception("DBSH-00000 Connection is not set, element=" + GetType().FullName);
            }
            return providerString;
        }

        protected DatabaseInfo GetDatabaseStructure(IShellContext context)
        {
            return context.GetDatabaseStructure(GetProviderString(context));
        }

        //protected string Replace(IShellContext context, string value, string replacePattern = null)
        //{
        //    if (Context != null) return Context.Replace(value, replacePattern);
        //    return value;
        //}
    }
}
