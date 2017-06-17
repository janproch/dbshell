SELECT     
	db.name as DatabaseName,     
	mfrows.RowSize * 8 as RowSizeKB,     
	mflog.LogSize * 8 as LogSizeKB,
	db.collation_name as Collation,
	db.recovery_model_desc as RecoveryModel,
	db.snapshot_isolation_state as SnapshotIsolation,
	db.is_read_committed_snapshot_on as IsReadCommitedSnapshot
FROM [SERVER].sys.databases db     
LEFT JOIN (SELECT database_id, 
                  SUM(size) RowSize 
            FROM [SERVER].sys.master_files 
            WHERE type = 0 
            GROUP BY database_id, type) mfrows 
    ON mfrows.database_id = db.database_id     
LEFT JOIN (SELECT database_id, 
                  SUM(size) LogSize 
            FROM [SERVER].sys.master_files 
            WHERE type = 1 
            GROUP BY database_id, type) mflog 
    ON mflog.database_id = db.database_id     
order by db.name
