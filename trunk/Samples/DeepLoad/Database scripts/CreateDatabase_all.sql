USE [DeepLoad]
GO
/****** Object:  Table [dbo].[1_Continents]    Script Date: 01/13/2013 15:48:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[1_Continents](
	[Continent_ID] [int] IDENTITY(1,1) NOT NULL,
	[Continent_Name] [varchar](50) COLLATE Latin1_General_CI_AI NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Continents] PRIMARY KEY CLUSTERED 
(
	[Continent_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[1_Continents] ON
INSERT [dbo].[1_Continents] ([Continent_ID], [Continent_Name], [IsActive]) VALUES (1, N'Europe', 1)
INSERT [dbo].[1_Continents] ([Continent_ID], [Continent_Name], [IsActive]) VALUES (2, N'Africa', 1)
INSERT [dbo].[1_Continents] ([Continent_ID], [Continent_Name], [IsActive]) VALUES (3, N'America', 1)
SET IDENTITY_INSERT [dbo].[1_Continents] OFF
/****** Object:  Table [dbo].[2_SubContinents]    Script Date: 01/13/2013 15:48:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[2_SubContinents](
	[SubContinent_ID] [int] IDENTITY(1,1) NOT NULL,
	[SubContinent_Name] [varchar](50) COLLATE Latin1_General_CI_AI NOT NULL,
	[Parent_Continent_ID] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_SubContinents] PRIMARY KEY CLUSTERED 
(
	[SubContinent_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[2_SubContinents] ON
INSERT [dbo].[2_SubContinents] ([SubContinent_ID], [SubContinent_Name], [Parent_Continent_ID], [IsActive]) VALUES (1, N'Europe UE', 1, 1)
INSERT [dbo].[2_SubContinents] ([SubContinent_ID], [SubContinent_Name], [Parent_Continent_ID], [IsActive]) VALUES (2, N'Other European Countries', 1, 1)
INSERT [dbo].[2_SubContinents] ([SubContinent_ID], [SubContinent_Name], [Parent_Continent_ID], [IsActive]) VALUES (3, N'North Africa', 2, 1)
INSERT [dbo].[2_SubContinents] ([SubContinent_ID], [SubContinent_Name], [Parent_Continent_ID], [IsActive]) VALUES (4, N'Africa Sub Saharan', 2, 1)
INSERT [dbo].[2_SubContinents] ([SubContinent_ID], [SubContinent_Name], [Parent_Continent_ID], [IsActive]) VALUES (5, N'North America', 3, 1)
INSERT [dbo].[2_SubContinents] ([SubContinent_ID], [SubContinent_Name], [Parent_Continent_ID], [IsActive]) VALUES (6, N'Latin America', 3, 1)
SET IDENTITY_INSERT [dbo].[2_SubContinents] OFF
/****** Object:  Table [dbo].[3_Countries]    Script Date: 01/13/2013 15:48:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[3_Countries](
	[Country_ID] [int] IDENTITY(1,1) NOT NULL,
	[Country_Name] [varchar](50) COLLATE Latin1_General_CI_AI NOT NULL,
	[Parent_SubContinent_ID] [int] NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Countries] PRIMARY KEY CLUSTERED 
(
	[Country_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[3_Countries] ON
INSERT [dbo].[3_Countries] ([Country_ID], [Country_Name], [Parent_SubContinent_ID], [IsActive]) VALUES (1, N'Portugal', 1, 1)
INSERT [dbo].[3_Countries] ([Country_ID], [Country_Name], [Parent_SubContinent_ID], [IsActive]) VALUES (2, N'The Nederlands', 1, 1)
INSERT [dbo].[3_Countries] ([Country_ID], [Country_Name], [Parent_SubContinent_ID], [IsActive]) VALUES (3, N'Switzerland', 2, 1)
INSERT [dbo].[3_Countries] ([Country_ID], [Country_Name], [Parent_SubContinent_ID], [IsActive]) VALUES (4, N'Angola', 4, 1)
INSERT [dbo].[3_Countries] ([Country_ID], [Country_Name], [Parent_SubContinent_ID], [IsActive]) VALUES (5, N'Mozambique', 4, 1)
INSERT [dbo].[3_Countries] ([Country_ID], [Country_Name], [Parent_SubContinent_ID], [IsActive]) VALUES (6, N'Marroc', 3, 1)
INSERT [dbo].[3_Countries] ([Country_ID], [Country_Name], [Parent_SubContinent_ID], [IsActive]) VALUES (7, N'Brasil', 6, 1)
INSERT [dbo].[3_Countries] ([Country_ID], [Country_Name], [Parent_SubContinent_ID], [IsActive]) VALUES (8, N'USA', 5, 1)
INSERT [dbo].[3_Countries] ([Country_ID], [Country_Name], [Parent_SubContinent_ID], [IsActive]) VALUES (9, N'Argentina', 6, 1)
SET IDENTITY_INSERT [dbo].[3_Countries] OFF
/****** Object:  Table [dbo].[Dummy_Level_1_1_2]    Script Date: 01/13/2013 15:48:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dummy_Level_1_1_2](
	[Level_1_1_2_ID] [int] IDENTITY(1,1) NOT NULL,
	[Level_1_1_2_Name] [varchar](50) COLLATE Latin1_General_CI_AI NOT NULL,
	[MarentID2] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Level_1_1_2] PRIMARY KEY CLUSTERED 
(
	[Level_1_1_2_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Dummy_Level_1_1_2] ON
INSERT [dbo].[Dummy_Level_1_1_2] ([Level_1_1_2_ID], [Level_1_1_2_Name], [MarentID2], [IsActive]) VALUES (1, N'Portugal', 1, 1)
INSERT [dbo].[Dummy_Level_1_1_2] ([Level_1_1_2_ID], [Level_1_1_2_Name], [MarentID2], [IsActive]) VALUES (2, N'The Nederlands', 1, 1)
INSERT [dbo].[Dummy_Level_1_1_2] ([Level_1_1_2_ID], [Level_1_1_2_Name], [MarentID2], [IsActive]) VALUES (3, N'Switzerland', 2, 1)
INSERT [dbo].[Dummy_Level_1_1_2] ([Level_1_1_2_ID], [Level_1_1_2_Name], [MarentID2], [IsActive]) VALUES (4, N'Angola', 4, 1)
INSERT [dbo].[Dummy_Level_1_1_2] ([Level_1_1_2_ID], [Level_1_1_2_Name], [MarentID2], [IsActive]) VALUES (5, N'Mozambique', 4, 1)
INSERT [dbo].[Dummy_Level_1_1_2] ([Level_1_1_2_ID], [Level_1_1_2_Name], [MarentID2], [IsActive]) VALUES (6, N'Marroc', 3, 1)
INSERT [dbo].[Dummy_Level_1_1_2] ([Level_1_1_2_ID], [Level_1_1_2_Name], [MarentID2], [IsActive]) VALUES (7, N'Brasil', 6, 1)
INSERT [dbo].[Dummy_Level_1_1_2] ([Level_1_1_2_ID], [Level_1_1_2_Name], [MarentID2], [IsActive]) VALUES (8, N'USA', 5, 1)
INSERT [dbo].[Dummy_Level_1_1_2] ([Level_1_1_2_ID], [Level_1_1_2_Name], [MarentID2], [IsActive]) VALUES (9, N'Argentina', 6, 1)
SET IDENTITY_INSERT [dbo].[Dummy_Level_1_1_2] OFF
/****** Object:  Table [dbo].[2_SubContinents_ReChild]    Script Date: 01/13/2013 15:48:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[2_SubContinents_ReChild](
	[SubContinent_ID2] [int] NOT NULL,
	[SubContinent_Child_Name] [varchar](50) COLLATE Latin1_General_CI_AI NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_SubContinents_ReChild] PRIMARY KEY CLUSTERED 
(
	[SubContinent_ID2] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[2_SubContinents_ReChild] ([SubContinent_ID2], [SubContinent_Child_Name], [IsActive]) VALUES (1, N'Europeans', 1)
INSERT [dbo].[2_SubContinents_ReChild] ([SubContinent_ID2], [SubContinent_Child_Name], [IsActive]) VALUES (2, N'Europeans', 1)
INSERT [dbo].[2_SubContinents_ReChild] ([SubContinent_ID2], [SubContinent_Child_Name], [IsActive]) VALUES (3, N'Northern Africans', 1)
INSERT [dbo].[2_SubContinents_ReChild] ([SubContinent_ID2], [SubContinent_Child_Name], [IsActive]) VALUES (4, N'Africans', 1)
INSERT [dbo].[2_SubContinents_ReChild] ([SubContinent_ID2], [SubContinent_Child_Name], [IsActive]) VALUES (5, N'Americans', 1)
INSERT [dbo].[2_SubContinents_ReChild] ([SubContinent_ID2], [SubContinent_Child_Name], [IsActive]) VALUES (6, N'Americanos', 1)
/****** Object:  Table [dbo].[2_SubContinents_Child]    Script Date: 01/13/2013 15:48:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[2_SubContinents_Child](
	[SubContinent_ID1] [int] NOT NULL,
	[SubContinent_Child_Name] [varchar](50) COLLATE Latin1_General_CI_AI NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_SubContinents_Child] PRIMARY KEY CLUSTERED 
(
	[SubContinent_ID1] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[2_SubContinents_Child] ([SubContinent_ID1], [SubContinent_Child_Name], [IsActive]) VALUES (1, N'Jean Monet', 1)
INSERT [dbo].[2_SubContinents_Child] ([SubContinent_ID1], [SubContinent_Child_Name], [IsActive]) VALUES (2, N'Anti UE hero', 1)
INSERT [dbo].[2_SubContinents_Child] ([SubContinent_ID1], [SubContinent_Child_Name], [IsActive]) VALUES (3, N'North Africa Hero', 1)
INSERT [dbo].[2_SubContinents_Child] ([SubContinent_ID1], [SubContinent_Child_Name], [IsActive]) VALUES (4, N'Nelson Mandela', 1)
INSERT [dbo].[2_SubContinents_Child] ([SubContinent_ID1], [SubContinent_Child_Name], [IsActive]) VALUES (5, N'George Washington', 1)
INSERT [dbo].[2_SubContinents_Child] ([SubContinent_ID1], [SubContinent_Child_Name], [IsActive]) VALUES (6, N'Simon Bolivar', 1)
/****** Object:  Table [dbo].[Dummy_Level_1_2]    Script Date: 01/13/2013 15:48:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dummy_Level_1_2](
	[Level_1_2_ID] [int] IDENTITY(1,1) NOT NULL,
	[Level_1_2_Name] [varchar](50) COLLATE Latin1_General_CI_AI NOT NULL,
	[ParentID2] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Level_1_2] PRIMARY KEY CLUSTERED 
(
	[Level_1_2_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Dummy_Level_1_2] ON
INSERT [dbo].[Dummy_Level_1_2] ([Level_1_2_ID], [Level_1_2_Name], [ParentID2], [IsActive]) VALUES (1, N'Europe UE', 1, 1)
INSERT [dbo].[Dummy_Level_1_2] ([Level_1_2_ID], [Level_1_2_Name], [ParentID2], [IsActive]) VALUES (2, N'Other European Countries', 1, 1)
INSERT [dbo].[Dummy_Level_1_2] ([Level_1_2_ID], [Level_1_2_Name], [ParentID2], [IsActive]) VALUES (3, N'North Africa', 2, 1)
INSERT [dbo].[Dummy_Level_1_2] ([Level_1_2_ID], [Level_1_2_Name], [ParentID2], [IsActive]) VALUES (4, N'Africa Sub Saharan', 2, 1)
INSERT [dbo].[Dummy_Level_1_2] ([Level_1_2_ID], [Level_1_2_Name], [ParentID2], [IsActive]) VALUES (5, N'North America', 3, 1)
INSERT [dbo].[Dummy_Level_1_2] ([Level_1_2_ID], [Level_1_2_Name], [ParentID2], [IsActive]) VALUES (6, N'Latin America', 3, 1)
SET IDENTITY_INSERT [dbo].[Dummy_Level_1_2] OFF
/****** Object:  Table [dbo].[1_Continents_Child]    Script Date: 01/13/2013 15:48:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[1_Continents_Child](
	[Continent_ID1] [int] NOT NULL,
	[Continent_Child_Name] [varchar](50) COLLATE Latin1_General_CI_AI NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Continents_Child] PRIMARY KEY CLUSTERED 
(
	[Continent_ID1] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[1_Continents_Child] ([Continent_ID1], [Continent_Child_Name], [IsActive]) VALUES (1, N'Strabon', 1)
INSERT [dbo].[1_Continents_Child] ([Continent_ID1], [Continent_Child_Name], [IsActive]) VALUES (2, N'Lucy', 1)
INSERT [dbo].[1_Continents_Child] ([Continent_ID1], [Continent_Child_Name], [IsActive]) VALUES (3, N'Amerigo Vespucci', 1)
/****** Object:  Table [dbo].[1_Continents_ReChild]    Script Date: 01/13/2013 15:48:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[1_Continents_ReChild](
	[Continent_ID2] [int] NOT NULL,
	[Continent_Child_Name] [varchar](50) COLLATE Latin1_General_CI_AI NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Continents_ReChild] PRIMARY KEY CLUSTERED 
(
	[Continent_ID2] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[1_Continents_ReChild] ([Continent_ID2], [Continent_Child_Name], [IsActive]) VALUES (1, N'Europeans', 1)
INSERT [dbo].[1_Continents_ReChild] ([Continent_ID2], [Continent_Child_Name], [IsActive]) VALUES (2, N'Africans', 1)
INSERT [dbo].[1_Continents_ReChild] ([Continent_ID2], [Continent_Child_Name], [IsActive]) VALUES (3, N'Americans', 1)
/****** Object:  Table [dbo].[Dummy_Level_1_1_1_2]    Script Date: 01/13/2013 15:48:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[Dummy_Level_1_1_1_2](
	[Level_1_1_1_2_ID] [int] IDENTITY(1,1) NOT NULL,
	[Level_1_1_1_2_Name] [varchar](50) COLLATE Latin1_General_CI_AI NOT NULL,
	[LarentID2] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Level_1_1_1_2] PRIMARY KEY CLUSTERED 
(
	[Level_1_1_1_2_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[Dummy_Level_1_1_1_2] ON
INSERT [dbo].[Dummy_Level_1_1_1_2] ([Level_1_1_1_2_ID], [Level_1_1_1_2_Name], [LarentID2], [IsActive]) VALUES (1, N'Centro', 1, 1)
INSERT [dbo].[Dummy_Level_1_1_1_2] ([Level_1_1_1_2_ID], [Level_1_1_1_2_Name], [LarentID2], [IsActive]) VALUES (2, N'Norte', 1, 1)
INSERT [dbo].[Dummy_Level_1_1_1_2] ([Level_1_1_1_2_ID], [Level_1_1_1_2_Name], [LarentID2], [IsActive]) VALUES (3, N'Sul', 1, 1)
INSERT [dbo].[Dummy_Level_1_1_1_2] ([Level_1_1_1_2_ID], [Level_1_1_1_2_Name], [LarentID2], [IsActive]) VALUES (4, N'Limburg', 2, 1)
INSERT [dbo].[Dummy_Level_1_1_1_2] ([Level_1_1_1_2_ID], [Level_1_1_1_2_Name], [LarentID2], [IsActive]) VALUES (5, N'North Holland', 2, 1)
INSERT [dbo].[Dummy_Level_1_1_1_2] ([Level_1_1_1_2_ID], [Level_1_1_1_2_Name], [LarentID2], [IsActive]) VALUES (6, N'South Holland', 2, 1)
INSERT [dbo].[Dummy_Level_1_1_1_2] ([Level_1_1_1_2_ID], [Level_1_1_1_2_Name], [LarentID2], [IsActive]) VALUES (7, N'Bern', 3, 1)
INSERT [dbo].[Dummy_Level_1_1_1_2] ([Level_1_1_1_2_ID], [Level_1_1_1_2_Name], [LarentID2], [IsActive]) VALUES (8, N'Genève', 3, 1)
INSERT [dbo].[Dummy_Level_1_1_1_2] ([Level_1_1_1_2_ID], [Level_1_1_1_2_Name], [LarentID2], [IsActive]) VALUES (9, N'Zurich', 3, 1)
INSERT [dbo].[Dummy_Level_1_1_1_2] ([Level_1_1_1_2_ID], [Level_1_1_1_2_Name], [LarentID2], [IsActive]) VALUES (10, N'Luanda', 4, 1)
INSERT [dbo].[Dummy_Level_1_1_1_2] ([Level_1_1_1_2_ID], [Level_1_1_1_2_Name], [LarentID2], [IsActive]) VALUES (11, N'Huambo', 4, 1)
INSERT [dbo].[Dummy_Level_1_1_1_2] ([Level_1_1_1_2_ID], [Level_1_1_1_2_Name], [LarentID2], [IsActive]) VALUES (12, N'Huíla', 4, 1)
INSERT [dbo].[Dummy_Level_1_1_1_2] ([Level_1_1_1_2_ID], [Level_1_1_1_2_Name], [LarentID2], [IsActive]) VALUES (13, N'Maputo', 5, 1)
INSERT [dbo].[Dummy_Level_1_1_1_2] ([Level_1_1_1_2_ID], [Level_1_1_1_2_Name], [LarentID2], [IsActive]) VALUES (14, N'Beira', 5, 1)
INSERT [dbo].[Dummy_Level_1_1_1_2] ([Level_1_1_1_2_ID], [Level_1_1_1_2_Name], [LarentID2], [IsActive]) VALUES (15, N'Nampula', 5, 1)
INSERT [dbo].[Dummy_Level_1_1_1_2] ([Level_1_1_1_2_ID], [Level_1_1_1_2_Name], [LarentID2], [IsActive]) VALUES (16, N'Casablanca', 6, 1)
INSERT [dbo].[Dummy_Level_1_1_1_2] ([Level_1_1_1_2_ID], [Level_1_1_1_2_Name], [LarentID2], [IsActive]) VALUES (17, N'Marrakesh', 6, 1)
INSERT [dbo].[Dummy_Level_1_1_1_2] ([Level_1_1_1_2_ID], [Level_1_1_1_2_Name], [LarentID2], [IsActive]) VALUES (18, N'Rabat', 6, 1)
INSERT [dbo].[Dummy_Level_1_1_1_2] ([Level_1_1_1_2_ID], [Level_1_1_1_2_Name], [LarentID2], [IsActive]) VALUES (19, N'Rio de Janeiro', 7, 1)
INSERT [dbo].[Dummy_Level_1_1_1_2] ([Level_1_1_1_2_ID], [Level_1_1_1_2_Name], [LarentID2], [IsActive]) VALUES (20, N'Olinda', 7, 1)
INSERT [dbo].[Dummy_Level_1_1_1_2] ([Level_1_1_1_2_ID], [Level_1_1_1_2_Name], [LarentID2], [IsActive]) VALUES (21, N'Pernanbuco', 7, 1)
INSERT [dbo].[Dummy_Level_1_1_1_2] ([Level_1_1_1_2_ID], [Level_1_1_1_2_Name], [LarentID2], [IsActive]) VALUES (22, N'California', 8, 1)
INSERT [dbo].[Dummy_Level_1_1_1_2] ([Level_1_1_1_2_ID], [Level_1_1_1_2_Name], [LarentID2], [IsActive]) VALUES (23, N'Lousiana', 8, 1)
INSERT [dbo].[Dummy_Level_1_1_1_2] ([Level_1_1_1_2_ID], [Level_1_1_1_2_Name], [LarentID2], [IsActive]) VALUES (24, N'Texas', 8, 1)
INSERT [dbo].[Dummy_Level_1_1_1_2] ([Level_1_1_1_2_ID], [Level_1_1_1_2_Name], [LarentID2], [IsActive]) VALUES (25, N'Buenos Aires', 9, 1)
INSERT [dbo].[Dummy_Level_1_1_1_2] ([Level_1_1_1_2_ID], [Level_1_1_1_2_Name], [LarentID2], [IsActive]) VALUES (26, N'Mendoza', 9, 1)
INSERT [dbo].[Dummy_Level_1_1_1_2] ([Level_1_1_1_2_ID], [Level_1_1_1_2_Name], [LarentID2], [IsActive]) VALUES (27, N'San Miguel de Tucumán', 9, 1)
SET IDENTITY_INSERT [dbo].[Dummy_Level_1_1_1_2] OFF
/****** Object:  Table [dbo].[3_Countries_ReChild]    Script Date: 01/13/2013 15:48:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[3_Countries_ReChild](
	[Country_ID2] [int] NOT NULL,
	[Country_Child_Name] [varchar](50) COLLATE Latin1_General_CI_AI NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Countries_ReChild] PRIMARY KEY CLUSTERED 
(
	[Country_ID2] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[3_Countries_ReChild] ([Country_ID2], [Country_Child_Name], [IsActive]) VALUES (1, N'Portuguese', 1)
INSERT [dbo].[3_Countries_ReChild] ([Country_ID2], [Country_Child_Name], [IsActive]) VALUES (2, N'Nederlander', 1)
INSERT [dbo].[3_Countries_ReChild] ([Country_ID2], [Country_Child_Name], [IsActive]) VALUES (3, N'Swiss', 1)
INSERT [dbo].[3_Countries_ReChild] ([Country_ID2], [Country_Child_Name], [IsActive]) VALUES (4, N'Angolan', 1)
INSERT [dbo].[3_Countries_ReChild] ([Country_ID2], [Country_Child_Name], [IsActive]) VALUES (5, N'Mozambique people', 1)
INSERT [dbo].[3_Countries_ReChild] ([Country_ID2], [Country_Child_Name], [IsActive]) VALUES (6, N'Marrocan', 1)
INSERT [dbo].[3_Countries_ReChild] ([Country_ID2], [Country_Child_Name], [IsActive]) VALUES (7, N'Brasilian', 1)
INSERT [dbo].[3_Countries_ReChild] ([Country_ID2], [Country_Child_Name], [IsActive]) VALUES (8, N'USA people', 1)
INSERT [dbo].[3_Countries_ReChild] ([Country_ID2], [Country_Child_Name], [IsActive]) VALUES (9, N'Argentina people', 1)
/****** Object:  Table [dbo].[4_Regions]    Script Date: 01/13/2013 15:48:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[4_Regions](
	[Region_ID] [int] IDENTITY(1,1) NOT NULL,
	[Region_Name] [varchar](50) COLLATE Latin1_General_CI_AI NOT NULL,
	[Parent_Country_ID] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Regions] PRIMARY KEY CLUSTERED 
(
	[Region_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[4_Regions] ON
INSERT [dbo].[4_Regions] ([Region_ID], [Region_Name], [Parent_Country_ID], [IsActive]) VALUES (1, N'Centro', 1, 1)
INSERT [dbo].[4_Regions] ([Region_ID], [Region_Name], [Parent_Country_ID], [IsActive]) VALUES (2, N'Norte', 1, 1)
INSERT [dbo].[4_Regions] ([Region_ID], [Region_Name], [Parent_Country_ID], [IsActive]) VALUES (3, N'Sul', 1, 1)
INSERT [dbo].[4_Regions] ([Region_ID], [Region_Name], [Parent_Country_ID], [IsActive]) VALUES (4, N'Limburg', 2, 1)
INSERT [dbo].[4_Regions] ([Region_ID], [Region_Name], [Parent_Country_ID], [IsActive]) VALUES (5, N'North Holland', 2, 1)
INSERT [dbo].[4_Regions] ([Region_ID], [Region_Name], [Parent_Country_ID], [IsActive]) VALUES (6, N'South Holland', 2, 1)
INSERT [dbo].[4_Regions] ([Region_ID], [Region_Name], [Parent_Country_ID], [IsActive]) VALUES (7, N'Bern', 3, 1)
INSERT [dbo].[4_Regions] ([Region_ID], [Region_Name], [Parent_Country_ID], [IsActive]) VALUES (8, N'Genève', 3, 1)
INSERT [dbo].[4_Regions] ([Region_ID], [Region_Name], [Parent_Country_ID], [IsActive]) VALUES (9, N'Zurich', 3, 1)
INSERT [dbo].[4_Regions] ([Region_ID], [Region_Name], [Parent_Country_ID], [IsActive]) VALUES (10, N'Luanda', 4, 1)
INSERT [dbo].[4_Regions] ([Region_ID], [Region_Name], [Parent_Country_ID], [IsActive]) VALUES (11, N'Huambo', 4, 1)
INSERT [dbo].[4_Regions] ([Region_ID], [Region_Name], [Parent_Country_ID], [IsActive]) VALUES (12, N'Huíla', 4, 1)
INSERT [dbo].[4_Regions] ([Region_ID], [Region_Name], [Parent_Country_ID], [IsActive]) VALUES (13, N'Maputo', 5, 1)
INSERT [dbo].[4_Regions] ([Region_ID], [Region_Name], [Parent_Country_ID], [IsActive]) VALUES (14, N'Beira', 5, 1)
INSERT [dbo].[4_Regions] ([Region_ID], [Region_Name], [Parent_Country_ID], [IsActive]) VALUES (15, N'Nampula', 5, 1)
INSERT [dbo].[4_Regions] ([Region_ID], [Region_Name], [Parent_Country_ID], [IsActive]) VALUES (16, N'Casablanca', 6, 1)
INSERT [dbo].[4_Regions] ([Region_ID], [Region_Name], [Parent_Country_ID], [IsActive]) VALUES (17, N'Marrakesh', 6, 1)
INSERT [dbo].[4_Regions] ([Region_ID], [Region_Name], [Parent_Country_ID], [IsActive]) VALUES (18, N'Rabat', 6, 1)
INSERT [dbo].[4_Regions] ([Region_ID], [Region_Name], [Parent_Country_ID], [IsActive]) VALUES (19, N'Rio de Janeiro', 7, 1)
INSERT [dbo].[4_Regions] ([Region_ID], [Region_Name], [Parent_Country_ID], [IsActive]) VALUES (20, N'Olinda', 7, 1)
INSERT [dbo].[4_Regions] ([Region_ID], [Region_Name], [Parent_Country_ID], [IsActive]) VALUES (21, N'Pernanbuco', 7, 1)
INSERT [dbo].[4_Regions] ([Region_ID], [Region_Name], [Parent_Country_ID], [IsActive]) VALUES (22, N'California', 8, 1)
INSERT [dbo].[4_Regions] ([Region_ID], [Region_Name], [Parent_Country_ID], [IsActive]) VALUES (23, N'Louisiana', 8, 1)
INSERT [dbo].[4_Regions] ([Region_ID], [Region_Name], [Parent_Country_ID], [IsActive]) VALUES (24, N'Texas', 8, 1)
INSERT [dbo].[4_Regions] ([Region_ID], [Region_Name], [Parent_Country_ID], [IsActive]) VALUES (25, N'Buenos Aires', 9, 1)
INSERT [dbo].[4_Regions] ([Region_ID], [Region_Name], [Parent_Country_ID], [IsActive]) VALUES (26, N'Mendoza', 9, 1)
INSERT [dbo].[4_Regions] ([Region_ID], [Region_Name], [Parent_Country_ID], [IsActive]) VALUES (27, N'San Miguel de Tucumán', 9, 1)
SET IDENTITY_INSERT [dbo].[4_Regions] OFF
/****** Object:  Table [dbo].[3_Countries_Child]    Script Date: 01/13/2013 15:48:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[3_Countries_Child](
	[Country_ID1] [int] NOT NULL,
	[Country_Child_Name] [varchar](50) COLLATE Latin1_General_CI_AI NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Countries_Child] PRIMARY KEY CLUSTERED 
(
	[Country_ID1] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[3_Countries_Child] ([Country_ID1], [Country_Child_Name], [IsActive]) VALUES (1, N'Luiz Vaz de Camões', 1)
INSERT [dbo].[3_Countries_Child] ([Country_ID1], [Country_Child_Name], [IsActive]) VALUES (2, N'Willem van Oranje', 1)
INSERT [dbo].[3_Countries_Child] ([Country_ID1], [Country_Child_Name], [IsActive]) VALUES (3, N'Wilhelm Tell', 1)
INSERT [dbo].[3_Countries_Child] ([Country_ID1], [Country_Child_Name], [IsActive]) VALUES (4, N'Agostinho Neto', 1)
INSERT [dbo].[3_Countries_Child] ([Country_ID1], [Country_Child_Name], [IsActive]) VALUES (5, N'Eduardo Mondlane', 1)
INSERT [dbo].[3_Countries_Child] ([Country_ID1], [Country_Child_Name], [IsActive]) VALUES (6, N'Abu Yusuf Ya''qub al-Mansur', 1)
INSERT [dbo].[3_Countries_Child] ([Country_ID1], [Country_Child_Name], [IsActive]) VALUES (7, N'Tiradentes', 1)
INSERT [dbo].[3_Countries_Child] ([Country_ID1], [Country_Child_Name], [IsActive]) VALUES (8, N'Gearge Washington', 1)
INSERT [dbo].[3_Countries_Child] ([Country_ID1], [Country_Child_Name], [IsActive]) VALUES (9, N'Simon Bolivar', 1)
/****** Object:  Table [dbo].[4_Regions_Child]    Script Date: 01/13/2013 15:48:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[4_Regions_Child](
	[Region_ID1] [int] NOT NULL,
	[Region_Child_Name] [varchar](50) COLLATE Latin1_General_CI_AI NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Regions_Child] PRIMARY KEY CLUSTERED 
(
	[Region_ID1] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[4_Regions_Child] ([Region_ID1], [Region_Child_Name], [IsActive]) VALUES (1, N'Hero of Centro', 1)
INSERT [dbo].[4_Regions_Child] ([Region_ID1], [Region_Child_Name], [IsActive]) VALUES (2, N'Hero of Norte', 1)
INSERT [dbo].[4_Regions_Child] ([Region_ID1], [Region_Child_Name], [IsActive]) VALUES (3, N'Hero of Sul', 1)
INSERT [dbo].[4_Regions_Child] ([Region_ID1], [Region_Child_Name], [IsActive]) VALUES (4, N'Hero of Limburg', 1)
INSERT [dbo].[4_Regions_Child] ([Region_ID1], [Region_Child_Name], [IsActive]) VALUES (5, N'Hero of North Holland', 1)
INSERT [dbo].[4_Regions_Child] ([Region_ID1], [Region_Child_Name], [IsActive]) VALUES (6, N'Hero of South Holland', 1)
INSERT [dbo].[4_Regions_Child] ([Region_ID1], [Region_Child_Name], [IsActive]) VALUES (7, N'Hero of Bern', 1)
INSERT [dbo].[4_Regions_Child] ([Region_ID1], [Region_Child_Name], [IsActive]) VALUES (8, N'Hero of Genève', 1)
INSERT [dbo].[4_Regions_Child] ([Region_ID1], [Region_Child_Name], [IsActive]) VALUES (9, N'Hero of Zurich', 1)
INSERT [dbo].[4_Regions_Child] ([Region_ID1], [Region_Child_Name], [IsActive]) VALUES (10, N'Hero of Luanda', 1)
INSERT [dbo].[4_Regions_Child] ([Region_ID1], [Region_Child_Name], [IsActive]) VALUES (11, N'Hero of Huambo', 1)
INSERT [dbo].[4_Regions_Child] ([Region_ID1], [Region_Child_Name], [IsActive]) VALUES (12, N'Hero of Huíla', 1)
INSERT [dbo].[4_Regions_Child] ([Region_ID1], [Region_Child_Name], [IsActive]) VALUES (13, N'Hero of Maputo', 1)
INSERT [dbo].[4_Regions_Child] ([Region_ID1], [Region_Child_Name], [IsActive]) VALUES (14, N'Hero of Beira', 1)
INSERT [dbo].[4_Regions_Child] ([Region_ID1], [Region_Child_Name], [IsActive]) VALUES (15, N'Hero of Nampula', 1)
INSERT [dbo].[4_Regions_Child] ([Region_ID1], [Region_Child_Name], [IsActive]) VALUES (16, N'Humphrey Bogart', 1)
INSERT [dbo].[4_Regions_Child] ([Region_ID1], [Region_Child_Name], [IsActive]) VALUES (17, N'Hero of Marrakesh', 1)
INSERT [dbo].[4_Regions_Child] ([Region_ID1], [Region_Child_Name], [IsActive]) VALUES (18, N'Hero of Rabat', 1)
INSERT [dbo].[4_Regions_Child] ([Region_ID1], [Region_Child_Name], [IsActive]) VALUES (19, N'Hero of Rio', 1)
INSERT [dbo].[4_Regions_Child] ([Region_ID1], [Region_Child_Name], [IsActive]) VALUES (20, N'Hero of Olinda', 1)
INSERT [dbo].[4_Regions_Child] ([Region_ID1], [Region_Child_Name], [IsActive]) VALUES (21, N'Hero of Pernanbuco', 1)
INSERT [dbo].[4_Regions_Child] ([Region_ID1], [Region_Child_Name], [IsActive]) VALUES (22, N'John Sutter', 1)
INSERT [dbo].[4_Regions_Child] ([Region_ID1], [Region_Child_Name], [IsActive]) VALUES (23, N'Louis XIV', 1)
INSERT [dbo].[4_Regions_Child] ([Region_ID1], [Region_Child_Name], [IsActive]) VALUES (24, N'David Crockett', 1)
INSERT [dbo].[4_Regions_Child] ([Region_ID1], [Region_Child_Name], [IsActive]) VALUES (25, N'Hero of Buenos Aires', 1)
INSERT [dbo].[4_Regions_Child] ([Region_ID1], [Region_Child_Name], [IsActive]) VALUES (26, N'Hero of Mendoza', 1)
INSERT [dbo].[4_Regions_Child] ([Region_ID1], [Region_Child_Name], [IsActive]) VALUES (27, N'Hero of Tucumán', 1)
/****** Object:  Table [dbo].[4_Regions_ReChild]    Script Date: 01/13/2013 15:48:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[4_Regions_ReChild](
	[Region_ID2] [int] NOT NULL,
	[Region_Child_Name] [varchar](50) COLLATE Latin1_General_CI_AI NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Regions_ReChild] PRIMARY KEY CLUSTERED 
(
	[Region_ID2] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[4_Regions_ReChild] ([Region_ID2], [Region_Child_Name], [IsActive]) VALUES (1, N'Centro people', 1)
INSERT [dbo].[4_Regions_ReChild] ([Region_ID2], [Region_Child_Name], [IsActive]) VALUES (2, N'Norte people', 1)
INSERT [dbo].[4_Regions_ReChild] ([Region_ID2], [Region_Child_Name], [IsActive]) VALUES (3, N'Sul people', 1)
INSERT [dbo].[4_Regions_ReChild] ([Region_ID2], [Region_Child_Name], [IsActive]) VALUES (4, N'Limburgers', 1)
INSERT [dbo].[4_Regions_ReChild] ([Region_ID2], [Region_Child_Name], [IsActive]) VALUES (5, N'North Hollanders', 1)
INSERT [dbo].[4_Regions_ReChild] ([Region_ID2], [Region_Child_Name], [IsActive]) VALUES (6, N'South Hollanders', 1)
INSERT [dbo].[4_Regions_ReChild] ([Region_ID2], [Region_Child_Name], [IsActive]) VALUES (7, N'Bern people', 1)
INSERT [dbo].[4_Regions_ReChild] ([Region_ID2], [Region_Child_Name], [IsActive]) VALUES (8, N'Genève people', 1)
INSERT [dbo].[4_Regions_ReChild] ([Region_ID2], [Region_Child_Name], [IsActive]) VALUES (9, N'Zurich people', 1)
INSERT [dbo].[4_Regions_ReChild] ([Region_ID2], [Region_Child_Name], [IsActive]) VALUES (10, N'Luanda people', 1)
INSERT [dbo].[4_Regions_ReChild] ([Region_ID2], [Region_Child_Name], [IsActive]) VALUES (11, N'Huambo people', 1)
INSERT [dbo].[4_Regions_ReChild] ([Region_ID2], [Region_Child_Name], [IsActive]) VALUES (12, N'Huíla people', 1)
INSERT [dbo].[4_Regions_ReChild] ([Region_ID2], [Region_Child_Name], [IsActive]) VALUES (13, N'Maputo people', 1)
INSERT [dbo].[4_Regions_ReChild] ([Region_ID2], [Region_Child_Name], [IsActive]) VALUES (14, N'Beira people', 1)
INSERT [dbo].[4_Regions_ReChild] ([Region_ID2], [Region_Child_Name], [IsActive]) VALUES (15, N'Nampula people', 1)
INSERT [dbo].[4_Regions_ReChild] ([Region_ID2], [Region_Child_Name], [IsActive]) VALUES (16, N'Casablanca people', 1)
INSERT [dbo].[4_Regions_ReChild] ([Region_ID2], [Region_Child_Name], [IsActive]) VALUES (17, N'Marrakesh people', 1)
INSERT [dbo].[4_Regions_ReChild] ([Region_ID2], [Region_Child_Name], [IsActive]) VALUES (18, N'Rabat people', 1)
INSERT [dbo].[4_Regions_ReChild] ([Region_ID2], [Region_Child_Name], [IsActive]) VALUES (19, N'Cariocas', 1)
INSERT [dbo].[4_Regions_ReChild] ([Region_ID2], [Region_Child_Name], [IsActive]) VALUES (20, N'Olinda people', 1)
INSERT [dbo].[4_Regions_ReChild] ([Region_ID2], [Region_Child_Name], [IsActive]) VALUES (21, N'Pernanbuco people', 1)
INSERT [dbo].[4_Regions_ReChild] ([Region_ID2], [Region_Child_Name], [IsActive]) VALUES (22, N'Californians', 1)
INSERT [dbo].[4_Regions_ReChild] ([Region_ID2], [Region_Child_Name], [IsActive]) VALUES (23, N'Louisians', 1)
INSERT [dbo].[4_Regions_ReChild] ([Region_ID2], [Region_Child_Name], [IsActive]) VALUES (24, N'Texans', 1)
INSERT [dbo].[4_Regions_ReChild] ([Region_ID2], [Region_Child_Name], [IsActive]) VALUES (25, N'Buenos Aires people', 1)
INSERT [dbo].[4_Regions_ReChild] ([Region_ID2], [Region_Child_Name], [IsActive]) VALUES (26, N'Mendoza people', 1)
INSERT [dbo].[4_Regions_ReChild] ([Region_ID2], [Region_Child_Name], [IsActive]) VALUES (27, N'Tucumán  people', 1)
/****** Object:  Table [dbo].[5_Cities]    Script Date: 01/13/2013 15:48:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[5_Cities](
	[City_ID] [int] IDENTITY(1,1) NOT NULL,
	[City_Name] [varchar](50) COLLATE Latin1_General_CI_AI NOT NULL,
	[Parent_Region_ID] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Cities] PRIMARY KEY CLUSTERED 
(
	[City_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[5_Cities] ON
INSERT [dbo].[5_Cities] ([City_ID], [City_Name], [Parent_Region_ID], [IsActive]) VALUES (1, N'Lisboa', 1, 1)
INSERT [dbo].[5_Cities] ([City_ID], [City_Name], [Parent_Region_ID], [IsActive]) VALUES (2, N'Porto', 2, 1)
INSERT [dbo].[5_Cities] ([City_ID], [City_Name], [Parent_Region_ID], [IsActive]) VALUES (3, N'Setúbal', 1, 1)
INSERT [dbo].[5_Cities] ([City_ID], [City_Name], [Parent_Region_ID], [IsActive]) VALUES (4, N'Amsterdam', 5, 1)
INSERT [dbo].[5_Cities] ([City_ID], [City_Name], [Parent_Region_ID], [IsActive]) VALUES (5, N'Roterdam', 6, 1)
INSERT [dbo].[5_Cities] ([City_ID], [City_Name], [Parent_Region_ID], [IsActive]) VALUES (6, N'Den Haag', 6, 1)
INSERT [dbo].[5_Cities] ([City_ID], [City_Name], [Parent_Region_ID], [IsActive]) VALUES (7, N'Bern', 7, 1)
INSERT [dbo].[5_Cities] ([City_ID], [City_Name], [Parent_Region_ID], [IsActive]) VALUES (8, N'Genève', 8, 1)
INSERT [dbo].[5_Cities] ([City_ID], [City_Name], [Parent_Region_ID], [IsActive]) VALUES (9, N'Zurich', 9, 1)
INSERT [dbo].[5_Cities] ([City_ID], [City_Name], [Parent_Region_ID], [IsActive]) VALUES (10, N'Luanda', 10, 1)
INSERT [dbo].[5_Cities] ([City_ID], [City_Name], [Parent_Region_ID], [IsActive]) VALUES (11, N'Huambo', 11, 1)
INSERT [dbo].[5_Cities] ([City_ID], [City_Name], [Parent_Region_ID], [IsActive]) VALUES (12, N'Lubango', 12, 1)
INSERT [dbo].[5_Cities] ([City_ID], [City_Name], [Parent_Region_ID], [IsActive]) VALUES (13, N'Maputo', 13, 1)
INSERT [dbo].[5_Cities] ([City_ID], [City_Name], [Parent_Region_ID], [IsActive]) VALUES (14, N'Beira', 14, 1)
INSERT [dbo].[5_Cities] ([City_ID], [City_Name], [Parent_Region_ID], [IsActive]) VALUES (15, N'Nampula', 15, 1)
INSERT [dbo].[5_Cities] ([City_ID], [City_Name], [Parent_Region_ID], [IsActive]) VALUES (16, N'Casablanca', 16, 1)
INSERT [dbo].[5_Cities] ([City_ID], [City_Name], [Parent_Region_ID], [IsActive]) VALUES (17, N'Marrakesh', 17, 1)
INSERT [dbo].[5_Cities] ([City_ID], [City_Name], [Parent_Region_ID], [IsActive]) VALUES (18, N'Rabat', 18, 1)
INSERT [dbo].[5_Cities] ([City_ID], [City_Name], [Parent_Region_ID], [IsActive]) VALUES (19, N'Rio de Janeiro', 19, 1)
INSERT [dbo].[5_Cities] ([City_ID], [City_Name], [Parent_Region_ID], [IsActive]) VALUES (20, N'Olinda', 20, 1)
INSERT [dbo].[5_Cities] ([City_ID], [City_Name], [Parent_Region_ID], [IsActive]) VALUES (21, N'Pernanbuco', 21, 1)
INSERT [dbo].[5_Cities] ([City_ID], [City_Name], [Parent_Region_ID], [IsActive]) VALUES (22, N'S. Francisco', 22, 1)
INSERT [dbo].[5_Cities] ([City_ID], [City_Name], [Parent_Region_ID], [IsActive]) VALUES (23, N'Los Angeles', 22, 1)
INSERT [dbo].[5_Cities] ([City_ID], [City_Name], [Parent_Region_ID], [IsActive]) VALUES (24, N'Houston', 24, 1)
INSERT [dbo].[5_Cities] ([City_ID], [City_Name], [Parent_Region_ID], [IsActive]) VALUES (25, N'Buenos Aires', 25, 1)
INSERT [dbo].[5_Cities] ([City_ID], [City_Name], [Parent_Region_ID], [IsActive]) VALUES (26, N'Mendoza', 26, 1)
INSERT [dbo].[5_Cities] ([City_ID], [City_Name], [Parent_Region_ID], [IsActive]) VALUES (27, N'San Miguel de Tucumán', 27, 1)
SET IDENTITY_INSERT [dbo].[5_Cities] OFF
/****** Object:  Table [dbo].[6_CityRoads]    Script Date: 01/13/2013 15:48:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[6_CityRoads](
	[CityRoad_ID] [int] IDENTITY(1,1) NOT NULL,
	[CityRoad_Name] [varchar](50) COLLATE Latin1_General_CI_AI NOT NULL,
	[Parent_City_ID] [int] NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_CityRoads] PRIMARY KEY CLUSTERED 
(
	[CityRoad_ID] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
SET IDENTITY_INSERT [dbo].[6_CityRoads] ON
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (1, N'Street 1 of Lisboa', 1, 0)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (2, N'Avenue 2 of Lisboa', 1, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (3, N'Square 3 of Lisboa', 1, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (4, N'Street 1 of Porto', 2, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (5, N'Avenue 2 of Porto', 2, 0)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (6, N'Square 3 of Porto', 2, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (7, N'Street 1 of Setúbal', 3, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (8, N'Avenue 2 of Setúbal', 3, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (9, N'Square 3 of Setúbal', 3, 0)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (10, N'Street 1 of Amsterdam', 4, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (11, N'Avenue 2 of Amsterdam', 4, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (12, N'Square 3 of Amsterdam', 4, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (13, N'Street 1 of Roterdam', 5, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (14, N'Avenue 2 of Roterdam', 5, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (15, N'Square 3 of Roterdam', 5, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (16, N'Street 1 of Den Haag', 6, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (17, N'Avenue 2 of Den Haag', 6, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (18, N'Square 3 of Den Haag', 6, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (19, N'Street 1 of Bern', 7, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (20, N'Avenue 2 of Bern', 7, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (21, N'Square 3 of Bern', 7, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (22, N'Street 1 of Genève', 8, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (23, N'Avenue 2 of Genève', 8, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (24, N'Square 3 of Genève', 8, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (25, N'Street 1 of Zurich', 9, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (26, N'Avenue 2 of Zurich', 9, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (27, N'Square 3 of Zurich', 9, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (28, N'Street 1 of Luanda', 10, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (29, N'Avenue 2 of Luanda', 10, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (30, N'Square 3 of Luanda', 10, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (31, N'Street 1 of Huambo', 11, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (32, N'Avenue 2 of Huambo', 11, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (33, N'Square 3 of Huambo', 11, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (34, N'Street 1 of Lubango', 12, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (35, N'Avenue 2 of Lubango', 12, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (36, N'Square 3 of Lubango', 12, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (37, N'Street 1 of Maputo', 13, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (38, N'Avenue 2 of Maputo', 13, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (39, N'Square 3 of Maputo', 13, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (40, N'Street 1 of Beira', 14, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (41, N'Avenue 2 of Beira', 14, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (42, N'Square 3 of Beira', 14, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (43, N'Street 1 of Nampula', 15, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (44, N'Avenue 2 of Nampula', 15, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (45, N'Square 3 of Nampula', 15, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (46, N'Street 1 of Casablanca', 16, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (47, N'Avenue 2 of Casablanca', 16, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (48, N'Square 3 of Casablanca', 16, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (49, N'Street 1 of Marrakesh', 17, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (50, N'Avenue 2 of Marrakesh', 17, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (51, N'Square 3 of Marrakesh', 17, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (52, N'Street 1 of Rabat', 18, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (53, N'Avenue 2 of Rabat', 18, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (54, N'Square 3 of Rabat', 18, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (55, N'Street 1 of Rio of Janeiro', 19, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (56, N'Avenue 2 of Rio of Janeiro', 19, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (57, N'Square 3 of Rio of Janeiro', 19, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (58, N'Street 1 of Olinda', 20, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (59, N'Avenue 2 of Olinda', 20, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (60, N'Square 3 of Olinda', 20, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (61, N'Street 1 of Pernanbuco', 21, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (62, N'Avenue 2 of Pernanbuco', 21, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (63, N'Square 3 of Pernanbuco', 21, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (64, N'Street 1 of S. Francisco', 22, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (65, N'Avenue 2 of S. Francisco', 22, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (66, N'Square 3 of S. Francisco', 22, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (67, N'Street 1 of St. Louis', 23, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (68, N'Avenue 2 of St. Louis', 23, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (69, N'Square 3 of St. Louis', 23, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (70, N'Street 1 of Houston', 24, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (71, N'Avenue 2 of Houston', 24, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (72, N'Square 3 of Houston', 24, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (73, N'Street 1 of Buenos Aires', 25, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (74, N'Avenue 2 of Buenos Aires', 25, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (75, N'Square 3 of Buenos Aires', 25, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (76, N'Street 1 of Mendoza', 26, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (77, N'Avenue 2 of Mendoza', 26, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (78, N'Square 3 of Mendoza', 26, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (79, N'Street 1 of San Miguel of Tucumán', 27, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (80, N'Avenue 2 of San Miguel of Tucumán', 27, 1)
INSERT [dbo].[6_CityRoads] ([CityRoad_ID], [CityRoad_Name], [Parent_City_ID], [IsActive]) VALUES (81, N'Square 3 of San Miguel of Tucumán', 27, 1)
SET IDENTITY_INSERT [dbo].[6_CityRoads] OFF
/****** Object:  Table [dbo].[5_Cities_Child]    Script Date: 01/13/2013 15:48:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[5_Cities_Child](
	[City_ID1] [int] NOT NULL,
	[City_Child_Name] [varchar](50) COLLATE Latin1_General_CI_AI NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Cities_Child] PRIMARY KEY CLUSTERED 
(
	[City_ID1] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[5_Cities_Child] ([City_ID1], [City_Child_Name], [IsActive]) VALUES (1, N'Fernando Pessoa', 1)
INSERT [dbo].[5_Cities_Child] ([City_ID1], [City_Child_Name], [IsActive]) VALUES (2, N'Hero of Porto', 1)
INSERT [dbo].[5_Cities_Child] ([City_ID1], [City_Child_Name], [IsActive]) VALUES (3, N'Bocage', 1)
INSERT [dbo].[5_Cities_Child] ([City_ID1], [City_Child_Name], [IsActive]) VALUES (4, N'Rembrandt', 1)
INSERT [dbo].[5_Cities_Child] ([City_ID1], [City_Child_Name], [IsActive]) VALUES (5, N'Erasmus Roterodamus', 1)
INSERT [dbo].[5_Cities_Child] ([City_ID1], [City_Child_Name], [IsActive]) VALUES (6, N'Willem van Oranje', 1)
INSERT [dbo].[5_Cities_Child] ([City_ID1], [City_Child_Name], [IsActive]) VALUES (7, N'Hero of Bern', 1)
INSERT [dbo].[5_Cities_Child] ([City_ID1], [City_Child_Name], [IsActive]) VALUES (8, N'Hero of Genève', 1)
INSERT [dbo].[5_Cities_Child] ([City_ID1], [City_Child_Name], [IsActive]) VALUES (9, N'Hero of Zurich', 1)
INSERT [dbo].[5_Cities_Child] ([City_ID1], [City_Child_Name], [IsActive]) VALUES (10, N'Hero of Luanda', 1)
INSERT [dbo].[5_Cities_Child] ([City_ID1], [City_Child_Name], [IsActive]) VALUES (11, N'Hero of Humabo', 1)
INSERT [dbo].[5_Cities_Child] ([City_ID1], [City_Child_Name], [IsActive]) VALUES (12, N'Hero of Lubango', 1)
INSERT [dbo].[5_Cities_Child] ([City_ID1], [City_Child_Name], [IsActive]) VALUES (13, N'Hero of Maputo', 1)
INSERT [dbo].[5_Cities_Child] ([City_ID1], [City_Child_Name], [IsActive]) VALUES (14, N'Hero of Beira', 1)
INSERT [dbo].[5_Cities_Child] ([City_ID1], [City_Child_Name], [IsActive]) VALUES (15, N'Hero of Nampula', 1)
INSERT [dbo].[5_Cities_Child] ([City_ID1], [City_Child_Name], [IsActive]) VALUES (16, N'Humphrey Bogart', 1)
INSERT [dbo].[5_Cities_Child] ([City_ID1], [City_Child_Name], [IsActive]) VALUES (17, N'Hero of Marrakesh', 1)
INSERT [dbo].[5_Cities_Child] ([City_ID1], [City_Child_Name], [IsActive]) VALUES (18, N'Mohamed IV', 1)
INSERT [dbo].[5_Cities_Child] ([City_ID1], [City_Child_Name], [IsActive]) VALUES (19, N'Hero of Rio de Janeiro', 1)
INSERT [dbo].[5_Cities_Child] ([City_ID1], [City_Child_Name], [IsActive]) VALUES (20, N'Hero of Olinda', 1)
INSERT [dbo].[5_Cities_Child] ([City_ID1], [City_Child_Name], [IsActive]) VALUES (21, N'Hero of Pernanbuco', 1)
INSERT [dbo].[5_Cities_Child] ([City_ID1], [City_Child_Name], [IsActive]) VALUES (22, N'John Sutter', 1)
INSERT [dbo].[5_Cities_Child] ([City_ID1], [City_Child_Name], [IsActive]) VALUES (23, N'Hero of Los Angeles', 1)
INSERT [dbo].[5_Cities_Child] ([City_ID1], [City_Child_Name], [IsActive]) VALUES (24, N'Hero of Houston', 1)
INSERT [dbo].[5_Cities_Child] ([City_ID1], [City_Child_Name], [IsActive]) VALUES (25, N'Founder of Buenos Aires', 1)
INSERT [dbo].[5_Cities_Child] ([City_ID1], [City_Child_Name], [IsActive]) VALUES (26, N'Hero of Mendoza', 1)
INSERT [dbo].[5_Cities_Child] ([City_ID1], [City_Child_Name], [IsActive]) VALUES (27, N'Mayor of Tucumán', 1)
/****** Object:  Table [dbo].[5_Cities_ReChild]    Script Date: 01/13/2013 15:48:24 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
SET ANSI_PADDING ON
GO
CREATE TABLE [dbo].[5_Cities_ReChild](
	[City_ID2] [int] NOT NULL,
	[City_Child_Name] [varchar](50) COLLATE Latin1_General_CI_AI NOT NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Cities_ReChild] PRIMARY KEY CLUSTERED 
(
	[City_ID2] ASC
)WITH (PAD_INDEX  = OFF, STATISTICS_NORECOMPUTE  = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS  = ON, ALLOW_PAGE_LOCKS  = ON) ON [PRIMARY]
) ON [PRIMARY]
GO
SET ANSI_PADDING OFF
GO
INSERT [dbo].[5_Cities_ReChild] ([City_ID2], [City_Child_Name], [IsActive]) VALUES (1, N'Lisboa people', 1)
INSERT [dbo].[5_Cities_ReChild] ([City_ID2], [City_Child_Name], [IsActive]) VALUES (2, N'Porto people', 1)
INSERT [dbo].[5_Cities_ReChild] ([City_ID2], [City_Child_Name], [IsActive]) VALUES (3, N'Setúbal people', 1)
INSERT [dbo].[5_Cities_ReChild] ([City_ID2], [City_Child_Name], [IsActive]) VALUES (4, N'Amsterdamers', 1)
INSERT [dbo].[5_Cities_ReChild] ([City_ID2], [City_Child_Name], [IsActive]) VALUES (5, N'Roterdamers', 1)
INSERT [dbo].[5_Cities_ReChild] ([City_ID2], [City_Child_Name], [IsActive]) VALUES (6, N'Den Haag people', 1)
INSERT [dbo].[5_Cities_ReChild] ([City_ID2], [City_Child_Name], [IsActive]) VALUES (7, N'Bernians', 1)
INSERT [dbo].[5_Cities_ReChild] ([City_ID2], [City_Child_Name], [IsActive]) VALUES (8, N'Genevesers', 1)
INSERT [dbo].[5_Cities_ReChild] ([City_ID2], [City_Child_Name], [IsActive]) VALUES (9, N'Zurichers', 1)
INSERT [dbo].[5_Cities_ReChild] ([City_ID2], [City_Child_Name], [IsActive]) VALUES (10, N'Luanders', 1)
INSERT [dbo].[5_Cities_ReChild] ([City_ID2], [City_Child_Name], [IsActive]) VALUES (11, N'Huambo people', 1)
INSERT [dbo].[5_Cities_ReChild] ([City_ID2], [City_Child_Name], [IsActive]) VALUES (12, N'Lubango people', 1)
INSERT [dbo].[5_Cities_ReChild] ([City_ID2], [City_Child_Name], [IsActive]) VALUES (13, N'Maputo people', 1)
INSERT [dbo].[5_Cities_ReChild] ([City_ID2], [City_Child_Name], [IsActive]) VALUES (14, N'Beira people', 1)
INSERT [dbo].[5_Cities_ReChild] ([City_ID2], [City_Child_Name], [IsActive]) VALUES (15, N'Nampulers', 1)
INSERT [dbo].[5_Cities_ReChild] ([City_ID2], [City_Child_Name], [IsActive]) VALUES (16, N'Casablanquers', 1)
INSERT [dbo].[5_Cities_ReChild] ([City_ID2], [City_Child_Name], [IsActive]) VALUES (17, N'Marrakesh people', 1)
INSERT [dbo].[5_Cities_ReChild] ([City_ID2], [City_Child_Name], [IsActive]) VALUES (18, N'Rabat people', 1)
INSERT [dbo].[5_Cities_ReChild] ([City_ID2], [City_Child_Name], [IsActive]) VALUES (19, N'Cariocas', 1)
INSERT [dbo].[5_Cities_ReChild] ([City_ID2], [City_Child_Name], [IsActive]) VALUES (20, N'Olinda people', 1)
INSERT [dbo].[5_Cities_ReChild] ([City_ID2], [City_Child_Name], [IsActive]) VALUES (21, N'Pernanbuco people ', 1)
INSERT [dbo].[5_Cities_ReChild] ([City_ID2], [City_Child_Name], [IsActive]) VALUES (22, N'Friscos', 1)
INSERT [dbo].[5_Cities_ReChild] ([City_ID2], [City_Child_Name], [IsActive]) VALUES (23, N'Angels', 1)
INSERT [dbo].[5_Cities_ReChild] ([City_ID2], [City_Child_Name], [IsActive]) VALUES (24, N'Houstonians', 1)
INSERT [dbo].[5_Cities_ReChild] ([City_ID2], [City_Child_Name], [IsActive]) VALUES (25, N'Buenos Aires people', 1)
INSERT [dbo].[5_Cities_ReChild] ([City_ID2], [City_Child_Name], [IsActive]) VALUES (26, N'Mendoza people', 1)
INSERT [dbo].[5_Cities_ReChild] ([City_ID2], [City_Child_Name], [IsActive]) VALUES (27, N'Tucumán people', 1)
/****** Object:  StoredProcedure [dbo].[DeleteA04_SubContinent]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteA04_SubContinent]
    @SubContinent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID] FROM [2_SubContinents]
            WHERE
                [SubContinent_ID] = @SubContinent_ID
        )
        BEGIN
            RAISERROR ('''A04_SubContinent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete child A12_CityRoad from 6_CityRoads */
        DELETE
            [6_CityRoads]
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child A11_City_ReChild from 5_Cities_ReChild */
        DELETE
            [5_Cities_ReChild]
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child A11_City_Child from 5_Cities_Child */
        DELETE
            [5_Cities_Child]
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child A10_City from 5_Cities */
        DELETE
            [5_Cities]
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child A09_Region_ReChild from 4_Regions_ReChild */
        DELETE
            [4_Regions_ReChild]
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child A09_Region_Child from 4_Regions_Child */
        DELETE
            [4_Regions_Child]
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child A08_Region from 4_Regions */
        DELETE
            [4_Regions]
        FROM [4_Regions]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child A07_Country_ReChild from 3_Countries_ReChild */
        DELETE
            [3_Countries_ReChild]
        FROM [3_Countries_ReChild]
            INNER JOIN [3_Countries] ON [3_Countries_ReChild].[Country_ID2] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child A07_Country_Child from 3_Countries_Child */
        DELETE
            [3_Countries_Child]
        FROM [3_Countries_Child]
            INNER JOIN [3_Countries] ON [3_Countries_Child].[Country_ID1] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child A06_Country from 3_Countries */
        DELETE
            [3_Countries]
        FROM [3_Countries]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child A05_SubContinent_ReChild from 2_SubContinents_ReChild */
        DELETE
            [2_SubContinents_ReChild]
        FROM [2_SubContinents_ReChild]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_ReChild].[SubContinent_ID2] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child A05_SubContinent_Child from 2_SubContinents_Child */
        DELETE
            [2_SubContinents_Child]
        FROM [2_SubContinents_Child]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_Child].[SubContinent_ID1] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete A04_SubContinent object from 2_SubContinents */
        DELETE
        FROM [2_SubContinents]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddA04_SubContinent]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddA04_SubContinent]
    @SubContinent_ID int OUTPUT,
    @Continent_ID int,
    @SubContinent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 2_SubContinents */
        INSERT INTO [2_SubContinents]
        (
            [Parent_Continent_ID],
            [SubContinent_Name]
        )
        VALUES
        (
            @Continent_ID,
            @SubContinent_Name
        )

        /* Return new primary key */
        SET @SubContinent_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateA04_SubContinent]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateA04_SubContinent]
    @SubContinent_ID int,
    @SubContinent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID] FROM [2_SubContinents]
            WHERE
                [SubContinent_ID] = @SubContinent_ID
        )
        BEGIN
            RAISERROR ('''A04_SubContinent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 2_SubContinents */
        UPDATE [2_SubContinents]
        SET
            [SubContinent_Name] = @SubContinent_Name
        WHERE
            [SubContinent_ID] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteF02_Continent]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteF02_Continent]
    @Continent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID] FROM [1_Continents]
            WHERE
                [Continent_ID] = @Continent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F02_Continent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark child F12_CityRoad as not active */
        UPDATE [6_CityRoads]
        SET    [IsActive] = 'false'
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child F11_City_ReChild as not active */
        UPDATE [5_Cities_ReChild]
        SET    [IsActive] = 'false'
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child F11_City_Child as not active */
        UPDATE [5_Cities_Child]
        SET    [IsActive] = 'false'
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child F10_City as not active */
        UPDATE [5_Cities]
        SET    [IsActive] = 'false'
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child F09_Region_ReChild as not active */
        UPDATE [4_Regions_ReChild]
        SET    [IsActive] = 'false'
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child F09_Region_Child as not active */
        UPDATE [4_Regions_Child]
        SET    [IsActive] = 'false'
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child F08_Region as not active */
        UPDATE [4_Regions]
        SET    [IsActive] = 'false'
        FROM [4_Regions]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child F07_Country_ReChild as not active */
        UPDATE [3_Countries_ReChild]
        SET    [IsActive] = 'false'
        FROM [3_Countries_ReChild]
            INNER JOIN [3_Countries] ON [3_Countries_ReChild].[Country_ID2] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child F07_Country_Child as not active */
        UPDATE [3_Countries_Child]
        SET    [IsActive] = 'false'
        FROM [3_Countries_Child]
            INNER JOIN [3_Countries] ON [3_Countries_Child].[Country_ID1] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child F06_Country as not active */
        UPDATE [3_Countries]
        SET    [IsActive] = 'false'
        FROM [3_Countries]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child F05_SubContinent_ReChild as not active */
        UPDATE [2_SubContinents_ReChild]
        SET    [IsActive] = 'false'
        FROM [2_SubContinents_ReChild]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_ReChild].[SubContinent_ID2] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child F05_SubContinent_Child as not active */
        UPDATE [2_SubContinents_Child]
        SET    [IsActive] = 'false'
        FROM [2_SubContinents_Child]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_Child].[SubContinent_ID1] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child F04_SubContinent as not active */
        UPDATE [2_SubContinents]
        SET    [IsActive] = 'false'
        FROM [2_SubContinents]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child F03_Continent_ReChild as not active */
        UPDATE [1_Continents_ReChild]
        SET    [IsActive] = 'false'
        FROM [1_Continents_ReChild]
            INNER JOIN [1_Continents] ON [1_Continents_ReChild].[Continent_ID2] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child F03_Continent_Child as not active */
        UPDATE [1_Continents_Child]
        SET    [IsActive] = 'false'
        FROM [1_Continents_Child]
            INNER JOIN [1_Continents] ON [1_Continents_Child].[Continent_ID1] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark F02_Continent object as not active */
        UPDATE [1_Continents]
        SET    [IsActive] = 'false'
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetF01_ContinentColl]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetF01_ContinentColl]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get F02_Continent from table */
        SELECT
            [1_Continents].[Continent_ID],
            [1_Continents].[Continent_Name]
        FROM [1_Continents]
        WHERE
            [1_Continents].[IsActive] = 'true'

        /* Get F03_Continent_Child from table */
        SELECT
            [1_Continents_Child].[Continent_ID1],
            [1_Continents_Child].[Continent_Child_Name]
        FROM [1_Continents_Child]
        WHERE
            [1_Continents_Child].[IsActive] = 'true'

        /* Get F03_Continent_ReChild from table */
        SELECT
            [1_Continents_ReChild].[Continent_ID2],
            [1_Continents_ReChild].[Continent_Child_Name]
        FROM [1_Continents_ReChild]
        WHERE
            [1_Continents_ReChild].[IsActive] = 'true'

        /* Get F04_SubContinent from table */
        SELECT
            [2_SubContinents].[Parent_Continent_ID],
            [2_SubContinents].[SubContinent_ID],
            [2_SubContinents].[SubContinent_Name]
        FROM [2_SubContinents]
        WHERE
            [2_SubContinents].[IsActive] = 'true'

        /* Get F05_SubContinent_Child from table */
        SELECT
            [2_SubContinents_Child].[SubContinent_ID1],
            [2_SubContinents_Child].[SubContinent_Child_Name]
        FROM [2_SubContinents_Child]
        WHERE
            [2_SubContinents_Child].[IsActive] = 'true'

        /* Get F05_SubContinent_ReChild from table */
        SELECT
            [2_SubContinents_ReChild].[SubContinent_ID2],
            [2_SubContinents_ReChild].[SubContinent_Child_Name]
        FROM [2_SubContinents_ReChild]
        WHERE
            [2_SubContinents_ReChild].[IsActive] = 'true'

        /* Get F06_Country from table */
        SELECT
            [3_Countries].[Parent_SubContinent_ID],
            [3_Countries].[Country_ID],
            [3_Countries].[Country_Name]
        FROM [3_Countries]
        WHERE
            [3_Countries].[IsActive] = 'true'

        /* Get F07_Country_Child from table */
        SELECT
            [3_Countries_Child].[Country_ID1],
            [3_Countries_Child].[Country_Child_Name]
        FROM [3_Countries_Child]
        WHERE
            [3_Countries_Child].[IsActive] = 'true'

        /* Get F07_Country_ReChild from table */
        SELECT
            [3_Countries_ReChild].[Country_ID2],
            [3_Countries_ReChild].[Country_Child_Name]
        FROM [3_Countries_ReChild]
        WHERE
            [3_Countries_ReChild].[IsActive] = 'true'

        /* Get F08_Region from table */
        SELECT
            [4_Regions].[Parent_Country_ID],
            [4_Regions].[Region_ID],
            [4_Regions].[Region_Name]
        FROM [4_Regions]
        WHERE
            [4_Regions].[IsActive] = 'true'

        /* Get F09_Region_Child from table */
        SELECT
            [4_Regions_Child].[Region_ID1],
            [4_Regions_Child].[Region_Child_Name]
        FROM [4_Regions_Child]
        WHERE
            [4_Regions_Child].[IsActive] = 'true'

        /* Get F09_Region_ReChild from table */
        SELECT
            [4_Regions_ReChild].[Region_ID2],
            [4_Regions_ReChild].[Region_Child_Name]
        FROM [4_Regions_ReChild]
        WHERE
            [4_Regions_ReChild].[IsActive] = 'true'

        /* Get F10_City from table */
        SELECT
            [5_Cities].[Parent_Region_ID],
            [5_Cities].[City_ID],
            [5_Cities].[City_Name]
        FROM [5_Cities]
        WHERE
            [5_Cities].[IsActive] = 'true'

        /* Get F11_City_Child from table */
        SELECT
            [5_Cities_Child].[City_ID1],
            [5_Cities_Child].[City_Child_Name]
        FROM [5_Cities_Child]
        WHERE
            [5_Cities_Child].[IsActive] = 'true'

        /* Get F11_City_ReChild from table */
        SELECT
            [5_Cities_ReChild].[City_ID2],
            [5_Cities_ReChild].[City_Child_Name]
        FROM [5_Cities_ReChild]
        WHERE
            [5_Cities_ReChild].[IsActive] = 'true'

        /* Get F12_CityRoad from table */
        SELECT
            [6_CityRoads].[Parent_City_ID],
            [6_CityRoads].[CityRoad_ID],
            [6_CityRoads].[CityRoad_Name]
        FROM [6_CityRoads]
        WHERE
            [6_CityRoads].[IsActive] = 'true'

    END
GO
/****** Object:  StoredProcedure [dbo].[AddF04_SubContinent]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddF04_SubContinent]
    @SubContinent_ID int OUTPUT,
    @Continent_ID int,
    @SubContinent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 2_SubContinents */
        INSERT INTO [2_SubContinents]
        (
            [Parent_Continent_ID],
            [SubContinent_Name]
        )
        VALUES
        (
            @Continent_ID,
            @SubContinent_Name
        )

        /* Return new primary key */
        SET @SubContinent_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateF04_SubContinent]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateF04_SubContinent]
    @SubContinent_ID int,
    @SubContinent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID] FROM [2_SubContinents]
            WHERE
                [SubContinent_ID] = @SubContinent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F04_SubContinent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 2_SubContinents */
        UPDATE [2_SubContinents]
        SET
            [SubContinent_Name] = @SubContinent_Name
        WHERE
            [SubContinent_ID] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteF04_SubContinent]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteF04_SubContinent]
    @SubContinent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID] FROM [2_SubContinents]
            WHERE
                [SubContinent_ID] = @SubContinent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F04_SubContinent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark child F12_CityRoad as not active */
        UPDATE [6_CityRoads]
        SET    [IsActive] = 'false'
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child F11_City_ReChild as not active */
        UPDATE [5_Cities_ReChild]
        SET    [IsActive] = 'false'
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child F11_City_Child as not active */
        UPDATE [5_Cities_Child]
        SET    [IsActive] = 'false'
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child F10_City as not active */
        UPDATE [5_Cities]
        SET    [IsActive] = 'false'
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child F09_Region_ReChild as not active */
        UPDATE [4_Regions_ReChild]
        SET    [IsActive] = 'false'
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child F09_Region_Child as not active */
        UPDATE [4_Regions_Child]
        SET    [IsActive] = 'false'
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child F08_Region as not active */
        UPDATE [4_Regions]
        SET    [IsActive] = 'false'
        FROM [4_Regions]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child F07_Country_ReChild as not active */
        UPDATE [3_Countries_ReChild]
        SET    [IsActive] = 'false'
        FROM [3_Countries_ReChild]
            INNER JOIN [3_Countries] ON [3_Countries_ReChild].[Country_ID2] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child F07_Country_Child as not active */
        UPDATE [3_Countries_Child]
        SET    [IsActive] = 'false'
        FROM [3_Countries_Child]
            INNER JOIN [3_Countries] ON [3_Countries_Child].[Country_ID1] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child F06_Country as not active */
        UPDATE [3_Countries]
        SET    [IsActive] = 'false'
        FROM [3_Countries]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child F05_SubContinent_ReChild as not active */
        UPDATE [2_SubContinents_ReChild]
        SET    [IsActive] = 'false'
        FROM [2_SubContinents_ReChild]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_ReChild].[SubContinent_ID2] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child F05_SubContinent_Child as not active */
        UPDATE [2_SubContinents_Child]
        SET    [IsActive] = 'false'
        FROM [2_SubContinents_Child]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_Child].[SubContinent_ID1] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark F04_SubContinent object as not active */
        UPDATE [2_SubContinents]
        SET    [IsActive] = 'false'
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetA02_Continent]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetA02_Continent]
    @Continent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get A02_Continent from table */
        SELECT
            [1_Continents].[Continent_ID],
            [1_Continents].[Continent_Name]
        FROM [1_Continents]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Get A03_Continent_Child from table */
        SELECT
            [1_Continents_Child].[Continent_Child_Name]
        FROM [1_Continents_Child]
            INNER JOIN [1_Continents] ON [1_Continents_Child].[Continent_ID1] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Get A03_Continent_ReChild from table */
        SELECT
            [1_Continents_ReChild].[Continent_Child_Name]
        FROM [1_Continents_ReChild]
            INNER JOIN [1_Continents] ON [1_Continents_ReChild].[Continent_ID2] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Get A04_SubContinent from table */
        SELECT
            [2_SubContinents].[SubContinent_ID],
            [2_SubContinents].[SubContinent_Name]
        FROM [2_SubContinents]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Get A05_SubContinent_Child from table */
        SELECT
            [2_SubContinents_Child].[SubContinent_ID1],
            [2_SubContinents_Child].[SubContinent_Child_Name],
            [2_SubContinents_Child].[RowVersion]
        FROM [2_SubContinents_Child]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_Child].[SubContinent_ID1] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Get A05_SubContinent_ReChild from table */
        SELECT
            [2_SubContinents_ReChild].[SubContinent_ID2],
            [2_SubContinents_ReChild].[SubContinent_Child_Name],
            [2_SubContinents_ReChild].[RowVersion]
        FROM [2_SubContinents_ReChild]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_ReChild].[SubContinent_ID2] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Get A06_Country from table */
        SELECT
            [3_Countries].[Parent_SubContinent_ID],
            [3_Countries].[Country_ID],
            [3_Countries].[Country_Name],
            [3_Countries].[RowVersion]
        FROM [3_Countries]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Get A07_Country_Child from table */
        SELECT
            [3_Countries_Child].[Country_ID1],
            [3_Countries_Child].[Country_Child_Name]
        FROM [3_Countries_Child]
            INNER JOIN [3_Countries] ON [3_Countries_Child].[Country_ID1] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Get A07_Country_ReChild from table */
        SELECT
            [3_Countries_ReChild].[Country_ID2],
            [3_Countries_ReChild].[Country_Child_Name]
        FROM [3_Countries_ReChild]
            INNER JOIN [3_Countries] ON [3_Countries_ReChild].[Country_ID2] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Get A08_Region from table */
        SELECT
            [4_Regions].[Parent_Country_ID],
            [4_Regions].[Region_ID],
            [4_Regions].[Region_Name]
        FROM [4_Regions]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Get A09_Region_Child from table */
        SELECT
            [4_Regions_Child].[Region_ID1],
            [4_Regions_Child].[Region_Child_Name]
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Get A09_Region_ReChild from table */
        SELECT
            [4_Regions_ReChild].[Region_ID2],
            [4_Regions_ReChild].[Region_Child_Name]
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Get A10_City from table */
        SELECT
            [5_Cities].[Parent_Region_ID],
            [5_Cities].[City_ID],
            [5_Cities].[City_Name]
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Get A11_City_Child from table */
        SELECT
            [5_Cities_Child].[City_ID1],
            [5_Cities_Child].[City_Child_Name]
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Get A11_City_ReChild from table */
        SELECT
            [5_Cities_ReChild].[City_ID2],
            [5_Cities_ReChild].[City_Child_Name]
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Get A12_CityRoad from table */
        SELECT
            [6_CityRoads].[Parent_City_ID],
            [6_CityRoads].[CityRoad_ID],
            [6_CityRoads].[CityRoad_Name]
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddH04_SubContinent]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddH04_SubContinent]
    @SubContinent_ID int OUTPUT,
    @Continent_ID int,
    @SubContinent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 2_SubContinents */
        INSERT INTO [2_SubContinents]
        (
            [Parent_Continent_ID],
            [SubContinent_Name]
        )
        VALUES
        (
            @Continent_ID,
            @SubContinent_Name
        )

        /* Return new primary key */
        SET @SubContinent_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteA02_Continent]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteA02_Continent]
    @Continent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID] FROM [1_Continents]
            WHERE
                [Continent_ID] = @Continent_ID
        )
        BEGIN
            RAISERROR ('''A02_Continent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete child A12_CityRoad from 6_CityRoads */
        DELETE
            [6_CityRoads]
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child A11_City_ReChild from 5_Cities_ReChild */
        DELETE
            [5_Cities_ReChild]
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child A11_City_Child from 5_Cities_Child */
        DELETE
            [5_Cities_Child]
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child A10_City from 5_Cities */
        DELETE
            [5_Cities]
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child A09_Region_ReChild from 4_Regions_ReChild */
        DELETE
            [4_Regions_ReChild]
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child A09_Region_Child from 4_Regions_Child */
        DELETE
            [4_Regions_Child]
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child A08_Region from 4_Regions */
        DELETE
            [4_Regions]
        FROM [4_Regions]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child A07_Country_ReChild from 3_Countries_ReChild */
        DELETE
            [3_Countries_ReChild]
        FROM [3_Countries_ReChild]
            INNER JOIN [3_Countries] ON [3_Countries_ReChild].[Country_ID2] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child A07_Country_Child from 3_Countries_Child */
        DELETE
            [3_Countries_Child]
        FROM [3_Countries_Child]
            INNER JOIN [3_Countries] ON [3_Countries_Child].[Country_ID1] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child A06_Country from 3_Countries */
        DELETE
            [3_Countries]
        FROM [3_Countries]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child A05_SubContinent_ReChild from 2_SubContinents_ReChild */
        DELETE
            [2_SubContinents_ReChild]
        FROM [2_SubContinents_ReChild]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_ReChild].[SubContinent_ID2] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child A05_SubContinent_Child from 2_SubContinents_Child */
        DELETE
            [2_SubContinents_Child]
        FROM [2_SubContinents_Child]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_Child].[SubContinent_ID1] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child A04_SubContinent from 2_SubContinents */
        DELETE
            [2_SubContinents]
        FROM [2_SubContinents]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child A03_Continent_ReChild from 1_Continents_ReChild */
        DELETE
            [1_Continents_ReChild]
        FROM [1_Continents_ReChild]
            INNER JOIN [1_Continents] ON [1_Continents_ReChild].[Continent_ID2] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child A03_Continent_Child from 1_Continents_Child */
        DELETE
            [1_Continents_Child]
        FROM [1_Continents_Child]
            INNER JOIN [1_Continents] ON [1_Continents_Child].[Continent_ID1] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete A02_Continent object from 1_Continents */
        DELETE
        FROM [1_Continents]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteH04_SubContinent]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteH04_SubContinent]
    @SubContinent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID] FROM [2_SubContinents]
            WHERE
                [SubContinent_ID] = @SubContinent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H04_SubContinent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark child H12_CityRoad as not active */
        UPDATE [6_CityRoads]
        SET    [IsActive] = 'false'
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child H11_City_ReChild as not active */
        UPDATE [5_Cities_ReChild]
        SET    [IsActive] = 'false'
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child H11_City_Child as not active */
        UPDATE [5_Cities_Child]
        SET    [IsActive] = 'false'
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child H10_City as not active */
        UPDATE [5_Cities]
        SET    [IsActive] = 'false'
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child H09_Region_ReChild as not active */
        UPDATE [4_Regions_ReChild]
        SET    [IsActive] = 'false'
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child H09_Region_Child as not active */
        UPDATE [4_Regions_Child]
        SET    [IsActive] = 'false'
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child H08_Region as not active */
        UPDATE [4_Regions]
        SET    [IsActive] = 'false'
        FROM [4_Regions]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child H07_Country_ReChild as not active */
        UPDATE [3_Countries_ReChild]
        SET    [IsActive] = 'false'
        FROM [3_Countries_ReChild]
            INNER JOIN [3_Countries] ON [3_Countries_ReChild].[Country_ID2] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child H07_Country_Child as not active */
        UPDATE [3_Countries_Child]
        SET    [IsActive] = 'false'
        FROM [3_Countries_Child]
            INNER JOIN [3_Countries] ON [3_Countries_Child].[Country_ID1] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child H06_Country as not active */
        UPDATE [3_Countries]
        SET    [IsActive] = 'false'
        FROM [3_Countries]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child H05_SubContinent_ReChild as not active */
        UPDATE [2_SubContinents_ReChild]
        SET    [IsActive] = 'false'
        FROM [2_SubContinents_ReChild]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_ReChild].[SubContinent_ID2] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child H05_SubContinent_Child as not active */
        UPDATE [2_SubContinents_Child]
        SET    [IsActive] = 'false'
        FROM [2_SubContinents_Child]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_Child].[SubContinent_ID1] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark H04_SubContinent object as not active */
        UPDATE [2_SubContinents]
        SET    [IsActive] = 'false'
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateH04_SubContinent]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateH04_SubContinent]
    @SubContinent_ID int,
    @SubContinent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID] FROM [2_SubContinents]
            WHERE
                [SubContinent_ID] = @SubContinent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H04_SubContinent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 2_SubContinents */
        UPDATE [2_SubContinents]
        SET
            [SubContinent_Name] = @SubContinent_Name
        WHERE
            [SubContinent_ID] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetH03_SubContinentColl]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetH03_SubContinentColl]
    @Parent_Continent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get H04_SubContinent from table */
        SELECT
            [2_SubContinents].[SubContinent_ID],
            [2_SubContinents].[SubContinent_Name]
        FROM [2_SubContinents]
        WHERE
            [2_SubContinents].[Parent_Continent_ID] = @Parent_Continent_ID AND
            [2_SubContinents].[IsActive] = 'true'

    END
