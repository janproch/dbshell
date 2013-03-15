using System;
using System.Collections.Generic;
using System.Text;

namespace DbShell.Driver.Common.FilterParser
{
    public class FilterTokenizer
    {
        public enum Token
        {
            Eof,
            String,
            Number,
            Operator,
            Comma
        }

        public readonly bool AllowDecimals;
        public readonly string Text;

        public int Position;
        public Token Current;
        public string CurrentData;
        public List<string> Operators = new List<string>();

        public FilterTokenizer(string text, bool allowDecimals = false, IEnumerable<string> operators = null)
        {
            Text = text;
            AllowDecimals = allowDecimals;
            if (operators != null) Operators = new List<string>(operators);
            Operators.Sort((a, b) => b.Length - a.Length);
            NextToken();
        }

        public char CurrentCh
        {
            get
            {
                if (Position < Text.Length) return Text[Position];
                return '\0';
            }
        }

        public char NextCh
        {
            get
            {
                if (Position + 1 < Text.Length) return Text[Position + 1];
                return '\0';
            }
        }

        public bool IsEof
        {
            get { return Current == Token.Eof; }
        }

        private bool IsCharEof
        {
            get { return Position >= Text.Length; }
        }

        private string CurrentText
        {
            get
            {
                if (Position < Text.Length) return Text.Substring(Position);
                return "";
            }
        }

        private string StartWithOne(IEnumerable<string> values)
        {
            string text = CurrentText;
            foreach(string value in values)
            {
                if (text.StartsWith(value)) return value;
            }
            return null;
        }

        private void JumpSpaces()
        {
            while (CurrentCh == ' ') Position++;
        }

        public void NextToken()
        {
            CurrentData = null;
            JumpSpaces();
            if (IsCharEof)
            {
                Current = Token.Eof;
                return;
            }
            string op = StartWithOne(Operators);
            if (op != null)
            {
                Current = Token.Operator;
                CurrentData = op;
                return;
            }
            if (Char.IsDigit(CurrentCh))
            {
                var sb = new StringBuilder();
                while (Char.IsDigit(CurrentCh))
                {
                    sb.Append(CurrentCh);
                    Position++;
                }
                if (AllowDecimals && CurrentCh == '.' && Char.IsDigit(NextCh))
                {
                    sb.Append('.');
                    Position++;
                    while (Char.IsDigit(CurrentCh))
                    {
                        sb.Append(CurrentCh);
                        Position++;
                    }
                }
            }
            if (CurrentCh == ',')
            {
                Current = Token.Comma;
                Position++;
            }
        }

        public bool IsOperator(string op)
        {
            return Current == Token.Operator && CurrentData == op;
        }
    }
}
