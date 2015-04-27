using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.CommonTypeSystem;

namespace DbShell.Driver.SqlServer
{
    public class SqlServerDialectDataAdapter : DialectDataAdapterBase
    {
        public SqlServerDialectDataAdapter(IDatabaseFactory factory)
            : base(factory)
        {
        }

        protected override void ConvertNotNullValue(Common.CommonDataLayer.ICdlValueReader reader, DbTypeBase type, Common.CommonDataLayer.CdlValueHolder valueHolder,
                                                    Common.CommonDataLayer.ICdlValueConvertor converter)
        {
            if (type is DbTypeDatetime)
            {
                converter.ConvertValue(reader, TypeStorage.DateTime, valueHolder);
            }
            else
            {
                base.ConvertNotNullValue(reader, type, valueHolder, converter);
            }
        }
    }
}
