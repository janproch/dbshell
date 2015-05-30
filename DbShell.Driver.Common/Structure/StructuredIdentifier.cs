using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Globalization;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.Utility;

namespace DbShell.Driver.Common.Structure
{
    /// <summary>
    /// class to hold values like [dbo].[t1].[xxxx]
    /// similar to ObjectPath
    /// </summary>
    public class StructuredIdentifier : IFormattable
    {
        private List<string> _nameItems = new List<string>();

        public ReadOnlyCollection<string> NameItems
        {
            get { return _nameItems.AsReadOnly(); }
        }

        public StructuredIdentifier()
        {

        }

        public StructuredIdentifier(StructuredIdentifier a, string b)
        {
            _nameItems.AddRange(a._nameItems);
            _nameItems.Add(b);
        }

        public StructuredIdentifier(string a, StructuredIdentifier b)
        {
            _nameItems.Add(a);
            _nameItems.AddRange(b._nameItems);
        }

        public StructuredIdentifier(StructuredIdentifier a, StructuredIdentifier b)
        {
            _nameItems.AddRange(a._nameItems);
            _nameItems.AddRange(b._nameItems);
        }

        public StructuredIdentifier(List<string> source, int index, int count)
        {
            for (int i = index; i < index + count; i++)
            {
                _nameItems.Add(source[i]);
            }
        }

        public static StructuredIdentifier Parse(string s)
        {
            var res = new StructuredIdentifier();
            int pos = 0;
            var currentSb = new StringBuilder();
            bool isQuoted = false;
            while (pos < s.Length)
            {
                char ch = s[pos];
                if (ch == '[' && !isQuoted)
                {
                    isQuoted = true;
                    pos++;
                    continue;
                }
                if (ch == ']' && isQuoted)
                {
                    isQuoted = false;
                    pos++;
                    continue;
                }
                if (isQuoted)
                {
                    currentSb.Append(ch);
                    pos++;
                    continue;
                }
                if (ch == '.')
                {
                    res._nameItems.Add(currentSb.ToString());
                    currentSb.Clear();
                    pos++;
                    continue;
                }
                currentSb.Append(ch);
                pos++;
            }
            if (currentSb.Length > 0)
            {
                res._nameItems.Add(currentSb.ToString());
            }
            return res;
        }

        private static string QuoteNameIfNecessary(string name)
        {
            if (MustBeQuoted(name)) return "[" + name + "]";
            return name;
        }

        private static bool MustBeQuoted(string name)
        {
            return !name.All(Char.IsLetterOrDigit);
        }

        public string ToString(string format, IFormatProvider formatProvider)
        {
            switch (format)
            {
                case "S":
                    if (_nameItems.Any()) return _nameItems.Last();
                    return "";
                case "L":
                case "M":
                default:
                    return _nameItems.Select(QuoteNameIfNecessary).CreateDelimitedText(".");
            }
        }

        public override string ToString()
        {
            return ToString("L", CultureInfo.InvariantCulture);
        }

        public int Count
        {
            get { return _nameItems.Count; }
        }

        public string this[int index]
        {
            get { return _nameItems[index]; }
        }

        public bool IsEmpty
        {
            get { return !_nameItems.Any(); }
        }

        public string First
        {
            get { return _nameItems.FirstOrDefault(); }
        }

        public string Last
        {
            get { return _nameItems.LastOrDefault(); }
        }

        public StructuredIdentifier WithoutLast
        {
            get
            {
                if (Count <= 1) return new StructuredIdentifier();
                return new StructuredIdentifier(_nameItems, 0, _nameItems.Count - 1);
            }
        }

        public StructuredIdentifier WithoutFirst
        {
            get
            {
                if (Count <= 1) return new StructuredIdentifier();
                return new StructuredIdentifier(_nameItems, 1, _nameItems.Count - 1);
            }
        }

        public static StructuredIdentifier operator /(StructuredIdentifier a, string b)
        {
            return new StructuredIdentifier(a, b);
        }

        public static StructuredIdentifier operator /(string a, StructuredIdentifier b)
        {
            return new StructuredIdentifier(a, b);
        }

        public static StructuredIdentifier operator /(StructuredIdentifier a, StructuredIdentifier b)
        {
            return new StructuredIdentifier(a, b);
        }
    }
}
