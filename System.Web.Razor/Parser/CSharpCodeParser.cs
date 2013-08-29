using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Linq;
using System.Web.Razor.Parser.SyntaxTree;
using System.Web.Razor.Resources;
using System.Web.Razor.Text;
using System.Diagnostics.CodeAnalysis;

namespace System.Web.Razor.Parser {
    public class CSharpCodeParser : CodeParser {

        internal static ISet<string> DefaultKeywords = new HashSet<string>() {
            "if",
            "do",
            "try",
            "for",
            "foreach",
            "while",
            "switch",
            "lock",
            "using",
            "section",
            "inherits",
            "helper",
            "functions",
            "namespace",
            "class",
            "layout"
        };

        internal static readonly int UsingKeywordLength = 5; // using

        private static Dictionary<char, char> _bracketPairs = new Dictionary<char, char>() {
            { '{', '}' },
            { '(', ')' },
            { '[', ']' },
            { '<', '>' }
        };

        private ISet<string> _topLevelKeywords;
        private BlockParser _implicitExpressionParser;

        private Dictionary<string, BlockParser> _identifierHandlers;

        protected internal Dictionary<string, BlockParser> RazorKeywords { get; private set; }

        protected internal override ISet<string> TopLevelKeywords {
            get {
                if (_topLevelKeywords == null) {
                    _topLevelKeywords = new HashSet<string>(Enumerable.Concat(
                        _identifierHandlers.Keys,
                        RazorKeywords.Keys
                    ));
                }
                return _topLevelKeywords;
            }
        }

        public CSharpCodeParser() {
            _implicitExpressionParser = WrapSimpleBlockParser(BlockType.Expression, ParseImplicitExpression);
            _identifierHandlers = new Dictionary<string, BlockParser>() {
                { "if", WrapSimpleBlockParser(BlockType.Statement, ParseIfStatement) },
                { "do", WrapSimpleBlockParser(BlockType.Statement, ParseDoStatement) },
                { "try", WrapSimpleBlockParser(BlockType.Statement, ParseTryStatement) },
                { "for", WrapSimpleBlockParser(BlockType.Statement, ParseConditionalBlockStatement) },
                { "foreach", WrapSimpleBlockParser(BlockType.Statement, ParseConditionalBlockStatement) },
                { "while", WrapSimpleBlockParser(BlockType.Statement, ParseConditionalBlockStatement) },
                { "switch", WrapSimpleBlockParser(BlockType.Statement, ParseConditionalBlockStatement) },
                { "lock", WrapSimpleBlockParser(BlockType.Statement, ParseConditionalBlockStatement) },
                { "using", ParseUsingStatement },
                { "case", WrapSimpleBlockParser(BlockType.Statement, ParseCaseBlock) },
                { "default", WrapSimpleBlockParser(BlockType.Statement, ParseCaseBlock) }
            };
            RazorKeywords = new Dictionary<string, BlockParser>() {
                { "section", WrapSimpleBlockParser(BlockType.Section, ParseSectionBlock) },
                { "inherits", WrapSimpleBlockParser(BlockType.Directive, ParseInheritsStatement) },
                { "helper", WrapSimpleBlockParser(BlockType.Helper, ParseHelperBlock) },
                { "functions", ParseFunctionsBlock },
                { "namespace", HandleReservedWord },
                { "class", HandleReservedWord },
                { "layout", HandleReservedWord }
            };
        }

        public override bool IsAtExplicitTransition() {
            return ParserHelpers.IsIdentifierStart(CurrentCharacter) ||
                   CurrentCharacter == '{' ||
                   CurrentCharacter == '(' ||
                   IsCommentStart();
        }

        public override bool IsAtImplicitTransition() {
            // No special implicit transitions for code
            return IsAtExplicitTransition();
        }

        protected override bool TryRecover(bool allowTransition, SpanFactory previousSpanFactory) {
            if (CurrentCharacter == ';') {
                return true;
            }
            if (CurrentCharacter == '{') {
                return !BalanceBrackets(allowTransition: allowTransition, spanFactory: previousSpanFactory, appendOuter: true, bracket: null, useTemporaryBuffer: false);
            }
            return false;
        }

        public override void ParseBlock() {
            if (Context == null) { throw new InvalidOperationException(RazorResources.Parser_Context_Not_Set); }

            // Initialize flags
            bool isStatementBlock = false;
            bool complete = true;

            // What kind of code block are we parsing?
            if (ParserHelpers.IsIdentifierStart(CurrentCharacter)) {
                CodeBlockInfo block = ParseBlockStart(isTopLevel: true, captureTransition: true);
                BlockParser parser = GetBlockParser(block, _implicitExpressionParser, out isStatementBlock);

                Debug.Assert(parser != null);
                complete = parser(block);
            }
            else {
                switch (CurrentCharacter) {
                    case '{':
                        StartBlock(BlockType.Statement);

                        isStatementBlock = true;
                        complete = ParseCodeBlock(new CodeBlockInfo(RazorResources.BlockName_Code, CurrentLocation, true), bracesAreMetacode: true);
                        break;
                    case '(':
                        StartBlock(BlockType.Expression);

                        complete = ParseDelimitedBlock(new CodeBlockInfo(RazorResources.BlockName_ExplicitExpression, CurrentLocation, true));
                        break;
                    default:
                        if (Char.IsWhiteSpace(CurrentCharacter)) {
                            OnError(CurrentLocation, RazorResources.ParseError_Unexpected_WhiteSpace_At_Start_Of_CodeBlock_CS);
                        }
                        else if (EndOfFile) {
                            OnError(CurrentLocation, RazorResources.ParseError_Unexpected_EndOfFile_At_Start_Of_CodeBlock);
                        }
                        else {
                            OnError(CurrentLocation, RazorResources.ParseError_Unexpected_Character_At_Start_Of_CodeBlock_CS, CurrentCharacter);
                        }
                        // Output a zero-length expression block
                        StartBlock(BlockType.Expression);
                        End(ImplicitExpressionSpan.Create(Context,
                                                          keywords: TopLevelKeywords,
                                                          acceptTrailingDot: false,
                                                          acceptedCharacters: AcceptedCharacters.NonWhiteSpace));
                        complete = true;
                        break;
                }
            }

            // Read all whitespace up to and including the trailing newline IF there isn't any whitespace until the newline
            if (!DesignTimeMode && isStatementBlock && !Context.WhiteSpaceIsImportantToAncestorBlock) {
                using (Context.StartTemporaryBuffer()) {
                    Context.AcceptWhiteSpace(includeNewLines: false);
                    if (Char.IsWhiteSpace(CurrentCharacter)) {
                        Context.AcceptLine(includeNewLineSequence: true);
                        Context.AcceptTemporaryBuffer();
                    }
                }
            }

            // End a span if we have any content left and don't already have a growable span
            if ((!Context.PreviousSpanCanGrow && !complete) || HaveContent) {
                var acceptedCharacters = !complete ? AcceptedCharacters.Any : AcceptedCharacters.None;
                End(CodeSpan.Create(Context, hidden: false, acceptedCharacters: acceptedCharacters));
            }
            EndBlock();
        }

