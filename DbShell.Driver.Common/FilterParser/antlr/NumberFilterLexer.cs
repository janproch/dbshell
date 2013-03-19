// $ANTLR 3.2 Sep 23, 2009 12:02:23 NumberFilter.g 2013-03-19 20:36:18

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162


using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;


public partial class NumberFilterLexer : Lexer {
    public const int D = 26;
    public const int E = 27;
    public const int F = 28;
    public const int GE = 9;
    public const int G = 29;
    public const int LT = 6;
    public const int A = 23;
    public const int B = 24;
    public const int C = 25;
    public const int L = 18;
    public const int M = 34;
    public const int N = 16;
    public const int O = 19;
    public const int H = 30;
    public const int I = 31;
    public const int J = 32;
    public const int NUMBER = 5;
    public const int K = 33;
    public const int U = 17;
    public const int T = 20;
    public const int WHITESPACE = 22;
    public const int W = 40;
    public const int V = 39;
    public const int Q = 36;
    public const int P = 35;
    public const int S = 38;
    public const int MINUS = 4;
    public const int R = 37;
    public const int EOF = -1;
    public const int Y = 42;
    public const int X = 41;
    public const int Z = 43;
    public const int COMMA = 14;
    public const int T_NULL = 12;
    public const int GT = 7;
    public const int ENDLINE = 15;
    public const int DIGIT = 21;
    public const int EQ = 11;
    public const int T_NOT = 13;
    public const int LE = 8;
    public const int NE = 10;

    // delegates
    // delegators

    public NumberFilterLexer() 
    {
		InitializeCyclicDFAs();
    }
    public NumberFilterLexer(ICharStream input)
		: this(input, null) {
    }
    public NumberFilterLexer(ICharStream input, RecognizerSharedState state)
		: base(input, state) {
		InitializeCyclicDFAs(); 

    }
    
    override public string GrammarFileName
    {
    	get { return "NumberFilter.g";} 
    }

    // $ANTLR start "T_NULL"
    public void mT_NULL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_NULL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // NumberFilter.g:59:7: ( N U L L )
            // NumberFilter.g:59:9: N U L L
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
            // NumberFilter.g:60:6: ( N O T )
            // NumberFilter.g:60:8: N O T
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

    // $ANTLR start "MINUS"
    public void mMINUS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = MINUS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // NumberFilter.g:62:6: ( '-' )
            // NumberFilter.g:62:9: '-'
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
            // NumberFilter.g:63:3: ( '<' )
            // NumberFilter.g:63:6: '<'
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
            // NumberFilter.g:64:3: ( '>' )
            // NumberFilter.g:64:6: '>'
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
            // NumberFilter.g:65:3: ( '>=' )
            // NumberFilter.g:65:6: '>='
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
            // NumberFilter.g:66:3: ( '<=' )
            // NumberFilter.g:66:6: '<='
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
            // NumberFilter.g:67:3: ( '!=' | '<>' )
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
                    // NumberFilter.g:67:6: '!='
                    {
                    	Match("!="); 


                    }
                    break;
                case 2 :
                    // NumberFilter.g:67:13: '<>'
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
            // NumberFilter.g:68:3: ( '=' )
            // NumberFilter.g:68:6: '='
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
            // NumberFilter.g:69:6: ( ',' )
            // NumberFilter.g:69:8: ','
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