GO
/****** Object:  StoredProcedure [dbo].[GetB01_ContinentColl]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetB01_ContinentColl]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get B02_Continent from table */
        SELECT
            [1_Continents].[Continent_ID],
            [1_Continents].[Continent_Name]
        FROM [1_Continents]

        /* Get B03_Continent_Child from table */
        SELECT
            [1_Continents_Child].[Continent_ID1],
            [1_Continents_Child].[Continent_Child_Name]
        FROM [1_Continents_Child]

        /* Get B03_Continent_ReChild from table */
        SELECT
            [1_Continents_ReChild].[Continent_ID2],
            [1_Continents_ReChild].[Continent_Child_Name]
        FROM [1_Continents_ReChild]

        /* Get B04_SubContinent from table */
        SELECT
            [2_SubContinents].[Parent_Continent_ID],
            [2_SubContinents].[SubContinent_ID],
            [2_SubContinents].[SubContinent_Name]
        FROM [2_SubContinents]

        /* Get B05_SubContinent_Child from table */
        SELECT
            [2_SubContinents_Child].[SubContinent_ID1],
            [2_SubContinents_Child].[SubContinent_Child_Name]
        FROM [2_SubContinents_Child]

        /* Get B05_SubContinent_ReChild from table */
        SELECT
            [2_SubContinents_ReChild].[SubContinent_ID2],
            [2_SubContinents_ReChild].[SubContinent_Child_Name]
        FROM [2_SubContinents_ReChild]

        /* Get B06_Country from table */
        SELECT
            [3_Countries].[Parent_SubContinent_ID],
            [3_Countries].[Country_ID],
            [3_Countries].[Country_Name]
        FROM [3_Countries]

        /* Get B07_Country_Child from table */
        SELECT
            [3_Countries_Child].[Country_ID1],
            [3_Countries_Child].[Country_Child_Name]
        FROM [3_Countries_Child]

        /* Get B07_Country_ReChild from table */
        SELECT
            [3_Countries_ReChild].[Country_ID2],
            [3_Countries_ReChild].[Country_Child_Name]
        FROM [3_Countries_ReChild]

        /* Get B08_Region from table */
        SELECT
            [4_Regions].[Parent_Country_ID],
            [4_Regions].[Region_ID],
            [4_Regions].[Region_Name]
        FROM [4_Regions]

        /* Get B09_Region_Child from table */
        SELECT
            [4_Regions_Child].[Region_ID1],
            [4_Regions_Child].[Region_Child_Name]
        FROM [4_Regions_Child]

        /* Get B09_Region_ReChild from table */
        SELECT
            [4_Regions_ReChild].[Region_ID2],
            [4_Regions_ReChild].[Region_Child_Name]
        FROM [4_Regions_ReChild]

        /* Get B10_City from table */
        SELECT
            [5_Cities].[Parent_Region_ID],
            [5_Cities].[City_ID],
            [5_Cities].[City_Name]
        FROM [5_Cities]

        /* Get B11_City_Child from table */
        SELECT
            [5_Cities_Child].[City_ID1],
            [5_Cities_Child].[City_Child_Name]
        FROM [5_Cities_Child]

        /* Get B11_City_ReChild from table */
        SELECT
            [5_Cities_ReChild].[City_ID2],
            [5_Cities_ReChild].[City_Child_Name]
        FROM [5_Cities_ReChild]

        /* Get B12_CityRoad from table */
        SELECT
            [6_CityRoads].[Parent_City_ID],
            [6_CityRoads].[CityRoad_ID],
            [6_CityRoads].[CityRoad_Name]
        FROM [6_CityRoads]

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteB02_Continent]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteB02_Continent]
    @Continent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID] FROM [1_Continents]
            WHERE
                [Continent_ID] = @Continent_ID
        )
        BEGIN
            RAISERROR ('''B02_Continent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete child B12_CityRoad from 6_CityRoads */
        DELETE
            [6_CityRoads]
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child B11_City_ReChild from 5_Cities_ReChild */
        DELETE
            [5_Cities_ReChild]
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child B11_City_Child from 5_Cities_Child */
        DELETE
            [5_Cities_Child]
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child B10_City from 5_Cities */
        DELETE
            [5_Cities]
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child B09_Region_ReChild from 4_Regions_ReChild */
        DELETE
            [4_Regions_ReChild]
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child B09_Region_Child from 4_Regions_Child */
        DELETE
            [4_Regions_Child]
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child B08_Region from 4_Regions */
        DELETE
            [4_Regions]
        FROM [4_Regions]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child B07_Country_ReChild from 3_Countries_ReChild */
        DELETE
            [3_Countries_ReChild]
        FROM [3_Countries_ReChild]
            INNER JOIN [3_Countries] ON [3_Countries_ReChild].[Country_ID2] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child B07_Country_Child from 3_Countries_Child */
        DELETE
            [3_Countries_Child]
        FROM [3_Countries_Child]
            INNER JOIN [3_Countries] ON [3_Countries_Child].[Country_ID1] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child B06_Country from 3_Countries */
        DELETE
            [3_Countries]
        FROM [3_Countries]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child B05_SubContinent_ReChild from 2_SubContinents_ReChild */
        DELETE
            [2_SubContinents_ReChild]
        FROM [2_SubContinents_ReChild]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_ReChild].[SubContinent_ID2] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child B05_SubContinent_Child from 2_SubContinents_Child */
        DELETE
            [2_SubContinents_Child]
        FROM [2_SubContinents_Child]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_Child].[SubContinent_ID1] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child B04_SubContinent from 2_SubContinents */
        DELETE
            [2_SubContinents]
        FROM [2_SubContinents]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child B03_Continent_ReChild from 1_Continents_ReChild */
        DELETE
            [1_Continents_ReChild]
        FROM [1_Continents_ReChild]
            INNER JOIN [1_Continents] ON [1_Continents_ReChild].[Continent_ID2] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child B03_Continent_Child from 1_Continents_Child */
        DELETE
            [1_Continents_Child]
        FROM [1_Continents_Child]
            INNER JOIN [1_Continents] ON [1_Continents_Child].[Continent_ID1] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete B02_Continent object from 1_Continents */
        DELETE
        FROM [1_Continents]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddB04_SubContinent]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddB04_SubContinent]
    @SubContinent_ID int OUTPUT,
    @Continent_ID int,
    @SubContinent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 2_SubContinents */
        INSERT INTO [2_SubContinents]
        (
            [Parent_Continent_ID],
            [SubContinent_Name]
        )
        VALUES
        (
            @Continent_ID,
            @SubContinent_Name
        )

        /* Return new primary key */
        SET @SubContinent_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateB04_SubContinent]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateB04_SubContinent]
    @SubContinent_ID int,
    @SubContinent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID] FROM [2_SubContinents]
            WHERE
                [SubContinent_ID] = @SubContinent_ID
        )
        BEGIN
            RAISERROR ('''B04_SubContinent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 2_SubContinents */
        UPDATE [2_SubContinents]
        SET
            [SubContinent_Name] = @SubContinent_Name
        WHERE
            [SubContinent_ID] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetG03_SubContinentColl]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetG03_SubContinentColl]
    @Parent_Continent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get G04_SubContinent from table */
        SELECT
            [2_SubContinents].[SubContinent_ID],
            [2_SubContinents].[SubContinent_Name]
        FROM [2_SubContinents]
        WHERE
            [2_SubContinents].[Parent_Continent_ID] = @Parent_Continent_ID AND
            [2_SubContinents].[IsActive] = 'true'

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteB04_SubContinent]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteB04_SubContinent]
    @SubContinent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID] FROM [2_SubContinents]
            WHERE
                [SubContinent_ID] = @SubContinent_ID
        )
        BEGIN
            RAISERROR ('''B04_SubContinent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete child B12_CityRoad from 6_CityRoads */
        DELETE
            [6_CityRoads]
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child B11_City_ReChild from 5_Cities_ReChild */
        DELETE
            [5_Cities_ReChild]
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child B11_City_Child from 5_Cities_Child */
        DELETE
            [5_Cities_Child]
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child B10_City from 5_Cities */
        DELETE
            [5_Cities]
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child B09_Region_ReChild from 4_Regions_ReChild */
        DELETE
            [4_Regions_ReChild]
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child B09_Region_Child from 4_Regions_Child */
        DELETE
            [4_Regions_Child]
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child B08_Region from 4_Regions */
        DELETE
            [4_Regions]
        FROM [4_Regions]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child B07_Country_ReChild from 3_Countries_ReChild */
        DELETE
            [3_Countries_ReChild]
        FROM [3_Countries_ReChild]
            INNER JOIN [3_Countries] ON [3_Countries_ReChild].[Country_ID2] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child B07_Country_Child from 3_Countries_Child */
        DELETE
            [3_Countries_Child]
        FROM [3_Countries_Child]
            INNER JOIN [3_Countries] ON [3_Countries_Child].[Country_ID1] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child B06_Country from 3_Countries */
        DELETE
            [3_Countries]
        FROM [3_Countries]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child B05_SubContinent_ReChild from 2_SubContinents_ReChild */
        DELETE
            [2_SubContinents_ReChild]
        FROM [2_SubContinents_ReChild]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_ReChild].[SubContinent_ID2] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child B05_SubContinent_Child from 2_SubContinents_Child */
        DELETE
            [2_SubContinents_Child]
        FROM [2_SubContinents_Child]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_Child].[SubContinent_ID1] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete B04_SubContinent object from 2_SubContinents */
        DELETE
        FROM [2_SubContinents]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteG02_Continent]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteG02_Continent]
    @Continent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID] FROM [1_Continents]
            WHERE
                [Continent_ID] = @Continent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G02_Continent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark child G12_CityRoad as not active */
        UPDATE [6_CityRoads]
        SET    [IsActive] = 'false'
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child G11_City_ReChild as not active */
        UPDATE [5_Cities_ReChild]
        SET    [IsActive] = 'false'
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child G11_City_Child as not active */
        UPDATE [5_Cities_Child]
        SET    [IsActive] = 'false'
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child G10_City as not active */
        UPDATE [5_Cities]
        SET    [IsActive] = 'false'
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child G09_Region_ReChild as not active */
        UPDATE [4_Regions_ReChild]
        SET    [IsActive] = 'false'
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child G09_Region_Child as not active */
        UPDATE [4_Regions_Child]
        SET    [IsActive] = 'false'
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child G08_Region as not active */
        UPDATE [4_Regions]
        SET    [IsActive] = 'false'
        FROM [4_Regions]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child G07_Country_ReChild as not active */
        UPDATE [3_Countries_ReChild]
        SET    [IsActive] = 'false'
        FROM [3_Countries_ReChild]
            INNER JOIN [3_Countries] ON [3_Countries_ReChild].[Country_ID2] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child G07_Country_Child as not active */
        UPDATE [3_Countries_Child]
        SET    [IsActive] = 'false'
        FROM [3_Countries_Child]
            INNER JOIN [3_Countries] ON [3_Countries_Child].[Country_ID1] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child G06_Country as not active */
        UPDATE [3_Countries]
        SET    [IsActive] = 'false'
        FROM [3_Countries]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child G05_SubContinent_ReChild as not active */
        UPDATE [2_SubContinents_ReChild]
        SET    [IsActive] = 'false'
        FROM [2_SubContinents_ReChild]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_ReChild].[SubContinent_ID2] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child G05_SubContinent_Child as not active */
        UPDATE [2_SubContinents_Child]
        SET    [IsActive] = 'false'
        FROM [2_SubContinents_Child]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_Child].[SubContinent_ID1] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child G04_SubContinent as not active */
        UPDATE [2_SubContinents]
        SET    [IsActive] = 'false'
        FROM [2_SubContinents]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child G03_Continent_ReChild as not active */
        UPDATE [1_Continents_ReChild]
        SET    [IsActive] = 'false'
        FROM [1_Continents_ReChild]
            INNER JOIN [1_Continents] ON [1_Continents_ReChild].[Continent_ID2] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child G03_Continent_Child as not active */
        UPDATE [1_Continents_Child]
        SET    [IsActive] = 'false'
        FROM [1_Continents_Child]
            INNER JOIN [1_Continents] ON [1_Continents_Child].[Continent_ID1] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark G02_Continent object as not active */
        UPDATE [1_Continents]
        SET    [IsActive] = 'false'
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteD02_Continent]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteD02_Continent]
    @Continent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID] FROM [1_Continents]
            WHERE
                [Continent_ID] = @Continent_ID
        )
        BEGIN
            RAISERROR ('''D02_Continent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete child D12_CityRoad from 6_CityRoads */
        DELETE
            [6_CityRoads]
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child D11_City_ReChild from 5_Cities_ReChild */
        DELETE
            [5_Cities_ReChild]
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child D11_City_Child from 5_Cities_Child */
        DELETE
            [5_Cities_Child]
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child D10_City from 5_Cities */
        DELETE
            [5_Cities]
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child D09_Region_ReChild from 4_Regions_ReChild */
        DELETE
            [4_Regions_ReChild]
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child D09_Region_Child from 4_Regions_Child */
        DELETE
            [4_Regions_Child]
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child D08_Region from 4_Regions */
        DELETE
            [4_Regions]
        FROM [4_Regions]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child D07_Country_ReChild from 3_Countries_ReChild */
        DELETE
            [3_Countries_ReChild]
        FROM [3_Countries_ReChild]
            INNER JOIN [3_Countries] ON [3_Countries_ReChild].[Country_ID2] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child D07_Country_Child from 3_Countries_Child */
        DELETE
            [3_Countries_Child]
        FROM [3_Countries_Child]
            INNER JOIN [3_Countries] ON [3_Countries_Child].[Country_ID1] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child D06_Country from 3_Countries */
        DELETE
            [3_Countries]
        FROM [3_Countries]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child D05_SubContinent_ReChild from 2_SubContinents_ReChild */
        DELETE
            [2_SubContinents_ReChild]
        FROM [2_SubContinents_ReChild]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_ReChild].[SubContinent_ID2] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child D05_SubContinent_Child from 2_SubContinents_Child */
        DELETE
            [2_SubContinents_Child]
        FROM [2_SubContinents_Child]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_Child].[SubContinent_ID1] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child D04_SubContinent from 2_SubContinents */
        DELETE
            [2_SubContinents]
        FROM [2_SubContinents]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child D03_Continent_ReChild from 1_Continents_ReChild */
        DELETE
            [1_Continents_ReChild]
        FROM [1_Continents_ReChild]
            INNER JOIN [1_Continents] ON [1_Continents_ReChild].[Continent_ID2] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child D03_Continent_Child from 1_Continents_Child */
        DELETE
            [1_Continents_Child]
        FROM [1_Continents_Child]
            INNER JOIN [1_Continents] ON [1_Continents_Child].[Continent_ID1] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete D02_Continent object from 1_Continents */
        DELETE
        FROM [1_Continents]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddD04_SubContinent]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddD04_SubContinent]
    @SubContinent_ID int OUTPUT,
    @Continent_ID int,
    @SubContinent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 2_SubContinents */
        INSERT INTO [2_SubContinents]
        (
            [Parent_Continent_ID],
            [SubContinent_Name]
        )
        VALUES
        (
            @Continent_ID,
            @SubContinent_Name
        )

        /* Return new primary key */
        SET @SubContinent_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateD04_SubContinent]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateD04_SubContinent]
    @SubContinent_ID int,
    @SubContinent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID] FROM [2_SubContinents]
            WHERE
                [SubContinent_ID] = @SubContinent_ID
        )
        BEGIN
            RAISERROR ('''D04_SubContinent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 2_SubContinents */
        UPDATE [2_SubContinents]
        SET
            [SubContinent_Name] = @SubContinent_Name
        WHERE
            [SubContinent_ID] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteD04_SubContinent]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteD04_SubContinent]
    @SubContinent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID] FROM [2_SubContinents]
            WHERE
                [SubContinent_ID] = @SubContinent_ID
        )
        BEGIN
            RAISERROR ('''D04_SubContinent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete child D12_CityRoad from 6_CityRoads */
        DELETE
            [6_CityRoads]
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child D11_City_ReChild from 5_Cities_ReChild */
        DELETE
            [5_Cities_ReChild]
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child D11_City_Child from 5_Cities_Child */
        DELETE
            [5_Cities_Child]
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child D10_City from 5_Cities */
        DELETE
            [5_Cities]
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child D09_Region_ReChild from 4_Regions_ReChild */
        DELETE
            [4_Regions_ReChild]
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child D09_Region_Child from 4_Regions_Child */
        DELETE
            [4_Regions_Child]
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child D08_Region from 4_Regions */
        DELETE
            [4_Regions]
        FROM [4_Regions]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child D07_Country_ReChild from 3_Countries_ReChild */
        DELETE
            [3_Countries_ReChild]
        FROM [3_Countries_ReChild]
            INNER JOIN [3_Countries] ON [3_Countries_ReChild].[Country_ID2] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child D07_Country_Child from 3_Countries_Child */
        DELETE
            [3_Countries_Child]
        FROM [3_Countries_Child]
            INNER JOIN [3_Countries] ON [3_Countries_Child].[Country_ID1] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child D06_Country from 3_Countries */
        DELETE
            [3_Countries]
        FROM [3_Countries]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child D05_SubContinent_ReChild from 2_SubContinents_ReChild */
        DELETE
            [2_SubContinents_ReChild]
        FROM [2_SubContinents_ReChild]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_ReChild].[SubContinent_ID2] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child D05_SubContinent_Child from 2_SubContinents_Child */
        DELETE
            [2_SubContinents_Child]
        FROM [2_SubContinents_Child]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_Child].[SubContinent_ID1] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete D04_SubContinent object from 2_SubContinents */
        DELETE
        FROM [2_SubContinents]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetD03_SubContinentColl]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetD03_SubContinentColl]
    @Parent_Continent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D04_SubContinent from table */
        SELECT
            [2_SubContinents].[SubContinent_ID],
            [2_SubContinents].[SubContinent_Name]
        FROM [2_SubContinents]
        WHERE
            [2_SubContinents].[Parent_Continent_ID] = @Parent_Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteE02_Continent]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteE02_Continent]
    @Continent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID] FROM [1_Continents]
            WHERE
                [Continent_ID] = @Continent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E02_Continent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark child E12_CityRoad as not active */
        UPDATE [6_CityRoads]
        SET    [IsActive] = 'false'
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child E11_City_ReChild as not active */
        UPDATE [5_Cities_ReChild]
        SET    [IsActive] = 'false'
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child E11_City_Child as not active */
        UPDATE [5_Cities_Child]
        SET    [IsActive] = 'false'
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child E10_City as not active */
        UPDATE [5_Cities]
        SET    [IsActive] = 'false'
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child E09_Region_ReChild as not active */
        UPDATE [4_Regions_ReChild]
        SET    [IsActive] = 'false'
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child E09_Region_Child as not active */
        UPDATE [4_Regions_Child]
        SET    [IsActive] = 'false'
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child E08_Region as not active */
        UPDATE [4_Regions]
        SET    [IsActive] = 'false'
        FROM [4_Regions]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child E07_Country_ReChild as not active */
        UPDATE [3_Countries_ReChild]
        SET    [IsActive] = 'false'
        FROM [3_Countries_ReChild]
            INNER JOIN [3_Countries] ON [3_Countries_ReChild].[Country_ID2] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child E07_Country_Child as not active */
        UPDATE [3_Countries_Child]
        SET    [IsActive] = 'false'
        FROM [3_Countries_Child]
            INNER JOIN [3_Countries] ON [3_Countries_Child].[Country_ID1] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child E06_Country as not active */
        UPDATE [3_Countries]
        SET    [IsActive] = 'false'
        FROM [3_Countries]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child E05_SubContinent_ReChild as not active */
        UPDATE [2_SubContinents_ReChild]
        SET    [IsActive] = 'false'
        FROM [2_SubContinents_ReChild]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_ReChild].[SubContinent_ID2] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child E05_SubContinent_Child as not active */
        UPDATE [2_SubContinents_Child]
        SET    [IsActive] = 'false'
        FROM [2_SubContinents_Child]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_Child].[SubContinent_ID1] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child E04_SubContinent as not active */
        UPDATE [2_SubContinents]
        SET    [IsActive] = 'false'
        FROM [2_SubContinents]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child E03_Continent_ReChild as not active */
        UPDATE [1_Continents_ReChild]
        SET    [IsActive] = 'false'
        FROM [1_Continents_ReChild]
            INNER JOIN [1_Continents] ON [1_Continents_ReChild].[Continent_ID2] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child E03_Continent_Child as not active */
        UPDATE [1_Continents_Child]
        SET    [IsActive] = 'false'
        FROM [1_Continents_Child]
            INNER JOIN [1_Continents] ON [1_Continents_Child].[Continent_ID1] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark E02_Continent object as not active */
        UPDATE [1_Continents]
        SET    [IsActive] = 'false'
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetE02_Continent]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetE02_Continent]
    @Continent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get E02_Continent from table */
        SELECT
            [1_Continents].[Continent_ID],
            [1_Continents].[Continent_Name]
        FROM [1_Continents]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID AND
            [1_Continents].[IsActive] = 'true'

        /* Get E03_Continent_Child from table */
        SELECT
            [1_Continents_Child].[Continent_Child_Name]
        FROM [1_Continents_Child]
            INNER JOIN [1_Continents] ON [1_Continents_Child].[Continent_ID1] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID AND
            [1_Continents_Child].[IsActive] = 'true'

        /* Get E03_Continent_ReChild from table */
        SELECT
            [1_Continents_ReChild].[Continent_Child_Name]
        FROM [1_Continents_ReChild]
            INNER JOIN [1_Continents] ON [1_Continents_ReChild].[Continent_ID2] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID AND
            [1_Continents_ReChild].[IsActive] = 'true'

        /* Get E04_SubContinent from table */
        SELECT
            [2_SubContinents].[SubContinent_ID],
            [2_SubContinents].[SubContinent_Name]
        FROM [2_SubContinents]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID AND
            [2_SubContinents].[IsActive] = 'true'

        /* Get E05_SubContinent_Child from table */
        SELECT
            [2_SubContinents_Child].[SubContinent_ID1],
            [2_SubContinents_Child].[SubContinent_Child_Name],
            [2_SubContinents_Child].[RowVersion]
        FROM [2_SubContinents_Child]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_Child].[SubContinent_ID1] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID AND
            [2_SubContinents_Child].[IsActive] = 'true'

        /* Get E05_SubContinent_ReChild from table */
        SELECT
            [2_SubContinents_ReChild].[SubContinent_ID2],
            [2_SubContinents_ReChild].[SubContinent_Child_Name],
            [2_SubContinents_ReChild].[RowVersion]
        FROM [2_SubContinents_ReChild]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_ReChild].[SubContinent_ID2] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID AND
            [2_SubContinents_ReChild].[IsActive] = 'true'

        /* Get E06_Country from table */
        SELECT
            [3_Countries].[Parent_SubContinent_ID],
            [3_Countries].[Country_ID],
            [3_Countries].[Country_Name],
            [3_Countries].[RowVersion]
        FROM [3_Countries]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID AND
            [3_Countries].[IsActive] = 'true'

        /* Get E07_Country_Child from table */
        SELECT
            [3_Countries_Child].[Country_ID1],
            [3_Countries_Child].[Country_Child_Name]
        FROM [3_Countries_Child]
            INNER JOIN [3_Countries] ON [3_Countries_Child].[Country_ID1] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID AND
            [3_Countries_Child].[IsActive] = 'true'

        /* Get E07_Country_ReChild from table */
        SELECT
            [3_Countries_ReChild].[Country_ID2],
            [3_Countries_ReChild].[Country_Child_Name]
        FROM [3_Countries_ReChild]
            INNER JOIN [3_Countries] ON [3_Countries_ReChild].[Country_ID2] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID AND
            [3_Countries_ReChild].[IsActive] = 'true'

        /* Get E08_Region from table */
        SELECT
            [4_Regions].[Parent_Country_ID],
            [4_Regions].[Region_ID],
            [4_Regions].[Region_Name]
        FROM [4_Regions]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID AND
            [4_Regions].[IsActive] = 'true'

        /* Get E09_Region_Child from table */
        SELECT
            [4_Regions_Child].[Region_ID1],
            [4_Regions_Child].[Region_Child_Name]
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID AND
            [4_Regions_Child].[IsActive] = 'true'

        /* Get E09_Region_ReChild from table */
        SELECT
            [4_Regions_ReChild].[Region_ID2],
            [4_Regions_ReChild].[Region_Child_Name]
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID AND
            [4_Regions_ReChild].[IsActive] = 'true'

        /* Get E10_City from table */
        SELECT
            [5_Cities].[Parent_Region_ID],
            [5_Cities].[City_ID],
            [5_Cities].[City_Name]
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID AND
            [5_Cities].[IsActive] = 'true'

        /* Get E11_City_Child from table */
        SELECT
            [5_Cities_Child].[City_ID1],
            [5_Cities_Child].[City_Child_Name]
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID AND
            [5_Cities_Child].[IsActive] = 'true'

        /* Get E11_City_ReChild from table */
        SELECT
            [5_Cities_ReChild].[City_ID2],
            [5_Cities_ReChild].[City_Child_Name]
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID AND
            [5_Cities_ReChild].[IsActive] = 'true'

        /* Get E12_CityRoad from table */
        SELECT
            [6_CityRoads].[Parent_City_ID],
            [6_CityRoads].[CityRoad_ID],
            [6_CityRoads].[CityRoad_Name]
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID AND
            [6_CityRoads].[IsActive] = 'true'

    END
