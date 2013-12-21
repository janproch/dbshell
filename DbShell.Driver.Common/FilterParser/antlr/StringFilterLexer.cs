// $ANTLR 3.2 Sep 23, 2009 12:02:23 StringFilter.g 2013-12-21 16:34:59

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162


using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;


public partial class StringFilterLexer : Lexer {
    public const int DOLLAR = 17;
    public const int LT = 9;
    public const int STAR = 24;
    public const int EOF = -1;
    public const int Q_STRING = 4;
    public const int COMMA = 22;
    public const int T_NULL = 19;
    public const int PLUS = 7;
    public const int DIGIT = 35;
    public const int EQ = 14;
    public const int NE = 13;
    public const int D = 39;
    public const int E = 30;
    public const int F = 40;
    public const int GE = 12;
    public const int G = 41;
    public const int I_STRING = 6;
    public const int A = 36;
    public const int B = 37;
    public const int C = 38;
    public const int L = 27;
    public const int M = 31;
    public const int N = 25;
    public const int O = 28;
    public const int H = 42;
    public const int I = 43;
    public const int J = 44;
    public const int K = 45;
    public const int U = 26;
    public const int T = 29;
    public const int W = 50;
    public const int WHITESPACE = 34;
    public const int V = 49;
    public const int Q = 46;
    public const int P = 32;
    public const int S = 48;
    public const int R = 47;
    public const int MINUS = 8;
    public const int Y = 33;
    public const int X = 51;
    public const int Z = 52;
    public const int NDOLLAR = 18;
    public const int T_EMPTY = 21;
    public const int A_STRING = 5;
    public const int GT = 10;
    public const int ARROW = 15;
    public const int ENDLINE = 23;
    public const int T_NOT = 20;
    public const int NARROW = 16;
    public const int LE = 11;

    // delegates
    // delegators

    public StringFilterLexer() 
    {
		InitializeCyclicDFAs();
    }
    public StringFilterLexer(ICharStream input)
		: this(input, null) {
    }
    public StringFilterLexer(ICharStream input, RecognizerSharedState state)
		: base(input, state) {
		InitializeCyclicDFAs(); 

    }
    
    override public string GrammarFileName
    {
    	get { return "StringFilter.g";} 
    }

    // $ANTLR start "MINUS"
    public void mMINUS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = MINUS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // StringFilter.g:44:6: ( '-' )
            // StringFilter.g:44:9: '-'
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
            // StringFilter.g:45:3: ( '<' )
            // StringFilter.g:45:6: '<'
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
            // StringFilter.g:46:3: ( '>' )
            // StringFilter.g:46:6: '>'
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
            // StringFilter.g:47:3: ( '>=' )
            // StringFilter.g:47:6: '>='
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
            // StringFilter.g:48:3: ( '<=' )
            // StringFilter.g:48:6: '<='
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
            // StringFilter.g:49:3: ( '!=' | '<>' )
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
                    // StringFilter.g:49:6: '!='
                    {
                    	Match("!="); 


                    }
                    break;
                case 2 :
                    // StringFilter.g:49:13: '<>'
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
            // StringFilter.g:50:3: ( '=' )
            // StringFilter.g:50:6: '='
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

    // $ANTLR start "PLUS"
    public void mPLUS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = PLUS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // StringFilter.g:51:5: ( '+' )
            // StringFilter.g:51:7: '+'
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

    // $ANTLR start "STAR"
    public void mSTAR() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = STAR;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // StringFilter.g:52:5: ( '*' )
            // StringFilter.g:52:8: '*'
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
    // $ANTLR end "STAR"

    // $ANTLR start "COMMA"
    public void mCOMMA() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = COMMA;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // StringFilter.g:53:6: ( ',' )
            // StringFilter.g:53:8: ','
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

    // $ANTLR start "ARROW"
    public void mARROW() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = ARROW;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // StringFilter.g:54:6: ( '^' )
            // StringFilter.g:54:9: '^'
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
    // $ANTLR end "ARROW"

    // $ANTLR start "DOLLAR"
    public void mDOLLAR() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = DOLLAR;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // StringFilter.g:55:7: ( '$' )
            // StringFilter.g:55:10: '$'
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

