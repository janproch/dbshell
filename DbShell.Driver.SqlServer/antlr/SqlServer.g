grammar SqlServer;

options {
	language=CSharp2;
	output=AST;
}

@header {
    using System.Globalization;
    using DbShell.Driver.Common.Utility;
}

find_deps[DepsCollector dc]
    : find_dep_item[dc]*;
find_dep_item[DepsCollector dc]
    : keyword | operator_no_dot | T_NSTRING | T_STRING | T_INTEGER | T_FLOAT | T_BINARYNUM | T_BLOB |
        name1=id { var name=new DepsName();name.AddComponent(UnquoteName($name1.text)); }
        (DOT DOT? (name2=id { name.AddComponent(UnquoteName($name2.text));} | ASTERISK)  )*
        {dc.AddName(name); } ;

id: T_IDENT | T_QUOTED_IDENT;

// ****************************************************************************
// LEXER definitions
// ****************************************************************************
EQUALS:        '=';
SAFEEQUALS:    '<=>';
EQUALS2:       '==';
NOT_EQUALS:    '!=';
NOT_EQUALS2:   '<>';
LESS:          '<';
LESS_OR_EQ:    '<=';
GREATER:       '>';
GREATER_OR_EQ: '>=';
SHIFT_LEFT:    '<<';
SHIFT_RIGHT:   '>>';
AMPERSAND:     '&';
DOUBLE_AMPERSAND: '&&';
PIPE:          '|';
DOUBLE_PIPE:   '||';
PLUS:          '+';
MINUS:         '-';
TILDA:         '~';
ASTERISK:      '*';
SLASH:         '/';
PERCENT:       '%';
SEMI:          ';';
DOT:           '.';
COMMA:         ',';
LPAREN:        '(';
RPAREN:        ')';
QUESTION:      '?';
EXCLAMATION:   '!';
COLON:         ':';
AT:            '@';
DOLLAR:        '$';
ARROW_UP:      '^';

operator_no_dot :
    EQUALS | SAFEEQUALS | EQUALS2 | NOT_EQUALS | NOT_EQUALS2 | LESS | LESS_OR_EQ
    | GREATER | GREATER_OR_EQ | SHIFT_LEFT | SHIFT_RIGHT | AMPERSAND | DOUBLE_AMPERSAND
    | PIPE | DOUBLE_PIPE | PLUS | MINUS | TILDA | ASTERISK | SLASH | PERCENT | SEMI
    | COMMA | LPAREN | RPAREN | QUESTION | EXCLAMATION | COLON | AT | DOLLAR
    | ARROW_UP;

any_operator: DOT | operator_no_dot;

// http://www.antlr.org/wiki/pages/viewpage.action?pageId=1782
fragment A:('a'|'A');
fragment B:('b'|'B');
fragment C:('c'|'C');
fragment D:('d'|'D');
fragment E:('e'|'E');
fragment F:('f'|'F');
fragment G:('g'|'G');
fragment H:('h'|'H');
fragment I:('i'|'I');
fragment J:('j'|'J');
fragment K:('k'|'K');
fragment L:('l'|'L');
fragment M:('m'|'M');
fragment N:('n'|'N');
fragment O:('o'|'O');
fragment P:('p'|'P');
fragment Q:('q'|'Q');
fragment R:('r'|'R');
fragment S:('s'|'S');
fragment T:('t'|'T');
fragment U:('u'|'U');
fragment V:('v'|'V');
fragment W:('w'|'W');
fragment X:('x'|'X');
fragment Y:('y'|'Y');
fragment Z:('z'|'Z');


