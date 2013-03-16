// $ANTLR 3.2 Sep 23, 2009 12:02:23 DateTimeFilter.g 2013-03-16 13:19:45

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162


using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;


public partial class DateTimeFilterLexer : Lexer {
    public const int DEC = 21;
    public const int LT = 48;
    public const int JAN = 10;
    public const int MON = 22;
    public const int FLOW_MONTH = 7;
    public const int THIS_YEAR = 42;
    public const int HOUR_ANY_MINUTE = 6;
    public const int YEAR = 4;
    public const int AUG = 17;
    public const int THIS_MONTH = 39;
    public const int NOV = 20;
    public const int APR = 13;
    public const int MAY = 14;
    public const int EOF = -1;
    public const int FEB = 11;
    public const int YEAR_MONTH = 9;
    public const int SUN = 28;
    public const int LAST_YEAR = 41;
    public const int TIME = 45;
    public const int TUE = 23;
    public const int LAST_MONTH = 38;
    public const int SEP = 18;
    public const int COMMA = 46;
    public const int LAST_WEEK = 35;
    public const int JUL = 16;
    public const int FLOW_DAY = 8;
    public const int DIGIT = 54;
    public const int JUN = 15;
    public const int EQ = 53;
    public const int THU = 25;
    public const int NEXT_HOUR = 31;
    public const int NE = 52;
    public const int TOMORROW = 34;
    public const int GE = 50;
    public const int FRI = 26;
    public const int TODAY = 33;
    public const int NEXT_MONTH = 40;
    public const int LAST_HOUR = 29;
    public const int WED = 24;
    public const int THIS_HOUR = 30;
    public const int NEXT_WEEK = 37;
    public const int WHITESPACE = 55;
    public const int SAT = 27;
    public const int MINUS = 44;
    public const int THIS_WEEK = 36;
    public const int OCT = 19;
    public const int NEXT_YEAR = 43;
    public const int MAR = 12;
    public const int GT = 49;
    public const int ENDLINE = 47;
    public const int DATE = 5;
    public const int YESTERDAY = 32;
    public const int LE = 51;

    // delegates
    // delegators

    public DateTimeFilterLexer() 
    {
		InitializeCyclicDFAs();
    }
    public DateTimeFilterLexer(ICharStream input)
		: this(input, null) {
    }
    public DateTimeFilterLexer(ICharStream input, RecognizerSharedState state)
		: base(input, state) {
		InitializeCyclicDFAs(); 

    }
    
    override public string GrammarFileName
    {
    	get { return "DateTimeFilter.g";} 
    }

    // $ANTLR start "MINUS"
    public void mMINUS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = MINUS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:82:6: ( '-' )
            // DateTimeFilter.g:82:9: '-'
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

    // $ANTLR start "LT"
    public void mLT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = LT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:83:3: ( '<' )
            // DateTimeFilter.g:83:6: '<'
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
    // $ANTLR end "LT"

    // $ANTLR start "GT"
    public void mGT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = GT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:84:3: ( '>' )
            // DateTimeFilter.g:84:6: '>'
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
    // $ANTLR end "GT"

    // $ANTLR start "GE"
    public void mGE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = GE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:85:3: ( '>=' )
            // DateTimeFilter.g:85:6: '>='
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
    // $ANTLR end "GE"

    // $ANTLR start "LE"
    public void mLE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = LE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:86:3: ( '<=' )
            // DateTimeFilter.g:86:6: '<='
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
    // $ANTLR end "LE"

    // $ANTLR start "NE"
    public void mNE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = NE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:87:3: ( '!=' | '<>' )
            int alt1 = 2;
            int LA1_0 = input.LA(1);

