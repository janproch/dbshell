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
        public string LinkedServerName { get; set; }

        [XmlElem]
        public string LinkedDatabaseName { get; set; }

        [XmlElem]
        public string ExplicitDatabaseName { get; set; }

        public LinkedDatabaseInfo(string server, string database)
        {
            LinkedServerName = server;
            LinkedDatabaseName = database;
        }

        public LinkedDatabaseInfo(string explicitDatabase)
        {
            ExplicitDatabaseName = explicitDatabase;
        }

        public LinkedDatabaseInfo()
        {
        }

        public override string ToString()
        {
            if (LinkedServerName != null) return String.Format("[{0}].[{1}].", LinkedServerName, LinkedDatabaseName);
            if (ExplicitDatabaseName != null) return String.Format("[{0}].", ExplicitDatabaseName);
            return "";
        }

        public bool IsExplicitDatabase => !String.IsNullOrEmpty(ExplicitDatabaseName);
        public bool IsLinkedServer => !String.IsNullOrEmpty(LinkedServerName) && !String.IsNullOrEmpty(LinkedDatabaseName);
    }
}
