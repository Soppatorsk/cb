USE [master]
GO
/****** Object:  Database [Coolbooks]    Script Date: 2023-04-13 14:21:47 ******/
CREATE DATABASE [Coolbooks]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Coolbooks', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Coolbooks.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Coolbooks_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.SQLEXPRESS\MSSQL\DATA\Coolbooks_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Coolbooks] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Coolbooks].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Coolbooks] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Coolbooks] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Coolbooks] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Coolbooks] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Coolbooks] SET ARITHABORT OFF 
GO
ALTER DATABASE [Coolbooks] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Coolbooks] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Coolbooks] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Coolbooks] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Coolbooks] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Coolbooks] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Coolbooks] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Coolbooks] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Coolbooks] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Coolbooks] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Coolbooks] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Coolbooks] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Coolbooks] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Coolbooks] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Coolbooks] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Coolbooks] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Coolbooks] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Coolbooks] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [Coolbooks] SET  MULTI_USER 
GO
ALTER DATABASE [Coolbooks] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Coolbooks] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Coolbooks] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Coolbooks] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Coolbooks] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Coolbooks] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
ALTER DATABASE [Coolbooks] SET QUERY_STORE = OFF
GO
USE [Coolbooks]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 2023-04-13 14:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Author](
	[AuthorID] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [nvarchar](250) NULL,
	[Lastname] [nvarchar](250) NULL,
	[Created] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[AuthorID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Book]    Script Date: 2023-04-13 14:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[BookID] [int] IDENTITY(1,1) NOT NULL,
	[UserID] [int] NULL,
	[AuthorID] [int] NULL,
	[GenreID] [int] NULL,
	[Title] [nvarchar](250) NULL,
	[Description] [nvarchar](250) NULL,
	[ISBN] [nvarchar](250) NULL,
	[Imagepath] [nvarchar](250) NULL,
	[IsDeleted] [bit] NULL,
	[Created] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 2023-04-13 14:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[GenreID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
	[Description] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[GenreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Review]    Script Date: 2023-04-13 14:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Review](
	[ReviewID] [int] IDENTITY(1,1) NOT NULL,
	[BookID] [int] NULL,
	[UserID] [int] NULL,
	[Title] [nvarchar](250) NULL,
	[Text] [nvarchar](250) NULL,
	[Rating] [nvarchar](250) NULL,
	[Created] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[ReviewID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[SiteUser]    Script Date: 2023-04-13 14:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[SiteUser](
	[UserID] [int] IDENTITY(1,1) NOT NULL,
	[UserinfoID] [int] NULL,
	[Email] [nvarchar](50) NULL,
	[PasswordHash] [nvarchar](250) NULL,
	[SecurityStamp] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Userinfo]    Script Date: 2023-04-13 14:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Userinfo](
	[UserInfoID] [int] IDENTITY(1,1) NOT NULL,
	[Firstname] [nvarchar](50) NULL,
	[Lastname] [nvarchar](50) NULL,
	[Phone] [nvarchar](250) NULL,
	[Address] [nvarchar](250) NULL,
	[Created] [date] NULL,
	[Role] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[UserInfoID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[Author] ON 

INSERT [dbo].[Author] ([AuthorID], [Firstname], [Lastname], [Created]) VALUES (1, N'J.R.R', N'Tolkien', CAST(N'2022-11-30' AS Date))
INSERT [dbo].[Author] ([AuthorID], [Firstname], [Lastname], [Created]) VALUES (2, N'William', N'Gibson', CAST(N'2022-11-15' AS Date))
INSERT [dbo].[Author] ([AuthorID], [Firstname], [Lastname], [Created]) VALUES (3, N'Torey', N'Hayden', CAST(N'2022-10-12' AS Date))
INSERT [dbo].[Author] ([AuthorID], [Firstname], [Lastname], [Created]) VALUES (4, N'Zadie', N'Smith', CAST(N'2022-09-02' AS Date))
INSERT [dbo].[Author] ([AuthorID], [Firstname], [Lastname], [Created]) VALUES (5, N'A.A', N'Milne', CAST(N'2022-02-01' AS Date))
INSERT [dbo].[Author] ([AuthorID], [Firstname], [Lastname], [Created]) VALUES (6, N'John', N'Milton', CAST(N'2022-02-14' AS Date))
INSERT [dbo].[Author] ([AuthorID], [Firstname], [Lastname], [Created]) VALUES (7, N'H.P.', N'Lovecraft', CAST(N'2022-04-12' AS Date))
INSERT [dbo].[Author] ([AuthorID], [Firstname], [Lastname], [Created]) VALUES (8, N'Agatha', N'Christie', CAST(N'2022-04-11' AS Date))
INSERT [dbo].[Author] ([AuthorID], [Firstname], [Lastname], [Created]) VALUES (9, N'Robert Louis', N'Stevenson', CAST(N'2022-01-14' AS Date))
SET IDENTITY_INSERT [dbo].[Author] OFF
GO
SET IDENTITY_INSERT [dbo].[Book] ON 

INSERT [dbo].[Book] ([BookID], [UserID], [AuthorID], [GenreID], [Title], [Description], [ISBN], [Imagepath], [IsDeleted], [Created]) VALUES (1, 1, 1, 2, N'The Fellowship of the Ring', N'First of the Lord of the Rings trilogy', N'789456', N'/Images/lotr.jpg', 0, CAST(N'2022-01-01' AS Date))
INSERT [dbo].[Book] ([BookID], [UserID], [AuthorID], [GenreID], [Title], [Description], [ISBN], [Imagepath], [IsDeleted], [Created]) VALUES (2, 1, 2, 1, N'Neuromancer', N'Birth of Cyberpunk', N'456123', N'/Images/neuromancer.jpg', 0, CAST(N'2022-01-01' AS Date))
INSERT [dbo].[Book] ([BookID], [UserID], [AuthorID], [GenreID], [Title], [Description], [ISBN], [Imagepath], [IsDeleted], [Created]) VALUES (3, 1, 3, 6, N'One Child', N'child psychopathology, child abuse', N'456123', N'/Images/onechild.jpg', 0, CAST(N'2022-04-02' AS Date))
INSERT [dbo].[Book] ([BookID], [UserID], [AuthorID], [GenreID], [Title], [Description], [ISBN], [Imagepath], [IsDeleted], [Created]) VALUES (4, 1, 4, 5, N'Grand Union: Stories', N'10 short stories', N'45612311', N'/Images/grandunion.jpg', 0, CAST(N'2022-09-11' AS Date))
INSERT [dbo].[Book] ([BookID], [UserID], [AuthorID], [GenreID], [Title], [Description], [ISBN], [Imagepath], [IsDeleted], [Created]) VALUES (5, 1, 5, 3, N'Winnie-The-Pooh', N'Our beloved Pooh Bear', N'4561231145', N'/Images/winniethepooh.jpg', 0, CAST(N'2022-10-03' AS Date))
INSERT [dbo].[Book] ([BookID], [UserID], [AuthorID], [GenreID], [Title], [Description], [ISBN], [Imagepath], [IsDeleted], [Created]) VALUES (6, 1, 6, 4, N'Paradise Lost', N'Where the angles fear to tread', N'456123666', N'/Images/paradiselost.jpg', 0, CAST(N'2022-10-03' AS Date))
INSERT [dbo].[Book] ([BookID], [UserID], [AuthorID], [GenreID], [Title], [Description], [ISBN], [Imagepath], [IsDeleted], [Created]) VALUES (9, 1, 7, 7, N'The Call of Cthulhu', N'Weird tales from the unknown', N'444555666', N'/Images/callofcthulhu.jpg', 0, CAST(N'2022-04-12' AS Date))
INSERT [dbo].[Book] ([BookID], [UserID], [AuthorID], [GenreID], [Title], [Description], [ISBN], [Imagepath], [IsDeleted], [Created]) VALUES (10, 1, 8, 8, N'4.50 from Paddington', N'Miss Marple is back', N'111333', N'/Images/450frompaddington.jpg', 0, CAST(N'2022-04-11' AS Date))
INSERT [dbo].[Book] ([BookID], [UserID], [AuthorID], [GenreID], [Title], [Description], [ISBN], [Imagepath], [IsDeleted], [Created]) VALUES (11, 1, 9, 3, N'Treasure Island', N'Yar!', N'78941523', N'/Images/treasureisland.jpg', 0, CAST(N'2021-04-12' AS Date))
SET IDENTITY_INSERT [dbo].[Book] OFF
GO
SET IDENTITY_INSERT [dbo].[Genre] ON 

INSERT [dbo].[Genre] ([GenreID], [Name], [Description]) VALUES (1, N'Science Fiction', NULL)
INSERT [dbo].[Genre] ([GenreID], [Name], [Description]) VALUES (2, N'Fantasy', NULL)
INSERT [dbo].[Genre] ([GenreID], [Name], [Description]) VALUES (3, N'Children''s Books', NULL)
INSERT [dbo].[Genre] ([GenreID], [Name], [Description]) VALUES (4, N'Poetry', NULL)
INSERT [dbo].[Genre] ([GenreID], [Name], [Description]) VALUES (5, N'Short Stories', NULL)
INSERT [dbo].[Genre] ([GenreID], [Name], [Description]) VALUES (6, N'Non-Fiction', NULL)
INSERT [dbo].[Genre] ([GenreID], [Name], [Description]) VALUES (7, N'Horror', NULL)
INSERT [dbo].[Genre] ([GenreID], [Name], [Description]) VALUES (8, N'Murder Mystery', NULL)
SET IDENTITY_INSERT [dbo].[Genre] OFF
GO
SET IDENTITY_INSERT [dbo].[Review] ON 

INSERT [dbo].[Review] ([ReviewID], [BookID], [UserID], [Title], [Text], [Rating], [Created]) VALUES (1, 5, 3, N'Touching story', N'A beautiful story about friendship. It warmed my heart.', N'5', CAST(N'2022-04-13T16:54:00.000' AS DateTime))
INSERT [dbo].[Review] ([ReviewID], [BookID], [UserID], [Title], [Text], [Rating], [Created]) VALUES (2, 2, 4, N'What???', N'Utterfly confusing. Didnt like it at all', N'1', CAST(N'2022-11-19T19:15:00.000' AS DateTime))
INSERT [dbo].[Review] ([ReviewID], [BookID], [UserID], [Title], [Text], [Rating], [Created]) VALUES (3, 1, 2, N'Team Sauron', N'All time classic. Wish the elfs lost the war though.', N'4', CAST(N'2022-06-06T23:08:00.000' AS DateTime))
SET IDENTITY_INSERT [dbo].[Review] OFF
GO
SET IDENTITY_INSERT [dbo].[SiteUser] ON 

INSERT [dbo].[SiteUser] ([UserID], [UserinfoID], [Email], [PasswordHash], [SecurityStamp]) VALUES (1, 1, N'admin@coolbooks.com', N'abc123', NULL)
INSERT [dbo].[SiteUser] ([UserID], [UserinfoID], [Email], [PasswordHash], [SecurityStamp]) VALUES (2, 2, N'sskog@hotmail.ze', N'knut11', NULL)
INSERT [dbo].[SiteUser] ([UserID], [UserinfoID], [Email], [PasswordHash], [SecurityStamp]) VALUES (3, 3, N'gurkmonstret@hotmail.se', N'gurkmonstret', NULL)
INSERT [dbo].[SiteUser] ([UserID], [UserinfoID], [Email], [PasswordHash], [SecurityStamp]) VALUES (4, 4, N'greenmachine@yahoo.kom', N'avocado2016', NULL)
SET IDENTITY_INSERT [dbo].[SiteUser] OFF
GO
SET IDENTITY_INSERT [dbo].[Userinfo] ON 

INSERT [dbo].[Userinfo] ([UserInfoID], [Firstname], [Lastname], [Phone], [Address], [Created], [Role]) VALUES (1, N'Admin', N'Admin', N'111', N'111', CAST(N'2021-11-08' AS Date), N'Admin')
INSERT [dbo].[Userinfo] ([UserInfoID], [Firstname], [Lastname], [Phone], [Address], [Created], [Role]) VALUES (2, N'Samuel', N'Skog', N'010-124546', N'Dragongränd 11', CAST(N'2022-01-15' AS Date), N'User')
INSERT [dbo].[Userinfo] ([UserInfoID], [Firstname], [Lastname], [Phone], [Address], [Created], [Role]) VALUES (3, N'Kim', N'Gustafsson', N'0763192771', N'Råbyvägen 57H', CAST(N'2023-04-12' AS Date), N'User')
INSERT [dbo].[Userinfo] ([UserInfoID], [Firstname], [Lastname], [Phone], [Address], [Created], [Role]) VALUES (4, N'Petra', N'Henriksson', N'0521-212223', N'Hundvägen 64', CAST(N'2022-11-05' AS Date), N'User')
SET IDENTITY_INSERT [dbo].[Userinfo] OFF
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Author] ([AuthorID])
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD FOREIGN KEY([GenreID])
REFERENCES [dbo].[Genre] ([GenreID])
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[SiteUser] ([UserID])
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD FOREIGN KEY([BookID])
REFERENCES [dbo].[Book] ([BookID])
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD FOREIGN KEY([UserID])
REFERENCES [dbo].[SiteUser] ([UserID])
GO
ALTER TABLE [dbo].[SiteUser]  WITH CHECK ADD FOREIGN KEY([UserinfoID])
REFERENCES [dbo].[Userinfo] ([UserInfoID])
GO
/****** Object:  StoredProcedure [dbo].[spAddAuthor]    Script Date: 2023-04-13 14:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
Create PROCEDURE [dbo].[spAddAuthor]
AS

Insert into Author (Firstname, Lastname, Created)
values ('J.R.R', 'Tolkien', '2022-11-30');

Insert into Author (Firstname, Lastname, Created)
values ('William', 'Gibson', '2022-11-15');

Insert into Author (Firstname, Lastname, Created)
values ('Torey', 'Hayden', '2022-10-12');

Insert into Author (Firstname, Lastname, Created)
values ('Zadie', 'Smith', '2022-09-02');

Insert into Author (Firstname, Lastname, Created)
values ('A.A', 'Milne', '2022-02-01');

Insert into Author (Firstname, Lastname, Created)
values ('John', 'Milton', '2022-02-14');
GO
/****** Object:  StoredProcedure [dbo].[spAddBook]    Script Date: 2023-04-13 14:21:47 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO




Create PROCEDURE [dbo].[spAddBook]
AS

Insert into Book (Title, Description, ISBN, IsDeleted, Created)
values ('The Fellowship of the Ring', 'First of the Lord of the Rings trilogy', '789456', 0, '2022-01-01')

Insert into Book (Title, Description, ISBN, IsDeleted, Created)
values ('Neuromancer', 'Birth of Cyberpunk', '456123', 0, '2022-01-01')

Insert into Book (Title, Description, ISBN, IsDeleted, Created)
values ('One Child', 'child psychopathology, child abuse', '456123', 0,'2022-04-02')

Insert into Book (Title, Description, ISBN, IsDeleted, Created)
values ('Grand Union: Stories', '10 short stories', '45612311', 0, '2022-09-11')

Insert into Book (Title, Description, ISBN, IsDeleted, Created)
values ('Winnie-The-Pooh', 'Our beloved Pooh Bear', '4561231145', 0, '2022-10-03')

Insert into Book (Title, Description, ISBN, IsDeleted, Created)
values ('Paradise Lost', 'Where the angles fear to tread', '456123666', 0, '2022-10-03')

GO
/****** Object:  StoredProcedure [dbo].[spAddGenre]    Script Date: 2023-04-13 14:21:48 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO



Create PROCEDURE [dbo].[spAddGenre]
AS
Insert into Genre (Name)
values ('Science Fiction')

Insert into Genre (Name)
values ('Fantasy')

Insert into Genre (Name)
values ('Children''s Books')

Insert into Genre (Name)
values ('Poetry')

Insert into Genre (Name)
values ('Short Stories')

Insert into Genre (Name)
values ('Non-Fiction')

GO
USE [master]
GO
ALTER DATABASE [Coolbooks] SET  READ_WRITE 
GO
