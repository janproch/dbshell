grammar DateTimeFilter;
 
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

specification:
  y=YEAR { var d1=new DateTime(Int32.Parse($y.text), 1, 1); AddDateTimeIntervalCondition(d1, d1.AddYears(1)); }
  | d=DATE { AddDateCondition($d.text); }
  //| d=DATE t=TIME { AddDateTimeCondition($d.text, $t.text); }
  | d=HOUR_ANY_MINUTE { AddAnyMinuteCondition($d.text); } 
  | d=FLOW_MONTH { AddFlowMonthCondition($d.text); }
  | d=FLOW_DAY { AddFlowDayCondition($d.text); }
  | d=YEAR_MONTH { AddYearMonthCondition($d.text); }
  
  | T_JAN { AddMonthCondition(1); }
  | T_FEB { AddMonthCondition(2); }
  | T_MAR { AddMonthCondition(3); }
  | T_APR { AddMonthCondition(4); }
  | T_MAY { AddMonthCondition(5); }
  | T_JUN { AddMonthCondition(6); }
  | T_JUL { AddMonthCondition(7); }
  | T_AUG { AddMonthCondition(8); }
  | T_SEP { AddMonthCondition(9); }
  | T_OCT { AddMonthCondition(10); }
  | T_NOV { AddMonthCondition(11); }
  | T_DEC { AddMonthCondition(12); }
  
  | T_MON { AddDayOfWeekCondition(DayOfWeek.Monday); }
  | T_TUE { AddDayOfWeekCondition(DayOfWeek.Tuesday); }
  | T_WED { AddDayOfWeekCondition(DayOfWeek.Wednesday); }
  | T_THU { AddDayOfWeekCondition(DayOfWeek.Thursday); }
  | T_FRI { AddDayOfWeekCondition(DayOfWeek.Friday); }
  | T_SAT { AddDayOfWeekCondition(DayOfWeek.Saturday); }
  | T_SUN { AddDayOfWeekCondition(DayOfWeek.Sunday); }
  
  | T_LAST T_HOUR { var h1 = new DateTime(Now.Year, Now.Month, Now.Day, Now.Hour, 0, 0); AddDateTimeIntervalCondition(h1 - TimeSpan.FromHours(1), h1); }
  | T_THIS T_HOUR { var h1 = new DateTime(Now.Year, Now.Month, Now.Day, Now.Hour, 0, 0); AddDateTimeIntervalCondition(h1, h1 + TimeSpan.FromHours(1)); }
  | T_NEXT T_HOUR { var h1 = new DateTime(Now.Year, Now.Month, Now.Day, Now.Hour, 0, 0); AddDateTimeIntervalCondition(h1 + TimeSpan.FromHours(1), h1 + TimeSpan.FromHours(2)); }

  | T_YESTERDAY { AddDateTimeIntervalCondition(Now.Date-TimeSpan.FromDays(1), Now.Date); }
  | T_TODAY { AddDateTimeIntervalCondition(Now.Date, Now.Date+TimeSpan.FromDays(1)); }
  | T_TOMORROW { AddDateTimeIntervalCondition(Now.Date+TimeSpan.FromDays(1), Now.Date+TimeSpan.FromDays(2)); }
  
  | T_LAST T_WEEK { var d1=GetFirstDayOfWeek(Now.Date); AddDateTimeIntervalCondition(d1-TimeSpan.FromDays(7), d1); }
  | T_THIS T_WEEK { var d1=GetFirstDayOfWeek(Now.Date); AddDateTimeIntervalCondition(d1, d1+TimeSpan.FromDays(7)); }
  | T_NEXT T_WEEK { var d1=GetFirstDayOfWeek(Now.Date); AddDateTimeIntervalCondition(d1+TimeSpan.FromDays(7), d1+TimeSpan.FromDays(14)); }

  | T_LAST T_MONTH { var d1=new DateTime(Now.Year, Now.Month, 1); AddDateTimeIntervalCondition(d1.AddMonths(-1), d1); }
  | T_THIS T_MONTH { var d1=new DateTime(Now.Year, Now.Month, 1); AddDateTimeIntervalCondition(d1, d1.AddMonths(1)); }
  | T_NEXT T_MONTH { var d1=new DateTime(Now.Year, Now.Month, 1); AddDateTimeIntervalCondition(d1.AddMonths(1), d1.AddMonths(2)); }
  
  | T_LAST T_YEAR { var d1=new DateTime(Now.Year, 1, 1); AddDateTimeIntervalCondition(d1.AddYears(-1), d1); }
  | T_THIS T_YEAR { var d1=new DateTime(Now.Year, 1, 1); AddDateTimeIntervalCondition(d1, d1.AddYears(1)); }
  | T_NEXT T_YEAR { var d1=new DateTime(Now.Year, 1, 1); AddDateTimeIntervalCondition(d1.AddYears(1), d1.AddYears(2)); }
  
  | EQ d=DATE { var dt=ParseDate($d.text);AddDateTimeIntervalCondition(dt, dt + TimeSpan.FromDays(1)); }  
  | LT d=DATE { var dt=ParseDate($d.text);AddDateTimeRelation(dt, "<"); }  
  | LE d=DATE { var dt=ParseDate($d.text);AddDateTimeRelation(dt+TimeSpan.FromDays(1), "<"); }  
  | GT d=DATE { var dt=ParseDate($d.text);AddDateTimeRelation(dt+TimeSpan.FromDays(1), ">="); }  
  | GE d=DATE { var dt=ParseDate($d.text);AddDateTimeRelation(dt, ">="); }  
  | NE d=DATE { var dt=ParseDate($d.text);AddDateTimeNotIntervalCondition(dt, dt + TimeSpan.FromDays(1)); }

  | d=DATE time_noexact { string time=Pop<string>(); AddDateTimeIntervalCondition(ParseDate($d.text) + ParseTime(time), ParseDate($d.text) + ParseTimeEnd(time)); }  
  | EQ d=DATE time_noexact { string time=Pop<string>(); AddDateTimeIntervalCondition(ParseDate($d.text) + ParseTime(time), ParseDate($d.text) + ParseTimeEnd(time)); }

  | d=DATE time_exact { string time=Pop<string>(); var dt=ParseDate($d.text) + ParseTime(time);AddDateTimeRelation(dt, "=");  }  
  | EQ d=DATE time_exact { string time=Pop<string>(); var dt=ParseDate($d.text) + ParseTime(time);AddDateTimeRelation(dt, "=");  }
    
  | LT d=DATE t=time { var dt=ParseDate($d.text)+ParseTime($t.text);AddDateTimeRelation(dt, "<"); }  
  | LE d=DATE t=time { var dt=ParseDate($d.text)+ParseTimeEnd($t.text);AddDateTimeRelation(dt, "<"); }  
  | GT d=DATE t=time { var dt=ParseDate($d.text)+ParseTime($t.text);AddDateTimeRelation(dt, ">"); }  
  | GE d=DATE t=time { var dt=ParseDate($d.text)+ParseTime($t.text);AddDateTimeRelation(dt, ">="); }
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

