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

number: 
  MINUS num1=NUMBER { Push(-Decimal.Parse($num1.text, CultureInfo.InvariantCulture)); }
  | num2=NUMBER { Push(Decimal.Parse($num2.text, CultureInfo.InvariantCulture)); } ;

interval : 
number MINUS number {
        var right = Pop<decimal>();var left = Pop<decimal>();
        Condition.Conditions.Add(new DmlfBetweenCondition
            {
                Expr = ColumnValue,
                LowerBound = new DmlfLiteralExpression{Value = left},
                UpperBound = new DmlfLiteralExpression{Value = right},
            });
};
 
factor:
  number { AddEqualCondition(Pop<decimal>().ToString(CultureInfo.InvariantCulture)); } 
  | interval
  | LT num1=number { AddNumberRelation($num1.text, "<"); } 
  | GT num1=number { AddNumberRelation($num1.text, ">"); } 
  | LE num1=number { AddNumberRelation($num1.text, "<="); } 
  | GE num1=number { AddNumberRelation($num1.text, "<="); } 
  | NE num1=number { AddNumberRelation($num1.text, "<>"); } 
  | EQ num1=number { AddNumberRelation($num1.text, "="); } 
   ;

list: 
  factor ( COMMA factor ) *; 
 
expr: list; 
 
MINUS:  '-';
LT:  '<';
GT:  '>';
GE:  '>=';
LE:  '<=';
NE:  '!=' | '<>';
EQ:  '=';
COMMA: ',';
 
NUMBER  : (DIGIT)+ ;

WHITESPACE : ( '\t' | ' ' | '\u000C' )+    { $channel = HIDDEN; } ;
ENDLINE: ( '\r' | '\n' )+; 
 
fragment DIGIT  : '0'..'9' ;
