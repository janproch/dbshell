grammar LogicalFilter;
 
options {
	language=CSharp2;
	output=AST;
  superClass=DbShellFilterAntlrParser;
}

@header {
  using DbShell.Driver.Common.DmlFramework;
using System.Globalization;
}

sql_identifier:
  lit1=SQL_LITERAL { Push($lit1.text); }
  (DOT lit2=SQL_LITERAL { Push(Pop<string>() + "." + $lit2.text); } )* 
  ; 
  
sql_variable:
    var=SQL_VARIABLE { Push($var.text); };
  
sql_name : sql_identifier | sql_variable;

element:
  T_TRUE { AddTrueCondition();  } 
  | T_FALSE { AddFalseCondition();  } 
  | T_1 { AddTrueCondition();  } 
  | T_0 { AddFalseCondition();  } 
  | T_NULL { AddIsNullCondition(); }
  | T_NOT T_NULL { AddIsNotNullCondition(); }
  
  | NE sql_name { AddSqlLiteralRelation(Pop<string>(), "<>"); } 
  | EQ sql_name { AddSqlLiteralRelation(Pop<string>(), "="); }
  | EQ2 sql_name { AddSqlLiteralRelationWithNullTest_EQ(Pop<string>()); } 
  | NE2 sql_name { AddSqlLiteralRelationWithNullTest_NE(Pop<string>()); }
  ;
  
factor :
  element+;

list: 
  factor ( (COMMA | (ENDLINE+)) { AddAndCondition(); } factor ) * ENDLINE*; 
 
expr: list ; 

T_NULL: N U L L;
T_NOT: N O T;
T_TRUE: T R U E;
T_FALSE: F A L S E;
T_0: DIGIT_0;
T_1: DIGIT_1;
 
NE:  '<>';
EQ:  '=';
COMMA: ',';
DOT: '.';
EQ2:  '==';
NE2:  '!=';

WHITESPACE : ( '\t' | ' ' | '\u000C' )+    { $channel = HIDDEN; } ;
ENDLINE: ( '\r' | '\n' )+; 
 
SQL_LITERAL:
	  ('['
	  	(
	  		  options{greedy=true;}: ~(']' | '\r' | '\n' )
	  	)*
	  ']' )
;
 
SQL_VARIABLE:
    ('@'    
        ('a'..'z'|'A'..'Z'|'_')
        ( options{greedy=true;}: ('a'..'z'|'A'..'Z'|'0'..'9'|'_')  )*
    )
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
 
fragment DIGIT_0  : '0';
fragment DIGIT_1  : '1';

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
