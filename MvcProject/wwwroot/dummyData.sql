--NOGNI AF
-- Dummy data for Gebruiker table
INSERT INTO Gebruiker (Id, Naam, Voornaam, Initialen, Gebruikersnaam, Wachtwoord, Email, Verwijderd, UserName, NormalizedUserName, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount)
VALUES
    ('UserID1', 'Doe','John', 'J', 'john_doe', 'password123', 'john@example.com', 0, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, 0, 0, NULL, 0, 0),
    ('UserID2', 'Doe','Alice', 'A', 'alice_smith', 'password456', 'alice@example.com', 0, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, 0, 0, NULL, 0, 0),
    ('UserID3', 'Doe','David', 'D', 'david_smith', 'password789', 'david@example.com', 0, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, 0, 0, NULL, 0, 0),
    ('UserID4', 'Doe','Emma', 'E', 'emma_jones', 'passwordabc', 'emma@example.com', 0, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, 0, 0, NULL, 0, 0),
    ('UserID5', 'Doe','Michael', 'M', 'michael_brown', 'passworddef', 'michael@example.com', 0, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, 0, 0, NULL, 0, 0),
    ('UserID6', 'Doe','Sophia', 'S', 'sophia_davis', 'passwordegf', 'sophia@example.com', 0, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, 0, 0, NULL, 0, 0),
    ('UserID7', 'Doe','James', 'J', 'james_wilson', 'passwordhij', 'james@example.com', 0, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, 0, 0, NULL, 0, 0),
    ('UserID8', 'Doe','Olivia', 'O', 'olivia_johnson', 'passwordklm', 'olivia@example.com', 0, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, 0, 0, NULL, 0, 0),
    ('UserID9', 'Doe','William', 'W', 'william_miller', 'passwordnop', 'william@example.com', 0, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, 0, 0, NULL, 0,0);
-- Dummy data for Studiebezoek table
INSERT INTO Studiebezoek (StudiebezoekId, GebruikerId, VakId, Datum, StartUur, EindUur, Reden, AantalStudenten, KostprijsStudiebezoek,
    VervoerBus, VervoerTram, VervoerTrein, VervoerTeVoet, VervoerAuto, VervoerFiets, KostprijsVervoer,
    AfwezigeStudenten, Opmerkingen, isGoedgekeurdCo, isGoedgekeurdDir, isAfgewezen, opmerkingAfgewezen, isAfgewerkt)
VALUES
    (1, 'UserID1', 1, '2023-01-15', '09:00:00', '12:00:00', 'Reason 1', 25, 150.25, 1, 0, 1, 0, 1, 0, 75.50, 'Student1, Student2', 'Comments 1', 1, 1, 0, '', 1),
    (2, 'UserID2', 2, '2023-02-20', '10:30:00', '14:30:00', 'Reason 2', 30, 200.50, 0, 1, 0, 1, 0, 1, 100.25, 'Student3, Student4', 'Comments 2', 1, 1, 0, '', 1),
    (3, 'UserID3', 3, '2023-03-25', '11:15:00', '13:45:00', 'Reason 3', 20, 120.75, 1, 0, 1, 0, 1, 0, 60.38, 'Student5, Student6', 'Comments 3', 1, 1, 0, '', 1),
    (4, 'UserID4', 4, '2023-04-30', '08:45:00', '11:00:00', 'Reason 4', 15, 90.25, 0, 1, 0, 1, 0, 1, 45.13, 'Student7, Student8', 'Comments 4', 1, 1, 0, '', 1),
    (5, 'UserID5', 5, '2023-05-10', '12:00:00', '15:00:00', 'Reason 5', 35, 250.00, 1, 0, 1, 0, 1, 0, 125.00, 'Student9, Student10', 'Comments 5', 1, 1, 0, '', 1),
    (6, 'UserID6', 6, '2023-06-05', '09:30:00', '12:30:00', 'Reason 6', 28, 180.75, 0, 1, 0, 1, 0, 1, 90.38, 'Student11, Student12', 'Comments 6', 1, 1, 0, '', 1),
    (7, 'UserID7', 7, '2023-07-20', '10:00:00', '13:00:00', 'Reason 7', 22, 140.50, 1, 0, 1, 0, 1, 0, 70.25, 'Student13, Student14', 'Comments 7', 1, 1, 0, '', 1),
    (8, 'UserID8', 8, '2023-08-15', '11:45:00', '14:45:00', 'Reason 8', 18, 110.25, 0, 1, 0, 1, 0, 1, 55.13, 'Student15, Student16', 'Comments 8', 1, 1, 0, '', 1),
    (9, 'UserID9', 9, '2023-09-30', '09:00:00', '12:00:00', 'Reason 9', 32, 220.00, 1, 0, 1, 0, 1, 0, 110.00, 'Student17, Student18', 'Comments 9', 1, 1, 0, '', 1),
    (10, 'UserID10', 10, '2023-10-25', '10:30:00', '14:30:00', 'Reason 10', 27, 170.25, 0, 1, 0, 1, 0, 1, 85.13, 'Student19, Student20', 'Comments 10', 1, 1, 0, '', 1);

