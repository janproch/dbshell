// $ANTLR 3.2 Sep 23, 2009 12:02:23 StringFilter.g 2016-09-05 21:10:00

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
    public const int DOLLAR = 20;
    public const int LT = 12;
    public const int STAR = 29;
    public const int EOF = -1;
    public const int Q_STRING = 4;
    public const int TILDA = 11;
    public const int COMMA = 27;
    public const int T_NULL = 22;
    public const int PLUS = 10;
    public const int DIGIT = 40;
    public const int EQ = 17;
    public const int DOT = 8;
    public const int NE = 16;
    public const int D = 44;
    public const int E = 35;
    public const int F = 45;
    public const int GE = 15;
    public const int G = 46;
    public const int SQL_VARIABLE = 9;
    public const int I_STRING = 6;
    public const int A = 41;
    public const int B = 42;
    public const int C = 43;
    public const int NE2 = 26;
    public const int L = 32;
    public const int M = 36;
    public const int N = 30;
    public const int O = 33;
    public const int H = 47;
    public const int I = 48;
    public const int J = 49;
    public const int K = 50;
    public const int U = 31;
    public const int T = 34;
    public const int W = 55;
    public const int WHITESPACE = 39;
    public const int V = 54;
    public const int Q = 51;
    public const int P = 37;
    public const int S = 53;
    public const int R = 52;
    public const int Y = 38;
    public const int EQ2 = 25;
    public const int SQL_LITERAL = 7;
    public const int X = 56;
    public const int Z = 57;
    public const int NDOLLAR = 21;
    public const int T_EMPTY = 24;
    public const int A_STRING = 5;
    public const int GT = 13;
    public const int ARROW = 18;
    public const int ENDLINE = 28;
    public const int T_NOT = 23;
    public const int NARROW = 19;
    public const int LE = 14;

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

    // $ANTLR start "TILDA"
    public void mTILDA() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = TILDA;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // StringFilter.g:63:6: ( '~' )
            // StringFilter.g:63:9: '~'
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

    // $ANTLR start "LT"
    public void mLT() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = LT;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // StringFilter.g:64:3: ( '<' )
            // StringFilter.g:64:6: '<'
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
            // StringFilter.g:65:3: ( '>' )
            // StringFilter.g:65:6: '>'
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
            // StringFilter.g:66:3: ( '>=' )
            // StringFilter.g:66:6: '>='
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
            // StringFilter.g:67:3: ( '<=' )
            // StringFilter.g:67:6: '<='
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
            // StringFilter.g:68:3: ( '<>' )
            // StringFilter.g:68:6: '<>'
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
            // StringFilter.g:69:3: ( '=' )
            // StringFilter.g:69:6: '='
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
            // StringFilter.g:70:5: ( '+' )
            // StringFilter.g:70:7: '+'
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
            // StringFilter.g:71:5: ( '*' )
            // StringFilter.g:71:8: '*'
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
            // StringFilter.g:72:6: ( ',' )
            // StringFilter.g:72:8: ','
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
            // StringFilter.g:73:6: ( '^' )
            // StringFilter.g:73:9: '^'
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
            // StringFilter.g:74:7: ( '$' )
            // StringFilter.g:74:10: '$'
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
            // StringFilter.g:75:7: ( '!^' )
            // StringFilter.g:75:10: '!^'
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
            // StringFilter.g:76:8: ( '!$' )
            // StringFilter.g:76:11: '!$'
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
            // StringFilter.g:77:4: ( '.' )
            // StringFilter.g:77:6: '.'
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
            // StringFilter.g:78:4: ( '==' )
            // StringFilter.g:78:7: '=='
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
            // StringFilter.g:79:4: ( '!=' )
            // StringFilter.g:79:7: '!='
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
            // StringFilter.g:81:7: ( N U L L )
            // StringFilter.g:81:9: N U L L
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
            // StringFilter.g:82:6: ( N O T )
            // StringFilter.g:82:8: N O T
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
            // StringFilter.g:83:8: ( E M P T Y )
            // StringFilter.g:83:10: E M P T Y
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
            // StringFilter.g:85:12: ( ( '[' ( options {greedy=true; } : ~ ( ']' | '\\r' | '\\n' ) )* ']' ) )
            // StringFilter.g:86:4: ( '[' ( options {greedy=true; } : ~ ( ']' | '\\r' | '\\n' ) )* ']' )
            {
            	// StringFilter.g:86:4: ( '[' ( options {greedy=true; } : ~ ( ']' | '\\r' | '\\n' ) )* ']' )
            	// StringFilter.g:86:5: '[' ( options {greedy=true; } : ~ ( ']' | '\\r' | '\\n' ) )* ']'
            	{
            		Match('['); 
            		// StringFilter.g:87:5: ( options {greedy=true; } : ~ ( ']' | '\\r' | '\\n' ) )*
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
            				    // StringFilter.g:88:31: ~ ( ']' | '\\r' | '\\n' )
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

    // $ANTLR start "SQL_VARIABLE"
    public void mSQL_VARIABLE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = SQL_VARIABLE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // StringFilter.g:93:13: ( ( '@' ( 'a' .. 'z' | 'A' .. 'Z' | '_' ) ( options {greedy=true; } : ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '_' ) )* ) )
            // StringFilter.g:94:5: ( '@' ( 'a' .. 'z' | 'A' .. 'Z' | '_' ) ( options {greedy=true; } : ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '_' ) )* )
            {
            	// StringFilter.g:94:5: ( '@' ( 'a' .. 'z' | 'A' .. 'Z' | '_' ) ( options {greedy=true; } : ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '_' ) )* )
            	// StringFilter.g:94:6: '@' ( 'a' .. 'z' | 'A' .. 'Z' | '_' ) ( options {greedy=true; } : ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '_' ) )*
            	{
            		Match('@'); 
            		if ( (input.LA(1) >= 'A' && input.LA(1) <= 'Z') || input.LA(1) == '_' || (input.LA(1) >= 'a' && input.LA(1) <= 'z') ) 
            		{
            		    input.Consume();

            		}
            		else 
            		{
            		    MismatchedSetException mse = new MismatchedSetException(null,input);
            		    Recover(mse);
            		    throw mse;}

            		// StringFilter.g:96:9: ( options {greedy=true; } : ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '_' ) )*
            		do 
            		{
            		    int alt2 = 2;
            		    int LA2_0 = input.LA(1);

            		    if ( ((LA2_0 >= '0' && LA2_0 <= '9') || (LA2_0 >= 'A' && LA2_0 <= 'Z') || LA2_0 == '_' || (LA2_0 >= 'a' && LA2_0 <= 'z')) )
            		    {
            		        alt2 = 1;
            		    }


            		    switch (alt2) 
            			{
            				case 1 :
            				    // StringFilter.g:96:34: ( 'a' .. 'z' | 'A' .. 'Z' | '0' .. '9' | '_' )
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
            				    goto loop2;
            		    }
            		} while (true);

            		loop2:
            			;	// Stops C# compiler whining that label 'loop2' has no statements


            	}


            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "SQL_VARIABLE"

    // $ANTLR start "A_STRING"
    public void mA_STRING() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = A_STRING;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // StringFilter.g:100:9: ( ( '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\'' ) )
            // StringFilter.g:101:4: ( '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\'' )
            {
            	// StringFilter.g:101:4: ( '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\'' )
            	// StringFilter.g:101:5: '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\''
            	{
            		Match('\''); 
            		// StringFilter.g:102:5: ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )*
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
            				    // StringFilter.g:103:31: ~ ( '\\'' | '\\r' | '\\n' )
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
            				    // StringFilter.g:103:56: '\\'' '\\''
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
    // $ANTLR end "A_STRING"

    // $ANTLR start "Q_STRING"
    public void mQ_STRING() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = Q_STRING;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // StringFilter.g:108:9: ( ( '\\\"' ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )* '\\\"' ) )
            // StringFilter.g:109:4: ( '\\\"' ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )* '\\\"' )
            {
            	// StringFilter.g:109:4: ( '\\\"' ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )* '\\\"' )
            	// StringFilter.g:109:5: '\\\"' ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )* '\\\"'
            	{
            		Match('\"'); 
            		// StringFilter.g:110:5: ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )*
            		do 
            		{
            		    int alt4 = 3;
            		    int LA4_0 = input.LA(1);

            		    if ( (LA4_0 == '\"') )
            		    {
            		        int LA4_1 = input.LA(2);

            		        if ( (LA4_1 == '\"') )
            		        {
            		            alt4 = 2;
            		        }


            		    }
            		    else if ( ((LA4_0 >= '\u0000' && LA4_0 <= '\t') || (LA4_0 >= '\u000B' && LA4_0 <= '\f') || (LA4_0 >= '\u000E' && LA4_0 <= '!') || (LA4_0 >= '#' && LA4_0 <= '\uFFFF')) )
            		    {
            		        alt4 = 1;
            		    }


            		    switch (alt4) 
            			{
            				case 1 :
            				    // StringFilter.g:111:31: ~ ( '\\\"' | '\\r' | '\\n' )
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
            				    // StringFilter.g:111:56: '\\\"' '\\\"'
            				    {
            				    	Match('\"'); 
            				    	Match('\"'); 

            				    }
            				    break;

            				default:
            				    goto loop4;
            		    }
            		} while (true);

            		loop4:
            			;	// Stops C# compiler whining that label 'loop4' has no statements

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
            // StringFilter.g:116:9: ( (~ ( '[' | '~' | ' ' | '<' | '>' | '=' | '!' | '\\r' | '\\n' | '^' | '$' | '*' | ',' | '+' ) )* )
            // StringFilter.g:116:11: (~ ( '[' | '~' | ' ' | '<' | '>' | '=' | '!' | '\\r' | '\\n' | '^' | '$' | '*' | ',' | '+' ) )*
            {
            	// StringFilter.g:116:11: (~ ( '[' | '~' | ' ' | '<' | '>' | '=' | '!' | '\\r' | '\\n' | '^' | '$' | '*' | ',' | '+' ) )*
            	do 
            	{
            	    int alt5 = 2;
            	    int LA5_0 = input.LA(1);

            	    if ( ((LA5_0 >= '\u0000' && LA5_0 <= '\t') || (LA5_0 >= '\u000B' && LA5_0 <= '\f') || (LA5_0 >= '\u000E' && LA5_0 <= '\u001F') || (LA5_0 >= '\"' && LA5_0 <= '#') || (LA5_0 >= '%' && LA5_0 <= ')') || (LA5_0 >= '-' && LA5_0 <= ';') || (LA5_0 >= '?' && LA5_0 <= 'Z') || (LA5_0 >= '\\' && LA5_0 <= ']') || (LA5_0 >= '_' && LA5_0 <= '}') || (LA5_0 >= '\u007F' && LA5_0 <= '\uFFFF')) )
            	    {
            	        alt5 = 1;
            	    }


            	    switch (alt5) 
            		{
            			case 1 :
            			    // StringFilter.g:116:12: ~ ( '[' | '~' | ' ' | '<' | '>' | '=' | '!' | '\\r' | '\\n' | '^' | '$' | '*' | ',' | '+' )
            			    {
            			    	if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '\t') || (input.LA(1) >= '\u000B' && input.LA(1) <= '\f') || (input.LA(1) >= '\u000E' && input.LA(1) <= '\u001F') || (input.LA(1) >= '\"' && input.LA(1) <= '#') || (input.LA(1) >= '%' && input.LA(1) <= ')') || (input.LA(1) >= '-' && input.LA(1) <= ';') || (input.LA(1) >= '?' && input.LA(1) <= 'Z') || (input.LA(1) >= '\\' && input.LA(1) <= ']') || (input.LA(1) >= '_' && input.LA(1) <= '}') || (input.LA(1) >= '\u007F' && input.LA(1) <= '\uFFFF') ) 
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
            			    goto loop5;
            	    }
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
    // $ANTLR end "I_STRING"

    // $ANTLR start "WHITESPACE"
    public void mWHITESPACE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = WHITESPACE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // StringFilter.g:118:12: ( ( '\\t' | ' ' | '\\u000C' )+ )
            // StringFilter.g:118:14: ( '\\t' | ' ' | '\\u000C' )+
            {
            	// StringFilter.g:118:14: ( '\\t' | ' ' | '\\u000C' )+
            	int cnt6 = 0;
            	do 
            	{
            	    int alt6 = 2;
            	    int LA6_0 = input.LA(1);

            	    if ( (LA6_0 == '\t' || LA6_0 == '\f' || LA6_0 == ' ') )
            	    {
            	        alt6 = 1;
            	    }


            	    switch (alt6) 
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
            			    if ( cnt6 >= 1 ) goto loop6;
            		            EarlyExitException eee6 =
            		                new EarlyExitException(6, input);
            		            throw eee6;
            	    }
            	    cnt6++;
            	} while (true);

            	loop6:
            		;	// Stops C# compiler whining that label 'loop6' has no statements

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
            // StringFilter.g:119:8: ( ( '\\r' | '\\n' )+ )
            // StringFilter.g:119:10: ( '\\r' | '\\n' )+
            {
            	// StringFilter.g:119:10: ( '\\r' | '\\n' )+
            	int cnt7 = 0;
            	do 
            	{
            	    int alt7 = 2;
            	    int LA7_0 = input.LA(1);

            	    if ( (LA7_0 == '\n' || LA7_0 == '\r') )
            	    {
            	        alt7 = 1;
            	    }


            	    switch (alt7) 
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
            // StringFilter.g:121:17: ( '0' .. '9' )
            // StringFilter.g:121:19: '0' .. '9'
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
            // StringFilter.g:123:11: ( 'A' )
            // StringFilter.g:123:13: 'A'
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
            // StringFilter.g:124:11: ( 'B' )
            // StringFilter.g:124:13: 'B'
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
            // StringFilter.g:125:11: ( 'C' )
            // StringFilter.g:125:13: 'C'
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
            // StringFilter.g:126:11: ( 'D' )
            // StringFilter.g:126:13: 'D'
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
            // StringFilter.g:127:11: ( 'E' )
            // StringFilter.g:127:13: 'E'
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
            // StringFilter.g:128:11: ( 'F' )
            // StringFilter.g:128:13: 'F'
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
            // StringFilter.g:129:11: ( 'G' )
            // StringFilter.g:129:13: 'G'
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
            // StringFilter.g:130:11: ( 'H' )
            // StringFilter.g:130:13: 'H'
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
            // StringFilter.g:131:11: ( 'I' )
            // StringFilter.g:131:13: 'I'
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
            // StringFilter.g:132:11: ( 'J' )
            // StringFilter.g:132:13: 'J'
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
            // StringFilter.g:133:11: ( 'K' )
            // StringFilter.g:133:13: 'K'
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
            // StringFilter.g:134:11: ( 'L' )
            // StringFilter.g:134:13: 'L'
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
            // StringFilter.g:135:11: ( 'M' )
            // StringFilter.g:135:13: 'M'
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
            // StringFilter.g:136:11: ( 'N' )
            // StringFilter.g:136:13: 'N'
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
            // StringFilter.g:137:11: ( 'O' )
            // StringFilter.g:137:13: 'O'
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
            // StringFilter.g:138:11: ( 'P' )
            // StringFilter.g:138:13: 'P'
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
            // StringFilter.g:139:11: ( 'Q' )
            // StringFilter.g:139:13: 'Q'
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
            // StringFilter.g:140:11: ( 'R' )
            // StringFilter.g:140:13: 'R'
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
            // StringFilter.g:141:11: ( 'S' )
            // StringFilter.g:141:13: 'S'
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
            // StringFilter.g:142:11: ( 'T' )
            // StringFilter.g:142:13: 'T'
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
            // StringFilter.g:143:11: ( 'U' )
            // StringFilter.g:143:13: 'U'
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
            // StringFilter.g:144:11: ( 'V' )
            // StringFilter.g:144:13: 'V'
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
            // StringFilter.g:145:11: ( 'W' )
            // StringFilter.g:145:13: 'W'
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
            // StringFilter.g:146:11: ( 'X' )
            // StringFilter.g:146:13: 'X'
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
            // StringFilter.g:147:11: ( 'Y' )
            // StringFilter.g:147:13: 'Y'
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
            // StringFilter.g:148:11: ( 'Z' )
            // StringFilter.g:148:13: 'Z'
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
        // StringFilter.g:1:8: ( TILDA | LT | GT | GE | LE | NE | EQ | PLUS | STAR | COMMA | ARROW | DOLLAR | NARROW | NDOLLAR | DOT | EQ2 | NE2 | T_NULL | T_NOT | T_EMPTY | SQL_LITERAL | SQL_VARIABLE | A_STRING | Q_STRING | I_STRING | WHITESPACE | ENDLINE )
        int alt8 = 27;
        alt8 = dfa8.Predict(input);
        switch (alt8) 
        {
            case 1 :
                // StringFilter.g:1:10: TILDA
                {
                	mTILDA(); 

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
                // StringFilter.g:1:123: SQL_VARIABLE
                {
                	mSQL_VARIABLE(); 

                }
                break;
            case 23 :
                // StringFilter.g:1:136: A_STRING
                {
                	mA_STRING(); 

                }
                break;
            case 24 :
                // StringFilter.g:1:145: Q_STRING
                {
                	mQ_STRING(); 

                }
                break;
            case 25 :
                // StringFilter.g:1:154: I_STRING
                {
                	mI_STRING(); 

                }
                break;
            case 26 :
                // StringFilter.g:1:163: WHITESPACE
                {
                	mWHITESPACE(); 

                }
                break;
            case 27 :
                // StringFilter.g:1:174: ENDLINE
                {
                	mENDLINE(); 

                }
                break;

        }

    }


    protected DFA8 dfa8;
	private void InitializeCyclicDFAs()
	{
	    this.dfa8 = new DFA8(this);
	    this.dfa8.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA8_SpecialStateTransition);
	}

    const string DFA8_eotS =
        "\x01\x13\x01\uffff\x01\x18\x01\x1a\x01\x1c\x06\uffff\x01\x20\x02"+
        "\x13\x01\uffff\x04\x13\x0e\uffff\x03\x13\x01\x2e\x01\x13\x01\x27"+
        "\x01\uffff\x01\x13\x01\x2a\x01\uffff\x01\x32\x02\x13\x01\uffff\x01"+
        "\x2e\x02\x13\x01\uffff\x01\x35\x01\x13\x01\uffff\x01\x37\x01\uffff";
    const string DFA8_eofS =
        "\x38\uffff";
    const string DFA8_minS =
        "\x01\x09\x01\uffff\x03\x3d\x05\uffff\x01\x24\x01\x00\x01\x4f\x01"+
        "\x4d\x01\uffff\x01\x41\x02\x00\x01\x09\x0e\uffff\x01\x54\x01\x4c"+
        "\x01\x50\x03\x00\x01\uffff\x02\x00\x01\uffff\x01\x00\x01\x4c\x01"+
        "\x54\x01\uffff\x03\x00\x01\uffff\x01\x00\x01\x59\x01\uffff\x01\x00"+
        "\x01\uffff";
    const string DFA8_maxS =
        "\x01\x7e\x01\uffff\x01\x3e\x02\x3d\x05\uffff\x01\x5e\x01\uffff"+
        "\x01\x55\x01\x4d\x01\uffff\x01\x7a\x02\uffff\x01\x20\x0e\uffff\x01"+
        "\x54\x01\x4c\x01\x50\x03\uffff\x01\uffff\x02\uffff\x01\uffff\x01"+
        "\uffff\x01\x4c\x01\x54\x01\uffff\x03\uffff\x01\uffff\x01\uffff\x01"+
        "\x59\x01\uffff\x01\uffff\x01\uffff";
    const string DFA8_acceptS =
        "\x01\uffff\x01\x01\x03\uffff\x01\x08\x01\x09\x01\x0a\x01\x0b\x01"+
        "\x0c\x04\uffff\x01\x15\x04\uffff\x01\x19\x01\x1a\x01\x1b\x01\x05"+
        "\x01\x06\x01\x02\x01\x04\x01\x03\x01\x10\x01\x07\x01\x0d\x01\x0e"+
        "\x01\x11\x01\x0f\x06\uffff\x01\x17\x02\uffff\x01\x18\x03\uffff\x01"+
        "\x16\x03\uffff\x01\x13\x02\uffff\x01\x12\x01\uffff\x01\x14";
    const string DFA8_specialS =
        "\x0b\uffff\x01\x05\x04\uffff\x01\x03\x01\x0c\x12\uffff\x01\x01"+
        "\x01\x07\x01\x02\x01\uffff\x01\x0d\x01\x08\x01\uffff\x01\x0a\x03"+
        "\uffff\x01\x00\x01\x09\x01\x0b\x01\uffff\x01\x04\x02\uffff\x01\x06"+
        "\x01\uffff}>";
    static readonly string[] DFA8_transitionS = {
            "\x01\x12\x01\x15\x01\uffff\x01\x12\x01\x15\x12\uffff\x01\x14"+
            "\x01\x0a\x01\x11\x01\uffff\x01\x09\x02\uffff\x01\x10\x02\uffff"+
            "\x01\x06\x01\x05\x01\x07\x01\uffff\x01\x0b\x0d\uffff\x01\x02"+
            "\x01\x04\x01\x03\x01\uffff\x01\x0f\x04\uffff\x01\x0d\x08\uffff"+
            "\x01\x0c\x0c\uffff\x01\x0e\x02\uffff\x01\x08\x1f\uffff\x01\x01",
            "",
            "\x01\x16\x01\x17",
            "\x01\x19",
            "\x01\x1b",
            "",
            "",
            "",
            "",
            "",
            "\x01\x1e\x18\uffff\x01\x1f\x20\uffff\x01\x1d",
            "\x0a\x13\x01\uffff\x02\x13\x01\uffff\x12\x13\x02\uffff\x02"+
            "\x13\x01\uffff\x05\x13\x03\uffff\x0f\x13\x03\uffff\x1c\x13\x01"+
            "\uffff\x02\x13\x01\uffff\x1f\x13\x01\uffff\uff81\x13",
            "\x01\x21\x05\uffff\x01\x22",
            "\x01\x23",
            "",
            "\x1a\x24\x04\uffff\x01\x24\x01\uffff\x1a\x24",
            "\x0a\x25\x01\uffff\x02\x25\x01\uffff\x12\x25\x02\x27\x02\x25"+
            "\x01\x27\x02\x25\x01\x26\x02\x25\x03\x27\x0f\x25\x03\x27\x1c"+
            "\x25\x01\x27\x02\x25\x01\x27\x1f\x25\x01\x27\uff81\x25",
            "\x0a\x28\x01\uffff\x02\x28\x01\uffff\x12\x28\x02\x2a\x01\x29"+
            "\x01\x28\x01\x2a\x05\x28\x03\x2a\x0f\x28\x03\x2a\x1c\x28\x01"+
            "\x2a\x02\x28\x01\x2a\x1f\x28\x01\x2a\uff81\x28",
            "\x01\x12\x02\uffff\x01\x12\x13\uffff\x01\x14",
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
            "\x01\x2b",
            "\x01\x2c",
            "\x01\x2d",
            "\x0a\x13\x01\uffff\x02\x13\x01\uffff\x12\x13\x02\uffff\x02"+
            "\x13\x01\uffff\x05\x13\x03\uffff\x03\x13\x0a\x2f\x02\x13\x03"+
            "\uffff\x02\x13\x1a\x2f\x01\uffff\x02\x13\x01\uffff\x01\x2f\x01"+
            "\x13\x1a\x2f\x03\x13\x01\uffff\uff81\x13",
            "\x0a\x25\x01\uffff\x02\x25\x01\uffff\x12\x25\x02\x27\x02\x25"+
            "\x01\x27\x02\x25\x01\x26\x02\x25\x03\x27\x0f\x25\x03\x27\x1c"+
            "\x25\x01\x27\x02\x25\x01\x27\x1f\x25\x01\x27\uff81\x25",
            "\x0a\x13\x01\uffff\x02\x13\x01\uffff\x12\x13\x02\uffff\x02"+
            "\x13\x01\uffff\x02\x13\x01\x30\x02\x13\x03\uffff\x0f\x13\x03"+
            "\uffff\x1c\x13\x01\uffff\x02\x13\x01\uffff\x1f\x13\x01\uffff"+
            "\uff81\x13",
            "",
            "\x0a\x28\x01\uffff\x02\x28\x01\uffff\x12\x28\x02\x2a\x01\x29"+
            "\x01\x28\x01\x2a\x05\x28\x03\x2a\x0f\x28\x03\x2a\x1c\x28\x01"+
            "\x2a\x02\x28\x01\x2a\x1f\x28\x01\x2a\uff81\x28",
            "\x0a\x13\x01\uffff\x02\x13\x01\uffff\x12\x13\x02\uffff\x01"+
            "\x31\x01\x13\x01\uffff\x05\x13\x03\uffff\x0f\x13\x03\uffff\x1c"+
            "\x13\x01\uffff\x02\x13\x01\uffff\x1f\x13\x01\uffff\uff81\x13",
            "",
            "\x0a\x13\x01\uffff\x02\x13\x01\uffff\x12\x13\x02\uffff\x02"+
            "\x13\x01\uffff\x05\x13\x03\uffff\x0f\x13\x03\uffff\x1c\x13\x01"+
            "\uffff\x02\x13\x01\uffff\x1f\x13\x01\uffff\uff81\x13",
            "\x01\x33",
            "\x01\x34",
            "",
            "\x0a\x13\x01\uffff\x02\x13\x01\uffff\x12\x13\x02\uffff\x02"+
            "\x13\x01\uffff\x05\x13\x03\uffff\x03\x13\x0a\x2f\x02\x13\x03"+
            "\uffff\x02\x13\x1a\x2f\x01\uffff\x02\x13\x01\uffff\x01\x2f\x01"+
            "\x13\x1a\x2f\x03\x13\x01\uffff\uff81\x13",
            "\x0a\x25\x01\uffff\x02\x25\x01\uffff\x12\x25\x02\x27\x02\x25"+
            "\x01\x27\x02\x25\x01\x26\x02\x25\x03\x27\x0f\x25\x03\x27\x1c"+
            "\x25\x01\x27\x02\x25\x01\x27\x1f\x25\x01\x27\uff81\x25",
            "\x0a\x28\x01\uffff\x02\x28\x01\uffff\x12\x28\x02\x2a\x01\x29"+
            "\x01\x28\x01\x2a\x05\x28\x03\x2a\x0f\x28\x03\x2a\x1c\x28\x01"+
            "\x2a\x02\x28\x01\x2a\x1f\x28\x01\x2a\uff81\x28",
            "",
            "\x0a\x13\x01\uffff\x02\x13\x01\uffff\x12\x13\x02\uffff\x02"+
            "\x13\x01\uffff\x05\x13\x03\uffff\x0f\x13\x03\uffff\x1c\x13\x01"+
            "\uffff\x02\x13\x01\uffff\x1f\x13\x01\uffff\uff81\x13",
            "\x01\x36",
            "",
            "\x0a\x13\x01\uffff\x02\x13\x01\uffff\x12\x13\x02\uffff\x02"+
            "\x13\x01\uffff\x05\x13\x03\uffff\x0f\x13\x03\uffff\x1c\x13\x01"+
            "\uffff\x02\x13\x01\uffff\x1f\x13\x01\uffff\uff81\x13",
            ""
    };

    static readonly short[] DFA8_eot = DFA.UnpackEncodedString(DFA8_eotS);
    static readonly short[] DFA8_eof = DFA.UnpackEncodedString(DFA8_eofS);
    static readonly char[] DFA8_min = DFA.UnpackEncodedStringToUnsignedChars(DFA8_minS);
    static readonly char[] DFA8_max = DFA.UnpackEncodedStringToUnsignedChars(DFA8_maxS);
    static readonly short[] DFA8_accept = DFA.UnpackEncodedString(DFA8_acceptS);
    static readonly short[] DFA8_special = DFA.UnpackEncodedString(DFA8_specialS);
    static readonly short[][] DFA8_transition = DFA.UnpackEncodedStringArray(DFA8_transitionS);

    protected class DFA8 : DFA
    {
        public DFA8(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 8;
            this.eot = DFA8_eot;
            this.eof = DFA8_eof;
            this.min = DFA8_min;
            this.max = DFA8_max;
            this.accept = DFA8_accept;
            this.special = DFA8_special;
            this.transition = DFA8_transition;

        }

        override public string Description
        {
            get { return "1:1: Tokens : ( TILDA | LT | GT | GE | LE | NE | EQ | PLUS | STAR | COMMA | ARROW | DOLLAR | NARROW | NDOLLAR | DOT | EQ2 | NE2 | T_NULL | T_NOT | T_EMPTY | SQL_LITERAL | SQL_VARIABLE | A_STRING | Q_STRING | I_STRING | WHITESPACE | ENDLINE );"; }
        }

    }


    protected internal int DFA8_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            IIntStream input = _input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA8_47 = input.LA(1);

                   	s = -1;
                   	if ( ((LA8_47 >= '0' && LA8_47 <= '9') || (LA8_47 >= 'A' && LA8_47 <= 'Z') || LA8_47 == '_' || (LA8_47 >= 'a' && LA8_47 <= 'z')) ) { s = 47; }

                   	else if ( ((LA8_47 >= '\u0000' && LA8_47 <= '\t') || (LA8_47 >= '\u000B' && LA8_47 <= '\f') || (LA8_47 >= '\u000E' && LA8_47 <= '\u001F') || (LA8_47 >= '\"' && LA8_47 <= '#') || (LA8_47 >= '%' && LA8_47 <= ')') || (LA8_47 >= '-' && LA8_47 <= '/') || (LA8_47 >= ':' && LA8_47 <= ';') || (LA8_47 >= '?' && LA8_47 <= '@') || (LA8_47 >= '\\' && LA8_47 <= ']') || LA8_47 == '`' || (LA8_47 >= '{' && LA8_47 <= '}') || (LA8_47 >= '\u007F' && LA8_47 <= '\uFFFF')) ) { s = 19; }

                   	else s = 46;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 1 : 
                   	int LA8_36 = input.LA(1);

                   	s = -1;
                   	if ( ((LA8_36 >= '0' && LA8_36 <= '9') || (LA8_36 >= 'A' && LA8_36 <= 'Z') || LA8_36 == '_' || (LA8_36 >= 'a' && LA8_36 <= 'z')) ) { s = 47; }

                   	else if ( ((LA8_36 >= '\u0000' && LA8_36 <= '\t') || (LA8_36 >= '\u000B' && LA8_36 <= '\f') || (LA8_36 >= '\u000E' && LA8_36 <= '\u001F') || (LA8_36 >= '\"' && LA8_36 <= '#') || (LA8_36 >= '%' && LA8_36 <= ')') || (LA8_36 >= '-' && LA8_36 <= '/') || (LA8_36 >= ':' && LA8_36 <= ';') || (LA8_36 >= '?' && LA8_36 <= '@') || (LA8_36 >= '\\' && LA8_36 <= ']') || LA8_36 == '`' || (LA8_36 >= '{' && LA8_36 <= '}') || (LA8_36 >= '\u007F' && LA8_36 <= '\uFFFF')) ) { s = 19; }

                   	else s = 46;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 2 : 
                   	int LA8_38 = input.LA(1);

                   	s = -1;
                   	if ( (LA8_38 == '\'') ) { s = 48; }

                   	else if ( ((LA8_38 >= '\u0000' && LA8_38 <= '\t') || (LA8_38 >= '\u000B' && LA8_38 <= '\f') || (LA8_38 >= '\u000E' && LA8_38 <= '\u001F') || (LA8_38 >= '\"' && LA8_38 <= '#') || (LA8_38 >= '%' && LA8_38 <= '&') || (LA8_38 >= '(' && LA8_38 <= ')') || (LA8_38 >= '-' && LA8_38 <= ';') || (LA8_38 >= '?' && LA8_38 <= 'Z') || (LA8_38 >= '\\' && LA8_38 <= ']') || (LA8_38 >= '_' && LA8_38 <= '}') || (LA8_38 >= '\u007F' && LA8_38 <= '\uFFFF')) ) { s = 19; }

                   	else s = 39;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 3 : 
                   	int LA8_16 = input.LA(1);

                   	s = -1;
                   	if ( ((LA8_16 >= '\u0000' && LA8_16 <= '\t') || (LA8_16 >= '\u000B' && LA8_16 <= '\f') || (LA8_16 >= '\u000E' && LA8_16 <= '\u001F') || (LA8_16 >= '\"' && LA8_16 <= '#') || (LA8_16 >= '%' && LA8_16 <= '&') || (LA8_16 >= '(' && LA8_16 <= ')') || (LA8_16 >= '-' && LA8_16 <= ';') || (LA8_16 >= '?' && LA8_16 <= 'Z') || (LA8_16 >= '\\' && LA8_16 <= ']') || (LA8_16 >= '_' && LA8_16 <= '}') || (LA8_16 >= '\u007F' && LA8_16 <= '\uFFFF')) ) { s = 37; }

                   	else if ( (LA8_16 == '\'') ) { s = 38; }

                   	else if ( ((LA8_16 >= ' ' && LA8_16 <= '!') || LA8_16 == '$' || (LA8_16 >= '*' && LA8_16 <= ',') || (LA8_16 >= '<' && LA8_16 <= '>') || LA8_16 == '[' || LA8_16 == '^' || LA8_16 == '~') ) { s = 39; }

                   	else s = 19;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 4 : 
                   	int LA8_51 = input.LA(1);

                   	s = -1;
                   	if ( ((LA8_51 >= '\u0000' && LA8_51 <= '\t') || (LA8_51 >= '\u000B' && LA8_51 <= '\f') || (LA8_51 >= '\u000E' && LA8_51 <= '\u001F') || (LA8_51 >= '\"' && LA8_51 <= '#') || (LA8_51 >= '%' && LA8_51 <= ')') || (LA8_51 >= '-' && LA8_51 <= ';') || (LA8_51 >= '?' && LA8_51 <= 'Z') || (LA8_51 >= '\\' && LA8_51 <= ']') || (LA8_51 >= '_' && LA8_51 <= '}') || (LA8_51 >= '\u007F' && LA8_51 <= '\uFFFF')) ) { s = 19; }

                   	else s = 53;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 5 : 
                   	int LA8_11 = input.LA(1);

                   	s = -1;
                   	if ( ((LA8_11 >= '\u0000' && LA8_11 <= '\t') || (LA8_11 >= '\u000B' && LA8_11 <= '\f') || (LA8_11 >= '\u000E' && LA8_11 <= '\u001F') || (LA8_11 >= '\"' && LA8_11 <= '#') || (LA8_11 >= '%' && LA8_11 <= ')') || (LA8_11 >= '-' && LA8_11 <= ';') || (LA8_11 >= '?' && LA8_11 <= 'Z') || (LA8_11 >= '\\' && LA8_11 <= ']') || (LA8_11 >= '_' && LA8_11 <= '}') || (LA8_11 >= '\u007F' && LA8_11 <= '\uFFFF')) ) { s = 19; }

                   	else s = 32;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 6 : 
                   	int LA8_54 = input.LA(1);

                   	s = -1;
                   	if ( ((LA8_54 >= '\u0000' && LA8_54 <= '\t') || (LA8_54 >= '\u000B' && LA8_54 <= '\f') || (LA8_54 >= '\u000E' && LA8_54 <= '\u001F') || (LA8_54 >= '\"' && LA8_54 <= '#') || (LA8_54 >= '%' && LA8_54 <= ')') || (LA8_54 >= '-' && LA8_54 <= ';') || (LA8_54 >= '?' && LA8_54 <= 'Z') || (LA8_54 >= '\\' && LA8_54 <= ']') || (LA8_54 >= '_' && LA8_54 <= '}') || (LA8_54 >= '\u007F' && LA8_54 <= '\uFFFF')) ) { s = 19; }

                   	else s = 55;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 7 : 
                   	int LA8_37 = input.LA(1);

                   	s = -1;
                   	if ( (LA8_37 == '\'') ) { s = 38; }

                   	else if ( ((LA8_37 >= '\u0000' && LA8_37 <= '\t') || (LA8_37 >= '\u000B' && LA8_37 <= '\f') || (LA8_37 >= '\u000E' && LA8_37 <= '\u001F') || (LA8_37 >= '\"' && LA8_37 <= '#') || (LA8_37 >= '%' && LA8_37 <= '&') || (LA8_37 >= '(' && LA8_37 <= ')') || (LA8_37 >= '-' && LA8_37 <= ';') || (LA8_37 >= '?' && LA8_37 <= 'Z') || (LA8_37 >= '\\' && LA8_37 <= ']') || (LA8_37 >= '_' && LA8_37 <= '}') || (LA8_37 >= '\u007F' && LA8_37 <= '\uFFFF')) ) { s = 37; }

                   	else if ( ((LA8_37 >= ' ' && LA8_37 <= '!') || LA8_37 == '$' || (LA8_37 >= '*' && LA8_37 <= ',') || (LA8_37 >= '<' && LA8_37 <= '>') || LA8_37 == '[' || LA8_37 == '^' || LA8_37 == '~') ) { s = 39; }

                   	else s = 19;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 8 : 
                   	int LA8_41 = input.LA(1);

                   	s = -1;
                   	if ( (LA8_41 == '\"') ) { s = 49; }

                   	else if ( ((LA8_41 >= '\u0000' && LA8_41 <= '\t') || (LA8_41 >= '\u000B' && LA8_41 <= '\f') || (LA8_41 >= '\u000E' && LA8_41 <= '\u001F') || LA8_41 == '#' || (LA8_41 >= '%' && LA8_41 <= ')') || (LA8_41 >= '-' && LA8_41 <= ';') || (LA8_41 >= '?' && LA8_41 <= 'Z') || (LA8_41 >= '\\' && LA8_41 <= ']') || (LA8_41 >= '_' && LA8_41 <= '}') || (LA8_41 >= '\u007F' && LA8_41 <= '\uFFFF')) ) { s = 19; }

                   	else s = 42;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 9 : 
                   	int LA8_48 = input.LA(1);

                   	s = -1;
                   	if ( (LA8_48 == '\'') ) { s = 38; }

                   	else if ( ((LA8_48 >= '\u0000' && LA8_48 <= '\t') || (LA8_48 >= '\u000B' && LA8_48 <= '\f') || (LA8_48 >= '\u000E' && LA8_48 <= '\u001F') || (LA8_48 >= '\"' && LA8_48 <= '#') || (LA8_48 >= '%' && LA8_48 <= '&') || (LA8_48 >= '(' && LA8_48 <= ')') || (LA8_48 >= '-' && LA8_48 <= ';') || (LA8_48 >= '?' && LA8_48 <= 'Z') || (LA8_48 >= '\\' && LA8_48 <= ']') || (LA8_48 >= '_' && LA8_48 <= '}') || (LA8_48 >= '\u007F' && LA8_48 <= '\uFFFF')) ) { s = 37; }

                   	else if ( ((LA8_48 >= ' ' && LA8_48 <= '!') || LA8_48 == '$' || (LA8_48 >= '*' && LA8_48 <= ',') || (LA8_48 >= '<' && LA8_48 <= '>') || LA8_48 == '[' || LA8_48 == '^' || LA8_48 == '~') ) { s = 39; }

                   	else s = 19;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 10 : 
                   	int LA8_43 = input.LA(1);

                   	s = -1;
                   	if ( ((LA8_43 >= '\u0000' && LA8_43 <= '\t') || (LA8_43 >= '\u000B' && LA8_43 <= '\f') || (LA8_43 >= '\u000E' && LA8_43 <= '\u001F') || (LA8_43 >= '\"' && LA8_43 <= '#') || (LA8_43 >= '%' && LA8_43 <= ')') || (LA8_43 >= '-' && LA8_43 <= ';') || (LA8_43 >= '?' && LA8_43 <= 'Z') || (LA8_43 >= '\\' && LA8_43 <= ']') || (LA8_43 >= '_' && LA8_43 <= '}') || (LA8_43 >= '\u007F' && LA8_43 <= '\uFFFF')) ) { s = 19; }

                   	else s = 50;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 11 : 
                   	int LA8_49 = input.LA(1);

                   	s = -1;
                   	if ( (LA8_49 == '\"') ) { s = 41; }

                   	else if ( ((LA8_49 >= '\u0000' && LA8_49 <= '\t') || (LA8_49 >= '\u000B' && LA8_49 <= '\f') || (LA8_49 >= '\u000E' && LA8_49 <= '\u001F') || LA8_49 == '#' || (LA8_49 >= '%' && LA8_49 <= ')') || (LA8_49 >= '-' && LA8_49 <= ';') || (LA8_49 >= '?' && LA8_49 <= 'Z') || (LA8_49 >= '\\' && LA8_49 <= ']') || (LA8_49 >= '_' && LA8_49 <= '}') || (LA8_49 >= '\u007F' && LA8_49 <= '\uFFFF')) ) { s = 40; }

                   	else if ( ((LA8_49 >= ' ' && LA8_49 <= '!') || LA8_49 == '$' || (LA8_49 >= '*' && LA8_49 <= ',') || (LA8_49 >= '<' && LA8_49 <= '>') || LA8_49 == '[' || LA8_49 == '^' || LA8_49 == '~') ) { s = 42; }

                   	else s = 19;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 12 : 
                   	int LA8_17 = input.LA(1);

                   	s = -1;
                   	if ( ((LA8_17 >= '\u0000' && LA8_17 <= '\t') || (LA8_17 >= '\u000B' && LA8_17 <= '\f') || (LA8_17 >= '\u000E' && LA8_17 <= '\u001F') || LA8_17 == '#' || (LA8_17 >= '%' && LA8_17 <= ')') || (LA8_17 >= '-' && LA8_17 <= ';') || (LA8_17 >= '?' && LA8_17 <= 'Z') || (LA8_17 >= '\\' && LA8_17 <= ']') || (LA8_17 >= '_' && LA8_17 <= '}') || (LA8_17 >= '\u007F' && LA8_17 <= '\uFFFF')) ) { s = 40; }

                   	else if ( (LA8_17 == '\"') ) { s = 41; }

                   	else if ( ((LA8_17 >= ' ' && LA8_17 <= '!') || LA8_17 == '$' || (LA8_17 >= '*' && LA8_17 <= ',') || (LA8_17 >= '<' && LA8_17 <= '>') || LA8_17 == '[' || LA8_17 == '^' || LA8_17 == '~') ) { s = 42; }

                   	else s = 19;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 13 : 
                   	int LA8_40 = input.LA(1);

                   	s = -1;
                   	if ( (LA8_40 == '\"') ) { s = 41; }

                   	else if ( ((LA8_40 >= '\u0000' && LA8_40 <= '\t') || (LA8_40 >= '\u000B' && LA8_40 <= '\f') || (LA8_40 >= '\u000E' && LA8_40 <= '\u001F') || LA8_40 == '#' || (LA8_40 >= '%' && LA8_40 <= ')') || (LA8_40 >= '-' && LA8_40 <= ';') || (LA8_40 >= '?' && LA8_40 <= 'Z') || (LA8_40 >= '\\' && LA8_40 <= ']') || (LA8_40 >= '_' && LA8_40 <= '}') || (LA8_40 >= '\u007F' && LA8_40 <= '\uFFFF')) ) { s = 40; }

                   	else if ( ((LA8_40 >= ' ' && LA8_40 <= '!') || LA8_40 == '$' || (LA8_40 >= '*' && LA8_40 <= ',') || (LA8_40 >= '<' && LA8_40 <= '>') || LA8_40 == '[' || LA8_40 == '^' || LA8_40 == '~') ) { s = 42; }

                   	else s = 19;

                   	if ( s >= 0 ) return s;
                   	break;
        }
        NoViableAltException nvae8 =
            new NoViableAltException(dfa.Description, 8, _s, input);
        dfa.Error(nvae8);
        throw nvae8;
    }
 
    
}
