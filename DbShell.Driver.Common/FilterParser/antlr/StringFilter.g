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

sql_name:
  lit1=SQL_LITERAL { Push($lit1.text); }
  (DOT lit2=SQL_LITERAL { Push(Pop<string>() + "." + $lit2.text); } )* 
  ; 

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
  | T_NULL { AddIsNullCondition(); }
  | T_NOT T_NULL { AddIsNotNullCondition(); }
  | T_EMPTY { AddIsEmptyCondition(); }
  | T_NOT T_EMPTY { AddIsNotEmptyCondition(); }
  
  | LT sql_name { AddSqlLiteralRelation(Pop<string>(), "<"); } 
  | GT sql_name { AddSqlLiteralRelation(Pop<string>(), ">"); } 
  | LE sql_name { AddSqlLiteralRelation(Pop<string>(), "<="); } 
  | GE sql_name { AddSqlLiteralRelation(Pop<string>(), ">="); } 
  | NE sql_name { AddSqlLiteralRelation(Pop<string>(), "<>"); } 
  | EQ sql_name { AddSqlLiteralRelation(Pop<string>(), "="); }
  | EQ2 sql_name { AddSqlLiteralRelationWithNullTest_EQ(Pop<string>()); } 
  | NE2 sql_name { AddSqlLiteralRelationWithNullTest_NE(Pop<string>()); }
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
NE:  '<>';
EQ:  '=';
PLUS: '+';
STAR:  '*';
COMMA: ',';
ARROW:  '^';
DOLLAR:  '$';
NARROW:  '!^';
NDOLLAR:  '!$';
DOT: '.';
EQ2:  '==';
NE2:  '!=';

T_NULL: N U L L;
T_NOT: N O T;
T_EMPTY: E M P T Y;

SQL_LITERAL:
	  ('['
	  	(
	  		  options{greedy=true;}: ~(']' | '\r' | '\n' )
	  	)*
	  ']' )
;

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

fragment A: 'A';
fragment B: 'B';
fragment C: 'C';
fragment D: 'D';
fragment E: 'E';
fragment F: 'F';
fragment G: 'G';
fragment H: 'H';
fragment I: 'I';
fragment J: 'J';
fragment K: 'K';
fragment L: 'L';
fragment M: 'M';
fragment N: 'N';
fragment O: 'O';
fragment P: 'P';
fragment Q: 'Q';
fragment R: 'R';
fragment S: 'S';
fragment T: 'T';
fragment U: 'U';
fragment V: 'V';
fragment W: 'W';
fragment X: 'X';
fragment Y: 'Y';
fragment Z: 'Z';
