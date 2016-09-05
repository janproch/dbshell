grammar ObjectFilter;
 
options {
	language=CSharp2;
	output=AST;
    superClass=ObjectFilterAntlrParser;
}

@header {
  using DbShell.Driver.Common.Utility;
  using System.Globalization;
}

string_lit: Q_STRING | A_STRING | I_STRING; 

element:
  s1=string_lit  { AddStringTestCondition<ObjectFilterContainsTextCondition>(ExtractString($s1.text)); }
  | TILDA s1=string_lit  { AddStringTestCondition<ObjectFilterContainsTextCondition>(ExtractString($s1.text));NegateLastCondition(); }
  | ARROW s1=string_lit { AddStringTestCondition<ObjectFilterStartsWithCondition>(ExtractString($s1.text)); } 
  | NARROW s1=string_lit { AddStringTestCondition<ObjectFilterStartsWithCondition>(ExtractString($s1.text));NegateLastCondition(); } 
  | DOLLAR s1=string_lit { AddStringTestCondition<ObjectFilterEndsWithCondition>(ExtractString($s1.text)); } 
  | NDOLLAR s1=string_lit { AddStringTestCondition<ObjectFilterEndsWithCondition>(ExtractString($s1.text));NegateLastCondition(); } 
  | EQ s1=string_lit { AddStringTestCondition<ObjectFilterEqualsCondition>(ExtractString($s1.text)); } 
  | NE s1=string_lit { AddStringTestCondition<ObjectFilterEqualsCondition>(ExtractString($s1.text));NegateLastCondition(); } 
   ;

element_with_context:
	element 
	| HASH element { SetLastConditionContext(ObjectFilterContextEnum.Content); }
	| MAIL element { SetLastConditionContext(ObjectFilterContextEnum.Schema); }
	;
   
factor:
  element_with_context+;

list: 
  factor ( (COMMA | (ENDLINE+)) { AddAndCondition(); } factor ) * ENDLINE*; 
 
expr: list; 
 
TILDA:  '~';
NE:  '<>';
EQ:  '=';
HASH: '#';
MAIL: '@';
COMMA: ',';
ARROW:  '^';
DOLLAR:  '$';
NARROW:  '!^';
NDOLLAR:  '!$';

A_STRING:
	  ('\''
	  	(
	  		  options{greedy=true;}: ~('\'' | '\r' | '\n' ) | '\'' '\''
	  	)*
	  '\'' )
;

Q_STRING:
	  ('\"'
	  	(
	  		  options{greedy=true;}: ~('\"' | '\r' | '\n' ) | '\"' '\"'
	  	)*
	  '\"' )
;

I_STRING: (~('[' | '~' | ' ' | '<' | '>' | '=' | '!' | '\r' | '\n' | '^' | '$' | '*' | ',' | '+' | '#' | '@' ))*;

WHITESPACE : ( '\t' | ' ' | '\u000C' )+    { $channel = HIDDEN; } ;
ENDLINE: ( '\r' | '\n' )+; 

