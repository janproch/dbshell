

CREATE TABLE dbo.Source ( 
    Id INT NOT NULL, 
    A NVARCHAR(160) NULL, 
    B NVARCHAR(160) NULL, 
    C NVARCHAR(160) NULL, 
    CONSTRAINT PK_SourceMaster PRIMARY KEY (Id)
)


CREATE TABLE dbo.Target ( 
    Id INT IDENTITY NOT NULL, 
	IdOriginal NVARCHAR(100) NULL,
    A NVARCHAR(160) NULL, 
    B NVARCHAR(160) NULL, 
    C NVARCHAR(160) NULL, 
    DeletedDate DATETIME NULL, 
	ImportGroup NVARCHAR(160),
    ValidFrom DATETIME NULL, 
    ValidTo DATETIME NULL, 
    CONSTRAINT PK_Target PRIMARY KEY (Id)
)

INSERT INTO Source VALUES (1, '1a', '1b', '1c');
INSERT INTO Source VALUES (2, '2a', '2b', '2c');
INSERT INTO Source VALUES (3, '3a', '3b', '3c');
INSERT INTO Source VALUES (4, '4a', '4b', '4c');