ADD : A D D;
ALTER : A L T E R;
AND : A N D;
AS : A S;
ASC : A S C;
BEGIN : B E G I N;
BETWEEN : B E T W E E N;
BY : B Y;
CASCADE : C A S C A D E;
CASE : C A S E;
CAST : C A S T;
CHECK : C H E C K;
COLLATE : C O L L A T E;
COLUMN : C O L U M N;
COMMIT : C O M M I T;
CONFLICT : C O N F L I C T;
CONSTRAINT : C O N S T R A I N T;
CREATE : C R E A T E;
CROSS : C R O S S;
CURRENT_TIME : C U R R E N T '_' T I M E;
CURRENT_DATE : C U R R E N T '_' D A T E;
CURRENT_TIMESTAMP : C U R R E N T '_' T I M E S T A M P;
UTC_TIMESTAMP : U T C '_' T I M E S T A M P;
DATABASE : D A T A B A S E;
DEFAULT : D E F A U L T;
DELETE : D E L E T E;
DESC : D E S C;
DISTINCT : D I S T I N C T;
DROP : D R O P;
ELSE : E L S E;
END : E N D;
ESCAPE : E S C A P E;
EXCEPT : E X C E P T;
EXCLUSIVE : E X C L U S I V E;
EXISTS : E X I S T S;
EXPLAIN : E X P L A I N;
FOR : F O R;
FOREIGN : F O R E I G N;
FROM : F R O M;
GROUP : G R O U P;
HAVING : H A V I N G;
IF : I F;
IN : I N;
INDEX : I N D E X;
INNER : I N N E R;
INSERT : I N S E R T;
INTERSECT : I N T E R S E C T;
INTO : I N T O;
IS : I S;
JOIN : J O I N;
KEY : K E Y;
LEFT : L E F T;
LIKE : L I K E;
NOT : N O T;
NULL : N U L L;
OF : O F;
ON : O N;
OR : O R;
ORDER : O R D E R;
OUTER : O U T E R;
PRIMARY : P R I M A R Y;
REFERENCES : R E F E R E N C E S;
ROLLBACK : R O L L B A C K;
SELECT : S E L E C T;
SET : S E T;
TABLE : T A B L E;
TEMPORARY : T E M P O R A R Y;
TEMP : T E M P;
THEN : T H E N;
TO : T O;
TRANSACTION : T R A N S A C T I O N;
TRIGGER : T R I G G E R;
UNION : U N I O N;
UNIQUE : U N I Q U E;
UPDATE : U P D A T E;
VALUES : V A L U E S;
VIEW : V I E W;
WHEN : W H E N;
WHERE : W H E R E;
WITH : W I T H;
PARSER : P A R S E R;
XOR : X O R;

fragment ID_START: ('a'..'z'|'A'..'Z'|'_');
T_IDENT: (ID_START (ID_START|'0'..'9')*);
T_QUOTED_IDENT: '[' ( options {greedy=false;} : . )* ']';

T_NSTRING:
	('N' | 'n')
	  ('\''
	  	(
	  		  options{greedy=true;}: ~('\'' | '\r' | '\n' ) | '\'' '\''
	  	)*
	  '\'' )
;
T_STRING:
	  ('\''
	  	(
	  		  options{greedy=true;}: ~('\'' | '\r' | '\n' ) | '\'' '\''
	  	)*
	  '\'' )
;
T_INTEGER: ('0'..'9')+;
fragment FLOAT_EXP : ('e'|'E') ('+'|'-')? ('0'..'9')+ ;
T_FLOAT
    :   ('0'..'9')+ '.' ('0'..'9')* FLOAT_EXP?
    |   '.' ('0'..'9')+ FLOAT_EXP?
    |   ('0'..'9')+ FLOAT_EXP
    ;
T_BLOB: ('x'|'X') '\'' ('0'..'9'|'a'..'f'|'A'..'F')+ '\'';

T_BINARYNUM : ('0' 'b' ('0' | '1')+ ) | 'b' '\'' ('0' | '1')+ '\'';

fragment T_COMMENT: '/*' ( options {greedy=false;} : . )* '*/';
fragment LINE_COMMENT: '--' ~('\n'|'\r')* ('\r'? '\n'|EOF);

WHITESPACE: (' '|'\r'|'\t'|'\u000C'|'\n'|T_COMMENT|LINE_COMMENT) {$channel=HIDDEN;};

keyword :
ADD|ALTER|AND|AS|ASC|BEGIN|BETWEEN|BY|CASCADE|CASE|CAST|CHECK|COLLATE|COLUMN|COMMIT|CONFLICT|CONSTRAINT|CREATE|CROSS|CURRENT_TIME|CURRENT_DATE|CURRENT_TIMESTAMP|UTC_TIMESTAMP|DATABASE|DEFAULT|DELETE|DESC|DISTINCT|DROP|ELSE|END|ESCAPE|EXCEPT|EXCLUSIVE|EXISTS|EXPLAIN|FOR|FOREIGN|FROM|GROUP|HAVING|IF|IN|INDEX|INNER|INSERT|INTERSECT|INTO|IS|JOIN|KEY|LEFT|LIKE|NOT|NULL|OF|ON|OR|ORDER|OUTER|PRIMARY|REFERENCES|ROLLBACK|SELECT|SET|TABLE|TEMPORARY|TEMP|THEN|TO|TRANSACTION|TRIGGER|UNION|UNIQUE|UPDATE|VALUES|VIEW|WHEN|WHERE|WITH|PARSER|XOR
;
sysname :

;
