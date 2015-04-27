// $ANTLR 3.2 Sep 23, 2009 12:02:23 DateTimeFilter.g 2015-01-03 12:47:24

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
    public const int LT = 42;
    public const int FLOW_MONTH = 9;
    public const int T_AUG = 19;
    public const int YEAR = 6;
    public const int HOUR_ANY_MINUTE = 8;
    public const int T_OCT = 21;
    public const int T_NEXT = 34;
    public const int EOF = -1;
    public const int T_SEP = 20;
    public const int T_SAT = 29;
    public const int YEAR_MONTH = 11;
    public const int TIME_SECOND = 54;
    public const int COMMA = 55;
    public const int T_NULL = 47;
    public const int T_SUN = 30;
    public const int T_WED = 26;
    public const int TIME_MINUE = 53;
    public const int T_FRI = 28;
    public const int FLOW_DAY = 10;
    public const int DIGIT = 57;
    public const int EQ = 41;
    public const int DOT = 5;
    public const int T_YESTERDAY = 35;
    public const int NE = 46;
    public const int T_WEEK = 38;
    public const int D = 74;
    public const int E = 65;
    public const int F = 76;
    public const int GE = 45;
    public const int T_APR = 15;
    public const int G = 79;
    public const int A = 59;
    public const int TIME_SECOND_FRACTION = 52;
    public const int B = 77;
    public const int T_THIS = 33;
    public const int C = 80;
    public const int NE2 = 50;
    public const int T_TUE = 25;
    public const int T_TOMORROW = 37;
    public const int L = 58;
    public const int M = 72;
    public const int N = 64;
    public const int O = 67;
    public const int H = 62;
    public const int I = 63;
    public const int J = 75;
    public const int T_LAST = 31;
    public const int K = 71;
    public const int U = 68;
    public const int T = 61;
    public const int W = 70;
    public const int WHITESPACE = 82;
    public const int T_YEAR = 40;
    public const int V = 81;
    public const int Q = 83;
    public const int P = 78;
    public const int T_MONTH = 39;
    public const int S = 60;
    public const int MINUS = 51;
    public const int R = 69;
    public const int Y = 73;
    public const int SQL_LITERAL = 4;
    public const int EQ2 = 49;
    public const int X = 66;
    public const int T_DEC = 23;
    public const int Z = 84;
    public const int T_THU = 27;
    public const int T_HOUR = 32;
    public const int T_JAN = 12;
    public const int T_JUN = 17;
    public const int GT = 44;
    public const int T_MON = 24;
    public const int ENDLINE = 56;
    public const int T_TODAY = 36;
    public const int T_MAY = 16;
    public const int DATE = 7;
    public const int T_NOT = 48;
    public const int T_NOV = 22;
    public const int T_FEB = 13;
    public const int LE = 43;
    public const int T_MAR = 14;
    public const int T_JUL = 18;

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
            // DateTimeFilter.g:127:6: ( '-' )
            // DateTimeFilter.g:127:9: '-'
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
            // DateTimeFilter.g:128:3: ( '<' )
            // DateTimeFilter.g:128:6: '<'
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
            // DateTimeFilter.g:129:3: ( '>' )
            // DateTimeFilter.g:129:6: '>'
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
            // DateTimeFilter.g:130:3: ( '>=' )
            // DateTimeFilter.g:130:6: '>='
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
            // DateTimeFilter.g:131:3: ( '<=' )
            // DateTimeFilter.g:131:6: '<='
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
            // DateTimeFilter.g:132:3: ( '<>' )
            // DateTimeFilter.g:132:6: '<>'
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
    // $ANTLR end "NE"

    // $ANTLR start "EQ"
    public void mEQ() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = EQ;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:133:3: ( '=' )
            // DateTimeFilter.g:133:6: '='
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
            // DateTimeFilter.g:134:6: ( ',' )
            // DateTimeFilter.g:134:8: ','
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

    // $ANTLR start "DOT"
    public void mDOT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = DOT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:135:4: ( '.' )
            // DateTimeFilter.g:135:6: '.'
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

    // $ANTLR start "EQ2"
    public void mEQ2() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = EQ2;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:136:4: ( '==' )
            // DateTimeFilter.g:136:7: '=='
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
    // $ANTLR end "EQ2"

    // $ANTLR start "NE2"
    public void mNE2() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = NE2;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:137:4: ( '!=' )
            // DateTimeFilter.g:137:7: '!='
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
    // $ANTLR end "NE2"

    // $ANTLR start "YEAR"
    public void mYEAR() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = YEAR;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:139:5: ( DIGIT DIGIT DIGIT DIGIT )
            // DateTimeFilter.g:139:7: DIGIT DIGIT DIGIT DIGIT
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
            // DateTimeFilter.g:141:5: ( DIGIT DIGIT DIGIT DIGIT '-' ( DIGIT )? DIGIT '-' ( DIGIT )? DIGIT | ( DIGIT )? DIGIT '.' ( DIGIT )? DIGIT '.' ( DIGIT DIGIT DIGIT DIGIT )? | ( DIGIT )? DIGIT '/' ( DIGIT )? DIGIT ( '/' DIGIT DIGIT DIGIT DIGIT )? )
            int alt9 = 3;
            int LA9_0 = input.LA(1);

            if ( ((LA9_0 >= '0' && LA9_0 <= '9')) )
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
                    case '.':
                    	{
                        alt9 = 2;
                        }
                        break;
                    case '/':
                    	{
                        alt9 = 3;
                        }
                        break;
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
                        alt9 = 1;
                        }
                        break;
                    	default:
                    	    NoViableAltException nvae_d9s2 =
                    	        new NoViableAltException("", 9, 2, input);

                    	    throw nvae_d9s2;
                    }

                    }
                    break;
                case '.':
                	{
                    alt9 = 2;
                    }
                    break;
                case '/':
                	{
                    alt9 = 3;
                    }
                    break;
                	default:
                	    NoViableAltException nvae_d9s1 =
                	        new NoViableAltException("", 9, 1, input);

                	    throw nvae_d9s1;
                }

            }
            else 
            {
                NoViableAltException nvae_d9s0 =
                    new NoViableAltException("", 9, 0, input);

                throw nvae_d9s0;
            }
            switch (alt9) 
            {
                case 1 :
                    // DateTimeFilter.g:141:7: DIGIT DIGIT DIGIT DIGIT '-' ( DIGIT )? DIGIT '-' ( DIGIT )? DIGIT
                    {
                    	mDIGIT(); 
                    	mDIGIT(); 
                    	mDIGIT(); 
                    	mDIGIT(); 
                    	Match('-'); 
                    	// DateTimeFilter.g:141:35: ( DIGIT )?
                    	int alt1 = 2;
                    	int LA1_0 = input.LA(1);

                    	if ( ((LA1_0 >= '0' && LA1_0 <= '9')) )
                    	{
                    	    int LA1_1 = input.LA(2);

                    	    if ( ((LA1_1 >= '0' && LA1_1 <= '9')) )
                    	    {
                    	        alt1 = 1;
                    	    }
                    	}
                    	switch (alt1) 
                    	{
                    	    case 1 :
                    	        // DateTimeFilter.g:141:35: DIGIT
                    	        {
                    	        	mDIGIT(); 

                    	        }
                    	        break;

                    	}

                    	mDIGIT(); 
                    	Match('-'); 
                    	// DateTimeFilter.g:141:52: ( DIGIT )?
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
                    	        // DateTimeFilter.g:141:52: DIGIT
                    	        {
                    	        	mDIGIT(); 

                    	        }
                    	        break;

                    	}

                    	mDIGIT(); 

                    }
                    break;
                case 2 :
                    // DateTimeFilter.g:142:5: ( DIGIT )? DIGIT '.' ( DIGIT )? DIGIT '.' ( DIGIT DIGIT DIGIT DIGIT )?
                    {
                    	// DateTimeFilter.g:142:5: ( DIGIT )?
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
                    	        // DateTimeFilter.g:142:5: DIGIT
                    	        {
                    	        	mDIGIT(); 

                    	        }
                    	        break;

                    	}

                    	mDIGIT(); 
                    	Match('.'); 
                    	// DateTimeFilter.g:142:23: ( DIGIT )?
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
                    	        // DateTimeFilter.g:142:23: DIGIT
                    	        {
                    	        	mDIGIT(); 

                    	        }
                    	        break;

                    	}

                    	mDIGIT(); 
                    	Match('.'); 
                    	// DateTimeFilter.g:142:40: ( DIGIT DIGIT DIGIT DIGIT )?
                    	int alt5 = 2;
                    	int LA5_0 = input.LA(1);

                    	if ( ((LA5_0 >= '0' && LA5_0 <= '9')) )
                    	{
                    	    alt5 = 1;
                    	}
                    	switch (alt5) 
                    	{
                    	    case 1 :
                    	        // DateTimeFilter.g:142:41: DIGIT DIGIT DIGIT DIGIT
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
                    // DateTimeFilter.g:143:5: ( DIGIT )? DIGIT '/' ( DIGIT )? DIGIT ( '/' DIGIT DIGIT DIGIT DIGIT )?
                    {
                    	// DateTimeFilter.g:143:5: ( DIGIT )?
                    	int alt6 = 2;
                    	int LA6_0 = input.LA(1);

                    	if ( ((LA6_0 >= '0' && LA6_0 <= '9')) )
                    	{
                    	    int LA6_1 = input.LA(2);

                    	    if ( ((LA6_1 >= '0' && LA6_1 <= '9')) )
                    	    {
                    	        alt6 = 1;
                    	    }
                    	}
                    	switch (alt6) 
                    	{
                    	    case 1 :
                    	        // DateTimeFilter.g:143:5: DIGIT
                    	        {
                    	        	mDIGIT(); 

                    	        }
                    	        break;

                    	}

                    	mDIGIT(); 
                    	Match('/'); 
                    	// DateTimeFilter.g:143:23: ( DIGIT )?
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
                    	        // DateTimeFilter.g:143:23: DIGIT
                    	        {
                    	        	mDIGIT(); 

                    	        }
                    	        break;

                    	}

                    	mDIGIT(); 
                    	// DateTimeFilter.g:143:36: ( '/' DIGIT DIGIT DIGIT DIGIT )?
                    	int alt8 = 2;
                    	int LA8_0 = input.LA(1);

                    	if ( (LA8_0 == '/') )
                    	{
                    	    alt8 = 1;
                    	}
                    	switch (alt8) 
                    	{
                    	    case 1 :
                    	        // DateTimeFilter.g:143:37: '/' DIGIT DIGIT DIGIT DIGIT
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

    // $ANTLR start "TIME_MINUE"
    public void mTIME_MINUE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = TIME_MINUE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:146:11: ( ( DIGIT )? DIGIT ':' ( DIGIT )? DIGIT )
            // DateTimeFilter.g:146:13: ( DIGIT )? DIGIT ':' ( DIGIT )? DIGIT
            {
            	// DateTimeFilter.g:146:13: ( DIGIT )?
            	int alt10 = 2;
            	int LA10_0 = input.LA(1);

            	if ( ((LA10_0 >= '0' && LA10_0 <= '9')) )
            	{
            	    int LA10_1 = input.LA(2);

            	    if ( ((LA10_1 >= '0' && LA10_1 <= '9')) )
            	    {
            	        alt10 = 1;
            	    }
            	}
            	switch (alt10) 
            	{
            	    case 1 :
            	        // DateTimeFilter.g:146:13: DIGIT
            	        {
            	        	mDIGIT(); 

            	        }
            	        break;

            	}

            	mDIGIT(); 
            	Match(':'); 
            	// DateTimeFilter.g:146:30: ( DIGIT )?
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
            	        // DateTimeFilter.g:146:30: DIGIT
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
    // $ANTLR end "TIME_MINUE"

    // $ANTLR start "TIME_SECOND"
    public void mTIME_SECOND() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = TIME_SECOND;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:147:12: ( ( DIGIT )? DIGIT ':' ( DIGIT )? DIGIT ':' ( DIGIT )? DIGIT )
            // DateTimeFilter.g:147:14: ( DIGIT )? DIGIT ':' ( DIGIT )? DIGIT ':' ( DIGIT )? DIGIT
            {
            	// DateTimeFilter.g:147:14: ( DIGIT )?
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
            	        // DateTimeFilter.g:147:14: DIGIT
            	        {
            	        	mDIGIT(); 

            	        }
            	        break;

            	}

            	mDIGIT(); 
            	Match(':'); 
            	// DateTimeFilter.g:147:31: ( DIGIT )?
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
            	        // DateTimeFilter.g:147:31: DIGIT
            	        {
            	        	mDIGIT(); 

            	        }
            	        break;

            	}

            	mDIGIT(); 
            	Match(':'); 
            	// DateTimeFilter.g:147:48: ( DIGIT )?
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
            	        // DateTimeFilter.g:147:48: DIGIT
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
    // $ANTLR end "TIME_SECOND"

    // $ANTLR start "TIME_SECOND_FRACTION"
    public void mTIME_SECOND_FRACTION() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = TIME_SECOND_FRACTION;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:148:21: ( ( DIGIT )? DIGIT ':' ( DIGIT )? DIGIT ':' ( DIGIT )? DIGIT '.' ( DIGIT )* )
            // DateTimeFilter.g:148:23: ( DIGIT )? DIGIT ':' ( DIGIT )? DIGIT ':' ( DIGIT )? DIGIT '.' ( DIGIT )*
            {
            	// DateTimeFilter.g:148:23: ( DIGIT )?
            	int alt15 = 2;
            	int LA15_0 = input.LA(1);

            	if ( ((LA15_0 >= '0' && LA15_0 <= '9')) )
            	{
            	    int LA15_1 = input.LA(2);

            	    if ( ((LA15_1 >= '0' && LA15_1 <= '9')) )
            	    {
            	        alt15 = 1;
            	    }
            	}
            	switch (alt15) 
            	{
            	    case 1 :
            	        // DateTimeFilter.g:148:23: DIGIT
            	        {
            	        	mDIGIT(); 

            	        }
            	        break;

            	}

            	mDIGIT(); 
            	Match(':'); 
            	// DateTimeFilter.g:148:40: ( DIGIT )?
            	int alt16 = 2;
            	int LA16_0 = input.LA(1);

            	if ( ((LA16_0 >= '0' && LA16_0 <= '9')) )
            	{
            	    int LA16_1 = input.LA(2);

            	    if ( ((LA16_1 >= '0' && LA16_1 <= '9')) )
            	    {
            	        alt16 = 1;
            	    }
            	}
            	switch (alt16) 
            	{
            	    case 1 :
            	        // DateTimeFilter.g:148:40: DIGIT
            	        {
            	        	mDIGIT(); 

            	        }
            	        break;

            	}

            	mDIGIT(); 
            	Match(':'); 
            	// DateTimeFilter.g:148:57: ( DIGIT )?
            	int alt17 = 2;
            	int LA17_0 = input.LA(1);

            	if ( ((LA17_0 >= '0' && LA17_0 <= '9')) )
            	{
            	    int LA17_1 = input.LA(2);

            	    if ( ((LA17_1 >= '0' && LA17_1 <= '9')) )
            	    {
            	        alt17 = 1;
            	    }
            	}
            	switch (alt17) 
            	{
            	    case 1 :
            	        // DateTimeFilter.g:148:57: DIGIT
            	        {
            	        	mDIGIT(); 

            	        }
            	        break;

            	}

            	mDIGIT(); 
            	Match('.'); 
            	// DateTimeFilter.g:148:74: ( DIGIT )*
            	do 
            	{
            	    int alt18 = 2;
            	    int LA18_0 = input.LA(1);

            	    if ( ((LA18_0 >= '0' && LA18_0 <= '9')) )
            	    {
            	        alt18 = 1;
            	    }


            	    switch (alt18) 
            		{
            			case 1 :
            			    // DateTimeFilter.g:148:74: DIGIT
            			    {
            			    	mDIGIT(); 

            			    }
            			    break;

            			default:
            			    goto loop18;
            	    }
            	} while (true);

            	loop18:
            		;	// Stops C# compiler whining that label 'loop18' has no statements


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "TIME_SECOND_FRACTION"

    // $ANTLR start "FLOW_MONTH"
    public void mFLOW_MONTH() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = FLOW_MONTH;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:150:11: ( ( DIGIT )? DIGIT '/' )
            // DateTimeFilter.g:150:13: ( DIGIT )? DIGIT '/'
            {
            	// DateTimeFilter.g:150:13: ( DIGIT )?
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
            	        // DateTimeFilter.g:150:13: DIGIT
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
            // DateTimeFilter.g:151:9: ( ( DIGIT )? DIGIT '.' )
            // DateTimeFilter.g:151:11: ( DIGIT )? DIGIT '.'
            {
            	// DateTimeFilter.g:151:11: ( DIGIT )?
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
            	        // DateTimeFilter.g:151:11: DIGIT
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
            // DateTimeFilter.g:152:11: ( DIGIT DIGIT DIGIT DIGIT '-' ( DIGIT )? DIGIT )
            // DateTimeFilter.g:152:13: DIGIT DIGIT DIGIT DIGIT '-' ( DIGIT )? DIGIT
            {
            	mDIGIT(); 
            	mDIGIT(); 
            	mDIGIT(); 
            	mDIGIT(); 
            	Match('-'); 
            	// DateTimeFilter.g:152:41: ( DIGIT )?
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
            	        // DateTimeFilter.g:152:41: DIGIT
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
            // DateTimeFilter.g:153:16: ( ( DIGIT )? DIGIT ':' '*' )
            // DateTimeFilter.g:153:18: ( DIGIT )? DIGIT ':' '*'
            {
            	// DateTimeFilter.g:153:18: ( DIGIT )?
            	int alt22 = 2;
            	int LA22_0 = input.LA(1);

            	if ( ((LA22_0 >= '0' && LA22_0 <= '9')) )
            	{
            	    int LA22_1 = input.LA(2);

            	    if ( ((LA22_1 >= '0' && LA22_1 <= '9')) )
            	    {
            	        alt22 = 1;
            	    }
            	}
            	switch (alt22) 
            	{
            	    case 1 :
            	        // DateTimeFilter.g:153:18: DIGIT
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

    // $ANTLR start "T_LAST"
    public void mT_LAST() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_LAST;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:155:7: ( L A S T )
            // DateTimeFilter.g:155:9: L A S T
            {
            	mL(); 
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
    // $ANTLR end "T_LAST"

    // $ANTLR start "T_THIS"
    public void mT_THIS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_THIS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:156:7: ( T H I S )
            // DateTimeFilter.g:156:9: T H I S
            {
            	mT(); 
            	mH(); 
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
    // $ANTLR end "T_THIS"

    // $ANTLR start "T_NEXT"
    public void mT_NEXT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_NEXT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:157:7: ( N E X T )
            // DateTimeFilter.g:157:9: N E X T
            {
            	mN(); 
            	mE(); 
            	mX(); 
            	mT(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_NEXT"

    // $ANTLR start "T_HOUR"
    public void mT_HOUR() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_HOUR;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:159:7: ( H O U R )
            // DateTimeFilter.g:159:9: H O U R
            {
            	mH(); 
            	mO(); 
            	mU(); 
            	mR(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_HOUR"

    // $ANTLR start "T_WEEK"
    public void mT_WEEK() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_WEEK;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:160:7: ( W E E K )
            // DateTimeFilter.g:160:9: W E E K
            {
            	mW(); 
            	mE(); 
            	mE(); 
            	mK(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_WEEK"

    // $ANTLR start "T_MONTH"
    public void mT_MONTH() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_MONTH;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:161:8: ( M O N T H )
            // DateTimeFilter.g:161:10: M O N T H
            {
            	mM(); 
            	mO(); 
            	mN(); 
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
    // $ANTLR end "T_MONTH"

    // $ANTLR start "T_YEAR"
    public void mT_YEAR() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_YEAR;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:162:7: ( Y E A R )
            // DateTimeFilter.g:162:9: Y E A R
            {
            	mY(); 
            	mE(); 
            	mA(); 
            	mR(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_YEAR"

    // $ANTLR start "T_YESTERDAY"
    public void mT_YESTERDAY() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_YESTERDAY;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:164:12: ( Y E S T E R D A Y )
            // DateTimeFilter.g:164:14: Y E S T E R D A Y
            {
            	mY(); 
            	mE(); 
            	mS(); 
            	mT(); 
            	mE(); 
            	mR(); 
            	mD(); 
            	mA(); 
            	mY(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_YESTERDAY"

    // $ANTLR start "T_TODAY"
    public void mT_TODAY() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_TODAY;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:165:8: ( T O D A Y )
            // DateTimeFilter.g:165:10: T O D A Y
            {
            	mT(); 
            	mO(); 
            	mD(); 
            	mA(); 
            	mY(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_TODAY"

    // $ANTLR start "T_TOMORROW"
    public void mT_TOMORROW() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_TOMORROW;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:166:11: ( T O M O R R O W )
            // DateTimeFilter.g:166:13: T O M O R R O W
            {
            	mT(); 
            	mO(); 
            	mM(); 
            	mO(); 
            	mR(); 
            	mR(); 
            	mO(); 
            	mW(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_TOMORROW"

    // $ANTLR start "T_JAN"
    public void mT_JAN() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_JAN;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:168:6: ( J A N )
            // DateTimeFilter.g:168:8: J A N
            {
            	mJ(); 
            	mA(); 
            	mN(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_JAN"

    // $ANTLR start "T_FEB"
    public void mT_FEB() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_FEB;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:169:6: ( F E B )
            // DateTimeFilter.g:169:8: F E B
            {
            	mF(); 
            	mE(); 
            	mB(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_FEB"

    // $ANTLR start "T_MAR"
    public void mT_MAR() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_MAR;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:170:6: ( M A R )
            // DateTimeFilter.g:170:8: M A R
            {
            	mM(); 
            	mA(); 
            	mR(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_MAR"

    // $ANTLR start "T_APR"
    public void mT_APR() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_APR;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:171:6: ( A P R )
            // DateTimeFilter.g:171:8: A P R
            {
            	mA(); 
            	mP(); 
            	mR(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_APR"

    // $ANTLR start "T_MAY"
    public void mT_MAY() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_MAY;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:172:6: ( M A Y )
            // DateTimeFilter.g:172:8: M A Y
            {
            	mM(); 
            	mA(); 
            	mY(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_MAY"

    // $ANTLR start "T_JUN"
    public void mT_JUN() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_JUN;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:173:6: ( J U N )
            // DateTimeFilter.g:173:8: J U N
            {
            	mJ(); 
            	mU(); 
            	mN(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_JUN"

    // $ANTLR start "T_JUL"
    public void mT_JUL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_JUL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:174:6: ( J U L )
            // DateTimeFilter.g:174:8: J U L
            {
            	mJ(); 
            	mU(); 
            	mL(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_JUL"

    // $ANTLR start "T_AUG"
    public void mT_AUG() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_AUG;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:175:6: ( A U G )
            // DateTimeFilter.g:175:8: A U G
            {
            	mA(); 
            	mU(); 
            	mG(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_AUG"

    // $ANTLR start "T_SEP"
    public void mT_SEP() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_SEP;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:176:6: ( S E P )
            // DateTimeFilter.g:176:8: S E P
            {
            	mS(); 
            	mE(); 
            	mP(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_SEP"

    // $ANTLR start "T_OCT"
    public void mT_OCT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_OCT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:177:6: ( O C T )
            // DateTimeFilter.g:177:8: O C T
            {
            	mO(); 
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
    // $ANTLR end "T_OCT"

    // $ANTLR start "T_NOV"
    public void mT_NOV() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_NOV;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:178:6: ( N O V )
            // DateTimeFilter.g:178:8: N O V
            {
            	mN(); 
            	mO(); 
            	mV(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_NOV"

    // $ANTLR start "T_DEC"
    public void mT_DEC() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_DEC;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:179:6: ( D E C )
            // DateTimeFilter.g:179:8: D E C
            {
            	mD(); 
            	mE(); 
            	mC(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_DEC"

    // $ANTLR start "T_MON"
    public void mT_MON() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_MON;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:181:6: ( M O N )
            // DateTimeFilter.g:181:8: M O N
            {
            	mM(); 
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
    // $ANTLR end "T_MON"

    // $ANTLR start "T_TUE"
    public void mT_TUE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_TUE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:182:6: ( T U E )
            // DateTimeFilter.g:182:8: T U E
            {
            	mT(); 
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
    // $ANTLR end "T_TUE"

    // $ANTLR start "T_WED"
    public void mT_WED() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_WED;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:183:6: ( W E D )
            // DateTimeFilter.g:183:8: W E D
            {
            	mW(); 
            	mE(); 
            	mD(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_WED"

    // $ANTLR start "T_THU"
    public void mT_THU() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_THU;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:184:6: ( T H U )
            // DateTimeFilter.g:184:8: T H U
            {
            	mT(); 
            	mH(); 
            	mU(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_THU"

    // $ANTLR start "T_FRI"
    public void mT_FRI() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_FRI;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:185:6: ( F R I )
            // DateTimeFilter.g:185:8: F R I
            {
            	mF(); 
            	mR(); 
            	mI(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_FRI"

    // $ANTLR start "T_SAT"
    public void mT_SAT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_SAT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:186:6: ( S A T )
            // DateTimeFilter.g:186:8: S A T
            {
            	mS(); 
            	mA(); 
            	mT(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_SAT"

    // $ANTLR start "T_SUN"
    public void mT_SUN() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_SUN;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:187:6: ( S U N )
            // DateTimeFilter.g:187:8: S U N
            {
            	mS(); 
            	mU(); 
            	mN(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_SUN"

    // $ANTLR start "T_NULL"
    public void mT_NULL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_NULL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:189:7: ( N U L L )
            // DateTimeFilter.g:189:9: N U L L
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
    // $ANTLR end "T_NULL"

    // $ANTLR start "T_NOT"
    public void mT_NOT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_NOT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:190:6: ( N O T )
            // DateTimeFilter.g:190:8: N O T
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
    // $ANTLR end "T_NOT"

    // $ANTLR start "WHITESPACE"
    public void mWHITESPACE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = WHITESPACE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:192:12: ( ( '\\t' | ' ' | '\\u000C' )+ )
            // DateTimeFilter.g:192:14: ( '\\t' | ' ' | '\\u000C' )+
            {
            	// DateTimeFilter.g:192:14: ( '\\t' | ' ' | '\\u000C' )+
            	int cnt23 = 0;
            	do 
            	{
            	    int alt23 = 2;
            	    int LA23_0 = input.LA(1);

            	    if ( (LA23_0 == '\t' || LA23_0 == '\f' || LA23_0 == ' ') )
            	    {
            	        alt23 = 1;
            	    }


            	    switch (alt23) 
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
            			    if ( cnt23 >= 1 ) goto loop23;
            		            EarlyExitException eee23 =
            		                new EarlyExitException(23, input);
            		            throw eee23;
            	    }
            	    cnt23++;
            	} while (true);

            	loop23:
            		;	// Stops C# compiler whining that label 'loop23' has no statements

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
            // DateTimeFilter.g:193:8: ( ( '\\r' | '\\n' )+ )
            // DateTimeFilter.g:193:10: ( '\\r' | '\\n' )+
            {
            	// DateTimeFilter.g:193:10: ( '\\r' | '\\n' )+
            	int cnt24 = 0;
            	do 
            	{
            	    int alt24 = 2;
            	    int LA24_0 = input.LA(1);

            	    if ( (LA24_0 == '\n' || LA24_0 == '\r') )
            	    {
            	        alt24 = 1;
            	    }


            	    switch (alt24) 
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
            			    if ( cnt24 >= 1 ) goto loop24;
            		            EarlyExitException eee24 =
            		                new EarlyExitException(24, input);
            		            throw eee24;
            	    }
            	    cnt24++;
            	} while (true);

            	loop24:
            		;	// Stops C# compiler whining that label 'loop24' has no statements


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "ENDLINE"

    // $ANTLR start "SQL_LITERAL"
    public void mSQL_LITERAL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = SQL_LITERAL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // DateTimeFilter.g:195:12: ( ( '[' ( options {greedy=true; } : ~ ( ']' | '\\r' | '\\n' ) )* ']' ) )
            // DateTimeFilter.g:196:4: ( '[' ( options {greedy=true; } : ~ ( ']' | '\\r' | '\\n' ) )* ']' )
            {
            	// DateTimeFilter.g:196:4: ( '[' ( options {greedy=true; } : ~ ( ']' | '\\r' | '\\n' ) )* ']' )
            	// DateTimeFilter.g:196:5: '[' ( options {greedy=true; } : ~ ( ']' | '\\r' | '\\n' ) )* ']'
            	{
            		Match('['); 
            		// DateTimeFilter.g:197:5: ( options {greedy=true; } : ~ ( ']' | '\\r' | '\\n' ) )*
            		do 
            		{
            		    int alt25 = 2;
            		    int LA25_0 = input.LA(1);

            		    if ( ((LA25_0 >= '\u0000' && LA25_0 <= '\t') || (LA25_0 >= '\u000B' && LA25_0 <= '\f') || (LA25_0 >= '\u000E' && LA25_0 <= '\\') || (LA25_0 >= '^' && LA25_0 <= '\uFFFF')) )
            		    {
            		        alt25 = 1;
            		    }


            		    switch (alt25) 
            			{
            				case 1 :
            				    // DateTimeFilter.g:198:31: ~ ( ']' | '\\r' | '\\n' )
            				    {
            				    	if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '\t') || (input.LA(1) >= '\u000B' && input.LA(1) <= '\f') || (input.LA(1) >= '\u000E' && input.LA(1) <= '\\') || (input.LA(1) >= '^' && input.LA(1) <= '\uFFFF') ) 
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
            				    goto loop25;
            		    }
            		} while (true);

            		loop25:
            			;	// Stops C# compiler whining that label 'loop25' has no statements

            		Match(']'); 

            	}


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "SQL_LITERAL"

    // $ANTLR start "DIGIT"
    public void mDIGIT() // throws RecognitionException [2]
    {
    		try
    		{
            // DateTimeFilter.g:203:17: ( '0' .. '9' )
            // DateTimeFilter.g:203:19: '0' .. '9'
            {
            	MatchRange('0','9'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "DIGIT"

    // $ANTLR start "A"
    public void mA() // throws RecognitionException [2]
    {
    		try
    		{
            // DateTimeFilter.g:205:11: ( 'A' )
            // DateTimeFilter.g:205:13: 'A'
            {
            	Match('A'); 

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
            // DateTimeFilter.g:206:11: ( 'B' )
            // DateTimeFilter.g:206:13: 'B'
            {
            	Match('B'); 

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
            // DateTimeFilter.g:207:11: ( 'C' )
            // DateTimeFilter.g:207:13: 'C'
            {
            	Match('C'); 

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
            // DateTimeFilter.g:208:11: ( 'D' )
            // DateTimeFilter.g:208:13: 'D'
            {
            	Match('D'); 

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
            // DateTimeFilter.g:209:11: ( 'E' )
            // DateTimeFilter.g:209:13: 'E'
            {
            	Match('E'); 

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
            // DateTimeFilter.g:210:11: ( 'F' )
            // DateTimeFilter.g:210:13: 'F'
            {
            	Match('F'); 

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
            // DateTimeFilter.g:211:11: ( 'G' )
            // DateTimeFilter.g:211:13: 'G'
            {
            	Match('G'); 

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
            // DateTimeFilter.g:212:11: ( 'H' )
            // DateTimeFilter.g:212:13: 'H'
            {
            	Match('H'); 

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
            // DateTimeFilter.g:213:11: ( 'I' )
            // DateTimeFilter.g:213:13: 'I'
            {
            	Match('I'); 

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
            // DateTimeFilter.g:214:11: ( 'J' )
            // DateTimeFilter.g:214:13: 'J'
            {
            	Match('J'); 

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
            // DateTimeFilter.g:215:11: ( 'K' )
            // DateTimeFilter.g:215:13: 'K'
            {
            	Match('K'); 

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
            // DateTimeFilter.g:216:11: ( 'L' )
            // DateTimeFilter.g:216:13: 'L'
            {
            	Match('L'); 

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
            // DateTimeFilter.g:217:11: ( 'M' )
            // DateTimeFilter.g:217:13: 'M'
            {
            	Match('M'); 

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
            // DateTimeFilter.g:218:11: ( 'N' )
            // DateTimeFilter.g:218:13: 'N'
            {
            	Match('N'); 

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
            // DateTimeFilter.g:219:11: ( 'O' )
            // DateTimeFilter.g:219:13: 'O'
            {
            	Match('O'); 

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
            // DateTimeFilter.g:220:11: ( 'P' )
            // DateTimeFilter.g:220:13: 'P'
            {
            	Match('P'); 

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
            // DateTimeFilter.g:221:11: ( 'Q' )
            // DateTimeFilter.g:221:13: 'Q'
            {
            	Match('Q'); 

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
            // DateTimeFilter.g:222:11: ( 'R' )
            // DateTimeFilter.g:222:13: 'R'
            {
            	Match('R'); 

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
            // DateTimeFilter.g:223:11: ( 'S' )
            // DateTimeFilter.g:223:13: 'S'
            {
            	Match('S'); 

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
            // DateTimeFilter.g:224:11: ( 'T' )
            // DateTimeFilter.g:224:13: 'T'
            {
            	Match('T'); 

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
            // DateTimeFilter.g:225:11: ( 'U' )
            // DateTimeFilter.g:225:13: 'U'
            {
            	Match('U'); 

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
            // DateTimeFilter.g:226:11: ( 'V' )
            // DateTimeFilter.g:226:13: 'V'
            {
            	Match('V'); 

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
            // DateTimeFilter.g:227:11: ( 'W' )
            // DateTimeFilter.g:227:13: 'W'
            {
            	Match('W'); 

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
            // DateTimeFilter.g:228:11: ( 'X' )
            // DateTimeFilter.g:228:13: 'X'
            {
            	Match('X'); 

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
            // DateTimeFilter.g:229:11: ( 'Y' )
            // DateTimeFilter.g:229:13: 'Y'
            {
            	Match('Y'); 

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
            // DateTimeFilter.g:230:11: ( 'Z' )
            // DateTimeFilter.g:230:13: 'Z'
            {
            	Match('Z'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "Z"

    override public void mTokens() // throws RecognitionException 
    {
        // DateTimeFilter.g:1:8: ( MINUS | LT | GT | GE | LE | NE | EQ | COMMA | DOT | EQ2 | NE2 | YEAR | DATE | TIME_MINUE | TIME_SECOND | TIME_SECOND_FRACTION | FLOW_MONTH | FLOW_DAY | YEAR_MONTH | HOUR_ANY_MINUTE | T_LAST | T_THIS | T_NEXT | T_HOUR | T_WEEK | T_MONTH | T_YEAR | T_YESTERDAY | T_TODAY | T_TOMORROW | T_JAN | T_FEB | T_MAR | T_APR | T_MAY | T_JUN | T_JUL | T_AUG | T_SEP | T_OCT | T_NOV | T_DEC | T_MON | T_TUE | T_WED | T_THU | T_FRI | T_SAT | T_SUN | T_NULL | T_NOT | WHITESPACE | ENDLINE | SQL_LITERAL )
        int alt26 = 54;
        alt26 = dfa26.Predict(input);
        switch (alt26) 
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
                // DateTimeFilter.g:1:40: DOT
                {
                	mDOT(); 

                }
                break;
            case 10 :
                // DateTimeFilter.g:1:44: EQ2
                {
                	mEQ2(); 

                }
                break;
            case 11 :
                // DateTimeFilter.g:1:48: NE2
                {
                	mNE2(); 

                }
                break;
            case 12 :
                // DateTimeFilter.g:1:52: YEAR
                {
                	mYEAR(); 

                }
                break;
            case 13 :
                // DateTimeFilter.g:1:57: DATE
                {
                	mDATE(); 

                }
                break;
            case 14 :
                // DateTimeFilter.g:1:62: TIME_MINUE
                {
                	mTIME_MINUE(); 

                }
                break;
            case 15 :
                // DateTimeFilter.g:1:73: TIME_SECOND
                {
                	mTIME_SECOND(); 

                }
                break;
            case 16 :
                // DateTimeFilter.g:1:85: TIME_SECOND_FRACTION
                {
                	mTIME_SECOND_FRACTION(); 

                }
                break;
            case 17 :
                // DateTimeFilter.g:1:106: FLOW_MONTH
                {
                	mFLOW_MONTH(); 

                }
                break;
            case 18 :
                // DateTimeFilter.g:1:117: FLOW_DAY
                {
                	mFLOW_DAY(); 

                }
                break;
            case 19 :
                // DateTimeFilter.g:1:126: YEAR_MONTH
                {
                	mYEAR_MONTH(); 

                }
                break;
            case 20 :
                // DateTimeFilter.g:1:137: HOUR_ANY_MINUTE
                {
                	mHOUR_ANY_MINUTE(); 

                }
                break;
            case 21 :
                // DateTimeFilter.g:1:153: T_LAST
                {
                	mT_LAST(); 

                }
                break;
            case 22 :
                // DateTimeFilter.g:1:160: T_THIS
                {
                	mT_THIS(); 

                }
                break;
            case 23 :
                // DateTimeFilter.g:1:167: T_NEXT
                {
                	mT_NEXT(); 

                }
                break;
            case 24 :
                // DateTimeFilter.g:1:174: T_HOUR
                {
                	mT_HOUR(); 

                }
                break;
            case 25 :
                // DateTimeFilter.g:1:181: T_WEEK
                {
                	mT_WEEK(); 

                }
                break;
            case 26 :
                // DateTimeFilter.g:1:188: T_MONTH
                {
                	mT_MONTH(); 

                }
                break;
            case 27 :
                // DateTimeFilter.g:1:196: T_YEAR
                {
                	mT_YEAR(); 

                }
                break;
            case 28 :
                // DateTimeFilter.g:1:203: T_YESTERDAY
                {
                	mT_YESTERDAY(); 

                }
                break;
            case 29 :
                // DateTimeFilter.g:1:215: T_TODAY
                {
                	mT_TODAY(); 

                }
                break;
            case 30 :
                // DateTimeFilter.g:1:223: T_TOMORROW
                {
                	mT_TOMORROW(); 

                }
                break;
            case 31 :
                // DateTimeFilter.g:1:234: T_JAN
                {
                	mT_JAN(); 

                }
                break;
            case 32 :
                // DateTimeFilter.g:1:240: T_FEB
                {
                	mT_FEB(); 

                }
                break;
            case 33 :
                // DateTimeFilter.g:1:246: T_MAR
                {
                	mT_MAR(); 

                }
                break;
            case 34 :
                // DateTimeFilter.g:1:252: T_APR
                {
                	mT_APR(); 

                }
                break;
            case 35 :
                // DateTimeFilter.g:1:258: T_MAY
                {
                	mT_MAY(); 

                }
                break;
            case 36 :
                // DateTimeFilter.g:1:264: T_JUN
                {
                	mT_JUN(); 

                }
                break;
            case 37 :
                // DateTimeFilter.g:1:270: T_JUL
                {
                	mT_JUL(); 

                }
                break;
            case 38 :
                // DateTimeFilter.g:1:276: T_AUG
                {
                	mT_AUG(); 

                }
                break;
            case 39 :
                // DateTimeFilter.g:1:282: T_SEP
                {
                	mT_SEP(); 

                }
                break;
            case 40 :
                // DateTimeFilter.g:1:288: T_OCT
                {
                	mT_OCT(); 

                }
                break;
            case 41 :
                // DateTimeFilter.g:1:294: T_NOV
                {
                	mT_NOV(); 

                }
                break;
            case 42 :
                // DateTimeFilter.g:1:300: T_DEC
                {
                	mT_DEC(); 

                }
                break;
            case 43 :
                // DateTimeFilter.g:1:306: T_MON
                {
                	mT_MON(); 

                }
                break;
            case 44 :
                // DateTimeFilter.g:1:312: T_TUE
                {
                	mT_TUE(); 

                }
                break;
            case 45 :
                // DateTimeFilter.g:1:318: T_WED
                {
                	mT_WED(); 

                }
                break;
            case 46 :
                // DateTimeFilter.g:1:324: T_THU
                {
                	mT_THU(); 

                }
                break;
            case 47 :
                // DateTimeFilter.g:1:330: T_FRI
                {
                	mT_FRI(); 

                }
                break;
            case 48 :
                // DateTimeFilter.g:1:336: T_SAT
                {
                	mT_SAT(); 

                }
                break;
            case 49 :
                // DateTimeFilter.g:1:342: T_SUN
                {
                	mT_SUN(); 

                }
                break;
            case 50 :
                // DateTimeFilter.g:1:348: T_NULL
                {
                	mT_NULL(); 

                }
                break;
            case 51 :
                // DateTimeFilter.g:1:355: T_NOT
                {
                	mT_NOT(); 

                }
                break;
            case 52 :
                // DateTimeFilter.g:1:361: WHITESPACE
                {
                	mWHITESPACE(); 

                }
                break;
            case 53 :
                // DateTimeFilter.g:1:372: ENDLINE
                {
                	mENDLINE(); 

                }
                break;
            case 54 :
                // DateTimeFilter.g:1:380: SQL_LITERAL
                {
                	mSQL_LITERAL(); 

                }
                break;

        }

    }


    protected DFA26 dfa26;
	private void InitializeCyclicDFAs()
	{
	    this.dfa26 = new DFA26(this);
	}

    const string DFA26_eotS =
        "\x02\uffff\x01\x1b\x01\x1d\x01\x1f\x1c\uffff\x01\x39\x01\uffff"+
        "\x01\x3c\x14\uffff\x01\x4c\x0e\uffff\x01\x50\x06\uffff\x01\x4c\x01"+
        "\x53\x02\uffff\x01\x55\x04\uffff\x01\x55\x01\x59\x01\uffff\x01\x59";
    const string DFA26_eofS =
        "\x5b\uffff";
    const string DFA26_minS =
        "\x01\x09\x01\uffff\x03\x3d\x03\uffff\x01\x2e\x01\uffff\x01\x48"+
        "\x01\x45\x01\uffff\x01\x45\x01\x41\x01\x45\x01\x41\x01\x45\x01\x50"+
        "\x01\x41\x0c\uffff\x01\x2a\x01\x30\x01\x2e\x01\x30\x01\x44\x01\x49"+
        "\x03\uffff\x01\x54\x01\x44\x01\x52\x01\x4e\x01\x41\x01\x4c\x09\uffff"+
        "\x01\x30\x02\uffff\x01\x30\x0b\uffff\x01\x54\x05\uffff\x01\x30\x01"+
        "\x3a\x01\x2d\x02\uffff\x01\x2e\x01\uffff\x01\x30\x02\uffff\x01\x2e"+
        "\x01\x2d\x01\uffff\x01\x2d";
    const string DFA26_maxS =
        "\x01\x5b\x01\uffff\x01\x3e\x02\x3d\x03\uffff\x01\x3a\x01\uffff"+
        "\x02\x55\x01\uffff\x01\x45\x01\x4f\x01\x45\x01\x55\x01\x52\x02\x55"+
        "\x0c\uffff\x02\x39\x01\x3a\x01\x39\x01\x4d\x01\x55\x03\uffff\x01"+
        "\x56\x01\x45\x01\x59\x01\x4e\x01\x53\x01\x4e\x09\uffff\x01\x3a\x02"+
        "\uffff\x01\x39\x0b\uffff\x01\x54\x05\uffff\x01\x39\x01\x3a\x01\x2d"+
        "\x02\uffff\x01\x39\x01\uffff\x01\x39\x02\uffff\x01\x2e\x01\x39\x01"+
        "\uffff\x01\x2d";
    const string DFA26_acceptS =
        "\x01\uffff\x01\x01\x03\uffff\x01\x08\x01\x09\x01\x0b\x01\uffff"+
        "\x01\x15\x02\uffff\x01\x18\x07\uffff\x01\x28\x01\x2a\x01\x34\x01"+
        "\x35\x01\x36\x01\x05\x01\x06\x01\x02\x01\x04\x01\x03\x01\x0a\x01"+
        "\x07\x06\uffff\x01\x2c\x01\x17\x01\x32\x06\uffff\x01\x1f\x01\x2f"+
        "\x01\x20\x01\x22\x01\x26\x01\x30\x01\x27\x01\x31\x01\x14\x01\uffff"+
        "\x01\x11\x01\x0d\x01\uffff\x01\x12\x01\x1e\x01\x1d\x01\x16\x01\x2e"+
        "\x01\x29\x01\x33\x01\x2d\x01\x19\x01\x23\x01\x21\x01\uffff\x01\x1c"+
        "\x01\x1b\x01\x24\x01\x25\x01\x0e\x03\uffff\x01\x2b\x01\x1a\x01\uffff"+
        "\x01\x0c\x01\uffff\x01\x0f\x01\x10\x02\uffff\x01\x13\x01\uffff";
    const string DFA26_specialS =
        "\x5b\uffff}>";
    static readonly string[] DFA26_transitionS = {
            "\x01\x16\x01\x17\x01\uffff\x01\x16\x01\x17\x12\uffff\x01\x16"+
            "\x01\x07\x0a\uffff\x01\x05\x01\x01\x01\x06\x01\uffff\x0a\x08"+
            "\x02\uffff\x01\x02\x01\x04\x01\x03\x02\uffff\x01\x12\x02\uffff"+
            "\x01\x15\x01\uffff\x01\x11\x01\uffff\x01\x0c\x01\uffff\x01\x10"+
            "\x01\uffff\x01\x09\x01\x0e\x01\x0b\x01\x14\x03\uffff\x01\x13"+
            "\x01\x0a\x02\uffff\x01\x0d\x01\uffff\x01\x0f\x01\uffff\x01\x18",
            "",
            "\x01\x19\x01\x1a",
            "\x01\x1c",
            "\x01\x1e",
            "",
            "",
            "",
            "\x01\x23\x01\x21\x0a\x22\x01\x20",
            "",
            "\x01\x25\x06\uffff\x01\x24\x05\uffff\x01\x26",
            "\x01\x27\x09\uffff\x01\x29\x05\uffff\x01\x28",
            "",
            "\x01\x2a",
            "\x01\x2b\x0d\uffff\x01\x2c",
            "\x01\x2d",
            "\x01\x2f\x13\uffff\x01\x2e",
            "\x01\x31\x0c\uffff\x01\x30",
            "\x01\x32\x04\uffff\x01\x33",
            "\x01\x34\x03\uffff\x01\x35\x0f\uffff\x01\x36",
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
            "\x01\x37\x05\uffff\x0a\x38",
            "\x0a\x3a",
            "\x01\x23\x01\x21\x0a\x3b\x01\x20",
            "\x0a\x3a",
            "\x01\x3e\x08\uffff\x01\x3d",
            "\x01\x3f\x0b\uffff\x01\x40",
            "",
            "",
            "",
            "\x01\x42\x01\uffff\x01\x41",
            "\x01\x43\x01\x44",
            "\x01\x46\x06\uffff\x01\x45",
            "\x01\x47",
            "\x01\x49\x11\uffff\x01\x48",
            "\x01\x4b\x01\uffff\x01\x4a",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x0a\x4e\x01\x4d",
            "",
            "",
            "\x0a\x4f",
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
            "\x01\x51",
            "",
            "",
            "",
            "",
            "",
            "\x0a\x52",
            "\x01\x4d",
            "\x01\x54",
            "",
            "",
            "\x01\x56\x01\uffff\x0a\x57",
            "",
            "\x0a\x58",
            "",
            "",
            "\x01\x56",
            "\x01\x3a\x02\uffff\x0a\x5a",
            "",
            "\x01\x3a"
    };

    static readonly short[] DFA26_eot = DFA.UnpackEncodedString(DFA26_eotS);
    static readonly short[] DFA26_eof = DFA.UnpackEncodedString(DFA26_eofS);
    static readonly char[] DFA26_min = DFA.UnpackEncodedStringToUnsignedChars(DFA26_minS);
    static readonly char[] DFA26_max = DFA.UnpackEncodedStringToUnsignedChars(DFA26_maxS);
    static readonly short[] DFA26_accept = DFA.UnpackEncodedString(DFA26_acceptS);
    static readonly short[] DFA26_special = DFA.UnpackEncodedString(DFA26_specialS);
    static readonly short[][] DFA26_transition = DFA.UnpackEncodedStringArray(DFA26_transitionS);

    protected class DFA26 : DFA
    {
        public DFA26(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 26;
            this.eot = DFA26_eot;
            this.eof = DFA26_eof;
            this.min = DFA26_min;
            this.max = DFA26_max;
            this.accept = DFA26_accept;
            this.special = DFA26_special;
            this.transition = DFA26_transition;

        }

        override public string Description
        {
            get { return "1:1: Tokens : ( MINUS | LT | GT | GE | LE | NE | EQ | COMMA | DOT | EQ2 | NE2 | YEAR | DATE | TIME_MINUE | TIME_SECOND | TIME_SECOND_FRACTION | FLOW_MONTH | FLOW_DAY | YEAR_MONTH | HOUR_ANY_MINUTE | T_LAST | T_THIS | T_NEXT | T_HOUR | T_WEEK | T_MONTH | T_YEAR | T_YESTERDAY | T_TODAY | T_TOMORROW | T_JAN | T_FEB | T_MAR | T_APR | T_MAY | T_JUN | T_JUL | T_AUG | T_SEP | T_OCT | T_NOV | T_DEC | T_MON | T_TUE | T_WED | T_THU | T_FRI | T_SAT | T_SUN | T_NULL | T_NOT | WHITESPACE | ENDLINE | SQL_LITERAL );"; }
        }

    }

 
    
}
