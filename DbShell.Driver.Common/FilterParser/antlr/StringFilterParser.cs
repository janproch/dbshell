// $ANTLR 3.2 Sep 23, 2009 12:02:23 StringFilter.g 2014-10-25 22:48:42

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

public partial class StringFilterParser : DbShellFilterAntlrParser
{
    public static readonly string[] tokenNames = new string[] 
	{
        "<invalid>", 
		"<EOR>", 
		"<DOWN>", 
		"<UP>", 
		"Q_STRING", 
		"A_STRING", 
		"I_STRING", 
		"SQL_LITERAL", 
		"DOT", 
		"PLUS", 
		"MINUS", 
		"LT", 
		"GT", 
		"LE", 
		"GE", 
		"NE", 
		"EQ", 
		"ARROW", 
		"NARROW", 
		"DOLLAR", 
		"NDOLLAR", 
		"T_NULL", 
		"T_NOT", 
		"T_EMPTY", 
		"EQ2", 
		"NE2", 
		"COMMA", 
		"ENDLINE", 
		"STAR", 
		"N", 
		"U", 
		"L", 
		"O", 
		"T", 
		"E", 
		"M", 
		"P", 
		"Y", 
		"WHITESPACE", 
		"DIGIT", 
		"A", 
		"B", 
		"C", 
		"D", 
		"F", 
		"G", 
		"H", 
		"I", 
		"J", 
		"K", 
		"Q", 
		"R", 
		"S", 
		"V", 
		"W", 
		"X", 
		"Z"
    };

    public const int DOLLAR = 19;
    public const int LT = 11;
    public const int STAR = 28;
    public const int EOF = -1;
    public const int Q_STRING = 4;
    public const int COMMA = 26;
    public const int T_NULL = 21;
    public const int PLUS = 9;
    public const int DIGIT = 39;
    public const int EQ = 16;
    public const int DOT = 8;
    public const int NE = 15;
    public const int D = 43;
    public const int E = 34;
    public const int F = 44;
    public const int GE = 14;
    public const int G = 45;
    public const int I_STRING = 6;
    public const int A = 40;
    public const int B = 41;
    public const int NE2 = 25;
    public const int C = 42;
    public const int L = 31;
    public const int M = 35;
    public const int N = 29;
    public const int O = 32;
    public const int H = 46;
    public const int I = 47;
    public const int J = 48;
    public const int K = 49;
    public const int U = 30;
    public const int T = 33;
    public const int W = 54;
    public const int WHITESPACE = 38;
    public const int V = 53;
    public const int Q = 50;
    public const int P = 36;
    public const int S = 52;
    public const int R = 51;
    public const int MINUS = 10;
    public const int Y = 37;
    public const int X = 55;
    public const int SQL_LITERAL = 7;
    public const int EQ2 = 24;
    public const int Z = 56;
    public const int NDOLLAR = 20;
    public const int T_EMPTY = 23;
    public const int A_STRING = 5;
    public const int ARROW = 17;
    public const int GT = 12;
    public const int ENDLINE = 27;
    public const int T_NOT = 22;
    public const int NARROW = 18;
    public const int LE = 13;

    // delegates
    // delegators



        public StringFilterParser(ITokenStream input)
    		: this(input, new RecognizerSharedState()) {
        }

