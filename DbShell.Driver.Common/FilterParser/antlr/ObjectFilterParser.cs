// $ANTLR 3.2 Sep 23, 2009 12:02:23 ObjectFilter.g 2016-09-07 21:54:37

// The variable 'variable' is assigned but its value is never used.
#pragma warning disable 168, 219
// Unreachable code detected.
#pragma warning disable 162


  using DbShell.Driver.Common.Utility;
  using System.Globalization;


using System;
using Antlr.Runtime;
using IList 		= System.Collections.IList;
using ArrayList 	= System.Collections.ArrayList;
using Stack 		= Antlr.Runtime.Collections.StackList;



using Antlr.Runtime.Tree;

public partial class ObjectFilterParser : ObjectFilterAntlrParser
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
		"PLUS", 
		"TILDA", 
		"ARROW", 
		"NARROW", 
		"DOLLAR", 
		"NDOLLAR", 
		"EQ", 
		"NE", 
		"HASH", 
		"MAIL", 
		"COMMA", 
		"ENDLINE", 
		"WHITESPACE"
    };

    public const int DOLLAR = 11;
    public const int I_STRING = 6;
    public const int MAIL = 16;
    public const int HASH = 15;
    public const int WHITESPACE = 19;
    public const int EOF = -1;
    public const int Q_STRING = 4;
    public const int TILDA = 8;
    public const int NDOLLAR = 12;
    public const int COMMA = 17;
    public const int A_STRING = 5;
    public const int ARROW = 9;
    public const int PLUS = 7;
    public const int ENDLINE = 18;
    public const int EQ = 13;
    public const int NARROW = 10;
    public const int NE = 14;

    // delegates
    // delegators



        public ObjectFilterParser(ITokenStream input)
    		: this(input, new RecognizerSharedState()) {
        }

        public ObjectFilterParser(ITokenStream input, RecognizerSharedState state)
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
		get { return ObjectFilterParser.tokenNames; }
    }

    override public string GrammarFileName {
		get { return "ObjectFilter.g"; }
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
    // ObjectFilter.g:14:1: string_lit : ( Q_STRING | A_STRING | I_STRING );
    public ObjectFilterParser.string_lit_return string_lit() // throws RecognitionException [1]
    {   
        ObjectFilterParser.string_lit_return retval = new ObjectFilterParser.string_lit_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken set1 = null;

        object set1_tree=null;

        try 
    	{
            // ObjectFilter.g:14:11: ( Q_STRING | A_STRING | I_STRING )
            // ObjectFilter.g:
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
    // ObjectFilter.g:16:1: element : (s1= string_lit | PLUS s1= string_lit | TILDA s1= string_lit | ARROW s1= string_lit | NARROW s1= string_lit | DOLLAR s1= string_lit | NDOLLAR s1= string_lit | EQ s1= string_lit | NE s1= string_lit );
    public ObjectFilterParser.element_return element() // throws RecognitionException [1]
    {   
        ObjectFilterParser.element_return retval = new ObjectFilterParser.element_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken PLUS2 = null;
        IToken TILDA3 = null;
        IToken ARROW4 = null;
        IToken NARROW5 = null;
        IToken DOLLAR6 = null;
        IToken NDOLLAR7 = null;
        IToken EQ8 = null;
        IToken NE9 = null;
        ObjectFilterParser.string_lit_return s1 = default(ObjectFilterParser.string_lit_return);


        object PLUS2_tree=null;
        object TILDA3_tree=null;
        object ARROW4_tree=null;
        object NARROW5_tree=null;
        object DOLLAR6_tree=null;
        object NDOLLAR7_tree=null;
        object EQ8_tree=null;
        object NE9_tree=null;

        try 
    	{
            // ObjectFilter.g:16:8: (s1= string_lit | PLUS s1= string_lit | TILDA s1= string_lit | ARROW s1= string_lit | NARROW s1= string_lit | DOLLAR s1= string_lit | NDOLLAR s1= string_lit | EQ s1= string_lit | NE s1= string_lit )
            int alt1 = 9;
            switch ( input.LA(1) ) 
            {
            case Q_STRING:
            case A_STRING:
            case I_STRING:
            	{
                alt1 = 1;
                }
                break;
            case PLUS:
            	{
                alt1 = 2;
                }
                break;
            case TILDA:
            	{
                alt1 = 3;
                }
                break;
            case ARROW:
            	{
                alt1 = 4;
                }
                break;
            case NARROW:
            	{
                alt1 = 5;
                }
                break;
            case DOLLAR:
            	{
                alt1 = 6;
                }
                break;
            case NDOLLAR:
            	{
                alt1 = 7;
                }
                break;
            case EQ:
            	{
                alt1 = 8;
                }
                break;
            case NE:
            	{
                alt1 = 9;
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
                    // ObjectFilter.g:17:3: s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_string_lit_in_element62);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringTestCondition<ObjectFilterContainsTextCondition>(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null))); 

                    }
                    break;
                case 2 :
                    // ObjectFilter.g:18:5: PLUS s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PLUS2=(IToken)Match(input,PLUS,FOLLOW_PLUS_in_element70); 
                    		PLUS2_tree = (object)adaptor.Create(PLUS2);
                    		adaptor.AddChild(root_0, PLUS2_tree);

                    	PushFollow(FOLLOW_string_lit_in_element74);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringTestCondition<ObjectFilterContainsTextCondition>(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null))); 

                    }
                    break;
                case 3 :
                    // ObjectFilter.g:19:5: TILDA s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	TILDA3=(IToken)Match(input,TILDA,FOLLOW_TILDA_in_element82); 
                    		TILDA3_tree = (object)adaptor.Create(TILDA3);
                    		adaptor.AddChild(root_0, TILDA3_tree);

                    	PushFollow(FOLLOW_string_lit_in_element86);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringTestCondition<ObjectFilterContainsTextCondition>(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)));NegateLastCondition(); 

                    }
                    break;
                case 4 :
                    // ObjectFilter.g:20:5: ARROW s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	ARROW4=(IToken)Match(input,ARROW,FOLLOW_ARROW_in_element95); 
                    		ARROW4_tree = (object)adaptor.Create(ARROW4);
                    		adaptor.AddChild(root_0, ARROW4_tree);

                    	PushFollow(FOLLOW_string_lit_in_element99);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringTestCondition<ObjectFilterStartsWithCondition>(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null))); 

                    }
                    break;
                case 5 :
                    // ObjectFilter.g:21:5: NARROW s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NARROW5=(IToken)Match(input,NARROW,FOLLOW_NARROW_in_element108); 
                    		NARROW5_tree = (object)adaptor.Create(NARROW5);
                    		adaptor.AddChild(root_0, NARROW5_tree);

                    	PushFollow(FOLLOW_string_lit_in_element112);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringTestCondition<ObjectFilterStartsWithCondition>(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)));NegateLastCondition(); 

                    }
                    break;
                case 6 :
                    // ObjectFilter.g:22:5: DOLLAR s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	DOLLAR6=(IToken)Match(input,DOLLAR,FOLLOW_DOLLAR_in_element121); 
                    		DOLLAR6_tree = (object)adaptor.Create(DOLLAR6);
                    		adaptor.AddChild(root_0, DOLLAR6_tree);

                    	PushFollow(FOLLOW_string_lit_in_element125);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringTestCondition<ObjectFilterEndsWithCondition>(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null))); 

                    }
                    break;
                case 7 :
                    // ObjectFilter.g:23:5: NDOLLAR s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NDOLLAR7=(IToken)Match(input,NDOLLAR,FOLLOW_NDOLLAR_in_element134); 
                    		NDOLLAR7_tree = (object)adaptor.Create(NDOLLAR7);
                    		adaptor.AddChild(root_0, NDOLLAR7_tree);

                    	PushFollow(FOLLOW_string_lit_in_element138);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringTestCondition<ObjectFilterEndsWithCondition>(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)));NegateLastCondition(); 

                    }
                    break;
                case 8 :
                    // ObjectFilter.g:24:5: EQ s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	EQ8=(IToken)Match(input,EQ,FOLLOW_EQ_in_element147); 
                    		EQ8_tree = (object)adaptor.Create(EQ8);
                    		adaptor.AddChild(root_0, EQ8_tree);

                    	PushFollow(FOLLOW_string_lit_in_element151);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringTestCondition<ObjectFilterEqualsCondition>(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null))); 

                    }
                    break;
                case 9 :
                    // ObjectFilter.g:25:5: NE s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NE9=(IToken)Match(input,NE,FOLLOW_NE_in_element160); 
                    		NE9_tree = (object)adaptor.Create(NE9);
                    		adaptor.AddChild(root_0, NE9_tree);

                    	PushFollow(FOLLOW_string_lit_in_element164);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringTestCondition<ObjectFilterEqualsCondition>(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)));NegateLastCondition(); 

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

    public class element_with_context_return : ParserRuleReturnScope
    {
        private object tree;
        override public object Tree
        {
        	get { return tree; }
        	set { tree = (object) value; }
        }
    };

    // $ANTLR start "element_with_context"
    // ObjectFilter.g:28:1: element_with_context : ( element | HASH element | MAIL element );
    public ObjectFilterParser.element_with_context_return element_with_context() // throws RecognitionException [1]
    {   
        ObjectFilterParser.element_with_context_return retval = new ObjectFilterParser.element_with_context_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken HASH11 = null;
        IToken MAIL13 = null;
        ObjectFilterParser.element_return element10 = default(ObjectFilterParser.element_return);

        ObjectFilterParser.element_return element12 = default(ObjectFilterParser.element_return);

        ObjectFilterParser.element_return element14 = default(ObjectFilterParser.element_return);


        object HASH11_tree=null;
        object MAIL13_tree=null;

        try 
    	{
            // ObjectFilter.g:28:21: ( element | HASH element | MAIL element )
            int alt2 = 3;
            switch ( input.LA(1) ) 
            {
            case Q_STRING:
            case A_STRING:
            case I_STRING:
            case PLUS:
            case TILDA:
            case ARROW:
            case NARROW:
            case DOLLAR:
            case NDOLLAR:
            case EQ:
            case NE:
            	{
                alt2 = 1;
                }
                break;
            case HASH:
            	{
                alt2 = 2;
                }
                break;
            case MAIL:
            	{
                alt2 = 3;
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
                    // ObjectFilter.g:29:2: element
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_element_in_element_with_context179);
                    	element10 = element();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, element10.Tree);

                    }
                    break;
                case 2 :
                    // ObjectFilter.g:30:4: HASH element
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	HASH11=(IToken)Match(input,HASH,FOLLOW_HASH_in_element_with_context185); 
                    		HASH11_tree = (object)adaptor.Create(HASH11);
                    		adaptor.AddChild(root_0, HASH11_tree);

                    	PushFollow(FOLLOW_element_in_element_with_context187);
                    	element12 = element();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, element12.Tree);
                    	 SetLastConditionContext(ObjectFilterContextEnum.Content); 

                    }
                    break;
                case 3 :
                    // ObjectFilter.g:31:4: MAIL element
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	MAIL13=(IToken)Match(input,MAIL,FOLLOW_MAIL_in_element_with_context194); 
                    		MAIL13_tree = (object)adaptor.Create(MAIL13);
                    		adaptor.AddChild(root_0, MAIL13_tree);

                    	PushFollow(FOLLOW_element_in_element_with_context196);
                    	element14 = element();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, element14.Tree);
                    	 SetLastConditionContext(ObjectFilterContextEnum.Schema); 

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
    // $ANTLR end "element_with_context"

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
    // ObjectFilter.g:34:1: factor : ( element_with_context )+ ;
    public ObjectFilterParser.factor_return factor() // throws RecognitionException [1]
    {   
        ObjectFilterParser.factor_return retval = new ObjectFilterParser.factor_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        ObjectFilterParser.element_with_context_return element_with_context15 = default(ObjectFilterParser.element_with_context_return);



        try 
    	{
            // ObjectFilter.g:34:7: ( ( element_with_context )+ )
            // ObjectFilter.g:35:3: ( element_with_context )+
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// ObjectFilter.g:35:3: ( element_with_context )+
            	int cnt3 = 0;
            	do 
            	{
            	    int alt3 = 2;
            	    int LA3_0 = input.LA(1);

            	    if ( ((LA3_0 >= Q_STRING && LA3_0 <= MAIL)) )
            	    {
            	        alt3 = 1;
            	    }


            	    switch (alt3) 
            		{
            			case 1 :
            			    // ObjectFilter.g:35:3: element_with_context
            			    {
            			    	PushFollow(FOLLOW_element_with_context_in_factor212);
            			    	element_with_context15 = element_with_context();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, element_with_context15.Tree);

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
    // ObjectFilter.g:37:1: list : factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )* ;
    public ObjectFilterParser.list_return list() // throws RecognitionException [1]
    {   
        ObjectFilterParser.list_return retval = new ObjectFilterParser.list_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken COMMA17 = null;
        IToken ENDLINE18 = null;
        IToken ENDLINE20 = null;
        ObjectFilterParser.factor_return factor16 = default(ObjectFilterParser.factor_return);

        ObjectFilterParser.factor_return factor19 = default(ObjectFilterParser.factor_return);


        object COMMA17_tree=null;
        object ENDLINE18_tree=null;
        object ENDLINE20_tree=null;

        try 
    	{
            // ObjectFilter.g:37:5: ( factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )* )
            // ObjectFilter.g:38:3: factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_factor_in_list223);
            	factor16 = factor();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, factor16.Tree);
            	// ObjectFilter.g:38:10: ( ( COMMA | ( ( ENDLINE )+ ) ) factor )*
            	do 
            	{
            	    int alt6 = 2;
            	    alt6 = dfa6.Predict(input);
            	    switch (alt6) 
            		{
            			case 1 :
            			    // ObjectFilter.g:38:12: ( COMMA | ( ( ENDLINE )+ ) ) factor
            			    {
            			    	// ObjectFilter.g:38:12: ( COMMA | ( ( ENDLINE )+ ) )
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
            			    	        // ObjectFilter.g:38:13: COMMA
            			    	        {
            			    	        	COMMA17=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_list228); 
            			    	        		COMMA17_tree = (object)adaptor.Create(COMMA17);
            			    	        		adaptor.AddChild(root_0, COMMA17_tree);


            			    	        }
            			    	        break;
            			    	    case 2 :
            			    	        // ObjectFilter.g:38:21: ( ( ENDLINE )+ )
            			    	        {
            			    	        	// ObjectFilter.g:38:21: ( ( ENDLINE )+ )
            			    	        	// ObjectFilter.g:38:22: ( ENDLINE )+
            			    	        	{
            			    	        		// ObjectFilter.g:38:22: ( ENDLINE )+
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
            			    	        				    // ObjectFilter.g:38:22: ENDLINE
            			    	        				    {
            			    	        				    	ENDLINE18=(IToken)Match(input,ENDLINE,FOLLOW_ENDLINE_in_list233); 
            			    	        				    		ENDLINE18_tree = (object)adaptor.Create(ENDLINE18);
            			    	        				    		adaptor.AddChild(root_0, ENDLINE18_tree);


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
            			    	PushFollow(FOLLOW_factor_in_list240);
            			    	factor19 = factor();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, factor19.Tree);

            			    }
            			    break;

            			default:
            			    goto loop6;
            	    }
            	} while (true);

            	loop6:
            		;	// Stops C# compiler whining that label 'loop6' has no statements

            	// ObjectFilter.g:38:67: ( ENDLINE )*
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
            			    // ObjectFilter.g:38:67: ENDLINE
            			    {
            			    	ENDLINE20=(IToken)Match(input,ENDLINE,FOLLOW_ENDLINE_in_list246); 
            			    		ENDLINE20_tree = (object)adaptor.Create(ENDLINE20);
            			    		adaptor.AddChild(root_0, ENDLINE20_tree);


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
    // ObjectFilter.g:40:1: expr : list ;
    public ObjectFilterParser.expr_return expr() // throws RecognitionException [1]
    {   
        ObjectFilterParser.expr_return retval = new ObjectFilterParser.expr_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        ObjectFilterParser.list_return list21 = default(ObjectFilterParser.list_return);



        try 
    	{
            // ObjectFilter.g:40:5: ( list )
            // ObjectFilter.g:40:7: list
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_list_in_expr256);
            	list21 = list();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, list21.Tree);

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
        "\x01\x11\x01\x04\x02\uffff";
    const string DFA6_maxS =
        "\x02\x12\x02\uffff";
    const string DFA6_acceptS =
        "\x02\uffff\x01\x02\x01\x01";
    const string DFA6_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA6_transitionS = {
            "\x01\x03\x01\x01",
            "\x0d\x03\x01\uffff\x01\x01",
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
            get { return "()* loopback of 38:10: ( ( COMMA | ( ( ENDLINE )+ ) ) factor )*"; }
        }

    }

 

    public static readonly BitSet FOLLOW_set_in_string_lit0 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_string_lit_in_element62 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_PLUS_in_element70 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element74 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_TILDA_in_element82 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element86 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_ARROW_in_element95 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element99 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NARROW_in_element108 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element112 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DOLLAR_in_element121 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element125 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NDOLLAR_in_element134 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element138 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EQ_in_element147 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element151 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NE_in_element160 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element164 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_element_in_element_with_context179 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_HASH_in_element_with_context185 = new BitSet(new ulong[]{0x0000000000007FF0UL});
    public static readonly BitSet FOLLOW_element_in_element_with_context187 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_MAIL_in_element_with_context194 = new BitSet(new ulong[]{0x0000000000007FF0UL});
    public static readonly BitSet FOLLOW_element_in_element_with_context196 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_element_with_context_in_factor212 = new BitSet(new ulong[]{0x000000000001FFF2UL});
    public static readonly BitSet FOLLOW_factor_in_list223 = new BitSet(new ulong[]{0x0000000000060002UL});
    public static readonly BitSet FOLLOW_COMMA_in_list228 = new BitSet(new ulong[]{0x000000000001FFF0UL});
    public static readonly BitSet FOLLOW_ENDLINE_in_list233 = new BitSet(new ulong[]{0x000000000005FFF0UL});
    public static readonly BitSet FOLLOW_factor_in_list240 = new BitSet(new ulong[]{0x0000000000060002UL});
    public static readonly BitSet FOLLOW_ENDLINE_in_list246 = new BitSet(new ulong[]{0x0000000000040002UL});
    public static readonly BitSet FOLLOW_list_in_expr256 = new BitSet(new ulong[]{0x0000000000000002UL});

}
