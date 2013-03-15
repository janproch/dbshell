grammar IntegerFilter;
 
 
expr    : term ( ( PLUS | MINUS )  term )* ;
 
term    : factor ( ( MULT | DIV ) factor )* ;
 
factor  : NUMBER ;

list :  
 
expr : list; 
 
 
MINUS:  '-';
LT:  '<';
GT:  '>';
 
NUMBER  : (DIGIT)+ ;

WHITESPACE : ( '\t' | ' ' | '\r' | '\n'| '\u000C' )+    { $channel = HIDDEN; } ;
 
fragment DIGIT  : '0'..'9' ;
