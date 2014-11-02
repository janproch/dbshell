// $ANTLR 3.2 Sep 23, 2009 12:02:23 StringFilter.g 2014-11-02 21:57:15

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
    public const int DOLLAR = 19;
    public const int LT = 11;
    public const int STAR = 28;
    public const int EOF = -1;
    public const int Q_STRING = 4;
    public const int COMMA = 26;
    public const int T_NULL = 21;
    public const int PLUS = 9;
    public const int DIGIT = 39;
    public const int EQ = 16;
    public const int DOT = 8;
    public const int NE = 15;
    public const int D = 43;
    public const int E = 34;
    public const int GE = 14;
    public const int F = 44;
    public const int G = 45;
    public const int I_STRING = 6;
    public const int A = 40;
    public const int B = 41;
    public const int NE2 = 25;
    public const int C = 42;
    public const int L = 31;
    public const int M = 35;
    public const int N = 29;
    public const int O = 32;
    public const int H = 46;
    public const int I = 47;
    public const int J = 48;
    public const int K = 49;
    public const int U = 30;
    public const int T = 33;
    public const int W = 54;
    public const int WHITESPACE = 38;
    public const int V = 53;
    public const int Q = 50;
    public const int P = 36;
    public const int S = 52;
    public const int R = 51;
    public const int MINUS = 10;
    public const int Y = 37;
    public const int EQ2 = 24;
    public const int SQL_LITERAL = 7;
    public const int X = 55;
    public const int Z = 56;
    public const int NDOLLAR = 20;
    public const int T_EMPTY = 23;
    public const int A_STRING = 5;
    public const int GT = 12;
    public const int ARROW = 17;
    public const int ENDLINE = 27;
    public const int T_NOT = 22;
    public const int NARROW = 18;
    public const int LE = 13;

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
            // StringFilter.g:58:6: ( '-' )
            // StringFilter.g:58:9: '-'
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
            // StringFilter.g:59:3: ( '<' )
            // StringFilter.g:59:6: '<'
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
            // StringFilter.g:60:3: ( '>' )
            // StringFilter.g:60:6: '>'
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
            // StringFilter.g:61:3: ( '>=' )
            // StringFilter.g:61:6: '>='
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
            // StringFilter.g:62:3: ( '<=' )
            // StringFilter.g:62:6: '<='
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
            // StringFilter.g:63:3: ( '<>' )
            // StringFilter.g:63:6: '<>'
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
            // StringFilter.g:64:3: ( '=' )
            // StringFilter.g:64:6: '='
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
            // StringFilter.g:65:5: ( '+' )
            // StringFilter.g:65:7: '+'
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
            // StringFilter.g:66:5: ( '*' )
            // StringFilter.g:66:8: '*'
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
            // StringFilter.g:67:6: ( ',' )
            // StringFilter.g:67:8: ','
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
            // StringFilter.g:68:6: ( '^' )
            // StringFilter.g:68:9: '^'
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
            // StringFilter.g:69:7: ( '$' )
            // StringFilter.g:69:10: '$'
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
            // StringFilter.g:70:7: ( '!^' )
            // StringFilter.g:70:10: '!^'
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
            // StringFilter.g:71:8: ( '!$' )
            // StringFilter.g:71:11: '!$'
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

    // $ANTLR start "DOT"
    public void mDOT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = DOT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // StringFilter.g:72:4: ( '.' )
            // StringFilter.g:72:6: '.'
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
            // StringFilter.g:73:4: ( '==' )
            // StringFilter.g:73:7: '=='
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
            // StringFilter.g:74:4: ( '!=' )
            // StringFilter.g:74:7: '!='
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

    // $ANTLR start "T_NULL"
    public void mT_NULL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_NULL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // StringFilter.g:76:7: ( N U L L )
            // StringFilter.g:76:9: N U L L
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
            // StringFilter.g:77:6: ( N O T )
            // StringFilter.g:77:8: N O T
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
            // StringFilter.g:78:8: ( E M P T Y )
            // StringFilter.g:78:10: E M P T Y
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

    // $ANTLR start "SQL_LITERAL"
    public void mSQL_LITERAL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = SQL_LITERAL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // StringFilter.g:80:12: ( ( '[' ( options {greedy=true; } : ~ ( ']' | '\\r' | '\\n' ) )* ']' ) )
            // StringFilter.g:81:4: ( '[' ( options {greedy=true; } : ~ ( ']' | '\\r' | '\\n' ) )* ']' )
            {
            	// StringFilter.g:81:4: ( '[' ( options {greedy=true; } : ~ ( ']' | '\\r' | '\\n' ) )* ']' )
            	// StringFilter.g:81:5: '[' ( options {greedy=true; } : ~ ( ']' | '\\r' | '\\n' ) )* ']'
            	{
            		Match('['); 
            		// StringFilter.g:82:5: ( options {greedy=true; } : ~ ( ']' | '\\r' | '\\n' ) )*
            		do 
            		{
            		    int alt1 = 2;
            		    int LA1_0 = input.LA(1);

            		    if ( ((LA1_0 >= '\u0000' && LA1_0 <= '\t') || (LA1_0 >= '\u000B' && LA1_0 <= '\f') || (LA1_0 >= '\u000E' && LA1_0 <= '\\') || (LA1_0 >= '^' && LA1_0 <= '\uFFFF')) )
            		    {
            		        alt1 = 1;
            		    }


            		    switch (alt1) 
            			{
            				case 1 :
            				    // StringFilter.g:83:31: ~ ( ']' | '\\r' | '\\n' )
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
            				    goto loop1;
            		    }
            		} while (true);

            		loop1:
            			;	// Stops C# compiler whining that label 'loop1' has no statements

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
            // StringFilter.g:88:9: ( ( '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\'' ) )
            // StringFilter.g:89:4: ( '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\'' )
            {
            	// StringFilter.g:89:4: ( '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\'' )
            	// StringFilter.g:89:5: '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\''
            	{
            		Match('\''); 
            		// StringFilter.g:90:5: ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )*
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
            				    // StringFilter.g:91:31: ~ ( '\\'' | '\\r' | '\\n' )
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
            				    // StringFilter.g:91:56: '\\'' '\\''
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
            // StringFilter.g:96:9: ( ( '\\\"' ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )* '\\\"' ) )
            // StringFilter.g:97:4: ( '\\\"' ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )* '\\\"' )
            {
            	// StringFilter.g:97:4: ( '\\\"' ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )* '\\\"' )
            	// StringFilter.g:97:5: '\\\"' ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )* '\\\"'
            	{
            		Match('\"'); 
            		// StringFilter.g:98:5: ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )*
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
            				    // StringFilter.g:99:31: ~ ( '\\\"' | '\\r' | '\\n' )
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
            				    // StringFilter.g:99:56: '\\\"' '\\\"'
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
            // StringFilter.g:104:9: ( (~ ( '[' | '-' | ' ' | '<' | '>' | '=' | '!' | '\\r' | '\\n' | '^' | '$' | '*' | ',' | '+' ) )* )
            // StringFilter.g:104:11: (~ ( '[' | '-' | ' ' | '<' | '>' | '=' | '!' | '\\r' | '\\n' | '^' | '$' | '*' | ',' | '+' ) )*
            {
            	// StringFilter.g:104:11: (~ ( '[' | '-' | ' ' | '<' | '>' | '=' | '!' | '\\r' | '\\n' | '^' | '$' | '*' | ',' | '+' ) )*
            	do 
            	{
            	    int alt4 = 2;
            	    int LA4_0 = input.LA(1);

            	    if ( ((LA4_0 >= '\u0000' && LA4_0 <= '\t') || (LA4_0 >= '\u000B' && LA4_0 <= '\f') || (LA4_0 >= '\u000E' && LA4_0 <= '\u001F') || (LA4_0 >= '\"' && LA4_0 <= '#') || (LA4_0 >= '%' && LA4_0 <= ')') || (LA4_0 >= '.' && LA4_0 <= ';') || (LA4_0 >= '?' && LA4_0 <= 'Z') || (LA4_0 >= '\\' && LA4_0 <= ']') || (LA4_0 >= '_' && LA4_0 <= '\uFFFF')) )
            	    {
            	        alt4 = 1;
            	    }


            	    switch (alt4) 
            		{
            			case 1 :
            			    // StringFilter.g:104:12: ~ ( '[' | '-' | ' ' | '<' | '>' | '=' | '!' | '\\r' | '\\n' | '^' | '$' | '*' | ',' | '+' )
            			    {
            			    	if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '\t') || (input.LA(1) >= '\u000B' && input.LA(1) <= '\f') || (input.LA(1) >= '\u000E' && input.LA(1) <= '\u001F') || (input.LA(1) >= '\"' && input.LA(1) <= '#') || (input.LA(1) >= '%' && input.LA(1) <= ')') || (input.LA(1) >= '.' && input.LA(1) <= ';') || (input.LA(1) >= '?' && input.LA(1) <= 'Z') || (input.LA(1) >= '\\' && input.LA(1) <= ']') || (input.LA(1) >= '_' && input.LA(1) <= '\uFFFF') ) 
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
            // StringFilter.g:106:12: ( ( '\\t' | ' ' | '\\u000C' )+ )
            // StringFilter.g:106:14: ( '\\t' | ' ' | '\\u000C' )+
            {
            	// StringFilter.g:106:14: ( '\\t' | ' ' | '\\u000C' )+
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
            // StringFilter.g:107:8: ( ( '\\r' | '\\n' )+ )
            // StringFilter.g:107:10: ( '\\r' | '\\n' )+
            {
            	// StringFilter.g:107:10: ( '\\r' | '\\n' )+
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
            // StringFilter.g:109:17: ( '0' .. '9' )
            // StringFilter.g:109:19: '0' .. '9'
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
            // StringFilter.g:111:11: ( 'A' )
            // StringFilter.g:111:13: 'A'
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
            // StringFilter.g:112:11: ( 'B' )
            // StringFilter.g:112:13: 'B'
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
            // StringFilter.g:113:11: ( 'C' )
            // StringFilter.g:113:13: 'C'
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
            // StringFilter.g:114:11: ( 'D' )
            // StringFilter.g:114:13: 'D'
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
            // StringFilter.g:115:11: ( 'E' )
            // StringFilter.g:115:13: 'E'
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
            // StringFilter.g:116:11: ( 'F' )
            // StringFilter.g:116:13: 'F'
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
            // StringFilter.g:117:11: ( 'G' )
            // StringFilter.g:117:13: 'G'
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
            // StringFilter.g:118:11: ( 'H' )
            // StringFilter.g:118:13: 'H'
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
            // StringFilter.g:119:11: ( 'I' )
            // StringFilter.g:119:13: 'I'
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
            // StringFilter.g:120:11: ( 'J' )
            // StringFilter.g:120:13: 'J'
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
            // StringFilter.g:121:11: ( 'K' )
            // StringFilter.g:121:13: 'K'
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
            // StringFilter.g:122:11: ( 'L' )
            // StringFilter.g:122:13: 'L'
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
            // StringFilter.g:123:11: ( 'M' )
            // StringFilter.g:123:13: 'M'
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
            // StringFilter.g:124:11: ( 'N' )
            // StringFilter.g:124:13: 'N'
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
            // StringFilter.g:125:11: ( 'O' )
            // StringFilter.g:125:13: 'O'
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
            // StringFilter.g:126:11: ( 'P' )
            // StringFilter.g:126:13: 'P'
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
            // StringFilter.g:127:11: ( 'Q' )
            // StringFilter.g:127:13: 'Q'
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
            // StringFilter.g:128:11: ( 'R' )
            // StringFilter.g:128:13: 'R'
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
            // StringFilter.g:129:11: ( 'S' )
            // StringFilter.g:129:13: 'S'
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
            // StringFilter.g:130:11: ( 'T' )
            // StringFilter.g:130:13: 'T'
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
            // StringFilter.g:131:11: ( 'U' )
            // StringFilter.g:131:13: 'U'
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
            // StringFilter.g:132:11: ( 'V' )
            // StringFilter.g:132:13: 'V'
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
            // StringFilter.g:133:11: ( 'W' )
            // StringFilter.g:133:13: 'W'
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
            // StringFilter.g:134:11: ( 'X' )
            // StringFilter.g:134:13: 'X'
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
            // StringFilter.g:135:11: ( 'Y' )
            // StringFilter.g:135:13: 'Y'
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
            // StringFilter.g:136:11: ( 'Z' )
            // StringFilter.g:136:13: 'Z'
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
        // StringFilter.g:1:8: ( MINUS | LT | GT | GE | LE | NE | EQ | PLUS | STAR | COMMA | ARROW | DOLLAR | NARROW | NDOLLAR | DOT | EQ2 | NE2 | T_NULL | T_NOT | T_EMPTY | SQL_LITERAL | A_STRING | Q_STRING | I_STRING | WHITESPACE | ENDLINE )
        int alt7 = 26;
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
                // StringFilter.g:1:78: DOT
                {
                	mDOT(); 

                }
                break;
            case 16 :
                // StringFilter.g:1:82: EQ2
                {
                	mEQ2(); 

                }
                break;
            case 17 :
                // StringFilter.g:1:86: NE2
                {
                	mNE2(); 

                }
                break;
            case 18 :
                // StringFilter.g:1:90: T_NULL
                {
                	mT_NULL(); 

                }
                break;
            case 19 :
                // StringFilter.g:1:97: T_NOT
                {
                	mT_NOT(); 

                }
                break;
            case 20 :
                // StringFilter.g:1:103: T_EMPTY
                {
                	mT_EMPTY(); 

                }
                break;
            case 21 :
                // StringFilter.g:1:111: SQL_LITERAL
                {
                	mSQL_LITERAL(); 

                }
                break;
            case 22 :
                // StringFilter.g:1:123: A_STRING
                {
                	mA_STRING(); 

                }
                break;
            case 23 :
                // StringFilter.g:1:132: Q_STRING
                {
                	mQ_STRING(); 

                }
                break;
            case 24 :
                // StringFilter.g:1:141: I_STRING
                {
                	mI_STRING(); 

                }
                break;
            case 25 :
                // StringFilter.g:1:150: WHITESPACE
                {
                	mWHITESPACE(); 

                }
                break;
            case 26 :
                // StringFilter.g:1:161: ENDLINE
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
        "\x01\x12\x01\uffff\x01\x17\x01\x19\x01\x1b\x06\uffff\x01\x1f\x02"+
        "\x12\x01\uffff\x03\x12\x0e\uffff\x04\x12\x01\x25\x01\uffff\x01\x12"+
        "\x01\x28\x01\uffff\x01\x12\x01\x2f\x03\x12\x01\x31\x01\uffff\x01"+
        "\x12\x01\uffff\x01\x33\x01\uffff";
    const string DFA7_eofS =
        "\x34\uffff";
    const string DFA7_minS =
        "\x01\x09\x01\uffff\x03\x3d\x05\uffff\x01\x24\x01\x00\x01\x4f\x01"+
        "\x4d\x01\uffff\x02\x00\x01\x09\x0e\uffff\x01\x4c\x01\x54\x01\x50"+
        "\x02\x00\x01\uffff\x02\x00\x01\uffff\x01\x4c\x01\x00\x01\x54\x03"+
        "\x00\x01\uffff\x01\x59\x01\uffff\x01\x00\x01\uffff";
    const string DFA7_maxS =
        "\x01\x5e\x01\uffff\x01\x3e\x02\x3d\x05\uffff\x01\x5e\x01\uffff"+
        "\x01\x55\x01\x4d\x01\uffff\x02\uffff\x01\x20\x0e\uffff\x01\x4c\x01"+
        "\x54\x01\x50\x02\uffff\x01\uffff\x02\uffff\x01\uffff\x01\x4c\x01"+
        "\uffff\x01\x54\x03\uffff\x01\uffff\x01\x59\x01\uffff\x01\uffff\x01"+
        "\uffff";
    const string DFA7_acceptS =
        "\x01\uffff\x01\x01\x03\uffff\x01\x08\x01\x09\x01\x0a\x01\x0b\x01"+
        "\x0c\x04\uffff\x01\x15\x03\uffff\x01\x18\x01\x19\x01\x1a\x01\x05"+
        "\x01\x06\x01\x02\x01\x04\x01\x03\x01\x10\x01\x07\x01\x0d\x01\x0e"+
        "\x01\x11\x01\x0f\x05\uffff\x01\x16\x02\uffff\x01\x17\x06\uffff\x01"+
        "\x13\x01\uffff\x01\x12\x01\uffff\x01\x14";
    const string DFA7_specialS =
        "\x0b\uffff\x01\x06\x03\uffff\x01\x07\x01\x04\x12\uffff\x01\x01"+
        "\x01\x05\x01\uffff\x01\x00\x01\x0b\x02\uffff\x01\x02\x01\uffff\x01"+
        "\x03\x01\x09\x01\x08\x03\uffff\x01\x0a\x01\uffff}>";
    static readonly string[] DFA7_transitionS = {
            "\x01\x11\x01\x14\x01\uffff\x01\x11\x01\x14\x12\uffff\x01\x13"+
            "\x01\x0a\x01\x10\x01\uffff\x01\x09\x02\uffff\x01\x0f\x02\uffff"+
            "\x01\x06\x01\x05\x01\x07\x01\x01\x01\x0b\x0d\uffff\x01\x02\x01"+
            "\x04\x01\x03\x06\uffff\x01\x0d\x08\uffff\x01\x0c\x0c\uffff\x01"+
            "\x0e\x02\uffff\x01\x08",
            "",
            "\x01\x15\x01\x16",
            "\x01\x18",
            "\x01\x1a",
            "",
            "",
            "",
            "",
            "",
            "\x01\x1d\x18\uffff\x01\x1e\x20\uffff\x01\x1c",
            "\x0a\x12\x01\uffff\x02\x12\x01\uffff\x12\x12\x02\uffff\x02"+
            "\x12\x01\uffff\x05\x12\x04\uffff\x0e\x12\x03\uffff\x1c\x12\x01"+
            "\uffff\x02\x12\x01\uffff\uffa1\x12",
            "\x01\x21\x05\uffff\x01\x20",
            "\x01\x22",
            "",
            "\x0a\x23\x01\uffff\x02\x23\x01\uffff\x12\x23\x02\x25\x02\x23"+
            "\x01\x25\x02\x23\x01\x24\x02\x23\x04\x25\x0e\x23\x03\x25\x1c"+
            "\x23\x01\x25\x02\x23\x01\x25\uffa1\x23",
            "\x0a\x26\x01\uffff\x02\x26\x01\uffff\x12\x26\x02\x28\x01\x27"+
            "\x01\x26\x01\x28\x05\x26\x04\x28\x0e\x26\x03\x28\x1c\x26\x01"+
            "\x28\x02\x26\x01\x28\uffa1\x26",
            "\x01\x11\x02\uffff\x01\x11\x13\uffff\x01\x13",
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
            "\x01\x29",
            "\x01\x2a",
            "\x01\x2b",
            "\x0a\x23\x01\uffff\x02\x23\x01\uffff\x12\x23\x02\x25\x02\x23"+
            "\x01\x25\x02\x23\x01\x24\x02\x23\x04\x25\x0e\x23\x03\x25\x1c"+
            "\x23\x01\x25\x02\x23\x01\x25\uffa1\x23",
            "\x0a\x12\x01\uffff\x02\x12\x01\uffff\x12\x12\x02\uffff\x02"+
            "\x12\x01\uffff\x02\x12\x01\x2c\x02\x12\x04\uffff\x0e\x12\x03"+
            "\uffff\x1c\x12\x01\uffff\x02\x12\x01\uffff\uffa1\x12",
            "",
            "\x0a\x26\x01\uffff\x02\x26\x01\uffff\x12\x26\x02\x28\x01\x27"+
            "\x01\x26\x01\x28\x05\x26\x04\x28\x0e\x26\x03\x28\x1c\x26\x01"+
            "\x28\x02\x26\x01\x28\uffa1\x26",
            "\x0a\x12\x01\uffff\x02\x12\x01\uffff\x12\x12\x02\uffff\x01"+
            "\x2d\x01\x12\x01\uffff\x05\x12\x04\uffff\x0e\x12\x03\uffff\x1c"+
            "\x12\x01\uffff\x02\x12\x01\uffff\uffa1\x12",
            "",
            "\x01\x2e",
            "\x0a\x12\x01\uffff\x02\x12\x01\uffff\x12\x12\x02\uffff\x02"+
            "\x12\x01\uffff\x05\x12\x04\uffff\x0e\x12\x03\uffff\x1c\x12\x01"+
            "\uffff\x02\x12\x01\uffff\uffa1\x12",
            "\x01\x30",
            "\x0a\x23\x01\uffff\x02\x23\x01\uffff\x12\x23\x02\x25\x02\x23"+
            "\x01\x25\x02\x23\x01\x24\x02\x23\x04\x25\x0e\x23\x03\x25\x1c"+
            "\x23\x01\x25\x02\x23\x01\x25\uffa1\x23",
            "\x0a\x26\x01\uffff\x02\x26\x01\uffff\x12\x26\x02\x28\x01\x27"+
            "\x01\x26\x01\x28\x05\x26\x04\x28\x0e\x26\x03\x28\x1c\x26\x01"+
            "\x28\x02\x26\x01\x28\uffa1\x26",
            "\x0a\x12\x01\uffff\x02\x12\x01\uffff\x12\x12\x02\uffff\x02"+
            "\x12\x01\uffff\x05\x12\x04\uffff\x0e\x12\x03\uffff\x1c\x12\x01"+
            "\uffff\x02\x12\x01\uffff\uffa1\x12",
            "",
            "\x01\x32",
            "",
            "\x0a\x12\x01\uffff\x02\x12\x01\uffff\x12\x12\x02\uffff\x02"+
            "\x12\x01\uffff\x05\x12\x04\uffff\x0e\x12\x03\uffff\x1c\x12\x01"+
            "\uffff\x02\x12\x01\uffff\uffa1\x12",
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
            get { return "1:1: Tokens : ( MINUS | LT | GT | GE | LE | NE | EQ | PLUS | STAR | COMMA | ARROW | DOLLAR | NARROW | NDOLLAR | DOT | EQ2 | NE2 | T_NULL | T_NOT | T_EMPTY | SQL_LITERAL | A_STRING | Q_STRING | I_STRING | WHITESPACE | ENDLINE );"; }
        }

    }


    protected internal int DFA7_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            IIntStream input = _input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA7_38 = input.LA(1);

                   	s = -1;
                   	if ( (LA7_38 == '\"') ) { s = 39; }

                   	else if ( ((LA7_38 >= '\u0000' && LA7_38 <= '\t') || (LA7_38 >= '\u000B' && LA7_38 <= '\f') || (LA7_38 >= '\u000E' && LA7_38 <= '\u001F') || LA7_38 == '#' || (LA7_38 >= '%' && LA7_38 <= ')') || (LA7_38 >= '.' && LA7_38 <= ';') || (LA7_38 >= '?' && LA7_38 <= 'Z') || (LA7_38 >= '\\' && LA7_38 <= ']') || (LA7_38 >= '_' && LA7_38 <= '\uFFFF')) ) { s = 38; }

                   	else if ( ((LA7_38 >= ' ' && LA7_38 <= '!') || LA7_38 == '$' || (LA7_38 >= '*' && LA7_38 <= '-') || (LA7_38 >= '<' && LA7_38 <= '>') || LA7_38 == '[' || LA7_38 == '^') ) { s = 40; }

                   	else s = 18;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 1 : 
                   	int LA7_35 = input.LA(1);

                   	s = -1;
                   	if ( (LA7_35 == '\'') ) { s = 36; }

                   	else if ( ((LA7_35 >= '\u0000' && LA7_35 <= '\t') || (LA7_35 >= '\u000B' && LA7_35 <= '\f') || (LA7_35 >= '\u000E' && LA7_35 <= '\u001F') || (LA7_35 >= '\"' && LA7_35 <= '#') || (LA7_35 >= '%' && LA7_35 <= '&') || (LA7_35 >= '(' && LA7_35 <= ')') || (LA7_35 >= '.' && LA7_35 <= ';') || (LA7_35 >= '?' && LA7_35 <= 'Z') || (LA7_35 >= '\\' && LA7_35 <= ']') || (LA7_35 >= '_' && LA7_35 <= '\uFFFF')) ) { s = 35; }

                   	else if ( ((LA7_35 >= ' ' && LA7_35 <= '!') || LA7_35 == '$' || (LA7_35 >= '*' && LA7_35 <= '-') || (LA7_35 >= '<' && LA7_35 <= '>') || LA7_35 == '[' || LA7_35 == '^') ) { s = 37; }

                   	else s = 18;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 2 : 
                   	int LA7_42 = input.LA(1);

                   	s = -1;
                   	if ( ((LA7_42 >= '\u0000' && LA7_42 <= '\t') || (LA7_42 >= '\u000B' && LA7_42 <= '\f') || (LA7_42 >= '\u000E' && LA7_42 <= '\u001F') || (LA7_42 >= '\"' && LA7_42 <= '#') || (LA7_42 >= '%' && LA7_42 <= ')') || (LA7_42 >= '.' && LA7_42 <= ';') || (LA7_42 >= '?' && LA7_42 <= 'Z') || (LA7_42 >= '\\' && LA7_42 <= ']') || (LA7_42 >= '_' && LA7_42 <= '\uFFFF')) ) { s = 18; }

                   	else s = 47;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 3 : 
                   	int LA7_44 = input.LA(1);

                   	s = -1;
                   	if ( (LA7_44 == '\'') ) { s = 36; }

                   	else if ( ((LA7_44 >= '\u0000' && LA7_44 <= '\t') || (LA7_44 >= '\u000B' && LA7_44 <= '\f') || (LA7_44 >= '\u000E' && LA7_44 <= '\u001F') || (LA7_44 >= '\"' && LA7_44 <= '#') || (LA7_44 >= '%' && LA7_44 <= '&') || (LA7_44 >= '(' && LA7_44 <= ')') || (LA7_44 >= '.' && LA7_44 <= ';') || (LA7_44 >= '?' && LA7_44 <= 'Z') || (LA7_44 >= '\\' && LA7_44 <= ']') || (LA7_44 >= '_' && LA7_44 <= '\uFFFF')) ) { s = 35; }

                   	else if ( ((LA7_44 >= ' ' && LA7_44 <= '!') || LA7_44 == '$' || (LA7_44 >= '*' && LA7_44 <= '-') || (LA7_44 >= '<' && LA7_44 <= '>') || LA7_44 == '[' || LA7_44 == '^') ) { s = 37; }

                   	else s = 18;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 4 : 
                   	int LA7_16 = input.LA(1);

                   	s = -1;
                   	if ( ((LA7_16 >= '\u0000' && LA7_16 <= '\t') || (LA7_16 >= '\u000B' && LA7_16 <= '\f') || (LA7_16 >= '\u000E' && LA7_16 <= '\u001F') || LA7_16 == '#' || (LA7_16 >= '%' && LA7_16 <= ')') || (LA7_16 >= '.' && LA7_16 <= ';') || (LA7_16 >= '?' && LA7_16 <= 'Z') || (LA7_16 >= '\\' && LA7_16 <= ']') || (LA7_16 >= '_' && LA7_16 <= '\uFFFF')) ) { s = 38; }

                   	else if ( (LA7_16 == '\"') ) { s = 39; }

                   	else if ( ((LA7_16 >= ' ' && LA7_16 <= '!') || LA7_16 == '$' || (LA7_16 >= '*' && LA7_16 <= '-') || (LA7_16 >= '<' && LA7_16 <= '>') || LA7_16 == '[' || LA7_16 == '^') ) { s = 40; }

                   	else s = 18;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 5 : 
                   	int LA7_36 = input.LA(1);

                   	s = -1;
                   	if ( (LA7_36 == '\'') ) { s = 44; }

                   	else if ( ((LA7_36 >= '\u0000' && LA7_36 <= '\t') || (LA7_36 >= '\u000B' && LA7_36 <= '\f') || (LA7_36 >= '\u000E' && LA7_36 <= '\u001F') || (LA7_36 >= '\"' && LA7_36 <= '#') || (LA7_36 >= '%' && LA7_36 <= '&') || (LA7_36 >= '(' && LA7_36 <= ')') || (LA7_36 >= '.' && LA7_36 <= ';') || (LA7_36 >= '?' && LA7_36 <= 'Z') || (LA7_36 >= '\\' && LA7_36 <= ']') || (LA7_36 >= '_' && LA7_36 <= '\uFFFF')) ) { s = 18; }

                   	else s = 37;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 6 : 
                   	int LA7_11 = input.LA(1);

                   	s = -1;
                   	if ( ((LA7_11 >= '\u0000' && LA7_11 <= '\t') || (LA7_11 >= '\u000B' && LA7_11 <= '\f') || (LA7_11 >= '\u000E' && LA7_11 <= '\u001F') || (LA7_11 >= '\"' && LA7_11 <= '#') || (LA7_11 >= '%' && LA7_11 <= ')') || (LA7_11 >= '.' && LA7_11 <= ';') || (LA7_11 >= '?' && LA7_11 <= 'Z') || (LA7_11 >= '\\' && LA7_11 <= ']') || (LA7_11 >= '_' && LA7_11 <= '\uFFFF')) ) { s = 18; }

                   	else s = 31;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 7 : 
                   	int LA7_15 = input.LA(1);

                   	s = -1;
                   	if ( ((LA7_15 >= '\u0000' && LA7_15 <= '\t') || (LA7_15 >= '\u000B' && LA7_15 <= '\f') || (LA7_15 >= '\u000E' && LA7_15 <= '\u001F') || (LA7_15 >= '\"' && LA7_15 <= '#') || (LA7_15 >= '%' && LA7_15 <= '&') || (LA7_15 >= '(' && LA7_15 <= ')') || (LA7_15 >= '.' && LA7_15 <= ';') || (LA7_15 >= '?' && LA7_15 <= 'Z') || (LA7_15 >= '\\' && LA7_15 <= ']') || (LA7_15 >= '_' && LA7_15 <= '\uFFFF')) ) { s = 35; }

                   	else if ( (LA7_15 == '\'') ) { s = 36; }

                   	else if ( ((LA7_15 >= ' ' && LA7_15 <= '!') || LA7_15 == '$' || (LA7_15 >= '*' && LA7_15 <= '-') || (LA7_15 >= '<' && LA7_15 <= '>') || LA7_15 == '[' || LA7_15 == '^') ) { s = 37; }

                   	else s = 18;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 8 : 
                   	int LA7_46 = input.LA(1);

                   	s = -1;
                   	if ( ((LA7_46 >= '\u0000' && LA7_46 <= '\t') || (LA7_46 >= '\u000B' && LA7_46 <= '\f') || (LA7_46 >= '\u000E' && LA7_46 <= '\u001F') || (LA7_46 >= '\"' && LA7_46 <= '#') || (LA7_46 >= '%' && LA7_46 <= ')') || (LA7_46 >= '.' && LA7_46 <= ';') || (LA7_46 >= '?' && LA7_46 <= 'Z') || (LA7_46 >= '\\' && LA7_46 <= ']') || (LA7_46 >= '_' && LA7_46 <= '\uFFFF')) ) { s = 18; }

                   	else s = 49;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 9 : 
                   	int LA7_45 = input.LA(1);

                   	s = -1;
                   	if ( (LA7_45 == '\"') ) { s = 39; }

                   	else if ( ((LA7_45 >= '\u0000' && LA7_45 <= '\t') || (LA7_45 >= '\u000B' && LA7_45 <= '\f') || (LA7_45 >= '\u000E' && LA7_45 <= '\u001F') || LA7_45 == '#' || (LA7_45 >= '%' && LA7_45 <= ')') || (LA7_45 >= '.' && LA7_45 <= ';') || (LA7_45 >= '?' && LA7_45 <= 'Z') || (LA7_45 >= '\\' && LA7_45 <= ']') || (LA7_45 >= '_' && LA7_45 <= '\uFFFF')) ) { s = 38; }

                   	else if ( ((LA7_45 >= ' ' && LA7_45 <= '!') || LA7_45 == '$' || (LA7_45 >= '*' && LA7_45 <= '-') || (LA7_45 >= '<' && LA7_45 <= '>') || LA7_45 == '[' || LA7_45 == '^') ) { s = 40; }

                   	else s = 18;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 10 : 
                   	int LA7_50 = input.LA(1);

                   	s = -1;
                   	if ( ((LA7_50 >= '\u0000' && LA7_50 <= '\t') || (LA7_50 >= '\u000B' && LA7_50 <= '\f') || (LA7_50 >= '\u000E' && LA7_50 <= '\u001F') || (LA7_50 >= '\"' && LA7_50 <= '#') || (LA7_50 >= '%' && LA7_50 <= ')') || (LA7_50 >= '.' && LA7_50 <= ';') || (LA7_50 >= '?' && LA7_50 <= 'Z') || (LA7_50 >= '\\' && LA7_50 <= ']') || (LA7_50 >= '_' && LA7_50 <= '\uFFFF')) ) { s = 18; }

                   	else s = 51;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 11 : 
                   	int LA7_39 = input.LA(1);

                   	s = -1;
                   	if ( (LA7_39 == '\"') ) { s = 45; }

                   	else if ( ((LA7_39 >= '\u0000' && LA7_39 <= '\t') || (LA7_39 >= '\u000B' && LA7_39 <= '\f') || (LA7_39 >= '\u000E' && LA7_39 <= '\u001F') || LA7_39 == '#' || (LA7_39 >= '%' && LA7_39 <= ')') || (LA7_39 >= '.' && LA7_39 <= ';') || (LA7_39 >= '?' && LA7_39 <= 'Z') || (LA7_39 >= '\\' && LA7_39 <= ']') || (LA7_39 >= '_' && LA7_39 <= '\uFFFF')) ) { s = 18; }

                   	else s = 40;

                   	if ( s >= 0 ) return s;
                   	break;
        }
        NoViableAltException nvae7 =
            new NoViableAltException(dfa.Description, 7, _s, input);
        dfa.Error(nvae7);
        throw nvae7;
    }
 
    
}
