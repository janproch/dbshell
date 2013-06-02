using DbShell.Driver.Common.CommonDataLayer;

namespace DbShell.Core.RazorModels
{
    public class DataRowModel
    {
        private ICdlRecord _record;

        public DataRowModel(ICdlRecord record)
        {
            _record = record;
        }

        public object this[int index]
        {
            get { return _record.GetValue(index); }
        }

        public object this[string field]
        {
            get { return _record.GetValue(field); }
        }
    }
}
