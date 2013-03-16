// $ANTLR 3.2 Sep 23, 2009 12:02:23 StringFilter.g 2013-03-16 10:33:08

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
    public const int GE = 12;
    public const int LT = 9;
    public const int STAR = 7;
    public const int I_STRING = 6;
    public const int WHITESPACE = 21;
    public const int MINUS = 8;
    public const int EOF = -1;
    public const int Q_STRING = 4;
    public const int NDOLLAR = 18;
    public const int COMMA = 19;
    public const int A_STRING = 5;
    public const int GT = 10;
    public const int ARROW = 15;
    public const int ENDLINE = 20;
    public const int DIGIT = 22;
    public const int EQ = 14;
    public const int NARROW = 16;
    public const int LE = 11;
    public const int NE = 13;

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
            // StringFilter.g:40:6: ( '-' )
            // StringFilter.g:40:9: '-'
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
            // StringFilter.g:41:3: ( '<' )
            // StringFilter.g:41:6: '<'
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
            // StringFilter.g:42:3: ( '>' )
            // StringFilter.g:42:6: '>'
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
            // StringFilter.g:43:3: ( '>=' )
            // StringFilter.g:43:6: '>='
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
            // StringFilter.g:44:3: ( '<=' )
            // StringFilter.g:44:6: '<='
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
            // StringFilter.g:45:3: ( '!=' | '<>' )
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
                    // StringFilter.g:45:6: '!='
                    {
                    	Match("!="); 


                    }
                    break;
                case 2 :
                    // StringFilter.g:45:13: '<>'
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
            // StringFilter.g:46:3: ( '=' )
            // StringFilter.g:46:6: '='
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

    // $ANTLR start "STAR"
    public void mSTAR() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = STAR;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // StringFilter.g:47:5: ( '*' )
            // StringFilter.g:47:8: '*'
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
            // StringFilter.g:48:6: ( ',' )
            // StringFilter.g:48:8: ','
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
            // StringFilter.g:49:6: ( '^' )
            // StringFilter.g:49:9: '^'
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
            // StringFilter.g:50:7: ( '$' )
            // StringFilter.g:50:10: '$'
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
            // StringFilter.g:51:7: ( '!^' )
            // StringFilter.g:51:10: '!^'
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
            // StringFilter.g:52:8: ( '!$' )
            // StringFilter.g:52:11: '!$'
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

    // $ANTLR start "A_STRING"
    public void mA_STRING() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = A_STRING;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // StringFilter.g:54:9: ( ( '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\'' ) )
            // StringFilter.g:55:4: ( '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\'' )
            {
            	// StringFilter.g:55:4: ( '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\'' )
            	// StringFilter.g:55:5: '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\''
            	{
            		Match('\''); 
            		// StringFilter.g:56:5: ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )*
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
            				    // StringFilter.g:57:31: ~ ( '\\'' | '\\r' | '\\n' )
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
            				    // StringFilter.g:57:56: '\\'' '\\''
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
            // StringFilter.g:62:9: ( ( '\\\"' ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )* '\\\"' ) )
            // StringFilter.g:63:4: ( '\\\"' ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )* '\\\"' )
            {
            	// StringFilter.g:63:4: ( '\\\"' ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )* '\\\"' )
            	// StringFilter.g:63:5: '\\\"' ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )* '\\\"'
            	{
            		Match('\"'); 
            		// StringFilter.g:64:5: ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )*
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
            				    // StringFilter.g:65:31: ~ ( '\\\"' | '\\r' | '\\n' )
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
            				    // StringFilter.g:65:56: '\\\"' '\\\"'
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
            // StringFilter.g:70:9: ( (~ ( '-' | ' ' | '<' | '>' | '=' | '!' | '\\r' | '\\n' | '^' | '$' | '*' | ',' ) )* )
            // StringFilter.g:70:11: (~ ( '-' | ' ' | '<' | '>' | '=' | '!' | '\\r' | '\\n' | '^' | '$' | '*' | ',' ) )*
            {
            	// StringFilter.g:70:11: (~ ( '-' | ' ' | '<' | '>' | '=' | '!' | '\\r' | '\\n' | '^' | '$' | '*' | ',' ) )*
            	do 
            	{
            	    int alt4 = 2;
            	    int LA4_0 = input.LA(1);

            	    if ( ((LA4_0 >= '\u0000' && LA4_0 <= '\t') || (LA4_0 >= '\u000B' && LA4_0 <= '\f') || (LA4_0 >= '\u000E' && LA4_0 <= '\u001F') || (LA4_0 >= '\"' && LA4_0 <= '#') || (LA4_0 >= '%' && LA4_0 <= ')') || LA4_0 == '+' || (LA4_0 >= '.' && LA4_0 <= ';') || (LA4_0 >= '?' && LA4_0 <= ']') || (LA4_0 >= '_' && LA4_0 <= '\uFFFF')) )
            	    {
            	        alt4 = 1;
            	    }


            	    switch (alt4) 
            		{
            			case 1 :
            			    // StringFilter.g:70:12: ~ ( '-' | ' ' | '<' | '>' | '=' | '!' | '\\r' | '\\n' | '^' | '$' | '*' | ',' )
            			    {
            			    	if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '\t') || (input.LA(1) >= '\u000B' && input.LA(1) <= '\f') || (input.LA(1) >= '\u000E' && input.LA(1) <= '\u001F') || (input.LA(1) >= '\"' && input.LA(1) <= '#') || (input.LA(1) >= '%' && input.LA(1) <= ')') || input.LA(1) == '+' || (input.LA(1) >= '.' && input.LA(1) <= ';') || (input.LA(1) >= '?' && input.LA(1) <= ']') || (input.LA(1) >= '_' && input.LA(1) <= '\uFFFF') ) 
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
            // StringFilter.g:73:12: ( ( '\\t' | ' ' | '\\u000C' )+ )
            // StringFilter.g:73:14: ( '\\t' | ' ' | '\\u000C' )+
            {
            	// StringFilter.g:73:14: ( '\\t' | ' ' | '\\u000C' )+
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
            // StringFilter.g:74:8: ( ( '\\r' | '\\n' )+ )
            // StringFilter.g:74:10: ( '\\r' | '\\n' )+
            {
            	// StringFilter.g:74:10: ( '\\r' | '\\n' )+
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
            // StringFilter.g:76:17: ( '0' .. '9' )
            // StringFilter.g:76:19: '0' .. '9'
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
        // StringFilter.g:1:8: ( MINUS | LT | GT | GE | LE | NE | EQ | STAR | COMMA | ARROW | DOLLAR | NARROW | NDOLLAR | A_STRING | Q_STRING | I_STRING | WHITESPACE | ENDLINE )
        int alt7 = 18;
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
                // StringFilter.g:1:34: STAR
                {
                	mSTAR(); 

                }
                break;
            case 9 :
                // StringFilter.g:1:39: COMMA
                {
                	mCOMMA(); 

                }
                break;
            case 10 :
                // StringFilter.g:1:45: ARROW
                {
                	mARROW(); 

                }
                break;
            case 11 :
                // StringFilter.g:1:51: DOLLAR
                {
                	mDOLLAR(); 

                }
                break;
            case 12 :
                // StringFilter.g:1:58: NARROW
                {
                	mNARROW(); 

                }
                break;
            case 13 :
                // StringFilter.g:1:65: NDOLLAR
                {
                	mNDOLLAR(); 

                }
                break;
            case 14 :
                // StringFilter.g:1:73: A_STRING
                {
                	mA_STRING(); 

                }
                break;
            case 15 :
                // StringFilter.g:1:82: Q_STRING
                {
                	mQ_STRING(); 

                }
                break;
            case 16 :
                // StringFilter.g:1:91: I_STRING
                {
                	mI_STRING(); 

                }
                break;
            case 17 :
                // StringFilter.g:1:100: WHITESPACE
                {
                	mWHITESPACE(); 

                }
                break;
            case 18 :
                // StringFilter.g:1:111: ENDLINE
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
        "\x01\x0d\x01\uffff\x01\x12\x01\x14\x06\uffff\x03\x0d\x0a\uffff"+
        "\x01\x0d\x01\x19\x01\uffff\x01\x0d\x01\x1c\x01\uffff\x02\x0d";
    const string DFA7_eofS =
        "\x1f\uffff";
    const string DFA7_minS =
        "\x01\x09\x01\uffff\x02\x3d\x01\x24\x05\uffff\x02\x00\x01\x09\x0a"+
        "\uffff\x02\x00\x01\uffff\x02\x00\x01\uffff\x02\x00";
    const string DFA7_maxS =
        "\x01\x5e\x01\uffff\x01\x3e\x01\x3d\x01\x5e\x05\uffff\x02\uffff"+
        "\x01\x20\x0a\uffff\x02\uffff\x01\uffff\x02\uffff\x01\uffff\x02\uffff";
    const string DFA7_acceptS =
        "\x01\uffff\x01\x01\x03\uffff\x01\x07\x01\x08\x01\x09\x01\x0a\x01"+
        "\x0b\x03\uffff\x01\x10\x01\x11\x01\x12\x01\x05\x01\x06\x01\x02\x01"+
        "\x04\x01\x03\x01\x0c\x01\x0d\x02\uffff\x01\x0e\x02\uffff\x01\x0f"+
        "\x02\uffff";
    const string DFA7_specialS =
        "\x0a\uffff\x01\x06\x01\x07\x0b\uffff\x01\x03\x01\x02\x01\uffff"+
        "\x01\x00\x01\x05\x01\uffff\x01\x04\x01\x01}>";
    static readonly string[] DFA7_transitionS = {
            "\x01\x0c\x01\x0f\x01\uffff\x01\x0c\x01\x0f\x12\uffff\x01\x0e"+
            "\x01\x04\x01\x0b\x01\uffff\x01\x09\x02\uffff\x01\x0a\x02\uffff"+
            "\x01\x06\x01\uffff\x01\x07\x01\x01\x0e\uffff\x01\x02\x01\x05"+
            "\x01\x03\x1f\uffff\x01\x08",
            "",
            "\x01\x10\x01\x11",
            "\x01\x13",
            "\x01\x16\x18\uffff\x01\x11\x20\uffff\x01\x15",
            "",
            "",
            "",
            "",
            "",
            "\x0a\x17\x01\uffff\x02\x17\x01\uffff\x12\x17\x02\x19\x02\x17"+
            "\x01\x19\x02\x17\x01\x18\x02\x17\x01\x19\x01\x17\x02\x19\x0e"+
            "\x17\x03\x19\x1f\x17\x01\x19\uffa1\x17",
            "\x0a\x1a\x01\uffff\x02\x1a\x01\uffff\x12\x1a\x02\x1c\x01\x1b"+
            "\x01\x1a\x01\x1c\x05\x1a\x01\x1c\x01\x1a\x02\x1c\x0e\x1a\x03"+
            "\x1c\x1f\x1a\x01\x1c\uffa1\x1a",
            "\x01\x0c\x02\uffff\x01\x0c\x13\uffff\x01\x0e",
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
            "\x0a\x17\x01\uffff\x02\x17\x01\uffff\x12\x17\x02\x19\x02\x17"+
            "\x01\x19\x02\x17\x01\x18\x02\x17\x01\x19\x01\x17\x02\x19\x0e"+
            "\x17\x03\x19\x1f\x17\x01\x19\uffa1\x17",
            "\x0a\x0d\x01\uffff\x02\x0d\x01\uffff\x12\x0d\x02\uffff\x02"+
            "\x0d\x01\uffff\x02\x0d\x01\x1d\x02\x0d\x01\uffff\x01\x0d\x02"+
            "\uffff\x0e\x0d\x03\uffff\x1f\x0d\x01\uffff\uffa1\x0d",
            "",
            "\x0a\x1a\x01\uffff\x02\x1a\x01\uffff\x12\x1a\x02\x1c\x01\x1b"+
            "\x01\x1a\x01\x1c\x05\x1a\x01\x1c\x01\x1a\x02\x1c\x0e\x1a\x03"+
            "\x1c\x1f\x1a\x01\x1c\uffa1\x1a",
            "\x0a\x0d\x01\uffff\x02\x0d\x01\uffff\x12\x0d\x02\uffff\x01"+
            "\x1e\x01\x0d\x01\uffff\x05\x0d\x01\uffff\x01\x0d\x02\uffff\x0e"+
            "\x0d\x03\uffff\x1f\x0d\x01\uffff\uffa1\x0d",
            "",
            "\x0a\x17\x01\uffff\x02\x17\x01\uffff\x12\x17\x02\x19\x02\x17"+
            "\x01\x19\x02\x17\x01\x18\x02\x17\x01\x19\x01\x17\x02\x19\x0e"+
            "\x17\x03\x19\x1f\x17\x01\x19\uffa1\x17",
            "\x0a\x1a\x01\uffff\x02\x1a\x01\uffff\x12\x1a\x02\x1c\x01\x1b"+
            "\x01\x1a\x01\x1c\x05\x1a\x01\x1c\x01\x1a\x02\x1c\x0e\x1a\x03"+
            "\x1c\x1f\x1a\x01\x1c\uffa1\x1a"
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
            get { return "1:1: Tokens : ( MINUS | LT | GT | GE | LE | NE | EQ | STAR | COMMA | ARROW | DOLLAR | NARROW | NDOLLAR | A_STRING | Q_STRING | I_STRING | WHITESPACE | ENDLINE );"; }
        }

    }


    protected internal int DFA7_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            IIntStream input = _input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA7_26 = input.LA(1);

                   	s = -1;
                   	if ( (LA7_26 == '\"') ) { s = 27; }

                   	else if ( ((LA7_26 >= '\u0000' && LA7_26 <= '\t') || (LA7_26 >= '\u000B' && LA7_26 <= '\f') || (LA7_26 >= '\u000E' && LA7_26 <= '\u001F') || LA7_26 == '#' || (LA7_26 >= '%' && LA7_26 <= ')') || LA7_26 == '+' || (LA7_26 >= '.' && LA7_26 <= ';') || (LA7_26 >= '?' && LA7_26 <= ']') || (LA7_26 >= '_' && LA7_26 <= '\uFFFF')) ) { s = 26; }

                   	else if ( ((LA7_26 >= ' ' && LA7_26 <= '!') || LA7_26 == '$' || LA7_26 == '*' || (LA7_26 >= ',' && LA7_26 <= '-') || (LA7_26 >= '<' && LA7_26 <= '>') || LA7_26 == '^') ) { s = 28; }

                   	else s = 13;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 1 : 
                   	int LA7_30 = input.LA(1);

                   	s = -1;
                   	if ( (LA7_30 == '\"') ) { s = 27; }

                   	else if ( ((LA7_30 >= '\u0000' && LA7_30 <= '\t') || (LA7_30 >= '\u000B' && LA7_30 <= '\f') || (LA7_30 >= '\u000E' && LA7_30 <= '\u001F') || LA7_30 == '#' || (LA7_30 >= '%' && LA7_30 <= ')') || LA7_30 == '+' || (LA7_30 >= '.' && LA7_30 <= ';') || (LA7_30 >= '?' && LA7_30 <= ']') || (LA7_30 >= '_' && LA7_30 <= '\uFFFF')) ) { s = 26; }

                   	else if ( ((LA7_30 >= ' ' && LA7_30 <= '!') || LA7_30 == '$' || LA7_30 == '*' || (LA7_30 >= ',' && LA7_30 <= '-') || (LA7_30 >= '<' && LA7_30 <= '>') || LA7_30 == '^') ) { s = 28; }

                   	else s = 13;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 2 : 
                   	int LA7_24 = input.LA(1);

                   	s = -1;
                   	if ( (LA7_24 == '\'') ) { s = 29; }

                   	else if ( ((LA7_24 >= '\u0000' && LA7_24 <= '\t') || (LA7_24 >= '\u000B' && LA7_24 <= '\f') || (LA7_24 >= '\u000E' && LA7_24 <= '\u001F') || (LA7_24 >= '\"' && LA7_24 <= '#') || (LA7_24 >= '%' && LA7_24 <= '&') || (LA7_24 >= '(' && LA7_24 <= ')') || LA7_24 == '+' || (LA7_24 >= '.' && LA7_24 <= ';') || (LA7_24 >= '?' && LA7_24 <= ']') || (LA7_24 >= '_' && LA7_24 <= '\uFFFF')) ) { s = 13; }

                   	else s = 25;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 3 : 
                   	int LA7_23 = input.LA(1);

                   	s = -1;
                   	if ( (LA7_23 == '\'') ) { s = 24; }

                   	else if ( ((LA7_23 >= '\u0000' && LA7_23 <= '\t') || (LA7_23 >= '\u000B' && LA7_23 <= '\f') || (LA7_23 >= '\u000E' && LA7_23 <= '\u001F') || (LA7_23 >= '\"' && LA7_23 <= '#') || (LA7_23 >= '%' && LA7_23 <= '&') || (LA7_23 >= '(' && LA7_23 <= ')') || LA7_23 == '+' || (LA7_23 >= '.' && LA7_23 <= ';') || (LA7_23 >= '?' && LA7_23 <= ']') || (LA7_23 >= '_' && LA7_23 <= '\uFFFF')) ) { s = 23; }

                   	else if ( ((LA7_23 >= ' ' && LA7_23 <= '!') || LA7_23 == '$' || LA7_23 == '*' || (LA7_23 >= ',' && LA7_23 <= '-') || (LA7_23 >= '<' && LA7_23 <= '>') || LA7_23 == '^') ) { s = 25; }

                   	else s = 13;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 4 : 
                   	int LA7_29 = input.LA(1);

                   	s = -1;
                   	if ( (LA7_29 == '\'') ) { s = 24; }

                   	else if ( ((LA7_29 >= '\u0000' && LA7_29 <= '\t') || (LA7_29 >= '\u000B' && LA7_29 <= '\f') || (LA7_29 >= '\u000E' && LA7_29 <= '\u001F') || (LA7_29 >= '\"' && LA7_29 <= '#') || (LA7_29 >= '%' && LA7_29 <= '&') || (LA7_29 >= '(' && LA7_29 <= ')') || LA7_29 == '+' || (LA7_29 >= '.' && LA7_29 <= ';') || (LA7_29 >= '?' && LA7_29 <= ']') || (LA7_29 >= '_' && LA7_29 <= '\uFFFF')) ) { s = 23; }

                   	else if ( ((LA7_29 >= ' ' && LA7_29 <= '!') || LA7_29 == '$' || LA7_29 == '*' || (LA7_29 >= ',' && LA7_29 <= '-') || (LA7_29 >= '<' && LA7_29 <= '>') || LA7_29 == '^') ) { s = 25; }

                   	else s = 13;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 5 : 
                   	int LA7_27 = input.LA(1);

                   	s = -1;
                   	if ( (LA7_27 == '\"') ) { s = 30; }

                   	else if ( ((LA7_27 >= '\u0000' && LA7_27 <= '\t') || (LA7_27 >= '\u000B' && LA7_27 <= '\f') || (LA7_27 >= '\u000E' && LA7_27 <= '\u001F') || LA7_27 == '#' || (LA7_27 >= '%' && LA7_27 <= ')') || LA7_27 == '+' || (LA7_27 >= '.' && LA7_27 <= ';') || (LA7_27 >= '?' && LA7_27 <= ']') || (LA7_27 >= '_' && LA7_27 <= '\uFFFF')) ) { s = 13; }

                   	else s = 28;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 6 : 
                   	int LA7_10 = input.LA(1);

                   	s = -1;
                   	if ( ((LA7_10 >= '\u0000' && LA7_10 <= '\t') || (LA7_10 >= '\u000B' && LA7_10 <= '\f') || (LA7_10 >= '\u000E' && LA7_10 <= '\u001F') || (LA7_10 >= '\"' && LA7_10 <= '#') || (LA7_10 >= '%' && LA7_10 <= '&') || (LA7_10 >= '(' && LA7_10 <= ')') || LA7_10 == '+' || (LA7_10 >= '.' && LA7_10 <= ';') || (LA7_10 >= '?' && LA7_10 <= ']') || (LA7_10 >= '_' && LA7_10 <= '\uFFFF')) ) { s = 23; }

                   	else if ( (LA7_10 == '\'') ) { s = 24; }

                   	else if ( ((LA7_10 >= ' ' && LA7_10 <= '!') || LA7_10 == '$' || LA7_10 == '*' || (LA7_10 >= ',' && LA7_10 <= '-') || (LA7_10 >= '<' && LA7_10 <= '>') || LA7_10 == '^') ) { s = 25; }

                   	else s = 13;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 7 : 
                   	int LA7_11 = input.LA(1);

                   	s = -1;
                   	if ( ((LA7_11 >= '\u0000' && LA7_11 <= '\t') || (LA7_11 >= '\u000B' && LA7_11 <= '\f') || (LA7_11 >= '\u000E' && LA7_11 <= '\u001F') || LA7_11 == '#' || (LA7_11 >= '%' && LA7_11 <= ')') || LA7_11 == '+' || (LA7_11 >= '.' && LA7_11 <= ';') || (LA7_11 >= '?' && LA7_11 <= ']') || (LA7_11 >= '_' && LA7_11 <= '\uFFFF')) ) { s = 26; }

                   	else if ( (LA7_11 == '\"') ) { s = 27; }

                   	else if ( ((LA7_11 >= ' ' && LA7_11 <= '!') || LA7_11 == '$' || LA7_11 == '*' || (LA7_11 >= ',' && LA7_11 <= '-') || (LA7_11 >= '<' && LA7_11 <= '>') || LA7_11 == '^') ) { s = 28; }

                   	else s = 13;

                   	if ( s >= 0 ) return s;
                   	break;
        }
        NoViableAltException nvae7 =
            new NoViableAltException(dfa.Description, 7, _s, input);
        dfa.Error(nvae7);
        throw nvae7;
    }
 
    
}