GO
/****** Object:  StoredProcedure [dbo].[AddG04_SubContinent]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddG04_SubContinent]
    @SubContinent_ID int OUTPUT,
    @Continent_ID int,
    @SubContinent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 2_SubContinents */
        INSERT INTO [2_SubContinents]
        (
            [Parent_Continent_ID],
            [SubContinent_Name]
        )
        VALUES
        (
            @Continent_ID,
            @SubContinent_Name
        )

        /* Return new primary key */
        SET @SubContinent_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateG04_SubContinent]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateG04_SubContinent]
    @SubContinent_ID int,
    @SubContinent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID] FROM [2_SubContinents]
            WHERE
                [SubContinent_ID] = @SubContinent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G04_SubContinent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 2_SubContinents */
        UPDATE [2_SubContinents]
        SET
            [SubContinent_Name] = @SubContinent_Name
        WHERE
            [SubContinent_ID] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteG04_SubContinent]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteG04_SubContinent]
    @SubContinent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID] FROM [2_SubContinents]
            WHERE
                [SubContinent_ID] = @SubContinent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G04_SubContinent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark child G12_CityRoad as not active */
        UPDATE [6_CityRoads]
        SET    [IsActive] = 'false'
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child G11_City_ReChild as not active */
        UPDATE [5_Cities_ReChild]
        SET    [IsActive] = 'false'
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child G11_City_Child as not active */
        UPDATE [5_Cities_Child]
        SET    [IsActive] = 'false'
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child G10_City as not active */
        UPDATE [5_Cities]
        SET    [IsActive] = 'false'
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child G09_Region_ReChild as not active */
        UPDATE [4_Regions_ReChild]
        SET    [IsActive] = 'false'
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child G09_Region_Child as not active */
        UPDATE [4_Regions_Child]
        SET    [IsActive] = 'false'
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child G08_Region as not active */
        UPDATE [4_Regions]
        SET    [IsActive] = 'false'
        FROM [4_Regions]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child G07_Country_ReChild as not active */
        UPDATE [3_Countries_ReChild]
        SET    [IsActive] = 'false'
        FROM [3_Countries_ReChild]
            INNER JOIN [3_Countries] ON [3_Countries_ReChild].[Country_ID2] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child G07_Country_Child as not active */
        UPDATE [3_Countries_Child]
        SET    [IsActive] = 'false'
        FROM [3_Countries_Child]
            INNER JOIN [3_Countries] ON [3_Countries_Child].[Country_ID1] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child G06_Country as not active */
        UPDATE [3_Countries]
        SET    [IsActive] = 'false'
        FROM [3_Countries]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child G05_SubContinent_ReChild as not active */
        UPDATE [2_SubContinents_ReChild]
        SET    [IsActive] = 'false'
        FROM [2_SubContinents_ReChild]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_ReChild].[SubContinent_ID2] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child G05_SubContinent_Child as not active */
        UPDATE [2_SubContinents_Child]
        SET    [IsActive] = 'false'
        FROM [2_SubContinents_Child]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_Child].[SubContinent_ID1] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark G04_SubContinent object as not active */
        UPDATE [2_SubContinents]
        SET    [IsActive] = 'false'
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteH02_Continent]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteH02_Continent]
    @Continent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID] FROM [1_Continents]
            WHERE
                [Continent_ID] = @Continent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H02_Continent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark child H12_CityRoad as not active */
        UPDATE [6_CityRoads]
        SET    [IsActive] = 'false'
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child H11_City_ReChild as not active */
        UPDATE [5_Cities_ReChild]
        SET    [IsActive] = 'false'
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child H11_City_Child as not active */
        UPDATE [5_Cities_Child]
        SET    [IsActive] = 'false'
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child H10_City as not active */
        UPDATE [5_Cities]
        SET    [IsActive] = 'false'
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child H09_Region_ReChild as not active */
        UPDATE [4_Regions_ReChild]
        SET    [IsActive] = 'false'
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child H09_Region_Child as not active */
        UPDATE [4_Regions_Child]
        SET    [IsActive] = 'false'
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child H08_Region as not active */
        UPDATE [4_Regions]
        SET    [IsActive] = 'false'
        FROM [4_Regions]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child H07_Country_ReChild as not active */
        UPDATE [3_Countries_ReChild]
        SET    [IsActive] = 'false'
        FROM [3_Countries_ReChild]
            INNER JOIN [3_Countries] ON [3_Countries_ReChild].[Country_ID2] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child H07_Country_Child as not active */
        UPDATE [3_Countries_Child]
        SET    [IsActive] = 'false'
        FROM [3_Countries_Child]
            INNER JOIN [3_Countries] ON [3_Countries_Child].[Country_ID1] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child H06_Country as not active */
        UPDATE [3_Countries]
        SET    [IsActive] = 'false'
        FROM [3_Countries]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child H05_SubContinent_ReChild as not active */
        UPDATE [2_SubContinents_ReChild]
        SET    [IsActive] = 'false'
        FROM [2_SubContinents_ReChild]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_ReChild].[SubContinent_ID2] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child H05_SubContinent_Child as not active */
        UPDATE [2_SubContinents_Child]
        SET    [IsActive] = 'false'
        FROM [2_SubContinents_Child]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_Child].[SubContinent_ID1] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child H04_SubContinent as not active */
        UPDATE [2_SubContinents]
        SET    [IsActive] = 'false'
        FROM [2_SubContinents]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child H03_Continent_ReChild as not active */
        UPDATE [1_Continents_ReChild]
        SET    [IsActive] = 'false'
        FROM [1_Continents_ReChild]
            INNER JOIN [1_Continents] ON [1_Continents_ReChild].[Continent_ID2] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark child H03_Continent_Child as not active */
        UPDATE [1_Continents_Child]
        SET    [IsActive] = 'false'
        FROM [1_Continents_Child]
            INNER JOIN [1_Continents] ON [1_Continents_Child].[Continent_ID1] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Mark H02_Continent object as not active */
        UPDATE [1_Continents]
        SET    [IsActive] = 'false'
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddC04_SubContinent]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddC04_SubContinent]
    @SubContinent_ID int OUTPUT,
    @Continent_ID int,
    @SubContinent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 2_SubContinents */
        INSERT INTO [2_SubContinents]
        (
            [Parent_Continent_ID],
            [SubContinent_Name]
        )
        VALUES
        (
            @Continent_ID,
            @SubContinent_Name
        )

        /* Return new primary key */
        SET @SubContinent_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateC04_SubContinent]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateC04_SubContinent]
    @SubContinent_ID int,
    @SubContinent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID] FROM [2_SubContinents]
            WHERE
                [SubContinent_ID] = @SubContinent_ID
        )
        BEGIN
            RAISERROR ('''C04_SubContinent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 2_SubContinents */
        UPDATE [2_SubContinents]
        SET
            [SubContinent_Name] = @SubContinent_Name
        WHERE
            [SubContinent_ID] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteC04_SubContinent]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteC04_SubContinent]
    @SubContinent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID] FROM [2_SubContinents]
            WHERE
                [SubContinent_ID] = @SubContinent_ID
        )
        BEGIN
            RAISERROR ('''C04_SubContinent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete child C12_CityRoad from 6_CityRoads */
        DELETE
            [6_CityRoads]
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child C11_City_ReChild from 5_Cities_ReChild */
        DELETE
            [5_Cities_ReChild]
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child C11_City_Child from 5_Cities_Child */
        DELETE
            [5_Cities_Child]
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child C10_City from 5_Cities */
        DELETE
            [5_Cities]
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child C09_Region_ReChild from 4_Regions_ReChild */
        DELETE
            [4_Regions_ReChild]
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child C09_Region_Child from 4_Regions_Child */
        DELETE
            [4_Regions_Child]
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child C08_Region from 4_Regions */
        DELETE
            [4_Regions]
        FROM [4_Regions]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child C07_Country_ReChild from 3_Countries_ReChild */
        DELETE
            [3_Countries_ReChild]
        FROM [3_Countries_ReChild]
            INNER JOIN [3_Countries] ON [3_Countries_ReChild].[Country_ID2] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child C07_Country_Child from 3_Countries_Child */
        DELETE
            [3_Countries_Child]
        FROM [3_Countries_Child]
            INNER JOIN [3_Countries] ON [3_Countries_Child].[Country_ID1] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child C06_Country from 3_Countries */
        DELETE
            [3_Countries]
        FROM [3_Countries]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child C05_SubContinent_ReChild from 2_SubContinents_ReChild */
        DELETE
            [2_SubContinents_ReChild]
        FROM [2_SubContinents_ReChild]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_ReChild].[SubContinent_ID2] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete child C05_SubContinent_Child from 2_SubContinents_Child */
        DELETE
            [2_SubContinents_Child]
        FROM [2_SubContinents_Child]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_Child].[SubContinent_ID1] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Delete C04_SubContinent object from 2_SubContinents */
        DELETE
        FROM [2_SubContinents]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetC03_SubContinentColl]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetC03_SubContinentColl]
    @Parent_Continent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get C04_SubContinent from table */
        SELECT
            [2_SubContinents].[SubContinent_ID],
            [2_SubContinents].[SubContinent_Name]
        FROM [2_SubContinents]
        WHERE
            [2_SubContinents].[Parent_Continent_ID] = @Parent_Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddE04_SubContinent]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddE04_SubContinent]
    @SubContinent_ID int OUTPUT,
    @Continent_ID int,
    @SubContinent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 2_SubContinents */
        INSERT INTO [2_SubContinents]
        (
            [Parent_Continent_ID],
            [SubContinent_Name]
        )
        VALUES
        (
            @Continent_ID,
            @SubContinent_Name
        )

        /* Return new primary key */
        SET @SubContinent_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateE04_SubContinent]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateE04_SubContinent]
    @SubContinent_ID int,
    @SubContinent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID] FROM [2_SubContinents]
            WHERE
                [SubContinent_ID] = @SubContinent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E04_SubContinent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 2_SubContinents */
        UPDATE [2_SubContinents]
        SET
            [SubContinent_Name] = @SubContinent_Name
        WHERE
            [SubContinent_ID] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteE04_SubContinent]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteE04_SubContinent]
    @SubContinent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID] FROM [2_SubContinents]
            WHERE
                [SubContinent_ID] = @SubContinent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E04_SubContinent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark child E12_CityRoad as not active */
        UPDATE [6_CityRoads]
        SET    [IsActive] = 'false'
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child E11_City_ReChild as not active */
        UPDATE [5_Cities_ReChild]
        SET    [IsActive] = 'false'
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child E11_City_Child as not active */
        UPDATE [5_Cities_Child]
        SET    [IsActive] = 'false'
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child E10_City as not active */
        UPDATE [5_Cities]
        SET    [IsActive] = 'false'
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child E09_Region_ReChild as not active */
        UPDATE [4_Regions_ReChild]
        SET    [IsActive] = 'false'
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child E09_Region_Child as not active */
        UPDATE [4_Regions_Child]
        SET    [IsActive] = 'false'
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child E08_Region as not active */
        UPDATE [4_Regions]
        SET    [IsActive] = 'false'
        FROM [4_Regions]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child E07_Country_ReChild as not active */
        UPDATE [3_Countries_ReChild]
        SET    [IsActive] = 'false'
        FROM [3_Countries_ReChild]
            INNER JOIN [3_Countries] ON [3_Countries_ReChild].[Country_ID2] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child E07_Country_Child as not active */
        UPDATE [3_Countries_Child]
        SET    [IsActive] = 'false'
        FROM [3_Countries_Child]
            INNER JOIN [3_Countries] ON [3_Countries_Child].[Country_ID1] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child E06_Country as not active */
        UPDATE [3_Countries]
        SET    [IsActive] = 'false'
        FROM [3_Countries]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child E05_SubContinent_ReChild as not active */
        UPDATE [2_SubContinents_ReChild]
        SET    [IsActive] = 'false'
        FROM [2_SubContinents_ReChild]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_ReChild].[SubContinent_ID2] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark child E05_SubContinent_Child as not active */
        UPDATE [2_SubContinents_Child]
        SET    [IsActive] = 'false'
        FROM [2_SubContinents_Child]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_Child].[SubContinent_ID1] = [2_SubContinents].[SubContinent_ID]
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

        /* Mark E04_SubContinent object as not active */
        UPDATE [2_SubContinents]
        SET    [IsActive] = 'false'
        WHERE
            [2_SubContinents].[SubContinent_ID] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteC02_Continent]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteC02_Continent]
    @Continent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID] FROM [1_Continents]
            WHERE
                [Continent_ID] = @Continent_ID
        )
        BEGIN
            RAISERROR ('''C02_Continent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete child C12_CityRoad from 6_CityRoads */
        DELETE
            [6_CityRoads]
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child C11_City_ReChild from 5_Cities_ReChild */
        DELETE
            [5_Cities_ReChild]
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child C11_City_Child from 5_Cities_Child */
        DELETE
            [5_Cities_Child]
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child C10_City from 5_Cities */
        DELETE
            [5_Cities]
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child C09_Region_ReChild from 4_Regions_ReChild */
        DELETE
            [4_Regions_ReChild]
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child C09_Region_Child from 4_Regions_Child */
        DELETE
            [4_Regions_Child]
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child C08_Region from 4_Regions */
        DELETE
            [4_Regions]
        FROM [4_Regions]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child C07_Country_ReChild from 3_Countries_ReChild */
        DELETE
            [3_Countries_ReChild]
        FROM [3_Countries_ReChild]
            INNER JOIN [3_Countries] ON [3_Countries_ReChild].[Country_ID2] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child C07_Country_Child from 3_Countries_Child */
        DELETE
            [3_Countries_Child]
        FROM [3_Countries_Child]
            INNER JOIN [3_Countries] ON [3_Countries_Child].[Country_ID1] = [3_Countries].[Country_ID]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child C06_Country from 3_Countries */
        DELETE
            [3_Countries]
        FROM [3_Countries]
            INNER JOIN [2_SubContinents] ON [3_Countries].[Parent_SubContinent_ID] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child C05_SubContinent_ReChild from 2_SubContinents_ReChild */
        DELETE
            [2_SubContinents_ReChild]
        FROM [2_SubContinents_ReChild]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_ReChild].[SubContinent_ID2] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child C05_SubContinent_Child from 2_SubContinents_Child */
        DELETE
            [2_SubContinents_Child]
        FROM [2_SubContinents_Child]
            INNER JOIN [2_SubContinents] ON [2_SubContinents_Child].[SubContinent_ID1] = [2_SubContinents].[SubContinent_ID]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child C04_SubContinent from 2_SubContinents */
        DELETE
            [2_SubContinents]
        FROM [2_SubContinents]
            INNER JOIN [1_Continents] ON [2_SubContinents].[Parent_Continent_ID] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child C03_Continent_ReChild from 1_Continents_ReChild */
        DELETE
            [1_Continents_ReChild]
        FROM [1_Continents_ReChild]
            INNER JOIN [1_Continents] ON [1_Continents_ReChild].[Continent_ID2] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete child C03_Continent_Child from 1_Continents_Child */
        DELETE
            [1_Continents_Child]
        FROM [1_Continents_Child]
            INNER JOIN [1_Continents] ON [1_Continents_Child].[Continent_ID1] = [1_Continents].[Continent_ID]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

        /* Delete C02_Continent object from 1_Continents */
        DELETE
        FROM [1_Continents]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetC02_Continent]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetC02_Continent]
    @Continent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get C02_Continent from table */
        SELECT
            [1_Continents].[Continent_ID],
            [1_Continents].[Continent_Name]
        FROM [1_Continents]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddC02_Continent]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddC02_Continent]
    @Continent_ID int OUTPUT,
    @Continent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 1_Continents */
        INSERT INTO [1_Continents]
        (
            [Continent_Name]
        )
        VALUES
        (
            @Continent_Name
        )

        /* Return new primary key */
        SET @Continent_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateC02_Continent]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateC02_Continent]
    @Continent_ID int,
    @Continent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID] FROM [1_Continents]
            WHERE
                [Continent_ID] = @Continent_ID
        )
        BEGIN
            RAISERROR ('''C02_Continent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 1_Continents */
        UPDATE [1_Continents]
        SET
            [Continent_Name] = @Continent_Name
        WHERE
            [Continent_ID] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetH01_ContinentColl]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetH01_ContinentColl]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get H02_Continent from table */
        SELECT
            [1_Continents].[Continent_ID],
            [1_Continents].[Continent_Name]
        FROM [1_Continents]
        WHERE
            [1_Continents].[IsActive] = 'true'

    END