        protected internal BlockParser WrapSimpleBlockParser(BlockType type, BlockParser blockParser) {
            return (block) => {
                if (block.IsTopLevel) {
                    StartBlock(type);
                    block.ResumeSpans(Context);
                }
                return blockParser(block);
            };
        }

        protected bool HandleReservedWord(CodeBlockInfo block) {
            StartBlock(BlockType.Directive);
            block.ResumeSpans(Context);
            End(MetaCodeSpan.Create(Context, hidden: false, acceptedCharacters: AcceptedCharacters.None));
            OnError(block.Start, String.Format(CultureInfo.CurrentCulture, RazorResources.ParseError_ReservedWord, block.Name));
            return true;
        }

        protected internal virtual bool ParseInheritsStatement(CodeBlockInfo block) {
            SourceLocation endInheritsLocation = Context.CurrentLocation;
            bool readWhitespace = RequireSingleWhiteSpace();
            End(MetaCodeSpan.Create(Context, hidden: false, acceptedCharacters: readWhitespace ? AcceptedCharacters.None : AcceptedCharacters.Any));

            // Accept Whitespace up to the new line or non-whitespace character
            Context.AcceptWhiteSpace(includeNewLines: false);

            string typeName = null;
            if (ParserHelpers.IsIdentifierStart(CurrentCharacter)) {
                using (Context.StartTemporaryBuffer()) {
                    // Accept a dotted-identifier, but allow <>
                    Context.AcceptLine(includeNewLineSequence: false);
                    typeName = Context.ContentBuffer.ToString();
                    Context.AcceptTemporaryBuffer();
                }
                Context.AcceptNewLine();
            }
            else {
                OnError(endInheritsLocation, RazorResources.ParseError_InheritsKeyword_Must_Be_Followed_By_TypeName);
            }

            if (HaveContent || readWhitespace) {
                End(InheritsSpan.Create(Context, typeName));
            }

            return false;
        }

        // @[not a block statement keyword]
        protected internal virtual bool ParseImplicitExpression(CodeBlockInfo block) {
            return ParseImplicitExpression(block, isWithinCode: false, expectIdentifierFirst: false);
        }

        protected internal virtual bool ParseImplicitExpression(CodeBlockInfo block, bool isWithinCode, bool expectIdentifierFirst) {
            // TODO: Refactor this into better block creation logic
            block.Name = RazorResources.BlockName_ImplicitExpression;

            AcceptedCharacters accepted = AcceptDottedExpression(isWithinCode, expectIdentifierFirst, '(', '[');
            End(ImplicitExpressionSpan.Create(Context, TopLevelKeywords, isWithinCode, accepted));

            return true; // Return value doesn't matter since we're creating the span here.
        }

        // Example statements:
        //  foreach(var f in Foo) [statement]
        //  { [statement-list] }
        //  <tag>[markup]</tag>
        protected internal virtual void ParseStatement(CodeBlockInfo block) {
            // Check for markup, because that will change the whitespace handling

            // Dev10 Bug 884969 - Emit space between markup and code
            // Whitespace ownership rules:
            //  * If there's no markup on a line, all the whitespace (including the trailing newline) belongs to code
            //  * Markup owns all markup from its start character back to, but excluding, the preceding  newline (or the start of code)
            //  * Markup owns all markup from its end character up to, and including, the trailing newline (or the start of code)
            Context.StartTemporaryBuffer();

            // Eat whitespace until a non-whitespace character, 
            AcceptWhiteSpaceByLines();

            // Error Detection: Check for @<p>Foo</p> and display an error
            if (CurrentCharacter == RazorParser.TransitionCharacter && Context.MarkupParser.NextIsTransition(allowImplicit: true, allowExplicit: false)) {
                Context.AcceptTemporaryBufferInDesignTimeMode();
                ParseInvalidMarkupSwitch();
                return;
            }
            // It's markup, so the whitespace belongs to the markup at runtime
            else if (Context.MarkupParser.IsAtImplicitTransition() ||
                (CurrentCharacter == RazorParser.TransitionCharacter && Context.MarkupParser.NextIsTransition(allowImplicit: false, allowExplicit: true))) {
                Context.AcceptTemporaryBufferInDesignTimeMode();
                ParseBlockWithOtherParser(previousSpanFactory: CodeSpan.Create);
                return;
            }

            // No markup on this line, so it's whitespace belongs to code.
            Context.AcceptTemporaryBuffer();

            // Ok, not markup at this point, so check for C# statements and other statements
            if (ParserHelpers.IsIdentifierStart(CurrentCharacter)) {
                CodeBlockInfo subBlock = ParseBlockStart(isTopLevel: false, captureTransition: false);
                BlockParser parser = GetBlockParser(subBlock, null);
                if (parser != null) {
                    // Block type is always the same as the current one since Plan9 Keywords aren't allowed here, so merge it into the current block
                    parser(subBlock);
                }
                else {
                    AcceptStatementToSemicolon();
                }
            }
            // Use the first character to determine if it's something we need to handle specially
            else if (CurrentCharacter == RazorParser.TransitionCharacter) {
                if (!TryParseComment(previousSpanFactory: CodeSpan.Create)) {
                    // "@[expr]" ==> Shorthand for Write([expr]);
                    ParseEmbeddedExpression();
                }
            }
            else if (CurrentCharacter == '{') {
                // "{ [statement-list] }" ==> Start of a code block
                ParseCodeBlock(block, bracesAreMetacode: false);
            }
            else if (IsCommentStart()) {
                AcceptComment();
            }
            else if (CurrentCharacter != '}') {
                // Nothing interesting, so just read to the ';'
                AcceptStatementToSemicolon();
            }
        }

