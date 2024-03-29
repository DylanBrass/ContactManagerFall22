﻿USE [FinalProjectDB]
GO
/****** Object:  User [ProjectUser]    Script Date: 2022-12-20 8:46:03 PM ******/
CREATE USER [ProjectUser] FOR LOGIN [ProjectUser] WITH DEFAULT_SCHEMA=[dbo]
GO
ALTER ROLE [db_datareader] ADD MEMBER [ProjectUser]
GO
ALTER ROLE [db_datawriter] ADD MEMBER [ProjectUser]
GO
/****** Object:  Table [dbo].[Address]    Script Date: 2022-12-20 8:46:03 PM ******/
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
/****** Object:  Table [dbo].[Contact]    Script Date: 2022-12-20 8:46:03 PM ******/
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
	[Birthday] [date] NOT NULL,
	[Note] [varchar](280) NULL,
 CONSTRAINT [PK_Contact] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Email]    Script Date: 2022-12-20 8:46:03 PM ******/
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
/****** Object:  Table [dbo].[Image]    Script Date: 2022-12-20 8:46:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Image](
	[Id] [int] NOT NULL,
	[Image] [varbinary](max) NOT NULL,
	[Hidden_Id] [int] IDENTITY(1,1) NOT NULL,
 CONSTRAINT [PK_Image] PRIMARY KEY CLUSTERED 
(
	[Hidden_Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Phone]    Script Date: 2022-12-20 8:46:03 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Phone](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Phone_Number] [varchar](50) NULL,
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
/****** Object:  Table [dbo].[Type]    Script Date: 2022-12-20 8:46:03 PM ******/
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
ALTER TABLE [dbo].[Address] ADD  CONSTRAINT [DF_Address_DateCreated]  DEFAULT (getdate()) FOR [DateCreated]
GO
ALTER TABLE [dbo].[Address] ADD  CONSTRAINT [DF_Address_LastUpdated]  DEFAULT (getdate()) FOR [LastUpdated]
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
ALTER TABLE [dbo].[Address]  WITH CHECK ADD  CONSTRAINT [FK_Address_Type] FOREIGN KEY([Type_Code])
REFERENCES [dbo].[Type] ([Code])
GO
ALTER TABLE [dbo].[Address] CHECK CONSTRAINT [FK_Address_Type]
GO
ALTER TABLE [dbo].[Email]  WITH CHECK ADD  CONSTRAINT [FK_Email_Type] FOREIGN KEY([Type_Code])
REFERENCES [dbo].[Type] ([Code])
GO
ALTER TABLE [dbo].[Email] CHECK CONSTRAINT [FK_Email_Type]
GO
ALTER TABLE [dbo].[Image]  WITH NOCHECK ADD  CONSTRAINT [FK_Image_Contact] FOREIGN KEY([Id])
REFERENCES [dbo].[Contact] ([Id])
GO
ALTER TABLE [dbo].[Image] CHECK CONSTRAINT [FK_Image_Contact]
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
