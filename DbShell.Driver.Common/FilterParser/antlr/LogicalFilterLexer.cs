// $ANTLR 3.2 Sep 23, 2009 12:02:23 LogicalFilter.g 2014-10-25 22:48:44

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162


using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;


public partial class LogicalFilterLexer : Lexer {
    public const int EOF = -1;
    public const int Q_STRING = 32;
    public const int DIGIT_0 = 28;
    public const int DIGIT_1 = 29;
    public const int COMMA = 16;
    public const int T_NULL = 10;
    public const int T_TRUE = 6;
    public const int EQ = 13;
    public const int DOT = 5;
    public const int NE = 12;
    public const int D = 35;
    public const int E = 24;
    public const int F = 25;
    public const int G = 36;
    public const int A = 26;
    public const int B = 33;
    public const int NE2 = 15;
    public const int C = 34;
    public const int L = 20;
    public const int M = 41;
    public const int N = 18;
    public const int O = 21;
    public const int H = 37;
    public const int I = 38;
    public const int J = 39;
    public const int K = 40;
    public const int U = 19;
    public const int T = 22;
    public const int W = 45;
    public const int WHITESPACE = 30;
    public const int V = 44;
    public const int Q = 43;
    public const int P = 42;
    public const int S = 27;
    public const int R = 23;
    public const int Y = 47;
    public const int X = 46;
    public const int EQ2 = 14;
    public const int SQL_LITERAL = 4;
    public const int Z = 48;
    public const int T_FALSE = 7;
    public const int T_1 = 8;
    public const int T_0 = 9;
    public const int A_STRING = 31;
    public const int ENDLINE = 17;
    public const int T_NOT = 11;

    // delegates
    // delegators

    public LogicalFilterLexer() 
    {
		InitializeCyclicDFAs();
    }
    public LogicalFilterLexer(ICharStream input)
		: this(input, null) {
    }
    public LogicalFilterLexer(ICharStream input, RecognizerSharedState state)
		: base(input, state) {
		InitializeCyclicDFAs(); 

    }
    
    override public string GrammarFileName
    {
    	get { return "LogicalFilter.g";} 
    }

    // $ANTLR start "T_NULL"
    public void mT_NULL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_NULL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // LogicalFilter.g:41:7: ( N U L L )
            // LogicalFilter.g:41:9: N U L L
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
            // LogicalFilter.g:42:6: ( N O T )
            // LogicalFilter.g:42:8: N O T
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

