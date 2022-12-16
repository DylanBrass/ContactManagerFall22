USE [FinalProjectDB]
GO
/****** Object:  User [ProjectUser]    Script Date: 2022-12-15 9:57:41 PM ******/
CREATE USER [ProjectUser] FOR LOGIN [ProjectUser] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_datareader] ADD MEMBER [ProjectUser]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [ProjectUser]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 2022-12-15 9:57:41 PM ******/
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
/****** Object:  Table [dbo].[Contact]    Script Date: 2022-12-15 9:57:41 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Contact](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [varchar](30) NOT NULL,
	[LastName] [varchar](30) NOT NULL,
	[DateAdded] [date] NOT NULL,
	[LastUpdated] [date] NOT NULL,
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
/****** Object:  Table [dbo].[Email]    Script Date: 2022-12-15 9:57:41 PM ******/
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
/****** Object:  Table [dbo].[Image]    Script Date: 2022-12-15 9:57:41 PM ******/
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
/****** Object:  Table [dbo].[Phone]    Script Date: 2022-12-15 9:57:41 PM ******/
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
/****** Object:  Table [dbo].[Type]    Script Date: 2022-12-15 9:57:41 PM ******/
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
INSERT [dbo].[Address] ([Id], [Contact_Id], [City], [Country], [AreaCode], [Street], [AddressNumber], [ApartementNum], [DateCreated], [LastUpdated], [Active], [Type_Code]) VALUES (4, 8, N'La Prairie', N'Canada', N'JJJ 7J8', N'Rose', 45, NULL, CAST(N'2022-10-10' AS Date), CAST(N'2022-10-10' AS Date), 0, N'H')
GO
SET IDENTITY_INSERT [dbo].[Address] OFF
GO
SET IDENTITY_INSERT [dbo].[Contact] ON 
GO
INSERT [dbo].[Contact] ([Id], [FirstName], [LastName], [DateAdded], [LastUpdated], [Favourite], [Active], [Salutation], [Nickname], [Birthday], [Note]) VALUES (8, N'Dylan', N'Brassard', CAST(N'2022-10-10' AS Date), CAST(N'2022-12-15' AS Date), 1, 1, N'M', N'DB', CAST(N'2004-06-05' AS Date), N'He sucks')
GO
INSERT [dbo].[Contact] ([Id], [FirstName], [LastName], [DateAdded], [LastUpdated], [Favourite], [Active], [Salutation], [Nickname], [Birthday], [Note]) VALUES (12, N'Karina', N'Evangelista', CAST(N'2022-10-10' AS Date), CAST(N'2022-12-14' AS Date), 1, 1, N'Miss', N'KE', CAST(N'2004-01-01' AS Date), N'She is good at making stuff pretty but not herself')
GO
INSERT [dbo].[Contact] ([Id], [FirstName], [LastName], [DateAdded], [LastUpdated], [Favourite], [Active], [Salutation], [Nickname], [Birthday], [Note]) VALUES (14, N'Henna', N'Chung', CAST(N'2022-12-08' AS Date), CAST(N'2022-12-15' AS Date), 1, 0, N'Miss', N'HC', CAST(N'2004-08-22' AS Date), N'She is a happy duck')
GO
INSERT [dbo].[Contact] ([Id], [FirstName], [LastName], [DateAdded], [LastUpdated], [Favourite], [Active], [Salutation], [Nickname], [Birthday], [Note]) VALUES (25, N'Denisa', N'Hategan', CAST(N'2022-12-15' AS Date), CAST(N'2022-12-15' AS Date), 1, 0, N'Miss', N'DH', CAST(N'2003-12-08' AS Date), N'I am shrek')
GO
INSERT [dbo].[Contact] ([Id], [FirstName], [LastName], [DateAdded], [LastUpdated], [Favourite], [Active], [Salutation], [Nickname], [Birthday], [Note]) VALUES (26, N'Benoit', N'Brassard', CAST(N'2022-12-15' AS Date), CAST(N'2022-12-15' AS Date), 0, 0, N'Sir', N'BB', CAST(N'1965-12-14' AS Date), N'Papa')
GO
INSERT [dbo].[Contact] ([Id], [FirstName], [LastName], [DateAdded], [LastUpdated], [Favourite], [Active], [Salutation], [Nickname], [Birthday], [Note]) VALUES (27, N'Nancy', N'Renauld', CAST(N'2022-12-15' AS Date), CAST(N'2022-12-15' AS Date), 1, 1, N'Miss', N'NR', CAST(N'1963-04-19' AS Date), N'Mother')
GO
INSERT [dbo].[Contact] ([Id], [FirstName], [LastName], [DateAdded], [LastUpdated], [Favourite], [Active], [Salutation], [Nickname], [Birthday], [Note]) VALUES (28, N'Radu', N'Hategan', CAST(N'2022-12-15' AS Date), CAST(N'2022-12-15' AS Date), 0, 1, N'Scary', N'RH', CAST(N'1900-05-08' AS Date), N'Father of Shrek')
GO
SET IDENTITY_INSERT [dbo].[Contact] OFF
GO
SET IDENTITY_INSERT [dbo].[Email] ON 
GO
INSERT [dbo].[Email] ([Id], [Contact_Id], [Email], [Type_Code], [DateCreated], [LastUpdated], [Active]) VALUES (1, 8, N'dylan.brassard@outlook.com', N'H', CAST(N'2022-12-13' AS Date), CAST(N'2022-12-13' AS Date), 0)
GO
INSERT [dbo].[Email] ([Id], [Contact_Id], [Email], [Type_Code], [DateCreated], [LastUpdated], [Active]) VALUES (3, 12, N'karina@outlook.com', N'H', CAST(N'2022-12-15' AS Date), CAST(N'2022-12-15' AS Date), 1)
GO
SET IDENTITY_INSERT [dbo].[Email] OFF
GO
SET IDENTITY_INSERT [dbo].[Phone] ON 
GO
INSERT [dbo].[Phone] ([Id], [Phone_Number], [Contact_Id], [Type_Code], [DateCreated], [LastUpdated], [Active]) VALUES (4, N'450-659-7338', 8, N'H', CAST(N'2022-12-13' AS Date), CAST(N'2022-12-13' AS Date), 0)
GO
INSERT [dbo].[Phone] ([Id], [Phone_Number], [Contact_Id], [Type_Code], [DateCreated], [LastUpdated], [Active]) VALUES (7, N'450-998-4547', 12, N'B', CAST(N'2022-12-14' AS Date), CAST(N'2022-12-14' AS Date), 1)
GO
SET IDENTITY_INSERT [dbo].[Phone] OFF
GO
INSERT [dbo].[Type] ([Code], [Description]) VALUES (N'B', N'Business')
GO
INSERT [dbo].[Type] ([Code], [Description]) VALUES (N'H', N'Home')
GO
INSERT [dbo].[Type] ([Code], [Description]) VALUES (N'O', N'Other')
GO
ALTER TABLE [dbo].[Address] ADD  CONSTRAINT [DF_Address_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Contact] ADD  CONSTRAINT [DF_Contact_DateAdded]  DEFAULT (getdate()) FOR [DateAdded]
GO
ALTER TABLE [dbo].[Contact] ADD  CONSTRAINT [DF_Contact_LastUpdated]  DEFAULT (getdate()) FOR [LastUpdated]
GO
ALTER TABLE [dbo].[Contact] ADD  CONSTRAINT [DF_Contact_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Email] ADD  CONSTRAINT [DF_Email_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Email] ADD  CONSTRAINT [DF_Email_LastUpdated]  DEFAULT (getdate()) FOR [LastUpdated]
GO
ALTER TABLE [dbo].[Email] ADD  CONSTRAINT [DF_Email_Active]  DEFAULT ((1)) FOR [Active]
GO
ALTER TABLE [dbo].[Phone] ADD  CONSTRAINT [DF_Phone_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Phone] ADD  CONSTRAINT [DF_Phone_LastUpdated]  DEFAULT (getdate()) FOR [LastUpdated]
GO
ALTER TABLE [dbo].[Phone] ADD  CONSTRAINT [DF_Phone_Active]  DEFAULT ((1)) FOR [Active]
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
