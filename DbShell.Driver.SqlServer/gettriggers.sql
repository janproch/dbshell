select s.name as [schema],  t.name, t.object_id, t.parent_id, t.create_date, t.modify_date from sys.triggers t
inner join sys.objects o on o.object_id = t.object_id
inner join sys.schemas s on o.schema_id = s.schema_id
where t.object_id =[OBJECT_ID_CONDITION]