-- Dummy data for Begeleiding table
INSERT INTO Begeleiding (StudiebezoekId, GebruikerId)
VALUES
    (1, 'UserID1'),
    (2, 'UserID2'),
    (3, 'UserID3'),
    (4, 'UserID4'),
    (5, 'UserID5'),
    (6, 'UserID6'),
    (7, 'UserID7'),
    (8, 'UserID8'),
    (9, 'UserID9'),
    (10, 'UserID10');

-- Dummy data for Bijlage table
INSERT INTO Bijlage (StudiebezoekId, BestandsNaam)
VALUES
    (1, 'File1.pdf'),
    (2, 'File2.docx'),
    (3, 'File3.pdf'),
    (4, 'File4.docx'),
    (5, 'File5.txt'),
    (6, 'File6.pdf'),
    (7, 'File7.docx'),
    (8, 'File8.pdf'),
    (9, 'File9.docx'),
    (10, 'File10.txt');

-- Dummy data for Foto table
INSERT INTO Foto (FotoAlbumId, NaamFoto, Thumbnail)
VALUES
    (1, 'Image1.jpg', 'Thumb1.jpg'),
    (2, 'Image2.png', 'Thumb2.png'),
    (3, 'Image3.jpg', 'Thumb3.jpg'),
    (4, 'Image4.png', 'Thumb4.png'),
    (5, 'Image5.jpg', 'Thumb5.jpg'),
    (6, 'Image6.png', 'Thumb6.png'),
    (7, 'Image7.jpg', 'Thumb7.jpg'),
    (8, 'Image8.png', 'Thumb8.png'),
    (9, 'Image9.jpg', 'Thumb9.jpg'),
    (10, 'Image10.png', 'Thumb10.png');

-- Dummy data for FotoAlbum table
INSERT INTO FotoAlbum (StudiebezoekId, Naam, Datum)
VALUES
    (1, 'Album 1', '2023-11-01'),
    (2, 'Album 2', '2023-11-02'),
    (3, 'Album 3', '2023-11-03'),
    (4, 'Album 4', '2023-11-04'),
    (5, 'Album 5', '2023-11-05'),
    (6, 'Album 6', '2023-11-06'),
    (7, 'Album 7', '2023-11-07'),
    (8, 'Album 8', '2023-11-08'),
    (9, 'Album 9', '2023-11-09'),
    (10, 'Album 10', '2023-11-10');


-- Dummy data for Navorming table
INSERT INTO Navorming (GebruikerId, Datum, StartUur, EindUur, Reden, Kostprijs, IsGoedgekeurdDir, IsAfgewezen, OpmerkingAfgewezen, IsAfgewerkt)
VALUES
    ('UserID1', '2023-11-01', '09:00:00', '17:00:00', 'Reason 1', 250.00, 1, 0, '', 1),
    ('UserID2', '2023-11-02', '09:30:00', '16:30:00', 'Reason 2', 300.00, 1, 0, '', 1),
    ('UserID3', '2023-11-03', '10:00:00', '18:00:00', 'Reason 3', 280.00, 1, 0, '', 1),
    ('UserID4', '2023-11-04', '09:15:00', '16:15:00', 'Reason 4', 320.00, 1, 0, '', 1),
    ('UserID5', '2023-11-05', '08:45:00', '15:45:00', 'Reason 5', 270.00, 1, 0, '', 1),
    ('UserID6', '2023-11-06', '09:30:00', '17:30:00', 'Reason 6', 290.00, 1, 0, '', 1),
    ('UserID7', '2023-11-07', '10:15:00', '18:15:00', 'Reason 7', 310.00, 1, 0, '', 1),
    ('UserID8', '2023-11-08', '09:00:00', '16:00:00', 'Reason 8', 260.00, 1, 0, '', 1),
    ('UserID9', '2023-11-09', '08:30:00', '15:30:00', 'Reason 9', 280.00, 1, 0, '', 1),
    ('UserID1', '2023-11-10', '09:45:00', '16:45:00', 'Reason 10', 300.00, 1, 0, '', 1);
INSERT INTO Afwezigheid (GebruikerId, StartDatum, EindDatum)
VALUES
    ('UserID1', '2023-11-01', '2023-11-05'),
    ('UserID2', '2023-11-02', '2023-11-06'),
    ('UserID3', '2023-11-03', '2023-11-07'),
    ('UserID4', '2023-11-04', '2023-11-08'),
    ('UserID5', '2023-11-05', '2023-11-09'),
    ('UserID6', '2023-11-06', '2023-11-10'),
    ('UserID7', '2023-11-07', '2023-11-11'),
    ('UserID8', '2023-11-08', '2023-11-12'),
    ('UserID9', '2023-11-09', '2023-11-13'),
    ('UserID10', '2023-11-10', '2023-11-14');

