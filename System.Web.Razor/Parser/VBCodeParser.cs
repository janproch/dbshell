using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.Web.Razor.Parser.SyntaxTree;
using System.Web.Razor.Resources;
using System.Web.Razor.Text;
using System.Web.Razor.Utils;

namespace System.Web.Razor.Parser {
    public class VBCodeParser : CodeParser {
        internal static ISet<string> DefaultKeywords = new HashSet<string>(StringComparer.OrdinalIgnoreCase) {
            "functions",
            "code",
            "section",
            "do",
            "while",
            "if",
            "select",
            "for",
            "try",
            "with",
            "synclock",
            "using",
            "imports",
            "inherits",
            "option",
            "helper",
            "namespace",
            "class",
            "layout"
        };

        private ISet<string> _topLevelKeywords;

        protected internal Dictionary<string, BlockParser> KeywordHandlers { get; private set; }

        protected internal override ISet<string> TopLevelKeywords {
            get {
                if (_topLevelKeywords == null) {
                    _topLevelKeywords = new HashSet<string>(KeywordHandlers.Keys, StringComparer.OrdinalIgnoreCase);
                }
                return _topLevelKeywords;
            }
        }

        private const string ExitKeyword = "exit";
        private const string ContinueKeyword = "continue";
        private const string OptionStrictCodeDomName = "AllowLateBound";
        private const string OptionExplicitCodeDomName = "RequireVariableDeclaration";
        internal static readonly string EndSectionKeyword = "End Section";
        internal static readonly string EndHelperKeyword = "End Helper";
        internal static readonly int ImportsKeywordLength = 7; // Imports

        private readonly BlockParser HelperBodyParser;

        public VBCodeParser() {
            KeywordHandlers = new Dictionary<string, BlockParser>(StringComparer.OrdinalIgnoreCase) {
                { "code", CreateKeywordBlockParser("Code", isSpecialBlock: true, blockType: BlockType.Statement, terminatorTokens: new string[] {"End", "Code"}) },
                { "do", CreateKeywordBlockParser("Do", supportsExitAndContinue: true, acceptRestOfLine: true, terminatorTokens: new string[] {"Loop"}) },
                { "while", CreateKeywordBlockParser("While", supportsExitAndContinue: true, terminatorTokens: new string[] {"End", "While"}) },
                { "if", CreateKeywordBlockParser("If", terminatorTokens: new string[] {"End", "If"}) },
                { "select", CreateKeywordBlockParser("Select", blockName: "Select Case", terminatorTokens: new string[] {"End", "Select"}) },
                { "for", CreateKeywordBlockParser("For", supportsExitAndContinue: true, acceptRestOfLine: true, terminatorTokens: new string[] {"Next"}) },
                { "try", CreateKeywordBlockParser("Try", terminatorTokens: new string[] {"End", "Try"}) },
                { "with", CreateKeywordBlockParser("With", terminatorTokens: new string[] {"End", "With"}) },
                { "synclock", CreateKeywordBlockParser("SyncLock", terminatorTokens: new string[] {"End", "SyncLock"}) },
                { "using", CreateKeywordBlockParser("Using", terminatorTokens: new string[] {"End", "Using"}) },
                { "functions", CreateKeywordBlockParser("Functions", isSpecialBlock: true, blockType: BlockType.Functions, terminatorTokens: new string[] {"End", "Functions"}) },
                { "section", ParseSectionStatement },
                { "imports", ParseImportsStatement },
                { "inherits", ParseInheritsStatement },
                { "option", ParseOptionStatement },
                { "helper", ParseHelperBlock },
                { "namespace", HandleReservedWord },
                { "class", HandleReservedWord },
                { "layout", HandleReservedWord }
            };

            HelperBodyParser = CreateKeywordBlockParser("Helper", isSpecialBlock: true, terminatorTokens: new string[] { "End", "Helper" });
        }

        public override bool IsAtExplicitTransition() {
            return ParserHelpers.IsIdentifierStart(CurrentCharacter) ||
                   CurrentCharacter == '(' ||
                   CurrentCharacter == '\'';
        }

