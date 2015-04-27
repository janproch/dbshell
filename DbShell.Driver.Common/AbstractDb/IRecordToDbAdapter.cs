using DbShell.Driver.Common.CommonDataLayer;

namespace DbShell.Driver.Common.AbstractDb
{
    public interface IRecordToDbAdapter
    {
        ICdlRecord AdaptRecord(ICdlRecord record);
    }
}
