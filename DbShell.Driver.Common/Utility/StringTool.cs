using System;
using System.Collections.Generic;
using System.Text;
using System.Web;

namespace DbShell.Driver.Common.Utility
{
    public static class StringTool
    {
        static string[] HEXCHARS = new string[] { "0", "1", "2", "3", "4", "5", "6", "7", "8", "9", "A", "B", "C", "D", "E", "F" };

        public static sbyte DecodeHex(char c)
        {
            if (c >= '0' && c <= '9') return (sbyte)(c - '0');
            if (c >= 'a' && c <= 'f') return (sbyte)(c - 'a' + 10);
            if (c >= 'A' && c <= 'F') return (sbyte)(c - 'A' + 10);
            return -1;
        }

        public static string EncodeHex(byte value)
        {
            return HEXCHARS[value / 16] + HEXCHARS[value % 16];
        }

        public static void EncodeHex(byte value, StringBuilder sb)
        {
            sb.Append(HEXCHARS[value / 16]);
            sb.Append(HEXCHARS[value % 16]);
        }

        public static void EncodeOct(byte value, StringBuilder sb)
        {
            sb.Append(HEXCHARS[value / 64]); value %= 64;
            sb.Append(HEXCHARS[value / 8]); value %= 8;
            sb.Append(HEXCHARS[value]);
        }

        public static void EncodeHex(byte[] data, StringBuilder sb)
        {
            foreach (byte b in data)
            {
                EncodeHex(b, sb);
            }
        }

        public static string EncodeHex(byte[] data, int linewi)
        {
            StringBuilder sb = new StringBuilder();
            int bytesonline = 0;
            foreach (byte b in data)
            {
                sb.Append(EncodeHex(b));
                bytesonline++;
                if (bytesonline >= linewi)
                {
                    sb.Append("\n");
                    bytesonline = 0;
                }
                else
                {
                    sb.Append(" ");
                }
            }
            if (bytesonline > 0) sb.Append("\n");
            return sb.ToString();
        }

