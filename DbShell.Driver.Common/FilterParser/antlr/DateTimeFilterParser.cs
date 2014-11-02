// $ANTLR 3.2 Sep 23, 2009 12:02:23 DateTimeFilter.g 2014-11-02 21:57:16

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

public partial class DateTimeFilterParser : DbShellFilterAntlrParser
{
    public static readonly string[] tokenNames = new string[] 
	{
        "<invalid>", 
		"<EOR>", 
		"<DOWN>", 
		"<UP>", 
		"SQL_LITERAL", 
		"DOT", 
		"YEAR", 
		"DATE", 
		"HOUR_ANY_MINUTE", 
		"FLOW_MONTH", 
		"FLOW_DAY", 
		"YEAR_MONTH", 
		"T_JAN", 
		"T_FEB", 
		"T_MAR", 
		"T_APR", 
		"T_MAY", 
		"T_JUN", 
		"T_JUL", 
		"T_AUG", 
		"T_SEP", 
		"T_OCT", 
		"T_NOV", 
		"T_DEC", 
		"T_MON", 
		"T_TUE", 
		"T_WED", 
		"T_THU", 
		"T_FRI", 
		"T_SAT", 
		"T_SUN", 
		"T_LAST", 
		"T_HOUR", 
		"T_THIS", 
		"T_NEXT", 
		"T_YESTERDAY", 
		"T_TODAY", 
		"T_TOMORROW", 
		"T_WEEK", 
		"T_MONTH", 
		"T_YEAR", 
		"EQ", 
		"LT", 
		"LE", 
		"GT", 
		"GE", 
		"NE", 
		"T_NULL", 
		"T_NOT", 
		"EQ2", 
		"NE2", 
		"MINUS", 
		"TIME_SECOND_FRACTION", 
		"TIME_MINUE", 
		"TIME_SECOND", 
		"COMMA", 
		"ENDLINE", 
		"DIGIT", 
		"L", 
		"A", 
		"S", 
		"T", 
		"H", 
		"I", 
		"N", 
		"E", 
		"X", 
		"O", 
		"U", 
		"R", 
		"W", 
		"K", 
		"M", 
		"Y", 
		"D", 
		"J", 
		"F", 
		"B", 
		"P", 
		"G", 
		"C", 
		"V", 
		"WHITESPACE", 
		"Q", 
		"Z"
    };

    public const int LT = 42;
    public const int FLOW_MONTH = 9;
    public const int T_AUG = 19;
    public const int HOUR_ANY_MINUTE = 8;
    public const int YEAR = 6;
    public const int T_OCT = 21;
    public const int T_NEXT = 34;
    public const int EOF = -1;
    public const int T_SEP = 20;
    public const int T_SAT = 29;
    public const int YEAR_MONTH = 11;
    public const int TIME_SECOND = 54;
    public const int COMMA = 55;
    public const int T_NULL = 47;
    public const int T_SUN = 30;
    public const int T_WED = 26;
    public const int TIME_MINUE = 53;
    public const int T_FRI = 28;
    public const int FLOW_DAY = 10;
    public const int DIGIT = 57;
    public const int EQ = 41;
    public const int DOT = 5;
    public const int T_YESTERDAY = 35;
    public const int NE = 46;
    public const int T_WEEK = 38;
    public const int D = 74;
    public const int E = 65;
    public const int F = 76;
    public const int GE = 45;
    public const int T_APR = 15;
    public const int G = 79;
    public const int A = 59;
    public const int TIME_SECOND_FRACTION = 52;
    public const int B = 77;
    public const int T_THIS = 33;
    public const int C = 80;
    public const int NE2 = 50;
    public const int T_TUE = 25;
    public const int T_TOMORROW = 37;
    public const int L = 58;
    public const int M = 72;
    public const int N = 64;
    public const int O = 67;
    public const int H = 62;
    public const int I = 63;
    public const int J = 75;
    public const int K = 71;
    public const int T_LAST = 31;
    public const int U = 68;
    public const int T = 61;
    public const int WHITESPACE = 82;
    public const int W = 70;
    public const int V = 81;
    public const int T_YEAR = 40;
    public const int Q = 83;
    public const int P = 78;
    public const int S = 60;
    public const int T_MONTH = 39;
    public const int R = 69;
    public const int MINUS = 51;
    public const int Y = 73;
    public const int X = 66;
    public const int EQ2 = 49;
    public const int SQL_LITERAL = 4;
    public const int T_DEC = 23;
    public const int Z = 84;
    public const int T_THU = 27;
    public const int T_HOUR = 32;
    public const int T_JAN = 12;
    public const int T_JUN = 17;
    public const int GT = 44;
    public const int ENDLINE = 56;
    public const int T_MON = 24;
    public const int T_TODAY = 36;
    public const int T_MAY = 16;
    public const int T_NOT = 48;
    public const int DATE = 7;
    public const int T_NOV = 22;
    public const int T_FEB = 13;
    public const int LE = 43;
    public const int T_MAR = 14;
    public const int T_JUL = 18;

    // delegates
    // delegators



        public DateTimeFilterParser(ITokenStream input)
    		: this(input, new RecognizerSharedState()) {
        }

