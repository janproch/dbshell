// $ANTLR 3.2 Sep 23, 2009 12:02:23 NumberFilter.g 2016-09-07 21:54:31

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
		"SQL_VARIABLE", 
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

    public const int LT = 11;
    public const int EOF = -1;
    public const int Q_STRING = 6;
    public const int COMMA = 21;
    public const int T_NULL = 17;
    public const int DIGIT = 28;
    public const int EQ = 16;
    public const int DOT = 9;
    public const int NE = 15;
    public const int D = 33;
    public const int E = 34;
    public const int GE = 14;
    public const int F = 35;
    public const int G = 36;
    public const int SQL_VARIABLE = 10;
    public const int A = 30;
    public const int B = 31;
    public const int NE2 = 20;
    public const int C = 32;
    public const int L = 25;
    public const int M = 41;
    public const int N = 23;
    public const int O = 26;
    public const int H = 37;
    public const int I = 38;
    public const int J = 39;
    public const int NUMBER = 5;
    public const int K = 40;
    public const int U = 24;
    public const int T = 27;
    public const int W = 47;
    public const int WHITESPACE = 29;
    public const int V = 46;
    public const int Q = 43;
    public const int P = 42;
    public const int S = 45;
    public const int R = 44;
    public const int MINUS = 4;
    public const int Y = 49;
    public const int X = 48;
    public const int SQL_LITERAL = 8;
    public const int EQ2 = 19;
    public const int Z = 50;
    public const int A_STRING = 7;
    public const int GT = 12;
    public const int ENDLINE = 22;
    public const int T_NOT = 18;
    public const int LE = 13;

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

                    if ( (LA4_5 == NUMBER) )
                    {
                        alt4 = 1;
                    }
                    else if ( ((LA4_5 >= Q_STRING && LA4_5 <= A_STRING)) )
                    {
                        alt4 = 2;
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

                        if ( (LA4_5 == NUMBER) )
                        {
                            alt4 = 1;
                        }
                        else if ( ((LA4_5 >= Q_STRING && LA4_5 <= A_STRING)) )
                        {
                            alt4 = 2;
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

                    if ( (LA4_5 == NUMBER) )
                    {
                        alt4 = 1;
                    }
                    else if ( ((LA4_5 >= Q_STRING && LA4_5 <= A_STRING)) )
                    {
                        alt4 = 2;
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

                    if ( (LA4_5 == NUMBER) )
                    {
                        alt4 = 1;
                    }
                    else if ( ((LA4_5 >= Q_STRING && LA4_5 <= A_STRING)) )
                    {
                        alt4 = 2;
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

    public class sql_identifier_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "sql_identifier"
    // NumberFilter.g:48:1: sql_identifier : lit1= SQL_LITERAL ( DOT lit2= SQL_LITERAL )* ;
    public NumberFilterParser.sql_identifier_return sql_identifier() // throws RecognitionException [1]
    {   
        NumberFilterParser.sql_identifier_return retval = new NumberFilterParser.sql_identifier_return();
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
            // NumberFilter.g:48:15: (lit1= SQL_LITERAL ( DOT lit2= SQL_LITERAL )* )
            // NumberFilter.g:49:3: lit1= SQL_LITERAL ( DOT lit2= SQL_LITERAL )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	lit1=(IToken)Match(input,SQL_LITERAL,FOLLOW_SQL_LITERAL_in_sql_identifier161); 
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
            			    	DOT11=(IToken)Match(input,DOT,FOLLOW_DOT_in_sql_identifier168); 
            			    		DOT11_tree = (object)adaptor.Create(DOT11);
            			    		adaptor.AddChild(root_0, DOT11_tree);

            			    	lit2=(IToken)Match(input,SQL_LITERAL,FOLLOW_SQL_LITERAL_in_sql_identifier172); 
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
    // $ANTLR end "sql_identifier"

    public class sql_variable_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "sql_variable"
    // NumberFilter.g:53:1: sql_variable : var= SQL_VARIABLE ;
    public NumberFilterParser.sql_variable_return sql_variable() // throws RecognitionException [1]
    {   
        NumberFilterParser.sql_variable_return retval = new NumberFilterParser.sql_variable_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken var = null;

        object var_tree=null;

        try 
    	{
            // NumberFilter.g:53:13: (var= SQL_VARIABLE )
            // NumberFilter.g:54:5: var= SQL_VARIABLE
            {
            	root_0 = (object)adaptor.GetNilNode();

            	var=(IToken)Match(input,SQL_VARIABLE,FOLLOW_SQL_VARIABLE_in_sql_variable197); 
            		var_tree = (object)adaptor.Create(var);
            		adaptor.AddChild(root_0, var_tree);

            	 Push(((var != null) ? var.Text : null)); 

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
    // $ANTLR end "sql_variable"

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
    // NumberFilter.g:56:1: sql_name : ( sql_identifier | sql_variable );
    public NumberFilterParser.sql_name_return sql_name() // throws RecognitionException [1]
    {   
        NumberFilterParser.sql_name_return retval = new NumberFilterParser.sql_name_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        NumberFilterParser.sql_identifier_return sql_identifier12 = default(NumberFilterParser.sql_identifier_return);

        NumberFilterParser.sql_variable_return sql_variable13 = default(NumberFilterParser.sql_variable_return);



        try 
    	{
            // NumberFilter.g:56:10: ( sql_identifier | sql_variable )
            int alt6 = 2;
            int LA6_0 = input.LA(1);

            if ( (LA6_0 == SQL_LITERAL) )
            {
                alt6 = 1;
            }
            else if ( (LA6_0 == SQL_VARIABLE) )
            {
                alt6 = 2;
            }
            else 
            {
                NoViableAltException nvae_d6s0 =
                    new NoViableAltException("", 6, 0, input);

                throw nvae_d6s0;
            }
            switch (alt6) 
            {
                case 1 :
                    // NumberFilter.g:56:12: sql_identifier
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_sql_identifier_in_sql_name209);
                    	sql_identifier12 = sql_identifier();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_identifier12.Tree);

                    }
                    break;
                case 2 :
                    // NumberFilter.g:56:29: sql_variable
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_sql_variable_in_sql_name213);
                    	sql_variable13 = sql_variable();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_variable13.Tree);

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
    // NumberFilter.g:59:1: element_no_negative : ( positive_number | number_as_string | interval | LT num1= number | GT num1= number | LE num1= number | GE num1= number | NE num1= number | EQ num1= number | T_NULL | T_NOT T_NULL | LT sql_name | GT sql_name | LE sql_name | GE sql_name | NE sql_name | EQ sql_name | EQ2 sql_name | NE2 sql_name );
    public NumberFilterParser.element_no_negative_return element_no_negative() // throws RecognitionException [1]
    {   
        NumberFilterParser.element_no_negative_return retval = new NumberFilterParser.element_no_negative_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken LT17 = null;
        IToken GT18 = null;
        IToken LE19 = null;
        IToken GE20 = null;
        IToken NE21 = null;
        IToken EQ22 = null;
        IToken T_NULL23 = null;
        IToken T_NOT24 = null;
        IToken T_NULL25 = null;
        IToken LT26 = null;
        IToken GT28 = null;
        IToken LE30 = null;
        IToken GE32 = null;
        IToken NE34 = null;
        IToken EQ36 = null;
        IToken EQ238 = null;
        IToken NE240 = null;
        NumberFilterParser.number_return num1 = default(NumberFilterParser.number_return);

        NumberFilterParser.positive_number_return positive_number14 = default(NumberFilterParser.positive_number_return);

        NumberFilterParser.number_as_string_return number_as_string15 = default(NumberFilterParser.number_as_string_return);

        NumberFilterParser.interval_return interval16 = default(NumberFilterParser.interval_return);

        NumberFilterParser.sql_name_return sql_name27 = default(NumberFilterParser.sql_name_return);

        NumberFilterParser.sql_name_return sql_name29 = default(NumberFilterParser.sql_name_return);

        NumberFilterParser.sql_name_return sql_name31 = default(NumberFilterParser.sql_name_return);

        NumberFilterParser.sql_name_return sql_name33 = default(NumberFilterParser.sql_name_return);

        NumberFilterParser.sql_name_return sql_name35 = default(NumberFilterParser.sql_name_return);

        NumberFilterParser.sql_name_return sql_name37 = default(NumberFilterParser.sql_name_return);

        NumberFilterParser.sql_name_return sql_name39 = default(NumberFilterParser.sql_name_return);

        NumberFilterParser.sql_name_return sql_name41 = default(NumberFilterParser.sql_name_return);


        object LT17_tree=null;
        object GT18_tree=null;
        object LE19_tree=null;
        object GE20_tree=null;
        object NE21_tree=null;
        object EQ22_tree=null;
        object T_NULL23_tree=null;
        object T_NOT24_tree=null;
        object T_NULL25_tree=null;
        object LT26_tree=null;
        object GT28_tree=null;
        object LE30_tree=null;
        object GE32_tree=null;
        object NE34_tree=null;
        object EQ36_tree=null;
        object EQ238_tree=null;
        object NE240_tree=null;

        try 
    	{
            // NumberFilter.g:59:20: ( positive_number | number_as_string | interval | LT num1= number | GT num1= number | LE num1= number | GE num1= number | NE num1= number | EQ num1= number | T_NULL | T_NOT T_NULL | LT sql_name | GT sql_name | LE sql_name | GE sql_name | NE sql_name | EQ sql_name | EQ2 sql_name | NE2 sql_name )
            int alt7 = 19;
            alt7 = dfa7.Predict(input);
            switch (alt7) 
            {
                case 1 :
                    // NumberFilter.g:60:3: positive_number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_positive_number_in_element_no_negative224);
                    	positive_number14 = positive_number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, positive_number14.Tree);
                    	 AddNumberEqualCondition(Pop<decimal>()); 

                    }
                    break;
                case 2 :
                    // NumberFilter.g:61:5: number_as_string
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_number_as_string_in_element_no_negative233);
                    	number_as_string15 = number_as_string();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, number_as_string15.Tree);
                    	 AddNumberEqualCondition(Pop<decimal>()); 

                    }
                    break;
                case 3 :
                    // NumberFilter.g:62:5: interval
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_interval_in_element_no_negative242);
                    	interval16 = interval();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, interval16.Tree);

                    }
                    break;
                case 4 :
                    // NumberFilter.g:63:5: LT num1= number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LT17=(IToken)Match(input,LT,FOLLOW_LT_in_element_no_negative248); 
                    		LT17_tree = (object)adaptor.Create(LT17);
                    		adaptor.AddChild(root_0, LT17_tree);

                    	PushFollow(FOLLOW_number_in_element_no_negative252);
                    	num1 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, num1.Tree);
                    	 AddNumberRelation(Pop<decimal>(), "<"); 

                    }
                    break;
                case 5 :
                    // NumberFilter.g:64:5: GT num1= number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GT18=(IToken)Match(input,GT,FOLLOW_GT_in_element_no_negative261); 
                    		GT18_tree = (object)adaptor.Create(GT18);
                    		adaptor.AddChild(root_0, GT18_tree);

                    	PushFollow(FOLLOW_number_in_element_no_negative265);
                    	num1 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, num1.Tree);
                    	 AddNumberRelation(Pop<decimal>(), ">"); 

                    }
                    break;
                case 6 :
                    // NumberFilter.g:65:5: LE num1= number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LE19=(IToken)Match(input,LE,FOLLOW_LE_in_element_no_negative274); 
                    		LE19_tree = (object)adaptor.Create(LE19);
                    		adaptor.AddChild(root_0, LE19_tree);

                    	PushFollow(FOLLOW_number_in_element_no_negative278);
                    	num1 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, num1.Tree);
                    	 AddNumberRelation(Pop<decimal>(), "<="); 

                    }
                    break;
                case 7 :
                    // NumberFilter.g:66:5: GE num1= number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GE20=(IToken)Match(input,GE,FOLLOW_GE_in_element_no_negative287); 
                    		GE20_tree = (object)adaptor.Create(GE20);
                    		adaptor.AddChild(root_0, GE20_tree);

                    	PushFollow(FOLLOW_number_in_element_no_negative291);
                    	num1 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, num1.Tree);
                    	 AddNumberRelation(Pop<decimal>(), ">="); 

                    }
                    break;
                case 8 :
                    // NumberFilter.g:67:5: NE num1= number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NE21=(IToken)Match(input,NE,FOLLOW_NE_in_element_no_negative300); 
                    		NE21_tree = (object)adaptor.Create(NE21);
                    		adaptor.AddChild(root_0, NE21_tree);

                    	PushFollow(FOLLOW_number_in_element_no_negative304);
                    	num1 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, num1.Tree);
                    	 AddNumberRelation(Pop<decimal>(), "<>"); 

                    }
                    break;
                case 9 :
                    // NumberFilter.g:68:5: EQ num1= number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	EQ22=(IToken)Match(input,EQ,FOLLOW_EQ_in_element_no_negative313); 
                    		EQ22_tree = (object)adaptor.Create(EQ22);
                    		adaptor.AddChild(root_0, EQ22_tree);

                    	PushFollow(FOLLOW_number_in_element_no_negative317);
                    	num1 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, num1.Tree);
                    	 AddNumberRelation(Pop<decimal>(), "="); 

                    }
                    break;
                case 10 :
                    // NumberFilter.g:69:5: T_NULL
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NULL23=(IToken)Match(input,T_NULL,FOLLOW_T_NULL_in_element_no_negative326); 
                    		T_NULL23_tree = (object)adaptor.Create(T_NULL23);
                    		adaptor.AddChild(root_0, T_NULL23_tree);

                    	 AddIsNullCondition(); 

                    }
                    break;
                case 11 :
                    // NumberFilter.g:70:5: T_NOT T_NULL
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NOT24=(IToken)Match(input,T_NOT,FOLLOW_T_NOT_in_element_no_negative334); 
                    		T_NOT24_tree = (object)adaptor.Create(T_NOT24);
                    		adaptor.AddChild(root_0, T_NOT24_tree);

                    	T_NULL25=(IToken)Match(input,T_NULL,FOLLOW_T_NULL_in_element_no_negative336); 
                    		T_NULL25_tree = (object)adaptor.Create(T_NULL25);
                    		adaptor.AddChild(root_0, T_NULL25_tree);

                    	 AddIsNotNullCondition(); 

                    }
                    break;
                case 12 :
                    // NumberFilter.g:72:5: LT sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LT26=(IToken)Match(input,LT,FOLLOW_LT_in_element_no_negative347); 
                    		LT26_tree = (object)adaptor.Create(LT26);
                    		adaptor.AddChild(root_0, LT26_tree);

                    	PushFollow(FOLLOW_sql_name_in_element_no_negative349);
                    	sql_name27 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name27.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), "<"); 

                    }
                    break;
                case 13 :
                    // NumberFilter.g:73:5: GT sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GT28=(IToken)Match(input,GT,FOLLOW_GT_in_element_no_negative358); 
                    		GT28_tree = (object)adaptor.Create(GT28);
                    		adaptor.AddChild(root_0, GT28_tree);

                    	PushFollow(FOLLOW_sql_name_in_element_no_negative360);
                    	sql_name29 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name29.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), ">"); 

                    }
                    break;
                case 14 :
                    // NumberFilter.g:74:5: LE sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LE30=(IToken)Match(input,LE,FOLLOW_LE_in_element_no_negative369); 
                    		LE30_tree = (object)adaptor.Create(LE30);
                    		adaptor.AddChild(root_0, LE30_tree);

                    	PushFollow(FOLLOW_sql_name_in_element_no_negative371);
                    	sql_name31 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name31.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), "<="); 

                    }
                    break;
                case 15 :
                    // NumberFilter.g:75:5: GE sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GE32=(IToken)Match(input,GE,FOLLOW_GE_in_element_no_negative380); 
                    		GE32_tree = (object)adaptor.Create(GE32);
                    		adaptor.AddChild(root_0, GE32_tree);

                    	PushFollow(FOLLOW_sql_name_in_element_no_negative382);
                    	sql_name33 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name33.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), ">="); 

                    }
                    break;
                case 16 :
                    // NumberFilter.g:76:5: NE sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NE34=(IToken)Match(input,NE,FOLLOW_NE_in_element_no_negative391); 
                    		NE34_tree = (object)adaptor.Create(NE34);
                    		adaptor.AddChild(root_0, NE34_tree);

                    	PushFollow(FOLLOW_sql_name_in_element_no_negative393);
                    	sql_name35 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name35.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), "<>"); 

                    }
                    break;
                case 17 :
                    // NumberFilter.g:77:5: EQ sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	EQ36=(IToken)Match(input,EQ,FOLLOW_EQ_in_element_no_negative402); 
                    		EQ36_tree = (object)adaptor.Create(EQ36);
                    		adaptor.AddChild(root_0, EQ36_tree);

                    	PushFollow(FOLLOW_sql_name_in_element_no_negative404);
                    	sql_name37 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name37.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), "="); 

                    }
                    break;
                case 18 :
                    // NumberFilter.g:78:5: EQ2 sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	EQ238=(IToken)Match(input,EQ2,FOLLOW_EQ2_in_element_no_negative412); 
                    		EQ238_tree = (object)adaptor.Create(EQ238);
                    		adaptor.AddChild(root_0, EQ238_tree);

                    	PushFollow(FOLLOW_sql_name_in_element_no_negative414);
                    	sql_name39 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name39.Tree);
                    	 AddSqlLiteralRelationWithNullTest_EQ(Pop<string>()); 

                    }
                    break;
                case 19 :
                    // NumberFilter.g:79:5: NE2 sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NE240=(IToken)Match(input,NE2,FOLLOW_NE2_in_element_no_negative423); 
                    		NE240_tree = (object)adaptor.Create(NE240);
                    		adaptor.AddChild(root_0, NE240_tree);

                    	PushFollow(FOLLOW_sql_name_in_element_no_negative425);
                    	sql_name41 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name41.Tree);
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
    // NumberFilter.g:82:1: element_maybe_negative : ( negative_number | element_no_negative );
    public NumberFilterParser.element_maybe_negative_return element_maybe_negative() // throws RecognitionException [1]
    {   
        NumberFilterParser.element_maybe_negative_return retval = new NumberFilterParser.element_maybe_negative_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        NumberFilterParser.negative_number_return negative_number42 = default(NumberFilterParser.negative_number_return);

        NumberFilterParser.element_no_negative_return element_no_negative43 = default(NumberFilterParser.element_no_negative_return);



        try 
    	{
            // NumberFilter.g:82:23: ( negative_number | element_no_negative )
            int alt8 = 2;
            alt8 = dfa8.Predict(input);
            switch (alt8) 
            {
                case 1 :
                    // NumberFilter.g:83:3: negative_number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_negative_number_in_element_maybe_negative441);
                    	negative_number42 = negative_number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, negative_number42.Tree);
                    	 AddNumberEqualCondition(Pop<decimal>()); 

                    }
                    break;
                case 2 :
                    // NumberFilter.g:84:5: element_no_negative
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_element_no_negative_in_element_maybe_negative449);
                    	element_no_negative43 = element_no_negative();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, element_no_negative43.Tree);

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
    // NumberFilter.g:87:1: factor : element_maybe_negative ( element_no_negative )* ;
    public NumberFilterParser.factor_return factor() // throws RecognitionException [1]
    {   
        NumberFilterParser.factor_return retval = new NumberFilterParser.factor_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        NumberFilterParser.element_maybe_negative_return element_maybe_negative44 = default(NumberFilterParser.element_maybe_negative_return);

        NumberFilterParser.element_no_negative_return element_no_negative45 = default(NumberFilterParser.element_no_negative_return);



        try 
    	{
            // NumberFilter.g:87:8: ( element_maybe_negative ( element_no_negative )* )
            // NumberFilter.g:88:3: element_maybe_negative ( element_no_negative )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_element_maybe_negative_in_factor462);
            	element_maybe_negative44 = element_maybe_negative();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, element_maybe_negative44.Tree);
            	// NumberFilter.g:88:26: ( element_no_negative )*
            	do 
            	{
            	    int alt9 = 2;
            	    int LA9_0 = input.LA(1);

            	    if ( ((LA9_0 >= MINUS && LA9_0 <= A_STRING) || (LA9_0 >= LT && LA9_0 <= NE2)) )
            	    {
            	        alt9 = 1;
            	    }


            	    switch (alt9) 
            		{
            			case 1 :
            			    // NumberFilter.g:88:26: element_no_negative
            			    {
            			    	PushFollow(FOLLOW_element_no_negative_in_factor464);
            			    	element_no_negative45 = element_no_negative();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, element_no_negative45.Tree);

            			    }
            			    break;

            			default:
            			    goto loop9;
            	    }
            	} while (true);

            	loop9:
            		;	// Stops C# compiler whining that label 'loop9' has no statements


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
    // NumberFilter.g:90:1: list : factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )* ;
    public NumberFilterParser.list_return list() // throws RecognitionException [1]
    {   
        NumberFilterParser.list_return retval = new NumberFilterParser.list_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken COMMA47 = null;
        IToken ENDLINE48 = null;
        IToken ENDLINE50 = null;
        NumberFilterParser.factor_return factor46 = default(NumberFilterParser.factor_return);

        NumberFilterParser.factor_return factor49 = default(NumberFilterParser.factor_return);


        object COMMA47_tree=null;
        object ENDLINE48_tree=null;
        object ENDLINE50_tree=null;

        try 
    	{
            // NumberFilter.g:90:5: ( factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )* )
            // NumberFilter.g:91:3: factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_factor_in_list475);
            	factor46 = factor();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, factor46.Tree);
            	// NumberFilter.g:91:10: ( ( COMMA | ( ( ENDLINE )+ ) ) factor )*
            	do 
            	{
            	    int alt12 = 2;
            	    alt12 = dfa12.Predict(input);
            	    switch (alt12) 
            		{
            			case 1 :
            			    // NumberFilter.g:91:12: ( COMMA | ( ( ENDLINE )+ ) ) factor
            			    {
            			    	// NumberFilter.g:91:12: ( COMMA | ( ( ENDLINE )+ ) )
            			    	int alt11 = 2;
            			    	int LA11_0 = input.LA(1);

            			    	if ( (LA11_0 == COMMA) )
            			    	{
            			    	    alt11 = 1;
            			    	}
            			    	else if ( (LA11_0 == ENDLINE) )
            			    	{
            			    	    alt11 = 2;
            			    	}
            			    	else 
            			    	{
            			    	    NoViableAltException nvae_d11s0 =
            			    	        new NoViableAltException("", 11, 0, input);

            			    	    throw nvae_d11s0;
            			    	}
            			    	switch (alt11) 
            			    	{
            			    	    case 1 :
            			    	        // NumberFilter.g:91:13: COMMA
            			    	        {
            			    	        	COMMA47=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_list480); 
            			    	        		COMMA47_tree = (object)adaptor.Create(COMMA47);
            			    	        		adaptor.AddChild(root_0, COMMA47_tree);


            			    	        }
            			    	        break;
            			    	    case 2 :
            			    	        // NumberFilter.g:91:21: ( ( ENDLINE )+ )
            			    	        {
            			    	        	// NumberFilter.g:91:21: ( ( ENDLINE )+ )
            			    	        	// NumberFilter.g:91:22: ( ENDLINE )+
            			    	        	{
            			    	        		// NumberFilter.g:91:22: ( ENDLINE )+
            			    	        		int cnt10 = 0;
            			    	        		do 
            			    	        		{
            			    	        		    int alt10 = 2;
            			    	        		    int LA10_0 = input.LA(1);

            			    	        		    if ( (LA10_0 == ENDLINE) )
            			    	        		    {
            			    	        		        alt10 = 1;
            			    	        		    }


            			    	        		    switch (alt10) 
            			    	        			{
            			    	        				case 1 :
            			    	        				    // NumberFilter.g:91:22: ENDLINE
            			    	        				    {
            			    	        				    	ENDLINE48=(IToken)Match(input,ENDLINE,FOLLOW_ENDLINE_in_list485); 
            			    	        				    		ENDLINE48_tree = (object)adaptor.Create(ENDLINE48);
            			    	        				    		adaptor.AddChild(root_0, ENDLINE48_tree);


            			    	        				    }
            			    	        				    break;

            			    	        				default:
            			    	        				    if ( cnt10 >= 1 ) goto loop10;
            			    	        			            EarlyExitException eee10 =
            			    	        			                new EarlyExitException(10, input);
            			    	        			            throw eee10;
            			    	        		    }
            			    	        		    cnt10++;
            			    	        		} while (true);

            			    	        		loop10:
            			    	        			;	// Stops C# compiler whining that label 'loop10' has no statements


            			    	        	}


            			    	        }
            			    	        break;

            			    	}

            			    	 AddAndCondition(); 
            			    	PushFollow(FOLLOW_factor_in_list492);
            			    	factor49 = factor();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, factor49.Tree);

            			    }
            			    break;

            			default:
            			    goto loop12;
            	    }
            	} while (true);

            	loop12:
            		;	// Stops C# compiler whining that label 'loop12' has no statements

            	// NumberFilter.g:91:67: ( ENDLINE )*
            	do 
            	{
            	    int alt13 = 2;
            	    int LA13_0 = input.LA(1);

            	    if ( (LA13_0 == ENDLINE) )
            	    {
            	        alt13 = 1;
            	    }


            	    switch (alt13) 
            		{
            			case 1 :
            			    // NumberFilter.g:91:67: ENDLINE
            			    {
            			    	ENDLINE50=(IToken)Match(input,ENDLINE,FOLLOW_ENDLINE_in_list498); 
            			    		ENDLINE50_tree = (object)adaptor.Create(ENDLINE50);
            			    		adaptor.AddChild(root_0, ENDLINE50_tree);


            			    }
            			    break;

            			default:
            			    goto loop13;
            	    }
            	} while (true);

            	loop13:
            		;	// Stops C# compiler whining that label 'loop13' has no statements


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
    // NumberFilter.g:93:1: expr : list ;
    public NumberFilterParser.expr_return expr() // throws RecognitionException [1]
    {   
        NumberFilterParser.expr_return retval = new NumberFilterParser.expr_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        NumberFilterParser.list_return list51 = default(NumberFilterParser.list_return);



        try 
    	{
            // NumberFilter.g:93:5: ( list )
            // NumberFilter.g:93:7: list
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_list_in_expr508);
            	list51 = list();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, list51.Tree);

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


   	protected DFA7 dfa7;
   	protected DFA8 dfa8;
   	protected DFA12 dfa12;
	private void InitializeCyclicDFAs()
	{
    	this.dfa7 = new DFA7(this);
    	this.dfa8 = new DFA8(this);
    	this.dfa12 = new DFA12(this);
	}

    const string DFA7_eotS =
        "\x29\uffff";
    const string DFA7_eofS =
        "\x01\uffff\x01\x10\x02\x12\x1b\uffff\x02\x04\x02\uffff\x01\x10"+
        "\x01\x12\x02\uffff\x02\x04";
    const string DFA7_minS =
        "\x04\x04\x01\uffff\x06\x04\x04\uffff\x01\x05\x01\uffff\x01\x05"+
        "\x0d\uffff\x02\x04\x02\x05\x02\x04\x02\x05\x02\x04";
    const string DFA7_maxS =
        "\x01\x14\x03\x16\x01\uffff\x06\x0a\x04\uffff\x01\x07\x01\uffff"+
        "\x01\x07\x0d\uffff\x02\x16\x02\x07\x02\x16\x02\x07\x02\x16";
    const string DFA7_acceptS =
        "\x04\uffff\x01\x03\x06\uffff\x01\x0a\x01\x0b\x01\x12\x01\x13\x01"+
        "\uffff\x01\x01\x01\uffff\x01\x02\x01\x0c\x01\x04\x01\x05\x01\x0d"+
        "\x01\x0e\x01\x06\x01\x07\x01\x0f\x01\x10\x01\x08\x01\x09\x01\x11"+
        "\x0a\uffff";
    const string DFA7_specialS =
        "\x29\uffff}>";
    static readonly string[] DFA7_transitionS = {
            "\x01\x04\x01\x01\x01\x02\x01\x03\x03\uffff\x01\x05\x01\x06"+
            "\x01\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x01\x0c\x01\x0d\x01"+
            "\x0e",
            "\x01\x0f\x03\x10\x03\uffff\x0c\x10",
            "\x01\x11\x03\x12\x03\uffff\x0c\x12",
            "\x01\x11\x03\x12\x03\uffff\x0c\x12",
            "",
            "\x04\x14\x01\x13\x01\uffff\x01\x13",
            "\x04\x15\x01\x16\x01\uffff\x01\x16",
            "\x04\x18\x01\x17\x01\uffff\x01\x17",
            "\x04\x19\x01\x1a\x01\uffff\x01\x1a",
            "\x04\x1c\x01\x1b\x01\uffff\x01\x1b",
            "\x04\x1d\x01\x1e\x01\uffff\x01\x1e",
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
            "\x01\x21\x03\x04\x03\uffff\x0c\x04",
            "\x01\x22\x03\x04\x03\uffff\x0c\x04",
            "\x01\x23\x02\x10",
            "\x01\x24\x02\x12",
            "\x01\x25\x03\x10\x03\uffff\x0c\x10",
            "\x01\x26\x03\x12\x03\uffff\x0c\x12",
            "\x01\x27\x02\x04",
            "\x01\x28\x02\x04",
            "\x01\x21\x03\x04\x03\uffff\x0c\x04",
            "\x01\x22\x03\x04\x03\uffff\x0c\x04"
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
            get { return "59:1: element_no_negative : ( positive_number | number_as_string | interval | LT num1= number | GT num1= number | LE num1= number | GE num1= number | NE num1= number | EQ num1= number | T_NULL | T_NOT T_NULL | LT sql_name | GT sql_name | LE sql_name | GE sql_name | NE sql_name | EQ sql_name | EQ2 sql_name | NE2 sql_name );"; }
        }

    }

    const string DFA8_eotS =
        "\x0b\uffff";
    const string DFA8_eofS =
        "\x03\uffff\x01\x05\x02\uffff\x01\x02\x01\uffff\x01\x05\x01\uffff"+
        "\x01\x02";
    const string DFA8_minS =
        "\x01\x04\x01\x05\x01\uffff\x01\x04\x01\x05\x01\uffff\x01\x04\x01"+
        "\x05\x01\x04\x01\x05\x01\x04";
    const string DFA8_maxS =
        "\x01\x14\x01\x05\x01\uffff\x01\x16\x01\x07\x01\uffff\x01\x16\x01"+
        "\x07\x01\x16\x01\x07\x01\x16";
    const string DFA8_acceptS =
        "\x02\uffff\x01\x02\x02\uffff\x01\x01\x05\uffff";
    const string DFA8_specialS =
        "\x0b\uffff}>";
    static readonly string[] DFA8_transitionS = {
            "\x01\x01\x03\x02\x03\uffff\x0a\x02",
            "\x01\x03",
            "",
            "\x01\x04\x03\x05\x03\uffff\x0c\x05",
            "\x01\x06\x02\x02",
            "",
            "\x01\x07\x03\x02\x03\uffff\x0c\x02",
            "\x01\x08\x02\x05",
            "\x01\x09\x03\x05\x03\uffff\x0c\x05",
            "\x01\x0a\x02\x02",
            "\x01\x07\x03\x02\x03\uffff\x0c\x02"
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
            get { return "82:1: element_maybe_negative : ( negative_number | element_no_negative );"; }
        }

    }

    const string DFA12_eotS =
        "\x04\uffff";
    const string DFA12_eofS =
        "\x02\x02\x02\uffff";
    const string DFA12_minS =
        "\x01\x15\x01\x04\x02\uffff";
    const string DFA12_maxS =
        "\x02\x16\x02\uffff";
    const string DFA12_acceptS =
        "\x02\uffff\x01\x02\x01\x01";
    const string DFA12_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA12_transitionS = {
            "\x01\x03\x01\x01",
            "\x04\x03\x03\uffff\x0a\x03\x01\uffff\x01\x01",
            "",
            ""
    };

    static readonly short[] DFA12_eot = DFA.UnpackEncodedString(DFA12_eotS);
    static readonly short[] DFA12_eof = DFA.UnpackEncodedString(DFA12_eofS);
    static readonly char[] DFA12_min = DFA.UnpackEncodedStringToUnsignedChars(DFA12_minS);
    static readonly char[] DFA12_max = DFA.UnpackEncodedStringToUnsignedChars(DFA12_maxS);
    static readonly short[] DFA12_accept = DFA.UnpackEncodedString(DFA12_acceptS);
    static readonly short[] DFA12_special = DFA.UnpackEncodedString(DFA12_specialS);
    static readonly short[][] DFA12_transition = DFA.UnpackEncodedStringArray(DFA12_transitionS);

    protected class DFA12 : DFA
    {
        public DFA12(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 12;
            this.eot = DFA12_eot;
            this.eof = DFA12_eof;
            this.min = DFA12_min;
            this.max = DFA12_max;
            this.accept = DFA12_accept;
            this.special = DFA12_special;
            this.transition = DFA12_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 91:10: ( ( COMMA | ( ( ENDLINE )+ ) ) factor )*"; }
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
    public static readonly BitSet FOLLOW_SQL_LITERAL_in_sql_identifier161 = new BitSet(new ulong[]{0x0000000000000202UL});
    public static readonly BitSet FOLLOW_DOT_in_sql_identifier168 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_SQL_LITERAL_in_sql_identifier172 = new BitSet(new ulong[]{0x0000000000000202UL});
    public static readonly BitSet FOLLOW_SQL_VARIABLE_in_sql_variable197 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_sql_identifier_in_sql_name209 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_sql_variable_in_sql_name213 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_positive_number_in_element_no_negative224 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_number_as_string_in_element_no_negative233 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_interval_in_element_no_negative242 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_element_no_negative248 = new BitSet(new ulong[]{0x00000000000000F0UL});
    public static readonly BitSet FOLLOW_number_in_element_no_negative252 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GT_in_element_no_negative261 = new BitSet(new ulong[]{0x00000000000000F0UL});
    public static readonly BitSet FOLLOW_number_in_element_no_negative265 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LE_in_element_no_negative274 = new BitSet(new ulong[]{0x00000000000000F0UL});
    public static readonly BitSet FOLLOW_number_in_element_no_negative278 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GE_in_element_no_negative287 = new BitSet(new ulong[]{0x00000000000000F0UL});
    public static readonly BitSet FOLLOW_number_in_element_no_negative291 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NE_in_element_no_negative300 = new BitSet(new ulong[]{0x00000000000000F0UL});
    public static readonly BitSet FOLLOW_number_in_element_no_negative304 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EQ_in_element_no_negative313 = new BitSet(new ulong[]{0x00000000000000F0UL});
    public static readonly BitSet FOLLOW_number_in_element_no_negative317 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NULL_in_element_no_negative326 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NOT_in_element_no_negative334 = new BitSet(new ulong[]{0x0000000000020000UL});
    public static readonly BitSet FOLLOW_T_NULL_in_element_no_negative336 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_element_no_negative347 = new BitSet(new ulong[]{0x0000000000000500UL});
    public static readonly BitSet FOLLOW_sql_name_in_element_no_negative349 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GT_in_element_no_negative358 = new BitSet(new ulong[]{0x0000000000000500UL});
    public static readonly BitSet FOLLOW_sql_name_in_element_no_negative360 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LE_in_element_no_negative369 = new BitSet(new ulong[]{0x0000000000000500UL});
    public static readonly BitSet FOLLOW_sql_name_in_element_no_negative371 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GE_in_element_no_negative380 = new BitSet(new ulong[]{0x0000000000000500UL});
    public static readonly BitSet FOLLOW_sql_name_in_element_no_negative382 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NE_in_element_no_negative391 = new BitSet(new ulong[]{0x0000000000000500UL});
    public static readonly BitSet FOLLOW_sql_name_in_element_no_negative393 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EQ_in_element_no_negative402 = new BitSet(new ulong[]{0x0000000000000500UL});
    public static readonly BitSet FOLLOW_sql_name_in_element_no_negative404 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EQ2_in_element_no_negative412 = new BitSet(new ulong[]{0x0000000000000500UL});
    public static readonly BitSet FOLLOW_sql_name_in_element_no_negative414 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NE2_in_element_no_negative423 = new BitSet(new ulong[]{0x0000000000000500UL});
    public static readonly BitSet FOLLOW_sql_name_in_element_no_negative425 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_negative_number_in_element_maybe_negative441 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_element_no_negative_in_element_maybe_negative449 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_element_maybe_negative_in_factor462 = new BitSet(new ulong[]{0x00000000001FF8F2UL});
    public static readonly BitSet FOLLOW_element_no_negative_in_factor464 = new BitSet(new ulong[]{0x00000000001FF8F2UL});
    public static readonly BitSet FOLLOW_factor_in_list475 = new BitSet(new ulong[]{0x0000000000600002UL});
    public static readonly BitSet FOLLOW_COMMA_in_list480 = new BitSet(new ulong[]{0x00000000001FF8F0UL});
    public static readonly BitSet FOLLOW_ENDLINE_in_list485 = new BitSet(new ulong[]{0x00000000005FF8F0UL});
    public static readonly BitSet FOLLOW_factor_in_list492 = new BitSet(new ulong[]{0x0000000000600002UL});
    public static readonly BitSet FOLLOW_ENDLINE_in_list498 = new BitSet(new ulong[]{0x0000000000400002UL});
    public static readonly BitSet FOLLOW_list_in_expr508 = new BitSet(new ulong[]{0x0000000000000002UL});

}