        public StringFilterParser(ITokenStream input, RecognizerSharedState state)
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
		get { return StringFilterParser.tokenNames; }
    }

    override public string GrammarFileName {
		get { return "StringFilter.g"; }
    }


    public class string_lit_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "string_lit"
    // StringFilter.g:14:1: string_lit : ( Q_STRING | A_STRING | I_STRING );
    public StringFilterParser.string_lit_return string_lit() // throws RecognitionException [1]
    {   
        StringFilterParser.string_lit_return retval = new StringFilterParser.string_lit_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken set1 = null;

        object set1_tree=null;

        try 
    	{
            // StringFilter.g:14:11: ( Q_STRING | A_STRING | I_STRING )
            // StringFilter.g:
            {
            	root_0 = (object)adaptor.GetNilNode();

            	set1 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= Q_STRING && input.LA(1) <= I_STRING) ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (object)adaptor.Create(set1));
            	    state.errorRecovery = false;
            	}
            	else 
            	{
            	    MismatchedSetException mse = new MismatchedSetException(null,input);
            	    throw mse;
            	}


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
    // $ANTLR end "string_lit"

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
    // StringFilter.g:16:1: sql_name : lit1= SQL_LITERAL ( DOT lit2= SQL_LITERAL )* ;
    public StringFilterParser.sql_name_return sql_name() // throws RecognitionException [1]
    {   
        StringFilterParser.sql_name_return retval = new StringFilterParser.sql_name_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken lit1 = null;
        IToken lit2 = null;
        IToken DOT2 = null;

        object lit1_tree=null;
        object lit2_tree=null;
        object DOT2_tree=null;

        try 
    	{
            // StringFilter.g:16:9: (lit1= SQL_LITERAL ( DOT lit2= SQL_LITERAL )* )
            // StringFilter.g:17:3: lit1= SQL_LITERAL ( DOT lit2= SQL_LITERAL )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	lit1=(IToken)Match(input,SQL_LITERAL,FOLLOW_SQL_LITERAL_in_sql_name60); 
            		lit1_tree = (object)adaptor.Create(lit1);
            		adaptor.AddChild(root_0, lit1_tree);

            	 Push(((lit1 != null) ? lit1.Text : null)); 
            	// StringFilter.g:18:3: ( DOT lit2= SQL_LITERAL )*
            	do 
            	{
            	    int alt1 = 2;
            	    int LA1_0 = input.LA(1);

            	    if ( (LA1_0 == DOT) )
            	    {
            	        alt1 = 1;
            	    }


            	    switch (alt1) 
            		{
            			case 1 :
            			    // StringFilter.g:18:4: DOT lit2= SQL_LITERAL
            			    {
            			    	DOT2=(IToken)Match(input,DOT,FOLLOW_DOT_in_sql_name67); 
            			    		DOT2_tree = (object)adaptor.Create(DOT2);
            			    		adaptor.AddChild(root_0, DOT2_tree);

            			    	lit2=(IToken)Match(input,SQL_LITERAL,FOLLOW_SQL_LITERAL_in_sql_name71); 
            			    		lit2_tree = (object)adaptor.Create(lit2);
            			    		adaptor.AddChild(root_0, lit2_tree);

            			    	 Push(Pop<string>() + "." + ((lit2 != null) ? lit2.Text : null)); 

            			    }
            			    break;

            			default:
            			    goto loop1;
            	    }
            	} while (true);

            	loop1:
            		;	// Stops C# compiler whining that label 'loop1' has no statements


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

    public class element_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "element"
    // StringFilter.g:21:1: element : (s1= string_lit | PLUS s1= string_lit | MINUS s1= string_lit | LT s1= string_lit | GT s1= string_lit | LE s1= string_lit | GE s1= string_lit | NE s1= string_lit | EQ s1= string_lit | ARROW s1= string_lit | NARROW s1= string_lit | DOLLAR s1= string_lit | NDOLLAR s1= string_lit | T_NULL | T_NOT T_NULL | T_EMPTY | T_NOT T_EMPTY | LT sql_name | GT sql_name | LE sql_name | GE sql_name | NE sql_name | EQ sql_name | EQ2 sql_name | NE2 sql_name );
    public StringFilterParser.element_return element() // throws RecognitionException [1]
    {   
        StringFilterParser.element_return retval = new StringFilterParser.element_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken PLUS3 = null;
        IToken MINUS4 = null;
        IToken LT5 = null;
        IToken GT6 = null;
        IToken LE7 = null;
        IToken GE8 = null;
        IToken NE9 = null;
        IToken EQ10 = null;
        IToken ARROW11 = null;
        IToken NARROW12 = null;
        IToken DOLLAR13 = null;
        IToken NDOLLAR14 = null;
        IToken T_NULL15 = null;
        IToken T_NOT16 = null;
        IToken T_NULL17 = null;
        IToken T_EMPTY18 = null;
        IToken T_NOT19 = null;
        IToken T_EMPTY20 = null;
        IToken LT21 = null;
        IToken GT23 = null;
        IToken LE25 = null;
        IToken GE27 = null;
        IToken NE29 = null;
        IToken EQ31 = null;
        IToken EQ233 = null;
        IToken NE235 = null;
        StringFilterParser.string_lit_return s1 = default(StringFilterParser.string_lit_return);

        StringFilterParser.sql_name_return sql_name22 = default(StringFilterParser.sql_name_return);

        StringFilterParser.sql_name_return sql_name24 = default(StringFilterParser.sql_name_return);

        StringFilterParser.sql_name_return sql_name26 = default(StringFilterParser.sql_name_return);

        StringFilterParser.sql_name_return sql_name28 = default(StringFilterParser.sql_name_return);

        StringFilterParser.sql_name_return sql_name30 = default(StringFilterParser.sql_name_return);

        StringFilterParser.sql_name_return sql_name32 = default(StringFilterParser.sql_name_return);

        StringFilterParser.sql_name_return sql_name34 = default(StringFilterParser.sql_name_return);

        StringFilterParser.sql_name_return sql_name36 = default(StringFilterParser.sql_name_return);


        object PLUS3_tree=null;
        object MINUS4_tree=null;
        object LT5_tree=null;
        object GT6_tree=null;
        object LE7_tree=null;
        object GE8_tree=null;
        object NE9_tree=null;
        object EQ10_tree=null;
        object ARROW11_tree=null;
        object NARROW12_tree=null;
        object DOLLAR13_tree=null;
        object NDOLLAR14_tree=null;
        object T_NULL15_tree=null;
        object T_NOT16_tree=null;
        object T_NULL17_tree=null;
        object T_EMPTY18_tree=null;
        object T_NOT19_tree=null;
        object T_EMPTY20_tree=null;
        object LT21_tree=null;
        object GT23_tree=null;
        object LE25_tree=null;
        object GE27_tree=null;
        object NE29_tree=null;
        object EQ31_tree=null;
        object EQ233_tree=null;
        object NE235_tree=null;

        try 
    	{
            // StringFilter.g:21:8: (s1= string_lit | PLUS s1= string_lit | MINUS s1= string_lit | LT s1= string_lit | GT s1= string_lit | LE s1= string_lit | GE s1= string_lit | NE s1= string_lit | EQ s1= string_lit | ARROW s1= string_lit | NARROW s1= string_lit | DOLLAR s1= string_lit | NDOLLAR s1= string_lit | T_NULL | T_NOT T_NULL | T_EMPTY | T_NOT T_EMPTY | LT sql_name | GT sql_name | LE sql_name | GE sql_name | NE sql_name | EQ sql_name | EQ2 sql_name | NE2 sql_name )
            int alt2 = 25;
            alt2 = dfa2.Predict(input);
            switch (alt2) 
            {
                case 1 :
                    // StringFilter.g:22:3: s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_string_lit_in_element92);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddLikeCondition(true, ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)), true); 

                    }
                    break;
                case 2 :
                    // StringFilter.g:23:5: PLUS s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PLUS3=(IToken)Match(input,PLUS,FOLLOW_PLUS_in_element101); 
                    		PLUS3_tree = (object)adaptor.Create(PLUS3);
                    		adaptor.AddChild(root_0, PLUS3_tree);

                    	PushFollow(FOLLOW_string_lit_in_element105);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddLikeCondition(true, ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)), true); 

                    }
                    break;
                case 3 :
                    // StringFilter.g:24:5: MINUS s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	MINUS4=(IToken)Match(input,MINUS,FOLLOW_MINUS_in_element114); 
                    		MINUS4_tree = (object)adaptor.Create(MINUS4);
                    		adaptor.AddChild(root_0, MINUS4_tree);

                    	PushFollow(FOLLOW_string_lit_in_element118);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddLikeCondition(true, ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)), true);NegateLastCondition(); 

                    }
                    break;
                case 4 :
                    // StringFilter.g:25:5: LT s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LT5=(IToken)Match(input,LT,FOLLOW_LT_in_element127); 
                    		LT5_tree = (object)adaptor.Create(LT5);
                    		adaptor.AddChild(root_0, LT5_tree);

                    	PushFollow(FOLLOW_string_lit_in_element131);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringRelation(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)), "<"); 

                    }
                    break;
                case 5 :
                    // StringFilter.g:26:5: GT s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GT6=(IToken)Match(input,GT,FOLLOW_GT_in_element140); 
                    		GT6_tree = (object)adaptor.Create(GT6);
                    		adaptor.AddChild(root_0, GT6_tree);

                    	PushFollow(FOLLOW_string_lit_in_element144);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringRelation(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)), ">"); 

                    }
                    break;
                case 6 :
                    // StringFilter.g:27:5: LE s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LE7=(IToken)Match(input,LE,FOLLOW_LE_in_element153); 
                    		LE7_tree = (object)adaptor.Create(LE7);
                    		adaptor.AddChild(root_0, LE7_tree);

                    	PushFollow(FOLLOW_string_lit_in_element157);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringRelation(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)), "<="); 

                    }
                    break;
                case 7 :
                    // StringFilter.g:28:5: GE s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GE8=(IToken)Match(input,GE,FOLLOW_GE_in_element166); 
                    		GE8_tree = (object)adaptor.Create(GE8);
                    		adaptor.AddChild(root_0, GE8_tree);

                    	PushFollow(FOLLOW_string_lit_in_element170);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringRelation(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)), ">="); 

                    }
                    break;
                case 8 :
                    // StringFilter.g:29:5: NE s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NE9=(IToken)Match(input,NE,FOLLOW_NE_in_element179); 
                    		NE9_tree = (object)adaptor.Create(NE9);
                    		adaptor.AddChild(root_0, NE9_tree);

                    	PushFollow(FOLLOW_string_lit_in_element183);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringRelation(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)), "<>"); 

                    }
                    break;
                case 9 :
                    // StringFilter.g:30:5: EQ s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	EQ10=(IToken)Match(input,EQ,FOLLOW_EQ_in_element192); 
                    		EQ10_tree = (object)adaptor.Create(EQ10);
                    		adaptor.AddChild(root_0, EQ10_tree);

                    	PushFollow(FOLLOW_string_lit_in_element196);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringRelation(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)), "="); 

                    }
                    break;
                case 10 :
                    // StringFilter.g:31:5: ARROW s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	ARROW11=(IToken)Match(input,ARROW,FOLLOW_ARROW_in_element205); 
                    		ARROW11_tree = (object)adaptor.Create(ARROW11);
                    		adaptor.AddChild(root_0, ARROW11_tree);

                    	PushFollow(FOLLOW_string_lit_in_element209);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddLikeCondition(false, ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)), true); 

                    }
                    break;
                case 11 :
                    // StringFilter.g:32:5: NARROW s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NARROW12=(IToken)Match(input,NARROW,FOLLOW_NARROW_in_element218); 
                    		NARROW12_tree = (object)adaptor.Create(NARROW12);
                    		adaptor.AddChild(root_0, NARROW12_tree);

                    	PushFollow(FOLLOW_string_lit_in_element222);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddLikeCondition(false, ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)), true);NegateLastCondition(); 

                    }
                    break;
                case 12 :
                    // StringFilter.g:33:5: DOLLAR s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	DOLLAR13=(IToken)Match(input,DOLLAR,FOLLOW_DOLLAR_in_element231); 
                    		DOLLAR13_tree = (object)adaptor.Create(DOLLAR13);
                    		adaptor.AddChild(root_0, DOLLAR13_tree);

                    	PushFollow(FOLLOW_string_lit_in_element235);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddLikeCondition(true, ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)), false); 

                    }
                    break;
                case 13 :
                    // StringFilter.g:34:5: NDOLLAR s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NDOLLAR14=(IToken)Match(input,NDOLLAR,FOLLOW_NDOLLAR_in_element244); 
                    		NDOLLAR14_tree = (object)adaptor.Create(NDOLLAR14);
                    		adaptor.AddChild(root_0, NDOLLAR14_tree);

                    	PushFollow(FOLLOW_string_lit_in_element248);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddLikeCondition(true, ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)), false);NegateLastCondition(); 

                    }
                    break;
                case 14 :
                    // StringFilter.g:35:5: T_NULL
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NULL15=(IToken)Match(input,T_NULL,FOLLOW_T_NULL_in_element257); 
                    		T_NULL15_tree = (object)adaptor.Create(T_NULL15);
                    		adaptor.AddChild(root_0, T_NULL15_tree);

                    	 AddIsNullCondition(); 

                    }
                    break;
                case 15 :
                    // StringFilter.g:36:5: T_NOT T_NULL
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NOT16=(IToken)Match(input,T_NOT,FOLLOW_T_NOT_in_element265); 
                    		T_NOT16_tree = (object)adaptor.Create(T_NOT16);
                    		adaptor.AddChild(root_0, T_NOT16_tree);

                    	T_NULL17=(IToken)Match(input,T_NULL,FOLLOW_T_NULL_in_element267); 
                    		T_NULL17_tree = (object)adaptor.Create(T_NULL17);
                    		adaptor.AddChild(root_0, T_NULL17_tree);

                    	 AddIsNotNullCondition(); 

                    }
                    break;
                case 16 :
                    // StringFilter.g:37:5: T_EMPTY
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_EMPTY18=(IToken)Match(input,T_EMPTY,FOLLOW_T_EMPTY_in_element275); 
                    		T_EMPTY18_tree = (object)adaptor.Create(T_EMPTY18);
                    		adaptor.AddChild(root_0, T_EMPTY18_tree);

                    	 AddIsEmptyCondition(); 

                    }
                    break;
                case 17 :
                    // StringFilter.g:38:5: T_NOT T_EMPTY
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NOT19=(IToken)Match(input,T_NOT,FOLLOW_T_NOT_in_element283); 
                    		T_NOT19_tree = (object)adaptor.Create(T_NOT19);
                    		adaptor.AddChild(root_0, T_NOT19_tree);

                    	T_EMPTY20=(IToken)Match(input,T_EMPTY,FOLLOW_T_EMPTY_in_element285); 
                    		T_EMPTY20_tree = (object)adaptor.Create(T_EMPTY20);
                    		adaptor.AddChild(root_0, T_EMPTY20_tree);

                    	 AddIsNotEmptyCondition(); 

                    }
                    break;
                case 18 :
                    // StringFilter.g:40:5: LT sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LT21=(IToken)Match(input,LT,FOLLOW_LT_in_element296); 
                    		LT21_tree = (object)adaptor.Create(LT21);
                    		adaptor.AddChild(root_0, LT21_tree);

                    	PushFollow(FOLLOW_sql_name_in_element298);
                    	sql_name22 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name22.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), "<"); 

                    }
                    break;
                case 19 :
                    // StringFilter.g:41:5: GT sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GT23=(IToken)Match(input,GT,FOLLOW_GT_in_element307); 
                    		GT23_tree = (object)adaptor.Create(GT23);
                    		adaptor.AddChild(root_0, GT23_tree);

                    	PushFollow(FOLLOW_sql_name_in_element309);
                    	sql_name24 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name24.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), ">"); 

                    }
                    break;
                case 20 :
                    // StringFilter.g:42:5: LE sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LE25=(IToken)Match(input,LE,FOLLOW_LE_in_element318); 
                    		LE25_tree = (object)adaptor.Create(LE25);
                    		adaptor.AddChild(root_0, LE25_tree);

                    	PushFollow(FOLLOW_sql_name_in_element320);
                    	sql_name26 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name26.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), "<="); 

                    }
                    break;
                case 21 :
                    // StringFilter.g:43:5: GE sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GE27=(IToken)Match(input,GE,FOLLOW_GE_in_element329); 
                    		GE27_tree = (object)adaptor.Create(GE27);
                    		adaptor.AddChild(root_0, GE27_tree);

                    	PushFollow(FOLLOW_sql_name_in_element331);
                    	sql_name28 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name28.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), ">="); 

                    }
                    break;
                case 22 :
                    // StringFilter.g:44:5: NE sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NE29=(IToken)Match(input,NE,FOLLOW_NE_in_element340); 
                    		NE29_tree = (object)adaptor.Create(NE29);
                    		adaptor.AddChild(root_0, NE29_tree);

                    	PushFollow(FOLLOW_sql_name_in_element342);
                    	sql_name30 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name30.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), "<>"); 

                    }
                    break;
                case 23 :
                    // StringFilter.g:45:5: EQ sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	EQ31=(IToken)Match(input,EQ,FOLLOW_EQ_in_element351); 
                    		EQ31_tree = (object)adaptor.Create(EQ31);
                    		adaptor.AddChild(root_0, EQ31_tree);

                    	PushFollow(FOLLOW_sql_name_in_element353);
                    	sql_name32 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name32.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), "="); 

                    }
                    break;
                case 24 :
                    // StringFilter.g:46:5: EQ2 sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	EQ233=(IToken)Match(input,EQ2,FOLLOW_EQ2_in_element361); 
                    		EQ233_tree = (object)adaptor.Create(EQ233);
                    		adaptor.AddChild(root_0, EQ233_tree);

                    	PushFollow(FOLLOW_sql_name_in_element363);
                    	sql_name34 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name34.Tree);
                    	 AddSqlLiteralRelationWithNullTest_EQ(Pop<string>()); 

                    }
                    break;
                case 25 :
                    // StringFilter.g:47:5: NE2 sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NE235=(IToken)Match(input,NE2,FOLLOW_NE2_in_element372); 
                    		NE235_tree = (object)adaptor.Create(NE235);
                    		adaptor.AddChild(root_0, NE235_tree);

                    	PushFollow(FOLLOW_sql_name_in_element374);
                    	sql_name36 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name36.Tree);
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
    // $ANTLR end "element"

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
    // StringFilter.g:50:1: factor : ( element )+ ;
    public StringFilterParser.factor_return factor() // throws RecognitionException [1]
    {   
        StringFilterParser.factor_return retval = new StringFilterParser.factor_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        StringFilterParser.element_return element37 = default(StringFilterParser.element_return);



        try 
    	{
            // StringFilter.g:50:7: ( ( element )+ )
            // StringFilter.g:51:3: ( element )+
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// StringFilter.g:51:3: ( element )+
            	int cnt3 = 0;
            	do 
            	{
            	    int alt3 = 2;
            	    int LA3_0 = input.LA(1);

            	    if ( ((LA3_0 >= Q_STRING && LA3_0 <= I_STRING) || (LA3_0 >= PLUS && LA3_0 <= NE2)) )
            	    {
            	        alt3 = 1;
            	    }


            	    switch (alt3) 
            		{
            			case 1 :
            			    // StringFilter.g:51:3: element
            			    {
            			    	PushFollow(FOLLOW_element_in_factor389);
            			    	element37 = element();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, element37.Tree);

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
    // StringFilter.g:53:1: list : factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )* ;
    public StringFilterParser.list_return list() // throws RecognitionException [1]
    {   
        StringFilterParser.list_return retval = new StringFilterParser.list_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken COMMA39 = null;
        IToken ENDLINE40 = null;
        IToken ENDLINE42 = null;
        StringFilterParser.factor_return factor38 = default(StringFilterParser.factor_return);

        StringFilterParser.factor_return factor41 = default(StringFilterParser.factor_return);


        object COMMA39_tree=null;
        object ENDLINE40_tree=null;
        object ENDLINE42_tree=null;

        try 
    	{
            // StringFilter.g:53:5: ( factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )* )
            // StringFilter.g:54:3: factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_factor_in_list400);
            	factor38 = factor();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, factor38.Tree);
            	// StringFilter.g:54:10: ( ( COMMA | ( ( ENDLINE )+ ) ) factor )*
            	do 
            	{
            	    int alt6 = 2;
            	    alt6 = dfa6.Predict(input);
            	    switch (alt6) 
            		{
            			case 1 :
            			    // StringFilter.g:54:12: ( COMMA | ( ( ENDLINE )+ ) ) factor
            			    {
            			    	// StringFilter.g:54:12: ( COMMA | ( ( ENDLINE )+ ) )
            			    	int alt5 = 2;
            			    	int LA5_0 = input.LA(1);

            			    	if ( (LA5_0 == COMMA) )
            			    	{
            			    	    alt5 = 1;
            			    	}
            			    	else if ( (LA5_0 == ENDLINE) )
            			    	{
            			    	    alt5 = 2;
            			    	}
            			    	else 
            			    	{
            			    	    NoViableAltException nvae_d5s0 =
            			    	        new NoViableAltException("", 5, 0, input);

            			    	    throw nvae_d5s0;
            			    	}
            			    	switch (alt5) 
            			    	{
            			    	    case 1 :
            			    	        // StringFilter.g:54:13: COMMA
            			    	        {
            			    	        	COMMA39=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_list405); 
            			    	        		COMMA39_tree = (object)adaptor.Create(COMMA39);
            			    	        		adaptor.AddChild(root_0, COMMA39_tree);


            			    	        }
            			    	        break;
            			    	    case 2 :
            			    	        // StringFilter.g:54:21: ( ( ENDLINE )+ )
            			    	        {
            			    	        	// StringFilter.g:54:21: ( ( ENDLINE )+ )
            			    	        	// StringFilter.g:54:22: ( ENDLINE )+
            			    	        	{
            			    	        		// StringFilter.g:54:22: ( ENDLINE )+
            			    	        		int cnt4 = 0;
            			    	        		do 
            			    	        		{
            			    	        		    int alt4 = 2;
            			    	        		    int LA4_0 = input.LA(1);

            			    	        		    if ( (LA4_0 == ENDLINE) )
            			    	        		    {
            			    	        		        alt4 = 1;
            			    	        		    }


            			    	        		    switch (alt4) 
            			    	        			{
            			    	        				case 1 :
            			    	        				    // StringFilter.g:54:22: ENDLINE
            			    	        				    {
            			    	        				    	ENDLINE40=(IToken)Match(input,ENDLINE,FOLLOW_ENDLINE_in_list410); 
            			    	        				    		ENDLINE40_tree = (object)adaptor.Create(ENDLINE40);
            			    	        				    		adaptor.AddChild(root_0, ENDLINE40_tree);


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


            			    	        	}


            			    	        }
            			    	        break;

            			    	}

            			    	 AddAndCondition(); 
            			    	PushFollow(FOLLOW_factor_in_list417);
            			    	factor41 = factor();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, factor41.Tree);

            			    }
            			    break;

            			default:
            			    goto loop6;
            	    }
            	} while (true);

            	loop6:
            		;	// Stops C# compiler whining that label 'loop6' has no statements

            	// StringFilter.g:54:67: ( ENDLINE )*
            	do 
            	{
            	    int alt7 = 2;
            	    int LA7_0 = input.LA(1);

            	    if ( (LA7_0 == ENDLINE) )
            	    {
            	        alt7 = 1;
            	    }


            	    switch (alt7) 
            		{
            			case 1 :
            			    // StringFilter.g:54:67: ENDLINE
            			    {
            			    	ENDLINE42=(IToken)Match(input,ENDLINE,FOLLOW_ENDLINE_in_list423); 
            			    		ENDLINE42_tree = (object)adaptor.Create(ENDLINE42);
            			    		adaptor.AddChild(root_0, ENDLINE42_tree);


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
    // StringFilter.g:56:1: expr : list ;
    public StringFilterParser.expr_return expr() // throws RecognitionException [1]
    {   
        StringFilterParser.expr_return retval = new StringFilterParser.expr_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        StringFilterParser.list_return list43 = default(StringFilterParser.list_return);



        try 
    	{
            // StringFilter.g:56:5: ( list )
            // StringFilter.g:56:7: list
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_list_in_expr433);
            	list43 = list();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, list43.Tree);

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
   	protected DFA6 dfa6;
	private void InitializeCyclicDFAs()
	{
    	this.dfa2 = new DFA2(this);
    	this.dfa6 = new DFA6(this);
	}

    const string DFA2_eotS =
        "\x21\uffff";
    const string DFA2_eofS =
        "\x21\uffff";
    const string DFA2_minS =
        "\x01\x04\x03\uffff\x06\x04\x05\uffff\x01\x15\x11\uffff";
    const string DFA2_maxS =
        "\x01\x19\x03\uffff\x06\x07\x05\uffff\x01\x17\x11\uffff";
    const string DFA2_acceptS =
        "\x01\uffff\x01\x01\x01\x02\x01\x03\x06\uffff\x01\x0a\x01\x0b\x01"+
        "\x0c\x01\x0d\x01\x0e\x01\uffff\x01\x10\x01\x18\x01\x19\x01\x12\x01"+
        "\x04\x01\x05\x01\x13\x01\x06\x01\x14\x01\x07\x01\x15\x01\x08\x01"+
        "\x16\x01\x09\x01\x17\x01\x0f\x01\x11";
    const string DFA2_specialS =
        "\x21\uffff}>";
    static readonly string[] DFA2_transitionS = {
            "\x03\x01\x02\uffff\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06"+
            "\x01\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x01\x0c\x01\x0d\x01"+
            "\x0e\x01\x0f\x01\x10\x01\x11\x01\x12",
            "",
            "",
            "",
            "\x03\x14\x01\x13",
            "\x03\x15\x01\x16",
            "\x03\x17\x01\x18",
            "\x03\x19\x01\x1a",
            "\x03\x1b\x01\x1c",
            "\x03\x1d\x01\x1e",
            "",
            "",
            "",
            "",
            "",
            "\x01\x1f\x01\uffff\x01\x20",
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
            "",
            "",
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
            get { return "21:1: element : (s1= string_lit | PLUS s1= string_lit | MINUS s1= string_lit | LT s1= string_lit | GT s1= string_lit | LE s1= string_lit | GE s1= string_lit | NE s1= string_lit | EQ s1= string_lit | ARROW s1= string_lit | NARROW s1= string_lit | DOLLAR s1= string_lit | NDOLLAR s1= string_lit | T_NULL | T_NOT T_NULL | T_EMPTY | T_NOT T_EMPTY | LT sql_name | GT sql_name | LE sql_name | GE sql_name | NE sql_name | EQ sql_name | EQ2 sql_name | NE2 sql_name );"; }
        }

    }

    const string DFA6_eotS =
        "\x04\uffff";
    const string DFA6_eofS =
        "\x02\x02\x02\uffff";
    const string DFA6_minS =
        "\x01\x1a\x01\x04\x02\uffff";
    const string DFA6_maxS =
        "\x02\x1b\x02\uffff";
    const string DFA6_acceptS =
        "\x02\uffff\x01\x02\x01\x01";
    const string DFA6_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA6_transitionS = {
            "\x01\x03\x01\x01",
            "\x03\x03\x02\uffff\x11\x03\x01\uffff\x01\x01",
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
            get { return "()* loopback of 54:10: ( ( COMMA | ( ( ENDLINE )+ ) ) factor )*"; }
        }

    }

 

    public static readonly BitSet FOLLOW_set_in_string_lit0 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_SQL_LITERAL_in_sql_name60 = new BitSet(new ulong[]{0x0000000000000102UL});
    public static readonly BitSet FOLLOW_DOT_in_sql_name67 = new BitSet(new ulong[]{0x0000000000000080UL});
    public static readonly BitSet FOLLOW_SQL_LITERAL_in_sql_name71 = new BitSet(new ulong[]{0x0000000000000102UL});
    public static readonly BitSet FOLLOW_string_lit_in_element92 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_PLUS_in_element101 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element105 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_MINUS_in_element114 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element118 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_element127 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element131 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GT_in_element140 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element144 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LE_in_element153 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element157 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GE_in_element166 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element170 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NE_in_element179 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element183 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EQ_in_element192 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element196 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_ARROW_in_element205 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element209 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NARROW_in_element218 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element222 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DOLLAR_in_element231 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element235 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NDOLLAR_in_element244 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element248 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NULL_in_element257 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NOT_in_element265 = new BitSet(new ulong[]{0x0000000000200000UL});
    public static readonly BitSet FOLLOW_T_NULL_in_element267 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_EMPTY_in_element275 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NOT_in_element283 = new BitSet(new ulong[]{0x0000000000800000UL});
    public static readonly BitSet FOLLOW_T_EMPTY_in_element285 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_element296 = new BitSet(new ulong[]{0x0000000000000080UL});
    public static readonly BitSet FOLLOW_sql_name_in_element298 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GT_in_element307 = new BitSet(new ulong[]{0x0000000000000080UL});
    public static readonly BitSet FOLLOW_sql_name_in_element309 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LE_in_element318 = new BitSet(new ulong[]{0x0000000000000080UL});
    public static readonly BitSet FOLLOW_sql_name_in_element320 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GE_in_element329 = new BitSet(new ulong[]{0x0000000000000080UL});
    public static readonly BitSet FOLLOW_sql_name_in_element331 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NE_in_element340 = new BitSet(new ulong[]{0x0000000000000080UL});
    public static readonly BitSet FOLLOW_sql_name_in_element342 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EQ_in_element351 = new BitSet(new ulong[]{0x0000000000000080UL});
    public static readonly BitSet FOLLOW_sql_name_in_element353 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EQ2_in_element361 = new BitSet(new ulong[]{0x0000000000000080UL});
    public static readonly BitSet FOLLOW_sql_name_in_element363 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NE2_in_element372 = new BitSet(new ulong[]{0x0000000000000080UL});
    public static readonly BitSet FOLLOW_sql_name_in_element374 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_element_in_factor389 = new BitSet(new ulong[]{0x0000000003FFFE72UL});
    public static readonly BitSet FOLLOW_factor_in_list400 = new BitSet(new ulong[]{0x000000000C000002UL});
    public static readonly BitSet FOLLOW_COMMA_in_list405 = new BitSet(new ulong[]{0x0000000003FFFE70UL});
    public static readonly BitSet FOLLOW_ENDLINE_in_list410 = new BitSet(new ulong[]{0x000000000BFFFE70UL});
    public static readonly BitSet FOLLOW_factor_in_list417 = new BitSet(new ulong[]{0x000000000C000002UL});
    public static readonly BitSet FOLLOW_ENDLINE_in_list423 = new BitSet(new ulong[]{0x0000000008000002UL});
    public static readonly BitSet FOLLOW_list_in_expr433 = new BitSet(new ulong[]{0x0000000000000002UL});

}
