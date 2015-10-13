
CREATE TABLE dbo.Continent ( 
    ContinentName NVARCHAR(250) NOT NULL PRIMARY KEY
)
CREATE TABLE dbo.Country ( 
    CountryCode NVARCHAR(250) NOT NULL PRIMARY KEY,
    CountryName NVARCHAR(250),
    ContinentName NVARCHAR(250),
)
CREATE TABLE dbo.City ( 
	CityName NVARCHAR(250) NOT NULL PRIMARY KEY,
	CountryCode NVARCHAR(250),
	CityCitizens INT
)
CREATE TABLE dbo.CityPart ( 
	CityPartName NVARCHAR(250) NOT NULL PRIMARY KEY,
	CityName NVARCHAR(250)
)


INSERT INTO Continent (ContinentName) VALUES ('Europe');
INSERT INTO Continent (ContinentName) VALUES ('Asia');
INSERT INTO Continent (ContinentName) VALUES ('America');
INSERT INTO Continent (ContinentName) VALUES ('Australia');
INSERT INTO Continent (ContinentName) VALUES ('Antarctida');

INSERT INTO Country (CountryCode, CountryName, ContinentName) VALUES ('CZE', 'Czechia', 'Europe');
INSERT INTO Country (CountryCode, CountryName, ContinentName) VALUES ('SL', 'Slovakia', 'Europe');
INSERT INTO Country (CountryCode, CountryName, ContinentName) VALUES ('POL', 'Poland', 'Europe');
INSERT INTO Country (CountryCode, CountryName, ContinentName) VALUES ('GE', 'Germany', 'Europe');
INSERT INTO Country (CountryCode, CountryName, ContinentName) VALUES ('USA', 'United States', 'America');

INSERT INTO City (CityName, CountryCode, CityCitizens) VALUES ('Prague', 'CZE', 1200000);
INSERT INTO City (CityName, CountryCode, CityCitizens) VALUES ('Brno', 'CZE', 800000);
INSERT INTO City (CityName, CountryCode, CityCitizens) VALUES ('Ostrava', 'CZE', 500000);

INSERT INTO City (CityName, CountryCode, CityCitizens) VALUES ('Bratislava', 'SL', 800000);
INSERT INTO City (CityName, CountryCode, CityCitizens) VALUES ('Kosice', 'SL', 300000);

INSERT INTO City (CityName, CountryCode, CityCitizens) VALUES ('New York', 'USA', 20000000);
INSERT INTO City (CityName, CountryCode, CityCitizens) VALUES ('Washington', 'USA', 5000000);

INSERT INTO CityPart (CityPartName, CityName) VALUES ('Troja', 'Prague');
INSERT INTO CityPart (CityPartName, CityName) VALUES ('Hradcany', 'Prague');
INSERT INTO CityPart (CityPartName, CityName) VALUES ('Modrany', 'Prague');
INSERT INTO CityPart (CityPartName, CityName) VALUES ('Poruba', 'Ostrava');
INSERT INTO CityPart (CityPartName, CityName) VALUES ('Svinov', 'Ostrava');

INSERT INTO CityPart (CityPartName, CityName) VALUES ('Brooklyn', 'New York');
INSERT INTO CityPart (CityPartName, CityName) VALUES ('Long Island', 'New York');
INSERT INTO CityPart (CityPartName, CityName) VALUES ('Medford', 'New York');


CREATE TABLE TargetCityParts ( 
    ContinentName NVARCHAR(250),
	CityPartName NVARCHAR(250)
)

CREATE TABLE TargetContinents ( 
    ContinentName NVARCHAR(250)
)
