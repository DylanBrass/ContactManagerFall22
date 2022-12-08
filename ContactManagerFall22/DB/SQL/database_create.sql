USE [FinalProjectDB]
GO
/****** Object:  User [ProjectUser]    Script Date: 2022-12-08 10:11:11 AM ******/
CREATE USER [ProjectUser] FOR LOGIN [ProjectUser] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_datareader] ADD MEMBER [ProjectUser]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [ProjectUser]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 2022-12-08 10:11:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Address](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Contact_Id] [int] NOT NULL,
	[City] [varchar](50) NOT NULL,
	[Country] [varchar](50) NOT NULL,
	[AreaCode] [varchar](50) NOT NULL,
	[Street] [varchar](50) NOT NULL,
	[AddressNumber] [int] NOT NULL,
	[ApartementNum] [int] NULL,
	[DateCreated] [date] NOT NULL,
	[LastUpdated] [date] NOT NULL,
	[Active] [bit] NOT NULL,
	[Type_Code] [char](1) NOT NULL,
 CONSTRAINT [PK_Address] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Contact]    Script Date: 2022-12-08 10:11:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Img_Id] [int] NULL,
	[FirstName] [varchar](30) NOT NULL,
	[LastName] [varchar](30) NOT NULL,
	[DateAdded] [date] NOT NULL,
	[LastUpdated] [date] NOT NULL,
	[Email] [varchar](100) NULL,
	[Favourite] [bit] NOT NULL,
	[Active] [bit] NOT NULL,
	[Salutation] [varchar](50) NULL,
	[Nickname] [varchar](50) NULL,
	[Birthday] [date] NULL,
	[Note] [varchar](280) NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Email]    Script Date: 2022-12-08 10:11:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Email](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Contact_Id] [int] NOT NULL,
	[Email] [varchar](100) NOT NULL,
	[Type_Code] [char](1) NOT NULL,
	[DateCreated] [date] NOT NULL,
	[LastUpdated] [date] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Email] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Image]    Script Date: 2022-12-08 10:11:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Image] [varbinary](max) NOT NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phone]    Script Date: 2022-12-08 10:11:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phone](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Phone_Number] [varchar](50) NOT NULL,
	[Contact_Id] [int] NOT NULL,
	[Type_Code] [char](1) NOT NULL,
	[DateCreated] [date] NOT NULL,
	[LastUpdated] [date] NOT NULL,
	[Active] [bit] NOT NULL,
 CONSTRAINT [PK_Phone] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Type]    Script Date: 2022-12-08 10:11:11 AM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Type](
	[Code] [char](1) NOT NULL,
	[Description] [varchar](50) NOT NULL,
 CONSTRAINT [PK_Type] PRIMARY KEY CLUSTERED 
(
	[Code] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Address] ON 
GO
INSERT [dbo].[Address] ([Id], [Contact_Id], [City], [Country], [AreaCode], [Street], [AddressNumber], [ApartementNum], [DateCreated], [LastUpdated], [Active], [Type_Code]) VALUES (4, 8, N'La Prairie', N'Canada', N'JJJ 7J8', N'Rose', 45, NULL, CAST(N'2022-10-10' AS Date), CAST(N'2022-10-10' AS Date), 1, N'H')
GO
SET IDENTITY_INSERT [dbo].[Address] OFF
GO
SET IDENTITY_INSERT [dbo].[Contact] ON 
GO
INSERT [dbo].[Contact] ([Id], [Img_Id], [FirstName], [LastName], [DateAdded], [LastUpdated], [Email], [Favourite], [Active], [Salutation], [Nickname], [Birthday], [Note]) VALUES (8, NULL, N'Dylan', N'Brassard', CAST(N'2022-10-10' AS Date), CAST(N'2022-10-10' AS Date), N'dylan.brassard@outlook.com', 1, 1, N'M', N'DB', CAST(N'2004-05-06' AS Date), N'He sucks')
GO
INSERT [dbo].[Contact] ([Id], [Img_Id], [FirstName], [LastName], [DateAdded], [LastUpdated], [Email], [Favourite], [Active], [Salutation], [Nickname], [Birthday], [Note]) VALUES (12, NULL, N'Karina', N'Evangelista', CAST(N'2022-10-10' AS Date), CAST(N'2022-10-10' AS Date), N'karina@hotmail.com', 1, 1, N'Miss', N'KE', CAST(N'2004-01-01' AS Date), N'She is good at making stuff pretty but not herself')
GO
SET IDENTITY_INSERT [dbo].[Contact] OFF
GO
INSERT [dbo].[Type] ([Code], [Description]) VALUES (N'B', N'Business')
GO
INSERT [dbo].[Type] ([Code], [Description]) VALUES (N'H', N'Home')
GO
INSERT [dbo].[Type] ([Code], [Description]) VALUES (N'O', N'Other')
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Contact] FOREIGN KEY([Contact_Id])
REFERENCES [dbo].[Contact] ([Id])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Contact]
GO
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Type] FOREIGN KEY([Type_Code])
REFERENCES [dbo].[Type] ([Code])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Type]
GO
ALTER TABLE [dbo].[Email]  WITH CHECK ADD  CONSTRAINT [FK_Email_Contact] FOREIGN KEY([Contact_Id])
REFERENCES [dbo].[Contact] ([Id])
GO
ALTER TABLE [dbo].[Email] CHECK CONSTRAINT [FK_Email_Contact]
GO
ALTER TABLE [dbo].[Email]  WITH CHECK ADD  CONSTRAINT [FK_Email_Type] FOREIGN KEY([Type_Code])
REFERENCES [dbo].[Type] ([Code])
GO
ALTER TABLE [dbo].[Email] CHECK CONSTRAINT [FK_Email_Type]
GO
ALTER TABLE [dbo].[Phone]  WITH CHECK ADD  CONSTRAINT [FK_Phone_Contact] FOREIGN KEY([Contact_Id])
REFERENCES [dbo].[Contact] ([Id])
GO
ALTER TABLE [dbo].[Phone] CHECK CONSTRAINT [FK_Phone_Contact]
GO
ALTER TABLE [dbo].[Phone]  WITH CHECK ADD  CONSTRAINT [FK_Phone_Type] FOREIGN KEY([Type_Code])
REFERENCES [dbo].[Type] ([Code])
GO
ALTER TABLE [dbo].[Phone] CHECK CONSTRAINT [FK_Phone_Type]
GO
