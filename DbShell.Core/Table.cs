using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Common;
using DbShell.Core.Utility;
using DbShell.Driver.Common.CommonDataLayer;

namespace DbShell.Core
{
    public class Table : ElementBase, ITabularDataSource
    {
        //public string Schema { get; set; }
        public string Name { get; set; }

        Driver.Common.Structure.TableInfo ITabularDataSource.GetRowFormat()
        {
            var analyser = Connection.Factory.CreateAnalyser();
            using (var conn = Connection.Connect())
            {
                analyser.Run(conn, conn.Database);
                return analyser.Result.FindTable(Name);
            }
        }

        Driver.Common.CommonDataLayer.ICdlReader ITabularDataSource.CreateReader()
        {
            var dda = Connection.Factory.CreateDataAdapter();
            var conn = Connection.Connect();
            var cmd = conn.CreateCommand();
            //var fmt = Connection.Factory.CreateDumper();
            cmd.CommandText = "SELECT * FROM [" + Name + "]";
            return dda.AdaptReader(cmd.ExecuteReader());
        }
    }
}
