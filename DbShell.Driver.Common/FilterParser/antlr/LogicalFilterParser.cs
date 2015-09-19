// $ANTLR 3.2 Sep 23, 2009 12:02:23 LogicalFilter.g 2015-09-19 21:51:35

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

public partial class LogicalFilterParser : DbShellFilterAntlrParser
{
    public static readonly string[] tokenNames = new string[] 
	{
        "<invalid>", 
		"<EOR>", 
		"<DOWN>", 
		"<UP>", 
		"SQL_LITERAL", 
		"DOT", 
		"SQL_VARIABLE", 
		"T_TRUE", 
		"T_FALSE", 
		"T_1", 
		"T_0", 
		"T_NULL", 
		"T_NOT", 
		"NE", 
		"EQ", 
		"EQ2", 
		"NE2", 
		"COMMA", 
		"ENDLINE", 
		"N", 
		"U", 
		"L", 
		"O", 
		"T", 
		"R", 
		"E", 
		"F", 
		"A", 
		"S", 
		"DIGIT_0", 
		"DIGIT_1", 
		"WHITESPACE", 
		"A_STRING", 
		"Q_STRING", 
		"B", 
		"C", 
		"D", 
		"G", 
		"H", 
		"I", 
		"J", 
		"K", 
		"M", 
		"P", 
		"Q", 
		"V", 
		"W", 
		"X", 
		"Y", 
		"Z"
    };

    public const int EOF = -1;
    public const int Q_STRING = 33;
    public const int DIGIT_0 = 29;
    public const int COMMA = 17;
    public const int DIGIT_1 = 30;
    public const int T_NULL = 11;
    public const int T_TRUE = 7;
    public const int EQ = 14;
    public const int DOT = 5;
    public const int NE = 13;
    public const int D = 36;
    public const int E = 25;
    public const int F = 26;
    public const int G = 37;
    public const int SQL_VARIABLE = 6;
    public const int A = 27;
    public const int B = 34;
    public const int NE2 = 16;
    public const int C = 35;
    public const int L = 21;
    public const int M = 42;
    public const int N = 19;
    public const int O = 22;
    public const int H = 38;
    public const int I = 39;
    public const int J = 40;
    public const int K = 41;
    public const int U = 20;
    public const int T = 23;
    public const int W = 46;
    public const int WHITESPACE = 31;
    public const int V = 45;
    public const int Q = 44;
    public const int P = 43;
    public const int S = 28;
    public const int R = 24;
    public const int Y = 48;
    public const int X = 47;
    public const int EQ2 = 15;
    public const int SQL_LITERAL = 4;
    public const int Z = 49;
    public const int T_FALSE = 8;
    public const int T_1 = 9;
    public const int T_0 = 10;
    public const int A_STRING = 32;
    public const int ENDLINE = 18;
    public const int T_NOT = 12;

    // delegates
    // delegators



        public LogicalFilterParser(ITokenStream input)
    		: this(input, new RecognizerSharedState()) {
        }

