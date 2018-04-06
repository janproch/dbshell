CREATE TABLE SourceType ( 
    ID_SourceType INT NOT NULL, 
	ShouldBeExported BIT NOT NULL,
    CONSTRAINT PK_SourceType PRIMARY KEY (ID_SourceType)
);
CREATE TABLE SourceNotLinked ( 
    ID_SourceNotLinked INT NOT NULL
);
CREATE TABLE Source ( 
    ID_Source INT NOT NULL, 
	ID_SourceType INT NOT NULL,
    Value1 INT NULL, 
    CONSTRAINT PK_Source PRIMARY KEY (ID_Source)
);

CREATE TABLE Target ( 
    ID INT IDENTITY NOT NULL, 
    IdOriginal INT NULL, 
    Value1 INT NULL, 
    CONSTRAINT PK_Target PRIMARY KEY (ID)
);

INSERT INTO SourceType (ID_SourceType, ShouldBeExported) VALUES (1, 0); 
INSERT INTO SourceType (ID_SourceType, ShouldBeExported) VALUES (2, 1); 

INSERT INTO SourceNotLinked (ID_SourceNotLinked) VALUES (1); 
INSERT INTO SourceNotLinked (ID_SourceNotLinked) VALUES (2); 

INSERT INTO [dbo].[Source] (ID_Source, ID_SourceType, Value1) VALUES (1, 1, 1);
INSERT INTO [dbo].[Source] (ID_Source, ID_SourceType, Value1) VALUES (2, 1, 2);
INSERT INTO [dbo].[Source] (ID_Source, ID_SourceType, Value1) VALUES (3, 2, 3);
INSERT INTO [dbo].[Source] (ID_Source, ID_SourceType, Value1) VALUES (4, 2, 4);
