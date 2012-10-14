using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.CommonTypeSystem
{
    public abstract class DbTypeNumber : DbTypeBase
    {
        protected bool m_unsigned = false;
        [XmlAttrib("unsigned")]
        public bool Unsigned
        {
            get { return m_unsigned; }
            set { m_unsigned = value; }
        }
    }
}