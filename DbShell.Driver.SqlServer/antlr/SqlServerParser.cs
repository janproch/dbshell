// $ANTLR 3.2 Sep 23, 2009 12:02:23 ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g 2013-06-03 21:01:02

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162


    using System.Globalization;
    using DbShell.Driver.Common.Utility;


using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;



using Antlr.Runtime.Tree;

public partial class SqlServerParser : Parser
{
    public static readonly string[] tokenNames = new string[] 
	{
        "<invalid>", 
		"<EOR>", 
		"<DOWN>", 
		"<UP>", 
		"T_NSTRING", 
		"T_STRING", 
		"T_INTEGER", 
		"T_FLOAT", 
		"T_BINARYNUM", 
		"T_BLOB", 
		"DOT", 
		"ASTERISK", 
		"T_IDENT", 
		"T_QUOTED_IDENT", 
		"EQUALS", 
		"SAFEEQUALS", 
		"EQUALS2", 
		"NOT_EQUALS", 
		"NOT_EQUALS2", 
		"LESS", 
		"LESS_OR_EQ", 
		"GREATER", 
		"GREATER_OR_EQ", 
		"SHIFT_LEFT", 
		"SHIFT_RIGHT", 
		"AMPERSAND", 
		"DOUBLE_AMPERSAND", 
		"PIPE", 
		"DOUBLE_PIPE", 
		"PLUS", 
		"MINUS", 
		"TILDA", 
		"SLASH", 
		"PERCENT", 
		"SEMI", 
		"COMMA", 
		"LPAREN", 
		"RPAREN", 
		"QUESTION", 
		"EXCLAMATION", 
		"COLON", 
		"AT", 
		"DOLLAR", 
		"ARROW_UP", 
		"A", 
		"B", 
		"C", 
		"D", 
		"E", 
		"F", 
		"G", 
		"H", 
		"I", 
		"J", 
		"K", 
		"L", 
		"M", 
		"N", 
		"O", 
		"P", 
		"Q", 
		"R", 
		"S", 
		"T", 
		"U", 
		"V", 
		"W", 
		"X", 
		"Y", 
		"Z", 
		"ADD", 
		"ALTER", 
		"AND", 
		"AS", 
		"ASC", 
		"BEGIN", 
		"BETWEEN", 
		"BY", 
		"CASCADE", 
		"CASE", 
		"CAST", 
		"CHECK", 
		"COLLATE", 
		"COLUMN", 
		"COMMIT", 
		"CONFLICT", 
		"CONSTRAINT", 
		"CREATE", 
		"CROSS", 
		"CURRENT_TIME", 
		"CURRENT_DATE", 
		"CURRENT_TIMESTAMP", 
		"UTC_TIMESTAMP", 
		"DATABASE", 
		"DEFAULT", 
		"DELETE", 
		"DESC", 
		"DISTINCT", 
		"DROP", 
		"ELSE", 
		"END", 
		"ESCAPE", 
		"EXCEPT", 
		"EXCLUSIVE", 
		"EXISTS", 
		"EXPLAIN", 
		"FOR", 
		"FOREIGN", 
		"FROM", 
		"GROUP", 
		"HAVING", 
		"IF", 
		"IN", 
		"INDEX", 
		"INNER", 
		"INSERT", 
		"INTERSECT", 
		"INTO", 
		"IS", 
		"JOIN", 
		"KEY", 
		"LEFT", 
		"LIKE", 
		"NOT", 
		"NULL", 
		"OF", 
		"ON", 
		"OR", 
		"ORDER", 
		"OUTER", 
		"PRIMARY", 
		"REFERENCES", 
		"ROLLBACK", 
		"SELECT", 
		"SET", 
		"TABLE", 
		"TEMPORARY", 
		"TEMP", 
		"THEN", 
		"TO", 
		"TRANSACTION", 
		"TRIGGER", 
		"UNION", 
		"UNIQUE", 
		"UPDATE", 
		"VALUES", 
		"VIEW", 
		"WHEN", 
		"WHERE", 
		"WITH", 
		"PARSER", 
		"XOR", 
		"ID_START", 
		"FLOAT_EXP", 
		"T_COMMENT", 
		"LINE_COMMENT", 
		"WHITESPACE"
    };

