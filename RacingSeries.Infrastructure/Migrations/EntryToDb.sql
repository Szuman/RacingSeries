DELETE FROM Contests
DELETE FROM Drivers
DELETE FROM Sponsors
DELETE FROM Tracks
DELETE FROM Teams

INSERT INTO Drivers (FirstName, LastName, Country, BirthDate) VALUES ('Max', 'Supermax', 'NL', CONVERT(datetime, '19971024', 112))
INSERT INTO Contests (Name, DateTime) VALUES ('Aus GP', CONVERT(datetime, '20220303', 112))
INSERT INTO Sponsors (Name, Description) VALUES ('Orlen', 'Polish Hot Dog Industry')
INSERT INTO Teams (Name, Country, EntryDate) VALUES ('RedBull Racing Honda', 'AUS', CONVERT(datetime, '20060211', 112))
INSERT INTO Tracks (Name, Country) VALUES ('RedBull Ring', 'AUS')
