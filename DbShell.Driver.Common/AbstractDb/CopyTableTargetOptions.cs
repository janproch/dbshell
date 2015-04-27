using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.AbstractDb
{
    public enum TargetColumnMapMode
    {
        Name,
        NameExact, // name with case sensitive comparation
        Ordinal,
        OrdinalSkipIdentity,
    }

    public class CopyTableTargetOptions
    {
        public CopyTableTargetOptions()
        {
            AllowBulkCopy = true;
            TruncateBeforeCopy = false;
            DisableConstraints = false;
            TargetMapMode = TargetColumnMapMode.Name;
        }

        [XmlElem]
        public bool AllowBulkCopy { get; set; }

        [XmlElem]
        public bool TruncateBeforeCopy { get; set; }

        [XmlElem]
        public bool DisableConstraints { get; set; }

        [XmlElem]
        public TargetColumnMapMode TargetMapMode { get; set; }
    }
}
