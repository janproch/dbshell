// $ANTLR 3.2 Sep 23, 2009 12:02:23 LogicalFilter.g 2014-10-25 22:48:44

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
    public const int Q_STRING = 32;
    public const int DIGIT_0 = 28;
    public const int COMMA = 16;
    public const int DIGIT_1 = 29;
    public const int T_NULL = 10;
    public const int T_TRUE = 6;
    public const int EQ = 13;
    public const int DOT = 5;
    public const int NE = 12;
    public const int D = 35;
    public const int E = 24;
    public const int F = 25;
    public const int G = 36;
    public const int A = 26;
    public const int B = 33;
    public const int NE2 = 15;
    public const int C = 34;
    public const int L = 20;
    public const int M = 41;
    public const int N = 18;
    public const int O = 21;
    public const int H = 37;
    public const int I = 38;
    public const int J = 39;
    public const int K = 40;
    public const int U = 19;
    public const int T = 22;
    public const int W = 45;
    public const int WHITESPACE = 30;
    public const int V = 44;
    public const int Q = 43;
    public const int P = 42;
    public const int S = 27;
    public const int R = 23;
    public const int Y = 47;
    public const int X = 46;
    public const int EQ2 = 14;
    public const int SQL_LITERAL = 4;
    public const int Z = 48;
    public const int T_FALSE = 7;
    public const int T_1 = 8;
    public const int T_0 = 9;
    public const int A_STRING = 31;
    public const int ENDLINE = 17;
    public const int T_NOT = 11;

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
    // LogicalFilter.g:14:1: sql_name : lit1= SQL_LITERAL ( DOT lit2= SQL_LITERAL )* ;
    public LogicalFilterParser.sql_name_return sql_name() // throws RecognitionException [1]
    {   
        LogicalFilterParser.sql_name_return retval = new LogicalFilterParser.sql_name_return();
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
            // LogicalFilter.g:14:9: (lit1= SQL_LITERAL ( DOT lit2= SQL_LITERAL )* )
            // LogicalFilter.g:15:3: lit1= SQL_LITERAL ( DOT lit2= SQL_LITERAL )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	lit1=(IToken)Match(input,SQL_LITERAL,FOLLOW_SQL_LITERAL_in_sql_name44); 
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
            			    	DOT1=(IToken)Match(input,DOT,FOLLOW_DOT_in_sql_name51); 
            			    		DOT1_tree = (object)adaptor.Create(DOT1);
            			    		adaptor.AddChild(root_0, DOT1_tree);

            			    	lit2=(IToken)Match(input,SQL_LITERAL,FOLLOW_SQL_LITERAL_in_sql_name55); 
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
    // LogicalFilter.g:19:1: element : ( T_TRUE | T_FALSE | T_1 | T_0 | T_NULL | T_NOT T_NULL | NE sql_name | EQ sql_name | EQ2 sql_name | NE2 sql_name );
    public LogicalFilterParser.element_return element() // throws RecognitionException [1]
    {   
        LogicalFilterParser.element_return retval = new LogicalFilterParser.element_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken T_TRUE2 = null;
        IToken T_FALSE3 = null;
        IToken T_14 = null;
        IToken T_05 = null;
        IToken T_NULL6 = null;
        IToken T_NOT7 = null;
        IToken T_NULL8 = null;
        IToken NE9 = null;
        IToken EQ11 = null;
        IToken EQ213 = null;
        IToken NE215 = null;
        LogicalFilterParser.sql_name_return sql_name10 = default(LogicalFilterParser.sql_name_return);

        LogicalFilterParser.sql_name_return sql_name12 = default(LogicalFilterParser.sql_name_return);

        LogicalFilterParser.sql_name_return sql_name14 = default(LogicalFilterParser.sql_name_return);

        LogicalFilterParser.sql_name_return sql_name16 = default(LogicalFilterParser.sql_name_return);


        object T_TRUE2_tree=null;
        object T_FALSE3_tree=null;
        object T_14_tree=null;
        object T_05_tree=null;
        object T_NULL6_tree=null;
        object T_NOT7_tree=null;
        object T_NULL8_tree=null;
        object NE9_tree=null;
        object EQ11_tree=null;
        object EQ213_tree=null;
        object NE215_tree=null;

        try 
    	{
            // LogicalFilter.g:19:8: ( T_TRUE | T_FALSE | T_1 | T_0 | T_NULL | T_NOT T_NULL | NE sql_name | EQ sql_name | EQ2 sql_name | NE2 sql_name )
            int alt2 = 10;
            switch ( input.LA(1) ) 
            {
            case T_TRUE:
            	{
                alt2 = 1;
                }
                break;
            case T_FALSE:
            	{
                alt2 = 2;
                }
                break;
            case T_1:
            	{
                alt2 = 3;
                }
                break;
            case T_0:
            	{
                alt2 = 4;
                }
                break;
            case T_NULL:
            	{
                alt2 = 5;
                }
                break;
            case T_NOT:
            	{
                alt2 = 6;
                }
                break;
            case NE:
            	{
                alt2 = 7;
                }
                break;
            case EQ:
            	{
                alt2 = 8;
                }
                break;
            case EQ2:
            	{
                alt2 = 9;
                }
                break;
            case NE2:
            	{
                alt2 = 10;
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
                    // LogicalFilter.g:20:3: T_TRUE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_TRUE2=(IToken)Match(input,T_TRUE,FOLLOW_T_TRUE_in_element74); 
                    		T_TRUE2_tree = (object)adaptor.Create(T_TRUE2);
                    		adaptor.AddChild(root_0, T_TRUE2_tree);

                    	 AddTrueCondition();  

                    }
                    break;
                case 2 :
                    // LogicalFilter.g:21:5: T_FALSE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_FALSE3=(IToken)Match(input,T_FALSE,FOLLOW_T_FALSE_in_element83); 
                    		T_FALSE3_tree = (object)adaptor.Create(T_FALSE3);
                    		adaptor.AddChild(root_0, T_FALSE3_tree);

                    	 AddFalseCondition();  

                    }
                    break;
                case 3 :
                    // LogicalFilter.g:22:5: T_1
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_14=(IToken)Match(input,T_1,FOLLOW_T_1_in_element92); 
                    		T_14_tree = (object)adaptor.Create(T_14);
                    		adaptor.AddChild(root_0, T_14_tree);

                    	 AddTrueCondition();  

                    }
                    break;
                case 4 :
                    // LogicalFilter.g:23:5: T_0
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_05=(IToken)Match(input,T_0,FOLLOW_T_0_in_element101); 
                    		T_05_tree = (object)adaptor.Create(T_05);
                    		adaptor.AddChild(root_0, T_05_tree);

                    	 AddFalseCondition();  

                    }
                    break;
                case 5 :
                    // LogicalFilter.g:24:5: T_NULL
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NULL6=(IToken)Match(input,T_NULL,FOLLOW_T_NULL_in_element110); 
                    		T_NULL6_tree = (object)adaptor.Create(T_NULL6);
                    		adaptor.AddChild(root_0, T_NULL6_tree);

                    	 AddIsNullCondition(); 

                    }
                    break;
                case 6 :
                    // LogicalFilter.g:25:5: T_NOT T_NULL
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NOT7=(IToken)Match(input,T_NOT,FOLLOW_T_NOT_in_element118); 
                    		T_NOT7_tree = (object)adaptor.Create(T_NOT7);
                    		adaptor.AddChild(root_0, T_NOT7_tree);

                    	T_NULL8=(IToken)Match(input,T_NULL,FOLLOW_T_NULL_in_element120); 
                    		T_NULL8_tree = (object)adaptor.Create(T_NULL8);
                    		adaptor.AddChild(root_0, T_NULL8_tree);

                    	 AddIsNotNullCondition(); 

                    }
                    break;
                case 7 :
                    // LogicalFilter.g:27:5: NE sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NE9=(IToken)Match(input,NE,FOLLOW_NE_in_element131); 
                    		NE9_tree = (object)adaptor.Create(NE9);
                    		adaptor.AddChild(root_0, NE9_tree);

                    	PushFollow(FOLLOW_sql_name_in_element133);
                    	sql_name10 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name10.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), "<>"); 

                    }
                    break;
                case 8 :
                    // LogicalFilter.g:28:5: EQ sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	EQ11=(IToken)Match(input,EQ,FOLLOW_EQ_in_element142); 
                    		EQ11_tree = (object)adaptor.Create(EQ11);
                    		adaptor.AddChild(root_0, EQ11_tree);

                    	PushFollow(FOLLOW_sql_name_in_element144);
                    	sql_name12 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name12.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), "="); 

                    }
                    break;
                case 9 :
                    // LogicalFilter.g:29:5: EQ2 sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	EQ213=(IToken)Match(input,EQ2,FOLLOW_EQ2_in_element152); 
                    		EQ213_tree = (object)adaptor.Create(EQ213);
                    		adaptor.AddChild(root_0, EQ213_tree);

                    	PushFollow(FOLLOW_sql_name_in_element154);
                    	sql_name14 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name14.Tree);
                    	 AddSqlLiteralRelationWithNullTest_EQ(Pop<string>()); 

                    }
                    break;
                case 10 :
                    // LogicalFilter.g:30:5: NE2 sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NE215=(IToken)Match(input,NE2,FOLLOW_NE2_in_element163); 
                    		NE215_tree = (object)adaptor.Create(NE215);
                    		adaptor.AddChild(root_0, NE215_tree);

                    	PushFollow(FOLLOW_sql_name_in_element165);
                    	sql_name16 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name16.Tree);
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
    // LogicalFilter.g:33:1: factor : ( element )+ ;
    public LogicalFilterParser.factor_return factor() // throws RecognitionException [1]
    {   
        LogicalFilterParser.factor_return retval = new LogicalFilterParser.factor_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        LogicalFilterParser.element_return element17 = default(LogicalFilterParser.element_return);



        try 
    	{
            // LogicalFilter.g:33:8: ( ( element )+ )
            // LogicalFilter.g:34:3: ( element )+
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// LogicalFilter.g:34:3: ( element )+
            	int cnt3 = 0;
            	do 
            	{
            	    int alt3 = 2;
            	    int LA3_0 = input.LA(1);

            	    if ( ((LA3_0 >= T_TRUE && LA3_0 <= NE2)) )
            	    {
            	        alt3 = 1;
            	    }


            	    switch (alt3) 
            		{
            			case 1 :
            			    // LogicalFilter.g:34:3: element
            			    {
            			    	PushFollow(FOLLOW_element_in_factor182);
            			    	element17 = element();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, element17.Tree);

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
    // LogicalFilter.g:36:1: list : factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )* ;
    public LogicalFilterParser.list_return list() // throws RecognitionException [1]
    {   
        LogicalFilterParser.list_return retval = new LogicalFilterParser.list_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken COMMA19 = null;
        IToken ENDLINE20 = null;
        IToken ENDLINE22 = null;
        LogicalFilterParser.factor_return factor18 = default(LogicalFilterParser.factor_return);

        LogicalFilterParser.factor_return factor21 = default(LogicalFilterParser.factor_return);


        object COMMA19_tree=null;
        object ENDLINE20_tree=null;
        object ENDLINE22_tree=null;

        try 
    	{
            // LogicalFilter.g:36:5: ( factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )* )
            // LogicalFilter.g:37:3: factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_factor_in_list193);
            	factor18 = factor();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, factor18.Tree);
            	// LogicalFilter.g:37:10: ( ( COMMA | ( ( ENDLINE )+ ) ) factor )*
            	do 
            	{
            	    int alt6 = 2;
            	    alt6 = dfa6.Predict(input);
            	    switch (alt6) 
            		{
            			case 1 :
            			    // LogicalFilter.g:37:12: ( COMMA | ( ( ENDLINE )+ ) ) factor
            			    {
            			    	// LogicalFilter.g:37:12: ( COMMA | ( ( ENDLINE )+ ) )
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
            			    	        // LogicalFilter.g:37:13: COMMA
            			    	        {
            			    	        	COMMA19=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_list198); 
            			    	        		COMMA19_tree = (object)adaptor.Create(COMMA19);
            			    	        		adaptor.AddChild(root_0, COMMA19_tree);


            			    	        }
            			    	        break;
            			    	    case 2 :
            			    	        // LogicalFilter.g:37:21: ( ( ENDLINE )+ )
            			    	        {
            			    	        	// LogicalFilter.g:37:21: ( ( ENDLINE )+ )
            			    	        	// LogicalFilter.g:37:22: ( ENDLINE )+
            			    	        	{
            			    	        		// LogicalFilter.g:37:22: ( ENDLINE )+
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
            			    	        				    // LogicalFilter.g:37:22: ENDLINE
            			    	        				    {
            			    	        				    	ENDLINE20=(IToken)Match(input,ENDLINE,FOLLOW_ENDLINE_in_list203); 
            			    	        				    		ENDLINE20_tree = (object)adaptor.Create(ENDLINE20);
            			    	        				    		adaptor.AddChild(root_0, ENDLINE20_tree);


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
            			    	PushFollow(FOLLOW_factor_in_list210);
            			    	factor21 = factor();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, factor21.Tree);

            			    }
            			    break;

            			default:
            			    goto loop6;
            	    }
            	} while (true);

            	loop6:
            		;	// Stops C# compiler whining that label 'loop6' has no statements

            	// LogicalFilter.g:37:67: ( ENDLINE )*
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
            			    // LogicalFilter.g:37:67: ENDLINE
            			    {
            			    	ENDLINE22=(IToken)Match(input,ENDLINE,FOLLOW_ENDLINE_in_list216); 
            			    		ENDLINE22_tree = (object)adaptor.Create(ENDLINE22);
            			    		adaptor.AddChild(root_0, ENDLINE22_tree);


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
    // LogicalFilter.g:39:1: expr : list ;
    public LogicalFilterParser.expr_return expr() // throws RecognitionException [1]
    {   
        LogicalFilterParser.expr_return retval = new LogicalFilterParser.expr_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        LogicalFilterParser.list_return list23 = default(LogicalFilterParser.list_return);



        try 
    	{
            // LogicalFilter.g:39:5: ( list )
            // LogicalFilter.g:39:7: list
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_list_in_expr226);
            	list23 = list();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, list23.Tree);

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
	private void InitializeCyclicDFAs()
	{
    	this.dfa6 = new DFA6(this);
	}

    const string DFA6_eotS =
        "\x04\uffff";
    const string DFA6_eofS =
        "\x02\x02\x02\uffff";
    const string DFA6_minS =
        "\x01\x10\x01\x06\x02\uffff";
    const string DFA6_maxS =
        "\x02\x11\x02\uffff";
    const string DFA6_acceptS =
        "\x02\uffff\x01\x02\x01\x01";
    const string DFA6_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA6_transitionS = {
            "\x01\x03\x01\x01",
            "\x0a\x03\x01\uffff\x01\x01",
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
            get { return "()* loopback of 37:10: ( ( COMMA | ( ( ENDLINE )+ ) ) factor )*"; }
        }

    }

 

    public static readonly BitSet FOLLOW_SQL_LITERAL_in_sql_name44 = new BitSet(new ulong[]{0x0000000000000022UL});
    public static readonly BitSet FOLLOW_DOT_in_sql_name51 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_SQL_LITERAL_in_sql_name55 = new BitSet(new ulong[]{0x0000000000000022UL});
    public static readonly BitSet FOLLOW_T_TRUE_in_element74 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_FALSE_in_element83 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_1_in_element92 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_0_in_element101 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NULL_in_element110 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NOT_in_element118 = new BitSet(new ulong[]{0x0000000000000400UL});
    public static readonly BitSet FOLLOW_T_NULL_in_element120 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NE_in_element131 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_sql_name_in_element133 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EQ_in_element142 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_sql_name_in_element144 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EQ2_in_element152 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_sql_name_in_element154 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NE2_in_element163 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_sql_name_in_element165 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_element_in_factor182 = new BitSet(new ulong[]{0x000000000000FFC2UL});
    public static readonly BitSet FOLLOW_factor_in_list193 = new BitSet(new ulong[]{0x0000000000030002UL});
    public static readonly BitSet FOLLOW_COMMA_in_list198 = new BitSet(new ulong[]{0x000000000000FFC0UL});
    public static readonly BitSet FOLLOW_ENDLINE_in_list203 = new BitSet(new ulong[]{0x000000000002FFC0UL});
    public static readonly BitSet FOLLOW_factor_in_list210 = new BitSet(new ulong[]{0x0000000000030002UL});
    public static readonly BitSet FOLLOW_ENDLINE_in_list216 = new BitSet(new ulong[]{0x0000000000020002UL});
    public static readonly BitSet FOLLOW_list_in_expr226 = new BitSet(new ulong[]{0x0000000000000002UL});

}
