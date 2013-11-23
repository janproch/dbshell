using DbShell.Driver.Common.DbDiff;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.AbstractDb
{
    /// <summary>
    /// basic information about SQL dialect (identifier quoting, etc.)
    /// </summary>
    public interface ISqlDialect
    {
        /// <summary>
        /// how ' character is quoted in string
        /// </summary>
        char StringEscapeChar { get; }
        /// <summary>
        /// begin of quoted identifier
        /// </summary>
        char QuoteIdentBegin { get; }
        /// <summary>
        /// end of quoted identifier
        /// </summary>
        char QuoteIdentEnd { get; }

        string QuoteIdentifier(string ident);
        string QuoteIdentifierIfNecessary(string ident);
        string UnquoteName(string name);

        HashSetEx<string> Keywords { get; }
        string StripComments(string content);

        SqlDumperCaps DumperCaps { get; }
        SqlDialectCaps DialectCaps { get; }
    }
}
