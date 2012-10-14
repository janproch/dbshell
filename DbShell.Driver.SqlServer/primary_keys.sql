SELECT Tablename = t.Table_Name, SchemaName = t.Table_Schema, ColumnName = c.Column_Name from 
    INFORMATION_SCHEMA.TABLE_CONSTRAINTS t, 
    INFORMATION_SCHEMA.CONSTRAINT_COLUMN_USAGE c
WHERE 
    c.Constraint_Name = t.Constraint_Name
    AND c.Table_Name = t.Table_Name
    AND Constraint_Type = 'PRIMARY KEY'
