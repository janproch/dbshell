CREATE TABLE dbo.Source ( 
    SourceId INT IDENTITY NOT NULL, 
    Value NVARCHAR(160) NULL, 
	GroupName NVARCHAR(160) NULL, 
    CONSTRAINT PK_Source PRIMARY KEY (SourceId)
)
CREATE TABLE TargetItem (
	TargetItemId INT NOT NULL PRIMARY KEY IDENTITY,
	TargetIdOriginal NVARCHAR(100) NULL,
    Value NVARCHAR(160) NULL
)
CREATE TABLE TargetCategory (
	TargetCategoryId INT NOT NULL PRIMARY KEY,
	IsImported BIT NOT NULL
)
CREATE TABLE TargetGroup (
	TargetGroupId INT NOT NULL PRIMARY KEY IDENTITY,
	GroupName NVARCHAR(160) NULL, 
	TargetCategoryId INT NULL REFERENCES TargetCategory(TargetCategoryId)
)
CREATE TABLE TargetItemGroup (
	TargetItemId INT NOT NULL REFERENCES TargetItem(TargetItemId),
	TargetGroupId INT NOT NULL REFERENCES TargetGroup(TargetGroupId),
	PRIMARY KEY (TargetItemId, TargetGroupId)
)

INSERT INTO Source (Value, GroupName) VALUES ('val1', 'g1');
INSERT INTO Source (Value, GroupName) VALUES ('val2', 'g1');
INSERT INTO Source (Value, GroupName) VALUES ('val3', 'g2');

INSERT INTO TargetCategory VALUES (1, 1) -- imported 
INSERT INTO TargetCategory VALUES (2, 0) -- not imported