-- Dummy data for GebruikerNavorming table
INSERT INTO GebruikerNavorming (GebruikerId, NavormingId)
VALUES
    ('UserID1', 1),
    ('UserID2', 2),
    ('UserID3', 3),
    ('UserID4', 4),
    ('UserID5', 5),
    ('UserID6', 6),
    ('UserID7', 7),
    ('UserID8', 8),
    ('UserID9', 9),
    ('UserID10', 1);


-- Dummy data for Klas table
INSERT INTO Klas (KlasId, Naam, Verwijderd)
VALUES
    (1, 'Class 1A', 0),
    (2, 'Class 2B', 0),
    (3, 'Class 3C', 0),
    (4, 'Class 4D', 0),
    (5, 'Class 5E', 0),
    (6, 'Class 6F', 0),
    (7, 'Class 7G', 0),
    (8, 'Class 8H', 0),
    (9, 'Class 9I', 0),
    (10, 'Class 10J', 0);

-- Dummy data for KlasStudiebezoek table
INSERT INTO KlasStudiebezoek (KlasId, StudiebezoekId)
VALUES
    (1, 1),
    (2, 2),
    (3, 3),
    (4, 4),
    (5, 5),
    (6, 6),
    (7, 7),
    (8, 8),
    (9, 9),
    (10, 10);


-- Dummy data for Rol table
INSERT INTO Rol (Id, Naam, Email, UserName, NormalizedUserName, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount)
VALUES
    ('RoleID1', 'Role1', NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, 0, 0, NULL, 0, 0),
    ('RoleID2', 'Role2', NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, 0, 0, NULL, 0, 0),
    ('RoleID3', 'Role3', NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, 0, 0, NULL, 0, 0),
    ('RoleID4', 'Role4', NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, 0, 0, NULL, 0, 0),
    ('RoleID5', 'Role5', NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, 0, 0, NULL, 0, 0),
    ('RoleID6', 'Role6', NULL, NULL, NULL, NULL,  1, NULL, NULL, NULL, NULL, 0, 0, NULL, 0, 0),
    ('RoleID7', 'Role7', NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, 0, 0, NULL, 0, 0),
    ('RoleID8', 'Role8', NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, 0, 0, NULL, 0, 0),
    ('RoleID9', 'Role9', NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, 0, 0, NULL, 0, 0),
    ('RoleID10', 'Role10', NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, 0, 0, NULL, 0, 0);
-- Dummy data for GebruikerRol table
INSERT INTO GebruikerRol (Id, GebruikerId, RolId, UserName, NormalizedUserName, Email, NormalizedEmail, EmailConfirmed, PasswordHash, SecurityStamp, ConcurrencyStamp, PhoneNumber, PhoneNumberConfirmed, TwoFactorEnabled, LockoutEnd, LockoutEnabled, AccessFailedCount)
VALUES
    ('UserRoleID1', 'UserID1', 'RoleID1', NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, 0, 0, NULL, 0, 0),
    ('UserRoleID2', 'UserID2', 'RoleID2', NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, 0, 0, NULL, 0, 0),
    ('UserRoleID3', 'UserID3', 'RoleID3', NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, 0, 0, NULL, 0, 0),
    ('UserRoleID4', 'UserID4', 'RoleID4', NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, 0, 0, NULL, 0, 0),
    ('UserRoleID5', 'UserID5', 'RoleID5', NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, 0, 0, NULL, 0, 0),
    ('UserRoleID6', 'UserID6', 'RoleID6', NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, 0, 0, NULL, 0, 0),
    ('UserRoleID7', 'UserID7', 'RoleID7', NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, 0, 0, NULL, 0, 0),
    ('UserRoleID8', 'UserID8', 'RoleID8', NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, 0, 0, NULL, 0, 0),
    ('UserRoleID9', 'UserID9', 'RoleID9', NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, 0, 0, NULL, 0, 0),
    ('UserRoleID10', 'UserID10', 'RoleID10', NULL, NULL, NULL, NULL, 1, NULL, NULL, NULL, NULL, 0, 0, NULL, 0, 0);



-- Dummy data for Vak table
INSERT INTO Vak (Naam, Verwijderd)
VALUES
    ('Subject 1', 0),
    ('Subject 2', 0),
    ('Subject 3', 0),
    ('Subject 4', 0),
    ('Subject 5', 0),
    ('Subject 6', 0),
    ('Subject 7', 0),
    ('Subject 8', 0),
    ('Subject 9', 0),
    ('Subject 10', 0);