using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using DbShell.Driver.Common.AbstractDb;

namespace DbShell.Driver.Common.Utility
{
    public static class SqlEditorInfoTool
    {
        public static void PutEditorInfo(ISqlDumper dmp, string editorInfo)
        {
            if (editorInfo == null) return;
            dmp.Put("&n-- *** EDITOR-INFO-BEGIN ***&n");
            foreach (var line in editorInfo.Split('\n'))
            {
                dmp.Put("-- %s&n", line.TrimEnd());
            }
            dmp.Put("-- *** EDITOR-INFO-END ***&n");
        }

        public static string FormatEditorInfo(string editorInfo)
        {
            if (editorInfo == null) return "";
            var sb = new StringBuilder();
            sb.Append("\n-- *** EDITOR-INFO-BEGIN ***\n");
            foreach (var line in editorInfo.Split('\n'))
            {
                sb.AppendFormat("-- {0}\n", line.TrimEnd());
            }
            sb.Append("-- *** EDITOR-INFO-END ***\n");
            return sb.ToString();
        }

        public static string ExtractEditorInfo(string sql)
        {
            if (sql == null) return null;
            if (!sql.Contains("*** EDITOR-INFO-BEGIN ***")) return null;
            var lines = sql.Split('\n').Select(x => x.TrimEnd()).ToList();
            int beginIndex = lines.IndexOfIf(x => x.Contains("-- *** EDITOR-INFO-BEGIN ***"));
            int endIndex = lines.IndexOfIf(x => x.Contains("-- *** EDITOR-INFO-END ***"));
            if (beginIndex>=0 && endIndex >= 0)
            {
                var sb = new StringBuilder();
                for(int i = beginIndex + 1; i < endIndex; i++)
                {
                    string line = lines[i];
                    if (line.StartsWith("-- ")) sb.Append(line.Substring(3) + "\n");
                }
                return sb.ToString();
            }
            return null;
        }
    }
}
