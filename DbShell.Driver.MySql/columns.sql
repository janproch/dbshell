select 
	TABLE_NAME, 
	COLUMN_NAME,
	IS_NULLABLE,
	DATA_TYPE,
	CHARACTER_MAXIMUM_LENGTH,
	NUMERIC_PRECISION,
	NUMERIC_SCALE,
	COLUMN_DEFAULT
from INFORMATION_SCHEMA.COLUMNS
where TABLE_SCHEMA = '#DATABASE#' and TABLE_NAME =[OBJECT_NAME_CONDITION]
order by ORDINAL_POSITION