    // $ANTLR start "NARROW"
    public void mNARROW() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = NARROW;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // StringFilter.g:56:7: ( '!^' )
            // StringFilter.g:56:10: '!^'
            {
            	Match("!^"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "NARROW"

    // $ANTLR start "NDOLLAR"
    public void mNDOLLAR() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = NDOLLAR;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // StringFilter.g:57:8: ( '!$' )
            // StringFilter.g:57:11: '!$'
            {
            	Match("!$"); 


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "NDOLLAR"

    // $ANTLR start "T_NULL"
    public void mT_NULL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_NULL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // StringFilter.g:59:7: ( N U L L )
            // StringFilter.g:59:9: N U L L
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
            // StringFilter.g:60:6: ( N O T )
            // StringFilter.g:60:8: N O T
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

    // $ANTLR start "T_EMPTY"
    public void mT_EMPTY() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_EMPTY;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // StringFilter.g:61:8: ( E M P T Y )
            // StringFilter.g:61:10: E M P T Y
            {
            	mE(); 
            	mM(); 
            	mP(); 
            	mT(); 
            	mY(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_EMPTY"

    // $ANTLR start "A_STRING"
    public void mA_STRING() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = A_STRING;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // StringFilter.g:63:9: ( ( '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\'' ) )
            // StringFilter.g:64:4: ( '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\'' )
            {
            	// StringFilter.g:64:4: ( '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\'' )
            	// StringFilter.g:64:5: '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\''
            	{
            		Match('\''); 
            		// StringFilter.g:65:5: ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )*
            		do 
            		{
            		    int alt2 = 3;
            		    int LA2_0 = input.LA(1);

            		    if ( (LA2_0 == '\'') )
            		    {
            		        int LA2_1 = input.LA(2);

            		        if ( (LA2_1 == '\'') )
            		        {
            		            alt2 = 2;
            		        }


            		    }
            		    else if ( ((LA2_0 >= '\u0000' && LA2_0 <= '\t') || (LA2_0 >= '\u000B' && LA2_0 <= '\f') || (LA2_0 >= '\u000E' && LA2_0 <= '&') || (LA2_0 >= '(' && LA2_0 <= '\uFFFF')) )
            		    {
            		        alt2 = 1;
            		    }


            		    switch (alt2) 
            			{
            				case 1 :
            				    // StringFilter.g:66:31: ~ ( '\\'' | '\\r' | '\\n' )
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
            				    // StringFilter.g:66:56: '\\'' '\\''
            				    {
            				    	Match('\''); 
            				    	Match('\''); 

            				    }
            				    break;

            				default:
            				    goto loop2;
            		    }
            		} while (true);

            		loop2:
            			;	// Stops C# compiler whining that label 'loop2' has no statements

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
            // StringFilter.g:71:9: ( ( '\\\"' ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )* '\\\"' ) )
            // StringFilter.g:72:4: ( '\\\"' ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )* '\\\"' )
            {
            	// StringFilter.g:72:4: ( '\\\"' ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )* '\\\"' )
            	// StringFilter.g:72:5: '\\\"' ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )* '\\\"'
            	{
            		Match('\"'); 
            		// StringFilter.g:73:5: ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )*
            		do 
            		{
            		    int alt3 = 3;
            		    int LA3_0 = input.LA(1);

            		    if ( (LA3_0 == '\"') )
            		    {
            		        int LA3_1 = input.LA(2);

            		        if ( (LA3_1 == '\"') )
            		        {
            		            alt3 = 2;
            		        }


            		    }
            		    else if ( ((LA3_0 >= '\u0000' && LA3_0 <= '\t') || (LA3_0 >= '\u000B' && LA3_0 <= '\f') || (LA3_0 >= '\u000E' && LA3_0 <= '!') || (LA3_0 >= '#' && LA3_0 <= '\uFFFF')) )
            		    {
            		        alt3 = 1;
            		    }


            		    switch (alt3) 
            			{
            				case 1 :
            				    // StringFilter.g:74:31: ~ ( '\\\"' | '\\r' | '\\n' )
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
            				    // StringFilter.g:74:56: '\\\"' '\\\"'
            				    {
            				    	Match('\"'); 
            				    	Match('\"'); 

            				    }
            				    break;

            				default:
            				    goto loop3;
            		    }
            		} while (true);

            		loop3:
            			;	// Stops C# compiler whining that label 'loop3' has no statements

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

    // $ANTLR start "I_STRING"
    public void mI_STRING() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = I_STRING;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // StringFilter.g:79:9: ( (~ ( '-' | ' ' | '<' | '>' | '=' | '!' | '\\r' | '\\n' | '^' | '$' | '*' | ',' | '+' ) )* )
            // StringFilter.g:79:11: (~ ( '-' | ' ' | '<' | '>' | '=' | '!' | '\\r' | '\\n' | '^' | '$' | '*' | ',' | '+' ) )*
            {
            	// StringFilter.g:79:11: (~ ( '-' | ' ' | '<' | '>' | '=' | '!' | '\\r' | '\\n' | '^' | '$' | '*' | ',' | '+' ) )*
            	do 
            	{
            	    int alt4 = 2;
            	    int LA4_0 = input.LA(1);

            	    if ( ((LA4_0 >= '\u0000' && LA4_0 <= '\t') || (LA4_0 >= '\u000B' && LA4_0 <= '\f') || (LA4_0 >= '\u000E' && LA4_0 <= '\u001F') || (LA4_0 >= '\"' && LA4_0 <= '#') || (LA4_0 >= '%' && LA4_0 <= ')') || (LA4_0 >= '.' && LA4_0 <= ';') || (LA4_0 >= '?' && LA4_0 <= ']') || (LA4_0 >= '_' && LA4_0 <= '\uFFFF')) )
            	    {
            	        alt4 = 1;
            	    }


            	    switch (alt4) 
            		{
            			case 1 :
            			    // StringFilter.g:79:12: ~ ( '-' | ' ' | '<' | '>' | '=' | '!' | '\\r' | '\\n' | '^' | '$' | '*' | ',' | '+' )
            			    {
            			    	if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '\t') || (input.LA(1) >= '\u000B' && input.LA(1) <= '\f') || (input.LA(1) >= '\u000E' && input.LA(1) <= '\u001F') || (input.LA(1) >= '\"' && input.LA(1) <= '#') || (input.LA(1) >= '%' && input.LA(1) <= ')') || (input.LA(1) >= '.' && input.LA(1) <= ';') || (input.LA(1) >= '?' && input.LA(1) <= ']') || (input.LA(1) >= '_' && input.LA(1) <= '\uFFFF') ) 
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
            			    goto loop4;
            	    }
            	} while (true);

            	loop4:
            		;	// Stops C# compiler whining that label 'loop4' has no statements


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "I_STRING"

    // $ANTLR start "WHITESPACE"
    public void mWHITESPACE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = WHITESPACE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // StringFilter.g:81:12: ( ( '\\t' | ' ' | '\\u000C' )+ )
            // StringFilter.g:81:14: ( '\\t' | ' ' | '\\u000C' )+
            {
            	// StringFilter.g:81:14: ( '\\t' | ' ' | '\\u000C' )+
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
            			    // StringFilter.g:
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
            // StringFilter.g:82:8: ( ( '\\r' | '\\n' )+ )
            // StringFilter.g:82:10: ( '\\r' | '\\n' )+
            {
            	// StringFilter.g:82:10: ( '\\r' | '\\n' )+
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
            			    // StringFilter.g:
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
            // StringFilter.g:84:17: ( '0' .. '9' )
            // StringFilter.g:84:19: '0' .. '9'
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
            // StringFilter.g:86:11: ( 'A' )
            // StringFilter.g:86:13: 'A'
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
            // StringFilter.g:87:11: ( 'B' )
            // StringFilter.g:87:13: 'B'
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
            // StringFilter.g:88:11: ( 'C' )
            // StringFilter.g:88:13: 'C'
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
            // StringFilter.g:89:11: ( 'D' )
            // StringFilter.g:89:13: 'D'
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
            // StringFilter.g:90:11: ( 'E' )
            // StringFilter.g:90:13: 'E'
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
            // StringFilter.g:91:11: ( 'F' )
            // StringFilter.g:91:13: 'F'
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
            // StringFilter.g:92:11: ( 'G' )
            // StringFilter.g:92:13: 'G'
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
            // StringFilter.g:93:11: ( 'H' )
            // StringFilter.g:93:13: 'H'
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
            // StringFilter.g:94:11: ( 'I' )
            // StringFilter.g:94:13: 'I'
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
            // StringFilter.g:95:11: ( 'J' )
            // StringFilter.g:95:13: 'J'
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
            // StringFilter.g:96:11: ( 'K' )
            // StringFilter.g:96:13: 'K'
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
            // StringFilter.g:97:11: ( 'L' )
            // StringFilter.g:97:13: 'L'
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
            // StringFilter.g:98:11: ( 'M' )
            // StringFilter.g:98:13: 'M'
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
            // StringFilter.g:99:11: ( 'N' )
            // StringFilter.g:99:13: 'N'
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
            // StringFilter.g:100:11: ( 'O' )
            // StringFilter.g:100:13: 'O'
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
            // StringFilter.g:101:11: ( 'P' )
            // StringFilter.g:101:13: 'P'
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
            // StringFilter.g:102:11: ( 'Q' )
            // StringFilter.g:102:13: 'Q'
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
            // StringFilter.g:103:11: ( 'R' )
            // StringFilter.g:103:13: 'R'
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
            // StringFilter.g:104:11: ( 'S' )
            // StringFilter.g:104:13: 'S'
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
            // StringFilter.g:105:11: ( 'T' )
            // StringFilter.g:105:13: 'T'
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
            // StringFilter.g:106:11: ( 'U' )
            // StringFilter.g:106:13: 'U'
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
            // StringFilter.g:107:11: ( 'V' )
            // StringFilter.g:107:13: 'V'
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
            // StringFilter.g:108:11: ( 'W' )
            // StringFilter.g:108:13: 'W'
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
            // StringFilter.g:109:11: ( 'X' )
            // StringFilter.g:109:13: 'X'
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
            // StringFilter.g:110:11: ( 'Y' )
            // StringFilter.g:110:13: 'Y'
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
            // StringFilter.g:111:11: ( 'Z' )
            // StringFilter.g:111:13: 'Z'
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
        // StringFilter.g:1:8: ( MINUS | LT | GT | GE | LE | NE | EQ | PLUS | STAR | COMMA | ARROW | DOLLAR | NARROW | NDOLLAR | T_NULL | T_NOT | T_EMPTY | A_STRING | Q_STRING | I_STRING | WHITESPACE | ENDLINE )
        int alt7 = 22;
        alt7 = dfa7.Predict(input);
        switch (alt7) 
        {
            case 1 :
                // StringFilter.g:1:10: MINUS
                {
                	mMINUS(); 

                }
                break;
            case 2 :
                // StringFilter.g:1:16: LT
                {
                	mLT(); 

                }
                break;
            case 3 :
                // StringFilter.g:1:19: GT
                {
                	mGT(); 

                }
                break;
            case 4 :
                // StringFilter.g:1:22: GE
                {
                	mGE(); 

                }
                break;
            case 5 :
                // StringFilter.g:1:25: LE
                {
                	mLE(); 

                }
                break;
            case 6 :
                // StringFilter.g:1:28: NE
                {
                	mNE(); 

                }
                break;
            case 7 :
                // StringFilter.g:1:31: EQ
                {
                	mEQ(); 

                }
                break;
            case 8 :
                // StringFilter.g:1:34: PLUS
                {
                	mPLUS(); 

                }
                break;
            case 9 :
                // StringFilter.g:1:39: STAR
                {
                	mSTAR(); 

                }
                break;
            case 10 :
                // StringFilter.g:1:44: COMMA
                {
                	mCOMMA(); 

                }
                break;
            case 11 :
                // StringFilter.g:1:50: ARROW
                {
                	mARROW(); 

                }
                break;
            case 12 :
                // StringFilter.g:1:56: DOLLAR
                {
                	mDOLLAR(); 

                }
                break;
            case 13 :
                // StringFilter.g:1:63: NARROW
                {
                	mNARROW(); 

                }
                break;
            case 14 :
                // StringFilter.g:1:70: NDOLLAR
                {
                	mNDOLLAR(); 

                }
                break;
            case 15 :
                // StringFilter.g:1:78: T_NULL
                {
                	mT_NULL(); 

                }
                break;
            case 16 :
                // StringFilter.g:1:85: T_NOT
                {
                	mT_NOT(); 

                }
                break;
            case 17 :
                // StringFilter.g:1:91: T_EMPTY
                {
                	mT_EMPTY(); 

                }
                break;
            case 18 :
                // StringFilter.g:1:99: A_STRING
                {
                	mA_STRING(); 

                }
                break;
            case 19 :
                // StringFilter.g:1:108: Q_STRING
                {
                	mQ_STRING(); 

                }
                break;
            case 20 :
                // StringFilter.g:1:117: I_STRING
                {
                	mI_STRING(); 

                }
                break;
            case 21 :
                // StringFilter.g:1:126: WHITESPACE
                {
                	mWHITESPACE(); 

                }
                break;
            case 22 :
                // StringFilter.g:1:137: ENDLINE
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
	    this.dfa7.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA7_SpecialStateTransition);
	}

    const string DFA7_eotS =
        "\x01\x10\x01\uffff\x01\x15\x01\x17\x07\uffff\x05\x10\x0a\uffff"+
        "\x04\x10\x01\x1f\x01\uffff\x01\x10\x01\x22\x01\uffff\x01\x10\x01"+
        "\x29\x03\x10\x01\x2b\x01\uffff\x01\x10\x01\uffff\x01\x2d\x01\uffff";
    const string DFA7_eofS =
        "\x2e\uffff";
    const string DFA7_minS =
        "\x01\x09\x01\uffff\x02\x3d\x01\x24\x06\uffff\x01\x4f\x01\x4d\x02"+
        "\x00\x01\x09\x0a\uffff\x01\x4c\x01\x54\x01\x50\x02\x00\x01\uffff"+
        "\x02\x00\x01\uffff\x01\x4c\x01\x00\x01\x54\x03\x00\x01\uffff\x01"+
        "\x59\x01\uffff\x01\x00\x01\uffff";
    const string DFA7_maxS =
        "\x01\x5e\x01\uffff\x01\x3e\x01\x3d\x01\x5e\x06\uffff\x01\x55\x01"+
        "\x4d\x02\uffff\x01\x20\x0a\uffff\x01\x4c\x01\x54\x01\x50\x02\uffff"+
        "\x01\uffff\x02\uffff\x01\uffff\x01\x4c\x01\uffff\x01\x54\x03\uffff"+
        "\x01\uffff\x01\x59\x01\uffff\x01\uffff\x01\uffff";
    const string DFA7_acceptS =
        "\x01\uffff\x01\x01\x03\uffff\x01\x07\x01\x08\x01\x09\x01\x0a\x01"+
        "\x0b\x01\x0c\x05\uffff\x01\x14\x01\x15\x01\x16\x01\x05\x01\x06\x01"+
        "\x02\x01\x04\x01\x03\x01\x0d\x01\x0e\x05\uffff\x01\x12\x02\uffff"+
        "\x01\x13\x06\uffff\x01\x10\x01\uffff\x01\x0f\x01\uffff\x01\x11";
    const string DFA7_specialS =
        "\x0d\uffff\x01\x08\x01\x06\x0e\uffff\x01\x04\x01\x00\x01\uffff"+
        "\x01\x07\x01\x03\x02\uffff\x01\x02\x01\uffff\x01\x05\x01\x09\x01"+
        "\x0a\x03\uffff\x01\x01\x01\uffff}>";
    static readonly string[] DFA7_transitionS = {
            "\x01\x0f\x01\x12\x01\uffff\x01\x0f\x01\x12\x12\uffff\x01\x11"+
            "\x01\x04\x01\x0e\x01\uffff\x01\x0a\x02\uffff\x01\x0d\x02\uffff"+
            "\x01\x07\x01\x06\x01\x08\x01\x01\x0e\uffff\x01\x02\x01\x05\x01"+
            "\x03\x06\uffff\x01\x0c\x08\uffff\x01\x0b\x0f\uffff\x01\x09",
            "",
            "\x01\x13\x01\x14",
            "\x01\x16",
            "\x01\x19\x18\uffff\x01\x14\x20\uffff\x01\x18",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\x1b\x05\uffff\x01\x1a",
            "\x01\x1c",
            "\x0a\x1d\x01\uffff\x02\x1d\x01\uffff\x12\x1d\x02\x1f\x02\x1d"+
            "\x01\x1f\x02\x1d\x01\x1e\x02\x1d\x04\x1f\x0e\x1d\x03\x1f\x1f"+
            "\x1d\x01\x1f\uffa1\x1d",
            "\x0a\x20\x01\uffff\x02\x20\x01\uffff\x12\x20\x02\x22\x01\x21"+
            "\x01\x20\x01\x22\x05\x20\x04\x22\x0e\x20\x03\x22\x1f\x20\x01"+
            "\x22\uffa1\x20",
            "\x01\x0f\x02\uffff\x01\x0f\x13\uffff\x01\x11",
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
            "\x01\x23",
            "\x01\x24",
            "\x01\x25",
            "\x0a\x1d\x01\uffff\x02\x1d\x01\uffff\x12\x1d\x02\x1f\x02\x1d"+
            "\x01\x1f\x02\x1d\x01\x1e\x02\x1d\x04\x1f\x0e\x1d\x03\x1f\x1f"+
            "\x1d\x01\x1f\uffa1\x1d",
            "\x0a\x10\x01\uffff\x02\x10\x01\uffff\x12\x10\x02\uffff\x02"+
            "\x10\x01\uffff\x02\x10\x01\x26\x02\x10\x04\uffff\x0e\x10\x03"+
            "\uffff\x1f\x10\x01\uffff\uffa1\x10",
            "",
            "\x0a\x20\x01\uffff\x02\x20\x01\uffff\x12\x20\x02\x22\x01\x21"+
            "\x01\x20\x01\x22\x05\x20\x04\x22\x0e\x20\x03\x22\x1f\x20\x01"+
            "\x22\uffa1\x20",
            "\x0a\x10\x01\uffff\x02\x10\x01\uffff\x12\x10\x02\uffff\x01"+
            "\x27\x01\x10\x01\uffff\x05\x10\x04\uffff\x0e\x10\x03\uffff\x1f"+
            "\x10\x01\uffff\uffa1\x10",
            "",
            "\x01\x28",
            "\x0a\x10\x01\uffff\x02\x10\x01\uffff\x12\x10\x02\uffff\x02"+
            "\x10\x01\uffff\x05\x10\x04\uffff\x0e\x10\x03\uffff\x1f\x10\x01"+
            "\uffff\uffa1\x10",
            "\x01\x2a",
            "\x0a\x1d\x01\uffff\x02\x1d\x01\uffff\x12\x1d\x02\x1f\x02\x1d"+
            "\x01\x1f\x02\x1d\x01\x1e\x02\x1d\x04\x1f\x0e\x1d\x03\x1f\x1f"+
            "\x1d\x01\x1f\uffa1\x1d",
            "\x0a\x20\x01\uffff\x02\x20\x01\uffff\x12\x20\x02\x22\x01\x21"+
            "\x01\x20\x01\x22\x05\x20\x04\x22\x0e\x20\x03\x22\x1f\x20\x01"+
            "\x22\uffa1\x20",
            "\x0a\x10\x01\uffff\x02\x10\x01\uffff\x12\x10\x02\uffff\x02"+
            "\x10\x01\uffff\x05\x10\x04\uffff\x0e\x10\x03\uffff\x1f\x10\x01"+
            "\uffff\uffa1\x10",
            "",
            "\x01\x2c",
            "",
            "\x0a\x10\x01\uffff\x02\x10\x01\uffff\x12\x10\x02\uffff\x02"+
            "\x10\x01\uffff\x05\x10\x04\uffff\x0e\x10\x03\uffff\x1f\x10\x01"+
            "\uffff\uffa1\x10",
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
            get { return "1:1: Tokens : ( MINUS | LT | GT | GE | LE | NE | EQ | PLUS | STAR | COMMA | ARROW | DOLLAR | NARROW | NDOLLAR | T_NULL | T_NOT | T_EMPTY | A_STRING | Q_STRING | I_STRING | WHITESPACE | ENDLINE );"; }
        }

    }


    protected internal int DFA7_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            IIntStream input = _input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA7_30 = input.LA(1);

                   	s = -1;
                   	if ( (LA7_30 == '\'') ) { s = 38; }

                   	else if ( ((LA7_30 >= '\u0000' && LA7_30 <= '\t') || (LA7_30 >= '\u000B' && LA7_30 <= '\f') || (LA7_30 >= '\u000E' && LA7_30 <= '\u001F') || (LA7_30 >= '\"' && LA7_30 <= '#') || (LA7_30 >= '%' && LA7_30 <= '&') || (LA7_30 >= '(' && LA7_30 <= ')') || (LA7_30 >= '.' && LA7_30 <= ';') || (LA7_30 >= '?' && LA7_30 <= ']') || (LA7_30 >= '_' && LA7_30 <= '\uFFFF')) ) { s = 16; }

                   	else s = 31;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 1 : 
                   	int LA7_44 = input.LA(1);

                   	s = -1;
                   	if ( ((LA7_44 >= '\u0000' && LA7_44 <= '\t') || (LA7_44 >= '\u000B' && LA7_44 <= '\f') || (LA7_44 >= '\u000E' && LA7_44 <= '\u001F') || (LA7_44 >= '\"' && LA7_44 <= '#') || (LA7_44 >= '%' && LA7_44 <= ')') || (LA7_44 >= '.' && LA7_44 <= ';') || (LA7_44 >= '?' && LA7_44 <= ']') || (LA7_44 >= '_' && LA7_44 <= '\uFFFF')) ) { s = 16; }

                   	else s = 45;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 2 : 
                   	int LA7_36 = input.LA(1);

                   	s = -1;
                   	if ( ((LA7_36 >= '\u0000' && LA7_36 <= '\t') || (LA7_36 >= '\u000B' && LA7_36 <= '\f') || (LA7_36 >= '\u000E' && LA7_36 <= '\u001F') || (LA7_36 >= '\"' && LA7_36 <= '#') || (LA7_36 >= '%' && LA7_36 <= ')') || (LA7_36 >= '.' && LA7_36 <= ';') || (LA7_36 >= '?' && LA7_36 <= ']') || (LA7_36 >= '_' && LA7_36 <= '\uFFFF')) ) { s = 16; }

                   	else s = 41;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 3 : 
                   	int LA7_33 = input.LA(1);

                   	s = -1;
                   	if ( (LA7_33 == '\"') ) { s = 39; }

                   	else if ( ((LA7_33 >= '\u0000' && LA7_33 <= '\t') || (LA7_33 >= '\u000B' && LA7_33 <= '\f') || (LA7_33 >= '\u000E' && LA7_33 <= '\u001F') || LA7_33 == '#' || (LA7_33 >= '%' && LA7_33 <= ')') || (LA7_33 >= '.' && LA7_33 <= ';') || (LA7_33 >= '?' && LA7_33 <= ']') || (LA7_33 >= '_' && LA7_33 <= '\uFFFF')) ) { s = 16; }

                   	else s = 34;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 4 : 
                   	int LA7_29 = input.LA(1);

                   	s = -1;
                   	if ( (LA7_29 == '\'') ) { s = 30; }

                   	else if ( ((LA7_29 >= '\u0000' && LA7_29 <= '\t') || (LA7_29 >= '\u000B' && LA7_29 <= '\f') || (LA7_29 >= '\u000E' && LA7_29 <= '\u001F') || (LA7_29 >= '\"' && LA7_29 <= '#') || (LA7_29 >= '%' && LA7_29 <= '&') || (LA7_29 >= '(' && LA7_29 <= ')') || (LA7_29 >= '.' && LA7_29 <= ';') || (LA7_29 >= '?' && LA7_29 <= ']') || (LA7_29 >= '_' && LA7_29 <= '\uFFFF')) ) { s = 29; }

                   	else if ( ((LA7_29 >= ' ' && LA7_29 <= '!') || LA7_29 == '$' || (LA7_29 >= '*' && LA7_29 <= '-') || (LA7_29 >= '<' && LA7_29 <= '>') || LA7_29 == '^') ) { s = 31; }

                   	else s = 16;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 5 : 
                   	int LA7_38 = input.LA(1);

                   	s = -1;
                   	if ( (LA7_38 == '\'') ) { s = 30; }

                   	else if ( ((LA7_38 >= '\u0000' && LA7_38 <= '\t') || (LA7_38 >= '\u000B' && LA7_38 <= '\f') || (LA7_38 >= '\u000E' && LA7_38 <= '\u001F') || (LA7_38 >= '\"' && LA7_38 <= '#') || (LA7_38 >= '%' && LA7_38 <= '&') || (LA7_38 >= '(' && LA7_38 <= ')') || (LA7_38 >= '.' && LA7_38 <= ';') || (LA7_38 >= '?' && LA7_38 <= ']') || (LA7_38 >= '_' && LA7_38 <= '\uFFFF')) ) { s = 29; }

                   	else if ( ((LA7_38 >= ' ' && LA7_38 <= '!') || LA7_38 == '$' || (LA7_38 >= '*' && LA7_38 <= '-') || (LA7_38 >= '<' && LA7_38 <= '>') || LA7_38 == '^') ) { s = 31; }

                   	else s = 16;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 6 : 
                   	int LA7_14 = input.LA(1);

                   	s = -1;
                   	if ( ((LA7_14 >= '\u0000' && LA7_14 <= '\t') || (LA7_14 >= '\u000B' && LA7_14 <= '\f') || (LA7_14 >= '\u000E' && LA7_14 <= '\u001F') || LA7_14 == '#' || (LA7_14 >= '%' && LA7_14 <= ')') || (LA7_14 >= '.' && LA7_14 <= ';') || (LA7_14 >= '?' && LA7_14 <= ']') || (LA7_14 >= '_' && LA7_14 <= '\uFFFF')) ) { s = 32; }

                   	else if ( (LA7_14 == '\"') ) { s = 33; }

                   	else if ( ((LA7_14 >= ' ' && LA7_14 <= '!') || LA7_14 == '$' || (LA7_14 >= '*' && LA7_14 <= '-') || (LA7_14 >= '<' && LA7_14 <= '>') || LA7_14 == '^') ) { s = 34; }

                   	else s = 16;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 7 : 
                   	int LA7_32 = input.LA(1);

                   	s = -1;
                   	if ( (LA7_32 == '\"') ) { s = 33; }

                   	else if ( ((LA7_32 >= '\u0000' && LA7_32 <= '\t') || (LA7_32 >= '\u000B' && LA7_32 <= '\f') || (LA7_32 >= '\u000E' && LA7_32 <= '\u001F') || LA7_32 == '#' || (LA7_32 >= '%' && LA7_32 <= ')') || (LA7_32 >= '.' && LA7_32 <= ';') || (LA7_32 >= '?' && LA7_32 <= ']') || (LA7_32 >= '_' && LA7_32 <= '\uFFFF')) ) { s = 32; }

                   	else if ( ((LA7_32 >= ' ' && LA7_32 <= '!') || LA7_32 == '$' || (LA7_32 >= '*' && LA7_32 <= '-') || (LA7_32 >= '<' && LA7_32 <= '>') || LA7_32 == '^') ) { s = 34; }

                   	else s = 16;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 8 : 
                   	int LA7_13 = input.LA(1);

                   	s = -1;
                   	if ( ((LA7_13 >= '\u0000' && LA7_13 <= '\t') || (LA7_13 >= '\u000B' && LA7_13 <= '\f') || (LA7_13 >= '\u000E' && LA7_13 <= '\u001F') || (LA7_13 >= '\"' && LA7_13 <= '#') || (LA7_13 >= '%' && LA7_13 <= '&') || (LA7_13 >= '(' && LA7_13 <= ')') || (LA7_13 >= '.' && LA7_13 <= ';') || (LA7_13 >= '?' && LA7_13 <= ']') || (LA7_13 >= '_' && LA7_13 <= '\uFFFF')) ) { s = 29; }

                   	else if ( (LA7_13 == '\'') ) { s = 30; }

                   	else if ( ((LA7_13 >= ' ' && LA7_13 <= '!') || LA7_13 == '$' || (LA7_13 >= '*' && LA7_13 <= '-') || (LA7_13 >= '<' && LA7_13 <= '>') || LA7_13 == '^') ) { s = 31; }

                   	else s = 16;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 9 : 
                   	int LA7_39 = input.LA(1);

                   	s = -1;
                   	if ( (LA7_39 == '\"') ) { s = 33; }

                   	else if ( ((LA7_39 >= '\u0000' && LA7_39 <= '\t') || (LA7_39 >= '\u000B' && LA7_39 <= '\f') || (LA7_39 >= '\u000E' && LA7_39 <= '\u001F') || LA7_39 == '#' || (LA7_39 >= '%' && LA7_39 <= ')') || (LA7_39 >= '.' && LA7_39 <= ';') || (LA7_39 >= '?' && LA7_39 <= ']') || (LA7_39 >= '_' && LA7_39 <= '\uFFFF')) ) { s = 32; }

                   	else if ( ((LA7_39 >= ' ' && LA7_39 <= '!') || LA7_39 == '$' || (LA7_39 >= '*' && LA7_39 <= '-') || (LA7_39 >= '<' && LA7_39 <= '>') || LA7_39 == '^') ) { s = 34; }

                   	else s = 16;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 10 : 
                   	int LA7_40 = input.LA(1);

                   	s = -1;
                   	if ( ((LA7_40 >= '\u0000' && LA7_40 <= '\t') || (LA7_40 >= '\u000B' && LA7_40 <= '\f') || (LA7_40 >= '\u000E' && LA7_40 <= '\u001F') || (LA7_40 >= '\"' && LA7_40 <= '#') || (LA7_40 >= '%' && LA7_40 <= ')') || (LA7_40 >= '.' && LA7_40 <= ';') || (LA7_40 >= '?' && LA7_40 <= ']') || (LA7_40 >= '_' && LA7_40 <= '\uFFFF')) ) { s = 16; }

                   	else s = 43;

                   	if ( s >= 0 ) return s;
                   	break;
        }
        NoViableAltException nvae7 =
            new NoViableAltException(dfa.Description, 7, _s, input);
        dfa.Error(nvae7);
        throw nvae7;
    }
 
    
}