GO
/****** Object:  StoredProcedure [dbo].[AddH02_Continent]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddH02_Continent]
    @Continent_ID int OUTPUT,
    @Continent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 1_Continents */
        INSERT INTO [1_Continents]
        (
            [Continent_Name]
        )
        VALUES
        (
            @Continent_Name
        )

        /* Return new primary key */
        SET @Continent_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateH02_Continent]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateH02_Continent]
    @Continent_ID int,
    @Continent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID] FROM [1_Continents]
            WHERE
                [Continent_ID] = @Continent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H02_Continent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 1_Continents */
        UPDATE [1_Continents]
        SET
            [Continent_Name] = @Continent_Name
        WHERE
            [Continent_ID] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateE02_Continent]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateE02_Continent]
    @Continent_ID int,
    @Continent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID] FROM [1_Continents]
            WHERE
                [Continent_ID] = @Continent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E02_Continent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 1_Continents */
        UPDATE [1_Continents]
        SET
            [Continent_Name] = @Continent_Name
        WHERE
            [Continent_ID] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddE02_Continent]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddE02_Continent]
    @Continent_ID int OUTPUT,
    @Continent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 1_Continents */
        INSERT INTO [1_Continents]
        (
            [Continent_Name]
        )
        VALUES
        (
            @Continent_Name
        )

        /* Return new primary key */
        SET @Continent_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateD02_Continent]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateD02_Continent]
    @Continent_ID int,
    @Continent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID] FROM [1_Continents]
            WHERE
                [Continent_ID] = @Continent_ID
        )
        BEGIN
            RAISERROR ('''D02_Continent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 1_Continents */
        UPDATE [1_Continents]
        SET
            [Continent_Name] = @Continent_Name
        WHERE
            [Continent_ID] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddD02_Continent]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddD02_Continent]
    @Continent_ID int OUTPUT,
    @Continent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 1_Continents */
        INSERT INTO [1_Continents]
        (
            [Continent_Name]
        )
        VALUES
        (
            @Continent_Name
        )

        /* Return new primary key */
        SET @Continent_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[GetD01_ContinentColl]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetD01_ContinentColl]
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D02_Continent from table */
        SELECT
            [1_Continents].[Continent_ID],
            [1_Continents].[Continent_Name]
        FROM [1_Continents]

    END
GO
/****** Object:  StoredProcedure [dbo].[GetG02_Continent]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetG02_Continent]
    @Continent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get G02_Continent from table */
        SELECT
            [1_Continents].[Continent_ID],
            [1_Continents].[Continent_Name]
        FROM [1_Continents]
        WHERE
            [1_Continents].[Continent_ID] = @Continent_ID AND
            [1_Continents].[IsActive] = 'true'

    END
GO
/****** Object:  StoredProcedure [dbo].[AddG02_Continent]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddG02_Continent]
    @Continent_ID int OUTPUT,
    @Continent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 1_Continents */
        INSERT INTO [1_Continents]
        (
            [Continent_Name]
        )
        VALUES
        (
            @Continent_Name
        )

        /* Return new primary key */
        SET @Continent_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateG02_Continent]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateG02_Continent]
    @Continent_ID int,
    @Continent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID] FROM [1_Continents]
            WHERE
                [Continent_ID] = @Continent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G02_Continent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 1_Continents */
        UPDATE [1_Continents]
        SET
            [Continent_Name] = @Continent_Name
        WHERE
            [Continent_ID] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddB02_Continent]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddB02_Continent]
    @Continent_ID int OUTPUT,
    @Continent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 1_Continents */
        INSERT INTO [1_Continents]
        (
            [Continent_Name]
        )
        VALUES
        (
            @Continent_Name
        )

        /* Return new primary key */
        SET @Continent_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateB02_Continent]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateB02_Continent]
    @Continent_ID int,
    @Continent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID] FROM [1_Continents]
            WHERE
                [Continent_ID] = @Continent_ID
        )
        BEGIN
            RAISERROR ('''B02_Continent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 1_Continents */
        UPDATE [1_Continents]
        SET
            [Continent_Name] = @Continent_Name
        WHERE
            [Continent_ID] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddA02_Continent]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddA02_Continent]
    @Continent_ID int OUTPUT,
    @Continent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 1_Continents */
        INSERT INTO [1_Continents]
        (
            [Continent_Name]
        )
        VALUES
        (
            @Continent_Name
        )

        /* Return new primary key */
        SET @Continent_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateA02_Continent]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateA02_Continent]
    @Continent_ID int,
    @Continent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID] FROM [1_Continents]
            WHERE
                [Continent_ID] = @Continent_ID
        )
        BEGIN
            RAISERROR ('''A02_Continent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 1_Continents */
        UPDATE [1_Continents]
        SET
            [Continent_Name] = @Continent_Name
        WHERE
            [Continent_ID] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateF02_Continent]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateF02_Continent]
    @Continent_ID int,
    @Continent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID] FROM [1_Continents]
            WHERE
                [Continent_ID] = @Continent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F02_Continent'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 1_Continents */
        UPDATE [1_Continents]
        SET
            [Continent_Name] = @Continent_Name
        WHERE
            [Continent_ID] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddF02_Continent]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddF02_Continent]
    @Continent_ID int OUTPUT,
    @Continent_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 1_Continents */
        INSERT INTO [1_Continents]
        (
            [Continent_Name]
        )
        VALUES
        (
            @Continent_Name
        )

        /* Return new primary key */
        SET @Continent_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateH06_Country]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateH06_Country]
    @Country_ID int,
    @Country_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID] FROM [3_Countries]
            WHERE
                [Country_ID] = @Country_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H06_Country'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 3_Countries */
        UPDATE [3_Countries]
        SET
            [Country_Name] = @Country_Name
        WHERE
            [Country_ID] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddH06_Country]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddH06_Country]
    @Country_ID int OUTPUT,
    @SubContinent_ID int,
    @Country_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 3_Countries */
        INSERT INTO [3_Countries]
        (
            [Parent_SubContinent_ID],
            [Country_Name]
        )
        VALUES
        (
            @SubContinent_ID,
            @Country_Name
        )

        /* Return new primary key */
        SET @Country_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteH06_Country]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteH06_Country]
    @Country_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID] FROM [3_Countries]
            WHERE
                [Country_ID] = @Country_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H06_Country'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark child H12_CityRoad as not active */
        UPDATE [6_CityRoads]
        SET    [IsActive] = 'false'
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child H11_City_ReChild as not active */
        UPDATE [5_Cities_ReChild]
        SET    [IsActive] = 'false'
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child H11_City_Child as not active */
        UPDATE [5_Cities_Child]
        SET    [IsActive] = 'false'
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child H10_City as not active */
        UPDATE [5_Cities]
        SET    [IsActive] = 'false'
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child H09_Region_ReChild as not active */
        UPDATE [4_Regions_ReChild]
        SET    [IsActive] = 'false'
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child H09_Region_Child as not active */
        UPDATE [4_Regions_Child]
        SET    [IsActive] = 'false'
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child H08_Region as not active */
        UPDATE [4_Regions]
        SET    [IsActive] = 'false'
        FROM [4_Regions]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child H07_Country_ReChild as not active */
        UPDATE [3_Countries_ReChild]
        SET    [IsActive] = 'false'
        FROM [3_Countries_ReChild]
            INNER JOIN [3_Countries] ON [3_Countries_ReChild].[Country_ID2] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child H07_Country_Child as not active */
        UPDATE [3_Countries_Child]
        SET    [IsActive] = 'false'
        FROM [3_Countries_Child]
            INNER JOIN [3_Countries] ON [3_Countries_Child].[Country_ID1] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark H06_Country object as not active */
        UPDATE [3_Countries]
        SET    [IsActive] = 'false'
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateA06_Country]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateA06_Country]
    @Country_ID int,
    @Country_Name varchar(50),
    @Parent_SubContinent_ID int,
    @RowVersion timestamp,
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID] FROM [3_Countries]
            WHERE
                [Country_ID] = @Country_ID
        )
        BEGIN
            RAISERROR ('''A06_Country'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Check for row version match */
        IF NOT EXISTS
        (
            SELECT [Country_ID] FROM [3_Countries]
            WHERE
                [Country_ID] = @Country_ID AND
                [RowVersion] = @RowVersion
        )
        BEGIN
            RAISERROR ('''A06_Country'' object was modified by another user.', 16, 1)
            RETURN
        END

        /* Update object in 3_Countries */
        UPDATE [3_Countries]
        SET
            [Country_Name] = @Country_Name,
            [Parent_SubContinent_ID] = @Parent_SubContinent_ID
        WHERE
            [Country_ID] = @Country_ID AND
            [RowVersion] = @RowVersion

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [3_Countries]
        WHERE
            [Country_ID] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteA06_Country]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteA06_Country]
    @Country_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID] FROM [3_Countries]
            WHERE
                [Country_ID] = @Country_ID
        )
        BEGIN
            RAISERROR ('''A06_Country'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete child A12_CityRoad from 6_CityRoads */
        DELETE
            [6_CityRoads]
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child A11_City_ReChild from 5_Cities_ReChild */
        DELETE
            [5_Cities_ReChild]
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child A11_City_Child from 5_Cities_Child */
        DELETE
            [5_Cities_Child]
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child A10_City from 5_Cities */
        DELETE
            [5_Cities]
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child A09_Region_ReChild from 4_Regions_ReChild */
        DELETE
            [4_Regions_ReChild]
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child A09_Region_Child from 4_Regions_Child */
        DELETE
            [4_Regions_Child]
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child A08_Region from 4_Regions */
        DELETE
            [4_Regions]
        FROM [4_Regions]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child A07_Country_ReChild from 3_Countries_ReChild */
        DELETE
            [3_Countries_ReChild]
        FROM [3_Countries_ReChild]
            INNER JOIN [3_Countries] ON [3_Countries_ReChild].[Country_ID2] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child A07_Country_Child from 3_Countries_Child */
        DELETE
            [3_Countries_Child]
        FROM [3_Countries_Child]
            INNER JOIN [3_Countries] ON [3_Countries_Child].[Country_ID1] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete A06_Country object from 3_Countries */
        DELETE
        FROM [3_Countries]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddA06_Country]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddA06_Country]
    @Country_ID int OUTPUT,
    @SubContinent_ID int,
    @Country_Name varchar(50),
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 3_Countries */
        INSERT INTO [3_Countries]
        (
            [Parent_SubContinent_ID],
            [Country_Name]
        )
        VALUES
        (
            @SubContinent_ID,
            @Country_Name
        )

        /* Return new primary key */
        SET @Country_ID = SCOPE_IDENTITY()

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [3_Countries]
        WHERE
            [Country_ID] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetH05_CountryColl]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetH05_CountryColl]
    @Parent_SubContinent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get H06_Country from table */
        SELECT
            [3_Countries].[Country_ID],
            [3_Countries].[Country_Name]
        FROM [3_Countries]
        WHERE
            [3_Countries].[Parent_SubContinent_ID] = @Parent_SubContinent_ID AND
            [3_Countries].[IsActive] = 'true'

    END
