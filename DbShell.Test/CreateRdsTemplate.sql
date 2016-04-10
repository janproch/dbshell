CREATE TABLE dbo.Source ( 
    SourceId INT NOT NULL PRIMARY KEY, 
    Value1 INT NULL, 
    Value2 INT NULL
)
CREATE TABLE dbo.Target ( 
    TargetId INT IDENTITY NOT NULL PRIMARY KEY, 
	TargetIdOriginal NVARCHAR(100) NULL,
    Value NVARCHAR(160) NULL
)

INSERT INTO Source (SourceId, Value1, Value2) VALUES (1, 1, 2);
INSERT INTO Source (SourceId, Value1, Value2) VALUES (2, 1, NULL);
INSERT INTO Source (SourceId, Value1, Value2) VALUES (3, NULL, 2);
