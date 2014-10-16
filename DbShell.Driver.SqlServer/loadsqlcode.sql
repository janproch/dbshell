select s.name as OBJ_NAME, u.name as OBJ_SCHEMA, c.text AS CODE_TEXT
    from sys.objects s
    inner join sys.syscomments c on s.object_id = c.id
    inner join sys.schemas u on u.schema_id = s.schema_id
where (s.object_id =[OBJECT_ID_CONDITION]) AND (#TYPECOND#)
order by u.name, s.name, c.colid