GO
/****** Object:  StoredProcedure [dbo].[AddC06_Country]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddC06_Country]
    @Country_ID int OUTPUT,
    @SubContinent_ID int,
    @Country_Name varchar(50),
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 3_Countries */
        INSERT INTO [3_Countries]
        (
            [Parent_SubContinent_ID],
            [Country_Name]
        )
        VALUES
        (
            @SubContinent_ID,
            @Country_Name
        )

        /* Return new primary key */
        SET @Country_ID = SCOPE_IDENTITY()

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [3_Countries]
        WHERE
            [Country_ID] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateD06_Country]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateD06_Country]
    @Country_ID int,
    @Country_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID] FROM [3_Countries]
            WHERE
                [Country_ID] = @Country_ID
        )
        BEGIN
            RAISERROR ('''D06_Country'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 3_Countries */
        UPDATE [3_Countries]
        SET
            [Country_Name] = @Country_Name
        WHERE
            [Country_ID] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddD06_Country]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddD06_Country]
    @Country_ID int OUTPUT,
    @SubContinent_ID int,
    @Country_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 3_Countries */
        INSERT INTO [3_Countries]
        (
            [Parent_SubContinent_ID],
            [Country_Name]
        )
        VALUES
        (
            @SubContinent_ID,
            @Country_Name
        )

        /* Return new primary key */
        SET @Country_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteD06_Country]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteD06_Country]
    @Country_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID] FROM [3_Countries]
            WHERE
                [Country_ID] = @Country_ID
        )
        BEGIN
            RAISERROR ('''D06_Country'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete child D12_CityRoad from 6_CityRoads */
        DELETE
            [6_CityRoads]
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child D11_City_ReChild from 5_Cities_ReChild */
        DELETE
            [5_Cities_ReChild]
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child D11_City_Child from 5_Cities_Child */
        DELETE
            [5_Cities_Child]
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child D10_City from 5_Cities */
        DELETE
            [5_Cities]
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child D09_Region_ReChild from 4_Regions_ReChild */
        DELETE
            [4_Regions_ReChild]
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child D09_Region_Child from 4_Regions_Child */
        DELETE
            [4_Regions_Child]
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child D08_Region from 4_Regions */
        DELETE
            [4_Regions]
        FROM [4_Regions]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child D07_Country_ReChild from 3_Countries_ReChild */
        DELETE
            [3_Countries_ReChild]
        FROM [3_Countries_ReChild]
            INNER JOIN [3_Countries] ON [3_Countries_ReChild].[Country_ID2] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child D07_Country_Child from 3_Countries_Child */
        DELETE
            [3_Countries_Child]
        FROM [3_Countries_Child]
            INNER JOIN [3_Countries] ON [3_Countries_Child].[Country_ID1] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete D06_Country object from 3_Countries */
        DELETE
        FROM [3_Countries]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteB06_Country]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteB06_Country]
    @Country_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID] FROM [3_Countries]
            WHERE
                [Country_ID] = @Country_ID
        )
        BEGIN
            RAISERROR ('''B06_Country'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete child B12_CityRoad from 6_CityRoads */
        DELETE
            [6_CityRoads]
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child B11_City_ReChild from 5_Cities_ReChild */
        DELETE
            [5_Cities_ReChild]
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child B11_City_Child from 5_Cities_Child */
        DELETE
            [5_Cities_Child]
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child B10_City from 5_Cities */
        DELETE
            [5_Cities]
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child B09_Region_ReChild from 4_Regions_ReChild */
        DELETE
            [4_Regions_ReChild]
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child B09_Region_Child from 4_Regions_Child */
        DELETE
            [4_Regions_Child]
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child B08_Region from 4_Regions */
        DELETE
            [4_Regions]
        FROM [4_Regions]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child B07_Country_ReChild from 3_Countries_ReChild */
        DELETE
            [3_Countries_ReChild]
        FROM [3_Countries_ReChild]
            INNER JOIN [3_Countries] ON [3_Countries_ReChild].[Country_ID2] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child B07_Country_Child from 3_Countries_Child */
        DELETE
            [3_Countries_Child]
        FROM [3_Countries_Child]
            INNER JOIN [3_Countries] ON [3_Countries_Child].[Country_ID1] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete B06_Country object from 3_Countries */
        DELETE
        FROM [3_Countries]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddF06_Country]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddF06_Country]
    @Country_ID int OUTPUT,
    @SubContinent_ID int,
    @Country_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 3_Countries */
        INSERT INTO [3_Countries]
        (
            [Parent_SubContinent_ID],
            [Country_Name]
        )
        VALUES
        (
            @SubContinent_ID,
            @Country_Name
        )

        /* Return new primary key */
        SET @Country_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateF06_Country]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateF06_Country]
    @Country_ID int,
    @Country_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID] FROM [3_Countries]
            WHERE
                [Country_ID] = @Country_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F06_Country'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 3_Countries */
        UPDATE [3_Countries]
        SET
            [Country_Name] = @Country_Name
        WHERE
            [Country_ID] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteF06_Country]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteF06_Country]
    @Country_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID] FROM [3_Countries]
            WHERE
                [Country_ID] = @Country_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F06_Country'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark child F12_CityRoad as not active */
        UPDATE [6_CityRoads]
        SET    [IsActive] = 'false'
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child F11_City_ReChild as not active */
        UPDATE [5_Cities_ReChild]
        SET    [IsActive] = 'false'
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child F11_City_Child as not active */
        UPDATE [5_Cities_Child]
        SET    [IsActive] = 'false'
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child F10_City as not active */
        UPDATE [5_Cities]
        SET    [IsActive] = 'false'
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child F09_Region_ReChild as not active */
        UPDATE [4_Regions_ReChild]
        SET    [IsActive] = 'false'
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child F09_Region_Child as not active */
        UPDATE [4_Regions_Child]
        SET    [IsActive] = 'false'
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child F08_Region as not active */
        UPDATE [4_Regions]
        SET    [IsActive] = 'false'
        FROM [4_Regions]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child F07_Country_ReChild as not active */
        UPDATE [3_Countries_ReChild]
        SET    [IsActive] = 'false'
        FROM [3_Countries_ReChild]
            INNER JOIN [3_Countries] ON [3_Countries_ReChild].[Country_ID2] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child F07_Country_Child as not active */
        UPDATE [3_Countries_Child]
        SET    [IsActive] = 'false'
        FROM [3_Countries_Child]
            INNER JOIN [3_Countries] ON [3_Countries_Child].[Country_ID1] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark F06_Country object as not active */
        UPDATE [3_Countries]
        SET    [IsActive] = 'false'
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetD05_CountryColl]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetD05_CountryColl]
    @Parent_SubContinent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D06_Country from table */
        SELECT
            [3_Countries].[Country_ID],
            [3_Countries].[Country_Name]
        FROM [3_Countries]
        WHERE
            [3_Countries].[Parent_SubContinent_ID] = @Parent_SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateB06_Country]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateB06_Country]
    @Country_ID int,
    @Country_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID] FROM [3_Countries]
            WHERE
                [Country_ID] = @Country_ID
        )
        BEGIN
            RAISERROR ('''B06_Country'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 3_Countries */
        UPDATE [3_Countries]
        SET
            [Country_Name] = @Country_Name
        WHERE
            [Country_ID] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddB06_Country]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddB06_Country]
    @Country_ID int OUTPUT,
    @SubContinent_ID int,
    @Country_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 3_Countries */
        INSERT INTO [3_Countries]
        (
            [Parent_SubContinent_ID],
            [Country_Name]
        )
        VALUES
        (
            @SubContinent_ID,
            @Country_Name
        )

        /* Return new primary key */
        SET @Country_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[GetG05_CountryColl]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetG05_CountryColl]
    @Parent_SubContinent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get G06_Country from table */
        SELECT
            [3_Countries].[Country_ID],
            [3_Countries].[Country_Name],
            [3_Countries].[Parent_SubContinent_ID],
            [3_Countries].[RowVersion]
        FROM [3_Countries]
        WHERE
            [3_Countries].[Parent_SubContinent_ID] = @Parent_SubContinent_ID AND
            [3_Countries].[IsActive] = 'true'

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateG06_Country]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateG06_Country]
    @Country_ID int,
    @Country_Name varchar(50),
    @Parent_SubContinent_ID int,
    @RowVersion timestamp,
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID] FROM [3_Countries]
            WHERE
                [Country_ID] = @Country_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G06_Country'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Check for row version match */
        IF NOT EXISTS
        (
            SELECT [Country_ID] FROM [3_Countries]
            WHERE
                [Country_ID] = @Country_ID AND
                [RowVersion] = @RowVersion
        )
        BEGIN
            RAISERROR ('''G06_Country'' object was modified by another user.', 16, 1)
            RETURN
        END

        /* Update object in 3_Countries */
        UPDATE [3_Countries]
        SET
            [Country_Name] = @Country_Name,
            [Parent_SubContinent_ID] = @Parent_SubContinent_ID
        WHERE
            [Country_ID] = @Country_ID AND
            [RowVersion] = @RowVersion

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [3_Countries]
        WHERE
            [Country_ID] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteG06_Country]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteG06_Country]
    @Country_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID] FROM [3_Countries]
            WHERE
                [Country_ID] = @Country_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G06_Country'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark child G12_CityRoad as not active */
        UPDATE [6_CityRoads]
        SET    [IsActive] = 'false'
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child G11_City_ReChild as not active */
        UPDATE [5_Cities_ReChild]
        SET    [IsActive] = 'false'
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child G11_City_Child as not active */
        UPDATE [5_Cities_Child]
        SET    [IsActive] = 'false'
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child G10_City as not active */
        UPDATE [5_Cities]
        SET    [IsActive] = 'false'
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child G09_Region_ReChild as not active */
        UPDATE [4_Regions_ReChild]
        SET    [IsActive] = 'false'
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child G09_Region_Child as not active */
        UPDATE [4_Regions_Child]
        SET    [IsActive] = 'false'
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child G08_Region as not active */
        UPDATE [4_Regions]
        SET    [IsActive] = 'false'
        FROM [4_Regions]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child G07_Country_ReChild as not active */
        UPDATE [3_Countries_ReChild]
        SET    [IsActive] = 'false'
        FROM [3_Countries_ReChild]
            INNER JOIN [3_Countries] ON [3_Countries_ReChild].[Country_ID2] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child G07_Country_Child as not active */
        UPDATE [3_Countries_Child]
        SET    [IsActive] = 'false'
        FROM [3_Countries_Child]
            INNER JOIN [3_Countries] ON [3_Countries_Child].[Country_ID1] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark G06_Country object as not active */
        UPDATE [3_Countries]
        SET    [IsActive] = 'false'
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddG06_Country]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddG06_Country]
    @Country_ID int OUTPUT,
    @SubContinent_ID int,
    @Country_Name varchar(50),
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 3_Countries */
        INSERT INTO [3_Countries]
        (
            [Parent_SubContinent_ID],
            [Country_Name]
        )
        VALUES
        (
            @SubContinent_ID,
            @Country_Name
        )

        /* Return new primary key */
        SET @Country_ID = SCOPE_IDENTITY()

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [3_Countries]
        WHERE
            [Country_ID] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateC06_Country]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateC06_Country]
    @Country_ID int,
    @Country_Name varchar(50),
    @Parent_SubContinent_ID int,
    @RowVersion timestamp,
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID] FROM [3_Countries]
            WHERE
                [Country_ID] = @Country_ID
        )
        BEGIN
            RAISERROR ('''C06_Country'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Check for row version match */
        IF NOT EXISTS
        (
            SELECT [Country_ID] FROM [3_Countries]
            WHERE
                [Country_ID] = @Country_ID AND
                [RowVersion] = @RowVersion
        )
        BEGIN
            RAISERROR ('''C06_Country'' object was modified by another user.', 16, 1)
            RETURN
        END

        /* Update object in 3_Countries */
        UPDATE [3_Countries]
        SET
            [Country_Name] = @Country_Name,
            [Parent_SubContinent_ID] = @Parent_SubContinent_ID
        WHERE
            [Country_ID] = @Country_ID AND
            [RowVersion] = @RowVersion

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [3_Countries]
        WHERE
            [Country_ID] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteC06_Country]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteC06_Country]
    @Country_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID] FROM [3_Countries]
            WHERE
                [Country_ID] = @Country_ID
        )
        BEGIN
            RAISERROR ('''C06_Country'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete child C12_CityRoad from 6_CityRoads */
        DELETE
            [6_CityRoads]
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child C11_City_ReChild from 5_Cities_ReChild */
        DELETE
            [5_Cities_ReChild]
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child C11_City_Child from 5_Cities_Child */
        DELETE
            [5_Cities_Child]
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child C10_City from 5_Cities */
        DELETE
            [5_Cities]
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child C09_Region_ReChild from 4_Regions_ReChild */
        DELETE
            [4_Regions_ReChild]
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child C09_Region_Child from 4_Regions_Child */
        DELETE
            [4_Regions_Child]
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child C08_Region from 4_Regions */
        DELETE
            [4_Regions]
        FROM [4_Regions]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child C07_Country_ReChild from 3_Countries_ReChild */
        DELETE
            [3_Countries_ReChild]
        FROM [3_Countries_ReChild]
            INNER JOIN [3_Countries] ON [3_Countries_ReChild].[Country_ID2] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete child C07_Country_Child from 3_Countries_Child */
        DELETE
            [3_Countries_Child]
        FROM [3_Countries_Child]
            INNER JOIN [3_Countries] ON [3_Countries_Child].[Country_ID1] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Delete C06_Country object from 3_Countries */
        DELETE
        FROM [3_Countries]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateE06_Country]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateE06_Country]
    @Country_ID int,
    @Country_Name varchar(50),
    @Parent_SubContinent_ID int,
    @RowVersion timestamp,
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID] FROM [3_Countries]
            WHERE
                [Country_ID] = @Country_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E06_Country'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Check for row version match */
        IF NOT EXISTS
        (
            SELECT [Country_ID] FROM [3_Countries]
            WHERE
                [Country_ID] = @Country_ID AND
                [RowVersion] = @RowVersion
        )
        BEGIN
            RAISERROR ('''E06_Country'' object was modified by another user.', 16, 1)
            RETURN
        END

        /* Update object in 3_Countries */
        UPDATE [3_Countries]
        SET
            [Country_Name] = @Country_Name,
            [Parent_SubContinent_ID] = @Parent_SubContinent_ID
        WHERE
            [Country_ID] = @Country_ID AND
            [RowVersion] = @RowVersion

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [3_Countries]
        WHERE
            [Country_ID] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddE06_Country]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddE06_Country]
    @Country_ID int OUTPUT,
    @SubContinent_ID int,
    @Country_Name varchar(50),
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 3_Countries */
        INSERT INTO [3_Countries]
        (
            [Parent_SubContinent_ID],
            [Country_Name]
        )
        VALUES
        (
            @SubContinent_ID,
            @Country_Name
        )

        /* Return new primary key */
        SET @Country_ID = SCOPE_IDENTITY()

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [3_Countries]
        WHERE
            [Country_ID] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetC05_CountryColl]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetC05_CountryColl]
    @Parent_SubContinent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get C06_Country from table */
        SELECT
            [3_Countries].[Country_ID],
            [3_Countries].[Country_Name],
            [3_Countries].[Parent_SubContinent_ID],
            [3_Countries].[RowVersion]
        FROM [3_Countries]
        WHERE
            [3_Countries].[Parent_SubContinent_ID] = @Parent_SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteE06_Country]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteE06_Country]
    @Country_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID] FROM [3_Countries]
            WHERE
                [Country_ID] = @Country_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E06_Country'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark child E12_CityRoad as not active */
        UPDATE [6_CityRoads]
        SET    [IsActive] = 'false'
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child E11_City_ReChild as not active */
        UPDATE [5_Cities_ReChild]
        SET    [IsActive] = 'false'
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child E11_City_Child as not active */
        UPDATE [5_Cities_Child]
        SET    [IsActive] = 'false'
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child E10_City as not active */
        UPDATE [5_Cities]
        SET    [IsActive] = 'false'
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child E09_Region_ReChild as not active */
        UPDATE [4_Regions_ReChild]
        SET    [IsActive] = 'false'
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child E09_Region_Child as not active */
        UPDATE [4_Regions_Child]
        SET    [IsActive] = 'false'
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child E08_Region as not active */
        UPDATE [4_Regions]
        SET    [IsActive] = 'false'
        FROM [4_Regions]
            INNER JOIN [3_Countries] ON [4_Regions].[Parent_Country_ID] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child E07_Country_ReChild as not active */
        UPDATE [3_Countries_ReChild]
        SET    [IsActive] = 'false'
        FROM [3_Countries_ReChild]
            INNER JOIN [3_Countries] ON [3_Countries_ReChild].[Country_ID2] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark child E07_Country_Child as not active */
        UPDATE [3_Countries_Child]
        SET    [IsActive] = 'false'
        FROM [3_Countries_Child]
            INNER JOIN [3_Countries] ON [3_Countries_Child].[Country_ID1] = [3_Countries].[Country_ID]
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

        /* Mark E06_Country object as not active */
        UPDATE [3_Countries]
        SET    [IsActive] = 'false'
        WHERE
            [3_Countries].[Country_ID] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddE08_Region]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddE08_Region]
    @Region_ID int OUTPUT,
    @Country_ID int,
    @Region_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 4_Regions */
        INSERT INTO [4_Regions]
        (
            [Parent_Country_ID],
            [Region_Name]
        )
        VALUES
        (
            @Country_ID,
            @Region_Name
        )

        /* Return new primary key */
        SET @Region_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateE08_Region]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateE08_Region]
    @Region_ID int,
    @Region_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID] FROM [4_Regions]
            WHERE
                [Region_ID] = @Region_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E08_Region'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 4_Regions */
        UPDATE [4_Regions]
        SET
            [Region_Name] = @Region_Name
        WHERE
            [Region_ID] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteE08_Region]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteE08_Region]
    @Region_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID] FROM [4_Regions]
            WHERE
                [Region_ID] = @Region_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E08_Region'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark child E12_CityRoad as not active */
        UPDATE [6_CityRoads]
        SET    [IsActive] = 'false'
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Mark child E11_City_ReChild as not active */
        UPDATE [5_Cities_ReChild]
        SET    [IsActive] = 'false'
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Mark child E11_City_Child as not active */
        UPDATE [5_Cities_Child]
        SET    [IsActive] = 'false'
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Mark child E10_City as not active */
        UPDATE [5_Cities]
        SET    [IsActive] = 'false'
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Mark child E09_Region_ReChild as not active */
        UPDATE [4_Regions_ReChild]
        SET    [IsActive] = 'false'
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Mark child E09_Region_Child as not active */
        UPDATE [4_Regions_Child]
        SET    [IsActive] = 'false'
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Mark E08_Region object as not active */
        UPDATE [4_Regions]
        SET    [IsActive] = 'false'
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddB08_Region]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddB08_Region]
    @Region_ID int OUTPUT,
    @Country_ID int,
    @Region_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 4_Regions */
        INSERT INTO [4_Regions]
        (
            [Parent_Country_ID],
            [Region_Name]
        )
        VALUES
        (
            @Country_ID,
            @Region_Name
        )

        /* Return new primary key */
        SET @Region_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateB08_Region]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateB08_Region]
    @Region_ID int,
    @Region_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID] FROM [4_Regions]
            WHERE
                [Region_ID] = @Region_ID
        )
        BEGIN
            RAISERROR ('''B08_Region'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 4_Regions */
        UPDATE [4_Regions]
        SET
            [Region_Name] = @Region_Name
        WHERE
            [Region_ID] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddG08_Region]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddG08_Region]
    @Region_ID int OUTPUT,
    @Country_ID int,
    @Region_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 4_Regions */
        INSERT INTO [4_Regions]
        (
            [Parent_Country_ID],
            [Region_Name]
        )
        VALUES
        (
            @Country_ID,
            @Region_Name
        )

        /* Return new primary key */
        SET @Region_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteB08_Region]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteB08_Region]
    @Region_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID] FROM [4_Regions]
            WHERE
                [Region_ID] = @Region_ID
        )
        BEGIN
            RAISERROR ('''B08_Region'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete child B12_CityRoad from 6_CityRoads */
        DELETE
            [6_CityRoads]
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Delete child B11_City_ReChild from 5_Cities_ReChild */
        DELETE
            [5_Cities_ReChild]
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Delete child B11_City_Child from 5_Cities_Child */
        DELETE
            [5_Cities_Child]
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Delete child B10_City from 5_Cities */
        DELETE
            [5_Cities]
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Delete child B09_Region_ReChild from 4_Regions_ReChild */
        DELETE
            [4_Regions_ReChild]
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Delete child B09_Region_Child from 4_Regions_Child */
        DELETE
            [4_Regions_Child]
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Delete B08_Region object from 4_Regions */
        DELETE
        FROM [4_Regions]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteG08_Region]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteG08_Region]
    @Region_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID] FROM [4_Regions]
            WHERE
                [Region_ID] = @Region_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G08_Region'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark child G12_CityRoad as not active */
        UPDATE [6_CityRoads]
        SET    [IsActive] = 'false'
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Mark child G11_City_ReChild as not active */
        UPDATE [5_Cities_ReChild]
        SET    [IsActive] = 'false'
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Mark child G11_City_Child as not active */
        UPDATE [5_Cities_Child]
        SET    [IsActive] = 'false'
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Mark child G10_City as not active */
        UPDATE [5_Cities]
        SET    [IsActive] = 'false'
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Mark child G09_Region_ReChild as not active */
        UPDATE [4_Regions_ReChild]
        SET    [IsActive] = 'false'
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Mark child G09_Region_Child as not active */
        UPDATE [4_Regions_Child]
        SET    [IsActive] = 'false'
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Mark G08_Region object as not active */
        UPDATE [4_Regions]
        SET    [IsActive] = 'false'
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateG08_Region]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateG08_Region]
    @Region_ID int,
    @Region_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID] FROM [4_Regions]
            WHERE
                [Region_ID] = @Region_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G08_Region'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 4_Regions */
        UPDATE [4_Regions]
        SET
            [Region_Name] = @Region_Name
        WHERE
            [Region_ID] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetG07_RegionColl]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetG07_RegionColl]
    @Parent_Country_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get G08_Region from table */
        SELECT
            [4_Regions].[Region_ID],
            [4_Regions].[Region_Name]
        FROM [4_Regions]
        WHERE
            [4_Regions].[Parent_Country_ID] = @Parent_Country_ID AND
            [4_Regions].[IsActive] = 'true'

    END
GO
/****** Object:  StoredProcedure [dbo].[AddF08_Region]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddF08_Region]
    @Region_ID int OUTPUT,
    @Country_ID int,
    @Region_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 4_Regions */
        INSERT INTO [4_Regions]
        (
            [Parent_Country_ID],
            [Region_Name]
        )
        VALUES
        (
            @Country_ID,
            @Region_Name
        )

        /* Return new primary key */
        SET @Region_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateF08_Region]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateF08_Region]
    @Region_ID int,
    @Region_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID] FROM [4_Regions]
            WHERE
                [Region_ID] = @Region_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F08_Region'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 4_Regions */
        UPDATE [4_Regions]
        SET
            [Region_Name] = @Region_Name
        WHERE
            [Region_ID] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteF08_Region]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteF08_Region]
    @Region_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID] FROM [4_Regions]
            WHERE
                [Region_ID] = @Region_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F08_Region'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark child F12_CityRoad as not active */
        UPDATE [6_CityRoads]
        SET    [IsActive] = 'false'
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Mark child F11_City_ReChild as not active */
        UPDATE [5_Cities_ReChild]
        SET    [IsActive] = 'false'
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Mark child F11_City_Child as not active */
        UPDATE [5_Cities_Child]
        SET    [IsActive] = 'false'
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Mark child F10_City as not active */
        UPDATE [5_Cities]
        SET    [IsActive] = 'false'
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Mark child F09_Region_ReChild as not active */
        UPDATE [4_Regions_ReChild]
        SET    [IsActive] = 'false'
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Mark child F09_Region_Child as not active */
        UPDATE [4_Regions_Child]
        SET    [IsActive] = 'false'
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Mark F08_Region object as not active */
        UPDATE [4_Regions]
        SET    [IsActive] = 'false'
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddH08_Region]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddH08_Region]
    @Region_ID int OUTPUT,
    @Country_ID int,
    @Region_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 4_Regions */
        INSERT INTO [4_Regions]
        (
            [Parent_Country_ID],
            [Region_Name]
        )
        VALUES
        (
            @Country_ID,
            @Region_Name
        )

        /* Return new primary key */
        SET @Region_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[AddA08_Region]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddA08_Region]
    @Region_ID int OUTPUT,
    @Country_ID int,
    @Region_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 4_Regions */
        INSERT INTO [4_Regions]
        (
            [Parent_Country_ID],
            [Region_Name]
        )
        VALUES
        (
            @Country_ID,
            @Region_Name
        )

        /* Return new primary key */
        SET @Region_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateA08_Region]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateA08_Region]
    @Region_ID int,
    @Region_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID] FROM [4_Regions]
            WHERE
                [Region_ID] = @Region_ID
        )
        BEGIN
            RAISERROR ('''A08_Region'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 4_Regions */
        UPDATE [4_Regions]
        SET
            [Region_Name] = @Region_Name
        WHERE
            [Region_ID] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteA08_Region]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteA08_Region]
    @Region_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID] FROM [4_Regions]
            WHERE
                [Region_ID] = @Region_ID
        )
        BEGIN
            RAISERROR ('''A08_Region'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete child A12_CityRoad from 6_CityRoads */
        DELETE
            [6_CityRoads]
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Delete child A11_City_ReChild from 5_Cities_ReChild */
        DELETE
            [5_Cities_ReChild]
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Delete child A11_City_Child from 5_Cities_Child */
        DELETE
            [5_Cities_Child]
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Delete child A10_City from 5_Cities */
        DELETE
            [5_Cities]
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Delete child A09_Region_ReChild from 4_Regions_ReChild */
        DELETE
            [4_Regions_ReChild]
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Delete child A09_Region_Child from 4_Regions_Child */
        DELETE
            [4_Regions_Child]
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Delete A08_Region object from 4_Regions */
        DELETE
        FROM [4_Regions]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddD08_Region]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddD08_Region]
    @Region_ID int OUTPUT,
    @Country_ID int,
    @Region_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 4_Regions */
        INSERT INTO [4_Regions]
        (
            [Parent_Country_ID],
            [Region_Name]
        )
        VALUES
        (
            @Country_ID,
            @Region_Name
        )

        /* Return new primary key */
        SET @Region_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteD08_Region]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteD08_Region]
    @Region_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID] FROM [4_Regions]
            WHERE
                [Region_ID] = @Region_ID
        )
        BEGIN
            RAISERROR ('''D08_Region'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete child D12_CityRoad from 6_CityRoads */
        DELETE
            [6_CityRoads]
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Delete child D11_City_ReChild from 5_Cities_ReChild */
        DELETE
            [5_Cities_ReChild]
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Delete child D11_City_Child from 5_Cities_Child */
        DELETE
            [5_Cities_Child]
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Delete child D10_City from 5_Cities */
        DELETE
            [5_Cities]
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Delete child D09_Region_ReChild from 4_Regions_ReChild */
        DELETE
            [4_Regions_ReChild]
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Delete child D09_Region_Child from 4_Regions_Child */
        DELETE
            [4_Regions_Child]
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Delete D08_Region object from 4_Regions */
        DELETE
        FROM [4_Regions]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateD08_Region]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateD08_Region]
    @Region_ID int,
    @Region_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID] FROM [4_Regions]
            WHERE
                [Region_ID] = @Region_ID
        )
        BEGIN
            RAISERROR ('''D08_Region'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 4_Regions */
        UPDATE [4_Regions]
        SET
            [Region_Name] = @Region_Name
        WHERE
            [Region_ID] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetD07_RegionColl]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetD07_RegionColl]
    @Parent_Country_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D08_Region from table */
        SELECT
            [4_Regions].[Region_ID],
            [4_Regions].[Region_Name]
        FROM [4_Regions]
        WHERE
            [4_Regions].[Parent_Country_ID] = @Parent_Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetC07_RegionColl]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetC07_RegionColl]
    @Parent_Country_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get C08_Region from table */
        SELECT
            [4_Regions].[Region_ID],
            [4_Regions].[Region_Name]
        FROM [4_Regions]
        WHERE
            [4_Regions].[Parent_Country_ID] = @Parent_Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteC08_Region]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteC08_Region]
    @Region_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID] FROM [4_Regions]
            WHERE
                [Region_ID] = @Region_ID
        )
        BEGIN
            RAISERROR ('''C08_Region'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete child C12_CityRoad from 6_CityRoads */
        DELETE
            [6_CityRoads]
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Delete child C11_City_ReChild from 5_Cities_ReChild */
        DELETE
            [5_Cities_ReChild]
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Delete child C11_City_Child from 5_Cities_Child */
        DELETE
            [5_Cities_Child]
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Delete child C10_City from 5_Cities */
        DELETE
            [5_Cities]
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Delete child C09_Region_ReChild from 4_Regions_ReChild */
        DELETE
            [4_Regions_ReChild]
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Delete child C09_Region_Child from 4_Regions_Child */
        DELETE
            [4_Regions_Child]
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Delete C08_Region object from 4_Regions */
        DELETE
        FROM [4_Regions]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateC08_Region]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateC08_Region]
    @Region_ID int,
    @Region_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID] FROM [4_Regions]
            WHERE
                [Region_ID] = @Region_ID
        )
        BEGIN
            RAISERROR ('''C08_Region'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 4_Regions */
        UPDATE [4_Regions]
        SET
            [Region_Name] = @Region_Name
        WHERE
            [Region_ID] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddC08_Region]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddC08_Region]
    @Region_ID int OUTPUT,
    @Country_ID int,
    @Region_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 4_Regions */
        INSERT INTO [4_Regions]
        (
            [Parent_Country_ID],
            [Region_Name]
        )
        VALUES
        (
            @Country_ID,
            @Region_Name
        )

        /* Return new primary key */
        SET @Region_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[GetH07_RegionColl]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetH07_RegionColl]
    @Parent_Country_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get H08_Region from table */
        SELECT
            [4_Regions].[Region_ID],
            [4_Regions].[Region_Name]
        FROM [4_Regions]
        WHERE
            [4_Regions].[Parent_Country_ID] = @Parent_Country_ID AND
            [4_Regions].[IsActive] = 'true'

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateH08_Region]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateH08_Region]
    @Region_ID int,
    @Region_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID] FROM [4_Regions]
            WHERE
                [Region_ID] = @Region_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H08_Region'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 4_Regions */
        UPDATE [4_Regions]
        SET
            [Region_Name] = @Region_Name
        WHERE
            [Region_ID] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteH08_Region]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteH08_Region]
    @Region_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID] FROM [4_Regions]
            WHERE
                [Region_ID] = @Region_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H08_Region'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark child H12_CityRoad as not active */
        UPDATE [6_CityRoads]
        SET    [IsActive] = 'false'
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Mark child H11_City_ReChild as not active */
        UPDATE [5_Cities_ReChild]
        SET    [IsActive] = 'false'
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Mark child H11_City_Child as not active */
        UPDATE [5_Cities_Child]
        SET    [IsActive] = 'false'
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Mark child H10_City as not active */
        UPDATE [5_Cities]
        SET    [IsActive] = 'false'
        FROM [5_Cities]
            INNER JOIN [4_Regions] ON [5_Cities].[Parent_Region_ID] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Mark child H09_Region_ReChild as not active */
        UPDATE [4_Regions_ReChild]
        SET    [IsActive] = 'false'
        FROM [4_Regions_ReChild]
            INNER JOIN [4_Regions] ON [4_Regions_ReChild].[Region_ID2] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Mark child H09_Region_Child as not active */
        UPDATE [4_Regions_Child]
        SET    [IsActive] = 'false'
        FROM [4_Regions_Child]
            INNER JOIN [4_Regions] ON [4_Regions_Child].[Region_ID1] = [4_Regions].[Region_ID]
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

        /* Mark H08_Region object as not active */
        UPDATE [4_Regions]
        SET    [IsActive] = 'false'
        WHERE
            [4_Regions].[Region_ID] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteC10_City]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteC10_City]
    @City_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID] FROM [5_Cities]
            WHERE
                [City_ID] = @City_ID
        )
        BEGIN
            RAISERROR ('''C10_City'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete child C12_CityRoad from 6_CityRoads */
        DELETE
            [6_CityRoads]
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
        WHERE
            [5_Cities].[City_ID] = @City_ID

        /* Delete child C11_City_ReChild from 5_Cities_ReChild */
        DELETE
            [5_Cities_ReChild]
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
        WHERE
            [5_Cities].[City_ID] = @City_ID

        /* Delete child C11_City_Child from 5_Cities_Child */
        DELETE
            [5_Cities_Child]
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
        WHERE
            [5_Cities].[City_ID] = @City_ID

        /* Delete C10_City object from 5_Cities */
        DELETE
        FROM [5_Cities]
        WHERE
            [5_Cities].[City_ID] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateC10_City]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateC10_City]
    @City_ID int,
    @City_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID] FROM [5_Cities]
            WHERE
                [City_ID] = @City_ID
        )
        BEGIN
            RAISERROR ('''C10_City'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 5_Cities */
        UPDATE [5_Cities]
        SET
            [City_Name] = @City_Name
        WHERE
            [City_ID] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddC10_City]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddC10_City]
    @City_ID int OUTPUT,
    @Region_ID int,
    @City_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 5_Cities */
        INSERT INTO [5_Cities]
        (
            [Parent_Region_ID],
            [City_Name]
        )
        VALUES
        (
            @Region_ID,
            @City_Name
        )

        /* Return new primary key */
        SET @City_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[GetC09_CityColl]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetC09_CityColl]
    @Parent_Region_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get C10_City from table */
        SELECT
            [5_Cities].[City_ID],
            [5_Cities].[City_Name]
        FROM [5_Cities]
        WHERE
            [5_Cities].[Parent_Region_ID] = @Parent_Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddE10_City]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddE10_City]
    @City_ID int OUTPUT,
    @Region_ID int,
    @City_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 5_Cities */
        INSERT INTO [5_Cities]
        (
            [Parent_Region_ID],
            [City_Name]
        )
        VALUES
        (
            @Region_ID,
            @City_Name
        )

        /* Return new primary key */
        SET @City_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateE10_City]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateE10_City]
    @City_ID int,
    @City_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID] FROM [5_Cities]
            WHERE
                [City_ID] = @City_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E10_City'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 5_Cities */
        UPDATE [5_Cities]
        SET
            [City_Name] = @City_Name
        WHERE
            [City_ID] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteE10_City]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteE10_City]
    @City_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID] FROM [5_Cities]
            WHERE
                [City_ID] = @City_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E10_City'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark child E12_CityRoad as not active */
        UPDATE [6_CityRoads]
        SET    [IsActive] = 'false'
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
        WHERE
            [5_Cities].[City_ID] = @City_ID

        /* Mark child E11_City_ReChild as not active */
        UPDATE [5_Cities_ReChild]
        SET    [IsActive] = 'false'
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
        WHERE
            [5_Cities].[City_ID] = @City_ID

        /* Mark child E11_City_Child as not active */
        UPDATE [5_Cities_Child]
        SET    [IsActive] = 'false'
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
        WHERE
            [5_Cities].[City_ID] = @City_ID

        /* Mark E10_City object as not active */
        UPDATE [5_Cities]
        SET    [IsActive] = 'false'
        WHERE
            [5_Cities].[City_ID] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetD09_CityColl]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetD09_CityColl]
    @Parent_Region_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D10_City from table */
        SELECT
            [5_Cities].[City_ID],
            [5_Cities].[City_Name]
        FROM [5_Cities]
        WHERE
            [5_Cities].[Parent_Region_ID] = @Parent_Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetH09_CityColl]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetH09_CityColl]
    @Parent_Region_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get H10_City from table */
        SELECT
            [5_Cities].[City_ID],
            [5_Cities].[City_Name]
        FROM [5_Cities]
        WHERE
            [5_Cities].[Parent_Region_ID] = @Parent_Region_ID AND
            [5_Cities].[IsActive] = 'true'

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteH10_City]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteH10_City]
    @City_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID] FROM [5_Cities]
            WHERE
                [City_ID] = @City_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H10_City'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark child H12_CityRoad as not active */
        UPDATE [6_CityRoads]
        SET    [IsActive] = 'false'
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
        WHERE
            [5_Cities].[City_ID] = @City_ID

        /* Mark child H11_City_ReChild as not active */
        UPDATE [5_Cities_ReChild]
        SET    [IsActive] = 'false'
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
        WHERE
            [5_Cities].[City_ID] = @City_ID

        /* Mark child H11_City_Child as not active */
        UPDATE [5_Cities_Child]
        SET    [IsActive] = 'false'
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
        WHERE
            [5_Cities].[City_ID] = @City_ID

        /* Mark H10_City object as not active */
        UPDATE [5_Cities]
        SET    [IsActive] = 'false'
        WHERE
            [5_Cities].[City_ID] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateH10_City]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateH10_City]
    @City_ID int,
    @City_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID] FROM [5_Cities]
            WHERE
                [City_ID] = @City_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H10_City'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 5_Cities */
        UPDATE [5_Cities]
        SET
            [City_Name] = @City_Name
        WHERE
            [City_ID] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddH10_City]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddH10_City]
    @City_ID int OUTPUT,
    @Region_ID int,
    @City_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 5_Cities */
        INSERT INTO [5_Cities]
        (
            [Parent_Region_ID],
            [City_Name]
        )
        VALUES
        (
            @Region_ID,
            @City_Name
        )

        /* Return new primary key */
        SET @City_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateA10_City]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateA10_City]
    @City_ID int,
    @City_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID] FROM [5_Cities]
            WHERE
                [City_ID] = @City_ID
        )
        BEGIN
            RAISERROR ('''A10_City'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 5_Cities */
        UPDATE [5_Cities]
        SET
            [City_Name] = @City_Name
        WHERE
            [City_ID] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteA10_City]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteA10_City]
    @City_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID] FROM [5_Cities]
            WHERE
                [City_ID] = @City_ID
        )
        BEGIN
            RAISERROR ('''A10_City'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete child A12_CityRoad from 6_CityRoads */
        DELETE
            [6_CityRoads]
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
        WHERE
            [5_Cities].[City_ID] = @City_ID

        /* Delete child A11_City_ReChild from 5_Cities_ReChild */
        DELETE
            [5_Cities_ReChild]
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
        WHERE
            [5_Cities].[City_ID] = @City_ID

        /* Delete child A11_City_Child from 5_Cities_Child */
        DELETE
            [5_Cities_Child]
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
        WHERE
            [5_Cities].[City_ID] = @City_ID

        /* Delete A10_City object from 5_Cities */
        DELETE
        FROM [5_Cities]
        WHERE
            [5_Cities].[City_ID] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddA10_City]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddA10_City]
    @City_ID int OUTPUT,
    @Region_ID int,
    @City_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 5_Cities */
        INSERT INTO [5_Cities]
        (
            [Parent_Region_ID],
            [City_Name]
        )
        VALUES
        (
            @Region_ID,
            @City_Name
        )

        /* Return new primary key */
        SET @City_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteF10_City]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteF10_City]
    @City_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID] FROM [5_Cities]
            WHERE
                [City_ID] = @City_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F10_City'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark child F12_CityRoad as not active */
        UPDATE [6_CityRoads]
        SET    [IsActive] = 'false'
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
        WHERE
            [5_Cities].[City_ID] = @City_ID

        /* Mark child F11_City_ReChild as not active */
        UPDATE [5_Cities_ReChild]
        SET    [IsActive] = 'false'
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
        WHERE
            [5_Cities].[City_ID] = @City_ID

        /* Mark child F11_City_Child as not active */
        UPDATE [5_Cities_Child]
        SET    [IsActive] = 'false'
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
        WHERE
            [5_Cities].[City_ID] = @City_ID

        /* Mark F10_City object as not active */
        UPDATE [5_Cities]
        SET    [IsActive] = 'false'
        WHERE
            [5_Cities].[City_ID] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddF10_City]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddF10_City]
    @City_ID int OUTPUT,
    @Region_ID int,
    @City_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 5_Cities */
        INSERT INTO [5_Cities]
        (
            [Parent_Region_ID],
            [City_Name]
        )
        VALUES
        (
            @Region_ID,
            @City_Name
        )

        /* Return new primary key */
        SET @City_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateF10_City]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateF10_City]
    @City_ID int,
    @City_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID] FROM [5_Cities]
            WHERE
                [City_ID] = @City_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F10_City'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 5_Cities */
        UPDATE [5_Cities]
        SET
            [City_Name] = @City_Name
        WHERE
            [City_ID] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddB10_City]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddB10_City]
    @City_ID int OUTPUT,
    @Region_ID int,
    @City_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 5_Cities */
        INSERT INTO [5_Cities]
        (
            [Parent_Region_ID],
            [City_Name]
        )
        VALUES
        (
            @Region_ID,
            @City_Name
        )

        /* Return new primary key */
        SET @City_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateB10_City]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateB10_City]
    @City_ID int,
    @City_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID] FROM [5_Cities]
            WHERE
                [City_ID] = @City_ID
        )
        BEGIN
            RAISERROR ('''B10_City'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 5_Cities */
        UPDATE [5_Cities]
        SET
            [City_Name] = @City_Name
        WHERE
            [City_ID] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetG09_CityColl]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetG09_CityColl]
    @Parent_Region_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get G10_City from table */
        SELECT
            [5_Cities].[City_ID],
            [5_Cities].[City_Name]
        FROM [5_Cities]
        WHERE
            [5_Cities].[Parent_Region_ID] = @Parent_Region_ID AND
            [5_Cities].[IsActive] = 'true'

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteD10_City]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteD10_City]
    @City_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID] FROM [5_Cities]
            WHERE
                [City_ID] = @City_ID
        )
        BEGIN
            RAISERROR ('''D10_City'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete child D12_CityRoad from 6_CityRoads */
        DELETE
            [6_CityRoads]
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
        WHERE
            [5_Cities].[City_ID] = @City_ID

        /* Delete child D11_City_ReChild from 5_Cities_ReChild */
        DELETE
            [5_Cities_ReChild]
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
        WHERE
            [5_Cities].[City_ID] = @City_ID

        /* Delete child D11_City_Child from 5_Cities_Child */
        DELETE
            [5_Cities_Child]
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
        WHERE
            [5_Cities].[City_ID] = @City_ID

        /* Delete D10_City object from 5_Cities */
        DELETE
        FROM [5_Cities]
        WHERE
            [5_Cities].[City_ID] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteB10_City]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteB10_City]
    @City_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID] FROM [5_Cities]
            WHERE
                [City_ID] = @City_ID
        )
        BEGIN
            RAISERROR ('''B10_City'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete child B12_CityRoad from 6_CityRoads */
        DELETE
            [6_CityRoads]
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
        WHERE
            [5_Cities].[City_ID] = @City_ID

        /* Delete child B11_City_ReChild from 5_Cities_ReChild */
        DELETE
            [5_Cities_ReChild]
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
        WHERE
            [5_Cities].[City_ID] = @City_ID

        /* Delete child B11_City_Child from 5_Cities_Child */
        DELETE
            [5_Cities_Child]
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
        WHERE
            [5_Cities].[City_ID] = @City_ID

        /* Delete B10_City object from 5_Cities */
        DELETE
        FROM [5_Cities]
        WHERE
            [5_Cities].[City_ID] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateD10_City]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateD10_City]
    @City_ID int,
    @City_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID] FROM [5_Cities]
            WHERE
                [City_ID] = @City_ID
        )
        BEGIN
            RAISERROR ('''D10_City'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 5_Cities */
        UPDATE [5_Cities]
        SET
            [City_Name] = @City_Name
        WHERE
            [City_ID] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddD10_City]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddD10_City]
    @City_ID int OUTPUT,
    @Region_ID int,
    @City_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 5_Cities */
        INSERT INTO [5_Cities]
        (
            [Parent_Region_ID],
            [City_Name]
        )
        VALUES
        (
            @Region_ID,
            @City_Name
        )

        /* Return new primary key */
        SET @City_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateG10_City]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateG10_City]
    @City_ID int,
    @City_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID] FROM [5_Cities]
            WHERE
                [City_ID] = @City_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G10_City'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 5_Cities */
        UPDATE [5_Cities]
        SET
            [City_Name] = @City_Name
        WHERE
            [City_ID] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddG10_City]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddG10_City]
    @City_ID int OUTPUT,
    @Region_ID int,
    @City_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 5_Cities */
        INSERT INTO [5_Cities]
        (
            [Parent_Region_ID],
            [City_Name]
        )
        VALUES
        (
            @Region_ID,
            @City_Name
        )

        /* Return new primary key */
        SET @City_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteG10_City]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteG10_City]
    @City_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID] FROM [5_Cities]
            WHERE
                [City_ID] = @City_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G10_City'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark child G12_CityRoad as not active */
        UPDATE [6_CityRoads]
        SET    [IsActive] = 'false'
        FROM [6_CityRoads]
            INNER JOIN [5_Cities] ON [6_CityRoads].[Parent_City_ID] = [5_Cities].[City_ID]
        WHERE
            [5_Cities].[City_ID] = @City_ID

        /* Mark child G11_City_ReChild as not active */
        UPDATE [5_Cities_ReChild]
        SET    [IsActive] = 'false'
        FROM [5_Cities_ReChild]
            INNER JOIN [5_Cities] ON [5_Cities_ReChild].[City_ID2] = [5_Cities].[City_ID]
        WHERE
            [5_Cities].[City_ID] = @City_ID

        /* Mark child G11_City_Child as not active */
        UPDATE [5_Cities_Child]
        SET    [IsActive] = 'false'
        FROM [5_Cities_Child]
            INNER JOIN [5_Cities] ON [5_Cities_Child].[City_ID1] = [5_Cities].[City_ID]
        WHERE
            [5_Cities].[City_ID] = @City_ID

        /* Mark G10_City object as not active */
        UPDATE [5_Cities]
        SET    [IsActive] = 'false'
        WHERE
            [5_Cities].[City_ID] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteG12_CityRoad]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteG12_CityRoad]
    @CityRoad_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [CityRoad_ID] FROM [6_CityRoads]
            WHERE
                [CityRoad_ID] = @CityRoad_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G12_CityRoad'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark G12_CityRoad object as not active */
        UPDATE [6_CityRoads]
        SET    [IsActive] = 'false'
        WHERE
            [6_CityRoads].[CityRoad_ID] = @CityRoad_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddG12_CityRoad]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddG12_CityRoad]
    @CityRoad_ID int OUTPUT,
    @City_ID int,
    @CityRoad_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 6_CityRoads */
        INSERT INTO [6_CityRoads]
        (
            [Parent_City_ID],
            [CityRoad_Name]
        )
        VALUES
        (
            @City_ID,
            @CityRoad_Name
        )

        /* Return new primary key */
        SET @CityRoad_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateG12_CityRoad]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateG12_CityRoad]
    @CityRoad_ID int,
    @CityRoad_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [CityRoad_ID] FROM [6_CityRoads]
            WHERE
                [CityRoad_ID] = @CityRoad_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G12_CityRoad'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 6_CityRoads */
        UPDATE [6_CityRoads]
        SET
            [CityRoad_Name] = @CityRoad_Name
        WHERE
            [CityRoad_ID] = @CityRoad_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetG11_CityRoadColl]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetG11_CityRoadColl]
    @Parent_City_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get G12_CityRoad from table */
        SELECT
            [6_CityRoads].[CityRoad_ID],
            [6_CityRoads].[CityRoad_Name]
        FROM [6_CityRoads]
        WHERE
            [6_CityRoads].[Parent_City_ID] = @Parent_City_ID AND
            [6_CityRoads].[IsActive] = 'true'

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteB12_CityRoad]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteB12_CityRoad]
    @CityRoad_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [CityRoad_ID] FROM [6_CityRoads]
            WHERE
                [CityRoad_ID] = @CityRoad_ID
        )
        BEGIN
            RAISERROR ('''B12_CityRoad'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete B12_CityRoad object from 6_CityRoads */
        DELETE
        FROM [6_CityRoads]
        WHERE
            [6_CityRoads].[CityRoad_ID] = @CityRoad_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateB12_CityRoad]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateB12_CityRoad]
    @CityRoad_ID int,
    @CityRoad_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [CityRoad_ID] FROM [6_CityRoads]
            WHERE
                [CityRoad_ID] = @CityRoad_ID
        )
        BEGIN
            RAISERROR ('''B12_CityRoad'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 6_CityRoads */
        UPDATE [6_CityRoads]
        SET
            [CityRoad_Name] = @CityRoad_Name
        WHERE
            [CityRoad_ID] = @CityRoad_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddB12_CityRoad]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddB12_CityRoad]
    @CityRoad_ID int OUTPUT,
    @City_ID int,
    @CityRoad_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 6_CityRoads */
        INSERT INTO [6_CityRoads]
        (
            [Parent_City_ID],
            [CityRoad_Name]
        )
        VALUES
        (
            @City_ID,
            @CityRoad_Name
        )

        /* Return new primary key */
        SET @CityRoad_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[GetD11_CityRoadColl]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetD11_CityRoadColl]
    @Parent_City_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D12_CityRoad from table */
        SELECT
            [6_CityRoads].[CityRoad_ID],
            [6_CityRoads].[CityRoad_Name]
        FROM [6_CityRoads]
        WHERE
            [6_CityRoads].[Parent_City_ID] = @Parent_City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateD12_CityRoad]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateD12_CityRoad]
    @CityRoad_ID int,
    @CityRoad_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [CityRoad_ID] FROM [6_CityRoads]
            WHERE
                [CityRoad_ID] = @CityRoad_ID
        )
        BEGIN
            RAISERROR ('''D12_CityRoad'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 6_CityRoads */
        UPDATE [6_CityRoads]
        SET
            [CityRoad_Name] = @CityRoad_Name
        WHERE
            [CityRoad_ID] = @CityRoad_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteD12_CityRoad]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteD12_CityRoad]
    @CityRoad_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [CityRoad_ID] FROM [6_CityRoads]
            WHERE
                [CityRoad_ID] = @CityRoad_ID
        )
        BEGIN
            RAISERROR ('''D12_CityRoad'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete D12_CityRoad object from 6_CityRoads */
        DELETE
        FROM [6_CityRoads]
        WHERE
            [6_CityRoads].[CityRoad_ID] = @CityRoad_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddD12_CityRoad]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddD12_CityRoad]
    @CityRoad_ID int OUTPUT,
    @City_ID int,
    @CityRoad_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 6_CityRoads */
        INSERT INTO [6_CityRoads]
        (
            [Parent_City_ID],
            [CityRoad_Name]
        )
        VALUES
        (
            @City_ID,
            @CityRoad_Name
        )

        /* Return new primary key */
        SET @CityRoad_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[GetH11_CityRoadColl]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetH11_CityRoadColl]
    @Parent_City_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get H12_CityRoad from table */
        SELECT
            [6_CityRoads].[CityRoad_ID],
            [6_CityRoads].[CityRoad_Name]
        FROM [6_CityRoads]
        WHERE
            [6_CityRoads].[Parent_City_ID] = @Parent_City_ID AND
            [6_CityRoads].[IsActive] = 'true'

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteH12_CityRoad]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteH12_CityRoad]
    @CityRoad_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [CityRoad_ID] FROM [6_CityRoads]
            WHERE
                [CityRoad_ID] = @CityRoad_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H12_CityRoad'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark H12_CityRoad object as not active */
        UPDATE [6_CityRoads]
        SET    [IsActive] = 'false'
        WHERE
            [6_CityRoads].[CityRoad_ID] = @CityRoad_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteA12_CityRoad]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteA12_CityRoad]
    @CityRoad_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [CityRoad_ID] FROM [6_CityRoads]
            WHERE
                [CityRoad_ID] = @CityRoad_ID
        )
        BEGIN
            RAISERROR ('''A12_CityRoad'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete A12_CityRoad object from 6_CityRoads */
        DELETE
        FROM [6_CityRoads]
        WHERE
            [6_CityRoads].[CityRoad_ID] = @CityRoad_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateC12_CityRoad]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateC12_CityRoad]
    @CityRoad_ID int,
    @CityRoad_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [CityRoad_ID] FROM [6_CityRoads]
            WHERE
                [CityRoad_ID] = @CityRoad_ID
        )
        BEGIN
            RAISERROR ('''C12_CityRoad'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 6_CityRoads */
        UPDATE [6_CityRoads]
        SET
            [CityRoad_Name] = @CityRoad_Name
        WHERE
            [CityRoad_ID] = @CityRoad_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteC12_CityRoad]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteC12_CityRoad]
    @CityRoad_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [CityRoad_ID] FROM [6_CityRoads]
            WHERE
                [CityRoad_ID] = @CityRoad_ID
        )
        BEGIN
            RAISERROR ('''C12_CityRoad'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete C12_CityRoad object from 6_CityRoads */
        DELETE
        FROM [6_CityRoads]
        WHERE
            [6_CityRoads].[CityRoad_ID] = @CityRoad_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddC12_CityRoad]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddC12_CityRoad]
    @CityRoad_ID int OUTPUT,
    @City_ID int,
    @CityRoad_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 6_CityRoads */
        INSERT INTO [6_CityRoads]
        (
            [Parent_City_ID],
            [CityRoad_Name]
        )
        VALUES
        (
            @City_ID,
            @CityRoad_Name
        )

        /* Return new primary key */
        SET @CityRoad_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[AddF12_CityRoad]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddF12_CityRoad]
    @CityRoad_ID int OUTPUT,
    @City_ID int,
    @CityRoad_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 6_CityRoads */
        INSERT INTO [6_CityRoads]
        (
            [Parent_City_ID],
            [CityRoad_Name]
        )
        VALUES
        (
            @City_ID,
            @CityRoad_Name
        )

        /* Return new primary key */
        SET @CityRoad_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateF12_CityRoad]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateF12_CityRoad]
    @CityRoad_ID int,
    @CityRoad_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [CityRoad_ID] FROM [6_CityRoads]
            WHERE
                [CityRoad_ID] = @CityRoad_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F12_CityRoad'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 6_CityRoads */
        UPDATE [6_CityRoads]
        SET
            [CityRoad_Name] = @CityRoad_Name
        WHERE
            [CityRoad_ID] = @CityRoad_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteF12_CityRoad]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteF12_CityRoad]
    @CityRoad_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [CityRoad_ID] FROM [6_CityRoads]
            WHERE
                [CityRoad_ID] = @CityRoad_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F12_CityRoad'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark F12_CityRoad object as not active */
        UPDATE [6_CityRoads]
        SET    [IsActive] = 'false'
        WHERE
            [6_CityRoads].[CityRoad_ID] = @CityRoad_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateH12_CityRoad]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateH12_CityRoad]
    @CityRoad_ID int,
    @CityRoad_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [CityRoad_ID] FROM [6_CityRoads]
            WHERE
                [CityRoad_ID] = @CityRoad_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H12_CityRoad'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 6_CityRoads */
        UPDATE [6_CityRoads]
        SET
            [CityRoad_Name] = @CityRoad_Name
        WHERE
            [CityRoad_ID] = @CityRoad_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateA12_CityRoad]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateA12_CityRoad]
    @CityRoad_ID int,
    @CityRoad_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [CityRoad_ID] FROM [6_CityRoads]
            WHERE
                [CityRoad_ID] = @CityRoad_ID
        )
        BEGIN
            RAISERROR ('''A12_CityRoad'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 6_CityRoads */
        UPDATE [6_CityRoads]
        SET
            [CityRoad_Name] = @CityRoad_Name
        WHERE
            [CityRoad_ID] = @CityRoad_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddH12_CityRoad]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddH12_CityRoad]
    @CityRoad_ID int OUTPUT,
    @City_ID int,
    @CityRoad_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 6_CityRoads */
        INSERT INTO [6_CityRoads]
        (
            [Parent_City_ID],
            [CityRoad_Name]
        )
        VALUES
        (
            @City_ID,
            @CityRoad_Name
        )

        /* Return new primary key */
        SET @CityRoad_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[AddA12_CityRoad]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddA12_CityRoad]
    @CityRoad_ID int OUTPUT,
    @City_ID int,
    @CityRoad_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 6_CityRoads */
        INSERT INTO [6_CityRoads]
        (
            [Parent_City_ID],
            [CityRoad_Name]
        )
        VALUES
        (
            @City_ID,
            @CityRoad_Name
        )

        /* Return new primary key */
        SET @CityRoad_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteE12_CityRoad]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteE12_CityRoad]
    @CityRoad_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [CityRoad_ID] FROM [6_CityRoads]
            WHERE
                [CityRoad_ID] = @CityRoad_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E12_CityRoad'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark E12_CityRoad object as not active */
        UPDATE [6_CityRoads]
        SET    [IsActive] = 'false'
        WHERE
            [6_CityRoads].[CityRoad_ID] = @CityRoad_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddE12_CityRoad]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddE12_CityRoad]
    @CityRoad_ID int OUTPUT,
    @City_ID int,
    @CityRoad_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 6_CityRoads */
        INSERT INTO [6_CityRoads]
        (
            [Parent_City_ID],
            [CityRoad_Name]
        )
        VALUES
        (
            @City_ID,
            @CityRoad_Name
        )

        /* Return new primary key */
        SET @CityRoad_ID = SCOPE_IDENTITY()

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateE12_CityRoad]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateE12_CityRoad]
    @CityRoad_ID int,
    @CityRoad_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [CityRoad_ID] FROM [6_CityRoads]
            WHERE
                [CityRoad_ID] = @CityRoad_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E12_CityRoad'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 6_CityRoads */
        UPDATE [6_CityRoads]
        SET
            [CityRoad_Name] = @CityRoad_Name
        WHERE
            [CityRoad_ID] = @CityRoad_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetC11_CityRoadColl]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetC11_CityRoadColl]
    @Parent_City_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get C12_CityRoad from table */
        SELECT
            [6_CityRoads].[CityRoad_ID],
            [6_CityRoads].[CityRoad_Name]
        FROM [6_CityRoads]
        WHERE
            [6_CityRoads].[Parent_City_ID] = @Parent_City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddA03_Continent_ReChild]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddA03_Continent_ReChild]
    @Continent_ID int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 1_Continents_ReChild */
        INSERT INTO [1_Continents_ReChild]
        (
            [Continent_ID2],
            [Continent_Child_Name]
        )
        VALUES
        (
            @Continent_ID,
            @Continent_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteF03_Continent_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteF03_Continent_ReChild]
    @Continent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID2] FROM [1_Continents_ReChild]
            WHERE
                [Continent_ID2] = @Continent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F03_Continent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark F03_Continent_ReChild object as not active */
        UPDATE [1_Continents_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [1_Continents_ReChild].[Continent_ID2] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateF03_Continent_ReChild]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateF03_Continent_ReChild]
    @Continent_ID int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID2] FROM [1_Continents_ReChild]
            WHERE
                [Continent_ID2] = @Continent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F03_Continent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 1_Continents_ReChild */
        UPDATE [1_Continents_ReChild]
        SET
            [Continent_Child_Name] = @Continent_Child_Name
        WHERE
            [Continent_ID2] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddF03_Continent_ReChild]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddF03_Continent_ReChild]
    @Continent_ID int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 1_Continents_ReChild */
        INSERT INTO [1_Continents_ReChild]
        (
            [Continent_ID2],
            [Continent_Child_Name]
        )
        VALUES
        (
            @Continent_ID,
            @Continent_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateA03_Continent_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateA03_Continent_ReChild]
    @Continent_ID int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID2] FROM [1_Continents_ReChild]
            WHERE
                [Continent_ID2] = @Continent_ID
        )
        BEGIN
            RAISERROR ('''A03_Continent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 1_Continents_ReChild */
        UPDATE [1_Continents_ReChild]
        SET
            [Continent_Child_Name] = @Continent_Child_Name
        WHERE
            [Continent_ID2] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteA03_Continent_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteA03_Continent_ReChild]
    @Continent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID2] FROM [1_Continents_ReChild]
            WHERE
                [Continent_ID2] = @Continent_ID
        )
        BEGIN
            RAISERROR ('''A03_Continent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete A03_Continent_ReChild object from 1_Continents_ReChild */
        DELETE
        FROM [1_Continents_ReChild]
        WHERE
            [1_Continents_ReChild].[Continent_ID2] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddH03_Continent_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddH03_Continent_ReChild]
    @Continent_ID int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 1_Continents_ReChild */
        INSERT INTO [1_Continents_ReChild]
        (
            [Continent_ID2],
            [Continent_Child_Name]
        )
        VALUES
        (
            @Continent_ID,
            @Continent_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[GetH03_Continent_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetH03_Continent_ReChild]
    @Continent_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get H03_Continent_ReChild from table */
        SELECT
            [1_Continents_ReChild].[Continent_Child_Name]
        FROM [1_Continents_ReChild]
        WHERE
            [1_Continents_ReChild].[Continent_ID2] = @Continent_ID2 AND
            [1_Continents_ReChild].[IsActive] = 'true'

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateH03_Continent_ReChild]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateH03_Continent_ReChild]
    @Continent_ID int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID2] FROM [1_Continents_ReChild]
            WHERE
                [Continent_ID2] = @Continent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H03_Continent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 1_Continents_ReChild */
        UPDATE [1_Continents_ReChild]
        SET
            [Continent_Child_Name] = @Continent_Child_Name
        WHERE
            [Continent_ID2] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteH03_Continent_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteH03_Continent_ReChild]
    @Continent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID2] FROM [1_Continents_ReChild]
            WHERE
                [Continent_ID2] = @Continent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H03_Continent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark H03_Continent_ReChild object as not active */
        UPDATE [1_Continents_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [1_Continents_ReChild].[Continent_ID2] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteB03_Continent_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteB03_Continent_ReChild]
    @Continent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID2] FROM [1_Continents_ReChild]
            WHERE
                [Continent_ID2] = @Continent_ID
        )
        BEGIN
            RAISERROR ('''B03_Continent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete B03_Continent_ReChild object from 1_Continents_ReChild */
        DELETE
        FROM [1_Continents_ReChild]
        WHERE
            [1_Continents_ReChild].[Continent_ID2] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateB03_Continent_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateB03_Continent_ReChild]
    @Continent_ID int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID2] FROM [1_Continents_ReChild]
            WHERE
                [Continent_ID2] = @Continent_ID
        )
        BEGIN
            RAISERROR ('''B03_Continent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 1_Continents_ReChild */
        UPDATE [1_Continents_ReChild]
        SET
            [Continent_Child_Name] = @Continent_Child_Name
        WHERE
            [Continent_ID2] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddB03_Continent_ReChild]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddB03_Continent_ReChild]
    @Continent_ID int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 1_Continents_ReChild */
        INSERT INTO [1_Continents_ReChild]
        (
            [Continent_ID2],
            [Continent_Child_Name]
        )
        VALUES
        (
            @Continent_ID,
            @Continent_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[GetG03_Continent_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetG03_Continent_ReChild]
    @Continent_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get G03_Continent_ReChild from table */
        SELECT
            [1_Continents_ReChild].[Continent_Child_Name]
        FROM [1_Continents_ReChild]
        WHERE
            [1_Continents_ReChild].[Continent_ID2] = @Continent_ID2 AND
            [1_Continents_ReChild].[IsActive] = 'true'

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteG03_Continent_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteG03_Continent_ReChild]
    @Continent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID2] FROM [1_Continents_ReChild]
            WHERE
                [Continent_ID2] = @Continent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G03_Continent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark G03_Continent_ReChild object as not active */
        UPDATE [1_Continents_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [1_Continents_ReChild].[Continent_ID2] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddG03_Continent_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddG03_Continent_ReChild]
    @Continent_ID int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 1_Continents_ReChild */
        INSERT INTO [1_Continents_ReChild]
        (
            [Continent_ID2],
            [Continent_Child_Name]
        )
        VALUES
        (
            @Continent_ID,
            @Continent_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateG03_Continent_ReChild]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateG03_Continent_ReChild]
    @Continent_ID int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID2] FROM [1_Continents_ReChild]
            WHERE
                [Continent_ID2] = @Continent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G03_Continent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 1_Continents_ReChild */
        UPDATE [1_Continents_ReChild]
        SET
            [Continent_Child_Name] = @Continent_Child_Name
        WHERE
            [Continent_ID2] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddD03_Continent_ReChild]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddD03_Continent_ReChild]
    @Continent_ID int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 1_Continents_ReChild */
        INSERT INTO [1_Continents_ReChild]
        (
            [Continent_ID2],
            [Continent_Child_Name]
        )
        VALUES
        (
            @Continent_ID,
            @Continent_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateD03_Continent_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateD03_Continent_ReChild]
    @Continent_ID int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID2] FROM [1_Continents_ReChild]
            WHERE
                [Continent_ID2] = @Continent_ID
        )
        BEGIN
            RAISERROR ('''D03_Continent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 1_Continents_ReChild */
        UPDATE [1_Continents_ReChild]
        SET
            [Continent_Child_Name] = @Continent_Child_Name
        WHERE
            [Continent_ID2] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteD03_Continent_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteD03_Continent_ReChild]
    @Continent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID2] FROM [1_Continents_ReChild]
            WHERE
                [Continent_ID2] = @Continent_ID
        )
        BEGIN
            RAISERROR ('''D03_Continent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete D03_Continent_ReChild object from 1_Continents_ReChild */
        DELETE
        FROM [1_Continents_ReChild]
        WHERE
            [1_Continents_ReChild].[Continent_ID2] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetD03_Continent_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetD03_Continent_ReChild]
    @Continent_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D03_Continent_ReChild from table */
        SELECT
            [1_Continents_ReChild].[Continent_Child_Name]
        FROM [1_Continents_ReChild]
        WHERE
            [1_Continents_ReChild].[Continent_ID2] = @Continent_ID2

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteE03_Continent_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteE03_Continent_ReChild]
    @Continent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID2] FROM [1_Continents_ReChild]
            WHERE
                [Continent_ID2] = @Continent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E03_Continent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark E03_Continent_ReChild object as not active */
        UPDATE [1_Continents_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [1_Continents_ReChild].[Continent_ID2] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateE03_Continent_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateE03_Continent_ReChild]
    @Continent_ID int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID2] FROM [1_Continents_ReChild]
            WHERE
                [Continent_ID2] = @Continent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E03_Continent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 1_Continents_ReChild */
        UPDATE [1_Continents_ReChild]
        SET
            [Continent_Child_Name] = @Continent_Child_Name
        WHERE
            [Continent_ID2] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddE03_Continent_ReChild]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddE03_Continent_ReChild]
    @Continent_ID int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 1_Continents_ReChild */
        INSERT INTO [1_Continents_ReChild]
        (
            [Continent_ID2],
            [Continent_Child_Name]
        )
        VALUES
        (
            @Continent_ID,
            @Continent_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[GetC03_Continent_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetC03_Continent_ReChild]
    @Continent_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get C03_Continent_ReChild from table */
        SELECT
            [1_Continents_ReChild].[Continent_Child_Name]
        FROM [1_Continents_ReChild]
        WHERE
            [1_Continents_ReChild].[Continent_ID2] = @Continent_ID2

    END
GO
/****** Object:  StoredProcedure [dbo].[AddC03_Continent_ReChild]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddC03_Continent_ReChild]
    @Continent_ID int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 1_Continents_ReChild */
        INSERT INTO [1_Continents_ReChild]
        (
            [Continent_ID2],
            [Continent_Child_Name]
        )
        VALUES
        (
            @Continent_ID,
            @Continent_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteC03_Continent_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteC03_Continent_ReChild]
    @Continent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID2] FROM [1_Continents_ReChild]
            WHERE
                [Continent_ID2] = @Continent_ID
        )
        BEGIN
            RAISERROR ('''C03_Continent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete C03_Continent_ReChild object from 1_Continents_ReChild */
        DELETE
        FROM [1_Continents_ReChild]
        WHERE
            [1_Continents_ReChild].[Continent_ID2] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateC03_Continent_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateC03_Continent_ReChild]
    @Continent_ID int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID2] FROM [1_Continents_ReChild]
            WHERE
                [Continent_ID2] = @Continent_ID
        )
        BEGIN
            RAISERROR ('''C03_Continent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 1_Continents_ReChild */
        UPDATE [1_Continents_ReChild]
        SET
            [Continent_Child_Name] = @Continent_Child_Name
        WHERE
            [Continent_ID2] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetC03_Continent_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetC03_Continent_Child]
    @Continent_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get C03_Continent_Child from table */
        SELECT
            [1_Continents_Child].[Continent_Child_Name]
        FROM [1_Continents_Child]
        WHERE
            [1_Continents_Child].[Continent_ID1] = @Continent_ID1

    END
GO
/****** Object:  StoredProcedure [dbo].[AddC03_Continent_Child]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddC03_Continent_Child]
    @Continent_ID int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 1_Continents_Child */
        INSERT INTO [1_Continents_Child]
        (
            [Continent_ID1],
            [Continent_Child_Name]
        )
        VALUES
        (
            @Continent_ID,
            @Continent_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateC03_Continent_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateC03_Continent_Child]
    @Continent_ID int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID1] FROM [1_Continents_Child]
            WHERE
                [Continent_ID1] = @Continent_ID
        )
        BEGIN
            RAISERROR ('''C03_Continent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 1_Continents_Child */
        UPDATE [1_Continents_Child]
        SET
            [Continent_Child_Name] = @Continent_Child_Name
        WHERE
            [Continent_ID1] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteC03_Continent_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteC03_Continent_Child]
    @Continent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID1] FROM [1_Continents_Child]
            WHERE
                [Continent_ID1] = @Continent_ID
        )
        BEGIN
            RAISERROR ('''C03_Continent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete C03_Continent_Child object from 1_Continents_Child */
        DELETE
        FROM [1_Continents_Child]
        WHERE
            [1_Continents_Child].[Continent_ID1] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteH03_Continent_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteH03_Continent_Child]
    @Continent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID1] FROM [1_Continents_Child]
            WHERE
                [Continent_ID1] = @Continent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H03_Continent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark H03_Continent_Child object as not active */
        UPDATE [1_Continents_Child]
        SET    [IsActive] = 'false'
        WHERE
            [1_Continents_Child].[Continent_ID1] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateE03_Continent_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateE03_Continent_Child]
    @Continent_ID int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID1] FROM [1_Continents_Child]
            WHERE
                [Continent_ID1] = @Continent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E03_Continent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 1_Continents_Child */
        UPDATE [1_Continents_Child]
        SET
            [Continent_Child_Name] = @Continent_Child_Name
        WHERE
            [Continent_ID1] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddE03_Continent_Child]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddE03_Continent_Child]
    @Continent_ID int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 1_Continents_Child */
        INSERT INTO [1_Continents_Child]
        (
            [Continent_ID1],
            [Continent_Child_Name]
        )
        VALUES
        (
            @Continent_ID,
            @Continent_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteE03_Continent_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteE03_Continent_Child]
    @Continent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID1] FROM [1_Continents_Child]
            WHERE
                [Continent_ID1] = @Continent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E03_Continent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark E03_Continent_Child object as not active */
        UPDATE [1_Continents_Child]
        SET    [IsActive] = 'false'
        WHERE
            [1_Continents_Child].[Continent_ID1] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddD03_Continent_Child]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddD03_Continent_Child]
    @Continent_ID int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 1_Continents_Child */
        INSERT INTO [1_Continents_Child]
        (
            [Continent_ID1],
            [Continent_Child_Name]
        )
        VALUES
        (
            @Continent_ID,
            @Continent_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteD03_Continent_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteD03_Continent_Child]
    @Continent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID1] FROM [1_Continents_Child]
            WHERE
                [Continent_ID1] = @Continent_ID
        )
        BEGIN
            RAISERROR ('''D03_Continent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete D03_Continent_Child object from 1_Continents_Child */
        DELETE
        FROM [1_Continents_Child]
        WHERE
            [1_Continents_Child].[Continent_ID1] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetD03_Continent_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetD03_Continent_Child]
    @Continent_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D03_Continent_Child from table */
        SELECT
            [1_Continents_Child].[Continent_Child_Name]
        FROM [1_Continents_Child]
        WHERE
            [1_Continents_Child].[Continent_ID1] = @Continent_ID1

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateD03_Continent_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateD03_Continent_Child]
    @Continent_ID int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID1] FROM [1_Continents_Child]
            WHERE
                [Continent_ID1] = @Continent_ID
        )
        BEGIN
            RAISERROR ('''D03_Continent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 1_Continents_Child */
        UPDATE [1_Continents_Child]
        SET
            [Continent_Child_Name] = @Continent_Child_Name
        WHERE
            [Continent_ID1] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddG03_Continent_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddG03_Continent_Child]
    @Continent_ID int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 1_Continents_Child */
        INSERT INTO [1_Continents_Child]
        (
            [Continent_ID1],
            [Continent_Child_Name]
        )
        VALUES
        (
            @Continent_ID,
            @Continent_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[GetG03_Continent_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetG03_Continent_Child]
    @Continent_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get G03_Continent_Child from table */
        SELECT
            [1_Continents_Child].[Continent_Child_Name]
        FROM [1_Continents_Child]
        WHERE
            [1_Continents_Child].[Continent_ID1] = @Continent_ID1 AND
            [1_Continents_Child].[IsActive] = 'true'

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateG03_Continent_Child]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateG03_Continent_Child]
    @Continent_ID int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID1] FROM [1_Continents_Child]
            WHERE
                [Continent_ID1] = @Continent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G03_Continent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 1_Continents_Child */
        UPDATE [1_Continents_Child]
        SET
            [Continent_Child_Name] = @Continent_Child_Name
        WHERE
            [Continent_ID1] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteG03_Continent_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteG03_Continent_Child]
    @Continent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID1] FROM [1_Continents_Child]
            WHERE
                [Continent_ID1] = @Continent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G03_Continent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark G03_Continent_Child object as not active */
        UPDATE [1_Continents_Child]
        SET    [IsActive] = 'false'
        WHERE
            [1_Continents_Child].[Continent_ID1] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteB03_Continent_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteB03_Continent_Child]
    @Continent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID1] FROM [1_Continents_Child]
            WHERE
                [Continent_ID1] = @Continent_ID
        )
        BEGIN
            RAISERROR ('''B03_Continent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete B03_Continent_Child object from 1_Continents_Child */
        DELETE
        FROM [1_Continents_Child]
        WHERE
            [1_Continents_Child].[Continent_ID1] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateB03_Continent_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateB03_Continent_Child]
    @Continent_ID int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID1] FROM [1_Continents_Child]
            WHERE
                [Continent_ID1] = @Continent_ID
        )
        BEGIN
            RAISERROR ('''B03_Continent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 1_Continents_Child */
        UPDATE [1_Continents_Child]
        SET
            [Continent_Child_Name] = @Continent_Child_Name
        WHERE
            [Continent_ID1] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddB03_Continent_Child]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddB03_Continent_Child]
    @Continent_ID int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 1_Continents_Child */
        INSERT INTO [1_Continents_Child]
        (
            [Continent_ID1],
            [Continent_Child_Name]
        )
        VALUES
        (
            @Continent_ID,
            @Continent_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[AddH03_Continent_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddH03_Continent_Child]
    @Continent_ID int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 1_Continents_Child */
        INSERT INTO [1_Continents_Child]
        (
            [Continent_ID1],
            [Continent_Child_Name]
        )
        VALUES
        (
            @Continent_ID,
            @Continent_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[GetH03_Continent_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetH03_Continent_Child]
    @Continent_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get H03_Continent_Child from table */
        SELECT
            [1_Continents_Child].[Continent_Child_Name]
        FROM [1_Continents_Child]
        WHERE
            [1_Continents_Child].[Continent_ID1] = @Continent_ID1 AND
            [1_Continents_Child].[IsActive] = 'true'

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateH03_Continent_Child]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateH03_Continent_Child]
    @Continent_ID int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID1] FROM [1_Continents_Child]
            WHERE
                [Continent_ID1] = @Continent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H03_Continent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 1_Continents_Child */
        UPDATE [1_Continents_Child]
        SET
            [Continent_Child_Name] = @Continent_Child_Name
        WHERE
            [Continent_ID1] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteA03_Continent_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteA03_Continent_Child]
    @Continent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID1] FROM [1_Continents_Child]
            WHERE
                [Continent_ID1] = @Continent_ID
        )
        BEGIN
            RAISERROR ('''A03_Continent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete A03_Continent_Child object from 1_Continents_Child */
        DELETE
        FROM [1_Continents_Child]
        WHERE
            [1_Continents_Child].[Continent_ID1] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateA03_Continent_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateA03_Continent_Child]
    @Continent_ID int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID1] FROM [1_Continents_Child]
            WHERE
                [Continent_ID1] = @Continent_ID
        )
        BEGIN
            RAISERROR ('''A03_Continent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 1_Continents_Child */
        UPDATE [1_Continents_Child]
        SET
            [Continent_Child_Name] = @Continent_Child_Name
        WHERE
            [Continent_ID1] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddA03_Continent_Child]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddA03_Continent_Child]
    @Continent_ID int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 1_Continents_Child */
        INSERT INTO [1_Continents_Child]
        (
            [Continent_ID1],
            [Continent_Child_Name]
        )
        VALUES
        (
            @Continent_ID,
            @Continent_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteF03_Continent_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteF03_Continent_Child]
    @Continent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID1] FROM [1_Continents_Child]
            WHERE
                [Continent_ID1] = @Continent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F03_Continent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark F03_Continent_Child object as not active */
        UPDATE [1_Continents_Child]
        SET    [IsActive] = 'false'
        WHERE
            [1_Continents_Child].[Continent_ID1] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateF03_Continent_Child]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateF03_Continent_Child]
    @Continent_ID int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Continent_ID1] FROM [1_Continents_Child]
            WHERE
                [Continent_ID1] = @Continent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F03_Continent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 1_Continents_Child */
        UPDATE [1_Continents_Child]
        SET
            [Continent_Child_Name] = @Continent_Child_Name
        WHERE
            [Continent_ID1] = @Continent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddF03_Continent_Child]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddF03_Continent_Child]
    @Continent_ID int,
    @Continent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 1_Continents_Child */
        INSERT INTO [1_Continents_Child]
        (
            [Continent_ID1],
            [Continent_Child_Name]
        )
        VALUES
        (
            @Continent_ID,
            @Continent_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[GetH05_SubContinent_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetH05_SubContinent_ReChild]
    @SubContinent_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get H05_SubContinent_ReChild from table */
        SELECT
            [2_SubContinents_ReChild].[SubContinent_Child_Name]
        FROM [2_SubContinents_ReChild]
        WHERE
            [2_SubContinents_ReChild].[SubContinent_ID2] = @SubContinent_ID2 AND
            [2_SubContinents_ReChild].[IsActive] = 'true'

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteA05_SubContinent_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteA05_SubContinent_ReChild]
    @SubContinent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID2] FROM [2_SubContinents_ReChild]
            WHERE
                [SubContinent_ID2] = @SubContinent_ID
        )
        BEGIN
            RAISERROR ('''A05_SubContinent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete A05_SubContinent_ReChild object from 2_SubContinents_ReChild */
        DELETE
        FROM [2_SubContinents_ReChild]
        WHERE
            [2_SubContinents_ReChild].[SubContinent_ID2] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateA05_SubContinent_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateA05_SubContinent_ReChild]
    @SubContinent_ID int,
    @SubContinent_Child_Name varchar(50),
    @RowVersion timestamp,
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID2] FROM [2_SubContinents_ReChild]
            WHERE
                [SubContinent_ID2] = @SubContinent_ID
        )
        BEGIN
            RAISERROR ('''A05_SubContinent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Check for row version match */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID2] FROM [2_SubContinents_ReChild]
            WHERE
                [SubContinent_ID2] = @SubContinent_ID AND
                [RowVersion] = @RowVersion
        )
        BEGIN
            RAISERROR ('''A05_SubContinent_ReChild'' object was modified by another user.', 16, 1)
            RETURN
        END

        /* Update object in 2_SubContinents_ReChild */
        UPDATE [2_SubContinents_ReChild]
        SET
            [SubContinent_Child_Name] = @SubContinent_Child_Name
        WHERE
            [SubContinent_ID2] = @SubContinent_ID AND
            [RowVersion] = @RowVersion

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [2_SubContinents_ReChild]
        WHERE
            [SubContinent_ID2] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddA05_SubContinent_ReChild]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddA05_SubContinent_ReChild]
    @SubContinent_ID int,
    @SubContinent_Child_Name varchar(50),
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 2_SubContinents_ReChild */
        INSERT INTO [2_SubContinents_ReChild]
        (
            [SubContinent_ID2],
            [SubContinent_Child_Name]
        )
        VALUES
        (
            @SubContinent_ID,
            @SubContinent_Child_Name
        )

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [2_SubContinents_ReChild]
        WHERE
            [SubContinent_ID2] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateF05_SubContinent_ReChild]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateF05_SubContinent_ReChild]
    @SubContinent_ID int,
    @SubContinent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID2] FROM [2_SubContinents_ReChild]
            WHERE
                [SubContinent_ID2] = @SubContinent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F05_SubContinent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 2_SubContinents_ReChild */
        UPDATE [2_SubContinents_ReChild]
        SET
            [SubContinent_Child_Name] = @SubContinent_Child_Name
        WHERE
            [SubContinent_ID2] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteF05_SubContinent_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteF05_SubContinent_ReChild]
    @SubContinent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID2] FROM [2_SubContinents_ReChild]
            WHERE
                [SubContinent_ID2] = @SubContinent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F05_SubContinent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark F05_SubContinent_ReChild object as not active */
        UPDATE [2_SubContinents_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [2_SubContinents_ReChild].[SubContinent_ID2] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateH05_SubContinent_ReChild]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateH05_SubContinent_ReChild]
    @SubContinent_ID int,
    @SubContinent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID2] FROM [2_SubContinents_ReChild]
            WHERE
                [SubContinent_ID2] = @SubContinent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H05_SubContinent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 2_SubContinents_ReChild */
        UPDATE [2_SubContinents_ReChild]
        SET
            [SubContinent_Child_Name] = @SubContinent_Child_Name
        WHERE
            [SubContinent_ID2] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteH05_SubContinent_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteH05_SubContinent_ReChild]
    @SubContinent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID2] FROM [2_SubContinents_ReChild]
            WHERE
                [SubContinent_ID2] = @SubContinent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H05_SubContinent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark H05_SubContinent_ReChild object as not active */
        UPDATE [2_SubContinents_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [2_SubContinents_ReChild].[SubContinent_ID2] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddH05_SubContinent_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddH05_SubContinent_ReChild]
    @SubContinent_ID int,
    @SubContinent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 2_SubContinents_ReChild */
        INSERT INTO [2_SubContinents_ReChild]
        (
            [SubContinent_ID2],
            [SubContinent_Child_Name]
        )
        VALUES
        (
            @SubContinent_ID,
            @SubContinent_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteD05_SubContinent_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteD05_SubContinent_ReChild]
    @SubContinent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID2] FROM [2_SubContinents_ReChild]
            WHERE
                [SubContinent_ID2] = @SubContinent_ID
        )
        BEGIN
            RAISERROR ('''D05_SubContinent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete D05_SubContinent_ReChild object from 2_SubContinents_ReChild */
        DELETE
        FROM [2_SubContinents_ReChild]
        WHERE
            [2_SubContinents_ReChild].[SubContinent_ID2] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddD05_SubContinent_ReChild]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddD05_SubContinent_ReChild]
    @SubContinent_ID int,
    @SubContinent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 2_SubContinents_ReChild */
        INSERT INTO [2_SubContinents_ReChild]
        (
            [SubContinent_ID2],
            [SubContinent_Child_Name]
        )
        VALUES
        (
            @SubContinent_ID,
            @SubContinent_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateD05_SubContinent_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateD05_SubContinent_ReChild]
    @SubContinent_ID int,
    @SubContinent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID2] FROM [2_SubContinents_ReChild]
            WHERE
                [SubContinent_ID2] = @SubContinent_ID
        )
        BEGIN
            RAISERROR ('''D05_SubContinent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 2_SubContinents_ReChild */
        UPDATE [2_SubContinents_ReChild]
        SET
            [SubContinent_Child_Name] = @SubContinent_Child_Name
        WHERE
            [SubContinent_ID2] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetD05_SubContinent_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetD05_SubContinent_ReChild]
    @SubContinent_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D05_SubContinent_ReChild from table */
        SELECT
            [2_SubContinents_ReChild].[SubContinent_Child_Name]
        FROM [2_SubContinents_ReChild]
        WHERE
            [2_SubContinents_ReChild].[SubContinent_ID2] = @SubContinent_ID2

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteB05_SubContinent_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteB05_SubContinent_ReChild]
    @SubContinent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID2] FROM [2_SubContinents_ReChild]
            WHERE
                [SubContinent_ID2] = @SubContinent_ID
        )
        BEGIN
            RAISERROR ('''B05_SubContinent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete B05_SubContinent_ReChild object from 2_SubContinents_ReChild */
        DELETE
        FROM [2_SubContinents_ReChild]
        WHERE
            [2_SubContinents_ReChild].[SubContinent_ID2] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateB05_SubContinent_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateB05_SubContinent_ReChild]
    @SubContinent_ID int,
    @SubContinent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID2] FROM [2_SubContinents_ReChild]
            WHERE
                [SubContinent_ID2] = @SubContinent_ID
        )
        BEGIN
            RAISERROR ('''B05_SubContinent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 2_SubContinents_ReChild */
        UPDATE [2_SubContinents_ReChild]
        SET
            [SubContinent_Child_Name] = @SubContinent_Child_Name
        WHERE
            [SubContinent_ID2] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddB05_SubContinent_ReChild]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddB05_SubContinent_ReChild]
    @SubContinent_ID int,
    @SubContinent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 2_SubContinents_ReChild */
        INSERT INTO [2_SubContinents_ReChild]
        (
            [SubContinent_ID2],
            [SubContinent_Child_Name]
        )
        VALUES
        (
            @SubContinent_ID,
            @SubContinent_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[AddF05_SubContinent_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddF05_SubContinent_ReChild]
    @SubContinent_ID int,
    @SubContinent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 2_SubContinents_ReChild */
        INSERT INTO [2_SubContinents_ReChild]
        (
            [SubContinent_ID2],
            [SubContinent_Child_Name]
        )
        VALUES
        (
            @SubContinent_ID,
            @SubContinent_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteG05_SubContinent_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteG05_SubContinent_ReChild]
    @SubContinent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID2] FROM [2_SubContinents_ReChild]
            WHERE
                [SubContinent_ID2] = @SubContinent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G05_SubContinent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark G05_SubContinent_ReChild object as not active */
        UPDATE [2_SubContinents_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [2_SubContinents_ReChild].[SubContinent_ID2] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddG05_SubContinent_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddG05_SubContinent_ReChild]
    @SubContinent_ID int,
    @SubContinent_Child_Name varchar(50),
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 2_SubContinents_ReChild */
        INSERT INTO [2_SubContinents_ReChild]
        (
            [SubContinent_ID2],
            [SubContinent_Child_Name]
        )
        VALUES
        (
            @SubContinent_ID,
            @SubContinent_Child_Name
        )

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [2_SubContinents_ReChild]
        WHERE
            [SubContinent_ID2] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateG05_SubContinent_ReChild]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateG05_SubContinent_ReChild]
    @SubContinent_ID int,
    @SubContinent_Child_Name varchar(50),
    @RowVersion timestamp,
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID2] FROM [2_SubContinents_ReChild]
            WHERE
                [SubContinent_ID2] = @SubContinent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G05_SubContinent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Check for row version match */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID2] FROM [2_SubContinents_ReChild]
            WHERE
                [SubContinent_ID2] = @SubContinent_ID AND
                [RowVersion] = @RowVersion
        )
        BEGIN
            RAISERROR ('''G05_SubContinent_ReChild'' object was modified by another user.', 16, 1)
            RETURN
        END

        /* Update object in 2_SubContinents_ReChild */
        UPDATE [2_SubContinents_ReChild]
        SET
            [SubContinent_Child_Name] = @SubContinent_Child_Name
        WHERE
            [SubContinent_ID2] = @SubContinent_ID AND
            [RowVersion] = @RowVersion

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [2_SubContinents_ReChild]
        WHERE
            [SubContinent_ID2] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetG05_SubContinent_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetG05_SubContinent_ReChild]
    @SubContinent_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get G05_SubContinent_ReChild from table */
        SELECT
            [2_SubContinents_ReChild].[SubContinent_Child_Name],
            [2_SubContinents_ReChild].[RowVersion]
        FROM [2_SubContinents_ReChild]
        WHERE
            [2_SubContinents_ReChild].[SubContinent_ID2] = @SubContinent_ID2 AND
            [2_SubContinents_ReChild].[IsActive] = 'true'

    END
GO
/****** Object:  StoredProcedure [dbo].[AddC05_SubContinent_ReChild]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddC05_SubContinent_ReChild]
    @SubContinent_ID int,
    @SubContinent_Child_Name varchar(50),
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 2_SubContinents_ReChild */
        INSERT INTO [2_SubContinents_ReChild]
        (
            [SubContinent_ID2],
            [SubContinent_Child_Name]
        )
        VALUES
        (
            @SubContinent_ID,
            @SubContinent_Child_Name
        )

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [2_SubContinents_ReChild]
        WHERE
            [SubContinent_ID2] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetC05_SubContinent_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetC05_SubContinent_ReChild]
    @SubContinent_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get C05_SubContinent_ReChild from table */
        SELECT
            [2_SubContinents_ReChild].[SubContinent_Child_Name],
            [2_SubContinents_ReChild].[RowVersion]
        FROM [2_SubContinents_ReChild]
        WHERE
            [2_SubContinents_ReChild].[SubContinent_ID2] = @SubContinent_ID2

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteC05_SubContinent_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteC05_SubContinent_ReChild]
    @SubContinent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID2] FROM [2_SubContinents_ReChild]
            WHERE
                [SubContinent_ID2] = @SubContinent_ID
        )
        BEGIN
            RAISERROR ('''C05_SubContinent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete C05_SubContinent_ReChild object from 2_SubContinents_ReChild */
        DELETE
        FROM [2_SubContinents_ReChild]
        WHERE
            [2_SubContinents_ReChild].[SubContinent_ID2] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteE05_SubContinent_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteE05_SubContinent_ReChild]
    @SubContinent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID2] FROM [2_SubContinents_ReChild]
            WHERE
                [SubContinent_ID2] = @SubContinent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E05_SubContinent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark E05_SubContinent_ReChild object as not active */
        UPDATE [2_SubContinents_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [2_SubContinents_ReChild].[SubContinent_ID2] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateE05_SubContinent_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateE05_SubContinent_ReChild]
    @SubContinent_ID int,
    @SubContinent_Child_Name varchar(50),
    @RowVersion timestamp,
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID2] FROM [2_SubContinents_ReChild]
            WHERE
                [SubContinent_ID2] = @SubContinent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E05_SubContinent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Check for row version match */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID2] FROM [2_SubContinents_ReChild]
            WHERE
                [SubContinent_ID2] = @SubContinent_ID AND
                [RowVersion] = @RowVersion
        )
        BEGIN
            RAISERROR ('''E05_SubContinent_ReChild'' object was modified by another user.', 16, 1)
            RETURN
        END

        /* Update object in 2_SubContinents_ReChild */
        UPDATE [2_SubContinents_ReChild]
        SET
            [SubContinent_Child_Name] = @SubContinent_Child_Name
        WHERE
            [SubContinent_ID2] = @SubContinent_ID AND
            [RowVersion] = @RowVersion

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [2_SubContinents_ReChild]
        WHERE
            [SubContinent_ID2] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddE05_SubContinent_ReChild]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddE05_SubContinent_ReChild]
    @SubContinent_ID int,
    @SubContinent_Child_Name varchar(50),
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 2_SubContinents_ReChild */
        INSERT INTO [2_SubContinents_ReChild]
        (
            [SubContinent_ID2],
            [SubContinent_Child_Name]
        )
        VALUES
        (
            @SubContinent_ID,
            @SubContinent_Child_Name
        )

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [2_SubContinents_ReChild]
        WHERE
            [SubContinent_ID2] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateC05_SubContinent_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateC05_SubContinent_ReChild]
    @SubContinent_ID int,
    @SubContinent_Child_Name varchar(50),
    @RowVersion timestamp,
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID2] FROM [2_SubContinents_ReChild]
            WHERE
                [SubContinent_ID2] = @SubContinent_ID
        )
        BEGIN
            RAISERROR ('''C05_SubContinent_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Check for row version match */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID2] FROM [2_SubContinents_ReChild]
            WHERE
                [SubContinent_ID2] = @SubContinent_ID AND
                [RowVersion] = @RowVersion
        )
        BEGIN
            RAISERROR ('''C05_SubContinent_ReChild'' object was modified by another user.', 16, 1)
            RETURN
        END

        /* Update object in 2_SubContinents_ReChild */
        UPDATE [2_SubContinents_ReChild]
        SET
            [SubContinent_Child_Name] = @SubContinent_Child_Name
        WHERE
            [SubContinent_ID2] = @SubContinent_ID AND
            [RowVersion] = @RowVersion

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [2_SubContinents_ReChild]
        WHERE
            [SubContinent_ID2] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteE05_SubContinent_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteE05_SubContinent_Child]
    @SubContinent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID1] FROM [2_SubContinents_Child]
            WHERE
                [SubContinent_ID1] = @SubContinent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E05_SubContinent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark E05_SubContinent_Child object as not active */
        UPDATE [2_SubContinents_Child]
        SET    [IsActive] = 'false'
        WHERE
            [2_SubContinents_Child].[SubContinent_ID1] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddE05_SubContinent_Child]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddE05_SubContinent_Child]
    @SubContinent_ID int,
    @SubContinent_Child_Name varchar(50),
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 2_SubContinents_Child */
        INSERT INTO [2_SubContinents_Child]
        (
            [SubContinent_ID1],
            [SubContinent_Child_Name]
        )
        VALUES
        (
            @SubContinent_ID,
            @SubContinent_Child_Name
        )

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [2_SubContinents_Child]
        WHERE
            [SubContinent_ID1] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateE05_SubContinent_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateE05_SubContinent_Child]
    @SubContinent_ID int,
    @SubContinent_Child_Name varchar(50),
    @SubContinent_ID1 int,
    @RowVersion timestamp,
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID1], [SubContinent_ID1] FROM [2_SubContinents_Child]
            WHERE
                [SubContinent_ID1] = @SubContinent_ID AND
                [SubContinent_ID1] = @SubContinent_ID1 AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E05_SubContinent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Check for row version match */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID1], [SubContinent_ID1] FROM [2_SubContinents_Child]
            WHERE
                [SubContinent_ID1] = @SubContinent_ID AND
                [SubContinent_ID1] = @SubContinent_ID1 AND
                [RowVersion] = @RowVersion
        )
        BEGIN
            RAISERROR ('''E05_SubContinent_Child'' object was modified by another user.', 16, 1)
            RETURN
        END

        /* Update object in 2_SubContinents_Child */
        UPDATE [2_SubContinents_Child]
        SET
            [SubContinent_Child_Name] = @SubContinent_Child_Name
        WHERE
            [SubContinent_ID1] = @SubContinent_ID AND
            [SubContinent_ID1] = @SubContinent_ID1 AND
            [RowVersion] = @RowVersion

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [2_SubContinents_Child]
        WHERE
            [SubContinent_ID1] = @SubContinent_ID AND
            [SubContinent_ID1] = @SubContinent_ID1

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateC05_SubContinent_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateC05_SubContinent_Child]
    @SubContinent_ID int,
    @SubContinent_Child_Name varchar(50),
    @SubContinent_ID1 int,
    @RowVersion timestamp,
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID1], [SubContinent_ID1] FROM [2_SubContinents_Child]
            WHERE
                [SubContinent_ID1] = @SubContinent_ID AND
                [SubContinent_ID1] = @SubContinent_ID1
        )
        BEGIN
            RAISERROR ('''C05_SubContinent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Check for row version match */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID1], [SubContinent_ID1] FROM [2_SubContinents_Child]
            WHERE
                [SubContinent_ID1] = @SubContinent_ID AND
                [SubContinent_ID1] = @SubContinent_ID1 AND
                [RowVersion] = @RowVersion
        )
        BEGIN
            RAISERROR ('''C05_SubContinent_Child'' object was modified by another user.', 16, 1)
            RETURN
        END

        /* Update object in 2_SubContinents_Child */
        UPDATE [2_SubContinents_Child]
        SET
            [SubContinent_Child_Name] = @SubContinent_Child_Name
        WHERE
            [SubContinent_ID1] = @SubContinent_ID AND
            [SubContinent_ID1] = @SubContinent_ID1 AND
            [RowVersion] = @RowVersion

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [2_SubContinents_Child]
        WHERE
            [SubContinent_ID1] = @SubContinent_ID AND
            [SubContinent_ID1] = @SubContinent_ID1

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteC05_SubContinent_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteC05_SubContinent_Child]
    @SubContinent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID1] FROM [2_SubContinents_Child]
            WHERE
                [SubContinent_ID1] = @SubContinent_ID
        )
        BEGIN
            RAISERROR ('''C05_SubContinent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete C05_SubContinent_Child object from 2_SubContinents_Child */
        DELETE
        FROM [2_SubContinents_Child]
        WHERE
            [2_SubContinents_Child].[SubContinent_ID1] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddC05_SubContinent_Child]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddC05_SubContinent_Child]
    @SubContinent_ID int,
    @SubContinent_Child_Name varchar(50),
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 2_SubContinents_Child */
        INSERT INTO [2_SubContinents_Child]
        (
            [SubContinent_ID1],
            [SubContinent_Child_Name]
        )
        VALUES
        (
            @SubContinent_ID,
            @SubContinent_Child_Name
        )

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [2_SubContinents_Child]
        WHERE
            [SubContinent_ID1] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetC05_SubContinent_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetC05_SubContinent_Child]
    @SubContinent_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get C05_SubContinent_Child from table */
        SELECT
            [2_SubContinents_Child].[SubContinent_Child_Name],
            [2_SubContinents_Child].[SubContinent_ID1],
            [2_SubContinents_Child].[RowVersion]
        FROM [2_SubContinents_Child]
        WHERE
            [2_SubContinents_Child].[SubContinent_ID1] = @SubContinent_ID1

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteG05_SubContinent_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteG05_SubContinent_Child]
    @SubContinent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID1] FROM [2_SubContinents_Child]
            WHERE
                [SubContinent_ID1] = @SubContinent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G05_SubContinent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark G05_SubContinent_Child object as not active */
        UPDATE [2_SubContinents_Child]
        SET    [IsActive] = 'false'
        WHERE
            [2_SubContinents_Child].[SubContinent_ID1] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetG05_SubContinent_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetG05_SubContinent_Child]
    @SubContinent_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get G05_SubContinent_Child from table */
        SELECT
            [2_SubContinents_Child].[SubContinent_Child_Name],
            [2_SubContinents_Child].[SubContinent_ID1],
            [2_SubContinents_Child].[RowVersion]
        FROM [2_SubContinents_Child]
        WHERE
            [2_SubContinents_Child].[SubContinent_ID1] = @SubContinent_ID1 AND
            [2_SubContinents_Child].[IsActive] = 'true'

    END
GO
/****** Object:  StoredProcedure [dbo].[AddG05_SubContinent_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddG05_SubContinent_Child]
    @SubContinent_ID int,
    @SubContinent_Child_Name varchar(50),
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 2_SubContinents_Child */
        INSERT INTO [2_SubContinents_Child]
        (
            [SubContinent_ID1],
            [SubContinent_Child_Name]
        )
        VALUES
        (
            @SubContinent_ID,
            @SubContinent_Child_Name
        )

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [2_SubContinents_Child]
        WHERE
            [SubContinent_ID1] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateG05_SubContinent_Child]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateG05_SubContinent_Child]
    @SubContinent_ID int,
    @SubContinent_Child_Name varchar(50),
    @SubContinent_ID1 int,
    @RowVersion timestamp,
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID1], [SubContinent_ID1] FROM [2_SubContinents_Child]
            WHERE
                [SubContinent_ID1] = @SubContinent_ID AND
                [SubContinent_ID1] = @SubContinent_ID1 AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G05_SubContinent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Check for row version match */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID1], [SubContinent_ID1] FROM [2_SubContinents_Child]
            WHERE
                [SubContinent_ID1] = @SubContinent_ID AND
                [SubContinent_ID1] = @SubContinent_ID1 AND
                [RowVersion] = @RowVersion
        )
        BEGIN
            RAISERROR ('''G05_SubContinent_Child'' object was modified by another user.', 16, 1)
            RETURN
        END

        /* Update object in 2_SubContinents_Child */
        UPDATE [2_SubContinents_Child]
        SET
            [SubContinent_Child_Name] = @SubContinent_Child_Name
        WHERE
            [SubContinent_ID1] = @SubContinent_ID AND
            [SubContinent_ID1] = @SubContinent_ID1 AND
            [RowVersion] = @RowVersion

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [2_SubContinents_Child]
        WHERE
            [SubContinent_ID1] = @SubContinent_ID AND
            [SubContinent_ID1] = @SubContinent_ID1

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateD05_SubContinent_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateD05_SubContinent_Child]
    @SubContinent_ID int,
    @SubContinent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID1] FROM [2_SubContinents_Child]
            WHERE
                [SubContinent_ID1] = @SubContinent_ID
        )
        BEGIN
            RAISERROR ('''D05_SubContinent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 2_SubContinents_Child */
        UPDATE [2_SubContinents_Child]
        SET
            [SubContinent_Child_Name] = @SubContinent_Child_Name
        WHERE
            [SubContinent_ID1] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteD05_SubContinent_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteD05_SubContinent_Child]
    @SubContinent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID1] FROM [2_SubContinents_Child]
            WHERE
                [SubContinent_ID1] = @SubContinent_ID
        )
        BEGIN
            RAISERROR ('''D05_SubContinent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete D05_SubContinent_Child object from 2_SubContinents_Child */
        DELETE
        FROM [2_SubContinents_Child]
        WHERE
            [2_SubContinents_Child].[SubContinent_ID1] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddB05_SubContinent_Child]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddB05_SubContinent_Child]
    @SubContinent_ID int,
    @SubContinent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 2_SubContinents_Child */
        INSERT INTO [2_SubContinents_Child]
        (
            [SubContinent_ID1],
            [SubContinent_Child_Name]
        )
        VALUES
        (
            @SubContinent_ID,
            @SubContinent_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateB05_SubContinent_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateB05_SubContinent_Child]
    @SubContinent_ID int,
    @SubContinent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID1] FROM [2_SubContinents_Child]
            WHERE
                [SubContinent_ID1] = @SubContinent_ID
        )
        BEGIN
            RAISERROR ('''B05_SubContinent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 2_SubContinents_Child */
        UPDATE [2_SubContinents_Child]
        SET
            [SubContinent_Child_Name] = @SubContinent_Child_Name
        WHERE
            [SubContinent_ID1] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteB05_SubContinent_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteB05_SubContinent_Child]
    @SubContinent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID1] FROM [2_SubContinents_Child]
            WHERE
                [SubContinent_ID1] = @SubContinent_ID
        )
        BEGIN
            RAISERROR ('''B05_SubContinent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete B05_SubContinent_Child object from 2_SubContinents_Child */
        DELETE
        FROM [2_SubContinents_Child]
        WHERE
            [2_SubContinents_Child].[SubContinent_ID1] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetD05_SubContinent_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetD05_SubContinent_Child]
    @SubContinent_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D05_SubContinent_Child from table */
        SELECT
            [2_SubContinents_Child].[SubContinent_Child_Name]
        FROM [2_SubContinents_Child]
        WHERE
            [2_SubContinents_Child].[SubContinent_ID1] = @SubContinent_ID1

    END