    public const int CAST = 80;
    public const int T_STRING = 5;
    public const int TRIGGER = 141;
    public const int CURRENT_TIME = 89;
    public const int CASE = 79;
    public const int T_IDENT = 12;
    public const int EQUALS = 14;
    public const int NOT = 123;
    public const int T_INTEGER = 6;
    public const int EXCEPT = 102;
    public const int CASCADE = 78;
    public const int FOREIGN = 107;
    public const int EOF = -1;
    public const int EXPLAIN = 105;
    public const int RPAREN = 37;
    public const int CREATE = 87;
    public const int GREATER = 21;
    public const int INSERT = 115;
    public const int ESCAPE = 101;
    public const int EXCLAMATION = 39;
    public const int BEGIN = 75;
    public const int LESS = 19;
    public const int CONFLICT = 85;
    public const int SELECT = 133;
    public const int LESS_OR_EQ = 20;
    public const int INTO = 117;
    public const int D = 47;
    public const int E = 48;
    public const int UNIQUE = 143;
    public const int F = 49;
    public const int G = 50;
    public const int A = 44;
    public const int VIEW = 146;
    public const int B = 45;
    public const int C = 46;
    public const int ASC = 74;
    public const int LINE_COMMENT = 155;
    public const int L = 55;
    public const int SAFEEQUALS = 15;
    public const int M = 56;
    public const int N = 57;
    public const int TRANSACTION = 140;
    public const int KEY = 120;
    public const int T_BINARYNUM = 8;
    public const int O = 58;
    public const int TEMP = 137;
    public const int H = 51;
    public const int NULL = 124;
    public const int I = 52;
    public const int ELSE = 99;
    public const int J = 53;
    public const int K = 54;
    public const int T_FLOAT = 7;
    public const int U = 64;
    public const int ON = 126;
    public const int T = 63;
    public const int WHITESPACE = 156;
    public const int W = 66;
    public const int T_NSTRING = 4;
    public const int V = 65;
    public const int PRIMARY = 130;
    public const int Q = 60;
    public const int DELETE = 95;
    public const int P = 59;
    public const int S = 62;
    public const int R = 61;
    public const int ROLLBACK = 132;
    public const int OF = 125;
    public const int Y = 68;
    public const int X = 67;
    public const int Z = 69;
    public const int SHIFT_LEFT = 23;
    public const int INTERSECT = 116;
    public const int GROUP = 109;
    public const int SHIFT_RIGHT = 24;
    public const int OR = 127;
    public const int CHECK = 81;
    public const int FROM = 108;
    public const int END = 100;
    public const int PARSER = 150;
    public const int TEMPORARY = 136;
    public const int DISTINCT = 97;
    public const int CONSTRAINT = 86;
    public const int CURRENT_DATE = 90;
    public const int DOLLAR = 42;
    public const int WHERE = 148;
    public const int ALTER = 71;
    public const int INNER = 114;
    public const int UTC_TIMESTAMP = 92;
    public const int ORDER = 128;
    public const int UPDATE = 144;
    public const int TABLE = 135;
    public const int FOR = 106;
    public const int EXCLUSIVE = 103;
    public const int AND = 72;
    public const int DOUBLE_AMPERSAND = 26;
    public const int NOT_EQUALS = 17;
    public const int CROSS = 88;
    public const int T_COMMENT = 154;
    public const int LPAREN = 36;
    public const int ASTERISK = 11;
    public const int IF = 111;
    public const int GREATER_OR_EQ = 22;
    public const int AT = 41;
    public const int DOUBLE_PIPE = 28;
    public const int INDEX = 113;
    public const int AS = 73;
    public const int TILDA = 31;
    public const int SLASH = 32;
    public const int THEN = 138;
    public const int IN = 112;
    public const int REFERENCES = 131;
    public const int COMMA = 35;
    public const int IS = 118;
    public const int LEFT = 121;
    public const int COLUMN = 83;
    public const int PLUS = 29;
    public const int PIPE = 27;
    public const int EXISTS = 104;
    public const int DOT = 10;
    public const int CURRENT_TIMESTAMP = 91;
    public const int WITH = 149;
    public const int LIKE = 122;
    public const int ADD = 70;
    public const int COLLATE = 82;
    public const int OUTER = 129;
    public const int ARROW_UP = 43;
    public const int BY = 77;
    public const int XOR = 151;
    public const int EQUALS2 = 16;
    public const int PERCENT = 33;
    public const int TO = 139;
    public const int NOT_EQUALS2 = 18;
    public const int DEFAULT = 94;
    public const int VALUES = 145;
    public const int AMPERSAND = 25;
    public const int SET = 134;
    public const int HAVING = 110;
    public const int MINUS = 30;
    public const int SEMI = 34;
    public const int JOIN = 119;
    public const int UNION = 142;
    public const int COLON = 40;
    public const int T_QUOTED_IDENT = 13;
    public const int FLOAT_EXP = 153;
    public const int COMMIT = 84;
    public const int DATABASE = 93;
    public const int QUESTION = 38;
    public const int DROP = 98;
    public const int WHEN = 147;
    public const int T_BLOB = 9;
    public const int DESC = 96;
    public const int ID_START = 152;
    public const int BETWEEN = 76;

