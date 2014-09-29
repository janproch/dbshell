using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonTypeSystem;

namespace DbShell.Driver.SqlServer
{
    public class SqlServerTypeProvider : SqlTypeProviderBase
    {
        public override void GetNativeDataType(Common.CommonTypeSystem.DbTypeBase commonType, Common.Structure.ColumnInfo columnInfo)
        {
            base.GetNativeDataType(commonType, columnInfo);
            switch (commonType.Code)
            {
                case DbTypeCode.Logical:
                    columnInfo.DataType = "bit";
                    return;
                case DbTypeCode.Blob:
                    columnInfo.DataType = "image";
                    return;
            }
        }
    }
}
