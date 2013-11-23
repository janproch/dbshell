using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Driver.SqlServer
{
    // based of MSSQL 2008 datatypes, see http://msdn.microsoft.com/en-us/library/ms187752.aspx
    public enum SqlTypeCode
    {
        BigInt,
        Binary,
        Bit,
        Char,
        Date, // 2008
        DateTime,
        DateTime2, // 2008
        DateTimeOffset, // 2008
        Decimal,
        Float,
        Image,
        Int,
        Money,
        NChar,
        NText,
        NVarChar,
        Real,
        UniqueIdentifier,
        SmallDateTime,
        SmallInt,
        SmallMoney,
        Text,
        Time, // 2008
        Timestamp,
        TinyInt,
        VarBinary,
        VarChar,
        Variant,
        Xml, // 2005
        Numeric,

        Generic,
        //Udt = 29,
        //Structured = 30,
        //Date = 31,
        //Time = 32,
        //DateTime2 = 33,
        //DateTimeOffset = 34,
    }
}