        protected internal virtual void ParseInvalidMarkupSwitch() {
            using (Context.StartTemporaryBuffer()) {
                Context.AcceptWhiteSpace(includeNewLines: true);
                Context.AcceptCurrent();

                // Now at the start of a statement, so set an error marker
                OnError(CurrentLocation, RazorResources.ParseError_AtInCode_Must_Be_Followed_By_Colon_Paren_Or_Identifier_Start);
            }

            ParseBlockWithOtherParser(previousSpanFactory: CodeSpan.Create);
        }

        protected internal virtual bool ParseConditionalBlockStatement(CodeBlockInfo block) {
            Context.AcceptWhiteSpace(includeNewLines: true);

            if (CurrentCharacter == '(') {
                SourceLocation errorLocation = CurrentLocation;
                // Balance parens
                if (!BalanceBrackets()) {
                    Context.AcceptLine(includeNewLineSequence: false);
                    OnError(errorLocation, RazorResources.ParseError_Expected_CloseBracket_Before_EOF, "(", ")");
                    return false;
                }
            }

            return ParseControlFlowBody(block);
        }

        protected internal virtual bool ParseControlFlowBody(CodeBlockInfo block) {
            bool success = true;
            using (Context.StartTemporaryBuffer()) {
                Context.AcceptWhiteSpace(includeNewLines: true);

                if (CurrentCharacter != '{') {
                    success = false;
                    OnError(CurrentLocation, RazorResources.ParseError_SingleLine_ControlFlowStatements_Not_Allowed, "{", CurrentCharacter);
                }
                else {
                    Context.AcceptTemporaryBuffer();
                }
            }

            if (success) {
                // We know for sure it's a code block
                return ParseCodeBlock(block, bracesAreMetacode: false);
            }
            else {
                // Error recovery, let's just accept a statement
                ParseStatement(block);
                return false; // Not complete yet though
            }
        }

        protected internal virtual bool ParseTryStatement(CodeBlockInfo block) {
            // Parse the body
            ParseControlFlowBody(block);

            // Check for additional clauses
            bool allowAdditionalClauses = false;
            do {
                allowAdditionalClauses = false;
                Context.StartTemporaryBuffer();
                AcceptWhiteSpaceAndComments();
                if (!ParserHelpers.IsIdentifierStart(CurrentCharacter)) {
                    Context.RejectTemporaryBuffer();
                }
                else {
                    SourceLocation blockStart = CurrentLocation;
                    string identifier = Context.AcceptIdentifier();
                    if (String.Equals(identifier, "catch")) {
                        Context.AcceptTemporaryBuffer();
                        ParseConditionalBlockStatement(new CodeBlockInfo("catch", blockStart, false));
                        allowAdditionalClauses = true;
                    }
                    else if (String.Equals(identifier, "finally")) {
                        Context.AcceptTemporaryBuffer();

                        // After the "finally" we know we're done, but only if it's complete
                        return ParseControlFlowBody(new CodeBlockInfo("finally", blockStart, false));
                    }
                    else {
                        Context.RejectTemporaryBuffer();
                    }
                }
            } while (allowAdditionalClauses);
            return false;
        }

        protected internal virtual bool ParseDoStatement(CodeBlockInfo block) {
            // Parse the body
            bool bodyComplete = ParseControlFlowBody(block);

            // Check for a while clause and return if it's not there (C# requires it, but there's no real reason we need to, C# can report the error if it's missing)
            Context.StartTemporaryBuffer();
            AcceptWhiteSpaceAndComments();
            if (!Context.Peek("while", caseSensitive: true)) {
                Context.RejectTemporaryBuffer();
                return false;
            }
            Context.AcceptTemporaryBuffer();

            // Parse the while clause
            string whileKeyword = Context.AcceptIdentifier();
            Debug.Assert(whileKeyword == "while");

            Context.AcceptWhiteSpace(includeNewLines: true);
            if (CurrentCharacter == '(') {
                SourceLocation errorLocation = CurrentLocation;
                if (!BalanceBrackets()) {
                    Context.AcceptLine(includeNewLineSequence: false);
                    OnError(errorLocation, RazorResources.ParseError_Expected_CloseBracket_Before_EOF, "(", ")");
                }
            }
            if (CurrentCharacter == ';') {
                Context.AcceptCurrent();
                return bodyComplete; // The while clause is complete
            }
            return false;
        }