    // delegates
    // delegators



        public SqlServerParser(ITokenStream input)
    		: this(input, new RecognizerSharedState()) {
        }

        public SqlServerParser(ITokenStream input, RecognizerSharedState state)
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
		get { return SqlServerParser.tokenNames; }
    }

    override public string GrammarFileName {
		get { return "..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g"; }
    }


    public class find_deps_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "find_deps"
    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:13:1: find_deps[DepsCollector dc] : ( find_dep_item[dc] )* ;
    public SqlServerParser.find_deps_return find_deps(DepsCollector dc) // throws RecognitionException [1]
    {   
        SqlServerParser.find_deps_return retval = new SqlServerParser.find_deps_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        SqlServerParser.find_dep_item_return find_dep_item1 = default(SqlServerParser.find_dep_item_return);



        try 
    	{
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:14:5: ( ( find_dep_item[dc] )* )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:14:7: ( find_dep_item[dc] )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:14:7: ( find_dep_item[dc] )*
            	do 
            	{
            	    int alt1 = 2;
            	    int LA1_0 = input.LA(1);

            	    if ( ((LA1_0 >= T_NSTRING && LA1_0 <= T_BLOB) || (LA1_0 >= ASTERISK && LA1_0 <= ARROW_UP) || (LA1_0 >= ADD && LA1_0 <= XOR)) )
            	    {
            	        alt1 = 1;
            	    }


            	    switch (alt1) 
            		{
            			case 1 :
            			    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:14:7: find_dep_item[dc]
            			    {
            			    	PushFollow(FOLLOW_find_dep_item_in_find_deps38);
            			    	find_dep_item1 = find_dep_item(dc);
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, find_dep_item1.Tree);

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
    // $ANTLR end "find_deps"

    public class find_dep_item_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "find_dep_item"
    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:15:1: find_dep_item[DepsCollector dc] : ( keyword | operator_no_dot | T_NSTRING | T_STRING | T_INTEGER | T_FLOAT | T_BINARYNUM | T_BLOB | name1= id ( DOT ( DOT )? (name2= id | ASTERISK ) )* );
    public SqlServerParser.find_dep_item_return find_dep_item(DepsCollector dc) // throws RecognitionException [1]
    {   
        SqlServerParser.find_dep_item_return retval = new SqlServerParser.find_dep_item_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken T_NSTRING4 = null;
        IToken T_STRING5 = null;
        IToken T_INTEGER6 = null;
        IToken T_FLOAT7 = null;
        IToken T_BINARYNUM8 = null;
        IToken T_BLOB9 = null;
        IToken DOT10 = null;
        IToken DOT11 = null;
        IToken ASTERISK12 = null;
        SqlServerParser.id_return name1 = default(SqlServerParser.id_return);

        SqlServerParser.id_return name2 = default(SqlServerParser.id_return);

        SqlServerParser.keyword_return keyword2 = default(SqlServerParser.keyword_return);

        SqlServerParser.operator_no_dot_return operator_no_dot3 = default(SqlServerParser.operator_no_dot_return);


        object T_NSTRING4_tree=null;
        object T_STRING5_tree=null;
        object T_INTEGER6_tree=null;
        object T_FLOAT7_tree=null;
        object T_BINARYNUM8_tree=null;
        object T_BLOB9_tree=null;
        object DOT10_tree=null;
        object DOT11_tree=null;
        object ASTERISK12_tree=null;

        try 
    	{
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:16:5: ( keyword | operator_no_dot | T_NSTRING | T_STRING | T_INTEGER | T_FLOAT | T_BINARYNUM | T_BLOB | name1= id ( DOT ( DOT )? (name2= id | ASTERISK ) )* )
            int alt5 = 9;
            switch ( input.LA(1) ) 
            {
            case ADD:
            case ALTER:
            case AND:
            case AS:
            case ASC:
            case BEGIN:
            case BETWEEN:
            case BY:
            case CASCADE:
            case CASE:
            case CAST:
            case CHECK:
            case COLLATE:
            case COLUMN:
            case COMMIT:
            case CONFLICT:
            case CONSTRAINT:
            case CREATE:
            case CROSS:
            case CURRENT_TIME:
            case CURRENT_DATE:
            case CURRENT_TIMESTAMP:
            case UTC_TIMESTAMP:
            case DATABASE:
            case DEFAULT:
            case DELETE:
            case DESC:
            case DISTINCT:
            case DROP:
            case ELSE:
            case END:
            case ESCAPE:
            case EXCEPT:
            case EXCLUSIVE:
            case EXISTS:
            case EXPLAIN:
            case FOR:
            case FOREIGN:
            case FROM:
            case GROUP:
            case HAVING:
            case IF:
            case IN:
            case INDEX:
            case INNER:
            case INSERT:
            case INTERSECT:
            case INTO:
            case IS:
            case JOIN:
            case KEY:
            case LEFT:
            case LIKE:
            case NOT:
            case NULL:
            case OF:
            case ON:
            case OR:
            case ORDER:
            case OUTER:
            case PRIMARY:
            case REFERENCES:
            case ROLLBACK:
            case SELECT:
            case SET:
            case TABLE:
            case TEMPORARY:
            case TEMP:
            case THEN:
            case TO:
            case TRANSACTION:
            case TRIGGER:
            case UNION:
            case UNIQUE:
            case UPDATE:
            case VALUES:
            case VIEW:
            case WHEN:
            case WHERE:
            case WITH:
            case PARSER:
            case XOR:
            	{
                alt5 = 1;
                }
                break;
            case ASTERISK:
            case EQUALS:
            case SAFEEQUALS:
            case EQUALS2:
            case NOT_EQUALS:
            case NOT_EQUALS2:
            case LESS:
            case LESS_OR_EQ:
            case GREATER:
            case GREATER_OR_EQ:
            case SHIFT_LEFT:
            case SHIFT_RIGHT:
            case AMPERSAND:
            case DOUBLE_AMPERSAND:
            case PIPE:
            case DOUBLE_PIPE:
            case PLUS:
            case MINUS:
            case TILDA:
            case SLASH:
            case PERCENT:
            case SEMI:
            case COMMA:
            case LPAREN:
            case RPAREN:
            case QUESTION:
            case EXCLAMATION:
            case COLON:
            case AT:
            case DOLLAR:
            case ARROW_UP:
            	{
                alt5 = 2;
                }
                break;
            case T_NSTRING:
            	{
                alt5 = 3;
                }
                break;
            case T_STRING:
            	{
                alt5 = 4;
                }
                break;
            case T_INTEGER:
            	{
                alt5 = 5;
                }
                break;
            case T_FLOAT:
            	{
                alt5 = 6;
                }
                break;
            case T_BINARYNUM:
            	{
                alt5 = 7;
                }
                break;
            case T_BLOB:
            	{
                alt5 = 8;
                }
                break;
            case T_IDENT:
            case T_QUOTED_IDENT:
            	{
                alt5 = 9;
                }
                break;
            	default:
            	    NoViableAltException nvae_d5s0 =
            	        new NoViableAltException("", 5, 0, input);

            	    throw nvae_d5s0;
            }

            switch (alt5) 
            {
                case 1 :
                    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:16:7: keyword
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_keyword_in_find_dep_item52);
                    	keyword2 = keyword();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, keyword2.Tree);

                    }
                    break;
                case 2 :
                    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:16:17: operator_no_dot
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_operator_no_dot_in_find_dep_item56);
                    	operator_no_dot3 = operator_no_dot();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, operator_no_dot3.Tree);

                    }
                    break;
                case 3 :
                    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:16:35: T_NSTRING
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_NSTRING4=(IToken)Match(input,T_NSTRING,FOLLOW_T_NSTRING_in_find_dep_item60); 
                    		T_NSTRING4_tree = (object)adaptor.Create(T_NSTRING4);
                    		adaptor.AddChild(root_0, T_NSTRING4_tree);


                    }
                    break;
                case 4 :
                    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:16:47: T_STRING
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_STRING5=(IToken)Match(input,T_STRING,FOLLOW_T_STRING_in_find_dep_item64); 
                    		T_STRING5_tree = (object)adaptor.Create(T_STRING5);
                    		adaptor.AddChild(root_0, T_STRING5_tree);


                    }
                    break;
                case 5 :
                    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:16:58: T_INTEGER
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_INTEGER6=(IToken)Match(input,T_INTEGER,FOLLOW_T_INTEGER_in_find_dep_item68); 
                    		T_INTEGER6_tree = (object)adaptor.Create(T_INTEGER6);
                    		adaptor.AddChild(root_0, T_INTEGER6_tree);


                    }
                    break;
                case 6 :
                    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:16:70: T_FLOAT
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_FLOAT7=(IToken)Match(input,T_FLOAT,FOLLOW_T_FLOAT_in_find_dep_item72); 
                    		T_FLOAT7_tree = (object)adaptor.Create(T_FLOAT7);
                    		adaptor.AddChild(root_0, T_FLOAT7_tree);


                    }
                    break;
                case 7 :
                    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:16:80: T_BINARYNUM
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_BINARYNUM8=(IToken)Match(input,T_BINARYNUM,FOLLOW_T_BINARYNUM_in_find_dep_item76); 
                    		T_BINARYNUM8_tree = (object)adaptor.Create(T_BINARYNUM8);
                    		adaptor.AddChild(root_0, T_BINARYNUM8_tree);


                    }
                    break;
                case 8 :
                    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:16:94: T_BLOB
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	T_BLOB9=(IToken)Match(input,T_BLOB,FOLLOW_T_BLOB_in_find_dep_item80); 
                    		T_BLOB9_tree = (object)adaptor.Create(T_BLOB9);
                    		adaptor.AddChild(root_0, T_BLOB9_tree);


                    }
                    break;
                case 9 :
                    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:17:9: name1= id ( DOT ( DOT )? (name2= id | ASTERISK ) )*
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_id_in_find_dep_item94);
                    	name1 = id();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, name1.Tree);
                    	 var name=new DepsName();name.AddComponent(UnquoteName(((name1 != null) ? input.ToString((IToken)(name1.Start),(IToken)(name1.Stop)) : null))); 
                    	// ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:18:9: ( DOT ( DOT )? (name2= id | ASTERISK ) )*
                    	do 
                    	{
                    	    int alt4 = 2;
                    	    int LA4_0 = input.LA(1);

                    	    if ( (LA4_0 == DOT) )
                    	    {
                    	        alt4 = 1;
                    	    }


                    	    switch (alt4) 
                    		{
                    			case 1 :
                    			    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:18:10: DOT ( DOT )? (name2= id | ASTERISK )
                    			    {
                    			    	DOT10=(IToken)Match(input,DOT,FOLLOW_DOT_in_find_dep_item107); 
                    			    		DOT10_tree = (object)adaptor.Create(DOT10);
                    			    		adaptor.AddChild(root_0, DOT10_tree);

                    			    	// ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:18:14: ( DOT )?
                    			    	int alt2 = 2;
                    			    	int LA2_0 = input.LA(1);

                    			    	if ( (LA2_0 == DOT) )
                    			    	{
                    			    	    alt2 = 1;
                    			    	}
                    			    	switch (alt2) 
                    			    	{
                    			    	    case 1 :
                    			    	        // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:18:14: DOT
                    			    	        {
                    			    	        	DOT11=(IToken)Match(input,DOT,FOLLOW_DOT_in_find_dep_item109); 
                    			    	        		DOT11_tree = (object)adaptor.Create(DOT11);
                    			    	        		adaptor.AddChild(root_0, DOT11_tree);


                    			    	        }
                    			    	        break;

                    			    	}

                    			    	// ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:18:19: (name2= id | ASTERISK )
                    			    	int alt3 = 2;
                    			    	int LA3_0 = input.LA(1);

                    			    	if ( ((LA3_0 >= T_IDENT && LA3_0 <= T_QUOTED_IDENT)) )
                    			    	{
                    			    	    alt3 = 1;
                    			    	}
                    			    	else if ( (LA3_0 == ASTERISK) )
                    			    	{
                    			    	    alt3 = 2;
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
                    			    	        // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:18:20: name2= id
                    			    	        {
                    			    	        	PushFollow(FOLLOW_id_in_find_dep_item115);
                    			    	        	name2 = id();
                    			    	        	state.followingStackPointer--;

                    			    	        	adaptor.AddChild(root_0, name2.Tree);
                    			    	        	 name.AddComponent(UnquoteName(((name2 != null) ? input.ToString((IToken)(name2.Start),(IToken)(name2.Stop)) : null)));

                    			    	        }
                    			    	        break;
                    			    	    case 2 :
                    			    	        // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:18:79: ASTERISK
                    			    	        {
                    			    	        	ASTERISK12=(IToken)Match(input,ASTERISK,FOLLOW_ASTERISK_in_find_dep_item121); 
                    			    	        		ASTERISK12_tree = (object)adaptor.Create(ASTERISK12);
                    			    	        		adaptor.AddChild(root_0, ASTERISK12_tree);


                    			    	        }
                    			    	        break;

                    			    	}


                    			    }
                    			    break;

                    			default:
                    			    goto loop4;
                    	    }
                    	} while (true);

                    	loop4:
                    		;	// Stops C# compiler whining that label 'loop4' has no statements

                    	dc.AddName(name); 

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
    // $ANTLR end "find_dep_item"

    public class id_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "id"
    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:21:1: id : ( T_IDENT | T_QUOTED_IDENT );
    public SqlServerParser.id_return id() // throws RecognitionException [1]
    {   
        SqlServerParser.id_return retval = new SqlServerParser.id_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken set13 = null;

        object set13_tree=null;

        try 
    	{
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:21:3: ( T_IDENT | T_QUOTED_IDENT )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:
            {
            	root_0 = (object)adaptor.GetNilNode();

            	set13 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= T_IDENT && input.LA(1) <= T_QUOTED_IDENT) ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (object)adaptor.Create(set13));
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
    // $ANTLR end "id"

    public class operator_no_dot_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "operator_no_dot"
    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:59:1: operator_no_dot : ( EQUALS | SAFEEQUALS | EQUALS2 | NOT_EQUALS | NOT_EQUALS2 | LESS | LESS_OR_EQ | GREATER | GREATER_OR_EQ | SHIFT_LEFT | SHIFT_RIGHT | AMPERSAND | DOUBLE_AMPERSAND | PIPE | DOUBLE_PIPE | PLUS | MINUS | TILDA | ASTERISK | SLASH | PERCENT | SEMI | COMMA | LPAREN | RPAREN | QUESTION | EXCLAMATION | COLON | AT | DOLLAR | ARROW_UP );
    public SqlServerParser.operator_no_dot_return operator_no_dot() // throws RecognitionException [1]
    {   
        SqlServerParser.operator_no_dot_return retval = new SqlServerParser.operator_no_dot_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken set14 = null;

        object set14_tree=null;

        try 
    	{
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:59:17: ( EQUALS | SAFEEQUALS | EQUALS2 | NOT_EQUALS | NOT_EQUALS2 | LESS | LESS_OR_EQ | GREATER | GREATER_OR_EQ | SHIFT_LEFT | SHIFT_RIGHT | AMPERSAND | DOUBLE_AMPERSAND | PIPE | DOUBLE_PIPE | PLUS | MINUS | TILDA | ASTERISK | SLASH | PERCENT | SEMI | COMMA | LPAREN | RPAREN | QUESTION | EXCLAMATION | COLON | AT | DOLLAR | ARROW_UP )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:
            {
            	root_0 = (object)adaptor.GetNilNode();

            	set14 = (IToken)input.LT(1);
            	if ( input.LA(1) == ASTERISK || (input.LA(1) >= EQUALS && input.LA(1) <= ARROW_UP) ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (object)adaptor.Create(set14));
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
    // $ANTLR end "operator_no_dot"

    public class any_operator_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "any_operator"
    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:66:1: any_operator : ( DOT | operator_no_dot );
    public SqlServerParser.any_operator_return any_operator() // throws RecognitionException [1]
    {   
        SqlServerParser.any_operator_return retval = new SqlServerParser.any_operator_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken DOT15 = null;
        SqlServerParser.operator_no_dot_return operator_no_dot16 = default(SqlServerParser.operator_no_dot_return);


        object DOT15_tree=null;

        try 
    	{
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:66:13: ( DOT | operator_no_dot )
            int alt6 = 2;
            int LA6_0 = input.LA(1);

            if ( (LA6_0 == DOT) )
            {
                alt6 = 1;
            }
            else if ( (LA6_0 == ASTERISK || (LA6_0 >= EQUALS && LA6_0 <= ARROW_UP)) )
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
                    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:66:15: DOT
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	DOT15=(IToken)Match(input,DOT,FOLLOW_DOT_in_any_operator681); 
                    		DOT15_tree = (object)adaptor.Create(DOT15);
                    		adaptor.AddChild(root_0, DOT15_tree);


                    }
                    break;
                case 2 :
                    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:66:21: operator_no_dot
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_operator_no_dot_in_any_operator685);
                    	operator_no_dot16 = operator_no_dot();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, operator_no_dot16.Tree);

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
    // $ANTLR end "any_operator"

    public class keyword_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "keyword"
    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:215:1: keyword : ( ADD | ALTER | AND | AS | ASC | BEGIN | BETWEEN | BY | CASCADE | CASE | CAST | CHECK | COLLATE | COLUMN | COMMIT | CONFLICT | CONSTRAINT | CREATE | CROSS | CURRENT_TIME | CURRENT_DATE | CURRENT_TIMESTAMP | UTC_TIMESTAMP | DATABASE | DEFAULT | DELETE | DESC | DISTINCT | DROP | ELSE | END | ESCAPE | EXCEPT | EXCLUSIVE | EXISTS | EXPLAIN | FOR | FOREIGN | FROM | GROUP | HAVING | IF | IN | INDEX | INNER | INSERT | INTERSECT | INTO | IS | JOIN | KEY | LEFT | LIKE | NOT | NULL | OF | ON | OR | ORDER | OUTER | PRIMARY | REFERENCES | ROLLBACK | SELECT | SET | TABLE | TEMPORARY | TEMP | THEN | TO | TRANSACTION | TRIGGER | UNION | UNIQUE | UPDATE | VALUES | VIEW | WHEN | WHERE | WITH | PARSER | XOR );
    public SqlServerParser.keyword_return keyword() // throws RecognitionException [1]
    {   
        SqlServerParser.keyword_return retval = new SqlServerParser.keyword_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken set17 = null;

        object set17_tree=null;

        try 
    	{
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:215:9: ( ADD | ALTER | AND | AS | ASC | BEGIN | BETWEEN | BY | CASCADE | CASE | CAST | CHECK | COLLATE | COLUMN | COMMIT | CONFLICT | CONSTRAINT | CREATE | CROSS | CURRENT_TIME | CURRENT_DATE | CURRENT_TIMESTAMP | UTC_TIMESTAMP | DATABASE | DEFAULT | DELETE | DESC | DISTINCT | DROP | ELSE | END | ESCAPE | EXCEPT | EXCLUSIVE | EXISTS | EXPLAIN | FOR | FOREIGN | FROM | GROUP | HAVING | IF | IN | INDEX | INNER | INSERT | INTERSECT | INTO | IS | JOIN | KEY | LEFT | LIKE | NOT | NULL | OF | ON | OR | ORDER | OUTER | PRIMARY | REFERENCES | ROLLBACK | SELECT | SET | TABLE | TEMPORARY | TEMP | THEN | TO | TRANSACTION | TRIGGER | UNION | UNIQUE | UPDATE | VALUES | VIEW | WHEN | WHERE | WITH | PARSER | XOR )
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:
            {
            	root_0 = (object)adaptor.GetNilNode();

            	set17 = (IToken)input.LT(1);
            	if ( (input.LA(1) >= ADD && input.LA(1) <= XOR) ) 
            	{
            	    input.Consume();
            	    adaptor.AddChild(root_0, (object)adaptor.Create(set17));
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
    // $ANTLR end "keyword"

    public class sysname_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "sysname"
    // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:218:1: sysname : ;
    public SqlServerParser.sysname_return sysname() // throws RecognitionException [1]
    {   
        SqlServerParser.sysname_return retval = new SqlServerParser.sysname_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        try 
    	{
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:218:9: ()
            // ..\\DbShell.Driver.SqlServer\\antlr\\SqlServer.g:220:1: 
            {
            	root_0 = (object)adaptor.GetNilNode();

            }

            retval.Stop = input.LT(-1);

            	retval.Tree = (object)adaptor.RulePostProcessing(root_0);
            	adaptor.SetTokenBoundaries(retval.Tree, (IToken) retval.Start, (IToken) retval.Stop);
        }
        finally 
    	{
        }
        return retval;
    }
    // $ANTLR end "sysname"

    // Delegated rules


	private void InitializeCyclicDFAs()
	{
	}

 

    public static readonly BitSet FOLLOW_find_dep_item_in_find_deps38 = new BitSet(new ulong[]{0x00000FFFFFFFFBF2UL,0xFFFFFFFFFFFFFFC0UL,0x0000000000FFFFFFUL});
    public static readonly BitSet FOLLOW_keyword_in_find_dep_item52 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_operator_no_dot_in_find_dep_item56 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_NSTRING_in_find_dep_item60 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_STRING_in_find_dep_item64 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_INTEGER_in_find_dep_item68 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_FLOAT_in_find_dep_item72 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_BINARYNUM_in_find_dep_item76 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_T_BLOB_in_find_dep_item80 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_id_in_find_dep_item94 = new BitSet(new ulong[]{0x0000000000000402UL});
    public static readonly BitSet FOLLOW_DOT_in_find_dep_item107 = new BitSet(new ulong[]{0x00000FFFFFFFFFF0UL,0xFFFFFFFFFFFFFFC0UL,0x0000000000FFFFFFUL});
    public static readonly BitSet FOLLOW_DOT_in_find_dep_item109 = new BitSet(new ulong[]{0x00000FFFFFFFFFF0UL,0xFFFFFFFFFFFFFFC0UL,0x0000000000FFFFFFUL});
    public static readonly BitSet FOLLOW_id_in_find_dep_item115 = new BitSet(new ulong[]{0x0000000000000402UL});
    public static readonly BitSet FOLLOW_ASTERISK_in_find_dep_item121 = new BitSet(new ulong[]{0x0000000000000402UL});
    public static readonly BitSet FOLLOW_set_in_id0 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_operator_no_dot0 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DOT_in_any_operator681 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_operator_no_dot_in_any_operator685 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_set_in_keyword0 = new BitSet(new ulong[]{0x0000000000000002UL});

}
