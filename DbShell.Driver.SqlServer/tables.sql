select
	o.name as TableName, s.name as SchemaName, o.object_id, 
	o.create_date, o.modify_date 
from [SERVER].sys.tables o
inner join [SERVER].sys.schemas s on o.schema_id = s.schema_id
where o.object_id =[OBJECT_ID_CONDITION]
