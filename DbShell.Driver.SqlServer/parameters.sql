SELECT o.object_id, SPECIFIC_SCHEMA, SPECIFIC_NAME, PARAMETER_MODE, IS_RESULT, PARAMETER_NAME, DATA_TYPE 
FROM [SERVER].INFORMATION_SCHEMA.PARAMETERS p 
inner join [SERVER].sys.objects o on p.SPECIFIC_NAME = o.name
inner join [SERVER].sys.schemas s on p.SPECIFIC_SCHEMA = s.name and s.schema_id = o.schema_id
where o.object_id =[OBJECT_ID_CONDITION]
ORDER BY ORDINAL_POSITION
