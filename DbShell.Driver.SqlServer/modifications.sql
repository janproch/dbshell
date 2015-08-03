select o.object_id, o.modify_date, o.type, o.name, s.name as [schema]
from [SERVER].sys.objects o 
inner join [SERVER].sys.schemas s on o.schema_id = s.schema_id
where o.type in ('U', 'V', 'P', 'IF', 'FN', 'TR', 'TF')
