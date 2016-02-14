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
    public class StructuredIdentifier : IFormattable, IComparable
    {
        private List<string> _nameItems = new List<string>();

        public ReadOnlyCollection<string> NameItems
        {
            get { return _nameItems.AsReadOnly(); }
        }

        public StructuredIdentifier()
        {

        }

        public StructuredIdentifier(string name)
        {
            _nameItems.Add(name);
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

        public StructuredIdentifier(IEnumerable<string> source)
        {
            _nameItems.AddRange(source);
        }

        public static StructuredIdentifier Parse(string s)
        {
            if (s == null) return null;
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
            return name.Any(x => !Char.IsLetterOrDigit(x) && x != '_');
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

        public NameWithSchema ToNameWithSchema()
        {
            if (Count == 2) return new NameWithSchema(this[0], this[1]);
            if (Count == 1) return new NameWithSchema(this[0]);
            return null;
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

        public override int GetHashCode()
        {
            return ToString().GetHashCode();
        }

        public int CompareTo(object obj)
        {
            return System.String.Compare(ToString(), (obj != null ? obj.ToString() : ""), System.StringComparison.Ordinal);
        }

        public override bool Equals(object obj)
        {
            if (ReferenceEquals(obj, null)) return false;
            return ToString() == obj.ToString();
        }

        public static bool operator ==(StructuredIdentifier a, StructuredIdentifier b)
        {
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return ReferenceEquals(a, b);
            return a.ToString() == b.ToString();
        }

        public static bool operator !=(StructuredIdentifier a, StructuredIdentifier b)
        {
            if (ReferenceEquals(a, null) || ReferenceEquals(b, null)) return !ReferenceEquals(a, b);
            return !(a == b);
        }
    }
}
