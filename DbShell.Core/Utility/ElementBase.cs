using System.ComponentModel;
using DbShell.Common;

namespace DbShell.Core.Utility
{
    public class ElementBase
    {
        [TypeConverter(typeof(ConnectionTypeConverter))]
        public IConnectionProvider Connection { get; set; }
    }
}
