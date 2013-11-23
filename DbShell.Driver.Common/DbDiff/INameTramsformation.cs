using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.DbDiff
{
    public interface INameTransformation
    {
        NameWithSchema RenameObject(NameWithSchema name, string objtype);
        string RenameConstraint(ConstraintInfo constraint);
        string RenameColumn(NameWithSchema table, string name);
    }
}