        protected internal virtual bool ParseIfStatement(CodeBlockInfo block) {
            SourceLocation errorLocation = CurrentLocation;

            // Parse the body
            ParseConditionalBlockStatement(block);

            // Parse the attached branches
            do {
                // Start a temporary buffer just in case we don't see the branch we expected
                Context.StartTemporaryBuffer();
                AcceptWhiteSpaceAndComments();
                errorLocation = CurrentLocation;

                // If the first character after the whitespace isn't an identifier, or comment we're done
                // If the first character is an identifier but isn't "else", we're also done
                if (!ParserHelpers.IsIdentifierStart(CurrentCharacter) ||
                    !String.Equals("else", Context.AcceptIdentifier(), StringComparison.Ordinal)) {
                    Context.RejectTemporaryBuffer();
                    break;
                }
                else {
                    Context.AcceptTemporaryBuffer();
                }

                bool isElseIf = false;
                using (Context.StartTemporaryBuffer()) {
                    Context.AcceptWhiteSpace(includeNewLines: true);

                    // Now, we need to check for "else if"
                    if (ParserHelpers.IsIdentifierStart(CurrentCharacter) && String.Equals("if", Context.AcceptIdentifier(), StringComparison.Ordinal)) {
                        isElseIf = true;
                        // It's an else if branch, parse a condition AND a body
                        Context.AcceptTemporaryBuffer();
                        Context.AcceptWhiteSpace(includeNewLines: true);
                        ParseConditionalBlockStatement(new CodeBlockInfo("else if", errorLocation, false));
                    }
                    else if (CurrentCharacter == '{') {
                        // It's a valid else
                        Context.AcceptTemporaryBuffer();
                    }
                    else {
                        // Brace-less else
                        OnError(CurrentLocation, RazorResources.ParseError_SingleLine_ControlFlowStatements_Not_Allowed, "{", CurrentCharacter);
                    }
                }

                // Have to do this because the using() {} block can't overlap with the if and we want the temporary buffer cleared up before this point
                if (!isElseIf) {
                    // It's an else branch, just parse a body

                    CodeBlockInfo elseBlock = new CodeBlockInfo("else", errorLocation, false);
                    if (CurrentCharacter == '{') {
                        return ParseCodeBlock(elseBlock, bracesAreMetacode: false);
                    }
                    else {
                        ParseStatement(elseBlock);
                        return false;
                    }
                }
            } while (!EndOfFile);
            return false;
        }

        protected internal virtual void AcceptWhiteSpaceAndComments() {
            Debug.Assert(InTemporaryBuffer);
            do {
                if (Context.Peek(RazorParser.StartCommentSequence, caseSensitive: true)) {
                    Context.AcceptTemporaryBuffer();
                    End(CodeSpan.Create);
                    ParseComment();
                    Context.StartTemporaryBuffer();
                }

                // Grab comments
                AcceptComment();

                Context.AcceptWhiteSpace(includeNewLines: true);
            } while (IsCommentStart() || Context.Peek(RazorParser.StartCommentSequence, caseSensitive: true));
        }

        protected internal virtual bool ParseCaseBlock(CodeBlockInfo block) {
            // TODO: Only allow case and default statements directly within switch statement
            // Parse until the ':'
            Context.AcceptUntilInclusive(':');

            while (!EndOfFile) {
                using (Context.StartTemporaryBuffer()) {
                    Context.AcceptWhiteSpace(includeNewLines: true);
                    string identifier = Context.AcceptIdentifier();
                    if (String.Equals(identifier, "case", StringComparison.OrdinalIgnoreCase) ||
                        String.Equals(identifier, "default", StringComparison.OrdinalIgnoreCase)) {
                        // Reached the next case block
                        break;
                    }
                    else if (CurrentCharacter == '}') {
                        // Reached the end of the switch, but we don't handle the '}'
                        break;
                    }
                }

                ParseStatement(block);
            }
            return false;
        }

        private bool ParseUsingStatement(CodeBlockInfo block) {
            if (block.IsTopLevel) {
                Context.ResumeSpan(block.InitialSpan);
            }

            using (Context.StartTemporaryBuffer()) {
                // Skip whitespace by lines
                Context.AcceptWhiteSpace(includeNewLines: false);

                if (CurrentCharacter == '(') {
                    Context.AcceptTemporaryBuffer();

                    // Parse like a regular control flow statement
                    if (block.IsTopLevel) {
                        block.InitialSpan = CodeSpan.Create(Context);
                        Context.ResetBuffers();

                        StartBlock(BlockType.Statement);
                        block.ResumeSpans(Context);
                    }
                    return ParseConditionalBlockStatement(block);
                }
                else if (!block.IsTopLevel) {
                    Context.RejectTemporaryBuffer();

                    // Not the right kind of using for this block.  We're not in a top-level block and we saw a namespace import or type alias
                    OnError(block.Start, RazorResources.ParseError_NamespaceImportAndTypeAlias_Cannot_Exist_Within_CodeBlock);
                }
                else if (ParserHelpers.IsIdentifierStart(CurrentCharacter)) {
                    Context.RejectTemporaryBuffer();

                    // Parse a namespace import
                    block.InitialSpan = CodeSpan.Create(Context);
                    Context.ResetBuffers();

                    StartBlock(BlockType.Directive);
                    block.ResumeSpans(Context);
                    ParseNamespaceImport();
                    return true;
                }
                else {
                    if (block.IsTopLevel) {
                        Context.AcceptTemporaryBuffer();

                        block.InitialSpan = CodeSpan.Create(Context);
                        Context.ResetBuffers();

                        StartBlock(BlockType.Statement);
                        block.ResumeSpans(Context);
                    }
                }
            }
            return false;
        }

