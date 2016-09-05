// $ANTLR 3.2 Sep 23, 2009 12:02:23 ObjectFilter.g 2016-09-05 21:10:04

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
    public const int DOLLAR = 10;
    public const int TILDA = 7;
    public const int I_STRING = 6;
    public const int NDOLLAR = 11;
    public const int COMMA = 16;
    public const int MAIL = 15;
    public const int HASH = 14;
    public const int A_STRING = 5;
    public const int ARROW = 8;
    public const int WHITESPACE = 18;
    public const int ENDLINE = 17;
    public const int EQ = 12;
    public const int EOF = -1;
    public const int NARROW = 9;
    public const int Q_STRING = 4;
    public const int NE = 13;

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

    // $ANTLR start "TILDA"
    public void mTILDA() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = TILDA;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // ObjectFilter.g:41:6: ( '~' )
            // ObjectFilter.g:41:9: '~'
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
            // ObjectFilter.g:42:3: ( '<>' )
            // ObjectFilter.g:42:6: '<>'
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
            // ObjectFilter.g:43:3: ( '=' )
            // ObjectFilter.g:43:6: '='
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
            // ObjectFilter.g:44:5: ( '#' )
            // ObjectFilter.g:44:7: '#'
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
            // ObjectFilter.g:45:5: ( '@' )
            // ObjectFilter.g:45:7: '@'
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
            // ObjectFilter.g:46:6: ( ',' )
            // ObjectFilter.g:46:8: ','
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
            // ObjectFilter.g:47:6: ( '^' )
            // ObjectFilter.g:47:9: '^'
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
            // ObjectFilter.g:48:7: ( '$' )
            // ObjectFilter.g:48:10: '$'
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
            // ObjectFilter.g:49:7: ( '!^' )
            // ObjectFilter.g:49:10: '!^'
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
            // ObjectFilter.g:50:8: ( '!$' )
            // ObjectFilter.g:50:11: '!$'
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
            // ObjectFilter.g:52:9: ( ( '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\'' ) )
            // ObjectFilter.g:53:4: ( '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\'' )
            {
            	// ObjectFilter.g:53:4: ( '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\'' )
            	// ObjectFilter.g:53:5: '\\'' ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )* '\\''
            	{
            		Match('\''); 
            		// ObjectFilter.g:54:5: ( options {greedy=true; } : ~ ( '\\'' | '\\r' | '\\n' ) | '\\'' '\\'' )*
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
            				    // ObjectFilter.g:55:31: ~ ( '\\'' | '\\r' | '\\n' )
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
            				    // ObjectFilter.g:55:56: '\\'' '\\''
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
            // ObjectFilter.g:60:9: ( ( '\\\"' ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )* '\\\"' ) )
            // ObjectFilter.g:61:4: ( '\\\"' ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )* '\\\"' )
            {
            	// ObjectFilter.g:61:4: ( '\\\"' ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )* '\\\"' )
            	// ObjectFilter.g:61:5: '\\\"' ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )* '\\\"'
            	{
            		Match('\"'); 
            		// ObjectFilter.g:62:5: ( options {greedy=true; } : ~ ( '\\\"' | '\\r' | '\\n' ) | '\\\"' '\\\"' )*
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
            				    // ObjectFilter.g:63:31: ~ ( '\\\"' | '\\r' | '\\n' )
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
            				    // ObjectFilter.g:63:56: '\\\"' '\\\"'
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
            // ObjectFilter.g:68:9: ( (~ ( '[' | '~' | ' ' | '<' | '>' | '=' | '!' | '\\r' | '\\n' | '^' | '$' | '*' | ',' | '+' | '#' | '@' ) )* )
            // ObjectFilter.g:68:11: (~ ( '[' | '~' | ' ' | '<' | '>' | '=' | '!' | '\\r' | '\\n' | '^' | '$' | '*' | ',' | '+' | '#' | '@' ) )*
            {
            	// ObjectFilter.g:68:11: (~ ( '[' | '~' | ' ' | '<' | '>' | '=' | '!' | '\\r' | '\\n' | '^' | '$' | '*' | ',' | '+' | '#' | '@' ) )*
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
            			    // ObjectFilter.g:68:12: ~ ( '[' | '~' | ' ' | '<' | '>' | '=' | '!' | '\\r' | '\\n' | '^' | '$' | '*' | ',' | '+' | '#' | '@' )
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
            // ObjectFilter.g:70:12: ( ( '\\t' | ' ' | '\\u000C' )+ )
            // ObjectFilter.g:70:14: ( '\\t' | ' ' | '\\u000C' )+
            {
            	// ObjectFilter.g:70:14: ( '\\t' | ' ' | '\\u000C' )+
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
            // ObjectFilter.g:71:8: ( ( '\\r' | '\\n' )+ )
            // ObjectFilter.g:71:10: ( '\\r' | '\\n' )+
            {
            	// ObjectFilter.g:71:10: ( '\\r' | '\\n' )+
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
        // ObjectFilter.g:1:8: ( TILDA | NE | EQ | HASH | MAIL | COMMA | ARROW | DOLLAR | NARROW | NDOLLAR | A_STRING | Q_STRING | I_STRING | WHITESPACE | ENDLINE )
        int alt6 = 15;
        alt6 = dfa6.Predict(input);
        switch (alt6) 
        {
            case 1 :
                // ObjectFilter.g:1:10: TILDA
                {
                	mTILDA(); 

                }
                break;
            case 2 :
                // ObjectFilter.g:1:16: NE
                {
                	mNE(); 

                }
                break;
            case 3 :
                // ObjectFilter.g:1:19: EQ
                {
                	mEQ(); 

                }
                break;
            case 4 :
                // ObjectFilter.g:1:22: HASH
                {
                	mHASH(); 

                }
                break;
            case 5 :
                // ObjectFilter.g:1:27: MAIL
                {
                	mMAIL(); 

                }
                break;
            case 6 :
                // ObjectFilter.g:1:32: COMMA
                {
                	mCOMMA(); 

                }
                break;
            case 7 :
                // ObjectFilter.g:1:38: ARROW
                {
                	mARROW(); 

                }
                break;
            case 8 :
                // ObjectFilter.g:1:44: DOLLAR
                {
                	mDOLLAR(); 

                }
                break;
            case 9 :
                // ObjectFilter.g:1:51: NARROW
                {
                	mNARROW(); 

                }
                break;
            case 10 :
                // ObjectFilter.g:1:58: NDOLLAR
                {
                	mNDOLLAR(); 

                }
                break;
            case 11 :
                // ObjectFilter.g:1:66: A_STRING
                {
                	mA_STRING(); 

                }
                break;
            case 12 :
                // ObjectFilter.g:1:75: Q_STRING
                {
                	mQ_STRING(); 

                }
                break;
            case 13 :
                // ObjectFilter.g:1:84: I_STRING
                {
                	mI_STRING(); 

                }
                break;
            case 14 :
                // ObjectFilter.g:1:93: WHITESPACE
                {
                	mWHITESPACE(); 

                }
                break;
            case 15 :
                // ObjectFilter.g:1:104: ENDLINE
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
        "\x01\x0d\x09\uffff\x03\x0d\x05\uffff\x01\x0d\x01\x14\x01\uffff"+
        "\x01\x0d\x01\x17\x01\uffff\x02\x0d";
    const string DFA6_eofS =
        "\x1a\uffff";
    const string DFA6_minS =
        "\x01\x09\x08\uffff\x01\x24\x02\x00\x01\x09\x05\uffff\x02\x00\x01"+
        "\uffff\x02\x00\x01\uffff\x02\x00";
    const string DFA6_maxS =
        "\x01\x7e\x08\uffff\x01\x5e\x02\uffff\x01\x20\x05\uffff\x02\uffff"+
        "\x01\uffff\x02\uffff\x01\uffff\x02\uffff";
    const string DFA6_acceptS =
        "\x01\uffff\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06\x01"+
        "\x07\x01\x08\x04\uffff\x01\x0d\x01\x0e\x01\x0f\x01\x09\x01\x0a\x02"+
        "\uffff\x01\x0b\x02\uffff\x01\x0c\x02\uffff";
    const string DFA6_specialS =
        "\x0a\uffff\x01\x01\x01\x07\x06\uffff\x01\x00\x01\x02\x01\uffff"+
        "\x01\x03\x01\x05\x01\uffff\x01\x06\x01\x04}>";
    static readonly string[] DFA6_transitionS = {
            "\x01\x0c\x01\x0f\x01\uffff\x01\x0c\x01\x0f\x12\uffff\x01\x0e"+
            "\x01\x09\x01\x0b\x01\x04\x01\x08\x02\uffff\x01\x0a\x04\uffff"+
            "\x01\x06\x0f\uffff\x01\x02\x01\x03\x02\uffff\x01\x05\x1d\uffff"+
            "\x01\x07\x1f\uffff\x01\x01",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\x11\x39\uffff\x01\x10",
            "\x0a\x12\x01\uffff\x02\x12\x01\uffff\x12\x12\x02\x14\x01\x12"+
            "\x02\x14\x02\x12\x01\x13\x02\x12\x03\x14\x0f\x12\x03\x14\x01"+
            "\x12\x01\x14\x1a\x12\x01\x14\x02\x12\x01\x14\x1f\x12\x01\x14"+
            "\uff81\x12",
            "\x0a\x15\x01\uffff\x02\x15\x01\uffff\x12\x15\x02\x17\x01\x16"+
            "\x02\x17\x05\x15\x03\x17\x0f\x15\x03\x17\x01\x15\x01\x17\x1a"+
            "\x15\x01\x17\x02\x15\x01\x17\x1f\x15\x01\x17\uff81\x15",
            "\x01\x0c\x02\uffff\x01\x0c\x13\uffff\x01\x0e",
            "",
            "",
            "",
            "",
            "",
            "\x0a\x12\x01\uffff\x02\x12\x01\uffff\x12\x12\x02\x14\x01\x12"+
            "\x02\x14\x02\x12\x01\x13\x02\x12\x03\x14\x0f\x12\x03\x14\x01"+
            "\x12\x01\x14\x1a\x12\x01\x14\x02\x12\x01\x14\x1f\x12\x01\x14"+
            "\uff81\x12",
            "\x0a\x0d\x01\uffff\x02\x0d\x01\uffff\x12\x0d\x02\uffff\x01"+
            "\x0d\x02\uffff\x02\x0d\x01\x18\x02\x0d\x03\uffff\x0f\x0d\x03"+
            "\uffff\x01\x0d\x01\uffff\x1a\x0d\x01\uffff\x02\x0d\x01\uffff"+
            "\x1f\x0d\x01\uffff\uff81\x0d",
            "",
            "\x0a\x15\x01\uffff\x02\x15\x01\uffff\x12\x15\x02\x17\x01\x16"+
            "\x02\x17\x05\x15\x03\x17\x0f\x15\x03\x17\x01\x15\x01\x17\x1a"+
            "\x15\x01\x17\x02\x15\x01\x17\x1f\x15\x01\x17\uff81\x15",
            "\x0a\x0d\x01\uffff\x02\x0d\x01\uffff\x12\x0d\x02\uffff\x01"+
            "\x19\x02\uffff\x05\x0d\x03\uffff\x0f\x0d\x03\uffff\x01\x0d\x01"+
            "\uffff\x1a\x0d\x01\uffff\x02\x0d\x01\uffff\x1f\x0d\x01\uffff"+
            "\uff81\x0d",
            "",
            "\x0a\x12\x01\uffff\x02\x12\x01\uffff\x12\x12\x02\x14\x01\x12"+
            "\x02\x14\x02\x12\x01\x13\x02\x12\x03\x14\x0f\x12\x03\x14\x01"+
            "\x12\x01\x14\x1a\x12\x01\x14\x02\x12\x01\x14\x1f\x12\x01\x14"+
            "\uff81\x12",
            "\x0a\x15\x01\uffff\x02\x15\x01\uffff\x12\x15\x02\x17\x01\x16"+
            "\x02\x17\x05\x15\x03\x17\x0f\x15\x03\x17\x01\x15\x01\x17\x1a"+
            "\x15\x01\x17\x02\x15\x01\x17\x1f\x15\x01\x17\uff81\x15"
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
            get { return "1:1: Tokens : ( TILDA | NE | EQ | HASH | MAIL | COMMA | ARROW | DOLLAR | NARROW | NDOLLAR | A_STRING | Q_STRING | I_STRING | WHITESPACE | ENDLINE );"; }
        }

    }


    protected internal int DFA6_SpecialStateTransition(DFA dfa, int s, IIntStream _input) //throws NoViableAltException
    {
            IIntStream input = _input;
    	int _s = s;
        switch ( s )
        {
               	case 0 : 
                   	int LA6_18 = input.LA(1);

                   	s = -1;
                   	if ( (LA6_18 == '\'') ) { s = 19; }

                   	else if ( ((LA6_18 >= '\u0000' && LA6_18 <= '\t') || (LA6_18 >= '\u000B' && LA6_18 <= '\f') || (LA6_18 >= '\u000E' && LA6_18 <= '\u001F') || LA6_18 == '\"' || (LA6_18 >= '%' && LA6_18 <= '&') || (LA6_18 >= '(' && LA6_18 <= ')') || (LA6_18 >= '-' && LA6_18 <= ';') || LA6_18 == '?' || (LA6_18 >= 'A' && LA6_18 <= 'Z') || (LA6_18 >= '\\' && LA6_18 <= ']') || (LA6_18 >= '_' && LA6_18 <= '}') || (LA6_18 >= '\u007F' && LA6_18 <= '\uFFFF')) ) { s = 18; }

                   	else if ( ((LA6_18 >= ' ' && LA6_18 <= '!') || (LA6_18 >= '#' && LA6_18 <= '$') || (LA6_18 >= '*' && LA6_18 <= ',') || (LA6_18 >= '<' && LA6_18 <= '>') || LA6_18 == '@' || LA6_18 == '[' || LA6_18 == '^' || LA6_18 == '~') ) { s = 20; }

                   	else s = 13;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 1 : 
                   	int LA6_10 = input.LA(1);

                   	s = -1;
                   	if ( ((LA6_10 >= '\u0000' && LA6_10 <= '\t') || (LA6_10 >= '\u000B' && LA6_10 <= '\f') || (LA6_10 >= '\u000E' && LA6_10 <= '\u001F') || LA6_10 == '\"' || (LA6_10 >= '%' && LA6_10 <= '&') || (LA6_10 >= '(' && LA6_10 <= ')') || (LA6_10 >= '-' && LA6_10 <= ';') || LA6_10 == '?' || (LA6_10 >= 'A' && LA6_10 <= 'Z') || (LA6_10 >= '\\' && LA6_10 <= ']') || (LA6_10 >= '_' && LA6_10 <= '}') || (LA6_10 >= '\u007F' && LA6_10 <= '\uFFFF')) ) { s = 18; }

                   	else if ( (LA6_10 == '\'') ) { s = 19; }

                   	else if ( ((LA6_10 >= ' ' && LA6_10 <= '!') || (LA6_10 >= '#' && LA6_10 <= '$') || (LA6_10 >= '*' && LA6_10 <= ',') || (LA6_10 >= '<' && LA6_10 <= '>') || LA6_10 == '@' || LA6_10 == '[' || LA6_10 == '^' || LA6_10 == '~') ) { s = 20; }

                   	else s = 13;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 2 : 
                   	int LA6_19 = input.LA(1);

                   	s = -1;
                   	if ( (LA6_19 == '\'') ) { s = 24; }

                   	else if ( ((LA6_19 >= '\u0000' && LA6_19 <= '\t') || (LA6_19 >= '\u000B' && LA6_19 <= '\f') || (LA6_19 >= '\u000E' && LA6_19 <= '\u001F') || LA6_19 == '\"' || (LA6_19 >= '%' && LA6_19 <= '&') || (LA6_19 >= '(' && LA6_19 <= ')') || (LA6_19 >= '-' && LA6_19 <= ';') || LA6_19 == '?' || (LA6_19 >= 'A' && LA6_19 <= 'Z') || (LA6_19 >= '\\' && LA6_19 <= ']') || (LA6_19 >= '_' && LA6_19 <= '}') || (LA6_19 >= '\u007F' && LA6_19 <= '\uFFFF')) ) { s = 13; }

                   	else s = 20;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 3 : 
                   	int LA6_21 = input.LA(1);

                   	s = -1;
                   	if ( (LA6_21 == '\"') ) { s = 22; }

                   	else if ( ((LA6_21 >= '\u0000' && LA6_21 <= '\t') || (LA6_21 >= '\u000B' && LA6_21 <= '\f') || (LA6_21 >= '\u000E' && LA6_21 <= '\u001F') || (LA6_21 >= '%' && LA6_21 <= ')') || (LA6_21 >= '-' && LA6_21 <= ';') || LA6_21 == '?' || (LA6_21 >= 'A' && LA6_21 <= 'Z') || (LA6_21 >= '\\' && LA6_21 <= ']') || (LA6_21 >= '_' && LA6_21 <= '}') || (LA6_21 >= '\u007F' && LA6_21 <= '\uFFFF')) ) { s = 21; }

                   	else if ( ((LA6_21 >= ' ' && LA6_21 <= '!') || (LA6_21 >= '#' && LA6_21 <= '$') || (LA6_21 >= '*' && LA6_21 <= ',') || (LA6_21 >= '<' && LA6_21 <= '>') || LA6_21 == '@' || LA6_21 == '[' || LA6_21 == '^' || LA6_21 == '~') ) { s = 23; }

                   	else s = 13;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 4 : 
                   	int LA6_25 = input.LA(1);

                   	s = -1;
                   	if ( (LA6_25 == '\"') ) { s = 22; }

                   	else if ( ((LA6_25 >= '\u0000' && LA6_25 <= '\t') || (LA6_25 >= '\u000B' && LA6_25 <= '\f') || (LA6_25 >= '\u000E' && LA6_25 <= '\u001F') || (LA6_25 >= '%' && LA6_25 <= ')') || (LA6_25 >= '-' && LA6_25 <= ';') || LA6_25 == '?' || (LA6_25 >= 'A' && LA6_25 <= 'Z') || (LA6_25 >= '\\' && LA6_25 <= ']') || (LA6_25 >= '_' && LA6_25 <= '}') || (LA6_25 >= '\u007F' && LA6_25 <= '\uFFFF')) ) { s = 21; }

                   	else if ( ((LA6_25 >= ' ' && LA6_25 <= '!') || (LA6_25 >= '#' && LA6_25 <= '$') || (LA6_25 >= '*' && LA6_25 <= ',') || (LA6_25 >= '<' && LA6_25 <= '>') || LA6_25 == '@' || LA6_25 == '[' || LA6_25 == '^' || LA6_25 == '~') ) { s = 23; }

                   	else s = 13;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 5 : 
                   	int LA6_22 = input.LA(1);

                   	s = -1;
                   	if ( (LA6_22 == '\"') ) { s = 25; }

                   	else if ( ((LA6_22 >= '\u0000' && LA6_22 <= '\t') || (LA6_22 >= '\u000B' && LA6_22 <= '\f') || (LA6_22 >= '\u000E' && LA6_22 <= '\u001F') || (LA6_22 >= '%' && LA6_22 <= ')') || (LA6_22 >= '-' && LA6_22 <= ';') || LA6_22 == '?' || (LA6_22 >= 'A' && LA6_22 <= 'Z') || (LA6_22 >= '\\' && LA6_22 <= ']') || (LA6_22 >= '_' && LA6_22 <= '}') || (LA6_22 >= '\u007F' && LA6_22 <= '\uFFFF')) ) { s = 13; }

                   	else s = 23;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 6 : 
                   	int LA6_24 = input.LA(1);

                   	s = -1;
                   	if ( (LA6_24 == '\'') ) { s = 19; }

                   	else if ( ((LA6_24 >= '\u0000' && LA6_24 <= '\t') || (LA6_24 >= '\u000B' && LA6_24 <= '\f') || (LA6_24 >= '\u000E' && LA6_24 <= '\u001F') || LA6_24 == '\"' || (LA6_24 >= '%' && LA6_24 <= '&') || (LA6_24 >= '(' && LA6_24 <= ')') || (LA6_24 >= '-' && LA6_24 <= ';') || LA6_24 == '?' || (LA6_24 >= 'A' && LA6_24 <= 'Z') || (LA6_24 >= '\\' && LA6_24 <= ']') || (LA6_24 >= '_' && LA6_24 <= '}') || (LA6_24 >= '\u007F' && LA6_24 <= '\uFFFF')) ) { s = 18; }

                   	else if ( ((LA6_24 >= ' ' && LA6_24 <= '!') || (LA6_24 >= '#' && LA6_24 <= '$') || (LA6_24 >= '*' && LA6_24 <= ',') || (LA6_24 >= '<' && LA6_24 <= '>') || LA6_24 == '@' || LA6_24 == '[' || LA6_24 == '^' || LA6_24 == '~') ) { s = 20; }

                   	else s = 13;

                   	if ( s >= 0 ) return s;
                   	break;
               	case 7 : 
                   	int LA6_11 = input.LA(1);

                   	s = -1;
                   	if ( ((LA6_11 >= '\u0000' && LA6_11 <= '\t') || (LA6_11 >= '\u000B' && LA6_11 <= '\f') || (LA6_11 >= '\u000E' && LA6_11 <= '\u001F') || (LA6_11 >= '%' && LA6_11 <= ')') || (LA6_11 >= '-' && LA6_11 <= ';') || LA6_11 == '?' || (LA6_11 >= 'A' && LA6_11 <= 'Z') || (LA6_11 >= '\\' && LA6_11 <= ']') || (LA6_11 >= '_' && LA6_11 <= '}') || (LA6_11 >= '\u007F' && LA6_11 <= '\uFFFF')) ) { s = 21; }

                   	else if ( (LA6_11 == '\"') ) { s = 22; }

                   	else if ( ((LA6_11 >= ' ' && LA6_11 <= '!') || (LA6_11 >= '#' && LA6_11 <= '$') || (LA6_11 >= '*' && LA6_11 <= ',') || (LA6_11 >= '<' && LA6_11 <= '>') || LA6_11 == '@' || LA6_11 == '[' || LA6_11 == '^' || LA6_11 == '~') ) { s = 23; }

                   	else s = 13;

                   	if ( s >= 0 ) return s;
                   	break;
        }
        NoViableAltException nvae6 =
            new NoViableAltException(dfa.Description, 6, _s, input);
        dfa.Error(nvae6);
        throw nvae6;
    }
 
    
}
