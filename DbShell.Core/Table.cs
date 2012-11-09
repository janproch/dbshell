using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Core
{
    /// <summary>
    /// Table in database
    /// </summary>
    public class Table : ElementBase, ITabularDataSource, ITabularDataTarget
    {
        /// <summary>
        /// Table schema, can be ommited (eg. "dbo" on SQL server)
        /// </summary>
        public string Schema { get; set; }

        /// <summary>
        /// Table name
        /// </summary>
        public string Name { get; set; }

        private TableInfo GetRowFormat()
        {
            var fullName = GetFullName();
            var db = GetDatabaseStructure();
            var table = db.FindTable(fullName.Schema, fullName.Name);
            if (table == null)
            {
                throw new Exception(String.Format("DBSH-00007 Table {0} not found", fullName));
            }
            return table;
        }

        private NameWithSchema GetFullName()
        {
            return new NameWithSchema(Context.Replace(Schema), Context.Replace(Name));
        }

        TableInfo ITabularDataSource.GetRowFormat()
        {
            return GetRowFormat();

        }

        ICdlReader ITabularDataSource.CreateReader()
        {
            var fullName = GetFullName();
            var dda = Connection.Factory.CreateDataAdapter();
            var conn = Connection.Connect();
            var cmd = conn.CreateCommand();
            var dialect = Connection.Factory.CreateDialect();
            cmd.CommandText = "SELECT * FROM " + dialect.QuoteFullName(fullName);
            var reader = cmd.ExecuteReader();
            var result = dda.AdaptReader(reader);
            result.Disposing += () =>
                {
                    reader.Dispose();
                    conn.Dispose();
                };
            return result;
        }


        bool ITabularDataTarget.AvailableRowFormat
        {
            get { return true; }
        }

        ICdlWriter ITabularDataTarget.CreateWriter(TableInfo rowFormat, CopyTableTargetOptions options)
        {
            return new TableWriter(Connection, GetFullName(), rowFormat, options);
        }

        TableInfo ITabularDataTarget.GetRowFormat()
        {
            return GetRowFormat();
        }

        public override string ToString()
        {
            return String.Format("[Table {0}]", GetFullName());
        }
    }
}
