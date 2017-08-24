using DbShell.Driver.Common.Utility;
using System.Runtime.Serialization;

namespace DbShell.Driver.Common.CommonTypeSystem
{
    [DataContract]
    public abstract class DbTypeNumber : DbTypeBase
    {
        protected bool m_unsigned = false;
        [XmlAttrib("unsigned")]
        [DataMember]
        public bool Unsigned
        {
            get { return m_unsigned; }
            set { m_unsigned = value; }
        }
    }
}