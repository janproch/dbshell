using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Driver.Common.CommonDataLayer;

namespace DbShell.Core
{
    public class Table : ElementBase, ITabularDataSource, ITabularDataTarget
    {
        public string Schema { get; set; }
        public string Name { get; set; }

        Driver.Common.Structure.TableInfo ITabularDataSource.GetRowFormat()
        {
            var db = GetDatabaseStructure();
            return db.FindTable(Schema, Name);
        }

        Driver.Common.CommonDataLayer.ICdlReader ITabularDataSource.CreateReader()
        {
            var dda = Connection.Factory.CreateDataAdapter();
            var conn = Connection.Connect();
            var cmd = conn.CreateCommand();
            //var fmt = Connection.Factory.CreateDumper();
            cmd.CommandText = "SELECT * FROM [" + Name + "]";
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
