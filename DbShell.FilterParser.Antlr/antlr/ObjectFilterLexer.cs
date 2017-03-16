// $ANTLR 3.2 Sep 23, 2009 12:02:23 ObjectFilter.g 2016-09-07 21:54:37

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162


using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;


public partial class ObjectFilterLexer : Lexer {
    public const int DOLLAR = 11;
    public const int I_STRING = 6;
    public const int MAIL = 16;
    public const int HASH = 15;
    public const int WHITESPACE = 19;
    public const int EOF = -1;
    public const int Q_STRING = 4;
    public const int TILDA = 8;
    public const int NDOLLAR = 12;
    public const int COMMA = 17;
    public const int A_STRING = 5;
    public const int ARROW = 9;
    public const int PLUS = 7;
    public const int ENDLINE = 18;
    public const int EQ = 13;
    public const int NARROW = 10;
    public const int NE = 14;

    // delegates
    // delegators

    public ObjectFilterLexer() 
    {
		InitializeCyclicDFAs();
    }
    public ObjectFilterLexer(ICharStream input)
		: this(input, null) {
    }
    public ObjectFilterLexer(ICharStream input, RecognizerSharedState state)
		: base(input, state) {
		InitializeCyclicDFAs(); 

    }
    
    override public string GrammarFileName
    {
    	get { return "ObjectFilter.g";} 
    }

    // $ANTLR start "PLUS"
    public void mPLUS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = PLUS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ObjectFilter.g:42:5: ( '+' )
            // ObjectFilter.g:42:8: '+'
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

    // $ANTLR start "TILDA"
    public void mTILDA() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = TILDA;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ObjectFilter.g:43:6: ( '~' )
            // ObjectFilter.g:43:9: '~'
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

    // $ANTLR start "NE"
    public void mNE() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = NE;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ObjectFilter.g:44:3: ( '<>' )
            // ObjectFilter.g:44:6: '<>'
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
            // ObjectFilter.g:45:3: ( '=' )
            // ObjectFilter.g:45:6: '='
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

    // $ANTLR start "HASH"
    public void mHASH() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = HASH;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ObjectFilter.g:46:5: ( '#' )
            // ObjectFilter.g:46:7: '#'
            {
            	Match('#'); 

            }

