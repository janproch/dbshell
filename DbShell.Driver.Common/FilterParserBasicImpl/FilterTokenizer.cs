using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace DbShell.Driver.Common.FilterParserBasicImpl
{
    public enum FilterTokenType
    {
        STRING,
        KEYWORD,
        COMMA,
        OPERATOR,
        NUMBER,
        BIT,
        MINUS,

        YEAR,
        DATE,

        TIME_MINUTE,
        TIME_SECOND,
        TIME_SECOND_FRACTION,

        FLOW_MONTH,
        FLOW_DAY,
        YEAR_MONTH,
        HOUR_ANY_MINUTE,
    }

    public class FilterToken
    {
        public FilterTokenType TokenType;
        public string Data;
        public int IntData;

        public override string ToString() => $"{TokenType}:{Data}";
    }

    public static class FilterRegexes
    {
        public static Regex YearRegex = new Regex(@"\d\d\d\d", RegexOptions.Compiled);
        public static Regex DateIsoRegex = new Regex(@"(\d\d\d\d)-(\d?\d)-(\d?\d)", RegexOptions.Compiled);
        public static Regex DateCzechRegex = new Regex(@"(\d?\d)\.(\d?\d)\.(\d\d\d\d)?", RegexOptions.Compiled);
        public static Regex DateUsRegex = new Regex(@"(\d?\d)\/(\d?\d)\/(\d\d\d\d)?", RegexOptions.Compiled);
        public static Regex NumberRegex = new Regex(@"\d+(\.\d+)?", RegexOptions.Compiled);
        public static Regex TimeSecondFractionRegex = new Regex(@"(\d?\d):(\d?\d):(\d?\d)\.(\d*)", RegexOptions.Compiled);
        public static Regex TimeSecondRegex = new Regex(@"(\d?\d):(\d?\d):(\d?\d)", RegexOptions.Compiled);
        public static Regex TimeMinuteRegex = new Regex(@"(\d?\d):(\d?\d)", RegexOptions.Compiled);
        public static Regex FlowMonthRegex = new Regex(@"(\d?\d)\/", RegexOptions.Compiled);
        public static Regex FlowDayRegex = new Regex(@"(\d?\d)\.", RegexOptions.Compiled);
        public static Regex YearMonthRegex = new Regex(@"(\d\d\d\d)-(\d\d)", RegexOptions.Compiled);
        public static Regex HourAnyMinuteRegex = new Regex(@"(\d\d):\*", RegexOptions.Compiled);
        public static Regex BitRegex = new Regex(@"0|1", RegexOptions.Compiled);
    }

    public class FilterTokenizer
    {
        private string _text;
        private int _position;

        public List<FilterToken> Result = new List<FilterToken>();
        private StringBuilder _buffer = new StringBuilder();
        private HashSet<string> _keywords;

        private FilterParseOptions _options;


        public bool IsError = false;

        public FilterTokenizer(string text, HashSet<string> keywords, FilterParseOptions options)
        {
            _text = text;
            _keywords = keywords;
            _options = options;
        }

        private bool EndOfString => _position >= _text.Length;
        private char CurrentChar => EndOfString ? '\0' : _text[_position];
        private void ClearBuffer() => _buffer.Clear();
        private void Skip() => _position++;
        private void Skip(char ch) { if (CurrentChar == ch) Skip(); }
        private void Read()
        {
            _buffer.Append(CurrentChar);
            Skip();
        }
        private const string _operatorChars = "=<>$!^~$";

        private void SkipWhitespace() => SkipWhile(Char.IsWhiteSpace);
        private static bool IsOperator(char ch) => _operatorChars.IndexOf(ch) >= 0;

        private bool IsNormalChar(char ch)
        {
            if (IsOperator(ch)) return false;
            if (ch == ',' || ch == '\'' || ch == '"' || Char.IsWhiteSpace(ch) || ch == '.') return false;
            if (ch == '-' && _options.ParseNumber) return false;
            return true;
        }

        private void Emit(FilterTokenType tokenType, int intData = 0)
        {
            Result.Add(new FilterParserBasicImpl.FilterToken
            {
                Data = _buffer.ToString(),
                TokenType = tokenType,
                IntData = intData,
            });
            ClearBuffer();
            SkipWhitespace();
        }

        private void ReadWhile(Func<char, bool> testFunc)
        {
            while (!EndOfString && testFunc(CurrentChar))
            {
                Read();
            }
        }

        private void ReadTo(char end) => ReadWhile(x => x != end);

        private void SkipWhile(Func<char, bool> testFunc)
        {
            while (!EndOfString && testFunc(CurrentChar))
            {
                Skip();
            }
        }

        private void Read(Regex regex)
        {
            var match = regex.Match(_text, _position);
            if (!match.Success) return;
            _buffer.Append(_text.Substring(_position, match.Length));
            _position += match.Length;
        }

        private bool IsReg(Regex regex)
        {
            var match = regex.Match(_text, _position);
            if (match.Success)
            {
                return match.Index == _position;
            }
            return false;
        }

        public void Run()
        {
            SkipWhitespace();
            while (!EndOfString)
            {
                SkipWhitespace();

                if (_options.ParseString || _options.ParseNumber)
                {
                    if (CurrentChar == '\'')
                    {
                        Skip();
                        ReadTo('\'');
                        Skip('\'');
                        Emit(FilterTokenType.STRING);
                        continue;
                    }

                    if (CurrentChar == '"')
                    {
                        Skip();
                        ReadTo('"');
                        Skip('"');
                        Emit(FilterTokenType.STRING);
                        continue;
                    }
                }

                if (Char.IsUpper(CurrentChar))
                {
                    int lastPos = _position;
                    ReadWhile(Char.IsLetter);
                    string buf = _buffer.ToString();
                    if (_keywords.Contains(buf))
                    {
                        Emit(FilterTokenType.KEYWORD);
                        continue;
                    }
                    _position = lastPos;
                }

                if (CurrentChar == ',')
                {
                    Skip();
                    Emit(FilterTokenType.COMMA);
                    continue;
                }

                if (IsOperator(CurrentChar))
                {
                    ReadWhile(IsOperator);
                    Emit(FilterTokenType.OPERATOR);
                    continue;
                }

                if (_options.ParseNumber)
                {
                    if (IsReg(FilterRegexes.NumberRegex))
                    {
                        Read(FilterRegexes.NumberRegex);
                        Emit(FilterTokenType.NUMBER);
                        continue;
                    }
                }

                if (_options.ParseLogical)
                {
                    if (IsReg(FilterRegexes.BitRegex))
                    {
                        Read(FilterRegexes.BitRegex);
                        Emit(FilterTokenType.BIT);
                        continue;
                    }
                }

                if (CurrentChar == '-' && _options.ParseNumber)
                {
                    Skip();
                    Emit(FilterTokenType.MINUS);
                    continue;
                }

                if (_options.ParseTime)
                {
                    if (IsReg(FilterRegexes.DateIsoRegex))
                    {
                        Read(FilterRegexes.DateIsoRegex);
                        Emit(FilterTokenType.DATE);
                        continue;
                    }
                    if (IsReg(FilterRegexes.DateCzechRegex))
                    {
                        Read(FilterRegexes.DateCzechRegex);
                        Emit(FilterTokenType.DATE);
                        continue;
                    }
                    if (IsReg(FilterRegexes.DateUsRegex))
                    {
                        Read(FilterRegexes.DateUsRegex);
                        Emit(FilterTokenType.DATE);
                        continue;
                    }
                    if (IsReg(FilterRegexes.TimeSecondFractionRegex))
                    {
                        Read(FilterRegexes.TimeSecondFractionRegex);
                        Emit(FilterTokenType.TIME_SECOND_FRACTION);
                        continue;
                    }
                    if (IsReg(FilterRegexes.TimeSecondRegex))
                    {
                        Read(FilterRegexes.TimeSecondRegex);
                        Emit(FilterTokenType.TIME_SECOND);
                        continue;
                    }
                    if (IsReg(FilterRegexes.TimeMinuteRegex))
                    {
                        Read(FilterRegexes.TimeMinuteRegex);
                        Emit(FilterTokenType.TIME_MINUTE);
                        continue;
                    }
                    if (IsReg(FilterRegexes.FlowDayRegex))
                    {
                        Read(FilterRegexes.FlowDayRegex);
                        Emit(FilterTokenType.FLOW_DAY);
                        continue;
                    }
                    if (IsReg(FilterRegexes.FlowMonthRegex))
                    {
                        Read(FilterRegexes.FlowMonthRegex);
                        Emit(FilterTokenType.FLOW_MONTH);
                        continue;
                    }
                    if (IsReg(FilterRegexes.YearMonthRegex))
                    {
                        Read(FilterRegexes.YearMonthRegex);
                        Emit(FilterTokenType.YEAR_MONTH);
                        continue;
                    }
                    if (IsReg(FilterRegexes.HourAnyMinuteRegex))
                    {
                        Read(FilterRegexes.HourAnyMinuteRegex);
                        Emit(FilterTokenType.HOUR_ANY_MINUTE);
                        continue;
                    }
                    if (IsReg(FilterRegexes.YearRegex))
                    {
                        Read(FilterRegexes.YearRegex);
                        Emit(FilterTokenType.YEAR);
                        continue;
                    }
                }

                if (!IsNormalChar(CurrentChar))
                {
                    IsError = true;
                    return;
                }

                if (!_options.ParseString)
                {
                    IsError = true;
                    return;
                }

                ReadWhile(IsNormalChar);
                Emit(FilterTokenType.STRING);
                continue;
            }
        }
    }
}
