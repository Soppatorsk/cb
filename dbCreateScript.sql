USE [master]
GO
/****** Object:  Database [Coolbooks]    Script Date: 05/05/2023 16:42:27 ******/
CREATE DATABASE [Coolbooks]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Coolbooks', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Coolbooks.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Coolbooks_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.SQLEXPRESS\MSSQL\DATA\Coolbooks_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [Coolbooks] SET COMPATIBILITY_LEVEL = 160
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
ALTER DATABASE [Coolbooks] SET QUERY_STORE = ON
GO
ALTER DATABASE [Coolbooks] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [Coolbooks]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 05/05/2023 16:42:27 ******/
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
/****** Object:  Table [dbo].[AspNetRoleClaims]    Script Date: 05/05/2023 16:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoleClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoleClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetRoles]    Script Date: 05/05/2023 16:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetRoles](
	[Id] [nvarchar](450) NOT NULL,
	[Name] [nvarchar](256) NULL,
	[NormalizedName] [nvarchar](256) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetRoles] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserClaims]    Script Date: 05/05/2023 16:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserClaims](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [nvarchar](450) NOT NULL,
	[ClaimType] [nvarchar](max) NULL,
	[ClaimValue] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserClaims] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserLogins]    Script Date: 05/05/2023 16:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserLogins](
	[LoginProvider] [nvarchar](128) NOT NULL,
	[ProviderKey] [nvarchar](128) NOT NULL,
	[ProviderDisplayName] [nvarchar](max) NULL,
	[UserId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserLogins] PRIMARY KEY CLUSTERED 
(
	[LoginProvider] ASC,
	[ProviderKey] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserRoles]    Script Date: 05/05/2023 16:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserRoles](
	[UserId] [nvarchar](450) NOT NULL,
	[RoleId] [nvarchar](450) NOT NULL,
 CONSTRAINT [PK_AspNetUserRoles] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[RoleId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUsers]    Script Date: 05/05/2023 16:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUsers](
	[Id] [nvarchar](450) NOT NULL,
	[UserName] [nvarchar](256) NULL,
	[NormalizedUserName] [nvarchar](256) NULL,
	[Email] [nvarchar](256) NULL,
	[NormalizedEmail] [nvarchar](256) NULL,
	[EmailConfirmed] [bit] NOT NULL,
	[PasswordHash] [nvarchar](max) NULL,
	[SecurityStamp] [nvarchar](max) NULL,
	[ConcurrencyStamp] [nvarchar](max) NULL,
	[PhoneNumber] [nvarchar](max) NULL,
	[PhoneNumberConfirmed] [bit] NOT NULL,
	[TwoFactorEnabled] [bit] NOT NULL,
	[LockoutEnd] [datetimeoffset](7) NULL,
	[LockoutEnabled] [bit] NOT NULL,
	[AccessFailedCount] [int] NOT NULL,
 CONSTRAINT [PK_AspNetUsers] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[AspNetUserTokens]    Script Date: 05/05/2023 16:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[AspNetUserTokens](
	[UserId] [nvarchar](450) NOT NULL,
	[LoginProvider] [nvarchar](128) NOT NULL,
	[Name] [nvarchar](128) NOT NULL,
	[Value] [nvarchar](max) NULL,
 CONSTRAINT [PK_AspNetUserTokens] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[LoginProvider] ASC,
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Author]    Script Date: 05/05/2023 16:42:27 ******/
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
/****** Object:  Table [dbo].[Book]    Script Date: 05/05/2023 16:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Book](
	[BookID] [int] IDENTITY(1,1) NOT NULL,
	[Id] [nvarchar](450) NULL,
	[AuthorID] [int] NULL,
	[GenreID] [int] NULL,
	[Title] [nvarchar](250) NULL,
	[Description] [nvarchar](max) NULL,
	[ISBN] [nvarchar](250) NULL,
	[Imagepath] [nvarchar](250) NULL,
	[IsDeleted] [bit] NULL,
	[Created] [date] NULL,
PRIMARY KEY CLUSTERED 
(
	[BookID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comment]    Script Date: 05/05/2023 16:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comment](
	[CommentID] [int] IDENTITY(1,1) NOT NULL,
	[ParentCommentID] [int] NULL,
	[ReviewID] [int] NULL,
	[Text] [nvarchar](250) NULL,
	[Id] [nvarchar](450) NULL,
	[Status] [nvarchar](50) NULL,
	[Created] [datetime] NULL,
PRIMARY KEY CLUSTERED 
(
	[CommentID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Genre]    Script Date: 05/05/2023 16:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Genre](
	[GenreID] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](250) NULL,
PRIMARY KEY CLUSTERED 
(
	[GenreID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Like]    Script Date: 05/05/2023 16:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Like](
	[LikeID] [int] IDENTITY(1,1) NOT NULL,
	[Id] [nvarchar](450) NULL,
	[ReviewID] [int] NULL,
	[CommentID] [int] NULL,
	[Like] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[LikeID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Review]    Script Date: 05/05/2023 16:42:27 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Review](
	[ReviewID] [int] IDENTITY(1,1) NOT NULL,
	[BookID] [int] NULL,
	[Id] [nvarchar](450) NULL,
	[Title] [nvarchar](250) NULL,
	[Text] [nvarchar](max) NULL,
	[Rating] [int] NULL,
	[Created] [datetime] NULL,
	[Status] [nvarchar](50) NULL,
PRIMARY KEY CLUSTERED 
(
	[ReviewID] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'00000000000000_CreateIdentitySchema', N'7.0.4')
GO
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'1', N'Admin', N'Admin', N'Admin')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'2', N'Moderator', N'Moderator', N'Moderator')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'3', N'User', N'User', N'User')
INSERT [dbo].[AspNetRoles] ([Id], [Name], [NormalizedName], [ConcurrencyStamp]) VALUES (N'4', NULL, NULL, NULL)
GO
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'19a9fec9-22e2-4190-ad44-ea2beb31d5a1', N'trash@torsk.net', N'TRASH@TORSK.NET', N'trash@torsk.net', N'TRASH@TORSK.NET', 1, N'AQAAAAIAAYagAAAAEG7iBqGO+OXt+tt7tsBFFbDRdxWlQK5j3QazJnrKXjVGdikpUF9+tKsEO/ppPZh+9A==', N'32LDSSE3AJJA5RGT4QBFZCZVCZO4M5FR', N'14ef90ff-d9c2-4464-88b6-ea19d7299aa0', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'38cb087e-5c93-435f-9c48-3e6b8ecd8ddc', N'Dem@dom.com', N'DEM@DOM.COM', N'Dem@dom.com', N'DEM@DOM.COM', 1, N'AQAAAAIAAYagAAAAEBS15omwA3wEN+pU5zGmcNCBWSAwOXQQD1L+CaC0ulBawX7txEu13R5q497g+49zxw==', N'TLXOK2DGEK7Y2CIWTLLUPGSG6ZNPM7UL', N'2a57d559-3674-4129-96b4-95a6a9e57ab7', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'512a98a6-549f-4075-89b0-b2bb1947ddb7', N'Kimgustafsson1@hotmail.se', N'KIMGUSTAFSSON1@HOTMAIL.SE', N'Kimgustafsson1@hotmail.se', N'KIMGUSTAFSSON1@HOTMAIL.SE', 1, N'AQAAAAIAAYagAAAAEOdE1Kp/Tjpqkc+pWhN4yxO2swc2WB5qJDJI8+AEJc2G6tGLnIg7MQ3a3OwWvWZAuw==', N'HUDM3VJHKFYUMHOKNH5IZYBT5WO5ZFLK', N'7b6dc84a-5537-4391-b64d-f432a6da3f5f', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'90f84345-831d-42bc-bb44-b2d9cf837ed2', N'gurkmonstret@hotmail.se', N'GURKMONSTRET@HOTMAIL.SE', N'gurkmonstret@hotmail.se', N'GURKMONSTRET@HOTMAIL.SE', 1, N'AQAAAAIAAYagAAAAED/GAOkBMWkG2OUVjGmsg1dPhK1OpEHEGMlP4a36yrXu1UeGSuh9SQDOOY2S+rN/2Q==', N'KQ3A7VECFK6B63D3XOZQQENVMLSIYLAY', N'95c3cb47-e40e-4d96-b93b-803b0d411d80', NULL, 0, 0, NULL, 1, 0)
INSERT [dbo].[AspNetUsers] ([Id], [UserName], [NormalizedUserName], [Email], [NormalizedEmail], [EmailConfirmed], [PasswordHash], [SecurityStamp], [ConcurrencyStamp], [PhoneNumber], [PhoneNumberConfirmed], [TwoFactorEnabled], [LockoutEnd], [LockoutEnabled], [AccessFailedCount]) VALUES (N'ec7a9adf-9cfc-4f3e-8df0-6732819467d2', N'Paul.Tanne@hotmail.se', N'PAUL.TANNE@HOTMAIL.SE', N'Paul.Tanne@hotmail.se', N'PAUL.TANNE@HOTMAIL.SE', 1, N'AQAAAAIAAYagAAAAEDm3o3VYq6CslfMWjoReLXN/9EzNWOHD1iB///st8AYJ16OoL7q7EB3M2iidrs/3Fw==', N'76BITO7S5E2NNT2IWOQU3VTAVLYWNPCW', N'7a1c438e-ef04-4059-908d-d01561f3330e', NULL, 0, 0, NULL, 1, 0)
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

INSERT [dbo].[Book] ([BookID], [Id], [AuthorID], [GenreID], [Title], [Description], [ISBN], [Imagepath], [IsDeleted], [Created]) VALUES (1, N'94807786-31eb-4656-8f39-39cd11eb0545', 1, 2, N'The Fellowship of the Ring', N'First of the Lord of the Rings trilogy', N'789456', N'/Images/lotr.jpg', 0, CAST(N'2022-01-01' AS Date))
INSERT [dbo].[Book] ([BookID], [Id], [AuthorID], [GenreID], [Title], [Description], [ISBN], [Imagepath], [IsDeleted], [Created]) VALUES (2, N'94807786-31eb-4656-8f39-39cd11eb0545', 2, 1, N'Neuromancer', N'Birth of Cyberpunk', N'456123', N'/Images/neuromancer.jpg', 0, CAST(N'2022-01-01' AS Date))
INSERT [dbo].[Book] ([BookID], [Id], [AuthorID], [GenreID], [Title], [Description], [ISBN], [Imagepath], [IsDeleted], [Created]) VALUES (3, N'94807786-31eb-4656-8f39-39cd11eb0545', 3, 6, N'One Child', N'child psychopathology, child abuse', N'456123', N'/Images/onechild.jpg', 0, CAST(N'2022-04-02' AS Date))
INSERT [dbo].[Book] ([BookID], [Id], [AuthorID], [GenreID], [Title], [Description], [ISBN], [Imagepath], [IsDeleted], [Created]) VALUES (4, N'94807786-31eb-4656-8f39-39cd11eb0545', 4, 5, N'Grand Union: Stories', N'10 short stories', N'45612311', N'/Images/grandunion.jpg', 0, CAST(N'2022-09-11' AS Date))
INSERT [dbo].[Book] ([BookID], [Id], [AuthorID], [GenreID], [Title], [Description], [ISBN], [Imagepath], [IsDeleted], [Created]) VALUES (5, N'94807786-31eb-4656-8f39-39cd11eb0545', 5, 3, N'Winnie-The-Pooh', N'Our beloved Pooh Bear', N'4561231145', N'/Images/winniethepooh.jpg', 0, CAST(N'2022-10-03' AS Date))
INSERT [dbo].[Book] ([BookID], [Id], [AuthorID], [GenreID], [Title], [Description], [ISBN], [Imagepath], [IsDeleted], [Created]) VALUES (6, N'94807786-31eb-4656-8f39-39cd11eb0545', 6, 4, N'Paradise Lost', N'Where the angles fear to tread', N'456123666', N'/Images/paradiselost.jpg', 0, CAST(N'2022-10-03' AS Date))
INSERT [dbo].[Book] ([BookID], [Id], [AuthorID], [GenreID], [Title], [Description], [ISBN], [Imagepath], [IsDeleted], [Created]) VALUES (7, N'94807786-31eb-4656-8f39-39cd11eb0545', 8, 8, N'4.50 from Paddington', N'Miss Marple is back', N'111333', N'/Images/450frompaddington.jpg', 0, CAST(N'2022-04-11' AS Date))
INSERT [dbo].[Book] ([BookID], [Id], [AuthorID], [GenreID], [Title], [Description], [ISBN], [Imagepath], [IsDeleted], [Created]) VALUES (9, N'94807786-31eb-4656-8f39-39cd11eb0545', 7, 7, N'The Call of Cthulhu', N'Weird tales from the unknown', N'444555666', N'/Images/callofcthulhu.jpg', 0, CAST(N'2022-04-12' AS Date))
INSERT [dbo].[Book] ([BookID], [Id], [AuthorID], [GenreID], [Title], [Description], [ISBN], [Imagepath], [IsDeleted], [Created]) VALUES (10, N'1', 1, 7, N'Yeet', N'Hohohooo!', N'1117700', N'/Images/Awesome-Chill-Background-scaled.jpg', 0, CAST(N'2023-05-05' AS Date))
INSERT [dbo].[Book] ([BookID], [Id], [AuthorID], [GenreID], [Title], [Description], [ISBN], [Imagepath], [IsDeleted], [Created]) VALUES (11, N'1', 1, 1, N'Yeet', N'Hohohooo!', N'0515015', N'/Images/Awesome-Chill-Background-scaled.jpg', 0, CAST(N'2023-05-05' AS Date))
INSERT [dbo].[Book] ([BookID], [Id], [AuthorID], [GenreID], [Title], [Description], [ISBN], [Imagepath], [IsDeleted], [Created]) VALUES (12, N'1', 3, 5, N'Yeet', N'Hejsan svejsan', N'51514', N'/Images/21c9d1688f7d8f220cc6922e255a5f4b.jpg', 0, CAST(N'2023-05-05' AS Date))
SET IDENTITY_INSERT [dbo].[Book] OFF
GO
SET IDENTITY_INSERT [dbo].[Comment] ON 

INSERT [dbo].[Comment] ([CommentID], [ParentCommentID], [ReviewID], [Text], [Id], [Status], [Created]) VALUES (1, NULL, 1, N'smeagol
', N'19a9fec9-22e2-4190-ad44-ea2beb31d5a1', NULL, CAST(N'2023-05-04T10:33:23.023' AS DateTime))
INSERT [dbo].[Comment] ([CommentID], [ParentCommentID], [ReviewID], [Text], [Id], [Status], [Created]) VALUES (2, 1, 1, N'heheheheh', N'19a9fec9-22e2-4190-ad44-ea2beb31d5a1', NULL, CAST(N'2023-05-04T10:33:42.363' AS DateTime))
SET IDENTITY_INSERT [dbo].[Comment] OFF
GO
SET IDENTITY_INSERT [dbo].[Genre] ON 

INSERT [dbo].[Genre] ([GenreID], [Name]) VALUES (1, N'Science Fiction')
INSERT [dbo].[Genre] ([GenreID], [Name]) VALUES (2, N'Fantasy')
INSERT [dbo].[Genre] ([GenreID], [Name]) VALUES (3, N'Children''s Books')
INSERT [dbo].[Genre] ([GenreID], [Name]) VALUES (4, N'Poetry')
INSERT [dbo].[Genre] ([GenreID], [Name]) VALUES (5, N'Short Stories')
INSERT [dbo].[Genre] ([GenreID], [Name]) VALUES (6, N'Non-Fiction')
INSERT [dbo].[Genre] ([GenreID], [Name]) VALUES (7, N'Horror')
INSERT [dbo].[Genre] ([GenreID], [Name]) VALUES (8, N'Murder Mystery')
SET IDENTITY_INSERT [dbo].[Genre] OFF
GO
SET IDENTITY_INSERT [dbo].[Review] ON 

INSERT [dbo].[Review] ([ReviewID], [BookID], [Id], [Title], [Text], [Rating], [Created], [Status]) VALUES (1, 1, N'19a9fec9-22e2-4190-ad44-ea2beb31d5a1', N'gollum', N'ererererer', 5, CAST(N'2023-05-04T10:33:13.313' AS DateTime), N'Public')
SET IDENTITY_INSERT [dbo].[Review] OFF
GO
ALTER TABLE [dbo].[AspNetRoleClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetRoleClaims] CHECK CONSTRAINT [FK_AspNetRoleClaims_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserClaims]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserClaims] CHECK CONSTRAINT [FK_AspNetUserClaims_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserLogins]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserLogins] CHECK CONSTRAINT [FK_AspNetUserLogins_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId] FOREIGN KEY([RoleId])
REFERENCES [dbo].[AspNetRoles] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetRoles_RoleId]
GO
ALTER TABLE [dbo].[AspNetUserRoles]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserRoles] CHECK CONSTRAINT [FK_AspNetUserRoles_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[AspNetUserTokens]  WITH CHECK ADD  CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[AspNetUsers] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[AspNetUserTokens] CHECK CONSTRAINT [FK_AspNetUserTokens_AspNetUsers_UserId]
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD FOREIGN KEY([AuthorID])
REFERENCES [dbo].[Author] ([AuthorID])
GO
ALTER TABLE [dbo].[Book]  WITH CHECK ADD FOREIGN KEY([GenreID])
REFERENCES [dbo].[Genre] ([GenreID])
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD FOREIGN KEY([Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD FOREIGN KEY([ParentCommentID])
REFERENCES [dbo].[Comment] ([CommentID])
GO
ALTER TABLE [dbo].[Comment]  WITH CHECK ADD FOREIGN KEY([ReviewID])
REFERENCES [dbo].[Review] ([ReviewID])
GO
ALTER TABLE [dbo].[Like]  WITH CHECK ADD FOREIGN KEY([CommentID])
REFERENCES [dbo].[Comment] ([CommentID])
GO
ALTER TABLE [dbo].[Like]  WITH CHECK ADD FOREIGN KEY([Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
ALTER TABLE [dbo].[Like]  WITH CHECK ADD FOREIGN KEY([ReviewID])
REFERENCES [dbo].[Review] ([ReviewID])
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD FOREIGN KEY([BookID])
REFERENCES [dbo].[Book] ([BookID])
GO
ALTER TABLE [dbo].[Review]  WITH CHECK ADD FOREIGN KEY([Id])
REFERENCES [dbo].[AspNetUsers] ([Id])
GO
USE [master]
GO
ALTER DATABASE [Coolbooks] SET  READ_WRITE 
GO
