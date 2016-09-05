// $ANTLR 3.2 Sep 23, 2009 12:02:23 DateTimeFilter.g 2016-09-05 21:10:01

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
		"SQL_VARIABLE", 
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

    public const int LT = 43;
    public const int FLOW_MONTH = 10;
    public const int T_AUG = 20;
    public const int HOUR_ANY_MINUTE = 9;
    public const int YEAR = 7;
    public const int T_OCT = 22;
    public const int T_NEXT = 35;
    public const int EOF = -1;
    public const int T_SEP = 21;
    public const int T_SAT = 30;
    public const int YEAR_MONTH = 12;
    public const int TIME_SECOND = 55;
    public const int COMMA = 56;
    public const int T_NULL = 48;
    public const int T_SUN = 31;
    public const int T_WED = 27;
    public const int TIME_MINUE = 54;
    public const int T_FRI = 29;
    public const int FLOW_DAY = 11;
    public const int DIGIT = 58;
    public const int EQ = 42;
    public const int DOT = 5;
    public const int T_YESTERDAY = 36;
    public const int NE = 47;
    public const int T_WEEK = 39;
    public const int D = 75;
    public const int E = 66;
    public const int F = 77;
    public const int GE = 46;
    public const int T_APR = 16;
    public const int G = 80;
    public const int A = 60;
    public const int TIME_SECOND_FRACTION = 53;
    public const int SQL_VARIABLE = 6;
    public const int B = 78;
    public const int T_THIS = 34;
    public const int C = 81;
    public const int NE2 = 51;
    public const int T_TUE = 26;
    public const int T_TOMORROW = 38;
    public const int L = 59;
    public const int M = 73;
    public const int N = 65;
    public const int O = 68;
    public const int H = 63;
    public const int I = 64;
    public const int J = 76;
    public const int K = 72;
    public const int T_LAST = 32;
    public const int U = 69;
    public const int T = 62;
    public const int WHITESPACE = 83;
    public const int W = 71;
    public const int V = 82;
    public const int T_YEAR = 41;
    public const int Q = 84;
    public const int P = 79;
    public const int S = 61;
    public const int T_MONTH = 40;
    public const int R = 70;
    public const int MINUS = 52;
    public const int Y = 74;
    public const int X = 67;
    public const int EQ2 = 50;
    public const int SQL_LITERAL = 4;
    public const int T_DEC = 24;
    public const int Z = 85;
    public const int T_THU = 28;
    public const int T_HOUR = 33;
    public const int T_JAN = 13;
    public const int T_JUN = 18;
    public const int GT = 45;
    public const int ENDLINE = 57;
    public const int T_MON = 25;
    public const int T_TODAY = 37;
    public const int T_MAY = 17;
    public const int T_NOT = 49;
    public const int DATE = 8;
    public const int T_NOV = 23;
    public const int T_FEB = 14;
    public const int LE = 44;
    public const int T_MAR = 15;
    public const int T_JUL = 19;

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
    // DateTimeFilter.g:14:1: sql_identifier : lit1= SQL_LITERAL ( DOT lit2= SQL_LITERAL )* ;
    public DateTimeFilterParser.sql_identifier_return sql_identifier() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.sql_identifier_return retval = new DateTimeFilterParser.sql_identifier_return();
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
            // DateTimeFilter.g:14:15: (lit1= SQL_LITERAL ( DOT lit2= SQL_LITERAL )* )
            // DateTimeFilter.g:15:3: lit1= SQL_LITERAL ( DOT lit2= SQL_LITERAL )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	lit1=(IToken)Match(input,SQL_LITERAL,FOLLOW_SQL_LITERAL_in_sql_identifier44); 
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
    // DateTimeFilter.g:19:1: sql_variable : var= SQL_VARIABLE ;
    public DateTimeFilterParser.sql_variable_return sql_variable() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.sql_variable_return retval = new DateTimeFilterParser.sql_variable_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken var = null;

        object var_tree=null;

        try 
    	{
            // DateTimeFilter.g:19:13: (var= SQL_VARIABLE )
            // DateTimeFilter.g:20:5: var= SQL_VARIABLE
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
    // DateTimeFilter.g:22:1: sql_name : ( sql_identifier | sql_variable );
    public DateTimeFilterParser.sql_name_return sql_name() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.sql_name_return retval = new DateTimeFilterParser.sql_name_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        DateTimeFilterParser.sql_identifier_return sql_identifier2 = default(DateTimeFilterParser.sql_identifier_return);

        DateTimeFilterParser.sql_variable_return sql_variable3 = default(DateTimeFilterParser.sql_variable_return);



        try 
    	{
            // DateTimeFilter.g:22:10: ( sql_identifier | sql_variable )
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
                    // DateTimeFilter.g:22:12: sql_identifier
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_sql_identifier_in_sql_name92);
                    	sql_identifier2 = sql_identifier();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_identifier2.Tree);

                    }
                    break;
                case 2 :
                    // DateTimeFilter.g:22:29: sql_variable
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
    // DateTimeFilter.g:24:1: specification : (y= YEAR | d= DATE | d= HOUR_ANY_MINUTE | d= FLOW_MONTH | d= FLOW_DAY | d= YEAR_MONTH | T_JAN | T_FEB | T_MAR | T_APR | T_MAY | T_JUN | T_JUL | T_AUG | T_SEP | T_OCT | T_NOV | T_DEC | T_MON | T_TUE | T_WED | T_THU | T_FRI | T_SAT | T_SUN | T_LAST T_HOUR | T_THIS T_HOUR | T_NEXT T_HOUR | T_YESTERDAY | T_TODAY | T_TOMORROW | T_LAST T_WEEK | T_THIS T_WEEK | T_NEXT T_WEEK | T_LAST T_MONTH | T_THIS T_MONTH | T_NEXT T_MONTH | T_LAST T_YEAR | T_THIS T_YEAR | T_NEXT T_YEAR | EQ d= DATE | LT d= DATE | LE d= DATE | GT d= DATE | GE d= DATE | NE d= DATE | d= DATE time_noexact | EQ d= DATE time_noexact | d= DATE time_exact | EQ d= DATE time_exact | LT d= DATE t= time | LE d= DATE t= time | GT d= DATE t= time | GE d= DATE t= time | T_NULL | T_NOT T_NULL | LT sql_name | GT sql_name | LE sql_name | GE sql_name | NE sql_name | EQ sql_name | EQ2 sql_name | NE2 sql_name );
    public DateTimeFilterParser.specification_return specification() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.specification_return retval = new DateTimeFilterParser.specification_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken y = null;
        IToken d = null;
        IToken T_JAN4 = null;
        IToken T_FEB5 = null;
        IToken T_MAR6 = null;
        IToken T_APR7 = null;
        IToken T_MAY8 = null;
        IToken T_JUN9 = null;
        IToken T_JUL10 = null;
        IToken T_AUG11 = null;
        IToken T_SEP12 = null;
        IToken T_OCT13 = null;
        IToken T_NOV14 = null;
        IToken T_DEC15 = null;
        IToken T_MON16 = null;
        IToken T_TUE17 = null;
        IToken T_WED18 = null;
        IToken T_THU19 = null;
        IToken T_FRI20 = null;
        IToken T_SAT21 = null;
        IToken T_SUN22 = null;
        IToken T_LAST23 = null;
        IToken T_HOUR24 = null;
        IToken T_THIS25 = null;
        IToken T_HOUR26 = null;
        IToken T_NEXT27 = null;
        IToken T_HOUR28 = null;
        IToken T_YESTERDAY29 = null;
        IToken T_TODAY30 = null;
        IToken T_TOMORROW31 = null;
        IToken T_LAST32 = null;
        IToken T_WEEK33 = null;
        IToken T_THIS34 = null;
        IToken T_WEEK35 = null;
        IToken T_NEXT36 = null;
        IToken T_WEEK37 = null;
        IToken T_LAST38 = null;
        IToken T_MONTH39 = null;
        IToken T_THIS40 = null;
        IToken T_MONTH41 = null;
        IToken T_NEXT42 = null;
        IToken T_MONTH43 = null;
        IToken T_LAST44 = null;
        IToken T_YEAR45 = null;
        IToken T_THIS46 = null;
        IToken T_YEAR47 = null;
        IToken T_NEXT48 = null;
        IToken T_YEAR49 = null;
        IToken EQ50 = null;
        IToken LT51 = null;
        IToken LE52 = null;
        IToken GT53 = null;
        IToken GE54 = null;
        IToken NE55 = null;
        IToken EQ57 = null;
        IToken EQ60 = null;
        IToken LT62 = null;
        IToken LE63 = null;
        IToken GT64 = null;
        IToken GE65 = null;
        IToken T_NULL66 = null;
        IToken T_NOT67 = null;
        IToken T_NULL68 = null;
        IToken LT69 = null;
        IToken GT71 = null;
        IToken LE73 = null;
        IToken GE75 = null;
        IToken NE77 = null;
        IToken EQ79 = null;
        IToken EQ281 = null;
        IToken NE283 = null;
        DateTimeFilterParser.time_return t = default(DateTimeFilterParser.time_return);

        DateTimeFilterParser.time_noexact_return time_noexact56 = default(DateTimeFilterParser.time_noexact_return);

        DateTimeFilterParser.time_noexact_return time_noexact58 = default(DateTimeFilterParser.time_noexact_return);

        DateTimeFilterParser.time_exact_return time_exact59 = default(DateTimeFilterParser.time_exact_return);

        DateTimeFilterParser.time_exact_return time_exact61 = default(DateTimeFilterParser.time_exact_return);

        DateTimeFilterParser.sql_name_return sql_name70 = default(DateTimeFilterParser.sql_name_return);

        DateTimeFilterParser.sql_name_return sql_name72 = default(DateTimeFilterParser.sql_name_return);

        DateTimeFilterParser.sql_name_return sql_name74 = default(DateTimeFilterParser.sql_name_return);

        DateTimeFilterParser.sql_name_return sql_name76 = default(DateTimeFilterParser.sql_name_return);

        DateTimeFilterParser.sql_name_return sql_name78 = default(DateTimeFilterParser.sql_name_return);

        DateTimeFilterParser.sql_name_return sql_name80 = default(DateTimeFilterParser.sql_name_return);

        DateTimeFilterParser.sql_name_return sql_name82 = default(DateTimeFilterParser.sql_name_return);

        DateTimeFilterParser.sql_name_return sql_name84 = default(DateTimeFilterParser.sql_name_return);


        object y_tree=null;
        object d_tree=null;
        object T_JAN4_tree=null;
        object T_FEB5_tree=null;
        object T_MAR6_tree=null;
        object T_APR7_tree=null;
        object T_MAY8_tree=null;
        object T_JUN9_tree=null;
        object T_JUL10_tree=null;
        object T_AUG11_tree=null;
        object T_SEP12_tree=null;
        object T_OCT13_tree=null;
        object T_NOV14_tree=null;
        object T_DEC15_tree=null;
        object T_MON16_tree=null;
        object T_TUE17_tree=null;
        object T_WED18_tree=null;
        object T_THU19_tree=null;
        object T_FRI20_tree=null;
        object T_SAT21_tree=null;
        object T_SUN22_tree=null;
        object T_LAST23_tree=null;
        object T_HOUR24_tree=null;
        object T_THIS25_tree=null;
        object T_HOUR26_tree=null;
        object T_NEXT27_tree=null;
        object T_HOUR28_tree=null;
        object T_YESTERDAY29_tree=null;
        object T_TODAY30_tree=null;
        object T_TOMORROW31_tree=null;
        object T_LAST32_tree=null;
        object T_WEEK33_tree=null;
        object T_THIS34_tree=null;
        object T_WEEK35_tree=null;
        object T_NEXT36_tree=null;
        object T_WEEK37_tree=null;
        object T_LAST38_tree=null;
        object T_MONTH39_tree=null;
        object T_THIS40_tree=null;
        object T_MONTH41_tree=null;
        object T_NEXT42_tree=null;
        object T_MONTH43_tree=null;
        object T_LAST44_tree=null;
        object T_YEAR45_tree=null;
        object T_THIS46_tree=null;
        object T_YEAR47_tree=null;
        object T_NEXT48_tree=null;
        object T_YEAR49_tree=null;
        object EQ50_tree=null;
        object LT51_tree=null;
        object LE52_tree=null;
        object GT53_tree=null;
        object GE54_tree=null;
        object NE55_tree=null;
        object EQ57_tree=null;
        object EQ60_tree=null;
        object LT62_tree=null;
        object LE63_tree=null;
        object GT64_tree=null;
        object GE65_tree=null;
        object T_NULL66_tree=null;
        object T_NOT67_tree=null;
        object T_NULL68_tree=null;
        object LT69_tree=null;
        object GT71_tree=null;
        object LE73_tree=null;
        object GE75_tree=null;
        object NE77_tree=null;
        object EQ79_tree=null;
        object EQ281_tree=null;
        object NE283_tree=null;

        try 
    	{
            // DateTimeFilter.g:24:14: (y= YEAR | d= DATE | d= HOUR_ANY_MINUTE | d= FLOW_MONTH | d= FLOW_DAY | d= YEAR_MONTH | T_JAN | T_FEB | T_MAR | T_APR | T_MAY | T_JUN | T_JUL | T_AUG | T_SEP | T_OCT | T_NOV | T_DEC | T_MON | T_TUE | T_WED | T_THU | T_FRI | T_SAT | T_SUN | T_LAST T_HOUR | T_THIS T_HOUR | T_NEXT T_HOUR | T_YESTERDAY | T_TODAY | T_TOMORROW | T_LAST T_WEEK | T_THIS T_WEEK | T_NEXT T_WEEK | T_LAST T_MONTH | T_THIS T_MONTH | T_NEXT T_MONTH | T_LAST T_YEAR | T_THIS T_YEAR | T_NEXT T_YEAR | EQ d= DATE | LT d= DATE | LE d= DATE | GT d= DATE | GE d= DATE | NE d= DATE | d= DATE time_noexact | EQ d= DATE time_noexact | d= DATE time_exact | EQ d= DATE time_exact | LT d= DATE t= time | LE d= DATE t= time | GT d= DATE t= time | GE d= DATE t= time | T_NULL | T_NOT T_NULL | LT sql_name | GT sql_name | LE sql_name | GE sql_name | NE sql_name | EQ sql_name | EQ2 sql_name | NE2 sql_name )
            int alt3 = 64;
            alt3 = dfa3.Predict(input);
            switch (alt3) 
            {
                case 1 :
                    // DateTimeFilter.g:25:3: y= YEAR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	y=(IToken)Match(input,YEAR,FOLLOW_YEAR_in_specification107); 
                    		y_tree = (object)adaptor.Create(y);
                    		adaptor.AddChild(root_0, y_tree);

                    	 var d1=new DateTime(Int32.Parse(((y != null) ? y.Text : null)), 1, 1); AddDateTimeIntervalCondition(d1, d1.AddYears(1)); 

                    }
                    break;
                case 2 :
                    // DateTimeFilter.g:26:5: d= DATE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification117); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 AddDateCondition(((d != null) ? d.Text : null)); 

                    }
                    break;
                case 3 :
                    // DateTimeFilter.g:28:5: d= HOUR_ANY_MINUTE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	d=(IToken)Match(input,HOUR_ANY_MINUTE,FOLLOW_HOUR_ANY_MINUTE_in_specification130); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 AddAnyMinuteCondition(((d != null) ? d.Text : null)); 

                    }
                    break;
                case 4 :
                    // DateTimeFilter.g:29:5: d= FLOW_MONTH
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	d=(IToken)Match(input,FLOW_MONTH,FOLLOW_FLOW_MONTH_in_specification141); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 AddFlowMonthCondition(((d != null) ? d.Text : null)); 

                    }
                    break;
                case 5 :
                    // DateTimeFilter.g:30:5: d= FLOW_DAY
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	d=(IToken)Match(input,FLOW_DAY,FOLLOW_FLOW_DAY_in_specification151); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 AddFlowDayCondition(((d != null) ? d.Text : null)); 

                    }
                    break;
                case 6 :
                    // DateTimeFilter.g:31:5: d= YEAR_MONTH
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	d=(IToken)Match(input,YEAR_MONTH,FOLLOW_YEAR_MONTH_in_specification161); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 AddYearMonthCondition(((d != null) ? d.Text : null)); 

                    }
                    break;
                case 7 :
                    // DateTimeFilter.g:33:5: T_JAN
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_JAN4=(IToken)Match(input,T_JAN,FOLLOW_T_JAN_in_specification172); 
                    		T_JAN4_tree = (object)adaptor.Create(T_JAN4);
                    		adaptor.AddChild(root_0, T_JAN4_tree);

                    	 AddMonthCondition(1); 

                    }
                    break;
                case 8 :
                    // DateTimeFilter.g:34:5: T_FEB
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_FEB5=(IToken)Match(input,T_FEB,FOLLOW_T_FEB_in_specification180); 
                    		T_FEB5_tree = (object)adaptor.Create(T_FEB5);
                    		adaptor.AddChild(root_0, T_FEB5_tree);

                    	 AddMonthCondition(2); 

                    }
                    break;
                case 9 :
                    // DateTimeFilter.g:35:5: T_MAR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_MAR6=(IToken)Match(input,T_MAR,FOLLOW_T_MAR_in_specification188); 
                    		T_MAR6_tree = (object)adaptor.Create(T_MAR6);
                    		adaptor.AddChild(root_0, T_MAR6_tree);

                    	 AddMonthCondition(3); 

                    }
                    break;
                case 10 :
                    // DateTimeFilter.g:36:5: T_APR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_APR7=(IToken)Match(input,T_APR,FOLLOW_T_APR_in_specification196); 
                    		T_APR7_tree = (object)adaptor.Create(T_APR7);
                    		adaptor.AddChild(root_0, T_APR7_tree);

                    	 AddMonthCondition(4); 

                    }
                    break;
                case 11 :
                    // DateTimeFilter.g:37:5: T_MAY
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_MAY8=(IToken)Match(input,T_MAY,FOLLOW_T_MAY_in_specification204); 
                    		T_MAY8_tree = (object)adaptor.Create(T_MAY8);
                    		adaptor.AddChild(root_0, T_MAY8_tree);

                    	 AddMonthCondition(5); 

                    }
                    break;
                case 12 :
                    // DateTimeFilter.g:38:5: T_JUN
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_JUN9=(IToken)Match(input,T_JUN,FOLLOW_T_JUN_in_specification212); 
                    		T_JUN9_tree = (object)adaptor.Create(T_JUN9);
                    		adaptor.AddChild(root_0, T_JUN9_tree);

                    	 AddMonthCondition(6); 

                    }
                    break;
                case 13 :
                    // DateTimeFilter.g:39:5: T_JUL
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_JUL10=(IToken)Match(input,T_JUL,FOLLOW_T_JUL_in_specification220); 
                    		T_JUL10_tree = (object)adaptor.Create(T_JUL10);
                    		adaptor.AddChild(root_0, T_JUL10_tree);

                    	 AddMonthCondition(7); 

                    }
                    break;
                case 14 :
                    // DateTimeFilter.g:40:5: T_AUG
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_AUG11=(IToken)Match(input,T_AUG,FOLLOW_T_AUG_in_specification228); 
                    		T_AUG11_tree = (object)adaptor.Create(T_AUG11);
                    		adaptor.AddChild(root_0, T_AUG11_tree);

                    	 AddMonthCondition(8); 

                    }
                    break;
                case 15 :
                    // DateTimeFilter.g:41:5: T_SEP
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_SEP12=(IToken)Match(input,T_SEP,FOLLOW_T_SEP_in_specification236); 
                    		T_SEP12_tree = (object)adaptor.Create(T_SEP12);
                    		adaptor.AddChild(root_0, T_SEP12_tree);

                    	 AddMonthCondition(9); 

                    }
                    break;
                case 16 :
                    // DateTimeFilter.g:42:5: T_OCT
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_OCT13=(IToken)Match(input,T_OCT,FOLLOW_T_OCT_in_specification244); 
                    		T_OCT13_tree = (object)adaptor.Create(T_OCT13);
                    		adaptor.AddChild(root_0, T_OCT13_tree);

                    	 AddMonthCondition(10); 

                    }
                    break;
                case 17 :
                    // DateTimeFilter.g:43:5: T_NOV
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NOV14=(IToken)Match(input,T_NOV,FOLLOW_T_NOV_in_specification252); 
                    		T_NOV14_tree = (object)adaptor.Create(T_NOV14);
                    		adaptor.AddChild(root_0, T_NOV14_tree);

                    	 AddMonthCondition(11); 

                    }
                    break;
                case 18 :
                    // DateTimeFilter.g:44:5: T_DEC
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_DEC15=(IToken)Match(input,T_DEC,FOLLOW_T_DEC_in_specification260); 
                    		T_DEC15_tree = (object)adaptor.Create(T_DEC15);
                    		adaptor.AddChild(root_0, T_DEC15_tree);

                    	 AddMonthCondition(12); 

                    }
                    break;
                case 19 :
                    // DateTimeFilter.g:46:5: T_MON
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_MON16=(IToken)Match(input,T_MON,FOLLOW_T_MON_in_specification271); 
                    		T_MON16_tree = (object)adaptor.Create(T_MON16);
                    		adaptor.AddChild(root_0, T_MON16_tree);

                    	 AddDayOfWeekCondition(DayOfWeek.Monday); 

                    }
                    break;
                case 20 :
                    // DateTimeFilter.g:47:5: T_TUE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_TUE17=(IToken)Match(input,T_TUE,FOLLOW_T_TUE_in_specification279); 
                    		T_TUE17_tree = (object)adaptor.Create(T_TUE17);
                    		adaptor.AddChild(root_0, T_TUE17_tree);

                    	 AddDayOfWeekCondition(DayOfWeek.Tuesday); 

                    }
                    break;
                case 21 :
                    // DateTimeFilter.g:48:5: T_WED
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_WED18=(IToken)Match(input,T_WED,FOLLOW_T_WED_in_specification287); 
                    		T_WED18_tree = (object)adaptor.Create(T_WED18);
                    		adaptor.AddChild(root_0, T_WED18_tree);

                    	 AddDayOfWeekCondition(DayOfWeek.Wednesday); 

                    }
                    break;
                case 22 :
                    // DateTimeFilter.g:49:5: T_THU
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_THU19=(IToken)Match(input,T_THU,FOLLOW_T_THU_in_specification295); 
                    		T_THU19_tree = (object)adaptor.Create(T_THU19);
                    		adaptor.AddChild(root_0, T_THU19_tree);

                    	 AddDayOfWeekCondition(DayOfWeek.Thursday); 

                    }
                    break;
                case 23 :
                    // DateTimeFilter.g:50:5: T_FRI
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_FRI20=(IToken)Match(input,T_FRI,FOLLOW_T_FRI_in_specification303); 
                    		T_FRI20_tree = (object)adaptor.Create(T_FRI20);
                    		adaptor.AddChild(root_0, T_FRI20_tree);

                    	 AddDayOfWeekCondition(DayOfWeek.Friday); 

                    }
                    break;
                case 24 :
                    // DateTimeFilter.g:51:5: T_SAT
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_SAT21=(IToken)Match(input,T_SAT,FOLLOW_T_SAT_in_specification311); 
                    		T_SAT21_tree = (object)adaptor.Create(T_SAT21);
                    		adaptor.AddChild(root_0, T_SAT21_tree);

                    	 AddDayOfWeekCondition(DayOfWeek.Saturday); 

                    }
                    break;
                case 25 :
                    // DateTimeFilter.g:52:5: T_SUN
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_SUN22=(IToken)Match(input,T_SUN,FOLLOW_T_SUN_in_specification319); 
                    		T_SUN22_tree = (object)adaptor.Create(T_SUN22);
                    		adaptor.AddChild(root_0, T_SUN22_tree);

                    	 AddDayOfWeekCondition(DayOfWeek.Sunday); 

                    }
                    break;
                case 26 :
                    // DateTimeFilter.g:54:5: T_LAST T_HOUR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_LAST23=(IToken)Match(input,T_LAST,FOLLOW_T_LAST_in_specification330); 
                    		T_LAST23_tree = (object)adaptor.Create(T_LAST23);
                    		adaptor.AddChild(root_0, T_LAST23_tree);

                    	T_HOUR24=(IToken)Match(input,T_HOUR,FOLLOW_T_HOUR_in_specification332); 
                    		T_HOUR24_tree = (object)adaptor.Create(T_HOUR24);
                    		adaptor.AddChild(root_0, T_HOUR24_tree);

                    	 var h1 = new DateTime(Now.Year, Now.Month, Now.Day, Now.Hour, 0, 0); AddDateTimeIntervalCondition(h1 - TimeSpan.FromHours(1), h1); 

                    }
                    break;
                case 27 :
                    // DateTimeFilter.g:55:5: T_THIS T_HOUR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_THIS25=(IToken)Match(input,T_THIS,FOLLOW_T_THIS_in_specification340); 
                    		T_THIS25_tree = (object)adaptor.Create(T_THIS25);
                    		adaptor.AddChild(root_0, T_THIS25_tree);

                    	T_HOUR26=(IToken)Match(input,T_HOUR,FOLLOW_T_HOUR_in_specification342); 
                    		T_HOUR26_tree = (object)adaptor.Create(T_HOUR26);
                    		adaptor.AddChild(root_0, T_HOUR26_tree);

                    	 var h1 = new DateTime(Now.Year, Now.Month, Now.Day, Now.Hour, 0, 0); AddDateTimeIntervalCondition(h1, h1 + TimeSpan.FromHours(1)); 

                    }
                    break;
                case 28 :
                    // DateTimeFilter.g:56:5: T_NEXT T_HOUR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NEXT27=(IToken)Match(input,T_NEXT,FOLLOW_T_NEXT_in_specification350); 
                    		T_NEXT27_tree = (object)adaptor.Create(T_NEXT27);
                    		adaptor.AddChild(root_0, T_NEXT27_tree);

                    	T_HOUR28=(IToken)Match(input,T_HOUR,FOLLOW_T_HOUR_in_specification352); 
                    		T_HOUR28_tree = (object)adaptor.Create(T_HOUR28);
                    		adaptor.AddChild(root_0, T_HOUR28_tree);

                    	 var h1 = new DateTime(Now.Year, Now.Month, Now.Day, Now.Hour, 0, 0); AddDateTimeIntervalCondition(h1 + TimeSpan.FromHours(1), h1 + TimeSpan.FromHours(2)); 

                    }
                    break;
                case 29 :
                    // DateTimeFilter.g:58:5: T_YESTERDAY
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_YESTERDAY29=(IToken)Match(input,T_YESTERDAY,FOLLOW_T_YESTERDAY_in_specification361); 
                    		T_YESTERDAY29_tree = (object)adaptor.Create(T_YESTERDAY29);
                    		adaptor.AddChild(root_0, T_YESTERDAY29_tree);

                    	 AddDateTimeIntervalCondition(Now.Date-TimeSpan.FromDays(1), Now.Date); 

                    }
                    break;
                case 30 :
                    // DateTimeFilter.g:59:5: T_TODAY
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_TODAY30=(IToken)Match(input,T_TODAY,FOLLOW_T_TODAY_in_specification369); 
                    		T_TODAY30_tree = (object)adaptor.Create(T_TODAY30);
                    		adaptor.AddChild(root_0, T_TODAY30_tree);

                    	 AddDateTimeIntervalCondition(Now.Date, Now.Date+TimeSpan.FromDays(1)); 

                    }
                    break;
                case 31 :
                    // DateTimeFilter.g:60:5: T_TOMORROW
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_TOMORROW31=(IToken)Match(input,T_TOMORROW,FOLLOW_T_TOMORROW_in_specification377); 
                    		T_TOMORROW31_tree = (object)adaptor.Create(T_TOMORROW31);
                    		adaptor.AddChild(root_0, T_TOMORROW31_tree);

                    	 AddDateTimeIntervalCondition(Now.Date+TimeSpan.FromDays(1), Now.Date+TimeSpan.FromDays(2)); 

                    }
                    break;
                case 32 :
                    // DateTimeFilter.g:62:5: T_LAST T_WEEK
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_LAST32=(IToken)Match(input,T_LAST,FOLLOW_T_LAST_in_specification388); 
                    		T_LAST32_tree = (object)adaptor.Create(T_LAST32);
                    		adaptor.AddChild(root_0, T_LAST32_tree);

                    	T_WEEK33=(IToken)Match(input,T_WEEK,FOLLOW_T_WEEK_in_specification390); 
                    		T_WEEK33_tree = (object)adaptor.Create(T_WEEK33);
                    		adaptor.AddChild(root_0, T_WEEK33_tree);

                    	 var d1=GetFirstDayOfWeek(Now.Date); AddDateTimeIntervalCondition(d1-TimeSpan.FromDays(7), d1); 

                    }
                    break;
                case 33 :
                    // DateTimeFilter.g:63:5: T_THIS T_WEEK
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_THIS34=(IToken)Match(input,T_THIS,FOLLOW_T_THIS_in_specification398); 
                    		T_THIS34_tree = (object)adaptor.Create(T_THIS34);
                    		adaptor.AddChild(root_0, T_THIS34_tree);

                    	T_WEEK35=(IToken)Match(input,T_WEEK,FOLLOW_T_WEEK_in_specification400); 
                    		T_WEEK35_tree = (object)adaptor.Create(T_WEEK35);
                    		adaptor.AddChild(root_0, T_WEEK35_tree);

                    	 var d1=GetFirstDayOfWeek(Now.Date); AddDateTimeIntervalCondition(d1, d1+TimeSpan.FromDays(7)); 

                    }
                    break;
                case 34 :
                    // DateTimeFilter.g:64:5: T_NEXT T_WEEK
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NEXT36=(IToken)Match(input,T_NEXT,FOLLOW_T_NEXT_in_specification408); 
                    		T_NEXT36_tree = (object)adaptor.Create(T_NEXT36);
                    		adaptor.AddChild(root_0, T_NEXT36_tree);

                    	T_WEEK37=(IToken)Match(input,T_WEEK,FOLLOW_T_WEEK_in_specification410); 
                    		T_WEEK37_tree = (object)adaptor.Create(T_WEEK37);
                    		adaptor.AddChild(root_0, T_WEEK37_tree);

                    	 var d1=GetFirstDayOfWeek(Now.Date); AddDateTimeIntervalCondition(d1+TimeSpan.FromDays(7), d1+TimeSpan.FromDays(14)); 

                    }
                    break;
                case 35 :
                    // DateTimeFilter.g:66:5: T_LAST T_MONTH
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_LAST38=(IToken)Match(input,T_LAST,FOLLOW_T_LAST_in_specification419); 
                    		T_LAST38_tree = (object)adaptor.Create(T_LAST38);
                    		adaptor.AddChild(root_0, T_LAST38_tree);

                    	T_MONTH39=(IToken)Match(input,T_MONTH,FOLLOW_T_MONTH_in_specification421); 
                    		T_MONTH39_tree = (object)adaptor.Create(T_MONTH39);
                    		adaptor.AddChild(root_0, T_MONTH39_tree);

                    	 var d1=new DateTime(Now.Year, Now.Month, 1); AddDateTimeIntervalCondition(d1.AddMonths(-1), d1); 

                    }
                    break;
                case 36 :
                    // DateTimeFilter.g:67:5: T_THIS T_MONTH
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_THIS40=(IToken)Match(input,T_THIS,FOLLOW_T_THIS_in_specification429); 
                    		T_THIS40_tree = (object)adaptor.Create(T_THIS40);
                    		adaptor.AddChild(root_0, T_THIS40_tree);

                    	T_MONTH41=(IToken)Match(input,T_MONTH,FOLLOW_T_MONTH_in_specification431); 
                    		T_MONTH41_tree = (object)adaptor.Create(T_MONTH41);
                    		adaptor.AddChild(root_0, T_MONTH41_tree);

                    	 var d1=new DateTime(Now.Year, Now.Month, 1); AddDateTimeIntervalCondition(d1, d1.AddMonths(1)); 

                    }
                    break;
                case 37 :
                    // DateTimeFilter.g:68:5: T_NEXT T_MONTH
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NEXT42=(IToken)Match(input,T_NEXT,FOLLOW_T_NEXT_in_specification439); 
                    		T_NEXT42_tree = (object)adaptor.Create(T_NEXT42);
                    		adaptor.AddChild(root_0, T_NEXT42_tree);

                    	T_MONTH43=(IToken)Match(input,T_MONTH,FOLLOW_T_MONTH_in_specification441); 
                    		T_MONTH43_tree = (object)adaptor.Create(T_MONTH43);
                    		adaptor.AddChild(root_0, T_MONTH43_tree);

                    	 var d1=new DateTime(Now.Year, Now.Month, 1); AddDateTimeIntervalCondition(d1.AddMonths(1), d1.AddMonths(2)); 

                    }
                    break;
                case 38 :
                    // DateTimeFilter.g:70:5: T_LAST T_YEAR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_LAST44=(IToken)Match(input,T_LAST,FOLLOW_T_LAST_in_specification452); 
                    		T_LAST44_tree = (object)adaptor.Create(T_LAST44);
                    		adaptor.AddChild(root_0, T_LAST44_tree);

                    	T_YEAR45=(IToken)Match(input,T_YEAR,FOLLOW_T_YEAR_in_specification454); 
                    		T_YEAR45_tree = (object)adaptor.Create(T_YEAR45);
                    		adaptor.AddChild(root_0, T_YEAR45_tree);

                    	 var d1=new DateTime(Now.Year, 1, 1); AddDateTimeIntervalCondition(d1.AddYears(-1), d1); 

                    }
                    break;
                case 39 :
                    // DateTimeFilter.g:71:5: T_THIS T_YEAR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_THIS46=(IToken)Match(input,T_THIS,FOLLOW_T_THIS_in_specification462); 
                    		T_THIS46_tree = (object)adaptor.Create(T_THIS46);
                    		adaptor.AddChild(root_0, T_THIS46_tree);

                    	T_YEAR47=(IToken)Match(input,T_YEAR,FOLLOW_T_YEAR_in_specification464); 
                    		T_YEAR47_tree = (object)adaptor.Create(T_YEAR47);
                    		adaptor.AddChild(root_0, T_YEAR47_tree);

                    	 var d1=new DateTime(Now.Year, 1, 1); AddDateTimeIntervalCondition(d1, d1.AddYears(1)); 

                    }
                    break;
                case 40 :
                    // DateTimeFilter.g:72:5: T_NEXT T_YEAR
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NEXT48=(IToken)Match(input,T_NEXT,FOLLOW_T_NEXT_in_specification472); 
                    		T_NEXT48_tree = (object)adaptor.Create(T_NEXT48);
                    		adaptor.AddChild(root_0, T_NEXT48_tree);

                    	T_YEAR49=(IToken)Match(input,T_YEAR,FOLLOW_T_YEAR_in_specification474); 
                    		T_YEAR49_tree = (object)adaptor.Create(T_YEAR49);
                    		adaptor.AddChild(root_0, T_YEAR49_tree);

                    	 var d1=new DateTime(Now.Year, 1, 1); AddDateTimeIntervalCondition(d1.AddYears(1), d1.AddYears(2)); 

                    }
                    break;
                case 41 :
                    // DateTimeFilter.g:74:5: EQ d= DATE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	EQ50=(IToken)Match(input,EQ,FOLLOW_EQ_in_specification485); 
                    		EQ50_tree = (object)adaptor.Create(EQ50);
                    		adaptor.AddChild(root_0, EQ50_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification489); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 var dt=ParseDate(((d != null) ? d.Text : null));AddDateTimeIntervalCondition(dt, dt + TimeSpan.FromDays(1)); 

                    }
                    break;
                case 42 :
                    // DateTimeFilter.g:75:5: LT d= DATE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LT51=(IToken)Match(input,LT,FOLLOW_LT_in_specification499); 
                    		LT51_tree = (object)adaptor.Create(LT51);
                    		adaptor.AddChild(root_0, LT51_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification503); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 var dt=ParseDate(((d != null) ? d.Text : null));AddDateTimeRelation(dt, "<"); 

                    }
                    break;
                case 43 :
                    // DateTimeFilter.g:76:5: LE d= DATE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LE52=(IToken)Match(input,LE,FOLLOW_LE_in_specification513); 
                    		LE52_tree = (object)adaptor.Create(LE52);
                    		adaptor.AddChild(root_0, LE52_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification517); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 var dt=ParseDate(((d != null) ? d.Text : null));AddDateTimeRelation(dt+TimeSpan.FromDays(1), "<"); 

                    }
                    break;
                case 44 :
                    // DateTimeFilter.g:77:5: GT d= DATE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GT53=(IToken)Match(input,GT,FOLLOW_GT_in_specification527); 
                    		GT53_tree = (object)adaptor.Create(GT53);
                    		adaptor.AddChild(root_0, GT53_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification531); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 var dt=ParseDate(((d != null) ? d.Text : null));AddDateTimeRelation(dt+TimeSpan.FromDays(1), ">="); 

                    }
                    break;
                case 45 :
                    // DateTimeFilter.g:78:5: GE d= DATE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GE54=(IToken)Match(input,GE,FOLLOW_GE_in_specification541); 
                    		GE54_tree = (object)adaptor.Create(GE54);
                    		adaptor.AddChild(root_0, GE54_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification545); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 var dt=ParseDate(((d != null) ? d.Text : null));AddDateTimeRelation(dt, ">="); 

                    }
                    break;
                case 46 :
                    // DateTimeFilter.g:79:5: NE d= DATE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NE55=(IToken)Match(input,NE,FOLLOW_NE_in_specification555); 
                    		NE55_tree = (object)adaptor.Create(NE55);
                    		adaptor.AddChild(root_0, NE55_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification559); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	 var dt=ParseDate(((d != null) ? d.Text : null));AddDateTimeNotIntervalCondition(dt, dt + TimeSpan.FromDays(1)); 

                    }
                    break;
                case 47 :
                    // DateTimeFilter.g:81:5: d= DATE time_noexact
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification570); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	PushFollow(FOLLOW_time_noexact_in_specification572);
                    	time_noexact56 = time_noexact();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, time_noexact56.Tree);
                    	 string time=Pop<string>(); AddDateTimeIntervalCondition(ParseDate(((d != null) ? d.Text : null)) + ParseTime(time), ParseDate(((d != null) ? d.Text : null)) + ParseTimeEnd(time)); 

                    }
                    break;
                case 48 :
                    // DateTimeFilter.g:82:5: EQ d= DATE time_noexact
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	EQ57=(IToken)Match(input,EQ,FOLLOW_EQ_in_specification582); 
                    		EQ57_tree = (object)adaptor.Create(EQ57);
                    		adaptor.AddChild(root_0, EQ57_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification586); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	PushFollow(FOLLOW_time_noexact_in_specification588);
                    	time_noexact58 = time_noexact();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, time_noexact58.Tree);
                    	 string time=Pop<string>(); AddDateTimeIntervalCondition(ParseDate(((d != null) ? d.Text : null)) + ParseTime(time), ParseDate(((d != null) ? d.Text : null)) + ParseTimeEnd(time)); 

                    }
                    break;
                case 49 :
                    // DateTimeFilter.g:84:5: d= DATE time_exact
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification599); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	PushFollow(FOLLOW_time_exact_in_specification601);
                    	time_exact59 = time_exact();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, time_exact59.Tree);
                    	 string time=Pop<string>(); var dt=ParseDate(((d != null) ? d.Text : null)) + ParseTime(time);AddDateTimeRelation(dt, "=");  

                    }
                    break;
                case 50 :
                    // DateTimeFilter.g:85:5: EQ d= DATE time_exact
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	EQ60=(IToken)Match(input,EQ,FOLLOW_EQ_in_specification611); 
                    		EQ60_tree = (object)adaptor.Create(EQ60);
                    		adaptor.AddChild(root_0, EQ60_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification615); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	PushFollow(FOLLOW_time_exact_in_specification617);
                    	time_exact61 = time_exact();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, time_exact61.Tree);
                    	 string time=Pop<string>(); var dt=ParseDate(((d != null) ? d.Text : null)) + ParseTime(time);AddDateTimeRelation(dt, "=");  

                    }
                    break;
                case 51 :
                    // DateTimeFilter.g:87:5: LT d= DATE t= time
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LT62=(IToken)Match(input,LT,FOLLOW_LT_in_specification630); 
                    		LT62_tree = (object)adaptor.Create(LT62);
                    		adaptor.AddChild(root_0, LT62_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification634); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	PushFollow(FOLLOW_time_in_specification638);
                    	t = time();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, t.Tree);
                    	 var dt=ParseDate(((d != null) ? d.Text : null))+ParseTime(((t != null) ? input.ToString((IToken)(t.Start),(IToken)(t.Stop)) : null));AddDateTimeRelation(dt, "<"); 

                    }
                    break;
                case 52 :
                    // DateTimeFilter.g:88:5: LE d= DATE t= time
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LE63=(IToken)Match(input,LE,FOLLOW_LE_in_specification648); 
                    		LE63_tree = (object)adaptor.Create(LE63);
                    		adaptor.AddChild(root_0, LE63_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification652); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	PushFollow(FOLLOW_time_in_specification656);
                    	t = time();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, t.Tree);
                    	 var dt=ParseDate(((d != null) ? d.Text : null))+ParseTimeEnd(((t != null) ? input.ToString((IToken)(t.Start),(IToken)(t.Stop)) : null));AddDateTimeRelation(dt, "<"); 

                    }
                    break;
                case 53 :
                    // DateTimeFilter.g:89:5: GT d= DATE t= time
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GT64=(IToken)Match(input,GT,FOLLOW_GT_in_specification666); 
                    		GT64_tree = (object)adaptor.Create(GT64);
                    		adaptor.AddChild(root_0, GT64_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification670); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	PushFollow(FOLLOW_time_in_specification674);
                    	t = time();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, t.Tree);
                    	 var dt=ParseDate(((d != null) ? d.Text : null))+ParseTime(((t != null) ? input.ToString((IToken)(t.Start),(IToken)(t.Stop)) : null));AddDateTimeRelation(dt, ">"); 

                    }
                    break;
                case 54 :
                    // DateTimeFilter.g:90:5: GE d= DATE t= time
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GE65=(IToken)Match(input,GE,FOLLOW_GE_in_specification684); 
                    		GE65_tree = (object)adaptor.Create(GE65);
                    		adaptor.AddChild(root_0, GE65_tree);

                    	d=(IToken)Match(input,DATE,FOLLOW_DATE_in_specification688); 
                    		d_tree = (object)adaptor.Create(d);
                    		adaptor.AddChild(root_0, d_tree);

                    	PushFollow(FOLLOW_time_in_specification692);
                    	t = time();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, t.Tree);
                    	 var dt=ParseDate(((d != null) ? d.Text : null))+ParseTime(((t != null) ? input.ToString((IToken)(t.Start),(IToken)(t.Stop)) : null));AddDateTimeRelation(dt, ">="); 

                    }
                    break;
                case 55 :
                    // DateTimeFilter.g:91:5: T_NULL
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NULL66=(IToken)Match(input,T_NULL,FOLLOW_T_NULL_in_specification700); 
                    		T_NULL66_tree = (object)adaptor.Create(T_NULL66);
                    		adaptor.AddChild(root_0, T_NULL66_tree);

                    	 AddIsNullCondition(); 

                    }
                    break;
                case 56 :
                    // DateTimeFilter.g:92:5: T_NOT T_NULL
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NOT67=(IToken)Match(input,T_NOT,FOLLOW_T_NOT_in_specification708); 
                    		T_NOT67_tree = (object)adaptor.Create(T_NOT67);
                    		adaptor.AddChild(root_0, T_NOT67_tree);

                    	T_NULL68=(IToken)Match(input,T_NULL,FOLLOW_T_NULL_in_specification710); 
                    		T_NULL68_tree = (object)adaptor.Create(T_NULL68);
                    		adaptor.AddChild(root_0, T_NULL68_tree);

                    	 AddIsNotNullCondition(); 

                    }
                    break;
                case 57 :
                    // DateTimeFilter.g:94:5: LT sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LT69=(IToken)Match(input,LT,FOLLOW_LT_in_specification721); 
                    		LT69_tree = (object)adaptor.Create(LT69);
                    		adaptor.AddChild(root_0, LT69_tree);

                    	PushFollow(FOLLOW_sql_name_in_specification723);
                    	sql_name70 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name70.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), "<"); 

                    }
                    break;
                case 58 :
                    // DateTimeFilter.g:95:5: GT sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GT71=(IToken)Match(input,GT,FOLLOW_GT_in_specification732); 
                    		GT71_tree = (object)adaptor.Create(GT71);
                    		adaptor.AddChild(root_0, GT71_tree);

                    	PushFollow(FOLLOW_sql_name_in_specification734);
                    	sql_name72 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name72.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), ">"); 

                    }
                    break;
                case 59 :
                    // DateTimeFilter.g:96:5: LE sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LE73=(IToken)Match(input,LE,FOLLOW_LE_in_specification743); 
                    		LE73_tree = (object)adaptor.Create(LE73);
                    		adaptor.AddChild(root_0, LE73_tree);

                    	PushFollow(FOLLOW_sql_name_in_specification745);
                    	sql_name74 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name74.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), "<="); 

                    }
                    break;
                case 60 :
                    // DateTimeFilter.g:97:5: GE sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GE75=(IToken)Match(input,GE,FOLLOW_GE_in_specification754); 
                    		GE75_tree = (object)adaptor.Create(GE75);
                    		adaptor.AddChild(root_0, GE75_tree);

                    	PushFollow(FOLLOW_sql_name_in_specification756);
                    	sql_name76 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name76.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), ">="); 

                    }
                    break;
                case 61 :
                    // DateTimeFilter.g:98:5: NE sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NE77=(IToken)Match(input,NE,FOLLOW_NE_in_specification765); 
                    		NE77_tree = (object)adaptor.Create(NE77);
                    		adaptor.AddChild(root_0, NE77_tree);

                    	PushFollow(FOLLOW_sql_name_in_specification767);
                    	sql_name78 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name78.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), "<>"); 

                    }
                    break;
                case 62 :
                    // DateTimeFilter.g:99:5: EQ sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	EQ79=(IToken)Match(input,EQ,FOLLOW_EQ_in_specification776); 
                    		EQ79_tree = (object)adaptor.Create(EQ79);
                    		adaptor.AddChild(root_0, EQ79_tree);

                    	PushFollow(FOLLOW_sql_name_in_specification778);
                    	sql_name80 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name80.Tree);
                    	 AddSqlLiteralRelation(Pop<string>(), "="); 

                    }
                    break;
                case 63 :
                    // DateTimeFilter.g:100:5: EQ2 sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	EQ281=(IToken)Match(input,EQ2,FOLLOW_EQ2_in_specification786); 
                    		EQ281_tree = (object)adaptor.Create(EQ281);
                    		adaptor.AddChild(root_0, EQ281_tree);

                    	PushFollow(FOLLOW_sql_name_in_specification788);
                    	sql_name82 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name82.Tree);
                    	 AddSqlLiteralRelationWithNullTest_EQ(Pop<string>()); 

                    }
                    break;
                case 64 :
                    // DateTimeFilter.g:101:5: NE2 sql_name
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NE283=(IToken)Match(input,NE2,FOLLOW_NE2_in_specification797); 
                    		NE283_tree = (object)adaptor.Create(NE283);
                    		adaptor.AddChild(root_0, NE283_tree);

                    	PushFollow(FOLLOW_sql_name_in_specification799);
                    	sql_name84 = sql_name();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, sql_name84.Tree);
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
    // DateTimeFilter.g:105:1: interval : (d1= DATE MINUS d2= DATE | d1= DATE t1= time MINUS d2= DATE t2= time );
    public DateTimeFilterParser.interval_return interval() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.interval_return retval = new DateTimeFilterParser.interval_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken d1 = null;
        IToken d2 = null;
        IToken MINUS85 = null;
        IToken MINUS86 = null;
        DateTimeFilterParser.time_return t1 = default(DateTimeFilterParser.time_return);

        DateTimeFilterParser.time_return t2 = default(DateTimeFilterParser.time_return);


        object d1_tree=null;
        object d2_tree=null;
        object MINUS85_tree=null;
        object MINUS86_tree=null;

        try 
    	{
            // DateTimeFilter.g:105:10: (d1= DATE MINUS d2= DATE | d1= DATE t1= time MINUS d2= DATE t2= time )
            int alt4 = 2;
            int LA4_0 = input.LA(1);

            if ( (LA4_0 == DATE) )
            {
                int LA4_1 = input.LA(2);

                if ( (LA4_1 == MINUS) )
                {
                    alt4 = 1;
                }
                else if ( ((LA4_1 >= TIME_SECOND_FRACTION && LA4_1 <= TIME_SECOND)) )
                {
                    alt4 = 2;
                }
                else 
                {
                    NoViableAltException nvae_d4s1 =
                        new NoViableAltException("", 4, 1, input);

                    throw nvae_d4s1;
                }
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
                    // DateTimeFilter.g:106:3: d1= DATE MINUS d2= DATE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	d1=(IToken)Match(input,DATE,FOLLOW_DATE_in_interval818); 
                    		d1_tree = (object)adaptor.Create(d1);
                    		adaptor.AddChild(root_0, d1_tree);

                    	MINUS85=(IToken)Match(input,MINUS,FOLLOW_MINUS_in_interval820); 
                    		MINUS85_tree = (object)adaptor.Create(MINUS85);
                    		adaptor.AddChild(root_0, MINUS85_tree);

                    	d2=(IToken)Match(input,DATE,FOLLOW_DATE_in_interval824); 
                    		d2_tree = (object)adaptor.Create(d2);
                    		adaptor.AddChild(root_0, d2_tree);

                    	 AddDateTimeIntervalCondition(ParseDate(((d1 != null) ? d1.Text : null)), ParseDate(((d2 != null) ? d2.Text : null)) + TimeSpan.FromDays(1)); 

                    }
                    break;
                case 2 :
                    // DateTimeFilter.g:107:5: d1= DATE t1= time MINUS d2= DATE t2= time
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	d1=(IToken)Match(input,DATE,FOLLOW_DATE_in_interval834); 
                    		d1_tree = (object)adaptor.Create(d1);
                    		adaptor.AddChild(root_0, d1_tree);

                    	PushFollow(FOLLOW_time_in_interval838);
                    	t1 = time();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, t1.Tree);
                    	MINUS86=(IToken)Match(input,MINUS,FOLLOW_MINUS_in_interval840); 
                    		MINUS86_tree = (object)adaptor.Create(MINUS86);
                    		adaptor.AddChild(root_0, MINUS86_tree);

                    	d2=(IToken)Match(input,DATE,FOLLOW_DATE_in_interval844); 
                    		d2_tree = (object)adaptor.Create(d2);
                    		adaptor.AddChild(root_0, d2_tree);

                    	PushFollow(FOLLOW_time_in_interval848);
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
    // DateTimeFilter.g:112:1: time : ( time_exact | time_noexact );
    public DateTimeFilterParser.time_return time() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.time_return retval = new DateTimeFilterParser.time_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        DateTimeFilterParser.time_exact_return time_exact87 = default(DateTimeFilterParser.time_exact_return);

        DateTimeFilterParser.time_noexact_return time_noexact88 = default(DateTimeFilterParser.time_noexact_return);



        try 
    	{
            // DateTimeFilter.g:112:5: ( time_exact | time_noexact )
            int alt5 = 2;
            int LA5_0 = input.LA(1);

            if ( (LA5_0 == TIME_SECOND_FRACTION) )
            {
                alt5 = 1;
            }
            else if ( ((LA5_0 >= TIME_MINUE && LA5_0 <= TIME_SECOND)) )
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
                    // DateTimeFilter.g:113:4: time_exact
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_time_exact_in_time861);
                    	time_exact87 = time_exact();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, time_exact87.Tree);

                    }
                    break;
                case 2 :
                    // DateTimeFilter.g:113:17: time_noexact
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_time_noexact_in_time865);
                    	time_noexact88 = time_noexact();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, time_noexact88.Tree);

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
    // DateTimeFilter.g:115:1: time_exact : t= TIME_SECOND_FRACTION ;
    public DateTimeFilterParser.time_exact_return time_exact() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.time_exact_return retval = new DateTimeFilterParser.time_exact_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken t = null;

        object t_tree=null;

        try 
    	{
            // DateTimeFilter.g:115:11: (t= TIME_SECOND_FRACTION )
            // DateTimeFilter.g:116:3: t= TIME_SECOND_FRACTION
            {
            	root_0 = (object)adaptor.GetNilNode();

            	t=(IToken)Match(input,TIME_SECOND_FRACTION,FOLLOW_TIME_SECOND_FRACTION_in_time_exact880); 
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
    // DateTimeFilter.g:118:1: time_noexact : (t= TIME_MINUE | t= TIME_SECOND );
    public DateTimeFilterParser.time_noexact_return time_noexact() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.time_noexact_return retval = new DateTimeFilterParser.time_noexact_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken t = null;

        object t_tree=null;

        try 
    	{
            // DateTimeFilter.g:118:13: (t= TIME_MINUE | t= TIME_SECOND )
            int alt6 = 2;
            int LA6_0 = input.LA(1);

            if ( (LA6_0 == TIME_MINUE) )
            {
                alt6 = 1;
            }
            else if ( (LA6_0 == TIME_SECOND) )
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
                    // DateTimeFilter.g:119:3: t= TIME_MINUE
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	t=(IToken)Match(input,TIME_MINUE,FOLLOW_TIME_MINUE_in_time_noexact896); 
                    		t_tree = (object)adaptor.Create(t);
                    		adaptor.AddChild(root_0, t_tree);

                    	 Push(((t != null) ? t.Text : null)); 

                    }
                    break;
                case 2 :
                    // DateTimeFilter.g:119:37: t= TIME_SECOND
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	t=(IToken)Match(input,TIME_SECOND,FOLLOW_TIME_SECOND_in_time_noexact904); 
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
    // DateTimeFilter.g:121:1: element : ( specification | interval );
    public DateTimeFilterParser.element_return element() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.element_return retval = new DateTimeFilterParser.element_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        DateTimeFilterParser.specification_return specification89 = default(DateTimeFilterParser.specification_return);

        DateTimeFilterParser.interval_return interval90 = default(DateTimeFilterParser.interval_return);



        try 
    	{
            // DateTimeFilter.g:121:8: ( specification | interval )
            int alt7 = 2;
            int LA7_0 = input.LA(1);

            if ( (LA7_0 == YEAR || (LA7_0 >= HOUR_ANY_MINUTE && LA7_0 <= T_LAST) || (LA7_0 >= T_THIS && LA7_0 <= T_TOMORROW) || (LA7_0 >= EQ && LA7_0 <= NE2)) )
            {
                alt7 = 1;
            }
            else if ( (LA7_0 == DATE) )
            {
                switch ( input.LA(2) ) 
                {
                case MINUS:
                	{
                    alt7 = 2;
                    }
                    break;
                case TIME_SECOND_FRACTION:
                	{
                    int LA7_4 = input.LA(3);

                    if ( (LA7_4 == MINUS) )
                    {
                        alt7 = 2;
                    }
                    else if ( (LA7_4 == EOF || (LA7_4 >= YEAR && LA7_4 <= T_LAST) || (LA7_4 >= T_THIS && LA7_4 <= T_TOMORROW) || (LA7_4 >= EQ && LA7_4 <= NE2) || (LA7_4 >= COMMA && LA7_4 <= ENDLINE)) )
                    {
                        alt7 = 1;
                    }
                    else 
                    {
                        NoViableAltException nvae_d7s4 =
                            new NoViableAltException("", 7, 4, input);

                        throw nvae_d7s4;
                    }
                    }
                    break;
                case TIME_MINUE:
                	{
                    int LA7_5 = input.LA(3);

                    if ( (LA7_5 == EOF || (LA7_5 >= YEAR && LA7_5 <= T_LAST) || (LA7_5 >= T_THIS && LA7_5 <= T_TOMORROW) || (LA7_5 >= EQ && LA7_5 <= NE2) || (LA7_5 >= COMMA && LA7_5 <= ENDLINE)) )
                    {
                        alt7 = 1;
                    }
                    else if ( (LA7_5 == MINUS) )
                    {
                        alt7 = 2;
                    }
                    else 
                    {
                        NoViableAltException nvae_d7s5 =
                            new NoViableAltException("", 7, 5, input);

                        throw nvae_d7s5;
                    }
                    }
                    break;
                case TIME_SECOND:
                	{
                    int LA7_6 = input.LA(3);

                    if ( (LA7_6 == EOF || (LA7_6 >= YEAR && LA7_6 <= T_LAST) || (LA7_6 >= T_THIS && LA7_6 <= T_TOMORROW) || (LA7_6 >= EQ && LA7_6 <= NE2) || (LA7_6 >= COMMA && LA7_6 <= ENDLINE)) )
                    {
                        alt7 = 1;
                    }
                    else if ( (LA7_6 == MINUS) )
                    {
                        alt7 = 2;
                    }
                    else 
                    {
                        NoViableAltException nvae_d7s6 =
                            new NoViableAltException("", 7, 6, input);

                        throw nvae_d7s6;
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
                    alt7 = 1;
                    }
                    break;
                	default:
                	    NoViableAltException nvae_d7s2 =
                	        new NoViableAltException("", 7, 2, input);

                	    throw nvae_d7s2;
                }

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
                    // DateTimeFilter.g:122:3: specification
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_specification_in_element916);
                    	specification89 = specification();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, specification89.Tree);

                    }
                    break;
                case 2 :
                    // DateTimeFilter.g:122:19: interval
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_interval_in_element920);
                    	interval90 = interval();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, interval90.Tree);

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
    // DateTimeFilter.g:124:1: factor : ( element )+ ;
    public DateTimeFilterParser.factor_return factor() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.factor_return retval = new DateTimeFilterParser.factor_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        DateTimeFilterParser.element_return element91 = default(DateTimeFilterParser.element_return);



        try 
    	{
            // DateTimeFilter.g:124:8: ( ( element )+ )
            // DateTimeFilter.g:125:3: ( element )+
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// DateTimeFilter.g:125:3: ( element )+
            	int cnt8 = 0;
            	do 
            	{
            	    int alt8 = 2;
            	    int LA8_0 = input.LA(1);

            	    if ( ((LA8_0 >= YEAR && LA8_0 <= T_LAST) || (LA8_0 >= T_THIS && LA8_0 <= T_TOMORROW) || (LA8_0 >= EQ && LA8_0 <= NE2)) )
            	    {
            	        alt8 = 1;
            	    }


            	    switch (alt8) 
            		{
            			case 1 :
            			    // DateTimeFilter.g:125:3: element
            			    {
            			    	PushFollow(FOLLOW_element_in_factor932);
            			    	element91 = element();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, element91.Tree);

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
    // DateTimeFilter.g:127:1: list : factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )* ;
    public DateTimeFilterParser.list_return list() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.list_return retval = new DateTimeFilterParser.list_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken COMMA93 = null;
        IToken ENDLINE94 = null;
        IToken ENDLINE96 = null;
        DateTimeFilterParser.factor_return factor92 = default(DateTimeFilterParser.factor_return);

        DateTimeFilterParser.factor_return factor95 = default(DateTimeFilterParser.factor_return);


        object COMMA93_tree=null;
        object ENDLINE94_tree=null;
        object ENDLINE96_tree=null;

        try 
    	{
            // DateTimeFilter.g:127:5: ( factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )* )
            // DateTimeFilter.g:128:3: factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_factor_in_list943);
            	factor92 = factor();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, factor92.Tree);
            	// DateTimeFilter.g:128:10: ( ( COMMA | ( ( ENDLINE )+ ) ) factor )*
            	do 
            	{
            	    int alt11 = 2;
            	    alt11 = dfa11.Predict(input);
            	    switch (alt11) 
            		{
            			case 1 :
            			    // DateTimeFilter.g:128:12: ( COMMA | ( ( ENDLINE )+ ) ) factor
            			    {
            			    	// DateTimeFilter.g:128:12: ( COMMA | ( ( ENDLINE )+ ) )
            			    	int alt10 = 2;
            			    	int LA10_0 = input.LA(1);

            			    	if ( (LA10_0 == COMMA) )
            			    	{
            			    	    alt10 = 1;
            			    	}
            			    	else if ( (LA10_0 == ENDLINE) )
            			    	{
            			    	    alt10 = 2;
            			    	}
            			    	else 
            			    	{
            			    	    NoViableAltException nvae_d10s0 =
            			    	        new NoViableAltException("", 10, 0, input);

            			    	    throw nvae_d10s0;
            			    	}
            			    	switch (alt10) 
            			    	{
            			    	    case 1 :
            			    	        // DateTimeFilter.g:128:13: COMMA
            			    	        {
            			    	        	COMMA93=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_list948); 
            			    	        		COMMA93_tree = (object)adaptor.Create(COMMA93);
            			    	        		adaptor.AddChild(root_0, COMMA93_tree);


            			    	        }
            			    	        break;
            			    	    case 2 :
            			    	        // DateTimeFilter.g:128:21: ( ( ENDLINE )+ )
            			    	        {
            			    	        	// DateTimeFilter.g:128:21: ( ( ENDLINE )+ )
            			    	        	// DateTimeFilter.g:128:22: ( ENDLINE )+
            			    	        	{
            			    	        		// DateTimeFilter.g:128:22: ( ENDLINE )+
            			    	        		int cnt9 = 0;
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
            			    	        				    // DateTimeFilter.g:128:22: ENDLINE
            			    	        				    {
            			    	        				    	ENDLINE94=(IToken)Match(input,ENDLINE,FOLLOW_ENDLINE_in_list953); 
            			    	        				    		ENDLINE94_tree = (object)adaptor.Create(ENDLINE94);
            			    	        				    		adaptor.AddChild(root_0, ENDLINE94_tree);


            			    	        				    }
            			    	        				    break;

            			    	        				default:
            			    	        				    if ( cnt9 >= 1 ) goto loop9;
            			    	        			            EarlyExitException eee9 =
            			    	        			                new EarlyExitException(9, input);
            			    	        			            throw eee9;
            			    	        		    }
            			    	        		    cnt9++;
            			    	        		} while (true);

            			    	        		loop9:
            			    	        			;	// Stops C# compiler whining that label 'loop9' has no statements


            			    	        	}


            			    	        }
            			    	        break;

            			    	}

            			    	 AddAndCondition(); 
            			    	PushFollow(FOLLOW_factor_in_list960);
            			    	factor95 = factor();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, factor95.Tree);

            			    }
            			    break;

            			default:
            			    goto loop11;
            	    }
            	} while (true);

            	loop11:
            		;	// Stops C# compiler whining that label 'loop11' has no statements

            	// DateTimeFilter.g:128:67: ( ENDLINE )*
            	do 
            	{
            	    int alt12 = 2;
            	    int LA12_0 = input.LA(1);

            	    if ( (LA12_0 == ENDLINE) )
            	    {
            	        alt12 = 1;
            	    }


            	    switch (alt12) 
            		{
            			case 1 :
            			    // DateTimeFilter.g:128:67: ENDLINE
            			    {
            			    	ENDLINE96=(IToken)Match(input,ENDLINE,FOLLOW_ENDLINE_in_list966); 
            			    		ENDLINE96_tree = (object)adaptor.Create(ENDLINE96);
            			    		adaptor.AddChild(root_0, ENDLINE96_tree);


            			    }
            			    break;

            			default:
            			    goto loop12;
            	    }
            	} while (true);

            	loop12:
            		;	// Stops C# compiler whining that label 'loop12' has no statements


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
    // DateTimeFilter.g:130:1: expr : list ;
    public DateTimeFilterParser.expr_return expr() // throws RecognitionException [1]
    {   
        DateTimeFilterParser.expr_return retval = new DateTimeFilterParser.expr_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        DateTimeFilterParser.list_return list97 = default(DateTimeFilterParser.list_return);



        try 
    	{
            // DateTimeFilter.g:130:5: ( list )
            // DateTimeFilter.g:130:7: list
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_list_in_expr976);
            	list97 = list();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, list97.Tree);

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
   	protected DFA11 dfa11;
	private void InitializeCyclicDFAs()
	{
    	this.dfa3 = new DFA3(this);
    	this.dfa11 = new DFA11(this);
	}

    const string DFA3_eotS =
        "\x50\uffff";
    const string DFA3_eofS =
        "\x02\uffff\x01\x2b\x36\uffff\x01\x45\x01\uffff\x01\x49\x01\uffff"+
        "\x01\x4a\x01\uffff\x01\x4d\x01\uffff\x01\x4e\x0e\uffff";
    const string DFA3_minS =
        "\x01\x07\x01\uffff\x01\x07\x17\uffff\x03\x21\x03\uffff\x06\x04"+
        "\x13\uffff\x01\x07\x01\uffff\x01\x07\x01\uffff\x01\x07\x01\uffff"+
        "\x01\x07\x01\uffff\x01\x07\x0e\uffff";
    const string DFA3_maxS =
        "\x01\x33\x01\uffff\x01\x39\x17\uffff\x03\x29\x03\uffff\x06\x08"+
        "\x13\uffff\x01\x39\x01\uffff\x01\x39\x01\uffff\x01\x39\x01\uffff"+
        "\x01\x39\x01\uffff\x01\x39\x0e\uffff";
    const string DFA3_acceptS =
        "\x01\uffff\x01\x01\x01\uffff\x01\x03\x01\x04\x01\x05\x01\x06\x01"+
        "\x07\x01\x08\x01\x09\x01\x0a\x01\x0b\x01\x0c\x01\x0d\x01\x0e\x01"+
        "\x0f\x01\x10\x01\x11\x01\x12\x01\x13\x01\x14\x01\x15\x01\x16\x01"+
        "\x17\x01\x18\x01\x19\x03\uffff\x01\x1d\x01\x1e\x01\x1f\x06\uffff"+
        "\x01\x37\x01\x38\x01\x3f\x01\x40\x01\x31\x01\x02\x01\x2f\x01\x1a"+
        "\x01\x20\x01\x23\x01\x26\x01\x1b\x01\x21\x01\x24\x01\x27\x01\x1c"+
        "\x01\x22\x01\x25\x01\x28\x01\uffff\x01\x3e\x01\uffff\x01\x39\x01"+
        "\uffff\x01\x3b\x01\uffff\x01\x3a\x01\uffff\x01\x3c\x01\x2e\x01\x3d"+
        "\x01\x29\x01\x32\x01\x30\x01\x33\x01\x2a\x01\x2b\x01\x34\x01\x35"+
        "\x01\x2c\x01\x2d\x01\x36";
    const string DFA3_specialS =
        "\x50\uffff}>";
    static readonly string[] DFA3_transitionS = {
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
            "\x01\x3a\x01\uffff\x01\x3a\x01\uffff\x01\x39",
            "\x01\x3c\x01\uffff\x01\x3c\x01\uffff\x01\x3b",
            "\x01\x3e\x01\uffff\x01\x3e\x01\uffff\x01\x3d",
            "\x01\x40\x01\uffff\x01\x40\x01\uffff\x01\x3f",
            "\x01\x42\x01\uffff\x01\x42\x01\uffff\x01\x41",
            "\x01\x44\x01\uffff\x01\x44\x01\uffff\x01\x43",
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
            "\x46\x02\x47\x02\x45",
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
            get { return "24:1: specification : (y= YEAR | d= DATE | d= HOUR_ANY_MINUTE | d= FLOW_MONTH | d= FLOW_DAY | d= YEAR_MONTH | T_JAN | T_FEB | T_MAR | T_APR | T_MAY | T_JUN | T_JUL | T_AUG | T_SEP | T_OCT | T_NOV | T_DEC | T_MON | T_TUE | T_WED | T_THU | T_FRI | T_SAT | T_SUN | T_LAST T_HOUR | T_THIS T_HOUR | T_NEXT T_HOUR | T_YESTERDAY | T_TODAY | T_TOMORROW | T_LAST T_WEEK | T_THIS T_WEEK | T_NEXT T_WEEK | T_LAST T_MONTH | T_THIS T_MONTH | T_NEXT T_MONTH | T_LAST T_YEAR | T_THIS T_YEAR | T_NEXT T_YEAR | EQ d= DATE | LT d= DATE | LE d= DATE | GT d= DATE | GE d= DATE | NE d= DATE | d= DATE time_noexact | EQ d= DATE time_noexact | d= DATE time_exact | EQ d= DATE time_exact | LT d= DATE t= time | LE d= DATE t= time | GT d= DATE t= time | GE d= DATE t= time | T_NULL | T_NOT T_NULL | LT sql_name | GT sql_name | LE sql_name | GE sql_name | NE sql_name | EQ sql_name | EQ2 sql_name | NE2 sql_name );"; }
        }

    }

    const string DFA11_eotS =
        "\x04\uffff";
    const string DFA11_eofS =
        "\x02\x02\x02\uffff";
    const string DFA11_minS =
        "\x01\x38\x01\x07\x02\uffff";
    const string DFA11_maxS =
        "\x02\x39\x02\uffff";
    const string DFA11_acceptS =
        "\x02\uffff\x01\x02\x01\x01";
    const string DFA11_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA11_transitionS = {
            "\x01\x03\x01\x01",
            "\x1a\x03\x01\uffff\x05\x03\x03\uffff\x0a\x03\x05\uffff\x01"+
            "\x01",
            "",
            ""
    };

    static readonly short[] DFA11_eot = DFA.UnpackEncodedString(DFA11_eotS);
    static readonly short[] DFA11_eof = DFA.UnpackEncodedString(DFA11_eofS);
    static readonly char[] DFA11_min = DFA.UnpackEncodedStringToUnsignedChars(DFA11_minS);
    static readonly char[] DFA11_max = DFA.UnpackEncodedStringToUnsignedChars(DFA11_maxS);
    static readonly short[] DFA11_accept = DFA.UnpackEncodedString(DFA11_acceptS);
    static readonly short[] DFA11_special = DFA.UnpackEncodedString(DFA11_specialS);
    static readonly short[][] DFA11_transition = DFA.UnpackEncodedStringArray(DFA11_transitionS);

    protected class DFA11 : DFA
    {
        public DFA11(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 11;
            this.eot = DFA11_eot;
            this.eof = DFA11_eof;
            this.min = DFA11_min;
            this.max = DFA11_max;
            this.accept = DFA11_accept;
            this.special = DFA11_special;
            this.transition = DFA11_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 128:10: ( ( COMMA | ( ( ENDLINE )+ ) ) factor )*"; }
        }

    }

 

    public static readonly BitSet FOLLOW_SQL_LITERAL_in_sql_identifier44 = new BitSet(new ulong[]{0x0000000000000022UL});
    public static readonly BitSet FOLLOW_DOT_in_sql_identifier51 = new BitSet(new ulong[]{0x0000000000000010UL});
    public static readonly BitSet FOLLOW_SQL_LITERAL_in_sql_identifier55 = new BitSet(new ulong[]{0x0000000000000022UL});
    public static readonly BitSet FOLLOW_SQL_VARIABLE_in_sql_variable80 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_sql_identifier_in_sql_name92 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_sql_variable_in_sql_name96 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_YEAR_in_specification107 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DATE_in_specification117 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_HOUR_ANY_MINUTE_in_specification130 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_FLOW_MONTH_in_specification141 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_FLOW_DAY_in_specification151 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_YEAR_MONTH_in_specification161 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_JAN_in_specification172 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_FEB_in_specification180 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_MAR_in_specification188 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_APR_in_specification196 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_MAY_in_specification204 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_JUN_in_specification212 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_JUL_in_specification220 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_AUG_in_specification228 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_SEP_in_specification236 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_OCT_in_specification244 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NOV_in_specification252 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_DEC_in_specification260 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_MON_in_specification271 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_TUE_in_specification279 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_WED_in_specification287 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_THU_in_specification295 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_FRI_in_specification303 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_SAT_in_specification311 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_SUN_in_specification319 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_LAST_in_specification330 = new BitSet(new ulong[]{0x0000000200000000UL});
    public static readonly BitSet FOLLOW_T_HOUR_in_specification332 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_THIS_in_specification340 = new BitSet(new ulong[]{0x0000000200000000UL});
    public static readonly BitSet FOLLOW_T_HOUR_in_specification342 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NEXT_in_specification350 = new BitSet(new ulong[]{0x0000000200000000UL});
    public static readonly BitSet FOLLOW_T_HOUR_in_specification352 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_YESTERDAY_in_specification361 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_TODAY_in_specification369 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_TOMORROW_in_specification377 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_LAST_in_specification388 = new BitSet(new ulong[]{0x0000008000000000UL});
    public static readonly BitSet FOLLOW_T_WEEK_in_specification390 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_THIS_in_specification398 = new BitSet(new ulong[]{0x0000008000000000UL});
    public static readonly BitSet FOLLOW_T_WEEK_in_specification400 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NEXT_in_specification408 = new BitSet(new ulong[]{0x0000008000000000UL});
    public static readonly BitSet FOLLOW_T_WEEK_in_specification410 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_LAST_in_specification419 = new BitSet(new ulong[]{0x0000010000000000UL});
    public static readonly BitSet FOLLOW_T_MONTH_in_specification421 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_THIS_in_specification429 = new BitSet(new ulong[]{0x0000010000000000UL});
    public static readonly BitSet FOLLOW_T_MONTH_in_specification431 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NEXT_in_specification439 = new BitSet(new ulong[]{0x0000010000000000UL});
    public static readonly BitSet FOLLOW_T_MONTH_in_specification441 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_LAST_in_specification452 = new BitSet(new ulong[]{0x0000020000000000UL});
    public static readonly BitSet FOLLOW_T_YEAR_in_specification454 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_THIS_in_specification462 = new BitSet(new ulong[]{0x0000020000000000UL});
    public static readonly BitSet FOLLOW_T_YEAR_in_specification464 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NEXT_in_specification472 = new BitSet(new ulong[]{0x0000020000000000UL});
    public static readonly BitSet FOLLOW_T_YEAR_in_specification474 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EQ_in_specification485 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_DATE_in_specification489 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_specification499 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_DATE_in_specification503 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LE_in_specification513 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_DATE_in_specification517 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GT_in_specification527 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_DATE_in_specification531 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GE_in_specification541 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_DATE_in_specification545 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NE_in_specification555 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_DATE_in_specification559 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DATE_in_specification570 = new BitSet(new ulong[]{0x00C0000000000000UL});
    public static readonly BitSet FOLLOW_time_noexact_in_specification572 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EQ_in_specification582 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_DATE_in_specification586 = new BitSet(new ulong[]{0x00C0000000000000UL});
    public static readonly BitSet FOLLOW_time_noexact_in_specification588 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DATE_in_specification599 = new BitSet(new ulong[]{0x0020000000000000UL});
    public static readonly BitSet FOLLOW_time_exact_in_specification601 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EQ_in_specification611 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_DATE_in_specification615 = new BitSet(new ulong[]{0x0020000000000000UL});
    public static readonly BitSet FOLLOW_time_exact_in_specification617 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_specification630 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_DATE_in_specification634 = new BitSet(new ulong[]{0x00E0000000000000UL});
    public static readonly BitSet FOLLOW_time_in_specification638 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LE_in_specification648 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_DATE_in_specification652 = new BitSet(new ulong[]{0x00E0000000000000UL});
    public static readonly BitSet FOLLOW_time_in_specification656 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GT_in_specification666 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_DATE_in_specification670 = new BitSet(new ulong[]{0x00E0000000000000UL});
    public static readonly BitSet FOLLOW_time_in_specification674 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GE_in_specification684 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_DATE_in_specification688 = new BitSet(new ulong[]{0x00E0000000000000UL});
    public static readonly BitSet FOLLOW_time_in_specification692 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NULL_in_specification700 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NOT_in_specification708 = new BitSet(new ulong[]{0x0001000000000000UL});
    public static readonly BitSet FOLLOW_T_NULL_in_specification710 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_specification721 = new BitSet(new ulong[]{0x0000000000000050UL});
    public static readonly BitSet FOLLOW_sql_name_in_specification723 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GT_in_specification732 = new BitSet(new ulong[]{0x0000000000000050UL});
    public static readonly BitSet FOLLOW_sql_name_in_specification734 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LE_in_specification743 = new BitSet(new ulong[]{0x0000000000000050UL});
    public static readonly BitSet FOLLOW_sql_name_in_specification745 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GE_in_specification754 = new BitSet(new ulong[]{0x0000000000000050UL});
    public static readonly BitSet FOLLOW_sql_name_in_specification756 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NE_in_specification765 = new BitSet(new ulong[]{0x0000000000000050UL});
    public static readonly BitSet FOLLOW_sql_name_in_specification767 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EQ_in_specification776 = new BitSet(new ulong[]{0x0000000000000050UL});
    public static readonly BitSet FOLLOW_sql_name_in_specification778 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EQ2_in_specification786 = new BitSet(new ulong[]{0x0000000000000050UL});
    public static readonly BitSet FOLLOW_sql_name_in_specification788 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NE2_in_specification797 = new BitSet(new ulong[]{0x0000000000000050UL});
    public static readonly BitSet FOLLOW_sql_name_in_specification799 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DATE_in_interval818 = new BitSet(new ulong[]{0x0010000000000000UL});
    public static readonly BitSet FOLLOW_MINUS_in_interval820 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_DATE_in_interval824 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DATE_in_interval834 = new BitSet(new ulong[]{0x00E0000000000000UL});
    public static readonly BitSet FOLLOW_time_in_interval838 = new BitSet(new ulong[]{0x0010000000000000UL});
    public static readonly BitSet FOLLOW_MINUS_in_interval840 = new BitSet(new ulong[]{0x0000000000000100UL});
    public static readonly BitSet FOLLOW_DATE_in_interval844 = new BitSet(new ulong[]{0x00E0000000000000UL});
    public static readonly BitSet FOLLOW_time_in_interval848 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_time_exact_in_time861 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_time_noexact_in_time865 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_TIME_SECOND_FRACTION_in_time_exact880 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_TIME_MINUE_in_time_noexact896 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_TIME_SECOND_in_time_noexact904 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_specification_in_element916 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_interval_in_element920 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_element_in_factor932 = new BitSet(new ulong[]{0x000FFC7DFFFFFF82UL});
    public static readonly BitSet FOLLOW_factor_in_list943 = new BitSet(new ulong[]{0x0300000000000002UL});
    public static readonly BitSet FOLLOW_COMMA_in_list948 = new BitSet(new ulong[]{0x000FFC7DFFFFFF80UL});
    public static readonly BitSet FOLLOW_ENDLINE_in_list953 = new BitSet(new ulong[]{0x020FFC7DFFFFFF80UL});
    public static readonly BitSet FOLLOW_factor_in_list960 = new BitSet(new ulong[]{0x0300000000000002UL});
    public static readonly BitSet FOLLOW_ENDLINE_in_list966 = new BitSet(new ulong[]{0x0200000000000002UL});
    public static readonly BitSet FOLLOW_list_in_expr976 = new BitSet(new ulong[]{0x0000000000000002UL});

}
