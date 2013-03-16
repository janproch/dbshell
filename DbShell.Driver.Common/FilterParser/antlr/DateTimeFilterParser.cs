// $ANTLR 3.2 Sep 23, 2009 12:02:23 DateTimeFilter.g 2013-03-16 13:19:45

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
		"MINUS", 
		"TIME", 
		"COMMA", 
		"ENDLINE", 
		"LT", 
		"GT", 
		"GE", 
		"LE", 
		"NE", 
		"EQ", 
		"DIGIT", 
		"WHITESPACE"
    };

    public const int DEC = 21;
    public const int LT = 48;
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
    public const int TIME = 45;
    public const int TUE = 23;
    public const int LAST_MONTH = 38;
    public const int SEP = 18;
    public const int COMMA = 46;
    public const int LAST_WEEK = 35;
    public const int JUL = 16;
    public const int FLOW_DAY = 8;
    public const int DIGIT = 54;
    public const int JUN = 15;
    public const int EQ = 53;
    public const int THU = 25;
    public const int NEXT_HOUR = 31;
    public const int NE = 52;
    public const int TOMORROW = 34;
    public const int GE = 50;
    public const int FRI = 26;
    public const int TODAY = 33;
    public const int NEXT_MONTH = 40;
    public const int LAST_HOUR = 29;
    public const int WED = 24;
    public const int THIS_HOUR = 30;
    public const int NEXT_WEEK = 37;
    public const int WHITESPACE = 55;
    public const int MINUS = 44;
    public const int SAT = 27;
    public const int THIS_WEEK = 36;
    public const int OCT = 19;
    public const int NEXT_YEAR = 43;
    public const int MAR = 12;
    public const int GT = 49;
    public const int ENDLINE = 47;
    public const int DATE = 5;
    public const int YESTERDAY = 32;
    public const int LE = 51;

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
    // DateTimeFilter.g:14:1: specification : (y= YEAR | d= DATE | HOUR_ANY_MINUTE | FLOW_MONTH | FLOW_DAY | YEAR_MONTH | JAN | FEB | MAR | APR | MAY | JUN | JUL | AUG | SEP | OCT | NOV | DEC | MON | TUE | WED | THU | FRI | SAT | SUN | LAST_HOUR | THIS_HOUR | NEXT_HOUR | YESTERDAY | TODAY | TOMORROW | LAST_WEEK | THIS_WEEK | NEXT_WEEK | LAST_MONTH | THIS_MONTH | NEXT_MONTH | LAST_YEAR | THIS_YEAR | NEXT_YEAR );
    public DateTimeFilterParser.specification_return specification() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.specification_return retval = new DateTimeFilterParser.specification_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken y = null;
        IToken d = null;
        IToken HOUR_ANY_MINUTE1 = null;
        IToken FLOW_MONTH2 = null;
        IToken FLOW_DAY3 = null;
        IToken YEAR_MONTH4 = null;
        IToken JAN5 = null;
        IToken FEB6 = null;
        IToken MAR7 = null;
        IToken APR8 = null;
        IToken MAY9 = null;
        IToken JUN10 = null;
        IToken JUL11 = null;
        IToken AUG12 = null;
        IToken SEP13 = null;
        IToken OCT14 = null;
        IToken NOV15 = null;
        IToken DEC16 = null;
        IToken MON17 = null;
        IToken TUE18 = null;
        IToken WED19 = null;
        IToken THU20 = null;
        IToken FRI21 = null;
        IToken SAT22 = null;
        IToken SUN23 = null;
        IToken LAST_HOUR24 = null;
        IToken THIS_HOUR25 = null;
        IToken NEXT_HOUR26 = null;
        IToken YESTERDAY27 = null;
        IToken TODAY28 = null;
        IToken TOMORROW29 = null;
        IToken LAST_WEEK30 = null;
        IToken THIS_WEEK31 = null;
        IToken NEXT_WEEK32 = null;
        IToken LAST_MONTH33 = null;
        IToken THIS_MONTH34 = null;
        IToken NEXT_MONTH35 = null;
        IToken LAST_YEAR36 = null;
        IToken THIS_YEAR37 = null;
        IToken NEXT_YEAR38 = null;

        object y_tree=null;
        object d_tree=null;
        object HOUR_ANY_MINUTE1_tree=null;
        object FLOW_MONTH2_tree=null;
        object FLOW_DAY3_tree=null;
        object YEAR_MONTH4_tree=null;
        object JAN5_tree=null;
        object FEB6_tree=null;
        object MAR7_tree=null;
        object APR8_tree=null;
        object MAY9_tree=null;
        object JUN10_tree=null;
        object JUL11_tree=null;
        object AUG12_tree=null;
        object SEP13_tree=null;
        object OCT14_tree=null;
        object NOV15_tree=null;
        object DEC16_tree=null;
        object MON17_tree=null;
        object TUE18_tree=null;
        object WED19_tree=null;
        object THU20_tree=null;
        object FRI21_tree=null;
        object SAT22_tree=null;
        object SUN23_tree=null;
        object LAST_HOUR24_tree=null;
        object THIS_HOUR25_tree=null;
        object NEXT_HOUR26_tree=null;
        object YESTERDAY27_tree=null;
        object TODAY28_tree=null;
        object TOMORROW29_tree=null;
        object LAST_WEEK30_tree=null;
        object THIS_WEEK31_tree=null;
        object NEXT_WEEK32_tree=null;
        object LAST_MONTH33_tree=null;
        object THIS_MONTH34_tree=null;
        object NEXT_MONTH35_tree=null;
        object LAST_YEAR36_tree=null;
        object THIS_YEAR37_tree=null;
        object NEXT_YEAR38_tree=null;

        try 
    	{
            // DateTimeFilter.g:14:14: (y= YEAR | d= DATE | HOUR_ANY_MINUTE | FLOW_MONTH | FLOW_DAY | YEAR_MONTH | JAN | FEB | MAR | APR | MAY | JUN | JUL | AUG | SEP | OCT | NOV | DEC | MON | TUE | WED | THU | FRI | SAT | SUN | LAST_HOUR | THIS_HOUR | NEXT_HOUR | YESTERDAY | TODAY | TOMORROW | LAST_WEEK | THIS_WEEK | NEXT_WEEK | LAST_MONTH | THIS_MONTH | NEXT_MONTH | LAST_YEAR | THIS_YEAR | NEXT_YEAR )
            int alt1 = 40;
            switch ( input.LA(1) ) 
            {
            case YEAR:
            	{
                alt1 = 1;
                }
                break;
            case DATE:
            	{
                alt1 = 2;
                }
                break;
            case HOUR_ANY_MINUTE:
            	{
                alt1 = 3;
                }
                break;
            case FLOW_MONTH:
            	{
                alt1 = 4;
                }
                break;
            case FLOW_DAY:
            	{
                alt1 = 5;
                }
                break;
            case YEAR_MONTH:
            	{
                alt1 = 6;
                }
                break;
            case JAN:
            	{
                alt1 = 7;
                }
                break;
            case FEB:
            	{
                alt1 = 8;
                }
                break;
            case MAR:
            	{
                alt1 = 9;
                }
                break;
            case APR:
            	{
                alt1 = 10;
                }
                break;
            case MAY:
            	{
                alt1 = 11;
                }
                break;
            case JUN:
            	{
                alt1 = 12;
                }
                break;
            case JUL:
            	{
                alt1 = 13;
                }
                break;
            case AUG:
            	{
                alt1 = 14;
                }
                break;
            case SEP:
            	{
                alt1 = 15;
                }
                break;
            case OCT:
            	{
                alt1 = 16;
                }
                break;
            case NOV:
            	{
                alt1 = 17;
                }
                break;
            case DEC:
            	{
                alt1 = 18;
                }
                break;
            case MON:
            	{
                alt1 = 19;
                }
                break;
            case TUE:
            	{
                alt1 = 20;
                }
                break;
            case WED:
            	{
                alt1 = 21;
                }
                break;
            case THU:
            	{
                alt1 = 22;
                }
                break;
            case FRI:
            	{
                alt1 = 23;
                }
                break;
            case SAT:
            	{
                alt1 = 24;
                }
                break;
            case SUN:
            	{
                alt1 = 25;
                }
                break;
            case LAST_HOUR:
            	{
                alt1 = 26;
                }
                break;
            case THIS_HOUR:
            	{
                alt1 = 27;
                }
                break;
            case NEXT_HOUR:
            	{
                alt1 = 28;
                }
                break;
            case YESTERDAY:
            	{
                alt1 = 29;
                }
                break;
            case TODAY:
            	{
                alt1 = 30;
                }
                break;
            case TOMORROW:
            	{
                alt1 = 31;
                }
                break;
            case LAST_WEEK:
            	{
                alt1 = 32;
                }
                break;
            case THIS_WEEK:
            	{
                alt1 = 33;
                }
                break;
            case NEXT_WEEK:
            	{
                alt1 = 34;
                }
                break;
            case LAST_MONTH:
            	{
                alt1 = 35;
                }
                break;
            case THIS_MONTH:
            	{
                alt1 = 36;
                }
                break;
            case NEXT_MONTH:
            	{
                alt1 = 37;
                }
                break;
            case LAST_YEAR:
            	{
                alt1 = 38;
                }
                break;
            case THIS_YEAR:
            	{
                alt1 = 39;
                }
                break;
            case NEXT_YEAR:
            	{
                alt1 = 40;
                }
                break;
            	default:
            	    NoViableAltException nvae_d1s0 =
            	        new NoViableAltException("", 1, 0, input);

            	    throw nvae_d1s0;
            }

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
                    // DateTimeFilter.g:17:5: HOUR_ANY_MINUTE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	HOUR_ANY_MINUTE1=(IToken)Match(input,HOUR_ANY_MINUTE,FOLLOW_HOUR_ANY_MINUTE_in_specification62); 
                    		HOUR_ANY_MINUTE1_tree = (object)adaptor.Create(HOUR_ANY_MINUTE1);
                    		adaptor.AddChild(root_0, HOUR_ANY_MINUTE1_tree);

                    	 AddAnyMinuteCondition(((d != null) ? d.Text : null)); 

                    }
                    break;
                case 4 :
                    // DateTimeFilter.g:18:5: FLOW_MONTH
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	FLOW_MONTH2=(IToken)Match(input,FLOW_MONTH,FOLLOW_FLOW_MONTH_in_specification71); 
                    		FLOW_MONTH2_tree = (object)adaptor.Create(FLOW_MONTH2);
                    		adaptor.AddChild(root_0, FLOW_MONTH2_tree);

                    	 AddFlowMonthCondition(((d != null) ? d.Text : null)); 

                    }
                    break;
                case 5 :
                    // DateTimeFilter.g:19:5: FLOW_DAY
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	FLOW_DAY3=(IToken)Match(input,FLOW_DAY,FOLLOW_FLOW_DAY_in_specification79); 
                    		FLOW_DAY3_tree = (object)adaptor.Create(FLOW_DAY3);
                    		adaptor.AddChild(root_0, FLOW_DAY3_tree);

                    	 AddFlowDayCondition(((d != null) ? d.Text : null)); 

                    }
                    break;
                case 6 :
                    // DateTimeFilter.g:20:5: YEAR_MONTH
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	YEAR_MONTH4=(IToken)Match(input,YEAR_MONTH,FOLLOW_YEAR_MONTH_in_specification87); 
                    		YEAR_MONTH4_tree = (object)adaptor.Create(YEAR_MONTH4);
                    		adaptor.AddChild(root_0, YEAR_MONTH4_tree);

                    	 AddYearMonthCondition(((d != null) ? d.Text : null)); 

                    }
                    break;
                case 7 :
                    // DateTimeFilter.g:22:5: JAN
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	JAN5=(IToken)Match(input,JAN,FOLLOW_JAN_in_specification98); 
                    		JAN5_tree = (object)adaptor.Create(JAN5);
                    		adaptor.AddChild(root_0, JAN5_tree);

                    	 AddMonthCondition(1); 

                    }
                    break;
                case 8 :
                    // DateTimeFilter.g:23:5: FEB
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	FEB6=(IToken)Match(input,FEB,FOLLOW_FEB_in_specification106); 
                    		FEB6_tree = (object)adaptor.Create(FEB6);
                    		adaptor.AddChild(root_0, FEB6_tree);

                    	 AddMonthCondition(2); 

                    }
                    break;
                case 9 :
                    // DateTimeFilter.g:24:5: MAR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	MAR7=(IToken)Match(input,MAR,FOLLOW_MAR_in_specification114); 
                    		MAR7_tree = (object)adaptor.Create(MAR7);
                    		adaptor.AddChild(root_0, MAR7_tree);

                    	 AddMonthCondition(3); 

                    }
                    break;
                case 10 :
                    // DateTimeFilter.g:25:5: APR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	APR8=(IToken)Match(input,APR,FOLLOW_APR_in_specification122); 
                    		APR8_tree = (object)adaptor.Create(APR8);
                    		adaptor.AddChild(root_0, APR8_tree);

                    	 AddMonthCondition(4); 

                    }
                    break;
                case 11 :
                    // DateTimeFilter.g:26:5: MAY
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	MAY9=(IToken)Match(input,MAY,FOLLOW_MAY_in_specification130); 
                    		MAY9_tree = (object)adaptor.Create(MAY9);
                    		adaptor.AddChild(root_0, MAY9_tree);

                    	 AddMonthCondition(5); 

                    }
                    break;
                case 12 :
                    // DateTimeFilter.g:27:5: JUN
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	JUN10=(IToken)Match(input,JUN,FOLLOW_JUN_in_specification138); 
                    		JUN10_tree = (object)adaptor.Create(JUN10);
                    		adaptor.AddChild(root_0, JUN10_tree);

                    	 AddMonthCondition(6); 

                    }
                    break;
                case 13 :
                    // DateTimeFilter.g:28:5: JUL
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	JUL11=(IToken)Match(input,JUL,FOLLOW_JUL_in_specification146); 
                    		JUL11_tree = (object)adaptor.Create(JUL11);
                    		adaptor.AddChild(root_0, JUL11_tree);

                    	 AddMonthCondition(7); 

                    }
                    break;
                case 14 :
                    // DateTimeFilter.g:29:5: AUG
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	AUG12=(IToken)Match(input,AUG,FOLLOW_AUG_in_specification154); 
                    		AUG12_tree = (object)adaptor.Create(AUG12);
                    		adaptor.AddChild(root_0, AUG12_tree);

                    	 AddMonthCondition(8); 

                    }
                    break;
                case 15 :
                    // DateTimeFilter.g:30:5: SEP
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	SEP13=(IToken)Match(input,SEP,FOLLOW_SEP_in_specification162); 
                    		SEP13_tree = (object)adaptor.Create(SEP13);
                    		adaptor.AddChild(root_0, SEP13_tree);

                    	 AddMonthCondition(9); 

                    }
                    break;
                case 16 :
                    // DateTimeFilter.g:31:5: OCT
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	OCT14=(IToken)Match(input,OCT,FOLLOW_OCT_in_specification170); 
                    		OCT14_tree = (object)adaptor.Create(OCT14);
                    		adaptor.AddChild(root_0, OCT14_tree);

                    	 AddMonthCondition(10); 

                    }
                    break;
                case 17 :
                    // DateTimeFilter.g:32:5: NOV
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NOV15=(IToken)Match(input,NOV,FOLLOW_NOV_in_specification178); 
                    		NOV15_tree = (object)adaptor.Create(NOV15);
                    		adaptor.AddChild(root_0, NOV15_tree);

                    	 AddMonthCondition(11); 

                    }
                    break;
                case 18 :
                    // DateTimeFilter.g:33:5: DEC
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	DEC16=(IToken)Match(input,DEC,FOLLOW_DEC_in_specification186); 
                    		DEC16_tree = (object)adaptor.Create(DEC16);
                    		adaptor.AddChild(root_0, DEC16_tree);

                    	 AddMonthCondition(12); 

                    }
                    break;
                case 19 :
                    // DateTimeFilter.g:35:5: MON
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	MON17=(IToken)Match(input,MON,FOLLOW_MON_in_specification197); 
                    		MON17_tree = (object)adaptor.Create(MON17);
                    		adaptor.AddChild(root_0, MON17_tree);

                    	 AddDayOfWeekCondition(1); 

                    }
                    break;
                case 20 :
                    // DateTimeFilter.g:36:5: TUE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	TUE18=(IToken)Match(input,TUE,FOLLOW_TUE_in_specification205); 
                    		TUE18_tree = (object)adaptor.Create(TUE18);
                    		adaptor.AddChild(root_0, TUE18_tree);

                    	 AddDayOfWeekCondition(2); 

                    }
                    break;
                case 21 :
                    // DateTimeFilter.g:37:5: WED
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	WED19=(IToken)Match(input,WED,FOLLOW_WED_in_specification213); 
                    		WED19_tree = (object)adaptor.Create(WED19);
                    		adaptor.AddChild(root_0, WED19_tree);

                    	 AddDayOfWeekCondition(3); 

                    }
                    break;
                case 22 :
                    // DateTimeFilter.g:38:5: THU
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	THU20=(IToken)Match(input,THU,FOLLOW_THU_in_specification221); 
                    		THU20_tree = (object)adaptor.Create(THU20);
                    		adaptor.AddChild(root_0, THU20_tree);

                    	 AddDayOfWeekCondition(4); 

                    }
                    break;
                case 23 :
                    // DateTimeFilter.g:39:5: FRI
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	FRI21=(IToken)Match(input,FRI,FOLLOW_FRI_in_specification229); 
                    		FRI21_tree = (object)adaptor.Create(FRI21);
                    		adaptor.AddChild(root_0, FRI21_tree);

                    	 AddDayOfWeekCondition(5); 

                    }
                    break;
                case 24 :
                    // DateTimeFilter.g:40:5: SAT
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	SAT22=(IToken)Match(input,SAT,FOLLOW_SAT_in_specification237); 
                    		SAT22_tree = (object)adaptor.Create(SAT22);
                    		adaptor.AddChild(root_0, SAT22_tree);

                    	 AddDayOfWeekCondition(6); 

                    }
                    break;
                case 25 :
                    // DateTimeFilter.g:41:5: SUN
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	SUN23=(IToken)Match(input,SUN,FOLLOW_SUN_in_specification245); 
                    		SUN23_tree = (object)adaptor.Create(SUN23);
                    		adaptor.AddChild(root_0, SUN23_tree);

                    	 AddDayOfWeekCondition(7); 

                    }
                    break;
                case 26 :
                    // DateTimeFilter.g:43:5: LAST_HOUR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LAST_HOUR24=(IToken)Match(input,LAST_HOUR,FOLLOW_LAST_HOUR_in_specification256); 
                    		LAST_HOUR24_tree = (object)adaptor.Create(LAST_HOUR24);
                    		adaptor.AddChild(root_0, LAST_HOUR24_tree);

                    	 var h1 = new DateTime(Now.Year, Now.Month, Now.Day, Now.Hour, 0, 0); AddDateTimeIntervalCondition(h1 - TimeSpan.FromHours(1), h1); 

                    }
                    break;
                case 27 :
                    // DateTimeFilter.g:44:5: THIS_HOUR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	THIS_HOUR25=(IToken)Match(input,THIS_HOUR,FOLLOW_THIS_HOUR_in_specification264); 
                    		THIS_HOUR25_tree = (object)adaptor.Create(THIS_HOUR25);
                    		adaptor.AddChild(root_0, THIS_HOUR25_tree);

                    	 var h1 = new DateTime(Now.Year, Now.Month, Now.Day, Now.Hour, 0, 0); AddDateTimeIntervalCondition(h1, h1 + TimeSpan.FromHours(1)); 

                    }
                    break;
                case 28 :
                    // DateTimeFilter.g:45:5: NEXT_HOUR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NEXT_HOUR26=(IToken)Match(input,NEXT_HOUR,FOLLOW_NEXT_HOUR_in_specification272); 
                    		NEXT_HOUR26_tree = (object)adaptor.Create(NEXT_HOUR26);
                    		adaptor.AddChild(root_0, NEXT_HOUR26_tree);

                    	 var h1 = new DateTime(Now.Year, Now.Month, Now.Day, Now.Hour, 0, 0); AddDateTimeIntervalCondition(h1 + TimeSpan.FromHours(1), h1 + TimeSpan.FromHours(2)); 

                    }
                    break;
                case 29 :
                    // DateTimeFilter.g:47:5: YESTERDAY
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	YESTERDAY27=(IToken)Match(input,YESTERDAY,FOLLOW_YESTERDAY_in_specification281); 
                    		YESTERDAY27_tree = (object)adaptor.Create(YESTERDAY27);
                    		adaptor.AddChild(root_0, YESTERDAY27_tree);

                    	 AddDateTimeIntervalCondition(Now.Date-TimeSpan.FromDays(1), Now.Date); 

                    }
                    break;
                case 30 :
                    // DateTimeFilter.g:48:5: TODAY
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	TODAY28=(IToken)Match(input,TODAY,FOLLOW_TODAY_in_specification289); 
                    		TODAY28_tree = (object)adaptor.Create(TODAY28);
                    		adaptor.AddChild(root_0, TODAY28_tree);

                    	 AddDateTimeIntervalCondition(Now.Date, Now.Date+TimeSpan.FromDays(1)); 

                    }
                    break;
                case 31 :
                    // DateTimeFilter.g:49:5: TOMORROW
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	TOMORROW29=(IToken)Match(input,TOMORROW,FOLLOW_TOMORROW_in_specification297); 
                    		TOMORROW29_tree = (object)adaptor.Create(TOMORROW29);
                    		adaptor.AddChild(root_0, TOMORROW29_tree);

                    	 AddDateTimeIntervalCondition(Now.Date+TimeSpan.FromDays(1), Now.Date+TimeSpan.FromDays(2)); 

                    }
                    break;
                case 32 :
                    // DateTimeFilter.g:51:5: LAST_WEEK
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LAST_WEEK30=(IToken)Match(input,LAST_WEEK,FOLLOW_LAST_WEEK_in_specification308); 
                    		LAST_WEEK30_tree = (object)adaptor.Create(LAST_WEEK30);
                    		adaptor.AddChild(root_0, LAST_WEEK30_tree);

                    	 var d1=GetFirstDayOfWeek(Now.Date); AddDateTimeIntervalCondition(d1-TimeSpan.FromDays(7), d1); 

                    }
                    break;
                case 33 :
                    // DateTimeFilter.g:52:5: THIS_WEEK
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	THIS_WEEK31=(IToken)Match(input,THIS_WEEK,FOLLOW_THIS_WEEK_in_specification316); 
                    		THIS_WEEK31_tree = (object)adaptor.Create(THIS_WEEK31);
                    		adaptor.AddChild(root_0, THIS_WEEK31_tree);

                    	 var d1=GetFirstDayOfWeek(Now.Date); AddDateTimeIntervalCondition(d1, d1+TimeSpan.FromDays(7)); 

                    }
                    break;
                case 34 :
                    // DateTimeFilter.g:53:5: NEXT_WEEK
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NEXT_WEEK32=(IToken)Match(input,NEXT_WEEK,FOLLOW_NEXT_WEEK_in_specification324); 
                    		NEXT_WEEK32_tree = (object)adaptor.Create(NEXT_WEEK32);
                    		adaptor.AddChild(root_0, NEXT_WEEK32_tree);

                    	 var d1=GetFirstDayOfWeek(Now.Date); AddDateTimeIntervalCondition(d1+TimeSpan.FromDays(7), d1+TimeSpan.FromDays(14)); 

                    }
                    break;
                case 35 :
                    // DateTimeFilter.g:55:5: LAST_MONTH
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LAST_MONTH33=(IToken)Match(input,LAST_MONTH,FOLLOW_LAST_MONTH_in_specification333); 
                    		LAST_MONTH33_tree = (object)adaptor.Create(LAST_MONTH33);
                    		adaptor.AddChild(root_0, LAST_MONTH33_tree);

                    	 var d1=new DateTime(Now.Year, Now.Month, 1); AddDateTimeIntervalCondition(d1.AddMonths(-1), d1); 

                    }
                    break;
                case 36 :
                    // DateTimeFilter.g:56:5: THIS_MONTH
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	THIS_MONTH34=(IToken)Match(input,THIS_MONTH,FOLLOW_THIS_MONTH_in_specification341); 
                    		THIS_MONTH34_tree = (object)adaptor.Create(THIS_MONTH34);
                    		adaptor.AddChild(root_0, THIS_MONTH34_tree);

                    	 var d1=new DateTime(Now.Year, Now.Month, 1); AddDateTimeIntervalCondition(d1, d1.AddMonths(1)); 

                    }
                    break;
                case 37 :
                    // DateTimeFilter.g:57:5: NEXT_MONTH
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NEXT_MONTH35=(IToken)Match(input,NEXT_MONTH,FOLLOW_NEXT_MONTH_in_specification349); 
                    		NEXT_MONTH35_tree = (object)adaptor.Create(NEXT_MONTH35);
                    		adaptor.AddChild(root_0, NEXT_MONTH35_tree);

                    	 var d1=new DateTime(Now.Year, Now.Month, 1); AddDateTimeIntervalCondition(d1.AddMonths(1), d1.AddMonths(2)); 

                    }
                    break;
                case 38 :
                    // DateTimeFilter.g:59:5: LAST_YEAR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LAST_YEAR36=(IToken)Match(input,LAST_YEAR,FOLLOW_LAST_YEAR_in_specification360); 
                    		LAST_YEAR36_tree = (object)adaptor.Create(LAST_YEAR36);
                    		adaptor.AddChild(root_0, LAST_YEAR36_tree);

                    	 var d1=new DateTime(Now.Year, 1, 1); AddDateTimeIntervalCondition(d1.AddYears(-1), d1); 

                    }
                    break;
                case 39 :
                    // DateTimeFilter.g:60:5: THIS_YEAR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	THIS_YEAR37=(IToken)Match(input,THIS_YEAR,FOLLOW_THIS_YEAR_in_specification368); 
                    		THIS_YEAR37_tree = (object)adaptor.Create(THIS_YEAR37);
                    		adaptor.AddChild(root_0, THIS_YEAR37_tree);

                    	 var d1=new DateTime(Now.Year, 1, 1); AddDateTimeIntervalCondition(d1, d1.AddYears(1)); 

                    }
                    break;
                case 40 :
                    // DateTimeFilter.g:61:5: NEXT_YEAR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NEXT_YEAR38=(IToken)Match(input,NEXT_YEAR,FOLLOW_NEXT_YEAR_in_specification376); 
                    		NEXT_YEAR38_tree = (object)adaptor.Create(NEXT_YEAR38);
                    		adaptor.AddChild(root_0, NEXT_YEAR38_tree);

                    	 var d1=new DateTime(Now.Year, 1, 1); AddDateTimeIntervalCondition(d1.AddYears(1), d1.AddYears(2)); 

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
    // DateTimeFilter.g:64:1: interval : (d1= DATE MINUS d2= DATE | d1= DATE t1= TIME MINUS d2= DATE t2= TIME );
    public DateTimeFilterParser.interval_return interval() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.interval_return retval = new DateTimeFilterParser.interval_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken d1 = null;
        IToken d2 = null;
        IToken t1 = null;
        IToken t2 = null;
        IToken MINUS39 = null;
        IToken MINUS40 = null;

        object d1_tree=null;
        object d2_tree=null;
        object t1_tree=null;
        object t2_tree=null;
        object MINUS39_tree=null;
        object MINUS40_tree=null;

        try 
    	{
            // DateTimeFilter.g:64:10: (d1= DATE MINUS d2= DATE | d1= DATE t1= TIME MINUS d2= DATE t2= TIME )
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
                    // DateTimeFilter.g:65:3: d1= DATE MINUS d2= DATE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	d1=(IToken)Match(input,DATE,FOLLOW_DATE_in_interval392); 
                    		d1_tree = (object)adaptor.Create(d1);
                    		adaptor.AddChild(root_0, d1_tree);

                    	MINUS39=(IToken)Match(input,MINUS,FOLLOW_MINUS_in_interval394); 
                    		MINUS39_tree = (object)adaptor.Create(MINUS39);
                    		adaptor.AddChild(root_0, MINUS39_tree);

                    	d2=(IToken)Match(input,DATE,FOLLOW_DATE_in_interval398); 
                    		d2_tree = (object)adaptor.Create(d2);
                    		adaptor.AddChild(root_0, d2_tree);

                    	 AddDateTimeIntervalCondition(ParseDate(((d1 != null) ? d1.Text : null)), ParseDate(((d2 != null) ? d2.Text : null)) + TimeSpan.FromDays(1)); 

                    }
                    break;
                case 2 :
                    // DateTimeFilter.g:66:5: d1= DATE t1= TIME MINUS d2= DATE t2= TIME
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	d1=(IToken)Match(input,DATE,FOLLOW_DATE_in_interval408); 
                    		d1_tree = (object)adaptor.Create(d1);
                    		adaptor.AddChild(root_0, d1_tree);

                    	t1=(IToken)Match(input,TIME,FOLLOW_TIME_in_interval412); 
                    		t1_tree = (object)adaptor.Create(t1);
                    		adaptor.AddChild(root_0, t1_tree);

                    	MINUS40=(IToken)Match(input,MINUS,FOLLOW_MINUS_in_interval414); 
                    		MINUS40_tree = (object)adaptor.Create(MINUS40);
                    		adaptor.AddChild(root_0, MINUS40_tree);

                    	d2=(IToken)Match(input,DATE,FOLLOW_DATE_in_interval418); 
                    		d2_tree = (object)adaptor.Create(d2);
                    		adaptor.AddChild(root_0, d2_tree);

                    	t2=(IToken)Match(input,TIME,FOLLOW_TIME_in_interval422); 
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
    // DateTimeFilter.g:71:1: element : ( specification | interval );
    public DateTimeFilterParser.element_return element() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.element_return retval = new DateTimeFilterParser.element_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        DateTimeFilterParser.specification_return specification41 = default(DateTimeFilterParser.specification_return);

        DateTimeFilterParser.interval_return interval42 = default(DateTimeFilterParser.interval_return);



        try 
    	{
            // DateTimeFilter.g:71:8: ( specification | interval )
            int alt3 = 2;
            int LA3_0 = input.LA(1);

            if ( (LA3_0 == YEAR || (LA3_0 >= HOUR_ANY_MINUTE && LA3_0 <= NEXT_YEAR)) )
            {
                alt3 = 1;
            }
            else if ( (LA3_0 == DATE) )
            {
                int LA3_2 = input.LA(2);

                if ( ((LA3_2 >= MINUS && LA3_2 <= TIME)) )
                {
                    alt3 = 2;
                }
                else if ( (LA3_2 == EOF || (LA3_2 >= YEAR && LA3_2 <= NEXT_YEAR) || (LA3_2 >= COMMA && LA3_2 <= ENDLINE)) )
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
                    // DateTimeFilter.g:72:3: specification
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_specification_in_element435);
                    	specification41 = specification();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, specification41.Tree);

                    }
                    break;
                case 2 :
                    // DateTimeFilter.g:72:19: interval
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_interval_in_element439);
                    	interval42 = interval();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, interval42.Tree);

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
    // DateTimeFilter.g:74:1: factor : ( element )+ ;
    public DateTimeFilterParser.factor_return factor() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.factor_return retval = new DateTimeFilterParser.factor_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        DateTimeFilterParser.element_return element43 = default(DateTimeFilterParser.element_return);



        try 
    	{
            // DateTimeFilter.g:74:8: ( ( element )+ )
            // DateTimeFilter.g:75:3: ( element )+
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// DateTimeFilter.g:75:3: ( element )+
            	int cnt4 = 0;
            	do 
            	{
            	    int alt4 = 2;
            	    int LA4_0 = input.LA(1);

            	    if ( ((LA4_0 >= YEAR && LA4_0 <= NEXT_YEAR)) )
            	    {
            	        alt4 = 1;
            	    }


            	    switch (alt4) 
            		{
            			case 1 :
            			    // DateTimeFilter.g:75:3: element
            			    {
            			    	PushFollow(FOLLOW_element_in_factor451);
            			    	element43 = element();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, element43.Tree);

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
    // DateTimeFilter.g:77:1: list : factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )* ;
    public DateTimeFilterParser.list_return list() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.list_return retval = new DateTimeFilterParser.list_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken COMMA45 = null;
        IToken ENDLINE46 = null;
        IToken ENDLINE48 = null;
        DateTimeFilterParser.factor_return factor44 = default(DateTimeFilterParser.factor_return);

        DateTimeFilterParser.factor_return factor47 = default(DateTimeFilterParser.factor_return);


        object COMMA45_tree=null;
        object ENDLINE46_tree=null;
        object ENDLINE48_tree=null;

        try 
    	{
            // DateTimeFilter.g:77:5: ( factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )* )
            // DateTimeFilter.g:78:3: factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_factor_in_list462);
            	factor44 = factor();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, factor44.Tree);
            	// DateTimeFilter.g:78:10: ( ( COMMA | ( ( ENDLINE )+ ) ) factor )*
            	do 
            	{
            	    int alt7 = 2;
            	    alt7 = dfa7.Predict(input);
            	    switch (alt7) 
            		{
            			case 1 :
            			    // DateTimeFilter.g:78:12: ( COMMA | ( ( ENDLINE )+ ) ) factor
            			    {
            			    	// DateTimeFilter.g:78:12: ( COMMA | ( ( ENDLINE )+ ) )
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
            			    	        // DateTimeFilter.g:78:13: COMMA
            			    	        {
            			    	        	COMMA45=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_list467); 
            			    	        		COMMA45_tree = (object)adaptor.Create(COMMA45);
            			    	        		adaptor.AddChild(root_0, COMMA45_tree);


            			    	        }
            			    	        break;
            			    	    case 2 :
            			    	        // DateTimeFilter.g:78:21: ( ( ENDLINE )+ )
            			    	        {
            			    	        	// DateTimeFilter.g:78:21: ( ( ENDLINE )+ )
            			    	        	// DateTimeFilter.g:78:22: ( ENDLINE )+
            			    	        	{
            			    	        		// DateTimeFilter.g:78:22: ( ENDLINE )+
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
            			    	        				    // DateTimeFilter.g:78:22: ENDLINE
            			    	        				    {
            			    	        				    	ENDLINE46=(IToken)Match(input,ENDLINE,FOLLOW_ENDLINE_in_list472); 
            			    	        				    		ENDLINE46_tree = (object)adaptor.Create(ENDLINE46);
            			    	        				    		adaptor.AddChild(root_0, ENDLINE46_tree);


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
            			    	PushFollow(FOLLOW_factor_in_list479);
            			    	factor47 = factor();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, factor47.Tree);

            			    }
            			    break;

            			default:
            			    goto loop7;
            	    }
            	} while (true);

            	loop7:
            		;	// Stops C# compiler whining that label 'loop7' has no statements

            	// DateTimeFilter.g:78:67: ( ENDLINE )*
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
            			    // DateTimeFilter.g:78:67: ENDLINE
            			    {
            			    	ENDLINE48=(IToken)Match(input,ENDLINE,FOLLOW_ENDLINE_in_list485); 
            			    		ENDLINE48_tree = (object)adaptor.Create(ENDLINE48);
            			    		adaptor.AddChild(root_0, ENDLINE48_tree);


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
    // DateTimeFilter.g:80:1: expr : list ;
    public DateTimeFilterParser.expr_return expr() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.expr_return retval = new DateTimeFilterParser.expr_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        DateTimeFilterParser.list_return list49 = default(DateTimeFilterParser.list_return);



        try 
    	{
            // DateTimeFilter.g:80:5: ( list )
            // DateTimeFilter.g:80:7: list
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_list_in_expr495);
            	list49 = list();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, list49.Tree);

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
        "\x01\x2e\x01\x04\x02\uffff";
    const string DFA7_maxS =
        "\x02\x2f\x02\uffff";
    const string DFA7_acceptS =
        "\x02\uffff\x01\x02\x01\x01";
    const string DFA7_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA7_transitionS = {
            "\x01\x03\x01\x01",
            "\x28\x03\x03\uffff\x01\x01",
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
            get { return "()* loopback of 78:10: ( ( COMMA | ( ( ENDLINE )+ ) ) factor )*"; }
        }

    }

 

    public static readonly BitSet FOLLOW_YEAR_in_specification44 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DATE_in_specification54 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_HOUR_ANY_MINUTE_in_specification62 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_FLOW_MONTH_in_specification71 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_FLOW_DAY_in_specification79 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_YEAR_MONTH_in_specification87 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_JAN_in_specification98 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_FEB_in_specification106 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_MAR_in_specification114 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_APR_in_specification122 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_MAY_in_specification130 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_JUN_in_specification138 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_JUL_in_specification146 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_AUG_in_specification154 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_SEP_in_specification162 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_OCT_in_specification170 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NOV_in_specification178 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DEC_in_specification186 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_MON_in_specification197 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_TUE_in_specification205 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_WED_in_specification213 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_THU_in_specification221 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_FRI_in_specification229 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_SAT_in_specification237 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_SUN_in_specification245 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LAST_HOUR_in_specification256 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_THIS_HOUR_in_specification264 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NEXT_HOUR_in_specification272 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_YESTERDAY_in_specification281 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_TODAY_in_specification289 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_TOMORROW_in_specification297 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LAST_WEEK_in_specification308 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_THIS_WEEK_in_specification316 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NEXT_WEEK_in_specification324 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LAST_MONTH_in_specification333 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_THIS_MONTH_in_specification341 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NEXT_MONTH_in_specification349 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LAST_YEAR_in_specification360 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_THIS_YEAR_in_specification368 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NEXT_YEAR_in_specification376 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DATE_in_interval392 = new BitSet(new ulong[]{0x0000100000000000UL});
    public static readonly BitSet FOLLOW_MINUS_in_interval394 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_DATE_in_interval398 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DATE_in_interval408 = new BitSet(new ulong[]{0x0000200000000000UL});
    public static readonly BitSet FOLLOW_TIME_in_interval412 = new BitSet(new ulong[]{0x0000100000000000UL});
    public static readonly BitSet FOLLOW_MINUS_in_interval414 = new BitSet(new ulong[]{0x0000000000000020UL});
    public static readonly BitSet FOLLOW_DATE_in_interval418 = new BitSet(new ulong[]{0x0000200000000000UL});
    public static readonly BitSet FOLLOW_TIME_in_interval422 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_specification_in_element435 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_interval_in_element439 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_element_in_factor451 = new BitSet(new ulong[]{0x00000FFFFFFFFFF2UL});
    public static readonly BitSet FOLLOW_factor_in_list462 = new BitSet(new ulong[]{0x0000C00000000002UL});
    public static readonly BitSet FOLLOW_COMMA_in_list467 = new BitSet(new ulong[]{0x00000FFFFFFFFFF0UL});
    public static readonly BitSet FOLLOW_ENDLINE_in_list472 = new BitSet(new ulong[]{0x00008FFFFFFFFFF0UL});
    public static readonly BitSet FOLLOW_factor_in_list479 = new BitSet(new ulong[]{0x0000C00000000002UL});
    public static readonly BitSet FOLLOW_ENDLINE_in_list485 = new BitSet(new ulong[]{0x0000800000000002UL});
    public static readonly BitSet FOLLOW_list_in_expr495 = new BitSet(new ulong[]{0x0000000000000002UL});

}