        public override bool IsAtImplicitTransition() {
            // No special implicit transitions
            return IsAtExplicitTransition();
        }

        public override void ParseBlock() {
            if (Context == null) { throw new InvalidOperationException(RazorResources.Parser_Context_Not_Set); }

            bool complete = false;
            if (ParserHelpers.IsIdentifierStart(CurrentCharacter)) {
                complete = ParseImplicitBlock(isTopLevel: true);
            }
            else {
                switch (CurrentCharacter) {
                    case '(':
                        complete = ParseExplicitExpression();
                        break;
                    default:
                        if (Char.IsWhiteSpace(CurrentCharacter)) {
                            OnError(CurrentLocation, RazorResources.ParseError_Unexpected_WhiteSpace_At_Start_Of_CodeBlock_VB);
                        }
                        else if (EndOfFile) {
                            OnError(CurrentLocation, RazorResources.ParseError_Unexpected_EndOfFile_At_Start_Of_CodeBlock);
                        }
                        else {
                            OnError(CurrentLocation, String.Format(CultureInfo.CurrentCulture,
                                                                   RazorResources.ParseError_Unexpected_Character_At_Start_Of_CodeBlock_VB,
                                                                   CurrentCharacter));
                        }
                        using (StartBlock(BlockType.Expression)) {
                            End(CodeSpan.Create);
                        }
                        complete = true;
                        break;
                }
            }

            if ((!complete && !Context.PreviousSpanCanGrow) || HaveContent) {
                End(CodeSpan.Create);
            }
        }

        protected internal override bool TryAcceptStringOrComment() {
            if (CurrentCharacter == '"') {
                Context.AcceptCurrent();

                bool inString = true;
                while (inString) {
                    Context.AcceptUntil(c => c == '"' || CharUtils.IsNewLine(c));
                    if (CurrentCharacter == '"') {
                        Context.AcceptCurrent();
                        if (CurrentCharacter == '"') {
                            // Doubled quote ==> escape sequence
                            Context.AcceptCurrent();
                        }
                        else {
                            inString = false;
                        }
                    }
                    else {
                        inString = false;
                    }
                }
                return true;
            }
            else if (CurrentCharacter == '\'') {
                Context.AcceptLine(includeNewLineSequence: true);
                return true;
            }
            else {
                using (Context.StartTemporaryBuffer()) {
                    string ident = Context.AcceptIdentifier();
                    if (String.Equals(ident, "REM", StringComparison.OrdinalIgnoreCase)) {
                        Context.AcceptTemporaryBuffer();
                        Context.AcceptLine(includeNewLineSequence: true);
                        return true;
                    }
                }
            }
            return false;
        }

        protected internal override bool HandleTransition(SpanFactory spanFactory) {
            return HandleTransitionCore(spanFactory, allowEmbeddedExpression: false);
        }

        private bool HandleTransitionCore(SpanFactory spanFactory, bool allowEmbeddedExpression, bool rejectOuterIfSwitching = false) {
            if (Context.Peek(RazorParser.StartCommentSequence, caseSensitive: true)) {
                Context.AcceptTemporaryBuffer();
                Debug.Assert(!InTemporaryBuffer);
                End(spanFactory);
                ParseComment();
                return true;
            }

            char? next = null;
            bool isTemplate = false;
            using (Context.StartTemporaryBuffer()) {
                Context.AcceptWhiteSpace(includeNewLines: true);
                if (CurrentCharacter != RazorParser.TransitionCharacter) {
                    return false;
                }
                Context.AcceptCurrent();
                next = CurrentCharacter;
                if (next == RazorParser.TransitionCharacter) {
                    isTemplate = true;
                    Context.AcceptCurrent();
                    next = CurrentCharacter;
                }
            }
            if (next == '<' || next == ':') {
                if (rejectOuterIfSwitching) {
                    Context.AcceptTemporaryBufferInDesignTimeMode();
                }
                else {
                    Context.AcceptTemporaryBuffer();
                }
                if (isTemplate) {
                    End(spanFactory);
                    StartBlock(BlockType.Template);
                }

                ParseBlockWithOtherParser(previousSpanFactory: spanFactory);

                if (isTemplate) {
                    EndBlock();
                }
                return true;
            }
            else if (allowEmbeddedExpression) {
                Context.AcceptTemporaryBuffer();
                ParseEmbeddedExpression();
                return true;
            }
            return false;
        }

