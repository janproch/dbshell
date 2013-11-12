using System;
using System.Collections;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Sql;
using DbShell.Driver.Common.Structure;

namespace DbShell.Core
{
    /// <summary>
    /// Creates table in database from row format
    /// </summary>
    public class CreateTable : ElementBase, ITabularDataTarget
    {
        /// <summary>
        /// Table schema, can be ommited (eg. "dbo" on SQL server)
        /// </summary>
        public string Schema { get; set; }

        /// <summary>
        /// Table name
        /// </summary>
        public string Name { get; set; }

        protected NameWithSchema GetFullName()
        {
            return new NameWithSchema(Replace(Schema), Replace(Name));
        }

        public bool AvailableRowFormat
        {
            get { throw new NotImplementedException(); }
        }

        public ICdlWriter CreateWriter(TableInfo rowFormat, CopyTableTargetOptions options)
        {
            using (var conn = Connection.Connect())
            {
                var tbl = rowFormat.Clone();
                tbl.FullName = GetFullName();
                foreach(var col in tbl.Columns) col.AutoIncrement = false;
                tbl.ForeignKeys.Clear();
                if (tbl.PrimaryKey != null) tbl.PrimaryKey.ConstraintName = null;
                tbl.AfterLoadLink();
                var sw = new StringWriter();
                var so = new SqlOutputStream(Connection.Factory.CreateDialect(), sw, new SqlFormatProperties());
                var dmp = Connection.Factory.CreateDumper(so, new SqlFormatProperties());
                dmp.CreateTable(tbl);
                using (var cmd = conn.CreateCommand())
                {
                    cmd.CommandText = sw.ToString();
                    cmd.ExecuteNonQuery();
                }
            }
            return new TableWriter(Context, Connection, GetFullName(), rowFormat, options);
        }

        public TableInfo GetRowFormat()
        {
            throw new NotImplementedException();
        }
    }
}
