// $ANTLR 3.2 Sep 23, 2009 12:02:23 NumberFilter.g 2013-05-18 20:05:54

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
    // NumberFilter.g:20:1: number_as_string : (num1= Q_STRING | num1= A_STRING );
    public NumberFilterParser.number_as_string_return number_as_string() // throws RecognitionException [1]
    {   
        NumberFilterParser.number_as_string_return retval = new NumberFilterParser.number_as_string_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken num1 = null;

        object num1_tree=null;

        try 
    	{
            // NumberFilter.g:20:17: (num1= Q_STRING | num1= A_STRING )
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
                    // NumberFilter.g:21:3: num1= Q_STRING
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	num1=(IToken)Match(input,Q_STRING,FOLLOW_Q_STRING_in_number_as_string80); 
                    		num1_tree = (object)adaptor.Create(num1);
                    		adaptor.AddChild(root_0, num1_tree);


                    }
                    break;
                case 2 :
                    // NumberFilter.g:21:19: num1= A_STRING
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	num1=(IToken)Match(input,A_STRING,FOLLOW_A_STRING_in_number_as_string86); 
                    		num1_tree = (object)adaptor.Create(num1);
                    		adaptor.AddChild(root_0, num1_tree);

                    	 string value=((num1 != null) ? num1.Text : null); Push(Decimal.Parse(value.Substring(1, value.Length - 2), CultureInfo.InvariantCulture)); 

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

                    	PushFollow(FOLLOW_positive_number_in_number99);
                    	positive_number2 = positive_number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, positive_number2.Tree);

                    }
                    break;
                case 2 :
                    // NumberFilter.g:24:21: negative_number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_negative_number_in_number103);
                    	negative_number3 = negative_number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, negative_number3.Tree);

                    }
                    break;
                case 3 :
                    // NumberFilter.g:24:39: number_as_string
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_number_as_string_in_number107);
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
    // NumberFilter.g:26:1: interval : number MINUS num2= NUMBER ;
    public NumberFilterParser.interval_return interval() // throws RecognitionException [1]
    {   
        NumberFilterParser.interval_return retval = new NumberFilterParser.interval_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken num2 = null;
        IToken MINUS6 = null;
        NumberFilterParser.number_return number5 = default(NumberFilterParser.number_return);


        object num2_tree=null;
        object MINUS6_tree=null;

        try 
    	{
            // NumberFilter.g:26:10: ( number MINUS num2= NUMBER )
            // NumberFilter.g:27:1: number MINUS num2= NUMBER
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_number_in_interval116);
            	number5 = number();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, number5.Tree);
            	MINUS6=(IToken)Match(input,MINUS,FOLLOW_MINUS_in_interval118); 
            		MINUS6_tree = (object)adaptor.Create(MINUS6);
            		adaptor.AddChild(root_0, MINUS6_tree);

            	num2=(IToken)Match(input,NUMBER,FOLLOW_NUMBER_in_interval122); 
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
    // NumberFilter.g:37:1: element_no_negative : ( positive_number | interval | LT num1= number | GT num1= number | LE num1= number | GE num1= number | NE num1= number | EQ num1= number | T_NULL | T_NOT T_NULL );
    public NumberFilterParser.element_no_negative_return element_no_negative() // throws RecognitionException [1]
    {   
        NumberFilterParser.element_no_negative_return retval = new NumberFilterParser.element_no_negative_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken LT9 = null;
        IToken GT10 = null;
        IToken LE11 = null;
        IToken GE12 = null;
        IToken NE13 = null;
        IToken EQ14 = null;
        IToken T_NULL15 = null;
        IToken T_NOT16 = null;
        IToken T_NULL17 = null;
        NumberFilterParser.number_return num1 = default(NumberFilterParser.number_return);

        NumberFilterParser.positive_number_return positive_number7 = default(NumberFilterParser.positive_number_return);

        NumberFilterParser.interval_return interval8 = default(NumberFilterParser.interval_return);


        object LT9_tree=null;
        object GT10_tree=null;
        object LE11_tree=null;
        object GE12_tree=null;
        object NE13_tree=null;
        object EQ14_tree=null;
        object T_NULL15_tree=null;
        object T_NOT16_tree=null;
        object T_NULL17_tree=null;

        try 
    	{
            // NumberFilter.g:37:20: ( positive_number | interval | LT num1= number | GT num1= number | LE num1= number | GE num1= number | NE num1= number | EQ num1= number | T_NULL | T_NOT T_NULL )
            int alt3 = 10;
            alt3 = dfa3.Predict(input);
            switch (alt3) 
            {
                case 1 :
                    // NumberFilter.g:38:3: positive_number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_positive_number_in_element_no_negative134);
                    	positive_number7 = positive_number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, positive_number7.Tree);
                    	 AddEqualCondition(Pop<decimal>().ToString(CultureInfo.InvariantCulture)); 

                    }
                    break;
                case 2 :
                    // NumberFilter.g:39:5: interval
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_interval_in_element_no_negative143);
                    	interval8 = interval();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, interval8.Tree);

                    }
                    break;
                case 3 :
                    // NumberFilter.g:40:5: LT num1= number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LT9=(IToken)Match(input,LT,FOLLOW_LT_in_element_no_negative149); 
                    		LT9_tree = (object)adaptor.Create(LT9);
                    		adaptor.AddChild(root_0, LT9_tree);

                    	PushFollow(FOLLOW_number_in_element_no_negative153);
                    	num1 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, num1.Tree);
                    	 AddNumberRelation(((num1 != null) ? input.ToString((IToken)(num1.Start),(IToken)(num1.Stop)) : null), "<"); 

                    }
                    break;
                case 4 :
                    // NumberFilter.g:41:5: GT num1= number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GT10=(IToken)Match(input,GT,FOLLOW_GT_in_element_no_negative162); 
                    		GT10_tree = (object)adaptor.Create(GT10);
                    		adaptor.AddChild(root_0, GT10_tree);

                    	PushFollow(FOLLOW_number_in_element_no_negative166);
                    	num1 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, num1.Tree);
                    	 AddNumberRelation(((num1 != null) ? input.ToString((IToken)(num1.Start),(IToken)(num1.Stop)) : null), ">"); 

                    }
                    break;
                case 5 :
                    // NumberFilter.g:42:5: LE num1= number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LE11=(IToken)Match(input,LE,FOLLOW_LE_in_element_no_negative175); 
                    		LE11_tree = (object)adaptor.Create(LE11);
                    		adaptor.AddChild(root_0, LE11_tree);

                    	PushFollow(FOLLOW_number_in_element_no_negative179);
                    	num1 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, num1.Tree);
                    	 AddNumberRelation(((num1 != null) ? input.ToString((IToken)(num1.Start),(IToken)(num1.Stop)) : null), "<="); 

                    }
                    break;
                case 6 :
                    // NumberFilter.g:43:5: GE num1= number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GE12=(IToken)Match(input,GE,FOLLOW_GE_in_element_no_negative188); 
                    		GE12_tree = (object)adaptor.Create(GE12);
                    		adaptor.AddChild(root_0, GE12_tree);

                    	PushFollow(FOLLOW_number_in_element_no_negative192);
                    	num1 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, num1.Tree);
                    	 AddNumberRelation(((num1 != null) ? input.ToString((IToken)(num1.Start),(IToken)(num1.Stop)) : null), ">="); 

                    }
                    break;
                case 7 :
                    // NumberFilter.g:44:5: NE num1= number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NE13=(IToken)Match(input,NE,FOLLOW_NE_in_element_no_negative201); 
                    		NE13_tree = (object)adaptor.Create(NE13);
                    		adaptor.AddChild(root_0, NE13_tree);

                    	PushFollow(FOLLOW_number_in_element_no_negative205);
                    	num1 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, num1.Tree);
                    	 AddNumberRelation(((num1 != null) ? input.ToString((IToken)(num1.Start),(IToken)(num1.Stop)) : null), "<>"); 

                    }
                    break;
                case 8 :
                    // NumberFilter.g:45:5: EQ num1= number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	EQ14=(IToken)Match(input,EQ,FOLLOW_EQ_in_element_no_negative214); 
                    		EQ14_tree = (object)adaptor.Create(EQ14);
                    		adaptor.AddChild(root_0, EQ14_tree);

                    	PushFollow(FOLLOW_number_in_element_no_negative218);
                    	num1 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, num1.Tree);
                    	 AddNumberRelation(((num1 != null) ? input.ToString((IToken)(num1.Start),(IToken)(num1.Stop)) : null), "="); 

                    }
                    break;
                case 9 :
                    // NumberFilter.g:46:5: T_NULL
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NULL15=(IToken)Match(input,T_NULL,FOLLOW_T_NULL_in_element_no_negative227); 
                    		T_NULL15_tree = (object)adaptor.Create(T_NULL15);
                    		adaptor.AddChild(root_0, T_NULL15_tree);

                    	 AddIsNullCondition(); 

                    }
                    break;
                case 10 :
                    // NumberFilter.g:47:5: T_NOT T_NULL
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NOT16=(IToken)Match(input,T_NOT,FOLLOW_T_NOT_in_element_no_negative235); 
                    		T_NOT16_tree = (object)adaptor.Create(T_NOT16);
                    		adaptor.AddChild(root_0, T_NOT16_tree);

                    	T_NULL17=(IToken)Match(input,T_NULL,FOLLOW_T_NULL_in_element_no_negative237); 
                    		T_NULL17_tree = (object)adaptor.Create(T_NULL17);
                    		adaptor.AddChild(root_0, T_NULL17_tree);

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
    // NumberFilter.g:50:1: element_maybe_negative : ( negative_number | element_no_negative );
    public NumberFilterParser.element_maybe_negative_return element_maybe_negative() // throws RecognitionException [1]
    {   
        NumberFilterParser.element_maybe_negative_return retval = new NumberFilterParser.element_maybe_negative_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        NumberFilterParser.negative_number_return negative_number18 = default(NumberFilterParser.negative_number_return);

        NumberFilterParser.element_no_negative_return element_no_negative19 = default(NumberFilterParser.element_no_negative_return);



        try 
    	{
            // NumberFilter.g:50:23: ( negative_number | element_no_negative )
            int alt4 = 2;
            alt4 = dfa4.Predict(input);
            switch (alt4) 
            {
                case 1 :
                    // NumberFilter.g:51:3: negative_number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_negative_number_in_element_maybe_negative253);
                    	negative_number18 = negative_number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, negative_number18.Tree);
                    	 AddEqualCondition(Pop<decimal>().ToString(CultureInfo.InvariantCulture)); 

                    }
                    break;
                case 2 :
                    // NumberFilter.g:52:5: element_no_negative
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_element_no_negative_in_element_maybe_negative261);
                    	element_no_negative19 = element_no_negative();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, element_no_negative19.Tree);

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
    // NumberFilter.g:54:1: factor : element_maybe_negative ( element_no_negative )* ;
    public NumberFilterParser.factor_return factor() // throws RecognitionException [1]
    {   
        NumberFilterParser.factor_return retval = new NumberFilterParser.factor_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        NumberFilterParser.element_maybe_negative_return element_maybe_negative20 = default(NumberFilterParser.element_maybe_negative_return);

        NumberFilterParser.element_no_negative_return element_no_negative21 = default(NumberFilterParser.element_no_negative_return);



        try 
    	{
            // NumberFilter.g:54:8: ( element_maybe_negative ( element_no_negative )* )
            // NumberFilter.g:55:3: element_maybe_negative ( element_no_negative )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_element_maybe_negative_in_factor273);
            	element_maybe_negative20 = element_maybe_negative();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, element_maybe_negative20.Tree);
            	// NumberFilter.g:55:26: ( element_no_negative )*
            	do 
            	{
            	    int alt5 = 2;
            	    int LA5_0 = input.LA(1);

            	    if ( ((LA5_0 >= MINUS && LA5_0 <= T_NOT)) )
            	    {
            	        alt5 = 1;
            	    }


            	    switch (alt5) 
            		{
            			case 1 :
            			    // NumberFilter.g:55:26: element_no_negative
            			    {
            			    	PushFollow(FOLLOW_element_no_negative_in_factor275);
            			    	element_no_negative21 = element_no_negative();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, element_no_negative21.Tree);

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
    // NumberFilter.g:57:1: list : factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )* ;
    public NumberFilterParser.list_return list() // throws RecognitionException [1]
    {   
        NumberFilterParser.list_return retval = new NumberFilterParser.list_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken COMMA23 = null;
        IToken ENDLINE24 = null;
        IToken ENDLINE26 = null;
        NumberFilterParser.factor_return factor22 = default(NumberFilterParser.factor_return);

        NumberFilterParser.factor_return factor25 = default(NumberFilterParser.factor_return);


        object COMMA23_tree=null;
        object ENDLINE24_tree=null;
        object ENDLINE26_tree=null;

        try 
    	{
            // NumberFilter.g:57:5: ( factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )* )
            // NumberFilter.g:58:3: factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_factor_in_list286);
            	factor22 = factor();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, factor22.Tree);
            	// NumberFilter.g:58:10: ( ( COMMA | ( ( ENDLINE )+ ) ) factor )*
            	do 
            	{
            	    int alt8 = 2;
            	    alt8 = dfa8.Predict(input);
            	    switch (alt8) 
            		{
            			case 1 :
            			    // NumberFilter.g:58:12: ( COMMA | ( ( ENDLINE )+ ) ) factor
            			    {
            			    	// NumberFilter.g:58:12: ( COMMA | ( ( ENDLINE )+ ) )
            			    	int alt7 = 2;
            			    	int LA7_0 = input.LA(1);

            			    	if ( (LA7_0 == COMMA) )
            			    	{
            			    	    alt7 = 1;
            			    	}
            			    	else if ( (LA7_0 == ENDLINE) )
            			    	{
            			    	    alt7 = 2;
            			    	}
            			    	else 
            			    	{
            			    	    NoViableAltException nvae_d7s0 =
            			    	        new NoViableAltException("", 7, 0, input);

            			    	    throw nvae_d7s0;
            			    	}
            			    	switch (alt7) 
            			    	{
            			    	    case 1 :
            			    	        // NumberFilter.g:58:13: COMMA
            			    	        {
            			    	        	COMMA23=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_list291); 
            			    	        		COMMA23_tree = (object)adaptor.Create(COMMA23);
            			    	        		adaptor.AddChild(root_0, COMMA23_tree);


            			    	        }
            			    	        break;
            			    	    case 2 :
            			    	        // NumberFilter.g:58:21: ( ( ENDLINE )+ )
            			    	        {
            			    	        	// NumberFilter.g:58:21: ( ( ENDLINE )+ )
            			    	        	// NumberFilter.g:58:22: ( ENDLINE )+
            			    	        	{
            			    	        		// NumberFilter.g:58:22: ( ENDLINE )+
            			    	        		int cnt6 = 0;
            			    	        		do 
            			    	        		{
            			    	        		    int alt6 = 2;
            			    	        		    int LA6_0 = input.LA(1);

            			    	        		    if ( (LA6_0 == ENDLINE) )
            			    	        		    {
            			    	        		        alt6 = 1;
            			    	        		    }


            			    	        		    switch (alt6) 
            			    	        			{
            			    	        				case 1 :
            			    	        				    // NumberFilter.g:58:22: ENDLINE
            			    	        				    {
            			    	        				    	ENDLINE24=(IToken)Match(input,ENDLINE,FOLLOW_ENDLINE_in_list296); 
            			    	        				    		ENDLINE24_tree = (object)adaptor.Create(ENDLINE24);
            			    	        				    		adaptor.AddChild(root_0, ENDLINE24_tree);


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


            			    	        }
            			    	        break;

            			    	}

            			    	 AddAndCondition(); 
            			    	PushFollow(FOLLOW_factor_in_list303);
            			    	factor25 = factor();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, factor25.Tree);

            			    }
            			    break;

            			default:
            			    goto loop8;
            	    }
            	} while (true);

            	loop8:
            		;	// Stops C# compiler whining that label 'loop8' has no statements

            	// NumberFilter.g:58:67: ( ENDLINE )*
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
            			    // NumberFilter.g:58:67: ENDLINE
            			    {
            			    	ENDLINE26=(IToken)Match(input,ENDLINE,FOLLOW_ENDLINE_in_list309); 
            			    		ENDLINE26_tree = (object)adaptor.Create(ENDLINE26);
            			    		adaptor.AddChild(root_0, ENDLINE26_tree);


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
    // NumberFilter.g:60:1: expr : list ;
    public NumberFilterParser.expr_return expr() // throws RecognitionException [1]
    {   
        NumberFilterParser.expr_return retval = new NumberFilterParser.expr_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        NumberFilterParser.list_return list27 = default(NumberFilterParser.list_return);



        try 
    	{
            // NumberFilter.g:60:5: ( list )
            // NumberFilter.g:60:7: list
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_list_in_expr319);
            	list27 = list();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, list27.Tree);

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


   	protected DFA3 dfa3;
   	protected DFA4 dfa4;
   	protected DFA8 dfa8;
	private void InitializeCyclicDFAs()
	{
    	this.dfa3 = new DFA3(this);
    	this.dfa4 = new DFA4(this);
    	this.dfa8 = new DFA8(this);
	}

    const string DFA3_eotS =
        "\x12\uffff";
    const string DFA3_eofS =
        "\x01\uffff\x01\x0c\x0b\uffff\x01\x02\x01\uffff\x01\x0c\x01\uffff"+
        "\x01\x02";
    const string DFA3_minS =
        "\x02\x04\x09\uffff\x01\x05\x01\uffff\x01\x04\x01\x05\x01\x04\x01"+
        "\x05\x01\x04";
    const string DFA3_maxS =
        "\x01\x0f\x01\x11\x09\uffff\x01\x05\x01\uffff\x01\x11\x01\x05\x01"+
        "\x11\x01\x05\x01\x11";
    const string DFA3_acceptS =
        "\x02\uffff\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06\x01\x07\x01"+
        "\x08\x01\x09\x01\x0a\x01\uffff\x01\x01\x05\uffff";
    const string DFA3_specialS =
        "\x12\uffff}>";
    static readonly string[] DFA3_transitionS = {
            "\x01\x02\x01\x01\x02\x02\x01\x03\x01\x04\x01\x05\x01\x06\x01"+
            "\x07\x01\x08\x01\x09\x01\x0a",
            "\x01\x0b\x0d\x0c",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\x0d",
            "",
            "\x01\x0e\x0d\x02",
            "\x01\x0f",
            "\x01\x10\x0d\x0c",
            "\x01\x11",
            "\x01\x0e\x0d\x02"
    };

    static readonly short[] DFA3_eot = DFA.UnpackEncodedString(DFA3_eotS);
    static readonly short[] DFA3_eof = DFA.UnpackEncodedString(DFA3_eofS);
    static readonly char[] DFA3_min = DFA.UnpackEncodedStringToUnsignedChars(DFA3_minS);
    static readonly char[] DFA3_max = DFA.UnpackEncodedStringToUnsignedChars(DFA3_maxS);
    static readonly short[] DFA3_accept = DFA.UnpackEncodedString(DFA3_acceptS);
    static readonly short[] DFA3_special = DFA.UnpackEncodedString(DFA3_specialS);
    static readonly short[][] DFA3_transition = DFA.UnpackEncodedStringArray(DFA3_transitionS);

    protected class DFA3 : DFA
    {
        public DFA3(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 3;
            this.eot = DFA3_eot;
            this.eof = DFA3_eof;
            this.min = DFA3_min;
            this.max = DFA3_max;
            this.accept = DFA3_accept;
            this.special = DFA3_special;
            this.transition = DFA3_transition;

        }

        override public string Description
        {
            get { return "37:1: element_no_negative : ( positive_number | interval | LT num1= number | GT num1= number | LE num1= number | GE num1= number | NE num1= number | EQ num1= number | T_NULL | T_NOT T_NULL );"; }
        }

    }

    const string DFA4_eotS =
        "\x0b\uffff";
    const string DFA4_eofS =
        "\x03\uffff\x01\x04\x02\uffff\x01\x02\x01\uffff\x01\x04\x01\uffff"+
        "\x01\x02";
    const string DFA4_minS =
        "\x01\x04\x01\x05\x01\uffff\x01\x04\x01\uffff\x01\x05\x01\x04\x01"+
        "\x05\x01\x04\x01\x05\x01\x04";
    const string DFA4_maxS =
        "\x01\x0f\x01\x05\x01\uffff\x01\x11\x01\uffff\x01\x05\x01\x11\x01"+
        "\x05\x01\x11\x01\x05\x01\x11";
    const string DFA4_acceptS =
        "\x02\uffff\x01\x02\x01\uffff\x01\x01\x06\uffff";
    const string DFA4_specialS =
        "\x0b\uffff}>";
    static readonly string[] DFA4_transitionS = {
            "\x01\x01\x0b\x02",
            "\x01\x03",
            "",
            "\x01\x05\x0d\x04",
            "",
            "\x01\x06",
            "\x01\x07\x0d\x02",
            "\x01\x08",
            "\x01\x09\x0d\x04",
            "\x01\x0a",
            "\x01\x07\x0d\x02"
    };

    static readonly short[] DFA4_eot = DFA.UnpackEncodedString(DFA4_eotS);
    static readonly short[] DFA4_eof = DFA.UnpackEncodedString(DFA4_eofS);
    static readonly char[] DFA4_min = DFA.UnpackEncodedStringToUnsignedChars(DFA4_minS);
    static readonly char[] DFA4_max = DFA.UnpackEncodedStringToUnsignedChars(DFA4_maxS);
    static readonly short[] DFA4_accept = DFA.UnpackEncodedString(DFA4_acceptS);
    static readonly short[] DFA4_special = DFA.UnpackEncodedString(DFA4_specialS);
    static readonly short[][] DFA4_transition = DFA.UnpackEncodedStringArray(DFA4_transitionS);

    protected class DFA4 : DFA
    {
        public DFA4(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 4;
            this.eot = DFA4_eot;
            this.eof = DFA4_eof;
            this.min = DFA4_min;
            this.max = DFA4_max;
            this.accept = DFA4_accept;
            this.special = DFA4_special;
            this.transition = DFA4_transition;

        }

        override public string Description
        {
            get { return "50:1: element_maybe_negative : ( negative_number | element_no_negative );"; }
        }

    }

    const string DFA8_eotS =
        "\x04\uffff";
    const string DFA8_eofS =
        "\x02\x02\x02\uffff";
    const string DFA8_minS =
        "\x01\x10\x01\x04\x02\uffff";
    const string DFA8_maxS =
        "\x02\x11\x02\uffff";
    const string DFA8_acceptS =
        "\x02\uffff\x01\x02\x01\x01";
    const string DFA8_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA8_transitionS = {
            "\x01\x03\x01\x01",
            "\x0c\x03\x01\uffff\x01\x01",
            "",
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
            get { return "()* loopback of 58:10: ( ( COMMA | ( ( ENDLINE )+ ) ) factor )*"; }
        }

    }

 

    public static readonly BitSet FOLLOW_MINUS_in_negative_number43 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_NUMBER_in_negative_number47 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NUMBER_in_positive_number63 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_Q_STRING_in_number_as_string80 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_A_STRING_in_number_as_string86 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_positive_number_in_number99 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_negative_number_in_number103 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_number_as_string_in_number107 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_number_in_interval116 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_MINUS_in_interval118 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_NUMBER_in_interval122 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_positive_number_in_element_no_negative134 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_interval_in_element_no_negative143 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_element_no_negative149 = new BitSet(new ulong[]{0x00000000000000F0UL});
    public static readonly BitSet FOLLOW_number_in_element_no_negative153 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GT_in_element_no_negative162 = new BitSet(new ulong[]{0x00000000000000F0UL});
    public static readonly BitSet FOLLOW_number_in_element_no_negative166 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LE_in_element_no_negative175 = new BitSet(new ulong[]{0x00000000000000F0UL});
    public static readonly BitSet FOLLOW_number_in_element_no_negative179 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GE_in_element_no_negative188 = new BitSet(new ulong[]{0x00000000000000F0UL});
    public static readonly BitSet FOLLOW_number_in_element_no_negative192 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NE_in_element_no_negative201 = new BitSet(new ulong[]{0x00000000000000F0UL});
    public static readonly BitSet FOLLOW_number_in_element_no_negative205 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EQ_in_element_no_negative214 = new BitSet(new ulong[]{0x00000000000000F0UL});
    public static readonly BitSet FOLLOW_number_in_element_no_negative218 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NULL_in_element_no_negative227 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NOT_in_element_no_negative235 = new BitSet(new ulong[]{0x0000000000004000UL});
    public static readonly BitSet FOLLOW_T_NULL_in_element_no_negative237 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_negative_number_in_element_maybe_negative253 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_element_no_negative_in_element_maybe_negative261 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_element_maybe_negative_in_factor273 = new BitSet(new ulong[]{0x000000000000FFF2UL});
    public static readonly BitSet FOLLOW_element_no_negative_in_factor275 = new BitSet(new ulong[]{0x000000000000FFF2UL});
    public static readonly BitSet FOLLOW_factor_in_list286 = new BitSet(new ulong[]{0x0000000000030002UL});
    public static readonly BitSet FOLLOW_COMMA_in_list291 = new BitSet(new ulong[]{0x000000000000FFF0UL});
    public static readonly BitSet FOLLOW_ENDLINE_in_list296 = new BitSet(new ulong[]{0x000000000002FFF0UL});
    public static readonly BitSet FOLLOW_factor_in_list303 = new BitSet(new ulong[]{0x0000000000030002UL});
    public static readonly BitSet FOLLOW_ENDLINE_in_list309 = new BitSet(new ulong[]{0x0000000000020002UL});
    public static readonly BitSet FOLLOW_list_in_expr319 = new BitSet(new ulong[]{0x0000000000000002UL});

}
