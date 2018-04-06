CREATE TABLE Source ( 
    ID INT NOT NULL, 
    Value1 INT NULL, 
    CONSTRAINT PK_Source PRIMARY KEY (ID)
);

CREATE TABLE Target ( 
    ID INT IDENTITY NOT NULL, 
    IdOriginal INT NULL, 
    Value1 INT NULL, 
    ValidFrom DATETIME NOT NULL, 
    ValidTo DATETIME NULL, 
    CONSTRAINT PK_Target PRIMARY KEY (ID)
);

INSERT INTO [dbo].[Source] ([ID], [Value1]) VALUES (1, 1);
INSERT INTO [dbo].[Source] ([ID], [Value1]) VALUES (2, 2);
INSERT INTO [dbo].[Target] ([Value1], ValidFrom, ValidTo) VALUES (100, '2000-01-01T00:00:00', '2000-01-01T00:00:00');
