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
        [XamlProperty]
        public string Schema { get; set; }

        /// <summary>
        /// Table name
        /// </summary>
        [XamlProperty]
        public string Name { get; set; }

        /// <summary>
        /// if table already exists, it is droppped
        /// </summary>
        [XamlProperty]
        public bool DropIfExists { get; set; }

        /// <summary>
        /// Name if created identity column. If given, column with type INT PRIMARY KEY IDENTITY is created
        /// </summary>
        public string IdentityColumn { get; set; }

        /// <summary>
        /// Linked server name
        /// </summary>
        [XamlProperty]
        public string LinkedServerName { get; set; }

        /// <summary>
        /// Database name on linked server
        /// </summary>
        [XamlProperty]
        public string LinkedDatabaseName { get; set; }

        public LinkedDatabaseInfo LinkedInfo
        {
            get { return new LinkedDatabaseInfo(LinkedServerName, LinkedDatabaseName); }
            set
            {
                if (value == null)
                {
                    LinkedServerName = null;
                    LinkedDatabaseName = null;
                }
                else
                {
                    LinkedServerName = value.LinkedServerName;
                    LinkedDatabaseName = value.LinkedDatabaseName;
                }
            }
        }

        protected NameWithSchema GetFullName(IShellContext context)
        {
            return new NameWithSchema(context.Replace(Schema), context.Replace(Name));
        }

        public bool IsAvailableRowFormat(IShellContext context)
        {
            throw new NotImplementedException();
        }

        public ICdlWriter CreateWriter(TableInfo rowFormat, CopyTableTargetOptions options, IShellContext context)
        {
            var connection = GetConnectionProvider(context);
            using (var conn = connection.Connect())
            {
                var db = new DatabaseInfo();
                db.LinkedInfo = LinkedInfo;
                var tbl = rowFormat.CloneTable(db);
                tbl.FullName = GetFullName(context);
                foreach(var col in tbl.Columns) col.AutoIncrement = false;
                tbl.ForeignKeys.Clear();
                if (tbl.PrimaryKey != null) tbl.PrimaryKey.ConstraintName = null;
                tbl.AfterLoadLink();

                if (IdentityColumn != null)
                {
                    var col = new ColumnInfo(tbl);
                    col.Name = IdentityColumn;
                    col.DataType = "int";
                    col.AutoIncrement = true;
                    col.NotNull = true;
                    var pk = new PrimaryKeyInfo(tbl);
                    pk.Columns.Add(new ColumnReference {RefColumn = col});
                    pk.ConstraintName = "PK_" + tbl.Name;
                    tbl.PrimaryKey = pk;
                    tbl.Columns.Add(col);
                }

                //var sw = new StringWriter();
                var so = new ConnectionSqlOutputStream(conn, null, connection.Factory.CreateDialect());
                var dmp = connection.Factory.CreateDumper(so, new SqlFormatProperties());
                if (DropIfExists) dmp.DropTable(tbl, true);
                tbl.Columns.ForEach(x => x.EnsureDataType(connection.Factory.CreateSqlTypeProvider()));
                dmp.CreateTable(tbl);
                //using (var cmd = conn.CreateCommand())
                //{
                //    cmd.CommandText = sw.ToString();
                //    cmd.ExecuteNonQuery();
                //}

                return new TableWriter(context, connection, GetFullName(context), rowFormat, options, tbl, LinkedInfo);
            }
        }

        public TableInfo GetRowFormat(IShellContext context)
        {
            throw new NotImplementedException();
        }

        public override string ToString()
        {
            return String.Format("[Create Table {0}]", Name);
        }
    }
}