GO
/****** Object:  StoredProcedure [dbo].[AddD05_SubContinent_Child]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddD05_SubContinent_Child]
    @SubContinent_ID int,
    @SubContinent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 2_SubContinents_Child */
        INSERT INTO [2_SubContinents_Child]
        (
            [SubContinent_ID1],
            [SubContinent_Child_Name]
        )
        VALUES
        (
            @SubContinent_ID,
            @SubContinent_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteH05_SubContinent_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteH05_SubContinent_Child]
    @SubContinent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID1] FROM [2_SubContinents_Child]
            WHERE
                [SubContinent_ID1] = @SubContinent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H05_SubContinent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark H05_SubContinent_Child object as not active */
        UPDATE [2_SubContinents_Child]
        SET    [IsActive] = 'false'
        WHERE
            [2_SubContinents_Child].[SubContinent_ID1] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateH05_SubContinent_Child]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateH05_SubContinent_Child]
    @SubContinent_ID int,
    @SubContinent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID1] FROM [2_SubContinents_Child]
            WHERE
                [SubContinent_ID1] = @SubContinent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H05_SubContinent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 2_SubContinents_Child */
        UPDATE [2_SubContinents_Child]
        SET
            [SubContinent_Child_Name] = @SubContinent_Child_Name
        WHERE
            [SubContinent_ID1] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetH05_SubContinent_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetH05_SubContinent_Child]
    @SubContinent_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get H05_SubContinent_Child from table */
        SELECT
            [2_SubContinents_Child].[SubContinent_Child_Name]
        FROM [2_SubContinents_Child]
        WHERE
            [2_SubContinents_Child].[SubContinent_ID1] = @SubContinent_ID1 AND
            [2_SubContinents_Child].[IsActive] = 'true'

    END
