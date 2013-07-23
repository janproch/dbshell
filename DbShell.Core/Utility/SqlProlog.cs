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
            public List<string> Arguments = new List<string>();
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

        public SqlProlog(string content)
            : this(new StringReader(content ?? String.Empty))
        {

        }

        public SqlProlog(TextReader reader)
        {
            for (;;)
            {
                string line = reader.ReadLine();
                if (line == null) return;
                line = line.Trim();
                if (String.IsNullOrEmpty(line)) continue;

                var parser = new Parser(line);
                if (parser.Current != '-' || parser.Next != '-') return;
                parser.Skip(2);
                parser.JumpWhite();
                if (parser.Current != '#') return;
                parser.Skip(1);
                string command = parser.ReadToken();
                if (command == null) continue;
                var item = new CommandItem
                    {
                        Command = command
                    };
                Commands.Add(item);
                while (!parser.IsEof)
                {
                    string token = parser.ReadToken();
                    if (token == null) break;
                    item.Arguments.Add(token);
                }
            }
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
                    if (cmd.Command.StartsWith("razor", StringComparison.OrdinalIgnoreCase) && cmd.Command.Length == 6)
                    {
                        return cmd.Command[5];
                    }
                    if (String.Compare("razor", cmd.Command, StringComparison.OrdinalIgnoreCase) == 0)
                    {
                        return '\0';
                    }
                }
                return null;
            }
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

            foreach (var replace in Replaces)
            {
                content = content.Replace(replace.Arguments[0], replace.Arguments[1]);
            }
            return content;
        }
    }
}
