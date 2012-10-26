using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.AbstractDb
{
    public class DialectBase : ISqlDialect
    {
        HashSetEx<string> m_possibleKeywords;
        HashSetEx<string> m_noContextReservedWords;

        public HashSetEx<string> PossibleKeywords
        {
            get
            {
                if (m_possibleKeywords == null) m_possibleKeywords = LoadPossibleKeywords();
                return m_possibleKeywords;
            }
        }

        public HashSetEx<string> NoContextReservedWords
        {
            get
            {
                if (m_noContextReservedWords == null) m_noContextReservedWords = LoadNoContextReservedWords();
                return m_noContextReservedWords;
            }
        }

        protected virtual HashSetEx<string> LoadNoContextReservedWords()
        {
            var res = new HashSetEx<string>();
            res.Add("SELECT"); res.Add("CREATE"); res.Add("UPDATE"); res.Add("DELETE");
            res.Add("DROP"); res.Add("ALTER"); res.Add("TABLE"); res.Add("VIEW");
            res.Add("FROM"); res.Add("WHERE"); res.Add("GROUP"); res.Add("ORDER"); res.Add("BY");
            res.Add("ASC"); res.Add("DESC"); res.Add("HAVING"); res.Add("INTO"); res.Add("ASC");
            res.Add("LEFT"); res.Add("RIGHT"); res.Add("INNER"); res.Add("OUTER");
            res.Add("CROSS"); res.Add("NATURAL"); res.Add("JOIN"); res.Add("ON");
            res.Add("DISTINCT"); res.Add("ALL"); res.Add("ANY");
            return res;
        }

        protected virtual HashSetEx<string> LoadPossibleKeywords()
        {
            var res = new HashSetEx<string>();
            //res.AddRange(from k in CoreRes.keywords.Split('\n') where k != "" select k.ToUpper().Trim());
            return res;
        }


        /// <summary>
        /// how ' character is quoted in string
        /// </summary>
        public virtual char StringEscapeChar
        {
            get { return '\\'; }
        }

        /// <summary>
        /// begin of quoted identifier
        /// </summary>
        public virtual char QuoteIdentBegin
        {
            get { return '"'; }
        }

        /// <summary>
        /// end of quoted identifier
        /// </summary>
        public virtual char QuoteIdentEnd
        {
            get { return '"'; }
        }

        public virtual string QuoteIdentifier(string ident)
        {
            //if (ident.IndexOf('.') >= 0) return ident;
            if (QuoteIdentBegin != '\0' && QuoteIdentEnd != '\0') return QuoteIdentBegin + ident + QuoteIdentEnd;
            return ident;
        }

        public virtual string UnquoteName(string name)
        {
            int dstart = 0, dend = 0;
            if (QuoteIdentBegin != '\0' && name.Length > 0 && name[0] == QuoteIdentBegin) dstart = 1;
            if (QuoteIdentEnd != '\0' && name.Length > dstart && name[name.Length - 1] == QuoteIdentEnd) dend = 1;
            if (dstart > 0 || dend > 0) return name.Substring(dstart, name.Length - dstart - dend);
            return name;
        }
    }
}