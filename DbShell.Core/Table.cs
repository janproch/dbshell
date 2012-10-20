using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.Structure;
using DbShell.Driver.Common.Utility;

namespace DbShell.Core
{
    public class Table : ElementBase, ITabularDataSource, ITabularDataTarget
    {
        public string Schema { get; set; }
        public string Name { get; set; }

        Driver.Common.Structure.TableInfo ITabularDataSource.GetRowFormat()
        {
            var fullName = new NameWithSchema(Context.Replace(Schema), Context.Replace(Name));
            var db = GetDatabaseStructure();
            var table = db.FindTable(fullName.Schema, fullName.Name);
            if (table == null)
            {
                throw new Exception(String.Format("DBSH-00000 Table {0} not found", fullName));
            }
            return table;
        }

        Driver.Common.CommonDataLayer.ICdlReader ITabularDataSource.CreateReader()
        {
            var fullName = new NameWithSchema(Context.Replace(Schema), Context.Replace(Name));
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
            get { throw new NotImplementedException(); }
        }

        ICdlWriter ITabularDataTarget.CreateWriter(Driver.Common.Structure.TableInfo rowFormat)
        {
            throw new NotImplementedException();
        }

        Driver.Common.Structure.TableInfo ITabularDataTarget.GetRowFormat()
        {
            throw new NotImplementedException();
        }
    }
}
