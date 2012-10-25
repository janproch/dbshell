using System;
using System.Globalization;
using System.Text;

namespace DbShell.Driver.Common.CommonDataLayer
{
    internal static class DateTimeExFormat
    {
        private static string[] fixedNumberFormats = new string[] { "0", "00", "000", "0000", "00000", "000000", "0000000" };

        internal static string FormatCustomized(DateTimeEx dateTime, string format, DateTimeFormatInfo dtfi)
        {
            int num2;
            StringBuilder outputBuffer = new StringBuilder();
            for (int i = 0; i < format.Length; i += num2)
            {
                char patternChar = format[i];
                switch (patternChar)
                {
                    case 'F':
                    case 'f':
                        {
                            num2 = ParseRepeatPattern(format, i, patternChar);
                            if (num2 > 7)
                            {
                                throw new FormatException("DBSH-00000 Bad format");
                            }
                            long num5 = dateTime.Nanosecond / 100;
                            num5 /= (long)Math.Pow(10.0, (double)(7 - num2));
                            outputBuffer.Append(((int)num5).ToString(fixedNumberFormats[num2 - 1], CultureInfo.InvariantCulture));
                            break;
                        }
                    case 'H':
                        {
                            num2 = ParseRepeatPattern(format, i, patternChar);
                            FormatDigits(outputBuffer, dateTime.Hour, num2);
                            break;
                        }
                    case ':':
                        {
                            outputBuffer.Append(dtfi.TimeSeparator);
                            num2 = 1;
                            break;
                        }
                    case '/':
                        {
                            outputBuffer.Append(dtfi.DateSeparator);
                            num2 = 1;
                            break;
                        }
                    case '\'':
                    case '"':
                        {
                            StringBuilder result = new StringBuilder();
                            num2 = ParseQuoteString(format, i, result);
                            outputBuffer.Append(result);
                            break;
                        }
                    case 'M':
                        {
                            num2 = ParseRepeatPattern(format, i, patternChar);
                            int month = dateTime.Month;
                            FormatDigits(outputBuffer, month, num2);
                            break;
                        }

                    case '\\':
                        {
                            int ch = ParseNextChar(format, i);
                            if (ch < 0)
                            {
                                throw new FormatException("DBSH-00000 Invalid format");
                            }
                            outputBuffer.Append((char)ch);
                            num2 = 2;
                            break;
                        }
                    case 'd':
                        {
                            num2 = ParseRepeatPattern(format, i, patternChar);
                            int dayOfMonth = dateTime.Day;
                            FormatDigits(outputBuffer, dayOfMonth, num2);
                            break;
                        }
                    case 'g':
                        {
                            num2 = ParseRepeatPattern(format, i, patternChar);
                            outputBuffer.Append(dateTime.Year >= 0 ? "A.D" : "B.C");
                            break;
                        }
                    case 'h':
                        {
                            num2 = ParseRepeatPattern(format, i, patternChar);
                            int num3 = dateTime.Hour % 12;
                            if (num3 == 0)
                            {
                                num3 = 12;
                            }
                            FormatDigits(outputBuffer, num3, num2);
                            break;
                        }
                    case 's':
                        {
                            num2 = ParseRepeatPattern(format, i, patternChar);
                            FormatDigits(outputBuffer, dateTime.Second, num2);
                            break;
                        }
                    case 'm':
                        {
                            num2 = ParseRepeatPattern(format, i, patternChar);
                            FormatDigits(outputBuffer, dateTime.Minute, num2);
                            break;
                        }
                    case 'y':
                        {
                            int year = dateTime.Year;
                            num2 = ParseRepeatPattern(format, i, patternChar);
                            if (num2 == 2) FormatDigits(outputBuffer, year % 100, 2);
                            if (num2 == 3) FormatDigits(outputBuffer, year % 1000, 3);
                            if (num2 == 4) FormatDigits(outputBuffer, year, 4);
                            break;
                        }
                    default:
                        outputBuffer.Append(patternChar);
                        num2 = 1;
                        break;
                }
            }
            return outputBuffer.ToString();
        }

        private static void FormatDigits(StringBuilder outputBuffer, int number, int len)
        {
            string res = number.ToString(fixedNumberFormats[len - 1]);
            outputBuffer.Append(res);
        }
        internal static int ParseNextChar(string format, int pos)
        {
            if (pos >= (format.Length - 1))
            {
                return -1;
            }
            return format[pos + 1];
        }

        internal static int ParseQuoteString(string format, int pos, StringBuilder result)
        {
            int length = format.Length;
            int num2 = pos;
            char ch = format[pos++];
            bool flag = false;
            while (pos < length)
            {
                char ch2 = format[pos++];
                if (ch2 == ch)
                {
                    flag = true;
                    break;
                }
                if (ch2 == '\\')
                {
                    if (pos >= length)
                    {
                        throw new FormatException("DBSH-00000 Invalid format");
                    }
                    result.Append(format[pos++]);
                }
                else
                {
                    result.Append(ch2);
                }
            }
            if (!flag)
            {
                throw new FormatException("DBSH-00000 Format_BadQuote:" + ch);
            }
            return (pos - num2);
        }

        internal static int ParseRepeatPattern(string format, int pos, char patternChar)
        {
            int length = format.Length;
            int num2 = pos + 1;
            while ((num2 < length) && (format[num2] == patternChar))
            {
                num2++;
            }
            return (num2 - pos);
        }
    }
}

