CREATE TABLE Source2 ( 
    ID INT NOT NULL, 
    Value1 INT NULL, 
    CONSTRAINT PK_Source2 PRIMARY KEY (ID)
);
CREATE TABLE Target2 ( 
    ID INT IDENTITY NOT NULL, 
    IdOriginal INT NULL, 
    Value1 INT NULL, 
    IsImported BIT NULL, 
    CONSTRAINT PK_Target2 PRIMARY KEY (ID)
);
INSERT INTO [dbo].[Source2] ([ID], [Value1]) VALUES (-1, 1);
INSERT INTO [dbo].[Source2] ([ID], [Value1]) VALUES (2, 2);

INSERT INTO [dbo].[Target2] ([IdOriginal], [Value1], [IsImported]) VALUES (1, 101, 0);