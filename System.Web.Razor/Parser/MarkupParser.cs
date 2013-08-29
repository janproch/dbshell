
namespace System.Web.Razor.Parser {
    public abstract class MarkupParser : ParserBase {
        protected override ParserBase OtherParser {
            get { return Context.CodeParser; }
        }

        // Markup Parsers need the ParseDocument method since the markup parser is the first parser to hit the document 
        // and the logic may be different than the ParseBlock method.
        public abstract void ParseDocument();
        public abstract void ParseSection(Tuple<string, string> nestingSequences, bool caseSensitive);
        public abstract bool IsStartTag();
        public abstract bool IsEndTag();
    }
}
