select o.name, s.name as [schema], o.object_id, o.create_date, o.modify_date, o.type
from [SERVER].sys.objects o 
inner join [SERVER].sys.schemas s on o.schema_id = s.schema_id
where o.type in ('P', 'IF', 'FN', 'TF') and o.object_id =[OBJECT_ID_CONDITION]
