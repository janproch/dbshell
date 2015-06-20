using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Antlr.Runtime;

namespace DbShell.Driver.Common.AbstractDb
{
    public class AntlrTokens
    {
        public int EOF, F_INC, F_DEC, F_NL, T_IDENT, T_QUOTED_IDENT, DOT, SELECT, ORDER, BY, GROUP, HAVING, WHERE,
            JOIN, ON, FROM, T_STRING, UPDATE, DELETE, SET, INSERT, LPAREN, RPAREN, INTO, AS;

        public bool IsIdent(int tokid)
        {
            return tokid == T_IDENT || tokid == T_QUOTED_IDENT;
        }
    }

    public interface IParsingService
    {
        AntlrTokens GetAntlrTokens();
        ITokenStream GetAntlrTokenStream(TextReader reader);
    }
}
