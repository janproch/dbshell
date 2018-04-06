CREATE TABLE dbo.Source ( 
    SourceId INT IDENTITY NOT NULL, 
    Value NVARCHAR(160) NULL, 
    CONSTRAINT PK_Source PRIMARY KEY (SourceId)
)
CREATE TABLE TargetRef (
	TargetRefId INT NOT NULL PRIMARY KEY,
	SystemName VARCHAR(100) NOT NULL
)
CREATE TABLE dbo.Target ( 
    TargetId INT IDENTITY NOT NULL, 
	TargetIdOriginal NVARCHAR(100) NULL,
    Value NVARCHAR(160) NULL, 
	ParamId INT NULL,
	TargetRefId INT NOT NULL REFERENCES TargetRef(TargetRefId),
    CONSTRAINT PK_Target PRIMARY KEY (TargetId)
)

INSERT INTO Source (Value) VALUES ('val1');
INSERT INTO Source (Value) VALUES ('val2');
INSERT INTO Source (Value) VALUES ('val3');
INSERT INTO Source (Value) VALUES ('val4');

INSERT INTO TargetRef VALUES (1, 'SysRef')