        private bool ParseHelperBlock(CodeBlockInfo block) {
            SourceLocation errorLocation = CurrentLocation;
            bool readWhitespace = RequireSingleWhiteSpace();
            End(MetaCodeSpan.Create(Context, hidden: false, acceptedCharacters: readWhitespace ? AcceptedCharacters.None : AcceptedCharacters.Any));

            // Accept whitespace
            Context.AcceptWhiteSpace(includeNewLines: false);

            // Check for an identifier
            bool seenError = String.IsNullOrEmpty(
                Context.ExpectIdentifier(RazorResources.ParseError_Unexpected_Character_At_Helper_Name_Start, allowPrecedingWhiteSpace: true, errorLocation: errorLocation));

            // Check for parameter list
            errorLocation = CurrentLocation;
            Context.AcceptWhiteSpace(includeNewLines: false);
            bool seenOpenBracket = Context.Expect('(', outputError: !seenError, errorMessage: RazorResources.ParseError_MissingCharAfterHelperName, caseSensitive: true, errorLocation: errorLocation);
            seenError |= !seenOpenBracket;
            errorLocation = CurrentLocation;

            if (seenOpenBracket) {
                if (BalanceBrackets(allowTransition: false, spanFactory: null, appendOuter: true, bracket: '(', useTemporaryBuffer: false)) {
                    Context.Expect(')', outputError: !seenError);
                }
                else if (!seenError) {
                    seenError = true;
                    OnError(errorLocation, RazorResources.ParseError_UnterminatedHelperParameterList);
                }
            }

            bool outputtedHeader = false;
            Span headerSpan = null;
            using (Context.StartTemporaryBuffer()) {
                Context.AcceptWhiteSpace(includeNewLines: true);
                errorLocation = CurrentLocation;
                if (Context.Expect('{', outputError: !seenError, errorMessage: RazorResources.ParseError_MissingCharAfterHelperParameters)) {
                    Context.AcceptTemporaryBuffer();
                    if (HaveContent) {
                        outputtedHeader = true;
                        // Can't grow at the end since we saw "{"
                        headerSpan = HelperHeaderSpan.Create(Context, !seenError, AcceptedCharacters.Any);
                        End(headerSpan);
                        Context.FlushNextOutputSpan();
                    }

                    using (Context.StartBlock(BlockType.Statement, outputCurrentBufferAsTransition: false)) {
                        ParseCodeBlock(block, bracesAreMetacode: false, acceptBraces: false);
                        End(CodeSpan.Create);
                        Context.FlushNextOutputSpan();
                    }

                    if (CurrentCharacter != '}') {
                        if (headerSpan != null) {
                            headerSpan.AutoCompleteString = "}";
                        }
                    }
                    else {
                        headerSpan.AcceptedCharacters = AcceptedCharacters.None;
                        Context.AcceptCurrent();
                        End(HelperFooterSpan.Create);
                        return true; // Helper block can't grow any more
                    }
                }
                else {
                    seenError = true;
                    Context.RejectTemporaryBuffer();
                    Context.AcceptWhiteSpace(includeNewLines: false);
                }
            }

            if (!outputtedHeader && readWhitespace) {
                // In an error case, we need to classify whatever we did capture as HelperHeader
                End(HelperHeaderSpan.Create(Context, !seenError));
            }
            return false;
        }

        private bool ParseSectionBlock(CodeBlockInfo block) {
            RequireSingleWhiteSpace();
            Context.AcceptWhiteSpace(includeNewLines: false);
            bool complete = false;
            string sectionName = Context.ExpectIdentifier(RazorResources.ParseError_Unexpected_Character_At_Section_Name_Start);
            if (sectionName == null) {
                End(SectionHeaderSpan.Create(Context, sectionName: String.Empty, acceptedCharacters: AcceptedCharacters.Any));
            }
            else {
                Context.AcceptWhiteSpace(includeNewLines: false);
                using (Context.StartTemporaryBuffer()) {
                    Context.AcceptWhiteSpace(includeNewLines: true);
                    if (CurrentCharacter != '{') {
                        Context.RejectTemporaryBuffer();
                        OnError(CurrentLocation, RazorResources.ParseError_MissingOpenBraceAfterSection);
                        End(SectionHeaderSpan.Create(Context, sectionName, acceptedCharacters: AcceptedCharacters.Any));
                        return false;
                    }
                    else {
                        Context.AcceptTemporaryBuffer();
                    }
                }
                Context.AcceptCurrent(); // {

                SectionHeaderSpan headerSpan = SectionHeaderSpan.Create(Context, sectionName, acceptedCharacters: AcceptedCharacters.Any);
                End(headerSpan);

                Context.SwitchActiveParser();
                Context.MarkupParser.ParseSection(Tuple.Create("{", "}"), caseSensitive: true);
                Context.SwitchActiveParser();

                if (Context.CurrentCharacter == '}') {
                    complete = true;
                    Context.AcceptCurrent(); // }
                    End(MetaCodeSpan.Create(Context, hidden: false, acceptedCharacters: AcceptedCharacters.None));
                }
                else {
                    headerSpan.AutoCompleteString = "}";
                }

            }
            return complete;
        }

        private bool ParseFunctionsBlock(CodeBlockInfo block) {
            Debug.Assert(block.IsTopLevel, "Class blocks are only allowed at the top level");

            Context.ResumeSpan(block.InitialSpan);
            using (Context.StartTemporaryBuffer()) {
                Context.AcceptWhiteSpace(includeNewLines: true);
                if (CurrentCharacter == '{') {
                    Context.AcceptWhiteSpace(includeNewLines: true);
                }
                else {
                    Context.RejectTemporaryBuffer();

                    block.InitialSpan = CodeSpan.Create(Context);
                    Context.ResetBuffers();

                    StartBlock(BlockType.Expression);
                    block.ResumeSpans(Context);
                    ParseImplicitExpression(block);
                    return false;
                }
            }

            block.InitialSpan = MetaCodeSpan.Create(Context, hidden: false, acceptedCharacters: AcceptedCharacters.None);
            Context.ResetBuffers();

            StartBlock(BlockType.Functions);
            block.ResumeSpans(Context);

            return ParseDelimitedBlock(block, useErrorRecovery: false, autoCompleteString: "}");
        }

