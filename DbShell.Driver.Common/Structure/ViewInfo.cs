using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.Structure
{
    public class ViewInfo : NamedObjectInfo
    {
        public ViewInfo(DatabaseInfo database)
            : base(database)
        {
        }

        [XmlSubElem]
        public QueryResultInfo QueryInfo { get; set; }

        [XmlElem]
        public string QueryText { get; set; }

        public override DatabaseObjectType ObjectType
        {
            get { return DatabaseObjectType.View; }
        }

        public ViewInfo Clone(DatabaseInfo ownerDb = null)
        {
            var res = new ViewInfo(ownerDb ?? OwnerDatabase);
            res.Assign(this);
            return res;
        }

        protected override void Assign(DatabaseObjectInfo source)
        {
            base.Assign(source);
            var src = (ViewInfo) source;
            QueryText = src.QueryText;
            if (src.QueryInfo != null) QueryInfo = src.QueryInfo.Clone();
        }
    }
}