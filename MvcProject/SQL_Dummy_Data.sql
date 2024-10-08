USE [MVCProject]
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'28550414-c6b1-4fc7-ab51-a40cdd9ddc6a', N'Secretariaat', N'SECRETARIAAT', N'86d3fd1c-b86c-46fa-b945-c87746a776da')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'6014de27-b4fd-4bf8-8ae4-cd037e0042b1', N'Beheerder', N'BEHEERDER', N'172c26f1-1524-41ea-86d6-9a89cd0458a5')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'64fa4bb7-5679-4c9d-97c1-9cd72e99af73', N'Directie', N'DIRECTIE', N'3313093d-ed7a-40ad-bab4-391997790604')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'715dc1c7-8b7e-49ff-81ca-ecd1d309f60a', N'Leerkracht', N'LEERKRACHT', N'9bcae8b3-1c58-45bc-8e7a-aa2ef4b866e6')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'e8d94eeb-36d6-4ead-ae6d-0e29e6c0d872', N'Coördinator', N'COÖRDINATOR', N'49a8e7a9-f0a3-48c4-95cc-13bef3e05a67')
GO
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'9563e7a6-1175-41b0-8923-f8d1b71fe3e5', N'6014de27-b4fd-4bf8-8ae4-cd037e0042b1')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'dbd1eeb5-4e53-4b15-ad46-01c97344a59f', N'64fa4bb7-5679-4c9d-97c1-9cd72e99af73')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'33ad74ae-e8a6-49e9-935b-71a13045ecaf', N'715dc1c7-8b7e-49ff-81ca-ecd1d309f60a')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'ebc3fa96-7ebf-4b0e-accf-80430501c103', N'715dc1c7-8b7e-49ff-81ca-ecd1d309f60a')
INSERT [dbo].[AspNetUserRoles] ([UserId], [RoleId]) VALUES (N'c9f107c3-bcbe-451b-95e9-33965cebc6f9', N'e8d94eeb-36d6-4ead-ae6d-0e29e6c0d872')
GO
INSERT [dbo].[Gebruiker] ([Id], [Naam], [Voornaam], [Email], [Verwijderd], [Initialen], [UserName], [NormalizedUserName], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'33ad74ae-e8a6-49e9-935b-71a13045ecaf', N'Test', N'Leerkracht', N'test@leerkracht.be', NULL, N'LT', N'test@leerkracht.be', N'TEST@LEERKRACHT.BE', NULL, 0, N'AQAAAAEAACcQAAAAEPnEX+yCwKketwbdyIUmkAPIcnFGNvMh8JmXGXm/HDisENoH6RB5wZTmW2lbIuyRIQ==', N'2IJN5QK2FBKAXG7DRXCZS5A5B67CLA7Q', N'1addd4c9-4fcf-4311-9e57-55e816da191e', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Gebruiker] ([Id], [Naam], [Voornaam], [Email], [Verwijderd], [Initialen], [UserName], [NormalizedUserName], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'9563e7a6-1175-41b0-8923-f8d1b71fe3e5', N'test', N'Beheerder', N'test@beheerder.be', NULL, N'Bt', N'test@beheerder.be', N'TEST@BEHEERDER.BE', NULL, 0, N'AQAAAAEAACcQAAAAEJj/1JdJnSNZq2BuKeVSZXBx5oR1633GaDlTa429GzvlBQ/Z6NY25sh5iCyKyTvSHA==', N'WWQ4J543BBQVFG57ASIH7T6Q4UZCLOZK', N'83e21178-196b-4a41-8c7c-bd520f461086', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Gebruiker] ([Id], [Naam], [Voornaam], [Email], [Verwijderd], [Initialen], [UserName], [NormalizedUserName], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'c9f107c3-bcbe-451b-95e9-33965cebc6f9', N'Test', N'Coordinator', N'test@coordinator.be', NULL, N'CT', N'test@coordinator.be', N'TEST@COORDINATOR.BE', NULL, 0, N'AQAAAAEAACcQAAAAEJZHfi5i1UoYw00qSUsUGVzPG9Y5Jt8Dn4fJCwYrTNrGww+RXROrRQjwP+aAJD1uBg==', N'UHKEG6MP6FFXPD4NPLUFMTRBL5LQYGBD', N'502fbd63-577f-4508-a60a-b1708af2249a', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Gebruiker] ([Id], [Naam], [Voornaam], [Email], [Verwijderd], [Initialen], [UserName], [NormalizedUserName], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'dbd1eeb5-4e53-4b15-ad46-01c97344a59f', N'Test', N'Directie', N'test@directie.be', NULL, N'DT', N'test@directie.be', N'TEST@DIRECTIE.BE', NULL, 0, N'AQAAAAEAACcQAAAAED2rLfaS8jmIe3PPH7HejrSql9m3xepoU0dGH1s0Kv1kMmxwQPMrW81/RtMKq5KTaQ==', N'335BZRIOVCBOCFOGG6O2SZ5QH5NGLBCJ', N'd47c90e7-cc54-4594-9141-c1603f4e23a3', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[Gebruiker] ([Id], [Naam], [Voornaam], [Email], [Verwijderd], [Initialen], [UserName], [NormalizedUserName], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'ebc3fa96-7ebf-4b0e-accf-80430501c103', N'Test', N'Leerkracht', N'leerkracht@test.be', NULL, N'LT', N'leerkracht@test.be', N'LEERKRACHT@TEST.BE', NULL, 0, N'AQAAAAEAACcQAAAAEFFxWHSL2Z1TfXpu2r7GL12Fb7FT1Irl6hpm11bET02xxuG3yZAWug1YPDGFNoV3KA==', N'ORNYIZKVZENNEOJLPL4GJVBXVCHZOI7O', N'4d89921e-6d32-442f-b5c0-3e214118ceb2', NULL, 0, 0, NULL, 1, 0)
GO
SET IDENTITY_INSERT [dbo].[Navorming] ON 

INSERT [dbo].[Navorming] ([NavormingId], [GebruikerId], [Datum], [StartUur], [EindUur], [Reden], [Kostprijs], [IsGoedgekeurdDir], [IsAfgewezen], [OpmerkingAfgewezen], [IsAfgewerkt]) VALUES (2, N'33ad74ae-e8a6-49e9-935b-71a13045ecaf', CAST(N'2024-01-21T21:19:00.0000000' AS DateTime2), CAST(N'2024-01-31T21:19:00.0000000' AS DateTime2), CAST(N'2024-02-09T21:19:00.0000000' AS DateTime2), N'Museum Bezoek', CAST(2500.00 AS Decimal(18, 2)), 0, 0, N'Weer te duur', 0)
INSERT [dbo].[Navorming] ([NavormingId], [GebruikerId], [Datum], [StartUur], [EindUur], [Reden], [Kostprijs], [IsGoedgekeurdDir], [IsAfgewezen], [OpmerkingAfgewezen], [IsAfgewerkt]) VALUES (6, N'33ad74ae-e8a6-49e9-935b-71a13045ecaf', CAST(N'2024-01-19T23:40:00.0000000' AS DateTime2), CAST(N'2024-01-30T23:40:00.0000000' AS DateTime2), CAST(N'2024-01-31T23:40:00.0000000' AS DateTime2), N'test', CAST(240.00 AS Decimal(18, 2)), 0, 0, NULL, 0)
SET IDENTITY_INSERT [dbo].[Navorming] OFF
GO
SET IDENTITY_INSERT [dbo].[Vak] ON 

INSERT [dbo].[Vak] ([VakId], [Naam], [Verwijderd]) VALUES (1, N'Frans', 0)
SET IDENTITY_INSERT [dbo].[Vak] OFF
GO
SET IDENTITY_INSERT [dbo].[Studiebezoek] ON 

INSERT [dbo].[Studiebezoek] ([StudiebezoekId], [GebruikerId], [VakId], [Datum], [StartUur], [EindUur], [Reden], [AantalStudenten], [KostprijsStudiebezoek], [VervoerBus], [VervoerTram], [VervoerTrein], [VervoerTeVoet], [VervoerAuto], [VervoerFiets], [KostprijsVervoer], [AfwezigeStudenten], [Opmerkingen], [IsGoedgekeurdCo], [IsGoedgekeurdDir], [IsAfgewezen], [OpmerkingAfgewezen], [IsAfgewerkt]) VALUES (5, N'33ad74ae-e8a6-49e9-935b-71a13045ecaf', 1, CAST(N'2024-01-06T00:00:00.0000000' AS DateTime2), CAST(N'2024-01-06T08:00:00.0000000' AS DateTime2), CAST(N'2024-01-06T10:00:00.0000000' AS DateTime2), N'museum', 20, CAST(100.0000 AS Decimal(18, 4)), 0, 0, 0, 0, 0, 0, CAST(20.0000 AS Decimal(18, 4)), NULL, N'ok', 1, 1, 1, N'niet', 1)
INSERT [dbo].[Studiebezoek] ([StudiebezoekId], [GebruikerId], [VakId], [Datum], [StartUur], [EindUur], [Reden], [AantalStudenten], [KostprijsStudiebezoek], [VervoerBus], [VervoerTram], [VervoerTrein], [VervoerTeVoet], [VervoerAuto], [VervoerFiets], [KostprijsVervoer], [AfwezigeStudenten], [Opmerkingen], [IsGoedgekeurdCo], [IsGoedgekeurdDir], [IsAfgewezen], [OpmerkingAfgewezen], [IsAfgewerkt]) VALUES (6, N'33ad74ae-e8a6-49e9-935b-71a13045ecaf', 1, CAST(N'2024-01-26T23:41:00.0000000' AS DateTime2), CAST(N'2024-01-26T23:42:00.0000000' AS DateTime2), CAST(N'2024-01-26T23:42:00.0000000' AS DateTime2), N'Museum Bezoek', 3, CAST(100.0000 AS Decimal(18, 4)), 0, 0, 1, 0, 0, 0, CAST(20.0000 AS Decimal(18, 4)), NULL, NULL, 0, 0, 0, NULL, 0)
INSERT [dbo].[Studiebezoek] ([StudiebezoekId], [GebruikerId], [VakId], [Datum], [StartUur], [EindUur], [Reden], [AantalStudenten], [KostprijsStudiebezoek], [VervoerBus], [VervoerTram], [VervoerTrein], [VervoerTeVoet], [VervoerAuto], [VervoerFiets], [KostprijsVervoer], [AfwezigeStudenten], [Opmerkingen], [IsGoedgekeurdCo], [IsGoedgekeurdDir], [IsAfgewezen], [OpmerkingAfgewezen], [IsAfgewerkt]) VALUES (7, N'33ad74ae-e8a6-49e9-935b-71a13045ecaf', 1, CAST(N'2024-01-30T23:42:00.0000000' AS DateTime2), CAST(N'2024-01-30T23:43:00.0000000' AS DateTime2), CAST(N'2024-01-30T23:43:00.0000000' AS DateTime2), N'Paris', 6, CAST(100.0000 AS Decimal(18, 4)), 0, 0, 0, 1, 0, 0, CAST(20.0000 AS Decimal(18, 4)), NULL, NULL, 0, 0, 0, NULL, 0)
SET IDENTITY_INSERT [dbo].[Studiebezoek] OFF
GO
SET IDENTITY_INSERT [dbo].[FotoAlbum] ON 

INSERT [dbo].[FotoAlbum] ([FotoAlbumId], [StudiebezoekId], [Naam], [Datum], [GebruikerId]) VALUES (6, 5, N'Hafsa', CAST(N'2001-10-25T20:20:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[FotoAlbum] ([FotoAlbumId], [StudiebezoekId], [Naam], [Datum], [GebruikerId]) VALUES (7, 5, N'Hafsa', CAST(N'2004-10-25T22:22:00.0000000' AS DateTime2), NULL)
INSERT [dbo].[FotoAlbum] ([FotoAlbumId], [StudiebezoekId], [Naam], [Datum], [GebruikerId]) VALUES (9, 5, N'Test', CAST(N'2004-10-25T12:03:00.0000000' AS DateTime2), NULL)
SET IDENTITY_INSERT [dbo].[FotoAlbum] OFF
GO
SET IDENTITY_INSERT [dbo].[Klas] ON 

INSERT [dbo].[Klas] ([KlasId], [Naam], [Verwijderd]) VALUES (3, N'Biomedische ', 1)
SET IDENTITY_INSERT [dbo].[Klas] OFF
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231222092456_InitialCreate', N'6.0.25')
GO
