using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.AbstractDb
{
    public class CopyTableTargetOptions
    {
        public CopyTableTargetOptions()
        {
            AllowBulkCopy = true;
            TruncateBeforeCopy = false;
            DisableConstraints = false;
        }

        [XmlElem]
        public bool AllowBulkCopy { get; set; }

        [XmlElem]
        public bool TruncateBeforeCopy { get; set; }

        [XmlElem]
        public bool DisableConstraints { get; set; }
    }
}
