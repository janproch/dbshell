// $ANTLR 3.2 Sep 23, 2009 12:02:23 DateTimeFilter.g 2013-03-18 23:38:58

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
		"JAN", 
		"FEB", 
		"MAR", 
		"APR", 
		"MAY", 
		"JUN", 
		"JUL", 
		"AUG", 
		"SEP", 
		"OCT", 
		"NOV", 
		"DEC", 
		"MON", 
		"TUE", 
		"WED", 
		"THU", 
		"FRI", 
		"SAT", 
		"SUN", 
		"LAST_HOUR", 
		"THIS_HOUR", 
		"NEXT_HOUR", 
		"YESTERDAY", 
		"TODAY", 
		"TOMORROW", 
		"LAST_WEEK", 
		"THIS_WEEK", 
		"NEXT_WEEK", 
		"LAST_MONTH", 
		"THIS_MONTH", 
		"NEXT_MONTH", 
		"LAST_YEAR", 
		"THIS_YEAR", 
		"NEXT_YEAR", 
		"EQ", 
		"LT", 
		"LE", 
		"GT", 
		"GE", 
		"NE", 
		"TIME", 
		"MINUS", 
		"COMMA", 
		"ENDLINE", 
		"DIGIT", 
		"WHITESPACE"
    };

    public const int DEC = 21;
    public const int LT = 45;
    public const int JAN = 10;
    public const int FLOW_MONTH = 7;
    public const int MON = 22;
    public const int AUG = 17;
    public const int YEAR = 4;
    public const int HOUR_ANY_MINUTE = 6;
    public const int THIS_YEAR = 42;
    public const int THIS_MONTH = 39;
    public const int MAY = 14;
    public const int APR = 13;
    public const int NOV = 20;
    public const int EOF = -1;
    public const int FEB = 11;
    public const int YEAR_MONTH = 9;
    public const int SUN = 28;
    public const int LAST_YEAR = 41;
    public const int TIME = 50;
    public const int TUE = 23;
    public const int LAST_MONTH = 38;
    public const int SEP = 18;
    public const int COMMA = 52;
    public const int LAST_WEEK = 35;
    public const int JUL = 16;
    public const int FLOW_DAY = 8;
    public const int DIGIT = 54;
    public const int JUN = 15;
    public const int EQ = 44;
    public const int THU = 25;
    public const int NEXT_HOUR = 31;
    public const int NE = 49;
    public const int TOMORROW = 34;
    public const int GE = 48;
    public const int FRI = 26;
    public const int TODAY = 33;
    public const int NEXT_MONTH = 40;
    public const int LAST_HOUR = 29;
    public const int WED = 24;
    public const int THIS_HOUR = 30;
    public const int NEXT_WEEK = 37;
    public const int WHITESPACE = 55;
    public const int MINUS = 51;
    public const int SAT = 27;
    public const int THIS_WEEK = 36;
    public const int OCT = 19;
    public const int NEXT_YEAR = 43;
    public const int MAR = 12;
    public const int GT = 47;
    public const int ENDLINE = 53;
    public const int DATE = 5;
    public const int YESTERDAY = 32;
    public const int LE = 46;

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
    // DateTimeFilter.g:14:1: specification : (y= YEAR | d= DATE | d= HOUR_ANY_MINUTE | d= FLOW_MONTH | d= FLOW_DAY | d= YEAR_MONTH | JAN | FEB | MAR | APR | MAY | JUN | JUL | AUG | SEP | OCT | NOV | DEC | MON | TUE | WED | THU | FRI | SAT | SUN | LAST_HOUR | THIS_HOUR | NEXT_HOUR | YESTERDAY | TODAY | TOMORROW | LAST_WEEK | THIS_WEEK | NEXT_WEEK | LAST_MONTH | THIS_MONTH | NEXT_MONTH | LAST_YEAR | THIS_YEAR | NEXT_YEAR | EQ d= DATE | LT d= DATE | LE d= DATE | GT d= DATE | GE d= DATE | NE d= DATE | LT d= DATE t= TIME | LE d= DATE t= TIME | GT d= DATE t= TIME | GE d= DATE t= TIME );
    public DateTimeFilterParser.specification_return specification() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.specification_return retval = new DateTimeFilterParser.specification_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken y = null;
        IToken d = null;
        IToken t = null;
        IToken JAN1 = null;
        IToken FEB2 = null;
        IToken MAR3 = null;
        IToken APR4 = null;
        IToken MAY5 = null;
        IToken JUN6 = null;
        IToken JUL7 = null;
        IToken AUG8 = null;
        IToken SEP9 = null;
        IToken OCT10 = null;
        IToken NOV11 = null;
        IToken DEC12 = null;
        IToken MON13 = null;
        IToken TUE14 = null;
        IToken WED15 = null;
        IToken THU16 = null;
        IToken FRI17 = null;
        IToken SAT18 = null;
        IToken SUN19 = null;
        IToken LAST_HOUR20 = null;
        IToken THIS_HOUR21 = null;
        IToken NEXT_HOUR22 = null;
        IToken YESTERDAY23 = null;
        IToken TODAY24 = null;
        IToken TOMORROW25 = null;
        IToken LAST_WEEK26 = null;
        IToken THIS_WEEK27 = null;
        IToken NEXT_WEEK28 = null;
        IToken LAST_MONTH29 = null;
        IToken THIS_MONTH30 = null;
        IToken NEXT_MONTH31 = null;
        IToken LAST_YEAR32 = null;
        IToken THIS_YEAR33 = null;
        IToken NEXT_YEAR34 = null;
        IToken EQ35 = null;
        IToken LT36 = null;
        IToken LE37 = null;
        IToken GT38 = null;
        IToken GE39 = null;
        IToken NE40 = null;
        IToken LT41 = null;
        IToken LE42 = null;
        IToken GT43 = null;
        IToken GE44 = null;

        object y_tree=null;
        object d_tree=null;
        object t_tree=null;
        object JAN1_tree=null;
        object FEB2_tree=null;
        object MAR3_tree=null;
        object APR4_tree=null;
        object MAY5_tree=null;
        object JUN6_tree=null;
        object JUL7_tree=null;
        object AUG8_tree=null;
        object SEP9_tree=null;
        object OCT10_tree=null;
        object NOV11_tree=null;
        object DEC12_tree=null;
        object MON13_tree=null;
        object TUE14_tree=null;
        object WED15_tree=null;
        object THU16_tree=null;
        object FRI17_tree=null;
        object SAT18_tree=null;
        object SUN19_tree=null;
        object LAST_HOUR20_tree=null;
        object THIS_HOUR21_tree=null;
        object NEXT_HOUR22_tree=null;
        object YESTERDAY23_tree=null;
        object TODAY24_tree=null;
        object TOMORROW25_tree=null;
        object LAST_WEEK26_tree=null;
        object THIS_WEEK27_tree=null;
        object NEXT_WEEK28_tree=null;
        object LAST_MONTH29_tree=null;
        object THIS_MONTH30_tree=null;
        object NEXT_MONTH31_tree=null;
        object LAST_YEAR32_tree=null;
        object THIS_YEAR33_tree=null;
        object NEXT_YEAR34_tree=null;
        object EQ35_tree=null;
        object LT36_tree=null;
        object LE37_tree=null;
        object GT38_tree=null;
        object GE39_tree=null;
        object NE40_tree=null;
        object LT41_tree=null;
        object LE42_tree=null;
        object GT43_tree=null;
        object GE44_tree=null;

        try 
    	{
            // DateTimeFilter.g:14:14: (y= YEAR | d= DATE | d= HOUR_ANY_MINUTE | d= FLOW_MONTH | d= FLOW_DAY | d= YEAR_MONTH | JAN | FEB | MAR | APR | MAY | JUN | JUL | AUG | SEP | OCT | NOV | DEC | MON | TUE | WED | THU | FRI | SAT | SUN | LAST_HOUR | THIS_HOUR | NEXT_HOUR | YESTERDAY | TODAY | TOMORROW | LAST_WEEK | THIS_WEEK | NEXT_WEEK | LAST_MONTH | THIS_MONTH | NEXT_MONTH | LAST_YEAR | THIS_YEAR | NEXT_YEAR | EQ d= DATE | LT d= DATE | LE d= DATE | GT d= DATE | GE d= DATE | NE d= DATE | LT d= DATE t= TIME | LE d= DATE t= TIME | GT d= DATE t= TIME | GE d= DATE t= TIME )
            int alt1 = 50;
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
                    // DateTimeFilter.g:22:5: JAN
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	JAN1=(IToken)Match(input,JAN,FOLLOW_JAN_in_specification106); 
                    		JAN1_tree = (object)adaptor.Create(JAN1);
                    		adaptor.AddChild(root_0, JAN1_tree);

                    	 AddMonthCondition(1); 

                    }
                    break;
                case 8 :
                    // DateTimeFilter.g:23:5: FEB
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	FEB2=(IToken)Match(input,FEB,FOLLOW_FEB_in_specification114); 
                    		FEB2_tree = (object)adaptor.Create(FEB2);
                    		adaptor.AddChild(root_0, FEB2_tree);

                    	 AddMonthCondition(2); 

                    }
                    break;
                case 9 :
                    // DateTimeFilter.g:24:5: MAR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	MAR3=(IToken)Match(input,MAR,FOLLOW_MAR_in_specification122); 
                    		MAR3_tree = (object)adaptor.Create(MAR3);
                    		adaptor.AddChild(root_0, MAR3_tree);

                    	 AddMonthCondition(3); 

                    }
                    break;
                case 10 :
                    // DateTimeFilter.g:25:5: APR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	APR4=(IToken)Match(input,APR,FOLLOW_APR_in_specification130); 
                    		APR4_tree = (object)adaptor.Create(APR4);
                    		adaptor.AddChild(root_0, APR4_tree);

                    	 AddMonthCondition(4); 

                    }
                    break;
                case 11 :
                    // DateTimeFilter.g:26:5: MAY
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	MAY5=(IToken)Match(input,MAY,FOLLOW_MAY_in_specification138); 
                    		MAY5_tree = (object)adaptor.Create(MAY5);
                    		adaptor.AddChild(root_0, MAY5_tree);

                    	 AddMonthCondition(5); 

                    }
                    break;
                case 12 :
                    // DateTimeFilter.g:27:5: JUN
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	JUN6=(IToken)Match(input,JUN,FOLLOW_JUN_in_specification146); 
                    		JUN6_tree = (object)adaptor.Create(JUN6);
                    		adaptor.AddChild(root_0, JUN6_tree);

                    	 AddMonthCondition(6); 

                    }
                    break;
                case 13 :
                    // DateTimeFilter.g:28:5: JUL
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	JUL7=(IToken)Match(input,JUL,FOLLOW_JUL_in_specification154); 
                    		JUL7_tree = (object)adaptor.Create(JUL7);
                    		adaptor.AddChild(root_0, JUL7_tree);

                    	 AddMonthCondition(7); 

                    }
                    break;
                case 14 :
                    // DateTimeFilter.g:29:5: AUG
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	AUG8=(IToken)Match(input,AUG,FOLLOW_AUG_in_specification162); 
                    		AUG8_tree = (object)adaptor.Create(AUG8);
                    		adaptor.AddChild(root_0, AUG8_tree);

                    	 AddMonthCondition(8); 

                    }
                    break;
                case 15 :
                    // DateTimeFilter.g:30:5: SEP
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	SEP9=(IToken)Match(input,SEP,FOLLOW_SEP_in_specification170); 
                    		SEP9_tree = (object)adaptor.Create(SEP9);
                    		adaptor.AddChild(root_0, SEP9_tree);

                    	 AddMonthCondition(9); 

                    }
                    break;
                case 16 :
                    // DateTimeFilter.g:31:5: OCT
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	OCT10=(IToken)Match(input,OCT,FOLLOW_OCT_in_specification178); 
                    		OCT10_tree = (object)adaptor.Create(OCT10);
                    		adaptor.AddChild(root_0, OCT10_tree);

                    	 AddMonthCondition(10); 

                    }
                    break;
                case 17 :
                    // DateTimeFilter.g:32:5: NOV
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NOV11=(IToken)Match(input,NOV,FOLLOW_NOV_in_specification186); 
                    		NOV11_tree = (object)adaptor.Create(NOV11);
                    		adaptor.AddChild(root_0, NOV11_tree);

                    	 AddMonthCondition(11); 

                    }
                    break;
                case 18 :
                    // DateTimeFilter.g:33:5: DEC
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	DEC12=(IToken)Match(input,DEC,FOLLOW_DEC_in_specification194); 
                    		DEC12_tree = (object)adaptor.Create(DEC12);
                    		adaptor.AddChild(root_0, DEC12_tree);

                    	 AddMonthCondition(12); 

                    }
                    break;
                case 19 :
                    // DateTimeFilter.g:35:5: MON
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	MON13=(IToken)Match(input,MON,FOLLOW_MON_in_specification205); 
                    		MON13_tree = (object)adaptor.Create(MON13);
                    		adaptor.AddChild(root_0, MON13_tree);

                    	 AddDayOfWeekCondition(1); 

                    }
                    break;
                case 20 :
                    // DateTimeFilter.g:36:5: TUE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	TUE14=(IToken)Match(input,TUE,FOLLOW_TUE_in_specification213); 
                    		TUE14_tree = (object)adaptor.Create(TUE14);
                    		adaptor.AddChild(root_0, TUE14_tree);

                    	 AddDayOfWeekCondition(2); 

                    }
                    break;
                case 21 :
                    // DateTimeFilter.g:37:5: WED
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	WED15=(IToken)Match(input,WED,FOLLOW_WED_in_specification221); 
                    		WED15_tree = (object)adaptor.Create(WED15);
                    		adaptor.AddChild(root_0, WED15_tree);

                    	 AddDayOfWeekCondition(3); 

                    }
                    break;
                case 22 :
                    // DateTimeFilter.g:38:5: THU
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	THU16=(IToken)Match(input,THU,FOLLOW_THU_in_specification229); 
                    		THU16_tree = (object)adaptor.Create(THU16);
                    		adaptor.AddChild(root_0, THU16_tree);

                    	 AddDayOfWeekCondition(4); 

                    }
                    break;
                case 23 :
                    // DateTimeFilter.g:39:5: FRI
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	FRI17=(IToken)Match(input,FRI,FOLLOW_FRI_in_specification237); 
                    		FRI17_tree = (object)adaptor.Create(FRI17);
                    		adaptor.AddChild(root_0, FRI17_tree);

                    	 AddDayOfWeekCondition(5); 

                    }
                    break;
                case 24 :
                    // DateTimeFilter.g:40:5: SAT
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	SAT18=(IToken)Match(input,SAT,FOLLOW_SAT_in_specification245); 
                    		SAT18_tree = (object)adaptor.Create(SAT18);
                    		adaptor.AddChild(root_0, SAT18_tree);

                    	 AddDayOfWeekCondition(6); 

                    }
                    break;
                case 25 :
                    // DateTimeFilter.g:41:5: SUN
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	SUN19=(IToken)Match(input,SUN,FOLLOW_SUN_in_specification253); 
                    		SUN19_tree = (object)adaptor.Create(SUN19);
                    		adaptor.AddChild(root_0, SUN19_tree);

                    	 AddDayOfWeekCondition(7); 

                    }
                    break;
                case 26 :
                    // DateTimeFilter.g:43:5: LAST_HOUR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LAST_HOUR20=(IToken)Match(input,LAST_HOUR,FOLLOW_LAST_HOUR_in_specification264); 
                    		LAST_HOUR20_tree = (object)adaptor.Create(LAST_HOUR20);
                    		adaptor.AddChild(root_0, LAST_HOUR20_tree);

                    	 var h1 = new DateTime(Now.Year, Now.Month, Now.Day, Now.Hour, 0, 0); AddDateTimeIntervalCondition(h1 - TimeSpan.FromHours(1), h1); 

                    }
                    break;
                case 27 :
                    // DateTimeFilter.g:44:5: THIS_HOUR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	THIS_HOUR21=(IToken)Match(input,THIS_HOUR,FOLLOW_THIS_HOUR_in_specification272); 
                    		THIS_HOUR21_tree = (object)adaptor.Create(THIS_HOUR21);
                    		adaptor.AddChild(root_0, THIS_HOUR21_tree);

                    	 var h1 = new DateTime(Now.Year, Now.Month, Now.Day, Now.Hour, 0, 0); AddDateTimeIntervalCondition(h1, h1 + TimeSpan.FromHours(1)); 

                    }
                    break;
                case 28 :
                    // DateTimeFilter.g:45:5: NEXT_HOUR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NEXT_HOUR22=(IToken)Match(input,NEXT_HOUR,FOLLOW_NEXT_HOUR_in_specification280); 
                    		NEXT_HOUR22_tree = (object)adaptor.Create(NEXT_HOUR22);
                    		adaptor.AddChild(root_0, NEXT_HOUR22_tree);

                    	 var h1 = new DateTime(Now.Year, Now.Month, Now.Day, Now.Hour, 0, 0); AddDateTimeIntervalCondition(h1 + TimeSpan.FromHours(1), h1 + TimeSpan.FromHours(2)); 

                    }
                    break;
                case 29 :
                    // DateTimeFilter.g:47:5: YESTERDAY
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	YESTERDAY23=(IToken)Match(input,YESTERDAY,FOLLOW_YESTERDAY_in_specification289); 
                    		YESTERDAY23_tree = (object)adaptor.Create(YESTERDAY23);
                    		adaptor.AddChild(root_0, YESTERDAY23_tree);

                    	 AddDateTimeIntervalCondition(Now.Date-TimeSpan.FromDays(1), Now.Date); 

                    }
                    break;
                case 30 :
                    // DateTimeFilter.g:48:5: TODAY
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	TODAY24=(IToken)Match(input,TODAY,FOLLOW_TODAY_in_specification297); 
                    		TODAY24_tree = (object)adaptor.Create(TODAY24);
                    		adaptor.AddChild(root_0, TODAY24_tree);

                    	 AddDateTimeIntervalCondition(Now.Date, Now.Date+TimeSpan.FromDays(1)); 

                    }
                    break;
                case 31 :
                    // DateTimeFilter.g:49:5: TOMORROW
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	TOMORROW25=(IToken)Match(input,TOMORROW,FOLLOW_TOMORROW_in_specification305); 
                    		TOMORROW25_tree = (object)adaptor.Create(TOMORROW25);
                    		adaptor.AddChild(root_0, TOMORROW25_tree);

                    	 AddDateTimeIntervalCondition(Now.Date+TimeSpan.FromDays(1), Now.Date+TimeSpan.FromDays(2)); 

                    }
                    break;
                case 32 :
                    // DateTimeFilter.g:51:5: LAST_WEEK
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LAST_WEEK26=(IToken)Match(input,LAST_WEEK,FOLLOW_LAST_WEEK_in_specification316); 
                    		LAST_WEEK26_tree = (object)adaptor.Create(LAST_WEEK26);
                    		adaptor.AddChild(root_0, LAST_WEEK26_tree);

                    	 var d1=GetFirstDayOfWeek(Now.Date); AddDateTimeIntervalCondition(d1-TimeSpan.FromDays(7), d1); 

                    }
                    break;
                case 33 :
                    // DateTimeFilter.g:52:5: THIS_WEEK
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	THIS_WEEK27=(IToken)Match(input,THIS_WEEK,FOLLOW_THIS_WEEK_in_specification324); 
                    		THIS_WEEK27_tree = (object)adaptor.Create(THIS_WEEK27);
                    		adaptor.AddChild(root_0, THIS_WEEK27_tree);

                    	 var d1=GetFirstDayOfWeek(Now.Date); AddDateTimeIntervalCondition(d1, d1+TimeSpan.FromDays(7)); 

                    }
                    break;
                case 34 :
                    // DateTimeFilter.g:53:5: NEXT_WEEK
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NEXT_WEEK28=(IToken)Match(input,NEXT_WEEK,FOLLOW_NEXT_WEEK_in_specification332); 
                    		NEXT_WEEK28_tree = (object)adaptor.Create(NEXT_WEEK28);
                    		adaptor.AddChild(root_0, NEXT_WEEK28_tree);

                    	 var d1=GetFirstDayOfWeek(Now.Date); AddDateTimeIntervalCondition(d1+TimeSpan.FromDays(7), d1+TimeSpan.FromDays(14)); 

                    }
                    break;
                case 35 :
                    // DateTimeFilter.g:55:5: LAST_MONTH
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LAST_MONTH29=(IToken)Match(input,LAST_MONTH,FOLLOW_LAST_MONTH_in_specification341); 
                    		LAST_MONTH29_tree = (object)adaptor.Create(LAST_MONTH29);
                    		adaptor.AddChild(root_0, LAST_MONTH29_tree);

                    	 var d1=new DateTime(Now.Year, Now.Month, 1); AddDateTimeIntervalCondition(d1.AddMonths(-1), d1); 

                    }
                    break;
                case 36 :
                    // DateTimeFilter.g:56:5: THIS_MONTH
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	THIS_MONTH30=(IToken)Match(input,THIS_MONTH,FOLLOW_THIS_MONTH_in_specification349); 
                    		THIS_MONTH30_tree = (object)adaptor.Create(THIS_MONTH30);
                    		adaptor.AddChild(root_0, THIS_MONTH30_tree);

                    	 var d1=new DateTime(Now.Year, Now.Month, 1); AddDateTimeIntervalCondition(d1, d1.AddMonths(1)); 

                    }
                    break;
                case 37 :
                    // DateTimeFilter.g:57:5: NEXT_MONTH
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NEXT_MONTH31=(IToken)Match(input,NEXT_MONTH,FOLLOW_NEXT_MONTH_in_specification357); 
                    		NEXT_MONTH31_tree = (object)adaptor.Create(NEXT_MONTH31);
                    		adaptor.AddChild(root_0, NEXT_MONTH31_tree);

                    	 var d1=new DateTime(Now.Year, Now.Month, 1); AddDateTimeIntervalCondition(d1.AddMonths(1), d1.AddMonths(2)); 

                    }
                    break;
                case 38 :
                    // DateTimeFilter.g:59:5: LAST_YEAR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LAST_YEAR32=(IToken)Match(input,LAST_YEAR,FOLLOW_LAST_YEAR_in_specification368); 
                    		LAST_YEAR32_tree = (object)adaptor.Create(LAST_YEAR32);
                    		adaptor.AddChild(root_0, LAST_YEAR32_tree);

                    	 var d1=new DateTime(Now.Year, 1, 1); AddDateTimeIntervalCondition(d1.AddYears(-1), d1); 

                    }
                    break;
                case 39 :
                    // DateTimeFilter.g:60:5: THIS_YEAR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	THIS_YEAR33=(IToken)Match(input,THIS_YEAR,FOLLOW_THIS_YEAR_in_specification376); 
                    		THIS_YEAR33_tree = (object)adaptor.Create(THIS_YEAR33);
                    		adaptor.AddChild(root_0, THIS_YEAR33_tree);

                    	 var d1=new DateTime(Now.Year, 1, 1); AddDateTimeIntervalCondition(d1, d1.AddYears(1)); 

                    }
                    break;
                case 40 :
                    // DateTimeFilter.g:61:5: NEXT_YEAR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NEXT_YEAR34=(IToken)Match(input,NEXT_YEAR,FOLLOW_NEXT_YEAR_in_specification384); 
                    		NEXT_YEAR34_tree = (object)adaptor.Create(NEXT_YEAR34);
                    		adaptor.AddChild(root_0, NEXT_YEAR34_tree);

                    	 var d1=new DateTime(Now.Year, 1, 1); AddDateTimeIntervalCondition(d1.AddYears(1), d1.AddYears(2)); 

                    }
                    break;
                case 41 :
                    // DateTimeFilter.g:63:5: EQ d= DATE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	EQ35=(IToken)Match(input,EQ,FOLLOW_EQ_in_specification395); 
                    		EQ35_tree = (object)adaptor.Create(EQ35);
                    		adaptor.AddChild(root_0, EQ35_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification399); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 var dt=ParseDate(((d != null) ? d.Text : null));AddDateTimeIntervalCondition(dt, dt + TimeSpan.FromDays(1)); 

                    }
                    break;
                case 42 :
                    // DateTimeFilter.g:64:5: LT d= DATE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LT36=(IToken)Match(input,LT,FOLLOW_LT_in_specification409); 
                    		LT36_tree = (object)adaptor.Create(LT36);
                    		adaptor.AddChild(root_0, LT36_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification413); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 var dt=ParseDate(((d != null) ? d.Text : null));AddDateTimeRelation(dt, "<"); 

                    }
                    break;
                case 43 :
                    // DateTimeFilter.g:65:5: LE d= DATE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LE37=(IToken)Match(input,LE,FOLLOW_LE_in_specification423); 
                    		LE37_tree = (object)adaptor.Create(LE37);
                    		adaptor.AddChild(root_0, LE37_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification427); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 var dt=ParseDate(((d != null) ? d.Text : null));AddDateTimeRelation(dt+TimeSpan.FromDays(1), "<"); 

                    }
                    break;
                case 44 :
                    // DateTimeFilter.g:66:5: GT d= DATE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GT38=(IToken)Match(input,GT,FOLLOW_GT_in_specification437); 
                    		GT38_tree = (object)adaptor.Create(GT38);
                    		adaptor.AddChild(root_0, GT38_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification441); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 var dt=ParseDate(((d != null) ? d.Text : null));AddDateTimeRelation(dt+TimeSpan.FromDays(1), ">="); 

                    }
                    break;
                case 45 :
                    // DateTimeFilter.g:67:5: GE d= DATE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GE39=(IToken)Match(input,GE,FOLLOW_GE_in_specification451); 
                    		GE39_tree = (object)adaptor.Create(GE39);
                    		adaptor.AddChild(root_0, GE39_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification455); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 var dt=ParseDate(((d != null) ? d.Text : null));AddDateTimeRelation(dt, ">="); 

                    }
                    break;
                case 46 :
                    // DateTimeFilter.g:68:5: NE d= DATE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NE40=(IToken)Match(input,NE,FOLLOW_NE_in_specification465); 
                    		NE40_tree = (object)adaptor.Create(NE40);
                    		adaptor.AddChild(root_0, NE40_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification469); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 var dt=ParseDate(((d != null) ? d.Text : null));AddDateTimeNotIntervalCondition(dt, dt + TimeSpan.FromDays(1)); 

                    }
                    break;
                case 47 :
                    // DateTimeFilter.g:70:5: LT d= DATE t= TIME
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LT41=(IToken)Match(input,LT,FOLLOW_LT_in_specification482); 
                    		LT41_tree = (object)adaptor.Create(LT41);
                    		adaptor.AddChild(root_0, LT41_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification486); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	t=(IToken)Match(input,TIME,FOLLOW_TIME_in_specification490); 
                    		t_tree = (object)adaptor.Create(t);
                    		adaptor.AddChild(root_0, t_tree);

                    	 var dt=ParseDate(((d != null) ? d.Text : null))+ParseTime(((t != null) ? t.Text : null));AddDateTimeRelation(dt, "<"); 

                    }
                    break;
                case 48 :
                    // DateTimeFilter.g:71:5: LE d= DATE t= TIME
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LE42=(IToken)Match(input,LE,FOLLOW_LE_in_specification500); 
                    		LE42_tree = (object)adaptor.Create(LE42);
                    		adaptor.AddChild(root_0, LE42_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification504); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	t=(IToken)Match(input,TIME,FOLLOW_TIME_in_specification508); 
                    		t_tree = (object)adaptor.Create(t);
                    		adaptor.AddChild(root_0, t_tree);

                    	 var dt=ParseDate(((d != null) ? d.Text : null))+ParseTime(((t != null) ? t.Text : null));AddDateTimeRelation(dt, "<="); 

                    }
                    break;
                case 49 :
                    // DateTimeFilter.g:72:5: GT d= DATE t= TIME
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GT43=(IToken)Match(input,GT,FOLLOW_GT_in_specification518); 
                    		GT43_tree = (object)adaptor.Create(GT43);
                    		adaptor.AddChild(root_0, GT43_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification522); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	t=(IToken)Match(input,TIME,FOLLOW_TIME_in_specification526); 
                    		t_tree = (object)adaptor.Create(t);
                    		adaptor.AddChild(root_0, t_tree);

                    	 var dt=ParseDate(((d != null) ? d.Text : null))+ParseTime(((t != null) ? t.Text : null));AddDateTimeRelation(dt, ">"); 

                    }
                    break;
                case 50 :
                    // DateTimeFilter.g:73:5: GE d= DATE t= TIME
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GE44=(IToken)Match(input,GE,FOLLOW_GE_in_specification536); 
                    		GE44_tree = (object)adaptor.Create(GE44);
                    		adaptor.AddChild(root_0, GE44_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification540); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	t=(IToken)Match(input,TIME,FOLLOW_TIME_in_specification544); 
                    		t_tree = (object)adaptor.Create(t);
                    		adaptor.AddChild(root_0, t_tree);

                    	 var dt=ParseDate(((d != null) ? d.Text : null))+ParseTime(((t != null) ? t.Text : null));AddDateTimeRelation(dt, ">="); 

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
    // DateTimeFilter.g:76:1: interval : (d1= DATE MINUS d2= DATE | d1= DATE t1= TIME MINUS d2= DATE t2= TIME );
    public DateTimeFilterParser.interval_return interval() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.interval_return retval = new DateTimeFilterParser.interval_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken d1 = null;
        IToken d2 = null;
        IToken t1 = null;
        IToken t2 = null;
        IToken MINUS45 = null;
        IToken MINUS46 = null;

        object d1_tree=null;
        object d2_tree=null;
        object t1_tree=null;
        object t2_tree=null;
        object MINUS45_tree=null;
        object MINUS46_tree=null;

        try 
    	{
            // DateTimeFilter.g:76:10: (d1= DATE MINUS d2= DATE | d1= DATE t1= TIME MINUS d2= DATE t2= TIME )
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
                    // DateTimeFilter.g:77:3: d1= DATE MINUS d2= DATE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	d1=(IToken)Match(input,DATE,FOLLOW_DATE_in_interval562); 
                    		d1_tree = (object)adaptor.Create(d1);
                    		adaptor.AddChild(root_0, d1_tree);

                    	MINUS45=(IToken)Match(input,MINUS,FOLLOW_MINUS_in_interval564); 
                    		MINUS45_tree = (object)adaptor.Create(MINUS45);
                    		adaptor.AddChild(root_0, MINUS45_tree);

                    	d2=(IToken)Match(input,DATE,FOLLOW_DATE_in_interval568); 
                    		d2_tree = (object)adaptor.Create(d2);
                    		adaptor.AddChild(root_0, d2_tree);

                    	 AddDateTimeIntervalCondition(ParseDate(((d1 != null) ? d1.Text : null)), ParseDate(((d2 != null) ? d2.Text : null)) + TimeSpan.FromDays(1)); 

                    }
                    break;
                case 2 :
                    // DateTimeFilter.g:78:5: d1= DATE t1= TIME MINUS d2= DATE t2= TIME
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	d1=(IToken)Match(input,DATE,FOLLOW_DATE_in_interval578); 
                    		d1_tree = (object)adaptor.Create(d1);
                    		adaptor.AddChild(root_0, d1_tree);

                    	t1=(IToken)Match(input,TIME,FOLLOW_TIME_in_interval582); 
                    		t1_tree = (object)adaptor.Create(t1);
                    		adaptor.AddChild(root_0, t1_tree);

                    	MINUS46=(IToken)Match(input,MINUS,FOLLOW_MINUS_in_interval584); 
                    		MINUS46_tree = (object)adaptor.Create(MINUS46);
                    		adaptor.AddChild(root_0, MINUS46_tree);

                    	d2=(IToken)Match(input,DATE,FOLLOW_DATE_in_interval588); 
                    		d2_tree = (object)adaptor.Create(d2);
                    		adaptor.AddChild(root_0, d2_tree);

                    	t2=(IToken)Match(input,TIME,FOLLOW_TIME_in_interval592); 
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
    // DateTimeFilter.g:83:1: element : ( specification | interval );
    public DateTimeFilterParser.element_return element() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.element_return retval = new DateTimeFilterParser.element_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        DateTimeFilterParser.specification_return specification47 = default(DateTimeFilterParser.specification_return);

        DateTimeFilterParser.interval_return interval48 = default(DateTimeFilterParser.interval_return);



        try 
    	{
            // DateTimeFilter.g:83:8: ( specification | interval )
            int alt3 = 2;
            int LA3_0 = input.LA(1);

            if ( (LA3_0 == YEAR || (LA3_0 >= HOUR_ANY_MINUTE && LA3_0 <= NE)) )
            {
                alt3 = 1;
            }
            else if ( (LA3_0 == DATE) )
            {
                int LA3_2 = input.LA(2);

                if ( ((LA3_2 >= TIME && LA3_2 <= MINUS)) )
                {
                    alt3 = 2;
                }
                else if ( (LA3_2 == EOF || (LA3_2 >= YEAR && LA3_2 <= NE) || (LA3_2 >= COMMA && LA3_2 <= ENDLINE)) )
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
                    // DateTimeFilter.g:84:3: specification
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_specification_in_element605);
                    	specification47 = specification();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, specification47.Tree);

                    }
                    break;
                case 2 :
                    // DateTimeFilter.g:84:19: interval
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_interval_in_element609);
                    	interval48 = interval();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, interval48.Tree);

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
    // DateTimeFilter.g:86:1: factor : ( element )+ ;
    public DateTimeFilterParser.factor_return factor() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.factor_return retval = new DateTimeFilterParser.factor_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        DateTimeFilterParser.element_return element49 = default(DateTimeFilterParser.element_return);



        try 
    	{
            // DateTimeFilter.g:86:8: ( ( element )+ )
            // DateTimeFilter.g:87:3: ( element )+
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// DateTimeFilter.g:87:3: ( element )+
            	int cnt4 = 0;
            	do 
            	{
            	    int alt4 = 2;
            	    int LA4_0 = input.LA(1);

            	    if ( ((LA4_0 >= YEAR && LA4_0 <= NE)) )
            	    {
            	        alt4 = 1;
            	    }


            	    switch (alt4) 
            		{
            			case 1 :
            			    // DateTimeFilter.g:87:3: element
            			    {
            			    	PushFollow(FOLLOW_element_in_factor621);
            			    	element49 = element();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, element49.Tree);

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
    // DateTimeFilter.g:89:1: list : factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )* ;
    public DateTimeFilterParser.list_return list() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.list_return retval = new DateTimeFilterParser.list_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken COMMA51 = null;
        IToken ENDLINE52 = null;
        IToken ENDLINE54 = null;
        DateTimeFilterParser.factor_return factor50 = default(DateTimeFilterParser.factor_return);

        DateTimeFilterParser.factor_return factor53 = default(DateTimeFilterParser.factor_return);


        object COMMA51_tree=null;
        object ENDLINE52_tree=null;
        object ENDLINE54_tree=null;

        try 
    	{
            // DateTimeFilter.g:89:5: ( factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )* )
            // DateTimeFilter.g:90:3: factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_factor_in_list632);
            	factor50 = factor();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, factor50.Tree);
            	// DateTimeFilter.g:90:10: ( ( COMMA | ( ( ENDLINE )+ ) ) factor )*
            	do 
            	{
            	    int alt7 = 2;
            	    alt7 = dfa7.Predict(input);
            	    switch (alt7) 
            		{
            			case 1 :
            			    // DateTimeFilter.g:90:12: ( COMMA | ( ( ENDLINE )+ ) ) factor
            			    {
            			    	// DateTimeFilter.g:90:12: ( COMMA | ( ( ENDLINE )+ ) )
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
            			    	        // DateTimeFilter.g:90:13: COMMA
            			    	        {
            			    	        	COMMA51=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_list637); 
            			    	        		COMMA51_tree = (object)adaptor.Create(COMMA51);
            			    	        		adaptor.AddChild(root_0, COMMA51_tree);


            			    	        }
            			    	        break;
            			    	    case 2 :
            			    	        // DateTimeFilter.g:90:21: ( ( ENDLINE )+ )
            			    	        {
            			    	        	// DateTimeFilter.g:90:21: ( ( ENDLINE )+ )
            			    	        	// DateTimeFilter.g:90:22: ( ENDLINE )+
            			    	        	{
            			    	        		// DateTimeFilter.g:90:22: ( ENDLINE )+
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
            			    	        				    // DateTimeFilter.g:90:22: ENDLINE
            			    	        				    {
            			    	        				    	ENDLINE52=(IToken)Match(input,ENDLINE,FOLLOW_ENDLINE_in_list642); 
            			    	        				    		ENDLINE52_tree = (object)adaptor.Create(ENDLINE52);
            			    	        				    		adaptor.AddChild(root_0, ENDLINE52_tree);


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
            			    	PushFollow(FOLLOW_factor_in_list649);
            			    	factor53 = factor();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, factor53.Tree);

            			    }
            			    break;

            			default:
            			    goto loop7;
            	    }
            	} while (true);

            	loop7:
            		;	// Stops C# compiler whining that label 'loop7' has no statements

            	// DateTimeFilter.g:90:67: ( ENDLINE )*
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
            			    // DateTimeFilter.g:90:67: ENDLINE
            			    {
            			    	ENDLINE54=(IToken)Match(input,ENDLINE,FOLLOW_ENDLINE_in_list655); 
            			    		ENDLINE54_tree = (object)adaptor.Create(ENDLINE54);
            			    		adaptor.AddChild(root_0, ENDLINE54_tree);


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
    // DateTimeFilter.g:92:1: expr : list ;
    public DateTimeFilterParser.expr_return expr() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.expr_return retval = new DateTimeFilterParser.expr_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        DateTimeFilterParser.list_return list55 = default(DateTimeFilterParser.list_return);



        try 
    	{
            // DateTimeFilter.g:92:5: ( list )
            // DateTimeFilter.g:92:7: list
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_list_in_expr665);
            	list55 = list();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, list55.Tree);

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
        "\x3b\uffff";
    const string DFA1_eofS =
        "\x2f\uffff\x01\x34\x01\x36\x01\x38\x01\x3a\x08\uffff";
    const string DFA1_minS =
        "\x01\x04\x29\uffff\x04\x05\x01\uffff\x04\x04\x08\uffff";
    const string DFA1_maxS =
        "\x01\x31\x29\uffff\x04\x05\x01\uffff\x04\x35\x08\uffff";
    const string DFA1_acceptS =
        "\x01\uffff\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06\x01"+
        "\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x01\x0c\x01\x0d\x01\x0e\x01"+
        "\x0f\x01\x10\x01\x11\x01\x12\x01\x13\x01\x14\x01\x15\x01\x16\x01"+
        "\x17\x01\x18\x01\x19\x01\x1a\x01\x1b\x01\x1c\x01\x1d\x01\x1e\x01"+
        "\x1f\x01\x20\x01\x21\x01\x22\x01\x23\x01\x24\x01\x25\x01\x26\x01"+
        "\x27\x01\x28\x01\x29\x04\uffff\x01\x2e\x04\uffff\x01\x2f\x01\x2a"+
        "\x01\x30\x01\x2b\x01\x31\x01\x2c\x01\x32\x01\x2d";
    const string DFA1_specialS =
        "\x3b\uffff}>";
    static readonly string[] DFA1_transitionS = {
            "\x01\x01\x01\x02\x01\x03\x01\x04\x01\x05\x01\x06\x01\x07\x01"+
            "\x08\x01\x09\x01\x0a\x01\x0b\x01\x0c\x01\x0d\x01\x0e\x01\x0f"+
            "\x01\x10\x01\x11\x01\x12\x01\x13\x01\x14\x01\x15\x01\x16\x01"+
            "\x17\x01\x18\x01\x19\x01\x1a\x01\x1b\x01\x1c\x01\x1d\x01\x1e"+
            "\x01\x1f\x01\x20\x01\x21\x01\x22\x01\x23\x01\x24\x01\x25\x01"+
            "\x26\x01\x27\x01\x28\x01\x29\x01\x2a\x01\x2b\x01\x2c\x01\x2d"+
            "\x01\x2e",
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
            "\x01\x2f",
            "\x01\x30",
            "\x01\x31",
            "\x01\x32",
            "",
            "\x2e\x34\x01\x33\x01\uffff\x02\x34",
            "\x2e\x36\x01\x35\x01\uffff\x02\x36",
            "\x2e\x38\x01\x37\x01\uffff\x02\x38",
            "\x2e\x3a\x01\x39\x01\uffff\x02\x3a",
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
            get { return "14:1: specification : (y= YEAR | d= DATE | d= HOUR_ANY_MINUTE | d= FLOW_MONTH | d= FLOW_DAY | d= YEAR_MONTH | JAN | FEB | MAR | APR | MAY | JUN | JUL | AUG | SEP | OCT | NOV | DEC | MON | TUE | WED | THU | FRI | SAT | SUN | LAST_HOUR | THIS_HOUR | NEXT_HOUR | YESTERDAY | TODAY | TOMORROW | LAST_WEEK | THIS_WEEK | NEXT_WEEK | LAST_MONTH | THIS_MONTH | NEXT_MONTH | LAST_YEAR | THIS_YEAR | NEXT_YEAR | EQ d= DATE | LT d= DATE | LE d= DATE | GT d= DATE | GE d= DATE | NE d= DATE | LT d= DATE t= TIME | LE d= DATE t= TIME | GT d= DATE t= TIME | GE d= DATE t= TIME );"; }
        }

    }

    const string DFA7_eotS =
        "\x04\uffff";
    const string DFA7_eofS =
        "\x02\x02\x02\uffff";
    const string DFA7_minS =
        "\x01\x34\x01\x04\x02\uffff";
    const string DFA7_maxS =
        "\x02\x35\x02\uffff";
    const string DFA7_acceptS =
        "\x02\uffff\x01\x02\x01\x01";
    const string DFA7_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA7_transitionS = {
            "\x01\x03\x01\x01",
            "\x2e\x03\x03\uffff\x01\x01",
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
            get { return "()* loopback of 90:10: ( ( COMMA | ( ( ENDLINE )+ ) ) factor )*"; }
        }

    }

 

    public static readonly BitSet FOLLOW_YEAR_in_specification44 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DATE_in_specification54 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_HOUR_ANY_MINUTE_in_specification64 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_FLOW_MONTH_in_specification75 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_FLOW_DAY_in_specification85 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_YEAR_MONTH_in_specification95 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_JAN_in_specification106 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_FEB_in_specification114 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_MAR_in_specification122 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_APR_in_specification130 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_MAY_in_specification138 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_JUN_in_specification146 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_JUL_in_specification154 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_AUG_in_specification162 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_SEP_in_specification170 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_OCT_in_specification178 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NOV_in_specification186 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DEC_in_specification194 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_MON_in_specification205 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_TUE_in_specification213 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_WED_in_specification221 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_THU_in_specification229 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_FRI_in_specification237 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_SAT_in_specification245 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_SUN_in_specification253 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LAST_HOUR_in_specification264 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_THIS_HOUR_in_specification272 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NEXT_HOUR_in_specification280 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_YESTERDAY_in_specification289 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_TODAY_in_specification297 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_TOMORROW_in_specification305 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LAST_WEEK_in_specification316 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_THIS_WEEK_in_specification324 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NEXT_WEEK_in_specification332 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LAST_MONTH_in_specification341 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_THIS_MONTH_in_specification349 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NEXT_MONTH_in_specification357 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LAST_YEAR_in_specification368 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_THIS_YEAR_in_specification376 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NEXT_YEAR_in_specification384 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EQ_in_specification395 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_DATE_in_specification399 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_specification409 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_DATE_in_specification413 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LE_in_specification423 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_DATE_in_specification427 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GT_in_specification437 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_DATE_in_specification441 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GE_in_specification451 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_DATE_in_specification455 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NE_in_specification465 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_DATE_in_specification469 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_specification482 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_DATE_in_specification486 = new BitSet(new ulong[]{0x0004000000000000UL});
    public static readonly BitSet FOLLOW_TIME_in_specification490 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LE_in_specification500 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_DATE_in_specification504 = new BitSet(new ulong[]{0x0004000000000000UL});
    public static readonly BitSet FOLLOW_TIME_in_specification508 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GT_in_specification518 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_DATE_in_specification522 = new BitSet(new ulong[]{0x0004000000000000UL});
    public static readonly BitSet FOLLOW_TIME_in_specification526 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GE_in_specification536 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_DATE_in_specification540 = new BitSet(new ulong[]{0x0004000000000000UL});
    public static readonly BitSet FOLLOW_TIME_in_specification544 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DATE_in_interval562 = new BitSet(new ulong[]{0x0008000000000000UL});
    public static readonly BitSet FOLLOW_MINUS_in_interval564 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_DATE_in_interval568 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DATE_in_interval578 = new BitSet(new ulong[]{0x0004000000000000UL});
    public static readonly BitSet FOLLOW_TIME_in_interval582 = new BitSet(new ulong[]{0x0008000000000000UL});
    public static readonly BitSet FOLLOW_MINUS_in_interval584 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_DATE_in_interval588 = new BitSet(new ulong[]{0x0004000000000000UL});
    public static readonly BitSet FOLLOW_TIME_in_interval592 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_specification_in_element605 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_interval_in_element609 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_element_in_factor621 = new BitSet(new ulong[]{0x0003FFFFFFFFFFF2UL});
    public static readonly BitSet FOLLOW_factor_in_list632 = new BitSet(new ulong[]{0x0030000000000002UL});
    public static readonly BitSet FOLLOW_COMMA_in_list637 = new BitSet(new ulong[]{0x0003FFFFFFFFFFF0UL});
    public static readonly BitSet FOLLOW_ENDLINE_in_list642 = new BitSet(new ulong[]{0x0023FFFFFFFFFFF0UL});
    public static readonly BitSet FOLLOW_factor_in_list649 = new BitSet(new ulong[]{0x0030000000000002UL});
    public static readonly BitSet FOLLOW_ENDLINE_in_list655 = new BitSet(new ulong[]{0x0020000000000002UL});
    public static readonly BitSet FOLLOW_list_in_expr665 = new BitSet(new ulong[]{0x0000000000000002UL});

}
