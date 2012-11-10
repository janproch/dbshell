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
                string lineTrimmed = line.Trim();
                if (String.Compare(lineTrimmed, "GO", true) == 0)
                {
                    string res = buf.ToString();
                    if (res.Trim() != "") yield return new SplitQueryItem {Data = res, StartLine = startLine};
                    buf = new StringBuilder();
                    startLine = curline + 1;
                    continue;
                }
                buf.Append(line + "\n");
            }
            string res2 = buf.ToString();
            if (res2.Trim() != "") yield return new SplitQueryItem { Data = res2, StartLine = startLine };
        }
    }

}
