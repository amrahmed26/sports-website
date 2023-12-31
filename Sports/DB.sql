USE [Sports]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 11/11/2023 11:10:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[__EFMigrationsHistory](
	[MigrationId] [nvarchar](150) NOT NULL,
	[ProductVersion] [nvarchar](32) NOT NULL,
 CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY CLUSTERED 
(
	[MigrationId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Matches]    Script Date: 11/11/2023 11:10:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Matches](
	[MatchId] [int] IDENTITY(1,1) NOT NULL,
	[HomeId] [int] NOT NULL,
	[AwayId] [int] NOT NULL,
	[TournamentId] [int] NOT NULL,
	[Result] [nvarchar](10) NOT NULL,
	[MatchDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Matches] PRIMARY KEY CLUSTERED 
(
	[MatchId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Players]    Script Date: 11/11/2023 11:10:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Players](
	[PlayerId] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NOT NULL,
	[LastName] [nvarchar](50) NOT NULL,
	[BirtDate] [datetime2](7) NOT NULL,
	[TeamId] [int] NOT NULL,
 CONSTRAINT [PK_Players] PRIMARY KEY CLUSTERED 
(
	[PlayerId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Teams]    Script Date: 11/11/2023 11:10:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Teams](
	[TeamId] [int] IDENTITY(1,1) NOT NULL,
	[TeamName] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](500) NOT NULL,
	[Website] [nvarchar](100) NOT NULL,
	[Logo] [nvarchar](100) NOT NULL,
	[FoundationDate] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_Teams] PRIMARY KEY CLUSTERED 
(
	[TeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[TeamTournaments]    Script Date: 11/11/2023 11:10:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[TeamTournaments](
	[TeamId] [int] NOT NULL,
	[TournamentId] [int] NOT NULL,
 CONSTRAINT [PK_TeamTournaments] PRIMARY KEY CLUSTERED 
(
	[TournamentId] ASC,
	[TeamId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Tournaments]    Script Date: 11/11/2023 11:10:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Tournaments](
	[TournamentId] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](max) NOT NULL,
	[Description] [nvarchar](max) NOT NULL,
	[Logo] [nvarchar](max) NOT NULL,
	[TournamentVideo] [nvarchar](max) NULL,
 CONSTRAINT [PK_Tournaments] PRIMARY KEY CLUSTERED 
(
	[TournamentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20231109113500_intialDb', N'7.0.13')
GO
SET IDENTITY_INSERT [dbo].[Teams] ON 

INSERT [dbo].[Teams] ([TeamId], [TeamName], [Description], [Website], [Logo], [FoundationDate]) VALUES (9, N'Zamalek', N'<p>Zamalek</p>', N'test', N'2f8f83cd-2808-4599-a8da-bafb08d17b4e_hand.jpg', CAST(N'2023-11-11T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Teams] ([TeamId], [TeamName], [Description], [Website], [Logo], [FoundationDate]) VALUES (10, N'ASC', N'<p>test</p>', N'www.dot.com', N'8b9d6df8-7b25-44f4-8ca9-a00a3a68ce9e_hand.jpg', CAST(N'2023-11-03T00:00:00.0000000' AS DateTime2))
INSERT [dbo].[Teams] ([TeamId], [TeamName], [Description], [Website], [Logo], [FoundationDate]) VALUES (11, N'Enppi', N'<p>test</p>', N'https://www.youtube.com/embed/aSDdHSW6_bU?si=4cwcjUodU4cHqbsN', N'37cc1113-348c-4063-ac39-16b6722b67d1_hand.jpg', CAST(N'2023-11-08T00:00:00.0000000' AS DateTime2))
SET IDENTITY_INSERT [dbo].[Teams] OFF
GO
INSERT [dbo].[TeamTournaments] ([TeamId], [TournamentId]) VALUES (9, 24)
INSERT [dbo].[TeamTournaments] ([TeamId], [TournamentId]) VALUES (9, 25)
INSERT [dbo].[TeamTournaments] ([TeamId], [TournamentId]) VALUES (10, 25)
INSERT [dbo].[TeamTournaments] ([TeamId], [TournamentId]) VALUES (11, 24)
GO
SET IDENTITY_INSERT [dbo].[Tournaments] ON 

INSERT [dbo].[Tournaments] ([TournamentId], [Name], [Description], [Logo], [TournamentVideo]) VALUES (24, N'Caf Confederation', N'<p>test</p>', N'd32a2e52-26fc-47b3-bdb1-38f43397666f_hand.jpg', N'https://www.youtube.com/embed/aSDdHSW6_bU?si=4cwcjUodU4cHqbsN')
INSERT [dbo].[Tournaments] ([TournamentId], [Name], [Description], [Logo], [TournamentVideo]) VALUES (25, N'Caf Champions', N'<p>test</p>', N'f280085a-1b59-4e8c-9379-83c540e1b007_hand.jpg', N'https://www.youtube.com/embed/aSDdHSW6_bU?si=4cwcjUodU4cHqbsN')
SET IDENTITY_INSERT [dbo].[Tournaments] OFF
GO
ALTER TABLE [dbo].[Matches]  WITH CHECK ADD  CONSTRAINT [FK_Matches_Teams_AwayId] FOREIGN KEY([AwayId])
REFERENCES [dbo].[Teams] ([TeamId])
GO
ALTER TABLE [dbo].[Matches] CHECK CONSTRAINT [FK_Matches_Teams_AwayId]
GO
ALTER TABLE [dbo].[Matches]  WITH CHECK ADD  CONSTRAINT [FK_Matches_Teams_HomeId] FOREIGN KEY([HomeId])
REFERENCES [dbo].[Teams] ([TeamId])
GO
ALTER TABLE [dbo].[Matches] CHECK CONSTRAINT [FK_Matches_Teams_HomeId]
GO
ALTER TABLE [dbo].[Matches]  WITH CHECK ADD  CONSTRAINT [FK_Matches_Tournaments_TournamentId] FOREIGN KEY([TournamentId])
REFERENCES [dbo].[Tournaments] ([TournamentId])
GO
ALTER TABLE [dbo].[Matches] CHECK CONSTRAINT [FK_Matches_Tournaments_TournamentId]
GO
ALTER TABLE [dbo].[Players]  WITH CHECK ADD  CONSTRAINT [FK_Players_Teams_TeamId] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Teams] ([TeamId])
GO
ALTER TABLE [dbo].[Players] CHECK CONSTRAINT [FK_Players_Teams_TeamId]
GO
ALTER TABLE [dbo].[TeamTournaments]  WITH CHECK ADD  CONSTRAINT [FK_TeamTournaments_Teams_TeamId] FOREIGN KEY([TeamId])
REFERENCES [dbo].[Teams] ([TeamId])
GO
ALTER TABLE [dbo].[TeamTournaments] CHECK CONSTRAINT [FK_TeamTournaments_Teams_TeamId]
GO
ALTER TABLE [dbo].[TeamTournaments]  WITH CHECK ADD  CONSTRAINT [FK_TeamTournaments_Tournaments_TournamentId] FOREIGN KEY([TournamentId])
REFERENCES [dbo].[Tournaments] ([TournamentId])
GO
ALTER TABLE [dbo].[TeamTournaments] CHECK CONSTRAINT [FK_TeamTournaments_Tournaments_TournamentId]
GO
/****** Object:  StoredProcedure [dbo].[GetTourenamentForUpdate]    Script Date: 11/11/2023 11:10:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE procedure [dbo].[GetTourenamentForUpdate] (@Id int )
as 
begin
    WITH TeamJSON AS (
	select Teams.TeamId as Id,Teams.TeamName as Name ,1 as IsSelected
from TeamTournaments 
join Teams on TeamTournaments.TeamId=Teams.TeamId 
where TeamTournaments.TournamentId=@Id
union
select Teams.TeamId as Id,Teams.TeamName as Name ,0 as IsSelected
from Teams where Teams.TeamId not in (select TeamId from TeamTournaments where TournamentId=@ID)
)
select Tournaments.*,        (SELECT * FROM TeamJSON FOR JSON AUTO) AS teams

from 
Tournaments
where TournamentId=@Id
end
GO
