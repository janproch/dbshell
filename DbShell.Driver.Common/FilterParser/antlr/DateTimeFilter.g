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
  | d=HOUR_ANY_MINUTE { AddAnyMinuteCondition($d.text); } 
  | d=FLOW_MONTH { AddFlowMonthCondition($d.text); }
  | d=FLOW_DAY { AddFlowDayCondition($d.text); }
  | d=YEAR_MONTH { AddYearMonthCondition($d.text); }
  
  | JAN { AddMonthCondition(1); }
  | FEB { AddMonthCondition(2); }
  | MAR { AddMonthCondition(3); }
  | APR { AddMonthCondition(4); }
  | MAY { AddMonthCondition(5); }
  | JUN { AddMonthCondition(6); }
  | JUL { AddMonthCondition(7); }
  | AUG { AddMonthCondition(8); }
  | SEP { AddMonthCondition(9); }
  | OCT { AddMonthCondition(10); }
  | NOV { AddMonthCondition(11); }
  | DEC { AddMonthCondition(12); }
  
  | MON { AddDayOfWeekCondition(1); }
  | TUE { AddDayOfWeekCondition(2); }
  | WED { AddDayOfWeekCondition(3); }
  | THU { AddDayOfWeekCondition(4); }
  | FRI { AddDayOfWeekCondition(5); }
  | SAT { AddDayOfWeekCondition(6); }
  | SUN { AddDayOfWeekCondition(7); }
  
  | LAST_HOUR { var h1 = new DateTime(Now.Year, Now.Month, Now.Day, Now.Hour, 0, 0); AddDateTimeIntervalCondition(h1 - TimeSpan.FromHours(1), h1); }
  | THIS_HOUR { var h1 = new DateTime(Now.Year, Now.Month, Now.Day, Now.Hour, 0, 0); AddDateTimeIntervalCondition(h1, h1 + TimeSpan.FromHours(1)); }
  | NEXT_HOUR { var h1 = new DateTime(Now.Year, Now.Month, Now.Day, Now.Hour, 0, 0); AddDateTimeIntervalCondition(h1 + TimeSpan.FromHours(1), h1 + TimeSpan.FromHours(2)); }

  | YESTERDAY { AddDateTimeIntervalCondition(Now.Date-TimeSpan.FromDays(1), Now.Date); }
  | TODAY { AddDateTimeIntervalCondition(Now.Date, Now.Date+TimeSpan.FromDays(1)); }
  | TOMORROW { AddDateTimeIntervalCondition(Now.Date+TimeSpan.FromDays(1), Now.Date+TimeSpan.FromDays(2)); }
  
  | LAST_WEEK { var d1=GetFirstDayOfWeek(Now.Date); AddDateTimeIntervalCondition(d1-TimeSpan.FromDays(7), d1); }
  | THIS_WEEK { var d1=GetFirstDayOfWeek(Now.Date); AddDateTimeIntervalCondition(d1, d1+TimeSpan.FromDays(7)); }
  | NEXT_WEEK { var d1=GetFirstDayOfWeek(Now.Date); AddDateTimeIntervalCondition(d1+TimeSpan.FromDays(7), d1+TimeSpan.FromDays(14)); }

  | LAST_MONTH { var d1=new DateTime(Now.Year, Now.Month, 1); AddDateTimeIntervalCondition(d1.AddMonths(-1), d1); }
  | THIS_MONTH { var d1=new DateTime(Now.Year, Now.Month, 1); AddDateTimeIntervalCondition(d1, d1.AddMonths(1)); }
  | NEXT_MONTH { var d1=new DateTime(Now.Year, Now.Month, 1); AddDateTimeIntervalCondition(d1.AddMonths(1), d1.AddMonths(2)); }
  
  | LAST_YEAR { var d1=new DateTime(Now.Year, 1, 1); AddDateTimeIntervalCondition(d1.AddYears(-1), d1); }
  | THIS_YEAR { var d1=new DateTime(Now.Year, 1, 1); AddDateTimeIntervalCondition(d1, d1.AddYears(1)); }
  | NEXT_YEAR { var d1=new DateTime(Now.Year, 1, 1); AddDateTimeIntervalCondition(d1.AddYears(1), d1.AddYears(2)); }
  
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

LAST_HOUR: 'l' 'a' 's' 't' '_' 'h' 'o' 'u' 'r';
THIS_HOUR: 't' 'h' 'i' 's' '_' 'h' 'o' 'u' 'r';
NEXT_HOUR: 'n' 'e' 'x' 't' '_' 'h' 'o' 'u' 'r';

YESTERDAY: 'y' 'e' 's' 't' 'e' 'r' 'd' 'y';
TODAY: 't' 'o' 'd' 'a' 'y';
TOMORROW: 't' 'o' 'm' 'o' 'r' 'r' 'o' 'w';

LAST_WEEK: 'l' 'a' 's' 't' '_' 'w' 'e' 'e' 'k';
THIS_WEEK: 't' 'h' 'i' 's' '_' 'w' 'e' 'e' 'k';
NEXT_WEEK: 'n' 'e' 'x' 't' '_' 'w' 'e' 'e' 'k';

LAST_MONTH: 'l' 'a' 's' 't' '_' 'm' 'o' 'n' 't' 'h';
THIS_MONTH: 't' 'h' 'i' 's' '_' 'm' 'o' 'n' 't' 'h';
NEXT_MONTH: 'n' 'e' 'x' 't' '_' 'm' 'o' 'n' 't' 'h';

LAST_YEAR: 'l' 'a' 's' 't' '_' 'y' 'e' 'a' 'r';
THIS_YEAR: 't' 'h' 'i' 's' '_' 'y' 'e' 'a' 'r';
NEXT_YEAR: 'n' 'e' 'x' 't' '_' 'y' 'e' 'a' 'r';
 
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

JAN: 'j' 'a' 'n';
FEB: 'f' 'e' 'b';
MAR: 'm' 'a' 'r';
APR: 'a' 'p' 'r';
MAY: 'm' 'a' 'y';
JUN: 'j' 'u' 'n';
JUL: 'j' 'u' 'l';
AUG: 'a' 'u' 'g';
SEP: 's' 'e' 'p';
OCT: 'o' 'c' 't';
NOV: 'n' 'o' 'v';
DEC: 'd' 'e' 'c';

MON: 'm' 'o' 'n';
TUE: 't' 'u' 'e';
WED: 'w' 'e' 'd';
THU: 't' 'h' 'u';
FRI: 'f' 'r' 'i';
SAT: 's' 'a' 't';
SUN: 's' 'u' 'n';
  
WHITESPACE : ( '\t' | ' ' | '\u000C' )+    { $channel = HIDDEN; } ;
ENDLINE: ( '\r' | '\n' )+;

 
fragment DIGIT  : '0'..'9' ;
