CREATE TABLE dbo.Source ( 
    MasterId INT NOT NULL,
    DetailId INT NOT NULL PRIMARY KEY
)
CREATE TABLE TargetMaster (
	TargetMasterId INT IDENTITY NOT NULL PRIMARY KEY,
	MasterIdOriginal INT NULL
)
CREATE TABLE TargetDetail (
	TargetDetailId INT IDENTITY NOT NULL PRIMARY KEY,
	TargetMasterId INT NOT NULL REFERENCES TargetMaster(TargetMasterId),
	DetailIdOriginal INT NULL
)

INSERT INTO Source (MasterId, DetailId) VALUES (1, 1);
INSERT INTO Source (MasterId, DetailId) VALUES (1, 2);
INSERT INTO Source (MasterId, DetailId) VALUES (2, 3);
INSERT INTO Source (MasterId, DetailId) VALUES (2, 4);