        protected bool HandleReservedWord(CodeBlockInfo block) {
            using (StartBlock(BlockType.Directive)) {
                block.ResumeSpans(Context);
                End(MetaCodeSpan.Create(Context, hidden: false, acceptedCharacters: AcceptedCharacters.None));
                OnError(block.Start, String.Format(CultureInfo.CurrentCulture, RazorResources.ParseError_ReservedWord, block.Name));
            }
            return true;
        }

        private bool ParseHelperBlock(CodeBlockInfo block) {
            using (StartBlock(BlockType.Helper)) {
                block.ResumeSpans(Context);
                SourceLocation errorLocation = CurrentLocation;
                // If we see a new line then bail out early
                bool ateNewLine = ParserHelpers.IsNewLine(CurrentCharacter);
                bool readWhitespace = RequireSingleWhiteSpace();
                End(MetaCodeSpan.Create(Context, hidden: false, acceptedCharacters: readWhitespace ? AcceptedCharacters.None : AcceptedCharacters.Any));

                if (ateNewLine) {
                    return true;
                }

                // Accept whitespace
                AcceptWhitespaceWithVBNewlines();

                // Check for an identifier
                bool seenError = String.IsNullOrEmpty(
                    Context.ExpectIdentifier(RazorResources.ParseError_Unexpected_Character_At_Helper_Name_Start, allowPrecedingWhiteSpace: true, errorLocation: errorLocation));

                // Check for parameter list
                errorLocation = CurrentLocation;
                AcceptWhitespaceWithVBNewlines();
                bool outputtedHeader = false;
                if (Context.Expect('(', outputError: !seenError, errorMessage: RazorResources.ParseError_MissingCharAfterHelperName, caseSensitive: false, errorLocation: errorLocation)) {
                    errorLocation = CurrentLocation;
                    if (!BalanceBrackets(allowTransition: false, spanFactory: null, appendOuter: true, bracket: '(', useTemporaryBuffer: false)) {
                        OnError(errorLocation, RazorResources.ParseError_UnterminatedHelperParameterList);
                    }
                    else {
                        Context.Expect(')');

                        outputtedHeader = true;
                        Span headerSpan = HelperHeaderSpan.Create(Context, complete: !seenError, acceptedCharacters: AcceptedCharacters.Any);
                        End(headerSpan);
                        Context.FlushNextOutputSpan();

                        if (!HelperBodyParser(new CodeBlockInfo("Helper", block.Start, isTopLevel: true))) {
                            headerSpan.AutoCompleteString = VBCodeParser.EndHelperKeyword;
                        }
                    }
                }

                // Capture what we saw as an incomplete helper header span and return
                if (!outputtedHeader && readWhitespace) {
                    End(HelperHeaderSpan.Create(Context, complete: false));
                }

            }
            return true;
        }

        private bool ParseImplicitBlock(bool isTopLevel) {
            CodeBlockInfo block = ParseBlockStart(isTopLevel, captureTransition: true);
            BlockParser handler = null;
            if (block.Name != null && KeywordHandlers.TryGetValue(block.Name, out handler)) {
                return handler(block);
            }
            else {
                return ParseImplicitExpression(block);
            }
        }

