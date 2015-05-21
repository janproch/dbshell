using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Driver.Common.ChangeSet
{
    public class ChangeSetModel
    {
        public List<ChangeSetUpdateItem> Updates = new List<ChangeSetUpdateItem>();
        public List<ChangeSetUpdateItem> Inserts = new List<ChangeSetUpdateItem>();
        public List<ChangeSetUpdateItem> Deletes = new List<ChangeSetUpdateItem>();
    }
}
