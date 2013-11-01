select o.name, s.name as [schema], o.object_id, o.create_date, o.modify_date, o.type
from sys.objects o 
inner join sys.schemas s on o.schema_id = s.schema_id
where o.type in ('P', 'IF', 'FN') and o.object_id =[OBJECT_ID_CONDITION]