        private bool ParseSectionStatement(CodeBlockInfo block) {
            using (StartBlock(BlockType.Section)) {
                block.ResumeSpans(Context);
                RequireSingleWhiteSpace();
                AcceptWhitespaceWithVBNewlines();
                string sectionName = Context.ExpectIdentifier(RazorResources.ParseError_Unexpected_Character_At_Section_Name_Start,
                                                              allowPrecedingWhiteSpace: false);
                SectionHeaderSpan headerSpan = SectionHeaderSpan.Create(Context, sectionName ?? String.Empty, acceptedCharacters: AcceptedCharacters.Any);
                End(headerSpan);

                // Parse a section
                Context.SwitchActiveParser();
                Context.MarkupParser.ParseSection(Tuple.Create((string)null, "end section"), caseSensitive: false);
                Context.SwitchActiveParser();

                // Expect "End Section" (Expect will throw errors if they aren't there)
                if (EndOfFile) {
                    OnError(block.Start, RazorResources.ParseError_BlockNotTerminated, "Section", EndSectionKeyword);
                    headerSpan.AutoCompleteString = EndSectionKeyword;
                    return true;
                }

                bool success = false;
                if (Context.Expect("end", outputError: true, errorMessage: null, caseSensitive: false)) {
                    Context.AcceptWhiteSpace(includeNewLines: true);
                    success = Context.Expect("section", outputError: true, errorMessage: null, caseSensitive: false);
                }
                if (!success) {
                    headerSpan.AutoCompleteString = EndSectionKeyword;
                }
                End(MetaCodeSpan.Create(Context, hidden: false, acceptedCharacters: AcceptedCharacters.None));
            }
            return true;
        }

        protected virtual bool ParseInheritsStatement(CodeBlockInfo block) {
            using (StartBlock(BlockType.Directive)) {
                block.ResumeSpans(Context);
                SourceLocation endInheritsLocation = CurrentLocation;
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
            }
            return true;
        }

        private bool ParseOptionStatement(CodeBlockInfo block) {
            using (StartBlock(BlockType.Directive)) {
                block.ResumeSpans(Context);
                Context.AcceptWhiteSpace(includeNewLines: true);

                // Read the next two identifiers with interleaved whitespace
                // TODO: Error checking
                SourceLocation errorLocation = CurrentLocation;
                string option = Context.AcceptIdentifier();

                string codeDomOptionName = null;
                bool flag = true; // Default to whatever the "on" value is
                if (String.Equals(option, "strict", StringComparison.OrdinalIgnoreCase)) {
                    codeDomOptionName = OptionStrictCodeDomName;
                    flag = false; // Strict On == AllowLateBinding Off
                }
                else if (String.Equals(option, "explicit", StringComparison.OrdinalIgnoreCase)) {
                    // Explicit On = RequireVariableDeclaration On
                    codeDomOptionName = OptionExplicitCodeDomName;
                }
                else {
                    OnError(errorLocation, RazorResources.ParseError_UnknownOption, option);
                }

                if (codeDomOptionName != null) {
                    Context.AcceptWhiteSpace(includeNewLines: true);
                    string value = Context.AcceptIdentifier();
                    if (String.Equals(value, "off", StringComparison.OrdinalIgnoreCase)) {
                        // Flip the flag to it's "off" value
                        flag = !flag;
                    }
                    else if (!String.Equals(value, "on", StringComparison.OrdinalIgnoreCase)) {
                        // Not ON or OFF ==> Error
                        OnError(errorLocation, RazorResources.ParseError_InvalidOptionValue, option, value);
                    }
                }
                End(VBOptionSpan.Create(Context, codeDomOptionName, flag));
            }
            return true;
        }