        private bool ParseDelimitedBlock(CodeBlockInfo block, bool allowTransition = true, bool useErrorRecovery = true, string autoCompleteString = null) {
            Context.AcceptWhiteSpace(includeNewLines: true);

            // Append the open bracket as a metacode token
            char bracket = CurrentCharacter;
            if (!_bracketPairs.ContainsKey(bracket)) {
                throw new InvalidOperationException(RazorResources.ParseDelimitedBlock_Requires_Bracket);
            }
            char terminator = _bracketPairs[bracket];

            Context.AcceptCurrent();
            End(MetaCodeSpan.Create(Context, hidden: false, acceptedCharacters: AcceptedCharacters.None));

            // Append the terminator as a metacode token
            bool complete = BalanceBrackets(allowTransition: allowTransition, spanFactory: null, appendOuter: false, bracket: bracket, useTemporaryBuffer: useErrorRecovery);
            if (!complete) {
                if (useErrorRecovery) {
                    // Try to recover
                    TryRecover(RecoveryModes.Markup | RecoveryModes.Transition);
                }

                End(CodeSpan.Create(Context, autoCompleteString));
                OnError(block.Start, RazorResources.ParseError_Expected_EndOfBlock_Before_EOF, block.Name, terminator, bracket);
            }
            else {
                End(CodeSpan.Create);
                Context.AcceptCurrent();
                End(MetaCodeSpan.Create(Context, hidden: false, acceptedCharacters: AcceptedCharacters.None));
            }
            return complete;
        }

        private bool ParseCodeBlock(CodeBlockInfo block, bool bracesAreMetacode, bool acceptBraces = true) {
            bool success = false;

            if (acceptBraces) {
                Context.AcceptCurrent(); // "{"
            }
            Span openBraceSpan = null;
            if (bracesAreMetacode) {
                openBraceSpan = MetaCodeSpan.Create(Context, hidden: false, acceptedCharacters: AcceptedCharacters.None);
                End(openBraceSpan);
            }

            while (!EndOfFile && CurrentCharacter != '}') {
                ParseStatement(block);
            }

            if (bracesAreMetacode) {
                if (!Context.PreviousSpanCanGrow || HaveContent) {
                    End(CodeSpan.Create(Context));
                }
            }

            Context.FlushNextOutputSpan();

            if (CurrentCharacter == '}') {
                success = true;
                if (acceptBraces) {
                    Context.AcceptCurrent();
                    if (bracesAreMetacode) {
                        End(MetaCodeSpan.Create(Context, hidden: false, acceptedCharacters: AcceptedCharacters.None));
                    }
                }
            }
            else {
                if (openBraceSpan != null && openBraceSpan.Next != null && openBraceSpan.Next is CodeSpan) {
                    openBraceSpan.Next.AutoCompleteString = "}";
                }
                OnError(block.Start, RazorResources.ParseError_Expected_EndOfBlock_Before_EOF, block.Name, '}', '{');
            }

            return success;
        }

        private void ParseNamespaceImport() {
            string ns = null;
            using (Context.StartTemporaryBuffer()) {
                Context.AcceptWhiteSpace(includeNewLines: true);
                // Append a dotted identifier 
                // (technically the left-side of a namespace alias can't be a dotted identifier, but we'll let the C# compiler handle that)
                AcceptTypeName(allowGenerics: false);

                // Done, check for type aliasing
                using (Context.StartTemporaryBuffer()) {
                    Context.AcceptWhiteSpace(includeNewLines: false);
                    if (CurrentCharacter == '=') {
                        // It's an alias
                        Context.AcceptTemporaryBuffer();
                        Context.AcceptCurrent();
                        Context.AcceptWhiteSpace(includeNewLines: true);
                        AcceptTypeName();
                    }
                    else {
                        // Nope, not a type alias
                        Context.RejectTemporaryBuffer();
                    }
                }

                // Done, collect the temporary buffer as the namespace
                ns = Context.ContentBuffer.ToString();
                Context.AcceptTemporaryBuffer();
            }

            using (Context.StartTemporaryBuffer()) {
                Context.AcceptWhiteSpace(includeNewLines: false);
                if (Char.IsWhiteSpace(CurrentCharacter)) {
                    // In the case of the new line, we don't want to include it as part of the span
                    Context.RejectTemporaryBuffer();
                }
                else if (CurrentCharacter == ';') {
                    // If the span didn't end as a result of new line then look for a semicolon
                    Context.AcceptCurrent();
                    Context.AcceptTemporaryBuffer();
                }
            }

            End(NamespaceImportSpan.Create(Context, AcceptedCharacters.NonWhiteSpace | AcceptedCharacters.WhiteSpace, SpanKind.Code, ns, UsingKeywordLength));
        }

        // '@expr' or '@(expr)' in Code
        private void ParseEmbeddedExpression() {
            // Output everything up to this point as code
            Span prev = CodeSpan.Create(Context);
            Context.ResetBuffers();

            // Append the "@"
            Context.AcceptCurrent();
            Span transition = TransitionSpan.Create(Context);
            Context.ResetBuffers();

            // Output the previous span and the transition token
            Output(prev);
            Context.ResumeSpan(transition);

            if (CurrentCharacter == '(') {
                // Parse an explicit expression
                using (StartBlock(BlockType.Expression)) {
                    ParseDelimitedBlock(new CodeBlockInfo(RazorResources.BlockName_ExplicitExpression, CurrentLocation, false));
                }
            }
            else if (CurrentCharacter == RazorParser.TransitionCharacter) {
                // Is escape sequence, i.e.: @@class.Foo() means a call to the void method foo ('@class.Foo()', not 'Write(@class.Foo());')
                End(CodeSpan.Create(Context, hidden: true));
                AcceptStatementToSemicolon();
            }
            else {
                // Dev10 Bugs 927695: To fix this issue, we need to handle statement blocks within code
                CodeBlockInfo block = ParseBlockStart(isTopLevel: true, captureTransition: true);
                BlockParser parser = GetBlockParser(block, null);
                bool complete = false;
                if (parser != null) {
                    OnError(block.Start, RazorResources.ParseError_Unexpected_Keyword_After_At, block.Name);
                    complete = parser(block);
                }
                else {
                    StartBlock(BlockType.Expression);
                    block.ResumeSpans(Context);
                    complete = ParseImplicitExpression(block, true, block.Name == null);
                }
                if (!complete) {
                    End(CodeSpan.Create);
                }

                EndBlock();
            }
        }

