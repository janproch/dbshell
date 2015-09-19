grammar NumberFilter;
 
options {
	language=CSharp2;
	output=AST;
  superClass=DbShellFilterAntlrParser;
}

@header {
  using DbShell.Driver.Common.DmlFramework;
using System.Globalization;
}

negative_number: 
  MINUS num1=NUMBER { Push(-Decimal.Parse($num1.text, CultureInfo.InvariantCulture)); };
  
positive_number: 
  num1=NUMBER { Push(Decimal.Parse($num1.text, CultureInfo.InvariantCulture)); };
  
number_as_string:  
  (num1=Q_STRING | num1=A_STRING) { string value=$num1.text; Push(Decimal.Parse(value.Substring(1, value.Length - 2), CultureInfo.InvariantCulture)); };
  
number:
  positive_number | negative_number | number_as_string;

interval : 
number MINUS num2=NUMBER {
        var left = Pop<decimal>();var right=Decimal.Parse($num2.text, CultureInfo.InvariantCulture);
        Conditions.Add(new DmlfBetweenCondition
            {
                Expr = ColumnValue,
                LowerBound = new DmlfLiteralExpression{Value = left},
                UpperBound = new DmlfLiteralExpression{Value = right},
            });
} |
(number MINUS num2=Q_STRING | number MINUS num2=A_STRING) {
        var left = Pop<decimal>();
        string value=$num2.text; 
        var right=Decimal.Parse(value.Substring(1, value.Length - 2), CultureInfo.InvariantCulture);
        Conditions.Add(new DmlfBetweenCondition
            {
                Expr = ColumnValue,
                LowerBound = new DmlfLiteralExpression{Value = left},
                UpperBound = new DmlfLiteralExpression{Value = right},
            });
};

sql_identifier:
  lit1=SQL_LITERAL { Push($lit1.text); }
  (DOT lit2=SQL_LITERAL { Push(Pop<string>() + "." + $lit2.text); } )* 
  ; 
  
sql_variable:
    var=SQL_VARIABLE { Push($var.text); };
  
sql_name : sql_identifier | sql_variable;

 
element_no_negative:
  positive_number { AddNumberEqualCondition(Pop<decimal>()); } 
  | number_as_string { AddNumberEqualCondition(Pop<decimal>()); } 
  | interval
  | LT num1=number { AddNumberRelation(Pop<decimal>(), "<"); } 
  | GT num1=number { AddNumberRelation(Pop<decimal>(), ">"); } 
  | LE num1=number { AddNumberRelation(Pop<decimal>(), "<="); } 
  | GE num1=number { AddNumberRelation(Pop<decimal>(), ">="); } 
  | NE num1=number { AddNumberRelation(Pop<decimal>(), "<>"); } 
  | EQ num1=number { AddNumberRelation(Pop<decimal>(), "="); } 
  | T_NULL { AddIsNullCondition(); }
  | T_NOT T_NULL { AddIsNotNullCondition(); }
  
  | LT sql_name { AddSqlLiteralRelation(Pop<string>(), "<"); } 
  | GT sql_name { AddSqlLiteralRelation(Pop<string>(), ">"); } 
  | LE sql_name { AddSqlLiteralRelation(Pop<string>(), "<="); } 
  | GE sql_name { AddSqlLiteralRelation(Pop<string>(), ">="); } 
  | NE sql_name { AddSqlLiteralRelation(Pop<string>(), "<>"); } 
  | EQ sql_name { AddSqlLiteralRelation(Pop<string>(), "="); }
  | EQ2 sql_name { AddSqlLiteralRelationWithNullTest_EQ(Pop<string>()); } 
  | NE2 sql_name { AddSqlLiteralRelationWithNullTest_NE(Pop<string>()); }
  ;
  
element_maybe_negative:
  negative_number { AddNumberEqualCondition(Pop<decimal>()); }
  | element_no_negative
;
  
factor :
  element_maybe_negative element_no_negative*;

list: 
  factor ( (COMMA | (ENDLINE+)) { AddAndCondition(); } factor ) * ENDLINE*; 
 
expr: list ; 

T_NULL: N U L L;
T_NOT: N O T;
 
MINUS:  '-';
LT:  '<';
GT:  '>';
GE:  '>=';
LE:  '<=';
NE:  '<>';
EQ:  '=';
COMMA: ',';
DOT: '.';
EQ2:  '==';
NE2:  '!=';
 
NUMBER  : (DIGIT)+ ('.' (DIGIT)+)?;

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
