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
  
number:
  positive_number | negative_number;

interval : 
number MINUS num2=NUMBER {
        var left = Pop<decimal>();var right=Decimal.Parse($num2.text, CultureInfo.InvariantCulture);
        Conditions.Add(new DmlfBetweenCondition
            {
                Expr = ColumnValue,
                LowerBound = new DmlfLiteralExpression{Value = left},
                UpperBound = new DmlfLiteralExpression{Value = right},
            });
};
 
element_no_negative:
  positive_number { AddEqualCondition(Pop<decimal>().ToString(CultureInfo.InvariantCulture)); } 
  | interval
  | LT num1=number { AddNumberRelation($num1.text, "<"); } 
  | GT num1=number { AddNumberRelation($num1.text, ">"); } 
  | LE num1=number { AddNumberRelation($num1.text, "<="); } 
  | GE num1=number { AddNumberRelation($num1.text, ">="); } 
  | NE num1=number { AddNumberRelation($num1.text, "<>"); } 
  | EQ num1=number { AddNumberRelation($num1.text, "="); } 
  | T_NULL { AddIsNullCondition(); }
  | T_NOT T_NULL { AddIsNotNullCondition(); }
  ;
  
element_maybe_negative:
  negative_number { AddEqualCondition(Pop<decimal>().ToString(CultureInfo.InvariantCulture)); }
  | element_no_negative;
  
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
NE:  '!=' | '<>';
EQ:  '=';
COMMA: ',';
 
NUMBER  : (DIGIT)+ ('.' (DIGIT)+)?;

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
