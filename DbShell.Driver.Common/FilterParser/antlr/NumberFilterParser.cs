// $ANTLR 3.2 Sep 23, 2009 12:02:23 NumberFilter.g 2013-09-29 10:59:49

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
		"LT", 
		"GT", 
		"LE", 
		"GE", 
		"NE", 
		"EQ", 
		"T_NULL", 
		"T_NOT", 
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

    public const int LT = 8;
    public const int EOF = -1;
    public const int Q_STRING = 6;
    public const int COMMA = 16;
    public const int T_NULL = 14;
    public const int DIGIT = 23;
    public const int EQ = 13;
    public const int NE = 12;
    public const int D = 28;
    public const int E = 29;
    public const int GE = 11;
    public const int F = 30;
    public const int G = 31;
    public const int A = 25;
    public const int B = 26;
    public const int C = 27;
    public const int L = 20;
    public const int M = 36;
    public const int N = 18;
    public const int O = 21;
    public const int H = 32;
    public const int I = 33;
    public const int J = 34;
    public const int NUMBER = 5;
    public const int K = 35;
    public const int U = 19;
    public const int T = 22;
    public const int WHITESPACE = 24;
    public const int W = 42;
    public const int V = 41;
    public const int Q = 38;
    public const int P = 37;
    public const int S = 40;
    public const int MINUS = 4;
    public const int R = 39;
    public const int Y = 44;
    public const int X = 43;
    public const int Z = 45;
    public const int A_STRING = 7;
    public const int GT = 9;
    public const int ENDLINE = 17;
    public const int T_NOT = 15;
    public const int LE = 10;

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

                    	        if ( (LA3_5 == A_STRING) )
                    	        {
                    	            alt3 = 2;
                    	        }
                    	        else if ( (LA3_5 == Q_STRING) )
                    	        {
                    	            alt3 = 1;
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

                    	            if ( (LA3_5 == A_STRING) )
                    	            {
                    	                alt3 = 2;
                    	            }
                    	            else if ( (LA3_5 == Q_STRING) )
                    	            {
                    	                alt3 = 1;
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

                    	        if ( (LA3_5 == A_STRING) )
                    	        {
                    	            alt3 = 2;
                    	        }
                    	        else if ( (LA3_5 == Q_STRING) )
                    	        {
                    	            alt3 = 1;
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

                    	        if ( (LA3_5 == A_STRING) )
                    	        {
                    	            alt3 = 2;
                    	        }
                    	        else if ( (LA3_5 == Q_STRING) )
                    	        {
                    	            alt3 = 1;
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
    // NumberFilter.g:48:1: element_no_negative : ( positive_number | number_as_string | interval | LT num1= number | GT num1= number | LE num1= number | GE num1= number | NE num1= number | EQ num1= number | T_NULL | T_NOT T_NULL );
    public NumberFilterParser.element_no_negative_return element_no_negative() // throws RecognitionException [1]
    {   
        NumberFilterParser.element_no_negative_return retval = new NumberFilterParser.element_no_negative_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken LT14 = null;
        IToken GT15 = null;
        IToken LE16 = null;
        IToken GE17 = null;
        IToken NE18 = null;
        IToken EQ19 = null;
        IToken T_NULL20 = null;
        IToken T_NOT21 = null;
        IToken T_NULL22 = null;
        NumberFilterParser.number_return num1 = default(NumberFilterParser.number_return);

        NumberFilterParser.positive_number_return positive_number11 = default(NumberFilterParser.positive_number_return);

        NumberFilterParser.number_as_string_return number_as_string12 = default(NumberFilterParser.number_as_string_return);

        NumberFilterParser.interval_return interval13 = default(NumberFilterParser.interval_return);


        object LT14_tree=null;
        object GT15_tree=null;
        object LE16_tree=null;
        object GE17_tree=null;
        object NE18_tree=null;
        object EQ19_tree=null;
        object T_NULL20_tree=null;
        object T_NOT21_tree=null;
        object T_NULL22_tree=null;

        try 
    	{
            // NumberFilter.g:48:20: ( positive_number | number_as_string | interval | LT num1= number | GT num1= number | LE num1= number | GE num1= number | NE num1= number | EQ num1= number | T_NULL | T_NOT T_NULL )
            int alt5 = 11;
            alt5 = dfa5.Predict(input);
            switch (alt5) 
            {
                case 1 :
                    // NumberFilter.g:49:3: positive_number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_positive_number_in_element_no_negative160);
                    	positive_number11 = positive_number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, positive_number11.Tree);
                    	 AddEqualCondition(Pop<decimal>().ToString(CultureInfo.InvariantCulture)); 

                    }
                    break;
                case 2 :
                    // NumberFilter.g:50:5: number_as_string
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_number_as_string_in_element_no_negative169);
                    	number_as_string12 = number_as_string();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, number_as_string12.Tree);
                    	 AddEqualCondition(Pop<decimal>().ToString(CultureInfo.InvariantCulture)); 

                    }
                    break;
                case 3 :
                    // NumberFilter.g:51:5: interval
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_interval_in_element_no_negative178);
                    	interval13 = interval();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, interval13.Tree);

                    }
                    break;
                case 4 :
                    // NumberFilter.g:52:5: LT num1= number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LT14=(IToken)Match(input,LT,FOLLOW_LT_in_element_no_negative184); 
                    		LT14_tree = (object)adaptor.Create(LT14);
                    		adaptor.AddChild(root_0, LT14_tree);

                    	PushFollow(FOLLOW_number_in_element_no_negative188);
                    	num1 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, num1.Tree);
                    	 AddNumberRelation(Pop<decimal>(), "<"); 

                    }
                    break;
                case 5 :
                    // NumberFilter.g:53:5: GT num1= number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GT15=(IToken)Match(input,GT,FOLLOW_GT_in_element_no_negative197); 
                    		GT15_tree = (object)adaptor.Create(GT15);
                    		adaptor.AddChild(root_0, GT15_tree);

                    	PushFollow(FOLLOW_number_in_element_no_negative201);
                    	num1 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, num1.Tree);
                    	 AddNumberRelation(Pop<decimal>(), ">"); 

                    }
                    break;
                case 6 :
                    // NumberFilter.g:54:5: LE num1= number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LE16=(IToken)Match(input,LE,FOLLOW_LE_in_element_no_negative210); 
                    		LE16_tree = (object)adaptor.Create(LE16);
                    		adaptor.AddChild(root_0, LE16_tree);

                    	PushFollow(FOLLOW_number_in_element_no_negative214);
                    	num1 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, num1.Tree);
                    	 AddNumberRelation(Pop<decimal>(), "<="); 

                    }
                    break;
                case 7 :
                    // NumberFilter.g:55:5: GE num1= number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GE17=(IToken)Match(input,GE,FOLLOW_GE_in_element_no_negative223); 
                    		GE17_tree = (object)adaptor.Create(GE17);
                    		adaptor.AddChild(root_0, GE17_tree);

                    	PushFollow(FOLLOW_number_in_element_no_negative227);
                    	num1 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, num1.Tree);
                    	 AddNumberRelation(Pop<decimal>(), ">="); 

                    }
                    break;
                case 8 :
                    // NumberFilter.g:56:5: NE num1= number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NE18=(IToken)Match(input,NE,FOLLOW_NE_in_element_no_negative236); 
                    		NE18_tree = (object)adaptor.Create(NE18);
                    		adaptor.AddChild(root_0, NE18_tree);

                    	PushFollow(FOLLOW_number_in_element_no_negative240);
                    	num1 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, num1.Tree);
                    	 AddNumberRelation(Pop<decimal>(), "<>"); 

                    }
                    break;
                case 9 :
                    // NumberFilter.g:57:5: EQ num1= number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	EQ19=(IToken)Match(input,EQ,FOLLOW_EQ_in_element_no_negative249); 
                    		EQ19_tree = (object)adaptor.Create(EQ19);
                    		adaptor.AddChild(root_0, EQ19_tree);

                    	PushFollow(FOLLOW_number_in_element_no_negative253);
                    	num1 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, num1.Tree);
                    	 AddNumberRelation(Pop<decimal>(), "="); 

                    }
                    break;
                case 10 :
                    // NumberFilter.g:58:5: T_NULL
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NULL20=(IToken)Match(input,T_NULL,FOLLOW_T_NULL_in_element_no_negative262); 
                    		T_NULL20_tree = (object)adaptor.Create(T_NULL20);
                    		adaptor.AddChild(root_0, T_NULL20_tree);

                    	 AddIsNullCondition(); 

                    }
                    break;
                case 11 :
                    // NumberFilter.g:59:5: T_NOT T_NULL
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NOT21=(IToken)Match(input,T_NOT,FOLLOW_T_NOT_in_element_no_negative270); 
                    		T_NOT21_tree = (object)adaptor.Create(T_NOT21);
                    		adaptor.AddChild(root_0, T_NOT21_tree);

                    	T_NULL22=(IToken)Match(input,T_NULL,FOLLOW_T_NULL_in_element_no_negative272); 
                    		T_NULL22_tree = (object)adaptor.Create(T_NULL22);
                    		adaptor.AddChild(root_0, T_NULL22_tree);

                    	 AddIsNotNullCondition(); 

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
    // NumberFilter.g:62:1: element_maybe_negative : ( negative_number | element_no_negative );
    public NumberFilterParser.element_maybe_negative_return element_maybe_negative() // throws RecognitionException [1]
    {   
        NumberFilterParser.element_maybe_negative_return retval = new NumberFilterParser.element_maybe_negative_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        NumberFilterParser.negative_number_return negative_number23 = default(NumberFilterParser.negative_number_return);

        NumberFilterParser.element_no_negative_return element_no_negative24 = default(NumberFilterParser.element_no_negative_return);



        try 
    	{
            // NumberFilter.g:62:23: ( negative_number | element_no_negative )
            int alt6 = 2;
            alt6 = dfa6.Predict(input);
            switch (alt6) 
            {
                case 1 :
                    // NumberFilter.g:63:3: negative_number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_negative_number_in_element_maybe_negative288);
                    	negative_number23 = negative_number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, negative_number23.Tree);
                    	 AddEqualCondition(Pop<decimal>().ToString(CultureInfo.InvariantCulture)); 

                    }
                    break;
                case 2 :
                    // NumberFilter.g:64:5: element_no_negative
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_element_no_negative_in_element_maybe_negative296);
                    	element_no_negative24 = element_no_negative();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, element_no_negative24.Tree);

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
    // NumberFilter.g:67:1: factor : element_maybe_negative ( element_no_negative )* ;
    public NumberFilterParser.factor_return factor() // throws RecognitionException [1]
    {   
        NumberFilterParser.factor_return retval = new NumberFilterParser.factor_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        NumberFilterParser.element_maybe_negative_return element_maybe_negative25 = default(NumberFilterParser.element_maybe_negative_return);

        NumberFilterParser.element_no_negative_return element_no_negative26 = default(NumberFilterParser.element_no_negative_return);



        try 
    	{
            // NumberFilter.g:67:8: ( element_maybe_negative ( element_no_negative )* )
            // NumberFilter.g:68:3: element_maybe_negative ( element_no_negative )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_element_maybe_negative_in_factor309);
            	element_maybe_negative25 = element_maybe_negative();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, element_maybe_negative25.Tree);
            	// NumberFilter.g:68:26: ( element_no_negative )*
            	do 
            	{
            	    int alt7 = 2;
            	    int LA7_0 = input.LA(1);

            	    if ( ((LA7_0 >= MINUS && LA7_0 <= T_NOT)) )
            	    {
            	        alt7 = 1;
            	    }


            	    switch (alt7) 
            		{
            			case 1 :
            			    // NumberFilter.g:68:26: element_no_negative
            			    {
            			    	PushFollow(FOLLOW_element_no_negative_in_factor311);
            			    	element_no_negative26 = element_no_negative();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, element_no_negative26.Tree);

            			    }
            			    break;

            			default:
            			    goto loop7;
            	    }
            	} while (true);

            	loop7:
            		;	// Stops C# compiler whining that label 'loop7' has no statements


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
    // NumberFilter.g:70:1: list : factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )* ;
    public NumberFilterParser.list_return list() // throws RecognitionException [1]
    {   
        NumberFilterParser.list_return retval = new NumberFilterParser.list_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken COMMA28 = null;
        IToken ENDLINE29 = null;
        IToken ENDLINE31 = null;
        NumberFilterParser.factor_return factor27 = default(NumberFilterParser.factor_return);

        NumberFilterParser.factor_return factor30 = default(NumberFilterParser.factor_return);


        object COMMA28_tree=null;
        object ENDLINE29_tree=null;
        object ENDLINE31_tree=null;

        try 
    	{
            // NumberFilter.g:70:5: ( factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )* )
            // NumberFilter.g:71:3: factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_factor_in_list322);
            	factor27 = factor();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, factor27.Tree);
            	// NumberFilter.g:71:10: ( ( COMMA | ( ( ENDLINE )+ ) ) factor )*
            	do 
            	{
            	    int alt10 = 2;
            	    alt10 = dfa10.Predict(input);
            	    switch (alt10) 
            		{
            			case 1 :
            			    // NumberFilter.g:71:12: ( COMMA | ( ( ENDLINE )+ ) ) factor
            			    {
            			    	// NumberFilter.g:71:12: ( COMMA | ( ( ENDLINE )+ ) )
            			    	int alt9 = 2;
            			    	int LA9_0 = input.LA(1);

            			    	if ( (LA9_0 == COMMA) )
            			    	{
            			    	    alt9 = 1;
            			    	}
            			    	else if ( (LA9_0 == ENDLINE) )
            			    	{
            			    	    alt9 = 2;
            			    	}
            			    	else 
            			    	{
            			    	    NoViableAltException nvae_d9s0 =
            			    	        new NoViableAltException("", 9, 0, input);

            			    	    throw nvae_d9s0;
            			    	}
            			    	switch (alt9) 
            			    	{
            			    	    case 1 :
            			    	        // NumberFilter.g:71:13: COMMA
            			    	        {
            			    	        	COMMA28=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_list327); 
            			    	        		COMMA28_tree = (object)adaptor.Create(COMMA28);
            			    	        		adaptor.AddChild(root_0, COMMA28_tree);


            			    	        }
            			    	        break;
            			    	    case 2 :
            			    	        // NumberFilter.g:71:21: ( ( ENDLINE )+ )
            			    	        {
            			    	        	// NumberFilter.g:71:21: ( ( ENDLINE )+ )
            			    	        	// NumberFilter.g:71:22: ( ENDLINE )+
            			    	        	{
            			    	        		// NumberFilter.g:71:22: ( ENDLINE )+
            			    	        		int cnt8 = 0;
            			    	        		do 
            			    	        		{
            			    	        		    int alt8 = 2;
            			    	        		    int LA8_0 = input.LA(1);

            			    	        		    if ( (LA8_0 == ENDLINE) )
            			    	        		    {
            			    	        		        alt8 = 1;
            			    	        		    }


            			    	        		    switch (alt8) 
            			    	        			{
            			    	        				case 1 :
            			    	        				    // NumberFilter.g:71:22: ENDLINE
            			    	        				    {
            			    	        				    	ENDLINE29=(IToken)Match(input,ENDLINE,FOLLOW_ENDLINE_in_list332); 
            			    	        				    		ENDLINE29_tree = (object)adaptor.Create(ENDLINE29);
            			    	        				    		adaptor.AddChild(root_0, ENDLINE29_tree);


            			    	        				    }
            			    	        				    break;

            			    	        				default:
            			    	        				    if ( cnt8 >= 1 ) goto loop8;
            			    	        			            EarlyExitException eee8 =
            			    	        			                new EarlyExitException(8, input);
            			    	        			            throw eee8;
            			    	        		    }
            			    	        		    cnt8++;
            			    	        		} while (true);

            			    	        		loop8:
            			    	        			;	// Stops C# compiler whining that label 'loop8' has no statements


            			    	        	}


            			    	        }
            			    	        break;

            			    	}

            			    	 AddAndCondition(); 
            			    	PushFollow(FOLLOW_factor_in_list339);
            			    	factor30 = factor();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, factor30.Tree);

            			    }
            			    break;

            			default:
            			    goto loop10;
            	    }
            	} while (true);

            	loop10:
            		;	// Stops C# compiler whining that label 'loop10' has no statements

            	// NumberFilter.g:71:67: ( ENDLINE )*
            	do 
            	{
            	    int alt11 = 2;
            	    int LA11_0 = input.LA(1);

            	    if ( (LA11_0 == ENDLINE) )
            	    {
            	        alt11 = 1;
            	    }


            	    switch (alt11) 
            		{
            			case 1 :
            			    // NumberFilter.g:71:67: ENDLINE
            			    {
            			    	ENDLINE31=(IToken)Match(input,ENDLINE,FOLLOW_ENDLINE_in_list345); 
            			    		ENDLINE31_tree = (object)adaptor.Create(ENDLINE31);
            			    		adaptor.AddChild(root_0, ENDLINE31_tree);


            			    }
            			    break;

            			default:
            			    goto loop11;
            	    }
            	} while (true);

            	loop11:
            		;	// Stops C# compiler whining that label 'loop11' has no statements


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
    // NumberFilter.g:73:1: expr : list ;
    public NumberFilterParser.expr_return expr() // throws RecognitionException [1]
    {   
        NumberFilterParser.expr_return retval = new NumberFilterParser.expr_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        NumberFilterParser.list_return list32 = default(NumberFilterParser.list_return);



        try 
    	{
            // NumberFilter.g:73:5: ( list )
            // NumberFilter.g:73:7: list
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_list_in_expr355);
            	list32 = list();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, list32.Tree);

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


   	protected DFA5 dfa5;
   	protected DFA6 dfa6;
   	protected DFA10 dfa10;
	private void InitializeCyclicDFAs()
	{
    	this.dfa5 = new DFA5(this);
    	this.dfa6 = new DFA6(this);
    	this.dfa10 = new DFA10(this);
	}

    const string DFA5_eotS =
        "\x1b\uffff";
    const string DFA5_eofS =
        "\x01\uffff\x01\x0e\x02\x10\x0d\uffff\x02\x04\x02\uffff\x01\x0e"+
        "\x01\x10\x02\uffff\x02\x04";
    const string DFA5_minS =
        "\x04\x04\x09\uffff\x01\x05\x01\uffff\x01\x05\x01\uffff\x02\x04"+
        "\x02\x05\x02\x04\x02\x05\x02\x04";
    const string DFA5_maxS =
        "\x01\x0f\x03\x11\x09\uffff\x01\x07\x01\uffff\x01\x07\x01\uffff"+
        "\x02\x11\x02\x07\x02\x11\x02\x07\x02\x11";
    const string DFA5_acceptS =
        "\x04\uffff\x01\x03\x01\x04\x01\x05\x01\x06\x01\x07\x01\x08\x01"+
        "\x09\x01\x0a\x01\x0b\x01\uffff\x01\x01\x01\uffff\x01\x02\x0a\uffff";
    const string DFA5_specialS =
        "\x1b\uffff}>";
    static readonly string[] DFA5_transitionS = {
            "\x01\x04\x01\x01\x01\x02\x01\x03\x01\x05\x01\x06\x01\x07\x01"+
            "\x08\x01\x09\x01\x0a\x01\x0b\x01\x0c",
            "\x01\x0d\x0d\x0e",
            "\x01\x0f\x0d\x10",
            "\x01\x0f\x0d\x10",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\x11\x02\x04",
            "",
            "\x01\x12\x02\x04",
            "",
            "\x01\x13\x0d\x04",
            "\x01\x14\x0d\x04",
            "\x01\x15\x02\x0e",
            "\x01\x16\x02\x10",
            "\x01\x17\x0d\x0e",
            "\x01\x18\x0d\x10",
            "\x01\x19\x02\x04",
            "\x01\x1a\x02\x04",
            "\x01\x13\x0d\x04",
            "\x01\x14\x0d\x04"
    };

    static readonly short[] DFA5_eot = DFA.UnpackEncodedString(DFA5_eotS);
    static readonly short[] DFA5_eof = DFA.UnpackEncodedString(DFA5_eofS);
    static readonly char[] DFA5_min = DFA.UnpackEncodedStringToUnsignedChars(DFA5_minS);
    static readonly char[] DFA5_max = DFA.UnpackEncodedStringToUnsignedChars(DFA5_maxS);
    static readonly short[] DFA5_accept = DFA.UnpackEncodedString(DFA5_acceptS);
    static readonly short[] DFA5_special = DFA.UnpackEncodedString(DFA5_specialS);
    static readonly short[][] DFA5_transition = DFA.UnpackEncodedStringArray(DFA5_transitionS);

    protected class DFA5 : DFA
    {
        public DFA5(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 5;
            this.eot = DFA5_eot;
            this.eof = DFA5_eof;
            this.min = DFA5_min;
            this.max = DFA5_max;
            this.accept = DFA5_accept;
            this.special = DFA5_special;
            this.transition = DFA5_transition;

        }

        override public string Description
        {
            get { return "48:1: element_no_negative : ( positive_number | number_as_string | interval | LT num1= number | GT num1= number | LE num1= number | GE num1= number | NE num1= number | EQ num1= number | T_NULL | T_NOT T_NULL );"; }
        }

    }

    const string DFA6_eotS =
        "\x0b\uffff";
    const string DFA6_eofS =
        "\x03\uffff\x01\x05\x02\uffff\x01\x02\x01\uffff\x01\x05\x01\uffff"+
        "\x01\x02";
    const string DFA6_minS =
        "\x01\x04\x01\x05\x01\uffff\x01\x04\x01\x05\x01\uffff\x01\x04\x01"+
        "\x05\x01\x04\x01\x05\x01\x04";
    const string DFA6_maxS =
        "\x01\x0f\x01\x05\x01\uffff\x01\x11\x01\x07\x01\uffff\x01\x11\x01"+
        "\x07\x01\x11\x01\x07\x01\x11";
    const string DFA6_acceptS =
        "\x02\uffff\x01\x02\x02\uffff\x01\x01\x05\uffff";
    const string DFA6_specialS =
        "\x0b\uffff}>";
    static readonly string[] DFA6_transitionS = {
            "\x01\x01\x0b\x02",
            "\x01\x03",
            "",
            "\x01\x04\x0d\x05",
            "\x01\x06\x02\x02",
            "",
            "\x01\x07\x0d\x02",
            "\x01\x08\x02\x05",
            "\x01\x09\x0d\x05",
            "\x01\x0a\x02\x02",
            "\x01\x07\x0d\x02"
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
            get { return "62:1: element_maybe_negative : ( negative_number | element_no_negative );"; }
        }

    }

    const string DFA10_eotS =
        "\x04\uffff";
    const string DFA10_eofS =
        "\x02\x02\x02\uffff";
    const string DFA10_minS =
        "\x01\x10\x01\x04\x02\uffff";
    const string DFA10_maxS =
        "\x02\x11\x02\uffff";
    const string DFA10_acceptS =
        "\x02\uffff\x01\x02\x01\x01";
    const string DFA10_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA10_transitionS = {
            "\x01\x03\x01\x01",
            "\x0c\x03\x01\uffff\x01\x01",
            "",
            ""
    };

    static readonly short[] DFA10_eot = DFA.UnpackEncodedString(DFA10_eotS);
    static readonly short[] DFA10_eof = DFA.UnpackEncodedString(DFA10_eofS);
    static readonly char[] DFA10_min = DFA.UnpackEncodedStringToUnsignedChars(DFA10_minS);
    static readonly char[] DFA10_max = DFA.UnpackEncodedStringToUnsignedChars(DFA10_maxS);
    static readonly short[] DFA10_accept = DFA.UnpackEncodedString(DFA10_acceptS);
    static readonly short[] DFA10_special = DFA.UnpackEncodedString(DFA10_specialS);
    static readonly short[][] DFA10_transition = DFA.UnpackEncodedStringArray(DFA10_transitionS);

    protected class DFA10 : DFA
    {
        public DFA10(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 10;
            this.eot = DFA10_eot;
            this.eof = DFA10_eof;
            this.min = DFA10_min;
            this.max = DFA10_max;
            this.accept = DFA10_accept;
            this.special = DFA10_special;
            this.transition = DFA10_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 71:10: ( ( COMMA | ( ( ENDLINE )+ ) ) factor )*"; }
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
    public static readonly BitSet FOLLOW_positive_number_in_element_no_negative160 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_number_as_string_in_element_no_negative169 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_interval_in_element_no_negative178 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_element_no_negative184 = new BitSet(new ulong[]{0x00000000000000F0UL});
    public static readonly BitSet FOLLOW_number_in_element_no_negative188 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GT_in_element_no_negative197 = new BitSet(new ulong[]{0x00000000000000F0UL});
    public static readonly BitSet FOLLOW_number_in_element_no_negative201 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LE_in_element_no_negative210 = new BitSet(new ulong[]{0x00000000000000F0UL});
    public static readonly BitSet FOLLOW_number_in_element_no_negative214 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GE_in_element_no_negative223 = new BitSet(new ulong[]{0x00000000000000F0UL});
    public static readonly BitSet FOLLOW_number_in_element_no_negative227 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NE_in_element_no_negative236 = new BitSet(new ulong[]{0x00000000000000F0UL});
    public static readonly BitSet FOLLOW_number_in_element_no_negative240 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EQ_in_element_no_negative249 = new BitSet(new ulong[]{0x00000000000000F0UL});
    public static readonly BitSet FOLLOW_number_in_element_no_negative253 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NULL_in_element_no_negative262 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NOT_in_element_no_negative270 = new BitSet(new ulong[]{0x0000000000004000UL});
    public static readonly BitSet FOLLOW_T_NULL_in_element_no_negative272 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_negative_number_in_element_maybe_negative288 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_element_no_negative_in_element_maybe_negative296 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_element_maybe_negative_in_factor309 = new BitSet(new ulong[]{0x000000000000FFF2UL});
    public static readonly BitSet FOLLOW_element_no_negative_in_factor311 = new BitSet(new ulong[]{0x000000000000FFF2UL});
    public static readonly BitSet FOLLOW_factor_in_list322 = new BitSet(new ulong[]{0x0000000000030002UL});
    public static readonly BitSet FOLLOW_COMMA_in_list327 = new BitSet(new ulong[]{0x000000000000FFF0UL});
    public static readonly BitSet FOLLOW_ENDLINE_in_list332 = new BitSet(new ulong[]{0x000000000002FFF0UL});
    public static readonly BitSet FOLLOW_factor_in_list339 = new BitSet(new ulong[]{0x0000000000030002UL});
    public static readonly BitSet FOLLOW_ENDLINE_in_list345 = new BitSet(new ulong[]{0x0000000000020002UL});
    public static readonly BitSet FOLLOW_list_in_expr355 = new BitSet(new ulong[]{0x0000000000000002UL});

}
