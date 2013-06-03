// $ANTLR 3.2 Sep 23, 2009 12:02:23 ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g 2013-06-02 23:48:07

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162


using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;


public partial class SqlServerLexer : Lexer {
    public const int CAST = 80;
    public const int T_STRING = 5;
    public const int TRIGGER = 141;
    public const int CURRENT_TIME = 89;
    public const int CASE = 79;
    public const int T_IDENT = 12;
    public const int EQUALS = 14;
    public const int NOT = 123;
    public const int T_INTEGER = 6;
    public const int EXCEPT = 102;
    public const int CASCADE = 78;
    public const int EOF = -1;
    public const int FOREIGN = 107;
    public const int EXPLAIN = 105;
    public const int RPAREN = 37;
    public const int CREATE = 87;
    public const int GREATER = 21;
    public const int EXCLAMATION = 39;
    public const int ESCAPE = 101;
    public const int INSERT = 115;
    public const int BEGIN = 75;
    public const int LESS = 19;
    public const int CONFLICT = 85;
    public const int LESS_OR_EQ = 20;
    public const int SELECT = 133;
    public const int INTO = 117;
    public const int D = 47;
    public const int E = 48;
    public const int F = 49;
    public const int UNIQUE = 143;
    public const int G = 50;
    public const int A = 44;
    public const int B = 45;
    public const int VIEW = 146;
    public const int ASC = 74;
    public const int C = 46;
    public const int L = 55;
    public const int LINE_COMMENT = 155;
    public const int M = 56;
    public const int SAFEEQUALS = 15;
    public const int N = 57;
    public const int TRANSACTION = 140;
    public const int KEY = 120;
    public const int T_BINARYNUM = 8;
    public const int O = 58;
    public const int TEMP = 137;
    public const int H = 51;
    public const int NULL = 124;
    public const int I = 52;
    public const int ELSE = 99;
    public const int J = 53;
    public const int K = 54;
    public const int T_FLOAT = 7;
    public const int U = 64;
    public const int ON = 126;
    public const int T = 63;
    public const int WHITESPACE = 156;
    public const int W = 66;
    public const int T_NSTRING = 4;
    public const int V = 65;
    public const int PRIMARY = 130;
    public const int Q = 60;
    public const int DELETE = 95;
    public const int P = 59;
    public const int S = 62;
    public const int R = 61;
    public const int ROLLBACK = 132;
    public const int OF = 125;
    public const int Y = 68;
    public const int X = 67;
    public const int Z = 69;
    public const int SHIFT_LEFT = 23;
    public const int INTERSECT = 116;
    public const int GROUP = 109;
    public const int SHIFT_RIGHT = 24;
    public const int OR = 127;
    public const int CHECK = 81;
    public const int FROM = 108;
    public const int END = 100;
    public const int PARSER = 150;
    public const int TEMPORARY = 136;
    public const int DISTINCT = 97;
    public const int CONSTRAINT = 86;
    public const int CURRENT_DATE = 90;
    public const int DOLLAR = 42;
    public const int WHERE = 148;
    public const int ALTER = 71;
    public const int INNER = 114;
    public const int UTC_TIMESTAMP = 92;
    public const int ORDER = 128;
    public const int TABLE = 135;
    public const int UPDATE = 144;
    public const int FOR = 106;
    public const int EXCLUSIVE = 103;
    public const int AND = 72;
    public const int DOUBLE_AMPERSAND = 26;
    public const int CROSS = 88;
    public const int NOT_EQUALS = 17;
    public const int T_COMMENT = 154;
    public const int ASTERISK = 11;
    public const int LPAREN = 36;
    public const int IF = 111;
    public const int GREATER_OR_EQ = 22;
    public const int DOUBLE_PIPE = 28;
    public const int AT = 41;
    public const int AS = 73;
    public const int INDEX = 113;
    public const int TILDA = 31;
    public const int SLASH = 32;
    public const int IN = 112;
    public const int THEN = 138;
    public const int COMMA = 35;
    public const int REFERENCES = 131;
    public const int IS = 118;
    public const int LEFT = 121;
    public const int COLUMN = 83;
    public const int PIPE = 27;
    public const int PLUS = 29;
    public const int EXISTS = 104;
    public const int DOT = 10;
    public const int CURRENT_TIMESTAMP = 91;
    public const int LIKE = 122;
    public const int WITH = 149;
    public const int COLLATE = 82;
    public const int ADD = 70;
    public const int OUTER = 129;
    public const int BY = 77;
    public const int ARROW_UP = 43;
    public const int XOR = 151;
    public const int EQUALS2 = 16;
    public const int PERCENT = 33;
    public const int TO = 139;
    public const int NOT_EQUALS2 = 18;
    public const int DEFAULT = 94;
    public const int VALUES = 145;
    public const int AMPERSAND = 25;
    public const int SET = 134;
    public const int HAVING = 110;
    public const int MINUS = 30;
    public const int SEMI = 34;
    public const int JOIN = 119;
    public const int UNION = 142;
    public const int T_QUOTED_IDENT = 13;
    public const int COLON = 40;
    public const int FLOAT_EXP = 153;
    public const int COMMIT = 84;
    public const int QUESTION = 38;
    public const int DATABASE = 93;
    public const int DROP = 98;
    public const int WHEN = 147;
    public const int T_BLOB = 9;
    public const int DESC = 96;
    public const int ID_START = 152;
    public const int BETWEEN = 76;

    // delegates
    // delegators

    public SqlServerLexer() 
    {
		InitializeCyclicDFAs();
    }
    public SqlServerLexer(ICharStream input)
		: this(input, null) {
    }
    public SqlServerLexer(ICharStream input, RecognizerSharedState state)
		: base(input, state) {
		InitializeCyclicDFAs(); 

    }
    
    override public string GrammarFileName
    {
    	get { return "..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g";} 
    }

