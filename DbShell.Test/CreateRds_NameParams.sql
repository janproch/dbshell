CREATE TABLE dbo.SourceTemplate ( 
    SourceId INT IDENTITY NOT NULL, 
    Value NVARCHAR(160) NULL, 
    CONSTRAINT PK_SourceTemplate PRIMARY KEY (SourceId)
)
CREATE TABLE dbo.SourceData ( 
    SourceId INT IDENTITY NOT NULL, 
    Value NVARCHAR(160) NULL, 
    CONSTRAINT PK_SourceData PRIMARY KEY (SourceId)
)

CREATE TABLE dbo.TargetTemplate ( 
    TargetId INT IDENTITY NOT NULL, 
	TargetIdOriginal NVARCHAR(100) NULL,
    Value NVARCHAR(160) NULL, 
	ParamId INT NULL,
    CONSTRAINT PK_TargetTemplate PRIMARY KEY (TargetId)
)

CREATE TABLE dbo.TargetData ( 
    TargetId INT IDENTITY NOT NULL, 
	TargetIdOriginal NVARCHAR(100) NULL,
    Value NVARCHAR(160) NULL, 
	ParamId INT NULL,
    CONSTRAINT PK_TargetData PRIMARY KEY (TargetId)
)

INSERT INTO SourceData (Value) VALUES ('val1');
INSERT INTO SourceData (Value) VALUES ('val2');
INSERT INTO SourceData (Value) VALUES ('val3');
INSERT INTO SourceData (Value) VALUES ('val4');
