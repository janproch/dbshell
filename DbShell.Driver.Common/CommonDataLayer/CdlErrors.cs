using System;

namespace DbShell.Driver.Common.CommonDataLayer
{
    public class CdlTableError : Exception
    {
        public CdlTableError(string msg)
            : base(msg)
        { }
    }

    public class BadCdlRowStateError : Exception
    {
        public BadCdlRowStateError(string errcode, CdlRowState expected, CdlRowState found)
            : base(errcode + " Bad CDL row state, expected:" + expected.ToString() + "; found:" + found.ToString())
        {
        }
    }
}
