using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace DbShell.Driver.Common.FilterParserBasicImpl
{
    public abstract class ParserBase<T>
    {
        protected string _expression;
        protected FilterTokenizer _tokenizer;
        protected HashSet<string> _keywords = new HashSet<string>();

        protected List<FilterToken> _tokens;
        protected int _currentTokenIndex;
        protected FilterParseOptions _options;
        public bool IsError;

        public T Result;

        protected ParserBase(string expression)
        {
            _expression = expression;
        }

        public void Run()
        {
            _tokenizer = new FilterTokenizer(_expression, _keywords, _options);
            _tokenizer.Run();
            _tokens = _tokenizer.Result;
            IsError = _tokenizer.IsError;
            Result = ParseBody();
            if (IsError) Result = default(T);
        }

        protected abstract T ParseBody();

        protected bool EndOfInput => _currentTokenIndex >= _tokens.Count;

        protected FilterToken CurrentToken => _currentTokenIndex >= _tokens.Count ? null : _tokens[_currentTokenIndex];
        protected FilterToken NextToken => _currentTokenIndex + 1 >= _tokens.Count ? null : _tokens[_currentTokenIndex + 1];

        protected bool TestKeywords(params string[] keywords)
        {
            for (int i = 0; i < keywords.Length; i++)
            {
                if (i + _currentTokenIndex >= _tokens.Count) return false;
                if (_tokens[i + _currentTokenIndex].TokenType != FilterTokenType.KEYWORD) return false;
                if (_tokens[i + _currentTokenIndex].Data != keywords[i]) return false;
            }
            Next(keywords.Length);
            return true;
        }

        protected void Next(int count = 1)
        {
            _currentTokenIndex += count;
        }

        protected bool TestOperator(string opname)
        {
            if (CurrentToken?.TokenType == FilterTokenType.OPERATOR && CurrentToken.Data == opname)
            {
                Next();
                return true;
            }
            return false;
        }
    }
}