            state.type = _type;
            state.channel = _channel;
        }
        finally 
    	{
        }
    }
    // $ANTLR end "HASH"

    // $ANTLR start "MAIL"
    public void mMAIL() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = MAIL;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ObjectFilter.g:47:5: ( '@' )
            // ObjectFilter.g:47:7: '@'
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
    // $ANTLR end "MAIL"

    // $ANTLR start "COMMA"
    public void mCOMMA() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = COMMA;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ObjectFilter.g:48:6: ( ',' )
            // ObjectFilter.g:48:8: ','
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
            // ObjectFilter.g:49:6: ( '^' )
            // ObjectFilter.g:49:9: '^'
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
            // ObjectFilter.g:50:7: ( '$' )
            // ObjectFilter.g:50:10: '$'
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
            // ObjectFilter.g:51:7: ( '!^' )
            // ObjectFilter.g:51:10: '!^'
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
            // ObjectFilter.g:52:8: ( '!$' )
            // ObjectFilter.g:52:11: '!$'
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
            // ObjectFilter.g:54:9: ( ( '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\'' ) )
            // ObjectFilter.g:55:4: ( '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\'' )
            {
            	// ObjectFilter.g:55:4: ( '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\'' )
            	// ObjectFilter.g:55:5: '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\''
            	{
            		Match('\''); 
            		// ObjectFilter.g:56:5: ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )*
            		do 
            		{
            		    int alt1 = 3;
            		    int LA1_0 = input.LA(1);

            		    if ( (LA1_0 == '\'') )
            		    {
            		        int LA1_1 = input.LA(2);

            		        if ( (LA1_1 == '\'') )
            		        {
            		            alt1 = 2;
            		        }


            		    }
            		    else if ( ((LA1_0 >= '\u0000' && LA1_0 <= '\t') || (LA1_0 >= '\u000B' && LA1_0 <= '\f') || (LA1_0 >= '\u000E' && LA1_0 <= '&') || (LA1_0 >= '(' && LA1_0 <= '\uFFFF')) )
            		    {
            		        alt1 = 1;
            		    }


            		    switch (alt1) 
            			{
            				case 1 :
            				    // ObjectFilter.g:57:31: ~ ( '\\'' | '\\r' | '\\n' )
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
            				    // ObjectFilter.g:57:56: '\\'' '\\''
            				    {
            				    	Match('\''); 
            				    	Match('\''); 

            				    }
            				    break;

            				default:
            				    goto loop1;
            		    }
            		} while (true);

            		loop1:
            			;	// Stops C# compiler whining that label 'loop1' has no statements

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
            // ObjectFilter.g:62:9: ( ( '\\\"' ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )* '\\\"' ) )
            // ObjectFilter.g:63:4: ( '\\\"' ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )* '\\\"' )
            {
            	// ObjectFilter.g:63:4: ( '\\\"' ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )* '\\\"' )
            	// ObjectFilter.g:63:5: '\\\"' ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )* '\\\"'
            	{
            		Match('\"'); 
            		// ObjectFilter.g:64:5: ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )*
            		do 
            		{
            		    int alt2 = 3;
            		    int LA2_0 = input.LA(1);

            		    if ( (LA2_0 == '\"') )
            		    {
            		        int LA2_1 = input.LA(2);

            		        if ( (LA2_1 == '\"') )
            		        {
            		            alt2 = 2;
            		        }


            		    }
            		    else if ( ((LA2_0 >= '\u0000' && LA2_0 <= '\t') || (LA2_0 >= '\u000B' && LA2_0 <= '\f') || (LA2_0 >= '\u000E' && LA2_0 <= '!') || (LA2_0 >= '#' && LA2_0 <= '\uFFFF')) )
            		    {
            		        alt2 = 1;
            		    }


            		    switch (alt2) 
            			{
            				case 1 :
            				    // ObjectFilter.g:65:31: ~ ( '\\\"' | '\\r' | '\\n' )
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
            				    // ObjectFilter.g:65:56: '\\\"' '\\\"'
            				    {
            				    	Match('\"'); 
            				    	Match('\"'); 

            				    }
            				    break;

            				default:
            				    goto loop2;
            		    }
            		} while (true);

            		loop2:
            			;	// Stops C# compiler whining that label 'loop2' has no statements

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
            // ObjectFilter.g:70:9: ( (~ ( '[' | '~' | ' ' | '<' | '>' | '=' | '!' | '\\r' | '\\n' | '^' | '$' | '*' | ',' | '+' | '#' | '@' ) )* )
            // ObjectFilter.g:70:11: (~ ( '[' | '~' | ' ' | '<' | '>' | '=' | '!' | '\\r' | '\\n' | '^' | '$' | '*' | ',' | '+' | '#' | '@' ) )*
            {
            	// ObjectFilter.g:70:11: (~ ( '[' | '~' | ' ' | '<' | '>' | '=' | '!' | '\\r' | '\\n' | '^' | '$' | '*' | ',' | '+' | '#' | '@' ) )*
            	do 
            	{
            	    int alt3 = 2;
            	    int LA3_0 = input.LA(1);

            	    if ( ((LA3_0 >= '\u0000' && LA3_0 <= '\t') || (LA3_0 >= '\u000B' && LA3_0 <= '\f') || (LA3_0 >= '\u000E' && LA3_0 <= '\u001F') || LA3_0 == '\"' || (LA3_0 >= '%' && LA3_0 <= ')') || (LA3_0 >= '-' && LA3_0 <= ';') || LA3_0 == '?' || (LA3_0 >= 'A' && LA3_0 <= 'Z') || (LA3_0 >= '\\' && LA3_0 <= ']') || (LA3_0 >= '_' && LA3_0 <= '}') || (LA3_0 >= '\u007F' && LA3_0 <= '\uFFFF')) )
            	    {
            	        alt3 = 1;
            	    }


            	    switch (alt3) 
            		{
            			case 1 :
            			    // ObjectFilter.g:70:12: ~ ( '[' | '~' | ' ' | '<' | '>' | '=' | '!' | '\\r' | '\\n' | '^' | '$' | '*' | ',' | '+' | '#' | '@' )
            			    {
            			    	if ( (input.LA(1) >= '\u0000' && input.LA(1) <= '\t') || (input.LA(1) >= '\u000B' && input.LA(1) <= '\f') || (input.LA(1) >= '\u000E' && input.LA(1) <= '\u001F') || input.LA(1) == '\"' || (input.LA(1) >= '%' && input.LA(1) <= ')') || (input.LA(1) >= '-' && input.LA(1) <= ';') || input.LA(1) == '?' || (input.LA(1) >= 'A' && input.LA(1) <= 'Z') || (input.LA(1) >= '\\' && input.LA(1) <= ']') || (input.LA(1) >= '_' && input.LA(1) <= '}') || (input.LA(1) >= '\u007F' && input.LA(1) <= '\uFFFF') ) 
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
            // ObjectFilter.g:72:12: ( ( '\\t' | ' ' | '\\u000C' )+ )
            // ObjectFilter.g:72:14: ( '\\t' | ' ' | '\\u000C' )+
            {
            	// ObjectFilter.g:72:14: ( '\\t' | ' ' | '\\u000C' )+
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
            			    // ObjectFilter.g:
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
            // ObjectFilter.g:73:8: ( ( '\\r' | '\\n' )+ )
            // ObjectFilter.g:73:10: ( '\\r' | '\\n' )+
            {
            	// ObjectFilter.g:73:10: ( '\\r' | '\\n' )+
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
            			    // ObjectFilter.g:
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

    override public void mTokens() // throws RecognitionException 
    {
        // ObjectFilter.g:1:8: ( PLUS | TILDA | NE | EQ | HASH | MAIL | COMMA | ARROW | DOLLAR | NARROW | NDOLLAR | A_STRING | Q_STRING | I_STRING | WHITESPACE | ENDLINE )
        int alt6 = 16;
        alt6 = dfa6.Predict(input);
        switch (alt6) 
        {
            case 1 :
                // ObjectFilter.g:1:10: PLUS
                {
                	mPLUS(); 

                }
                break;
            case 2 :
                // ObjectFilter.g:1:15: TILDA
                {
                	mTILDA(); 

                }
                break;
            case 3 :
                // ObjectFilter.g:1:21: NE
                {
                	mNE(); 

                }
                break;
            case 4 :
                // ObjectFilter.g:1:24: EQ
                {
                	mEQ(); 

                }
                break;
            case 5 :
                // ObjectFilter.g:1:27: HASH
                {
                	mHASH(); 

                }
                break;
            case 6 :
                // ObjectFilter.g:1:32: MAIL
                {
                	mMAIL(); 

                }
                break;
            case 7 :
                // ObjectFilter.g:1:37: COMMA
                {
                	mCOMMA(); 

                }
                break;
            case 8 :
                // ObjectFilter.g:1:43: ARROW
                {
                	mARROW(); 

                }
                break;
            case 9 :
                // ObjectFilter.g:1:49: DOLLAR
                {
                	mDOLLAR(); 

                }
                break;
            case 10 :
                // ObjectFilter.g:1:56: NARROW
                {
                	mNARROW(); 

                }
                break;
            case 11 :
                // ObjectFilter.g:1:63: NDOLLAR
                {
                	mNDOLLAR(); 

                }
                break;
            case 12 :
                // ObjectFilter.g:1:71: A_STRING
                {
                	mA_STRING(); 

                }
                break;
            case 13 :
                // ObjectFilter.g:1:80: Q_STRING
                {
                	mQ_STRING(); 

                }
                break;
            case 14 :
                // ObjectFilter.g:1:89: I_STRING
                {
                	mI_STRING(); 

                }
                break;
            case 15 :
                // ObjectFilter.g:1:98: WHITESPACE
                {
                	mWHITESPACE(); 

                }
                break;
            case 16 :
                // ObjectFilter.g:1:109: ENDLINE
                {
                	mENDLINE(); 

                }
                break;

        }

    }


    protected DFA6 dfa6;
	private void InitializeCyclicDFAs()
	{
	    this.dfa6 = new DFA6(this);
	    this.dfa6.specialStateTransitionHandler = new DFA.SpecialStateTransitionHandler(DFA6_SpecialStateTransition);
	}

    const string DFA6_eotS =
        "\x01\x0e\x0a\uffff\x03\x0e\x05\uffff\x01\x0e\x01\x15\x01\uffff"+
        "\x01\x0e\x01\x18\x01\uffff\x02\x0e";
    const string DFA6_eofS =
        "\x1b\uffff";
    const string DFA6_minS =
        "\x01\x09\x09\uffff\x01\x24\x02\x00\x01\x09\x05\uffff\x02\x00\x01"+
        "\uffff\x02\x00\x01\uffff\x02\x00";
    const string DFA6_maxS =
        "\x01\x7e\x09\uffff\x01\x5e\x02\uffff\x01\x20\x05\uffff\x02\uffff"+
        "\x01\uffff\x02\uffff\x01\uffff\x02\uffff";
    const string DFA6_acceptS =
        "\x01\uffff\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06\x01"+
        "\x07\x01\x08\x01\x09\x04\uffff\x01\x0e\x01\x0f\x01\x10\x01\x0a\x01"+
        "\x0b\x02\uffff\x01\x0c\x02\uffff\x01\x0d\x02\uffff";
    const string DFA6_specialS =
        "\x0b\uffff\x01\x05\x01\x00\x06\uffff\x01\x02\x01\x06\x01\uffff"+
        "\x01\x03\x01\x07\x01\uffff\x01\x01\x01\x04}>";
    static readonly string[] DFA6_transitionS = {
            "\x01\x0d\x01\x10\x01\uffff\x01\x0d\x01\x10\x12\uffff\x01\x0f"+
            "\x01\x0a\x01\x0c\x01\x05\x01\x09\x02\uffff\x01\x0b\x03\uffff"+
            "\x01\x01\x01\x07\x0f\uffff\x01\x03\x01\x04\x02\uffff\x01\x06"+
            "\x1d\uffff\x01\x08\x1f\uffff\x01\x02",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\x12\x39\uffff\x01\x11",
            "\x0a\x13\x01\uffff\x02\x13\x01\uffff\x12\x13\x02\x15\x01\x13"+
            "\x02\x15\x02\x13\x01\x14\x02\x13\x03\x15\x0f\x13\x03\x15\x01"+
            "\x13\x01\x15\x1a\x13\x01\x15\x02\x13\x01\x15\x1f\x13\x01\x15"+
            "\uff81\x13",
            "\x0a\x16\x01\uffff\x02\x16\x01\uffff\x12\x16\x02\x18\x01\x17"+
            "\x02\x18\x05\x16\x03\x18\x0f\x16\x03\x18\x01\x16\x01\x18\x1a"+
            "\x16\x01\x18\x02\x16\x01\x18\x1f\x16\x01\x18\uff81\x16",
            "\x01\x0d\x02\uffff\x01\x0d\x13\uffff\x01\x0f",
            "",
            "",
            "",
            "",
            "",
            "\x0a\x13\x01\uffff\x02\x13\x01\uffff\x12\x13\x02\x15\x01\x13"+
            "\x02\x15\x02\x13\x01\x14\x02\x13\x03\x15\x0f\x13\x03\x15\x01"+
            "\x13\x01\x15\x1a\x13\x01\x15\x02\x13\x01\x15\x1f\x13\x01\x15"+
            "\uff81\x13",
            "\x0a\x0e\x01\uffff\x02\x0e\x01\uffff\x12\x0e\x02\uffff\x01"+
            "\x0e\x02\uffff\x02\x0e\x01\x19\x02\x0e\x03\uffff\x0f\x0e\x03"+
            "\uffff\x01\x0e\x01\uffff\x1a\x0e\x01\uffff\x02\x0e\x01\uffff"+
            "\x1f\x0e\x01\uffff\uff81\x0e",
            "",
            "\x0a\x16\x01\uffff\x02\x16\x01\uffff\x12\x16\x02\x18\x01\x17"+
            "\x02\x18\x05\x16\x03\x18\x0f\x16\x03\x18\x01\x16\x01\x18\x1a"+
            "\x16\x01\x18\x02\x16\x01\x18\x1f\x16\x01\x18\uff81\x16",
            "\x0a\x0e\x01\uffff\x02\x0e\x01\uffff\x12\x0e\x02\uffff\x01"+
            "\x1a\x02\uffff\x05\x0e\x03\uffff\x0f\x0e\x03\uffff\x01\x0e\x01"+
            "\uffff\x1a\x0e\x01\uffff\x02\x0e\x01\uffff\x1f\x0e\x01\uffff"+
            "\uff81\x0e",
            "",
            "\x0a\x13\x01\uffff\x02\x13\x01\uffff\x12\x13\x02\x15\x01\x13"+
            "\x02\x15\x02\x13\x01\x14\x02\x13\x03\x15\x0f\x13\x03\x15\x01"+
            "\x13\x01\x15\x1a\x13\x01\x15\x02\x13\x01\x15\x1f\x13\x01\x15"+
            "\uff81\x13",
            "\x0a\x16\x01\uffff\x02\x16\x01\uffff\x12\x16\x02\x18\x01\x17"+
            "\x02\x18\x05\x16\x03\x18\x0f\x16\x03\x18\x01\x16\x01\x18\x1a"+
            "\x16\x01\x18\x02\x16\x01\x18\x1f\x16\x01\x18\uff81\x16"
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
            get { return "1:1: Tokens : ( PLUS | TILDA | NE | EQ | HASH | MAIL | COMMA | ARROW | DOLLAR | NARROW | NDOLLAR | A_STRING | Q_STRING | I_STRING | WHITESPACE | ENDLINE );"; }
        }

    }


    protected internal int DFA6_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            IIntStream input = _input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA6_12 = input.LA(1);

                   	s = -1;
                   	if ( ((LA6_12 >= '\u0000' && LA6_12 <= '\t') || (LA6_12 >= '\u000B' && LA6_12 <= '\f') || (LA6_12 >= '\u000E' && LA6_12 <= '\u001F') || (LA6_12 >= '%' && LA6_12 <= ')') || (LA6_12 >= '-' && LA6_12 <= ';') || LA6_12 == '?' || (LA6_12 >= 'A' && LA6_12 <= 'Z') || (LA6_12 >= '\\' && LA6_12 <= ']') || (LA6_12 >= '_' && LA6_12 <= '}') || (LA6_12 >= '\u007F' && LA6_12 <= '\uFFFF')) ) { s = 22; }

                   	else if ( (LA6_12 == '\"') ) { s = 23; }

                   	else if ( ((LA6_12 >= ' ' && LA6_12 <= '!') || (LA6_12 >= '#' && LA6_12 <= '$') || (LA6_12 >= '*' && LA6_12 <= ',') || (LA6_12 >= '<' && LA6_12 <= '>') || LA6_12 == '@' || LA6_12 == '[' || LA6_12 == '^' || LA6_12 == '~') ) { s = 24; }

                   	else s = 14;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 1 : 
                   	int LA6_25 = input.LA(1);

                   	s = -1;
                   	if ( (LA6_25 == '\'') ) { s = 20; }

                   	else if ( ((LA6_25 >= '\u0000' && LA6_25 <= '\t') || (LA6_25 >= '\u000B' && LA6_25 <= '\f') || (LA6_25 >= '\u000E' && LA6_25 <= '\u001F') || LA6_25 == '\"' || (LA6_25 >= '%' && LA6_25 <= '&') || (LA6_25 >= '(' && LA6_25 <= ')') || (LA6_25 >= '-' && LA6_25 <= ';') || LA6_25 == '?' || (LA6_25 >= 'A' && LA6_25 <= 'Z') || (LA6_25 >= '\\' && LA6_25 <= ']') || (LA6_25 >= '_' && LA6_25 <= '}') || (LA6_25 >= '\u007F' && LA6_25 <= '\uFFFF')) ) { s = 19; }

                   	else if ( ((LA6_25 >= ' ' && LA6_25 <= '!') || (LA6_25 >= '#' && LA6_25 <= '$') || (LA6_25 >= '*' && LA6_25 <= ',') || (LA6_25 >= '<' && LA6_25 <= '>') || LA6_25 == '@' || LA6_25 == '[' || LA6_25 == '^' || LA6_25 == '~') ) { s = 21; }

                   	else s = 14;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 2 : 
                   	int LA6_19 = input.LA(1);

                   	s = -1;
                   	if ( (LA6_19 == '\'') ) { s = 20; }

                   	else if ( ((LA6_19 >= '\u0000' && LA6_19 <= '\t') || (LA6_19 >= '\u000B' && LA6_19 <= '\f') || (LA6_19 >= '\u000E' && LA6_19 <= '\u001F') || LA6_19 == '\"' || (LA6_19 >= '%' && LA6_19 <= '&') || (LA6_19 >= '(' && LA6_19 <= ')') || (LA6_19 >= '-' && LA6_19 <= ';') || LA6_19 == '?' || (LA6_19 >= 'A' && LA6_19 <= 'Z') || (LA6_19 >= '\\' && LA6_19 <= ']') || (LA6_19 >= '_' && LA6_19 <= '}') || (LA6_19 >= '\u007F' && LA6_19 <= '\uFFFF')) ) { s = 19; }

                   	else if ( ((LA6_19 >= ' ' && LA6_19 <= '!') || (LA6_19 >= '#' && LA6_19 <= '$') || (LA6_19 >= '*' && LA6_19 <= ',') || (LA6_19 >= '<' && LA6_19 <= '>') || LA6_19 == '@' || LA6_19 == '[' || LA6_19 == '^' || LA6_19 == '~') ) { s = 21; }

                   	else s = 14;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 3 : 
                   	int LA6_22 = input.LA(1);

                   	s = -1;
                   	if ( (LA6_22 == '\"') ) { s = 23; }

                   	else if ( ((LA6_22 >= '\u0000' && LA6_22 <= '\t') || (LA6_22 >= '\u000B' && LA6_22 <= '\f') || (LA6_22 >= '\u000E' && LA6_22 <= '\u001F') || (LA6_22 >= '%' && LA6_22 <= ')') || (LA6_22 >= '-' && LA6_22 <= ';') || LA6_22 == '?' || (LA6_22 >= 'A' && LA6_22 <= 'Z') || (LA6_22 >= '\\' && LA6_22 <= ']') || (LA6_22 >= '_' && LA6_22 <= '}') || (LA6_22 >= '\u007F' && LA6_22 <= '\uFFFF')) ) { s = 22; }

                   	else if ( ((LA6_22 >= ' ' && LA6_22 <= '!') || (LA6_22 >= '#' && LA6_22 <= '$') || (LA6_22 >= '*' && LA6_22 <= ',') || (LA6_22 >= '<' && LA6_22 <= '>') || LA6_22 == '@' || LA6_22 == '[' || LA6_22 == '^' || LA6_22 == '~') ) { s = 24; }

                   	else s = 14;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 4 : 
                   	int LA6_26 = input.LA(1);

                   	s = -1;
                   	if ( (LA6_26 == '\"') ) { s = 23; }

                   	else if ( ((LA6_26 >= '\u0000' && LA6_26 <= '\t') || (LA6_26 >= '\u000B' && LA6_26 <= '\f') || (LA6_26 >= '\u000E' && LA6_26 <= '\u001F') || (LA6_26 >= '%' && LA6_26 <= ')') || (LA6_26 >= '-' && LA6_26 <= ';') || LA6_26 == '?' || (LA6_26 >= 'A' && LA6_26 <= 'Z') || (LA6_26 >= '\\' && LA6_26 <= ']') || (LA6_26 >= '_' && LA6_26 <= '}') || (LA6_26 >= '\u007F' && LA6_26 <= '\uFFFF')) ) { s = 22; }

                   	else if ( ((LA6_26 >= ' ' && LA6_26 <= '!') || (LA6_26 >= '#' && LA6_26 <= '$') || (LA6_26 >= '*' && LA6_26 <= ',') || (LA6_26 >= '<' && LA6_26 <= '>') || LA6_26 == '@' || LA6_26 == '[' || LA6_26 == '^' || LA6_26 == '~') ) { s = 24; }

                   	else s = 14;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 5 : 
                   	int LA6_11 = input.LA(1);

                   	s = -1;
                   	if ( ((LA6_11 >= '\u0000' && LA6_11 <= '\t') || (LA6_11 >= '\u000B' && LA6_11 <= '\f') || (LA6_11 >= '\u000E' && LA6_11 <= '\u001F') || LA6_11 == '\"' || (LA6_11 >= '%' && LA6_11 <= '&') || (LA6_11 >= '(' && LA6_11 <= ')') || (LA6_11 >= '-' && LA6_11 <= ';') || LA6_11 == '?' || (LA6_11 >= 'A' && LA6_11 <= 'Z') || (LA6_11 >= '\\' && LA6_11 <= ']') || (LA6_11 >= '_' && LA6_11 <= '}') || (LA6_11 >= '\u007F' && LA6_11 <= '\uFFFF')) ) { s = 19; }

                   	else if ( (LA6_11 == '\'') ) { s = 20; }

                   	else if ( ((LA6_11 >= ' ' && LA6_11 <= '!') || (LA6_11 >= '#' && LA6_11 <= '$') || (LA6_11 >= '*' && LA6_11 <= ',') || (LA6_11 >= '<' && LA6_11 <= '>') || LA6_11 == '@' || LA6_11 == '[' || LA6_11 == '^' || LA6_11 == '~') ) { s = 21; }

                   	else s = 14;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 6 : 
                   	int LA6_20 = input.LA(1);

                   	s = -1;
                   	if ( (LA6_20 == '\'') ) { s = 25; }

                   	else if ( ((LA6_20 >= '\u0000' && LA6_20 <= '\t') || (LA6_20 >= '\u000B' && LA6_20 <= '\f') || (LA6_20 >= '\u000E' && LA6_20 <= '\u001F') || LA6_20 == '\"' || (LA6_20 >= '%' && LA6_20 <= '&') || (LA6_20 >= '(' && LA6_20 <= ')') || (LA6_20 >= '-' && LA6_20 <= ';') || LA6_20 == '?' || (LA6_20 >= 'A' && LA6_20 <= 'Z') || (LA6_20 >= '\\' && LA6_20 <= ']') || (LA6_20 >= '_' && LA6_20 <= '}') || (LA6_20 >= '\u007F' && LA6_20 <= '\uFFFF')) ) { s = 14; }

                   	else s = 21;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 7 : 
                   	int LA6_23 = input.LA(1);

                   	s = -1;
                   	if ( (LA6_23 == '\"') ) { s = 26; }

                   	else if ( ((LA6_23 >= '\u0000' && LA6_23 <= '\t') || (LA6_23 >= '\u000B' && LA6_23 <= '\f') || (LA6_23 >= '\u000E' && LA6_23 <= '\u001F') || (LA6_23 >= '%' && LA6_23 <= ')') || (LA6_23 >= '-' && LA6_23 <= ';') || LA6_23 == '?' || (LA6_23 >= 'A' && LA6_23 <= 'Z') || (LA6_23 >= '\\' && LA6_23 <= ']') || (LA6_23 >= '_' && LA6_23 <= '}') || (LA6_23 >= '\u007F' && LA6_23 <= '\uFFFF')) ) { s = 14; }

                   	else s = 24;

                   	if ( s >= 0 ) return s;
                   	break;
        }
        NoViableAltException nvae6 =
            new NoViableAltException(dfa.Description, 6, _s, input);
        dfa.Error(nvae6);
        throw nvae6;
    }
 
    
}