interval : 
  d1=DATE MINUS d2=DATE { AddDateTimeIntervalCondition(ParseDate($d1.text), ParseDate($d2.text) + TimeSpan.FromDays(1)); }
  | d1=DATE t1=time MINUS d2=DATE t2=time {
    AddDateTimeIntervalCondition(ParseDate($d1.text) + ParseTime($t1.text), ParseDate($d2.text) + ParseTimeEnd($t2.text));    
  }
;

time:
   time_exact | time_noexact;    

time_exact:
  t=TIME_SECOND_FRACTION { Push($t.text); };   

time_noexact:
  t=TIME_MINUE { Push($t.text); } | t=TIME_SECOND { Push($t.text); };
 
element:
  specification | interval;
  
factor :
  element+;

list: 
  factor ( (COMMA | (ENDLINE+)) { AddAndCondition(); } factor ) * ENDLINE*; 
 
expr: list ; 
 
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

YEAR: DIGIT DIGIT DIGIT DIGIT;

DATE: DIGIT DIGIT DIGIT DIGIT '-' DIGIT? DIGIT '-' DIGIT? DIGIT    // ISO format
  | DIGIT? DIGIT '.'  DIGIT? DIGIT '.' (DIGIT DIGIT DIGIT DIGIT)?  // Czech format
  | DIGIT? DIGIT '/'  DIGIT? DIGIT ('/' DIGIT DIGIT DIGIT DIGIT)?  // US format 
;

TIME_MINUE: DIGIT? DIGIT ':' DIGIT? DIGIT;
TIME_SECOND: DIGIT? DIGIT ':' DIGIT? DIGIT ':' DIGIT? DIGIT;
TIME_SECOND_FRACTION: DIGIT? DIGIT ':' DIGIT? DIGIT ':' DIGIT? DIGIT '.' DIGIT*;

FLOW_MONTH: DIGIT? DIGIT '/' ; 
FLOW_DAY: DIGIT? DIGIT '.' ; 
YEAR_MONTH: DIGIT DIGIT DIGIT DIGIT '-' DIGIT? DIGIT ; 
HOUR_ANY_MINUTE: DIGIT? DIGIT ':' '*'; 

T_LAST: L A S T;
T_THIS: T H I S;
T_NEXT: N E X T;

T_HOUR: H O U R;
T_WEEK: W E E K;
T_MONTH: M O N T H;
T_YEAR: Y E A R;

T_YESTERDAY: Y E S T E R D A Y;
T_TODAY: T O D A Y;
T_TOMORROW: T O M O R R O W; 

T_JAN: J A N;
T_FEB: F E B;
T_MAR: M A R;
T_APR: A P R;
T_MAY: M A Y;
T_JUN: J U N;
T_JUL: J U L;
T_AUG: A U G;
T_SEP: S E P;
T_OCT: O C T;
T_NOV: N O V;
T_DEC: D E C;

T_MON: M O N;
T_TUE: T U E;
T_WED: W E D;
T_THU: T H U;
T_FRI: F R I;
T_SAT: S A T;
T_SUN: S U N;

T_NULL: N U L L;
T_NOT: N O T;
  
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
