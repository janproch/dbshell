using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using Antlr.Runtime;

namespace DbShell.Driver.Common.AbstractDb
{
    public class ParsingServiceBase : IParsingService
    {
        public virtual AntlrTokens GetAntlrTokens()
        {
            return new AntlrTokens();
        }

        public virtual ITokenStream GetAntlrTokenStream(TextReader reader)
        {
            return null;
        }

        protected AntlrTokens GetAntlrTokens(string[] tokenNames)
        {
            var res = new AntlrTokens();
            res.EOF = Array.IndexOf(tokenNames, "EOF");
            res.F_DEC = Array.IndexOf(tokenNames, "F_DEC");
            res.F_INC = Array.IndexOf(tokenNames, "F_INC");
            res.F_NL = Array.IndexOf(tokenNames, "F_NL");
            res.T_IDENT = Array.IndexOf(tokenNames, "T_IDENT");
            res.T_QUOTED_IDENT = Array.IndexOf(tokenNames, "T_QUOTED_IDENT");
            res.DOT = Array.IndexOf(tokenNames, "DOT");
            res.SELECT = Array.IndexOf(tokenNames, "SELECT");
            res.ORDER = Array.IndexOf(tokenNames, "ORDER");
            res.BY = Array.IndexOf(tokenNames, "BY");
            res.GROUP = Array.IndexOf(tokenNames, "GROUP");
            res.HAVING = Array.IndexOf(tokenNames, "HAVING");
            res.WHERE = Array.IndexOf(tokenNames, "WHERE");
            res.JOIN = Array.IndexOf(tokenNames, "JOIN");
            res.ON = Array.IndexOf(tokenNames, "ON");
            res.FROM = Array.IndexOf(tokenNames, "FROM");
            res.T_STRING = Array.IndexOf(tokenNames, "T_STRING");
            res.UPDATE = Array.IndexOf(tokenNames, "UPDATE");
            res.DELETE = Array.IndexOf(tokenNames, "DELETE");
            res.SET = Array.IndexOf(tokenNames, "SET");
            res.INSERT = Array.IndexOf(tokenNames, "INSERT");
            res.LPAREN = Array.IndexOf(tokenNames, "LPAREN");
            res.RPAREN = Array.IndexOf(tokenNames, "RPAREN");
            res.INTO = Array.IndexOf(tokenNames, "INTO");
            res.AS = Array.IndexOf(tokenNames, "AS");
            return res;
        }
    }
}
