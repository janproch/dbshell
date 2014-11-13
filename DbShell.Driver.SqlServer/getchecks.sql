select c.parent_object_id as object_id, c.name, c.definition from [SERVER].sys.check_constraints c

where c.parent_object_id =[OBJECT_ID_CONDITION]

