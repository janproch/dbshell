#if !NETCOREAPP1_1

using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Antlr.Runtime;
using DbShell.Driver.Common.AbstractDb;

namespace DbShell.Driver.SqlServer
{
    public class SqlServerParsingService : ParsingServiceBase
    {
        public override AntlrTokens GetAntlrTokens()
        {
            var res = base.GetAntlrTokens(SqlServerParser.tokenNames);
            return res;
        }

        public override ITokenStream GetAntlrTokenStream(TextReader reader)
        {
            var lexer = new SqlServerLexer(new ANTLRReaderStream(reader));
            var tokens = new CommonTokenStream(lexer);
            return tokens;
        }
    }
}

#endif