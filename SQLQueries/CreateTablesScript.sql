USE [IMDB]
GO
/****** Object:  Table [dbo].[IMDbEpisodes]    Script Date: 21/1/2023 6:54:32 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IMDbEpisodes](
	[EpId] [nvarchar](12) NOT NULL,
	[SeasonNumber] [smallint] NULL,
	[EpisodeNumber] [int] NOT NULL,
	[Title] [nvarchar](200) NULL,
	[Image] [nvarchar](max) NULL,
	[Year] [int] NULL,
	[Released] [char](15) NULL,
	[Plot] [nvarchar](max) NULL,
	[IMDbRating] [numeric](16, 2) NULL,
	[IMDbRatingCount] [int] NULL,
	[IMDbId] [nvarchar](12) NOT NULL,
	[LastUpdate] [date] NULL,
 CONSTRAINT [PK_IMDbEpisodes_1] PRIMARY KEY CLUSTERED 
(
	[EpId] ASC,
	[EpisodeNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IMDbSeries]    Script Date: 21/1/2023 6:54:32 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IMDbSeries](
	[Id] [nvarchar](12) NOT NULL,
	[Title] [nvarchar](255) NULL,
	[Description] [nvarchar](255) NULL,
	[Genres] [nvarchar](255) NULL,
	[RuntimeStr] [nvarchar](255) NULL,
	[IMDbRating] [decimal](16, 2) NOT NULL,
	[IMDbRatingVotes] [int] NOT NULL,
	[Status] [int] NULL,
 CONSTRAINT [PK_IMDbSeries] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[IMDbSeriesInfo]    Script Date: 21/1/2023 6:54:32 μμ ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[IMDbSeriesInfo](
	[Id] [nvarchar](12) NOT NULL,
	[Seasons] [int] NULL,
	[ReleaseDate] [date] NULL,
	[Awards] [nvarchar](150) NULL,
	[Plot] [nvarchar](max) NULL,
	[PlotLocal] [nvarchar](max) NULL,
	[SeasonFetched] [int] NULL,
	[Lastupdate] [smalldatetime] NULL,
 CONSTRAINT [PK_IMDbSeriesInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
ALTER TABLE [dbo].[IMDbEpisodes]  WITH CHECK ADD  CONSTRAINT [FK_IMDbEpisodes_IMDbSeries] FOREIGN KEY([IMDbId])
REFERENCES [dbo].[IMDbSeries] ([Id])
GO
ALTER TABLE [dbo].[IMDbEpisodes] CHECK CONSTRAINT [FK_IMDbEpisodes_IMDbSeries]
GO
ALTER TABLE [dbo].[IMDbSeriesInfo]  WITH CHECK ADD  CONSTRAINT [FK_IMDbSeriesInfo_IMDbSeries] FOREIGN KEY([Id])
REFERENCES [dbo].[IMDbSeries] ([Id])
GO
ALTER TABLE [dbo].[IMDbSeriesInfo] CHECK CONSTRAINT [FK_IMDbSeriesInfo_IMDbSeries]
GO
