CREATE TABLE "Artist" ( 
    "ArtistId" SERIAL, 
    "Name" VARCHAR(120) NULL,
    CONSTRAINT PK_Artist PRIMARY KEY ("ArtistId")
);

CREATE TABLE "Album" ( 
    "AlbumId" SERIAL, 
    "Title" VARCHAR(160) NOT NULL, 
    "ArtistId" INT NOT NULL,
    CONSTRAINT PK_Album PRIMARY KEY ("AlbumId"),
    CONSTRAINT FK_AlbumArtistId FOREIGN KEY ("ArtistId") REFERENCES "Artist"("ArtistId") ON DELETE NO ACTION ON UPDATE NO ACTION
);
CREATE TABLE "AlbumCopy" ( 
    "AlbumId" SERIAL, 
    "Title" VARCHAR(160) NOT NULL, 
    "ArtistId" INT NOT NULL,
    CONSTRAINT PK_AlbumCopy PRIMARY KEY ("AlbumId")
);

CREATE TABLE "Genre" ( 
    "GenreId" INT NOT NULL, 
    "Name" VARCHAR(120) NULL, 
    CONSTRAINT PK_Genre PRIMARY KEY ("GenreId")
);

CREATE TABLE "ImportedData" ( 
    "ID_IMPORTED" SERIAL, 
	"Data1" VARCHAR(250) NULL,
	"Data2" VARCHAR(250) NULL,
	"Data3" VARCHAR(250) NULL,
    CONSTRAINT PK_ImportedData PRIMARY KEY ("ID_IMPORTED")
);

INSERT INTO "Artist" ("ArtistId", "Name") VALUES (1, 'AC/DC');
INSERT INTO "Artist" ("ArtistId", "Name") VALUES (2, 'TEST1');
INSERT INTO "Artist" ("ArtistId", "Name") VALUES (3, 'Aerosmith');
INSERT INTO "Artist" ("ArtistId", "Name") VALUES (4, 'Alanis Morissette');
INSERT INTO "Artist" ("ArtistId", "Name") VALUES (5, 'Alice In Chains');
INSERT INTO "Artist" ("ArtistId", "Name") VALUES (6, 'Antônio Carlos Jobim');
INSERT INTO "Artist" ("ArtistId", "Name") VALUES (7, 'Apocalyptica');
INSERT INTO "Artist" ("ArtistId", "Name") VALUES (8, 'Audioslave');
INSERT INTO "Artist" ("ArtistId", "Name") VALUES (9, 'BackBeat');
INSERT INTO "Artist" ("ArtistId", "Name") VALUES (10, 'Billy Cobham');


INSERT INTO "Album" ("AlbumId", "Title", "ArtistId") VALUES (1, 'For Those About To Rock We Salute You', 1);
INSERT INTO "Album" ("AlbumId", "Title", "ArtistId") VALUES (2, 'Balls to the Wall', 3);
INSERT INTO "Album" ("AlbumId", "Title", "ArtistId") VALUES (3, 'Restless and Wild', 2);
INSERT INTO "Album" ("AlbumId", "Title", "ArtistId") VALUES (4, 'Let There Be Rock', 1);
INSERT INTO "Album" ("AlbumId", "Title", "ArtistId") VALUES (5, 'Big Ones', 3);
INSERT INTO "Album" ("AlbumId", "Title", "ArtistId") VALUES (6, 'Jagged Little Pill', 4);
INSERT INTO "Album" ("AlbumId", "Title", "ArtistId") VALUES (7, 'Facelift', 5);
INSERT INTO "Album" ("AlbumId", "Title", "ArtistId") VALUES (8, 'Warner 25 Anos', 6);
INSERT INTO "Album" ("AlbumId", "Title", "ArtistId") VALUES (9, 'Plays Metallica By Four Cellos', 7);
INSERT INTO "Album" ("AlbumId", "Title", "ArtistId") VALUES (10, 'Audioslave', 8);


INSERT INTO "Genre" ("GenreId", "Name") VALUES (1, 'Rock');
INSERT INTO "Genre" ("GenreId", "Name") VALUES (2, 'Jazz');
INSERT INTO "Genre" ("GenreId", "Name") VALUES (3, 'Metal');
INSERT INTO "Genre" ("GenreId", "Name") VALUES (4, 'Alternative & Punk');
INSERT INTO "Genre" ("GenreId", "Name") VALUES (5, 'Rock And Roll');
INSERT INTO "Genre" ("GenreId", "Name") VALUES (6, 'Blues');
INSERT INTO "Genre" ("GenreId", "Name") VALUES (7, 'Latin');
INSERT INTO "Genre" ("GenreId", "Name") VALUES (8, 'Reggae');
INSERT INTO "Genre" ("GenreId", "Name") VALUES (9, 'Pop');
INSERT INTO "Genre" ("GenreId", "Name") VALUES (10, 'Soundtrack');
INSERT INTO "Genre" ("GenreId", "Name") VALUES (11, 'Bossa Nova');
INSERT INTO "Genre" ("GenreId", "Name") VALUES (12, 'Easy Listening');
INSERT INTO "Genre" ("GenreId", "Name") VALUES (13, 'Heavy Metal');
INSERT INTO "Genre" ("GenreId", "Name") VALUES (14, 'R&B/Soul');
INSERT INTO "Genre" ("GenreId", "Name") VALUES (15, 'Electronica/Dance');
INSERT INTO "Genre" ("GenreId", "Name") VALUES (16, 'World');
INSERT INTO "Genre" ("GenreId", "Name") VALUES (17, 'Hip Hop/Rap');
INSERT INTO "Genre" ("GenreId", "Name") VALUES (18, 'Science Fiction');
INSERT INTO "Genre" ("GenreId", "Name") VALUES (19, 'TV Shows');
INSERT INTO "Genre" ("GenreId", "Name") VALUES (20, 'Sci Fi & Fantasy');
INSERT INTO "Genre" ("GenreId", "Name") VALUES (21, 'Drama');
INSERT INTO "Genre" ("GenreId", "Name") VALUES (22, 'Comedy');
INSERT INTO "Genre" ("GenreId", "Name") VALUES (23, 'Alternative');
INSERT INTO "Genre" ("GenreId", "Name") VALUES (24, 'Classical');
INSERT INTO "Genre" ("GenreId", "Name") VALUES (25, 'Opera');

