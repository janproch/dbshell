// $ANTLR 3.2 Sep 23, 2009 12:02:23 NumberFilter.g 2015-01-03 12:47:22

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162


  using DbShell.Driver.Common.DmlFramework;
using System.Globalization;


using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;



using Antlr.Runtime.Tree;

public partial class NumberFilterParser : DbShellFilterAntlrParser
{
    public static readonly string[] tokenNames = new string[] 
	{
        "<invalid>", 
		"<EOR>", 
		"<DOWN>", 
		"<UP>", 
		"MINUS", 
		"NUMBER", 
		"Q_STRING", 
		"A_STRING", 
		"SQL_LITERAL", 
		"DOT", 
		"LT", 
		"GT", 
		"LE", 
		"GE", 
		"NE", 
		"EQ", 
		"T_NULL", 
		"T_NOT", 
		"EQ2", 
		"NE2", 
		"COMMA", 
		"ENDLINE", 
		"N", 
		"U", 
		"L", 
		"O", 
		"T", 
		"DIGIT", 
		"WHITESPACE", 
		"A", 
		"B", 
		"C", 
		"D", 
		"E", 
		"F", 
		"G", 
		"H", 
		"I", 
		"J", 
		"K", 
		"M", 
		"P", 
		"Q", 
		"R", 
		"S", 
		"V", 
		"W", 
		"X", 
		"Y", 
		"Z"
    };

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
    public const int GE = 13;
    public const int F = 34;
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
    public const int X = 47;
    public const int EQ2 = 18;
    public const int SQL_LITERAL = 8;
    public const int Z = 49;
    public const int A_STRING = 7;
    public const int GT = 11;
    public const int ENDLINE = 21;
    public const int T_NOT = 17;
    public const int LE = 12;

    // delegates
    // delegators



        public NumberFilterParser(ITokenStream input)
    		: this(input, new RecognizerSharedState()) {
        }

        public NumberFilterParser(ITokenStream input, RecognizerSharedState state)
    		: base(input, state) {
            InitializeCyclicDFAs();

             
        }
        
    protected ITreeAdaptor adaptor = new CommonTreeAdaptor();

    public ITreeAdaptor TreeAdaptor
    {
        get { return this.adaptor; }
        set {
    	this.adaptor = value;
    	}
    }

    override public string[] TokenNames {
		get { return NumberFilterParser.tokenNames; }
    }

    override public string GrammarFileName {
		get { return "NumberFilter.g"; }
    }


