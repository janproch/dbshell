CREATE TABLE dbo.Master ( 
    MasterId INT IDENTITY NOT NULL PRIMARY KEY, 
	MasterIdOriginal INT NULL,
	MasterIsCopy BIT NULL,
    MasterValue NVARCHAR(160) NULL
)
CREATE TABLE dbo.Detail ( 
    DetailId INT IDENTITY NOT NULL  PRIMARY KEY, 
	MasterId INT NOT NULL REFERENCES Master(MasterId),
	DetailIdOriginal INT NULL,
	DetailIsCopy BIT NULL,
    DetailValue NVARCHAR(160) NULL
)

SET IDENTITY_INSERT Master ON
INSERT INTO Master (MasterId, MasterIsCopy, MasterValue) VALUES (1, 0, 'master1');
INSERT INTO Master (MasterId, MasterIsCopy, MasterValue) VALUES (2, 0, 'master1');
SET IDENTITY_INSERT Master OFF

INSERT INTO Detail (MasterId, DetailIsCopy, DetailValue) VALUES (1, 0, 'master1_detail1');
INSERT INTO Detail (MasterId, DetailIsCopy, DetailValue) VALUES (1, 0, 'master1_detail2');
INSERT INTO Detail (MasterId, DetailIsCopy, DetailValue) VALUES (2, 0, 'master2_detail1');
INSERT INTO Detail (MasterId, DetailIsCopy, DetailValue) VALUES (2, 0, 'master2_detail2');
