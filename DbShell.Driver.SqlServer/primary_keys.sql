SELECT o.object_id, Tablename = t.Table_Name, SchemaName = t.Table_Schema, ColumnName = c.Column_Name, ConstraintName=t.constraint_name from 
    [SERVER].INFORMATION_SCHEMA.TABLE_CONSTRAINTS t,
    [SERVER].sys.objects o,
    [SERVER].sys.schemas s,
    [SERVER].INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE c
WHERE 
    c.Constraint_Name = t.Constraint_Name
    and t.table_name = o.name 
    and o.schema_id = s.schema_id and t.Table_Schema = s.name
    AND c.Table_Name = t.Table_Name
    AND Constraint_Type = 'PRIMARY KEY'
	and o.object_id =[OBJECT_ID_CONDITION]
