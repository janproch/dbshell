// $ANTLR 3.2 Sep 23, 2009 12:02:23 StringFilter.g 2013-03-16 13:19:43

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
		"STAR", 
		"MINUS", 
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
		"COMMA", 
		"ENDLINE", 
		"WHITESPACE", 
		"DIGIT"
    };

    public const int DOLLAR = 17;
    public const int GE = 12;
    public const int LT = 9;
    public const int STAR = 7;
    public const int I_STRING = 6;
    public const int WHITESPACE = 21;
    public const int MINUS = 8;
    public const int EOF = -1;
    public const int Q_STRING = 4;
    public const int NDOLLAR = 18;
    public const int COMMA = 19;
    public const int A_STRING = 5;
    public const int GT = 10;
    public const int ARROW = 15;
    public const int ENDLINE = 20;
    public const int DIGIT = 22;
    public const int EQ = 14;
    public const int NARROW = 16;
    public const int LE = 11;
    public const int NE = 13;

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
    // StringFilter.g:16:1: element : (s1= string_lit | STAR s1= string_lit | MINUS s1= string_lit | LT s1= string_lit | GT s1= string_lit | LE s1= string_lit | GE s1= string_lit | NE s1= string_lit | EQ s1= string_lit | ARROW s1= string_lit | NARROW s1= string_lit | DOLLAR s1= string_lit | NDOLLAR s1= string_lit );
    public StringFilterParser.element_return element() // throws RecognitionException [1]
    {   
        StringFilterParser.element_return retval = new StringFilterParser.element_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken STAR2 = null;
        IToken MINUS3 = null;
        IToken LT4 = null;
        IToken GT5 = null;
        IToken LE6 = null;
        IToken GE7 = null;
        IToken NE8 = null;
        IToken EQ9 = null;
        IToken ARROW10 = null;
        IToken NARROW11 = null;
        IToken DOLLAR12 = null;
        IToken NDOLLAR13 = null;
        StringFilterParser.string_lit_return s1 = default(StringFilterParser.string_lit_return);


        object STAR2_tree=null;
        object MINUS3_tree=null;
        object LT4_tree=null;
        object GT5_tree=null;
        object LE6_tree=null;
        object GE7_tree=null;
        object NE8_tree=null;
        object EQ9_tree=null;
        object ARROW10_tree=null;
        object NARROW11_tree=null;
        object DOLLAR12_tree=null;
        object NDOLLAR13_tree=null;

        try 
    	{
            // StringFilter.g:16:8: (s1= string_lit | STAR s1= string_lit | MINUS s1= string_lit | LT s1= string_lit | GT s1= string_lit | LE s1= string_lit | GE s1= string_lit | NE s1= string_lit | EQ s1= string_lit | ARROW s1= string_lit | NARROW s1= string_lit | DOLLAR s1= string_lit | NDOLLAR s1= string_lit )
            int alt1 = 13;
            switch ( input.LA(1) ) 
            {
            case Q_STRING:
            case A_STRING:
            case I_STRING:
            	{
                alt1 = 1;
                }
                break;
            case STAR:
            	{
                alt1 = 2;
                }
                break;
            case MINUS:
            	{
                alt1 = 3;
                }
                break;
            case LT:
            	{
                alt1 = 4;
                }
                break;
            case GT:
            	{
                alt1 = 5;
                }
                break;
            case LE:
            	{
                alt1 = 6;
                }
                break;
            case GE:
            	{
                alt1 = 7;
                }
                break;
            case NE:
            	{
                alt1 = 8;
                }
                break;
            case EQ:
            	{
                alt1 = 9;
                }
                break;
            case ARROW:
            	{
                alt1 = 10;
                }
                break;
            case NARROW:
            	{
                alt1 = 11;
                }
                break;
            case DOLLAR:
            	{
                alt1 = 12;
                }
                break;
            case NDOLLAR:
            	{
                alt1 = 13;
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
                    // StringFilter.g:17:3: s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_string_lit_in_element60);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddLikeCondition(true, ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)), true); 

                    }
                    break;
                case 2 :
                    // StringFilter.g:18:5: STAR s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	STAR2=(IToken)Match(input,STAR,FOLLOW_STAR_in_element69); 
                    		STAR2_tree = (object)adaptor.Create(STAR2);
                    		adaptor.AddChild(root_0, STAR2_tree);

                    	PushFollow(FOLLOW_string_lit_in_element73);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddLikeCondition(true, ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)), true); 

                    }
                    break;
                case 3 :
                    // StringFilter.g:19:5: MINUS s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	MINUS3=(IToken)Match(input,MINUS,FOLLOW_MINUS_in_element82); 
                    		MINUS3_tree = (object)adaptor.Create(MINUS3);
                    		adaptor.AddChild(root_0, MINUS3_tree);

                    	PushFollow(FOLLOW_string_lit_in_element86);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddLikeCondition(true, ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)), true);NegateLastCondition(); 

                    }
                    break;
                case 4 :
                    // StringFilter.g:20:5: LT s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LT4=(IToken)Match(input,LT,FOLLOW_LT_in_element95); 
                    		LT4_tree = (object)adaptor.Create(LT4);
                    		adaptor.AddChild(root_0, LT4_tree);

                    	PushFollow(FOLLOW_string_lit_in_element99);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringRelation(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)), "<"); 

                    }
                    break;
                case 5 :
                    // StringFilter.g:21:5: GT s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GT5=(IToken)Match(input,GT,FOLLOW_GT_in_element108); 
                    		GT5_tree = (object)adaptor.Create(GT5);
                    		adaptor.AddChild(root_0, GT5_tree);

                    	PushFollow(FOLLOW_string_lit_in_element112);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringRelation(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)), ">"); 

                    }
                    break;
                case 6 :
                    // StringFilter.g:22:5: LE s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	LE6=(IToken)Match(input,LE,FOLLOW_LE_in_element121); 
                    		LE6_tree = (object)adaptor.Create(LE6);
                    		adaptor.AddChild(root_0, LE6_tree);

                    	PushFollow(FOLLOW_string_lit_in_element125);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringRelation(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)), "<="); 

                    }
                    break;
                case 7 :
                    // StringFilter.g:23:5: GE s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	GE7=(IToken)Match(input,GE,FOLLOW_GE_in_element134); 
                    		GE7_tree = (object)adaptor.Create(GE7);
                    		adaptor.AddChild(root_0, GE7_tree);

                    	PushFollow(FOLLOW_string_lit_in_element138);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringRelation(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)), "<="); 

                    }
                    break;
                case 8 :
                    // StringFilter.g:24:5: NE s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NE8=(IToken)Match(input,NE,FOLLOW_NE_in_element147); 
                    		NE8_tree = (object)adaptor.Create(NE8);
                    		adaptor.AddChild(root_0, NE8_tree);

                    	PushFollow(FOLLOW_string_lit_in_element151);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringRelation(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)), "<>"); 

                    }
                    break;
                case 9 :
                    // StringFilter.g:25:5: EQ s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	EQ9=(IToken)Match(input,EQ,FOLLOW_EQ_in_element160); 
                    		EQ9_tree = (object)adaptor.Create(EQ9);
                    		adaptor.AddChild(root_0, EQ9_tree);

                    	PushFollow(FOLLOW_string_lit_in_element164);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringRelation(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)), "="); 

                    }
                    break;
                case 10 :
                    // StringFilter.g:26:5: ARROW s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	ARROW10=(IToken)Match(input,ARROW,FOLLOW_ARROW_in_element173); 
                    		ARROW10_tree = (object)adaptor.Create(ARROW10);
                    		adaptor.AddChild(root_0, ARROW10_tree);

                    	PushFollow(FOLLOW_string_lit_in_element177);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddLikeCondition(false, ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)), true); 

                    }
                    break;
                case 11 :
                    // StringFilter.g:27:5: NARROW s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NARROW11=(IToken)Match(input,NARROW,FOLLOW_NARROW_in_element186); 
                    		NARROW11_tree = (object)adaptor.Create(NARROW11);
                    		adaptor.AddChild(root_0, NARROW11_tree);

                    	PushFollow(FOLLOW_string_lit_in_element190);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddLikeCondition(false, ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)), true);NegateLastCondition(); 

                    }
                    break;
                case 12 :
                    // StringFilter.g:28:5: DOLLAR s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	DOLLAR12=(IToken)Match(input,DOLLAR,FOLLOW_DOLLAR_in_element199); 
                    		DOLLAR12_tree = (object)adaptor.Create(DOLLAR12);
                    		adaptor.AddChild(root_0, DOLLAR12_tree);

                    	PushFollow(FOLLOW_string_lit_in_element203);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddLikeCondition(true, ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)), false); 

                    }
                    break;
                case 13 :
                    // StringFilter.g:29:5: NDOLLAR s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NDOLLAR13=(IToken)Match(input,NDOLLAR,FOLLOW_NDOLLAR_in_element212); 
                    		NDOLLAR13_tree = (object)adaptor.Create(NDOLLAR13);
                    		adaptor.AddChild(root_0, NDOLLAR13_tree);

                    	PushFollow(FOLLOW_string_lit_in_element216);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddLikeCondition(true, ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)), false);NegateLastCondition(); 

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
    // StringFilter.g:32:1: factor : ( element )+ ;
    public StringFilterParser.factor_return factor() // throws RecognitionException [1]
    {   
        StringFilterParser.factor_return retval = new StringFilterParser.factor_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        StringFilterParser.element_return element14 = default(StringFilterParser.element_return);



        try 
    	{
            // StringFilter.g:32:7: ( ( element )+ )
            // StringFilter.g:33:3: ( element )+
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// StringFilter.g:33:3: ( element )+
            	int cnt2 = 0;
            	do 
            	{
            	    int alt2 = 2;
            	    int LA2_0 = input.LA(1);

            	    if ( ((LA2_0 >= Q_STRING && LA2_0 <= NDOLLAR)) )
            	    {
            	        alt2 = 1;
            	    }


            	    switch (alt2) 
            		{
            			case 1 :
            			    // StringFilter.g:33:3: element
            			    {
            			    	PushFollow(FOLLOW_element_in_factor232);
            			    	element14 = element();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, element14.Tree);

            			    }
            			    break;

            			default:
            			    if ( cnt2 >= 1 ) goto loop2;
            		            EarlyExitException eee2 =
            		                new EarlyExitException(2, input);
            		            throw eee2;
            	    }
            	    cnt2++;
            	} while (true);

            	loop2:
            		;	// Stops C# compiler whining that label 'loop2' has no statements


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
    // StringFilter.g:35:1: list : factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )* ;
    public StringFilterParser.list_return list() // throws RecognitionException [1]
    {   
        StringFilterParser.list_return retval = new StringFilterParser.list_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken COMMA16 = null;
        IToken ENDLINE17 = null;
        IToken ENDLINE19 = null;
        StringFilterParser.factor_return factor15 = default(StringFilterParser.factor_return);

        StringFilterParser.factor_return factor18 = default(StringFilterParser.factor_return);


        object COMMA16_tree=null;
        object ENDLINE17_tree=null;
        object ENDLINE19_tree=null;

        try 
    	{
            // StringFilter.g:35:5: ( factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )* )
            // StringFilter.g:36:3: factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_factor_in_list243);
            	factor15 = factor();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, factor15.Tree);
            	// StringFilter.g:36:10: ( ( COMMA | ( ( ENDLINE )+ ) ) factor )*
            	do 
            	{
            	    int alt5 = 2;
            	    alt5 = dfa5.Predict(input);
            	    switch (alt5) 
            		{
            			case 1 :
            			    // StringFilter.g:36:12: ( COMMA | ( ( ENDLINE )+ ) ) factor
            			    {
            			    	// StringFilter.g:36:12: ( COMMA | ( ( ENDLINE )+ ) )
            			    	int alt4 = 2;
            			    	int LA4_0 = input.LA(1);

            			    	if ( (LA4_0 == COMMA) )
            			    	{
            			    	    alt4 = 1;
            			    	}
            			    	else if ( (LA4_0 == ENDLINE) )
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
            			    	        // StringFilter.g:36:13: COMMA
            			    	        {
            			    	        	COMMA16=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_list248); 
            			    	        		COMMA16_tree = (object)adaptor.Create(COMMA16);
            			    	        		adaptor.AddChild(root_0, COMMA16_tree);


            			    	        }
            			    	        break;
            			    	    case 2 :
            			    	        // StringFilter.g:36:21: ( ( ENDLINE )+ )
            			    	        {
            			    	        	// StringFilter.g:36:21: ( ( ENDLINE )+ )
            			    	        	// StringFilter.g:36:22: ( ENDLINE )+
            			    	        	{
            			    	        		// StringFilter.g:36:22: ( ENDLINE )+
            			    	        		int cnt3 = 0;
            			    	        		do 
            			    	        		{
            			    	        		    int alt3 = 2;
            			    	        		    int LA3_0 = input.LA(1);

            			    	        		    if ( (LA3_0 == ENDLINE) )
            			    	        		    {
            			    	        		        alt3 = 1;
            			    	        		    }


            			    	        		    switch (alt3) 
            			    	        			{
            			    	        				case 1 :
            			    	        				    // StringFilter.g:36:22: ENDLINE
            			    	        				    {
            			    	        				    	ENDLINE17=(IToken)Match(input,ENDLINE,FOLLOW_ENDLINE_in_list253); 
            			    	        				    		ENDLINE17_tree = (object)adaptor.Create(ENDLINE17);
            			    	        				    		adaptor.AddChild(root_0, ENDLINE17_tree);


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


            			    	        }
            			    	        break;

            			    	}

            			    	 AddAndCondition(); 
            			    	PushFollow(FOLLOW_factor_in_list260);
            			    	factor18 = factor();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, factor18.Tree);

            			    }
            			    break;

            			default:
            			    goto loop5;
            	    }
            	} while (true);

            	loop5:
            		;	// Stops C# compiler whining that label 'loop5' has no statements

            	// StringFilter.g:36:67: ( ENDLINE )*
            	do 
            	{
            	    int alt6 = 2;
            	    int LA6_0 = input.LA(1);

            	    if ( (LA6_0 == ENDLINE) )
            	    {
            	        alt6 = 1;
            	    }


            	    switch (alt6) 
            		{
            			case 1 :
            			    // StringFilter.g:36:67: ENDLINE
            			    {
            			    	ENDLINE19=(IToken)Match(input,ENDLINE,FOLLOW_ENDLINE_in_list266); 
            			    		ENDLINE19_tree = (object)adaptor.Create(ENDLINE19);
            			    		adaptor.AddChild(root_0, ENDLINE19_tree);


            			    }
            			    break;

            			default:
            			    goto loop6;
            	    }
            	} while (true);

            	loop6:
            		;	// Stops C# compiler whining that label 'loop6' has no statements


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
    // StringFilter.g:38:1: expr : list ;
    public StringFilterParser.expr_return expr() // throws RecognitionException [1]
    {   
        StringFilterParser.expr_return retval = new StringFilterParser.expr_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        StringFilterParser.list_return list20 = default(StringFilterParser.list_return);



        try 
    	{
            // StringFilter.g:38:5: ( list )
            // StringFilter.g:38:7: list
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_list_in_expr276);
            	list20 = list();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, list20.Tree);

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


   	protected DFA5 dfa5;
	private void InitializeCyclicDFAs()
	{
    	this.dfa5 = new DFA5(this);
	}

    const string DFA5_eotS =
        "\x04\uffff";
    const string DFA5_eofS =
        "\x02\x02\x02\uffff";
    const string DFA5_minS =
        "\x01\x13\x01\x04\x02\uffff";
    const string DFA5_maxS =
        "\x02\x14\x02\uffff";
    const string DFA5_acceptS =
        "\x02\uffff\x01\x02\x01\x01";
    const string DFA5_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA5_transitionS = {
            "\x01\x03\x01\x01",
            "\x0f\x03\x01\uffff\x01\x01",
            "",
            ""
    };

    static readonly short[] DFA5_eot = DFA.UnpackEncodedString(DFA5_eotS);
    static readonly short[] DFA5_eof = DFA.UnpackEncodedString(DFA5_eofS);
    static readonly char[] DFA5_min = DFA.UnpackEncodedStringToUnsignedChars(DFA5_minS);
    static readonly char[] DFA5_max = DFA.UnpackEncodedStringToUnsignedChars(DFA5_maxS);
    static readonly short[] DFA5_accept = DFA.UnpackEncodedString(DFA5_acceptS);
    static readonly short[] DFA5_special = DFA.UnpackEncodedString(DFA5_specialS);
    static readonly short[][] DFA5_transition = DFA.UnpackEncodedStringArray(DFA5_transitionS);

    protected class DFA5 : DFA
    {
        public DFA5(BaseRecognizer recognizer)
        {
            this.recognizer = recognizer;
            this.decisionNumber = 5;
            this.eot = DFA5_eot;
            this.eof = DFA5_eof;
            this.min = DFA5_min;
            this.max = DFA5_max;
            this.accept = DFA5_accept;
            this.special = DFA5_special;
            this.transition = DFA5_transition;

        }

        override public string Description
        {
            get { return "()* loopback of 36:10: ( ( COMMA | ( ( ENDLINE )+ ) ) factor )*"; }
        }

    }

 

    public static readonly BitSet FOLLOW_set_in_string_lit0 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_string_lit_in_element60 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_STAR_in_element69 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element73 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_MINUS_in_element82 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element86 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LT_in_element95 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element99 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GT_in_element108 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element112 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_LE_in_element121 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element125 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_GE_in_element134 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element138 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NE_in_element147 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element151 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EQ_in_element160 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element164 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_ARROW_in_element173 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element177 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NARROW_in_element186 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element190 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DOLLAR_in_element199 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element203 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NDOLLAR_in_element212 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element216 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_element_in_factor232 = new BitSet(new ulong[]{0x000000000007FFF2UL});
    public static readonly BitSet FOLLOW_factor_in_list243 = new BitSet(new ulong[]{0x0000000000180002UL});
    public static readonly BitSet FOLLOW_COMMA_in_list248 = new BitSet(new ulong[]{0x000000000007FFF0UL});
    public static readonly BitSet FOLLOW_ENDLINE_in_list253 = new BitSet(new ulong[]{0x000000000017FFF0UL});
    public static readonly BitSet FOLLOW_factor_in_list260 = new BitSet(new ulong[]{0x0000000000180002UL});
    public static readonly BitSet FOLLOW_ENDLINE_in_list266 = new BitSet(new ulong[]{0x0000000000100002UL});
    public static readonly BitSet FOLLOW_list_in_expr276 = new BitSet(new ulong[]{0x0000000000000002UL});

}