        private bool ParseImportsStatement(CodeBlockInfo block) {
            using (StartBlock(BlockType.Directive)) {
                string ns = String.Empty;
                block.ResumeSpans(Context);
                using (Context.StartTemporaryBuffer()) {
                    Context.AcceptWhiteSpace(includeNewLines: false);
                    if (ParserHelpers.IsIdentifierStart(CurrentCharacter)) {
                        Context.AcceptIdentifier();
                        if (CurrentCharacter == '.') {
                            // Definitely a namespace import
                            Context.AcceptCurrent();
                            AcceptTypeName(allowGenerics: false);
                        }
                        else {
                            // Could be an alias, need to check what's after whitespace
                            using (Context.StartTemporaryBuffer()) {
                                Context.AcceptWhiteSpace(includeNewLines: false);
                                if (CurrentCharacter == '=') {
                                    Context.AcceptTemporaryBuffer();
                                    Context.AcceptCurrent();
                                    Context.AcceptWhiteSpace(includeNewLines: false);
                                    if (ParserHelpers.IsIdentifierStart(CurrentCharacter)) {
                                        AcceptTypeName();
                                    }
                                    else {
                                        OnError(CurrentLocation, RazorResources.ParseError_NamespaceOrTypeAliasExpected);
                                    }
                                }
                            }
                        }

                        // Capture the content of the temporary buffer as the namespace
                        ns = Context.ContentBuffer.ToString();
                    }
                    else {
                        OnError(CurrentLocation, RazorResources.ParseError_NamespaceOrTypeAliasExpected);
                    }
                    Context.AcceptTemporaryBuffer();
                    
                    // Capture trailing whitespace to the end of the line
                    Context.AcceptWhiteSpace(includeNewLines: false);
                    if (ParserHelpers.IsNewLine(Context.CurrentCharacter)) {
                        Context.AcceptNewLine();
                    }
                }
                End(NamespaceImportSpan.Create(Context, acceptedCharacters: AcceptedCharacters.Any, kind: SpanKind.MetaCode, ns: ns, namespaceKeywordLength: ImportsKeywordLength));
            }
            return true;
        }

        private bool ParseImplicitExpression(CodeBlockInfo block) {
            return ParseImplicitExpression(block, acceptTrailingDot: false);
        }

        private bool ParseImplicitExpression(CodeBlockInfo block, bool acceptTrailingDot) {
            bool expectIdentifierFirst = block.Name == null;
            block.Name = RazorResources.BlockName_ImplicitExpression;
            using (StartBlock(BlockType.Expression)) {
                block.ResumeSpans(Context);
                AcceptedCharacters accepted = AcceptDottedExpression(acceptTrailingDot, expectIdentifierFirst, '(');
                End(ImplicitExpressionSpan.Create(Context, TopLevelKeywords, acceptTrailingDot, accepted));
                return true;
            }
        }

        private bool ParseExplicitExpression() {
            using (StartBlock(BlockType.Expression)) {
                SourceLocation blockStart = CurrentLocation;

                // Accept the "(" and output it as a meta-code span
                Context.AcceptCurrent();
                End(MetaCodeSpan.Create(Context, hidden: false, acceptedCharacters: AcceptedCharacters.None));

                bool complete = BalanceBrackets(allowTransition: true, spanFactory: null, appendOuter: false, bracket: '(');
                if (!complete) {
                    // Accept to end of line to recover from the error
                    Context.AcceptLine(includeNewLineSequence: false);

                    End(CodeSpan.Create);
                    OnError(blockStart, RazorResources.ParseError_Expected_EndOfBlock_Before_EOF, "explicit expression", ")", "(");
                }
                else {
                    End(CodeSpan.Create);
                    Context.AcceptCurrent();
                    End(MetaCodeSpan.Create(Context, hidden: false, acceptedCharacters: AcceptedCharacters.None));
                }
                return complete;
            }
        }

