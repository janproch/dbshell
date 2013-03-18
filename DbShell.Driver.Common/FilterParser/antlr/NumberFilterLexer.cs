// $ANTLR 3.2 Sep 23, 2009 12:02:23 NumberFilter.g 2013-03-18 23:38:56

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
    public const int GE = 9;
    public const int LT = 6;
    public const int COMMA = 12;
    public const int NUMBER = 5;
    public const int GT = 7;
    public const int WHITESPACE = 15;
    public const int ENDLINE = 13;
    public const int DIGIT = 14;
    public const int MINUS = 4;
    public const int EQ = 11;
    public const int EOF = -1;
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

    // $ANTLR start "MINUS"
    public void mMINUS() // throws RecognitionException [2]
    {
    		try
    		{
            int _type = MINUS;
    	int _channel = DEFAULT_TOKEN_CHANNEL;
            // NumberFilter.g:57:6: ( '-' )
            // NumberFilter.g:57:9: '-'
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
            // NumberFilter.g:58:3: ( '<' )
            // NumberFilter.g:58:6: '<'
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
            // NumberFilter.g:59:3: ( '>' )
            // NumberFilter.g:59:6: '>'
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
            // NumberFilter.g:60:3: ( '>=' )
            // NumberFilter.g:60:6: '>='
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
            // NumberFilter.g:61:3: ( '<=' )
            // NumberFilter.g:61:6: '<='
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
            // NumberFilter.g:62:3: ( '!=' | '<>' )
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
                    // NumberFilter.g:62:6: '!='
                    {
                    	Match("!="); 


                    }
                    break;
                case 2 :
                    // NumberFilter.g:62:13: '<>'
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
            // NumberFilter.g:63:3: ( '=' )
            // NumberFilter.g:63:6: '='
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
            // NumberFilter.g:64:6: ( ',' )
            // NumberFilter.g:64:8: ','
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
            // NumberFilter.g:66:9: ( ( DIGIT )+ ( '.' ( DIGIT )+ )? )
            // NumberFilter.g:66:11: ( DIGIT )+ ( '.' ( DIGIT )+ )?
            {
            	// NumberFilter.g:66:11: ( DIGIT )+
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
            			    // NumberFilter.g:66:12: DIGIT
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

            	// NumberFilter.g:66:20: ( '.' ( DIGIT )+ )?
            	int alt4 = 2;
            	int LA4_0 = input.LA(1);

            	if ( (LA4_0 == '.') )
            	{
            	    alt4 = 1;
            	}
            	switch (alt4) 
            	{
            	    case 1 :
            	        // NumberFilter.g:66:21: '.' ( DIGIT )+
            	        {
            	        	Match('.'); 
            	        	// NumberFilter.g:66:25: ( DIGIT )+
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
            	        			    // NumberFilter.g:66:26: DIGIT
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
            // NumberFilter.g:68:12: ( ( '\\t' | ' ' | '\\u000C' )+ )
            // NumberFilter.g:68:14: ( '\\t' | ' ' | '\\u000C' )+
            {
            	// NumberFilter.g:68:14: ( '\\t' | ' ' | '\\u000C' )+
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
            // NumberFilter.g:69:8: ( ( '\\r' | '\\n' )+ )
            // NumberFilter.g:69:10: ( '\\r' | '\\n' )+
            {
            	// NumberFilter.g:69:10: ( '\\r' | '\\n' )+
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
            // NumberFilter.g:71:17: ( '0' .. '9' )
            // NumberFilter.g:71:19: '0' .. '9'
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
        // NumberFilter.g:1:8: ( MINUS | LT | GT | GE | LE | NE | EQ | COMMA | NUMBER | WHITESPACE | ENDLINE )
        int alt7 = 11;
        alt7 = dfa7.Predict(input);
        switch (alt7) 
        {
            case 1 :
                // NumberFilter.g:1:10: MINUS
                {
                	mMINUS(); 

                }
                break;
            case 2 :
                // NumberFilter.g:1:16: LT
                {
                	mLT(); 

                }
                break;
            case 3 :
                // NumberFilter.g:1:19: GT
                {
                	mGT(); 

                }
                break;
            case 4 :
                // NumberFilter.g:1:22: GE
                {
                	mGE(); 

                }
                break;
            case 5 :
                // NumberFilter.g:1:25: LE
                {
                	mLE(); 

                }
                break;
            case 6 :
                // NumberFilter.g:1:28: NE
                {
                	mNE(); 

                }
                break;
            case 7 :
                // NumberFilter.g:1:31: EQ
                {
                	mEQ(); 

                }
                break;
            case 8 :
                // NumberFilter.g:1:34: COMMA
                {
                	mCOMMA(); 

                }
                break;
            case 9 :
                // NumberFilter.g:1:40: NUMBER
                {
                	mNUMBER(); 

                }
                break;
            case 10 :
                // NumberFilter.g:1:47: WHITESPACE
                {
                	mWHITESPACE(); 

                }
                break;
            case 11 :
                // NumberFilter.g:1:58: ENDLINE
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
        "\x02\uffff\x01\x0b\x01\x0d\x0a\uffff";
    const string DFA7_eofS =
        "\x0e\uffff";
    const string DFA7_minS =
        "\x01\x09\x01\uffff\x02\x3d\x0a\uffff";
    const string DFA7_maxS =
        "\x01\x3e\x01\uffff\x01\x3e\x01\x3d\x0a\uffff";
    const string DFA7_acceptS =
        "\x01\uffff\x01\x01\x02\uffff\x01\x06\x01\x07\x01\x08\x01\x09\x01"+
        "\x0a\x01\x0b\x01\x05\x01\x02\x01\x04\x01\x03";
    const string DFA7_specialS =
        "\x0e\uffff}>";
    static readonly string[] DFA7_transitionS = {
            "\x01\x08\x01\x09\x01\uffff\x01\x08\x01\x09\x12\uffff\x01\x08"+
            "\x01\x04\x0a\uffff\x01\x06\x01\x01\x02\uffff\x0a\x07\x02\uffff"+
            "\x01\x02\x01\x05\x01\x03",
            "",
            "\x01\x0a\x01\x04",
            "\x01\x0c",
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
            get { return "1:1: Tokens : ( MINUS | LT | GT | GE | LE | NE | EQ | COMMA | NUMBER | WHITESPACE | ENDLINE );"; }
        }

    }

 
    
}
