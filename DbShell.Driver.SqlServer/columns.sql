select c.name as column_name, t.name as type_name, c.object_id, c.is_identity,
	c.max_length, c.precision, c.scale, c.is_nullable,
	d.definition as default_value, d.name as default_constraint,
	m.definition as computed_expression, m.is_persisted
from sys.columns c
inner join sys.types t on c.system_type_id = t.system_type_id and c.user_type_id = t.user_type_id
inner join sys.objects o on c.object_id = o.object_id
left join sys.default_constraints d on c.default_object_id = d.object_id
left join sys.computed_columns m on m.object_id = c.object_id and m.column_id = c.column_id
where o.type = 'U' and o.object_id =[OBJECT_ID_CONDITION]
order by c.column_id