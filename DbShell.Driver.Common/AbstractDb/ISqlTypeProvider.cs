using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.AbstractDb
{
    public interface ISqlTypeProvider
    {
        void GetNativeDataType(DbTypeBase commonType, ColumnInfo columnInfo);
    }
}