    // $ANTLR start "NUMBER"
    public void mNUMBER() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = NUMBER;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // NumberFilter.g:71:9: ( ( DIGIT )+ ( '.' ( DIGIT )+ )? )
            // NumberFilter.g:71:11: ( DIGIT )+ ( '.' ( DIGIT )+ )?
            {
            	// NumberFilter.g:71:11: ( DIGIT )+
            	int cnt2 = 0;
            	do 
            	{
            	    int alt2 = 2;
            	    int LA2_0 = input.LA(1);

            	    if ( ((LA2_0 >= '0' && LA2_0 <= '9')) )
            	    {
            	        alt2 = 1;
            	    }


            	    switch (alt2) 
            		{
            			case 1 :
            			    // NumberFilter.g:71:12: DIGIT
            			    {
            			    	mDIGIT(); 

            			    }
            			    break;

            			default:
            			    if ( cnt2 >= 1 ) goto loop2;
            		            EarlyExitException eee2 =
            		                new EarlyExitException(2, input);
            		            throw eee2;
            	    }
            	    cnt2++;
            	} while (true);

            	loop2:
            		;	// Stops C# compiler whining that label 'loop2' has no statements

            	// NumberFilter.g:71:20: ( '.' ( DIGIT )+ )?
            	int alt4 = 2;
            	int LA4_0 = input.LA(1);

            	if ( (LA4_0 == '.') )
            	{
            	    alt4 = 1;
            	}
            	switch (alt4) 
            	{
            	    case 1 :
            	        // NumberFilter.g:71:21: '.' ( DIGIT )+
            	        {
            	        	Match('.'); 
            	        	// NumberFilter.g:71:25: ( DIGIT )+
            	        	int cnt3 = 0;
            	        	do 
            	        	{
            	        	    int alt3 = 2;
            	        	    int LA3_0 = input.LA(1);

            	        	    if ( ((LA3_0 >= '0' && LA3_0 <= '9')) )
            	        	    {
            	        	        alt3 = 1;
            	        	    }


            	        	    switch (alt3) 
            	        		{
            	        			case 1 :
            	        			    // NumberFilter.g:71:26: DIGIT
            	        			    {
            	        			    	mDIGIT(); 

            	        			    }
            	        			    break;

            	        			default:
            	        			    if ( cnt3 >= 1 ) goto loop3;
            	        		            EarlyExitException eee3 =
            	        		                new EarlyExitException(3, input);
            	        		            throw eee3;
            	        	    }
            	        	    cnt3++;
            	        	} while (true);

            	        	loop3:
            	        		;	// Stops C# compiler whining that label 'loop3' has no statements


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
    // $ANTLR end "NUMBER"

    // $ANTLR start "WHITESPACE"
    public void mWHITESPACE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = WHITESPACE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // NumberFilter.g:73:12: ( ( '\\t' | ' ' | '\\u000C' )+ )
            // NumberFilter.g:73:14: ( '\\t' | ' ' | '\\u000C' )+
            {
            	// NumberFilter.g:73:14: ( '\\t' | ' ' | '\\u000C' )+
            	int cnt5 = 0;
            	do 
            	{
            	    int alt5 = 2;
            	    int LA5_0 = input.LA(1);

            	    if ( (LA5_0 == '\t' || LA5_0 == '\f' || LA5_0 == ' ') )
            	    {
            	        alt5 = 1;
            	    }


            	    switch (alt5) 
            		{
            			case 1 :
            			    // NumberFilter.g:
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
            			    if ( cnt5 >= 1 ) goto loop5;
            		            EarlyExitException eee5 =
            		                new EarlyExitException(5, input);
            		            throw eee5;
            	    }
            	    cnt5++;
            	} while (true);

            	loop5:
            		;	// Stops C# compiler whining that label 'loop5' has no statements

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
            // NumberFilter.g:74:8: ( ( '\\r' | '\\n' )+ )
            // NumberFilter.g:74:10: ( '\\r' | '\\n' )+
            {
            	// NumberFilter.g:74:10: ( '\\r' | '\\n' )+
            	int cnt6 = 0;
            	do 
            	{
            	    int alt6 = 2;
            	    int LA6_0 = input.LA(1);

            	    if ( (LA6_0 == '\n' || LA6_0 == '\r') )
            	    {
            	        alt6 = 1;
            	    }


            	    switch (alt6) 
            		{
            			case 1 :
            			    // NumberFilter.g:
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
            			    if ( cnt6 >= 1 ) goto loop6;
            		            EarlyExitException eee6 =
            		                new EarlyExitException(6, input);
            		            throw eee6;
            	    }
            	    cnt6++;
            	} while (true);

            	loop6:
            		;	// Stops C# compiler whining that label 'loop6' has no statements


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
            // NumberFilter.g:76:17: ( '0' .. '9' )
            // NumberFilter.g:76:19: '0' .. '9'
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
            // NumberFilter.g:78:11: ( 'A' )
            // NumberFilter.g:78:13: 'A'
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
            // NumberFilter.g:79:11: ( 'B' )
            // NumberFilter.g:79:13: 'B'
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
            // NumberFilter.g:80:11: ( 'C' )
            // NumberFilter.g:80:13: 'C'
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
            // NumberFilter.g:81:11: ( 'D' )
            // NumberFilter.g:81:13: 'D'
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
            // NumberFilter.g:82:11: ( 'E' )
            // NumberFilter.g:82:13: 'E'
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
            // NumberFilter.g:83:11: ( 'F' )
            // NumberFilter.g:83:13: 'F'
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
            // NumberFilter.g:84:11: ( 'G' )
            // NumberFilter.g:84:13: 'G'
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
            // NumberFilter.g:85:11: ( 'H' )
            // NumberFilter.g:85:13: 'H'
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
            // NumberFilter.g:86:11: ( 'I' )
            // NumberFilter.g:86:13: 'I'
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
            // NumberFilter.g:87:11: ( 'J' )
            // NumberFilter.g:87:13: 'J'
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
            // NumberFilter.g:88:11: ( 'K' )
            // NumberFilter.g:88:13: 'K'
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
            // NumberFilter.g:89:11: ( 'L' )
            // NumberFilter.g:89:13: 'L'
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
            // NumberFilter.g:90:11: ( 'M' )
            // NumberFilter.g:90:13: 'M'
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
            // NumberFilter.g:91:11: ( 'N' )
            // NumberFilter.g:91:13: 'N'
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
            // NumberFilter.g:92:11: ( 'O' )
            // NumberFilter.g:92:13: 'O'
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
            // NumberFilter.g:93:11: ( 'P' )
            // NumberFilter.g:93:13: 'P'
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
            // NumberFilter.g:94:11: ( 'Q' )
            // NumberFilter.g:94:13: 'Q'
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
            // NumberFilter.g:95:11: ( 'R' )
            // NumberFilter.g:95:13: 'R'
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
            // NumberFilter.g:96:11: ( 'S' )
            // NumberFilter.g:96:13: 'S'
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
            // NumberFilter.g:97:11: ( 'T' )
            // NumberFilter.g:97:13: 'T'
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
            // NumberFilter.g:98:11: ( 'U' )
            // NumberFilter.g:98:13: 'U'
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
            // NumberFilter.g:99:11: ( 'V' )
            // NumberFilter.g:99:13: 'V'
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
            // NumberFilter.g:100:11: ( 'W' )
            // NumberFilter.g:100:13: 'W'
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
            // NumberFilter.g:101:11: ( 'X' )
            // NumberFilter.g:101:13: 'X'
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
            // NumberFilter.g:102:11: ( 'Y' )
            // NumberFilter.g:102:13: 'Y'
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
            // NumberFilter.g:103:11: ( 'Z' )
            // NumberFilter.g:103:13: 'Z'
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
        // NumberFilter.g:1:8: ( T_NULL | T_NOT | MINUS | LT | GT | GE | LE | NE | EQ | COMMA | NUMBER | WHITESPACE | ENDLINE )
        int alt7 = 13;
        alt7 = dfa7.Predict(input);
        switch (alt7) 
        {
            case 1 :
                // NumberFilter.g:1:10: T_NULL
                {
                	mT_NULL(); 

                }
                break;
            case 2 :
                // NumberFilter.g:1:17: T_NOT
                {
                	mT_NOT(); 

                }
                break;
            case 3 :
                // NumberFilter.g:1:23: MINUS
                {
                	mMINUS(); 

                }
                break;
            case 4 :
                // NumberFilter.g:1:29: LT
                {
                	mLT(); 

                }
                break;
            case 5 :
                // NumberFilter.g:1:32: GT
                {
                	mGT(); 

                }
                break;
            case 6 :
                // NumberFilter.g:1:35: GE
                {
                	mGE(); 

                }
                break;
            case 7 :
                // NumberFilter.g:1:38: LE
                {
                	mLE(); 

                }
                break;
            case 8 :
                // NumberFilter.g:1:41: NE
                {
                	mNE(); 

                }
                break;
            case 9 :
                // NumberFilter.g:1:44: EQ
                {
                	mEQ(); 

                }
                break;
            case 10 :
                // NumberFilter.g:1:47: COMMA
                {
                	mCOMMA(); 

                }
                break;
            case 11 :
                // NumberFilter.g:1:53: NUMBER
                {
                	mNUMBER(); 

                }
                break;
            case 12 :
                // NumberFilter.g:1:60: WHITESPACE
                {
                	mWHITESPACE(); 

                }
                break;
            case 13 :
                // NumberFilter.g:1:71: ENDLINE
                {
                	mENDLINE(); 

                }
                break;

        }

    }


    protected DFA7 dfa7;
	private void InitializeCyclicDFAs()
	{
	    this.dfa7 = new DFA7(this);
	}

    const string DFA7_eotS =
        "\x03\uffff\x01\x0e\x01\x10\x0c\uffff";
    const string DFA7_eofS =
        "\x11\uffff";
    const string DFA7_minS =
        "\x01\x09\x01\x4f\x01\uffff\x02\x3d\x0c\uffff";
    const string DFA7_maxS =
        "\x01\x4e\x01\x55\x01\uffff\x01\x3e\x01\x3d\x0c\uffff";
    const string DFA7_acceptS =
        "\x02\uffff\x01\x03\x02\uffff\x01\x08\x01\x09\x01\x0a\x01\x0b\x01"+
        "\x0c\x01\x0d\x01\x01\x01\x02\x01\x07\x01\x04\x01\x06\x01\x05";
    const string DFA7_specialS =
        "\x11\uffff}>";
    static readonly string[] DFA7_transitionS = {
            "\x01\x09\x01\x0a\x01\uffff\x01\x09\x01\x0a\x12\uffff\x01\x09"+
            "\x01\x05\x0a\uffff\x01\x07\x01\x02\x02\uffff\x0a\x08\x02\uffff"+
            "\x01\x03\x01\x06\x01\x04\x0f\uffff\x01\x01",
            "\x01\x0c\x05\uffff\x01\x0b",
            "",
            "\x01\x0d\x01\x05",
            "\x01\x0f",
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
            ""
    };

    static readonly short[] DFA7_eot = DFA.UnpackEncodedString(DFA7_eotS);
    static readonly short[] DFA7_eof = DFA.UnpackEncodedString(DFA7_eofS);
    static readonly char[] DFA7_min = DFA.UnpackEncodedStringToUnsignedChars(DFA7_minS);
    static readonly char[] DFA7_max = DFA.UnpackEncodedStringToUnsignedChars(DFA7_maxS);
    static readonly short[] DFA7_accept = DFA.UnpackEncodedString(DFA7_acceptS);
    static readonly short[] DFA7_special = DFA.UnpackEncodedString(DFA7_specialS);
    static readonly short[][] DFA7_transition = DFA.UnpackEncodedStringArray(DFA7_transitionS);

    protected class DFA7 : DFA
    {
        public DFA7(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 7;
            this.eot = DFA7_eot;
            this.eof = DFA7_eof;
            this.min = DFA7_min;
            this.max = DFA7_max;
            this.accept = DFA7_accept;
            this.special = DFA7_special;
            this.transition = DFA7_transition;

        }

        override public string Description
        {
            get { return "1:1: Tokens : ( T_NULL | T_NOT | MINUS | LT | GT | GE | LE | NE | EQ | COMMA | NUMBER | WHITESPACE | ENDLINE );"; }
        }

    }

 
    
}
