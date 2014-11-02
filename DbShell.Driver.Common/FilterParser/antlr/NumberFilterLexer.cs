// $ANTLR 3.2 Sep 23, 2009 12:02:23 NumberFilter.g 2014-11-02 21:57:14

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
    public const int LT = 10;
    public const int EOF = -1;
    public const int Q_STRING = 6;
    public const int COMMA = 20;
    public const int T_NULL = 16;
    public const int DIGIT = 27;
    public const int EQ = 15;
    public const int DOT = 9;
    public const int NE = 14;
    public const int D = 32;
    public const int E = 33;
    public const int F = 34;
    public const int GE = 13;
    public const int G = 35;
    public const int A = 29;
    public const int B = 30;
    public const int NE2 = 19;
    public const int C = 31;
    public const int L = 24;
    public const int M = 40;
    public const int N = 22;
    public const int O = 25;
    public const int H = 36;
    public const int I = 37;
    public const int J = 38;
    public const int NUMBER = 5;
    public const int K = 39;
    public const int U = 23;
    public const int T = 26;
    public const int W = 46;
    public const int WHITESPACE = 28;
    public const int V = 45;
    public const int Q = 42;
    public const int P = 41;
    public const int S = 44;
    public const int R = 43;
    public const int MINUS = 4;
    public const int Y = 48;
    public const int SQL_LITERAL = 8;
    public const int X = 47;
    public const int EQ2 = 18;
    public const int Z = 49;
    public const int A_STRING = 7;
    public const int GT = 11;
    public const int ENDLINE = 21;
    public const int T_NOT = 17;
    public const int LE = 12;

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
            // NumberFilter.g:89:7: ( N U L L )
            // NumberFilter.g:89:9: N U L L
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
            // NumberFilter.g:90:6: ( N O T )
            // NumberFilter.g:90:8: N O T
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
            // NumberFilter.g:92:6: ( '-' )
            // NumberFilter.g:92:9: '-'
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
            // NumberFilter.g:93:3: ( '<' )
            // NumberFilter.g:93:6: '<'
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
            // NumberFilter.g:94:3: ( '>' )
            // NumberFilter.g:94:6: '>'
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
            // NumberFilter.g:95:3: ( '>=' )
            // NumberFilter.g:95:6: '>='
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
            // NumberFilter.g:96:3: ( '<=' )
            // NumberFilter.g:96:6: '<='
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
            // NumberFilter.g:97:3: ( '<>' )
            // NumberFilter.g:97:6: '<>'
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
            // NumberFilter.g:98:3: ( '=' )
            // NumberFilter.g:98:6: '='
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
            // NumberFilter.g:99:6: ( ',' )
            // NumberFilter.g:99:8: ','
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
            // NumberFilter.g:100:4: ( '.' )
            // NumberFilter.g:100:6: '.'
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
            // NumberFilter.g:101:4: ( '==' )
            // NumberFilter.g:101:7: '=='
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
            // NumberFilter.g:102:4: ( '!=' )
            // NumberFilter.g:102:7: '!='
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

    // $ANTLR start "NUMBER"
    public void mNUMBER() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = NUMBER;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // NumberFilter.g:104:9: ( ( DIGIT )+ ( '.' ( DIGIT )+ )? )
            // NumberFilter.g:104:11: ( DIGIT )+ ( '.' ( DIGIT )+ )?
            {
            	// NumberFilter.g:104:11: ( DIGIT )+
            	int cnt1 = 0;
            	do 
            	{
            	    int alt1 = 2;
            	    int LA1_0 = input.LA(1);

            	    if ( ((LA1_0 >= '0' && LA1_0 <= '9')) )
            	    {
            	        alt1 = 1;
            	    }


            	    switch (alt1) 
            		{
            			case 1 :
            			    // NumberFilter.g:104:12: DIGIT
            			    {
            			    	mDIGIT(); 

            			    }
            			    break;

            			default:
            			    if ( cnt1 >= 1 ) goto loop1;
            		            EarlyExitException eee1 =
            		                new EarlyExitException(1, input);
            		            throw eee1;
            	    }
            	    cnt1++;
            	} while (true);

            	loop1:
            		;	// Stops C# compiler whining that label 'loop1' has no statements

            	// NumberFilter.g:104:20: ( '.' ( DIGIT )+ )?
            	int alt3 = 2;
            	int LA3_0 = input.LA(1);

            	if ( (LA3_0 == '.') )
            	{
            	    alt3 = 1;
            	}
            	switch (alt3) 
            	{
            	    case 1 :
            	        // NumberFilter.g:104:21: '.' ( DIGIT )+
            	        {
            	        	Match('.'); 
            	        	// NumberFilter.g:104:25: ( DIGIT )+
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
            	        			    // NumberFilter.g:104:26: DIGIT
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
            // NumberFilter.g:106:12: ( ( '\\t' | ' ' | '\\u000C' )+ )
            // NumberFilter.g:106:14: ( '\\t' | ' ' | '\\u000C' )+
            {
            	// NumberFilter.g:106:14: ( '\\t' | ' ' | '\\u000C' )+
            	int cnt4 = 0;
            	do 
            	{
            	    int alt4 = 2;
            	    int LA4_0 = input.LA(1);

            	    if ( (LA4_0 == '\t' || LA4_0 == '\f' || LA4_0 == ' ') )
            	    {
            	        alt4 = 1;
            	    }


            	    switch (alt4) 
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
            			    if ( cnt4 >= 1 ) goto loop4;
            		            EarlyExitException eee4 =
            		                new EarlyExitException(4, input);
            		            throw eee4;
            	    }
            	    cnt4++;
            	} while (true);

            	loop4:
            		;	// Stops C# compiler whining that label 'loop4' has no statements

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
            // NumberFilter.g:107:8: ( ( '\\r' | '\\n' )+ )
            // NumberFilter.g:107:10: ( '\\r' | '\\n' )+
            {
            	// NumberFilter.g:107:10: ( '\\r' | '\\n' )+
            	int cnt5 = 0;
            	do 
            	{
            	    int alt5 = 2;
            	    int LA5_0 = input.LA(1);

            	    if ( (LA5_0 == '\n' || LA5_0 == '\r') )
            	    {
            	        alt5 = 1;
            	    }


            	    switch (alt5) 
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
    // $ANTLR end "ENDLINE"

    // $ANTLR start "SQL_LITERAL"
    public void mSQL_LITERAL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = SQL_LITERAL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // NumberFilter.g:109:12: ( ( '[' ( options {greedy=true; } : ~ ( ']' | '\\r' | '\\n' ) )* ']' ) )
            // NumberFilter.g:110:4: ( '[' ( options {greedy=true; } : ~ ( ']' | '\\r' | '\\n' ) )* ']' )
            {
            	// NumberFilter.g:110:4: ( '[' ( options {greedy=true; } : ~ ( ']' | '\\r' | '\\n' ) )* ']' )
            	// NumberFilter.g:110:5: '[' ( options {greedy=true; } : ~ ( ']' | '\\r' | '\\n' ) )* ']'
            	{
            		Match('['); 
            		// NumberFilter.g:111:5: ( options {greedy=true; } : ~ ( ']' | '\\r' | '\\n' ) )*
            		do 
            		{
            		    int alt6 = 2;
            		    int LA6_0 = input.LA(1);

            		    if ( ((LA6_0 >= '\u0000' && LA6_0 <= '\t') || (LA6_0 >= '\u000B' && LA6_0 <= '\f') || (LA6_0 >= '\u000E' && LA6_0 <= '\\') || (LA6_0 >= '^' && LA6_0 <= '\uFFFF')) )
            		    {
            		        alt6 = 1;
            		    }


            		    switch (alt6) 
            			{
            				case 1 :
            				    // NumberFilter.g:112:31: ~ ( ']' | '\\r' | '\\n' )
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
            				    goto loop6;
            		    }
            		} while (true);

            		loop6:
            			;	// Stops C# compiler whining that label 'loop6' has no statements

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

    // $ANTLR start "A_STRING"
    public void mA_STRING() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = A_STRING;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // NumberFilter.g:117:9: ( ( '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\'' ) )
            // NumberFilter.g:118:4: ( '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\'' )
            {
            	// NumberFilter.g:118:4: ( '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\'' )
            	// NumberFilter.g:118:5: '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\''
            	{
            		Match('\''); 
            		// NumberFilter.g:119:5: ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )*
            		do 
            		{
            		    int alt7 = 3;
            		    int LA7_0 = input.LA(1);

            		    if ( (LA7_0 == '\'') )
            		    {
            		        int LA7_1 = input.LA(2);

            		        if ( (LA7_1 == '\'') )
            		        {
            		            alt7 = 2;
            		        }


            		    }
            		    else if ( ((LA7_0 >= '\u0000' && LA7_0 <= '\t') || (LA7_0 >= '\u000B' && LA7_0 <= '\f') || (LA7_0 >= '\u000E' && LA7_0 <= '&') || (LA7_0 >= '(' && LA7_0 <= '\uFFFF')) )
            		    {
            		        alt7 = 1;
            		    }


            		    switch (alt7) 
            			{
            				case 1 :
            				    // NumberFilter.g:120:31: ~ ( '\\'' | '\\r' | '\\n' )
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
            				    // NumberFilter.g:120:56: '\\'' '\\''
            				    {
            				    	Match('\''); 
            				    	Match('\''); 

            				    }
            				    break;

            				default:
            				    goto loop7;
            		    }
            		} while (true);

            		loop7:
            			;	// Stops C# compiler whining that label 'loop7' has no statements

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
    // $ANTLR end "A_STRING"

    // $ANTLR start "Q_STRING"
    public void mQ_STRING() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = Q_STRING;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // NumberFilter.g:125:9: ( ( '\\\"' ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )* '\\\"' ) )
            // NumberFilter.g:126:4: ( '\\\"' ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )* '\\\"' )
            {
            	// NumberFilter.g:126:4: ( '\\\"' ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )* '\\\"' )
            	// NumberFilter.g:126:5: '\\\"' ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )* '\\\"'
            	{
            		Match('\"'); 
            		// NumberFilter.g:127:5: ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )*
            		do 
            		{
            		    int alt8 = 3;
            		    int LA8_0 = input.LA(1);

            		    if ( (LA8_0 == '\"') )
            		    {
            		        int LA8_1 = input.LA(2);

            		        if ( (LA8_1 == '\"') )
            		        {
            		            alt8 = 2;
            		        }


            		    }
            		    else if ( ((LA8_0 >= '\u0000' && LA8_0 <= '\t') || (LA8_0 >= '\u000B' && LA8_0 <= '\f') || (LA8_0 >= '\u000E' && LA8_0 <= '!') || (LA8_0 >= '#' && LA8_0 <= '\uFFFF')) )
            		    {
            		        alt8 = 1;
            		    }


            		    switch (alt8) 
            			{
            				case 1 :
            				    // NumberFilter.g:128:31: ~ ( '\\\"' | '\\r' | '\\n' )
            				    {
            				    	if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '\t') || (input.LA(1) >= '\u000B' && input.LA(1) <= '\f') || (input.LA(1) >= '\u000E' && input.LA(1) <= '!') || (input.LA(1) >= '#' && input.LA(1) <= '\uFFFF') ) 
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
            				    // NumberFilter.g:128:56: '\\\"' '\\\"'
            				    {
            				    	Match('\"'); 
            				    	Match('\"'); 

            				    }
            				    break;

            				default:
            				    goto loop8;
            		    }
            		} while (true);

            		loop8:
            			;	// Stops C# compiler whining that label 'loop8' has no statements

            		Match('\"'); 

            	}


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "Q_STRING"

    // $ANTLR start "DIGIT"
    public void mDIGIT() // throws RecognitionException [2]
    {
    		try
    		{
            // NumberFilter.g:133:17: ( '0' .. '9' )
            // NumberFilter.g:133:19: '0' .. '9'
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
            // NumberFilter.g:135:11: ( 'A' )
            // NumberFilter.g:135:13: 'A'
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
            // NumberFilter.g:136:11: ( 'B' )
            // NumberFilter.g:136:13: 'B'
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
            // NumberFilter.g:137:11: ( 'C' )
            // NumberFilter.g:137:13: 'C'
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
            // NumberFilter.g:138:11: ( 'D' )
            // NumberFilter.g:138:13: 'D'
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
            // NumberFilter.g:139:11: ( 'E' )
            // NumberFilter.g:139:13: 'E'
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
            // NumberFilter.g:140:11: ( 'F' )
            // NumberFilter.g:140:13: 'F'
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
            // NumberFilter.g:141:11: ( 'G' )
            // NumberFilter.g:141:13: 'G'
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
            // NumberFilter.g:142:11: ( 'H' )
            // NumberFilter.g:142:13: 'H'
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
            // NumberFilter.g:143:11: ( 'I' )
            // NumberFilter.g:143:13: 'I'
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
            // NumberFilter.g:144:11: ( 'J' )
            // NumberFilter.g:144:13: 'J'
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
            // NumberFilter.g:145:11: ( 'K' )
            // NumberFilter.g:145:13: 'K'
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
            // NumberFilter.g:146:11: ( 'L' )
            // NumberFilter.g:146:13: 'L'
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
            // NumberFilter.g:147:11: ( 'M' )
            // NumberFilter.g:147:13: 'M'
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
            // NumberFilter.g:148:11: ( 'N' )
            // NumberFilter.g:148:13: 'N'
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
            // NumberFilter.g:149:11: ( 'O' )
            // NumberFilter.g:149:13: 'O'
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
            // NumberFilter.g:150:11: ( 'P' )
            // NumberFilter.g:150:13: 'P'
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
            // NumberFilter.g:151:11: ( 'Q' )
            // NumberFilter.g:151:13: 'Q'
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
            // NumberFilter.g:152:11: ( 'R' )
            // NumberFilter.g:152:13: 'R'
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
            // NumberFilter.g:153:11: ( 'S' )
            // NumberFilter.g:153:13: 'S'
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
            // NumberFilter.g:154:11: ( 'T' )
            // NumberFilter.g:154:13: 'T'
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
            // NumberFilter.g:155:11: ( 'U' )
            // NumberFilter.g:155:13: 'U'
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
            // NumberFilter.g:156:11: ( 'V' )
            // NumberFilter.g:156:13: 'V'
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
            // NumberFilter.g:157:11: ( 'W' )
            // NumberFilter.g:157:13: 'W'
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
            // NumberFilter.g:158:11: ( 'X' )
            // NumberFilter.g:158:13: 'X'
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
            // NumberFilter.g:159:11: ( 'Y' )
            // NumberFilter.g:159:13: 'Y'
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
            // NumberFilter.g:160:11: ( 'Z' )
            // NumberFilter.g:160:13: 'Z'
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
        // NumberFilter.g:1:8: ( T_NULL | T_NOT | MINUS | LT | GT | GE | LE | NE | EQ | COMMA | DOT | EQ2 | NE2 | NUMBER | WHITESPACE | ENDLINE | SQL_LITERAL | A_STRING | Q_STRING )
        int alt9 = 19;
        alt9 = dfa9.Predict(input);
        switch (alt9) 
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
                // NumberFilter.g:1:53: DOT
                {
                	mDOT(); 

                }
                break;
            case 12 :
                // NumberFilter.g:1:57: EQ2
                {
                	mEQ2(); 

                }
                break;
            case 13 :
                // NumberFilter.g:1:61: NE2
                {
                	mNE2(); 

                }
                break;
            case 14 :
                // NumberFilter.g:1:65: NUMBER
                {
                	mNUMBER(); 

                }
                break;
            case 15 :
                // NumberFilter.g:1:72: WHITESPACE
                {
                	mWHITESPACE(); 

                }
                break;
            case 16 :
                // NumberFilter.g:1:83: ENDLINE
                {
                	mENDLINE(); 

                }
                break;
            case 17 :
                // NumberFilter.g:1:91: SQL_LITERAL
                {
                	mSQL_LITERAL(); 

                }
                break;
            case 18 :
                // NumberFilter.g:1:103: A_STRING
                {
                	mA_STRING(); 

                }
                break;
            case 19 :
                // NumberFilter.g:1:112: Q_STRING
                {
                	mQ_STRING(); 

                }
                break;

        }

    }


    protected DFA9 dfa9;
	private void InitializeCyclicDFAs()
	{
	    this.dfa9 = new DFA9(this);
	}

    const string DFA9_eotS =
        "\x03\uffff\x01\x13\x01\x15\x01\x17\x12\uffff";
    const string DFA9_eofS =
        "\x18\uffff";
    const string DFA9_minS =
        "\x01\x09\x01\x4f\x01\uffff\x03\x3d\x12\uffff";
    const string DFA9_maxS =
        "\x01\x5b\x01\x55\x01\uffff\x01\x3e\x02\x3d\x12\uffff";
    const string DFA9_acceptS =
        "\x02\uffff\x01\x03\x03\uffff\x01\x0a\x01\x0b\x01\x0d\x01\x0e\x01"+
        "\x0f\x01\x10\x01\x11\x01\x12\x01\x13\x01\x01\x01\x02\x01\x07\x01"+
        "\x08\x01\x04\x01\x06\x01\x05\x01\x0c\x01\x09";
    const string DFA9_specialS =
        "\x18\uffff}>";
    static readonly string[] DFA9_transitionS = {
            "\x01\x0a\x01\x0b\x01\uffff\x01\x0a\x01\x0b\x12\uffff\x01\x0a"+
            "\x01\x08\x01\x0e\x04\uffff\x01\x0d\x04\uffff\x01\x06\x01\x02"+
            "\x01\x07\x01\uffff\x0a\x09\x02\uffff\x01\x03\x01\x05\x01\x04"+
            "\x0f\uffff\x01\x01\x0c\uffff\x01\x0c",
            "\x01\x10\x05\uffff\x01\x0f",
            "",
            "\x01\x11\x01\x12",
            "\x01\x14",
            "\x01\x16",
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
            "",
            ""
    };

    static readonly short[] DFA9_eot = DFA.UnpackEncodedString(DFA9_eotS);
    static readonly short[] DFA9_eof = DFA.UnpackEncodedString(DFA9_eofS);
    static readonly char[] DFA9_min = DFA.UnpackEncodedStringToUnsignedChars(DFA9_minS);
    static readonly char[] DFA9_max = DFA.UnpackEncodedStringToUnsignedChars(DFA9_maxS);
    static readonly short[] DFA9_accept = DFA.UnpackEncodedString(DFA9_acceptS);
    static readonly short[] DFA9_special = DFA.UnpackEncodedString(DFA9_specialS);
    static readonly short[][] DFA9_transition = DFA.UnpackEncodedStringArray(DFA9_transitionS);

    protected class DFA9 : DFA
    {
        public DFA9(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 9;
            this.eot = DFA9_eot;
            this.eof = DFA9_eof;
            this.min = DFA9_min;
            this.max = DFA9_max;
            this.accept = DFA9_accept;
            this.special = DFA9_special;
            this.transition = DFA9_transition;

        }

        override public string Description
        {
            get { return "1:1: Tokens : ( T_NULL | T_NOT | MINUS | LT | GT | GE | LE | NE | EQ | COMMA | DOT | EQ2 | NE2 | NUMBER | WHITESPACE | ENDLINE | SQL_LITERAL | A_STRING | Q_STRING );"; }
        }

    }

 
    
}
