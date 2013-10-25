using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using DbShell.Core.RazorModels;

namespace DbShell.Core.Utility
{
    public class SqlProlog
    {
        public class CommandItem
        {
            public string Command;
            public int LineIndex;
            public List<string> Arguments = new List<string>();

            public bool IsCommand(string cmd)
            {
                return System.String.Compare(cmd, Command, System.StringComparison.OrdinalIgnoreCase) == 0;
            }

            public char? RazorChar
            {
                get
                {
                    if (Command.StartsWith("razor", StringComparison.OrdinalIgnoreCase) && Command.Length == 6)
                    {
                        return Command[5];
                    }
                    if (String.Compare("razor", Command, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        return '\0';
                    }
                    return null;
                }
            }

            public bool IsView
            {
                get { return IsCommand("view"); }
            }

            public bool IsRazor
            {
                get
                {
                    char? ch = RazorChar;
                    return ch.HasValue && (ch == '\0' || ch == '#');
                }
            }

            public string Transformation
            {
                get
                {
                    if (Command.StartsWith("razor")) return Command;
                    return null;
                }
            }
        }

        public List<CommandItem> Commands = new List<CommandItem>();

        private class Parser
        {
            private int _index;
            private string _s;

            internal Parser(string s)
            {
                _s = s;
            }

            internal bool IsEof
            {
                get { return _index >= _s.Length; }
            }

            internal void Skip(int count)
            {
                _index += count;
                if (IsEof) _index = _s.Length;
            }

            internal void JumpWhite()
            {
                while (!IsEof && Char.IsWhiteSpace(Current))
                {
                    _index++;
                }
            }

            internal char Current
            {
                get
                {
                    if (IsEof) return '\0';
                    return _s[_index];
                }
            }

            internal char Next
            {
                get
                {
                    if (_index >= _s.Length - 1) return '\0';
                    return _s[_index + 1];
                }
            }

            internal string ReadToken()
            {
                JumpWhite();

                if (IsEof) return null;

                var sb = new StringBuilder();

                if (Current == '\"')
                {
                    Skip(1);
                    while (!IsEof && Current != '\"')
                    {
                        sb.Append(Current);
                        Skip(1);
                    }
                    if (Current == '\"') Skip(1);
                }
                else
                {
                    while (!IsEof && !Char.IsWhiteSpace(Current))
                    {
                        sb.Append(Current);
                        Skip(1);
                    }
                }
                return sb.ToString();
            }
        }

        public int LineCount;

        public SqlProlog(string content)
            : this(new StringReader(content ?? String.Empty))
        {

        }

        public SqlProlog(TextReader reader)
        {
            int emptyLines = 0;
            for (;;)
            {
                string line = reader.ReadLine();
                if (line == null) return;
                line = line.Trim();
                if (String.IsNullOrEmpty(line))
                {
                    LineCount++;
                    emptyLines++;
                    continue;
                }

                var parser = new Parser(line);
                if (parser.Current != '-' || parser.Next != '-')
                {
                    LineCount -= emptyLines;
                    return;
                }
                var item = ParseLine(parser, ref emptyLines);
                if (item == null) continue;
                Commands.Add(item);
            }
        }

        private CommandItem ParseLine(string line)
        {
            int emptyLines = 0;
            var parser = new Parser(line.Trim());
            return ParseLine(parser, ref emptyLines);
        }

        private CommandItem ParseLine(Parser parser, ref int emptyLines)
        {
            if (parser.Current != '-' || parser.Next != '-')
            {
                return null;
            }
            parser.Skip(2);
            parser.JumpWhite();
            if (parser.Current != '#')
            {
                // comment but not prolog comment
                LineCount++;
                return null;
            }

            emptyLines = 0;
            LineCount++;

            parser.Skip(1);
            string command = parser.ReadToken();
            if (command == null) return null;
            var item = new CommandItem
                {
                    LineIndex = LineCount - 1,
                    Command = command,
                };
            Commands.Add(item);
            while (!parser.IsEof)
            {
                string token = parser.ReadToken();
                if (token == null) break;
                item.Arguments.Add(token);
            }
            return item;
        }