        private BlockParser CreateKeywordBlockParser(string identifier, string blockName = null, bool isSpecialBlock = false, bool supportsExitAndContinue = false, bool acceptRestOfLine = false, BlockType blockType = BlockType.Statement, params string[] terminatorTokens) {
            return block => {
                bool complete = false;
                if (blockName != null) {
                    block.Name = blockName;
                }
                else {
                    block.Name = identifier;
                }

                using (StartBlock(blockType)) {
                    block.ResumeSpans(Context);
                    Span headerSpan = null;
                    if (isSpecialBlock && HaveContent) {
                        headerSpan = MetaCodeSpan.Create(Context, hidden: false, acceptedCharacters: AcceptedCharacters.None);
                        End(headerSpan);
                    }

                    if (ParseBlockStatement(identifier, isSpecialBlock, supportsExitAndContinue, terminatorTokens)) {
                        complete = true;

                        // Saw end sequence...
                        if (isSpecialBlock) {
                            // ... but we need to output what we've seen so far as a code span first
                            End(CodeSpan.Create);

                            // Expect the terminator tokens with interleaved whitespace
                            for (int i = 0; i < terminatorTokens.Length - 1; i++) {
                                Context.Expect(terminatorTokens[i], outputError: true, errorMessage: null, caseSensitive: false);
                                AcceptWhitespaceWithVBNewlines();
                            }
                            // Expect the last one (no whitespace afterwards (for now))
                            Context.Expect(terminatorTokens[terminatorTokens.Length - 1], outputError: true, errorMessage: null, caseSensitive: false);

                            // Now we can output that as the meta-code span
                            End(MetaCodeSpan.Create(Context, hidden: false, acceptedCharacters: AcceptedCharacters.None));
                        }
                        else {
                            AcceptedCharacters acceptedCharacters = AcceptedCharacters.None;
                            Context.AcceptLine(includeNewLineSequence: false);
                            if (acceptRestOfLine) {
                                acceptedCharacters = AcceptedCharacters.WhiteSpace | AcceptedCharacters.NonWhiteSpace;
                            }

                            if (!DesignTimeMode) {
                                Context.AcceptNewLine();
                            }

                            End(CodeSpan.Create(Context, hidden: false, acceptedCharacters: acceptedCharacters));
                        }
                    }
                    else {
                        End(CodeSpan.Create);
                        Context.FlushNextOutputSpan();

                        // Returned because of EOF!
                        string terminator = String.Join(" ", terminatorTokens);
                        if (headerSpan != null && headerSpan.Next != null && headerSpan.Next is CodeSpan) {
                            headerSpan.Next.AutoCompleteString = terminator;
                        }
                        OnError(block.Start, RazorResources.ParseError_BlockNotTerminated, block.Name, terminator);
                    }
                }
                return complete;
            };
        }

        private bool ParseBlockStatement(string identifier, bool isSpecialBlock, bool supportsExitAndContinue, params string[] terminatorTokens) {
            while (!EndOfFile) {
                Context.StartTemporaryBuffer();
                AcceptWhiteSpaceByLines();

                if (!HandleTransitionCore(CodeSpan.Create, true, rejectOuterIfSwitching: true)) {
                    Context.AcceptTemporaryBuffer();

                    if (!TryAcceptStringOrComment()) {
                        Context.StartTemporaryBuffer();
                        if (AcceptWithInterleavedWhiteSpace(caseSensitive: false, expectedTokens: terminatorTokens)) {
                            if (!isSpecialBlock) {
                                Context.AcceptTemporaryBuffer();
                            }
                            else {
                                Context.RejectTemporaryBuffer();
                            }
                            return true;
                        }
                        else {
                            Context.AcceptTemporaryBuffer();
                            string nextIdentifier = Context.AcceptIdentifier();

                            if (String.IsNullOrEmpty(nextIdentifier)) {
                                AcceptCurrentAndNextIfXmlAttributeProperty();
                            }
                            else if ((!isSpecialBlock && supportsExitAndContinue) &&
                                        (String.Equals(ExitKeyword, nextIdentifier, StringComparison.OrdinalIgnoreCase) ||
                                        String.Equals(ContinueKeyword, nextIdentifier, StringComparison.OrdinalIgnoreCase))) {
                                // Handle the "Exit/Continue ..." case, but only if the block supports it
                                // Accept another identifier, if it's the same as the current one
                                Context.AcceptWhiteSpace(includeNewLines: true);
                                Context.Accept(identifier, caseSensitive: false);
                            }
                            else if (!isSpecialBlock && String.Equals(identifier, nextIdentifier, StringComparison.OrdinalIgnoreCase)) {
                                // Recursively parse this block
                                ParseBlockStatement(identifier, isSpecialBlock, supportsExitAndContinue, terminatorTokens);
                            }
                            else {
                                // Just saw an identifier, so accept it an optional type suffix
                                if (CurrentCharacter == '@') {
                                    Context.AcceptCurrent();
                                }
                            }
                        }
                    }
                }
            }
            return false;
        }

