﻿using System;
using System.Collections.Generic;
using System.Text;
using Irony.Parsing;

namespace DbShell.Core.ScriptParser
{
    public class DbShellLanguageProvider : Grammar, IDbShellLanguageProvider
    {
        public LanguageData DbShellLanguage { get; private set; }

        public DbShellLanguageProvider()
        {
            //Terminals
            var tident = new IdentifierTerminal("identifier");
            var tstring = new StringLiteral("string", "\"");
            var tnumber = new NumberLiteral("number");
            var tcomma = ToTerm(",");

            //Nonterminals
            var nCommand = new NonTerminal("Command");
            var nAssign = new NonTerminal("Assign");
            var nCommandWithSemicolon = new NonTerminal("CommandWithSemicolon");
            var nCommandList = new NonTerminal("CommandList");
            var nCommandPropList = new NonTerminal("CommandPropList");
            var nCommandProp = new NonTerminal("CommandProp");
            var nSubcommandList = new NonTerminal("SubCommandList");
            var nSubcommand = new NonTerminal("SubCommand");
            var nCommandValue = new NonTerminal("CommandValue");
            var nOptionalIdent = new NonTerminal("OptionalIdent");

            var narray = new NonTerminal("Array");
            var narrayBr = new NonTerminal("ArrayBr");
            var nvalue = new NonTerminal("Value");
            var nprop = new NonTerminal("Property");

            nCommand.Rule = tident + "(" + nCommandPropList + ")" + nSubcommandList;
            nCommand.Rule |= nAssign;
            nAssign.Rule = tident + "=" + tstring;
            nCommandWithSemicolon.Rule = nCommand;
            nCommandWithSemicolon.Rule |= nCommand + ";";
            nCommandList.Rule = MakeStarRule(nCommandList, nCommandWithSemicolon);

            nCommandPropList.Rule = MakeStarRule(nCommandPropList, tcomma, nCommandProp);
            nCommandValue.Rule = tstring | nCommand;
            nCommandProp.Rule = tident + "=" + nCommandValue;
            nSubcommandList.Rule = MakeStarRule(nSubcommandList, nSubcommand);
            nOptionalIdent.Rule = Empty | tident;
            nSubcommand.Rule = nOptionalIdent + "{" + nCommandList + "}";

            MarkPunctuation("{", "}", "(", ")", "=", ",", ";");
            MarkTransient(nCommandValue, nCommandWithSemicolon, nOptionalIdent);

            var singleLineComment = new CommentTerminal("SingleLineComment", "//", "\r", "\n", "\u2085", "\u2028", "\u2029");
            var delimitedComment = new CommentTerminal("DelimitedComment", "/*", "*/");
            NonGrammarTerminals.Add(singleLineComment);
            NonGrammarTerminals.Add(delimitedComment);

            this.Root = nCommandList;

            // build language
            DbShellLanguage = new LanguageData(this);
        }
    }
}
