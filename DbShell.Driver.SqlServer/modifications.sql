select o.object_id, o.modify_date, o.type, o.name, s.name as [schema]
from sys.objects o 
inner join sys.schemas s on o.schema_id = s.schema_id
where o.type in ('U', 'V', 'P', 'IF', 'FN', 'TR')
