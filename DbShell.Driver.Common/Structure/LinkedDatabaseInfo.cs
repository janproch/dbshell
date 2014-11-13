using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.Structure
{
    public class LinkedDatabaseInfo
    {
        [XmlElem]
        public string ServerName { get; set; }

        [XmlElem]
        public string DatabaseName { get; set; }

        public LinkedDatabaseInfo(string server, string database)
        {
            ServerName = server;
            DatabaseName = database;
        }

        public LinkedDatabaseInfo()
        {
        }

        public override string ToString()
        {
            if (ServerName != null) return String.Format("[{0}].[{1}].", ServerName, DatabaseName);
            return "";
        }
    }
}