        private void AcceptCurrentAndNextIfXmlAttributeProperty() {
            // If the previous character is a "." or identifier part, then the "@" is valid VB code:
            // * foo.@bar is an Attribute Axis Property
            // * Dim foo@ is a Type Suffix
            bool acceptAt = CurrentCharacter == '.' || ParserHelpers.IsIdentifierPart(CurrentCharacter);
            Context.AcceptCurrent();
            // Prevent foo.@bar from triggering switch to markup
            if (acceptAt && CurrentCharacter == RazorParser.TransitionCharacter) {
                Context.AcceptCurrent();
            }
        }

        private void
            ParseEmbeddedExpression() {
            // End the current code span
            End(CodeSpan.Create);

            // Expect "@"
            Context.Expect(RazorParser.TransitionCharacter);

            // Run the appropriate parser
            if (CurrentCharacter == '(') {
                ParseExplicitExpression();
            }
            else {
                CodeBlockInfo block = ParseBlockStart(isTopLevel: true, captureTransition: true);
                BlockParser parser = null;
                if (block.Name != null && KeywordHandlers.TryGetValue(block.Name, out parser)) {
                    OnError(block.Start, RazorResources.ParseError_Unexpected_Keyword_After_At, block.Name);
                    parser(block);
                }
                else {
                    ParseImplicitExpression(block, acceptTrailingDot: true);
                }
            }
        }

        protected internal override void AcceptGenericArgument() {
            if (CurrentCharacter == '(') {
                Context.AcceptCurrent();
                if (!Context.Peek("Of", caseSensitive: false)) {
                    OnError(CurrentLocation, RazorResources.ParseError_ExpectedOfKeyword_After_Start_Of_GenericTypeArgument);
                }
                else {
                    Context.Expect("Of", outputError: true, errorMessage: null, caseSensitive: false);
                    do {
                        Context.AcceptWhiteSpace(includeNewLines: false);
                        if (!ParserHelpers.IsIdentifierStart(CurrentCharacter)) {
                            OnError(CurrentLocation, RazorResources.ParseError_ExpectedTypeName_After_OfKeyword);
                            break;
                        }
                        else {
                            AcceptTypeName();
                            Context.AcceptWhiteSpace(includeNewLines: false);
                            if (CurrentCharacter == ',') {
                                Context.AcceptCurrent();
                            }
                            else {
                                break;
                            }
                        }
                    } while (!EndOfFile);
                    if (CurrentCharacter != ')') {
                        OnError(CurrentLocation, RazorResources.ParseError_ExpectedCloseParen_After_GenericTypeArgument);
                    }
                    else {
                        Context.AcceptCurrent();
                    }
                }
            }
        }

        private void AcceptWhitespaceWithVBNewlines() {
            while (!EndOfFile && (CharUtils.IsNonNewLineWhitespace(CurrentCharacter) || CurrentCharacter == '_')) {
                Context.AcceptWhiteSpace(includeNewLines: false);
                if (CurrentCharacter == '_') {
                    Context.AcceptCurrent();
                    if (CharUtils.IsNewLine(CurrentCharacter)) {
                        Context.AcceptNewLine();
                    }
                }
            }
        }

        private bool AcceptWithInterleavedWhiteSpace(bool caseSensitive = true, params string[] expectedTokens) {
            using (Context.StartTemporaryBuffer()) {
                bool requireWhitespace = false;
                foreach (string str in expectedTokens) {
                    if (requireWhitespace) {
                        // After the first token, at least one whitespace character must be seen for us to accept the sequence
                        if (!Char.IsWhiteSpace(CurrentCharacter)) {
                            return false;
                        }
                    }
                    // Accept whitespace, but not newlines unless prefixed by "_"
                    AcceptWhitespaceWithVBNewlines();
                    if (!Context.Accept(str, caseSensitive)) {
                        Context.RejectTemporaryBuffer();
                        return false;
                    }
                    requireWhitespace = true;
                }
                if (!EndOfFile && !Char.IsWhiteSpace(CurrentCharacter)) {
                    // The last token was just part of a larger token, so disregard it
                    Context.RejectTemporaryBuffer();
                    return false;
                }
                Context.AcceptTemporaryBuffer();
            }
            return true;
        }
    }
}