        public string Replace(string content, Func<CommandItem, bool> removeItem, string newItem)
        {
            var reader = new StringReader(content);
            var prologLines = new List<string>();
            for (int i = 0; i < LineCount; i++)
            {
                prologLines.Add(reader.ReadLine().TrimEnd());
            }
            string append = reader.ReadToEnd();
            bool shouldAddNewItem = newItem != null;
            foreach (var cmd in Commands.OrderByDescending(c => c.LineIndex))
            {
                if (removeItem(cmd))
                {
                    prologLines.RemoveAt(cmd.LineIndex);
                    if (shouldAddNewItem)
                    {
                        shouldAddNewItem = false;
                        prologLines.Insert(cmd.LineIndex, newItem);
                    }
                }
            }
            if (shouldAddNewItem) prologLines.Add(newItem);
            prologLines.Add(append);
            return String.Join("\r\n", prologLines.ToArray());
        }

        public IEnumerable<CommandItem> this[string command]
        {
            get { return Commands.Where(c => System.String.Compare(c.Command, command, System.StringComparison.OrdinalIgnoreCase) == 0); }
        }

        public bool HasCommand(string command)
        {
            return Commands.Any(c => System.String.Compare(c.Command, command, System.StringComparison.OrdinalIgnoreCase) == 0);
        }

        public bool IsView
        {
            get { return HasCommand("view"); }
        }

        public IEnumerable<CommandItem> Replaces
        {
            get { return this["replace"].Where(c => c.Arguments.Count == 2); }
        }

        public IEnumerable<string> Regions
        {
            get
            {
                foreach (var reg in this["addregion"])
                {
                    foreach (var arg in reg.Arguments) yield return arg;
                }
            }
        }

        public bool IsRazor
        {
            get
            {
                char? ch = RazorChar;
                return ch.HasValue && (ch == '\0' || ch == '#');
            }
        }

        public char? RazorChar
        {
            get
            {
                foreach (var cmd in Commands)
                {
                    char? ch = cmd.RazorChar;
                    if (ch != null) return ch;
                }
                return null;
            }
        }

        public string Transformation
        {
            get { return Commands.Select(cmd => cmd.Transformation).FirstOrDefault(tran => tran != null); }
        }

        public string PreprocessScript(string content)
        {
            if (IsRazor)
            {
                char ch = RazorChar ?? '\0';
                if (ch != '\0')
                {
                    content = Regex.Replace(content, @"^\s*--\s*#\s*razor" + ch, "", RegexOptions.Multiline | RegexOptions.IgnoreCase);
                    content = Regex.Replace(content, @"^\s*--\s*#", "--", RegexOptions.Multiline | RegexOptions.IgnoreCase);
                    content = content.Replace("@", "@@").Replace(ch, '@');
                }
                var sw = new StringWriter();
                RazorScripting.ParseRazor(content, sw.Write, new object());
                content = sw.ToString();
            }

            if (Regex.Match(content, @"^\s*--\s*#\s*region\s", RegexOptions.Multiline).Success)
            {
                // process regions
                var regs = Regions.ToList();
                var sb = new StringBuilder();
                bool isAllowed = true;
                bool isInRegion = false;
                foreach(string line in content.Split('\n'))
                {
                    var mBegin = Regex.Match(line, @"^\s*--\s*#\s*region\s+([^s]+)");
                    if (mBegin.Success)
                    {
                        if (isInRegion)
                        {
                            throw new Exception("DBSH-00111 Nested regions are not allowed");
                        }
                        isInRegion = true;
                        var item = ParseLine(line);
                        string region = item.Arguments[0];
                        isAllowed = regs.Contains(region);
                    }
                    var mEnd = Regex.Match(line, @"^\s*--\s*#\s*endregion");
                    if (mEnd.Success)
                    {
                        if (!isInRegion)
                        {
                            throw new Exception("DBSH-00112 #endregion without region");
                        }
                        isInRegion = false;
                        isAllowed = true;
                    }
                    if (isAllowed)
                    {
                        sb.Append(line + "\n");
                    }
                    else
                    {
                        sb.Append("\r\n");
                    }
                }
                if (isInRegion)
                {
                    throw new Exception("DBSH-00113 Unclosed region");
                }
                content = sb.ToString();
            }


            foreach (var replace in Replaces)
            {
                content = content.Replace(replace.Arguments[0], replace.Arguments[1]);
            }
            return content;
        }
    }
}
