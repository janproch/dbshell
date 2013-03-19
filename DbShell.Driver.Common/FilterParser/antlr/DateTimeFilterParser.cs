// $ANTLR 3.2 Sep 23, 2009 12:02:23 DateTimeFilter.g 2013-03-19 20:36:20

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
		"TIME", 
		"T_NULL", 
		"T_NOT", 
		"MINUS", 
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

    public const int LT = 40;
    public const int FLOW_MONTH = 7;
    public const int T_AUG = 17;
    public const int YEAR = 4;
    public const int HOUR_ANY_MINUTE = 6;
    public const int T_OCT = 19;
    public const int T_NEXT = 32;
    public const int EOF = -1;
    public const int T_SEP = 18;
    public const int T_SAT = 27;
    public const int YEAR_MONTH = 9;
    public const int TIME = 45;
    public const int COMMA = 49;
    public const int T_NULL = 46;
    public const int T_SUN = 28;
    public const int T_WED = 24;
    public const int T_FRI = 26;
    public const int FLOW_DAY = 8;
    public const int DIGIT = 51;
    public const int EQ = 39;
    public const int T_YESTERDAY = 33;
    public const int NE = 44;
    public const int T_WEEK = 36;
    public const int D = 68;
    public const int E = 59;
    public const int F = 70;
    public const int GE = 43;
    public const int T_APR = 13;
    public const int G = 73;
    public const int A = 53;
    public const int B = 71;
    public const int T_THIS = 31;
    public const int C = 74;
    public const int T_TUE = 23;
    public const int T_TOMORROW = 35;
    public const int L = 52;
    public const int M = 66;
    public const int N = 58;
    public const int O = 61;
    public const int H = 56;
    public const int I = 57;
    public const int J = 69;
    public const int K = 65;
    public const int T_LAST = 29;
    public const int U = 62;
    public const int T = 55;
    public const int WHITESPACE = 76;
    public const int W = 64;
    public const int V = 75;
    public const int T_YEAR = 38;
    public const int Q = 77;
    public const int P = 72;
    public const int S = 54;
    public const int T_MONTH = 37;
    public const int R = 63;
    public const int MINUS = 48;
    public const int Y = 67;
    public const int X = 60;
    public const int T_DEC = 21;
    public const int Z = 78;
    public const int T_THU = 25;
    public const int T_HOUR = 30;
    public const int T_JAN = 10;
    public const int T_JUN = 15;
    public const int GT = 42;
    public const int ENDLINE = 50;
    public const int T_MON = 22;
    public const int T_TODAY = 34;
    public const int T_MAY = 14;
    public const int T_NOT = 47;
    public const int DATE = 5;
    public const int T_NOV = 20;
    public const int T_FEB = 11;
    public const int LE = 41;
    public const int T_MAR = 12;
    public const int T_JUL = 16;

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
    // DateTimeFilter.g:14:1: specification : (y= YEAR | d= DATE | d= HOUR_ANY_MINUTE | d= FLOW_MONTH | d= FLOW_DAY | d= YEAR_MONTH | T_JAN | T_FEB | T_MAR | T_APR | T_MAY | T_JUN | T_JUL | T_AUG | T_SEP | T_OCT | T_NOV | T_DEC | T_MON | T_TUE | T_WED | T_THU | T_FRI | T_SAT | T_SUN | T_LAST T_HOUR | T_THIS T_HOUR | T_NEXT T_HOUR | T_YESTERDAY | T_TODAY | T_TOMORROW | T_LAST T_WEEK | T_THIS T_WEEK | T_NEXT T_WEEK | T_LAST T_MONTH | T_THIS T_MONTH | T_NEXT T_MONTH | T_LAST T_YEAR | T_THIS T_YEAR | T_NEXT T_YEAR | EQ d= DATE | LT d= DATE | LE d= DATE | GT d= DATE | GE d= DATE | NE d= DATE | LT d= DATE t= TIME | LE d= DATE t= TIME | GT d= DATE t= TIME | GE d= DATE t= TIME | T_NULL | T_NOT T_NULL );
    public DateTimeFilterParser.specification_return specification() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.specification_return retval = new DateTimeFilterParser.specification_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken y = null;
        IToken d = null;
        IToken t = null;
        IToken T_JAN1 = null;
        IToken T_FEB2 = null;
        IToken T_MAR3 = null;
        IToken T_APR4 = null;
        IToken T_MAY5 = null;
        IToken T_JUN6 = null;
        IToken T_JUL7 = null;
        IToken T_AUG8 = null;
        IToken T_SEP9 = null;
        IToken T_OCT10 = null;
        IToken T_NOV11 = null;
        IToken T_DEC12 = null;
        IToken T_MON13 = null;
        IToken T_TUE14 = null;
        IToken T_WED15 = null;
        IToken T_THU16 = null;
        IToken T_FRI17 = null;
        IToken T_SAT18 = null;
        IToken T_SUN19 = null;
        IToken T_LAST20 = null;
        IToken T_HOUR21 = null;
        IToken T_THIS22 = null;
        IToken T_HOUR23 = null;
        IToken T_NEXT24 = null;
        IToken T_HOUR25 = null;
        IToken T_YESTERDAY26 = null;
        IToken T_TODAY27 = null;
        IToken T_TOMORROW28 = null;
        IToken T_LAST29 = null;
        IToken T_WEEK30 = null;
        IToken T_THIS31 = null;
        IToken T_WEEK32 = null;
        IToken T_NEXT33 = null;
        IToken T_WEEK34 = null;
        IToken T_LAST35 = null;
        IToken T_MONTH36 = null;
        IToken T_THIS37 = null;
        IToken T_MONTH38 = null;
        IToken T_NEXT39 = null;
        IToken T_MONTH40 = null;
        IToken T_LAST41 = null;
        IToken T_YEAR42 = null;
        IToken T_THIS43 = null;
        IToken T_YEAR44 = null;
        IToken T_NEXT45 = null;
        IToken T_YEAR46 = null;
        IToken EQ47 = null;
        IToken LT48 = null;
        IToken LE49 = null;
        IToken GT50 = null;
        IToken GE51 = null;
        IToken NE52 = null;
        IToken LT53 = null;
        IToken LE54 = null;
        IToken GT55 = null;
        IToken GE56 = null;
        IToken T_NULL57 = null;
        IToken T_NOT58 = null;
        IToken T_NULL59 = null;

        object y_tree=null;
        object d_tree=null;
        object t_tree=null;
        object T_JAN1_tree=null;
        object T_FEB2_tree=null;
        object T_MAR3_tree=null;
        object T_APR4_tree=null;
        object T_MAY5_tree=null;
        object T_JUN6_tree=null;
        object T_JUL7_tree=null;
        object T_AUG8_tree=null;
        object T_SEP9_tree=null;
        object T_OCT10_tree=null;
        object T_NOV11_tree=null;
        object T_DEC12_tree=null;
        object T_MON13_tree=null;
        object T_TUE14_tree=null;
        object T_WED15_tree=null;
        object T_THU16_tree=null;
        object T_FRI17_tree=null;
        object T_SAT18_tree=null;
        object T_SUN19_tree=null;
        object T_LAST20_tree=null;
        object T_HOUR21_tree=null;
        object T_THIS22_tree=null;
        object T_HOUR23_tree=null;
        object T_NEXT24_tree=null;
        object T_HOUR25_tree=null;
        object T_YESTERDAY26_tree=null;
        object T_TODAY27_tree=null;
        object T_TOMORROW28_tree=null;
        object T_LAST29_tree=null;
        object T_WEEK30_tree=null;
        object T_THIS31_tree=null;
        object T_WEEK32_tree=null;
        object T_NEXT33_tree=null;
        object T_WEEK34_tree=null;
        object T_LAST35_tree=null;
        object T_MONTH36_tree=null;
        object T_THIS37_tree=null;
        object T_MONTH38_tree=null;
        object T_NEXT39_tree=null;
        object T_MONTH40_tree=null;
        object T_LAST41_tree=null;
        object T_YEAR42_tree=null;
        object T_THIS43_tree=null;
        object T_YEAR44_tree=null;
        object T_NEXT45_tree=null;
        object T_YEAR46_tree=null;
        object EQ47_tree=null;
        object LT48_tree=null;
        object LE49_tree=null;
        object GT50_tree=null;
        object GE51_tree=null;
        object NE52_tree=null;
        object LT53_tree=null;
        object LE54_tree=null;
        object GT55_tree=null;
        object GE56_tree=null;
        object T_NULL57_tree=null;
        object T_NOT58_tree=null;
        object T_NULL59_tree=null;

        try 
    	{
            // DateTimeFilter.g:14:14: (y= YEAR | d= DATE | d= HOUR_ANY_MINUTE | d= FLOW_MONTH | d= FLOW_DAY | d= YEAR_MONTH | T_JAN | T_FEB | T_MAR | T_APR | T_MAY | T_JUN | T_JUL | T_AUG | T_SEP | T_OCT | T_NOV | T_DEC | T_MON | T_TUE | T_WED | T_THU | T_FRI | T_SAT | T_SUN | T_LAST T_HOUR | T_THIS T_HOUR | T_NEXT T_HOUR | T_YESTERDAY | T_TODAY | T_TOMORROW | T_LAST T_WEEK | T_THIS T_WEEK | T_NEXT T_WEEK | T_LAST T_MONTH | T_THIS T_MONTH | T_NEXT T_MONTH | T_LAST T_YEAR | T_THIS T_YEAR | T_NEXT T_YEAR | EQ d= DATE | LT d= DATE | LE d= DATE | GT d= DATE | GE d= DATE | NE d= DATE | LT d= DATE t= TIME | LE d= DATE t= TIME | GT d= DATE t= TIME | GE d= DATE t= TIME | T_NULL | T_NOT T_NULL )
            int alt1 = 52;
            alt1 = dfa1.Predict(input);
            switch (alt1) 
            {
                case 1 :
                    // DateTimeFilter.g:15:3: y= YEAR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	y=(IToken)Match(input,YEAR,FOLLOW_YEAR_in_specification44); 
                    		y_tree = (object)adaptor.Create(y);
                    		adaptor.AddChild(root_0, y_tree);

                    	 var d1=new DateTime(Int32.Parse(((y != null) ? y.Text : null)), 1, 1); AddDateTimeIntervalCondition(d1, d1.AddYears(1)); 

                    }
                    break;
                case 2 :
                    // DateTimeFilter.g:16:5: d= DATE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification54); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 AddDateCondition(((d != null) ? d.Text : null)); 

                    }
                    break;
                case 3 :
                    // DateTimeFilter.g:17:5: d= HOUR_ANY_MINUTE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	d=(IToken)Match(input,HOUR_ANY_MINUTE,FOLLOW_HOUR_ANY_MINUTE_in_specification64); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 AddAnyMinuteCondition(((d != null) ? d.Text : null)); 

                    }
                    break;
                case 4 :
                    // DateTimeFilter.g:18:5: d= FLOW_MONTH
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	d=(IToken)Match(input,FLOW_MONTH,FOLLOW_FLOW_MONTH_in_specification75); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 AddFlowMonthCondition(((d != null) ? d.Text : null)); 

                    }
                    break;
                case 5 :
                    // DateTimeFilter.g:19:5: d= FLOW_DAY
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	d=(IToken)Match(input,FLOW_DAY,FOLLOW_FLOW_DAY_in_specification85); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 AddFlowDayCondition(((d != null) ? d.Text : null)); 

                    }
                    break;
                case 6 :
                    // DateTimeFilter.g:20:5: d= YEAR_MONTH
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	d=(IToken)Match(input,YEAR_MONTH,FOLLOW_YEAR_MONTH_in_specification95); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 AddYearMonthCondition(((d != null) ? d.Text : null)); 

                    }
                    break;
                case 7 :
                    // DateTimeFilter.g:22:5: T_JAN
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_JAN1=(IToken)Match(input,T_JAN,FOLLOW_T_JAN_in_specification106); 
                    		T_JAN1_tree = (object)adaptor.Create(T_JAN1);
                    		adaptor.AddChild(root_0, T_JAN1_tree);

                    	 AddMonthCondition(1); 

                    }
                    break;
                case 8 :
                    // DateTimeFilter.g:23:5: T_FEB
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_FEB2=(IToken)Match(input,T_FEB,FOLLOW_T_FEB_in_specification114); 
                    		T_FEB2_tree = (object)adaptor.Create(T_FEB2);
                    		adaptor.AddChild(root_0, T_FEB2_tree);

                    	 AddMonthCondition(2); 

                    }
                    break;
                case 9 :
                    // DateTimeFilter.g:24:5: T_MAR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_MAR3=(IToken)Match(input,T_MAR,FOLLOW_T_MAR_in_specification122); 
                    		T_MAR3_tree = (object)adaptor.Create(T_MAR3);
                    		adaptor.AddChild(root_0, T_MAR3_tree);

                    	 AddMonthCondition(3); 

                    }
                    break;
                case 10 :
                    // DateTimeFilter.g:25:5: T_APR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_APR4=(IToken)Match(input,T_APR,FOLLOW_T_APR_in_specification130); 
                    		T_APR4_tree = (object)adaptor.Create(T_APR4);
                    		adaptor.AddChild(root_0, T_APR4_tree);

                    	 AddMonthCondition(4); 

                    }
                    break;
                case 11 :
                    // DateTimeFilter.g:26:5: T_MAY
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_MAY5=(IToken)Match(input,T_MAY,FOLLOW_T_MAY_in_specification138); 
                    		T_MAY5_tree = (object)adaptor.Create(T_MAY5);
                    		adaptor.AddChild(root_0, T_MAY5_tree);

                    	 AddMonthCondition(5); 

                    }
                    break;
                case 12 :
                    // DateTimeFilter.g:27:5: T_JUN
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_JUN6=(IToken)Match(input,T_JUN,FOLLOW_T_JUN_in_specification146); 
                    		T_JUN6_tree = (object)adaptor.Create(T_JUN6);
                    		adaptor.AddChild(root_0, T_JUN6_tree);

                    	 AddMonthCondition(6); 

                    }
                    break;
                case 13 :
                    // DateTimeFilter.g:28:5: T_JUL
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_JUL7=(IToken)Match(input,T_JUL,FOLLOW_T_JUL_in_specification154); 
                    		T_JUL7_tree = (object)adaptor.Create(T_JUL7);
                    		adaptor.AddChild(root_0, T_JUL7_tree);

                    	 AddMonthCondition(7); 

                    }
                    break;
                case 14 :
                    // DateTimeFilter.g:29:5: T_AUG
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_AUG8=(IToken)Match(input,T_AUG,FOLLOW_T_AUG_in_specification162); 
                    		T_AUG8_tree = (object)adaptor.Create(T_AUG8);
                    		adaptor.AddChild(root_0, T_AUG8_tree);

                    	 AddMonthCondition(8); 

                    }
                    break;
                case 15 :
                    // DateTimeFilter.g:30:5: T_SEP
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_SEP9=(IToken)Match(input,T_SEP,FOLLOW_T_SEP_in_specification170); 
                    		T_SEP9_tree = (object)adaptor.Create(T_SEP9);
                    		adaptor.AddChild(root_0, T_SEP9_tree);

                    	 AddMonthCondition(9); 

                    }
                    break;
                case 16 :
                    // DateTimeFilter.g:31:5: T_OCT
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_OCT10=(IToken)Match(input,T_OCT,FOLLOW_T_OCT_in_specification178); 
                    		T_OCT10_tree = (object)adaptor.Create(T_OCT10);
                    		adaptor.AddChild(root_0, T_OCT10_tree);

                    	 AddMonthCondition(10); 

                    }
                    break;
                case 17 :
                    // DateTimeFilter.g:32:5: T_NOV
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NOV11=(IToken)Match(input,T_NOV,FOLLOW_T_NOV_in_specification186); 
                    		T_NOV11_tree = (object)adaptor.Create(T_NOV11);
                    		adaptor.AddChild(root_0, T_NOV11_tree);

                    	 AddMonthCondition(11); 

                    }
                    break;
                case 18 :
                    // DateTimeFilter.g:33:5: T_DEC
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_DEC12=(IToken)Match(input,T_DEC,FOLLOW_T_DEC_in_specification194); 
                    		T_DEC12_tree = (object)adaptor.Create(T_DEC12);
                    		adaptor.AddChild(root_0, T_DEC12_tree);

                    	 AddMonthCondition(12); 

                    }
                    break;
                case 19 :
                    // DateTimeFilter.g:35:5: T_MON
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_MON13=(IToken)Match(input,T_MON,FOLLOW_T_MON_in_specification205); 
                    		T_MON13_tree = (object)adaptor.Create(T_MON13);
                    		adaptor.AddChild(root_0, T_MON13_tree);

                    	 AddDayOfWeekCondition(1); 

                    }
                    break;
                case 20 :
                    // DateTimeFilter.g:36:5: T_TUE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_TUE14=(IToken)Match(input,T_TUE,FOLLOW_T_TUE_in_specification213); 
                    		T_TUE14_tree = (object)adaptor.Create(T_TUE14);
                    		adaptor.AddChild(root_0, T_TUE14_tree);

                    	 AddDayOfWeekCondition(2); 

                    }
                    break;
                case 21 :
                    // DateTimeFilter.g:37:5: T_WED
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_WED15=(IToken)Match(input,T_WED,FOLLOW_T_WED_in_specification221); 
                    		T_WED15_tree = (object)adaptor.Create(T_WED15);
                    		adaptor.AddChild(root_0, T_WED15_tree);

                    	 AddDayOfWeekCondition(3); 

                    }
                    break;
                case 22 :
                    // DateTimeFilter.g:38:5: T_THU
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_THU16=(IToken)Match(input,T_THU,FOLLOW_T_THU_in_specification229); 
                    		T_THU16_tree = (object)adaptor.Create(T_THU16);
                    		adaptor.AddChild(root_0, T_THU16_tree);

                    	 AddDayOfWeekCondition(4); 

                    }
                    break;
                case 23 :
                    // DateTimeFilter.g:39:5: T_FRI
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_FRI17=(IToken)Match(input,T_FRI,FOLLOW_T_FRI_in_specification237); 
                    		T_FRI17_tree = (object)adaptor.Create(T_FRI17);
                    		adaptor.AddChild(root_0, T_FRI17_tree);

                    	 AddDayOfWeekCondition(5); 

                    }
                    break;
                case 24 :
                    // DateTimeFilter.g:40:5: T_SAT
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_SAT18=(IToken)Match(input,T_SAT,FOLLOW_T_SAT_in_specification245); 
                    		T_SAT18_tree = (object)adaptor.Create(T_SAT18);
                    		adaptor.AddChild(root_0, T_SAT18_tree);

                    	 AddDayOfWeekCondition(6); 

                    }
                    break;
                case 25 :
                    // DateTimeFilter.g:41:5: T_SUN
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_SUN19=(IToken)Match(input,T_SUN,FOLLOW_T_SUN_in_specification253); 
                    		T_SUN19_tree = (object)adaptor.Create(T_SUN19);
                    		adaptor.AddChild(root_0, T_SUN19_tree);

                    	 AddDayOfWeekCondition(7); 

                    }
                    break;
                case 26 :
                    // DateTimeFilter.g:43:5: T_LAST T_HOUR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_LAST20=(IToken)Match(input,T_LAST,FOLLOW_T_LAST_in_specification264); 
                    		T_LAST20_tree = (object)adaptor.Create(T_LAST20);
                    		adaptor.AddChild(root_0, T_LAST20_tree);

                    	T_HOUR21=(IToken)Match(input,T_HOUR,FOLLOW_T_HOUR_in_specification266); 
                    		T_HOUR21_tree = (object)adaptor.Create(T_HOUR21);
                    		adaptor.AddChild(root_0, T_HOUR21_tree);

                    	 var h1 = new DateTime(Now.Year, Now.Month, Now.Day, Now.Hour, 0, 0); AddDateTimeIntervalCondition(h1 - TimeSpan.FromHours(1), h1); 

                    }
                    break;
                case 27 :
                    // DateTimeFilter.g:44:5: T_THIS T_HOUR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_THIS22=(IToken)Match(input,T_THIS,FOLLOW_T_THIS_in_specification274); 
                    		T_THIS22_tree = (object)adaptor.Create(T_THIS22);
                    		adaptor.AddChild(root_0, T_THIS22_tree);

                    	T_HOUR23=(IToken)Match(input,T_HOUR,FOLLOW_T_HOUR_in_specification276); 
                    		T_HOUR23_tree = (object)adaptor.Create(T_HOUR23);
                    		adaptor.AddChild(root_0, T_HOUR23_tree);

                    	 var h1 = new DateTime(Now.Year, Now.Month, Now.Day, Now.Hour, 0, 0); AddDateTimeIntervalCondition(h1, h1 + TimeSpan.FromHours(1)); 

                    }
                    break;
                case 28 :
                    // DateTimeFilter.g:45:5: T_NEXT T_HOUR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NEXT24=(IToken)Match(input,T_NEXT,FOLLOW_T_NEXT_in_specification284); 
                    		T_NEXT24_tree = (object)adaptor.Create(T_NEXT24);
                    		adaptor.AddChild(root_0, T_NEXT24_tree);

                    	T_HOUR25=(IToken)Match(input,T_HOUR,FOLLOW_T_HOUR_in_specification286); 
                    		T_HOUR25_tree = (object)adaptor.Create(T_HOUR25);
                    		adaptor.AddChild(root_0, T_HOUR25_tree);

                    	 var h1 = new DateTime(Now.Year, Now.Month, Now.Day, Now.Hour, 0, 0); AddDateTimeIntervalCondition(h1 + TimeSpan.FromHours(1), h1 + TimeSpan.FromHours(2)); 

                    }
                    break;
                case 29 :
                    // DateTimeFilter.g:47:5: T_YESTERDAY
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_YESTERDAY26=(IToken)Match(input,T_YESTERDAY,FOLLOW_T_YESTERDAY_in_specification295); 
                    		T_YESTERDAY26_tree = (object)adaptor.Create(T_YESTERDAY26);
                    		adaptor.AddChild(root_0, T_YESTERDAY26_tree);

                    	 AddDateTimeIntervalCondition(Now.Date-TimeSpan.FromDays(1), Now.Date); 

                    }
                    break;
                case 30 :
                    // DateTimeFilter.g:48:5: T_TODAY
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_TODAY27=(IToken)Match(input,T_TODAY,FOLLOW_T_TODAY_in_specification303); 
                    		T_TODAY27_tree = (object)adaptor.Create(T_TODAY27);
                    		adaptor.AddChild(root_0, T_TODAY27_tree);

                    	 AddDateTimeIntervalCondition(Now.Date, Now.Date+TimeSpan.FromDays(1)); 

                    }
                    break;
                case 31 :
                    // DateTimeFilter.g:49:5: T_TOMORROW
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_TOMORROW28=(IToken)Match(input,T_TOMORROW,FOLLOW_T_TOMORROW_in_specification311); 
                    		T_TOMORROW28_tree = (object)adaptor.Create(T_TOMORROW28);
                    		adaptor.AddChild(root_0, T_TOMORROW28_tree);

                    	 AddDateTimeIntervalCondition(Now.Date+TimeSpan.FromDays(1), Now.Date+TimeSpan.FromDays(2)); 

                    }
                    break;
                case 32 :
                    // DateTimeFilter.g:51:5: T_LAST T_WEEK
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_LAST29=(IToken)Match(input,T_LAST,FOLLOW_T_LAST_in_specification322); 
                    		T_LAST29_tree = (object)adaptor.Create(T_LAST29);
                    		adaptor.AddChild(root_0, T_LAST29_tree);

                    	T_WEEK30=(IToken)Match(input,T_WEEK,FOLLOW_T_WEEK_in_specification324); 
                    		T_WEEK30_tree = (object)adaptor.Create(T_WEEK30);
                    		adaptor.AddChild(root_0, T_WEEK30_tree);

                    	 var d1=GetFirstDayOfWeek(Now.Date); AddDateTimeIntervalCondition(d1-TimeSpan.FromDays(7), d1); 

                    }
                    break;
                case 33 :
                    // DateTimeFilter.g:52:5: T_THIS T_WEEK
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_THIS31=(IToken)Match(input,T_THIS,FOLLOW_T_THIS_in_specification332); 
                    		T_THIS31_tree = (object)adaptor.Create(T_THIS31);
                    		adaptor.AddChild(root_0, T_THIS31_tree);

                    	T_WEEK32=(IToken)Match(input,T_WEEK,FOLLOW_T_WEEK_in_specification334); 
                    		T_WEEK32_tree = (object)adaptor.Create(T_WEEK32);
                    		adaptor.AddChild(root_0, T_WEEK32_tree);

                    	 var d1=GetFirstDayOfWeek(Now.Date); AddDateTimeIntervalCondition(d1, d1+TimeSpan.FromDays(7)); 

                    }
                    break;
                case 34 :
                    // DateTimeFilter.g:53:5: T_NEXT T_WEEK
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NEXT33=(IToken)Match(input,T_NEXT,FOLLOW_T_NEXT_in_specification342); 
                    		T_NEXT33_tree = (object)adaptor.Create(T_NEXT33);
                    		adaptor.AddChild(root_0, T_NEXT33_tree);

                    	T_WEEK34=(IToken)Match(input,T_WEEK,FOLLOW_T_WEEK_in_specification344); 
                    		T_WEEK34_tree = (object)adaptor.Create(T_WEEK34);
                    		adaptor.AddChild(root_0, T_WEEK34_tree);

                    	 var d1=GetFirstDayOfWeek(Now.Date); AddDateTimeIntervalCondition(d1+TimeSpan.FromDays(7), d1+TimeSpan.FromDays(14)); 

                    }
                    break;
                case 35 :
                    // DateTimeFilter.g:55:5: T_LAST T_MONTH
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_LAST35=(IToken)Match(input,T_LAST,FOLLOW_T_LAST_in_specification353); 
                    		T_LAST35_tree = (object)adaptor.Create(T_LAST35);
                    		adaptor.AddChild(root_0, T_LAST35_tree);

                    	T_MONTH36=(IToken)Match(input,T_MONTH,FOLLOW_T_MONTH_in_specification355); 
                    		T_MONTH36_tree = (object)adaptor.Create(T_MONTH36);
                    		adaptor.AddChild(root_0, T_MONTH36_tree);

                    	 var d1=new DateTime(Now.Year, Now.Month, 1); AddDateTimeIntervalCondition(d1.AddMonths(-1), d1); 

                    }
                    break;
                case 36 :
                    // DateTimeFilter.g:56:5: T_THIS T_MONTH
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_THIS37=(IToken)Match(input,T_THIS,FOLLOW_T_THIS_in_specification363); 
                    		T_THIS37_tree = (object)adaptor.Create(T_THIS37);
                    		adaptor.AddChild(root_0, T_THIS37_tree);

                    	T_MONTH38=(IToken)Match(input,T_MONTH,FOLLOW_T_MONTH_in_specification365); 
                    		T_MONTH38_tree = (object)adaptor.Create(T_MONTH38);
                    		adaptor.AddChild(root_0, T_MONTH38_tree);

                    	 var d1=new DateTime(Now.Year, Now.Month, 1); AddDateTimeIntervalCondition(d1, d1.AddMonths(1)); 

                    }
                    break;
                case 37 :
                    // DateTimeFilter.g:57:5: T_NEXT T_MONTH
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NEXT39=(IToken)Match(input,T_NEXT,FOLLOW_T_NEXT_in_specification373); 
                    		T_NEXT39_tree = (object)adaptor.Create(T_NEXT39);
                    		adaptor.AddChild(root_0, T_NEXT39_tree);

                    	T_MONTH40=(IToken)Match(input,T_MONTH,FOLLOW_T_MONTH_in_specification375); 
                    		T_MONTH40_tree = (object)adaptor.Create(T_MONTH40);
                    		adaptor.AddChild(root_0, T_MONTH40_tree);

                    	 var d1=new DateTime(Now.Year, Now.Month, 1); AddDateTimeIntervalCondition(d1.AddMonths(1), d1.AddMonths(2)); 

                    }
                    break;
                case 38 :
                    // DateTimeFilter.g:59:5: T_LAST T_YEAR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_LAST41=(IToken)Match(input,T_LAST,FOLLOW_T_LAST_in_specification386); 
                    		T_LAST41_tree = (object)adaptor.Create(T_LAST41);
                    		adaptor.AddChild(root_0, T_LAST41_tree);

                    	T_YEAR42=(IToken)Match(input,T_YEAR,FOLLOW_T_YEAR_in_specification388); 
                    		T_YEAR42_tree = (object)adaptor.Create(T_YEAR42);
                    		adaptor.AddChild(root_0, T_YEAR42_tree);

                    	 var d1=new DateTime(Now.Year, 1, 1); AddDateTimeIntervalCondition(d1.AddYears(-1), d1); 

                    }
                    break;
                case 39 :
                    // DateTimeFilter.g:60:5: T_THIS T_YEAR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_THIS43=(IToken)Match(input,T_THIS,FOLLOW_T_THIS_in_specification396); 
                    		T_THIS43_tree = (object)adaptor.Create(T_THIS43);
                    		adaptor.AddChild(root_0, T_THIS43_tree);

                    	T_YEAR44=(IToken)Match(input,T_YEAR,FOLLOW_T_YEAR_in_specification398); 
                    		T_YEAR44_tree = (object)adaptor.Create(T_YEAR44);
                    		adaptor.AddChild(root_0, T_YEAR44_tree);

                    	 var d1=new DateTime(Now.Year, 1, 1); AddDateTimeIntervalCondition(d1, d1.AddYears(1)); 

                    }
                    break;
                case 40 :
                    // DateTimeFilter.g:61:5: T_NEXT T_YEAR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NEXT45=(IToken)Match(input,T_NEXT,FOLLOW_T_NEXT_in_specification406); 
                    		T_NEXT45_tree = (object)adaptor.Create(T_NEXT45);
                    		adaptor.AddChild(root_0, T_NEXT45_tree);

                    	T_YEAR46=(IToken)Match(input,T_YEAR,FOLLOW_T_YEAR_in_specification408); 
                    		T_YEAR46_tree = (object)adaptor.Create(T_YEAR46);
                    		adaptor.AddChild(root_0, T_YEAR46_tree);

                    	 var d1=new DateTime(Now.Year, 1, 1); AddDateTimeIntervalCondition(d1.AddYears(1), d1.AddYears(2)); 

                    }
                    break;
                case 41 :
                    // DateTimeFilter.g:63:5: EQ d= DATE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	EQ47=(IToken)Match(input,EQ,FOLLOW_EQ_in_specification419); 
                    		EQ47_tree = (object)adaptor.Create(EQ47);
                    		adaptor.AddChild(root_0, EQ47_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification423); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 var dt=ParseDate(((d != null) ? d.Text : null));AddDateTimeIntervalCondition(dt, dt + TimeSpan.FromDays(1)); 

                    }
                    break;
                case 42 :
                    // DateTimeFilter.g:64:5: LT d= DATE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LT48=(IToken)Match(input,LT,FOLLOW_LT_in_specification433); 
                    		LT48_tree = (object)adaptor.Create(LT48);
                    		adaptor.AddChild(root_0, LT48_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification437); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 var dt=ParseDate(((d != null) ? d.Text : null));AddDateTimeRelation(dt, "<"); 

                    }
                    break;
                case 43 :
                    // DateTimeFilter.g:65:5: LE d= DATE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LE49=(IToken)Match(input,LE,FOLLOW_LE_in_specification447); 
                    		LE49_tree = (object)adaptor.Create(LE49);
                    		adaptor.AddChild(root_0, LE49_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification451); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 var dt=ParseDate(((d != null) ? d.Text : null));AddDateTimeRelation(dt+TimeSpan.FromDays(1), "<"); 

                    }
                    break;
                case 44 :
                    // DateTimeFilter.g:66:5: GT d= DATE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GT50=(IToken)Match(input,GT,FOLLOW_GT_in_specification461); 
                    		GT50_tree = (object)adaptor.Create(GT50);
                    		adaptor.AddChild(root_0, GT50_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification465); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 var dt=ParseDate(((d != null) ? d.Text : null));AddDateTimeRelation(dt+TimeSpan.FromDays(1), ">="); 

                    }
                    break;
                case 45 :
                    // DateTimeFilter.g:67:5: GE d= DATE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GE51=(IToken)Match(input,GE,FOLLOW_GE_in_specification475); 
                    		GE51_tree = (object)adaptor.Create(GE51);
                    		adaptor.AddChild(root_0, GE51_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification479); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 var dt=ParseDate(((d != null) ? d.Text : null));AddDateTimeRelation(dt, ">="); 

                    }
                    break;
                case 46 :
                    // DateTimeFilter.g:68:5: NE d= DATE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NE52=(IToken)Match(input,NE,FOLLOW_NE_in_specification489); 
                    		NE52_tree = (object)adaptor.Create(NE52);
                    		adaptor.AddChild(root_0, NE52_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification493); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 var dt=ParseDate(((d != null) ? d.Text : null));AddDateTimeNotIntervalCondition(dt, dt + TimeSpan.FromDays(1)); 

                    }
                    break;
                case 47 :
                    // DateTimeFilter.g:70:5: LT d= DATE t= TIME
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LT53=(IToken)Match(input,LT,FOLLOW_LT_in_specification506); 
                    		LT53_tree = (object)adaptor.Create(LT53);
                    		adaptor.AddChild(root_0, LT53_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification510); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	t=(IToken)Match(input,TIME,FOLLOW_TIME_in_specification514); 
                    		t_tree = (object)adaptor.Create(t);
                    		adaptor.AddChild(root_0, t_tree);

                    	 var dt=ParseDate(((d != null) ? d.Text : null))+ParseTime(((t != null) ? t.Text : null));AddDateTimeRelation(dt, "<"); 

                    }
                    break;
                case 48 :
                    // DateTimeFilter.g:71:5: LE d= DATE t= TIME
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LE54=(IToken)Match(input,LE,FOLLOW_LE_in_specification524); 
                    		LE54_tree = (object)adaptor.Create(LE54);
                    		adaptor.AddChild(root_0, LE54_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification528); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	t=(IToken)Match(input,TIME,FOLLOW_TIME_in_specification532); 
                    		t_tree = (object)adaptor.Create(t);
                    		adaptor.AddChild(root_0, t_tree);

                    	 var dt=ParseDate(((d != null) ? d.Text : null))+ParseTime(((t != null) ? t.Text : null));AddDateTimeRelation(dt, "<="); 

                    }
                    break;
                case 49 :
                    // DateTimeFilter.g:72:5: GT d= DATE t= TIME
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GT55=(IToken)Match(input,GT,FOLLOW_GT_in_specification542); 
                    		GT55_tree = (object)adaptor.Create(GT55);
                    		adaptor.AddChild(root_0, GT55_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification546); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	t=(IToken)Match(input,TIME,FOLLOW_TIME_in_specification550); 
                    		t_tree = (object)adaptor.Create(t);
                    		adaptor.AddChild(root_0, t_tree);

                    	 var dt=ParseDate(((d != null) ? d.Text : null))+ParseTime(((t != null) ? t.Text : null));AddDateTimeRelation(dt, ">"); 

                    }
                    break;
                case 50 :
                    // DateTimeFilter.g:73:5: GE d= DATE t= TIME
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GE56=(IToken)Match(input,GE,FOLLOW_GE_in_specification560); 
                    		GE56_tree = (object)adaptor.Create(GE56);
                    		adaptor.AddChild(root_0, GE56_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification564); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	t=(IToken)Match(input,TIME,FOLLOW_TIME_in_specification568); 
                    		t_tree = (object)adaptor.Create(t);
                    		adaptor.AddChild(root_0, t_tree);

                    	 var dt=ParseDate(((d != null) ? d.Text : null))+ParseTime(((t != null) ? t.Text : null));AddDateTimeRelation(dt, ">="); 

                    }
                    break;
                case 51 :
                    // DateTimeFilter.g:74:5: T_NULL
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NULL57=(IToken)Match(input,T_NULL,FOLLOW_T_NULL_in_specification576); 
                    		T_NULL57_tree = (object)adaptor.Create(T_NULL57);
                    		adaptor.AddChild(root_0, T_NULL57_tree);

                    	 AddIsNullCondition(); 

                    }
                    break;
                case 52 :
                    // DateTimeFilter.g:75:5: T_NOT T_NULL
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NOT58=(IToken)Match(input,T_NOT,FOLLOW_T_NOT_in_specification584); 
                    		T_NOT58_tree = (object)adaptor.Create(T_NOT58);
                    		adaptor.AddChild(root_0, T_NOT58_tree);

                    	T_NULL59=(IToken)Match(input,T_NULL,FOLLOW_T_NULL_in_specification586); 
                    		T_NULL59_tree = (object)adaptor.Create(T_NULL59);
                    		adaptor.AddChild(root_0, T_NULL59_tree);

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
    // DateTimeFilter.g:78:1: interval : (d1= DATE MINUS d2= DATE | d1= DATE t1= TIME MINUS d2= DATE t2= TIME );
    public DateTimeFilterParser.interval_return interval() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.interval_return retval = new DateTimeFilterParser.interval_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken d1 = null;
        IToken d2 = null;
        IToken t1 = null;
        IToken t2 = null;
        IToken MINUS60 = null;
        IToken MINUS61 = null;

        object d1_tree=null;
        object d2_tree=null;
        object t1_tree=null;
        object t2_tree=null;
        object MINUS60_tree=null;
        object MINUS61_tree=null;

        try 
    	{
            // DateTimeFilter.g:78:10: (d1= DATE MINUS d2= DATE | d1= DATE t1= TIME MINUS d2= DATE t2= TIME )
            int alt2 = 2;
            int LA2_0 = input.LA(1);

            if ( (LA2_0 == DATE) )
            {
                int LA2_1 = input.LA(2);

                if ( (LA2_1 == MINUS) )
                {
                    alt2 = 1;
                }
                else if ( (LA2_1 == TIME) )
                {
                    alt2 = 2;
                }
                else 
                {
                    NoViableAltException nvae_d2s1 =
                        new NoViableAltException("", 2, 1, input);

                    throw nvae_d2s1;
                }
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
                    // DateTimeFilter.g:79:3: d1= DATE MINUS d2= DATE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	d1=(IToken)Match(input,DATE,FOLLOW_DATE_in_interval602); 
                    		d1_tree = (object)adaptor.Create(d1);
                    		adaptor.AddChild(root_0, d1_tree);

                    	MINUS60=(IToken)Match(input,MINUS,FOLLOW_MINUS_in_interval604); 
                    		MINUS60_tree = (object)adaptor.Create(MINUS60);
                    		adaptor.AddChild(root_0, MINUS60_tree);

                    	d2=(IToken)Match(input,DATE,FOLLOW_DATE_in_interval608); 
                    		d2_tree = (object)adaptor.Create(d2);
                    		adaptor.AddChild(root_0, d2_tree);

                    	 AddDateTimeIntervalCondition(ParseDate(((d1 != null) ? d1.Text : null)), ParseDate(((d2 != null) ? d2.Text : null)) + TimeSpan.FromDays(1)); 

                    }
                    break;
                case 2 :
                    // DateTimeFilter.g:80:5: d1= DATE t1= TIME MINUS d2= DATE t2= TIME
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	d1=(IToken)Match(input,DATE,FOLLOW_DATE_in_interval618); 
                    		d1_tree = (object)adaptor.Create(d1);
                    		adaptor.AddChild(root_0, d1_tree);

                    	t1=(IToken)Match(input,TIME,FOLLOW_TIME_in_interval622); 
                    		t1_tree = (object)adaptor.Create(t1);
                    		adaptor.AddChild(root_0, t1_tree);

                    	MINUS61=(IToken)Match(input,MINUS,FOLLOW_MINUS_in_interval624); 
                    		MINUS61_tree = (object)adaptor.Create(MINUS61);
                    		adaptor.AddChild(root_0, MINUS61_tree);

                    	d2=(IToken)Match(input,DATE,FOLLOW_DATE_in_interval628); 
                    		d2_tree = (object)adaptor.Create(d2);
                    		adaptor.AddChild(root_0, d2_tree);

                    	t2=(IToken)Match(input,TIME,FOLLOW_TIME_in_interval632); 
                    		t2_tree = (object)adaptor.Create(t2);
                    		adaptor.AddChild(root_0, t2_tree);


                    	    AddDateTimeIntervalCondition(ParseDate(((d1 != null) ? d1.Text : null)) + ParseTime(((t1 != null) ? t1.Text : null)), ParseDate(((d2 != null) ? d2.Text : null)) + ParseTime(((t2 != null) ? t2.Text : null)));    
                    	  

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
    // DateTimeFilter.g:85:1: element : ( specification | interval );
    public DateTimeFilterParser.element_return element() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.element_return retval = new DateTimeFilterParser.element_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        DateTimeFilterParser.specification_return specification62 = default(DateTimeFilterParser.specification_return);

        DateTimeFilterParser.interval_return interval63 = default(DateTimeFilterParser.interval_return);



        try 
    	{
            // DateTimeFilter.g:85:8: ( specification | interval )
            int alt3 = 2;
            int LA3_0 = input.LA(1);

            if ( (LA3_0 == YEAR || (LA3_0 >= HOUR_ANY_MINUTE && LA3_0 <= T_LAST) || (LA3_0 >= T_THIS && LA3_0 <= T_TOMORROW) || (LA3_0 >= EQ && LA3_0 <= NE) || (LA3_0 >= T_NULL && LA3_0 <= T_NOT)) )
            {
                alt3 = 1;
            }
            else if ( (LA3_0 == DATE) )
            {
                int LA3_2 = input.LA(2);

                if ( (LA3_2 == TIME || LA3_2 == MINUS) )
                {
                    alt3 = 2;
                }
                else if ( (LA3_2 == EOF || (LA3_2 >= YEAR && LA3_2 <= T_LAST) || (LA3_2 >= T_THIS && LA3_2 <= T_TOMORROW) || (LA3_2 >= EQ && LA3_2 <= NE) || (LA3_2 >= T_NULL && LA3_2 <= T_NOT) || (LA3_2 >= COMMA && LA3_2 <= ENDLINE)) )
                {
                    alt3 = 1;
                }
                else 
                {
                    NoViableAltException nvae_d3s2 =
                        new NoViableAltException("", 3, 2, input);

                    throw nvae_d3s2;
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
                    // DateTimeFilter.g:86:3: specification
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_specification_in_element645);
                    	specification62 = specification();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, specification62.Tree);

                    }
                    break;
                case 2 :
                    // DateTimeFilter.g:86:19: interval
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_interval_in_element649);
                    	interval63 = interval();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, interval63.Tree);

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
    // DateTimeFilter.g:88:1: factor : ( element )+ ;
    public DateTimeFilterParser.factor_return factor() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.factor_return retval = new DateTimeFilterParser.factor_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        DateTimeFilterParser.element_return element64 = default(DateTimeFilterParser.element_return);



        try 
    	{
            // DateTimeFilter.g:88:8: ( ( element )+ )
            // DateTimeFilter.g:89:3: ( element )+
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// DateTimeFilter.g:89:3: ( element )+
            	int cnt4 = 0;
            	do 
            	{
            	    int alt4 = 2;
            	    int LA4_0 = input.LA(1);

            	    if ( ((LA4_0 >= YEAR && LA4_0 <= T_LAST) || (LA4_0 >= T_THIS && LA4_0 <= T_TOMORROW) || (LA4_0 >= EQ && LA4_0 <= NE) || (LA4_0 >= T_NULL && LA4_0 <= T_NOT)) )
            	    {
            	        alt4 = 1;
            	    }


            	    switch (alt4) 
            		{
            			case 1 :
            			    // DateTimeFilter.g:89:3: element
            			    {
            			    	PushFollow(FOLLOW_element_in_factor661);
            			    	element64 = element();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, element64.Tree);

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
    // DateTimeFilter.g:91:1: list : factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )* ;
    public DateTimeFilterParser.list_return list() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.list_return retval = new DateTimeFilterParser.list_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken COMMA66 = null;
        IToken ENDLINE67 = null;
        IToken ENDLINE69 = null;
        DateTimeFilterParser.factor_return factor65 = default(DateTimeFilterParser.factor_return);

        DateTimeFilterParser.factor_return factor68 = default(DateTimeFilterParser.factor_return);


        object COMMA66_tree=null;
        object ENDLINE67_tree=null;
        object ENDLINE69_tree=null;

        try 
    	{
            // DateTimeFilter.g:91:5: ( factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )* )
            // DateTimeFilter.g:92:3: factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_factor_in_list672);
            	factor65 = factor();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, factor65.Tree);
            	// DateTimeFilter.g:92:10: ( ( COMMA | ( ( ENDLINE )+ ) ) factor )*
            	do 
            	{
            	    int alt7 = 2;
            	    alt7 = dfa7.Predict(input);
            	    switch (alt7) 
            		{
            			case 1 :
            			    // DateTimeFilter.g:92:12: ( COMMA | ( ( ENDLINE )+ ) ) factor
            			    {
            			    	// DateTimeFilter.g:92:12: ( COMMA | ( ( ENDLINE )+ ) )
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
            			    	        // DateTimeFilter.g:92:13: COMMA
            			    	        {
            			    	        	COMMA66=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_list677); 
            			    	        		COMMA66_tree = (object)adaptor.Create(COMMA66);
            			    	        		adaptor.AddChild(root_0, COMMA66_tree);


            			    	        }
            			    	        break;
            			    	    case 2 :
            			    	        // DateTimeFilter.g:92:21: ( ( ENDLINE )+ )
            			    	        {
            			    	        	// DateTimeFilter.g:92:21: ( ( ENDLINE )+ )
            			    	        	// DateTimeFilter.g:92:22: ( ENDLINE )+
            			    	        	{
            			    	        		// DateTimeFilter.g:92:22: ( ENDLINE )+
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
            			    	        				    // DateTimeFilter.g:92:22: ENDLINE
            			    	        				    {
            			    	        				    	ENDLINE67=(IToken)Match(input,ENDLINE,FOLLOW_ENDLINE_in_list682); 
            			    	        				    		ENDLINE67_tree = (object)adaptor.Create(ENDLINE67);
            			    	        				    		adaptor.AddChild(root_0, ENDLINE67_tree);


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
            			    	PushFollow(FOLLOW_factor_in_list689);
            			    	factor68 = factor();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, factor68.Tree);

            			    }
            			    break;

            			default:
            			    goto loop7;
            	    }
            	} while (true);

            	loop7:
            		;	// Stops C# compiler whining that label 'loop7' has no statements

            	// DateTimeFilter.g:92:67: ( ENDLINE )*
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
            			    // DateTimeFilter.g:92:67: ENDLINE
            			    {
            			    	ENDLINE69=(IToken)Match(input,ENDLINE,FOLLOW_ENDLINE_in_list695); 
            			    		ENDLINE69_tree = (object)adaptor.Create(ENDLINE69);
            			    		adaptor.AddChild(root_0, ENDLINE69_tree);


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
    // DateTimeFilter.g:94:1: expr : list ;
    public DateTimeFilterParser.expr_return expr() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.expr_return retval = new DateTimeFilterParser.expr_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        DateTimeFilterParser.list_return list70 = default(DateTimeFilterParser.list_return);



        try 
    	{
            // DateTimeFilter.g:94:5: ( list )
            // DateTimeFilter.g:94:7: list
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_list_in_expr705);
            	list70 = list();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, list70.Tree);

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


   	protected DFA1 dfa1;
   	protected DFA7 dfa7;
	private void InitializeCyclicDFAs()
	{
    	this.dfa1 = new DFA1(this);
    	this.dfa7 = new DFA7(this);
	}

    const string DFA1_eotS =
        "\x40\uffff";
    const string DFA1_eofS =
        "\x34\uffff\x01\x39\x01\x3b\x01\x3d\x01\x3f\x08\uffff";
    const string DFA1_minS =
        "\x01\x04\x19\uffff\x03\x1e\x04\uffff\x04\x05\x0f\uffff\x04\x04"+
        "\x08\uffff";
    const string DFA1_maxS =
        "\x01\x2f\x19\uffff\x03\x26\x04\uffff\x04\x05\x0f\uffff\x04\x32"+
        "\x08\uffff";
    const string DFA1_acceptS =
        "\x01\uffff\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06\x01"+
        "\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x01\x0c\x01\x0d\x01\x0e\x01"+
        "\x0f\x01\x10\x01\x11\x01\x12\x01\x13\x01\x14\x01\x15\x01\x16\x01"+
        "\x17\x01\x18\x01\x19\x03\uffff\x01\x1d\x01\x1e\x01\x1f\x01\x29\x04"+
        "\uffff\x01\x2e\x01\x33\x01\x34\x01\x1a\x01\x20\x01\x23\x01\x26\x01"+
        "\x1b\x01\x21\x01\x24\x01\x27\x01\x1c\x01\x22\x01\x25\x01\x28\x04"+
        "\uffff\x01\x2f\x01\x2a\x01\x30\x01\x2b\x01\x31\x01\x2c\x01\x32\x01"+
        "\x2d";
    const string DFA1_specialS =
        "\x40\uffff}>";
    static readonly string[] DFA1_transitionS = {
            "\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06\x01\x07\x01"+
            "\x08\x01\x09\x01\x0a\x01\x0b\x01\x0c\x01\x0d\x01\x0e\x01\x0f"+
            "\x01\x10\x01\x11\x01\x12\x01\x13\x01\x14\x01\x15\x01\x16\x01"+
            "\x17\x01\x18\x01\x19\x01\x1a\x01\uffff\x01\x1b\x01\x1c\x01\x1d"+
            "\x01\x1e\x01\x1f\x03\uffff\x01\x20\x01\x21\x01\x22\x01\x23\x01"+
            "\x24\x01\x25\x01\uffff\x01\x26\x01\x27",
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
            "",
            "",
            "\x01\x28\x05\uffff\x01\x29\x01\x2a\x01\x2b",
            "\x01\x2c\x05\uffff\x01\x2d\x01\x2e\x01\x2f",
            "\x01\x30\x05\uffff\x01\x31\x01\x32\x01\x33",
            "",
            "",
            "",
            "",
            "\x01\x34",
            "\x01\x35",
            "\x01\x36",
            "\x01\x37",
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
            "\x1a\x39\x01\uffff\x05\x39\x03\uffff\x06\x39\x01\x38\x02\x39"+
            "\x01\uffff\x02\x39",
            "\x1a\x3b\x01\uffff\x05\x3b\x03\uffff\x06\x3b\x01\x3a\x02\x3b"+
            "\x01\uffff\x02\x3b",
            "\x1a\x3d\x01\uffff\x05\x3d\x03\uffff\x06\x3d\x01\x3c\x02\x3d"+
            "\x01\uffff\x02\x3d",
            "\x1a\x3f\x01\uffff\x05\x3f\x03\uffff\x06\x3f\x01\x3e\x02\x3f"+
            "\x01\uffff\x02\x3f",
            "",
            "",
            "",
            "",
            "",
            "",
            "",
            ""
    };

    static readonly short[] DFA1_eot = DFA.UnpackEncodedString(DFA1_eotS);
    static readonly short[] DFA1_eof = DFA.UnpackEncodedString(DFA1_eofS);
    static readonly char[] DFA1_min = DFA.UnpackEncodedStringToUnsignedChars(DFA1_minS);
    static readonly char[] DFA1_max = DFA.UnpackEncodedStringToUnsignedChars(DFA1_maxS);
    static readonly short[] DFA1_accept = DFA.UnpackEncodedString(DFA1_acceptS);
    static readonly short[] DFA1_special = DFA.UnpackEncodedString(DFA1_specialS);
    static readonly short[][] DFA1_transition = DFA.UnpackEncodedStringArray(DFA1_transitionS);

    protected class DFA1 : DFA
    {
        public DFA1(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 1;
            this.eot = DFA1_eot;
            this.eof = DFA1_eof;
            this.min = DFA1_min;
            this.max = DFA1_max;
            this.accept = DFA1_accept;
            this.special = DFA1_special;
            this.transition = DFA1_transition;

        }

        override public string Description
        {
            get { return "14:1: specification : (y= YEAR | d= DATE | d= HOUR_ANY_MINUTE | d= FLOW_MONTH | d= FLOW_DAY | d= YEAR_MONTH | T_JAN | T_FEB | T_MAR | T_APR | T_MAY | T_JUN | T_JUL | T_AUG | T_SEP | T_OCT | T_NOV | T_DEC | T_MON | T_TUE | T_WED | T_THU | T_FRI | T_SAT | T_SUN | T_LAST T_HOUR | T_THIS T_HOUR | T_NEXT T_HOUR | T_YESTERDAY | T_TODAY | T_TOMORROW | T_LAST T_WEEK | T_THIS T_WEEK | T_NEXT T_WEEK | T_LAST T_MONTH | T_THIS T_MONTH | T_NEXT T_MONTH | T_LAST T_YEAR | T_THIS T_YEAR | T_NEXT T_YEAR | EQ d= DATE | LT d= DATE | LE d= DATE | GT d= DATE | GE d= DATE | NE d= DATE | LT d= DATE t= TIME | LE d= DATE t= TIME | GT d= DATE t= TIME | GE d= DATE t= TIME | T_NULL | T_NOT T_NULL );"; }
        }

    }

    const string DFA7_eotS =
        "\x04\uffff";
    const string DFA7_eofS =
        "\x02\x02\x02\uffff";
    const string DFA7_minS =
        "\x01\x31\x01\x04\x02\uffff";
    const string DFA7_maxS =
        "\x02\x32\x02\uffff";
    const string DFA7_acceptS =
        "\x02\uffff\x01\x02\x01\x01";
    const string DFA7_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA7_transitionS = {
            "\x01\x03\x01\x01",
            "\x1a\x03\x01\uffff\x05\x03\x03\uffff\x06\x03\x01\uffff\x02"+
            "\x03\x02\uffff\x01\x01",
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
            get { return "()* loopback of 92:10: ( ( COMMA | ( ( ENDLINE )+ ) ) factor )*"; }
        }

    }

 

    public static readonly BitSet FOLLOW_YEAR_in_specification44 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DATE_in_specification54 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_HOUR_ANY_MINUTE_in_specification64 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_FLOW_MONTH_in_specification75 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_FLOW_DAY_in_specification85 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_YEAR_MONTH_in_specification95 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_JAN_in_specification106 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_FEB_in_specification114 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_MAR_in_specification122 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_APR_in_specification130 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_MAY_in_specification138 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_JUN_in_specification146 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_JUL_in_specification154 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_AUG_in_specification162 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_SEP_in_specification170 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_OCT_in_specification178 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NOV_in_specification186 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_DEC_in_specification194 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_MON_in_specification205 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_TUE_in_specification213 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_WED_in_specification221 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_THU_in_specification229 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_FRI_in_specification237 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_SAT_in_specification245 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_SUN_in_specification253 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_LAST_in_specification264 = new BitSet(new ulong[]{0x0000000040000000UL});
    public static readonly BitSet FOLLOW_T_HOUR_in_specification266 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_THIS_in_specification274 = new BitSet(new ulong[]{0x0000000040000000UL});
    public static readonly BitSet FOLLOW_T_HOUR_in_specification276 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NEXT_in_specification284 = new BitSet(new ulong[]{0x0000000040000000UL});
    public static readonly BitSet FOLLOW_T_HOUR_in_specification286 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_YESTERDAY_in_specification295 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_TODAY_in_specification303 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_TOMORROW_in_specification311 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_LAST_in_specification322 = new BitSet(new ulong[]{0x0000001000000000UL});
    public static readonly BitSet FOLLOW_T_WEEK_in_specification324 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_THIS_in_specification332 = new BitSet(new ulong[]{0x0000001000000000UL});
    public static readonly BitSet FOLLOW_T_WEEK_in_specification334 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NEXT_in_specification342 = new BitSet(new ulong[]{0x0000001000000000UL});
    public static readonly BitSet FOLLOW_T_WEEK_in_specification344 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_LAST_in_specification353 = new BitSet(new ulong[]{0x0000002000000000UL});
    public static readonly BitSet FOLLOW_T_MONTH_in_specification355 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_THIS_in_specification363 = new BitSet(new ulong[]{0x0000002000000000UL});
    public static readonly BitSet FOLLOW_T_MONTH_in_specification365 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NEXT_in_specification373 = new BitSet(new ulong[]{0x0000002000000000UL});
    public static readonly BitSet FOLLOW_T_MONTH_in_specification375 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_LAST_in_specification386 = new BitSet(new ulong[]{0x0000004000000000UL});
    public static readonly BitSet FOLLOW_T_YEAR_in_specification388 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_THIS_in_specification396 = new BitSet(new ulong[]{0x0000004000000000UL});
    public static readonly BitSet FOLLOW_T_YEAR_in_specification398 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NEXT_in_specification406 = new BitSet(new ulong[]{0x0000004000000000UL});
    public static readonly BitSet FOLLOW_T_YEAR_in_specification408 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EQ_in_specification419 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_DATE_in_specification423 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_specification433 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_DATE_in_specification437 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LE_in_specification447 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_DATE_in_specification451 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GT_in_specification461 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_DATE_in_specification465 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GE_in_specification475 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_DATE_in_specification479 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NE_in_specification489 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_DATE_in_specification493 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_specification506 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_DATE_in_specification510 = new BitSet(new ulong[]{0x0000200000000000UL});
    public static readonly BitSet FOLLOW_TIME_in_specification514 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LE_in_specification524 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_DATE_in_specification528 = new BitSet(new ulong[]{0x0000200000000000UL});
    public static readonly BitSet FOLLOW_TIME_in_specification532 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GT_in_specification542 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_DATE_in_specification546 = new BitSet(new ulong[]{0x0000200000000000UL});
    public static readonly BitSet FOLLOW_TIME_in_specification550 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GE_in_specification560 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_DATE_in_specification564 = new BitSet(new ulong[]{0x0000200000000000UL});
    public static readonly BitSet FOLLOW_TIME_in_specification568 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NULL_in_specification576 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NOT_in_specification584 = new BitSet(new ulong[]{0x0000400000000000UL});
    public static readonly BitSet FOLLOW_T_NULL_in_specification586 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DATE_in_interval602 = new BitSet(new ulong[]{0x0001000000000000UL});
    public static readonly BitSet FOLLOW_MINUS_in_interval604 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_DATE_in_interval608 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DATE_in_interval618 = new BitSet(new ulong[]{0x0000200000000000UL});
    public static readonly BitSet FOLLOW_TIME_in_interval622 = new BitSet(new ulong[]{0x0001000000000000UL});
    public static readonly BitSet FOLLOW_MINUS_in_interval624 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_DATE_in_interval628 = new BitSet(new ulong[]{0x0000200000000000UL});
    public static readonly BitSet FOLLOW_TIME_in_interval632 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_specification_in_element645 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_interval_in_element649 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_element_in_factor661 = new BitSet(new ulong[]{0x0000DF8FBFFFFFF2UL});
    public static readonly BitSet FOLLOW_factor_in_list672 = new BitSet(new ulong[]{0x0006000000000002UL});
    public static readonly BitSet FOLLOW_COMMA_in_list677 = new BitSet(new ulong[]{0x0000DF8FBFFFFFF0UL});
    public static readonly BitSet FOLLOW_ENDLINE_in_list682 = new BitSet(new ulong[]{0x0004DF8FBFFFFFF0UL});
    public static readonly BitSet FOLLOW_factor_in_list689 = new BitSet(new ulong[]{0x0006000000000002UL});
    public static readonly BitSet FOLLOW_ENDLINE_in_list695 = new BitSet(new ulong[]{0x0004000000000002UL});
    public static readonly BitSet FOLLOW_list_in_expr705 = new BitSet(new ulong[]{0x0000000000000002UL});

}