        public DateTimeFilterParser(ITokenStream input, RecognizerSharedState state)
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
		get { return DateTimeFilterParser.tokenNames; }
    }

    override public string GrammarFileName {
		get { return "DateTimeFilter.g"; }
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
    // DateTimeFilter.g:14:1: sql_name : lit1= SQL_LITERAL ( DOT lit2= SQL_LITERAL )* ;
    public DateTimeFilterParser.sql_name_return sql_name() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.sql_name_return retval = new DateTimeFilterParser.sql_name_return();
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
            // DateTimeFilter.g:14:9: (lit1= SQL_LITERAL ( DOT lit2= SQL_LITERAL )* )
            // DateTimeFilter.g:15:3: lit1= SQL_LITERAL ( DOT lit2= SQL_LITERAL )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	lit1=(IToken)Match(input,SQL_LITERAL,FOLLOW_SQL_LITERAL_in_sql_name44); 
            		lit1_tree = (object)adaptor.Create(lit1);
            		adaptor.AddChild(root_0, lit1_tree);

            	 Push(((lit1 != null) ? lit1.Text : null)); 
            	// DateTimeFilter.g:16:3: ( DOT lit2= SQL_LITERAL )*
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
            			    // DateTimeFilter.g:16:4: DOT lit2= SQL_LITERAL
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

    public class specification_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "specification"
    // DateTimeFilter.g:19:1: specification : (y= YEAR | d= DATE | d= HOUR_ANY_MINUTE | d= FLOW_MONTH | d= FLOW_DAY | d= YEAR_MONTH | T_JAN | T_FEB | T_MAR | T_APR | T_MAY | T_JUN | T_JUL | T_AUG | T_SEP | T_OCT | T_NOV | T_DEC | T_MON | T_TUE | T_WED | T_THU | T_FRI | T_SAT | T_SUN | T_LAST T_HOUR | T_THIS T_HOUR | T_NEXT T_HOUR | T_YESTERDAY | T_TODAY | T_TOMORROW | T_LAST T_WEEK | T_THIS T_WEEK | T_NEXT T_WEEK | T_LAST T_MONTH | T_THIS T_MONTH | T_NEXT T_MONTH | T_LAST T_YEAR | T_THIS T_YEAR | T_NEXT T_YEAR | EQ d= DATE | LT d= DATE | LE d= DATE | GT d= DATE | GE d= DATE | NE d= DATE | d= DATE time_noexact | EQ d= DATE time_noexact | d= DATE time_exact | EQ d= DATE time_exact | LT d= DATE t= time | LE d= DATE t= time | GT d= DATE t= time | GE d= DATE t= time | T_NULL | T_NOT T_NULL | LT sql_name | GT sql_name | LE sql_name | GE sql_name | NE sql_name | EQ sql_name | EQ2 sql_name | NE2 sql_name );
    public DateTimeFilterParser.specification_return specification() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.specification_return retval = new DateTimeFilterParser.specification_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken y = null;
        IToken d = null;
        IToken T_JAN2 = null;
        IToken T_FEB3 = null;
        IToken T_MAR4 = null;
        IToken T_APR5 = null;
        IToken T_MAY6 = null;
        IToken T_JUN7 = null;
        IToken T_JUL8 = null;
        IToken T_AUG9 = null;
        IToken T_SEP10 = null;
        IToken T_OCT11 = null;
        IToken T_NOV12 = null;
        IToken T_DEC13 = null;
        IToken T_MON14 = null;
        IToken T_TUE15 = null;
        IToken T_WED16 = null;
        IToken T_THU17 = null;
        IToken T_FRI18 = null;
        IToken T_SAT19 = null;
        IToken T_SUN20 = null;
        IToken T_LAST21 = null;
        IToken T_HOUR22 = null;
        IToken T_THIS23 = null;
        IToken T_HOUR24 = null;
        IToken T_NEXT25 = null;
        IToken T_HOUR26 = null;
        IToken T_YESTERDAY27 = null;
        IToken T_TODAY28 = null;
        IToken T_TOMORROW29 = null;
        IToken T_LAST30 = null;
        IToken T_WEEK31 = null;
        IToken T_THIS32 = null;
        IToken T_WEEK33 = null;
        IToken T_NEXT34 = null;
        IToken T_WEEK35 = null;
        IToken T_LAST36 = null;
        IToken T_MONTH37 = null;
        IToken T_THIS38 = null;
        IToken T_MONTH39 = null;
        IToken T_NEXT40 = null;
        IToken T_MONTH41 = null;
        IToken T_LAST42 = null;
        IToken T_YEAR43 = null;
        IToken T_THIS44 = null;
        IToken T_YEAR45 = null;
        IToken T_NEXT46 = null;
        IToken T_YEAR47 = null;
        IToken EQ48 = null;
        IToken LT49 = null;
        IToken LE50 = null;
        IToken GT51 = null;
        IToken GE52 = null;
        IToken NE53 = null;
        IToken EQ55 = null;
        IToken EQ58 = null;
        IToken LT60 = null;
        IToken LE61 = null;
        IToken GT62 = null;
        IToken GE63 = null;
        IToken T_NULL64 = null;
        IToken T_NOT65 = null;
        IToken T_NULL66 = null;
        IToken LT67 = null;
        IToken GT69 = null;
        IToken LE71 = null;
        IToken GE73 = null;
        IToken NE75 = null;
        IToken EQ77 = null;
        IToken EQ279 = null;
        IToken NE281 = null;
        DateTimeFilterParser.time_return t = default(DateTimeFilterParser.time_return);

        DateTimeFilterParser.time_noexact_return time_noexact54 = default(DateTimeFilterParser.time_noexact_return);

        DateTimeFilterParser.time_noexact_return time_noexact56 = default(DateTimeFilterParser.time_noexact_return);

        DateTimeFilterParser.time_exact_return time_exact57 = default(DateTimeFilterParser.time_exact_return);

        DateTimeFilterParser.time_exact_return time_exact59 = default(DateTimeFilterParser.time_exact_return);

        DateTimeFilterParser.sql_name_return sql_name68 = default(DateTimeFilterParser.sql_name_return);

        DateTimeFilterParser.sql_name_return sql_name70 = default(DateTimeFilterParser.sql_name_return);

        DateTimeFilterParser.sql_name_return sql_name72 = default(DateTimeFilterParser.sql_name_return);

        DateTimeFilterParser.sql_name_return sql_name74 = default(DateTimeFilterParser.sql_name_return);

        DateTimeFilterParser.sql_name_return sql_name76 = default(DateTimeFilterParser.sql_name_return);

        DateTimeFilterParser.sql_name_return sql_name78 = default(DateTimeFilterParser.sql_name_return);

        DateTimeFilterParser.sql_name_return sql_name80 = default(DateTimeFilterParser.sql_name_return);

        DateTimeFilterParser.sql_name_return sql_name82 = default(DateTimeFilterParser.sql_name_return);


        object y_tree=null;
        object d_tree=null;
        object T_JAN2_tree=null;
        object T_FEB3_tree=null;
        object T_MAR4_tree=null;
        object T_APR5_tree=null;
        object T_MAY6_tree=null;
        object T_JUN7_tree=null;
        object T_JUL8_tree=null;
        object T_AUG9_tree=null;
        object T_SEP10_tree=null;
        object T_OCT11_tree=null;
        object T_NOV12_tree=null;
        object T_DEC13_tree=null;
        object T_MON14_tree=null;
        object T_TUE15_tree=null;
        object T_WED16_tree=null;
        object T_THU17_tree=null;
        object T_FRI18_tree=null;
        object T_SAT19_tree=null;
        object T_SUN20_tree=null;
        object T_LAST21_tree=null;
        object T_HOUR22_tree=null;
        object T_THIS23_tree=null;
        object T_HOUR24_tree=null;
        object T_NEXT25_tree=null;
        object T_HOUR26_tree=null;
        object T_YESTERDAY27_tree=null;
        object T_TODAY28_tree=null;
        object T_TOMORROW29_tree=null;
        object T_LAST30_tree=null;
        object T_WEEK31_tree=null;
        object T_THIS32_tree=null;
        object T_WEEK33_tree=null;
        object T_NEXT34_tree=null;
        object T_WEEK35_tree=null;
        object T_LAST36_tree=null;
        object T_MONTH37_tree=null;
        object T_THIS38_tree=null;
        object T_MONTH39_tree=null;
        object T_NEXT40_tree=null;
        object T_MONTH41_tree=null;
        object T_LAST42_tree=null;
        object T_YEAR43_tree=null;
        object T_THIS44_tree=null;
        object T_YEAR45_tree=null;
        object T_NEXT46_tree=null;
        object T_YEAR47_tree=null;
        object EQ48_tree=null;
        object LT49_tree=null;
        object LE50_tree=null;
        object GT51_tree=null;
        object GE52_tree=null;
        object NE53_tree=null;
        object EQ55_tree=null;
        object EQ58_tree=null;
        object LT60_tree=null;
        object LE61_tree=null;
        object GT62_tree=null;
        object GE63_tree=null;
        object T_NULL64_tree=null;
        object T_NOT65_tree=null;
        object T_NULL66_tree=null;
        object LT67_tree=null;
        object GT69_tree=null;
        object LE71_tree=null;
        object GE73_tree=null;
        object NE75_tree=null;
        object EQ77_tree=null;
        object EQ279_tree=null;
        object NE281_tree=null;

        try 
    	{
            // DateTimeFilter.g:19:14: (y= YEAR | d= DATE | d= HOUR_ANY_MINUTE | d= FLOW_MONTH | d= FLOW_DAY | d= YEAR_MONTH | T_JAN | T_FEB | T_MAR | T_APR | T_MAY | T_JUN | T_JUL | T_AUG | T_SEP | T_OCT | T_NOV | T_DEC | T_MON | T_TUE | T_WED | T_THU | T_FRI | T_SAT | T_SUN | T_LAST T_HOUR | T_THIS T_HOUR | T_NEXT T_HOUR | T_YESTERDAY | T_TODAY | T_TOMORROW | T_LAST T_WEEK | T_THIS T_WEEK | T_NEXT T_WEEK | T_LAST T_MONTH | T_THIS T_MONTH | T_NEXT T_MONTH | T_LAST T_YEAR | T_THIS T_YEAR | T_NEXT T_YEAR | EQ d= DATE | LT d= DATE | LE d= DATE | GT d= DATE | GE d= DATE | NE d= DATE | d= DATE time_noexact | EQ d= DATE time_noexact | d= DATE time_exact | EQ d= DATE time_exact | LT d= DATE t= time | LE d= DATE t= time | GT d= DATE t= time | GE d= DATE t= time | T_NULL | T_NOT T_NULL | LT sql_name | GT sql_name | LE sql_name | GE sql_name | NE sql_name | EQ sql_name | EQ2 sql_name | NE2 sql_name )
            int alt2 = 64;
            alt2 = dfa2.Predict(input);
            switch (alt2) 
            {
                case 1 :
                    // DateTimeFilter.g:20:3: y= YEAR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	y=(IToken)Match(input,YEAR,FOLLOW_YEAR_in_specification76); 
                    		y_tree = (object)adaptor.Create(y);
                    		adaptor.AddChild(root_0, y_tree);

                    	 var d1=new DateTime(Int32.Parse(((y != null) ? y.Text : null)), 1, 1); AddDateTimeIntervalCondition(d1, d1.AddYears(1)); 

                    }
                    break;
                case 2 :
                    // DateTimeFilter.g:21:5: d= DATE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification86); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 AddDateCondition(((d != null) ? d.Text : null)); 

                    }
                    break;
                case 3 :
                    // DateTimeFilter.g:23:5: d= HOUR_ANY_MINUTE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	d=(IToken)Match(input,HOUR_ANY_MINUTE,FOLLOW_HOUR_ANY_MINUTE_in_specification99); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 AddAnyMinuteCondition(((d != null) ? d.Text : null)); 

                    }
                    break;
                case 4 :
                    // DateTimeFilter.g:24:5: d= FLOW_MONTH
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	d=(IToken)Match(input,FLOW_MONTH,FOLLOW_FLOW_MONTH_in_specification110); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 AddFlowMonthCondition(((d != null) ? d.Text : null)); 

                    }
                    break;
                case 5 :
                    // DateTimeFilter.g:25:5: d= FLOW_DAY
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	d=(IToken)Match(input,FLOW_DAY,FOLLOW_FLOW_DAY_in_specification120); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 AddFlowDayCondition(((d != null) ? d.Text : null)); 

                    }
                    break;
                case 6 :
                    // DateTimeFilter.g:26:5: d= YEAR_MONTH
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	d=(IToken)Match(input,YEAR_MONTH,FOLLOW_YEAR_MONTH_in_specification130); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 AddYearMonthCondition(((d != null) ? d.Text : null)); 

                    }
                    break;
                case 7 :
                    // DateTimeFilter.g:28:5: T_JAN
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_JAN2=(IToken)Match(input,T_JAN,FOLLOW_T_JAN_in_specification141); 
                    		T_JAN2_tree = (object)adaptor.Create(T_JAN2);
                    		adaptor.AddChild(root_0, T_JAN2_tree);

                    	 AddMonthCondition(1); 

                    }
                    break;
                case 8 :
                    // DateTimeFilter.g:29:5: T_FEB
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_FEB3=(IToken)Match(input,T_FEB,FOLLOW_T_FEB_in_specification149); 
                    		T_FEB3_tree = (object)adaptor.Create(T_FEB3);
                    		adaptor.AddChild(root_0, T_FEB3_tree);

                    	 AddMonthCondition(2); 

                    }
                    break;
                case 9 :
                    // DateTimeFilter.g:30:5: T_MAR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_MAR4=(IToken)Match(input,T_MAR,FOLLOW_T_MAR_in_specification157); 
                    		T_MAR4_tree = (object)adaptor.Create(T_MAR4);
                    		adaptor.AddChild(root_0, T_MAR4_tree);

                    	 AddMonthCondition(3); 

                    }
                    break;
                case 10 :
                    // DateTimeFilter.g:31:5: T_APR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_APR5=(IToken)Match(input,T_APR,FOLLOW_T_APR_in_specification165); 
                    		T_APR5_tree = (object)adaptor.Create(T_APR5);
                    		adaptor.AddChild(root_0, T_APR5_tree);

                    	 AddMonthCondition(4); 

                    }
                    break;
                case 11 :
                    // DateTimeFilter.g:32:5: T_MAY
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_MAY6=(IToken)Match(input,T_MAY,FOLLOW_T_MAY_in_specification173); 
                    		T_MAY6_tree = (object)adaptor.Create(T_MAY6);
                    		adaptor.AddChild(root_0, T_MAY6_tree);

                    	 AddMonthCondition(5); 

                    }
                    break;
                case 12 :
                    // DateTimeFilter.g:33:5: T_JUN
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_JUN7=(IToken)Match(input,T_JUN,FOLLOW_T_JUN_in_specification181); 
                    		T_JUN7_tree = (object)adaptor.Create(T_JUN7);
                    		adaptor.AddChild(root_0, T_JUN7_tree);

                    	 AddMonthCondition(6); 

                    }
                    break;
                case 13 :
                    // DateTimeFilter.g:34:5: T_JUL
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_JUL8=(IToken)Match(input,T_JUL,FOLLOW_T_JUL_in_specification189); 
                    		T_JUL8_tree = (object)adaptor.Create(T_JUL8);
                    		adaptor.AddChild(root_0, T_JUL8_tree);

                    	 AddMonthCondition(7); 

                    }
                    break;
                case 14 :
                    // DateTimeFilter.g:35:5: T_AUG
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_AUG9=(IToken)Match(input,T_AUG,FOLLOW_T_AUG_in_specification197); 
                    		T_AUG9_tree = (object)adaptor.Create(T_AUG9);
                    		adaptor.AddChild(root_0, T_AUG9_tree);

                    	 AddMonthCondition(8); 

                    }
                    break;
                case 15 :
                    // DateTimeFilter.g:36:5: T_SEP
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_SEP10=(IToken)Match(input,T_SEP,FOLLOW_T_SEP_in_specification205); 
                    		T_SEP10_tree = (object)adaptor.Create(T_SEP10);
                    		adaptor.AddChild(root_0, T_SEP10_tree);

                    	 AddMonthCondition(9); 

                    }
                    break;
                case 16 :
                    // DateTimeFilter.g:37:5: T_OCT
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_OCT11=(IToken)Match(input,T_OCT,FOLLOW_T_OCT_in_specification213); 
                    		T_OCT11_tree = (object)adaptor.Create(T_OCT11);
                    		adaptor.AddChild(root_0, T_OCT11_tree);

                    	 AddMonthCondition(10); 

                    }
                    break;
                case 17 :
                    // DateTimeFilter.g:38:5: T_NOV
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NOV12=(IToken)Match(input,T_NOV,FOLLOW_T_NOV_in_specification221); 
                    		T_NOV12_tree = (object)adaptor.Create(T_NOV12);
                    		adaptor.AddChild(root_0, T_NOV12_tree);

                    	 AddMonthCondition(11); 

                    }
                    break;
                case 18 :
                    // DateTimeFilter.g:39:5: T_DEC
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_DEC13=(IToken)Match(input,T_DEC,FOLLOW_T_DEC_in_specification229); 
                    		T_DEC13_tree = (object)adaptor.Create(T_DEC13);
                    		adaptor.AddChild(root_0, T_DEC13_tree);

                    	 AddMonthCondition(12); 

                    }
                    break;
                case 19 :
                    // DateTimeFilter.g:41:5: T_MON
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_MON14=(IToken)Match(input,T_MON,FOLLOW_T_MON_in_specification240); 
                    		T_MON14_tree = (object)adaptor.Create(T_MON14);
                    		adaptor.AddChild(root_0, T_MON14_tree);

                    	 AddDayOfWeekCondition(DayOfWeek.Monday); 

                    }
                    break;
                case 20 :
                    // DateTimeFilter.g:42:5: T_TUE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_TUE15=(IToken)Match(input,T_TUE,FOLLOW_T_TUE_in_specification248); 
                    		T_TUE15_tree = (object)adaptor.Create(T_TUE15);
                    		adaptor.AddChild(root_0, T_TUE15_tree);

                    	 AddDayOfWeekCondition(DayOfWeek.Tuesday); 

                    }
                    break;
                case 21 :
                    // DateTimeFilter.g:43:5: T_WED
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_WED16=(IToken)Match(input,T_WED,FOLLOW_T_WED_in_specification256); 
                    		T_WED16_tree = (object)adaptor.Create(T_WED16);
                    		adaptor.AddChild(root_0, T_WED16_tree);

                    	 AddDayOfWeekCondition(DayOfWeek.Wednesday); 

                    }
                    break;
                case 22 :
                    // DateTimeFilter.g:44:5: T_THU
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_THU17=(IToken)Match(input,T_THU,FOLLOW_T_THU_in_specification264); 
                    		T_THU17_tree = (object)adaptor.Create(T_THU17);
                    		adaptor.AddChild(root_0, T_THU17_tree);

                    	 AddDayOfWeekCondition(DayOfWeek.Thursday); 

                    }
                    break;
                case 23 :
                    // DateTimeFilter.g:45:5: T_FRI
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_FRI18=(IToken)Match(input,T_FRI,FOLLOW_T_FRI_in_specification272); 
                    		T_FRI18_tree = (object)adaptor.Create(T_FRI18);
                    		adaptor.AddChild(root_0, T_FRI18_tree);

                    	 AddDayOfWeekCondition(DayOfWeek.Friday); 

                    }
                    break;
                case 24 :
                    // DateTimeFilter.g:46:5: T_SAT
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_SAT19=(IToken)Match(input,T_SAT,FOLLOW_T_SAT_in_specification280); 
                    		T_SAT19_tree = (object)adaptor.Create(T_SAT19);
                    		adaptor.AddChild(root_0, T_SAT19_tree);

                    	 AddDayOfWeekCondition(DayOfWeek.Saturday); 

                    }
                    break;
                case 25 :
                    // DateTimeFilter.g:47:5: T_SUN
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_SUN20=(IToken)Match(input,T_SUN,FOLLOW_T_SUN_in_specification288); 
                    		T_SUN20_tree = (object)adaptor.Create(T_SUN20);
                    		adaptor.AddChild(root_0, T_SUN20_tree);

                    	 AddDayOfWeekCondition(DayOfWeek.Sunday); 

                    }
                    break;
                case 26 :
                    // DateTimeFilter.g:49:5: T_LAST T_HOUR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_LAST21=(IToken)Match(input,T_LAST,FOLLOW_T_LAST_in_specification299); 
                    		T_LAST21_tree = (object)adaptor.Create(T_LAST21);
                    		adaptor.AddChild(root_0, T_LAST21_tree);

                    	T_HOUR22=(IToken)Match(input,T_HOUR,FOLLOW_T_HOUR_in_specification301); 
                    		T_HOUR22_tree = (object)adaptor.Create(T_HOUR22);
                    		adaptor.AddChild(root_0, T_HOUR22_tree);

                    	 var h1 = new DateTime(Now.Year, Now.Month, Now.Day, Now.Hour, 0, 0); AddDateTimeIntervalCondition(h1 - TimeSpan.FromHours(1), h1); 

                    }
                    break;
                case 27 :
                    // DateTimeFilter.g:50:5: T_THIS T_HOUR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_THIS23=(IToken)Match(input,T_THIS,FOLLOW_T_THIS_in_specification309); 
                    		T_THIS23_tree = (object)adaptor.Create(T_THIS23);
                    		adaptor.AddChild(root_0, T_THIS23_tree);

                    	T_HOUR24=(IToken)Match(input,T_HOUR,FOLLOW_T_HOUR_in_specification311); 
                    		T_HOUR24_tree = (object)adaptor.Create(T_HOUR24);
                    		adaptor.AddChild(root_0, T_HOUR24_tree);

                    	 var h1 = new DateTime(Now.Year, Now.Month, Now.Day, Now.Hour, 0, 0); AddDateTimeIntervalCondition(h1, h1 + TimeSpan.FromHours(1)); 

                    }
                    break;
                case 28 :
                    // DateTimeFilter.g:51:5: T_NEXT T_HOUR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NEXT25=(IToken)Match(input,T_NEXT,FOLLOW_T_NEXT_in_specification319); 
                    		T_NEXT25_tree = (object)adaptor.Create(T_NEXT25);
                    		adaptor.AddChild(root_0, T_NEXT25_tree);

                    	T_HOUR26=(IToken)Match(input,T_HOUR,FOLLOW_T_HOUR_in_specification321); 
                    		T_HOUR26_tree = (object)adaptor.Create(T_HOUR26);
                    		adaptor.AddChild(root_0, T_HOUR26_tree);

                    	 var h1 = new DateTime(Now.Year, Now.Month, Now.Day, Now.Hour, 0, 0); AddDateTimeIntervalCondition(h1 + TimeSpan.FromHours(1), h1 + TimeSpan.FromHours(2)); 

                    }
                    break;
                case 29 :
                    // DateTimeFilter.g:53:5: T_YESTERDAY
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_YESTERDAY27=(IToken)Match(input,T_YESTERDAY,FOLLOW_T_YESTERDAY_in_specification330); 
                    		T_YESTERDAY27_tree = (object)adaptor.Create(T_YESTERDAY27);
                    		adaptor.AddChild(root_0, T_YESTERDAY27_tree);

                    	 AddDateTimeIntervalCondition(Now.Date-TimeSpan.FromDays(1), Now.Date); 

                    }
                    break;
                case 30 :
                    // DateTimeFilter.g:54:5: T_TODAY
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_TODAY28=(IToken)Match(input,T_TODAY,FOLLOW_T_TODAY_in_specification338); 
                    		T_TODAY28_tree = (object)adaptor.Create(T_TODAY28);
                    		adaptor.AddChild(root_0, T_TODAY28_tree);

                    	 AddDateTimeIntervalCondition(Now.Date, Now.Date+TimeSpan.FromDays(1)); 

                    }
                    break;
                case 31 :
                    // DateTimeFilter.g:55:5: T_TOMORROW
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_TOMORROW29=(IToken)Match(input,T_TOMORROW,FOLLOW_T_TOMORROW_in_specification346); 
                    		T_TOMORROW29_tree = (object)adaptor.Create(T_TOMORROW29);
                    		adaptor.AddChild(root_0, T_TOMORROW29_tree);

                    	 AddDateTimeIntervalCondition(Now.Date+TimeSpan.FromDays(1), Now.Date+TimeSpan.FromDays(2)); 

                    }
                    break;
                case 32 :
                    // DateTimeFilter.g:57:5: T_LAST T_WEEK
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_LAST30=(IToken)Match(input,T_LAST,FOLLOW_T_LAST_in_specification357); 
                    		T_LAST30_tree = (object)adaptor.Create(T_LAST30);
                    		adaptor.AddChild(root_0, T_LAST30_tree);

                    	T_WEEK31=(IToken)Match(input,T_WEEK,FOLLOW_T_WEEK_in_specification359); 
                    		T_WEEK31_tree = (object)adaptor.Create(T_WEEK31);
                    		adaptor.AddChild(root_0, T_WEEK31_tree);

                    	 var d1=GetFirstDayOfWeek(Now.Date); AddDateTimeIntervalCondition(d1-TimeSpan.FromDays(7), d1); 

                    }
                    break;
                case 33 :
                    // DateTimeFilter.g:58:5: T_THIS T_WEEK
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_THIS32=(IToken)Match(input,T_THIS,FOLLOW_T_THIS_in_specification367); 
                    		T_THIS32_tree = (object)adaptor.Create(T_THIS32);
                    		adaptor.AddChild(root_0, T_THIS32_tree);

                    	T_WEEK33=(IToken)Match(input,T_WEEK,FOLLOW_T_WEEK_in_specification369); 
                    		T_WEEK33_tree = (object)adaptor.Create(T_WEEK33);
                    		adaptor.AddChild(root_0, T_WEEK33_tree);

                    	 var d1=GetFirstDayOfWeek(Now.Date); AddDateTimeIntervalCondition(d1, d1+TimeSpan.FromDays(7)); 

                    }
                    break;
                case 34 :
                    // DateTimeFilter.g:59:5: T_NEXT T_WEEK
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NEXT34=(IToken)Match(input,T_NEXT,FOLLOW_T_NEXT_in_specification377); 
                    		T_NEXT34_tree = (object)adaptor.Create(T_NEXT34);
                    		adaptor.AddChild(root_0, T_NEXT34_tree);

                    	T_WEEK35=(IToken)Match(input,T_WEEK,FOLLOW_T_WEEK_in_specification379); 
                    		T_WEEK35_tree = (object)adaptor.Create(T_WEEK35);
                    		adaptor.AddChild(root_0, T_WEEK35_tree);

                    	 var d1=GetFirstDayOfWeek(Now.Date); AddDateTimeIntervalCondition(d1+TimeSpan.FromDays(7), d1+TimeSpan.FromDays(14)); 

                    }
                    break;
                case 35 :
                    // DateTimeFilter.g:61:5: T_LAST T_MONTH
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_LAST36=(IToken)Match(input,T_LAST,FOLLOW_T_LAST_in_specification388); 
                    		T_LAST36_tree = (object)adaptor.Create(T_LAST36);
                    		adaptor.AddChild(root_0, T_LAST36_tree);

                    	T_MONTH37=(IToken)Match(input,T_MONTH,FOLLOW_T_MONTH_in_specification390); 
                    		T_MONTH37_tree = (object)adaptor.Create(T_MONTH37);
                    		adaptor.AddChild(root_0, T_MONTH37_tree);

                    	 var d1=new DateTime(Now.Year, Now.Month, 1); AddDateTimeIntervalCondition(d1.AddMonths(-1), d1); 

                    }
                    break;
                case 36 :
                    // DateTimeFilter.g:62:5: T_THIS T_MONTH
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_THIS38=(IToken)Match(input,T_THIS,FOLLOW_T_THIS_in_specification398); 
                    		T_THIS38_tree = (object)adaptor.Create(T_THIS38);
                    		adaptor.AddChild(root_0, T_THIS38_tree);

                    	T_MONTH39=(IToken)Match(input,T_MONTH,FOLLOW_T_MONTH_in_specification400); 
                    		T_MONTH39_tree = (object)adaptor.Create(T_MONTH39);
                    		adaptor.AddChild(root_0, T_MONTH39_tree);

                    	 var d1=new DateTime(Now.Year, Now.Month, 1); AddDateTimeIntervalCondition(d1, d1.AddMonths(1)); 

                    }
                    break;
                case 37 :
                    // DateTimeFilter.g:63:5: T_NEXT T_MONTH
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NEXT40=(IToken)Match(input,T_NEXT,FOLLOW_T_NEXT_in_specification408); 
                    		T_NEXT40_tree = (object)adaptor.Create(T_NEXT40);
                    		adaptor.AddChild(root_0, T_NEXT40_tree);

                    	T_MONTH41=(IToken)Match(input,T_MONTH,FOLLOW_T_MONTH_in_specification410); 
                    		T_MONTH41_tree = (object)adaptor.Create(T_MONTH41);
                    		adaptor.AddChild(root_0, T_MONTH41_tree);

                    	 var d1=new DateTime(Now.Year, Now.Month, 1); AddDateTimeIntervalCondition(d1.AddMonths(1), d1.AddMonths(2)); 

                    }
                    break;
                case 38 :
                    // DateTimeFilter.g:65:5: T_LAST T_YEAR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_LAST42=(IToken)Match(input,T_LAST,FOLLOW_T_LAST_in_specification421); 
                    		T_LAST42_tree = (object)adaptor.Create(T_LAST42);
                    		adaptor.AddChild(root_0, T_LAST42_tree);

                    	T_YEAR43=(IToken)Match(input,T_YEAR,FOLLOW_T_YEAR_in_specification423); 
                    		T_YEAR43_tree = (object)adaptor.Create(T_YEAR43);
                    		adaptor.AddChild(root_0, T_YEAR43_tree);

                    	 var d1=new DateTime(Now.Year, 1, 1); AddDateTimeIntervalCondition(d1.AddYears(-1), d1); 

                    }
                    break;
                case 39 :
                    // DateTimeFilter.g:66:5: T_THIS T_YEAR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_THIS44=(IToken)Match(input,T_THIS,FOLLOW_T_THIS_in_specification431); 
                    		T_THIS44_tree = (object)adaptor.Create(T_THIS44);
                    		adaptor.AddChild(root_0, T_THIS44_tree);

                    	T_YEAR45=(IToken)Match(input,T_YEAR,FOLLOW_T_YEAR_in_specification433); 
                    		T_YEAR45_tree = (object)adaptor.Create(T_YEAR45);
                    		adaptor.AddChild(root_0, T_YEAR45_tree);

                    	 var d1=new DateTime(Now.Year, 1, 1); AddDateTimeIntervalCondition(d1, d1.AddYears(1)); 

                    }
                    break;
                case 40 :
                    // DateTimeFilter.g:67:5: T_NEXT T_YEAR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NEXT46=(IToken)Match(input,T_NEXT,FOLLOW_T_NEXT_in_specification441); 
                    		T_NEXT46_tree = (object)adaptor.Create(T_NEXT46);
                    		adaptor.AddChild(root_0, T_NEXT46_tree);

                    	T_YEAR47=(IToken)Match(input,T_YEAR,FOLLOW_T_YEAR_in_specification443); 
                    		T_YEAR47_tree = (object)adaptor.Create(T_YEAR47);
                    		adaptor.AddChild(root_0, T_YEAR47_tree);

                    	 var d1=new DateTime(Now.Year, 1, 1); AddDateTimeIntervalCondition(d1.AddYears(1), d1.AddYears(2)); 

                    }
                    break;
                case 41 :
                    // DateTimeFilter.g:69:5: EQ d= DATE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	EQ48=(IToken)Match(input,EQ,FOLLOW_EQ_in_specification454); 
                    		EQ48_tree = (object)adaptor.Create(EQ48);
                    		adaptor.AddChild(root_0, EQ48_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification458); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 var dt=ParseDate(((d != null) ? d.Text : null));AddDateTimeIntervalCondition(dt, dt + TimeSpan.FromDays(1)); 

                    }
                    break;
                case 42 :
                    // DateTimeFilter.g:70:5: LT d= DATE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LT49=(IToken)Match(input,LT,FOLLOW_LT_in_specification468); 
                    		LT49_tree = (object)adaptor.Create(LT49);
                    		adaptor.AddChild(root_0, LT49_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification472); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 var dt=ParseDate(((d != null) ? d.Text : null));AddDateTimeRelation(dt, "<"); 

                    }
                    break;
                case 43 :
                    // DateTimeFilter.g:71:5: LE d= DATE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LE50=(IToken)Match(input,LE,FOLLOW_LE_in_specification482); 
                    		LE50_tree = (object)adaptor.Create(LE50);
                    		adaptor.AddChild(root_0, LE50_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification486); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 var dt=ParseDate(((d != null) ? d.Text : null));AddDateTimeRelation(dt+TimeSpan.FromDays(1), "<"); 

                    }
                    break;
                case 44 :
                    // DateTimeFilter.g:72:5: GT d= DATE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GT51=(IToken)Match(input,GT,FOLLOW_GT_in_specification496); 
                    		GT51_tree = (object)adaptor.Create(GT51);
                    		adaptor.AddChild(root_0, GT51_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification500); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 var dt=ParseDate(((d != null) ? d.Text : null));AddDateTimeRelation(dt+TimeSpan.FromDays(1), ">="); 

                    }
                    break;
                case 45 :
                    // DateTimeFilter.g:73:5: GE d= DATE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GE52=(IToken)Match(input,GE,FOLLOW_GE_in_specification510); 
                    		GE52_tree = (object)adaptor.Create(GE52);
                    		adaptor.AddChild(root_0, GE52_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification514); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 var dt=ParseDate(((d != null) ? d.Text : null));AddDateTimeRelation(dt, ">="); 

                    }
                    break;
                case 46 :
                    // DateTimeFilter.g:74:5: NE d= DATE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NE53=(IToken)Match(input,NE,FOLLOW_NE_in_specification524); 
                    		NE53_tree = (object)adaptor.Create(NE53);
                    		adaptor.AddChild(root_0, NE53_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification528); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 var dt=ParseDate(((d != null) ? d.Text : null));AddDateTimeNotIntervalCondition(dt, dt + TimeSpan.FromDays(1)); 

                    }
                    break;
                case 47 :
                    // DateTimeFilter.g:76:5: d= DATE time_noexact
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification539); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	PushFollow(FOLLOW_time_noexact_in_specification541);
                    	time_noexact54 = time_noexact();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, time_noexact54.Tree);
                    	 string time=Pop<string>(); AddDateTimeIntervalCondition(ParseDate(((d != null) ? d.Text : null)) + ParseTime(time), ParseDate(((d != null) ? d.Text : null)) + ParseTimeEnd(time)); 

                    }
                    break;
                case 48 :
                    // DateTimeFilter.g:77:5: EQ d= DATE time_noexact
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	EQ55=(IToken)Match(input,EQ,FOLLOW_EQ_in_specification551); 
                    		EQ55_tree = (object)adaptor.Create(EQ55);
                    		adaptor.AddChild(root_0, EQ55_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification555); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	PushFollow(FOLLOW_time_noexact_in_specification557);
                    	time_noexact56 = time_noexact();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, time_noexact56.Tree);
                    	 string time=Pop<string>(); AddDateTimeIntervalCondition(ParseDate(((d != null) ? d.Text : null)) + ParseTime(time), ParseDate(((d != null) ? d.Text : null)) + ParseTimeEnd(time)); 

                    }
                    break;
                case 49 :
                    // DateTimeFilter.g:79:5: d= DATE time_exact
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification568); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	PushFollow(FOLLOW_time_exact_in_specification570);
                    	time_exact57 = time_exact();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, time_exact57.Tree);
                    	 string time=Pop<string>(); var dt=ParseDate(((d != null) ? d.Text : null)) + ParseTime(time);AddDateTimeRelation(dt, "=");  

                    }
                    break;
                case 50 :
                    // DateTimeFilter.g:80:5: EQ d= DATE time_exact
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	EQ58=(IToken)Match(input,EQ,FOLLOW_EQ_in_specification580); 
                    		EQ58_tree = (object)adaptor.Create(EQ58);
                    		adaptor.AddChild(root_0, EQ58_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification584); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	PushFollow(FOLLOW_time_exact_in_specification586);
                    	time_exact59 = time_exact();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, time_exact59.Tree);
                    	 string time=Pop<string>(); var dt=ParseDate(((d != null) ? d.Text : null)) + ParseTime(time);AddDateTimeRelation(dt, "=");  

                    }
                    break;
                case 51 :
                    // DateTimeFilter.g:82:5: LT d= DATE t= time
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LT60=(IToken)Match(input,LT,FOLLOW_LT_in_specification599); 
                    		LT60_tree = (object)adaptor.Create(LT60);
                    		adaptor.AddChild(root_0, LT60_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification603); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	PushFollow(FOLLOW_time_in_specification607);
                    	t = time();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, t.Tree);
                    	 var dt=ParseDate(((d != null) ? d.Text : null))+ParseTime(((t != null) ? input.ToString((IToken)(t.Start),(IToken)(t.Stop)) : null));AddDateTimeRelation(dt, "<"); 

                    }
                    break;
                case 52 :
                    // DateTimeFilter.g:83:5: LE d= DATE t= time
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LE61=(IToken)Match(input,LE,FOLLOW_LE_in_specification617); 
                    		LE61_tree = (object)adaptor.Create(LE61);
                    		adaptor.AddChild(root_0, LE61_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification621); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	PushFollow(FOLLOW_time_in_specification625);
                    	t = time();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, t.Tree);
                    	 var dt=ParseDate(((d != null) ? d.Text : null))+ParseTimeEnd(((t != null) ? input.ToString((IToken)(t.Start),(IToken)(t.Stop)) : null));AddDateTimeRelation(dt, "<="); 

                    }
                    break;
                case 53 :
                    // DateTimeFilter.g:84:5: GT d= DATE t= time
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GT62=(IToken)Match(input,GT,FOLLOW_GT_in_specification635); 
                    		GT62_tree = (object)adaptor.Create(GT62);
                    		adaptor.AddChild(root_0, GT62_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification639); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	PushFollow(FOLLOW_time_in_specification643);
                    	t = time();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, t.Tree);
                    	 var dt=ParseDate(((d != null) ? d.Text : null))+ParseTime(((t != null) ? input.ToString((IToken)(t.Start),(IToken)(t.Stop)) : null));AddDateTimeRelation(dt, ">"); 

                    }
                    break;
                case 54 :
                    // DateTimeFilter.g:85:5: GE d= DATE t= time
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GE63=(IToken)Match(input,GE,FOLLOW_GE_in_specification653); 
                    		GE63_tree = (object)adaptor.Create(GE63);
                    		adaptor.AddChild(root_0, GE63_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification657); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	PushFollow(FOLLOW_time_in_specification661);
                    	t = time();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, t.Tree);
                    	 var dt=ParseDate(((d != null) ? d.Text : null))+ParseTime(((t != null) ? input.ToString((IToken)(t.Start),(IToken)(t.Stop)) : null));AddDateTimeRelation(dt, ">="); 

                    }
                    break;
                case 55 :
                    // DateTimeFilter.g:86:5: T_NULL
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NULL64=(IToken)Match(input,T_NULL,FOLLOW_T_NULL_in_specification669); 
                    		T_NULL64_tree = (object)adaptor.Create(T_NULL64);
                    		adaptor.AddChild(root_0, T_NULL64_tree);

                    	 AddIsNullCondition(); 

                    }
                    break;
                case 56 :
                    // DateTimeFilter.g:87:5: T_NOT T_NULL
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NOT65=(IToken)Match(input,T_NOT,FOLLOW_T_NOT_in_specification677); 
                    		T_NOT65_tree = (object)adaptor.Create(T_NOT65);
                    		adaptor.AddChild(root_0, T_NOT65_tree);

                    	T_NULL66=(IToken)Match(input,T_NULL,FOLLOW_T_NULL_in_specification679); 
                    		T_NULL66_tree = (object)adaptor.Create(T_NULL66);
                    		adaptor.AddChild(root_0, T_NULL66_tree);

                    	 AddIsNotNullCondition(); 

                    }
                    break;
                case 57 :
                    // DateTimeFilter.g:89:5: LT sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LT67=(IToken)Match(input,LT,FOLLOW_LT_in_specification690); 
                    		LT67_tree = (object)adaptor.Create(LT67);
                    		adaptor.AddChild(root_0, LT67_tree);

                    	PushFollow(FOLLOW_sql_name_in_specification692);
                    	sql_name68 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name68.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), "<"); 

                    }
                    break;
                case 58 :
                    // DateTimeFilter.g:90:5: GT sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GT69=(IToken)Match(input,GT,FOLLOW_GT_in_specification701); 
                    		GT69_tree = (object)adaptor.Create(GT69);
                    		adaptor.AddChild(root_0, GT69_tree);

                    	PushFollow(FOLLOW_sql_name_in_specification703);
                    	sql_name70 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name70.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), ">"); 

                    }
                    break;
                case 59 :
                    // DateTimeFilter.g:91:5: LE sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LE71=(IToken)Match(input,LE,FOLLOW_LE_in_specification712); 
                    		LE71_tree = (object)adaptor.Create(LE71);
                    		adaptor.AddChild(root_0, LE71_tree);

                    	PushFollow(FOLLOW_sql_name_in_specification714);
                    	sql_name72 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name72.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), "<="); 

                    }
                    break;
                case 60 :
                    // DateTimeFilter.g:92:5: GE sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GE73=(IToken)Match(input,GE,FOLLOW_GE_in_specification723); 
                    		GE73_tree = (object)adaptor.Create(GE73);
                    		adaptor.AddChild(root_0, GE73_tree);

                    	PushFollow(FOLLOW_sql_name_in_specification725);
                    	sql_name74 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name74.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), ">="); 

                    }
                    break;
                case 61 :
                    // DateTimeFilter.g:93:5: NE sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NE75=(IToken)Match(input,NE,FOLLOW_NE_in_specification734); 
                    		NE75_tree = (object)adaptor.Create(NE75);
                    		adaptor.AddChild(root_0, NE75_tree);

                    	PushFollow(FOLLOW_sql_name_in_specification736);
                    	sql_name76 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name76.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), "<>"); 

                    }
                    break;
                case 62 :
                    // DateTimeFilter.g:94:5: EQ sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	EQ77=(IToken)Match(input,EQ,FOLLOW_EQ_in_specification745); 
                    		EQ77_tree = (object)adaptor.Create(EQ77);
                    		adaptor.AddChild(root_0, EQ77_tree);

                    	PushFollow(FOLLOW_sql_name_in_specification747);
                    	sql_name78 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name78.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), "="); 

                    }
                    break;
                case 63 :
                    // DateTimeFilter.g:95:5: EQ2 sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	EQ279=(IToken)Match(input,EQ2,FOLLOW_EQ2_in_specification755); 
                    		EQ279_tree = (object)adaptor.Create(EQ279);
                    		adaptor.AddChild(root_0, EQ279_tree);

                    	PushFollow(FOLLOW_sql_name_in_specification757);
                    	sql_name80 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name80.Tree);
                    	 AddSqlLiteralRelationWithNullTest_EQ(Pop<string>()); 

                    }
                    break;
                case 64 :
                    // DateTimeFilter.g:96:5: NE2 sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NE281=(IToken)Match(input,NE2,FOLLOW_NE2_in_specification766); 
                    		NE281_tree = (object)adaptor.Create(NE281);
                    		adaptor.AddChild(root_0, NE281_tree);

                    	PushFollow(FOLLOW_sql_name_in_specification768);
                    	sql_name82 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name82.Tree);
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
    // $ANTLR end "specification"

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
    // DateTimeFilter.g:100:1: interval : (d1= DATE MINUS d2= DATE | d1= DATE t1= time MINUS d2= DATE t2= time );
    public DateTimeFilterParser.interval_return interval() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.interval_return retval = new DateTimeFilterParser.interval_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken d1 = null;
        IToken d2 = null;
        IToken MINUS83 = null;
        IToken MINUS84 = null;
        DateTimeFilterParser.time_return t1 = default(DateTimeFilterParser.time_return);

        DateTimeFilterParser.time_return t2 = default(DateTimeFilterParser.time_return);


        object d1_tree=null;
        object d2_tree=null;
        object MINUS83_tree=null;
        object MINUS84_tree=null;

        try 
    	{
            // DateTimeFilter.g:100:10: (d1= DATE MINUS d2= DATE | d1= DATE t1= time MINUS d2= DATE t2= time )
            int alt3 = 2;
            int LA3_0 = input.LA(1);

            if ( (LA3_0 == DATE) )
            {
                int LA3_1 = input.LA(2);

                if ( (LA3_1 == MINUS) )
                {
                    alt3 = 1;
                }
                else if ( ((LA3_1 >= TIME_SECOND_FRACTION && LA3_1 <= TIME_SECOND)) )
                {
                    alt3 = 2;
                }
                else 
                {
                    NoViableAltException nvae_d3s1 =
                        new NoViableAltException("", 3, 1, input);

                    throw nvae_d3s1;
                }
            }
            else 
            {
                NoViableAltException nvae_d3s0 =
                    new NoViableAltException("", 3, 0, input);

                throw nvae_d3s0;
            }
            switch (alt3) 
            {
                case 1 :
                    // DateTimeFilter.g:101:3: d1= DATE MINUS d2= DATE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	d1=(IToken)Match(input,DATE,FOLLOW_DATE_in_interval787); 
                    		d1_tree = (object)adaptor.Create(d1);
                    		adaptor.AddChild(root_0, d1_tree);

                    	MINUS83=(IToken)Match(input,MINUS,FOLLOW_MINUS_in_interval789); 
                    		MINUS83_tree = (object)adaptor.Create(MINUS83);
                    		adaptor.AddChild(root_0, MINUS83_tree);

                    	d2=(IToken)Match(input,DATE,FOLLOW_DATE_in_interval793); 
                    		d2_tree = (object)adaptor.Create(d2);
                    		adaptor.AddChild(root_0, d2_tree);

                    	 AddDateTimeIntervalCondition(ParseDate(((d1 != null) ? d1.Text : null)), ParseDate(((d2 != null) ? d2.Text : null)) + TimeSpan.FromDays(1)); 

                    }
                    break;
                case 2 :
                    // DateTimeFilter.g:102:5: d1= DATE t1= time MINUS d2= DATE t2= time
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	d1=(IToken)Match(input,DATE,FOLLOW_DATE_in_interval803); 
                    		d1_tree = (object)adaptor.Create(d1);
                    		adaptor.AddChild(root_0, d1_tree);

                    	PushFollow(FOLLOW_time_in_interval807);
                    	t1 = time();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, t1.Tree);
                    	MINUS84=(IToken)Match(input,MINUS,FOLLOW_MINUS_in_interval809); 
                    		MINUS84_tree = (object)adaptor.Create(MINUS84);
                    		adaptor.AddChild(root_0, MINUS84_tree);

                    	d2=(IToken)Match(input,DATE,FOLLOW_DATE_in_interval813); 
                    		d2_tree = (object)adaptor.Create(d2);
                    		adaptor.AddChild(root_0, d2_tree);

                    	PushFollow(FOLLOW_time_in_interval817);
                    	t2 = time();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, t2.Tree);

                    	    AddDateTimeIntervalCondition(ParseDate(((d1 != null) ? d1.Text : null)) + ParseTime(((t1 != null) ? input.ToString((IToken)(t1.Start),(IToken)(t1.Stop)) : null)), ParseDate(((d2 != null) ? d2.Text : null)) + ParseTimeEnd(((t2 != null) ? input.ToString((IToken)(t2.Start),(IToken)(t2.Stop)) : null)));    
                    	  

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

    public class time_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "time"
    // DateTimeFilter.g:107:1: time : ( time_exact | time_noexact );
    public DateTimeFilterParser.time_return time() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.time_return retval = new DateTimeFilterParser.time_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        DateTimeFilterParser.time_exact_return time_exact85 = default(DateTimeFilterParser.time_exact_return);

        DateTimeFilterParser.time_noexact_return time_noexact86 = default(DateTimeFilterParser.time_noexact_return);



        try 
    	{
            // DateTimeFilter.g:107:5: ( time_exact | time_noexact )
            int alt4 = 2;
            int LA4_0 = input.LA(1);

            if ( (LA4_0 == TIME_SECOND_FRACTION) )
            {
                alt4 = 1;
            }
            else if ( ((LA4_0 >= TIME_MINUE && LA4_0 <= TIME_SECOND)) )
            {
                alt4 = 2;
            }
            else 
            {
                NoViableAltException nvae_d4s0 =
                    new NoViableAltException("", 4, 0, input);

                throw nvae_d4s0;
            }
            switch (alt4) 
            {
                case 1 :
                    // DateTimeFilter.g:108:4: time_exact
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_time_exact_in_time830);
                    	time_exact85 = time_exact();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, time_exact85.Tree);

                    }
                    break;
                case 2 :
                    // DateTimeFilter.g:108:17: time_noexact
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_time_noexact_in_time834);
                    	time_noexact86 = time_noexact();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, time_noexact86.Tree);

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
    // $ANTLR end "time"

    public class time_exact_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "time_exact"
    // DateTimeFilter.g:110:1: time_exact : t= TIME_SECOND_FRACTION ;
    public DateTimeFilterParser.time_exact_return time_exact() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.time_exact_return retval = new DateTimeFilterParser.time_exact_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken t = null;

        object t_tree=null;

        try 
    	{
            // DateTimeFilter.g:110:11: (t= TIME_SECOND_FRACTION )
            // DateTimeFilter.g:111:3: t= TIME_SECOND_FRACTION
            {
            	root_0 = (object)adaptor.GetNilNode();

            	t=(IToken)Match(input,TIME_SECOND_FRACTION,FOLLOW_TIME_SECOND_FRACTION_in_time_exact849); 
            		t_tree = (object)adaptor.Create(t);
            		adaptor.AddChild(root_0, t_tree);

            	 Push(((t != null) ? t.Text : null)); 

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
    // $ANTLR end "time_exact"

    public class time_noexact_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "time_noexact"
    // DateTimeFilter.g:113:1: time_noexact : (t= TIME_MINUE | t= TIME_SECOND );
    public DateTimeFilterParser.time_noexact_return time_noexact() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.time_noexact_return retval = new DateTimeFilterParser.time_noexact_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken t = null;

        object t_tree=null;

        try 
    	{
            // DateTimeFilter.g:113:13: (t= TIME_MINUE | t= TIME_SECOND )
            int alt5 = 2;
            int LA5_0 = input.LA(1);

            if ( (LA5_0 == TIME_MINUE) )
            {
                alt5 = 1;
            }
            else if ( (LA5_0 == TIME_SECOND) )
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
                    // DateTimeFilter.g:114:3: t= TIME_MINUE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	t=(IToken)Match(input,TIME_MINUE,FOLLOW_TIME_MINUE_in_time_noexact865); 
                    		t_tree = (object)adaptor.Create(t);
                    		adaptor.AddChild(root_0, t_tree);

                    	 Push(((t != null) ? t.Text : null)); 

                    }
                    break;
                case 2 :
                    // DateTimeFilter.g:114:37: t= TIME_SECOND
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	t=(IToken)Match(input,TIME_SECOND,FOLLOW_TIME_SECOND_in_time_noexact873); 
                    		t_tree = (object)adaptor.Create(t);
                    		adaptor.AddChild(root_0, t_tree);

                    	 Push(((t != null) ? t.Text : null)); 

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
    // $ANTLR end "time_noexact"

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
    // DateTimeFilter.g:116:1: element : ( specification | interval );
    public DateTimeFilterParser.element_return element() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.element_return retval = new DateTimeFilterParser.element_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        DateTimeFilterParser.specification_return specification87 = default(DateTimeFilterParser.specification_return);

        DateTimeFilterParser.interval_return interval88 = default(DateTimeFilterParser.interval_return);



        try 
    	{
            // DateTimeFilter.g:116:8: ( specification | interval )
            int alt6 = 2;
            int LA6_0 = input.LA(1);

            if ( (LA6_0 == YEAR || (LA6_0 >= HOUR_ANY_MINUTE && LA6_0 <= T_LAST) || (LA6_0 >= T_THIS && LA6_0 <= T_TOMORROW) || (LA6_0 >= EQ && LA6_0 <= NE2)) )
            {
                alt6 = 1;
            }
            else if ( (LA6_0 == DATE) )
            {
                switch ( input.LA(2) ) 
                {
                case MINUS:
                	{
                    alt6 = 2;
                    }
                    break;
                case TIME_SECOND_FRACTION:
                	{
                    int LA6_4 = input.LA(3);

                    if ( (LA6_4 == MINUS) )
                    {
                        alt6 = 2;
                    }
                    else if ( (LA6_4 == EOF || (LA6_4 >= YEAR && LA6_4 <= T_LAST) || (LA6_4 >= T_THIS && LA6_4 <= T_TOMORROW) || (LA6_4 >= EQ && LA6_4 <= NE2) || (LA6_4 >= COMMA && LA6_4 <= ENDLINE)) )
                    {
                        alt6 = 1;
                    }
                    else 
                    {
                        NoViableAltException nvae_d6s4 =
                            new NoViableAltException("", 6, 4, input);

                        throw nvae_d6s4;
                    }
                    }
                    break;
                case TIME_MINUE:
                	{
                    int LA6_5 = input.LA(3);

                    if ( (LA6_5 == EOF || (LA6_5 >= YEAR && LA6_5 <= T_LAST) || (LA6_5 >= T_THIS && LA6_5 <= T_TOMORROW) || (LA6_5 >= EQ && LA6_5 <= NE2) || (LA6_5 >= COMMA && LA6_5 <= ENDLINE)) )
                    {
                        alt6 = 1;
                    }
                    else if ( (LA6_5 == MINUS) )
                    {
                        alt6 = 2;
                    }
                    else 
                    {
                        NoViableAltException nvae_d6s5 =
                            new NoViableAltException("", 6, 5, input);

                        throw nvae_d6s5;
                    }
                    }
                    break;
                case TIME_SECOND:
                	{
                    int LA6_6 = input.LA(3);

                    if ( (LA6_6 == EOF || (LA6_6 >= YEAR && LA6_6 <= T_LAST) || (LA6_6 >= T_THIS && LA6_6 <= T_TOMORROW) || (LA6_6 >= EQ && LA6_6 <= NE2) || (LA6_6 >= COMMA && LA6_6 <= ENDLINE)) )
                    {
                        alt6 = 1;
                    }
                    else if ( (LA6_6 == MINUS) )
                    {
                        alt6 = 2;
                    }
                    else 
                    {
                        NoViableAltException nvae_d6s6 =
                            new NoViableAltException("", 6, 6, input);

                        throw nvae_d6s6;
                    }
                    }
                    break;
                case EOF:
                case YEAR:
                case DATE:
                case HOUR_ANY_MINUTE:
                case FLOW_MONTH:
                case FLOW_DAY:
                case YEAR_MONTH:
                case T_JAN:
                case T_FEB:
                case T_MAR:
                case T_APR:
                case T_MAY:
                case T_JUN:
                case T_JUL:
                case T_AUG:
                case T_SEP:
                case T_OCT:
                case T_NOV:
                case T_DEC:
                case T_MON:
                case T_TUE:
                case T_WED:
                case T_THU:
                case T_FRI:
                case T_SAT:
                case T_SUN:
                case T_LAST:
                case T_THIS:
                case T_NEXT:
                case T_YESTERDAY:
                case T_TODAY:
                case T_TOMORROW:
                case EQ:
                case LT:
                case LE:
                case GT:
                case GE:
                case NE:
                case T_NULL:
                case T_NOT:
                case EQ2:
                case NE2:
                case COMMA:
                case ENDLINE:
                	{
                    alt6 = 1;
                    }
                    break;
                	default:
                	    NoViableAltException nvae_d6s2 =
                	        new NoViableAltException("", 6, 2, input);

                	    throw nvae_d6s2;
                }

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
                    // DateTimeFilter.g:117:3: specification
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_specification_in_element885);
                    	specification87 = specification();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, specification87.Tree);

                    }
                    break;
                case 2 :
                    // DateTimeFilter.g:117:19: interval
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_interval_in_element889);
                    	interval88 = interval();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, interval88.Tree);

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
    // DateTimeFilter.g:119:1: factor : ( element )+ ;
    public DateTimeFilterParser.factor_return factor() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.factor_return retval = new DateTimeFilterParser.factor_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        DateTimeFilterParser.element_return element89 = default(DateTimeFilterParser.element_return);



        try 
    	{
            // DateTimeFilter.g:119:8: ( ( element )+ )
            // DateTimeFilter.g:120:3: ( element )+
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// DateTimeFilter.g:120:3: ( element )+
            	int cnt7 = 0;
            	do 
            	{
            	    int alt7 = 2;
            	    int LA7_0 = input.LA(1);

            	    if ( ((LA7_0 >= YEAR && LA7_0 <= T_LAST) || (LA7_0 >= T_THIS && LA7_0 <= T_TOMORROW) || (LA7_0 >= EQ && LA7_0 <= NE2)) )
            	    {
            	        alt7 = 1;
            	    }


            	    switch (alt7) 
            		{
            			case 1 :
            			    // DateTimeFilter.g:120:3: element
            			    {
            			    	PushFollow(FOLLOW_element_in_factor901);
            			    	element89 = element();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, element89.Tree);

            			    }
            			    break;

            			default:
            			    if ( cnt7 >= 1 ) goto loop7;
            		            EarlyExitException eee7 =
            		                new EarlyExitException(7, input);
            		            throw eee7;
            	    }
            	    cnt7++;
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
    // DateTimeFilter.g:122:1: list : factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )* ;
    public DateTimeFilterParser.list_return list() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.list_return retval = new DateTimeFilterParser.list_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken COMMA91 = null;
        IToken ENDLINE92 = null;
        IToken ENDLINE94 = null;
        DateTimeFilterParser.factor_return factor90 = default(DateTimeFilterParser.factor_return);

        DateTimeFilterParser.factor_return factor93 = default(DateTimeFilterParser.factor_return);


        object COMMA91_tree=null;
        object ENDLINE92_tree=null;
        object ENDLINE94_tree=null;

        try 
    	{
            // DateTimeFilter.g:122:5: ( factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )* )
            // DateTimeFilter.g:123:3: factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_factor_in_list912);
            	factor90 = factor();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, factor90.Tree);
            	// DateTimeFilter.g:123:10: ( ( COMMA | ( ( ENDLINE )+ ) ) factor )*
            	do 
            	{
            	    int alt10 = 2;
            	    alt10 = dfa10.Predict(input);
            	    switch (alt10) 
            		{
            			case 1 :
            			    // DateTimeFilter.g:123:12: ( COMMA | ( ( ENDLINE )+ ) ) factor
            			    {
            			    	// DateTimeFilter.g:123:12: ( COMMA | ( ( ENDLINE )+ ) )
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
            			    	        // DateTimeFilter.g:123:13: COMMA
            			    	        {
            			    	        	COMMA91=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_list917); 
            			    	        		COMMA91_tree = (object)adaptor.Create(COMMA91);
            			    	        		adaptor.AddChild(root_0, COMMA91_tree);


            			    	        }
            			    	        break;
            			    	    case 2 :
            			    	        // DateTimeFilter.g:123:21: ( ( ENDLINE )+ )
            			    	        {
            			    	        	// DateTimeFilter.g:123:21: ( ( ENDLINE )+ )
            			    	        	// DateTimeFilter.g:123:22: ( ENDLINE )+
            			    	        	{
            			    	        		// DateTimeFilter.g:123:22: ( ENDLINE )+
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
            			    	        				    // DateTimeFilter.g:123:22: ENDLINE
            			    	        				    {
            			    	        				    	ENDLINE92=(IToken)Match(input,ENDLINE,FOLLOW_ENDLINE_in_list922); 
            			    	        				    		ENDLINE92_tree = (object)adaptor.Create(ENDLINE92);
            			    	        				    		adaptor.AddChild(root_0, ENDLINE92_tree);


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
            			    	PushFollow(FOLLOW_factor_in_list929);
            			    	factor93 = factor();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, factor93.Tree);

            			    }
            			    break;

            			default:
            			    goto loop10;
            	    }
            	} while (true);

            	loop10:
            		;	// Stops C# compiler whining that label 'loop10' has no statements

            	// DateTimeFilter.g:123:67: ( ENDLINE )*
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
            			    // DateTimeFilter.g:123:67: ENDLINE
            			    {
            			    	ENDLINE94=(IToken)Match(input,ENDLINE,FOLLOW_ENDLINE_in_list935); 
            			    		ENDLINE94_tree = (object)adaptor.Create(ENDLINE94);
            			    		adaptor.AddChild(root_0, ENDLINE94_tree);


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
    // DateTimeFilter.g:125:1: expr : list ;
    public DateTimeFilterParser.expr_return expr() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.expr_return retval = new DateTimeFilterParser.expr_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        DateTimeFilterParser.list_return list95 = default(DateTimeFilterParser.list_return);



        try 
    	{
            // DateTimeFilter.g:125:5: ( list )
            // DateTimeFilter.g:125:7: list
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_list_in_expr945);
            	list95 = list();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, list95.Tree);

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
   	protected DFA10 dfa10;
	private void InitializeCyclicDFAs()
	{
    	this.dfa2 = new DFA2(this);
    	this.dfa10 = new DFA10(this);
	}

    const string DFA2_eotS =
        "\x50\uffff";
    const string DFA2_eofS =
        "\x02\uffff\x01\x2b\x36\uffff\x01\x45\x01\uffff\x01\x49\x01\uffff"+
        "\x01\x4a\x01\uffff\x01\x4d\x01\uffff\x01\x4e\x0e\uffff";
    const string DFA2_minS =
        "\x01\x06\x01\uffff\x01\x06\x17\uffff\x03\x20\x03\uffff\x06\x04"+
        "\x13\uffff\x01\x06\x01\uffff\x01\x06\x01\uffff\x01\x06\x01\uffff"+
        "\x01\x06\x01\uffff\x01\x06\x0e\uffff";
    const string DFA2_maxS =
        "\x01\x32\x01\uffff\x01\x38\x17\uffff\x03\x28\x03\uffff\x06\x07"+
        "\x13\uffff\x01\x38\x01\uffff\x01\x38\x01\uffff\x01\x38\x01\uffff"+
        "\x01\x38\x01\uffff\x01\x38\x0e\uffff";
    const string DFA2_acceptS =
        "\x01\uffff\x01\x01\x01\uffff\x01\x03\x01\x04\x01\x05\x01\x06\x01"+
        "\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x01\x0c\x01\x0d\x01\x0e\x01"+
        "\x0f\x01\x10\x01\x11\x01\x12\x01\x13\x01\x14\x01\x15\x01\x16\x01"+
        "\x17\x01\x18\x01\x19\x03\uffff\x01\x1d\x01\x1e\x01\x1f\x06\uffff"+
        "\x01\x37\x01\x38\x01\x3f\x01\x40\x01\x31\x01\x02\x01\x2f\x01\x1a"+
        "\x01\x20\x01\x23\x01\x26\x01\x1b\x01\x21\x01\x24\x01\x27\x01\x1c"+
        "\x01\x22\x01\x25\x01\x28\x01\uffff\x01\x3e\x01\uffff\x01\x39\x01"+
        "\uffff\x01\x3b\x01\uffff\x01\x3a\x01\uffff\x01\x3c\x01\x2e\x01\x3d"+
        "\x01\x29\x01\x30\x01\x32\x01\x33\x01\x2a\x01\x2b\x01\x34\x01\x35"+
        "\x01\x2c\x01\x2d\x01\x36";
    const string DFA2_specialS =
        "\x50\uffff}>";
    static readonly string[] DFA2_transitionS = {
            "\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06\x01\x07\x01"+
            "\x08\x01\x09\x01\x0a\x01\x0b\x01\x0c\x01\x0d\x01\x0e\x01\x0f"+
            "\x01\x10\x01\x11\x01\x12\x01\x13\x01\x14\x01\x15\x01\x16\x01"+
            "\x17\x01\x18\x01\x19\x01\x1a\x01\uffff\x01\x1b\x01\x1c\x01\x1d"+
            "\x01\x1e\x01\x1f\x03\uffff\x01\x20\x01\x21\x01\x22\x01\x23\x01"+
            "\x24\x01\x25\x01\x26\x01\x27\x01\x28\x01\x29",
            "",
            "\x1a\x2b\x01\uffff\x05\x2b\x03\uffff\x0a\x2b\x01\uffff\x01"+
            "\x2a\x02\x2c\x02\x2b",
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
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            "\x01\x2d\x05\uffff\x01\x2e\x01\x2f\x01\x30",
            "\x01\x31\x05\uffff\x01\x32\x01\x33\x01\x34",
            "\x01\x35\x05\uffff\x01\x36\x01\x37\x01\x38",
            "",
            "",
            "",
            "\x01\x3a\x02\uffff\x01\x39",
            "\x01\x3c\x02\uffff\x01\x3b",
            "\x01\x3e\x02\uffff\x01\x3d",
            "\x01\x40\x02\uffff\x01\x3f",
            "\x01\x42\x02\uffff\x01\x41",
            "\x01\x44\x02\uffff\x01\x43",
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
            "",
            "",
            "",
            "\x1a\x45\x01\uffff\x05\x45\x03\uffff\x0a\x45\x01\uffff\x01"+
            "\x47\x02\x46\x02\x45",
            "",
            "\x1a\x49\x01\uffff\x05\x49\x03\uffff\x0a\x49\x01\uffff\x03"+
            "\x48\x02\x49",
            "",
            "\x1a\x4a\x01\uffff\x05\x4a\x03\uffff\x0a\x4a\x01\uffff\x03"+
            "\x4b\x02\x4a",
            "",
            "\x1a\x4d\x01\uffff\x05\x4d\x03\uffff\x0a\x4d\x01\uffff\x03"+
            "\x4c\x02\x4d",
            "",
            "\x1a\x4e\x01\uffff\x05\x4e\x03\uffff\x0a\x4e\x01\uffff\x03"+
            "\x4f\x02\x4e",
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
            get { return "19:1: specification : (y= YEAR | d= DATE | d= HOUR_ANY_MINUTE | d= FLOW_MONTH | d= FLOW_DAY | d= YEAR_MONTH | T_JAN | T_FEB | T_MAR | T_APR | T_MAY | T_JUN | T_JUL | T_AUG | T_SEP | T_OCT | T_NOV | T_DEC | T_MON | T_TUE | T_WED | T_THU | T_FRI | T_SAT | T_SUN | T_LAST T_HOUR | T_THIS T_HOUR | T_NEXT T_HOUR | T_YESTERDAY | T_TODAY | T_TOMORROW | T_LAST T_WEEK | T_THIS T_WEEK | T_NEXT T_WEEK | T_LAST T_MONTH | T_THIS T_MONTH | T_NEXT T_MONTH | T_LAST T_YEAR | T_THIS T_YEAR | T_NEXT T_YEAR | EQ d= DATE | LT d= DATE | LE d= DATE | GT d= DATE | GE d= DATE | NE d= DATE | d= DATE time_noexact | EQ d= DATE time_noexact | d= DATE time_exact | EQ d= DATE time_exact | LT d= DATE t= time | LE d= DATE t= time | GT d= DATE t= time | GE d= DATE t= time | T_NULL | T_NOT T_NULL | LT sql_name | GT sql_name | LE sql_name | GE sql_name | NE sql_name | EQ sql_name | EQ2 sql_name | NE2 sql_name );"; }
        }

    }

    const string DFA10_eotS =
        "\x04\uffff";
    const string DFA10_eofS =
        "\x02\x02\x02\uffff";
    const string DFA10_minS =
        "\x01\x37\x01\x06\x02\uffff";
    const string DFA10_maxS =
        "\x02\x38\x02\uffff";
    const string DFA10_acceptS =
        "\x02\uffff\x01\x02\x01\x01";
    const string DFA10_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA10_transitionS = {
            "\x01\x03\x01\x01",
            "\x1a\x03\x01\uffff\x05\x03\x03\uffff\x0a\x03\x05\uffff\x01"+
            "\x01",
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
            get { return "()* loopback of 123:10: ( ( COMMA | ( ( ENDLINE )+ ) ) factor )*"; }
        }

    }

 

    public static readonly BitSet FOLLOW_SQL_LITERAL_in_sql_name44 = new BitSet(new ulong[]{0x0000000000000022UL});
    public static readonly BitSet FOLLOW_DOT_in_sql_name51 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_SQL_LITERAL_in_sql_name55 = new BitSet(new ulong[]{0x0000000000000022UL});
    public static readonly BitSet FOLLOW_YEAR_in_specification76 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DATE_in_specification86 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_HOUR_ANY_MINUTE_in_specification99 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_FLOW_MONTH_in_specification110 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_FLOW_DAY_in_specification120 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_YEAR_MONTH_in_specification130 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_JAN_in_specification141 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_FEB_in_specification149 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_MAR_in_specification157 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_APR_in_specification165 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_MAY_in_specification173 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_JUN_in_specification181 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_JUL_in_specification189 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_AUG_in_specification197 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_SEP_in_specification205 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_OCT_in_specification213 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NOV_in_specification221 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_DEC_in_specification229 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_MON_in_specification240 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_TUE_in_specification248 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_WED_in_specification256 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_THU_in_specification264 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_FRI_in_specification272 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_SAT_in_specification280 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_SUN_in_specification288 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_LAST_in_specification299 = new BitSet(new ulong[]{0x0000000100000000UL});
    public static readonly BitSet FOLLOW_T_HOUR_in_specification301 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_THIS_in_specification309 = new BitSet(new ulong[]{0x0000000100000000UL});
    public static readonly BitSet FOLLOW_T_HOUR_in_specification311 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NEXT_in_specification319 = new BitSet(new ulong[]{0x0000000100000000UL});
    public static readonly BitSet FOLLOW_T_HOUR_in_specification321 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_YESTERDAY_in_specification330 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_TODAY_in_specification338 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_TOMORROW_in_specification346 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_LAST_in_specification357 = new BitSet(new ulong[]{0x0000004000000000UL});
    public static readonly BitSet FOLLOW_T_WEEK_in_specification359 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_THIS_in_specification367 = new BitSet(new ulong[]{0x0000004000000000UL});
    public static readonly BitSet FOLLOW_T_WEEK_in_specification369 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NEXT_in_specification377 = new BitSet(new ulong[]{0x0000004000000000UL});
    public static readonly BitSet FOLLOW_T_WEEK_in_specification379 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_LAST_in_specification388 = new BitSet(new ulong[]{0x0000008000000000UL});
    public static readonly BitSet FOLLOW_T_MONTH_in_specification390 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_THIS_in_specification398 = new BitSet(new ulong[]{0x0000008000000000UL});
    public static readonly BitSet FOLLOW_T_MONTH_in_specification400 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NEXT_in_specification408 = new BitSet(new ulong[]{0x0000008000000000UL});
    public static readonly BitSet FOLLOW_T_MONTH_in_specification410 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_LAST_in_specification421 = new BitSet(new ulong[]{0x0000010000000000UL});
    public static readonly BitSet FOLLOW_T_YEAR_in_specification423 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_THIS_in_specification431 = new BitSet(new ulong[]{0x0000010000000000UL});
    public static readonly BitSet FOLLOW_T_YEAR_in_specification433 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NEXT_in_specification441 = new BitSet(new ulong[]{0x0000010000000000UL});
    public static readonly BitSet FOLLOW_T_YEAR_in_specification443 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EQ_in_specification454 = new BitSet(new ulong[]{0x0000000000000080UL});
    public static readonly BitSet FOLLOW_DATE_in_specification458 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_specification468 = new BitSet(new ulong[]{0x0000000000000080UL});
    public static readonly BitSet FOLLOW_DATE_in_specification472 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LE_in_specification482 = new BitSet(new ulong[]{0x0000000000000080UL});
    public static readonly BitSet FOLLOW_DATE_in_specification486 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GT_in_specification496 = new BitSet(new ulong[]{0x0000000000000080UL});
    public static readonly BitSet FOLLOW_DATE_in_specification500 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GE_in_specification510 = new BitSet(new ulong[]{0x0000000000000080UL});
    public static readonly BitSet FOLLOW_DATE_in_specification514 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NE_in_specification524 = new BitSet(new ulong[]{0x0000000000000080UL});
    public static readonly BitSet FOLLOW_DATE_in_specification528 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DATE_in_specification539 = new BitSet(new ulong[]{0x0060000000000000UL});
    public static readonly BitSet FOLLOW_time_noexact_in_specification541 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EQ_in_specification551 = new BitSet(new ulong[]{0x0000000000000080UL});
    public static readonly BitSet FOLLOW_DATE_in_specification555 = new BitSet(new ulong[]{0x0060000000000000UL});
    public static readonly BitSet FOLLOW_time_noexact_in_specification557 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DATE_in_specification568 = new BitSet(new ulong[]{0x0010000000000000UL});
    public static readonly BitSet FOLLOW_time_exact_in_specification570 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EQ_in_specification580 = new BitSet(new ulong[]{0x0000000000000080UL});
    public static readonly BitSet FOLLOW_DATE_in_specification584 = new BitSet(new ulong[]{0x0010000000000000UL});
    public static readonly BitSet FOLLOW_time_exact_in_specification586 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_specification599 = new BitSet(new ulong[]{0x0000000000000080UL});
    public static readonly BitSet FOLLOW_DATE_in_specification603 = new BitSet(new ulong[]{0x0070000000000000UL});
    public static readonly BitSet FOLLOW_time_in_specification607 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LE_in_specification617 = new BitSet(new ulong[]{0x0000000000000080UL});
    public static readonly BitSet FOLLOW_DATE_in_specification621 = new BitSet(new ulong[]{0x0070000000000000UL});
    public static readonly BitSet FOLLOW_time_in_specification625 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GT_in_specification635 = new BitSet(new ulong[]{0x0000000000000080UL});
    public static readonly BitSet FOLLOW_DATE_in_specification639 = new BitSet(new ulong[]{0x0070000000000000UL});
    public static readonly BitSet FOLLOW_time_in_specification643 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GE_in_specification653 = new BitSet(new ulong[]{0x0000000000000080UL});
    public static readonly BitSet FOLLOW_DATE_in_specification657 = new BitSet(new ulong[]{0x0070000000000000UL});
    public static readonly BitSet FOLLOW_time_in_specification661 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NULL_in_specification669 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NOT_in_specification677 = new BitSet(new ulong[]{0x0000800000000000UL});
    public static readonly BitSet FOLLOW_T_NULL_in_specification679 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_specification690 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_sql_name_in_specification692 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GT_in_specification701 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_sql_name_in_specification703 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LE_in_specification712 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_sql_name_in_specification714 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GE_in_specification723 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_sql_name_in_specification725 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NE_in_specification734 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_sql_name_in_specification736 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EQ_in_specification745 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_sql_name_in_specification747 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EQ2_in_specification755 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_sql_name_in_specification757 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NE2_in_specification766 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_sql_name_in_specification768 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DATE_in_interval787 = new BitSet(new ulong[]{0x0008000000000000UL});
    public static readonly BitSet FOLLOW_MINUS_in_interval789 = new BitSet(new ulong[]{0x0000000000000080UL});
    public static readonly BitSet FOLLOW_DATE_in_interval793 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DATE_in_interval803 = new BitSet(new ulong[]{0x0070000000000000UL});
    public static readonly BitSet FOLLOW_time_in_interval807 = new BitSet(new ulong[]{0x0008000000000000UL});
    public static readonly BitSet FOLLOW_MINUS_in_interval809 = new BitSet(new ulong[]{0x0000000000000080UL});
    public static readonly BitSet FOLLOW_DATE_in_interval813 = new BitSet(new ulong[]{0x0070000000000000UL});
    public static readonly BitSet FOLLOW_time_in_interval817 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_time_exact_in_time830 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_time_noexact_in_time834 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_TIME_SECOND_FRACTION_in_time_exact849 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_TIME_MINUE_in_time_noexact865 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_TIME_SECOND_in_time_noexact873 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_specification_in_element885 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_interval_in_element889 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_element_in_factor901 = new BitSet(new ulong[]{0x0007FE3EFFFFFFC2UL});
    public static readonly BitSet FOLLOW_factor_in_list912 = new BitSet(new ulong[]{0x0180000000000002UL});
    public static readonly BitSet FOLLOW_COMMA_in_list917 = new BitSet(new ulong[]{0x0007FE3EFFFFFFC0UL});
    public static readonly BitSet FOLLOW_ENDLINE_in_list922 = new BitSet(new ulong[]{0x0107FE3EFFFFFFC0UL});
    public static readonly BitSet FOLLOW_factor_in_list929 = new BitSet(new ulong[]{0x0180000000000002UL});
    public static readonly BitSet FOLLOW_ENDLINE_in_list935 = new BitSet(new ulong[]{0x0100000000000002UL});
    public static readonly BitSet FOLLOW_list_in_expr945 = new BitSet(new ulong[]{0x0000000000000002UL});

}