        public LogicalFilterParser(ITokenStream input, RecognizerSharedState state)
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
		get { return LogicalFilterParser.tokenNames; }
    }

    override public string GrammarFileName {
		get { return "LogicalFilter.g"; }
    }


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
    // LogicalFilter.g:14:1: sql_identifier : lit1= SQL_LITERAL ( DOT lit2= SQL_LITERAL )* ;
    public LogicalFilterParser.sql_identifier_return sql_identifier() // throws RecognitionException [1]
    {   
        LogicalFilterParser.sql_identifier_return retval = new LogicalFilterParser.sql_identifier_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken lit1 = null;
        IToken lit2 = null;
        IToken DOT1 = null;

        object lit1_tree=null;
        object lit2_tree=null;
        object DOT1_tree=null;

        try 
    	{
            // LogicalFilter.g:14:15: (lit1= SQL_LITERAL ( DOT lit2= SQL_LITERAL )* )
            // LogicalFilter.g:15:3: lit1= SQL_LITERAL ( DOT lit2= SQL_LITERAL )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	lit1=(IToken)Match(input,SQL_LITERAL,FOLLOW_SQL_LITERAL_in_sql_identifier44); 
            		lit1_tree = (object)adaptor.Create(lit1);
            		adaptor.AddChild(root_0, lit1_tree);

            	 Push(((lit1 != null) ? lit1.Text : null)); 
            	// LogicalFilter.g:16:3: ( DOT lit2= SQL_LITERAL )*
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
            			    // LogicalFilter.g:16:4: DOT lit2= SQL_LITERAL
            			    {
            			    	DOT1=(IToken)Match(input,DOT,FOLLOW_DOT_in_sql_identifier51); 
            			    		DOT1_tree = (object)adaptor.Create(DOT1);
            			    		adaptor.AddChild(root_0, DOT1_tree);

            			    	lit2=(IToken)Match(input,SQL_LITERAL,FOLLOW_SQL_LITERAL_in_sql_identifier55); 
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
    // LogicalFilter.g:19:1: sql_variable : var= SQL_VARIABLE ;
    public LogicalFilterParser.sql_variable_return sql_variable() // throws RecognitionException [1]
    {   
        LogicalFilterParser.sql_variable_return retval = new LogicalFilterParser.sql_variable_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken var = null;

        object var_tree=null;

        try 
    	{
            // LogicalFilter.g:19:13: (var= SQL_VARIABLE )
            // LogicalFilter.g:20:5: var= SQL_VARIABLE
            {
            	root_0 = (object)adaptor.GetNilNode();

            	var=(IToken)Match(input,SQL_VARIABLE,FOLLOW_SQL_VARIABLE_in_sql_variable80); 
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
    // LogicalFilter.g:22:1: sql_name : ( sql_identifier | sql_variable );
    public LogicalFilterParser.sql_name_return sql_name() // throws RecognitionException [1]
    {   
        LogicalFilterParser.sql_name_return retval = new LogicalFilterParser.sql_name_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        LogicalFilterParser.sql_identifier_return sql_identifier2 = default(LogicalFilterParser.sql_identifier_return);

        LogicalFilterParser.sql_variable_return sql_variable3 = default(LogicalFilterParser.sql_variable_return);



        try 
    	{
            // LogicalFilter.g:22:10: ( sql_identifier | sql_variable )
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
                    // LogicalFilter.g:22:12: sql_identifier
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_sql_identifier_in_sql_name92);
                    	sql_identifier2 = sql_identifier();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_identifier2.Tree);

                    }
                    break;
                case 2 :
                    // LogicalFilter.g:22:29: sql_variable
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_sql_variable_in_sql_name96);
                    	sql_variable3 = sql_variable();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_variable3.Tree);

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
    // LogicalFilter.g:24:1: element : ( T_TRUE | T_FALSE | T_1 | T_0 | T_NULL | T_NOT T_NULL | NE sql_name | EQ sql_name | EQ2 sql_name | NE2 sql_name );
    public LogicalFilterParser.element_return element() // throws RecognitionException [1]
    {   
        LogicalFilterParser.element_return retval = new LogicalFilterParser.element_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken T_TRUE4 = null;
        IToken T_FALSE5 = null;
        IToken T_16 = null;
        IToken T_07 = null;
        IToken T_NULL8 = null;
        IToken T_NOT9 = null;
        IToken T_NULL10 = null;
        IToken NE11 = null;
        IToken EQ13 = null;
        IToken EQ215 = null;
        IToken NE217 = null;
        LogicalFilterParser.sql_name_return sql_name12 = default(LogicalFilterParser.sql_name_return);

        LogicalFilterParser.sql_name_return sql_name14 = default(LogicalFilterParser.sql_name_return);

        LogicalFilterParser.sql_name_return sql_name16 = default(LogicalFilterParser.sql_name_return);

        LogicalFilterParser.sql_name_return sql_name18 = default(LogicalFilterParser.sql_name_return);


        object T_TRUE4_tree=null;
        object T_FALSE5_tree=null;
        object T_16_tree=null;
        object T_07_tree=null;
        object T_NULL8_tree=null;
        object T_NOT9_tree=null;
        object T_NULL10_tree=null;
        object NE11_tree=null;
        object EQ13_tree=null;
        object EQ215_tree=null;
        object NE217_tree=null;

        try 
    	{
            // LogicalFilter.g:24:8: ( T_TRUE | T_FALSE | T_1 | T_0 | T_NULL | T_NOT T_NULL | NE sql_name | EQ sql_name | EQ2 sql_name | NE2 sql_name )
            int alt3 = 10;
            switch ( input.LA(1) ) 
            {
            case T_TRUE:
            	{
                alt3 = 1;
                }
                break;
            case T_FALSE:
            	{
                alt3 = 2;
                }
                break;
            case T_1:
            	{
                alt3 = 3;
                }
                break;
            case T_0:
            	{
                alt3 = 4;
                }
                break;
            case T_NULL:
            	{
                alt3 = 5;
                }
                break;
            case T_NOT:
            	{
                alt3 = 6;
                }
                break;
            case NE:
            	{
                alt3 = 7;
                }
                break;
            case EQ:
            	{
                alt3 = 8;
                }
                break;
            case EQ2:
            	{
                alt3 = 9;
                }
                break;
            case NE2:
            	{
                alt3 = 10;
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
                    // LogicalFilter.g:25:3: T_TRUE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_TRUE4=(IToken)Match(input,T_TRUE,FOLLOW_T_TRUE_in_element105); 
                    		T_TRUE4_tree = (object)adaptor.Create(T_TRUE4);
                    		adaptor.AddChild(root_0, T_TRUE4_tree);

                    	 AddTrueCondition();  

                    }
                    break;
                case 2 :
                    // LogicalFilter.g:26:5: T_FALSE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_FALSE5=(IToken)Match(input,T_FALSE,FOLLOW_T_FALSE_in_element114); 
                    		T_FALSE5_tree = (object)adaptor.Create(T_FALSE5);
                    		adaptor.AddChild(root_0, T_FALSE5_tree);

                    	 AddFalseCondition();  

                    }
                    break;
                case 3 :
                    // LogicalFilter.g:27:5: T_1
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_16=(IToken)Match(input,T_1,FOLLOW_T_1_in_element123); 
                    		T_16_tree = (object)adaptor.Create(T_16);
                    		adaptor.AddChild(root_0, T_16_tree);

                    	 AddTrueCondition();  

                    }
                    break;
                case 4 :
                    // LogicalFilter.g:28:5: T_0
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_07=(IToken)Match(input,T_0,FOLLOW_T_0_in_element132); 
                    		T_07_tree = (object)adaptor.Create(T_07);
                    		adaptor.AddChild(root_0, T_07_tree);

                    	 AddFalseCondition();  

                    }
                    break;
                case 5 :
                    // LogicalFilter.g:29:5: T_NULL
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NULL8=(IToken)Match(input,T_NULL,FOLLOW_T_NULL_in_element141); 
                    		T_NULL8_tree = (object)adaptor.Create(T_NULL8);
                    		adaptor.AddChild(root_0, T_NULL8_tree);

                    	 AddIsNullCondition(); 

                    }
                    break;
                case 6 :
                    // LogicalFilter.g:30:5: T_NOT T_NULL
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NOT9=(IToken)Match(input,T_NOT,FOLLOW_T_NOT_in_element149); 
                    		T_NOT9_tree = (object)adaptor.Create(T_NOT9);
                    		adaptor.AddChild(root_0, T_NOT9_tree);

                    	T_NULL10=(IToken)Match(input,T_NULL,FOLLOW_T_NULL_in_element151); 
                    		T_NULL10_tree = (object)adaptor.Create(T_NULL10);
                    		adaptor.AddChild(root_0, T_NULL10_tree);

                    	 AddIsNotNullCondition(); 

                    }
                    break;
                case 7 :
                    // LogicalFilter.g:32:5: NE sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NE11=(IToken)Match(input,NE,FOLLOW_NE_in_element162); 
                    		NE11_tree = (object)adaptor.Create(NE11);
                    		adaptor.AddChild(root_0, NE11_tree);

                    	PushFollow(FOLLOW_sql_name_in_element164);
                    	sql_name12 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name12.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), "<>"); 

                    }
                    break;
                case 8 :
                    // LogicalFilter.g:33:5: EQ sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	EQ13=(IToken)Match(input,EQ,FOLLOW_EQ_in_element173); 
                    		EQ13_tree = (object)adaptor.Create(EQ13);
                    		adaptor.AddChild(root_0, EQ13_tree);

                    	PushFollow(FOLLOW_sql_name_in_element175);
                    	sql_name14 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name14.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), "="); 

                    }
                    break;
                case 9 :
                    // LogicalFilter.g:34:5: EQ2 sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	EQ215=(IToken)Match(input,EQ2,FOLLOW_EQ2_in_element183); 
                    		EQ215_tree = (object)adaptor.Create(EQ215);
                    		adaptor.AddChild(root_0, EQ215_tree);

                    	PushFollow(FOLLOW_sql_name_in_element185);
                    	sql_name16 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name16.Tree);
                    	 AddSqlLiteralRelationWithNullTest_EQ(Pop<string>()); 

                    }
                    break;
                case 10 :
                    // LogicalFilter.g:35:5: NE2 sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NE217=(IToken)Match(input,NE2,FOLLOW_NE2_in_element194); 
                    		NE217_tree = (object)adaptor.Create(NE217);
                    		adaptor.AddChild(root_0, NE217_tree);

                    	PushFollow(FOLLOW_sql_name_in_element196);
                    	sql_name18 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name18.Tree);
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
    // LogicalFilter.g:38:1: factor : ( element )+ ;
    public LogicalFilterParser.factor_return factor() // throws RecognitionException [1]
    {   
        LogicalFilterParser.factor_return retval = new LogicalFilterParser.factor_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        LogicalFilterParser.element_return element19 = default(LogicalFilterParser.element_return);



        try 
    	{
            // LogicalFilter.g:38:8: ( ( element )+ )
            // LogicalFilter.g:39:3: ( element )+
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// LogicalFilter.g:39:3: ( element )+
            	int cnt4 = 0;
            	do 
            	{
            	    int alt4 = 2;
            	    int LA4_0 = input.LA(1);

            	    if ( ((LA4_0 >= T_TRUE && LA4_0 <= NE2)) )
            	    {
            	        alt4 = 1;
            	    }


            	    switch (alt4) 
            		{
            			case 1 :
            			    // LogicalFilter.g:39:3: element
            			    {
            			    	PushFollow(FOLLOW_element_in_factor213);
            			    	element19 = element();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, element19.Tree);

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
    // LogicalFilter.g:41:1: list : factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )* ;
    public LogicalFilterParser.list_return list() // throws RecognitionException [1]
    {   
        LogicalFilterParser.list_return retval = new LogicalFilterParser.list_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken COMMA21 = null;
        IToken ENDLINE22 = null;
        IToken ENDLINE24 = null;
        LogicalFilterParser.factor_return factor20 = default(LogicalFilterParser.factor_return);

        LogicalFilterParser.factor_return factor23 = default(LogicalFilterParser.factor_return);


        object COMMA21_tree=null;
        object ENDLINE22_tree=null;
        object ENDLINE24_tree=null;

        try 
    	{
            // LogicalFilter.g:41:5: ( factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )* )
            // LogicalFilter.g:42:3: factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_factor_in_list224);
            	factor20 = factor();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, factor20.Tree);
            	// LogicalFilter.g:42:10: ( ( COMMA | ( ( ENDLINE )+ ) ) factor )*
            	do 
            	{
            	    int alt7 = 2;
            	    alt7 = dfa7.Predict(input);
            	    switch (alt7) 
            		{
            			case 1 :
            			    // LogicalFilter.g:42:12: ( COMMA | ( ( ENDLINE )+ ) ) factor
            			    {
            			    	// LogicalFilter.g:42:12: ( COMMA | ( ( ENDLINE )+ ) )
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
            			    	        // LogicalFilter.g:42:13: COMMA
            			    	        {
            			    	        	COMMA21=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_list229); 
            			    	        		COMMA21_tree = (object)adaptor.Create(COMMA21);
            			    	        		adaptor.AddChild(root_0, COMMA21_tree);


            			    	        }
            			    	        break;
            			    	    case 2 :
            			    	        // LogicalFilter.g:42:21: ( ( ENDLINE )+ )
            			    	        {
            			    	        	// LogicalFilter.g:42:21: ( ( ENDLINE )+ )
            			    	        	// LogicalFilter.g:42:22: ( ENDLINE )+
            			    	        	{
            			    	        		// LogicalFilter.g:42:22: ( ENDLINE )+
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
            			    	        				    // LogicalFilter.g:42:22: ENDLINE
            			    	        				    {
            			    	        				    	ENDLINE22=(IToken)Match(input,ENDLINE,FOLLOW_ENDLINE_in_list234); 
            			    	        				    		ENDLINE22_tree = (object)adaptor.Create(ENDLINE22);
            			    	        				    		adaptor.AddChild(root_0, ENDLINE22_tree);


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
            			    	PushFollow(FOLLOW_factor_in_list241);
            			    	factor23 = factor();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, factor23.Tree);

            			    }
            			    break;

            			default:
            			    goto loop7;
            	    }
            	} while (true);

            	loop7:
            		;	// Stops C# compiler whining that label 'loop7' has no statements

            	// LogicalFilter.g:42:67: ( ENDLINE )*
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
            			    // LogicalFilter.g:42:67: ENDLINE
            			    {
            			    	ENDLINE24=(IToken)Match(input,ENDLINE,FOLLOW_ENDLINE_in_list247); 
            			    		ENDLINE24_tree = (object)adaptor.Create(ENDLINE24);
            			    		adaptor.AddChild(root_0, ENDLINE24_tree);


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
    // LogicalFilter.g:44:1: expr : list ;
    public LogicalFilterParser.expr_return expr() // throws RecognitionException [1]
    {   
        LogicalFilterParser.expr_return retval = new LogicalFilterParser.expr_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        LogicalFilterParser.list_return list25 = default(LogicalFilterParser.list_return);



        try 
    	{
            // LogicalFilter.g:44:5: ( list )
            // LogicalFilter.g:44:7: list
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_list_in_expr257);
            	list25 = list();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, list25.Tree);

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
	private void InitializeCyclicDFAs()
	{
    	this.dfa7 = new DFA7(this);
	}

    const string DFA7_eotS =
        "\x04\uffff";
    const string DFA7_eofS =
        "\x02\x02\x02\uffff";
    const string DFA7_minS =
        "\x01\x11\x01\x07\x02\uffff";
    const string DFA7_maxS =
        "\x02\x12\x02\uffff";
    const string DFA7_acceptS =
        "\x02\uffff\x01\x02\x01\x01";
    const string DFA7_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA7_transitionS = {
            "\x01\x03\x01\x01",
            "\x0a\x03\x01\uffff\x01\x01",
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
            get { return "()* loopback of 42:10: ( ( COMMA | ( ( ENDLINE )+ ) ) factor )*"; }
        }

    }

 

    public static readonly BitSet FOLLOW_SQL_LITERAL_in_sql_identifier44 = new BitSet(new ulong[]{0x0000000000000022UL});
    public static readonly BitSet FOLLOW_DOT_in_sql_identifier51 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_SQL_LITERAL_in_sql_identifier55 = new BitSet(new ulong[]{0x0000000000000022UL});
    public static readonly BitSet FOLLOW_SQL_VARIABLE_in_sql_variable80 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_sql_identifier_in_sql_name92 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_sql_variable_in_sql_name96 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_TRUE_in_element105 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_FALSE_in_element114 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_1_in_element123 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_0_in_element132 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NULL_in_element141 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NOT_in_element149 = new BitSet(new ulong[]{0x0000000000000800UL});
    public static readonly BitSet FOLLOW_T_NULL_in_element151 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NE_in_element162 = new BitSet(new ulong[]{0x0000000000000050UL});
    public static readonly BitSet FOLLOW_sql_name_in_element164 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EQ_in_element173 = new BitSet(new ulong[]{0x0000000000000050UL});
    public static readonly BitSet FOLLOW_sql_name_in_element175 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EQ2_in_element183 = new BitSet(new ulong[]{0x0000000000000050UL});
    public static readonly BitSet FOLLOW_sql_name_in_element185 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NE2_in_element194 = new BitSet(new ulong[]{0x0000000000000050UL});
    public static readonly BitSet FOLLOW_sql_name_in_element196 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_element_in_factor213 = new BitSet(new ulong[]{0x000000000001FF82UL});
    public static readonly BitSet FOLLOW_factor_in_list224 = new BitSet(new ulong[]{0x0000000000060002UL});
    public static readonly BitSet FOLLOW_COMMA_in_list229 = new BitSet(new ulong[]{0x000000000001FF80UL});
    public static readonly BitSet FOLLOW_ENDLINE_in_list234 = new BitSet(new ulong[]{0x000000000005FF80UL});
    public static readonly BitSet FOLLOW_factor_in_list241 = new BitSet(new ulong[]{0x0000000000060002UL});
    public static readonly BitSet FOLLOW_ENDLINE_in_list247 = new BitSet(new ulong[]{0x0000000000040002UL});
    public static readonly BitSet FOLLOW_list_in_expr257 = new BitSet(new ulong[]{0x0000000000000002UL});

}