    // $ANTLR start "EQUALS"
    public void mEQUALS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = EQUALS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:27:7: ( '=' )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:27:16: '='
            {
            	Match('='); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "EQUALS"

    // $ANTLR start "SAFEEQUALS"
    public void mSAFEEQUALS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = SAFEEQUALS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:28:11: ( '<=>' )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:28:16: '<=>'
            {
            	Match("<=>"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "SAFEEQUALS"

    // $ANTLR start "EQUALS2"
    public void mEQUALS2() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = EQUALS2;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:29:8: ( '==' )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:29:16: '=='
            {
            	Match("=="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "EQUALS2"

    // $ANTLR start "NOT_EQUALS"
    public void mNOT_EQUALS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = NOT_EQUALS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:30:11: ( '!=' )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:30:16: '!='
            {
            	Match("!="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "NOT_EQUALS"

    // $ANTLR start "NOT_EQUALS2"
    public void mNOT_EQUALS2() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = NOT_EQUALS2;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:31:12: ( '<>' )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:31:16: '<>'
            {
            	Match("<>"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "NOT_EQUALS2"

    // $ANTLR start "LESS"
    public void mLESS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = LESS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:32:5: ( '<' )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:32:16: '<'
            {
            	Match('<'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "LESS"

    // $ANTLR start "LESS_OR_EQ"
    public void mLESS_OR_EQ() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = LESS_OR_EQ;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:33:11: ( '<=' )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:33:16: '<='
            {
            	Match("<="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "LESS_OR_EQ"

    // $ANTLR start "GREATER"
    public void mGREATER() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = GREATER;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:34:8: ( '>' )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:34:16: '>'
            {
            	Match('>'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "GREATER"

    // $ANTLR start "GREATER_OR_EQ"
    public void mGREATER_OR_EQ() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = GREATER_OR_EQ;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:35:14: ( '>=' )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:35:16: '>='
            {
            	Match(">="); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "GREATER_OR_EQ"

    // $ANTLR start "SHIFT_LEFT"
    public void mSHIFT_LEFT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = SHIFT_LEFT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:36:11: ( '<<' )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:36:16: '<<'
            {
            	Match("<<"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "SHIFT_LEFT"

    // $ANTLR start "SHIFT_RIGHT"
    public void mSHIFT_RIGHT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = SHIFT_RIGHT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:37:12: ( '>>' )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:37:16: '>>'
            {
            	Match(">>"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "SHIFT_RIGHT"

    // $ANTLR start "AMPERSAND"
    public void mAMPERSAND() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = AMPERSAND;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:38:10: ( '&' )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:38:16: '&'
            {
            	Match('&'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "AMPERSAND"

    // $ANTLR start "DOUBLE_AMPERSAND"
    public void mDOUBLE_AMPERSAND() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = DOUBLE_AMPERSAND;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:39:17: ( '&&' )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:39:19: '&&'
            {
            	Match("&&"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "DOUBLE_AMPERSAND"

    // $ANTLR start "PIPE"
    public void mPIPE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = PIPE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:40:5: ( '|' )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:40:16: '|'
            {
            	Match('|'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "PIPE"

    // $ANTLR start "DOUBLE_PIPE"
    public void mDOUBLE_PIPE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = DOUBLE_PIPE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:41:12: ( '||' )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:41:16: '||'
            {
            	Match("||"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "DOUBLE_PIPE"

    // $ANTLR start "PLUS"
    public void mPLUS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = PLUS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:42:5: ( '+' )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:42:16: '+'
            {
            	Match('+'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "PLUS"

    // $ANTLR start "MINUS"
    public void mMINUS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = MINUS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:43:6: ( '-' )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:43:16: '-'
            {
            	Match('-'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "MINUS"

    // $ANTLR start "TILDA"
    public void mTILDA() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = TILDA;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:44:6: ( '~' )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:44:16: '~'
            {
            	Match('~'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "TILDA"

    // $ANTLR start "ASTERISK"
    public void mASTERISK() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = ASTERISK;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:45:9: ( '*' )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:45:16: '*'
            {
            	Match('*'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "ASTERISK"

    // $ANTLR start "SLASH"
    public void mSLASH() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = SLASH;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:46:6: ( '/' )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:46:16: '/'
            {
            	Match('/'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "SLASH"

    // $ANTLR start "PERCENT"
    public void mPERCENT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = PERCENT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:47:8: ( '%' )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:47:16: '%'
            {
            	Match('%'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "PERCENT"

    // $ANTLR start "SEMI"
    public void mSEMI() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = SEMI;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:48:5: ( ';' )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:48:16: ';'
            {
            	Match(';'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "SEMI"

    // $ANTLR start "DOT"
    public void mDOT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = DOT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:49:4: ( '.' )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:49:16: '.'
            {
            	Match('.'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "DOT"

    // $ANTLR start "COMMA"
    public void mCOMMA() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = COMMA;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:50:6: ( ',' )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:50:16: ','
            {
            	Match(','); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "COMMA"

    // $ANTLR start "LPAREN"
    public void mLPAREN() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = LPAREN;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:51:7: ( '(' )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:51:16: '('
            {
            	Match('('); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "LPAREN"

    // $ANTLR start "RPAREN"
    public void mRPAREN() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = RPAREN;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:52:7: ( ')' )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:52:16: ')'
            {
            	Match(')'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "RPAREN"

    // $ANTLR start "QUESTION"
    public void mQUESTION() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = QUESTION;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:53:9: ( '?' )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:53:16: '?'
            {
            	Match('?'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "QUESTION"

    // $ANTLR start "EXCLAMATION"
    public void mEXCLAMATION() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = EXCLAMATION;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:54:12: ( '!' )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:54:16: '!'
            {
            	Match('!'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "EXCLAMATION"

    // $ANTLR start "COLON"
    public void mCOLON() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = COLON;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:55:6: ( ':' )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:55:16: ':'
            {
            	Match(':'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "COLON"

    // $ANTLR start "AT"
    public void mAT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = AT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:56:3: ( '@' )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:56:16: '@'
            {
            	Match('@'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "AT"

    // $ANTLR start "DOLLAR"
    public void mDOLLAR() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = DOLLAR;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:57:7: ( '$' )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:57:16: '$'
            {
            	Match('$'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "DOLLAR"

    // $ANTLR start "ARROW_UP"
    public void mARROW_UP() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = ARROW_UP;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:58:9: ( '^' )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:58:16: '^'
            {
            	Match('^'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "ARROW_UP"

    // $ANTLR start "A"
    public void mA() // throws RecognitionException [2]
    {
    		try
    		{
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:70:11: ( ( 'a' | 'A' ) )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:70:12: ( 'a' | 'A' )
            {
            	if ( input.LA(1) == 'A' || input.LA(1) == 'a' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "A"

    // $ANTLR start "B"
    public void mB() // throws RecognitionException [2]
    {
    		try
    		{
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:71:11: ( ( 'b' | 'B' ) )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:71:12: ( 'b' | 'B' )
            {
            	if ( input.LA(1) == 'B' || input.LA(1) == 'b' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "B"

    // $ANTLR start "C"
    public void mC() // throws RecognitionException [2]
    {
    		try
    		{
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:72:11: ( ( 'c' | 'C' ) )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:72:12: ( 'c' | 'C' )
            {
            	if ( input.LA(1) == 'C' || input.LA(1) == 'c' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "C"

    // $ANTLR start "D"
    public void mD() // throws RecognitionException [2]
    {
    		try
    		{
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:73:11: ( ( 'd' | 'D' ) )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:73:12: ( 'd' | 'D' )
            {
            	if ( input.LA(1) == 'D' || input.LA(1) == 'd' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "D"

    // $ANTLR start "E"
    public void mE() // throws RecognitionException [2]
    {
    		try
    		{
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:74:11: ( ( 'e' | 'E' ) )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:74:12: ( 'e' | 'E' )
            {
            	if ( input.LA(1) == 'E' || input.LA(1) == 'e' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "E"

    // $ANTLR start "F"
    public void mF() // throws RecognitionException [2]
    {
    		try
    		{
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:75:11: ( ( 'f' | 'F' ) )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:75:12: ( 'f' | 'F' )
            {
            	if ( input.LA(1) == 'F' || input.LA(1) == 'f' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "F"

    // $ANTLR start "G"
    public void mG() // throws RecognitionException [2]
    {
    		try
    		{
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:76:11: ( ( 'g' | 'G' ) )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:76:12: ( 'g' | 'G' )
            {
            	if ( input.LA(1) == 'G' || input.LA(1) == 'g' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "G"

    // $ANTLR start "H"
    public void mH() // throws RecognitionException [2]
    {
    		try
    		{
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:77:11: ( ( 'h' | 'H' ) )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:77:12: ( 'h' | 'H' )
            {
            	if ( input.LA(1) == 'H' || input.LA(1) == 'h' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "H"

    // $ANTLR start "I"
    public void mI() // throws RecognitionException [2]
    {
    		try
    		{
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:78:11: ( ( 'i' | 'I' ) )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:78:12: ( 'i' | 'I' )
            {
            	if ( input.LA(1) == 'I' || input.LA(1) == 'i' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "I"

    // $ANTLR start "J"
    public void mJ() // throws RecognitionException [2]
    {
    		try
    		{
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:79:11: ( ( 'j' | 'J' ) )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:79:12: ( 'j' | 'J' )
            {
            	if ( input.LA(1) == 'J' || input.LA(1) == 'j' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "J"

    // $ANTLR start "K"
    public void mK() // throws RecognitionException [2]
    {
    		try
    		{
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:80:11: ( ( 'k' | 'K' ) )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:80:12: ( 'k' | 'K' )
            {
            	if ( input.LA(1) == 'K' || input.LA(1) == 'k' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "K"

    // $ANTLR start "L"
    public void mL() // throws RecognitionException [2]
    {
    		try
    		{
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:81:11: ( ( 'l' | 'L' ) )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:81:12: ( 'l' | 'L' )
            {
            	if ( input.LA(1) == 'L' || input.LA(1) == 'l' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "L"

    // $ANTLR start "M"
    public void mM() // throws RecognitionException [2]
    {
    		try
    		{
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:82:11: ( ( 'm' | 'M' ) )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:82:12: ( 'm' | 'M' )
            {
            	if ( input.LA(1) == 'M' || input.LA(1) == 'm' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "M"

    // $ANTLR start "N"
    public void mN() // throws RecognitionException [2]
    {
    		try
    		{
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:83:11: ( ( 'n' | 'N' ) )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:83:12: ( 'n' | 'N' )
            {
            	if ( input.LA(1) == 'N' || input.LA(1) == 'n' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "N"

    // $ANTLR start "O"
    public void mO() // throws RecognitionException [2]
    {
    		try
    		{
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:84:11: ( ( 'o' | 'O' ) )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:84:12: ( 'o' | 'O' )
            {
            	if ( input.LA(1) == 'O' || input.LA(1) == 'o' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "O"

    // $ANTLR start "P"
    public void mP() // throws RecognitionException [2]
    {
    		try
    		{
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:85:11: ( ( 'p' | 'P' ) )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:85:12: ( 'p' | 'P' )
            {
            	if ( input.LA(1) == 'P' || input.LA(1) == 'p' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "P"

    // $ANTLR start "Q"
    public void mQ() // throws RecognitionException [2]
    {
    		try
    		{
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:86:11: ( ( 'q' | 'Q' ) )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:86:12: ( 'q' | 'Q' )
            {
            	if ( input.LA(1) == 'Q' || input.LA(1) == 'q' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "Q"

    // $ANTLR start "R"
    public void mR() // throws RecognitionException [2]
    {
    		try
    		{
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:87:11: ( ( 'r' | 'R' ) )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:87:12: ( 'r' | 'R' )
            {
            	if ( input.LA(1) == 'R' || input.LA(1) == 'r' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "R"

    // $ANTLR start "S"
    public void mS() // throws RecognitionException [2]
    {
    		try
    		{
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:88:11: ( ( 's' | 'S' ) )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:88:12: ( 's' | 'S' )
            {
            	if ( input.LA(1) == 'S' || input.LA(1) == 's' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "S"

    // $ANTLR start "T"
    public void mT() // throws RecognitionException [2]
    {
    		try
    		{
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:89:11: ( ( 't' | 'T' ) )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:89:12: ( 't' | 'T' )
            {
            	if ( input.LA(1) == 'T' || input.LA(1) == 't' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "T"

    // $ANTLR start "U"
    public void mU() // throws RecognitionException [2]
    {
    		try
    		{
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:90:11: ( ( 'u' | 'U' ) )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:90:12: ( 'u' | 'U' )
            {
            	if ( input.LA(1) == 'U' || input.LA(1) == 'u' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "U"

    // $ANTLR start "V"
    public void mV() // throws RecognitionException [2]
    {
    		try
    		{
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:91:11: ( ( 'v' | 'V' ) )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:91:12: ( 'v' | 'V' )
            {
            	if ( input.LA(1) == 'V' || input.LA(1) == 'v' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "V"

    // $ANTLR start "W"
    public void mW() // throws RecognitionException [2]
    {
    		try
    		{
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:92:11: ( ( 'w' | 'W' ) )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:92:12: ( 'w' | 'W' )
            {
            	if ( input.LA(1) == 'W' || input.LA(1) == 'w' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "W"

    // $ANTLR start "X"
    public void mX() // throws RecognitionException [2]
    {
    		try
    		{
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:93:11: ( ( 'x' | 'X' ) )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:93:12: ( 'x' | 'X' )
            {
            	if ( input.LA(1) == 'X' || input.LA(1) == 'x' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "X"

    // $ANTLR start "Y"
    public void mY() // throws RecognitionException [2]
    {
    		try
    		{
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:94:11: ( ( 'y' | 'Y' ) )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:94:12: ( 'y' | 'Y' )
            {
            	if ( input.LA(1) == 'Y' || input.LA(1) == 'y' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "Y"

    // $ANTLR start "Z"
    public void mZ() // throws RecognitionException [2]
    {
    		try
    		{
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:95:11: ( ( 'z' | 'Z' ) )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:95:12: ( 'z' | 'Z' )
            {
            	if ( input.LA(1) == 'Z' || input.LA(1) == 'z' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "Z"

    // $ANTLR start "ADD"
    public void mADD() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = ADD;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:98:5: ( A D D )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:98:7: A D D
            {
            	mA(); 
            	mD(); 
            	mD(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "ADD"

    // $ANTLR start "ALTER"
    public void mALTER() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = ALTER;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:99:7: ( A L T E R )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:99:9: A L T E R
            {
            	mA(); 
            	mL(); 
            	mT(); 
            	mE(); 
            	mR(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "ALTER"

    // $ANTLR start "AND"
    public void mAND() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = AND;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:100:5: ( A N D )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:100:7: A N D
            {
            	mA(); 
            	mN(); 
            	mD(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "AND"

    // $ANTLR start "AS"
    public void mAS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = AS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:101:4: ( A S )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:101:6: A S
            {
            	mA(); 
            	mS(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "AS"

    // $ANTLR start "ASC"
    public void mASC() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = ASC;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:102:5: ( A S C )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:102:7: A S C
            {
            	mA(); 
            	mS(); 
            	mC(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "ASC"

    // $ANTLR start "BEGIN"
    public void mBEGIN() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = BEGIN;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:103:7: ( B E G I N )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:103:9: B E G I N
            {
            	mB(); 
            	mE(); 
            	mG(); 
            	mI(); 
            	mN(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "BEGIN"

    // $ANTLR start "BETWEEN"
    public void mBETWEEN() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = BETWEEN;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:104:9: ( B E T W E E N )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:104:11: B E T W E E N
            {
            	mB(); 
            	mE(); 
            	mT(); 
            	mW(); 
            	mE(); 
            	mE(); 
            	mN(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "BETWEEN"

    // $ANTLR start "BY"
    public void mBY() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = BY;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:105:4: ( B Y )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:105:6: B Y
            {
            	mB(); 
            	mY(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "BY"

    // $ANTLR start "CASCADE"
    public void mCASCADE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = CASCADE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:106:9: ( C A S C A D E )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:106:11: C A S C A D E
            {
            	mC(); 
            	mA(); 
            	mS(); 
            	mC(); 
            	mA(); 
            	mD(); 
            	mE(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "CASCADE"

    // $ANTLR start "CASE"
    public void mCASE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = CASE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:107:6: ( C A S E )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:107:8: C A S E
            {
            	mC(); 
            	mA(); 
            	mS(); 
            	mE(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "CASE"

    // $ANTLR start "CAST"
    public void mCAST() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = CAST;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:108:6: ( C A S T )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:108:8: C A S T
            {
            	mC(); 
            	mA(); 
            	mS(); 
            	mT(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "CAST"

    // $ANTLR start "CHECK"
    public void mCHECK() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = CHECK;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:109:7: ( C H E C K )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:109:9: C H E C K
            {
            	mC(); 
            	mH(); 
            	mE(); 
            	mC(); 
            	mK(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "CHECK"

    // $ANTLR start "COLLATE"
    public void mCOLLATE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = COLLATE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:110:9: ( C O L L A T E )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:110:11: C O L L A T E
            {
            	mC(); 
            	mO(); 
            	mL(); 
            	mL(); 
            	mA(); 
            	mT(); 
            	mE(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "COLLATE"

    // $ANTLR start "COLUMN"
    public void mCOLUMN() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = COLUMN;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:111:8: ( C O L U M N )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:111:10: C O L U M N
            {
            	mC(); 
            	mO(); 
            	mL(); 
            	mU(); 
            	mM(); 
            	mN(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "COLUMN"

    // $ANTLR start "COMMIT"
    public void mCOMMIT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = COMMIT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:112:8: ( C O M M I T )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:112:10: C O M M I T
            {
            	mC(); 
            	mO(); 
            	mM(); 
            	mM(); 
            	mI(); 
            	mT(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "COMMIT"

    // $ANTLR start "CONFLICT"
    public void mCONFLICT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = CONFLICT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:113:10: ( C O N F L I C T )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:113:12: C O N F L I C T
            {
            	mC(); 
            	mO(); 
            	mN(); 
            	mF(); 
            	mL(); 
            	mI(); 
            	mC(); 
            	mT(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "CONFLICT"

    // $ANTLR start "CONSTRAINT"
    public void mCONSTRAINT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = CONSTRAINT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:114:12: ( C O N S T R A I N T )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:114:14: C O N S T R A I N T
            {
            	mC(); 
            	mO(); 
            	mN(); 
            	mS(); 
            	mT(); 
            	mR(); 
            	mA(); 
            	mI(); 
            	mN(); 
            	mT(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "CONSTRAINT"

    // $ANTLR start "CREATE"
    public void mCREATE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = CREATE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:115:8: ( C R E A T E )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:115:10: C R E A T E
            {
            	mC(); 
            	mR(); 
            	mE(); 
            	mA(); 
            	mT(); 
            	mE(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "CREATE"

    // $ANTLR start "CROSS"
    public void mCROSS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = CROSS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:116:7: ( C R O S S )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:116:9: C R O S S
            {
            	mC(); 
            	mR(); 
            	mO(); 
            	mS(); 
            	mS(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "CROSS"

    // $ANTLR start "CURRENT_TIME"
    public void mCURRENT_TIME() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = CURRENT_TIME;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:117:14: ( C U R R E N T '_' T I M E )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:117:16: C U R R E N T '_' T I M E
            {
            	mC(); 
            	mU(); 
            	mR(); 
            	mR(); 
            	mE(); 
            	mN(); 
            	mT(); 
            	Match('_'); 
            	mT(); 
            	mI(); 
            	mM(); 
            	mE(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "CURRENT_TIME"

    // $ANTLR start "CURRENT_DATE"
    public void mCURRENT_DATE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = CURRENT_DATE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:118:14: ( C U R R E N T '_' D A T E )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:118:16: C U R R E N T '_' D A T E
            {
            	mC(); 
            	mU(); 
            	mR(); 
            	mR(); 
            	mE(); 
            	mN(); 
            	mT(); 
            	Match('_'); 
            	mD(); 
            	mA(); 
            	mT(); 
            	mE(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "CURRENT_DATE"

    // $ANTLR start "CURRENT_TIMESTAMP"
    public void mCURRENT_TIMESTAMP() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = CURRENT_TIMESTAMP;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:119:19: ( C U R R E N T '_' T I M E S T A M P )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:119:21: C U R R E N T '_' T I M E S T A M P
            {
            	mC(); 
            	mU(); 
            	mR(); 
            	mR(); 
            	mE(); 
            	mN(); 
            	mT(); 
            	Match('_'); 
            	mT(); 
            	mI(); 
            	mM(); 
            	mE(); 
            	mS(); 
            	mT(); 
            	mA(); 
            	mM(); 
            	mP(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "CURRENT_TIMESTAMP"

    // $ANTLR start "UTC_TIMESTAMP"
    public void mUTC_TIMESTAMP() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = UTC_TIMESTAMP;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:120:15: ( U T C '_' T I M E S T A M P )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:120:17: U T C '_' T I M E S T A M P
            {
            	mU(); 
            	mT(); 
            	mC(); 
            	Match('_'); 
            	mT(); 
            	mI(); 
            	mM(); 
            	mE(); 
            	mS(); 
            	mT(); 
            	mA(); 
            	mM(); 
            	mP(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "UTC_TIMESTAMP"

    // $ANTLR start "DATABASE"
    public void mDATABASE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = DATABASE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:121:10: ( D A T A B A S E )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:121:12: D A T A B A S E
            {
            	mD(); 
            	mA(); 
            	mT(); 
            	mA(); 
            	mB(); 
            	mA(); 
            	mS(); 
            	mE(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "DATABASE"

    // $ANTLR start "DEFAULT"
    public void mDEFAULT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = DEFAULT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:122:9: ( D E F A U L T )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:122:11: D E F A U L T
            {
            	mD(); 
            	mE(); 
            	mF(); 
            	mA(); 
            	mU(); 
            	mL(); 
            	mT(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "DEFAULT"

    // $ANTLR start "DELETE"
    public void mDELETE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = DELETE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:123:8: ( D E L E T E )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:123:10: D E L E T E
            {
            	mD(); 
            	mE(); 
            	mL(); 
            	mE(); 
            	mT(); 
            	mE(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "DELETE"

    // $ANTLR start "DESC"
    public void mDESC() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = DESC;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:124:6: ( D E S C )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:124:8: D E S C
            {
            	mD(); 
            	mE(); 
            	mS(); 
            	mC(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "DESC"

    // $ANTLR start "DISTINCT"
    public void mDISTINCT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = DISTINCT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:125:10: ( D I S T I N C T )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:125:12: D I S T I N C T
            {
            	mD(); 
            	mI(); 
            	mS(); 
            	mT(); 
            	mI(); 
            	mN(); 
            	mC(); 
            	mT(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "DISTINCT"

    // $ANTLR start "DROP"
    public void mDROP() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = DROP;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:126:6: ( D R O P )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:126:8: D R O P
            {
            	mD(); 
            	mR(); 
            	mO(); 
            	mP(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "DROP"

    // $ANTLR start "ELSE"
    public void mELSE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = ELSE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:127:6: ( E L S E )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:127:8: E L S E
            {
            	mE(); 
            	mL(); 
            	mS(); 
            	mE(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "ELSE"

    // $ANTLR start "END"
    public void mEND() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = END;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:128:5: ( E N D )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:128:7: E N D
            {
            	mE(); 
            	mN(); 
            	mD(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "END"

    // $ANTLR start "ESCAPE"
    public void mESCAPE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = ESCAPE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:129:8: ( E S C A P E )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:129:10: E S C A P E
            {
            	mE(); 
            	mS(); 
            	mC(); 
            	mA(); 
            	mP(); 
            	mE(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "ESCAPE"

    // $ANTLR start "EXCEPT"
    public void mEXCEPT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = EXCEPT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:130:8: ( E X C E P T )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:130:10: E X C E P T
            {
            	mE(); 
            	mX(); 
            	mC(); 
            	mE(); 
            	mP(); 
            	mT(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "EXCEPT"

    // $ANTLR start "EXCLUSIVE"
    public void mEXCLUSIVE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = EXCLUSIVE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:131:11: ( E X C L U S I V E )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:131:13: E X C L U S I V E
            {
            	mE(); 
            	mX(); 
            	mC(); 
            	mL(); 
            	mU(); 
            	mS(); 
            	mI(); 
            	mV(); 
            	mE(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "EXCLUSIVE"

    // $ANTLR start "EXISTS"
    public void mEXISTS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = EXISTS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:132:8: ( E X I S T S )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:132:10: E X I S T S
            {
            	mE(); 
            	mX(); 
            	mI(); 
            	mS(); 
            	mT(); 
            	mS(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "EXISTS"

    // $ANTLR start "EXPLAIN"
    public void mEXPLAIN() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = EXPLAIN;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:133:9: ( E X P L A I N )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:133:11: E X P L A I N
            {
            	mE(); 
            	mX(); 
            	mP(); 
            	mL(); 
            	mA(); 
            	mI(); 
            	mN(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "EXPLAIN"

    // $ANTLR start "FOR"
    public void mFOR() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = FOR;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:134:5: ( F O R )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:134:7: F O R
            {
            	mF(); 
            	mO(); 
            	mR(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "FOR"

    // $ANTLR start "FOREIGN"
    public void mFOREIGN() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = FOREIGN;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:135:9: ( F O R E I G N )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:135:11: F O R E I G N
            {
            	mF(); 
            	mO(); 
            	mR(); 
            	mE(); 
            	mI(); 
            	mG(); 
            	mN(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "FOREIGN"

    // $ANTLR start "FROM"
    public void mFROM() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = FROM;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:136:6: ( F R O M )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:136:8: F R O M
            {
            	mF(); 
            	mR(); 
            	mO(); 
            	mM(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "FROM"

    // $ANTLR start "GROUP"
    public void mGROUP() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = GROUP;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:137:7: ( G R O U P )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:137:9: G R O U P
            {
            	mG(); 
            	mR(); 
            	mO(); 
            	mU(); 
            	mP(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "GROUP"

    // $ANTLR start "HAVING"
    public void mHAVING() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = HAVING;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:138:8: ( H A V I N G )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:138:10: H A V I N G
            {
            	mH(); 
            	mA(); 
            	mV(); 
            	mI(); 
            	mN(); 
            	mG(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "HAVING"

    // $ANTLR start "IF"
    public void mIF() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = IF;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:139:4: ( I F )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:139:6: I F
            {
            	mI(); 
            	mF(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "IF"

    // $ANTLR start "IN"
    public void mIN() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = IN;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:140:4: ( I N )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:140:6: I N
            {
            	mI(); 
            	mN(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "IN"

    // $ANTLR start "INDEX"
    public void mINDEX() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = INDEX;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:141:7: ( I N D E X )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:141:9: I N D E X
            {
            	mI(); 
            	mN(); 
            	mD(); 
            	mE(); 
            	mX(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "INDEX"

    // $ANTLR start "INNER"
    public void mINNER() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = INNER;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:142:7: ( I N N E R )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:142:9: I N N E R
            {
            	mI(); 
            	mN(); 
            	mN(); 
            	mE(); 
            	mR(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "INNER"

    // $ANTLR start "INSERT"
    public void mINSERT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = INSERT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:143:8: ( I N S E R T )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:143:10: I N S E R T
            {
            	mI(); 
            	mN(); 
            	mS(); 
            	mE(); 
            	mR(); 
            	mT(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "INSERT"

    // $ANTLR start "INTERSECT"
    public void mINTERSECT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = INTERSECT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:144:11: ( I N T E R S E C T )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:144:13: I N T E R S E C T
            {
            	mI(); 
            	mN(); 
            	mT(); 
            	mE(); 
            	mR(); 
            	mS(); 
            	mE(); 
            	mC(); 
            	mT(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "INTERSECT"

    // $ANTLR start "INTO"
    public void mINTO() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = INTO;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:145:6: ( I N T O )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:145:8: I N T O
            {
            	mI(); 
            	mN(); 
            	mT(); 
            	mO(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "INTO"

    // $ANTLR start "IS"
    public void mIS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = IS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:146:4: ( I S )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:146:6: I S
            {
            	mI(); 
            	mS(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "IS"

    // $ANTLR start "JOIN"
    public void mJOIN() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = JOIN;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:147:6: ( J O I N )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:147:8: J O I N
            {
            	mJ(); 
            	mO(); 
            	mI(); 
            	mN(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "JOIN"

    // $ANTLR start "KEY"
    public void mKEY() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = KEY;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:148:5: ( K E Y )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:148:7: K E Y
            {
            	mK(); 
            	mE(); 
            	mY(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "KEY"

    // $ANTLR start "LEFT"
    public void mLEFT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = LEFT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:149:6: ( L E F T )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:149:8: L E F T
            {
            	mL(); 
            	mE(); 
            	mF(); 
            	mT(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "LEFT"

    // $ANTLR start "LIKE"
    public void mLIKE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = LIKE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:150:6: ( L I K E )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:150:8: L I K E
            {
            	mL(); 
            	mI(); 
            	mK(); 
            	mE(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "LIKE"

    // $ANTLR start "NOT"
    public void mNOT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = NOT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:151:5: ( N O T )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:151:7: N O T
            {
            	mN(); 
            	mO(); 
            	mT(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "NOT"

    // $ANTLR start "NULL"
    public void mNULL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = NULL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:152:6: ( N U L L )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:152:8: N U L L
            {
            	mN(); 
            	mU(); 
            	mL(); 
            	mL(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "NULL"

    // $ANTLR start "OF"
    public void mOF() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = OF;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:153:4: ( O F )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:153:6: O F
            {
            	mO(); 
            	mF(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "OF"

    // $ANTLR start "ON"
    public void mON() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = ON;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:154:4: ( O N )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:154:6: O N
            {
            	mO(); 
            	mN(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "ON"

    // $ANTLR start "OR"
    public void mOR() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = OR;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:155:4: ( O R )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:155:6: O R
            {
            	mO(); 
            	mR(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "OR"

    // $ANTLR start "ORDER"
    public void mORDER() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = ORDER;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:156:7: ( O R D E R )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:156:9: O R D E R
            {
            	mO(); 
            	mR(); 
            	mD(); 
            	mE(); 
            	mR(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "ORDER"

    // $ANTLR start "OUTER"
    public void mOUTER() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = OUTER;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:157:7: ( O U T E R )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:157:9: O U T E R
            {
            	mO(); 
            	mU(); 
            	mT(); 
            	mE(); 
            	mR(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "OUTER"

    // $ANTLR start "PRIMARY"
    public void mPRIMARY() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = PRIMARY;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:158:9: ( P R I M A R Y )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:158:11: P R I M A R Y
            {
            	mP(); 
            	mR(); 
            	mI(); 
            	mM(); 
            	mA(); 
            	mR(); 
            	mY(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "PRIMARY"

    // $ANTLR start "REFERENCES"
    public void mREFERENCES() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = REFERENCES;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:159:12: ( R E F E R E N C E S )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:159:14: R E F E R E N C E S
            {
            	mR(); 
            	mE(); 
            	mF(); 
            	mE(); 
            	mR(); 
            	mE(); 
            	mN(); 
            	mC(); 
            	mE(); 
            	mS(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "REFERENCES"

    // $ANTLR start "ROLLBACK"
    public void mROLLBACK() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = ROLLBACK;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:160:10: ( R O L L B A C K )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:160:12: R O L L B A C K
            {
            	mR(); 
            	mO(); 
            	mL(); 
            	mL(); 
            	mB(); 
            	mA(); 
            	mC(); 
            	mK(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "ROLLBACK"

    // $ANTLR start "SELECT"
    public void mSELECT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = SELECT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:161:8: ( S E L E C T )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:161:10: S E L E C T
            {
            	mS(); 
            	mE(); 
            	mL(); 
            	mE(); 
            	mC(); 
            	mT(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "SELECT"

    // $ANTLR start "SET"
    public void mSET() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = SET;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:162:5: ( S E T )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:162:7: S E T
            {
            	mS(); 
            	mE(); 
            	mT(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "SET"

    // $ANTLR start "TABLE"
    public void mTABLE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = TABLE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:163:7: ( T A B L E )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:163:9: T A B L E
            {
            	mT(); 
            	mA(); 
            	mB(); 
            	mL(); 
            	mE(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "TABLE"

    // $ANTLR start "TEMPORARY"
    public void mTEMPORARY() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = TEMPORARY;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:164:11: ( T E M P O R A R Y )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:164:13: T E M P O R A R Y
            {
            	mT(); 
            	mE(); 
            	mM(); 
            	mP(); 
            	mO(); 
            	mR(); 
            	mA(); 
            	mR(); 
            	mY(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "TEMPORARY"

    // $ANTLR start "TEMP"
    public void mTEMP() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = TEMP;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:165:6: ( T E M P )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:165:8: T E M P
            {
            	mT(); 
            	mE(); 
            	mM(); 
            	mP(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "TEMP"

    // $ANTLR start "THEN"
    public void mTHEN() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = THEN;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:166:6: ( T H E N )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:166:8: T H E N
            {
            	mT(); 
            	mH(); 
            	mE(); 
            	mN(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "THEN"

    // $ANTLR start "TO"
    public void mTO() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = TO;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:167:4: ( T O )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:167:6: T O
            {
            	mT(); 
            	mO(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "TO"

    // $ANTLR start "TRANSACTION"
    public void mTRANSACTION() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = TRANSACTION;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:168:13: ( T R A N S A C T I O N )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:168:15: T R A N S A C T I O N
            {
            	mT(); 
            	mR(); 
            	mA(); 
            	mN(); 
            	mS(); 
            	mA(); 
            	mC(); 
            	mT(); 
            	mI(); 
            	mO(); 
            	mN(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "TRANSACTION"

    // $ANTLR start "TRIGGER"
    public void mTRIGGER() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = TRIGGER;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:169:9: ( T R I G G E R )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:169:11: T R I G G E R
            {
            	mT(); 
            	mR(); 
            	mI(); 
            	mG(); 
            	mG(); 
            	mE(); 
            	mR(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "TRIGGER"

    // $ANTLR start "UNION"
    public void mUNION() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = UNION;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:170:7: ( U N I O N )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:170:9: U N I O N
            {
            	mU(); 
            	mN(); 
            	mI(); 
            	mO(); 
            	mN(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "UNION"

    // $ANTLR start "UNIQUE"
    public void mUNIQUE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = UNIQUE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:171:8: ( U N I Q U E )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:171:10: U N I Q U E
            {
            	mU(); 
            	mN(); 
            	mI(); 
            	mQ(); 
            	mU(); 
            	mE(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "UNIQUE"

    // $ANTLR start "UPDATE"
    public void mUPDATE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = UPDATE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:172:8: ( U P D A T E )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:172:10: U P D A T E
            {
            	mU(); 
            	mP(); 
            	mD(); 
            	mA(); 
            	mT(); 
            	mE(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "UPDATE"

    // $ANTLR start "VALUES"
    public void mVALUES() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = VALUES;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:173:8: ( V A L U E S )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:173:10: V A L U E S
            {
            	mV(); 
            	mA(); 
            	mL(); 
            	mU(); 
            	mE(); 
            	mS(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "VALUES"

    // $ANTLR start "VIEW"
    public void mVIEW() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = VIEW;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:174:6: ( V I E W )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:174:8: V I E W
            {
            	mV(); 
            	mI(); 
            	mE(); 
            	mW(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "VIEW"

    // $ANTLR start "WHEN"
    public void mWHEN() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = WHEN;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:175:6: ( W H E N )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:175:8: W H E N
            {
            	mW(); 
            	mH(); 
            	mE(); 
            	mN(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "WHEN"

    // $ANTLR start "WHERE"
    public void mWHERE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = WHERE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:176:7: ( W H E R E )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:176:9: W H E R E
            {
            	mW(); 
            	mH(); 
            	mE(); 
            	mR(); 
            	mE(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "WHERE"

    // $ANTLR start "WITH"
    public void mWITH() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = WITH;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:177:6: ( W I T H )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:177:8: W I T H
            {
            	mW(); 
            	mI(); 
            	mT(); 
            	mH(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "WITH"

    // $ANTLR start "PARSER"
    public void mPARSER() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = PARSER;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:178:8: ( P A R S E R )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:178:10: P A R S E R
            {
            	mP(); 
            	mA(); 
            	mR(); 
            	mS(); 
            	mE(); 
            	mR(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "PARSER"

    // $ANTLR start "XOR"
    public void mXOR() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = XOR;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:179:5: ( X O R )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:179:7: X O R
            {
            	mX(); 
            	mO(); 
            	mR(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "XOR"

    // $ANTLR start "ID_START"
    public void mID_START() // throws RecognitionException [2]
    {
    		try
    		{
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:181:18: ( ( 'a' .. 'z' | 'A' .. 'Z' | '_' ) )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:181:20: ( 'a' .. 'z' | 'A' .. 'Z' | '_' )
            {
            	if ( (input.LA(1) >= 'A' && input.LA(1) <= 'Z') || input.LA(1) == '_' || (input.LA(1) >= 'a' && input.LA(1) <= 'z') ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "ID_START"

    // $ANTLR start "T_IDENT"
    public void mT_IDENT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_IDENT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:182:8: ( ( ID_START ( ID_START | '0' .. '9' )* ) )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:182:10: ( ID_START ( ID_START | '0' .. '9' )* )
            {
            	// ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:182:10: ( ID_START ( ID_START | '0' .. '9' )* )
            	// ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:182:11: ID_START ( ID_START | '0' .. '9' )*
            	{
            		mID_START(); 
            		// ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:182:20: ( ID_START | '0' .. '9' )*
            		do 
            		{
            		    int alt1 = 2;
            		    int LA1_0 = input.LA(1);

            		    if ( ((LA1_0 >= '0' && LA1_0 <= '9') || (LA1_0 >= 'A' && LA1_0 <= 'Z') || LA1_0 == '_' || (LA1_0 >= 'a' && LA1_0 <= 'z')) )
            		    {
            		        alt1 = 1;
            		    }


            		    switch (alt1) 
            			{
            				case 1 :
            				    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:
            				    {
            				    	if ( (input.LA(1) >= '0' && input.LA(1) <= '9') || (input.LA(1) >= 'A' && input.LA(1) <= 'Z') || input.LA(1) == '_' || (input.LA(1) >= 'a' && input.LA(1) <= 'z') ) 
            				    	{
            				    	    input.Consume();

            				    	}
            				    	else 
            				    	{
            				    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            				    	    Recover(mse);
            				    	    throw mse;}


            				    }
            				    break;

            				default:
            				    goto loop1;
            		    }
            		} while (true);

            		loop1:
            			;	// Stops C# compiler whining that label 'loop1' has no statements


            	}


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_IDENT"

    // $ANTLR start "T_QUOTED_IDENT"
    public void mT_QUOTED_IDENT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_QUOTED_IDENT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:183:15: ( '[' ( options {greedy=false; } : . )* ']' )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:183:17: '[' ( options {greedy=false; } : . )* ']'
            {
            	Match('['); 
            	// ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:183:21: ( options {greedy=false; } : . )*
            	do 
            	{
            	    int alt2 = 2;
            	    int LA2_0 = input.LA(1);

            	    if ( (LA2_0 == ']') )
            	    {
            	        alt2 = 2;
            	    }
            	    else if ( ((LA2_0 >= '\u0000' && LA2_0 <= '\\') || (LA2_0 >= '^' && LA2_0 <= '\uFFFF')) )
            	    {
            	        alt2 = 1;
            	    }


            	    switch (alt2) 
            		{
            			case 1 :
            			    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:183:49: .
            			    {
            			    	MatchAny(); 

            			    }
            			    break;

            			default:
            			    goto loop2;
            	    }
            	} while (true);

            	loop2:
            		;	// Stops C# compiler whining that label 'loop2' has no statements

            	Match(']'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_QUOTED_IDENT"

    // $ANTLR start "T_NSTRING"
    public void mT_NSTRING() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_NSTRING;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:185:10: ( ( 'N' | 'n' ) ( '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\'' ) )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:186:2: ( 'N' | 'n' ) ( '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\'' )
            {
            	if ( input.LA(1) == 'N' || input.LA(1) == 'n' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}

            	// ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:187:4: ( '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\'' )
            	// ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:187:5: '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\''
            	{
            		Match('\''); 
            		// ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:188:5: ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )*
            		do 
            		{
            		    int alt3 = 3;
            		    int LA3_0 = input.LA(1);

            		    if ( (LA3_0 == '\'') )
            		    {
            		        int LA3_1 = input.LA(2);

            		        if ( (LA3_1 == '\'') )
            		        {
            		            alt3 = 2;
            		        }


            		    }
            		    else if ( ((LA3_0 >= '\u0000' && LA3_0 <= '\t') || (LA3_0 >= '\u000B' && LA3_0 <= '\f') || (LA3_0 >= '\u000E' && LA3_0 <= '&') || (LA3_0 >= '(' && LA3_0 <= '\uFFFF')) )
            		    {
            		        alt3 = 1;
            		    }


            		    switch (alt3) 
            			{
            				case 1 :
            				    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:189:31: ~ ( '\\'' | '\\r' | '\\n' )
            				    {
            				    	if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '\t') || (input.LA(1) >= '\u000B' && input.LA(1) <= '\f') || (input.LA(1) >= '\u000E' && input.LA(1) <= '&') || (input.LA(1) >= '(' && input.LA(1) <= '\uFFFF') ) 
            				    	{
            				    	    input.Consume();

            				    	}
            				    	else 
            				    	{
            				    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            				    	    Recover(mse);
            				    	    throw mse;}


            				    }
            				    break;
            				case 2 :
            				    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:189:56: '\\'' '\\''
            				    {
            				    	Match('\''); 
            				    	Match('\''); 

            				    }
            				    break;

            				default:
            				    goto loop3;
            		    }
            		} while (true);

            		loop3:
            			;	// Stops C# compiler whining that label 'loop3' has no statements

            		Match('\''); 

            	}


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_NSTRING"

    // $ANTLR start "T_STRING"
    public void mT_STRING() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_STRING;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:193:9: ( ( '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\'' ) )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:194:4: ( '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\'' )
            {
            	// ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:194:4: ( '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\'' )
            	// ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:194:5: '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\''
            	{
            		Match('\''); 
            		// ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:195:5: ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )*
            		do 
            		{
            		    int alt4 = 3;
            		    int LA4_0 = input.LA(1);

            		    if ( (LA4_0 == '\'') )
            		    {
            		        int LA4_1 = input.LA(2);

            		        if ( (LA4_1 == '\'') )
            		        {
            		            alt4 = 2;
            		        }


            		    }
            		    else if ( ((LA4_0 >= '\u0000' && LA4_0 <= '\t') || (LA4_0 >= '\u000B' && LA4_0 <= '\f') || (LA4_0 >= '\u000E' && LA4_0 <= '&') || (LA4_0 >= '(' && LA4_0 <= '\uFFFF')) )
            		    {
            		        alt4 = 1;
            		    }


            		    switch (alt4) 
            			{
            				case 1 :
            				    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:196:31: ~ ( '\\'' | '\\r' | '\\n' )
            				    {
            				    	if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '\t') || (input.LA(1) >= '\u000B' && input.LA(1) <= '\f') || (input.LA(1) >= '\u000E' && input.LA(1) <= '&') || (input.LA(1) >= '(' && input.LA(1) <= '\uFFFF') ) 
            				    	{
            				    	    input.Consume();

            				    	}
            				    	else 
            				    	{
            				    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            				    	    Recover(mse);
            				    	    throw mse;}


            				    }
            				    break;
            				case 2 :
            				    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:196:56: '\\'' '\\''
            				    {
            				    	Match('\''); 
            				    	Match('\''); 

            				    }
            				    break;

            				default:
            				    goto loop4;
            		    }
            		} while (true);

            		loop4:
            			;	// Stops C# compiler whining that label 'loop4' has no statements

            		Match('\''); 

            	}


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_STRING"

    // $ANTLR start "T_INTEGER"
    public void mT_INTEGER() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_INTEGER;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:200:10: ( ( '0' .. '9' )+ )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:200:12: ( '0' .. '9' )+
            {
            	// ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:200:12: ( '0' .. '9' )+
            	int cnt5 = 0;
            	do 
            	{
            	    int alt5 = 2;
            	    int LA5_0 = input.LA(1);

            	    if ( ((LA5_0 >= '0' && LA5_0 <= '9')) )
            	    {
            	        alt5 = 1;
            	    }


            	    switch (alt5) 
            		{
            			case 1 :
            			    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:200:13: '0' .. '9'
            			    {
            			    	MatchRange('0','9'); 

            			    }
            			    break;

            			default:
            			    if ( cnt5 >= 1 ) goto loop5;
            		            EarlyExitException eee5 =
            		                new EarlyExitException(5, input);
            		            throw eee5;
            	    }
            	    cnt5++;
            	} while (true);

            	loop5:
            		;	// Stops C# compiler whining that label 'loop5' has no statements


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_INTEGER"

    // $ANTLR start "FLOAT_EXP"
    public void mFLOAT_EXP() // throws RecognitionException [2]
    {
    		try
    		{
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:201:20: ( ( 'e' | 'E' ) ( '+' | '-' )? ( '0' .. '9' )+ )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:201:22: ( 'e' | 'E' ) ( '+' | '-' )? ( '0' .. '9' )+
            {
            	if ( input.LA(1) == 'E' || input.LA(1) == 'e' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}

            	// ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:201:32: ( '+' | '-' )?
            	int alt6 = 2;
            	int LA6_0 = input.LA(1);

            	if ( (LA6_0 == '+' || LA6_0 == '-') )
            	{
            	    alt6 = 1;
            	}
            	switch (alt6) 
            	{
            	    case 1 :
            	        // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:
            	        {
            	        	if ( input.LA(1) == '+' || input.LA(1) == '-' ) 
            	        	{
            	        	    input.Consume();

            	        	}
            	        	else 
            	        	{
            	        	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	        	    Recover(mse);
            	        	    throw mse;}


            	        }
            	        break;

            	}

            	// ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:201:43: ( '0' .. '9' )+
            	int cnt7 = 0;
            	do 
            	{
            	    int alt7 = 2;
            	    int LA7_0 = input.LA(1);

            	    if ( ((LA7_0 >= '0' && LA7_0 <= '9')) )
            	    {
            	        alt7 = 1;
            	    }


            	    switch (alt7) 
            		{
            			case 1 :
            			    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:201:44: '0' .. '9'
            			    {
            			    	MatchRange('0','9'); 

            			    }
            			    break;

            			default:
            			    if ( cnt7 >= 1 ) goto loop7;
            		            EarlyExitException eee7 =
            		                new EarlyExitException(7, input);
            		            throw eee7;
            	    }
            	    cnt7++;
            	} while (true);

            	loop7:
            		;	// Stops C# compiler whining that label 'loop7' has no statements


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "FLOAT_EXP"

    // $ANTLR start "T_FLOAT"
    public void mT_FLOAT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_FLOAT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:203:5: ( ( '0' .. '9' )+ '.' ( '0' .. '9' )* ( FLOAT_EXP )? | '.' ( '0' .. '9' )+ ( FLOAT_EXP )? | ( '0' .. '9' )+ FLOAT_EXP )
            int alt14 = 3;
            alt14 = dfa14.Predict(input);
            switch (alt14) 
            {
                case 1 :
                    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:203:9: ( '0' .. '9' )+ '.' ( '0' .. '9' )* ( FLOAT_EXP )?
                    {
                    	// ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:203:9: ( '0' .. '9' )+
                    	int cnt8 = 0;
                    	do 
                    	{
                    	    int alt8 = 2;
                    	    int LA8_0 = input.LA(1);

                    	    if ( ((LA8_0 >= '0' && LA8_0 <= '9')) )
                    	    {
                    	        alt8 = 1;
                    	    }


                    	    switch (alt8) 
                    		{
                    			case 1 :
                    			    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:203:10: '0' .. '9'
                    			    {
                    			    	MatchRange('0','9'); 

                    			    }
                    			    break;

                    			default:
                    			    if ( cnt8 >= 1 ) goto loop8;
                    		            EarlyExitException eee8 =
                    		                new EarlyExitException(8, input);
                    		            throw eee8;
                    	    }
                    	    cnt8++;
                    	} while (true);

                    	loop8:
                    		;	// Stops C# compiler whining that label 'loop8' has no statements

                    	Match('.'); 
                    	// ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:203:25: ( '0' .. '9' )*
                    	do 
                    	{
                    	    int alt9 = 2;
                    	    int LA9_0 = input.LA(1);

                    	    if ( ((LA9_0 >= '0' && LA9_0 <= '9')) )
                    	    {
                    	        alt9 = 1;
                    	    }


                    	    switch (alt9) 
                    		{
                    			case 1 :
                    			    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:203:26: '0' .. '9'
                    			    {
                    			    	MatchRange('0','9'); 

                    			    }
                    			    break;

                    			default:
                    			    goto loop9;
                    	    }
                    	} while (true);

                    	loop9:
                    		;	// Stops C# compiler whining that label 'loop9' has no statements

                    	// ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:203:37: ( FLOAT_EXP )?
                    	int alt10 = 2;
                    	int LA10_0 = input.LA(1);

                    	if ( (LA10_0 == 'E' || LA10_0 == 'e') )
                    	{
                    	    alt10 = 1;
                    	}
                    	switch (alt10) 
                    	{
                    	    case 1 :
                    	        // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:203:37: FLOAT_EXP
                    	        {
                    	        	mFLOAT_EXP(); 

                    	        }
                    	        break;

                    	}


                    }
                    break;
                case 2 :
                    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:204:9: '.' ( '0' .. '9' )+ ( FLOAT_EXP )?
                    {
                    	Match('.'); 
                    	// ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:204:13: ( '0' .. '9' )+
                    	int cnt11 = 0;
                    	do 
                    	{
                    	    int alt11 = 2;
                    	    int LA11_0 = input.LA(1);

                    	    if ( ((LA11_0 >= '0' && LA11_0 <= '9')) )
                    	    {
                    	        alt11 = 1;
                    	    }


                    	    switch (alt11) 
                    		{
                    			case 1 :
                    			    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:204:14: '0' .. '9'
                    			    {
                    			    	MatchRange('0','9'); 

                    			    }
                    			    break;

                    			default:
                    			    if ( cnt11 >= 1 ) goto loop11;
                    		            EarlyExitException eee11 =
                    		                new EarlyExitException(11, input);
                    		            throw eee11;
                    	    }
                    	    cnt11++;
                    	} while (true);

                    	loop11:
                    		;	// Stops C# compiler whining that label 'loop11' has no statements

                    	// ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:204:25: ( FLOAT_EXP )?
                    	int alt12 = 2;
                    	int LA12_0 = input.LA(1);

                    	if ( (LA12_0 == 'E' || LA12_0 == 'e') )
                    	{
                    	    alt12 = 1;
                    	}
                    	switch (alt12) 
                    	{
                    	    case 1 :
                    	        // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:204:25: FLOAT_EXP
                    	        {
                    	        	mFLOAT_EXP(); 

                    	        }
                    	        break;

                    	}


                    }
                    break;
                case 3 :
                    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:205:9: ( '0' .. '9' )+ FLOAT_EXP
                    {
                    	// ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:205:9: ( '0' .. '9' )+
                    	int cnt13 = 0;
                    	do 
                    	{
                    	    int alt13 = 2;
                    	    int LA13_0 = input.LA(1);

                    	    if ( ((LA13_0 >= '0' && LA13_0 <= '9')) )
                    	    {
                    	        alt13 = 1;
                    	    }


                    	    switch (alt13) 
                    		{
                    			case 1 :
                    			    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:205:10: '0' .. '9'
                    			    {
                    			    	MatchRange('0','9'); 

                    			    }
                    			    break;

                    			default:
                    			    if ( cnt13 >= 1 ) goto loop13;
                    		            EarlyExitException eee13 =
                    		                new EarlyExitException(13, input);
                    		            throw eee13;
                    	    }
                    	    cnt13++;
                    	} while (true);

                    	loop13:
                    		;	// Stops C# compiler whining that label 'loop13' has no statements

                    	mFLOAT_EXP(); 

                    }
                    break;

            }
            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_FLOAT"

    // $ANTLR start "T_BLOB"
    public void mT_BLOB() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_BLOB;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:207:7: ( ( 'x' | 'X' ) '\\'' ( '0' .. '9' | 'a' .. 'f' | 'A' .. 'F' )+ '\\'' )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:207:9: ( 'x' | 'X' ) '\\'' ( '0' .. '9' | 'a' .. 'f' | 'A' .. 'F' )+ '\\''
            {
            	if ( input.LA(1) == 'X' || input.LA(1) == 'x' ) 
            	{
            	    input.Consume();

            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    Recover(mse);
            	    throw mse;}

            	Match('\''); 
            	// ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:207:24: ( '0' .. '9' | 'a' .. 'f' | 'A' .. 'F' )+
            	int cnt15 = 0;
            	do 
            	{
            	    int alt15 = 2;
            	    int LA15_0 = input.LA(1);

            	    if ( ((LA15_0 >= '0' && LA15_0 <= '9') || (LA15_0 >= 'A' && LA15_0 <= 'F') || (LA15_0 >= 'a' && LA15_0 <= 'f')) )
            	    {
            	        alt15 = 1;
            	    }


            	    switch (alt15) 
            		{
            			case 1 :
            			    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:
            			    {
            			    	if ( (input.LA(1) >= '0' && input.LA(1) <= '9') || (input.LA(1) >= 'A' && input.LA(1) <= 'F') || (input.LA(1) >= 'a' && input.LA(1) <= 'f') ) 
            			    	{
            			    	    input.Consume();

            			    	}
            			    	else 
            			    	{
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    Recover(mse);
            			    	    throw mse;}


            			    }
            			    break;

            			default:
            			    if ( cnt15 >= 1 ) goto loop15;
            		            EarlyExitException eee15 =
            		                new EarlyExitException(15, input);
            		            throw eee15;
            	    }
            	    cnt15++;
            	} while (true);

            	loop15:
            		;	// Stops C# compiler whining that label 'loop15' has no statements

            	Match('\''); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_BLOB"

    // $ANTLR start "T_BINARYNUM"
    public void mT_BINARYNUM() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_BINARYNUM;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:209:13: ( ( '0' 'b' ( '0' | '1' )+ ) | 'b' '\\'' ( '0' | '1' )+ '\\'' )
            int alt18 = 2;
            int LA18_0 = input.LA(1);

            if ( (LA18_0 == '0') )
            {
                alt18 = 1;
            }
            else if ( (LA18_0 == 'b') )
            {
                alt18 = 2;
            }
            else 
            {
                NoViableAltException nvae_d18s0 =
                    new NoViableAltException("", 18, 0, input);

                throw nvae_d18s0;
            }
            switch (alt18) 
            {
                case 1 :
                    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:209:15: ( '0' 'b' ( '0' | '1' )+ )
                    {
                    	// ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:209:15: ( '0' 'b' ( '0' | '1' )+ )
                    	// ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:209:16: '0' 'b' ( '0' | '1' )+
                    	{
                    		Match('0'); 
                    		Match('b'); 
                    		// ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:209:24: ( '0' | '1' )+
                    		int cnt16 = 0;
                    		do 
                    		{
                    		    int alt16 = 2;
                    		    int LA16_0 = input.LA(1);

                    		    if ( ((LA16_0 >= '0' && LA16_0 <= '1')) )
                    		    {
                    		        alt16 = 1;
                    		    }


                    		    switch (alt16) 
                    			{
                    				case 1 :
                    				    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:
                    				    {
                    				    	if ( (input.LA(1) >= '0' && input.LA(1) <= '1') ) 
                    				    	{
                    				    	    input.Consume();

                    				    	}
                    				    	else 
                    				    	{
                    				    	    MismatchedSetException mse = new MismatchedSetException(null,input);
                    				    	    Recover(mse);
                    				    	    throw mse;}


                    				    }
                    				    break;

                    				default:
                    				    if ( cnt16 >= 1 ) goto loop16;
                    			            EarlyExitException eee16 =
                    			                new EarlyExitException(16, input);
                    			            throw eee16;
                    		    }
                    		    cnt16++;
                    		} while (true);

                    		loop16:
                    			;	// Stops C# compiler whining that label 'loop16' has no statements


                    	}


                    }
                    break;
                case 2 :
                    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:209:41: 'b' '\\'' ( '0' | '1' )+ '\\''
                    {
                    	Match('b'); 
                    	Match('\''); 
                    	// ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:209:50: ( '0' | '1' )+
                    	int cnt17 = 0;
                    	do 
                    	{
                    	    int alt17 = 2;
                    	    int LA17_0 = input.LA(1);

                    	    if ( ((LA17_0 >= '0' && LA17_0 <= '1')) )
                    	    {
                    	        alt17 = 1;
                    	    }


                    	    switch (alt17) 
                    		{
                    			case 1 :
                    			    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:
                    			    {
                    			    	if ( (input.LA(1) >= '0' && input.LA(1) <= '1') ) 
                    			    	{
                    			    	    input.Consume();

                    			    	}
                    			    	else 
                    			    	{
                    			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
                    			    	    Recover(mse);
                    			    	    throw mse;}


                    			    }
                    			    break;

                    			default:
                    			    if ( cnt17 >= 1 ) goto loop17;
                    		            EarlyExitException eee17 =
                    		                new EarlyExitException(17, input);
                    		            throw eee17;
                    	    }
                    	    cnt17++;
                    	} while (true);

                    	loop17:
                    		;	// Stops C# compiler whining that label 'loop17' has no statements

                    	Match('\''); 

                    }
                    break;

            }
            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_BINARYNUM"

    // $ANTLR start "T_COMMENT"
    public void mT_COMMENT() // throws RecognitionException [2]
    {
    		try
    		{
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:211:19: ( '/*' ( options {greedy=false; } : . )* '*/' )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:211:21: '/*' ( options {greedy=false; } : . )* '*/'
            {
            	Match("/*"); 

            	// ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:211:26: ( options {greedy=false; } : . )*
            	do 
            	{
            	    int alt19 = 2;
            	    int LA19_0 = input.LA(1);

            	    if ( (LA19_0 == '*') )
            	    {
            	        int LA19_1 = input.LA(2);

            	        if ( (LA19_1 == '/') )
            	        {
            	            alt19 = 2;
            	        }
            	        else if ( ((LA19_1 >= '\u0000' && LA19_1 <= '.') || (LA19_1 >= '0' && LA19_1 <= '\uFFFF')) )
            	        {
            	            alt19 = 1;
            	        }


            	    }
            	    else if ( ((LA19_0 >= '\u0000' && LA19_0 <= ')') || (LA19_0 >= '+' && LA19_0 <= '\uFFFF')) )
            	    {
            	        alt19 = 1;
            	    }


            	    switch (alt19) 
            		{
            			case 1 :
            			    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:211:54: .
            			    {
            			    	MatchAny(); 

            			    }
            			    break;

            			default:
            			    goto loop19;
            	    }
            	} while (true);

            	loop19:
            		;	// Stops C# compiler whining that label 'loop19' has no statements

            	Match("*/"); 


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_COMMENT"

    // $ANTLR start "LINE_COMMENT"
    public void mLINE_COMMENT() // throws RecognitionException [2]
    {
    		try
    		{
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:212:22: ( '--' (~ ( '\\n' | '\\r' ) )* ( ( '\\r' )? '\\n' | EOF ) )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:212:24: '--' (~ ( '\\n' | '\\r' ) )* ( ( '\\r' )? '\\n' | EOF )
            {
            	Match("--"); 

            	// ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:212:29: (~ ( '\\n' | '\\r' ) )*
            	do 
            	{
            	    int alt20 = 2;
            	    int LA20_0 = input.LA(1);

            	    if ( ((LA20_0 >= '\u0000' && LA20_0 <= '\t') || (LA20_0 >= '\u000B' && LA20_0 <= '\f') || (LA20_0 >= '\u000E' && LA20_0 <= '\uFFFF')) )
            	    {
            	        alt20 = 1;
            	    }


            	    switch (alt20) 
            		{
            			case 1 :
            			    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:212:29: ~ ( '\\n' | '\\r' )
            			    {
            			    	if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '\t') || (input.LA(1) >= '\u000B' && input.LA(1) <= '\f') || (input.LA(1) >= '\u000E' && input.LA(1) <= '\uFFFF') ) 
            			    	{
            			    	    input.Consume();

            			    	}
            			    	else 
            			    	{
            			    	    MismatchedSetException mse = new MismatchedSetException(null,input);
            			    	    Recover(mse);
            			    	    throw mse;}


            			    }
            			    break;

            			default:
            			    goto loop20;
            	    }
            	} while (true);

            	loop20:
            		;	// Stops C# compiler whining that label 'loop20' has no statements

            	// ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:212:43: ( ( '\\r' )? '\\n' | EOF )
            	int alt22 = 2;
            	int LA22_0 = input.LA(1);

            	if ( (LA22_0 == '\n' || LA22_0 == '\r') )
            	{
            	    alt22 = 1;
            	}
            	else 
            	{
            	    alt22 = 2;}
            	switch (alt22) 
            	{
            	    case 1 :
            	        // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:212:44: ( '\\r' )? '\\n'
            	        {
            	        	// ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:212:44: ( '\\r' )?
            	        	int alt21 = 2;
            	        	int LA21_0 = input.LA(1);

            	        	if ( (LA21_0 == '\r') )
            	        	{
            	        	    alt21 = 1;
            	        	}
            	        	switch (alt21) 
            	        	{
            	        	    case 1 :
            	        	        // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:212:44: '\\r'
            	        	        {
            	        	        	Match('\r'); 

            	        	        }
            	        	        break;

            	        	}

            	        	Match('\n'); 

            	        }
            	        break;
            	    case 2 :
            	        // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:212:55: EOF
            	        {
            	        	Match(EOF); 

            	        }
            	        break;

            	}


            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "LINE_COMMENT"

    // $ANTLR start "WHITESPACE"
    public void mWHITESPACE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = WHITESPACE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:214:11: ( ( ' ' | '\\r' | '\\t' | '\\u000C' | '\\n' | T_COMMENT | LINE_COMMENT ) )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:214:13: ( ' ' | '\\r' | '\\t' | '\\u000C' | '\\n' | T_COMMENT | LINE_COMMENT )
            {
            	// ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:214:13: ( ' ' | '\\r' | '\\t' | '\\u000C' | '\\n' | T_COMMENT | LINE_COMMENT )
            	int alt23 = 7;
            	switch ( input.LA(1) ) 
            	{
            	case ' ':
            		{
            	    alt23 = 1;
            	    }
            	    break;
            	case '\r':
            		{
            	    alt23 = 2;
            	    }
            	    break;
            	case '\t':
            		{
            	    alt23 = 3;
            	    }
            	    break;
            	case '\f':
            		{
            	    alt23 = 4;
            	    }
            	    break;
            	case '\n':
            		{
            	    alt23 = 5;
            	    }
            	    break;
            	case '/':
            		{
            	    alt23 = 6;
            	    }
            	    break;
            	case '-':
            		{
            	    alt23 = 7;
            	    }
            	    break;
            		default:
            		    NoViableAltException nvae_d23s0 =
            		        new NoViableAltException("", 23, 0, input);

            		    throw nvae_d23s0;
            	}

            	switch (alt23) 
            	{
            	    case 1 :
            	        // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:214:14: ' '
            	        {
            	        	Match(' '); 

            	        }
            	        break;
            	    case 2 :
            	        // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:214:18: '\\r'
            	        {
            	        	Match('\r'); 

            	        }
            	        break;
            	    case 3 :
            	        // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:214:23: '\\t'
            	        {
            	        	Match('\t'); 

            	        }
            	        break;
            	    case 4 :
            	        // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:214:28: '\\u000C'
            	        {
            	        	Match('\f'); 

            	        }
            	        break;
            	    case 5 :
            	        // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:214:37: '\\n'
            	        {
            	        	Match('\n'); 

            	        }
            	        break;
            	    case 6 :
            	        // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:214:42: T_COMMENT
            	        {
            	        	mT_COMMENT(); 

            	        }
            	        break;
            	    case 7 :
            	        // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:214:52: LINE_COMMENT
            	        {
            	        	mLINE_COMMENT(); 

            	        }
            	        break;

            	}

            	_channel=HIDDEN;

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "WHITESPACE"

    override public void mTokens() // throws RecognitionException 
    {
        // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:8: ( EQUALS | SAFEEQUALS | EQUALS2 | NOT_EQUALS | NOT_EQUALS2 | LESS | LESS_OR_EQ | GREATER | GREATER_OR_EQ | SHIFT_LEFT | SHIFT_RIGHT | AMPERSAND | DOUBLE_AMPERSAND | PIPE | DOUBLE_PIPE | PLUS | MINUS | TILDA | ASTERISK | SLASH | PERCENT | SEMI | DOT | COMMA | LPAREN | RPAREN | QUESTION | EXCLAMATION | COLON | AT | DOLLAR | ARROW_UP | ADD | ALTER | AND | AS | ASC | BEGIN | BETWEEN | BY | CASCADE | CASE | CAST | CHECK | COLLATE | COLUMN | COMMIT | CONFLICT | CONSTRAINT | CREATE | CROSS | CURRENT_TIME | CURRENT_DATE | CURRENT_TIMESTAMP | UTC_TIMESTAMP | DATABASE | DEFAULT | DELETE | DESC | DISTINCT | DROP | ELSE | END | ESCAPE | EXCEPT | EXCLUSIVE | EXISTS | EXPLAIN | FOR | FOREIGN | FROM | GROUP | HAVING | IF | IN | INDEX | INNER | INSERT | INTERSECT | INTO | IS | JOIN | KEY | LEFT | LIKE | NOT | NULL | OF | ON | OR | ORDER | OUTER | PRIMARY | REFERENCES | ROLLBACK | SELECT | SET | TABLE | TEMPORARY | TEMP | THEN | TO | TRANSACTION | TRIGGER | UNION | UNIQUE | UPDATE | VALUES | VIEW | WHEN | WHERE | WITH | PARSER | XOR | T_IDENT | T_QUOTED_IDENT | T_NSTRING | T_STRING | T_INTEGER | T_FLOAT | T_BLOB | T_BINARYNUM | WHITESPACE )
        int alt24 = 123;
        alt24 = dfa24.Predict(input);
        switch (alt24) 
        {
            case 1 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:10: EQUALS
                {
                	mEQUALS(); 

                }
                break;
            case 2 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:17: SAFEEQUALS
                {
                	mSAFEEQUALS(); 

                }
                break;
            case 3 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:28: EQUALS2
                {
                	mEQUALS2(); 

                }
                break;
            case 4 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:36: NOT_EQUALS
                {
                	mNOT_EQUALS(); 

                }
                break;
            case 5 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:47: NOT_EQUALS2
                {
                	mNOT_EQUALS2(); 

                }
                break;
            case 6 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:59: LESS
                {
                	mLESS(); 

                }
                break;
            case 7 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:64: LESS_OR_EQ
                {
                	mLESS_OR_EQ(); 

                }
                break;
            case 8 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:75: GREATER
                {
                	mGREATER(); 

                }
                break;
            case 9 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:83: GREATER_OR_EQ
                {
                	mGREATER_OR_EQ(); 

                }
                break;
            case 10 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:97: SHIFT_LEFT
                {
                	mSHIFT_LEFT(); 

                }
                break;
            case 11 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:108: SHIFT_RIGHT
                {
                	mSHIFT_RIGHT(); 

                }
                break;
            case 12 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:120: AMPERSAND
                {
                	mAMPERSAND(); 

                }
                break;
            case 13 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:130: DOUBLE_AMPERSAND
                {
                	mDOUBLE_AMPERSAND(); 

                }
                break;
            case 14 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:147: PIPE
                {
                	mPIPE(); 

                }
                break;
            case 15 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:152: DOUBLE_PIPE
                {
                	mDOUBLE_PIPE(); 

                }
                break;
            case 16 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:164: PLUS
                {
                	mPLUS(); 

                }
                break;
            case 17 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:169: MINUS
                {
                	mMINUS(); 

                }
                break;
            case 18 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:175: TILDA
                {
                	mTILDA(); 

                }
                break;
            case 19 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:181: ASTERISK
                {
                	mASTERISK(); 

                }
                break;
            case 20 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:190: SLASH
                {
                	mSLASH(); 

                }
                break;
            case 21 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:196: PERCENT
                {
                	mPERCENT(); 

                }
                break;
            case 22 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:204: SEMI
                {
                	mSEMI(); 

                }
                break;
            case 23 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:209: DOT
                {
                	mDOT(); 

                }
                break;
            case 24 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:213: COMMA
                {
                	mCOMMA(); 

                }
                break;
            case 25 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:219: LPAREN
                {
                	mLPAREN(); 

                }
                break;
            case 26 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:226: RPAREN
                {
                	mRPAREN(); 

                }
                break;
            case 27 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:233: QUESTION
                {
                	mQUESTION(); 

                }
                break;
            case 28 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:242: EXCLAMATION
                {
                	mEXCLAMATION(); 

                }
                break;
            case 29 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:254: COLON
                {
                	mCOLON(); 

                }
                break;
            case 30 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:260: AT
                {
                	mAT(); 

                }
                break;
            case 31 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:263: DOLLAR
                {
                	mDOLLAR(); 

                }
                break;
            case 32 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:270: ARROW_UP
                {
                	mARROW_UP(); 

                }
                break;
            case 33 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:279: ADD
                {
                	mADD(); 

                }
                break;
            case 34 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:283: ALTER
                {
                	mALTER(); 

                }
                break;
            case 35 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:289: AND
                {
                	mAND(); 

                }
                break;
            case 36 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:293: AS
                {
                	mAS(); 

                }
                break;
            case 37 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:296: ASC
                {
                	mASC(); 

                }
                break;
            case 38 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:300: BEGIN
                {
                	mBEGIN(); 

                }
                break;
            case 39 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:306: BETWEEN
                {
                	mBETWEEN(); 

                }
                break;
            case 40 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:314: BY
                {
                	mBY(); 

                }
                break;
            case 41 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:317: CASCADE
                {
                	mCASCADE(); 

                }
                break;
            case 42 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:325: CASE
                {
                	mCASE(); 

                }
                break;
            case 43 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:330: CAST
                {
                	mCAST(); 

                }
                break;
            case 44 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:335: CHECK
                {
                	mCHECK(); 

                }
                break;
            case 45 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:341: COLLATE
                {
                	mCOLLATE(); 

                }
                break;
            case 46 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:349: COLUMN
                {
                	mCOLUMN(); 

                }
                break;
            case 47 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:356: COMMIT
                {
                	mCOMMIT(); 

                }
                break;
            case 48 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:363: CONFLICT
                {
                	mCONFLICT(); 

                }
                break;
            case 49 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:372: CONSTRAINT
                {
                	mCONSTRAINT(); 

                }
                break;
            case 50 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:383: CREATE
                {
                	mCREATE(); 

                }
                break;
            case 51 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:390: CROSS
                {
                	mCROSS(); 

                }
                break;
            case 52 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:396: CURRENT_TIME
                {
                	mCURRENT_TIME(); 

                }
                break;
            case 53 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:409: CURRENT_DATE
                {
                	mCURRENT_DATE(); 

                }
                break;
            case 54 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:422: CURRENT_TIMESTAMP
                {
                	mCURRENT_TIMESTAMP(); 

                }
                break;
            case 55 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:440: UTC_TIMESTAMP
                {
                	mUTC_TIMESTAMP(); 

                }
                break;
            case 56 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:454: DATABASE
                {
                	mDATABASE(); 

                }
                break;
            case 57 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:463: DEFAULT
                {
                	mDEFAULT(); 

                }
                break;
            case 58 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:471: DELETE
                {
                	mDELETE(); 

                }
                break;
            case 59 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:478: DESC
                {
                	mDESC(); 

                }
                break;
            case 60 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:483: DISTINCT
                {
                	mDISTINCT(); 

                }
                break;
            case 61 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:492: DROP
                {
                	mDROP(); 

                }
                break;
            case 62 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:497: ELSE
                {
                	mELSE(); 

                }
                break;
            case 63 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:502: END
                {
                	mEND(); 

                }
                break;
            case 64 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:506: ESCAPE
                {
                	mESCAPE(); 

                }
                break;
            case 65 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:513: EXCEPT
                {
                	mEXCEPT(); 

                }
                break;
            case 66 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:520: EXCLUSIVE
                {
                	mEXCLUSIVE(); 

                }
                break;
            case 67 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:530: EXISTS
                {
                	mEXISTS(); 

                }
                break;
            case 68 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:537: EXPLAIN
                {
                	mEXPLAIN(); 

                }
                break;
            case 69 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:545: FOR
                {
                	mFOR(); 

                }
                break;
            case 70 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:549: FOREIGN
                {
                	mFOREIGN(); 

                }
                break;
            case 71 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:557: FROM
                {
                	mFROM(); 

                }
                break;
            case 72 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:562: GROUP
                {
                	mGROUP(); 

                }
                break;
            case 73 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:568: HAVING
                {
                	mHAVING(); 

                }
                break;
            case 74 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:575: IF
                {
                	mIF(); 

                }
                break;
            case 75 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:578: IN
                {
                	mIN(); 

                }
                break;
            case 76 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:581: INDEX
                {
                	mINDEX(); 

                }
                break;
            case 77 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:587: INNER
                {
                	mINNER(); 

                }
                break;
            case 78 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:593: INSERT
                {
                	mINSERT(); 

                }
                break;
            case 79 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:600: INTERSECT
                {
                	mINTERSECT(); 

                }
                break;
            case 80 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:610: INTO
                {
                	mINTO(); 

                }
                break;
            case 81 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:615: IS
                {
                	mIS(); 

                }
                break;
            case 82 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:618: JOIN
                {
                	mJOIN(); 

                }
                break;
            case 83 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:623: KEY
                {
                	mKEY(); 

                }
                break;
            case 84 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:627: LEFT
                {
                	mLEFT(); 

                }
                break;
            case 85 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:632: LIKE
                {
                	mLIKE(); 

                }
                break;
            case 86 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:637: NOT
                {
                	mNOT(); 

                }
                break;
            case 87 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:641: NULL
                {
                	mNULL(); 

                }
                break;
            case 88 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:646: OF
                {
                	mOF(); 

                }
                break;
            case 89 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:649: ON
                {
                	mON(); 

                }
                break;
            case 90 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:652: OR
                {
                	mOR(); 

                }
                break;
            case 91 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:655: ORDER
                {
                	mORDER(); 

                }
                break;
            case 92 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:661: OUTER
                {
                	mOUTER(); 

                }
                break;
            case 93 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:667: PRIMARY
                {
                	mPRIMARY(); 

                }
                break;
            case 94 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:675: REFERENCES
                {
                	mREFERENCES(); 

                }
                break;
            case 95 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:686: ROLLBACK
                {
                	mROLLBACK(); 

                }
                break;
            case 96 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:695: SELECT
                {
                	mSELECT(); 

                }
                break;
            case 97 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:702: SET
                {
                	mSET(); 

                }
                break;
            case 98 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:706: TABLE
                {
                	mTABLE(); 

                }
                break;
            case 99 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:712: TEMPORARY
                {
                	mTEMPORARY(); 

                }
                break;
            case 100 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:722: TEMP
                {
                	mTEMP(); 

                }
                break;
            case 101 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:727: THEN
                {
                	mTHEN(); 

                }
                break;
            case 102 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:732: TO
                {
                	mTO(); 

                }
                break;
            case 103 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:735: TRANSACTION
                {
                	mTRANSACTION(); 

                }
                break;
            case 104 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:747: TRIGGER
                {
                	mTRIGGER(); 

                }
                break;
            case 105 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:755: UNION
                {
                	mUNION(); 

                }
                break;
            case 106 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:761: UNIQUE
                {
                	mUNIQUE(); 

                }
                break;
            case 107 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:768: UPDATE
                {
                	mUPDATE(); 

                }
                break;
            case 108 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:775: VALUES
                {
                	mVALUES(); 

                }
                break;
            case 109 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:782: VIEW
                {
                	mVIEW(); 

                }
                break;
            case 110 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:787: WHEN
                {
                	mWHEN(); 

                }
                break;
            case 111 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:792: WHERE
                {
                	mWHERE(); 

                }
                break;
            case 112 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:798: WITH
                {
                	mWITH(); 

                }
                break;
            case 113 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:803: PARSER
                {
                	mPARSER(); 

                }
                break;
            case 114 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:810: XOR
                {
                	mXOR(); 

                }
                break;
            case 115 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:814: T_IDENT
                {
                	mT_IDENT(); 

                }
                break;
            case 116 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:822: T_QUOTED_IDENT
                {
                	mT_QUOTED_IDENT(); 

                }
                break;
            case 117 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:837: T_NSTRING
                {
                	mT_NSTRING(); 

                }
                break;
            case 118 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:847: T_STRING
                {
                	mT_STRING(); 

                }
                break;
            case 119 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:856: T_INTEGER
                {
                	mT_INTEGER(); 

                }
                break;
            case 120 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:866: T_FLOAT
                {
                	mT_FLOAT(); 

                }
                break;
            case 121 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:874: T_BLOB
                {
                	mT_BLOB(); 

                }
                break;
            case 122 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:881: T_BINARYNUM
                {
                	mT_BINARYNUM(); 

                }
                break;
            case 123 :
                // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:1:893: WHITESPACE
                {
                	mWHITESPACE(); 

                }
                break;

        }

    }


    protected DFA14 dfa14;
    protected DFA24 dfa24;
	private void InitializeCyclicDFAs()
	{
	    this.dfa14 = new DFA14(this);
	    this.dfa24 = new DFA24(this);
	}

    const string DFA14_eotS =
        "\x05\uffff";
    const string DFA14_eofS =
        "\x05\uffff";
    const string DFA14_minS =
        "\x02\x2e\x03\uffff";
    const string DFA14_maxS =
        "\x01\x39\x01\x65\x03\uffff";
    const string DFA14_acceptS =
        "\x02\uffff\x01\x02\x01\x03\x01\x01";
    const string DFA14_specialS =
        "\x05\uffff}>";
    static readonly string[] DFA14_transitionS = {
            "\x01\x02\x01\uffff\x0a\x01",
            "\x01\x04\x01\uffff\x0a\x01\x0b\uffff\x01\x03\x1f\uffff\x01"+
            "\x03",
            "",
            "",
            ""
    };

    static readonly short[] DFA14_eot = DFA.UnpackEncodedString(DFA14_eotS);
    static readonly short[] DFA14_eof = DFA.UnpackEncodedString(DFA14_eofS);
    static readonly char[] DFA14_min = DFA.UnpackEncodedStringToUnsignedChars(DFA14_minS);
    static readonly char[] DFA14_max = DFA.UnpackEncodedStringToUnsignedChars(DFA14_maxS);
    static readonly short[] DFA14_accept = DFA.UnpackEncodedString(DFA14_acceptS);
    static readonly short[] DFA14_special = DFA.UnpackEncodedString(DFA14_specialS);
    static readonly short[][] DFA14_transition = DFA.UnpackEncodedStringArray(DFA14_transitionS);

    protected class DFA14 : DFA
    {
        public DFA14(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 14;
            this.eot = DFA14_eot;
            this.eof = DFA14_eof;
            this.min = DFA14_min;
            this.max = DFA14_max;
            this.accept = DFA14_accept;
            this.special = DFA14_special;
            this.transition = DFA14_transition;

        }

        override public string Description
        {
            get { return "202:1: T_FLOAT : ( ( '0' .. '9' )+ '.' ( '0' .. '9' )* ( FLOAT_EXP )? | '.' ( '0' .. '9' )+ ( FLOAT_EXP )? | ( '0' .. '9' )+ FLOAT_EXP );"; }
        }

    }

    const string DFA24_eotS =
        "\x01\uffff\x01\x35\x01\x39\x01\x3b\x01\x3e\x01\x40\x01\x42\x01"+
        "\uffff\x01\x43\x02\uffff\x01\x44\x02\uffff\x01\x45\x08\uffff\x16"+
        "\x2d\x03\uffff\x02\u0080\x01\x2d\x03\uffff\x01\u0082\x10\uffff\x01"+
        "\u0083\x03\x2d\x01\uffff\x01\x2d\x01\u008a\x14\x2d\x01\u00a6\x01"+
        "\u00a7\x01\u00ac\x05\x2d\x01\uffff\x01\x2d\x01\u00b3\x01\u00b5\x01"+
        "\x2d\x01\u00b7\x05\x2d\x01\u00be\x08\x2d\x01\uffff\x01\x2d\x04\uffff"+
        "\x01\u00c9\x01\u00ca\x01\x2d\x01\u00cc\x02\x2d\x01\uffff\x16\x2d"+
        "\x01\u00eb\x01\u00ec\x03\x2d\x02\uffff\x04\x2d\x01\uffff\x01\x2d"+
        "\x01\u00f7\x02\x2d\x01\u00fa\x01\x2d\x01\uffff\x01\x2d\x01\uffff"+
        "\x01\x2d\x01\uffff\x05\x2d\x01\u0103\x01\uffff\x09\x2d\x01\u010e"+
        "\x02\uffff\x01\x2d\x01\uffff\x03\x2d\x01\u0113\x01\x2d\x01\u0115"+
        "\x0d\x2d\x01\u0123\x01\x2d\x01\u0125\x02\x2d\x01\u0128\x05\x2d\x02"+
        "\uffff\x01\x2d\x01\u012f\x04\x2d\x01\u0134\x02\x2d\x01\u0137\x01"+
        "\uffff\x01\u0138\x01\u0139\x01\uffff\x01\u013a\x07\x2d\x01\uffff"+
        "\x02\x2d\x01\u0144\x01\x2d\x01\u0146\x01\x2d\x01\u0149\x01\u014a"+
        "\x01\u014b\x01\x2d\x01\uffff\x01\u014d\x01\u014e\x02\x2d\x01\uffff"+
        "\x01\x2d\x01\uffff\x01\u0152\x06\x2d\x01\u0159\x01\x2d\x01\u015b"+
        "\x03\x2d\x01\uffff\x01\x2d\x01\uffff\x02\x2d\x01\uffff\x06\x2d\x01"+
        "\uffff\x01\u0168\x01\x2d\x01\u016a\x01\x2d\x01\uffff\x01\x2d\x01"+
        "\u016d\x04\uffff\x01\u016e\x01\u016f\x07\x2d\x01\uffff\x01\u0177"+
        "\x01\uffff\x02\x2d\x03\uffff\x01\u017a\x02\uffff\x03\x2d\x01\uffff"+
        "\x03\x2d\x01\u0181\x01\u0182\x01\u0183\x01\uffff\x01\u0184\x01\uffff"+
        "\x01\u0185\x02\x2d\x01\u0188\x03\x2d\x01\u018c\x01\x2d\x01\u018e"+
        "\x01\u018f\x01\x2d\x01\uffff\x01\u0191\x01\uffff\x01\x2d\x01\u0193"+
        "\x03\uffff\x01\u0194\x03\x2d\x01\u0198\x02\x2d\x01\uffff\x01\x2d"+
        "\x01\u019c\x01\uffff\x01\u019d\x01\x2d\x01\u019f\x02\x2d\x01\u01a2"+
        "\x05\uffff\x02\x2d\x01\uffff\x01\u01a5\x01\x2d\x01\u01a7\x01\uffff"+
        "\x01\x2d\x02\uffff\x01\u01a9\x01\uffff\x01\x2d\x02\uffff\x01\u01ab"+
        "\x02\x2d\x01\uffff\x01\x2d\x01\u01af\x01\x2d\x02\uffff\x01\x2d\x01"+
        "\uffff\x01\x2d\x01\u01b4\x01\uffff\x01\x2d\x01\u01b6\x01\uffff\x01"+
        "\u01b7\x01\uffff\x01\x2d\x01\uffff\x01\x2d\x01\uffff\x01\x2d\x01"+
        "\u01bb\x01\x2d\x01\uffff\x04\x2d\x01\uffff\x01\x2d\x02\uffff\x01"+
        "\u01c2\x01\u01c3\x01\x2d\x01\uffff\x01\x2d\x01\u01c6\x02\x2d\x01"+
        "\u01c9\x01\x2d\x02\uffff\x01\u01cb\x01\x2d\x01\uffff\x02\x2d\x01"+
        "\uffff\x01\x2d\x01\uffff\x01\u01d0\x01\u01d1\x01\u01d3\x01\x2d\x02"+
        "\uffff\x01\x2d\x01\uffff\x01\u01d6\x01\x2d\x01\uffff\x02\x2d\x01"+
        "\u01da\x01\uffff";
    const string DFA24_eofS =
        "\u01db\uffff";
    const string DFA24_minS =
        "\x01\x09\x01\x3d\x01\x3c\x02\x3d\x01\x26\x01\x7c\x01\uffff\x01"+
        "\x2d\x02\uffff\x01\x2a\x02\uffff\x01\x30\x08\uffff\x01\x44\x01\x27"+
        "\x01\x41\x01\x4e\x01\x41\x01\x4c\x01\x4f\x01\x52\x01\x41\x01\x46"+
        "\x01\x4f\x02\x45\x01\x27\x01\x46\x01\x41\x02\x45\x02\x41\x01\x48"+
        "\x01\x27\x03\uffff\x02\x2e\x01\x45\x03\uffff\x01\x3e\x10\uffff\x01"+
        "\x30\x01\x44\x01\x54\x01\x44\x01\uffff\x01\x47\x01\x30\x01\x52\x01"+
        "\x53\x01\x45\x01\x4c\x01\x45\x01\x49\x01\x44\x01\x43\x01\x54\x01"+
        "\x4f\x01\x46\x02\x53\x02\x43\x01\x44\x01\x52\x02\x4f\x01\x56\x03"+
        "\x30\x01\x49\x01\x59\x01\x4b\x01\x46\x01\x54\x01\uffff\x01\x4c\x02"+
        "\x30\x01\x54\x01\x30\x01\x52\x01\x49\x01\x46\x02\x4c\x01\x30\x01"+
        "\x41\x01\x45\x01\x42\x01\x4d\x01\x4c\x01\x45\x01\x54\x01\x45\x01"+
        "\uffff\x01\x52\x04\uffff\x02\x30\x01\x45\x01\x30\x01\x49\x01\x57"+
        "\x01\uffff\x01\x52\x02\x43\x01\x46\x01\x4c\x01\x4d\x01\x41\x01\x53"+
        "\x01\x4f\x01\x41\x01\x5f\x01\x41\x01\x50\x01\x45\x01\x43\x01\x41"+
        "\x01\x54\x01\x45\x01\x4c\x01\x53\x01\x45\x01\x41\x02\x30\x01\x4d"+
        "\x01\x55\x01\x49\x02\uffff\x04\x45\x01\uffff\x01\x4e\x01\x30\x01"+
        "\x45\x01\x54\x01\x30\x01\x4c\x01\uffff\x01\x45\x01\uffff\x01\x45"+
        "\x01\uffff\x01\x53\x01\x4d\x01\x45\x01\x4c\x01\x45\x01\x30\x01\uffff"+
        "\x01\x4e\x01\x47\x01\x4e\x01\x4c\x01\x50\x01\x55\x01\x57\x01\x48"+
        "\x01\x4e\x01\x30\x02\uffff\x01\x52\x01\uffff\x01\x4e\x02\x45\x01"+
        "\x30\x01\x41\x01\x30\x01\x4b\x01\x54\x01\x4c\x01\x41\x01\x4d\x01"+
        "\x49\x01\x54\x01\x53\x01\x55\x01\x4e\x02\x54\x01\x42\x01\x30\x01"+
        "\x54\x01\x30\x01\x55\x01\x49\x01\x30\x01\x41\x01\x54\x01\x55\x02"+
        "\x50\x02\uffff\x01\x49\x01\x30\x01\x50\x01\x4e\x02\x52\x01\x30\x01"+
        "\x52\x01\x58\x01\x30\x01\uffff\x02\x30\x01\uffff\x01\x30\x02\x52"+
        "\x01\x45\x01\x41\x01\x52\x01\x42\x01\x43\x01\uffff\x01\x53\x01\x47"+
        "\x01\x30\x01\x45\x01\x30\x01\x45\x03\x30\x01\x45\x01\uffff\x02\x30"+
        "\x01\x45\x01\x4e\x01\uffff\x01\x44\x01\uffff\x01\x30\x01\x52\x01"+
        "\x49\x01\x54\x01\x4e\x01\x54\x01\x45\x01\x30\x01\x45\x01\x30\x01"+
        "\x45\x01\x49\x01\x41\x01\uffff\x01\x45\x01\uffff\x01\x4c\x01\x4e"+
        "\x01\uffff\x01\x49\x02\x53\x01\x54\x01\x45\x01\x47\x01\uffff\x01"+
        "\x30\x01\x47\x01\x30\x01\x53\x01\uffff\x01\x54\x01\x30\x04\uffff"+
        "\x02\x30\x02\x52\x01\x45\x01\x41\x01\x54\x01\x41\x01\x45\x01\uffff"+
        "\x01\x30\x01\uffff\x01\x52\x01\x53\x03\uffff\x01\x30\x02\uffff\x01"+
        "\x4e\x01\x54\x01\x45\x01\uffff\x01\x41\x01\x43\x01\x45\x03\x30\x01"+
        "\uffff\x01\x30\x01\uffff\x01\x30\x01\x4d\x01\x53\x01\x30\x01\x54"+
        "\x01\x43\x01\x4e\x01\x30\x01\x49\x02\x30\x01\x4e\x01\uffff\x01\x30"+
        "\x01\uffff\x01\x45\x01\x30\x03\uffff\x01\x30\x01\x59\x01\x4e\x01"+
        "\x43\x01\x30\x01\x43\x01\x52\x01\uffff\x01\x41\x01\x30\x01\uffff"+
        "\x01\x30\x01\x5f\x01\x30\x01\x49\x01\x54\x01\x30\x05\uffff\x02\x45"+
        "\x01\uffff\x01\x30\x01\x54\x01\x30\x01\uffff\x01\x56\x02\uffff\x01"+
        "\x30\x01\uffff\x01\x43\x02\uffff\x01\x30\x01\x43\x01\x4b\x01\uffff"+
        "\x01\x54\x01\x30\x01\x52\x02\uffff\x01\x44\x01\uffff\x01\x4e\x01"+
        "\x30\x01\uffff\x01\x53\x01\x30\x01\uffff\x01\x30\x01\uffff\x01\x45"+
        "\x01\uffff\x01\x54\x01\uffff\x01\x45\x01\x30\x01\x49\x01\uffff\x01"+
        "\x59\x01\x49\x01\x41\x01\x54\x01\uffff\x01\x54\x02\uffff\x02\x30"+
        "\x01\x53\x01\uffff\x01\x4f\x01\x30\x01\x4d\x01\x54\x01\x30\x01\x41"+
        "\x02\uffff\x01\x30\x01\x4e\x01\uffff\x02\x45\x01\uffff\x01\x4d\x01"+
        "\uffff\x03\x30\x01\x50\x02\uffff\x01\x54\x01\uffff\x01\x30\x01\x41"+
        "\x01\uffff\x01\x4d\x01\x50\x01\x30\x01\uffff";
    const string DFA24_maxS =
        "\x01\x7e\x01\x3d\x01\x3e\x01\x3d\x01\x3e\x01\x26\x01\x7c\x01\uffff"+
        "\x01\x2d\x02\uffff\x01\x2a\x02\uffff\x01\x39\x08\uffff\x01\x73\x01"+
        "\x79\x01\x75\x01\x74\x01\x72\x01\x78\x02\x72\x01\x61\x01\x73\x01"+
        "\x6f\x01\x65\x01\x69\x02\x75\x01\x72\x01\x6f\x01\x65\x01\x72\x02"+
        "\x69\x01\x6f\x03\uffff\x02\x65\x01\x79\x03\uffff\x01\x3e\x10\uffff"+
        "\x01\x7a\x01\x64\x01\x74\x01\x64\x01\uffff\x01\x74\x01\x7a\x01\x72"+
        "\x01\x73\x01\x65\x01\x6e\x01\x6f\x01\x69\x01\x64\x01\x63\x01\x74"+
        "\x01\x6f\x03\x73\x01\x70\x01\x63\x01\x64\x01\x72\x02\x6f\x01\x76"+
        "\x03\x7a\x01\x69\x01\x79\x01\x6b\x01\x66\x01\x74\x01\uffff\x01\x6c"+
        "\x02\x7a\x01\x74\x01\x7a\x01\x72\x01\x69\x01\x66\x01\x6c\x01\x74"+
        "\x01\x7a\x01\x69\x01\x65\x01\x62\x01\x6d\x01\x6c\x01\x65\x01\x74"+
        "\x01\x65\x01\uffff\x01\x72\x04\uffff\x02\x7a\x01\x65\x01\x7a\x01"+
        "\x69\x01\x77\x01\uffff\x01\x72\x01\x74\x01\x63\x01\x73\x01\x75\x01"+
        "\x6d\x01\x61\x01\x73\x01\x71\x01\x61\x01\x5f\x01\x61\x01\x70\x01"+
        "\x65\x01\x63\x01\x61\x01\x74\x01\x65\x01\x6c\x01\x73\x01\x6c\x01"+
        "\x61\x02\x7a\x01\x6d\x01\x75\x01\x69\x02\uffff\x01\x65\x01\x6f\x02"+
        "\x65\x01\uffff\x01\x6e\x01\x7a\x01\x65\x01\x74\x01\x7a\x01\x6c\x01"+
        "\uffff\x01\x65\x01\uffff\x01\x65\x01\uffff\x01\x73\x01\x6d\x01\x65"+
        "\x01\x6c\x01\x65\x01\x7a\x01\uffff\x01\x6e\x01\x67\x01\x6e\x01\x6c"+
        "\x01\x70\x01\x75\x01\x77\x01\x68\x01\x72\x01\x7a\x02\uffff\x01\x72"+
        "\x01\uffff\x01\x6e\x02\x65\x01\x7a\x01\x61\x01\x7a\x01\x6b\x01\x74"+
        "\x01\x6c\x01\x61\x01\x6d\x01\x69\x01\x74\x01\x73\x01\x75\x01\x6e"+
        "\x02\x74\x01\x62\x01\x7a\x01\x74\x01\x7a\x01\x75\x01\x69\x01\x7a"+
        "\x01\x61\x01\x74\x01\x75\x02\x70\x02\uffff\x01\x69\x01\x7a\x01\x70"+
        "\x01\x6e\x02\x72\x01\x7a\x01\x72\x01\x78\x01\x7a\x01\uffff\x02\x7a"+
        "\x01\uffff\x01\x7a\x02\x72\x01\x65\x01\x61\x01\x72\x01\x62\x01\x63"+
        "\x01\uffff\x01\x73\x01\x67\x01\x7a\x01\x65\x01\x7a\x01\x65\x03\x7a"+
        "\x01\x65\x01\uffff\x02\x7a\x01\x65\x01\x6e\x01\uffff\x01\x64\x01"+
        "\uffff\x01\x7a\x01\x72\x01\x69\x01\x74\x01\x6e\x01\x74\x01\x65\x01"+
        "\x7a\x01\x65\x01\x7a\x01\x65\x01\x69\x01\x61\x01\uffff\x01\x65\x01"+
        "\uffff\x01\x6c\x01\x6e\x01\uffff\x01\x69\x02\x73\x01\x74\x01\x65"+
        "\x01\x67\x01\uffff\x01\x7a\x01\x67\x01\x7a\x01\x73\x01\uffff\x01"+
        "\x74\x01\x7a\x04\uffff\x02\x7a\x02\x72\x01\x65\x01\x61\x01\x74\x01"+
        "\x61\x01\x65\x01\uffff\x01\x7a\x01\uffff\x01\x72\x01\x73\x03\uffff"+
        "\x01\x7a\x02\uffff\x01\x6e\x01\x74\x01\x65\x01\uffff\x01\x61\x01"+
        "\x63\x01\x65\x03\x7a\x01\uffff\x01\x7a\x01\uffff\x01\x7a\x01\x6d"+
        "\x01\x73\x01\x7a\x01\x74\x01\x63\x01\x6e\x01\x7a\x01\x69\x02\x7a"+
        "\x01\x6e\x01\uffff\x01\x7a\x01\uffff\x01\x65\x01\x7a\x03\uffff\x01"+
        "\x7a\x01\x79\x01\x6e\x01\x63\x01\x7a\x01\x63\x01\x72\x01\uffff\x01"+
        "\x61\x01\x7a\x01\uffff\x01\x7a\x01\x5f\x01\x7a\x01\x69\x01\x74\x01"+
        "\x7a\x05\uffff\x02\x65\x01\uffff\x01\x7a\x01\x74\x01\x7a\x01\uffff"+
        "\x01\x76\x02\uffff\x01\x7a\x01\uffff\x01\x63\x02\uffff\x01\x7a\x01"+
        "\x63\x01\x6b\x01\uffff\x01\x74\x01\x7a\x01\x72\x02\uffff\x01\x74"+
        "\x01\uffff\x01\x6e\x01\x7a\x01\uffff\x01\x73\x01\x7a\x01\uffff\x01"+
        "\x7a\x01\uffff\x01\x65\x01\uffff\x01\x74\x01\uffff\x01\x65\x01\x7a"+
        "\x01\x69\x01\uffff\x01\x79\x01\x69\x01\x61\x01\x74\x01\uffff\x01"+
        "\x74\x02\uffff\x02\x7a\x01\x73\x01\uffff\x01\x6f\x01\x7a\x01\x6d"+
        "\x01\x74\x01\x7a\x01\x61\x02\uffff\x01\x7a\x01\x6e\x01\uffff\x02"+
        "\x65\x01\uffff\x01\x6d\x01\uffff\x03\x7a\x01\x70\x02\uffff\x01\x74"+
        "\x01\uffff\x01\x7a\x01\x61\x01\uffff\x01\x6d\x01\x70\x01\x7a\x01"+
        "\uffff";
    const string DFA24_acceptS =
        "\x07\uffff\x01\x10\x01\uffff\x01\x12\x01\x13\x01\uffff\x01\x15"+
        "\x01\x16\x01\uffff\x01\x18\x01\x19\x01\x1a\x01\x1b\x01\x1d\x01\x1e"+
        "\x01\x1f\x01\x20\x16\uffff\x01\x73\x01\x74\x01\x76\x03\uffff\x01"+
        "\x7b\x01\x03\x01\x01\x01\uffff\x01\x05\x01\x0a\x01\x06\x01\x04\x01"+
        "\x1c\x01\x09\x01\x0b\x01\x08\x01\x0d\x01\x0c\x01\x0f\x01\x0e\x01"+
        "\x11\x01\x14\x01\x17\x01\x78\x04\uffff\x01\x7a\x1e\uffff\x01\x75"+
        "\x13\uffff\x01\x79\x01\uffff\x01\x77\x01\x02\x01\x07\x01\x24\x06"+
        "\uffff\x01\x28\x1b\uffff\x01\x51\x01\x4b\x04\uffff\x01\x4a\x06\uffff"+
        "\x01\x5a\x01\uffff\x01\x58\x01\uffff\x01\x59\x06\uffff\x01\x66\x0a"+
        "\uffff\x01\x25\x01\x21\x01\uffff\x01\x23\x1e\uffff\x01\x3f\x01\x45"+
        "\x0a\uffff\x01\x53\x02\uffff\x01\x56\x08\uffff\x01\x61\x0a\uffff"+
        "\x01\x72\x04\uffff\x01\x2a\x01\uffff\x01\x2b\x0d\uffff\x01\x3d\x01"+
        "\uffff\x01\x3b\x02\uffff\x01\x3e\x06\uffff\x01\x47\x04\uffff\x01"+
        "\x50\x02\uffff\x01\x52\x01\x55\x01\x54\x01\x57\x09\uffff\x01\x65"+
        "\x01\uffff\x01\x64\x02\uffff\x01\x6d\x01\x70\x01\x6e\x01\uffff\x01"+
        "\x22\x01\x26\x03\uffff\x01\x2c\x06\uffff\x01\x33\x01\uffff\x01\x69"+
        "\x0c\uffff\x01\x48\x01\uffff\x01\x4d\x02\uffff\x01\x4c\x01\x5b\x01"+
        "\x5c\x07\uffff\x01\x62\x02\uffff\x01\x6f\x06\uffff\x01\x2e\x01\x2f"+
        "\x01\x32\x01\x6a\x01\x6b\x02\uffff\x01\x3a\x03\uffff\x01\x43\x01"+
        "\uffff\x01\x41\x01\x40\x01\uffff\x01\x49\x01\uffff\x01\x4e\x01\x71"+
        "\x03\uffff\x01\x60\x03\uffff\x01\x6c\x01\x27\x01\uffff\x01\x29\x02"+
        "\uffff\x01\x2d\x02\uffff\x01\x39\x01\uffff\x01\x44\x01\uffff\x01"+
        "\x46\x01\uffff\x01\x5d\x03\uffff\x01\x68\x04\uffff\x01\x30\x01\uffff"+
        "\x01\x38\x01\x3c\x03\uffff\x01\x5f\x06\uffff\x01\x42\x01\x4f\x02"+
        "\uffff\x01\x63\x02\uffff\x01\x31\x01\uffff\x01\x5e\x04\uffff\x01"+
        "\x67\x01\x34\x01\uffff\x01\x35\x02\uffff\x01\x37\x03\uffff\x01\x36";
    const string DFA24_specialS =
        "\u01db\uffff}>";
    static readonly string[] DFA24_transitionS = {
            "\x02\x33\x01\uffff\x02\x33\x12\uffff\x01\x33\x01\x03\x02\uffff"+
            "\x01\x15\x01\x0c\x01\x05\x01\x2f\x01\x10\x01\x11\x01\x0a\x01"+
            "\x07\x01\x0f\x01\x08\x01\x0e\x01\x0b\x01\x30\x09\x31\x01\x13"+
            "\x01\x0d\x01\x02\x01\x01\x01\x04\x01\x12\x01\x14\x01\x17\x01"+
            "\x32\x01\x19\x01\x1b\x01\x1c\x01\x1d\x01\x1e\x01\x1f\x01\x20"+
            "\x01\x21\x01\x22\x01\x23\x01\x2d\x01\x24\x01\x25\x01\x26\x01"+
            "\x2d\x01\x27\x01\x28\x01\x29\x01\x1a\x01\x2a\x01\x2b\x01\x2c"+
            "\x02\x2d\x01\x2e\x02\uffff\x01\x16\x01\x2d\x01\uffff\x01\x17"+
            "\x01\x18\x01\x19\x01\x1b\x01\x1c\x01\x1d\x01\x1e\x01\x1f\x01"+
            "\x20\x01\x21\x01\x22\x01\x23\x01\x2d\x01\x24\x01\x25\x01\x26"+
            "\x01\x2d\x01\x27\x01\x28\x01\x29\x01\x1a\x01\x2a\x01\x2b\x01"+
            "\x2c\x02\x2d\x01\uffff\x01\x06\x01\uffff\x01\x09",
            "\x01\x34",
            "\x01\x38\x01\x36\x01\x37",
            "\x01\x3a",
            "\x01\x3c\x01\x3d",
            "\x01\x3f",
            "\x01\x41",
            "",
            "\x01\x33",
            "",
            "",
            "\x01\x33",
            "",
            "",
            "\x0a\x46",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\x48\x07\uffff\x01\x49\x01\uffff\x01\x4a\x04\uffff\x01"+
            "\x47\x10\uffff\x01\x48\x07\uffff\x01\x49\x01\uffff\x01\x4a\x04"+
            "\uffff\x01\x47",
            "\x01\x4b\x1d\uffff\x01\x4c\x13\uffff\x01\x4d\x0b\uffff\x01"+
            "\x4c\x13\uffff\x01\x4d",
            "\x01\x4f\x06\uffff\x01\x50\x06\uffff\x01\x51\x02\uffff\x01"+
            "\x52\x02\uffff\x01\x4e\x0b\uffff\x01\x4f\x06\uffff\x01\x50\x06"+
            "\uffff\x01\x51\x02\uffff\x01\x52\x02\uffff\x01\x4e",
            "\x01\x53\x01\uffff\x01\x54\x03\uffff\x01\x55\x19\uffff\x01"+
            "\x53\x01\uffff\x01\x54\x03\uffff\x01\x55",
            "\x01\x56\x03\uffff\x01\x58\x03\uffff\x01\x59\x08\uffff\x01"+
            "\x57\x0e\uffff\x01\x56\x03\uffff\x01\x58\x03\uffff\x01\x59\x08"+
            "\uffff\x01\x57",
            "\x01\x5a\x01\uffff\x01\x5d\x04\uffff\x01\x5c\x04\uffff\x01"+
            "\x5b\x13\uffff\x01\x5a\x01\uffff\x01\x5d\x04\uffff\x01\x5c\x04"+
            "\uffff\x01\x5b",
            "\x01\x5e\x02\uffff\x01\x5f\x1c\uffff\x01\x5e\x02\uffff\x01"+
            "\x5f",
            "\x01\x60\x1f\uffff\x01\x60",
            "\x01\x61\x1f\uffff\x01\x61",
            "\x01\x64\x07\uffff\x01\x63\x04\uffff\x01\x62\x12\uffff\x01"+
            "\x64\x07\uffff\x01\x63\x04\uffff\x01\x62",
            "\x01\x65\x1f\uffff\x01\x65",
            "\x01\x66\x1f\uffff\x01\x66",
            "\x01\x68\x03\uffff\x01\x67\x1b\uffff\x01\x68\x03\uffff\x01"+
            "\x67",
            "\x01\x6a\x27\uffff\x01\x69\x05\uffff\x01\x6b\x19\uffff\x01"+
            "\x69\x05\uffff\x01\x6b",
            "\x01\x6d\x07\uffff\x01\x6f\x03\uffff\x01\x6c\x02\uffff\x01"+
            "\x6e\x10\uffff\x01\x6d\x07\uffff\x01\x6f\x03\uffff\x01\x6c\x02"+
            "\uffff\x01\x6e",
            "\x01\x70\x10\uffff\x01\x71\x0e\uffff\x01\x70\x10\uffff\x01"+
            "\x71",
            "\x01\x72\x09\uffff\x01\x73\x15\uffff\x01\x72\x09\uffff\x01"+
            "\x73",
            "\x01\x74\x1f\uffff\x01\x74",
            "\x01\x78\x03\uffff\x01\x79\x02\uffff\x01\x77\x06\uffff\x01"+
            "\x75\x02\uffff\x01\x76\x0e\uffff\x01\x78\x03\uffff\x01\x79\x02"+
            "\uffff\x01\x77\x06\uffff\x01\x75\x02\uffff\x01\x76",
            "\x01\x7a\x07\uffff\x01\x7b\x17\uffff\x01\x7a\x07\uffff\x01"+
            "\x7b",
            "\x01\x7d\x01\x7c\x1e\uffff\x01\x7d\x01\x7c",
            "\x01\x7e\x27\uffff\x01\x7f\x1f\uffff\x01\x7f",
            "",
            "",
            "",
            "\x01\x46\x01\uffff\x0a\x31\x0b\uffff\x01\x46\x1c\uffff\x01"+
            "\x4b\x02\uffff\x01\x46",
            "\x01\x46\x01\uffff\x0a\x31\x0b\uffff\x01\x46\x1f\uffff\x01"+
            "\x46",
            "\x01\x4c\x13\uffff\x01\x4d\x0b\uffff\x01\x4c\x13\uffff\x01"+
            "\x4d",
            "",
            "",
            "",
            "\x01\u0081",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x0a\x2d\x07\uffff\x02\x2d\x01\u0084\x17\x2d\x04\uffff\x01"+
            "\x2d\x01\uffff\x02\x2d\x01\u0084\x17\x2d",
            "\x01\u0085\x1f\uffff\x01\u0085",
            "\x01\u0086\x1f\uffff\x01\u0086",
            "\x01\u0087\x1f\uffff\x01\u0087",
            "",
            "\x01\u0088\x0c\uffff\x01\u0089\x12\uffff\x01\u0088\x0c\uffff"+
            "\x01\u0089",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u008b\x1f\uffff\x01\u008b",
            "\x01\u008c\x1f\uffff\x01\u008c",
            "\x01\u008d\x1f\uffff\x01\u008d",
            "\x01\u008f\x01\u0090\x01\u008e\x1d\uffff\x01\u008f\x01\u0090"+
            "\x01\u008e",
            "\x01\u0091\x09\uffff\x01\u0092\x15\uffff\x01\u0091\x09\uffff"+
            "\x01\u0092",
            "\x01\u0093\x1f\uffff\x01\u0093",
            "\x01\u0094\x1f\uffff\x01\u0094",
            "\x01\u0095\x1f\uffff\x01\u0095",
            "\x01\u0096\x1f\uffff\x01\u0096",
            "\x01\u0097\x1f\uffff\x01\u0097",
            "\x01\u009a\x05\uffff\x01\u0098\x06\uffff\x01\u0099\x12\uffff"+
            "\x01\u009a\x05\uffff\x01\u0098\x06\uffff\x01\u0099",
            "\x01\u009b\x1f\uffff\x01\u009b",
            "\x01\u009c\x1f\uffff\x01\u009c",
            "\x01\u009f\x05\uffff\x01\u009e\x06\uffff\x01\u009d\x12\uffff"+
            "\x01\u009f\x05\uffff\x01\u009e\x06\uffff\x01\u009d",
            "\x01\u00a0\x1f\uffff\x01\u00a0",
            "\x01\u00a1\x1f\uffff\x01\u00a1",
            "\x01\u00a2\x1f\uffff\x01\u00a2",
            "\x01\u00a3\x1f\uffff\x01\u00a3",
            "\x01\u00a4\x1f\uffff\x01\u00a4",
            "\x01\u00a5\x1f\uffff\x01\u00a5",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x0a\x2d\x07\uffff\x03\x2d\x01\u00ab\x09\x2d\x01\u00a8\x04"+
            "\x2d\x01\u00aa\x01\u00a9\x06\x2d\x04\uffff\x01\x2d\x01\uffff"+
            "\x03\x2d\x01\u00ab\x09\x2d\x01\u00a8\x04\x2d\x01\u00aa\x01\u00a9"+
            "\x06\x2d",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u00ad\x1f\uffff\x01\u00ad",
            "\x01\u00ae\x1f\uffff\x01\u00ae",
            "\x01\u00af\x1f\uffff\x01\u00af",
            "\x01\u00b0\x1f\uffff\x01\u00b0",
            "\x01\u00b1\x1f\uffff\x01\u00b1",
            "",
            "\x01\u00b2\x1f\uffff\x01\u00b2",
            "\x0a\x2d\x07\uffff\x03\x2d\x01\u00b4\x16\x2d\x04\uffff\x01"+
            "\x2d\x01\uffff\x03\x2d\x01\u00b4\x16\x2d",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u00b6\x1f\uffff\x01\u00b6",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u00b8\x1f\uffff\x01\u00b8",
            "\x01\u00b9\x1f\uffff\x01\u00b9",
            "\x01\u00ba\x1f\uffff\x01\u00ba",
            "\x01\u00bb\x1f\uffff\x01\u00bb",
            "\x01\u00bc\x07\uffff\x01\u00bd\x17\uffff\x01\u00bc\x07\uffff"+
            "\x01\u00bd",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u00bf\x07\uffff\x01\u00c0\x17\uffff\x01\u00bf\x07\uffff"+
            "\x01\u00c0",
            "\x01\u00c1\x1f\uffff\x01\u00c1",
            "\x01\u00c2\x1f\uffff\x01\u00c2",
            "\x01\u00c3\x1f\uffff\x01\u00c3",
            "\x01\u00c4\x1f\uffff\x01\u00c4",
            "\x01\u00c5\x1f\uffff\x01\u00c5",
            "\x01\u00c6\x1f\uffff\x01\u00c6",
            "\x01\u00c7\x1f\uffff\x01\u00c7",
            "",
            "\x01\u00c8\x1f\uffff\x01\u00c8",
            "",
            "",
            "",
            "",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u00cb\x1f\uffff\x01\u00cb",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u00cd\x1f\uffff\x01\u00cd",
            "\x01\u00ce\x1f\uffff\x01\u00ce",
            "",
            "\x01\u00cf\x1f\uffff\x01\u00cf",
            "\x01\u00d1\x01\uffff\x01\u00d0\x0e\uffff\x01\u00d2\x0e\uffff"+
            "\x01\u00d1\x01\uffff\x01\u00d0\x0e\uffff\x01\u00d2",
            "\x01\u00d3\x1f\uffff\x01\u00d3",
            "\x01\u00d5\x0c\uffff\x01\u00d4\x12\uffff\x01\u00d5\x0c\uffff"+
            "\x01\u00d4",
            "\x01\u00d6\x08\uffff\x01\u00d7\x16\uffff\x01\u00d6\x08\uffff"+
            "\x01\u00d7",
            "\x01\u00d8\x1f\uffff\x01\u00d8",
            "\x01\u00d9\x1f\uffff\x01\u00d9",
            "\x01\u00da\x1f\uffff\x01\u00da",
            "\x01\u00dc\x01\uffff\x01\u00db\x1d\uffff\x01\u00dc\x01\uffff"+
            "\x01\u00db",
            "\x01\u00dd\x1f\uffff\x01\u00dd",
            "\x01\u00de",
            "\x01\u00df\x1f\uffff\x01\u00df",
            "\x01\u00e0\x1f\uffff\x01\u00e0",
            "\x01\u00e1\x1f\uffff\x01\u00e1",
            "\x01\u00e2\x1f\uffff\x01\u00e2",
            "\x01\u00e3\x1f\uffff\x01\u00e3",
            "\x01\u00e4\x1f\uffff\x01\u00e4",
            "\x01\u00e5\x1f\uffff\x01\u00e5",
            "\x01\u00e6\x1f\uffff\x01\u00e6",
            "\x01\u00e7\x1f\uffff\x01\u00e7",
            "\x01\u00e9\x06\uffff\x01\u00e8\x18\uffff\x01\u00e9\x06\uffff"+
            "\x01\u00e8",
            "\x01\u00ea\x1f\uffff\x01\u00ea",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x0a\x2d\x07\uffff\x04\x2d\x01\u00ed\x15\x2d\x04\uffff\x01"+
            "\x2d\x01\uffff\x04\x2d\x01\u00ed\x15\x2d",
            "\x01\u00ee\x1f\uffff\x01\u00ee",
            "\x01\u00ef\x1f\uffff\x01\u00ef",
            "\x01\u00f0\x1f\uffff\x01\u00f0",
            "",
            "",
            "\x01\u00f1\x1f\uffff\x01\u00f1",
            "\x01\u00f2\x09\uffff\x01\u00f3\x15\uffff\x01\u00f2\x09\uffff"+
            "\x01\u00f3",
            "\x01\u00f4\x1f\uffff\x01\u00f4",
            "\x01\u00f5\x1f\uffff\x01\u00f5",
            "",
            "\x01\u00f6\x1f\uffff\x01\u00f6",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u00f8\x1f\uffff\x01\u00f8",
            "\x01\u00f9\x1f\uffff\x01\u00f9",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u00fb\x1f\uffff\x01\u00fb",
            "",
            "\x01\u00fc\x1f\uffff\x01\u00fc",
            "",
            "\x01\u00fd\x1f\uffff\x01\u00fd",
            "",
            "\x01\u00fe\x1f\uffff\x01\u00fe",
            "\x01\u00ff\x1f\uffff\x01\u00ff",
            "\x01\u0100\x1f\uffff\x01\u0100",
            "\x01\u0101\x1f\uffff\x01\u0101",
            "\x01\u0102\x1f\uffff\x01\u0102",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "",
            "\x01\u0104\x1f\uffff\x01\u0104",
            "\x01\u0105\x1f\uffff\x01\u0105",
            "\x01\u0106\x1f\uffff\x01\u0106",
            "\x01\u0107\x1f\uffff\x01\u0107",
            "\x01\u0108\x1f\uffff\x01\u0108",
            "\x01\u0109\x1f\uffff\x01\u0109",
            "\x01\u010a\x1f\uffff\x01\u010a",
            "\x01\u010b\x1f\uffff\x01\u010b",
            "\x01\u010c\x03\uffff\x01\u010d\x1b\uffff\x01\u010c\x03\uffff"+
            "\x01\u010d",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "",
            "",
            "\x01\u010f\x1f\uffff\x01\u010f",
            "",
            "\x01\u0110\x1f\uffff\x01\u0110",
            "\x01\u0111\x1f\uffff\x01\u0111",
            "\x01\u0112\x1f\uffff\x01\u0112",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u0114\x1f\uffff\x01\u0114",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u0116\x1f\uffff\x01\u0116",
            "\x01\u0117\x1f\uffff\x01\u0117",
            "\x01\u0118\x1f\uffff\x01\u0118",
            "\x01\u0119\x1f\uffff\x01\u0119",
            "\x01\u011a\x1f\uffff\x01\u011a",
            "\x01\u011b\x1f\uffff\x01\u011b",
            "\x01\u011c\x1f\uffff\x01\u011c",
            "\x01\u011d\x1f\uffff\x01\u011d",
            "\x01\u011e\x1f\uffff\x01\u011e",
            "\x01\u011f\x1f\uffff\x01\u011f",
            "\x01\u0120\x1f\uffff\x01\u0120",
            "\x01\u0121\x1f\uffff\x01\u0121",
            "\x01\u0122\x1f\uffff\x01\u0122",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u0124\x1f\uffff\x01\u0124",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u0126\x1f\uffff\x01\u0126",
            "\x01\u0127\x1f\uffff\x01\u0127",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u0129\x1f\uffff\x01\u0129",
            "\x01\u012a\x1f\uffff\x01\u012a",
            "\x01\u012b\x1f\uffff\x01\u012b",
            "\x01\u012c\x1f\uffff\x01\u012c",
            "\x01\u012d\x1f\uffff\x01\u012d",
            "",
            "",
            "\x01\u012e\x1f\uffff\x01\u012e",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u0130\x1f\uffff\x01\u0130",
            "\x01\u0131\x1f\uffff\x01\u0131",
            "\x01\u0132\x1f\uffff\x01\u0132",
            "\x01\u0133\x1f\uffff\x01\u0133",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u0135\x1f\uffff\x01\u0135",
            "\x01\u0136\x1f\uffff\x01\u0136",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u013b\x1f\uffff\x01\u013b",
            "\x01\u013c\x1f\uffff\x01\u013c",
            "\x01\u013d\x1f\uffff\x01\u013d",
            "\x01\u013e\x1f\uffff\x01\u013e",
            "\x01\u013f\x1f\uffff\x01\u013f",
            "\x01\u0140\x1f\uffff\x01\u0140",
            "\x01\u0141\x1f\uffff\x01\u0141",
            "",
            "\x01\u0142\x1f\uffff\x01\u0142",
            "\x01\u0143\x1f\uffff\x01\u0143",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u0145\x1f\uffff\x01\u0145",
            "\x0a\x2d\x07\uffff\x0e\x2d\x01\u0147\x0b\x2d\x04\uffff\x01"+
            "\x2d\x01\uffff\x0e\x2d\x01\u0147\x0b\x2d",
            "\x01\u0148\x1f\uffff\x01\u0148",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u014c\x1f\uffff\x01\u014c",
            "",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u014f\x1f\uffff\x01\u014f",
            "\x01\u0150\x1f\uffff\x01\u0150",
            "",
            "\x01\u0151\x1f\uffff\x01\u0151",
            "",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u0153\x1f\uffff\x01\u0153",
            "\x01\u0154\x1f\uffff\x01\u0154",
            "\x01\u0155\x1f\uffff\x01\u0155",
            "\x01\u0156\x1f\uffff\x01\u0156",
            "\x01\u0157\x1f\uffff\x01\u0157",
            "\x01\u0158\x1f\uffff\x01\u0158",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u015a\x1f\uffff\x01\u015a",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u015c\x1f\uffff\x01\u015c",
            "\x01\u015d\x1f\uffff\x01\u015d",
            "\x01\u015e\x1f\uffff\x01\u015e",
            "",
            "\x01\u015f\x1f\uffff\x01\u015f",
            "",
            "\x01\u0160\x1f\uffff\x01\u0160",
            "\x01\u0161\x1f\uffff\x01\u0161",
            "",
            "\x01\u0162\x1f\uffff\x01\u0162",
            "\x01\u0163\x1f\uffff\x01\u0163",
            "\x01\u0164\x1f\uffff\x01\u0164",
            "\x01\u0165\x1f\uffff\x01\u0165",
            "\x01\u0166\x1f\uffff\x01\u0166",
            "\x01\u0167\x1f\uffff\x01\u0167",
            "",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u0169\x1f\uffff\x01\u0169",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u016b\x1f\uffff\x01\u016b",
            "",
            "\x01\u016c\x1f\uffff\x01\u016c",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "",
            "",
            "",
            "",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u0170\x1f\uffff\x01\u0170",
            "\x01\u0171\x1f\uffff\x01\u0171",
            "\x01\u0172\x1f\uffff\x01\u0172",
            "\x01\u0173\x1f\uffff\x01\u0173",
            "\x01\u0174\x1f\uffff\x01\u0174",
            "\x01\u0175\x1f\uffff\x01\u0175",
            "\x01\u0176\x1f\uffff\x01\u0176",
            "",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "",
            "\x01\u0178\x1f\uffff\x01\u0178",
            "\x01\u0179\x1f\uffff\x01\u0179",
            "",
            "",
            "",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "",
            "",
            "\x01\u017b\x1f\uffff\x01\u017b",
            "\x01\u017c\x1f\uffff\x01\u017c",
            "\x01\u017d\x1f\uffff\x01\u017d",
            "",
            "\x01\u017e\x1f\uffff\x01\u017e",
            "\x01\u017f\x1f\uffff\x01\u017f",
            "\x01\u0180\x1f\uffff\x01\u0180",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u0186\x1f\uffff\x01\u0186",
            "\x01\u0187\x1f\uffff\x01\u0187",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u0189\x1f\uffff\x01\u0189",
            "\x01\u018a\x1f\uffff\x01\u018a",
            "\x01\u018b\x1f\uffff\x01\u018b",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u018d\x1f\uffff\x01\u018d",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u0190\x1f\uffff\x01\u0190",
            "",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "",
            "\x01\u0192\x1f\uffff\x01\u0192",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "",
            "",
            "",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u0195\x1f\uffff\x01\u0195",
            "\x01\u0196\x1f\uffff\x01\u0196",
            "\x01\u0197\x1f\uffff\x01\u0197",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u0199\x1f\uffff\x01\u0199",
            "\x01\u019a\x1f\uffff\x01\u019a",
            "",
            "\x01\u019b\x1f\uffff\x01\u019b",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u019e",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u01a0\x1f\uffff\x01\u01a0",
            "\x01\u01a1\x1f\uffff\x01\u01a1",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "",
            "",
            "",
            "",
            "",
            "\x01\u01a3\x1f\uffff\x01\u01a3",
            "\x01\u01a4\x1f\uffff\x01\u01a4",
            "",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u01a6\x1f\uffff\x01\u01a6",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "",
            "\x01\u01a8\x1f\uffff\x01\u01a8",
            "",
            "",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "",
            "\x01\u01aa\x1f\uffff\x01\u01aa",
            "",
            "",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u01ac\x1f\uffff\x01\u01ac",
            "\x01\u01ad\x1f\uffff\x01\u01ad",
            "",
            "\x01\u01ae\x1f\uffff\x01\u01ae",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u01b0\x1f\uffff\x01\u01b0",
            "",
            "",
            "\x01\u01b2\x0f\uffff\x01\u01b1\x0f\uffff\x01\u01b2\x0f\uffff"+
            "\x01\u01b1",
            "",
            "\x01\u01b3\x1f\uffff\x01\u01b3",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "",
            "\x01\u01b5\x1f\uffff\x01\u01b5",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "",
            "\x01\u01b8\x1f\uffff\x01\u01b8",
            "",
            "\x01\u01b9\x1f\uffff\x01\u01b9",
            "",
            "\x01\u01ba\x1f\uffff\x01\u01ba",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u01bc\x1f\uffff\x01\u01bc",
            "",
            "\x01\u01bd\x1f\uffff\x01\u01bd",
            "\x01\u01be\x1f\uffff\x01\u01be",
            "\x01\u01bf\x1f\uffff\x01\u01bf",
            "\x01\u01c0\x1f\uffff\x01\u01c0",
            "",
            "\x01\u01c1\x1f\uffff\x01\u01c1",
            "",
            "",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u01c4\x1f\uffff\x01\u01c4",
            "",
            "\x01\u01c5\x1f\uffff\x01\u01c5",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u01c7\x1f\uffff\x01\u01c7",
            "\x01\u01c8\x1f\uffff\x01\u01c8",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u01ca\x1f\uffff\x01\u01ca",
            "",
            "",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u01cc\x1f\uffff\x01\u01cc",
            "",
            "\x01\u01cd\x1f\uffff\x01\u01cd",
            "\x01\u01ce\x1f\uffff\x01\u01ce",
            "",
            "\x01\u01cf\x1f\uffff\x01\u01cf",
            "",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x0a\x2d\x07\uffff\x12\x2d\x01\u01d2\x07\x2d\x04\uffff\x01"+
            "\x2d\x01\uffff\x12\x2d\x01\u01d2\x07\x2d",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u01d4\x1f\uffff\x01\u01d4",
            "",
            "",
            "\x01\u01d5\x1f\uffff\x01\u01d5",
            "",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            "\x01\u01d7\x1f\uffff\x01\u01d7",
            "",
            "\x01\u01d8\x1f\uffff\x01\u01d8",
            "\x01\u01d9\x1f\uffff\x01\u01d9",
            "\x0a\x2d\x07\uffff\x1a\x2d\x04\uffff\x01\x2d\x01\uffff\x1a"+
            "\x2d",
            ""
    };

    static readonly short[] DFA24_eot = DFA.UnpackEncodedString(DFA24_eotS);
    static readonly short[] DFA24_eof = DFA.UnpackEncodedString(DFA24_eofS);
    static readonly char[] DFA24_min = DFA.UnpackEncodedStringToUnsignedChars(DFA24_minS);
    static readonly char[] DFA24_max = DFA.UnpackEncodedStringToUnsignedChars(DFA24_maxS);
    static readonly short[] DFA24_accept = DFA.UnpackEncodedString(DFA24_acceptS);
    static readonly short[] DFA24_special = DFA.UnpackEncodedString(DFA24_specialS);
    static readonly short[][] DFA24_transition = DFA.UnpackEncodedStringArray(DFA24_transitionS);

    protected class DFA24 : DFA
    {
        public DFA24(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 24;
            this.eot = DFA24_eot;
            this.eof = DFA24_eof;
            this.min = DFA24_min;
            this.max = DFA24_max;
            this.accept = DFA24_accept;
            this.special = DFA24_special;
            this.transition = DFA24_transition;

        }

        override public string Description
        {
            get { return "1:1: Tokens : ( EQUALS | SAFEEQUALS | EQUALS2 | NOT_EQUALS | NOT_EQUALS2 | LESS | LESS_OR_EQ | GREATER | GREATER_OR_EQ | SHIFT_LEFT | SHIFT_RIGHT | AMPERSAND | DOUBLE_AMPERSAND | PIPE | DOUBLE_PIPE | PLUS | MINUS | TILDA | ASTERISK | SLASH | PERCENT | SEMI | DOT | COMMA | LPAREN | RPAREN | QUESTION | EXCLAMATION | COLON | AT | DOLLAR | ARROW_UP | ADD | ALTER | AND | AS | ASC | BEGIN | BETWEEN | BY | CASCADE | CASE | CAST | CHECK | COLLATE | COLUMN | COMMIT | CONFLICT | CONSTRAINT | CREATE | CROSS | CURRENT_TIME | CURRENT_DATE | CURRENT_TIMESTAMP | UTC_TIMESTAMP | DATABASE | DEFAULT | DELETE | DESC | DISTINCT | DROP | ELSE | END | ESCAPE | EXCEPT | EXCLUSIVE | EXISTS | EXPLAIN | FOR | FOREIGN | FROM | GROUP | HAVING | IF | IN | INDEX | INNER | INSERT | INTERSECT | INTO | IS | JOIN | KEY | LEFT | LIKE | NOT | NULL | OF | ON | OR | ORDER | OUTER | PRIMARY | REFERENCES | ROLLBACK | SELECT | SET | TABLE | TEMPORARY | TEMP | THEN | TO | TRANSACTION | TRIGGER | UNION | UNIQUE | UPDATE | VALUES | VIEW | WHEN | WHERE | WITH | PARSER | XOR | T_IDENT | T_QUOTED_IDENT | T_NSTRING | T_STRING | T_INTEGER | T_FLOAT | T_BLOB | T_BINARYNUM | WHITESPACE );"; }
        }

    }

 
    
}