        protected internal override bool HandleTransition(SpanFactory spanFactory) {
            return HandleTransition(spanFactory, true);
        }

        private bool HandleTransition(SpanFactory spanFactory, bool acceptOuterTemporaryIfSwitching = false) {
            bool isMarkup = false;
            using (Context.StartTemporaryBuffer()) {
                Context.AcceptWhiteSpace(includeNewLines: true);
                Debug.Assert(CurrentCharacter == RazorParser.TransitionCharacter);
                Context.AcceptCurrent();
                isMarkup = Context.MarkupParser.IsAtTransition();
            }
            if (isMarkup) {
                if (acceptOuterTemporaryIfSwitching) {
                    // Accept the outer temporary buffer
                    Context.AcceptTemporaryBuffer();
                }
                if (DesignTimeMode) {
                    Context.AcceptWhiteSpace(includeNewLines: true);
                }
                End(spanFactory);
                using (StartBlock(BlockType.Template)) {
                    ParseBlockWithOtherParser(spanFactory);
                }
            }
            else {
                Context.AcceptWhiteSpace(includeNewLines: true);
            }

            return isMarkup;
        }

        protected internal override bool TryAcceptStringOrComment() {
            // We don't want terminators inside strings to trigger our exit condition, so we need to watch for them
            switch (CurrentCharacter) {
                // NOTE: Not using InlinePageParser.TransitionCharacter since we're looking for C#'s verbatim string specifier, not a transition
                case '@':
                    // Could be a verbatim string
                    if (Context.Peek("@\"", caseSensitive: true)) {
                        Context.AcceptCurrent();

                        // Read to the end of the verbatim string literal
                        AcceptQuotedLiteral(verbatim: true);
                        return true;
                    }
                    return false;
                case '"':
                case '\'':
                    // Read to the end of the string/character literal
                    AcceptQuotedLiteral(verbatim: false);
                    return true;
                case '/':
                    // Could be a comment
                    if (IsCommentStart()) {
                        AcceptComment();
                        return true;
                    }
                    return false;
                default:
                    return false;
            }
        }

        private void AcceptComment() {
            SourceLocation errorLocation = CurrentLocation;
            if (CurrentCharacter == '/') {
                Context.AcceptCurrent();
                if (CurrentCharacter == '/') {
                    // Read to the end of the line
                    Context.AcceptLine(includeNewLineSequence: true);
                }
                else if (CurrentCharacter == '*') {
                    // Block Comment, read until "*/"
                    Context.AcceptCurrent();
                    do {
                        Context.AcceptUntilInclusive('*');
                    } while (!EndOfFile && CurrentCharacter != '/');
                    if (EndOfFile) {
                        OnError(errorLocation, RazorResources.ParseError_BlockComment_Not_Terminated);
                    }
                    Context.AcceptCurrent();
                }
            }
        }

        private bool IsCommentStart() {
            return Context.PeekAny("//", "/*");
        }

