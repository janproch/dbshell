﻿CREATE TABLE dbo.Album ( 
    AlbumId INT IDENTITY NOT NULL, 
    Title NVARCHAR(160) NOT NULL, 
    ArtistId INT NOT NULL, 
    CONSTRAINT PK_Album PRIMARY KEY (AlbumId)
)
CREATE TABLE dbo.AlbumCopy ( 
    AlbumId INT IDENTITY NOT NULL, 
    Title NVARCHAR(160) NOT NULL, 
    ArtistId INT NOT NULL, 
    CONSTRAINT PK_AlbumCopy PRIMARY KEY (AlbumId)
)

SET IDENTITY_INSERT Album ON
INSERT INTO [Album] ([AlbumId], [Title], [ArtistId]) VALUES (1, 'For Those About To Rock We Salute You', 1);
INSERT INTO [Album] ([AlbumId], [Title], [ArtistId]) VALUES (2, 'Balls to the Wall', 3);
INSERT INTO [Album] ([AlbumId], [Title], [ArtistId]) VALUES (3, 'Restless and Wild', 2);
INSERT INTO [Album] ([AlbumId], [Title], [ArtistId]) VALUES (4, 'Let There Be Rock', 1);
INSERT INTO [Album] ([AlbumId], [Title], [ArtistId]) VALUES (5, 'Big Ones', 3);
INSERT INTO [Album] ([AlbumId], [Title], [ArtistId]) VALUES (6, 'Jagged Little Pill', 4);
INSERT INTO [Album] ([AlbumId], [Title], [ArtistId]) VALUES (7, 'Facelift', 5);
INSERT INTO [Album] ([AlbumId], [Title], [ArtistId]) VALUES (8, 'Warner 25 Anos', 6);
INSERT INTO [Album] ([AlbumId], [Title], [ArtistId]) VALUES (9, 'Plays Metallica By Four Cellos', 7);
INSERT INTO [Album] ([AlbumId], [Title], [ArtistId]) VALUES (10, 'Audioslave', 8);
SET IDENTITY_INSERT Album OFF


CREATE TABLE Genre ( 
    GenreId INT NOT NULL, 
    Name NVARCHAR(120) NULL, 
    CONSTRAINT PK_Genre PRIMARY KEY (GenreId)
)


INSERT INTO [Genre] ([GenreId], [Name]) VALUES (1, 'Rock');
INSERT INTO [Genre] ([GenreId], [Name]) VALUES (2, 'Jazz');
INSERT INTO [Genre] ([GenreId], [Name]) VALUES (3, 'Metal');
INSERT INTO [Genre] ([GenreId], [Name]) VALUES (4, 'Alternative & Punk');
INSERT INTO [Genre] ([GenreId], [Name]) VALUES (5, 'Rock And Roll');
INSERT INTO [Genre] ([GenreId], [Name]) VALUES (6, 'Blues');
INSERT INTO [Genre] ([GenreId], [Name]) VALUES (7, 'Latin');
INSERT INTO [Genre] ([GenreId], [Name]) VALUES (8, 'Reggae');
INSERT INTO [Genre] ([GenreId], [Name]) VALUES (9, 'Pop');
INSERT INTO [Genre] ([GenreId], [Name]) VALUES (10, 'Soundtrack');
INSERT INTO [Genre] ([GenreId], [Name]) VALUES (11, 'Bossa Nova');
INSERT INTO [Genre] ([GenreId], [Name]) VALUES (12, 'Easy Listening');
INSERT INTO [Genre] ([GenreId], [Name]) VALUES (13, 'Heavy Metal');
INSERT INTO [Genre] ([GenreId], [Name]) VALUES (14, 'R&B/Soul');
INSERT INTO [Genre] ([GenreId], [Name]) VALUES (15, 'Electronica/Dance');
INSERT INTO [Genre] ([GenreId], [Name]) VALUES (16, 'World');
INSERT INTO [Genre] ([GenreId], [Name]) VALUES (17, 'Hip Hop/Rap');
INSERT INTO [Genre] ([GenreId], [Name]) VALUES (18, 'Science Fiction');
INSERT INTO [Genre] ([GenreId], [Name]) VALUES (19, 'TV Shows');
INSERT INTO [Genre] ([GenreId], [Name]) VALUES (20, 'Sci Fi & Fantasy');
INSERT INTO [Genre] ([GenreId], [Name]) VALUES (21, 'Drama');
INSERT INTO [Genre] ([GenreId], [Name]) VALUES (22, 'Comedy');
INSERT INTO [Genre] ([GenreId], [Name]) VALUES (23, 'Alternative');
INSERT INTO [Genre] ([GenreId], [Name]) VALUES (24, 'Classical');
INSERT INTO [Genre] ([GenreId], [Name]) VALUES (25, 'Opera');
INSERT INTO [Genre] ([GenreId], [Name]) VALUES (30, 'TestGenre');
INSERT INTO [Genre] ([GenreId], [Name]) VALUES (31, 'test');
INSERT INTO [Genre] ([GenreId], [Name]) VALUES (32, 'test');
INSERT INTO [Genre] ([GenreId], [Name]) VALUES (35, 'test');
INSERT INTO [Genre] ([GenreId], [Name]) VALUES (101, 'Rock And Roll');
INSERT INTO [Genre] ([GenreId], [Name]) VALUES (102, 'Blues');

CREATE TABLE ImportedData ( 
    ID_IMPORTED INT IDENTITY NOT NULL, 
	Data1 NVARCHAR(250) NULL,
	Data2 NVARCHAR(250) NULL,
	Data3 NVARCHAR(250) NULL
    CONSTRAINT PK_ImportedData PRIMARY KEY (ID_IMPORTED)
)