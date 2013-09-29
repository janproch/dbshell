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
  
  | T_MON { AddDayOfWeekCondition(1); }
  | T_TUE { AddDayOfWeekCondition(2); }
  | T_WED { AddDayOfWeekCondition(3); }
  | T_THU { AddDayOfWeekCondition(4); }
  | T_FRI { AddDayOfWeekCondition(5); }
  | T_SAT { AddDayOfWeekCondition(6); }
  | T_SUN { AddDayOfWeekCondition(7); }
  
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
    
  | LT d=DATE t=TIME { var dt=ParseDate($d.text)+ParseTime($t.text);AddDateTimeRelation(dt, "<"); }  
  | LE d=DATE t=TIME { var dt=ParseDate($d.text)+ParseTime($t.text);AddDateTimeRelation(dt, "<="); }  
  | GT d=DATE t=TIME { var dt=ParseDate($d.text)+ParseTime($t.text);AddDateTimeRelation(dt, ">"); }  
  | GE d=DATE t=TIME { var dt=ParseDate($d.text)+ParseTime($t.text);AddDateTimeRelation(dt, ">="); }
  | T_NULL { AddIsNullCondition(); }
  | T_NOT T_NULL { AddIsNotNullCondition(); }
;

interval : 
  d1=DATE MINUS d2=DATE { AddDateTimeIntervalCondition(ParseDate($d1.text), ParseDate($d2.text) + TimeSpan.FromDays(1)); }
  | d1=DATE t1=TIME MINUS d2=DATE t2=TIME {
    AddDateTimeIntervalCondition(ParseDate($d1.text) + ParseTime($t1.text), ParseDate($d2.text) + ParseTime($t2.text));    
  }
;
 
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
NE:  '!=' | '<>';
EQ:  '=';
COMMA: ',';

YEAR: DIGIT DIGIT DIGIT DIGIT;

DATE: DIGIT DIGIT DIGIT DIGIT '-' DIGIT? DIGIT '-' DIGIT? DIGIT    // ISO format
  | DIGIT? DIGIT '.'  DIGIT? DIGIT '.' (DIGIT DIGIT DIGIT DIGIT)?  // Czech format
  | DIGIT? DIGIT '/'  DIGIT? DIGIT ('/' DIGIT DIGIT DIGIT DIGIT)?  // US format 
;

TIME: DIGIT? DIGIT ':' DIGIT? DIGIT ( ':' DIGIT? DIGIT ( '.' DIGIT (DIGIT? DIGIT)? )?  )?; 

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