GO
/****** Object:  StoredProcedure [dbo].[AddH05_SubContinent_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddH05_SubContinent_Child]
    @SubContinent_ID int,
    @SubContinent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 2_SubContinents_Child */
        INSERT INTO [2_SubContinents_Child]
        (
            [SubContinent_ID1],
            [SubContinent_Child_Name]
        )
        VALUES
        (
            @SubContinent_ID,
            @SubContinent_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[AddF05_SubContinent_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddF05_SubContinent_Child]
    @SubContinent_ID int,
    @SubContinent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 2_SubContinents_Child */
        INSERT INTO [2_SubContinents_Child]
        (
            [SubContinent_ID1],
            [SubContinent_Child_Name]
        )
        VALUES
        (
            @SubContinent_ID,
            @SubContinent_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateF05_SubContinent_Child]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateF05_SubContinent_Child]
    @SubContinent_ID int,
    @SubContinent_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID1] FROM [2_SubContinents_Child]
            WHERE
                [SubContinent_ID1] = @SubContinent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F05_SubContinent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 2_SubContinents_Child */
        UPDATE [2_SubContinents_Child]
        SET
            [SubContinent_Child_Name] = @SubContinent_Child_Name
        WHERE
            [SubContinent_ID1] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteF05_SubContinent_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteF05_SubContinent_Child]
    @SubContinent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID1] FROM [2_SubContinents_Child]
            WHERE
                [SubContinent_ID1] = @SubContinent_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F05_SubContinent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark F05_SubContinent_Child object as not active */
        UPDATE [2_SubContinents_Child]
        SET    [IsActive] = 'false'
        WHERE
            [2_SubContinents_Child].[SubContinent_ID1] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddA05_SubContinent_Child]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddA05_SubContinent_Child]
    @SubContinent_ID int,
    @SubContinent_Child_Name varchar(50),
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 2_SubContinents_Child */
        INSERT INTO [2_SubContinents_Child]
        (
            [SubContinent_ID1],
            [SubContinent_Child_Name]
        )
        VALUES
        (
            @SubContinent_ID,
            @SubContinent_Child_Name
        )

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [2_SubContinents_Child]
        WHERE
            [SubContinent_ID1] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateA05_SubContinent_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateA05_SubContinent_Child]
    @SubContinent_ID int,
    @SubContinent_Child_Name varchar(50),
    @SubContinent_ID1 int,
    @RowVersion timestamp,
    @NewRowVersion timestamp OUTPUT
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID1], [SubContinent_ID1] FROM [2_SubContinents_Child]
            WHERE
                [SubContinent_ID1] = @SubContinent_ID AND
                [SubContinent_ID1] = @SubContinent_ID1
        )
        BEGIN
            RAISERROR ('''A05_SubContinent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Check for row version match */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID1], [SubContinent_ID1] FROM [2_SubContinents_Child]
            WHERE
                [SubContinent_ID1] = @SubContinent_ID AND
                [SubContinent_ID1] = @SubContinent_ID1 AND
                [RowVersion] = @RowVersion
        )
        BEGIN
            RAISERROR ('''A05_SubContinent_Child'' object was modified by another user.', 16, 1)
            RETURN
        END

        /* Update object in 2_SubContinents_Child */
        UPDATE [2_SubContinents_Child]
        SET
            [SubContinent_Child_Name] = @SubContinent_Child_Name
        WHERE
            [SubContinent_ID1] = @SubContinent_ID AND
            [SubContinent_ID1] = @SubContinent_ID1 AND
            [RowVersion] = @RowVersion

        /* Return new row version value */
        SELECT @NewRowVersion = [RowVersion]
        FROM   [2_SubContinents_Child]
        WHERE
            [SubContinent_ID1] = @SubContinent_ID AND
            [SubContinent_ID1] = @SubContinent_ID1

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteA05_SubContinent_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteA05_SubContinent_Child]
    @SubContinent_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [SubContinent_ID1] FROM [2_SubContinents_Child]
            WHERE
                [SubContinent_ID1] = @SubContinent_ID
        )
        BEGIN
            RAISERROR ('''A05_SubContinent_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete A05_SubContinent_Child object from 2_SubContinents_Child */
        DELETE
        FROM [2_SubContinents_Child]
        WHERE
            [2_SubContinents_Child].[SubContinent_ID1] = @SubContinent_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateH07_Country_ReChild]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateH07_Country_ReChild]
    @Country_ID int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID2] FROM [3_Countries_ReChild]
            WHERE
                [Country_ID2] = @Country_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H07_Country_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 3_Countries_ReChild */
        UPDATE [3_Countries_ReChild]
        SET
            [Country_Child_Name] = @Country_Child_Name
        WHERE
            [Country_ID2] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteH07_Country_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteH07_Country_ReChild]
    @Country_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID2] FROM [3_Countries_ReChild]
            WHERE
                [Country_ID2] = @Country_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H07_Country_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark H07_Country_ReChild object as not active */
        UPDATE [3_Countries_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [3_Countries_ReChild].[Country_ID2] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddH07_Country_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddH07_Country_ReChild]
    @Country_ID int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 3_Countries_ReChild */
        INSERT INTO [3_Countries_ReChild]
        (
            [Country_ID2],
            [Country_Child_Name]
        )
        VALUES
        (
            @Country_ID,
            @Country_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[GetH07_Country_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetH07_Country_ReChild]
    @Country_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get H07_Country_ReChild from table */
        SELECT
            [3_Countries_ReChild].[Country_Child_Name]
        FROM [3_Countries_ReChild]
        WHERE
            [3_Countries_ReChild].[Country_ID2] = @Country_ID2 AND
            [3_Countries_ReChild].[IsActive] = 'true'

    END
GO
/****** Object:  StoredProcedure [dbo].[GetC07_Country_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetC07_Country_ReChild]
    @Country_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get C07_Country_ReChild from table */
        SELECT
            [3_Countries_ReChild].[Country_Child_Name]
        FROM [3_Countries_ReChild]
        WHERE
            [3_Countries_ReChild].[Country_ID2] = @Country_ID2

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateC07_Country_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateC07_Country_ReChild]
    @Country_ID int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID2] FROM [3_Countries_ReChild]
            WHERE
                [Country_ID2] = @Country_ID
        )
        BEGIN
            RAISERROR ('''C07_Country_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 3_Countries_ReChild */
        UPDATE [3_Countries_ReChild]
        SET
            [Country_Child_Name] = @Country_Child_Name
        WHERE
            [Country_ID2] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddC07_Country_ReChild]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddC07_Country_ReChild]
    @Country_ID int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 3_Countries_ReChild */
        INSERT INTO [3_Countries_ReChild]
        (
            [Country_ID2],
            [Country_Child_Name]
        )
        VALUES
        (
            @Country_ID,
            @Country_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteC07_Country_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteC07_Country_ReChild]
    @Country_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID2] FROM [3_Countries_ReChild]
            WHERE
                [Country_ID2] = @Country_ID
        )
        BEGIN
            RAISERROR ('''C07_Country_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete C07_Country_ReChild object from 3_Countries_ReChild */
        DELETE
        FROM [3_Countries_ReChild]
        WHERE
            [3_Countries_ReChild].[Country_ID2] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddD07_Country_ReChild]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddD07_Country_ReChild]
    @Country_ID int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 3_Countries_ReChild */
        INSERT INTO [3_Countries_ReChild]
        (
            [Country_ID2],
            [Country_Child_Name]
        )
        VALUES
        (
            @Country_ID,
            @Country_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteD07_Country_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteD07_Country_ReChild]
    @Country_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID2] FROM [3_Countries_ReChild]
            WHERE
                [Country_ID2] = @Country_ID
        )
        BEGIN
            RAISERROR ('''D07_Country_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete D07_Country_ReChild object from 3_Countries_ReChild */
        DELETE
        FROM [3_Countries_ReChild]
        WHERE
            [3_Countries_ReChild].[Country_ID2] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateD07_Country_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateD07_Country_ReChild]
    @Country_ID int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID2] FROM [3_Countries_ReChild]
            WHERE
                [Country_ID2] = @Country_ID
        )
        BEGIN
            RAISERROR ('''D07_Country_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 3_Countries_ReChild */
        UPDATE [3_Countries_ReChild]
        SET
            [Country_Child_Name] = @Country_Child_Name
        WHERE
            [Country_ID2] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetD07_Country_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetD07_Country_ReChild]
    @Country_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D07_Country_ReChild from table */
        SELECT
            [3_Countries_ReChild].[Country_Child_Name]
        FROM [3_Countries_ReChild]
        WHERE
            [3_Countries_ReChild].[Country_ID2] = @Country_ID2

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteF07_Country_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteF07_Country_ReChild]
    @Country_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID2] FROM [3_Countries_ReChild]
            WHERE
                [Country_ID2] = @Country_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F07_Country_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark F07_Country_ReChild object as not active */
        UPDATE [3_Countries_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [3_Countries_ReChild].[Country_ID2] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateF07_Country_ReChild]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateF07_Country_ReChild]
    @Country_ID int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID2] FROM [3_Countries_ReChild]
            WHERE
                [Country_ID2] = @Country_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F07_Country_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 3_Countries_ReChild */
        UPDATE [3_Countries_ReChild]
        SET
            [Country_Child_Name] = @Country_Child_Name
        WHERE
            [Country_ID2] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateA07_Country_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateA07_Country_ReChild]
    @Country_ID int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID2] FROM [3_Countries_ReChild]
            WHERE
                [Country_ID2] = @Country_ID
        )
        BEGIN
            RAISERROR ('''A07_Country_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 3_Countries_ReChild */
        UPDATE [3_Countries_ReChild]
        SET
            [Country_Child_Name] = @Country_Child_Name
        WHERE
            [Country_ID2] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteA07_Country_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteA07_Country_ReChild]
    @Country_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID2] FROM [3_Countries_ReChild]
            WHERE
                [Country_ID2] = @Country_ID
        )
        BEGIN
            RAISERROR ('''A07_Country_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete A07_Country_ReChild object from 3_Countries_ReChild */
        DELETE
        FROM [3_Countries_ReChild]
        WHERE
            [3_Countries_ReChild].[Country_ID2] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddA07_Country_ReChild]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddA07_Country_ReChild]
    @Country_ID int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 3_Countries_ReChild */
        INSERT INTO [3_Countries_ReChild]
        (
            [Country_ID2],
            [Country_Child_Name]
        )
        VALUES
        (
            @Country_ID,
            @Country_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[AddF07_Country_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddF07_Country_ReChild]
    @Country_ID int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 3_Countries_ReChild */
        INSERT INTO [3_Countries_ReChild]
        (
            [Country_ID2],
            [Country_Child_Name]
        )
        VALUES
        (
            @Country_ID,
            @Country_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[GetG07_Country_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetG07_Country_ReChild]
    @Country_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get G07_Country_ReChild from table */
        SELECT
            [3_Countries_ReChild].[Country_Child_Name]
        FROM [3_Countries_ReChild]
        WHERE
            [3_Countries_ReChild].[Country_ID2] = @Country_ID2 AND
            [3_Countries_ReChild].[IsActive] = 'true'

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateG07_Country_ReChild]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateG07_Country_ReChild]
    @Country_ID int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID2] FROM [3_Countries_ReChild]
            WHERE
                [Country_ID2] = @Country_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G07_Country_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 3_Countries_ReChild */
        UPDATE [3_Countries_ReChild]
        SET
            [Country_Child_Name] = @Country_Child_Name
        WHERE
            [Country_ID2] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddG07_Country_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddG07_Country_ReChild]
    @Country_ID int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 3_Countries_ReChild */
        INSERT INTO [3_Countries_ReChild]
        (
            [Country_ID2],
            [Country_Child_Name]
        )
        VALUES
        (
            @Country_ID,
            @Country_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteG07_Country_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteG07_Country_ReChild]
    @Country_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID2] FROM [3_Countries_ReChild]
            WHERE
                [Country_ID2] = @Country_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G07_Country_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark G07_Country_ReChild object as not active */
        UPDATE [3_Countries_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [3_Countries_ReChild].[Country_ID2] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteB07_Country_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteB07_Country_ReChild]
    @Country_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID2] FROM [3_Countries_ReChild]
            WHERE
                [Country_ID2] = @Country_ID
        )
        BEGIN
            RAISERROR ('''B07_Country_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete B07_Country_ReChild object from 3_Countries_ReChild */
        DELETE
        FROM [3_Countries_ReChild]
        WHERE
            [3_Countries_ReChild].[Country_ID2] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateB07_Country_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateB07_Country_ReChild]
    @Country_ID int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID2] FROM [3_Countries_ReChild]
            WHERE
                [Country_ID2] = @Country_ID
        )
        BEGIN
            RAISERROR ('''B07_Country_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 3_Countries_ReChild */
        UPDATE [3_Countries_ReChild]
        SET
            [Country_Child_Name] = @Country_Child_Name
        WHERE
            [Country_ID2] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddB07_Country_ReChild]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddB07_Country_ReChild]
    @Country_ID int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 3_Countries_ReChild */
        INSERT INTO [3_Countries_ReChild]
        (
            [Country_ID2],
            [Country_Child_Name]
        )
        VALUES
        (
            @Country_ID,
            @Country_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateE07_Country_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateE07_Country_ReChild]
    @Country_ID int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID2] FROM [3_Countries_ReChild]
            WHERE
                [Country_ID2] = @Country_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E07_Country_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 3_Countries_ReChild */
        UPDATE [3_Countries_ReChild]
        SET
            [Country_Child_Name] = @Country_Child_Name
        WHERE
            [Country_ID2] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteE07_Country_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteE07_Country_ReChild]
    @Country_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID2] FROM [3_Countries_ReChild]
            WHERE
                [Country_ID2] = @Country_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E07_Country_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark E07_Country_ReChild object as not active */
        UPDATE [3_Countries_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [3_Countries_ReChild].[Country_ID2] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddE07_Country_ReChild]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddE07_Country_ReChild]
    @Country_ID int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 3_Countries_ReChild */
        INSERT INTO [3_Countries_ReChild]
        (
            [Country_ID2],
            [Country_Child_Name]
        )
        VALUES
        (
            @Country_ID,
            @Country_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[AddE07_Country_Child]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddE07_Country_Child]
    @Country_ID int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 3_Countries_Child */
        INSERT INTO [3_Countries_Child]
        (
            [Country_ID1],
            [Country_Child_Name]
        )
        VALUES
        (
            @Country_ID,
            @Country_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteE07_Country_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteE07_Country_Child]
    @Country_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID1] FROM [3_Countries_Child]
            WHERE
                [Country_ID1] = @Country_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E07_Country_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark E07_Country_Child object as not active */
        UPDATE [3_Countries_Child]
        SET    [IsActive] = 'false'
        WHERE
            [3_Countries_Child].[Country_ID1] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateE07_Country_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateE07_Country_Child]
    @Country_ID int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID1] FROM [3_Countries_Child]
            WHERE
                [Country_ID1] = @Country_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E07_Country_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 3_Countries_Child */
        UPDATE [3_Countries_Child]
        SET
            [Country_Child_Name] = @Country_Child_Name
        WHERE
            [Country_ID1] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetG07_Country_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetG07_Country_Child]
    @Country_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get G07_Country_Child from table */
        SELECT
            [3_Countries_Child].[Country_Child_Name]
        FROM [3_Countries_Child]
        WHERE
            [3_Countries_Child].[Country_ID1] = @Country_ID1 AND
            [3_Countries_Child].[IsActive] = 'true'

    END
GO
/****** Object:  StoredProcedure [dbo].[AddG07_Country_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddG07_Country_Child]
    @Country_ID int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 3_Countries_Child */
        INSERT INTO [3_Countries_Child]
        (
            [Country_ID1],
            [Country_Child_Name]
        )
        VALUES
        (
            @Country_ID,
            @Country_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateG07_Country_Child]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateG07_Country_Child]
    @Country_ID int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID1] FROM [3_Countries_Child]
            WHERE
                [Country_ID1] = @Country_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G07_Country_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 3_Countries_Child */
        UPDATE [3_Countries_Child]
        SET
            [Country_Child_Name] = @Country_Child_Name
        WHERE
            [Country_ID1] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteG07_Country_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteG07_Country_Child]
    @Country_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID1] FROM [3_Countries_Child]
            WHERE
                [Country_ID1] = @Country_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G07_Country_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark G07_Country_Child object as not active */
        UPDATE [3_Countries_Child]
        SET    [IsActive] = 'false'
        WHERE
            [3_Countries_Child].[Country_ID1] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateB07_Country_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateB07_Country_Child]
    @Country_ID int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID1] FROM [3_Countries_Child]
            WHERE
                [Country_ID1] = @Country_ID
        )
        BEGIN
            RAISERROR ('''B07_Country_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 3_Countries_Child */
        UPDATE [3_Countries_Child]
        SET
            [Country_Child_Name] = @Country_Child_Name
        WHERE
            [Country_ID1] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteB07_Country_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteB07_Country_Child]
    @Country_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID1] FROM [3_Countries_Child]
            WHERE
                [Country_ID1] = @Country_ID
        )
        BEGIN
            RAISERROR ('''B07_Country_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete B07_Country_Child object from 3_Countries_Child */
        DELETE
        FROM [3_Countries_Child]
        WHERE
            [3_Countries_Child].[Country_ID1] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddB07_Country_Child]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddB07_Country_Child]
    @Country_ID int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 3_Countries_Child */
        INSERT INTO [3_Countries_Child]
        (
            [Country_ID1],
            [Country_Child_Name]
        )
        VALUES
        (
            @Country_ID,
            @Country_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteF07_Country_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteF07_Country_Child]
    @Country_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID1] FROM [3_Countries_Child]
            WHERE
                [Country_ID1] = @Country_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F07_Country_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark F07_Country_Child object as not active */
        UPDATE [3_Countries_Child]
        SET    [IsActive] = 'false'
        WHERE
            [3_Countries_Child].[Country_ID1] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddA07_Country_Child]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddA07_Country_Child]
    @Country_ID int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 3_Countries_Child */
        INSERT INTO [3_Countries_Child]
        (
            [Country_ID1],
            [Country_Child_Name]
        )
        VALUES
        (
            @Country_ID,
            @Country_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateF07_Country_Child]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateF07_Country_Child]
    @Country_ID int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID1] FROM [3_Countries_Child]
            WHERE
                [Country_ID1] = @Country_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F07_Country_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 3_Countries_Child */
        UPDATE [3_Countries_Child]
        SET
            [Country_Child_Name] = @Country_Child_Name
        WHERE
            [Country_ID1] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddF07_Country_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddF07_Country_Child]
    @Country_ID int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 3_Countries_Child */
        INSERT INTO [3_Countries_Child]
        (
            [Country_ID1],
            [Country_Child_Name]
        )
        VALUES
        (
            @Country_ID,
            @Country_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[AddD07_Country_Child]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddD07_Country_Child]
    @Country_ID int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 3_Countries_Child */
        INSERT INTO [3_Countries_Child]
        (
            [Country_ID1],
            [Country_Child_Name]
        )
        VALUES
        (
            @Country_ID,
            @Country_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateD07_Country_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateD07_Country_Child]
    @Country_ID int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID1] FROM [3_Countries_Child]
            WHERE
                [Country_ID1] = @Country_ID
        )
        BEGIN
            RAISERROR ('''D07_Country_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 3_Countries_Child */
        UPDATE [3_Countries_Child]
        SET
            [Country_Child_Name] = @Country_Child_Name
        WHERE
            [Country_ID1] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteD07_Country_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteD07_Country_Child]
    @Country_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID1] FROM [3_Countries_Child]
            WHERE
                [Country_ID1] = @Country_ID
        )
        BEGIN
            RAISERROR ('''D07_Country_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete D07_Country_Child object from 3_Countries_Child */
        DELETE
        FROM [3_Countries_Child]
        WHERE
            [3_Countries_Child].[Country_ID1] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetD07_Country_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetD07_Country_Child]
    @Country_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D07_Country_Child from table */
        SELECT
            [3_Countries_Child].[Country_Child_Name]
        FROM [3_Countries_Child]
        WHERE
            [3_Countries_Child].[Country_ID1] = @Country_ID1

    END
GO
/****** Object:  StoredProcedure [dbo].[GetC07_Country_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetC07_Country_Child]
    @Country_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get C07_Country_Child from table */
        SELECT
            [3_Countries_Child].[Country_Child_Name]
        FROM [3_Countries_Child]
        WHERE
            [3_Countries_Child].[Country_ID1] = @Country_ID1

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteC07_Country_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteC07_Country_Child]
    @Country_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID1] FROM [3_Countries_Child]
            WHERE
                [Country_ID1] = @Country_ID
        )
        BEGIN
            RAISERROR ('''C07_Country_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete C07_Country_Child object from 3_Countries_Child */
        DELETE
        FROM [3_Countries_Child]
        WHERE
            [3_Countries_Child].[Country_ID1] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateC07_Country_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateC07_Country_Child]
    @Country_ID int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID1] FROM [3_Countries_Child]
            WHERE
                [Country_ID1] = @Country_ID
        )
        BEGIN
            RAISERROR ('''C07_Country_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 3_Countries_Child */
        UPDATE [3_Countries_Child]
        SET
            [Country_Child_Name] = @Country_Child_Name
        WHERE
            [Country_ID1] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddC07_Country_Child]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddC07_Country_Child]
    @Country_ID int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 3_Countries_Child */
        INSERT INTO [3_Countries_Child]
        (
            [Country_ID1],
            [Country_Child_Name]
        )
        VALUES
        (
            @Country_ID,
            @Country_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteA07_Country_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteA07_Country_Child]
    @Country_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID1] FROM [3_Countries_Child]
            WHERE
                [Country_ID1] = @Country_ID
        )
        BEGIN
            RAISERROR ('''A07_Country_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete A07_Country_Child object from 3_Countries_Child */
        DELETE
        FROM [3_Countries_Child]
        WHERE
            [3_Countries_Child].[Country_ID1] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateA07_Country_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateA07_Country_Child]
    @Country_ID int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID1] FROM [3_Countries_Child]
            WHERE
                [Country_ID1] = @Country_ID
        )
        BEGIN
            RAISERROR ('''A07_Country_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 3_Countries_Child */
        UPDATE [3_Countries_Child]
        SET
            [Country_Child_Name] = @Country_Child_Name
        WHERE
            [Country_ID1] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteH07_Country_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteH07_Country_Child]
    @Country_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID1] FROM [3_Countries_Child]
            WHERE
                [Country_ID1] = @Country_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H07_Country_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark H07_Country_Child object as not active */
        UPDATE [3_Countries_Child]
        SET    [IsActive] = 'false'
        WHERE
            [3_Countries_Child].[Country_ID1] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetH07_Country_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetH07_Country_Child]
    @Country_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get H07_Country_Child from table */
        SELECT
            [3_Countries_Child].[Country_Child_Name]
        FROM [3_Countries_Child]
        WHERE
            [3_Countries_Child].[Country_ID1] = @Country_ID1 AND
            [3_Countries_Child].[IsActive] = 'true'

    END
GO
/****** Object:  StoredProcedure [dbo].[AddH07_Country_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddH07_Country_Child]
    @Country_ID int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 3_Countries_Child */
        INSERT INTO [3_Countries_Child]
        (
            [Country_ID1],
            [Country_Child_Name]
        )
        VALUES
        (
            @Country_ID,
            @Country_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateH07_Country_Child]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateH07_Country_Child]
    @Country_ID int,
    @Country_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Country_ID1] FROM [3_Countries_Child]
            WHERE
                [Country_ID1] = @Country_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H07_Country_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 3_Countries_Child */
        UPDATE [3_Countries_Child]
        SET
            [Country_Child_Name] = @Country_Child_Name
        WHERE
            [Country_ID1] = @Country_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteC09_Region_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteC09_Region_Child]
    @Region_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID1] FROM [4_Regions_Child]
            WHERE
                [Region_ID1] = @Region_ID
        )
        BEGIN
            RAISERROR ('''C09_Region_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete C09_Region_Child object from 4_Regions_Child */
        DELETE
        FROM [4_Regions_Child]
        WHERE
            [4_Regions_Child].[Region_ID1] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateC09_Region_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateC09_Region_Child]
    @Region_ID int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID1] FROM [4_Regions_Child]
            WHERE
                [Region_ID1] = @Region_ID
        )
        BEGIN
            RAISERROR ('''C09_Region_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 4_Regions_Child */
        UPDATE [4_Regions_Child]
        SET
            [Region_Child_Name] = @Region_Child_Name
        WHERE
            [Region_ID1] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetC09_Region_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetC09_Region_Child]
    @Region_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get C09_Region_Child from table */
        SELECT
            [4_Regions_Child].[Region_Child_Name]
        FROM [4_Regions_Child]
        WHERE
            [4_Regions_Child].[Region_ID1] = @Region_ID1

    END
GO
/****** Object:  StoredProcedure [dbo].[AddC09_Region_Child]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddC09_Region_Child]
    @Region_ID int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 4_Regions_Child */
        INSERT INTO [4_Regions_Child]
        (
            [Region_ID1],
            [Region_Child_Name]
        )
        VALUES
        (
            @Region_ID,
            @Region_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[AddE09_Region_Child]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddE09_Region_Child]
    @Region_ID int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 4_Regions_Child */
        INSERT INTO [4_Regions_Child]
        (
            [Region_ID1],
            [Region_Child_Name]
        )
        VALUES
        (
            @Region_ID,
            @Region_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[GetH09_Region_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetH09_Region_Child]
    @Region_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get H09_Region_Child from table */
        SELECT
            [4_Regions_Child].[Region_Child_Name]
        FROM [4_Regions_Child]
        WHERE
            [4_Regions_Child].[Region_ID1] = @Region_ID1 AND
            [4_Regions_Child].[IsActive] = 'true'

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateA09_Region_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateA09_Region_Child]
    @Region_ID int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID1] FROM [4_Regions_Child]
            WHERE
                [Region_ID1] = @Region_ID
        )
        BEGIN
            RAISERROR ('''A09_Region_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 4_Regions_Child */
        UPDATE [4_Regions_Child]
        SET
            [Region_Child_Name] = @Region_Child_Name
        WHERE
            [Region_ID1] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteA09_Region_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteA09_Region_Child]
    @Region_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID1] FROM [4_Regions_Child]
            WHERE
                [Region_ID1] = @Region_ID
        )
        BEGIN
            RAISERROR ('''A09_Region_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete A09_Region_Child object from 4_Regions_Child */
        DELETE
        FROM [4_Regions_Child]
        WHERE
            [4_Regions_Child].[Region_ID1] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddA09_Region_Child]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddA09_Region_Child]
    @Region_ID int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 4_Regions_Child */
        INSERT INTO [4_Regions_Child]
        (
            [Region_ID1],
            [Region_Child_Name]
        )
        VALUES
        (
            @Region_ID,
            @Region_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[AddH09_Region_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddH09_Region_Child]
    @Region_ID int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 4_Regions_Child */
        INSERT INTO [4_Regions_Child]
        (
            [Region_ID1],
            [Region_Child_Name]
        )
        VALUES
        (
            @Region_ID,
            @Region_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteH09_Region_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteH09_Region_Child]
    @Region_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID1] FROM [4_Regions_Child]
            WHERE
                [Region_ID1] = @Region_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H09_Region_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark H09_Region_Child object as not active */
        UPDATE [4_Regions_Child]
        SET    [IsActive] = 'false'
        WHERE
            [4_Regions_Child].[Region_ID1] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateH09_Region_Child]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateH09_Region_Child]
    @Region_ID int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID1] FROM [4_Regions_Child]
            WHERE
                [Region_ID1] = @Region_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H09_Region_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 4_Regions_Child */
        UPDATE [4_Regions_Child]
        SET
            [Region_Child_Name] = @Region_Child_Name
        WHERE
            [Region_ID1] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateF09_Region_Child]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateF09_Region_Child]
    @Region_ID int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID1] FROM [4_Regions_Child]
            WHERE
                [Region_ID1] = @Region_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F09_Region_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 4_Regions_Child */
        UPDATE [4_Regions_Child]
        SET
            [Region_Child_Name] = @Region_Child_Name
        WHERE
            [Region_ID1] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddF09_Region_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddF09_Region_Child]
    @Region_ID int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 4_Regions_Child */
        INSERT INTO [4_Regions_Child]
        (
            [Region_ID1],
            [Region_Child_Name]
        )
        VALUES
        (
            @Region_ID,
            @Region_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteF09_Region_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteF09_Region_Child]
    @Region_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID1] FROM [4_Regions_Child]
            WHERE
                [Region_ID1] = @Region_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F09_Region_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark F09_Region_Child object as not active */
        UPDATE [4_Regions_Child]
        SET    [IsActive] = 'false'
        WHERE
            [4_Regions_Child].[Region_ID1] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateG09_Region_Child]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateG09_Region_Child]
    @Region_ID int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID1] FROM [4_Regions_Child]
            WHERE
                [Region_ID1] = @Region_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G09_Region_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 4_Regions_Child */
        UPDATE [4_Regions_Child]
        SET
            [Region_Child_Name] = @Region_Child_Name
        WHERE
            [Region_ID1] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteG09_Region_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteG09_Region_Child]
    @Region_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID1] FROM [4_Regions_Child]
            WHERE
                [Region_ID1] = @Region_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G09_Region_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark G09_Region_Child object as not active */
        UPDATE [4_Regions_Child]
        SET    [IsActive] = 'false'
        WHERE
            [4_Regions_Child].[Region_ID1] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddD09_Region_Child]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddD09_Region_Child]
    @Region_ID int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 4_Regions_Child */
        INSERT INTO [4_Regions_Child]
        (
            [Region_ID1],
            [Region_Child_Name]
        )
        VALUES
        (
            @Region_ID,
            @Region_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[GetD09_Region_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetD09_Region_Child]
    @Region_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D09_Region_Child from table */
        SELECT
            [4_Regions_Child].[Region_Child_Name]
        FROM [4_Regions_Child]
        WHERE
            [4_Regions_Child].[Region_ID1] = @Region_ID1

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateD09_Region_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateD09_Region_Child]
    @Region_ID int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID1] FROM [4_Regions_Child]
            WHERE
                [Region_ID1] = @Region_ID
        )
        BEGIN
            RAISERROR ('''D09_Region_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 4_Regions_Child */
        UPDATE [4_Regions_Child]
        SET
            [Region_Child_Name] = @Region_Child_Name
        WHERE
            [Region_ID1] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteD09_Region_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteD09_Region_Child]
    @Region_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID1] FROM [4_Regions_Child]
            WHERE
                [Region_ID1] = @Region_ID
        )
        BEGIN
            RAISERROR ('''D09_Region_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete D09_Region_Child object from 4_Regions_Child */
        DELETE
        FROM [4_Regions_Child]
        WHERE
            [4_Regions_Child].[Region_ID1] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateB09_Region_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateB09_Region_Child]
    @Region_ID int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID1] FROM [4_Regions_Child]
            WHERE
                [Region_ID1] = @Region_ID
        )
        BEGIN
            RAISERROR ('''B09_Region_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 4_Regions_Child */
        UPDATE [4_Regions_Child]
        SET
            [Region_Child_Name] = @Region_Child_Name
        WHERE
            [Region_ID1] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddB09_Region_Child]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddB09_Region_Child]
    @Region_ID int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 4_Regions_Child */
        INSERT INTO [4_Regions_Child]
        (
            [Region_ID1],
            [Region_Child_Name]
        )
        VALUES
        (
            @Region_ID,
            @Region_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteB09_Region_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteB09_Region_Child]
    @Region_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID1] FROM [4_Regions_Child]
            WHERE
                [Region_ID1] = @Region_ID
        )
        BEGIN
            RAISERROR ('''B09_Region_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete B09_Region_Child object from 4_Regions_Child */
        DELETE
        FROM [4_Regions_Child]
        WHERE
            [4_Regions_Child].[Region_ID1] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteE09_Region_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteE09_Region_Child]
    @Region_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID1] FROM [4_Regions_Child]
            WHERE
                [Region_ID1] = @Region_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E09_Region_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark E09_Region_Child object as not active */
        UPDATE [4_Regions_Child]
        SET    [IsActive] = 'false'
        WHERE
            [4_Regions_Child].[Region_ID1] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateE09_Region_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateE09_Region_Child]
    @Region_ID int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID1] FROM [4_Regions_Child]
            WHERE
                [Region_ID1] = @Region_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E09_Region_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 4_Regions_Child */
        UPDATE [4_Regions_Child]
        SET
            [Region_Child_Name] = @Region_Child_Name
        WHERE
            [Region_ID1] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetG09_Region_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetG09_Region_Child]
    @Region_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get G09_Region_Child from table */
        SELECT
            [4_Regions_Child].[Region_Child_Name]
        FROM [4_Regions_Child]
        WHERE
            [4_Regions_Child].[Region_ID1] = @Region_ID1 AND
            [4_Regions_Child].[IsActive] = 'true'

    END
GO
/****** Object:  StoredProcedure [dbo].[AddG09_Region_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddG09_Region_Child]
    @Region_ID int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 4_Regions_Child */
        INSERT INTO [4_Regions_Child]
        (
            [Region_ID1],
            [Region_Child_Name]
        )
        VALUES
        (
            @Region_ID,
            @Region_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[GetG09_Region_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetG09_Region_ReChild]
    @Region_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get G09_Region_ReChild from table */
        SELECT
            [4_Regions_ReChild].[Region_Child_Name]
        FROM [4_Regions_ReChild]
        WHERE
            [4_Regions_ReChild].[Region_ID2] = @Region_ID2 AND
            [4_Regions_ReChild].[IsActive] = 'true'

    END
GO
/****** Object:  StoredProcedure [dbo].[AddG09_Region_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddG09_Region_ReChild]
    @Region_ID int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 4_Regions_ReChild */
        INSERT INTO [4_Regions_ReChild]
        (
            [Region_ID2],
            [Region_Child_Name]
        )
        VALUES
        (
            @Region_ID,
            @Region_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateG09_Region_ReChild]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateG09_Region_ReChild]
    @Region_ID int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID2] FROM [4_Regions_ReChild]
            WHERE
                [Region_ID2] = @Region_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G09_Region_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 4_Regions_ReChild */
        UPDATE [4_Regions_ReChild]
        SET
            [Region_Child_Name] = @Region_Child_Name
        WHERE
            [Region_ID2] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteG09_Region_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteG09_Region_ReChild]
    @Region_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID2] FROM [4_Regions_ReChild]
            WHERE
                [Region_ID2] = @Region_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G09_Region_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark G09_Region_ReChild object as not active */
        UPDATE [4_Regions_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [4_Regions_ReChild].[Region_ID2] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteB09_Region_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteB09_Region_ReChild]
    @Region_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID2] FROM [4_Regions_ReChild]
            WHERE
                [Region_ID2] = @Region_ID
        )
        BEGIN
            RAISERROR ('''B09_Region_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete B09_Region_ReChild object from 4_Regions_ReChild */
        DELETE
        FROM [4_Regions_ReChild]
        WHERE
            [4_Regions_ReChild].[Region_ID2] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateB09_Region_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateB09_Region_ReChild]
    @Region_ID int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID2] FROM [4_Regions_ReChild]
            WHERE
                [Region_ID2] = @Region_ID
        )
        BEGIN
            RAISERROR ('''B09_Region_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 4_Regions_ReChild */
        UPDATE [4_Regions_ReChild]
        SET
            [Region_Child_Name] = @Region_Child_Name
        WHERE
            [Region_ID2] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddB09_Region_ReChild]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddB09_Region_ReChild]
    @Region_ID int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 4_Regions_ReChild */
        INSERT INTO [4_Regions_ReChild]
        (
            [Region_ID2],
            [Region_Child_Name]
        )
        VALUES
        (
            @Region_ID,
            @Region_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteD09_Region_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteD09_Region_ReChild]
    @Region_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID2] FROM [4_Regions_ReChild]
            WHERE
                [Region_ID2] = @Region_ID
        )
        BEGIN
            RAISERROR ('''D09_Region_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete D09_Region_ReChild object from 4_Regions_ReChild */
        DELETE
        FROM [4_Regions_ReChild]
        WHERE
            [4_Regions_ReChild].[Region_ID2] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateD09_Region_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateD09_Region_ReChild]
    @Region_ID int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID2] FROM [4_Regions_ReChild]
            WHERE
                [Region_ID2] = @Region_ID
        )
        BEGIN
            RAISERROR ('''D09_Region_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 4_Regions_ReChild */
        UPDATE [4_Regions_ReChild]
        SET
            [Region_Child_Name] = @Region_Child_Name
        WHERE
            [Region_ID2] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetD09_Region_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetD09_Region_ReChild]
    @Region_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D09_Region_ReChild from table */
        SELECT
            [4_Regions_ReChild].[Region_Child_Name]
        FROM [4_Regions_ReChild]
        WHERE
            [4_Regions_ReChild].[Region_ID2] = @Region_ID2

    END
GO
/****** Object:  StoredProcedure [dbo].[AddD09_Region_ReChild]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddD09_Region_ReChild]
    @Region_ID int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 4_Regions_ReChild */
        INSERT INTO [4_Regions_ReChild]
        (
            [Region_ID2],
            [Region_Child_Name]
        )
        VALUES
        (
            @Region_ID,
            @Region_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateA09_Region_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateA09_Region_ReChild]
    @Region_ID int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID2] FROM [4_Regions_ReChild]
            WHERE
                [Region_ID2] = @Region_ID
        )
        BEGIN
            RAISERROR ('''A09_Region_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 4_Regions_ReChild */
        UPDATE [4_Regions_ReChild]
        SET
            [Region_Child_Name] = @Region_Child_Name
        WHERE
            [Region_ID2] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddA09_Region_ReChild]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddA09_Region_ReChild]
    @Region_ID int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 4_Regions_ReChild */
        INSERT INTO [4_Regions_ReChild]
        (
            [Region_ID2],
            [Region_Child_Name]
        )
        VALUES
        (
            @Region_ID,
            @Region_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[GetH09_Region_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetH09_Region_ReChild]
    @Region_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get H09_Region_ReChild from table */
        SELECT
            [4_Regions_ReChild].[Region_Child_Name]
        FROM [4_Regions_ReChild]
        WHERE
            [4_Regions_ReChild].[Region_ID2] = @Region_ID2 AND
            [4_Regions_ReChild].[IsActive] = 'true'

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteF09_Region_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteF09_Region_ReChild]
    @Region_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID2] FROM [4_Regions_ReChild]
            WHERE
                [Region_ID2] = @Region_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F09_Region_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark F09_Region_ReChild object as not active */
        UPDATE [4_Regions_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [4_Regions_ReChild].[Region_ID2] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateF09_Region_ReChild]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateF09_Region_ReChild]
    @Region_ID int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID2] FROM [4_Regions_ReChild]
            WHERE
                [Region_ID2] = @Region_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F09_Region_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 4_Regions_ReChild */
        UPDATE [4_Regions_ReChild]
        SET
            [Region_Child_Name] = @Region_Child_Name
        WHERE
            [Region_ID2] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddF09_Region_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddF09_Region_ReChild]
    @Region_ID int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 4_Regions_ReChild */
        INSERT INTO [4_Regions_ReChild]
        (
            [Region_ID2],
            [Region_Child_Name]
        )
        VALUES
        (
            @Region_ID,
            @Region_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteA09_Region_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteA09_Region_ReChild]
    @Region_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID2] FROM [4_Regions_ReChild]
            WHERE
                [Region_ID2] = @Region_ID
        )
        BEGIN
            RAISERROR ('''A09_Region_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete A09_Region_ReChild object from 4_Regions_ReChild */
        DELETE
        FROM [4_Regions_ReChild]
        WHERE
            [4_Regions_ReChild].[Region_ID2] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddH09_Region_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddH09_Region_ReChild]
    @Region_ID int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 4_Regions_ReChild */
        INSERT INTO [4_Regions_ReChild]
        (
            [Region_ID2],
            [Region_Child_Name]
        )
        VALUES
        (
            @Region_ID,
            @Region_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateH09_Region_ReChild]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateH09_Region_ReChild]
    @Region_ID int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID2] FROM [4_Regions_ReChild]
            WHERE
                [Region_ID2] = @Region_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H09_Region_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 4_Regions_ReChild */
        UPDATE [4_Regions_ReChild]
        SET
            [Region_Child_Name] = @Region_Child_Name
        WHERE
            [Region_ID2] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteH09_Region_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteH09_Region_ReChild]
    @Region_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID2] FROM [4_Regions_ReChild]
            WHERE
                [Region_ID2] = @Region_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H09_Region_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark H09_Region_ReChild object as not active */
        UPDATE [4_Regions_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [4_Regions_ReChild].[Region_ID2] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddE09_Region_ReChild]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddE09_Region_ReChild]
    @Region_ID int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 4_Regions_ReChild */
        INSERT INTO [4_Regions_ReChild]
        (
            [Region_ID2],
            [Region_Child_Name]
        )
        VALUES
        (
            @Region_ID,
            @Region_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateE09_Region_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateE09_Region_ReChild]
    @Region_ID int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID2] FROM [4_Regions_ReChild]
            WHERE
                [Region_ID2] = @Region_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E09_Region_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 4_Regions_ReChild */
        UPDATE [4_Regions_ReChild]
        SET
            [Region_Child_Name] = @Region_Child_Name
        WHERE
            [Region_ID2] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteE09_Region_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteE09_Region_ReChild]
    @Region_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID2] FROM [4_Regions_ReChild]
            WHERE
                [Region_ID2] = @Region_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E09_Region_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark E09_Region_ReChild object as not active */
        UPDATE [4_Regions_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [4_Regions_ReChild].[Region_ID2] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteC09_Region_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteC09_Region_ReChild]
    @Region_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID2] FROM [4_Regions_ReChild]
            WHERE
                [Region_ID2] = @Region_ID
        )
        BEGIN
            RAISERROR ('''C09_Region_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete C09_Region_ReChild object from 4_Regions_ReChild */
        DELETE
        FROM [4_Regions_ReChild]
        WHERE
            [4_Regions_ReChild].[Region_ID2] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateC09_Region_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateC09_Region_ReChild]
    @Region_ID int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [Region_ID2] FROM [4_Regions_ReChild]
            WHERE
                [Region_ID2] = @Region_ID
        )
        BEGIN
            RAISERROR ('''C09_Region_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 4_Regions_ReChild */
        UPDATE [4_Regions_ReChild]
        SET
            [Region_Child_Name] = @Region_Child_Name
        WHERE
            [Region_ID2] = @Region_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetC09_Region_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetC09_Region_ReChild]
    @Region_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get C09_Region_ReChild from table */
        SELECT
            [4_Regions_ReChild].[Region_Child_Name]
        FROM [4_Regions_ReChild]
        WHERE
            [4_Regions_ReChild].[Region_ID2] = @Region_ID2

    END
GO
/****** Object:  StoredProcedure [dbo].[AddC09_Region_ReChild]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddC09_Region_ReChild]
    @Region_ID int,
    @Region_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 4_Regions_ReChild */
        INSERT INTO [4_Regions_ReChild]
        (
            [Region_ID2],
            [Region_Child_Name]
        )
        VALUES
        (
            @Region_ID,
            @Region_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateC11_City_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateC11_City_Child]
    @City_ID int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID1] FROM [5_Cities_Child]
            WHERE
                [City_ID1] = @City_ID
        )
        BEGIN
            RAISERROR ('''C11_City_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 5_Cities_Child */
        UPDATE [5_Cities_Child]
        SET
            [City_Child_Name] = @City_Child_Name
        WHERE
            [City_ID1] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddC11_City_Child]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddC11_City_Child]
    @City_ID int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 5_Cities_Child */
        INSERT INTO [5_Cities_Child]
        (
            [City_ID1],
            [City_Child_Name]
        )
        VALUES
        (
            @City_ID,
            @City_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteC11_City_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteC11_City_Child]
    @City_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID1] FROM [5_Cities_Child]
            WHERE
                [City_ID1] = @City_ID
        )
        BEGIN
            RAISERROR ('''C11_City_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete C11_City_Child object from 5_Cities_Child */
        DELETE
        FROM [5_Cities_Child]
        WHERE
            [5_Cities_Child].[City_ID1] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetC11_City_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetC11_City_Child]
    @City_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get C11_City_Child from table */
        SELECT
            [5_Cities_Child].[City_Child_Name]
        FROM [5_Cities_Child]
        WHERE
            [5_Cities_Child].[City_ID1] = @City_ID1

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteE11_City_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteE11_City_Child]
    @City_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID1] FROM [5_Cities_Child]
            WHERE
                [City_ID1] = @City_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E11_City_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark E11_City_Child object as not active */
        UPDATE [5_Cities_Child]
        SET    [IsActive] = 'false'
        WHERE
            [5_Cities_Child].[City_ID1] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateE11_City_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateE11_City_Child]
    @City_ID int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID1] FROM [5_Cities_Child]
            WHERE
                [City_ID1] = @City_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E11_City_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 5_Cities_Child */
        UPDATE [5_Cities_Child]
        SET
            [City_Child_Name] = @City_Child_Name
        WHERE
            [City_ID1] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddE11_City_Child]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddE11_City_Child]
    @City_ID int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 5_Cities_Child */
        INSERT INTO [5_Cities_Child]
        (
            [City_ID1],
            [City_Child_Name]
        )
        VALUES
        (
            @City_ID,
            @City_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteF11_City_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteF11_City_Child]
    @City_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID1] FROM [5_Cities_Child]
            WHERE
                [City_ID1] = @City_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F11_City_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark F11_City_Child object as not active */
        UPDATE [5_Cities_Child]
        SET    [IsActive] = 'false'
        WHERE
            [5_Cities_Child].[City_ID1] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateF11_City_Child]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateF11_City_Child]
    @City_ID int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID1] FROM [5_Cities_Child]
            WHERE
                [City_ID1] = @City_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F11_City_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 5_Cities_Child */
        UPDATE [5_Cities_Child]
        SET
            [City_Child_Name] = @City_Child_Name
        WHERE
            [City_ID1] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddF11_City_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddF11_City_Child]
    @City_ID int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 5_Cities_Child */
        INSERT INTO [5_Cities_Child]
        (
            [City_ID1],
            [City_Child_Name]
        )
        VALUES
        (
            @City_ID,
            @City_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[AddA11_City_Child]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddA11_City_Child]
    @City_ID int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 5_Cities_Child */
        INSERT INTO [5_Cities_Child]
        (
            [City_ID1],
            [City_Child_Name]
        )
        VALUES
        (
            @City_ID,
            @City_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[GetH11_City_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetH11_City_Child]
    @City_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get H11_City_Child from table */
        SELECT
            [5_Cities_Child].[City_Child_Name]
        FROM [5_Cities_Child]
        WHERE
            [5_Cities_Child].[City_ID1] = @City_ID1 AND
            [5_Cities_Child].[IsActive] = 'true'

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteA11_City_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteA11_City_Child]
    @City_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID1] FROM [5_Cities_Child]
            WHERE
                [City_ID1] = @City_ID
        )
        BEGIN
            RAISERROR ('''A11_City_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete A11_City_Child object from 5_Cities_Child */
        DELETE
        FROM [5_Cities_Child]
        WHERE
            [5_Cities_Child].[City_ID1] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddH11_City_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddH11_City_Child]
    @City_ID int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 5_Cities_Child */
        INSERT INTO [5_Cities_Child]
        (
            [City_ID1],
            [City_Child_Name]
        )
        VALUES
        (
            @City_ID,
            @City_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateH11_City_Child]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateH11_City_Child]
    @City_ID int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID1] FROM [5_Cities_Child]
            WHERE
                [City_ID1] = @City_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H11_City_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 5_Cities_Child */
        UPDATE [5_Cities_Child]
        SET
            [City_Child_Name] = @City_Child_Name
        WHERE
            [City_ID1] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateA11_City_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateA11_City_Child]
    @City_ID int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID1] FROM [5_Cities_Child]
            WHERE
                [City_ID1] = @City_ID
        )
        BEGIN
            RAISERROR ('''A11_City_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 5_Cities_Child */
        UPDATE [5_Cities_Child]
        SET
            [City_Child_Name] = @City_Child_Name
        WHERE
            [City_ID1] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteH11_City_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteH11_City_Child]
    @City_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID1] FROM [5_Cities_Child]
            WHERE
                [City_ID1] = @City_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H11_City_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark H11_City_Child object as not active */
        UPDATE [5_Cities_Child]
        SET    [IsActive] = 'false'
        WHERE
            [5_Cities_Child].[City_ID1] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteB11_City_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteB11_City_Child]
    @City_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID1] FROM [5_Cities_Child]
            WHERE
                [City_ID1] = @City_ID
        )
        BEGIN
            RAISERROR ('''B11_City_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete B11_City_Child object from 5_Cities_Child */
        DELETE
        FROM [5_Cities_Child]
        WHERE
            [5_Cities_Child].[City_ID1] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateB11_City_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateB11_City_Child]
    @City_ID int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID1] FROM [5_Cities_Child]
            WHERE
                [City_ID1] = @City_ID
        )
        BEGIN
            RAISERROR ('''B11_City_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 5_Cities_Child */
        UPDATE [5_Cities_Child]
        SET
            [City_Child_Name] = @City_Child_Name
        WHERE
            [City_ID1] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddB11_City_Child]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddB11_City_Child]
    @City_ID int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 5_Cities_Child */
        INSERT INTO [5_Cities_Child]
        (
            [City_ID1],
            [City_Child_Name]
        )
        VALUES
        (
            @City_ID,
            @City_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[GetD11_City_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetD11_City_Child]
    @City_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D11_City_Child from table */
        SELECT
            [5_Cities_Child].[City_Child_Name]
        FROM [5_Cities_Child]
        WHERE
            [5_Cities_Child].[City_ID1] = @City_ID1

    END
GO
/****** Object:  StoredProcedure [dbo].[AddD11_City_Child]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddD11_City_Child]
    @City_ID int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 5_Cities_Child */
        INSERT INTO [5_Cities_Child]
        (
            [City_ID1],
            [City_Child_Name]
        )
        VALUES
        (
            @City_ID,
            @City_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateD11_City_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateD11_City_Child]
    @City_ID int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID1] FROM [5_Cities_Child]
            WHERE
                [City_ID1] = @City_ID
        )
        BEGIN
            RAISERROR ('''D11_City_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 5_Cities_Child */
        UPDATE [5_Cities_Child]
        SET
            [City_Child_Name] = @City_Child_Name
        WHERE
            [City_ID1] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteD11_City_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteD11_City_Child]
    @City_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID1] FROM [5_Cities_Child]
            WHERE
                [City_ID1] = @City_ID
        )
        BEGIN
            RAISERROR ('''D11_City_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete D11_City_Child object from 5_Cities_Child */
        DELETE
        FROM [5_Cities_Child]
        WHERE
            [5_Cities_Child].[City_ID1] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetG11_City_Child]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetG11_City_Child]
    @City_ID1 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get G11_City_Child from table */
        SELECT
            [5_Cities_Child].[City_Child_Name]
        FROM [5_Cities_Child]
        WHERE
            [5_Cities_Child].[City_ID1] = @City_ID1 AND
            [5_Cities_Child].[IsActive] = 'true'

    END
GO
/****** Object:  StoredProcedure [dbo].[AddG11_City_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddG11_City_Child]
    @City_ID int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 5_Cities_Child */
        INSERT INTO [5_Cities_Child]
        (
            [City_ID1],
            [City_Child_Name]
        )
        VALUES
        (
            @City_ID,
            @City_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateG11_City_Child]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateG11_City_Child]
    @City_ID int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID1] FROM [5_Cities_Child]
            WHERE
                [City_ID1] = @City_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G11_City_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 5_Cities_Child */
        UPDATE [5_Cities_Child]
        SET
            [City_Child_Name] = @City_Child_Name
        WHERE
            [City_ID1] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteG11_City_Child]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteG11_City_Child]
    @City_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID1] FROM [5_Cities_Child]
            WHERE
                [City_ID1] = @City_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G11_City_Child'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark G11_City_Child object as not active */
        UPDATE [5_Cities_Child]
        SET    [IsActive] = 'false'
        WHERE
            [5_Cities_Child].[City_ID1] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddG11_City_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddG11_City_ReChild]
    @City_ID int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 5_Cities_ReChild */
        INSERT INTO [5_Cities_ReChild]
        (
            [City_ID2],
            [City_Child_Name]
        )
        VALUES
        (
            @City_ID,
            @City_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateG11_City_ReChild]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateG11_City_ReChild]
    @City_ID int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID2] FROM [5_Cities_ReChild]
            WHERE
                [City_ID2] = @City_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G11_City_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 5_Cities_ReChild */
        UPDATE [5_Cities_ReChild]
        SET
            [City_Child_Name] = @City_Child_Name
        WHERE
            [City_ID2] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteG11_City_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteG11_City_ReChild]
    @City_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID2] FROM [5_Cities_ReChild]
            WHERE
                [City_ID2] = @City_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''G11_City_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark G11_City_ReChild object as not active */
        UPDATE [5_Cities_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [5_Cities_ReChild].[City_ID2] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetG11_City_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetG11_City_ReChild]
    @City_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get G11_City_ReChild from table */
        SELECT
            [5_Cities_ReChild].[City_Child_Name]
        FROM [5_Cities_ReChild]
        WHERE
            [5_Cities_ReChild].[City_ID2] = @City_ID2 AND
            [5_Cities_ReChild].[IsActive] = 'true'

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteD11_City_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteD11_City_ReChild]
    @City_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID2] FROM [5_Cities_ReChild]
            WHERE
                [City_ID2] = @City_ID
        )
        BEGIN
            RAISERROR ('''D11_City_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete D11_City_ReChild object from 5_Cities_ReChild */
        DELETE
        FROM [5_Cities_ReChild]
        WHERE
            [5_Cities_ReChild].[City_ID2] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddD11_City_ReChild]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddD11_City_ReChild]
    @City_ID int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 5_Cities_ReChild */
        INSERT INTO [5_Cities_ReChild]
        (
            [City_ID2],
            [City_Child_Name]
        )
        VALUES
        (
            @City_ID,
            @City_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateD11_City_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateD11_City_ReChild]
    @City_ID int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID2] FROM [5_Cities_ReChild]
            WHERE
                [City_ID2] = @City_ID
        )
        BEGIN
            RAISERROR ('''D11_City_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 5_Cities_ReChild */
        UPDATE [5_Cities_ReChild]
        SET
            [City_Child_Name] = @City_Child_Name
        WHERE
            [City_ID2] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteB11_City_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteB11_City_ReChild]
    @City_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID2] FROM [5_Cities_ReChild]
            WHERE
                [City_ID2] = @City_ID
        )
        BEGIN
            RAISERROR ('''B11_City_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete B11_City_ReChild object from 5_Cities_ReChild */
        DELETE
        FROM [5_Cities_ReChild]
        WHERE
            [5_Cities_ReChild].[City_ID2] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateB11_City_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateB11_City_ReChild]
    @City_ID int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID2] FROM [5_Cities_ReChild]
            WHERE
                [City_ID2] = @City_ID
        )
        BEGIN
            RAISERROR ('''B11_City_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 5_Cities_ReChild */
        UPDATE [5_Cities_ReChild]
        SET
            [City_Child_Name] = @City_Child_Name
        WHERE
            [City_ID2] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddB11_City_ReChild]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddB11_City_ReChild]
    @City_ID int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 5_Cities_ReChild */
        INSERT INTO [5_Cities_ReChild]
        (
            [City_ID2],
            [City_Child_Name]
        )
        VALUES
        (
            @City_ID,
            @City_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[GetD11_City_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetD11_City_ReChild]
    @City_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get D11_City_ReChild from table */
        SELECT
            [5_Cities_ReChild].[City_Child_Name]
        FROM [5_Cities_ReChild]
        WHERE
            [5_Cities_ReChild].[City_ID2] = @City_ID2

    END
GO
/****** Object:  StoredProcedure [dbo].[AddH11_City_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddH11_City_ReChild]
    @City_ID int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 5_Cities_ReChild */
        INSERT INTO [5_Cities_ReChild]
        (
            [City_ID2],
            [City_Child_Name]
        )
        VALUES
        (
            @City_ID,
            @City_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteA11_City_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteA11_City_ReChild]
    @City_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID2] FROM [5_Cities_ReChild]
            WHERE
                [City_ID2] = @City_ID
        )
        BEGIN
            RAISERROR ('''A11_City_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete A11_City_ReChild object from 5_Cities_ReChild */
        DELETE
        FROM [5_Cities_ReChild]
        WHERE
            [5_Cities_ReChild].[City_ID2] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddA11_City_ReChild]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddA11_City_ReChild]
    @City_ID int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 5_Cities_ReChild */
        INSERT INTO [5_Cities_ReChild]
        (
            [City_ID2],
            [City_Child_Name]
        )
        VALUES
        (
            @City_ID,
            @City_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteH11_City_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteH11_City_ReChild]
    @City_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID2] FROM [5_Cities_ReChild]
            WHERE
                [City_ID2] = @City_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H11_City_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark H11_City_ReChild object as not active */
        UPDATE [5_Cities_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [5_Cities_ReChild].[City_ID2] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateH11_City_ReChild]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateH11_City_ReChild]
    @City_ID int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID2] FROM [5_Cities_ReChild]
            WHERE
                [City_ID2] = @City_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''H11_City_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 5_Cities_ReChild */
        UPDATE [5_Cities_ReChild]
        SET
            [City_Child_Name] = @City_Child_Name
        WHERE
            [City_ID2] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetH11_City_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetH11_City_ReChild]
    @City_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get H11_City_ReChild from table */
        SELECT
            [5_Cities_ReChild].[City_Child_Name]
        FROM [5_Cities_ReChild]
        WHERE
            [5_Cities_ReChild].[City_ID2] = @City_ID2 AND
            [5_Cities_ReChild].[IsActive] = 'true'

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateA11_City_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateA11_City_ReChild]
    @City_ID int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID2] FROM [5_Cities_ReChild]
            WHERE
                [City_ID2] = @City_ID
        )
        BEGIN
            RAISERROR ('''A11_City_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 5_Cities_ReChild */
        UPDATE [5_Cities_ReChild]
        SET
            [City_Child_Name] = @City_Child_Name
        WHERE
            [City_ID2] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddF11_City_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddF11_City_ReChild]
    @City_ID int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 5_Cities_ReChild */
        INSERT INTO [5_Cities_ReChild]
        (
            [City_ID2],
            [City_Child_Name]
        )
        VALUES
        (
            @City_ID,
            @City_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteF11_City_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteF11_City_ReChild]
    @City_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID2] FROM [5_Cities_ReChild]
            WHERE
                [City_ID2] = @City_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F11_City_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark F11_City_ReChild object as not active */
        UPDATE [5_Cities_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [5_Cities_ReChild].[City_ID2] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateF11_City_ReChild]    Script Date: 01/13/2013 15:48:30 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateF11_City_ReChild]
    @City_ID int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID2] FROM [5_Cities_ReChild]
            WHERE
                [City_ID2] = @City_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''F11_City_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 5_Cities_ReChild */
        UPDATE [5_Cities_ReChild]
        SET
            [City_Child_Name] = @City_Child_Name
        WHERE
            [City_ID2] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteE11_City_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteE11_City_ReChild]
    @City_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID2] FROM [5_Cities_ReChild]
            WHERE
                [City_ID2] = @City_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E11_City_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Mark E11_City_ReChild object as not active */
        UPDATE [5_Cities_ReChild]
        SET    [IsActive] = 'false'
        WHERE
            [5_Cities_ReChild].[City_ID2] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[AddE11_City_ReChild]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddE11_City_ReChild]
    @City_ID int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 5_Cities_ReChild */
        INSERT INTO [5_Cities_ReChild]
        (
            [City_ID2],
            [City_Child_Name]
        )
        VALUES
        (
            @City_ID,
            @City_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateE11_City_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateE11_City_ReChild]
    @City_ID int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID2] FROM [5_Cities_ReChild]
            WHERE
                [City_ID2] = @City_ID AND
                [IsActive] = 'true'
        )
        BEGIN
            RAISERROR ('''E11_City_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 5_Cities_ReChild */
        UPDATE [5_Cities_ReChild]
        SET
            [City_Child_Name] = @City_Child_Name
        WHERE
            [City_ID2] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[DeleteC11_City_ReChild]    Script Date: 01/13/2013 15:48:28 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[DeleteC11_City_ReChild]
    @City_ID int
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID2] FROM [5_Cities_ReChild]
            WHERE
                [City_ID2] = @City_ID
        )
        BEGIN
            RAISERROR ('''C11_City_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Delete C11_City_ReChild object from 5_Cities_ReChild */
        DELETE
        FROM [5_Cities_ReChild]
        WHERE
            [5_Cities_ReChild].[City_ID2] = @City_ID

    END
GO
/****** Object:  StoredProcedure [dbo].[GetC11_City_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[GetC11_City_ReChild]
    @City_ID2 int
AS
    BEGIN

        SET NOCOUNT ON

        /* Get C11_City_ReChild from table */
        SELECT
            [5_Cities_ReChild].[City_Child_Name]
        FROM [5_Cities_ReChild]
        WHERE
            [5_Cities_ReChild].[City_ID2] = @City_ID2

    END
GO
/****** Object:  StoredProcedure [dbo].[AddC11_City_ReChild]    Script Date: 01/13/2013 15:48:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[AddC11_City_ReChild]
    @City_ID int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Insert object into 5_Cities_ReChild */
        INSERT INTO [5_Cities_ReChild]
        (
            [City_ID2],
            [City_Child_Name]
        )
        VALUES
        (
            @City_ID,
            @City_Child_Name
        )

    END
GO
/****** Object:  StoredProcedure [dbo].[UpdateC11_City_ReChild]    Script Date: 01/13/2013 15:48:29 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE PROCEDURE [dbo].[UpdateC11_City_ReChild]
    @City_ID int,
    @City_Child_Name varchar(50)
AS
    BEGIN

        SET NOCOUNT ON

        /* Check for object existence */
        IF NOT EXISTS
        (
            SELECT [City_ID2] FROM [5_Cities_ReChild]
            WHERE
                [City_ID2] = @City_ID
        )
        BEGIN
            RAISERROR ('''C11_City_ReChild'' object not found. It was probably removed by another user.', 16, 1)
            RETURN
        END

        /* Update object in 5_Cities_ReChild */
        UPDATE [5_Cities_ReChild]
        SET
            [City_Child_Name] = @City_Child_Name
        WHERE
            [City_ID2] = @City_ID

    END
GO
/****** Object:  Default [DF_Level_1_IsActive]    Script Date: 01/13/2013 15:48:24 ******/
ALTER TABLE [dbo].[1_Continents] ADD  CONSTRAINT [DF_Level_1_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_Level_1_1_Child_IsActive]    Script Date: 01/13/2013 15:48:24 ******/
ALTER TABLE [dbo].[1_Continents_Child] ADD  CONSTRAINT [DF_Level_1_1_Child_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_Level_1_1_ReChild_IsActive]    Script Date: 01/13/2013 15:48:24 ******/
ALTER TABLE [dbo].[1_Continents_ReChild] ADD  CONSTRAINT [DF_Level_1_1_ReChild_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_Level_1_1_IsActive]    Script Date: 01/13/2013 15:48:24 ******/
ALTER TABLE [dbo].[2_SubContinents] ADD  CONSTRAINT [DF_Level_1_1_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_Level_1_1_1_Child_IsActive]    Script Date: 01/13/2013 15:48:24 ******/
ALTER TABLE [dbo].[2_SubContinents_Child] ADD  CONSTRAINT [DF_Level_1_1_1_Child_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_Level_1_1_1_ReChild_IsActive]    Script Date: 01/13/2013 15:48:24 ******/
ALTER TABLE [dbo].[2_SubContinents_ReChild] ADD  CONSTRAINT [DF_Level_1_1_1_ReChild_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_Level_1_1_1_IsActive]    Script Date: 01/13/2013 15:48:24 ******/
ALTER TABLE [dbo].[3_Countries] ADD  CONSTRAINT [DF_Level_1_1_1_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_Level_1_1_1_1_Child_IsActive]    Script Date: 01/13/2013 15:48:24 ******/
ALTER TABLE [dbo].[3_Countries_Child] ADD  CONSTRAINT [DF_Level_1_1_1_1_Child_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_Level_1_1_1_1_ReChild_IsActive]    Script Date: 01/13/2013 15:48:24 ******/
ALTER TABLE [dbo].[3_Countries_ReChild] ADD  CONSTRAINT [DF_Level_1_1_1_1_ReChild_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_Level_1_1_1_1_IsActive]    Script Date: 01/13/2013 15:48:24 ******/
ALTER TABLE [dbo].[4_Regions] ADD  CONSTRAINT [DF_Level_1_1_1_1_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_Level_1_1_1_1_1_Child_IsActive]    Script Date: 01/13/2013 15:48:24 ******/
ALTER TABLE [dbo].[4_Regions_Child] ADD  CONSTRAINT [DF_Level_1_1_1_1_1_Child_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_Level_1_1_1_1_1_ReChild_IsActive]    Script Date: 01/13/2013 15:48:24 ******/
ALTER TABLE [dbo].[4_Regions_ReChild] ADD  CONSTRAINT [DF_Level_1_1_1_1_1_ReChild_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_Level_1_1_1_1_1_IsActive]    Script Date: 01/13/2013 15:48:24 ******/
ALTER TABLE [dbo].[5_Cities] ADD  CONSTRAINT [DF_Level_1_1_1_1_1_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_Level_1_1_1_1_1_1_Child_IsActive]    Script Date: 01/13/2013 15:48:24 ******/
ALTER TABLE [dbo].[5_Cities_Child] ADD  CONSTRAINT [DF_Level_1_1_1_1_1_1_Child_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_Level_1_1_1_1_1_1_ReChild_IsActive]    Script Date: 01/13/2013 15:48:24 ******/
ALTER TABLE [dbo].[5_Cities_ReChild] ADD  CONSTRAINT [DF_Level_1_1_1_1_1_1_ReChild_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_Level_1_1_1_1_1_1_IsActive]    Script Date: 01/13/2013 15:48:24 ******/
ALTER TABLE [dbo].[6_CityRoads] ADD  CONSTRAINT [DF_Level_1_1_1_1_1_1_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_Level_1_1_1_2_IsActive]    Script Date: 01/13/2013 15:48:24 ******/
ALTER TABLE [dbo].[Dummy_Level_1_1_1_2] ADD  CONSTRAINT [DF_Level_1_1_1_2_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_Level_1_1_2_IsActive]    Script Date: 01/13/2013 15:48:24 ******/
ALTER TABLE [dbo].[Dummy_Level_1_1_2] ADD  CONSTRAINT [DF_Level_1_1_2_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  Default [DF_Level_1_2_IsActive]    Script Date: 01/13/2013 15:48:24 ******/
ALTER TABLE [dbo].[Dummy_Level_1_2] ADD  CONSTRAINT [DF_Level_1_2_IsActive]  DEFAULT ((1)) FOR [IsActive]
GO
/****** Object:  ForeignKey [FK_Continents_Child_Continents]    Script Date: 01/13/2013 15:48:24 ******/
ALTER TABLE [dbo].[1_Continents_Child]  WITH CHECK ADD  CONSTRAINT [FK_Continents_Child_Continents] FOREIGN KEY([Continent_ID1])
REFERENCES [dbo].[1_Continents] ([Continent_ID])
GO
ALTER TABLE [dbo].[1_Continents_Child] CHECK CONSTRAINT [FK_Continents_Child_Continents]
GO
/****** Object:  ForeignKey [FK_FK_Continents_ReChild_Continents]    Script Date: 01/13/2013 15:48:24 ******/
ALTER TABLE [dbo].[1_Continents_ReChild]  WITH CHECK ADD  CONSTRAINT [FK_FK_Continents_ReChild_Continents] FOREIGN KEY([Continent_ID2])
REFERENCES [dbo].[1_Continents] ([Continent_ID])
GO
ALTER TABLE [dbo].[1_Continents_ReChild] CHECK CONSTRAINT [FK_FK_Continents_ReChild_Continents]
GO
/****** Object:  ForeignKey [FK_SubContinents_Continents]    Script Date: 01/13/2013 15:48:24 ******/
ALTER TABLE [dbo].[2_SubContinents]  WITH CHECK ADD  CONSTRAINT [FK_SubContinents_Continents] FOREIGN KEY([Parent_Continent_ID])
REFERENCES [dbo].[1_Continents] ([Continent_ID])
GO
ALTER TABLE [dbo].[2_SubContinents] CHECK CONSTRAINT [FK_SubContinents_Continents]
GO
/****** Object:  ForeignKey [FK_SubContinents_Child_SubContinents]    Script Date: 01/13/2013 15:48:24 ******/
ALTER TABLE [dbo].[2_SubContinents_Child]  WITH CHECK ADD  CONSTRAINT [FK_SubContinents_Child_SubContinents] FOREIGN KEY([SubContinent_ID1])
REFERENCES [dbo].[2_SubContinents] ([SubContinent_ID])
GO
ALTER TABLE [dbo].[2_SubContinents_Child] CHECK CONSTRAINT [FK_SubContinents_Child_SubContinents]
GO
/****** Object:  ForeignKey [FK_SubContinents_ReChild_SubContinents]    Script Date: 01/13/2013 15:48:24 ******/
ALTER TABLE [dbo].[2_SubContinents_ReChild]  WITH CHECK ADD  CONSTRAINT [FK_SubContinents_ReChild_SubContinents] FOREIGN KEY([SubContinent_ID2])
REFERENCES [dbo].[2_SubContinents] ([SubContinent_ID])
GO
ALTER TABLE [dbo].[2_SubContinents_ReChild] CHECK CONSTRAINT [FK_SubContinents_ReChild_SubContinents]
GO
/****** Object:  ForeignKey [FK_Countries_SubContinents]    Script Date: 01/13/2013 15:48:24 ******/
ALTER TABLE [dbo].[3_Countries]  WITH CHECK ADD  CONSTRAINT [FK_Countries_SubContinents] FOREIGN KEY([Parent_SubContinent_ID])
REFERENCES [dbo].[2_SubContinents] ([SubContinent_ID])
GO
ALTER TABLE [dbo].[3_Countries] CHECK CONSTRAINT [FK_Countries_SubContinents]
GO
/****** Object:  ForeignKey [FK_Countries_Child_Countries]    Script Date: 01/13/2013 15:48:24 ******/
ALTER TABLE [dbo].[3_Countries_Child]  WITH CHECK ADD  CONSTRAINT [FK_Countries_Child_Countries] FOREIGN KEY([Country_ID1])
REFERENCES [dbo].[3_Countries] ([Country_ID])
GO
ALTER TABLE [dbo].[3_Countries_Child] CHECK CONSTRAINT [FK_Countries_Child_Countries]
GO
/****** Object:  ForeignKey [FK_Countries_ReChild_Countries]    Script Date: 01/13/2013 15:48:24 ******/
ALTER TABLE [dbo].[3_Countries_ReChild]  WITH CHECK ADD  CONSTRAINT [FK_Countries_ReChild_Countries] FOREIGN KEY([Country_ID2])
REFERENCES [dbo].[3_Countries] ([Country_ID])
GO
ALTER TABLE [dbo].[3_Countries_ReChild] CHECK CONSTRAINT [FK_Countries_ReChild_Countries]
GO
/****** Object:  ForeignKey [FK_Regions_SubContinents]    Script Date: 01/13/2013 15:48:24 ******/
ALTER TABLE [dbo].[4_Regions]  WITH CHECK ADD  CONSTRAINT [FK_Regions_SubContinents] FOREIGN KEY([Parent_Country_ID])
REFERENCES [dbo].[3_Countries] ([Country_ID])
GO
ALTER TABLE [dbo].[4_Regions] CHECK CONSTRAINT [FK_Regions_SubContinents]
GO
/****** Object:  ForeignKey [FK_Regions_Child_Regions]    Script Date: 01/13/2013 15:48:24 ******/
ALTER TABLE [dbo].[4_Regions_Child]  WITH CHECK ADD  CONSTRAINT [FK_Regions_Child_Regions] FOREIGN KEY([Region_ID1])
REFERENCES [dbo].[4_Regions] ([Region_ID])
GO
ALTER TABLE [dbo].[4_Regions_Child] CHECK CONSTRAINT [FK_Regions_Child_Regions]
GO
/****** Object:  ForeignKey [FK_Regions_ReChild_Regions]    Script Date: 01/13/2013 15:48:24 ******/
ALTER TABLE [dbo].[4_Regions_ReChild]  WITH CHECK ADD  CONSTRAINT [FK_Regions_ReChild_Regions] FOREIGN KEY([Region_ID2])
REFERENCES [dbo].[4_Regions] ([Region_ID])
GO
ALTER TABLE [dbo].[4_Regions_ReChild] CHECK CONSTRAINT [FK_Regions_ReChild_Regions]
GO
/****** Object:  ForeignKey [FK_Cities_Regions]    Script Date: 01/13/2013 15:48:24 ******/
ALTER TABLE [dbo].[5_Cities]  WITH CHECK ADD  CONSTRAINT [FK_Cities_Regions] FOREIGN KEY([Parent_Region_ID])
REFERENCES [dbo].[4_Regions] ([Region_ID])
GO
ALTER TABLE [dbo].[5_Cities] CHECK CONSTRAINT [FK_Cities_Regions]
GO
/****** Object:  ForeignKey [FK_Cities_Child_Cities]    Script Date: 01/13/2013 15:48:24 ******/
ALTER TABLE [dbo].[5_Cities_Child]  WITH CHECK ADD  CONSTRAINT [FK_Cities_Child_Cities] FOREIGN KEY([City_ID1])
REFERENCES [dbo].[5_Cities] ([City_ID])
GO
ALTER TABLE [dbo].[5_Cities_Child] CHECK CONSTRAINT [FK_Cities_Child_Cities]
GO
/****** Object:  ForeignKey [FK_Cities_ReChild_Cities]    Script Date: 01/13/2013 15:48:24 ******/
ALTER TABLE [dbo].[5_Cities_ReChild]  WITH CHECK ADD  CONSTRAINT [FK_Cities_ReChild_Cities] FOREIGN KEY([City_ID2])
REFERENCES [dbo].[5_Cities] ([City_ID])
GO
ALTER TABLE [dbo].[5_Cities_ReChild] CHECK CONSTRAINT [FK_Cities_ReChild_Cities]
GO
/****** Object:  ForeignKey [FK_CityRoads_Cities]    Script Date: 01/13/2013 15:48:24 ******/
ALTER TABLE [dbo].[6_CityRoads]  WITH CHECK ADD  CONSTRAINT [FK_CityRoads_Cities] FOREIGN KEY([Parent_City_ID])
REFERENCES [dbo].[5_Cities] ([City_ID])
GO
ALTER TABLE [dbo].[6_CityRoads] CHECK CONSTRAINT [FK_CityRoads_Cities]
GO
/****** Object:  ForeignKey [FK_Level_1_1_1_2_Level_1_1_1]    Script Date: 01/13/2013 15:48:24 ******/
ALTER TABLE [dbo].[Dummy_Level_1_1_1_2]  WITH CHECK ADD  CONSTRAINT [FK_Level_1_1_1_2_Level_1_1_1] FOREIGN KEY([LarentID2])
REFERENCES [dbo].[3_Countries] ([Country_ID])
GO
ALTER TABLE [dbo].[Dummy_Level_1_1_1_2] CHECK CONSTRAINT [FK_Level_1_1_1_2_Level_1_1_1]
GO
/****** Object:  ForeignKey [FK_Level_1_1_2_Level_1_1]    Script Date: 01/13/2013 15:48:24 ******/
ALTER TABLE [dbo].[Dummy_Level_1_1_2]  WITH CHECK ADD  CONSTRAINT [FK_Level_1_1_2_Level_1_1] FOREIGN KEY([MarentID2])
REFERENCES [dbo].[2_SubContinents] ([SubContinent_ID])
GO
ALTER TABLE [dbo].[Dummy_Level_1_1_2] CHECK CONSTRAINT [FK_Level_1_1_2_Level_1_1]
GO
/****** Object:  ForeignKey [FK_Level_1_2_Level_1]    Script Date: 01/13/2013 15:48:24 ******/
ALTER TABLE [dbo].[Dummy_Level_1_2]  WITH CHECK ADD  CONSTRAINT [FK_Level_1_2_Level_1] FOREIGN KEY([ParentID2])
REFERENCES [dbo].[1_Continents] ([Continent_ID])
GO
ALTER TABLE [dbo].[Dummy_Level_1_2] CHECK CONSTRAINT [FK_Level_1_2_Level_1]
GO
