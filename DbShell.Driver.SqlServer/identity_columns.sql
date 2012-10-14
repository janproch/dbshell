select c.name as ColumnName, o.name as TableName, s.name as SchemaName
from sys.identity_columns c
inner join sys.objects o on c.object_id = o.object_id
inner join sys.schemas s on o.schema_id = s.schema_id
where o.type = 'U'