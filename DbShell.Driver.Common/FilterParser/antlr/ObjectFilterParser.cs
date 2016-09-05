// $ANTLR 3.2 Sep 23, 2009 12:02:23 ObjectFilter.g 2016-09-05 21:10:04

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

    public const int DOLLAR = 10;
    public const int TILDA = 7;
    public const int I_STRING = 6;
    public const int NDOLLAR = 11;
    public const int COMMA = 16;
    public const int MAIL = 15;
    public const int HASH = 14;
    public const int A_STRING = 5;
    public const int WHITESPACE = 18;
    public const int ARROW = 8;
    public const int ENDLINE = 17;
    public const int EQ = 12;
    public const int EOF = -1;
    public const int NARROW = 9;
    public const int NE = 13;
    public const int Q_STRING = 4;

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
    // ObjectFilter.g:16:1: element : (s1= string_lit | TILDA s1= string_lit | ARROW s1= string_lit | NARROW s1= string_lit | DOLLAR s1= string_lit | NDOLLAR s1= string_lit | EQ s1= string_lit | NE s1= string_lit );
    public ObjectFilterParser.element_return element() // throws RecognitionException [1]
    {   
        ObjectFilterParser.element_return retval = new ObjectFilterParser.element_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken TILDA2 = null;
        IToken ARROW3 = null;
        IToken NARROW4 = null;
        IToken DOLLAR5 = null;
        IToken NDOLLAR6 = null;
        IToken EQ7 = null;
        IToken NE8 = null;
        ObjectFilterParser.string_lit_return s1 = default(ObjectFilterParser.string_lit_return);


        object TILDA2_tree=null;
        object ARROW3_tree=null;
        object NARROW4_tree=null;
        object DOLLAR5_tree=null;
        object NDOLLAR6_tree=null;
        object EQ7_tree=null;
        object NE8_tree=null;

        try 
    	{
            // ObjectFilter.g:16:8: (s1= string_lit | TILDA s1= string_lit | ARROW s1= string_lit | NARROW s1= string_lit | DOLLAR s1= string_lit | NDOLLAR s1= string_lit | EQ s1= string_lit | NE s1= string_lit )
            int alt1 = 8;
            switch ( input.LA(1) ) 
            {
            case Q_STRING:
            case A_STRING:
            case I_STRING:
            	{
                alt1 = 1;
                }
                break;
            case TILDA:
            	{
                alt1 = 2;
                }
                break;
            case ARROW:
            	{
                alt1 = 3;
                }
                break;
            case NARROW:
            	{
                alt1 = 4;
                }
                break;
            case DOLLAR:
            	{
                alt1 = 5;
                }
                break;
            case NDOLLAR:
            	{
                alt1 = 6;
                }
                break;
            case EQ:
            	{
                alt1 = 7;
                }
                break;
            case NE:
            	{
                alt1 = 8;
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
                    // ObjectFilter.g:18:5: TILDA s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	TILDA2=(IToken)Match(input,TILDA,FOLLOW_TILDA_in_element71); 
                    		TILDA2_tree = (object)adaptor.Create(TILDA2);
                    		adaptor.AddChild(root_0, TILDA2_tree);

                    	PushFollow(FOLLOW_string_lit_in_element75);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringTestCondition<ObjectFilterContainsTextCondition>(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)));NegateLastCondition(); 

                    }
                    break;
                case 3 :
                    // ObjectFilter.g:19:5: ARROW s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	ARROW3=(IToken)Match(input,ARROW,FOLLOW_ARROW_in_element84); 
                    		ARROW3_tree = (object)adaptor.Create(ARROW3);
                    		adaptor.AddChild(root_0, ARROW3_tree);

                    	PushFollow(FOLLOW_string_lit_in_element88);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringTestCondition<ObjectFilterStartsWithCondition>(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null))); 

                    }
                    break;
                case 4 :
                    // ObjectFilter.g:20:5: NARROW s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NARROW4=(IToken)Match(input,NARROW,FOLLOW_NARROW_in_element97); 
                    		NARROW4_tree = (object)adaptor.Create(NARROW4);
                    		adaptor.AddChild(root_0, NARROW4_tree);

                    	PushFollow(FOLLOW_string_lit_in_element101);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringTestCondition<ObjectFilterStartsWithCondition>(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)));NegateLastCondition(); 

                    }
                    break;
                case 5 :
                    // ObjectFilter.g:21:5: DOLLAR s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	DOLLAR5=(IToken)Match(input,DOLLAR,FOLLOW_DOLLAR_in_element110); 
                    		DOLLAR5_tree = (object)adaptor.Create(DOLLAR5);
                    		adaptor.AddChild(root_0, DOLLAR5_tree);

                    	PushFollow(FOLLOW_string_lit_in_element114);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringTestCondition<ObjectFilterEndsWithCondition>(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null))); 

                    }
                    break;
                case 6 :
                    // ObjectFilter.g:22:5: NDOLLAR s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NDOLLAR6=(IToken)Match(input,NDOLLAR,FOLLOW_NDOLLAR_in_element123); 
                    		NDOLLAR6_tree = (object)adaptor.Create(NDOLLAR6);
                    		adaptor.AddChild(root_0, NDOLLAR6_tree);

                    	PushFollow(FOLLOW_string_lit_in_element127);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringTestCondition<ObjectFilterEndsWithCondition>(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null)));NegateLastCondition(); 

                    }
                    break;
                case 7 :
                    // ObjectFilter.g:23:5: EQ s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	EQ7=(IToken)Match(input,EQ,FOLLOW_EQ_in_element136); 
                    		EQ7_tree = (object)adaptor.Create(EQ7);
                    		adaptor.AddChild(root_0, EQ7_tree);

                    	PushFollow(FOLLOW_string_lit_in_element140);
                    	s1 = string_lit();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, s1.Tree);
                    	 AddStringTestCondition<ObjectFilterEqualsCondition>(ExtractString(((s1 != null) ? input.ToString((IToken)(s1.Start),(IToken)(s1.Stop)) : null))); 

                    }
                    break;
                case 8 :
                    // ObjectFilter.g:24:5: NE s1= string_lit
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	NE8=(IToken)Match(input,NE,FOLLOW_NE_in_element149); 
                    		NE8_tree = (object)adaptor.Create(NE8);
                    		adaptor.AddChild(root_0, NE8_tree);

                    	PushFollow(FOLLOW_string_lit_in_element153);
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
    // ObjectFilter.g:27:1: element_with_context : ( element | HASH element | MAIL element );
    public ObjectFilterParser.element_with_context_return element_with_context() // throws RecognitionException [1]
    {   
        ObjectFilterParser.element_with_context_return retval = new ObjectFilterParser.element_with_context_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken HASH10 = null;
        IToken MAIL12 = null;
        ObjectFilterParser.element_return element9 = default(ObjectFilterParser.element_return);

        ObjectFilterParser.element_return element11 = default(ObjectFilterParser.element_return);

        ObjectFilterParser.element_return element13 = default(ObjectFilterParser.element_return);


        object HASH10_tree=null;
        object MAIL12_tree=null;

        try 
    	{
            // ObjectFilter.g:27:21: ( element | HASH element | MAIL element )
            int alt2 = 3;
            switch ( input.LA(1) ) 
            {
            case Q_STRING:
            case A_STRING:
            case I_STRING:
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
                    // ObjectFilter.g:28:2: element
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	PushFollow(FOLLOW_element_in_element_with_context168);
                    	element9 = element();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, element9.Tree);

                    }
                    break;
                case 2 :
                    // ObjectFilter.g:29:4: HASH element
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	HASH10=(IToken)Match(input,HASH,FOLLOW_HASH_in_element_with_context174); 
                    		HASH10_tree = (object)adaptor.Create(HASH10);
                    		adaptor.AddChild(root_0, HASH10_tree);

                    	PushFollow(FOLLOW_element_in_element_with_context176);
                    	element11 = element();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, element11.Tree);
                    	 SetLastConditionContext(ObjectFilterContextEnum.Content); 

                    }
                    break;
                case 3 :
                    // ObjectFilter.g:30:4: MAIL element
                    {
                    	root_0 = (object)adaptor.GetNilNode();

                    	MAIL12=(IToken)Match(input,MAIL,FOLLOW_MAIL_in_element_with_context183); 
                    		MAIL12_tree = (object)adaptor.Create(MAIL12);
                    		adaptor.AddChild(root_0, MAIL12_tree);

                    	PushFollow(FOLLOW_element_in_element_with_context185);
                    	element13 = element();
                    	state.followingStackPointer--;

                    	adaptor.AddChild(root_0, element13.Tree);
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
    // ObjectFilter.g:33:1: factor : ( element_with_context )+ ;
    public ObjectFilterParser.factor_return factor() // throws RecognitionException [1]
    {   
        ObjectFilterParser.factor_return retval = new ObjectFilterParser.factor_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        ObjectFilterParser.element_with_context_return element_with_context14 = default(ObjectFilterParser.element_with_context_return);



        try 
    	{
            // ObjectFilter.g:33:7: ( ( element_with_context )+ )
            // ObjectFilter.g:34:3: ( element_with_context )+
            {
            	root_0 = (object)adaptor.GetNilNode();

            	// ObjectFilter.g:34:3: ( element_with_context )+
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
            			    // ObjectFilter.g:34:3: element_with_context
            			    {
            			    	PushFollow(FOLLOW_element_with_context_in_factor201);
            			    	element_with_context14 = element_with_context();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, element_with_context14.Tree);

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
    // ObjectFilter.g:36:1: list : factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )* ;
    public ObjectFilterParser.list_return list() // throws RecognitionException [1]
    {   
        ObjectFilterParser.list_return retval = new ObjectFilterParser.list_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        IToken COMMA16 = null;
        IToken ENDLINE17 = null;
        IToken ENDLINE19 = null;
        ObjectFilterParser.factor_return factor15 = default(ObjectFilterParser.factor_return);

        ObjectFilterParser.factor_return factor18 = default(ObjectFilterParser.factor_return);


        object COMMA16_tree=null;
        object ENDLINE17_tree=null;
        object ENDLINE19_tree=null;

        try 
    	{
            // ObjectFilter.g:36:5: ( factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )* )
            // ObjectFilter.g:37:3: factor ( ( COMMA | ( ( ENDLINE )+ ) ) factor )* ( ENDLINE )*
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_factor_in_list212);
            	factor15 = factor();
            	state.followingStackPointer--;

            	adaptor.AddChild(root_0, factor15.Tree);
            	// ObjectFilter.g:37:10: ( ( COMMA | ( ( ENDLINE )+ ) ) factor )*
            	do 
            	{
            	    int alt6 = 2;
            	    alt6 = dfa6.Predict(input);
            	    switch (alt6) 
            		{
            			case 1 :
            			    // ObjectFilter.g:37:12: ( COMMA | ( ( ENDLINE )+ ) ) factor
            			    {
            			    	// ObjectFilter.g:37:12: ( COMMA | ( ( ENDLINE )+ ) )
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
            			    	        // ObjectFilter.g:37:13: COMMA
            			    	        {
            			    	        	COMMA16=(IToken)Match(input,COMMA,FOLLOW_COMMA_in_list217); 
            			    	        		COMMA16_tree = (object)adaptor.Create(COMMA16);
            			    	        		adaptor.AddChild(root_0, COMMA16_tree);


            			    	        }
            			    	        break;
            			    	    case 2 :
            			    	        // ObjectFilter.g:37:21: ( ( ENDLINE )+ )
            			    	        {
            			    	        	// ObjectFilter.g:37:21: ( ( ENDLINE )+ )
            			    	        	// ObjectFilter.g:37:22: ( ENDLINE )+
            			    	        	{
            			    	        		// ObjectFilter.g:37:22: ( ENDLINE )+
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
            			    	        				    // ObjectFilter.g:37:22: ENDLINE
            			    	        				    {
            			    	        				    	ENDLINE17=(IToken)Match(input,ENDLINE,FOLLOW_ENDLINE_in_list222); 
            			    	        				    		ENDLINE17_tree = (object)adaptor.Create(ENDLINE17);
            			    	        				    		adaptor.AddChild(root_0, ENDLINE17_tree);


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
            			    	PushFollow(FOLLOW_factor_in_list229);
            			    	factor18 = factor();
            			    	state.followingStackPointer--;

            			    	adaptor.AddChild(root_0, factor18.Tree);

            			    }
            			    break;

            			default:
            			    goto loop6;
            	    }
            	} while (true);

            	loop6:
            		;	// Stops C# compiler whining that label 'loop6' has no statements

            	// ObjectFilter.g:37:67: ( ENDLINE )*
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
            			    // ObjectFilter.g:37:67: ENDLINE
            			    {
            			    	ENDLINE19=(IToken)Match(input,ENDLINE,FOLLOW_ENDLINE_in_list235); 
            			    		ENDLINE19_tree = (object)adaptor.Create(ENDLINE19);
            			    		adaptor.AddChild(root_0, ENDLINE19_tree);


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
    // ObjectFilter.g:39:1: expr : list ;
    public ObjectFilterParser.expr_return expr() // throws RecognitionException [1]
    {   
        ObjectFilterParser.expr_return retval = new ObjectFilterParser.expr_return();
        retval.Start = input.LT(1);

        object root_0 = null;

        ObjectFilterParser.list_return list20 = default(ObjectFilterParser.list_return);



        try 
    	{
            // ObjectFilter.g:39:5: ( list )
            // ObjectFilter.g:39:7: list
            {
            	root_0 = (object)adaptor.GetNilNode();

            	PushFollow(FOLLOW_list_in_expr245);
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
        "\x01\x10\x01\x04\x02\uffff";
    const string DFA6_maxS =
        "\x02\x11\x02\uffff";
    const string DFA6_acceptS =
        "\x02\uffff\x01\x02\x01\x01";
    const string DFA6_specialS =
        "\x04\uffff}>";
    static readonly string[] DFA6_transitionS = {
            "\x01\x03\x01\x01",
            "\x0c\x03\x01\uffff\x01\x01",
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

 

    public static readonly BitSet FOLLOW_set_in_string_lit0 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_string_lit_in_element62 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_TILDA_in_element71 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element75 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_ARROW_in_element84 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element88 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NARROW_in_element97 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element101 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_DOLLAR_in_element110 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element114 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NDOLLAR_in_element123 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element127 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_EQ_in_element136 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element140 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_NE_in_element149 = new BitSet(new ulong[]{0x0000000000000070UL});
    public static readonly BitSet FOLLOW_string_lit_in_element153 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_element_in_element_with_context168 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_HASH_in_element_with_context174 = new BitSet(new ulong[]{0x0000000000003FF0UL});
    public static readonly BitSet FOLLOW_element_in_element_with_context176 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_MAIL_in_element_with_context183 = new BitSet(new ulong[]{0x0000000000003FF0UL});
    public static readonly BitSet FOLLOW_element_in_element_with_context185 = new BitSet(new ulong[]{0x0000000000000002UL});
    public static readonly BitSet FOLLOW_element_with_context_in_factor201 = new BitSet(new ulong[]{0x000000000000FFF2UL});
    public static readonly BitSet FOLLOW_factor_in_list212 = new BitSet(new ulong[]{0x0000000000030002UL});
    public static readonly BitSet FOLLOW_COMMA_in_list217 = new BitSet(new ulong[]{0x000000000000FFF0UL});
    public static readonly BitSet FOLLOW_ENDLINE_in_list222 = new BitSet(new ulong[]{0x000000000002FFF0UL});
    public static readonly BitSet FOLLOW_factor_in_list229 = new BitSet(new ulong[]{0x0000000000030002UL});
    public static readonly BitSet FOLLOW_ENDLINE_in_list235 = new BitSet(new ulong[]{0x0000000000020002UL});
    public static readonly BitSet FOLLOW_list_in_expr245 = new BitSet(new ulong[]{0x0000000000000002UL});

}
