grammar StringFilter;
 
options {
	language=CSharp2;
	output=AST;
  superClass=DbShellFilterAntlrParser;
}

@header {
  using DbShell.Driver.Common.DmlFramework;
  using System.Globalization;
}

string_lit: Q_STRING | A_STRING | I_STRING; 

element:
  s1=string_lit  { AddLikeCondition(true, ExtractString($s1.text), true); }
  | PLUS s1=string_lit  { AddLikeCondition(true, ExtractString($s1.text), true); }
  | MINUS s1=string_lit  { AddLikeCondition(true, ExtractString($s1.text), true);NegateLastCondition(); }
  | LT s1=string_lit { AddStringRelation(ExtractString($s1.text), "<"); } 
  | GT s1=string_lit { AddStringRelation(ExtractString($s1.text), ">"); } 
  | LE s1=string_lit { AddStringRelation(ExtractString($s1.text), "<="); } 
  | GE s1=string_lit { AddStringRelation(ExtractString($s1.text), ">="); } 
  | NE s1=string_lit { AddStringRelation(ExtractString($s1.text), "<>"); } 
  | EQ s1=string_lit { AddStringRelation(ExtractString($s1.text), "="); } 
  | ARROW s1=string_lit { AddLikeCondition(false, ExtractString($s1.text), true); } 
  | NARROW s1=string_lit { AddLikeCondition(false, ExtractString($s1.text), true);NegateLastCondition(); } 
  | DOLLAR s1=string_lit { AddLikeCondition(true, ExtractString($s1.text), false); } 
  | NDOLLAR s1=string_lit { AddLikeCondition(true, ExtractString($s1.text), false);NegateLastCondition(); } 
   ;

factor:
  element+;

list: 
  factor ( (COMMA | (ENDLINE+)) { AddAndCondition(); } factor ) * ENDLINE*; 
 
expr: list; 
 
MINUS:  '-';
LT:  '<';
GT:  '>';
GE:  '>=';
LE:  '<=';
NE:  '!=' | '<>';
EQ:  '=';
PLUS: '+';
STAR:  '*';
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

I_STRING: (~('-' | ' ' | '<' | '>' | '=' | '!' | '\r' | '\n' | '^' | '$' | '*' | ',' | '+' ))*;


WHITESPACE : ( '\t' | ' ' | '\u000C' )+    { $channel = HIDDEN; } ;
ENDLINE: ( '\r' | '\n' )+; 
 
fragment DIGIT  : '0'..'9' ;
