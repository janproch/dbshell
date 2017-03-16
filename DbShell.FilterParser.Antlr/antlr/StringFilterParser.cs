// $ANTLR 3.2 Sep 23, 2009 12:02:23 StringFilter.g 2016-09-07 21:54:33

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
		"SQL_VARIABLE", 
		"PLUS", 
		"TILDA", 
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

    public const int DOLLAR = 20;
    public const int LT = 12;
    public const int STAR = 29;
    public const int EOF = -1;
    public const int Q_STRING = 4;
    public const int TILDA = 11;
    public const int COMMA = 27;
    public const int T_NULL = 22;
    public const int PLUS = 10;
    public const int DIGIT = 40;
    public const int EQ = 17;
    public const int DOT = 8;
    public const int NE = 16;
    public const int D = 44;
    public const int E = 35;
    public const int F = 45;
    public const int GE = 15;
    public const int G = 46;
    public const int SQL_VARIABLE = 9;
    public const int I_STRING = 6;
    public const int A = 41;
    public const int B = 42;
    public const int C = 43;
    public const int NE2 = 26;
    public const int L = 32;
    public const int M = 36;
    public const int N = 30;
    public const int O = 33;
    public const int H = 47;
    public const int I = 48;
    public const int J = 49;
    public const int K = 50;
    public const int U = 31;
    public const int T = 34;
    public const int W = 55;
    public const int WHITESPACE = 39;
    public const int V = 54;
    public const int Q = 51;
    public const int P = 37;
    public const int S = 53;
    public const int R = 52;
    public const int Y = 38;
    public const int X = 56;
    public const int SQL_LITERAL = 7;
    public const int EQ2 = 25;
    public const int Z = 57;
    public const int NDOLLAR = 21;
    public const int T_EMPTY = 24;
    public const int A_STRING = 5;
    public const int ARROW = 18;
    public const int GT = 13;
    public const int ENDLINE = 28;
    public const int T_NOT = 23;
    public const int NARROW = 19;
    public const int LE = 14;

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
    // StringFilter.g:16:1: sql_identifier : lit1= SQL_LITERAL ( DOT lit2= SQL_LITERAL )* ;
    public StringFilterParser.sql_identifier_return sql_identifier() // throws RecognitionException [1]
    {   
        StringFilterParser.sql_identifier_return retval = new StringFilterParser.sql_identifier_return();
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
            // StringFilter.g:16:15: (lit1= SQL_LITERAL ( DOT lit2= SQL_LITERAL )* )
            // StringFilter.g:17:3: lit1= SQL_LITERAL ( DOT lit2= SQL_LITERAL )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	lit1=(IToken)Match(input,SQL_LITERAL,FOLLOW_SQL_LITERAL_in_sql_identifier60); 
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
            			    	DOT2=(IToken)Match(input,DOT,FOLLOW_DOT_in_sql_identifier67); 
            			    		DOT2_tree = (object)adaptor.Create(DOT2);
            			    		adaptor.AddChild(root_0, DOT2_tree);

            			    	lit2=(IToken)Match(input,SQL_LITERAL,FOLLOW_SQL_LITERAL_in_sql_identifier71); 
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
    // StringFilter.g:21:1: sql_variable : var= SQL_VARIABLE ;
    public StringFilterParser.sql_variable_return sql_variable() // throws RecognitionException [1]
    {   
        StringFilterParser.sql_variable_return retval = new StringFilterParser.sql_variable_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken var = null;

        object var_tree=null;

        try 
    	{
            // StringFilter.g:21:13: (var= SQL_VARIABLE )
            // StringFilter.g:22:5: var= SQL_VARIABLE
            {
            	root_0 = (object)adaptor.GetNilNode();

            	var=(IToken)Match(input,SQL_VARIABLE,FOLLOW_SQL_VARIABLE_in_sql_variable96); 
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
    // StringFilter.g:24:1: sql_name : ( sql_identifier | sql_variable );
    public StringFilterParser.sql_name_return sql_name() // throws RecognitionException [1]
    {   
        StringFilterParser.sql_name_return retval = new StringFilterParser.sql_name_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        StringFilterParser.sql_identifier_return sql_identifier3 = default(StringFilterParser.sql_identifier_return);

        StringFilterParser.sql_variable_return sql_variable4 = default(StringFilterParser.sql_variable_return);



        try 
    	{
            // StringFilter.g:24:10: ( sql_identifier | sql_variable )
            int alt2 = 2;
            int LA2_0 = input.LA(1);

            if ( (LA2_0 == SQL_LITERAL) )
            {
                alt2 = 1;
            }
            else if ( (LA2_0 == SQL_VARIABLE) )
            {
                alt2 = 2;
            }
            else 
            {
                NoViableAltException nvae_d2s0 =
                    new NoViableAltException("", 2, 0, input);

                throw nvae_d2s0;
            }
            switch (alt2) 
            {
                case 1 :
                    // StringFilter.g:24:12: sql_identifier
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_sql_identifier_in_sql_name108);
                    	sql_identifier3 = sql_identifier();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_identifier3.Tree);

                    }
                    break;
                case 2 :
                    // StringFilter.g:24:29: sql_variable
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_sql_variable_in_sql_name112);
                    	sql_variable4 = sql_variable();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_variable4.Tree);

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
    // StringFilter.g:26:1: element : (s1= string_lit | PLUS s1= string_lit | TILDA s1= string_lit | LT s1= string_lit | GT s1= string_lit | LE s1= string_lit | GE s1= string_lit | NE s1= string_lit | EQ s1= string_lit | ARROW s1= string_lit | NARROW s1= string_lit | DOLLAR s1= string_lit | NDOLLAR s1= string_lit | T_NULL | T_NOT T_NULL | T_EMPTY | T_NOT T_EMPTY | LT sql_name | GT sql_name | LE sql_name | GE sql_name | NE sql_name | EQ sql_name | EQ2 sql_name | NE2 sql_name );
    public StringFilterParser.element_return element() // throws RecognitionException [1]
    {   
        StringFilterParser.element_return retval = new StringFilterParser.element_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken PLUS5 = null;
        IToken TILDA6 = null;
        IToken LT7 = null;
        IToken GT8 = null;
        IToken LE9 = null;
        IToken GE10 = null;
        IToken NE11 = null;
        IToken EQ12 = null;
        IToken ARROW13 = null;
        IToken NARROW14 = null;
        IToken DOLLAR15 = null;
        IToken NDOLLAR16 = null;
        IToken T_NULL17 = null;
        IToken T_NOT18 = null;
        IToken T_NULL19 = null;
        IToken T_EMPTY20 = null;
        IToken T_NOT21 = null;
        IToken T_EMPTY22 = null;
        IToken LT23 = null;
        IToken GT25 = null;
        IToken LE27 = null;
        IToken GE29 = null;
        IToken NE31 = null;
        IToken EQ33 = null;
        IToken EQ235 = null;
        IToken NE237 = null;
        StringFilterParser.string_lit_return s1 = default(StringFilterParser.string_lit_return);

        StringFilterParser.sql_name_return sql_name24 = default(StringFilterParser.sql_name_return);

        StringFilterParser.sql_name_return sql_name26 = default(StringFilterParser.sql_name_return);

        StringFilterParser.sql_name_return sql_name28 = default(StringFilterParser.sql_name_return);

        StringFilterParser.sql_name_return sql_name30 = default(StringFilterParser.sql_name_return);

        StringFilterParser.sql_name_return sql_name32 = default(StringFilterParser.sql_name_return);

        StringFilterParser.sql_name_return sql_name34 = default(StringFilterParser.sql_name_return);

        StringFilterParser.sql_name_return sql_name36 = default(StringFilterParser.sql_name_return);

        StringFilterParser.sql_name_return sql_name38 = default(StringFilterParser.sql_name_return);


        object PLUS5_tree=null;
        object TILDA6_tree=null;
        object LT7_tree=null;
        object GT8_tree=null;
        object LE9_tree=null;
        object GE10_tree=null;
        object NE11_tree=null;
        object EQ12_tree=null;
        object ARROW13_tree=null;
        object NARROW14_tree=null;
        object DOLLAR15_tree=null;
        object NDOLLAR16_tree=null;
        object T_NULL17_tree=null;
        object T_NOT18_tree=null;
        object T_NULL19_tree=null;
        object T_EMPTY20_tree=null;
        object T_NOT21_tree=null;
        object T_EMPTY22_tree=null;
        object LT23_tree=null;
        object GT25_tree=null;
        object LE27_tree=null;
        object GE29_tree=null;
        object NE31_tree=null;
        object EQ33_tree=null;
        object EQ235_tree=null;
        object NE237_tree=null;

        try 
    	{
            // StringFilter.g:26:8: (s1= string_lit | PLUS s1= string_lit | TILDA s1= string_lit | LT s1= string_lit | GT s1= string_lit | LE s1= string_lit | GE s1= string_lit | NE s1= string_lit | EQ s1= string_lit | ARROW s1= string_lit | NARROW s1= string_lit | DOLLAR s1= string_lit | NDOLLAR s1= string_lit | T_NULL | T_NOT T_NULL | T_EMPTY | T_NOT T_EMPTY | LT sql_name | GT sql_name | LE sql_name | GE sql_name | NE sql_name | EQ sql_name | EQ2 sql_name | NE2 sql_name )
            int alt3 = 25;
            alt3 = dfa3.Predict(input);
            switch (alt3) 
            {
                case 1 :
                    // StringFilter.g:27:3: s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_string_lit_in_element123);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringTestCondition<DmlfContainsTextCondition>(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null))); 

                    }
                    break;
                case 2 :
                    // StringFilter.g:28:5: PLUS s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PLUS5=(IToken)Match(input,PLUS,FOLLOW_PLUS_in_element132); 
                    		PLUS5_tree = (object)adaptor.Create(PLUS5);
                    		adaptor.AddChild(root_0, PLUS5_tree);

                    	PushFollow(FOLLOW_string_lit_in_element136);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringTestCondition<DmlfContainsTextCondition>(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null))); 

                    }
                    break;
                case 3 :
                    // StringFilter.g:29:5: TILDA s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	TILDA6=(IToken)Match(input,TILDA,FOLLOW_TILDA_in_element145); 
                    		TILDA6_tree = (object)adaptor.Create(TILDA6);
                    		adaptor.AddChild(root_0, TILDA6_tree);

                    	PushFollow(FOLLOW_string_lit_in_element149);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringTestCondition<DmlfContainsTextCondition>(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)));NegateLastCondition(); 

                    }
                    break;
                case 4 :
                    // StringFilter.g:30:5: LT s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LT7=(IToken)Match(input,LT,FOLLOW_LT_in_element158); 
                    		LT7_tree = (object)adaptor.Create(LT7);
                    		adaptor.AddChild(root_0, LT7_tree);

                    	PushFollow(FOLLOW_string_lit_in_element162);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringRelation(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)), "<"); 

                    }
                    break;
                case 5 :
                    // StringFilter.g:31:5: GT s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GT8=(IToken)Match(input,GT,FOLLOW_GT_in_element171); 
                    		GT8_tree = (object)adaptor.Create(GT8);
                    		adaptor.AddChild(root_0, GT8_tree);

                    	PushFollow(FOLLOW_string_lit_in_element175);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringRelation(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)), ">"); 

                    }
                    break;
                case 6 :
                    // StringFilter.g:32:5: LE s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LE9=(IToken)Match(input,LE,FOLLOW_LE_in_element184); 
                    		LE9_tree = (object)adaptor.Create(LE9);
                    		adaptor.AddChild(root_0, LE9_tree);

                    	PushFollow(FOLLOW_string_lit_in_element188);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringRelation(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)), "<="); 

                    }
                    break;
                case 7 :
                    // StringFilter.g:33:5: GE s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GE10=(IToken)Match(input,GE,FOLLOW_GE_in_element197); 
                    		GE10_tree = (object)adaptor.Create(GE10);
                    		adaptor.AddChild(root_0, GE10_tree);

                    	PushFollow(FOLLOW_string_lit_in_element201);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringRelation(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)), ">="); 

                    }
                    break;
                case 8 :
                    // StringFilter.g:34:5: NE s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NE11=(IToken)Match(input,NE,FOLLOW_NE_in_element210); 
                    		NE11_tree = (object)adaptor.Create(NE11);
                    		adaptor.AddChild(root_0, NE11_tree);

                    	PushFollow(FOLLOW_string_lit_in_element214);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringRelation(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)), "<>"); 

                    }
                    break;
                case 9 :
                    // StringFilter.g:35:5: EQ s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	EQ12=(IToken)Match(input,EQ,FOLLOW_EQ_in_element223); 
                    		EQ12_tree = (object)adaptor.Create(EQ12);
                    		adaptor.AddChild(root_0, EQ12_tree);

                    	PushFollow(FOLLOW_string_lit_in_element227);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringRelation(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)), "="); 

                    }
                    break;
                case 10 :
                    // StringFilter.g:36:5: ARROW s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	ARROW13=(IToken)Match(input,ARROW,FOLLOW_ARROW_in_element236); 
                    		ARROW13_tree = (object)adaptor.Create(ARROW13);
                    		adaptor.AddChild(root_0, ARROW13_tree);

                    	PushFollow(FOLLOW_string_lit_in_element240);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringTestCondition<DmlfStartsWithCondition>(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null))); 

                    }
                    break;
                case 11 :
                    // StringFilter.g:37:5: NARROW s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NARROW14=(IToken)Match(input,NARROW,FOLLOW_NARROW_in_element249); 
                    		NARROW14_tree = (object)adaptor.Create(NARROW14);
                    		adaptor.AddChild(root_0, NARROW14_tree);

                    	PushFollow(FOLLOW_string_lit_in_element253);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringTestCondition<DmlfStartsWithCondition>(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)));NegateLastCondition(); 

                    }
                    break;
                case 12 :
                    // StringFilter.g:38:5: DOLLAR s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	DOLLAR15=(IToken)Match(input,DOLLAR,FOLLOW_DOLLAR_in_element262); 
                    		DOLLAR15_tree = (object)adaptor.Create(DOLLAR15);
                    		adaptor.AddChild(root_0, DOLLAR15_tree);

                    	PushFollow(FOLLOW_string_lit_in_element266);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringTestCondition<DmlfEndsWithCondition>(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null))); 

                    }
                    break;
                case 13 :
                    // StringFilter.g:39:5: NDOLLAR s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NDOLLAR16=(IToken)Match(input,NDOLLAR,FOLLOW_NDOLLAR_in_element275); 
                    		NDOLLAR16_tree = (object)adaptor.Create(NDOLLAR16);
                    		adaptor.AddChild(root_0, NDOLLAR16_tree);

                    	PushFollow(FOLLOW_string_lit_in_element279);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringTestCondition<DmlfEndsWithCondition>(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)));NegateLastCondition(); 

                    }
                    break;
                case 14 :
                    // StringFilter.g:40:5: T_NULL
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NULL17=(IToken)Match(input,T_NULL,FOLLOW_T_NULL_in_element288); 
                    		T_NULL17_tree = (object)adaptor.Create(T_NULL17);
                    		adaptor.AddChild(root_0, T_NULL17_tree);

                    	 AddIsNullCondition(); 

                    }
                    break;
                case 15 :
                    // StringFilter.g:41:5: T_NOT T_NULL
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NOT18=(IToken)Match(input,T_NOT,FOLLOW_T_NOT_in_element296); 
                    		T_NOT18_tree = (object)adaptor.Create(T_NOT18);
                    		adaptor.AddChild(root_0, T_NOT18_tree);

                    	T_NULL19=(IToken)Match(input,T_NULL,FOLLOW_T_NULL_in_element298); 
                    		T_NULL19_tree = (object)adaptor.Create(T_NULL19);
                    		adaptor.AddChild(root_0, T_NULL19_tree);

                    	 AddIsNotNullCondition(); 

                    }
                    break;
                case 16 :
                    // StringFilter.g:42:5: T_EMPTY
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_EMPTY20=(IToken)Match(input,T_EMPTY,FOLLOW_T_EMPTY_in_element306); 
                    		T_EMPTY20_tree = (object)adaptor.Create(T_EMPTY20);
                    		adaptor.AddChild(root_0, T_EMPTY20_tree);

                    	 AddIsEmptyCondition(); 

                    }
                    break;
                case 17 :
                    // StringFilter.g:43:5: T_NOT T_EMPTY
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NOT21=(IToken)Match(input,T_NOT,FOLLOW_T_NOT_in_element314); 
                    		T_NOT21_tree = (object)adaptor.Create(T_NOT21);
                    		adaptor.AddChild(root_0, T_NOT21_tree);

                    	T_EMPTY22=(IToken)Match(input,T_EMPTY,FOLLOW_T_EMPTY_in_element316); 
                    		T_EMPTY22_tree = (object)adaptor.Create(T_EMPTY22);
                    		adaptor.AddChild(root_0, T_EMPTY22_tree);

                    	 AddIsNotEmptyCondition(); 

                    }
                    break;
                case 18 :
                    // StringFilter.g:45:5: LT sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LT23=(IToken)Match(input,LT,FOLLOW_LT_in_element327); 
                    		LT23_tree = (object)adaptor.Create(LT23);
                    		adaptor.AddChild(root_0, LT23_tree);

                    	PushFollow(FOLLOW_sql_name_in_element329);
                    	sql_name24 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name24.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), "<"); 

                    }
                    break;
                case 19 :
                    // StringFilter.g:46:5: GT sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GT25=(IToken)Match(input,GT,FOLLOW_GT_in_element338); 
                    		GT25_tree = (object)adaptor.Create(GT25);
                    		adaptor.AddChild(root_0, GT25_tree);

                    	PushFollow(FOLLOW_sql_name_in_element340);
                    	sql_name26 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name26.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), ">"); 

                    }
                    break;
                case 20 :
                    // StringFilter.g:47:5: LE sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LE27=(IToken)Match(input,LE,FOLLOW_LE_in_element349); 
                    		LE27_tree = (object)adaptor.Create(LE27);
                    		adaptor.AddChild(root_0, LE27_tree);

                    	PushFollow(FOLLOW_sql_name_in_element351);
                    	sql_name28 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name28.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), "<="); 

                    }
                    break;
                case 21 :
                    // StringFilter.g:48:5: GE sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GE29=(IToken)Match(input,GE,FOLLOW_GE_in_element360); 
                    		GE29_tree = (object)adaptor.Create(GE29);
                    		adaptor.AddChild(root_0, GE29_tree);

                    	PushFollow(FOLLOW_sql_name_in_element362);
                    	sql_name30 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name30.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), ">="); 

                    }
                    break;
                case 22 :
                    // StringFilter.g:49:5: NE sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NE31=(IToken)Match(input,NE,FOLLOW_NE_in_element371); 
                    		NE31_tree = (object)adaptor.Create(NE31);
                    		adaptor.AddChild(root_0, NE31_tree);

                    	PushFollow(FOLLOW_sql_name_in_element373);
                    	sql_name32 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name32.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), "<>"); 

                    }
                    break;
                case 23 :
                    // StringFilter.g:50:5: EQ sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	EQ33=(IToken)Match(input,EQ,FOLLOW_EQ_in_element382); 
                    		EQ33_tree = (object)adaptor.Create(EQ33);
                    		adaptor.AddChild(root_0, EQ33_tree);

                    	PushFollow(FOLLOW_sql_name_in_element384);
                    	sql_name34 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name34.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), "="); 

                    }
                    break;
                case 24 :
                    // StringFilter.g:51:5: EQ2 sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	EQ235=(IToken)Match(input,EQ2,FOLLOW_EQ2_in_element392); 
                    		EQ235_tree = (object)adaptor.Create(EQ235);
                    		adaptor.AddChild(root_0, EQ235_tree);

                    	PushFollow(FOLLOW_sql_name_in_element394);
                    	sql_name36 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name36.Tree);
                    	 AddSqlLiteralRelationWithNullTest_EQ(Pop<string>()); 

                    }
                    break;
                case 25 :
                    // StringFilter.g:52:5: NE2 sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NE237=(IToken)Match(input,NE2,FOLLOW_NE2_in_element403); 
                    		NE237_tree = (object)adaptor.Create(NE237);
                    		adaptor.AddChild(root_0, NE237_tree);

                    	PushFollow(FOLLOW_sql_name_in_element405);
                    	sql_name38 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name38.Tree);
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
    // StringFilter.g:55:1: factor : ( element )+ ;
    public StringFilterParser.factor_return factor() // throws RecognitionException [1]
    {   
        StringFilterParser.factor_return retval = new StringFilterParser.factor_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        StringFilterParser.element_return element39 = default(StringFilterParser.element_return);



        try 
    	{
            // StringFilter.g:55:7: ( ( element )+ )
            // StringFilter.g:56:3: ( element )+
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// StringFilter.g:56:3: ( element )+
            	int cnt4 = 0;
            	do 
            	{
            	    int alt4 = 2;
            	    int LA4_0 = input.LA(1);

            	    if ( ((LA4_0 >= Q_STRING && LA4_0 <= I_STRING) || (LA4_0 >= PLUS && LA4_0 <= NE2)) )
            	    {
            	        alt4 = 1;
            	    }


            	    switch (alt4) 
            		{
            			case 1 :
            			    // StringFilter.g:56:3: element
            			    {
            			    	PushFollow(FOLLOW_element_in_factor420);
            			    	element39 = element();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, element39.Tree);

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
    // StringFilter.g:58:1: list : factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )* ;
    public StringFilterParser.list_return list() // throws RecognitionException [1]
    {   
        StringFilterParser.list_return retval = new StringFilterParser.list_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken COMMA41 = null;
        IToken ENDLINE42 = null;
        IToken ENDLINE44 = null;
        StringFilterParser.factor_return factor40 = default(StringFilterParser.factor_return);

        StringFilterParser.factor_return factor43 = default(StringFilterParser.factor_return);


        object COMMA41_tree=null;
        object ENDLINE42_tree=null;
        object ENDLINE44_tree=null;

        try 
    	{
            // StringFilter.g:58:5: ( factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )* )
            // StringFilter.g:59:3: factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_factor_in_list431);
            	factor40 = factor();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, factor40.Tree);
            	// StringFilter.g:59:10: ( ( COMMA | ( ( ENDLINE )+ ) ) factor )*
            	do 
            	{
            	    int alt7 = 2;
            	    alt7 = dfa7.Predict(input);
            	    switch (alt7) 
            		{
            			case 1 :
            			    // StringFilter.g:59:12: ( COMMA | ( ( ENDLINE )+ ) ) factor
            			    {
            			    	// StringFilter.g:59:12: ( COMMA | ( ( ENDLINE )+ ) )
            			    	int alt6 = 2;
            			    	int LA6_0 = input.LA(1);

            			    	if ( (LA6_0 == COMMA) )
            			    	{
            			    	    alt6 = 1;
            			    	}
            			    	else if ( (LA6_0 == ENDLINE) )
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
            			    	        // StringFilter.g:59:13: COMMA
            			    	        {
            			    	        	COMMA41=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_list436); 
            			    	        		COMMA41_tree = (object)adaptor.Create(COMMA41);
            			    	        		adaptor.AddChild(root_0, COMMA41_tree);


            			    	        }
            			    	        break;
            			    	    case 2 :
            			    	        // StringFilter.g:59:21: ( ( ENDLINE )+ )
            			    	        {
            			    	        	// StringFilter.g:59:21: ( ( ENDLINE )+ )
            			    	        	// StringFilter.g:59:22: ( ENDLINE )+
            			    	        	{
            			    	        		// StringFilter.g:59:22: ( ENDLINE )+
            			    	        		int cnt5 = 0;
            			    	        		do 
            			    	        		{
            			    	        		    int alt5 = 2;
            			    	        		    int LA5_0 = input.LA(1);

            			    	        		    if ( (LA5_0 == ENDLINE) )
            			    	        		    {
            			    	        		        alt5 = 1;
            			    	        		    }


            			    	        		    switch (alt5) 
            			    	        			{
            			    	        				case 1 :
            			    	        				    // StringFilter.g:59:22: ENDLINE
            			    	        				    {
            			    	        				    	ENDLINE42=(IToken)Match(input,ENDLINE,FOLLOW_ENDLINE_in_list441); 
            			    	        				    		ENDLINE42_tree = (object)adaptor.Create(ENDLINE42);
            			    	        				    		adaptor.AddChild(root_0, ENDLINE42_tree);


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


            			    	        }
            			    	        break;

            			    	}

            			    	 AddAndCondition(); 
            			    	PushFollow(FOLLOW_factor_in_list448);
            			    	factor43 = factor();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, factor43.Tree);

            			    }
            			    break;

            			default:
            			    goto loop7;
            	    }
            	} while (true);

            	loop7:
            		;	// Stops C# compiler whining that label 'loop7' has no statements

            	// StringFilter.g:59:67: ( ENDLINE )*
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
            			    // StringFilter.g:59:67: ENDLINE
            			    {
            			    	ENDLINE44=(IToken)Match(input,ENDLINE,FOLLOW_ENDLINE_in_list454); 
            			    		ENDLINE44_tree = (object)adaptor.Create(ENDLINE44);
            			    		adaptor.AddChild(root_0, ENDLINE44_tree);


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
    // StringFilter.g:61:1: expr : list ;
    public StringFilterParser.expr_return expr() // throws RecognitionException [1]
    {   
        StringFilterParser.expr_return retval = new StringFilterParser.expr_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        StringFilterParser.list_return list45 = default(StringFilterParser.list_return);



        try 
    	{
            // StringFilter.g:61:5: ( list )
            // StringFilter.g:61:7: list
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_list_in_expr464);
            	list45 = list();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, list45.Tree);

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
   	protected DFA7 dfa7;
	private void InitializeCyclicDFAs()
	{
    	this.dfa3 = new DFA3(this);
    	this.dfa7 = new DFA7(this);
	}

    const string DFA3_eotS =
        "\x21\uffff";
    const string DFA3_eofS =
        "\x21\uffff";
    const string DFA3_minS =
        "\x01\x04\x03\uffff\x06\x04\x05\uffff\x01\x16\x11\uffff";
    const string DFA3_maxS =
        "\x01\x1a\x03\uffff\x06\x09\x05\uffff\x01\x18\x11\uffff";
    const string DFA3_acceptS =
        "\x01\uffff\x01\x01\x01\x02\x01\x03\x06\uffff\x01\x0a\x01\x0b\x01"+
        "\x0c\x01\x0d\x01\x0e\x01\uffff\x01\x10\x01\x18\x01\x19\x01\x04\x01"+
        "\x12\x01\x05\x01\x13\x01\x06\x01\x14\x01\x07\x01\x15\x01\x16\x01"+
        "\x08\x01\x17\x01\x09\x01\x0f\x01\x11";
    const string DFA3_specialS =
        "\x21\uffff}>";
    static readonly string[] DFA3_transitionS = {
            "\x03\x01\x03\uffff\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06"+
            "\x01\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x01\x0c\x01\x0d\x01"+
            "\x0e\x01\x0f\x01\x10\x01\x11\x01\x12",
            "",
            "",
            "",
            "\x03\x13\x01\x14\x01\uffff\x01\x14",
            "\x03\x15\x01\x16\x01\uffff\x01\x16",
            "\x03\x17\x01\x18\x01\uffff\x01\x18",
            "\x03\x19\x01\x1a\x01\uffff\x01\x1a",
            "\x03\x1c\x01\x1b\x01\uffff\x01\x1b",
            "\x03\x1e\x01\x1d\x01\uffff\x01\x1d",
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
            get { return "26:1: element : (s1= string_lit | PLUS s1= string_lit | TILDA s1= string_lit | LT s1= string_lit | GT s1= string_lit | LE s1= string_lit | GE s1= string_lit | NE s1= string_lit | EQ s1= string_lit | ARROW s1= string_lit | NARROW s1= string_lit | DOLLAR s1= string_lit | NDOLLAR s1= string_lit | T_NULL | T_NOT T_NULL | T_EMPTY | T_NOT T_EMPTY | LT sql_name | GT sql_name | LE sql_name | GE sql_name | NE sql_name | EQ sql_name | EQ2 sql_name | NE2 sql_name );"; }
        }

    }

    const string DFA7_eotS =
        "\x04\uffff";
    const string DFA7_eofS =
        "\x02\x02\x02\uffff";
    const string DFA7_minS =
        "\x01\x1b\x01\x04\x02\uffff";
    const string DFA7_maxS =
        "\x02\x1c\x02\uffff";
    const string DFA7_acceptS =
        "\x02\uffff\x01\x02\x01\x01";
    const string DFA7_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA7_transitionS = {
            "\x01\x03\x01\x01",
            "\x03\x03\x03\uffff\x11\x03\x01\uffff\x01\x01",
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
            get { return "()* loopback of 59:10: ( ( COMMA | ( ( ENDLINE )+ ) ) factor )*"; }
        }

    }

 

    public static readonly BitSet FOLLOW_set_in_string_lit0 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_SQL_LITERAL_in_sql_identifier60 = new BitSet(new ulong[]{0x0000000000000102UL});
    public static readonly BitSet FOLLOW_DOT_in_sql_identifier67 = new BitSet(new ulong[]{0x0000000000000080UL});
    public static readonly BitSet FOLLOW_SQL_LITERAL_in_sql_identifier71 = new BitSet(new ulong[]{0x0000000000000102UL});
    public static readonly BitSet FOLLOW_SQL_VARIABLE_in_sql_variable96 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_sql_identifier_in_sql_name108 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_sql_variable_in_sql_name112 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_string_lit_in_element123 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_PLUS_in_element132 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element136 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_TILDA_in_element145 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element149 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_element158 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element162 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GT_in_element171 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element175 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LE_in_element184 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element188 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GE_in_element197 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element201 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NE_in_element210 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element214 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EQ_in_element223 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element227 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_ARROW_in_element236 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element240 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NARROW_in_element249 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element253 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DOLLAR_in_element262 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element266 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NDOLLAR_in_element275 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element279 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NULL_in_element288 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NOT_in_element296 = new BitSet(new ulong[]{0x0000000000400000UL});
    public static readonly BitSet FOLLOW_T_NULL_in_element298 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_EMPTY_in_element306 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NOT_in_element314 = new BitSet(new ulong[]{0x0000000001000000UL});
    public static readonly BitSet FOLLOW_T_EMPTY_in_element316 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_element327 = new BitSet(new ulong[]{0x0000000000000280UL});
    public static readonly BitSet FOLLOW_sql_name_in_element329 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GT_in_element338 = new BitSet(new ulong[]{0x0000000000000280UL});
    public static readonly BitSet FOLLOW_sql_name_in_element340 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LE_in_element349 = new BitSet(new ulong[]{0x0000000000000280UL});
    public static readonly BitSet FOLLOW_sql_name_in_element351 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GE_in_element360 = new BitSet(new ulong[]{0x0000000000000280UL});
    public static readonly BitSet FOLLOW_sql_name_in_element362 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NE_in_element371 = new BitSet(new ulong[]{0x0000000000000280UL});
    public static readonly BitSet FOLLOW_sql_name_in_element373 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EQ_in_element382 = new BitSet(new ulong[]{0x0000000000000280UL});
    public static readonly BitSet FOLLOW_sql_name_in_element384 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EQ2_in_element392 = new BitSet(new ulong[]{0x0000000000000280UL});
    public static readonly BitSet FOLLOW_sql_name_in_element394 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NE2_in_element403 = new BitSet(new ulong[]{0x0000000000000280UL});
    public static readonly BitSet FOLLOW_sql_name_in_element405 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_element_in_factor420 = new BitSet(new ulong[]{0x0000000007FFFC72UL});
    public static readonly BitSet FOLLOW_factor_in_list431 = new BitSet(new ulong[]{0x0000000018000002UL});
    public static readonly BitSet FOLLOW_COMMA_in_list436 = new BitSet(new ulong[]{0x0000000007FFFC70UL});
    public static readonly BitSet FOLLOW_ENDLINE_in_list441 = new BitSet(new ulong[]{0x0000000017FFFC70UL});
    public static readonly BitSet FOLLOW_factor_in_list448 = new BitSet(new ulong[]{0x0000000018000002UL});
    public static readonly BitSet FOLLOW_ENDLINE_in_list454 = new BitSet(new ulong[]{0x0000000010000002UL});
    public static readonly BitSet FOLLOW_list_in_expr464 = new BitSet(new ulong[]{0x0000000000000002UL});

}