        [SuppressMessage("Microsoft.Maintainability", "CA1502:AvoidExcessiveComplexity", Justification = "Error recovery logic is complicated. TODO Fix this")]
        private void AcceptStatementToSemicolon() {
            // Point we're going to recover to incase we have an incomplete statement
            SourceLocation? recoveryPoint = null;
            using (Context.StartTemporaryBuffer()) {
                do {
                    // REVIEW: It looks like we're looking for '@' twice, but that's only because it's also a string literal prefix in C#
                    AcceptUntilUnquoted(c => Char.IsWhiteSpace(c) || c == '{' || c == RazorParser.TransitionCharacter || c == '@' || c == ';' || c == '}');

                    // Create a recovery point for this statement incase it's incomplete
                    if (!recoveryPoint.HasValue) {
                        using (Context.StartTemporaryBuffer()) {
                            // Recover to markup only and stop at end statement end code block
                            if (TryRecover(RecoveryModes.Markup,
                                           ch => ch == '}' ||
                                                 ch == ';' ||
                                                 ch == '@' ||
                                                 ch == '"',
                                                 allowTransition: false,
                                                 previousSpanFactory: null)) {
                                recoveryPoint = Context.CurrentLocation;
                            }
                        }
                    }

                    bool ateWhiteSpace = false;
                    if (Char.IsWhiteSpace(CurrentCharacter)) {
                        // Chomp whitespace
                        Context.StartTemporaryBuffer();
                        AcceptWhiteSpaceByLines();
                        ateWhiteSpace = true;
                    }

                    if (CurrentCharacter == RazorParser.TransitionCharacter &&
                        Context.MarkupParser.NextIsTransition(allowImplicit: true, allowExplicit: true)) {
                        if (ateWhiteSpace) {
                            // Reject the outer temporary buffer
                            Context.RejectTemporaryBuffer();
                        }

                        Context.AcceptTemporaryBuffer();
                        HandleTransition(CodeSpan.Create);
                        // We just parsed a transition, so restart the recovery point
                        recoveryPoint = null;

                        // Restart the outer temporary buffer
                        Context.StartTemporaryBuffer();
                        continue;
                    }
                    else {
                        if (ateWhiteSpace) {
                            // Accept the whitespace
                            Context.AcceptTemporaryBuffer();
                        }

                        // Bail out if this is markup and we're at a recovery point
                        if (Context.MarkupParser.IsStartTag() &&
                            recoveryPoint == Context.CurrentLocation) {
                            // Accept the buffer and bail out so the markup can be handled
                            Context.AcceptTemporaryBuffer();
                            return;
                        }

                        if (ateWhiteSpace) {
                            // Continue so we can parse the next statement w/o whitespace
                            continue;
                        }

                        if (Context.Peek(RazorParser.StartCommentSequence, caseSensitive: true)) {
                            // Accept the outer temporary buffer
                            Context.AcceptTemporaryBuffer();
                            End(CodeSpan.Create);
                            ParseComment();

                            // We just parsed a comment, so restart the recovery point
                            recoveryPoint = null;

                            // Start the outer buffer
                            Context.StartTemporaryBuffer();
                        }
                        else if (CurrentCharacter == '{') {
                            // Accept the outer buffer
                            Context.AcceptTemporaryBuffer();

                            BalanceBrackets(allowTransition: true, spanFactory: null, appendOuter: true, bracket: null, useTemporaryBuffer: false);

                            // Start the outer buffer
                            Context.StartTemporaryBuffer();
                        }
                        else if (CurrentCharacter == RazorParser.TransitionCharacter) {
                            Context.AcceptTemporaryBuffer();
                            if (!TryParseComment(previousSpanFactory: CodeSpan.Create) &&
                                Context.MarkupParser.IsAtExplicitTransition()) {
                                HandleTransition(CodeSpan.Create);
                                // Restart the recovery point
                                recoveryPoint = null;
                            }
                            else {
                                Context.AcceptCurrent();
                            }

                            Context.StartTemporaryBuffer();
                        }
                    }

                } while (!EndOfFile && CurrentCharacter != ';' && CurrentCharacter != '}');

                // Don't read the terminator if it's a { or }
                if (CurrentCharacter == ';') {
                    // Read the terminator
                    Context.AcceptCurrent();
                    Context.AcceptTemporaryBuffer();
                }
                else if (CurrentCharacter != '}' && recoveryPoint.HasValue) {
                    // If we have a recovery point then use it
                    Context.RejectTemporaryBuffer();
                    Context.AcceptUntil(recoveryPoint.Value);
                }
                else {
                    Context.AcceptTemporaryBuffer();
                }
            }

            // REVIEW: Report a parser error if we terminated because of "{" or "}"? We found a C# statement that wasn't terminated by a ';', but we were able to recover...
        }

        private void AcceptQuotedLiteral(bool verbatim) {
            // Capture the start quote
            SourceLocation errorMarker = CurrentLocation;
            char quoteCharacter = CurrentCharacter;
            char appended = CurrentCharacter;
            do {
                appended = CurrentCharacter;
                Context.AcceptCurrent();
                if (!verbatim) {
                    if (appended == '\n' || (appended == '\r' && CurrentCharacter != '\n')) {
                        OnError(errorMarker, RazorResources.ParseError_Unterminated_String_Literal);
                        return;
                    }
                    else if (appended == '\\') {
                        // Auto append the next two characters so they don't trigger the while loop condition
                        // Even if the next character isn't a quote, we can still append it, since we don't 
                        // actually care about escapes for any reason other than to determine when to terminate the literal
                        Context.AcceptCurrent();
                    }
                }
                else if (CurrentCharacter == quoteCharacter) {
                    // Append the quote 
                    // (if it's doubled up, we'll append the other in this branch, otherwise we'll exit now, so the final AppendCurrent won't mess us up)
                    Context.AcceptCurrent();
                    if (CurrentCharacter == quoteCharacter) {
                        // Doubled quote character => don't terminate the string, so gobble the extra quote up so we don't terminate
                        Context.AcceptCurrent();
                        if (CurrentCharacter == quoteCharacter) {
                            continue; // Repeat the loop to check if this quote is an escaped one.
                        }
                    }
                    else {
                        // Wasn't doubled up, so exit now, we've already appended the end quote
                        return;
                    }
                }
            } while (!EndOfFile && CurrentCharacter != quoteCharacter);
            if (EndOfFile) {
                OnError(errorMarker, RazorResources.ParseError_Unterminated_String_Literal);
            }
            Context.AcceptCurrent(); // Append the end quote
        }

        private BlockParser GetBlockParser(CodeBlockInfo block, BlockParser fallbackParser) {
            bool _ = false; // Don't care in this case
            return GetBlockParser(block, fallbackParser, out _);
        }

        private BlockParser GetBlockParser(CodeBlockInfo block, BlockParser fallbackParser, out bool isStatementBlock) {
            BlockParser parser = null;
            isStatementBlock = true;
            if (block.Name == null || !_identifierHandlers.TryGetValue(block.Name, out parser)) {
                isStatementBlock = false;
                if (block.Name == null || !block.IsTopLevel || !RazorKeywords.TryGetValue(block.Name, out parser)) {
                    parser = fallbackParser;
                }
            }
            return parser;
        }

        protected internal override void AcceptGenericArgument() {
            if (CurrentCharacter == '<') {
                Context.AcceptCurrent();
                do {
                    Context.AcceptWhiteSpace(includeNewLines: false);
                    AcceptTypeName();
                    Context.AcceptWhiteSpace(includeNewLines: false);
                    if (CurrentCharacter == ',') {
                        Context.AcceptCurrent();
                    }
                    else {
                        break;
                    }
                } while (!EndOfFile);
                if (CurrentCharacter != '>') {
                    OnError(CurrentLocation, RazorResources.ParseError_ExpectedCloseAngle_After_GenericTypeArgument);
                }
                else {
                    Context.AcceptCurrent();
                }
            }
        }
    }
}
