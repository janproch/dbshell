select s.name as [schema],  t.name, t.object_id, t.parent_id, t.create_date, t.modify_date from [SERVER].sys.triggers t
inner join [SERVER].sys.objects o on o.object_id = t.object_id
inner join [SERVER].sys.schemas s on o.schema_id = s.schema_id
where t.object_id =[OBJECT_ID_CONDITION]
