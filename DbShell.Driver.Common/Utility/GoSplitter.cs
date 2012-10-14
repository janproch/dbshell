using System;
using System.Collections.Generic;
using System.Text;
using System.IO;

namespace DbShell.Driver.Common.Utility
{
    public struct SplitQueryItem
    {
        public string Data;
        public string Delimiter;
        public int StartLine;
        public int Length
        {
            get
            {
                int res = 0;
                if (Data != null) res += Data.Length;
                if (Delimiter != null) res += Delimiter.Length;
                return res;
            }
        }
        public override string ToString()
        {
            return Data;
        }
        public static implicit operator string(SplitQueryItem value)
        {
            return value.Data;
        }
    }

    public static class GoSplitter
    {
        public static IEnumerable<SplitQueryItem> GoSplit(string sql)
        {
            return GoSplit(new StringReader(sql));
        }

        public static IEnumerable<SplitQueryItem> GoSplit(TextReader reader)
        {
            StringBuilder buf = new StringBuilder();
            int curline = -1;
            int startLine = 0;
            for (; ; )
            {
                string line = reader.ReadLine();
                curline++;
                if (line == null) break;
                if (line.StartsWith("GO", StringComparison.InvariantCultureIgnoreCase))
                {
                    if (line.Length == 2 || Char.IsWhiteSpace(line[2]) || Char.IsSymbol(line[2]))
                    {
                        string res = buf.ToString();
                        if (res.Trim() != "") yield return new SplitQueryItem { Data = res, StartLine = startLine };
                        buf = new StringBuilder();
                        startLine = curline + 1;
                        continue;
                    }
                }
                buf.Append(line + "\n");
            }
            string res2 = buf.ToString();
            if (res2.Trim() != "") yield return new SplitQueryItem { Data = res2, StartLine = startLine };
        }

        public static bool IsSimpleSelect(string query)
        {
            //return false;
            query = query.ToUpper().Trim();
            if (!query.StartsWith("SELECT")) return false;
            if (!query.Contains("FROM")) return false;
            if (query.IndexOf("SELECT", 1) >= 0) return false;
            if (query.IndexOf("UPDATE") >= 0) return false;
            if (query.IndexOf("INSERT") >= 0) return false;
            if (query.IndexOf("DELETE") >= 0) return false;
            if (query.IndexOf("\nGO") >= 0) return false;
            return true;
        }

        //public static string GetBaseTableName(string query)
        //{
        //    Match m = Regex.Match(query, "from\\s+[\\[\\\"\\`]?([a-zA-Z0-9_]+)", RegexOptions.IgnoreCase);
        //    if (m.Success) return m.Groups[1].Value;
        //    return null;
        //}
    }

}
