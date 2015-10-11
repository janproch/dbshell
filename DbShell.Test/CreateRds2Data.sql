

CREATE TABLE dbo.SourceMaster ( 
    Id INT NOT NULL, 
    Value NVARCHAR(160) NULL, 
    CONSTRAINT PK_SourceMaster PRIMARY KEY (Id)
)
CREATE TABLE dbo.SourceDetail ( 
    Id INT IDENTITY NOT NULL, 
    MasterId INT NOT NULL REFERENCES SourceMaster(Id), 
    Value NVARCHAR(160) NULL, 
    CONSTRAINT PK_SourceDetail PRIMARY KEY (Id)
)


CREATE TABLE dbo.Target ( 
    TargetId INT IDENTITY NOT NULL, 
	TargetIdOriginalMaster NVARCHAR(100) NULL,
	TargetIdOriginalDetail NVARCHAR(100) NULL,
    MasterValue NVARCHAR(160) NULL, 
    DetailValue NVARCHAR(160) NULL, 
    CONSTRAINT PK_Target PRIMARY KEY (TargetId)
)

INSERT INTO SourceMaster (Id, Value) VALUES (1, 'master1');
INSERT INTO SourceMaster (Id, Value) VALUES (2, 'master2');
INSERT INTO SourceMaster (Id, Value) VALUES (3, 'master3');
INSERT INTO SourceMaster (Id, Value) VALUES (4, 'master4');

INSERT INTO SourceDetail (MasterId, Value) VALUES (1, 'detail_1_1');
INSERT INTO SourceDetail (MasterId, Value) VALUES (1, 'detail_1_2');
INSERT INTO SourceDetail (MasterId, Value) VALUES (1, 'detail_1_3');
INSERT INTO SourceDetail (MasterId, Value) VALUES (2, 'detail_2_1');
INSERT INTO SourceDetail (MasterId, Value) VALUES (3, 'detail_3_1');