    // $ANTLR start "T_TRUE"
    public void mT_TRUE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_TRUE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // LogicalFilter.g:43:7: ( T R U E )
            // LogicalFilter.g:43:9: T R U E
            {
            	mT(); 
            	mR(); 
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
    // $ANTLR end "T_TRUE"

    // $ANTLR start "T_FALSE"
    public void mT_FALSE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_FALSE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // LogicalFilter.g:44:8: ( F A L S E )
            // LogicalFilter.g:44:10: F A L S E
            {
            	mF(); 
            	mA(); 
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
    // $ANTLR end "T_FALSE"

    // $ANTLR start "T_0"
    public void mT_0() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_0;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // LogicalFilter.g:45:4: ( DIGIT_0 )
            // LogicalFilter.g:45:6: DIGIT_0
            {
            	mDIGIT_0(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_0"

    // $ANTLR start "T_1"
    public void mT_1() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = T_1;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // LogicalFilter.g:46:4: ( DIGIT_1 )
            // LogicalFilter.g:46:6: DIGIT_1
            {
            	mDIGIT_1(); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "T_1"

    // $ANTLR start "NE"
    public void mNE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = NE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // LogicalFilter.g:48:3: ( '<>' )
            // LogicalFilter.g:48:6: '<>'
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
            // LogicalFilter.g:49:3: ( '=' )
            // LogicalFilter.g:49:6: '='
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
            // LogicalFilter.g:50:6: ( ',' )
            // LogicalFilter.g:50:8: ','
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
            // LogicalFilter.g:51:4: ( '.' )
            // LogicalFilter.g:51:6: '.'
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
            // LogicalFilter.g:52:4: ( '==' )
            // LogicalFilter.g:52:7: '=='
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
            // LogicalFilter.g:53:4: ( '!=' )
            // LogicalFilter.g:53:7: '!='
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

    // $ANTLR start "WHITESPACE"
    public void mWHITESPACE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = WHITESPACE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // LogicalFilter.g:55:12: ( ( '\\t' | ' ' | '\\u000C' )+ )
            // LogicalFilter.g:55:14: ( '\\t' | ' ' | '\\u000C' )+
            {
            	// LogicalFilter.g:55:14: ( '\\t' | ' ' | '\\u000C' )+
            	int cnt1 = 0;
            	do 
            	{
            	    int alt1 = 2;
            	    int LA1_0 = input.LA(1);

            	    if ( (LA1_0 == '\t' || LA1_0 == '\f' || LA1_0 == ' ') )
            	    {
            	        alt1 = 1;
            	    }


            	    switch (alt1) 
            		{
            			case 1 :
            			    // LogicalFilter.g:
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
            			    if ( cnt1 >= 1 ) goto loop1;
            		            EarlyExitException eee1 =
            		                new EarlyExitException(1, input);
            		            throw eee1;
            	    }
            	    cnt1++;
            	} while (true);

            	loop1:
            		;	// Stops C# compiler whining that label 'loop1' has no statements

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
            // LogicalFilter.g:56:8: ( ( '\\r' | '\\n' )+ )
            // LogicalFilter.g:56:10: ( '\\r' | '\\n' )+
            {
            	// LogicalFilter.g:56:10: ( '\\r' | '\\n' )+
            	int cnt2 = 0;
            	do 
            	{
            	    int alt2 = 2;
            	    int LA2_0 = input.LA(1);

            	    if ( (LA2_0 == '\n' || LA2_0 == '\r') )
            	    {
            	        alt2 = 1;
            	    }


            	    switch (alt2) 
            		{
            			case 1 :
            			    // LogicalFilter.g:
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
            // LogicalFilter.g:58:12: ( ( '[' ( options {greedy=true; } : ~ ( ']' | '\\r' | '\\n' ) )* ']' ) )
            // LogicalFilter.g:59:4: ( '[' ( options {greedy=true; } : ~ ( ']' | '\\r' | '\\n' ) )* ']' )
            {
            	// LogicalFilter.g:59:4: ( '[' ( options {greedy=true; } : ~ ( ']' | '\\r' | '\\n' ) )* ']' )
            	// LogicalFilter.g:59:5: '[' ( options {greedy=true; } : ~ ( ']' | '\\r' | '\\n' ) )* ']'
            	{
            		Match('['); 
            		// LogicalFilter.g:60:5: ( options {greedy=true; } : ~ ( ']' | '\\r' | '\\n' ) )*
            		do 
            		{
            		    int alt3 = 2;
            		    int LA3_0 = input.LA(1);

            		    if ( ((LA3_0 >= '\u0000' && LA3_0 <= '\t') || (LA3_0 >= '\u000B' && LA3_0 <= '\f') || (LA3_0 >= '\u000E' && LA3_0 <= '\\') || (LA3_0 >= '^' && LA3_0 <= '\uFFFF')) )
            		    {
            		        alt3 = 1;
            		    }


            		    switch (alt3) 
            			{
            				case 1 :
            				    // LogicalFilter.g:61:31: ~ ( ']' | '\\r' | '\\n' )
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
            				    goto loop3;
            		    }
            		} while (true);

            		loop3:
            			;	// Stops C# compiler whining that label 'loop3' has no statements

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
            // LogicalFilter.g:67:9: ( ( '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\'' ) )
            // LogicalFilter.g:68:4: ( '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\'' )
            {
            	// LogicalFilter.g:68:4: ( '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\'' )
            	// LogicalFilter.g:68:5: '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\''
            	{
            		Match('\''); 
            		// LogicalFilter.g:69:5: ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )*
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
            				    // LogicalFilter.g:70:31: ~ ( '\\'' | '\\r' | '\\n' )
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
            				    // LogicalFilter.g:70:56: '\\'' '\\''
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
    // $ANTLR end "A_STRING"

    // $ANTLR start "Q_STRING"
    public void mQ_STRING() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = Q_STRING;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // LogicalFilter.g:75:9: ( ( '\\\"' ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )* '\\\"' ) )
            // LogicalFilter.g:76:4: ( '\\\"' ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )* '\\\"' )
            {
            	// LogicalFilter.g:76:4: ( '\\\"' ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )* '\\\"' )
            	// LogicalFilter.g:76:5: '\\\"' ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )* '\\\"'
            	{
            		Match('\"'); 
            		// LogicalFilter.g:77:5: ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )*
            		do 
            		{
            		    int alt5 = 3;
            		    int LA5_0 = input.LA(1);

            		    if ( (LA5_0 == '\"') )
            		    {
            		        int LA5_1 = input.LA(2);

            		        if ( (LA5_1 == '\"') )
            		        {
            		            alt5 = 2;
            		        }


            		    }
            		    else if ( ((LA5_0 >= '\u0000' && LA5_0 <= '\t') || (LA5_0 >= '\u000B' && LA5_0 <= '\f') || (LA5_0 >= '\u000E' && LA5_0 <= '!') || (LA5_0 >= '#' && LA5_0 <= '\uFFFF')) )
            		    {
            		        alt5 = 1;
            		    }


            		    switch (alt5) 
            			{
            				case 1 :
            				    // LogicalFilter.g:78:31: ~ ( '\\\"' | '\\r' | '\\n' )
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
            				    // LogicalFilter.g:78:56: '\\\"' '\\\"'
            				    {
            				    	Match('\"'); 
            				    	Match('\"'); 

            				    }
            				    break;

            				default:
            				    goto loop5;
            		    }
            		} while (true);

            		loop5:
            			;	// Stops C# compiler whining that label 'loop5' has no statements

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

    // $ANTLR start "DIGIT_0"
    public void mDIGIT_0() // throws RecognitionException [2]
    {
    		try
    		{
            // LogicalFilter.g:83:19: ( '0' )
            // LogicalFilter.g:83:21: '0'
            {
            	Match('0'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "DIGIT_0"

    // $ANTLR start "DIGIT_1"
    public void mDIGIT_1() // throws RecognitionException [2]
    {
    		try
    		{
            // LogicalFilter.g:84:19: ( '1' )
            // LogicalFilter.g:84:21: '1'
            {
            	Match('1'); 

            }

        }
        finally 
    	{
        }
    }
    // $ANTLR end "DIGIT_1"

    // $ANTLR start "A"
    public void mA() // throws RecognitionException [2]
    {
    		try
    		{
            // LogicalFilter.g:86:11: ( 'A' )
            // LogicalFilter.g:86:13: 'A'
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
            // LogicalFilter.g:87:11: ( 'B' )
            // LogicalFilter.g:87:13: 'B'
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
            // LogicalFilter.g:88:11: ( 'C' )
            // LogicalFilter.g:88:13: 'C'
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
            // LogicalFilter.g:89:11: ( 'D' )
            // LogicalFilter.g:89:13: 'D'
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
            // LogicalFilter.g:90:11: ( 'E' )
            // LogicalFilter.g:90:13: 'E'
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
            // LogicalFilter.g:91:11: ( 'F' )
            // LogicalFilter.g:91:13: 'F'
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
            // LogicalFilter.g:92:11: ( 'G' )
            // LogicalFilter.g:92:13: 'G'
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
            // LogicalFilter.g:93:11: ( 'H' )
            // LogicalFilter.g:93:13: 'H'
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
            // LogicalFilter.g:94:11: ( 'I' )
            // LogicalFilter.g:94:13: 'I'
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
            // LogicalFilter.g:95:11: ( 'J' )
            // LogicalFilter.g:95:13: 'J'
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
            // LogicalFilter.g:96:11: ( 'K' )
            // LogicalFilter.g:96:13: 'K'
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
            // LogicalFilter.g:97:11: ( 'L' )
            // LogicalFilter.g:97:13: 'L'
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
            // LogicalFilter.g:98:11: ( 'M' )
            // LogicalFilter.g:98:13: 'M'
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
            // LogicalFilter.g:99:11: ( 'N' )
            // LogicalFilter.g:99:13: 'N'
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
            // LogicalFilter.g:100:11: ( 'O' )
            // LogicalFilter.g:100:13: 'O'
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
            // LogicalFilter.g:101:11: ( 'P' )
            // LogicalFilter.g:101:13: 'P'
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
            // LogicalFilter.g:102:11: ( 'Q' )
            // LogicalFilter.g:102:13: 'Q'
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
            // LogicalFilter.g:103:11: ( 'R' )
            // LogicalFilter.g:103:13: 'R'
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
            // LogicalFilter.g:104:11: ( 'S' )
            // LogicalFilter.g:104:13: 'S'
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
            // LogicalFilter.g:105:11: ( 'T' )
            // LogicalFilter.g:105:13: 'T'
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
            // LogicalFilter.g:106:11: ( 'U' )
            // LogicalFilter.g:106:13: 'U'
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
            // LogicalFilter.g:107:11: ( 'V' )
            // LogicalFilter.g:107:13: 'V'
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
            // LogicalFilter.g:108:11: ( 'W' )
            // LogicalFilter.g:108:13: 'W'
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
            // LogicalFilter.g:109:11: ( 'X' )
            // LogicalFilter.g:109:13: 'X'
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
            // LogicalFilter.g:110:11: ( 'Y' )
            // LogicalFilter.g:110:13: 'Y'
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
            // LogicalFilter.g:111:11: ( 'Z' )
            // LogicalFilter.g:111:13: 'Z'
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
        // LogicalFilter.g:1:8: ( T_NULL | T_NOT | T_TRUE | T_FALSE | T_0 | T_1 | NE | EQ | COMMA | DOT | EQ2 | NE2 | WHITESPACE | ENDLINE | SQL_LITERAL | A_STRING | Q_STRING )
        int alt6 = 17;
        alt6 = dfa6.Predict(input);
        switch (alt6) 
        {
            case 1 :
                // LogicalFilter.g:1:10: T_NULL
                {
                	mT_NULL(); 

                }
                break;
            case 2 :
                // LogicalFilter.g:1:17: T_NOT
                {
                	mT_NOT(); 

                }
                break;
            case 3 :
                // LogicalFilter.g:1:23: T_TRUE
                {
                	mT_TRUE(); 

                }
                break;
            case 4 :
                // LogicalFilter.g:1:30: T_FALSE
                {
                	mT_FALSE(); 

                }
                break;
            case 5 :
                // LogicalFilter.g:1:38: T_0
                {
                	mT_0(); 

                }
                break;
            case 6 :
                // LogicalFilter.g:1:42: T_1
                {
                	mT_1(); 

                }
                break;
            case 7 :
                // LogicalFilter.g:1:46: NE
                {
                	mNE(); 

                }
                break;
            case 8 :
                // LogicalFilter.g:1:49: EQ
                {
                	mEQ(); 

                }
                break;
            case 9 :
                // LogicalFilter.g:1:52: COMMA
                {
                	mCOMMA(); 

                }
                break;
            case 10 :
                // LogicalFilter.g:1:58: DOT
                {
                	mDOT(); 

                }
                break;
            case 11 :
                // LogicalFilter.g:1:62: EQ2
                {
                	mEQ2(); 

                }
                break;
            case 12 :
                // LogicalFilter.g:1:66: NE2
                {
                	mNE2(); 

                }
                break;
            case 13 :
                // LogicalFilter.g:1:70: WHITESPACE
                {
                	mWHITESPACE(); 

                }
                break;
            case 14 :
                // LogicalFilter.g:1:81: ENDLINE
                {
                	mENDLINE(); 

                }
                break;
            case 15 :
                // LogicalFilter.g:1:89: SQL_LITERAL
                {
                	mSQL_LITERAL(); 

                }
                break;
            case 16 :
                // LogicalFilter.g:1:101: A_STRING
                {
                	mA_STRING(); 

                }
                break;
            case 17 :
                // LogicalFilter.g:1:110: Q_STRING
                {
                	mQ_STRING(); 

                }
                break;

        }

    }


    protected DFA6 dfa6;
	private void InitializeCyclicDFAs()
	{
	    this.dfa6 = new DFA6(this);
	}

    const string DFA6_eotS =
        "\x07\uffff\x01\x13\x0c\uffff";
    const string DFA6_eofS =
        "\x14\uffff";
    const string DFA6_minS =
        "\x01\x09\x01\x4f\x05\uffff\x01\x3d\x0c\uffff";
    const string DFA6_maxS =
        "\x01\x5b\x01\x55\x05\uffff\x01\x3d\x0c\uffff";
    const string DFA6_acceptS =
        "\x02\uffff\x01\x03\x01\x04\x01\x05\x01\x06\x01\x07\x01\uffff\x01"+
        "\x09\x01\x0a\x01\x0c\x01\x0d\x01\x0e\x01\x0f\x01\x10\x01\x11\x01"+
        "\x01\x01\x02\x01\x0b\x01\x08";
    const string DFA6_specialS =
        "\x14\uffff}>";
    static readonly string[] DFA6_transitionS = {
            "\x01\x0b\x01\x0c\x01\uffff\x01\x0b\x01\x0c\x12\uffff\x01\x0b"+
            "\x01\x0a\x01\x0f\x04\uffff\x01\x0e\x04\uffff\x01\x08\x01\uffff"+
            "\x01\x09\x01\uffff\x01\x04\x01\x05\x0a\uffff\x01\x06\x01\x07"+
            "\x08\uffff\x01\x03\x07\uffff\x01\x01\x05\uffff\x01\x02\x06\uffff"+
            "\x01\x0d",
            "\x01\x11\x05\uffff\x01\x10",
            "",
            "",
            "",
            "",
            "",
            "\x01\x12",
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

    static readonly short[] DFA6_eot = DFA.UnpackEncodedString(DFA6_eotS);
    static readonly short[] DFA6_eof = DFA.UnpackEncodedString(DFA6_eofS);
    static readonly char[] DFA6_min = DFA.UnpackEncodedStringToUnsignedChars(DFA6_minS);
    static readonly char[] DFA6_max = DFA.UnpackEncodedStringToUnsignedChars(DFA6_maxS);
    static readonly short[] DFA6_accept = DFA.UnpackEncodedString(DFA6_acceptS);
    static readonly short[] DFA6_special = DFA.UnpackEncodedString(DFA6_specialS);
    static readonly short[][] DFA6_transition = DFA.UnpackEncodedStringArray(DFA6_transitionS);

    protected class DFA6 : DFA
    {
        public DFA6(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 6;
            this.eot = DFA6_eot;
            this.eof = DFA6_eof;
            this.min = DFA6_min;
            this.max = DFA6_max;
            this.accept = DFA6_accept;
            this.special = DFA6_special;
            this.transition = DFA6_transition;

        }

        override public string Description
        {
            get { return "1:1: Tokens : ( T_NULL | T_NOT | T_TRUE | T_FALSE | T_0 | T_1 | NE | EQ | COMMA | DOT | EQ2 | NE2 | WHITESPACE | ENDLINE | SQL_LITERAL | A_STRING | Q_STRING );"; }
        }

    }

 
    
}