    public class negative_number_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "negative_number"
    // NumberFilter.g:14:1: negative_number : MINUS num1= NUMBER ;
    public NumberFilterParser.negative_number_return negative_number() // throws RecognitionException [1]
    {   
        NumberFilterParser.negative_number_return retval = new NumberFilterParser.negative_number_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken num1 = null;
        IToken MINUS1 = null;

        object num1_tree=null;
        object MINUS1_tree=null;

        try 
    	{
            // NumberFilter.g:14:16: ( MINUS num1= NUMBER )
            // NumberFilter.g:15:3: MINUS num1= NUMBER
            {
            	root_0 = (object)adaptor.GetNilNode();

            	MINUS1=(IToken)Match(input,MINUS,FOLLOW_MINUS_in_negative_number43); 
            		MINUS1_tree = (object)adaptor.Create(MINUS1);
            		adaptor.AddChild(root_0, MINUS1_tree);

            	num1=(IToken)Match(input,NUMBER,FOLLOW_NUMBER_in_negative_number47); 
            		num1_tree = (object)adaptor.Create(num1);
            		adaptor.AddChild(root_0, num1_tree);

            	 Push(-Decimal.Parse(((num1 != null) ? num1.Text : null), CultureInfo.InvariantCulture)); 

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "negative_number"

    public class positive_number_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "positive_number"
    // NumberFilter.g:17:1: positive_number : num1= NUMBER ;
    public NumberFilterParser.positive_number_return positive_number() // throws RecognitionException [1]
    {   
        NumberFilterParser.positive_number_return retval = new NumberFilterParser.positive_number_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken num1 = null;

        object num1_tree=null;

        try 
    	{
            // NumberFilter.g:17:16: (num1= NUMBER )
            // NumberFilter.g:18:3: num1= NUMBER
            {
            	root_0 = (object)adaptor.GetNilNode();

            	num1=(IToken)Match(input,NUMBER,FOLLOW_NUMBER_in_positive_number63); 
            		num1_tree = (object)adaptor.Create(num1);
            		adaptor.AddChild(root_0, num1_tree);

            	 Push(Decimal.Parse(((num1 != null) ? num1.Text : null), CultureInfo.InvariantCulture)); 

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "positive_number"

    public class number_as_string_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "number_as_string"
    // NumberFilter.g:20:1: number_as_string : (num1= Q_STRING | num1= A_STRING ) ;
    public NumberFilterParser.number_as_string_return number_as_string() // throws RecognitionException [1]
    {   
        NumberFilterParser.number_as_string_return retval = new NumberFilterParser.number_as_string_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken num1 = null;

        object num1_tree=null;

        try 
    	{
            // NumberFilter.g:20:17: ( (num1= Q_STRING | num1= A_STRING ) )
            // NumberFilter.g:21:3: (num1= Q_STRING | num1= A_STRING )
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// NumberFilter.g:21:3: (num1= Q_STRING | num1= A_STRING )
            	int alt1 = 2;
            	int LA1_0 = input.LA(1);

            	if ( (LA1_0 == Q_STRING) )
            	{
            	    alt1 = 1;
            	}
            	else if ( (LA1_0 == A_STRING) )
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
            	        // NumberFilter.g:21:4: num1= Q_STRING
            	        {
            	        	num1=(IToken)Match(input,Q_STRING,FOLLOW_Q_STRING_in_number_as_string81); 
            	        		num1_tree = (object)adaptor.Create(num1);
            	        		adaptor.AddChild(root_0, num1_tree);


            	        }
            	        break;
            	    case 2 :
            	        // NumberFilter.g:21:20: num1= A_STRING
            	        {
            	        	num1=(IToken)Match(input,A_STRING,FOLLOW_A_STRING_in_number_as_string87); 
            	        		num1_tree = (object)adaptor.Create(num1);
            	        		adaptor.AddChild(root_0, num1_tree);


            	        }
            	        break;

            	}

            	 string value=((num1 != null) ? num1.Text : null); Push(Decimal.Parse(value.Substring(1, value.Length - 2), CultureInfo.InvariantCulture)); 

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "number_as_string"

    public class number_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "number"
    // NumberFilter.g:23:1: number : ( positive_number | negative_number | number_as_string );
    public NumberFilterParser.number_return number() // throws RecognitionException [1]
    {   
        NumberFilterParser.number_return retval = new NumberFilterParser.number_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        NumberFilterParser.positive_number_return positive_number2 = default(NumberFilterParser.positive_number_return);

        NumberFilterParser.negative_number_return negative_number3 = default(NumberFilterParser.negative_number_return);

        NumberFilterParser.number_as_string_return number_as_string4 = default(NumberFilterParser.number_as_string_return);



        try 
    	{
            // NumberFilter.g:23:7: ( positive_number | negative_number | number_as_string )
            int alt2 = 3;
            switch ( input.LA(1) ) 
            {
            case NUMBER:
            	{
                alt2 = 1;
                }
                break;
            case MINUS:
            	{
                alt2 = 2;
                }
                break;
            case Q_STRING:
            case A_STRING:
            	{
                alt2 = 3;
                }
                break;
            	default:
            	    NoViableAltException nvae_d2s0 =
            	        new NoViableAltException("", 2, 0, input);

            	    throw nvae_d2s0;
            }

            switch (alt2) 
            {
                case 1 :
                    // NumberFilter.g:24:3: positive_number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_positive_number_in_number101);
                    	positive_number2 = positive_number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, positive_number2.Tree);

                    }
                    break;
                case 2 :
                    // NumberFilter.g:24:21: negative_number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_negative_number_in_number105);
                    	negative_number3 = negative_number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, negative_number3.Tree);

                    }
                    break;
                case 3 :
                    // NumberFilter.g:24:39: number_as_string
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_number_as_string_in_number109);
                    	number_as_string4 = number_as_string();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, number_as_string4.Tree);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "number"

    public class interval_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "interval"
    // NumberFilter.g:26:1: interval : ( number MINUS num2= NUMBER | ( number MINUS num2= Q_STRING | number MINUS num2= A_STRING ) );
    public NumberFilterParser.interval_return interval() // throws RecognitionException [1]
    {   
        NumberFilterParser.interval_return retval = new NumberFilterParser.interval_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken num2 = null;
        IToken MINUS6 = null;
        IToken MINUS8 = null;
        IToken MINUS10 = null;
        NumberFilterParser.number_return number5 = default(NumberFilterParser.number_return);

        NumberFilterParser.number_return number7 = default(NumberFilterParser.number_return);

        NumberFilterParser.number_return number9 = default(NumberFilterParser.number_return);


        object num2_tree=null;
        object MINUS6_tree=null;
        object MINUS8_tree=null;
        object MINUS10_tree=null;

        try 
    	{
            // NumberFilter.g:26:10: ( number MINUS num2= NUMBER | ( number MINUS num2= Q_STRING | number MINUS num2= A_STRING ) )
            int alt4 = 2;
            switch ( input.LA(1) ) 
            {
            case NUMBER:
            	{
                int LA4_1 = input.LA(2);

                if ( (LA4_1 == MINUS) )
                {
                    int LA4_5 = input.LA(3);

                    if ( ((LA4_5 >= Q_STRING && LA4_5 <= A_STRING)) )
                    {
                        alt4 = 2;
                    }
                    else if ( (LA4_5 == NUMBER) )
                    {
                        alt4 = 1;
                    }
                    else 
                    {
                        NoViableAltException nvae_d4s5 =
                            new NoViableAltException("", 4, 5, input);

                        throw nvae_d4s5;
                    }
                }
                else 
                {
                    NoViableAltException nvae_d4s1 =
                        new NoViableAltException("", 4, 1, input);

                    throw nvae_d4s1;
                }
                }
                break;
            case MINUS:
            	{
                int LA4_2 = input.LA(2);

                if ( (LA4_2 == NUMBER) )
                {
                    int LA4_6 = input.LA(3);

                    if ( (LA4_6 == MINUS) )
                    {
                        int LA4_5 = input.LA(4);

                        if ( ((LA4_5 >= Q_STRING && LA4_5 <= A_STRING)) )
                        {
                            alt4 = 2;
                        }
                        else if ( (LA4_5 == NUMBER) )
                        {
                            alt4 = 1;
                        }
                        else 
                        {
                            NoViableAltException nvae_d4s5 =
                                new NoViableAltException("", 4, 5, input);

                            throw nvae_d4s5;
                        }
                    }
                    else 
                    {
                        NoViableAltException nvae_d4s6 =
                            new NoViableAltException("", 4, 6, input);

                        throw nvae_d4s6;
                    }
                }
                else 
                {
                    NoViableAltException nvae_d4s2 =
                        new NoViableAltException("", 4, 2, input);

                    throw nvae_d4s2;
                }
                }
                break;
            case Q_STRING:
            	{
                int LA4_3 = input.LA(2);

                if ( (LA4_3 == MINUS) )
                {
                    int LA4_5 = input.LA(3);

                    if ( ((LA4_5 >= Q_STRING && LA4_5 <= A_STRING)) )
                    {
                        alt4 = 2;
                    }
                    else if ( (LA4_5 == NUMBER) )
                    {
                        alt4 = 1;
                    }
                    else 
                    {
                        NoViableAltException nvae_d4s5 =
                            new NoViableAltException("", 4, 5, input);

                        throw nvae_d4s5;
                    }
                }
                else 
                {
                    NoViableAltException nvae_d4s3 =
                        new NoViableAltException("", 4, 3, input);

                    throw nvae_d4s3;
                }
                }
                break;
            case A_STRING:
            	{
                int LA4_4 = input.LA(2);

                if ( (LA4_4 == MINUS) )
                {
                    int LA4_5 = input.LA(3);

                    if ( ((LA4_5 >= Q_STRING && LA4_5 <= A_STRING)) )
                    {
                        alt4 = 2;
                    }
                    else if ( (LA4_5 == NUMBER) )
                    {
                        alt4 = 1;
                    }
                    else 
                    {
                        NoViableAltException nvae_d4s5 =
                            new NoViableAltException("", 4, 5, input);

                        throw nvae_d4s5;
                    }
                }
                else 
                {
                    NoViableAltException nvae_d4s4 =
                        new NoViableAltException("", 4, 4, input);

                    throw nvae_d4s4;
                }
                }
                break;
            	default:
            	    NoViableAltException nvae_d4s0 =
            	        new NoViableAltException("", 4, 0, input);

            	    throw nvae_d4s0;
            }

            switch (alt4) 
            {
                case 1 :
                    // NumberFilter.g:27:1: number MINUS num2= NUMBER
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_number_in_interval118);
                    	number5 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, number5.Tree);
                    	MINUS6=(IToken)Match(input,MINUS,FOLLOW_MINUS_in_interval120); 
                    		MINUS6_tree = (object)adaptor.Create(MINUS6);
                    		adaptor.AddChild(root_0, MINUS6_tree);

                    	num2=(IToken)Match(input,NUMBER,FOLLOW_NUMBER_in_interval124); 
                    		num2_tree = (object)adaptor.Create(num2);
                    		adaptor.AddChild(root_0, num2_tree);


                    	        var left = Pop<decimal>();var right=Decimal.Parse(((num2 != null) ? num2.Text : null), CultureInfo.InvariantCulture);
                    	        Conditions.Add(new DmlfBetweenCondition
                    	            {
                    	                Expr = ColumnValue,
                    	                LowerBound = new DmlfLiteralExpression{Value = left},
                    	                UpperBound = new DmlfLiteralExpression{Value = right},
                    	            });


                    }
                    break;
                case 2 :
                    // NumberFilter.g:36:1: ( number MINUS num2= Q_STRING | number MINUS num2= A_STRING )
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	// NumberFilter.g:36:1: ( number MINUS num2= Q_STRING | number MINUS num2= A_STRING )
                    	int alt3 = 2;
                    	switch ( input.LA(1) ) 
                    	{
                    	case NUMBER:
                    		{
                    	    int LA3_1 = input.LA(2);

                    	    if ( (LA3_1 == MINUS) )
                    	    {
                    	        int LA3_5 = input.LA(3);

                    	        if ( (LA3_5 == Q_STRING) )
                    	        {
                    	            alt3 = 1;
                    	        }
                    	        else if ( (LA3_5 == A_STRING) )
                    	        {
                    	            alt3 = 2;
                    	        }
                    	        else 
                    	        {
                    	            NoViableAltException nvae_d3s5 =
                    	                new NoViableAltException("", 3, 5, input);

                    	            throw nvae_d3s5;
                    	        }
                    	    }
                    	    else 
                    	    {
                    	        NoViableAltException nvae_d3s1 =
                    	            new NoViableAltException("", 3, 1, input);

                    	        throw nvae_d3s1;
                    	    }
                    	    }
                    	    break;
                    	case MINUS:
                    		{
                    	    int LA3_2 = input.LA(2);

                    	    if ( (LA3_2 == NUMBER) )
                    	    {
                    	        int LA3_6 = input.LA(3);

                    	        if ( (LA3_6 == MINUS) )
                    	        {
                    	            int LA3_5 = input.LA(4);

                    	            if ( (LA3_5 == Q_STRING) )
                    	            {
                    	                alt3 = 1;
                    	            }
                    	            else if ( (LA3_5 == A_STRING) )
                    	            {
                    	                alt3 = 2;
                    	            }
                    	            else 
                    	            {
                    	                NoViableAltException nvae_d3s5 =
                    	                    new NoViableAltException("", 3, 5, input);

                    	                throw nvae_d3s5;
                    	            }
                    	        }
                    	        else 
                    	        {
                    	            NoViableAltException nvae_d3s6 =
                    	                new NoViableAltException("", 3, 6, input);

                    	            throw nvae_d3s6;
                    	        }
                    	    }
                    	    else 
                    	    {
                    	        NoViableAltException nvae_d3s2 =
                    	            new NoViableAltException("", 3, 2, input);

                    	        throw nvae_d3s2;
                    	    }
                    	    }
                    	    break;
                    	case Q_STRING:
                    		{
                    	    int LA3_3 = input.LA(2);

                    	    if ( (LA3_3 == MINUS) )
                    	    {
                    	        int LA3_5 = input.LA(3);

                    	        if ( (LA3_5 == Q_STRING) )
                    	        {
                    	            alt3 = 1;
                    	        }
                    	        else if ( (LA3_5 == A_STRING) )
                    	        {
                    	            alt3 = 2;
                    	        }
                    	        else 
                    	        {
                    	            NoViableAltException nvae_d3s5 =
                    	                new NoViableAltException("", 3, 5, input);

                    	            throw nvae_d3s5;
                    	        }
                    	    }
                    	    else 
                    	    {
                    	        NoViableAltException nvae_d3s3 =
                    	            new NoViableAltException("", 3, 3, input);

                    	        throw nvae_d3s3;
                    	    }
                    	    }
                    	    break;
                    	case A_STRING:
                    		{
                    	    int LA3_4 = input.LA(2);

                    	    if ( (LA3_4 == MINUS) )
                    	    {
                    	        int LA3_5 = input.LA(3);

                    	        if ( (LA3_5 == Q_STRING) )
                    	        {
                    	            alt3 = 1;
                    	        }
                    	        else if ( (LA3_5 == A_STRING) )
                    	        {
                    	            alt3 = 2;
                    	        }
                    	        else 
                    	        {
                    	            NoViableAltException nvae_d3s5 =
                    	                new NoViableAltException("", 3, 5, input);

                    	            throw nvae_d3s5;
                    	        }
                    	    }
                    	    else 
                    	    {
                    	        NoViableAltException nvae_d3s4 =
                    	            new NoViableAltException("", 3, 4, input);

                    	        throw nvae_d3s4;
                    	    }
                    	    }
                    	    break;
                    		default:
                    		    NoViableAltException nvae_d3s0 =
                    		        new NoViableAltException("", 3, 0, input);

                    		    throw nvae_d3s0;
                    	}

                    	switch (alt3) 
                    	{
                    	    case 1 :
                    	        // NumberFilter.g:36:2: number MINUS num2= Q_STRING
                    	        {
                    	        	PushFollow(FOLLOW_number_in_interval131);
                    	        	number7 = number();
                    	        	state.followingStackPointer--;

                    	        	adaptor.AddChild(root_0, number7.Tree);
                    	        	MINUS8=(IToken)Match(input,MINUS,FOLLOW_MINUS_in_interval133); 
                    	        		MINUS8_tree = (object)adaptor.Create(MINUS8);
                    	        		adaptor.AddChild(root_0, MINUS8_tree);

                    	        	num2=(IToken)Match(input,Q_STRING,FOLLOW_Q_STRING_in_interval137); 
                    	        		num2_tree = (object)adaptor.Create(num2);
                    	        		adaptor.AddChild(root_0, num2_tree);


                    	        }
                    	        break;
                    	    case 2 :
                    	        // NumberFilter.g:36:31: number MINUS num2= A_STRING
                    	        {
                    	        	PushFollow(FOLLOW_number_in_interval141);
                    	        	number9 = number();
                    	        	state.followingStackPointer--;

                    	        	adaptor.AddChild(root_0, number9.Tree);
                    	        	MINUS10=(IToken)Match(input,MINUS,FOLLOW_MINUS_in_interval143); 
                    	        		MINUS10_tree = (object)adaptor.Create(MINUS10);
                    	        		adaptor.AddChild(root_0, MINUS10_tree);

                    	        	num2=(IToken)Match(input,A_STRING,FOLLOW_A_STRING_in_interval147); 
                    	        		num2_tree = (object)adaptor.Create(num2);
                    	        		adaptor.AddChild(root_0, num2_tree);


                    	        }
                    	        break;

                    	}


                    	        var left = Pop<decimal>();
                    	        string value=((num2 != null) ? num2.Text : null); 
                    	        var right=Decimal.Parse(value.Substring(1, value.Length - 2), CultureInfo.InvariantCulture);
                    	        Conditions.Add(new DmlfBetweenCondition
                    	            {
                    	                Expr = ColumnValue,
                    	                LowerBound = new DmlfLiteralExpression{Value = left},
                    	                UpperBound = new DmlfLiteralExpression{Value = right},
                    	            });


                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "interval"

    public class sql_name_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "sql_name"
    // NumberFilter.g:48:1: sql_name : lit1= SQL_LITERAL ( DOT lit2= SQL_LITERAL )* ;
    public NumberFilterParser.sql_name_return sql_name() // throws RecognitionException [1]
    {   
        NumberFilterParser.sql_name_return retval = new NumberFilterParser.sql_name_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken lit1 = null;
        IToken lit2 = null;
        IToken DOT11 = null;

        object lit1_tree=null;
        object lit2_tree=null;
        object DOT11_tree=null;

        try 
    	{
            // NumberFilter.g:48:9: (lit1= SQL_LITERAL ( DOT lit2= SQL_LITERAL )* )
            // NumberFilter.g:49:3: lit1= SQL_LITERAL ( DOT lit2= SQL_LITERAL )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	lit1=(IToken)Match(input,SQL_LITERAL,FOLLOW_SQL_LITERAL_in_sql_name161); 
            		lit1_tree = (object)adaptor.Create(lit1);
            		adaptor.AddChild(root_0, lit1_tree);

            	 Push(((lit1 != null) ? lit1.Text : null)); 
            	// NumberFilter.g:50:3: ( DOT lit2= SQL_LITERAL )*
            	do 
            	{
            	    int alt5 = 2;
            	    int LA5_0 = input.LA(1);

            	    if ( (LA5_0 == DOT) )
            	    {
            	        alt5 = 1;
            	    }


            	    switch (alt5) 
            		{
            			case 1 :
            			    // NumberFilter.g:50:4: DOT lit2= SQL_LITERAL
            			    {
            			    	DOT11=(IToken)Match(input,DOT,FOLLOW_DOT_in_sql_name168); 
            			    		DOT11_tree = (object)adaptor.Create(DOT11);
            			    		adaptor.AddChild(root_0, DOT11_tree);

            			    	lit2=(IToken)Match(input,SQL_LITERAL,FOLLOW_SQL_LITERAL_in_sql_name172); 
            			    		lit2_tree = (object)adaptor.Create(lit2);
            			    		adaptor.AddChild(root_0, lit2_tree);

            			    	 Push(Pop<string>() + "." + ((lit2 != null) ? lit2.Text : null)); 

            			    }
            			    break;

            			default:
            			    goto loop5;
            	    }
            	} while (true);

            	loop5:
            		;	// Stops C# compiler whining that label 'loop5' has no statements


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "sql_name"

    public class element_no_negative_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "element_no_negative"
    // NumberFilter.g:53:1: element_no_negative : ( positive_number | number_as_string | interval | LT num1= number | GT num1= number | LE num1= number | GE num1= number | NE num1= number | EQ num1= number | T_NULL | T_NOT T_NULL | LT sql_name | GT sql_name | LE sql_name | GE sql_name | NE sql_name | EQ sql_name | EQ2 sql_name | NE2 sql_name );
    public NumberFilterParser.element_no_negative_return element_no_negative() // throws RecognitionException [1]
    {   
        NumberFilterParser.element_no_negative_return retval = new NumberFilterParser.element_no_negative_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken LT15 = null;
        IToken GT16 = null;
        IToken LE17 = null;
        IToken GE18 = null;
        IToken NE19 = null;
        IToken EQ20 = null;
        IToken T_NULL21 = null;
        IToken T_NOT22 = null;
        IToken T_NULL23 = null;
        IToken LT24 = null;
        IToken GT26 = null;
        IToken LE28 = null;
        IToken GE30 = null;
        IToken NE32 = null;
        IToken EQ34 = null;
        IToken EQ236 = null;
        IToken NE238 = null;
        NumberFilterParser.number_return num1 = default(NumberFilterParser.number_return);

        NumberFilterParser.positive_number_return positive_number12 = default(NumberFilterParser.positive_number_return);

        NumberFilterParser.number_as_string_return number_as_string13 = default(NumberFilterParser.number_as_string_return);

        NumberFilterParser.interval_return interval14 = default(NumberFilterParser.interval_return);

        NumberFilterParser.sql_name_return sql_name25 = default(NumberFilterParser.sql_name_return);

        NumberFilterParser.sql_name_return sql_name27 = default(NumberFilterParser.sql_name_return);

        NumberFilterParser.sql_name_return sql_name29 = default(NumberFilterParser.sql_name_return);

        NumberFilterParser.sql_name_return sql_name31 = default(NumberFilterParser.sql_name_return);

        NumberFilterParser.sql_name_return sql_name33 = default(NumberFilterParser.sql_name_return);

        NumberFilterParser.sql_name_return sql_name35 = default(NumberFilterParser.sql_name_return);

        NumberFilterParser.sql_name_return sql_name37 = default(NumberFilterParser.sql_name_return);

        NumberFilterParser.sql_name_return sql_name39 = default(NumberFilterParser.sql_name_return);


        object LT15_tree=null;
        object GT16_tree=null;
        object LE17_tree=null;
        object GE18_tree=null;
        object NE19_tree=null;
        object EQ20_tree=null;
        object T_NULL21_tree=null;
        object T_NOT22_tree=null;
        object T_NULL23_tree=null;
        object LT24_tree=null;
        object GT26_tree=null;
        object LE28_tree=null;
        object GE30_tree=null;
        object NE32_tree=null;
        object EQ34_tree=null;
        object EQ236_tree=null;
        object NE238_tree=null;

        try 
    	{
            // NumberFilter.g:53:20: ( positive_number | number_as_string | interval | LT num1= number | GT num1= number | LE num1= number | GE num1= number | NE num1= number | EQ num1= number | T_NULL | T_NOT T_NULL | LT sql_name | GT sql_name | LE sql_name | GE sql_name | NE sql_name | EQ sql_name | EQ2 sql_name | NE2 sql_name )
            int alt6 = 19;
            alt6 = dfa6.Predict(input);
            switch (alt6) 
            {
                case 1 :
                    // NumberFilter.g:54:3: positive_number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_positive_number_in_element_no_negative192);
                    	positive_number12 = positive_number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, positive_number12.Tree);
                    	 AddNumberEqualCondition(Pop<decimal>()); 

                    }
                    break;
                case 2 :
                    // NumberFilter.g:55:5: number_as_string
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_number_as_string_in_element_no_negative201);
                    	number_as_string13 = number_as_string();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, number_as_string13.Tree);
                    	 AddNumberEqualCondition(Pop<decimal>()); 

                    }
                    break;
                case 3 :
                    // NumberFilter.g:56:5: interval
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_interval_in_element_no_negative210);
                    	interval14 = interval();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, interval14.Tree);

                    }
                    break;
                case 4 :
                    // NumberFilter.g:57:5: LT num1= number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LT15=(IToken)Match(input,LT,FOLLOW_LT_in_element_no_negative216); 
                    		LT15_tree = (object)adaptor.Create(LT15);
                    		adaptor.AddChild(root_0, LT15_tree);

                    	PushFollow(FOLLOW_number_in_element_no_negative220);
                    	num1 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, num1.Tree);
                    	 AddNumberRelation(Pop<decimal>(), "<"); 

                    }
                    break;
                case 5 :
                    // NumberFilter.g:58:5: GT num1= number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GT16=(IToken)Match(input,GT,FOLLOW_GT_in_element_no_negative229); 
                    		GT16_tree = (object)adaptor.Create(GT16);
                    		adaptor.AddChild(root_0, GT16_tree);

                    	PushFollow(FOLLOW_number_in_element_no_negative233);
                    	num1 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, num1.Tree);
                    	 AddNumberRelation(Pop<decimal>(), ">"); 

                    }
                    break;
                case 6 :
                    // NumberFilter.g:59:5: LE num1= number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LE17=(IToken)Match(input,LE,FOLLOW_LE_in_element_no_negative242); 
                    		LE17_tree = (object)adaptor.Create(LE17);
                    		adaptor.AddChild(root_0, LE17_tree);

                    	PushFollow(FOLLOW_number_in_element_no_negative246);
                    	num1 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, num1.Tree);
                    	 AddNumberRelation(Pop<decimal>(), "<="); 

                    }
                    break;
                case 7 :
                    // NumberFilter.g:60:5: GE num1= number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GE18=(IToken)Match(input,GE,FOLLOW_GE_in_element_no_negative255); 
                    		GE18_tree = (object)adaptor.Create(GE18);
                    		adaptor.AddChild(root_0, GE18_tree);

                    	PushFollow(FOLLOW_number_in_element_no_negative259);
                    	num1 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, num1.Tree);
                    	 AddNumberRelation(Pop<decimal>(), ">="); 

                    }
                    break;
                case 8 :
                    // NumberFilter.g:61:5: NE num1= number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NE19=(IToken)Match(input,NE,FOLLOW_NE_in_element_no_negative268); 
                    		NE19_tree = (object)adaptor.Create(NE19);
                    		adaptor.AddChild(root_0, NE19_tree);

                    	PushFollow(FOLLOW_number_in_element_no_negative272);
                    	num1 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, num1.Tree);
                    	 AddNumberRelation(Pop<decimal>(), "<>"); 

                    }
                    break;
                case 9 :
                    // NumberFilter.g:62:5: EQ num1= number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	EQ20=(IToken)Match(input,EQ,FOLLOW_EQ_in_element_no_negative281); 
                    		EQ20_tree = (object)adaptor.Create(EQ20);
                    		adaptor.AddChild(root_0, EQ20_tree);

                    	PushFollow(FOLLOW_number_in_element_no_negative285);
                    	num1 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, num1.Tree);
                    	 AddNumberRelation(Pop<decimal>(), "="); 

                    }
                    break;
                case 10 :
                    // NumberFilter.g:63:5: T_NULL
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NULL21=(IToken)Match(input,T_NULL,FOLLOW_T_NULL_in_element_no_negative294); 
                    		T_NULL21_tree = (object)adaptor.Create(T_NULL21);
                    		adaptor.AddChild(root_0, T_NULL21_tree);

                    	 AddIsNullCondition(); 

                    }
                    break;
                case 11 :
                    // NumberFilter.g:64:5: T_NOT T_NULL
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NOT22=(IToken)Match(input,T_NOT,FOLLOW_T_NOT_in_element_no_negative302); 
                    		T_NOT22_tree = (object)adaptor.Create(T_NOT22);
                    		adaptor.AddChild(root_0, T_NOT22_tree);

                    	T_NULL23=(IToken)Match(input,T_NULL,FOLLOW_T_NULL_in_element_no_negative304); 
                    		T_NULL23_tree = (object)adaptor.Create(T_NULL23);
                    		adaptor.AddChild(root_0, T_NULL23_tree);

                    	 AddIsNotNullCondition(); 

                    }
                    break;
                case 12 :
                    // NumberFilter.g:66:5: LT sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LT24=(IToken)Match(input,LT,FOLLOW_LT_in_element_no_negative315); 
                    		LT24_tree = (object)adaptor.Create(LT24);
                    		adaptor.AddChild(root_0, LT24_tree);

                    	PushFollow(FOLLOW_sql_name_in_element_no_negative317);
                    	sql_name25 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name25.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), "<"); 

                    }
                    break;
                case 13 :
                    // NumberFilter.g:67:5: GT sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GT26=(IToken)Match(input,GT,FOLLOW_GT_in_element_no_negative326); 
                    		GT26_tree = (object)adaptor.Create(GT26);
                    		adaptor.AddChild(root_0, GT26_tree);

                    	PushFollow(FOLLOW_sql_name_in_element_no_negative328);
                    	sql_name27 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name27.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), ">"); 

                    }
                    break;
                case 14 :
                    // NumberFilter.g:68:5: LE sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LE28=(IToken)Match(input,LE,FOLLOW_LE_in_element_no_negative337); 
                    		LE28_tree = (object)adaptor.Create(LE28);
                    		adaptor.AddChild(root_0, LE28_tree);

                    	PushFollow(FOLLOW_sql_name_in_element_no_negative339);
                    	sql_name29 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name29.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), "<="); 

                    }
                    break;
                case 15 :
                    // NumberFilter.g:69:5: GE sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GE30=(IToken)Match(input,GE,FOLLOW_GE_in_element_no_negative348); 
                    		GE30_tree = (object)adaptor.Create(GE30);
                    		adaptor.AddChild(root_0, GE30_tree);

                    	PushFollow(FOLLOW_sql_name_in_element_no_negative350);
                    	sql_name31 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name31.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), ">="); 

                    }
                    break;
                case 16 :
                    // NumberFilter.g:70:5: NE sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NE32=(IToken)Match(input,NE,FOLLOW_NE_in_element_no_negative359); 
                    		NE32_tree = (object)adaptor.Create(NE32);
                    		adaptor.AddChild(root_0, NE32_tree);

                    	PushFollow(FOLLOW_sql_name_in_element_no_negative361);
                    	sql_name33 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name33.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), "<>"); 

                    }
                    break;
                case 17 :
                    // NumberFilter.g:71:5: EQ sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	EQ34=(IToken)Match(input,EQ,FOLLOW_EQ_in_element_no_negative370); 
                    		EQ34_tree = (object)adaptor.Create(EQ34);
                    		adaptor.AddChild(root_0, EQ34_tree);

                    	PushFollow(FOLLOW_sql_name_in_element_no_negative372);
                    	sql_name35 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name35.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), "="); 

                    }
                    break;
                case 18 :
                    // NumberFilter.g:72:5: EQ2 sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	EQ236=(IToken)Match(input,EQ2,FOLLOW_EQ2_in_element_no_negative380); 
                    		EQ236_tree = (object)adaptor.Create(EQ236);
                    		adaptor.AddChild(root_0, EQ236_tree);

                    	PushFollow(FOLLOW_sql_name_in_element_no_negative382);
                    	sql_name37 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name37.Tree);
                    	 AddSqlLiteralRelationWithNullTest_EQ(Pop<string>()); 

                    }
                    break;
                case 19 :
                    // NumberFilter.g:73:5: NE2 sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NE238=(IToken)Match(input,NE2,FOLLOW_NE2_in_element_no_negative391); 
                    		NE238_tree = (object)adaptor.Create(NE238);
                    		adaptor.AddChild(root_0, NE238_tree);

                    	PushFollow(FOLLOW_sql_name_in_element_no_negative393);
                    	sql_name39 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name39.Tree);
                    	 AddSqlLiteralRelationWithNullTest_NE(Pop<string>()); 

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "element_no_negative"

    public class element_maybe_negative_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "element_maybe_negative"
    // NumberFilter.g:76:1: element_maybe_negative : ( negative_number | element_no_negative );
    public NumberFilterParser.element_maybe_negative_return element_maybe_negative() // throws RecognitionException [1]
    {   
        NumberFilterParser.element_maybe_negative_return retval = new NumberFilterParser.element_maybe_negative_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        NumberFilterParser.negative_number_return negative_number40 = default(NumberFilterParser.negative_number_return);

        NumberFilterParser.element_no_negative_return element_no_negative41 = default(NumberFilterParser.element_no_negative_return);



        try 
    	{
            // NumberFilter.g:76:23: ( negative_number | element_no_negative )
            int alt7 = 2;
            alt7 = dfa7.Predict(input);
            switch (alt7) 
            {
                case 1 :
                    // NumberFilter.g:77:3: negative_number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_negative_number_in_element_maybe_negative409);
                    	negative_number40 = negative_number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, negative_number40.Tree);
                    	 AddNumberEqualCondition(Pop<decimal>()); 

                    }
                    break;
                case 2 :
                    // NumberFilter.g:78:5: element_no_negative
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_element_no_negative_in_element_maybe_negative417);
                    	element_no_negative41 = element_no_negative();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, element_no_negative41.Tree);

                    }
                    break;

            }
            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "element_maybe_negative"

    public class factor_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "factor"
    // NumberFilter.g:81:1: factor : element_maybe_negative ( element_no_negative )* ;
    public NumberFilterParser.factor_return factor() // throws RecognitionException [1]
    {   
        NumberFilterParser.factor_return retval = new NumberFilterParser.factor_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        NumberFilterParser.element_maybe_negative_return element_maybe_negative42 = default(NumberFilterParser.element_maybe_negative_return);

        NumberFilterParser.element_no_negative_return element_no_negative43 = default(NumberFilterParser.element_no_negative_return);



        try 
    	{
            // NumberFilter.g:81:8: ( element_maybe_negative ( element_no_negative )* )
            // NumberFilter.g:82:3: element_maybe_negative ( element_no_negative )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_element_maybe_negative_in_factor430);
            	element_maybe_negative42 = element_maybe_negative();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, element_maybe_negative42.Tree);
            	// NumberFilter.g:82:26: ( element_no_negative )*
            	do 
            	{
            	    int alt8 = 2;
            	    int LA8_0 = input.LA(1);

            	    if ( ((LA8_0 >= MINUS && LA8_0 <= A_STRING) || (LA8_0 >= LT && LA8_0 <= NE2)) )
            	    {
            	        alt8 = 1;
            	    }


            	    switch (alt8) 
            		{
            			case 1 :
            			    // NumberFilter.g:82:26: element_no_negative
            			    {
            			    	PushFollow(FOLLOW_element_no_negative_in_factor432);
            			    	element_no_negative43 = element_no_negative();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, element_no_negative43.Tree);

            			    }
            			    break;

            			default:
            			    goto loop8;
            	    }
            	} while (true);

            	loop8:
            		;	// Stops C# compiler whining that label 'loop8' has no statements


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "factor"

    public class list_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "list"
    // NumberFilter.g:84:1: list : factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )* ;
    public NumberFilterParser.list_return list() // throws RecognitionException [1]
    {   
        NumberFilterParser.list_return retval = new NumberFilterParser.list_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken COMMA45 = null;
        IToken ENDLINE46 = null;
        IToken ENDLINE48 = null;
        NumberFilterParser.factor_return factor44 = default(NumberFilterParser.factor_return);

        NumberFilterParser.factor_return factor47 = default(NumberFilterParser.factor_return);


        object COMMA45_tree=null;
        object ENDLINE46_tree=null;
        object ENDLINE48_tree=null;

        try 
    	{
            // NumberFilter.g:84:5: ( factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )* )
            // NumberFilter.g:85:3: factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_factor_in_list443);
            	factor44 = factor();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, factor44.Tree);
            	// NumberFilter.g:85:10: ( ( COMMA | ( ( ENDLINE )+ ) ) factor )*
            	do 
            	{
            	    int alt11 = 2;
            	    alt11 = dfa11.Predict(input);
            	    switch (alt11) 
            		{
            			case 1 :
            			    // NumberFilter.g:85:12: ( COMMA | ( ( ENDLINE )+ ) ) factor
            			    {
            			    	// NumberFilter.g:85:12: ( COMMA | ( ( ENDLINE )+ ) )
            			    	int alt10 = 2;
            			    	int LA10_0 = input.LA(1);

            			    	if ( (LA10_0 == COMMA) )
            			    	{
            			    	    alt10 = 1;
            			    	}
            			    	else if ( (LA10_0 == ENDLINE) )
            			    	{
            			    	    alt10 = 2;
            			    	}
            			    	else 
            			    	{
            			    	    NoViableAltException nvae_d10s0 =
            			    	        new NoViableAltException("", 10, 0, input);

            			    	    throw nvae_d10s0;
            			    	}
            			    	switch (alt10) 
            			    	{
            			    	    case 1 :
            			    	        // NumberFilter.g:85:13: COMMA
            			    	        {
            			    	        	COMMA45=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_list448); 
            			    	        		COMMA45_tree = (object)adaptor.Create(COMMA45);
            			    	        		adaptor.AddChild(root_0, COMMA45_tree);


            			    	        }
            			    	        break;
            			    	    case 2 :
            			    	        // NumberFilter.g:85:21: ( ( ENDLINE )+ )
            			    	        {
            			    	        	// NumberFilter.g:85:21: ( ( ENDLINE )+ )
            			    	        	// NumberFilter.g:85:22: ( ENDLINE )+
            			    	        	{
            			    	        		// NumberFilter.g:85:22: ( ENDLINE )+
            			    	        		int cnt9 = 0;
            			    	        		do 
            			    	        		{
            			    	        		    int alt9 = 2;
            			    	        		    int LA9_0 = input.LA(1);

            			    	        		    if ( (LA9_0 == ENDLINE) )
            			    	        		    {
            			    	        		        alt9 = 1;
            			    	        		    }


            			    	        		    switch (alt9) 
            			    	        			{
            			    	        				case 1 :
            			    	        				    // NumberFilter.g:85:22: ENDLINE
            			    	        				    {
            			    	        				    	ENDLINE46=(IToken)Match(input,ENDLINE,FOLLOW_ENDLINE_in_list453); 
            			    	        				    		ENDLINE46_tree = (object)adaptor.Create(ENDLINE46);
            			    	        				    		adaptor.AddChild(root_0, ENDLINE46_tree);


            			    	        				    }
            			    	        				    break;

            			    	        				default:
            			    	        				    if ( cnt9 >= 1 ) goto loop9;
            			    	        			            EarlyExitException eee9 =
            			    	        			                new EarlyExitException(9, input);
            			    	        			            throw eee9;
            			    	        		    }
            			    	        		    cnt9++;
            			    	        		} while (true);

            			    	        		loop9:
            			    	        			;	// Stops C# compiler whining that label 'loop9' has no statements


            			    	        	}


            			    	        }
            			    	        break;

            			    	}

            			    	 AddAndCondition(); 
            			    	PushFollow(FOLLOW_factor_in_list460);
            			    	factor47 = factor();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, factor47.Tree);

            			    }
            			    break;

            			default:
            			    goto loop11;
            	    }
            	} while (true);

            	loop11:
            		;	// Stops C# compiler whining that label 'loop11' has no statements

            	// NumberFilter.g:85:67: ( ENDLINE )*
            	do 
            	{
            	    int alt12 = 2;
            	    int LA12_0 = input.LA(1);

            	    if ( (LA12_0 == ENDLINE) )
            	    {
            	        alt12 = 1;
            	    }


            	    switch (alt12) 
            		{
            			case 1 :
            			    // NumberFilter.g:85:67: ENDLINE
            			    {
            			    	ENDLINE48=(IToken)Match(input,ENDLINE,FOLLOW_ENDLINE_in_list466); 
            			    		ENDLINE48_tree = (object)adaptor.Create(ENDLINE48);
            			    		adaptor.AddChild(root_0, ENDLINE48_tree);


            			    }
            			    break;

            			default:
            			    goto loop12;
            	    }
            	} while (true);

            	loop12:
            		;	// Stops C# compiler whining that label 'loop12' has no statements


            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "list"

    public class expr_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "expr"
    // NumberFilter.g:87:1: expr : list ;
    public NumberFilterParser.expr_return expr() // throws RecognitionException [1]
    {   
        NumberFilterParser.expr_return retval = new NumberFilterParser.expr_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        NumberFilterParser.list_return list49 = default(NumberFilterParser.list_return);



        try 
    	{
            // NumberFilter.g:87:5: ( list )
            // NumberFilter.g:87:7: list
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_list_in_expr476);
            	list49 = list();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, list49.Tree);

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        catch (RecognitionException re) 
    	{
            ReportError(re);
            Recover(input,re);
    	// Conversion of the second argument necessary, but harmless
    	retval.Tree = (object)adaptor.ErrorNode(input, (IToken) retval.Start, input.LT(-1), re);

        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "expr"

    // Delegated rules


   	protected DFA6 dfa6;
   	protected DFA7 dfa7;
   	protected DFA11 dfa11;
	private void InitializeCyclicDFAs()
	{
    	this.dfa6 = new DFA6(this);
    	this.dfa7 = new DFA7(this);
    	this.dfa11 = new DFA11(this);
	}

    const string DFA6_eotS =
        "\x29\uffff";
    const string DFA6_eofS =
        "\x01\uffff\x01\x10\x02\x12\x1b\uffff\x02\x04\x02\uffff\x01\x10"+
        "\x01\x12\x02\uffff\x02\x04";
    const string DFA6_minS =
        "\x04\x04\x01\uffff\x06\x04\x04\uffff\x01\x05\x01\uffff\x01\x05"+
        "\x0d\uffff\x02\x04\x02\x05\x02\x04\x02\x05\x02\x04";
    const string DFA6_maxS =
        "\x01\x13\x03\x15\x01\uffff\x06\x08\x04\uffff\x01\x07\x01\uffff"+
        "\x01\x07\x0d\uffff\x02\x15\x02\x07\x02\x15\x02\x07\x02\x15";
    const string DFA6_acceptS =
        "\x04\uffff\x01\x03\x06\uffff\x01\x0a\x01\x0b\x01\x12\x01\x13\x01"+
        "\uffff\x01\x01\x01\uffff\x01\x02\x01\x04\x01\x0c\x01\x05\x01\x0d"+
        "\x01\x0e\x01\x06\x01\x07\x01\x0f\x01\x10\x01\x08\x01\x09\x01\x11"+
        "\x0a\uffff";
    const string DFA6_specialS =
        "\x29\uffff}>";
    static readonly string[] DFA6_transitionS = {
            "\x01\x04\x01\x01\x01\x02\x01\x03\x02\uffff\x01\x05\x01\x06"+
            "\x01\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x01\x0c\x01\x0d\x01"+
            "\x0e",
            "\x01\x0f\x03\x10\x02\uffff\x0c\x10",
            "\x01\x11\x03\x12\x02\uffff\x0c\x12",
            "\x01\x11\x03\x12\x02\uffff\x0c\x12",
            "",
            "\x04\x13\x01\x14",
            "\x04\x15\x01\x16",
            "\x04\x18\x01\x17",
            "\x04\x19\x01\x1a",
            "\x04\x1c\x01\x1b",
            "\x04\x1d\x01\x1e",
            "",
            "",
            "",
            "",
            "\x01\x1f\x02\x04",
            "",
            "\x01\x20\x02\x04",
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
            "\x01\x21\x03\x04\x02\uffff\x0c\x04",
            "\x01\x22\x03\x04\x02\uffff\x0c\x04",
            "\x01\x23\x02\x10",
            "\x01\x24\x02\x12",
            "\x01\x25\x03\x10\x02\uffff\x0c\x10",
            "\x01\x26\x03\x12\x02\uffff\x0c\x12",
            "\x01\x27\x02\x04",
            "\x01\x28\x02\x04",
            "\x01\x21\x03\x04\x02\uffff\x0c\x04",
            "\x01\x22\x03\x04\x02\uffff\x0c\x04"
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
            get { return "53:1: element_no_negative : ( positive_number | number_as_string | interval | LT num1= number | GT num1= number | LE num1= number | GE num1= number | NE num1= number | EQ num1= number | T_NULL | T_NOT T_NULL | LT sql_name | GT sql_name | LE sql_name | GE sql_name | NE sql_name | EQ sql_name | EQ2 sql_name | NE2 sql_name );"; }
        }

    }

    const string DFA7_eotS =
        "\x0b\uffff";
    const string DFA7_eofS =
        "\x03\uffff\x01\x05\x02\uffff\x01\x02\x01\uffff\x01\x05\x01\uffff"+
        "\x01\x02";
    const string DFA7_minS =
        "\x01\x04\x01\x05\x01\uffff\x01\x04\x01\x05\x01\uffff\x01\x04\x01"+
        "\x05\x01\x04\x01\x05\x01\x04";
    const string DFA7_maxS =
        "\x01\x13\x01\x05\x01\uffff\x01\x15\x01\x07\x01\uffff\x01\x15\x01"+
        "\x07\x01\x15\x01\x07\x01\x15";
    const string DFA7_acceptS =
        "\x02\uffff\x01\x02\x02\uffff\x01\x01\x05\uffff";
    const string DFA7_specialS =
        "\x0b\uffff}>";
    static readonly string[] DFA7_transitionS = {
            "\x01\x01\x03\x02\x02\uffff\x0a\x02",
            "\x01\x03",
            "",
            "\x01\x04\x03\x05\x02\uffff\x0c\x05",
            "\x01\x06\x02\x02",
            "",
            "\x01\x07\x03\x02\x02\uffff\x0c\x02",
            "\x01\x08\x02\x05",
            "\x01\x09\x03\x05\x02\uffff\x0c\x05",
            "\x01\x0a\x02\x02",
            "\x01\x07\x03\x02\x02\uffff\x0c\x02"
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
            get { return "76:1: element_maybe_negative : ( negative_number | element_no_negative );"; }
        }

    }

    const string DFA11_eotS =
        "\x04\uffff";
    const string DFA11_eofS =
        "\x02\x02\x02\uffff";
    const string DFA11_minS =
        "\x01\x14\x01\x04\x02\uffff";
    const string DFA11_maxS =
        "\x02\x15\x02\uffff";
    const string DFA11_acceptS =
        "\x02\uffff\x01\x02\x01\x01";
    const string DFA11_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA11_transitionS = {
            "\x01\x03\x01\x01",
            "\x04\x03\x02\uffff\x0a\x03\x01\uffff\x01\x01",
            "",
            ""
    };

    static readonly short[] DFA11_eot = DFA.UnpackEncodedString(DFA11_eotS);
    static readonly short[] DFA11_eof = DFA.UnpackEncodedString(DFA11_eofS);
    static readonly char[] DFA11_min = DFA.UnpackEncodedStringToUnsignedChars(DFA11_minS);
    static readonly char[] DFA11_max = DFA.UnpackEncodedStringToUnsignedChars(DFA11_maxS);
    static readonly short[] DFA11_accept = DFA.UnpackEncodedString(DFA11_acceptS);
    static readonly short[] DFA11_special = DFA.UnpackEncodedString(DFA11_specialS);
    static readonly short[][] DFA11_transition = DFA.UnpackEncodedStringArray(DFA11_transitionS);

    protected class DFA11 : DFA
    {
        public DFA11(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 11;
            this.eot = DFA11_eot;
            this.eof = DFA11_eof;
            this.min = DFA11_min;
            this.max = DFA11_max;
            this.accept = DFA11_accept;
            this.special = DFA11_special;
            this.transition = DFA11_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 85:10: ( ( COMMA | ( ( ENDLINE )+ ) ) factor )*"; }
        }

    }

 

    public static readonly BitSet FOLLOW_MINUS_in_negative_number43 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_NUMBER_in_negative_number47 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NUMBER_in_positive_number63 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_Q_STRING_in_number_as_string81 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_A_STRING_in_number_as_string87 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_positive_number_in_number101 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_negative_number_in_number105 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_number_as_string_in_number109 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_number_in_interval118 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_MINUS_in_interval120 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_NUMBER_in_interval124 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_number_in_interval131 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_MINUS_in_interval133 = new BitSet(new ulong[]{0x0000000000000040UL});
    public static readonly BitSet FOLLOW_Q_STRING_in_interval137 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_number_in_interval141 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_MINUS_in_interval143 = new BitSet(new ulong[]{0x0000000000000080UL});
    public static readonly BitSet FOLLOW_A_STRING_in_interval147 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_SQL_LITERAL_in_sql_name161 = new BitSet(new ulong[]{0x0000000000000202UL});
    public static readonly BitSet FOLLOW_DOT_in_sql_name168 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_SQL_LITERAL_in_sql_name172 = new BitSet(new ulong[]{0x0000000000000202UL});
    public static readonly BitSet FOLLOW_positive_number_in_element_no_negative192 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_number_as_string_in_element_no_negative201 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_interval_in_element_no_negative210 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_element_no_negative216 = new BitSet(new ulong[]{0x00000000000000F0UL});
    public static readonly BitSet FOLLOW_number_in_element_no_negative220 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GT_in_element_no_negative229 = new BitSet(new ulong[]{0x00000000000000F0UL});
    public static readonly BitSet FOLLOW_number_in_element_no_negative233 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LE_in_element_no_negative242 = new BitSet(new ulong[]{0x00000000000000F0UL});
    public static readonly BitSet FOLLOW_number_in_element_no_negative246 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GE_in_element_no_negative255 = new BitSet(new ulong[]{0x00000000000000F0UL});
    public static readonly BitSet FOLLOW_number_in_element_no_negative259 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NE_in_element_no_negative268 = new BitSet(new ulong[]{0x00000000000000F0UL});
    public static readonly BitSet FOLLOW_number_in_element_no_negative272 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EQ_in_element_no_negative281 = new BitSet(new ulong[]{0x00000000000000F0UL});
    public static readonly BitSet FOLLOW_number_in_element_no_negative285 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NULL_in_element_no_negative294 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NOT_in_element_no_negative302 = new BitSet(new ulong[]{0x0000000000010000UL});
    public static readonly BitSet FOLLOW_T_NULL_in_element_no_negative304 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_element_no_negative315 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_sql_name_in_element_no_negative317 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GT_in_element_no_negative326 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_sql_name_in_element_no_negative328 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LE_in_element_no_negative337 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_sql_name_in_element_no_negative339 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GE_in_element_no_negative348 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_sql_name_in_element_no_negative350 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NE_in_element_no_negative359 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_sql_name_in_element_no_negative361 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EQ_in_element_no_negative370 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_sql_name_in_element_no_negative372 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EQ2_in_element_no_negative380 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_sql_name_in_element_no_negative382 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NE2_in_element_no_negative391 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_sql_name_in_element_no_negative393 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_negative_number_in_element_maybe_negative409 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_element_no_negative_in_element_maybe_negative417 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_element_maybe_negative_in_factor430 = new BitSet(new ulong[]{0x00000000000FFCF2UL});
    public static readonly BitSet FOLLOW_element_no_negative_in_factor432 = new BitSet(new ulong[]{0x00000000000FFCF2UL});
    public static readonly BitSet FOLLOW_factor_in_list443 = new BitSet(new ulong[]{0x0000000000300002UL});
    public static readonly BitSet FOLLOW_COMMA_in_list448 = new BitSet(new ulong[]{0x00000000000FFCF0UL});
    public static readonly BitSet FOLLOW_ENDLINE_in_list453 = new BitSet(new ulong[]{0x00000000002FFCF0UL});
    public static readonly BitSet FOLLOW_factor_in_list460 = new BitSet(new ulong[]{0x0000000000300002UL});
    public static readonly BitSet FOLLOW_ENDLINE_in_list466 = new BitSet(new ulong[]{0x0000000000200002UL});
    public static readonly BitSet FOLLOW_list_in_expr476 = new BitSet(new ulong[]{0x0000000000000002UL});

}
