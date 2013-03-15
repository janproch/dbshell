// $ANTLR 3.2 Sep 23, 2009 12:02:23 NumberFilter.g 2013-03-15 23:25:25

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
		"LT", 
		"GT", 
		"LE", 
		"GE", 
		"NE", 
		"EQ", 
		"COMMA", 
		"DIGIT", 
		"WHITESPACE", 
		"ENDLINE"
    };

    public const int GE = 9;
    public const int LT = 6;
    public const int COMMA = 12;
    public const int NUMBER = 5;
    public const int WHITESPACE = 14;
    public const int GT = 7;
    public const int ENDLINE = 15;
    public const int DIGIT = 13;
    public const int EQ = 11;
    public const int MINUS = 4;
    public const int EOF = -1;
    public const int LE = 8;
    public const int NE = 10;

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
    // NumberFilter.g:14:1: number : ( MINUS num1= NUMBER | num2= NUMBER );
    public NumberFilterParser.number_return number() // throws RecognitionException [1]
    {   
        NumberFilterParser.number_return retval = new NumberFilterParser.number_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken num1 = null;
        IToken num2 = null;
        IToken MINUS1 = null;

        object num1_tree=null;
        object num2_tree=null;
        object MINUS1_tree=null;

        try 
    	{
            // NumberFilter.g:14:7: ( MINUS num1= NUMBER | num2= NUMBER )
            int alt1 = 2;
            int LA1_0 = input.LA(1);

            if ( (LA1_0 == MINUS) )
            {
                alt1 = 1;
            }
            else if ( (LA1_0 == NUMBER) )
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
                    // NumberFilter.g:15:3: MINUS num1= NUMBER
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	MINUS1=(IToken)Match(input,MINUS,FOLLOW_MINUS_in_number43); 
                    		MINUS1_tree = (object)adaptor.Create(MINUS1);
                    		adaptor.AddChild(root_0, MINUS1_tree);

                    	num1=(IToken)Match(input,NUMBER,FOLLOW_NUMBER_in_number47); 
                    		num1_tree = (object)adaptor.Create(num1);
                    		adaptor.AddChild(root_0, num1_tree);

                    	 Push(-Decimal.Parse(((num1 != null) ? num1.Text : null), CultureInfo.InvariantCulture)); 

                    }
                    break;
                case 2 :
                    // NumberFilter.g:16:5: num2= NUMBER
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	num2=(IToken)Match(input,NUMBER,FOLLOW_NUMBER_in_number57); 
                    		num2_tree = (object)adaptor.Create(num2);
                    		adaptor.AddChild(root_0, num2_tree);

                    	 Push(Decimal.Parse(((num2 != null) ? num2.Text : null), CultureInfo.InvariantCulture)); 

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
    // NumberFilter.g:18:1: interval : number MINUS number ;
    public NumberFilterParser.interval_return interval() // throws RecognitionException [1]
    {   
        NumberFilterParser.interval_return retval = new NumberFilterParser.interval_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken MINUS3 = null;
        NumberFilterParser.number_return number2 = default(NumberFilterParser.number_return);

        NumberFilterParser.number_return number4 = default(NumberFilterParser.number_return);


        object MINUS3_tree=null;

        try 
    	{
            // NumberFilter.g:18:10: ( number MINUS number )
            // NumberFilter.g:19:1: number MINUS number
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_number_in_interval69);
            	number2 = number();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, number2.Tree);
            	MINUS3=(IToken)Match(input,MINUS,FOLLOW_MINUS_in_interval71); 
            		MINUS3_tree = (object)adaptor.Create(MINUS3);
            		adaptor.AddChild(root_0, MINUS3_tree);

            	PushFollow(FOLLOW_number_in_interval73);
            	number4 = number();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, number4.Tree);

            	        var right = Pop<decimal>();var left = Pop<decimal>();
            	        Condition.Conditions.Add(new DmlfBetweenCondition
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
    // NumberFilter.g:29:1: factor : ( number | interval | LT num1= number | GT num1= number | LE num1= number | GE num1= number | NE num1= number | EQ num1= number );
    public NumberFilterParser.factor_return factor() // throws RecognitionException [1]
    {   
        NumberFilterParser.factor_return retval = new NumberFilterParser.factor_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken LT7 = null;
        IToken GT8 = null;
        IToken LE9 = null;
        IToken GE10 = null;
        IToken NE11 = null;
        IToken EQ12 = null;
        NumberFilterParser.number_return num1 = default(NumberFilterParser.number_return);

        NumberFilterParser.number_return number5 = default(NumberFilterParser.number_return);

        NumberFilterParser.interval_return interval6 = default(NumberFilterParser.interval_return);


        object LT7_tree=null;
        object GT8_tree=null;
        object LE9_tree=null;
        object GE10_tree=null;
        object NE11_tree=null;
        object EQ12_tree=null;

        try 
    	{
            // NumberFilter.g:29:7: ( number | interval | LT num1= number | GT num1= number | LE num1= number | GE num1= number | NE num1= number | EQ num1= number )
            int alt2 = 8;
            alt2 = dfa2.Predict(input);
            switch (alt2) 
            {
                case 1 :
                    // NumberFilter.g:30:3: number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_number_in_factor85);
                    	number5 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, number5.Tree);
                    	 AddEqualCondition(Pop<decimal>().ToString(CultureInfo.InvariantCulture)); 

                    }
                    break;
                case 2 :
                    // NumberFilter.g:31:5: interval
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_interval_in_factor94);
                    	interval6 = interval();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, interval6.Tree);

                    }
                    break;
                case 3 :
                    // NumberFilter.g:32:5: LT num1= number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LT7=(IToken)Match(input,LT,FOLLOW_LT_in_factor100); 
                    		LT7_tree = (object)adaptor.Create(LT7);
                    		adaptor.AddChild(root_0, LT7_tree);

                    	PushFollow(FOLLOW_number_in_factor104);
                    	num1 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, num1.Tree);
                    	 AddNumberRelation(((num1 != null) ? input.ToString((IToken)(num1.Start),(IToken)(num1.Stop)) : null), "<"); 

                    }
                    break;
                case 4 :
                    // NumberFilter.g:33:5: GT num1= number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GT8=(IToken)Match(input,GT,FOLLOW_GT_in_factor113); 
                    		GT8_tree = (object)adaptor.Create(GT8);
                    		adaptor.AddChild(root_0, GT8_tree);

                    	PushFollow(FOLLOW_number_in_factor117);
                    	num1 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, num1.Tree);
                    	 AddNumberRelation(((num1 != null) ? input.ToString((IToken)(num1.Start),(IToken)(num1.Stop)) : null), ">"); 

                    }
                    break;
                case 5 :
                    // NumberFilter.g:34:5: LE num1= number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LE9=(IToken)Match(input,LE,FOLLOW_LE_in_factor126); 
                    		LE9_tree = (object)adaptor.Create(LE9);
                    		adaptor.AddChild(root_0, LE9_tree);

                    	PushFollow(FOLLOW_number_in_factor130);
                    	num1 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, num1.Tree);
                    	 AddNumberRelation(((num1 != null) ? input.ToString((IToken)(num1.Start),(IToken)(num1.Stop)) : null), "<="); 

                    }
                    break;
                case 6 :
                    // NumberFilter.g:35:5: GE num1= number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GE10=(IToken)Match(input,GE,FOLLOW_GE_in_factor139); 
                    		GE10_tree = (object)adaptor.Create(GE10);
                    		adaptor.AddChild(root_0, GE10_tree);

                    	PushFollow(FOLLOW_number_in_factor143);
                    	num1 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, num1.Tree);
                    	 AddNumberRelation(((num1 != null) ? input.ToString((IToken)(num1.Start),(IToken)(num1.Stop)) : null), "<="); 

                    }
                    break;
                case 7 :
                    // NumberFilter.g:36:5: NE num1= number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NE11=(IToken)Match(input,NE,FOLLOW_NE_in_factor152); 
                    		NE11_tree = (object)adaptor.Create(NE11);
                    		adaptor.AddChild(root_0, NE11_tree);

                    	PushFollow(FOLLOW_number_in_factor156);
                    	num1 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, num1.Tree);
                    	 AddNumberRelation(((num1 != null) ? input.ToString((IToken)(num1.Start),(IToken)(num1.Stop)) : null), "<>"); 

                    }
                    break;
                case 8 :
                    // NumberFilter.g:37:5: EQ num1= number
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	EQ12=(IToken)Match(input,EQ,FOLLOW_EQ_in_factor165); 
                    		EQ12_tree = (object)adaptor.Create(EQ12);
                    		adaptor.AddChild(root_0, EQ12_tree);

                    	PushFollow(FOLLOW_number_in_factor169);
                    	num1 = number();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, num1.Tree);
                    	 AddNumberRelation(((num1 != null) ? input.ToString((IToken)(num1.Start),(IToken)(num1.Stop)) : null), "="); 

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
    // NumberFilter.g:40:1: list : factor ( COMMA factor )* ;
    public NumberFilterParser.list_return list() // throws RecognitionException [1]
    {   
        NumberFilterParser.list_return retval = new NumberFilterParser.list_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken COMMA14 = null;
        NumberFilterParser.factor_return factor13 = default(NumberFilterParser.factor_return);

        NumberFilterParser.factor_return factor15 = default(NumberFilterParser.factor_return);


        object COMMA14_tree=null;

        try 
    	{
            // NumberFilter.g:40:5: ( factor ( COMMA factor )* )
            // NumberFilter.g:41:3: factor ( COMMA factor )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_factor_in_list186);
            	factor13 = factor();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, factor13.Tree);
            	// NumberFilter.g:41:10: ( COMMA factor )*
            	do 
            	{
            	    int alt3 = 2;
            	    int LA3_0 = input.LA(1);

            	    if ( (LA3_0 == COMMA) )
            	    {
            	        alt3 = 1;
            	    }


            	    switch (alt3) 
            		{
            			case 1 :
            			    // NumberFilter.g:41:12: COMMA factor
            			    {
            			    	COMMA14=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_list190); 
            			    		COMMA14_tree = (object)adaptor.Create(COMMA14);
            			    		adaptor.AddChild(root_0, COMMA14_tree);

            			    	PushFollow(FOLLOW_factor_in_list192);
            			    	factor15 = factor();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, factor15.Tree);

            			    }
            			    break;

            			default:
            			    goto loop3;
            	    }
            	} while (true);

            	loop3:
            		;	// Stops C# compiler whining that label 'loop3' has no statements


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
    // NumberFilter.g:43:1: expr : list ;
    public NumberFilterParser.expr_return expr() // throws RecognitionException [1]
    {   
        NumberFilterParser.expr_return retval = new NumberFilterParser.expr_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        NumberFilterParser.list_return list16 = default(NumberFilterParser.list_return);



        try 
    	{
            // NumberFilter.g:43:5: ( list )
            // NumberFilter.g:43:7: list
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_list_in_expr205);
            	list16 = list();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, list16.Tree);

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


   	protected DFA2 dfa2;
	private void InitializeCyclicDFAs()
	{
    	this.dfa2 = new DFA2(this);
	}

    const string DFA2_eotS =
        "\x0c\uffff";
    const string DFA2_eofS =
        "\x02\uffff\x01\x0a\x06\uffff\x01\x0a\x02\uffff";
    const string DFA2_minS =
        "\x01\x04\x01\x05\x01\x04\x06\uffff\x01\x04\x02\uffff";
    const string DFA2_maxS =
        "\x01\x0b\x01\x05\x01\x0c\x06\uffff\x01\x0c\x02\uffff";
    const string DFA2_acceptS =
        "\x03\uffff\x01\x03\x01\x04\x01\x05\x01\x06\x01\x07\x01\x08\x01"+
        "\uffff\x01\x01\x01\x02";
    const string DFA2_specialS =
        "\x0c\uffff}>";
    static readonly string[] DFA2_transitionS = {
            "\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06\x01\x07\x01"+
            "\x08",
            "\x01\x09",
            "\x01\x0b\x07\uffff\x01\x0a",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\x0b\x07\uffff\x01\x0a",
            "",
            ""
    };

    static readonly short[] DFA2_eot = DFA.UnpackEncodedString(DFA2_eotS);
    static readonly short[] DFA2_eof = DFA.UnpackEncodedString(DFA2_eofS);
    static readonly char[] DFA2_min = DFA.UnpackEncodedStringToUnsignedChars(DFA2_minS);
    static readonly char[] DFA2_max = DFA.UnpackEncodedStringToUnsignedChars(DFA2_maxS);
    static readonly short[] DFA2_accept = DFA.UnpackEncodedString(DFA2_acceptS);
    static readonly short[] DFA2_special = DFA.UnpackEncodedString(DFA2_specialS);
    static readonly short[][] DFA2_transition = DFA.UnpackEncodedStringArray(DFA2_transitionS);

    protected class DFA2 : DFA
    {
        public DFA2(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 2;
            this.eot = DFA2_eot;
            this.eof = DFA2_eof;
            this.min = DFA2_min;
            this.max = DFA2_max;
            this.accept = DFA2_accept;
            this.special = DFA2_special;
            this.transition = DFA2_transition;

        }

        override public string Description
        {
            get { return "29:1: factor : ( number | interval | LT num1= number | GT num1= number | LE num1= number | GE num1= number | NE num1= number | EQ num1= number );"; }
        }

    }

 

    public static readonly BitSet FOLLOW_MINUS_in_number43 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_NUMBER_in_number47 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NUMBER_in_number57 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_number_in_interval69 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_MINUS_in_interval71 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_number_in_interval73 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_number_in_factor85 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_interval_in_factor94 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_factor100 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_number_in_factor104 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GT_in_factor113 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_number_in_factor117 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LE_in_factor126 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_number_in_factor130 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GE_in_factor139 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_number_in_factor143 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NE_in_factor152 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_number_in_factor156 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EQ_in_factor165 = new BitSet(new ulong[]{0x0000000000000030UL});
    public static readonly BitSet FOLLOW_number_in_factor169 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_factor_in_list186 = new BitSet(new ulong[]{0x0000000000001002UL});
    public static readonly BitSet FOLLOW_COMMA_in_list190 = new BitSet(new ulong[]{0x0000000000000FF0UL});
    public static readonly BitSet FOLLOW_factor_in_list192 = new BitSet(new ulong[]{0x0000000000001002UL});
    public static readonly BitSet FOLLOW_list_in_expr205 = new BitSet(new ulong[]{0x0000000000000002UL});

}
