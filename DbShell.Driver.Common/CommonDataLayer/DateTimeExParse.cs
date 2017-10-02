using System;
using System.Text;
using System.Globalization;

namespace DbShell.Driver.Common.CommonDataLayer
{
    internal static class DateTimeExParse
    {
        public static DateTimeEx ParseCustomized(string value, string format, DateTimeFormatInfo dtfi)
        {
            var lexer = new DateTimeLexer(value);
            DateTimeEx res = new DateTimeEx();

            int num2;
            bool isbc = false;
            for (int i = 0; i < format.Length; i += num2)
            {
                char patternChar = format[i];
                switch (patternChar)
                {
                    case 'F':
                    case 'f':
                        {
                            num2 = DateTimeExFormat.ParseRepeatPattern(format, i, patternChar);
                            if (num2 > 7)
                            {
                                throw new FormatException("DBSH-00039 Bad format");
                            }
                            int parsed = lexer.ReadNumber(num2);
                            res.Nanosecond = (int)Math.Pow(10.0, (double)(7 - num2)) * 100 * parsed;
                            break;
                        }
                    case 'H':
                        {
                            num2 = DateTimeExFormat.ParseRepeatPattern(format, i, patternChar);
                            res.Hour = lexer.ReadNumber(num2);
                            break;
                        }
#if !NETSTANDARD2_0

                    case ':':
                        {
                            lexer.Skip(dtfi.TimeSeparator);
                            num2 = 1;
                            break;
                        }
                    case '/':
                        {
                            lexer.Skip(dtfi.DateSeparator);
                            num2 = 1;
                            break;
                        }
#endif
                    case '\'':
                    case '"':
                        {
                            StringBuilder result = new StringBuilder();
                            num2 = DateTimeExFormat.ParseQuoteString(format, i, result);
                            lexer.Skip(result.ToString());
                            break;
                        }
                    case 'M':
                        {
                            num2 = DateTimeExFormat.ParseRepeatPattern(format, i, patternChar);
                            res.Month = lexer.ReadNumber(num2);
                            break;
                        }

                    case '\\':
                        {
                            int ch = DateTimeExFormat.ParseNextChar(format, i);
                            if (ch < 0)
                            {
                                throw new FormatException("DBSH-00040 Invalid format");
                            }
                            lexer.Skip((char)ch);
                            num2 = 2;
                            break;
                        }
                    case 'd':
                        {
                            num2 = DateTimeExFormat.ParseRepeatPattern(format, i, patternChar);
                            res.Day = lexer.ReadNumber(num2);
                            break;
                        }
                    case 'g':
                        {
                            num2 = DateTimeExFormat.ParseRepeatPattern(format, i, patternChar);
                            if (lexer.Skip("A.D")) { }
                            else if (lexer.Skip("B.C")) { isbc = true; }
                            break;
                        }
                    case 'h':
                        {
                            num2 = DateTimeExFormat.ParseRepeatPattern(format, i, patternChar);
                            res.Hour = lexer.ReadNumber(num2);
                            break;
                        }
                    case 's':
                        {
                            num2 = DateTimeExFormat.ParseRepeatPattern(format, i, patternChar);
                            res.Second = lexer.ReadNumber(num2);
                            break;
                        }
                    case 'm':
                        {
                            num2 = DateTimeExFormat.ParseRepeatPattern(format, i, patternChar);
                            res.Minute = lexer.ReadNumber(num2);
                            break;
                        }
                    case 'y':
                        {
                            num2 = DateTimeExFormat.ParseRepeatPattern(format, i, patternChar);
                            if (num2 == 2)
                            {
                                int num3=lexer.ReadNumber(2);
                                if (num3 < 69) res.Year = 2000 + num3;
                                else res.Year = 1900 + num3;
                            }
                            if (num2 == 3)
                            {
                                int num3 = lexer.ReadNumber(2);
                                if (num3 < 500) res.Year = 2000 + num3;
                                else res.Year = 1000 + num3;
                            }
                            if (num2 >= 4) res.Year = lexer.ReadNumber(num2);
                            break;
                        }
                    default:
                        {
                            lexer.Skip(patternChar);
                            num2 = 1;
                            break;
                        }
                }
            }
            if (isbc) res.Year = -res.Year;
            return res;
        }
    }

    internal class DateTimeLexer
    {
        string m_text;
        int m_pos;
        bool m_ignoreWS = true;

        internal DateTimeLexer(string text)
        {
            m_text = text;
        }

        internal void SkipWhites()
        {
            if (!m_ignoreWS) return;
            while (m_pos < m_text.Length && Char.IsWhiteSpace(m_text, m_pos)) m_pos++;
        }

        internal int ReadNumber(int maxlen)
        {
            SkipWhites();
            int res = 0;
            while (m_pos < m_text.Length && Char.IsDigit(m_text, m_pos) && maxlen > 0)
            {
                res *= 10;
                res += m_text[m_pos] - '0';
                m_pos++;
                maxlen--;
            }
            return res;
        }

        internal bool Skip(string text)
        {
            SkipWhites();
            foreach (char c in text)
            {
                if (m_ignoreWS && Char.IsWhiteSpace(c)) continue;
                if (m_pos < m_text.Length && c == m_text[m_pos])
                {
                    m_pos++;
                }
                else
                {
                    return false;
                }
            }
            return true;
        }

        internal bool Skip(char ch)
        {
            SkipWhites();
            if (m_pos < m_text.Length && ch == m_text[m_pos])
            {
                m_pos++;
                return true;
            }
            return false;
        }

    }
}