        public static string EncodeHex(byte[] data)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in data)
            {
                EncodeHex(b, sb);
            }
            return sb.ToString();
        }

        public static string EncodeOct(byte[] data, string prefix)
        {
            StringBuilder sb = new StringBuilder();
            foreach (byte b in data)
            {
                sb.Append(prefix);
                EncodeOct(b, sb);
            }
            return sb.ToString();
        }

        public static string EncodeHex(object o, int linewi)
        {
            if (o is byte[]) return EncodeHex((byte[])o, linewi);
            return "???";
        }

        public static string EncodeHexNice(object o, int linewi)
        {
            if (o is byte[]) return EncodeHexNice((byte[])o, linewi);
            return "???";
        }

        public static string EncodeConnectionString(Dictionary<string, string> pars)
        {
            StringBuilder res = new StringBuilder();
            bool was = false;
            foreach (string par in pars.Keys)
            {
                if (was) res.Append(";");
                res.Append(par);
                res.Append('"');
                string val = pars[par];
                if (val.Contains(";") || val.Contains("=") || val.Contains("'") || val.Contains("\""))
                {
                    res.Append('"');
                    foreach (char ch in val)
                    {
                        if (ch == '"') res.Append('"');
                        res.Append(ch);
                    }
                    res.Append('"');
                }
                else
                {
                    res.Append(val);
                }
                was = true;
            }
            return res.ToString();
        }

        public static Dictionary<string, string> DecodeConnectionString(string s)
        {
            int i = 0;
            Dictionary<string, string> res = new Dictionary<string, string>();
            while (i < s.Length)
            {
                StringBuilder name = new StringBuilder();
                while (i < s.Length && s[i] != '=')
                {
                    name.Append(s[i]);
                    i++;
                }
                if (i < s.Length) i++;
                StringBuilder val = new StringBuilder();
                if (i < s.Length)
                {
                    if (s[i] == '"' || s[i] == '\'')
                    {
                        char beg = s[i];
                        i++;
                        while (i < s.Length)
                        {
                            if (s[i] == beg)
                            {
                                if (i + i < s.Length && s[i + 1] == beg)
                                {
                                    val.Append(beg);
                                    i += 2;
                                }
                                else
                                {
                                    break;
                                }
                            }
                            else
                            {
                                val.Append(s[i]);
                                i++;
                            }
                        }
                        if (i < s.Length) i++; // end quote mark
                    }
                    else
                    {
                        while (i < s.Length && s[i] != ';')
                        {
                            val.Append(s[i]);
                            i++;
                        }
                    }
                    if (i < s.Length && s[i] == ';') i++;
                }
                res[name.ToString()] = val.ToString();
            }
            return res;
        }

        public static string Reverse(string str)
        {
            int len = str.Length;
            char[] arr = new char[len];

            for (int i = 0; i < len; i++)
            {
                arr[i] = str[len - 1 - i];
            }

            return new String(arr);
        }

        public static string UrlEncode(Dictionary<string, string> pars, Encoding e)
        {
            StringBuilder sb = new StringBuilder();
            bool was = false;
            foreach (string k in pars.Keys)
            {
                if (was) sb.Append('&');
                sb.Append(k);
                sb.Append('=');
                sb.Append(HttpUtility.UrlEncode(pars[k], e));
                was = true;
            }
            return sb.ToString();
        }

        public static string UrlEncode(Dictionary<string, byte[]> pars)
        {
            StringBuilder sb = new StringBuilder();
            bool was = false;
            foreach (string k in pars.Keys)
            {
                if (was) sb.Append('&');
                sb.Append(k);
                sb.Append('=');
                sb.Append(HttpUtility.UrlEncode(pars[k]));
                was = true;
            }
            return sb.ToString();
        }

        public static string UTF8ArrayToString(byte[] b)
        {
            if (b.Length >= 3 && b[0] == 239 && b[1] == 187 && b[2] == 191) // UTF-8 chars
            {
                b = PyList.SliceFrom(b, 3);
            }
            return Encoding.UTF8.GetString(b);
        }

        public static bool IsEmpty(this string s)
        {
            if (s == null) return true;
            if (s.Trim() == "") return true;
            return false;
        }

        public static int? ParseNullableInt(string value)
        {
            if (value == null) return null;
            int res;
            if (Int32.TryParse(value, out res)) return res;
            return null;
        }

        public static bool? ParseNullableBool(string value)
        {
            if (value == null) return null;
            if (value == "1") return true;
            if (value == "0") return false;
            return null;
        }

        public static int ParseIntStart(string value)
        {
            int res = 0;
            int pos = 0;
            while (pos < value.Length && Char.IsDigit(value, pos))
            {
                res *= 10;
                res += (value[pos] - '0');
                pos++;
            }
            return res;
        }

        public static string ReplaceCEscapes(this string value)
        {
            if (value == null) return null;
            return value
                .Replace("\\n", "\n")
                .Replace("\\r", "\r")
                .Replace("\\t", "\t")
                .Replace("\\\\", "\\");
        }

        public static string Capitalize(this string value)
        {
            if (value==null) return null;
            if (value.Length<=1) return value.ToUpper();
            return Char.ToUpper(value[0]) + value.Substring(1).ToLower();
        }
        /// <summary>
        /// creates string GoHomePlease from go_home_please
        /// </summary>
        /// <param name="value"></param>
        /// <returns></returns>
        public static string CapitalizeUnderscored(this string value)
        {
            if (value == null) return null;
            StringBuilder sb = new StringBuilder(value.Length);
            bool iscap = true;
            foreach (char ch in value)
            {
                if (ch == '_')
                {
                    iscap = true;
                }
                else
                {
                    if (iscap) sb.Append(Char.ToUpper(ch));
                    else sb.Append(Char.ToLower(ch));
                    iscap = false;
                }
            }
            return sb.ToString();
        }

        public static string TrimRightNice(this string value, int length)
        {
            if (value.Length <= length) return value;
            return value.Substring(0, length) + "...";
        }

        public static string EncodeHexNice(byte[] data, int linewi)
        {
            StringBuilder sb = new StringBuilder();
            int bytesonline = 0;
            int offset = 0;
            StringBuilder ascii = new StringBuilder();
            foreach (byte b in data)
            {
                if (bytesonline == 0)
                {
                    // start line
                    sb.Append(offset.ToString("X8") + ": ");
                }
                sb.Append(EncodeHex(b));
                if (b>=32 && b < 128) ascii.Append((char)b); 
                else ascii.Append("?");
                offset++;
                bytesonline++;
                if (bytesonline >= linewi)
                {
                    sb.Append(" | " + ascii.ToString());
                    ascii = new StringBuilder();
                    sb.Append("\n");
                    bytesonline = 0;
                }
                else
                {
                    if (bytesonline == linewi / 2) sb.Append("|");
                    else sb.Append(" ");
                }
            }
            if (bytesonline > 0)
            {
                while (bytesonline < linewi)
                {
                    sb.Append("   ");
                    bytesonline++;
                }
                sb.Append(" | " + ascii.ToString());
                sb.Append("\n");
            }
            return sb.ToString();
        }

        public static int? SafeNIntParse(this string value)
        {
            int res;
            if (Int32.TryParse(value ?? "", out res)) return res;
            return null;
        }

        public static int SafeIntParse(this string value)
        {
            int res;
            if (Int32.TryParse(value ?? "", out res)) return res;
            return 0;
        }

        public static int SafeIntParse(this string value, int defvalue)
        {
            int res;
            if (Int32.TryParse(value ?? "", out res)) return res;
            return defvalue;
        }

        public static string FormatInt(this int value)
        {
            if (value == 0) return "0";
            return value.ToString("#,#");
        }
    }
}
