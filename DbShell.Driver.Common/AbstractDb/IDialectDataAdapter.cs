using System.Data;
using DbShell.Driver.Common.CommonDataLayer;
using DbShell.Driver.Common.CommonTypeSystem;
using DbShell.Driver.Common.Structure;

namespace DbShell.Driver.Common.AbstractDb
{
    public class FulltextSearchParams
    {
        public bool ExactMatch = false;

        public string LikePrefix { get { return ExactMatch ? "" : "%"; } }
        public string LikePostfix { get { return ExactMatch ? "" : "%"; } }
    }

    public interface IDialectDataAdapter
    {
        ICdlReader AdaptReader(IDataReader reader);
        string GetSqlLiteral(ICdlValueReader reader, DbTypeBase type);
        string GetSqlLiteral(object value, DbTypeBase type);
        void AdaptValue(ICdlValueReader reader, DbTypeBase type, ICdlValueWriter writer, ICdlValueConvertor converter);
        string GetFulltextSearchExpr(string expr, string substring, FulltextSearchParams pars);
        string FilterNotDumpableCharacters(string value);
    }
}
