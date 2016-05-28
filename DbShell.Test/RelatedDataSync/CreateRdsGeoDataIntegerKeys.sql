
CREATE TABLE dbo.Continent ( 
	ContinentId INT NOT NULL PRIMARY KEY,
    ContinentName NVARCHAR(250) NOT NULL 
)
CREATE TABLE dbo.Country ( 
	CountryId INT NOT NULL PRIMARY KEY,
    CountryCode NVARCHAR(250) NOT NULL UNIQUE,
    CountryName NVARCHAR(250),
	ContinentId INT NOT NULL REFERENCES Continent(ContinentId)
)
CREATE TABLE dbo.City ( 
	CityId INT NOT NULL PRIMARY KEY,
	CityName NVARCHAR(250) NOT NULL,
	CountryId INT NOT NULL REFERENCES Country(CountryId),
	CityCitizens INT
)
CREATE TABLE dbo.CityPart ( 
	CityPartId INT NOT NULL IDeNTITY PRIMARY KEY,
	CityPartName NVARCHAR(250) NOT NULL,
	CityId INT NOT NULL REFERENCES City(CityId),
)


INSERT INTO Continent (ContinentId, ContinentName) VALUES (1,'Europe');
INSERT INTO Continent (ContinentId, ContinentName) VALUES (2,'Asia');
INSERT INTO Continent (ContinentId, ContinentName) VALUES (3,'America');
INSERT INTO Continent (ContinentId, ContinentName) VALUES (4,'Australia');
INSERT INTO Continent (ContinentId, ContinentName) VALUES (5,'Antarctida');

INSERT INTO Country (CountryId,CountryCode, CountryName, ContinentId) VALUES (1,'CZE', 'Czechia', 1);
INSERT INTO Country (CountryId,CountryCode, CountryName, ContinentId) VALUES (2,'SL', 'Slovakia', 1);
INSERT INTO Country (CountryId,CountryCode, CountryName, ContinentId) VALUES (3,'POL', 'Poland', 1);
INSERT INTO Country (CountryId,CountryCode, CountryName, ContinentId) VALUES (4,'GE', 'Germany', 1);
INSERT INTO Country (CountryId,CountryCode, CountryName, ContinentId) VALUES (5,'USA', 'United States', 2);

INSERT INTO City (CityId, CityName, CountryId, CityCitizens) VALUES (11, 'Prague', 1, 1200000);
INSERT INTO City (CityId, CityName, CountryId, CityCitizens) VALUES (12,'Brno', 1, 800000);
INSERT INTO City (CityId, CityName, CountryId, CityCitizens) VALUES (13,'Ostrava', 2, 500000);

INSERT INTO City (CityId, CityName, CountryId, CityCitizens) VALUES (21, 'Bratislava', 2, 800000);
INSERT INTO City (CityId, CityName, CountryId, CityCitizens) VALUES (22, 'Kosice', 3, 300000);

INSERT INTO City (CityId, CityName, CountryId, CityCitizens) VALUES (51,'New York', 5, 20000000);
INSERT INTO City (CityId, CityName, CountryId, CityCitizens) VALUES (52, 'Washington', 5, 5000000);

INSERT INTO CityPart (CityPartName, CityId) VALUES ('Troja', 11);
INSERT INTO CityPart (CityPartName, CityId) VALUES ('Hradcany', 11);
INSERT INTO CityPart (CityPartName, CityId) VALUES ('Modrany', 11);
INSERT INTO CityPart (CityPartName, CityId) VALUES ('Poruba', 13);
INSERT INTO CityPart (CityPartName, CityId) VALUES ('Svinov', 13);

INSERT INTO CityPart (CityPartName, CityId) VALUES ('Brooklyn', 51);
INSERT INTO CityPart (CityPartName, CityId) VALUES ('Long Island', 51);
INSERT INTO CityPart (CityPartName, CityId) VALUES ('Medford', 51);


CREATE TABLE TargetCityParts ( 
    ContinentName NVARCHAR(250),
	CityPartName NVARCHAR(250),
	CityPartIdOriginal INT,
	InfoData NVARCHAR(250),
	IsImported BIT
)

INSERT INTO TargetCityParts (CityPartName, CityPartIdOriginal, IsImported) VALUES ('Foo', 0, 0);

CREATE TABLE TargetContinents ( 
    ContinentName NVARCHAR(250),
	ContinentIdOriginal INT
)

CREATE TABLE TargetContinentNames ( 
    ContinentName NVARCHAR(250)
)