            if ( (LA1_0 == '!') )
            {
                alt1 = 1;
            }
            else if ( (LA1_0 == '<') )
            {
                alt1 = 2;
            }
            else 
            {
                NoViableAltException nvae_d1s0 =
                    new NoViableAltException("", 1, 0, input);

                throw nvae_d1s0;
            }
            switch (alt1) 
            {
                case 1 :
                    // DateTimeFilter.g:87:6: '!='
                    {
                    	Match("!="); 


                    }
                    break;
                case 2 :
                    // DateTimeFilter.g:87:13: '<>'
                    {
                    	Match("<>"); 


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
    // $ANTLR end "NE"

    // $ANTLR start "EQ"
    public void mEQ() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = EQ;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:88:3: ( '=' )
            // DateTimeFilter.g:88:6: '='
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
    // $ANTLR end "EQ"

    // $ANTLR start "COMMA"
    public void mCOMMA() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = COMMA;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:89:6: ( ',' )
            // DateTimeFilter.g:89:8: ','
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

    // $ANTLR start "LAST_HOUR"
    public void mLAST_HOUR() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = LAST_HOUR;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:91:10: ( 'l' 'a' 's' 't' '_' 'h' 'o' 'u' 'r' )
            // DateTimeFilter.g:91:12: 'l' 'a' 's' 't' '_' 'h' 'o' 'u' 'r'
            {
            	Match('l'); 
            	Match('a'); 
            	Match('s'); 
            	Match('t'); 
            	Match('_'); 
            	Match('h'); 
            	Match('o'); 
            	Match('u'); 
            	Match('r'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "LAST_HOUR"

    // $ANTLR start "THIS_HOUR"
    public void mTHIS_HOUR() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = THIS_HOUR;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:92:10: ( 't' 'h' 'i' 's' '_' 'h' 'o' 'u' 'r' )
            // DateTimeFilter.g:92:12: 't' 'h' 'i' 's' '_' 'h' 'o' 'u' 'r'
            {
            	Match('t'); 
            	Match('h'); 
            	Match('i'); 
            	Match('s'); 
            	Match('_'); 
            	Match('h'); 
            	Match('o'); 
            	Match('u'); 
            	Match('r'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "THIS_HOUR"

    // $ANTLR start "NEXT_HOUR"
    public void mNEXT_HOUR() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = NEXT_HOUR;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:93:10: ( 'n' 'e' 'x' 't' '_' 'h' 'o' 'u' 'r' )
            // DateTimeFilter.g:93:12: 'n' 'e' 'x' 't' '_' 'h' 'o' 'u' 'r'
            {
            	Match('n'); 
            	Match('e'); 
            	Match('x'); 
            	Match('t'); 
            	Match('_'); 
            	Match('h'); 
            	Match('o'); 
            	Match('u'); 
            	Match('r'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "NEXT_HOUR"

    // $ANTLR start "YESTERDAY"
    public void mYESTERDAY() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = YESTERDAY;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:95:10: ( 'y' 'e' 's' 't' 'e' 'r' 'd' 'y' )
            // DateTimeFilter.g:95:12: 'y' 'e' 's' 't' 'e' 'r' 'd' 'y'
            {
            	Match('y'); 
            	Match('e'); 
            	Match('s'); 
            	Match('t'); 
            	Match('e'); 
            	Match('r'); 
            	Match('d'); 
            	Match('y'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "YESTERDAY"

    // $ANTLR start "TODAY"
    public void mTODAY() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = TODAY;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:96:6: ( 't' 'o' 'd' 'a' 'y' )
            // DateTimeFilter.g:96:8: 't' 'o' 'd' 'a' 'y'
            {
            	Match('t'); 
            	Match('o'); 
            	Match('d'); 
            	Match('a'); 
            	Match('y'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "TODAY"

    // $ANTLR start "TOMORROW"
    public void mTOMORROW() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = TOMORROW;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:97:9: ( 't' 'o' 'm' 'o' 'r' 'r' 'o' 'w' )
            // DateTimeFilter.g:97:11: 't' 'o' 'm' 'o' 'r' 'r' 'o' 'w'
            {
            	Match('t'); 
            	Match('o'); 
            	Match('m'); 
            	Match('o'); 
            	Match('r'); 
            	Match('r'); 
            	Match('o'); 
            	Match('w'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "TOMORROW"

    // $ANTLR start "LAST_WEEK"
    public void mLAST_WEEK() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = LAST_WEEK;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:99:10: ( 'l' 'a' 's' 't' '_' 'w' 'e' 'e' 'k' )
            // DateTimeFilter.g:99:12: 'l' 'a' 's' 't' '_' 'w' 'e' 'e' 'k'
            {
            	Match('l'); 
            	Match('a'); 
            	Match('s'); 
            	Match('t'); 
            	Match('_'); 
            	Match('w'); 
            	Match('e'); 
            	Match('e'); 
            	Match('k'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "LAST_WEEK"

    // $ANTLR start "THIS_WEEK"
    public void mTHIS_WEEK() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = THIS_WEEK;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:100:10: ( 't' 'h' 'i' 's' '_' 'w' 'e' 'e' 'k' )
            // DateTimeFilter.g:100:12: 't' 'h' 'i' 's' '_' 'w' 'e' 'e' 'k'
            {
            	Match('t'); 
            	Match('h'); 
            	Match('i'); 
            	Match('s'); 
            	Match('_'); 
            	Match('w'); 
            	Match('e'); 
            	Match('e'); 
            	Match('k'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "THIS_WEEK"

    // $ANTLR start "NEXT_WEEK"
    public void mNEXT_WEEK() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = NEXT_WEEK;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:101:10: ( 'n' 'e' 'x' 't' '_' 'w' 'e' 'e' 'k' )
            // DateTimeFilter.g:101:12: 'n' 'e' 'x' 't' '_' 'w' 'e' 'e' 'k'
            {
            	Match('n'); 
            	Match('e'); 
            	Match('x'); 
            	Match('t'); 
            	Match('_'); 
            	Match('w'); 
            	Match('e'); 
            	Match('e'); 
            	Match('k'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "NEXT_WEEK"

    // $ANTLR start "LAST_MONTH"
    public void mLAST_MONTH() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = LAST_MONTH;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:103:11: ( 'l' 'a' 's' 't' '_' 'm' 'o' 'n' 't' 'h' )
            // DateTimeFilter.g:103:13: 'l' 'a' 's' 't' '_' 'm' 'o' 'n' 't' 'h'
            {
            	Match('l'); 
            	Match('a'); 
            	Match('s'); 
            	Match('t'); 
            	Match('_'); 
            	Match('m'); 
            	Match('o'); 
            	Match('n'); 
            	Match('t'); 
            	Match('h'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "LAST_MONTH"

    // $ANTLR start "THIS_MONTH"
    public void mTHIS_MONTH() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = THIS_MONTH;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:104:11: ( 't' 'h' 'i' 's' '_' 'm' 'o' 'n' 't' 'h' )
            // DateTimeFilter.g:104:13: 't' 'h' 'i' 's' '_' 'm' 'o' 'n' 't' 'h'
            {
            	Match('t'); 
            	Match('h'); 
            	Match('i'); 
            	Match('s'); 
            	Match('_'); 
            	Match('m'); 
            	Match('o'); 
            	Match('n'); 
            	Match('t'); 
            	Match('h'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "THIS_MONTH"

    // $ANTLR start "NEXT_MONTH"
    public void mNEXT_MONTH() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = NEXT_MONTH;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:105:11: ( 'n' 'e' 'x' 't' '_' 'm' 'o' 'n' 't' 'h' )
            // DateTimeFilter.g:105:13: 'n' 'e' 'x' 't' '_' 'm' 'o' 'n' 't' 'h'
            {
            	Match('n'); 
            	Match('e'); 
            	Match('x'); 
            	Match('t'); 
            	Match('_'); 
            	Match('m'); 
            	Match('o'); 
            	Match('n'); 
            	Match('t'); 
            	Match('h'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "NEXT_MONTH"

    // $ANTLR start "LAST_YEAR"
    public void mLAST_YEAR() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = LAST_YEAR;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:107:10: ( 'l' 'a' 's' 't' '_' 'y' 'e' 'a' 'r' )
            // DateTimeFilter.g:107:12: 'l' 'a' 's' 't' '_' 'y' 'e' 'a' 'r'
            {
            	Match('l'); 
            	Match('a'); 
            	Match('s'); 
            	Match('t'); 
            	Match('_'); 
            	Match('y'); 
            	Match('e'); 
            	Match('a'); 
            	Match('r'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "LAST_YEAR"

    // $ANTLR start "THIS_YEAR"
    public void mTHIS_YEAR() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = THIS_YEAR;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:108:10: ( 't' 'h' 'i' 's' '_' 'y' 'e' 'a' 'r' )
            // DateTimeFilter.g:108:12: 't' 'h' 'i' 's' '_' 'y' 'e' 'a' 'r'
            {
            	Match('t'); 
            	Match('h'); 
            	Match('i'); 
            	Match('s'); 
            	Match('_'); 
            	Match('y'); 
            	Match('e'); 
            	Match('a'); 
            	Match('r'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "THIS_YEAR"

    // $ANTLR start "NEXT_YEAR"
    public void mNEXT_YEAR() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = NEXT_YEAR;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:109:10: ( 'n' 'e' 'x' 't' '_' 'y' 'e' 'a' 'r' )
            // DateTimeFilter.g:109:12: 'n' 'e' 'x' 't' '_' 'y' 'e' 'a' 'r'
            {
            	Match('n'); 
            	Match('e'); 
            	Match('x'); 
            	Match('t'); 
            	Match('_'); 
            	Match('y'); 
            	Match('e'); 
            	Match('a'); 
            	Match('r'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "NEXT_YEAR"

    // $ANTLR start "YEAR"
    public void mYEAR() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = YEAR;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:111:5: ( DIGIT DIGIT DIGIT DIGIT )
            // DateTimeFilter.g:111:7: DIGIT DIGIT DIGIT DIGIT
            {
            	mDIGIT(); 
            	mDIGIT(); 
            	mDIGIT(); 
            	mDIGIT(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "YEAR"

    // $ANTLR start "DATE"
    public void mDATE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = DATE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:113:5: ( DIGIT DIGIT DIGIT DIGIT '-' ( DIGIT )? DIGIT '-' ( DIGIT )? DIGIT | ( DIGIT )? DIGIT '.' ( DIGIT )? DIGIT '.' ( DIGIT DIGIT DIGIT DIGIT )? | ( DIGIT )? DIGIT '/' ( DIGIT )? DIGIT ( '/' DIGIT DIGIT DIGIT DIGIT )? )
            int alt10 = 3;
            int LA10_0 = input.LA(1);

            if ( ((LA10_0 >= '0' && LA10_0 <= '9')) )
            {
                switch ( input.LA(2) ) 
                {
                case '0':
                case '1':
                case '2':
                case '3':
                case '4':
                case '5':
                case '6':
                case '7':
                case '8':
                case '9':
                	{
                    switch ( input.LA(3) ) 
                    {
                    case '0':
                    case '1':
                    case '2':
                    case '3':
                    case '4':
                    case '5':
                    case '6':
                    case '7':
                    case '8':
                    case '9':
                    	{
                        alt10 = 1;
                        }
                        break;
                    case '.':
                    	{
                        alt10 = 2;
                        }
                        break;
                    case '/':
                    	{
                        alt10 = 3;
                        }
                        break;
                    	default:
                    	    NoViableAltException nvae_d10s2 =
                    	        new NoViableAltException("", 10, 2, input);

                    	    throw nvae_d10s2;
                    }

                    }
                    break;
                case '.':
                	{
                    alt10 = 2;
                    }
                    break;
                case '/':
                	{
                    alt10 = 3;
                    }
                    break;
                	default:
                	    NoViableAltException nvae_d10s1 =
                	        new NoViableAltException("", 10, 1, input);

                	    throw nvae_d10s1;
                }

            }
            else 
            {
                NoViableAltException nvae_d10s0 =
                    new NoViableAltException("", 10, 0, input);

                throw nvae_d10s0;
            }
            switch (alt10) 
            {
                case 1 :
                    // DateTimeFilter.g:113:7: DIGIT DIGIT DIGIT DIGIT '-' ( DIGIT )? DIGIT '-' ( DIGIT )? DIGIT
                    {
                    	mDIGIT(); 
                    	mDIGIT(); 
                    	mDIGIT(); 
                    	mDIGIT(); 
                    	Match('-'); 
                    	// DateTimeFilter.g:113:35: ( DIGIT )?
                    	int alt2 = 2;
                    	int LA2_0 = input.LA(1);

                    	if ( ((LA2_0 >= '0' && LA2_0 <= '9')) )
                    	{
                    	    int LA2_1 = input.LA(2);

                    	    if ( ((LA2_1 >= '0' && LA2_1 <= '9')) )
                    	    {
                    	        alt2 = 1;
                    	    }
                    	}
                    	switch (alt2) 
                    	{
                    	    case 1 :
                    	        // DateTimeFilter.g:113:35: DIGIT
                    	        {
                    	        	mDIGIT(); 

                    	        }
                    	        break;

                    	}

                    	mDIGIT(); 
                    	Match('-'); 
                    	// DateTimeFilter.g:113:52: ( DIGIT )?
                    	int alt3 = 2;
                    	int LA3_0 = input.LA(1);

                    	if ( ((LA3_0 >= '0' && LA3_0 <= '9')) )
                    	{
                    	    int LA3_1 = input.LA(2);

                    	    if ( ((LA3_1 >= '0' && LA3_1 <= '9')) )
                    	    {
                    	        alt3 = 1;
                    	    }
                    	}
                    	switch (alt3) 
                    	{
                    	    case 1 :
                    	        // DateTimeFilter.g:113:52: DIGIT
                    	        {
                    	        	mDIGIT(); 

                    	        }
                    	        break;

                    	}

                    	mDIGIT(); 

                    }
                    break;
                case 2 :
                    // DateTimeFilter.g:114:5: ( DIGIT )? DIGIT '.' ( DIGIT )? DIGIT '.' ( DIGIT DIGIT DIGIT DIGIT )?
                    {
                    	// DateTimeFilter.g:114:5: ( DIGIT )?
                    	int alt4 = 2;
                    	int LA4_0 = input.LA(1);

                    	if ( ((LA4_0 >= '0' && LA4_0 <= '9')) )
                    	{
                    	    int LA4_1 = input.LA(2);

                    	    if ( ((LA4_1 >= '0' && LA4_1 <= '9')) )
                    	    {
                    	        alt4 = 1;
                    	    }
                    	}
                    	switch (alt4) 
                    	{
                    	    case 1 :
                    	        // DateTimeFilter.g:114:5: DIGIT
                    	        {
                    	        	mDIGIT(); 

                    	        }
                    	        break;

                    	}

                    	mDIGIT(); 
                    	Match('.'); 
                    	// DateTimeFilter.g:114:23: ( DIGIT )?
                    	int alt5 = 2;
                    	int LA5_0 = input.LA(1);

                    	if ( ((LA5_0 >= '0' && LA5_0 <= '9')) )
                    	{
                    	    int LA5_1 = input.LA(2);

                    	    if ( ((LA5_1 >= '0' && LA5_1 <= '9')) )
                    	    {
                    	        alt5 = 1;
                    	    }
                    	}
                    	switch (alt5) 
                    	{
                    	    case 1 :
                    	        // DateTimeFilter.g:114:23: DIGIT
                    	        {
                    	        	mDIGIT(); 

                    	        }
                    	        break;

                    	}

                    	mDIGIT(); 
                    	Match('.'); 
                    	// DateTimeFilter.g:114:40: ( DIGIT DIGIT DIGIT DIGIT )?
                    	int alt6 = 2;
                    	int LA6_0 = input.LA(1);

                    	if ( ((LA6_0 >= '0' && LA6_0 <= '9')) )
                    	{
                    	    alt6 = 1;
                    	}
                    	switch (alt6) 
                    	{
                    	    case 1 :
                    	        // DateTimeFilter.g:114:41: DIGIT DIGIT DIGIT DIGIT
                    	        {
                    	        	mDIGIT(); 
                    	        	mDIGIT(); 
                    	        	mDIGIT(); 
                    	        	mDIGIT(); 

                    	        }
                    	        break;

                    	}


                    }
                    break;
                case 3 :
                    // DateTimeFilter.g:115:5: ( DIGIT )? DIGIT '/' ( DIGIT )? DIGIT ( '/' DIGIT DIGIT DIGIT DIGIT )?
                    {
                    	// DateTimeFilter.g:115:5: ( DIGIT )?
                    	int alt7 = 2;
                    	int LA7_0 = input.LA(1);

                    	if ( ((LA7_0 >= '0' && LA7_0 <= '9')) )
                    	{
                    	    int LA7_1 = input.LA(2);

                    	    if ( ((LA7_1 >= '0' && LA7_1 <= '9')) )
                    	    {
                    	        alt7 = 1;
                    	    }
                    	}
                    	switch (alt7) 
                    	{
                    	    case 1 :
                    	        // DateTimeFilter.g:115:5: DIGIT
                    	        {
                    	        	mDIGIT(); 

                    	        }
                    	        break;

                    	}

                    	mDIGIT(); 
                    	Match('/'); 
                    	// DateTimeFilter.g:115:23: ( DIGIT )?
                    	int alt8 = 2;
                    	int LA8_0 = input.LA(1);

                    	if ( ((LA8_0 >= '0' && LA8_0 <= '9')) )
                    	{
                    	    int LA8_1 = input.LA(2);

                    	    if ( ((LA8_1 >= '0' && LA8_1 <= '9')) )
                    	    {
                    	        alt8 = 1;
                    	    }
                    	}
                    	switch (alt8) 
                    	{
                    	    case 1 :
                    	        // DateTimeFilter.g:115:23: DIGIT
                    	        {
                    	        	mDIGIT(); 

                    	        }
                    	        break;

                    	}

                    	mDIGIT(); 
                    	// DateTimeFilter.g:115:36: ( '/' DIGIT DIGIT DIGIT DIGIT )?
                    	int alt9 = 2;
                    	int LA9_0 = input.LA(1);

                    	if ( (LA9_0 == '/') )
                    	{
                    	    alt9 = 1;
                    	}
                    	switch (alt9) 
                    	{
                    	    case 1 :
                    	        // DateTimeFilter.g:115:37: '/' DIGIT DIGIT DIGIT DIGIT
                    	        {
                    	        	Match('/'); 
                    	        	mDIGIT(); 
                    	        	mDIGIT(); 
                    	        	mDIGIT(); 
                    	        	mDIGIT(); 

                    	        }
                    	        break;

                    	}


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
    // $ANTLR end "DATE"

    // $ANTLR start "TIME"
    public void mTIME() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = TIME;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:118:5: ( ( DIGIT )? DIGIT ':' ( DIGIT )? DIGIT ( ':' ( DIGIT )? DIGIT ( '.' DIGIT ( ( DIGIT )? DIGIT )? )? )? )
            // DateTimeFilter.g:118:7: ( DIGIT )? DIGIT ':' ( DIGIT )? DIGIT ( ':' ( DIGIT )? DIGIT ( '.' DIGIT ( ( DIGIT )? DIGIT )? )? )?
            {
            	// DateTimeFilter.g:118:7: ( DIGIT )?
            	int alt11 = 2;
            	int LA11_0 = input.LA(1);

            	if ( ((LA11_0 >= '0' && LA11_0 <= '9')) )
            	{
            	    int LA11_1 = input.LA(2);

            	    if ( ((LA11_1 >= '0' && LA11_1 <= '9')) )
            	    {
            	        alt11 = 1;
            	    }
            	}
            	switch (alt11) 
            	{
            	    case 1 :
            	        // DateTimeFilter.g:118:7: DIGIT
            	        {
            	        	mDIGIT(); 

            	        }
            	        break;

            	}

            	mDIGIT(); 
            	Match(':'); 
            	// DateTimeFilter.g:118:24: ( DIGIT )?
            	int alt12 = 2;
            	int LA12_0 = input.LA(1);

            	if ( ((LA12_0 >= '0' && LA12_0 <= '9')) )
            	{
            	    int LA12_1 = input.LA(2);

            	    if ( ((LA12_1 >= '0' && LA12_1 <= '9')) )
            	    {
            	        alt12 = 1;
            	    }
            	}
            	switch (alt12) 
            	{
            	    case 1 :
            	        // DateTimeFilter.g:118:24: DIGIT
            	        {
            	        	mDIGIT(); 

            	        }
            	        break;

            	}

            	mDIGIT(); 
            	// DateTimeFilter.g:118:37: ( ':' ( DIGIT )? DIGIT ( '.' DIGIT ( ( DIGIT )? DIGIT )? )? )?
            	int alt17 = 2;
            	int LA17_0 = input.LA(1);

            	if ( (LA17_0 == ':') )
            	{
            	    alt17 = 1;
            	}
            	switch (alt17) 
            	{
            	    case 1 :
            	        // DateTimeFilter.g:118:39: ':' ( DIGIT )? DIGIT ( '.' DIGIT ( ( DIGIT )? DIGIT )? )?
            	        {
            	        	Match(':'); 
            	        	// DateTimeFilter.g:118:43: ( DIGIT )?
            	        	int alt13 = 2;
            	        	int LA13_0 = input.LA(1);

            	        	if ( ((LA13_0 >= '0' && LA13_0 <= '9')) )
            	        	{
            	        	    int LA13_1 = input.LA(2);

            	        	    if ( ((LA13_1 >= '0' && LA13_1 <= '9')) )
            	        	    {
            	        	        alt13 = 1;
            	        	    }
            	        	}
            	        	switch (alt13) 
            	        	{
            	        	    case 1 :
            	        	        // DateTimeFilter.g:118:43: DIGIT
            	        	        {
            	        	        	mDIGIT(); 

            	        	        }
            	        	        break;

            	        	}

            	        	mDIGIT(); 
            	        	// DateTimeFilter.g:118:56: ( '.' DIGIT ( ( DIGIT )? DIGIT )? )?
            	        	int alt16 = 2;
            	        	int LA16_0 = input.LA(1);

            	        	if ( (LA16_0 == '.') )
            	        	{
            	        	    alt16 = 1;
            	        	}
            	        	switch (alt16) 
            	        	{
            	        	    case 1 :
            	        	        // DateTimeFilter.g:118:58: '.' DIGIT ( ( DIGIT )? DIGIT )?
            	        	        {
            	        	        	Match('.'); 
            	        	        	mDIGIT(); 
            	        	        	// DateTimeFilter.g:118:68: ( ( DIGIT )? DIGIT )?
            	        	        	int alt15 = 2;
            	        	        	int LA15_0 = input.LA(1);

            	        	        	if ( ((LA15_0 >= '0' && LA15_0 <= '9')) )
            	        	        	{
            	        	        	    alt15 = 1;
            	        	        	}
            	        	        	switch (alt15) 
            	        	        	{
            	        	        	    case 1 :
            	        	        	        // DateTimeFilter.g:118:69: ( DIGIT )? DIGIT
            	        	        	        {
            	        	        	        	// DateTimeFilter.g:118:69: ( DIGIT )?
            	        	        	        	int alt14 = 2;
            	        	        	        	int LA14_0 = input.LA(1);

            	        	        	        	if ( ((LA14_0 >= '0' && LA14_0 <= '9')) )
            	        	        	        	{
            	        	        	        	    int LA14_1 = input.LA(2);

            	        	        	        	    if ( ((LA14_1 >= '0' && LA14_1 <= '9')) )
            	        	        	        	    {
            	        	        	        	        alt14 = 1;
            	        	        	        	    }
            	        	        	        	}
            	        	        	        	switch (alt14) 
            	        	        	        	{
            	        	        	        	    case 1 :
            	        	        	        	        // DateTimeFilter.g:118:69: DIGIT
            	        	        	        	        {
            	        	        	        	        	mDIGIT(); 

            	        	        	        	        }
            	        	        	        	        break;

            	        	        	        	}

            	        	        	        	mDIGIT(); 

            	        	        	        }
            	        	        	        break;

            	        	        	}


            	        	        }
            	        	        break;

            	        	}


            	        }
            	        break;

            	}


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "TIME"

    // $ANTLR start "FLOW_MONTH"
    public void mFLOW_MONTH() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = FLOW_MONTH;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:120:11: ( ( DIGIT )? DIGIT '/' )
            // DateTimeFilter.g:120:13: ( DIGIT )? DIGIT '/'
            {
            	// DateTimeFilter.g:120:13: ( DIGIT )?
            	int alt18 = 2;
            	int LA18_0 = input.LA(1);

            	if ( ((LA18_0 >= '0' && LA18_0 <= '9')) )
            	{
            	    int LA18_1 = input.LA(2);

            	    if ( ((LA18_1 >= '0' && LA18_1 <= '9')) )
            	    {
            	        alt18 = 1;
            	    }
            	}
            	switch (alt18) 
            	{
            	    case 1 :
            	        // DateTimeFilter.g:120:13: DIGIT
            	        {
            	        	mDIGIT(); 

            	        }
            	        break;

            	}

            	mDIGIT(); 
            	Match('/'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "FLOW_MONTH"

    // $ANTLR start "FLOW_DAY"
    public void mFLOW_DAY() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = FLOW_DAY;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:121:9: ( ( DIGIT )? DIGIT '.' )
            // DateTimeFilter.g:121:11: ( DIGIT )? DIGIT '.'
            {
            	// DateTimeFilter.g:121:11: ( DIGIT )?
            	int alt19 = 2;
            	int LA19_0 = input.LA(1);

            	if ( ((LA19_0 >= '0' && LA19_0 <= '9')) )
            	{
            	    int LA19_1 = input.LA(2);

            	    if ( ((LA19_1 >= '0' && LA19_1 <= '9')) )
            	    {
            	        alt19 = 1;
            	    }
            	}
            	switch (alt19) 
            	{
            	    case 1 :
            	        // DateTimeFilter.g:121:11: DIGIT
            	        {
            	        	mDIGIT(); 

            	        }
            	        break;

            	}

            	mDIGIT(); 
            	Match('.'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "FLOW_DAY"

    // $ANTLR start "YEAR_MONTH"
    public void mYEAR_MONTH() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = YEAR_MONTH;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:122:11: ( DIGIT DIGIT DIGIT DIGIT '-' ( DIGIT )? DIGIT )
            // DateTimeFilter.g:122:13: DIGIT DIGIT DIGIT DIGIT '-' ( DIGIT )? DIGIT
            {
            	mDIGIT(); 
            	mDIGIT(); 
            	mDIGIT(); 
            	mDIGIT(); 
            	Match('-'); 
            	// DateTimeFilter.g:122:41: ( DIGIT )?
            	int alt20 = 2;
            	int LA20_0 = input.LA(1);

            	if ( ((LA20_0 >= '0' && LA20_0 <= '9')) )
            	{
            	    int LA20_1 = input.LA(2);

            	    if ( ((LA20_1 >= '0' && LA20_1 <= '9')) )
            	    {
            	        alt20 = 1;
            	    }
            	}
            	switch (alt20) 
            	{
            	    case 1 :
            	        // DateTimeFilter.g:122:41: DIGIT
            	        {
            	        	mDIGIT(); 

            	        }
            	        break;

            	}

            	mDIGIT(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "YEAR_MONTH"

    // $ANTLR start "HOUR_ANY_MINUTE"
    public void mHOUR_ANY_MINUTE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = HOUR_ANY_MINUTE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:123:16: ( ( DIGIT )? DIGIT ':' '*' )
            // DateTimeFilter.g:123:18: ( DIGIT )? DIGIT ':' '*'
            {
            	// DateTimeFilter.g:123:18: ( DIGIT )?
            	int alt21 = 2;
            	int LA21_0 = input.LA(1);

            	if ( ((LA21_0 >= '0' && LA21_0 <= '9')) )
            	{
            	    int LA21_1 = input.LA(2);

            	    if ( ((LA21_1 >= '0' && LA21_1 <= '9')) )
            	    {
            	        alt21 = 1;
            	    }
            	}
            	switch (alt21) 
            	{
            	    case 1 :
            	        // DateTimeFilter.g:123:18: DIGIT
            	        {
            	        	mDIGIT(); 

            	        }
            	        break;

            	}

            	mDIGIT(); 
            	Match(':'); 
            	Match('*'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "HOUR_ANY_MINUTE"

    // $ANTLR start "JAN"
    public void mJAN() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = JAN;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:125:4: ( 'j' 'a' 'n' )
            // DateTimeFilter.g:125:6: 'j' 'a' 'n'
            {
            	Match('j'); 
            	Match('a'); 
            	Match('n'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "JAN"

    // $ANTLR start "FEB"
    public void mFEB() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = FEB;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:126:4: ( 'f' 'e' 'b' )
            // DateTimeFilter.g:126:6: 'f' 'e' 'b'
            {
            	Match('f'); 
            	Match('e'); 
            	Match('b'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "FEB"

    // $ANTLR start "MAR"
    public void mMAR() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = MAR;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:127:4: ( 'm' 'a' 'r' )
            // DateTimeFilter.g:127:6: 'm' 'a' 'r'
            {
            	Match('m'); 
            	Match('a'); 
            	Match('r'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "MAR"

    // $ANTLR start "APR"
    public void mAPR() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = APR;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:128:4: ( 'a' 'p' 'r' )
            // DateTimeFilter.g:128:6: 'a' 'p' 'r'
            {
            	Match('a'); 
            	Match('p'); 
            	Match('r'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "APR"

    // $ANTLR start "MAY"
    public void mMAY() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = MAY;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:129:4: ( 'm' 'a' 'y' )
            // DateTimeFilter.g:129:6: 'm' 'a' 'y'
            {
            	Match('m'); 
            	Match('a'); 
            	Match('y'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "MAY"

    // $ANTLR start "JUN"
    public void mJUN() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = JUN;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:130:4: ( 'j' 'u' 'n' )
            // DateTimeFilter.g:130:6: 'j' 'u' 'n'
            {
            	Match('j'); 
            	Match('u'); 
            	Match('n'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "JUN"

    // $ANTLR start "JUL"
    public void mJUL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = JUL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:131:4: ( 'j' 'u' 'l' )
            // DateTimeFilter.g:131:6: 'j' 'u' 'l'
            {
            	Match('j'); 
            	Match('u'); 
            	Match('l'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "JUL"

    // $ANTLR start "AUG"
    public void mAUG() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = AUG;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:132:4: ( 'a' 'u' 'g' )
            // DateTimeFilter.g:132:6: 'a' 'u' 'g'
            {
            	Match('a'); 
            	Match('u'); 
            	Match('g'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "AUG"

    // $ANTLR start "SEP"
    public void mSEP() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = SEP;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:133:4: ( 's' 'e' 'p' )
            // DateTimeFilter.g:133:6: 's' 'e' 'p'
            {
            	Match('s'); 
            	Match('e'); 
            	Match('p'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "SEP"

    // $ANTLR start "OCT"
    public void mOCT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = OCT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:134:4: ( 'o' 'c' 't' )
            // DateTimeFilter.g:134:6: 'o' 'c' 't'
            {
            	Match('o'); 
            	Match('c'); 
            	Match('t'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "OCT"

    // $ANTLR start "NOV"
    public void mNOV() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = NOV;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:135:4: ( 'n' 'o' 'v' )
            // DateTimeFilter.g:135:6: 'n' 'o' 'v'
            {
            	Match('n'); 
            	Match('o'); 
            	Match('v'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "NOV"

    // $ANTLR start "DEC"
    public void mDEC() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = DEC;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:136:4: ( 'd' 'e' 'c' )
            // DateTimeFilter.g:136:6: 'd' 'e' 'c'
            {
            	Match('d'); 
            	Match('e'); 
            	Match('c'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "DEC"

    // $ANTLR start "MON"
    public void mMON() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = MON;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:138:4: ( 'm' 'o' 'n' )
            // DateTimeFilter.g:138:6: 'm' 'o' 'n'
            {
            	Match('m'); 
            	Match('o'); 
            	Match('n'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "MON"

    // $ANTLR start "TUE"
    public void mTUE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = TUE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:139:4: ( 't' 'u' 'e' )
            // DateTimeFilter.g:139:6: 't' 'u' 'e'
            {
            	Match('t'); 
            	Match('u'); 
            	Match('e'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "TUE"

    // $ANTLR start "WED"
    public void mWED() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = WED;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:140:4: ( 'w' 'e' 'd' )
            // DateTimeFilter.g:140:6: 'w' 'e' 'd'
            {
            	Match('w'); 
            	Match('e'); 
            	Match('d'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "WED"

    // $ANTLR start "THU"
    public void mTHU() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = THU;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:141:4: ( 't' 'h' 'u' )
            // DateTimeFilter.g:141:6: 't' 'h' 'u'
            {
            	Match('t'); 
            	Match('h'); 
            	Match('u'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "THU"

    // $ANTLR start "FRI"
    public void mFRI() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = FRI;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:142:4: ( 'f' 'r' 'i' )
            // DateTimeFilter.g:142:6: 'f' 'r' 'i'
            {
            	Match('f'); 
            	Match('r'); 
            	Match('i'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "FRI"

    // $ANTLR start "SAT"
    public void mSAT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = SAT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:143:4: ( 's' 'a' 't' )
            // DateTimeFilter.g:143:6: 's' 'a' 't'
            {
            	Match('s'); 
            	Match('a'); 
            	Match('t'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "SAT"

    // $ANTLR start "SUN"
    public void mSUN() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = SUN;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:144:4: ( 's' 'u' 'n' )
            // DateTimeFilter.g:144:6: 's' 'u' 'n'
            {
            	Match('s'); 
            	Match('u'); 
            	Match('n'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "SUN"

    // $ANTLR start "WHITESPACE"
    public void mWHITESPACE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = WHITESPACE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:146:12: ( ( '\\t' | ' ' | '\\u000C' )+ )
            // DateTimeFilter.g:146:14: ( '\\t' | ' ' | '\\u000C' )+
            {
            	// DateTimeFilter.g:146:14: ( '\\t' | ' ' | '\\u000C' )+
            	int cnt22 = 0;
            	do 
            	{
            	    int alt22 = 2;
            	    int LA22_0 = input.LA(1);

            	    if ( (LA22_0 == '\t' || LA22_0 == '\f' || LA22_0 == ' ') )
            	    {
            	        alt22 = 1;
            	    }


            	    switch (alt22) 
            		{
            			case 1 :
            			    // DateTimeFilter.g:
            			    {
            			    	if ( input.LA(1) == '\t' || input.LA(1) == '\f' || input.LA(1) == ' ' ) 
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
            			    if ( cnt22 >= 1 ) goto loop22;
            		            EarlyExitException eee22 =
            		                new EarlyExitException(22, input);
            		            throw eee22;
            	    }
            	    cnt22++;
            	} while (true);

            	loop22:
            		;	// Stops C# compiler whining that label 'loop22' has no statements

            	 _channel = HIDDEN; 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "WHITESPACE"

    // $ANTLR start "ENDLINE"
    public void mENDLINE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = ENDLINE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:147:8: ( ( '\\r' | '\\n' )+ )
            // DateTimeFilter.g:147:10: ( '\\r' | '\\n' )+
            {
            	// DateTimeFilter.g:147:10: ( '\\r' | '\\n' )+
            	int cnt23 = 0;
            	do 
            	{
            	    int alt23 = 2;
            	    int LA23_0 = input.LA(1);

            	    if ( (LA23_0 == '\n' || LA23_0 == '\r') )
            	    {
            	        alt23 = 1;
            	    }


            	    switch (alt23) 
            		{
            			case 1 :
            			    // DateTimeFilter.g:
            			    {
            			    	if ( input.LA(1) == '\n' || input.LA(1) == '\r' ) 
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
            			    if ( cnt23 >= 1 ) goto loop23;
            		            EarlyExitException eee23 =
            		                new EarlyExitException(23, input);
            		            throw eee23;
            	    }
            	    cnt23++;
            	} while (true);

            	loop23:
            		;	// Stops C# compiler whining that label 'loop23' has no statements


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "ENDLINE"

    // $ANTLR start "DIGIT"
    public void mDIGIT() // throws RecognitionException [2]
    {
    		try
    		{
            // DateTimeFilter.g:150:17: ( '0' .. '9' )
            // DateTimeFilter.g:150:19: '0' .. '9'
            {
            	MatchRange('0','9'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "DIGIT"

    override public void mTokens() // throws RecognitionException 
    {
        // DateTimeFilter.g:1:8: ( MINUS | LT | GT | GE | LE | NE | EQ | COMMA | LAST_HOUR | THIS_HOUR | NEXT_HOUR | YESTERDAY | TODAY | TOMORROW | LAST_WEEK | THIS_WEEK | NEXT_WEEK | LAST_MONTH | THIS_MONTH | NEXT_MONTH | LAST_YEAR | THIS_YEAR | NEXT_YEAR | YEAR | DATE | TIME | FLOW_MONTH | FLOW_DAY | YEAR_MONTH | HOUR_ANY_MINUTE | JAN | FEB | MAR | APR | MAY | JUN | JUL | AUG | SEP | OCT | NOV | DEC | MON | TUE | WED | THU | FRI | SAT | SUN | WHITESPACE | ENDLINE )
        int alt24 = 51;
        alt24 = dfa24.Predict(input);
        switch (alt24) 
        {
            case 1 :
                // DateTimeFilter.g:1:10: MINUS
                {
                	mMINUS(); 

                }
                break;
            case 2 :
                // DateTimeFilter.g:1:16: LT
                {
                	mLT(); 

                }
                break;
            case 3 :
                // DateTimeFilter.g:1:19: GT
                {
                	mGT(); 

                }
                break;
            case 4 :
                // DateTimeFilter.g:1:22: GE
                {
                	mGE(); 

                }
                break;
            case 5 :
                // DateTimeFilter.g:1:25: LE
                {
                	mLE(); 

                }
                break;
            case 6 :
                // DateTimeFilter.g:1:28: NE
                {
                	mNE(); 

                }
                break;
            case 7 :
                // DateTimeFilter.g:1:31: EQ
                {
                	mEQ(); 

                }
                break;
            case 8 :
                // DateTimeFilter.g:1:34: COMMA
                {
                	mCOMMA(); 

                }
                break;
            case 9 :
                // DateTimeFilter.g:1:40: LAST_HOUR
                {
                	mLAST_HOUR(); 

                }
                break;
            case 10 :
                // DateTimeFilter.g:1:50: THIS_HOUR
                {
                	mTHIS_HOUR(); 

                }
                break;
            case 11 :
                // DateTimeFilter.g:1:60: NEXT_HOUR
                {
                	mNEXT_HOUR(); 

                }
                break;
            case 12 :
                // DateTimeFilter.g:1:70: YESTERDAY
                {
                	mYESTERDAY(); 

                }
                break;
            case 13 :
                // DateTimeFilter.g:1:80: TODAY
                {
                	mTODAY(); 

                }
                break;
            case 14 :
                // DateTimeFilter.g:1:86: TOMORROW
                {
                	mTOMORROW(); 

                }
                break;
            case 15 :
                // DateTimeFilter.g:1:95: LAST_WEEK
                {
                	mLAST_WEEK(); 

                }
                break;
            case 16 :
                // DateTimeFilter.g:1:105: THIS_WEEK
                {
                	mTHIS_WEEK(); 

                }
                break;
            case 17 :
                // DateTimeFilter.g:1:115: NEXT_WEEK
                {
                	mNEXT_WEEK(); 

                }
                break;
            case 18 :
                // DateTimeFilter.g:1:125: LAST_MONTH
                {
                	mLAST_MONTH(); 

                }
                break;
            case 19 :
                // DateTimeFilter.g:1:136: THIS_MONTH
                {
                	mTHIS_MONTH(); 

                }
                break;
            case 20 :
                // DateTimeFilter.g:1:147: NEXT_MONTH
                {
                	mNEXT_MONTH(); 

                }
                break;
            case 21 :
                // DateTimeFilter.g:1:158: LAST_YEAR
                {
                	mLAST_YEAR(); 

                }
                break;
            case 22 :
                // DateTimeFilter.g:1:168: THIS_YEAR
                {
                	mTHIS_YEAR(); 

                }
                break;
            case 23 :
                // DateTimeFilter.g:1:178: NEXT_YEAR
                {
                	mNEXT_YEAR(); 

                }
                break;
            case 24 :
                // DateTimeFilter.g:1:188: YEAR
                {
                	mYEAR(); 

                }
                break;
            case 25 :
                // DateTimeFilter.g:1:193: DATE
                {
                	mDATE(); 

                }
                break;
            case 26 :
                // DateTimeFilter.g:1:198: TIME
                {
                	mTIME(); 

                }
                break;
            case 27 :
                // DateTimeFilter.g:1:203: FLOW_MONTH
                {
                	mFLOW_MONTH(); 

                }
                break;
            case 28 :
                // DateTimeFilter.g:1:214: FLOW_DAY
                {
                	mFLOW_DAY(); 

                }
                break;
            case 29 :
                // DateTimeFilter.g:1:223: YEAR_MONTH
                {
                	mYEAR_MONTH(); 

                }
                break;
            case 30 :
                // DateTimeFilter.g:1:234: HOUR_ANY_MINUTE
                {
                	mHOUR_ANY_MINUTE(); 

                }
                break;
            case 31 :
                // DateTimeFilter.g:1:250: JAN
                {
                	mJAN(); 

                }
                break;
            case 32 :
                // DateTimeFilter.g:1:254: FEB
                {
                	mFEB(); 

                }
                break;
            case 33 :
                // DateTimeFilter.g:1:258: MAR
                {
                	mMAR(); 

                }
                break;
            case 34 :
                // DateTimeFilter.g:1:262: APR
                {
                	mAPR(); 

                }
                break;
            case 35 :
                // DateTimeFilter.g:1:266: MAY
                {
                	mMAY(); 

                }
                break;
            case 36 :
                // DateTimeFilter.g:1:270: JUN
                {
                	mJUN(); 

                }
                break;
            case 37 :
                // DateTimeFilter.g:1:274: JUL
                {
                	mJUL(); 

                }
                break;
            case 38 :
                // DateTimeFilter.g:1:278: AUG
                {
                	mAUG(); 

                }
                break;
            case 39 :
                // DateTimeFilter.g:1:282: SEP
                {
                	mSEP(); 

                }
                break;
            case 40 :
                // DateTimeFilter.g:1:286: OCT
                {
                	mOCT(); 

                }
                break;
            case 41 :
                // DateTimeFilter.g:1:290: NOV
                {
                	mNOV(); 

                }
                break;
            case 42 :
                // DateTimeFilter.g:1:294: DEC
                {
                	mDEC(); 

                }
                break;
            case 43 :
                // DateTimeFilter.g:1:298: MON
                {
                	mMON(); 

                }
                break;
            case 44 :
                // DateTimeFilter.g:1:302: TUE
                {
                	mTUE(); 

                }
                break;
            case 45 :
                // DateTimeFilter.g:1:306: WED
                {
                	mWED(); 

                }
                break;
            case 46 :
                // DateTimeFilter.g:1:310: THU
                {
                	mTHU(); 

                }
                break;
            case 47 :
                // DateTimeFilter.g:1:314: FRI
                {
                	mFRI(); 

                }
                break;
            case 48 :
                // DateTimeFilter.g:1:318: SAT
                {
                	mSAT(); 

                }
                break;
            case 49 :
                // DateTimeFilter.g:1:322: SUN
                {
                	mSUN(); 

                }
                break;
            case 50 :
                // DateTimeFilter.g:1:326: WHITESPACE
                {
                	mWHITESPACE(); 

                }
                break;
            case 51 :
                // DateTimeFilter.g:1:337: ENDLINE
                {
                	mENDLINE(); 

                }
                break;

        }

    }


    protected DFA24 dfa24;
	private void InitializeCyclicDFAs()
	{
	    this.dfa24 = new DFA24(this);
	}

    const string DFA24_eotS =
        "\x02\uffff\x01\x17\x01\x19\x1d\uffff\x01\x37\x01\x38\x1f\uffff"+
        "\x01\x46\x11\uffff\x01\x55\x01\uffff\x01\x55";
    const string DFA24_eofS =
        "\x57\uffff";
    const string DFA24_minS =
        "\x01\x09\x01\uffff\x02\x3d\x03\uffff\x01\x61\x01\x68\x01\x65\x01"+
        "\uffff\x01\x2e\x01\x61\x01\x65\x01\x61\x01\x70\x01\x61\x09\uffff"+
        "\x01\x73\x01\x69\x01\x64\x01\uffff\x01\x78\x01\uffff\x01\x2e\x02"+
        "\x30\x01\x2a\x01\uffff\x01\x6c\x02\uffff\x01\x72\x06\uffff\x01\x74"+
        "\x01\x73\x03\uffff\x01\x74\x01\x30\x09\uffff\x03\x5f\x01\x2d\x03"+
        "\x68\x01\uffff\x01\x30\x0c\uffff\x01\x2d\x01\uffff\x01\x2d";
    const string DFA24_maxS =
        "\x01\x79\x01\uffff\x01\x3e\x01\x3d\x03\uffff\x01\x61\x01\x75\x01"+
        "\x6f\x01\uffff\x01\x3a\x01\x75\x01\x72\x01\x6f\x02\x75\x09\uffff"+
        "\x01\x73\x01\x75\x01\x6d\x01\uffff\x01\x78\x01\uffff\x01\x3a\x03"+
        "\x39\x01\uffff\x01\x6e\x02\uffff\x01\x79\x06\uffff\x01\x74\x01\x73"+
        "\x03\uffff\x01\x74\x01\x39\x09\uffff\x03\x5f\x01\x2d\x03\x79\x01"+
        "\uffff\x01\x39\x0c\uffff\x01\x39\x01\uffff\x01\x2d";
    const string DFA24_acceptS =
        "\x01\uffff\x01\x01\x02\uffff\x01\x06\x01\x07\x01\x08\x03\uffff"+
        "\x01\x0c\x06\uffff\x01\x28\x01\x2a\x01\x2d\x01\x32\x01\x33\x01\x05"+
        "\x01\x02\x01\x04\x01\x03\x03\uffff\x01\x2c\x01\uffff\x01\x29\x04"+
        "\uffff\x01\x1f\x01\uffff\x01\x20\x01\x2f\x01\uffff\x01\x2b\x01\x22"+
        "\x01\x26\x01\x27\x01\x30\x01\x31\x02\uffff\x01\x2e\x01\x0d\x01\x0e"+
        "\x02\uffff\x01\x19\x01\x1b\x01\x1c\x01\x1e\x01\x1a\x01\x24\x01\x25"+
        "\x01\x21\x01\x23\x07\uffff\x01\x18\x01\uffff\x01\x09\x01\x0f\x01"+
        "\x12\x01\x15\x01\x0a\x01\x10\x01\x13\x01\x16\x01\x0b\x01\x11\x01"+
        "\x14\x01\x17\x01\uffff\x01\x1d\x01\uffff";
    const string DFA24_specialS =
        "\x57\uffff}>";
    static readonly string[] DFA24_transitionS = {
            "\x01\x14\x01\x15\x01\uffff\x01\x14\x01\x15\x12\uffff\x01\x14"+
            "\x01\x04\x0a\uffff\x01\x06\x01\x01\x02\uffff\x0a\x0b\x02\uffff"+
            "\x01\x02\x01\x05\x01\x03\x22\uffff\x01\x0f\x02\uffff\x01\x12"+
            "\x01\uffff\x01\x0d\x03\uffff\x01\x0c\x01\uffff\x01\x07\x01\x0e"+
            "\x01\x09\x01\x11\x03\uffff\x01\x10\x01\x08\x02\uffff\x01\x13"+
            "\x01\uffff\x01\x0a",
            "",
            "\x01\x16\x01\x04",
            "\x01\x18",
            "",
            "",
            "",
            "\x01\x1a",
            "\x01\x1b\x06\uffff\x01\x1c\x05\uffff\x01\x1d",
            "\x01\x1e\x09\uffff\x01\x1f",
            "",
            "\x01\x22\x01\x21\x0a\x20\x01\x23",
            "\x01\x24\x13\uffff\x01\x25",
            "\x01\x26\x0c\uffff\x01\x27",
            "\x01\x28\x0d\uffff\x01\x29",
            "\x01\x2a\x04\uffff\x01\x2b",
            "\x01\x2d\x03\uffff\x01\x2c\x0f\uffff\x01\x2e",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\x2f",
            "\x01\x30\x0b\uffff\x01\x31",
            "\x01\x32\x08\uffff\x01\x33",
            "",
            "\x01\x34",
            "",
            "\x01\x22\x01\x21\x0a\x35\x01\x23",
            "\x0a\x36",
            "\x0a\x36",
            "\x01\x39\x05\uffff\x0a\x3a",
            "",
            "\x01\x3c\x01\uffff\x01\x3b",
            "",
            "",
            "\x01\x3d\x06\uffff\x01\x3e",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\x3f",
            "\x01\x40",
            "",
            "",
            "",
            "\x01\x41",
            "\x0a\x42",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\x43",
            "\x01\x44",
            "\x01\x45",
            "\x01\x47",
            "\x01\x48\x04\uffff\x01\x4a\x09\uffff\x01\x49\x01\uffff\x01"+
            "\x4b",
            "\x01\x4c\x04\uffff\x01\x4e\x09\uffff\x01\x4d\x01\uffff\x01"+
            "\x4f",
            "\x01\x50\x04\uffff\x01\x52\x09\uffff\x01\x51\x01\uffff\x01"+
            "\x53",
            "",
            "\x0a\x54",
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
            "\x01\x36\x02\uffff\x0a\x56",
            "",
            "\x01\x36"
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
            get { return "1:1: Tokens : ( MINUS | LT | GT | GE | LE | NE | EQ | COMMA | LAST_HOUR | THIS_HOUR | NEXT_HOUR | YESTERDAY | TODAY | TOMORROW | LAST_WEEK | THIS_WEEK | NEXT_WEEK | LAST_MONTH | THIS_MONTH | NEXT_MONTH | LAST_YEAR | THIS_YEAR | NEXT_YEAR | YEAR | DATE | TIME | FLOW_MONTH | FLOW_DAY | YEAR_MONTH | HOUR_ANY_MINUTE | JAN | FEB | MAR | APR | MAY | JUN | JUL | AUG | SEP | OCT | NOV | DEC | MON | TUE | WED | THU | FRI | SAT | SUN | WHITESPACE | ENDLINE );"; }
        }

    }

 
    
}
