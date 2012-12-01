namespace DbShell.Driver.Common.Structure
{
    public class ViewInfo : NamedObjectInfo
    {
        public ViewInfo(DatabaseInfo database)
            : base(database)
        {
        }

        public QueryResultInfo QueryInfo { get; set; }

        public string QueryText { get; set; }
    }
}