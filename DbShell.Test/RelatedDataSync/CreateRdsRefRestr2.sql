CREATE TABLE dbo.Source ( 
    SourceId INT IDENTITY NOT NULL, 
    Value NVARCHAR(160) NULL, 
	IsInGroup BIT NULL, 
    CONSTRAINT PK_Source PRIMARY KEY (SourceId)
)
CREATE TABLE TargetItem (
	TargetItemId INT NOT NULL PRIMARY KEY IDENTITY,
	TargetIdOriginal NVARCHAR(100) NULL,
    Value NVARCHAR(160) NULL
)
CREATE TABLE TargetGroup (
	TargetGroupId INT NOT NULL PRIMARY KEY,
	IsImported BIT NOT NULL
)
CREATE TABLE TargetItemGroup (
	TargetItemId INT NOT NULL REFERENCES TargetItem(TargetItemId),
	TargetGroupId INT NOT NULL REFERENCES TargetGroup(TargetGroupId),
	PRIMARY KEY (TargetItemId, TargetGroupId)
)

INSERT INTO Source (Value, IsInGroup) VALUES ('val1', 1);
INSERT INTO Source (Value, IsInGroup) VALUES ('val2', 1);
INSERT INTO Source (Value, IsInGroup) VALUES ('val3', 0);

INSERT INTO TargetGroup VALUES (1, 1) -- imported 
INSERT INTO TargetGroup VALUES (2, 0) -- not imported
