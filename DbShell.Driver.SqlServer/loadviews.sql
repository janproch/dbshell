SELECT 
	o.name as [Name], 
	u.name as [Schema],
	o.object_id,
	o.create_date,
	o.modify_date
FROM [SERVER].sys.objects o INNER JOIN [SERVER].sys.schemas u ON u.schema_id=o.schema_id 
WHERE type in ('V') and o.object_id =[OBJECT_ID_CONDITION]