using System;
using System.Collections.Generic;
using System.ComponentModel;
using DbShell.Common;
using DbShell.Driver.Common.Structure;

namespace DbShell.Core.Utility
{
    public class ElementBase : IShellElement
    {
        /// <summary>
        /// Gets or sets the connection.
        /// </summary>
        /// <value>
        /// The connection in format sqlserver://connection_string for SQL Server
        /// </value>
        [TypeConverter(typeof (ConnectionTypeConverter))]
        public IConnectionProvider Connection { get; set; }

        [DesignerSerializationVisibility(DesignerSerializationVisibility.Hidden)]
        public IShellContext Context { get; set; }

        /// <summary>
        /// Enumerates all child elements
        /// </summary>
        /// <param name="enumFunc">Function called for each child</param>
        public virtual void EnumChildren(Action<IShellElement> enumFunc)
        {
            if (Connection != this) YieldChild(enumFunc, Connection);
        }

        protected void YieldChild(Action<IShellElement> enumFunc, object value)
        {
            var obj = value as IShellElement;
            if (obj != null) enumFunc(obj);
        }

        protected DatabaseInfo GetDatabaseStructure()
        {
            return Context.GetDatabaseStructure(Connection);
        }
    }
}
