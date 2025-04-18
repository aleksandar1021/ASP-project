USE [master]
GO
/****** Object:  Database [Recipes]    Script Date: 6/16/2024 2:22:00 PM ******/
CREATE DATABASE [Recipes]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Recipes', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Recipes.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'Recipes_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL15.MSSQLSERVER\MSSQL\DATA\Recipes_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT
GO
ALTER DATABASE [Recipes] SET COMPATIBILITY_LEVEL = 150
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Recipes].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Recipes] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Recipes] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Recipes] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Recipes] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Recipes] SET ARITHABORT OFF 
GO
ALTER DATABASE [Recipes] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Recipes] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Recipes] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Recipes] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Recipes] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Recipes] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Recipes] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Recipes] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Recipes] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Recipes] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Recipes] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Recipes] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Recipes] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Recipes] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Recipes] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Recipes] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Recipes] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Recipes] SET RECOVERY FULL 
GO
ALTER DATABASE [Recipes] SET  MULTI_USER 
GO
ALTER DATABASE [Recipes] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Recipes] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Recipes] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Recipes] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [Recipes] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [Recipes] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'Recipes', N'ON'
GO
ALTER DATABASE [Recipes] SET QUERY_STORE = OFF
GO
USE [Recipes]
GO
/****** Object:  Table [dbo].[__EFMigrationsHistory]    Script Date: 6/16/2024 2:22:01 PM ******/
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
/****** Object:  Table [dbo].[Categories]    Script Date: 6/16/2024 2:22:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Categories](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Categories] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Comments]    Script Date: 6/16/2024 2:22:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Comments](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[ParentId] [int] NULL,
	[Text] [nvarchar](250) NOT NULL,
	[UserId] [int] NOT NULL,
	[RecipeId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Comments] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[ErrorLogs]    Script Date: 6/16/2024 2:22:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ErrorLogs](
	[Id] [uniqueidentifier] NOT NULL,
	[Message] [nvarchar](max) NOT NULL,
	[Time] [datetime2](7) NOT NULL,
	[StrackTrace] [nvarchar](max) NOT NULL,
 CONSTRAINT [PK_ErrorLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Follows]    Script Date: 6/16/2024 2:22:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Follows](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[FollowId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Follows] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Images]    Script Date: 6/16/2024 2:22:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Images](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RecipeId] [int] NOT NULL,
	[Path] [nvarchar](max) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Images] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ingredients]    Script Date: 6/16/2024 2:22:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ingredients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_Ingredients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Ratings]    Script Date: 6/16/2024 2:22:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Ratings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RatingValue] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Ratings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecipeIngredients]    Script Date: 6/16/2024 2:22:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecipeIngredients](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[IngredientId] [int] NOT NULL,
	[RecipeId] [int] NOT NULL,
	[Quantity] [nvarchar](200) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_RecipeIngredients] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[RecipeRatings]    Script Date: 6/16/2024 2:22:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[RecipeRatings](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RecipeId] [int] NOT NULL,
	[RatingId] [int] NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
	[UserId] [int] NOT NULL,
 CONSTRAINT [PK_RecipeRatings] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Recipes]    Script Date: 6/16/2024 2:22:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Recipes](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UserId] [int] NOT NULL,
	[CategoryId] [int] NOT NULL,
	[Title] [nvarchar](100) NOT NULL,
	[Description] [nvarchar](250) NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Recipes] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Steps]    Script Date: 6/16/2024 2:22:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Steps](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[RecipeId] [int] NOT NULL,
	[StepNumber] [int] NOT NULL,
	[Description] [nvarchar](250) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
 CONSTRAINT [PK_Steps] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UseCaseLogs]    Script Date: 6/16/2024 2:22:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UseCaseLogs](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[UseCaseName] [nvarchar](200) NOT NULL,
	[Username] [nvarchar](50) NOT NULL,
	[UseCaseData] [nvarchar](max) NULL,
	[ExecutedAt] [datetime2](7) NOT NULL,
 CONSTRAINT [PK_UseCaseLogs] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[Users]    Script Date: 6/16/2024 2:22:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Users](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](30) NOT NULL,
	[LastName] [nvarchar](30) NOT NULL,
	[Email] [nvarchar](100) NOT NULL,
	[Username] [nvarchar](100) NOT NULL,
	[Password] [nvarchar](250) NOT NULL,
	[CreatedAt] [datetime2](7) NOT NULL,
	[UpdatedAt] [datetime2](7) NULL,
	[IsActive] [bit] NOT NULL,
	[Image] [nvarchar](max) NULL,
 CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]
GO
/****** Object:  Table [dbo].[UserUseCases]    Script Date: 6/16/2024 2:22:01 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[UserUseCases](
	[UserId] [int] NOT NULL,
	[UseCaseId] [int] NOT NULL,
 CONSTRAINT [PK_UserUseCases] PRIMARY KEY CLUSTERED 
(
	[UserId] ASC,
	[UseCaseId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240604140301_AllTablesAndConfigurations', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240604141451_RecipeRatingsTableAndConfiguration', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240604141849_IngredientsTableAndConfiguration', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240604142705_RecipeIngredientsTableAndConfiguration', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240605135822_ErrorLogsTableAndConfiguration', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240606090536_UseCaseLogsTableAndConfiguration', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240606090649_UseCaseLogsTableAndConfiguration2', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240606132934_RemoveRoleTable', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240606133351_RemoveRoleId', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240606134129_SetIndexesOnTables', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240606135358_SetIndexesOnTables2', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240606135804_SetIndexesOnTables3', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240606170206_UserUseCaseTableAndConfiguration', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240607151110_DropUserImageComlumn', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240607161832_StepsTableAndConfiguration', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240608113716_AlterColumn', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240608165933_AlterTable', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240614183154_addUserImage', N'8.0.4')
INSERT [dbo].[__EFMigrationsHistory] ([MigrationId], [ProductVersion]) VALUES (N'20240615115236_FollowEdit', N'8.0.4')
GO
SET IDENTITY_INSERT [dbo].[Categories] ON 

INSERT [dbo].[Categories] ([Id], [ParentId], [CreatedAt], [UpdatedAt], [IsActive], [Name]) VALUES (1, NULL, CAST(N'2024-06-16T12:18:39.5606996' AS DateTime2), NULL, 1, N'Salty')
INSERT [dbo].[Categories] ([Id], [ParentId], [CreatedAt], [UpdatedAt], [IsActive], [Name]) VALUES (2, NULL, CAST(N'2024-06-16T12:18:39.5607002' AS DateTime2), NULL, 1, N'Sweet')
INSERT [dbo].[Categories] ([Id], [ParentId], [CreatedAt], [UpdatedAt], [IsActive], [Name]) VALUES (3, 2, CAST(N'2024-06-16T12:18:39.5607003' AS DateTime2), NULL, 1, N'Cakes')
INSERT [dbo].[Categories] ([Id], [ParentId], [CreatedAt], [UpdatedAt], [IsActive], [Name]) VALUES (4, 2, CAST(N'2024-06-16T12:18:39.5607005' AS DateTime2), NULL, 1, N'Ice cream')
INSERT [dbo].[Categories] ([Id], [ParentId], [CreatedAt], [UpdatedAt], [IsActive], [Name]) VALUES (5, 1, CAST(N'2024-06-16T12:18:39.5607006' AS DateTime2), NULL, 1, N'Meat')
SET IDENTITY_INSERT [dbo].[Categories] OFF
GO
SET IDENTITY_INSERT [dbo].[Comments] ON 

INSERT [dbo].[Comments] ([Id], [ParentId], [Text], [UserId], [RecipeId], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (1, NULL, N'Comment 2', 2, 1, CAST(N'2024-06-16T12:18:39.5607090' AS DateTime2), NULL, 1)
INSERT [dbo].[Comments] ([Id], [ParentId], [Text], [UserId], [RecipeId], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (2, NULL, N'Comment 1', 1, 2, CAST(N'2024-06-16T12:18:39.5607087' AS DateTime2), NULL, 1)
INSERT [dbo].[Comments] ([Id], [ParentId], [Text], [UserId], [RecipeId], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (3, 2, N'Child Comment', 2, 2, CAST(N'2024-06-16T12:18:39.5607088' AS DateTime2), NULL, 1)
SET IDENTITY_INSERT [dbo].[Comments] OFF
GO
SET IDENTITY_INSERT [dbo].[Follows] ON 

INSERT [dbo].[Follows] ([Id], [UserId], [FollowId], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (1, 1, 2, CAST(N'2024-06-16T12:18:39.5606875' AS DateTime2), NULL, 1)
INSERT [dbo].[Follows] ([Id], [UserId], [FollowId], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (2, 2, 1, CAST(N'2024-06-16T12:18:39.5606882' AS DateTime2), NULL, 1)
SET IDENTITY_INSERT [dbo].[Follows] OFF
GO
SET IDENTITY_INSERT [dbo].[Images] ON 

INSERT [dbo].[Images] ([Id], [RecipeId], [Path], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (1, 1, N'image3.jpg', CAST(N'2024-06-16T12:18:39.5607024' AS DateTime2), NULL, 1)
INSERT [dbo].[Images] ([Id], [RecipeId], [Path], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (2, 1, N'image4.jpg', CAST(N'2024-06-16T12:18:39.5607025' AS DateTime2), NULL, 1)
INSERT [dbo].[Images] ([Id], [RecipeId], [Path], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (3, 1, N'image5.jpg', CAST(N'2024-06-16T12:18:39.5607027' AS DateTime2), NULL, 1)
INSERT [dbo].[Images] ([Id], [RecipeId], [Path], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (4, 2, N'image1.jpg', CAST(N'2024-06-16T12:18:39.5607012' AS DateTime2), NULL, 1)
INSERT [dbo].[Images] ([Id], [RecipeId], [Path], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (5, 2, N'image2.jpg', CAST(N'2024-06-16T12:18:39.5607014' AS DateTime2), NULL, 1)
SET IDENTITY_INSERT [dbo].[Images] OFF
GO
SET IDENTITY_INSERT [dbo].[Ingredients] ON 

INSERT [dbo].[Ingredients] ([Id], [CreatedAt], [UpdatedAt], [IsActive], [Name]) VALUES (1, CAST(N'2024-06-16T12:18:39.5607049' AS DateTime2), NULL, 1, N'Salt')
INSERT [dbo].[Ingredients] ([Id], [CreatedAt], [UpdatedAt], [IsActive], [Name]) VALUES (2, CAST(N'2024-06-16T12:18:39.5607051' AS DateTime2), NULL, 1, N'Pepper')
INSERT [dbo].[Ingredients] ([Id], [CreatedAt], [UpdatedAt], [IsActive], [Name]) VALUES (3, CAST(N'2024-06-16T12:18:39.5607052' AS DateTime2), NULL, 1, N'Cheese')
INSERT [dbo].[Ingredients] ([Id], [CreatedAt], [UpdatedAt], [IsActive], [Name]) VALUES (4, CAST(N'2024-06-16T12:18:39.5607054' AS DateTime2), NULL, 1, N'Sugar')
INSERT [dbo].[Ingredients] ([Id], [CreatedAt], [UpdatedAt], [IsActive], [Name]) VALUES (5, CAST(N'2024-06-16T12:18:39.5607055' AS DateTime2), NULL, 1, N'Oil')
INSERT [dbo].[Ingredients] ([Id], [CreatedAt], [UpdatedAt], [IsActive], [Name]) VALUES (6, CAST(N'2024-06-16T12:18:39.5607056' AS DateTime2), NULL, 1, N'Onion')
INSERT [dbo].[Ingredients] ([Id], [CreatedAt], [UpdatedAt], [IsActive], [Name]) VALUES (7, CAST(N'2024-06-16T12:18:39.5607058' AS DateTime2), NULL, 1, N'Milk')
SET IDENTITY_INSERT [dbo].[Ingredients] OFF
GO
SET IDENTITY_INSERT [dbo].[Ratings] ON 

INSERT [dbo].[Ratings] ([Id], [RatingValue], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (1, 1, CAST(N'2024-06-16T12:18:39.5607036' AS DateTime2), NULL, 1)
INSERT [dbo].[Ratings] ([Id], [RatingValue], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (2, 2, CAST(N'2024-06-16T12:18:39.5607038' AS DateTime2), NULL, 1)
INSERT [dbo].[Ratings] ([Id], [RatingValue], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (3, 3, CAST(N'2024-06-16T12:18:39.5607040' AS DateTime2), NULL, 1)
INSERT [dbo].[Ratings] ([Id], [RatingValue], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (4, 4, CAST(N'2024-06-16T12:18:39.5607042' AS DateTime2), NULL, 1)
INSERT [dbo].[Ratings] ([Id], [RatingValue], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (5, 5, CAST(N'2024-06-16T12:18:39.5607043' AS DateTime2), NULL, 1)
SET IDENTITY_INSERT [dbo].[Ratings] OFF
GO
SET IDENTITY_INSERT [dbo].[RecipeIngredients] ON 

INSERT [dbo].[RecipeIngredients] ([Id], [IngredientId], [RecipeId], [Quantity], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (1, 4, 1, N'50 g', CAST(N'2024-06-16T12:18:39.5607083' AS DateTime2), NULL, 1)
INSERT [dbo].[RecipeIngredients] ([Id], [IngredientId], [RecipeId], [Quantity], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (2, 7, 1, N'100 ml', CAST(N'2024-06-16T12:18:39.5607085' AS DateTime2), NULL, 1)
INSERT [dbo].[RecipeIngredients] ([Id], [IngredientId], [RecipeId], [Quantity], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (3, 5, 2, N'1 ml', CAST(N'2024-06-16T12:18:39.5607079' AS DateTime2), NULL, 1)
INSERT [dbo].[RecipeIngredients] ([Id], [IngredientId], [RecipeId], [Quantity], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (4, 1, 2, N'10 g', CAST(N'2024-06-16T12:18:39.5607081' AS DateTime2), NULL, 1)
INSERT [dbo].[RecipeIngredients] ([Id], [IngredientId], [RecipeId], [Quantity], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (5, 2, 2, N'5 g', CAST(N'2024-06-16T12:18:39.5607082' AS DateTime2), NULL, 1)
SET IDENTITY_INSERT [dbo].[RecipeIngredients] OFF
GO
SET IDENTITY_INSERT [dbo].[RecipeRatings] ON 

INSERT [dbo].[RecipeRatings] ([Id], [RecipeId], [RatingId], [CreatedAt], [UpdatedAt], [IsActive], [UserId]) VALUES (1, 1, 4, CAST(N'2024-06-16T12:18:39.5607047' AS DateTime2), NULL, 1, 2)
INSERT [dbo].[RecipeRatings] ([Id], [RecipeId], [RatingId], [CreatedAt], [UpdatedAt], [IsActive], [UserId]) VALUES (2, 2, 5, CAST(N'2024-06-16T12:18:39.5607045' AS DateTime2), NULL, 1, 1)
SET IDENTITY_INSERT [dbo].[RecipeRatings] OFF
GO
SET IDENTITY_INSERT [dbo].[Recipes] ON 

INSERT [dbo].[Recipes] ([Id], [UserId], [CategoryId], [Title], [Description], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (1, 2, 2, N'Ice cream', N'Sweet ice cream', CAST(N'2024-06-16T12:18:39.5607021' AS DateTime2), NULL, 1)
INSERT [dbo].[Recipes] ([Id], [UserId], [CategoryId], [Title], [Description], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (2, 1, 5, N'Meat in mushroom sauce', NULL, CAST(N'2024-06-16T12:18:39.5607009' AS DateTime2), NULL, 1)
SET IDENTITY_INSERT [dbo].[Recipes] OFF
GO
SET IDENTITY_INSERT [dbo].[Steps] ON 

INSERT [dbo].[Steps] ([Id], [RecipeId], [StepNumber], [Description], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (1, 1, 1, N'Step 1', CAST(N'2024-06-16T12:18:39.5607028' AS DateTime2), NULL, 1)
INSERT [dbo].[Steps] ([Id], [RecipeId], [StepNumber], [Description], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (2, 1, 2, N'Step 2', CAST(N'2024-06-16T12:18:39.5607030' AS DateTime2), NULL, 1)
INSERT [dbo].[Steps] ([Id], [RecipeId], [StepNumber], [Description], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (3, 1, 3, N'Step 3', CAST(N'2024-06-16T12:18:39.5607031' AS DateTime2), NULL, 1)
INSERT [dbo].[Steps] ([Id], [RecipeId], [StepNumber], [Description], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (4, 1, 3, N'Step 4', CAST(N'2024-06-16T12:18:39.5607032' AS DateTime2), NULL, 1)
INSERT [dbo].[Steps] ([Id], [RecipeId], [StepNumber], [Description], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (5, 1, 3, N'Step 5', CAST(N'2024-06-16T12:18:39.5607034' AS DateTime2), NULL, 1)
INSERT [dbo].[Steps] ([Id], [RecipeId], [StepNumber], [Description], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (6, 2, 1, N'Step 1', CAST(N'2024-06-16T12:18:39.5607017' AS DateTime2), NULL, 1)
INSERT [dbo].[Steps] ([Id], [RecipeId], [StepNumber], [Description], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (7, 2, 2, N'Step 2', CAST(N'2024-06-16T12:18:39.5607019' AS DateTime2), NULL, 1)
INSERT [dbo].[Steps] ([Id], [RecipeId], [StepNumber], [Description], [CreatedAt], [UpdatedAt], [IsActive]) VALUES (8, 2, 3, N'Step 3', CAST(N'2024-06-16T12:18:39.5607020' AS DateTime2), NULL, 1)
SET IDENTITY_INSERT [dbo].[Steps] OFF
GO
SET IDENTITY_INSERT [dbo].[Users] ON 

INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Username], [Password], [CreatedAt], [UpdatedAt], [IsActive], [Image]) VALUES (1, N'User', N'User', N'user@gmail.com', N'user', N'$2a$10$NbncEcq9zSGMXk3OKvsm5OmQdl5IFUhRP9v67jYV8t0O7JJNKdu/q', CAST(N'2024-06-16T12:18:39.5606485' AS DateTime2), NULL, 1, NULL)
INSERT [dbo].[Users] ([Id], [FirstName], [LastName], [Email], [Username], [Password], [CreatedAt], [UpdatedAt], [IsActive], [Image]) VALUES (2, N'Admin', N'Admin', N'admin@gmail.com', N'admin', N'$2a$10$ZVOW5S6NP1GhXln8c.6d4eFf.rEwH0b.bM8f2auboiUu6.S..8PJ.', CAST(N'2024-06-16T12:18:39.5606879' AS DateTime2), NULL, 1, NULL)
SET IDENTITY_INSERT [dbo].[Users] OFF
GO
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 1)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 4)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 10)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 13)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 14)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 18)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 19)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 20)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 21)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 22)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 23)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 24)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 25)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 26)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 30)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 31)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 32)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 33)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 34)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 35)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 36)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 37)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 38)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 39)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 40)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 41)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 42)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 43)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 45)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 46)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 47)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 48)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 49)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 50)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (1, 51)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 1)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 2)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 3)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 4)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 5)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 6)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 7)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 8)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 9)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 10)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 11)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 12)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 13)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 14)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 15)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 16)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 17)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 18)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 19)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 20)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 21)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 22)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 23)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 24)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 25)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 26)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 27)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 28)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 29)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 30)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 31)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 32)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 33)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 34)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 35)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 36)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 37)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 38)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 39)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 40)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 41)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 42)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 43)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 44)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 45)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 46)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 47)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 48)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 49)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 50)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 51)
INSERT [dbo].[UserUseCases] ([UserId], [UseCaseId]) VALUES (2, 52)
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Categories_Name]    Script Date: 6/16/2024 2:22:01 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Categories_Name] ON [dbo].[Categories]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Categories_ParentId]    Script Date: 6/16/2024 2:22:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_Categories_ParentId] ON [dbo].[Categories]
(
	[ParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comments_ParentId]    Script Date: 6/16/2024 2:22:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_Comments_ParentId] ON [dbo].[Comments]
(
	[ParentId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comments_RecipeId]    Script Date: 6/16/2024 2:22:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_Comments_RecipeId] ON [dbo].[Comments]
(
	[RecipeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Comments_UserId]    Script Date: 6/16/2024 2:22:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_Comments_UserId] ON [dbo].[Comments]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Follows_FollowId]    Script Date: 6/16/2024 2:22:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_Follows_FollowId] ON [dbo].[Follows]
(
	[FollowId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Follows_UserId]    Script Date: 6/16/2024 2:22:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_Follows_UserId] ON [dbo].[Follows]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Images_RecipeId]    Script Date: 6/16/2024 2:22:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_Images_RecipeId] ON [dbo].[Images]
(
	[RecipeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Ingredients_Name]    Script Date: 6/16/2024 2:22:01 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Ingredients_Name] ON [dbo].[Ingredients]
(
	[Name] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Ratings_RatingValue]    Script Date: 6/16/2024 2:22:01 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Ratings_RatingValue] ON [dbo].[Ratings]
(
	[RatingValue] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RecipeIngredients_IngredientId]    Script Date: 6/16/2024 2:22:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_RecipeIngredients_IngredientId] ON [dbo].[RecipeIngredients]
(
	[IngredientId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RecipeIngredients_RecipeId]    Script Date: 6/16/2024 2:22:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_RecipeIngredients_RecipeId] ON [dbo].[RecipeIngredients]
(
	[RecipeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RecipeRatings_RatingId]    Script Date: 6/16/2024 2:22:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_RecipeRatings_RatingId] ON [dbo].[RecipeRatings]
(
	[RatingId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RecipeRatings_RecipeId]    Script Date: 6/16/2024 2:22:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_RecipeRatings_RecipeId] ON [dbo].[RecipeRatings]
(
	[RecipeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_RecipeRatings_UserId]    Script Date: 6/16/2024 2:22:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_RecipeRatings_UserId] ON [dbo].[RecipeRatings]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Recipes_CategoryId]    Script Date: 6/16/2024 2:22:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_Recipes_CategoryId] ON [dbo].[Recipes]
(
	[CategoryId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Recipes_Title]    Script Date: 6/16/2024 2:22:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_Recipes_Title] ON [dbo].[Recipes]
(
	[Title] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Recipes_UserId]    Script Date: 6/16/2024 2:22:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_Recipes_UserId] ON [dbo].[Recipes]
(
	[UserId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
/****** Object:  Index [IX_Steps_RecipeId]    Script Date: 6/16/2024 2:22:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_Steps_RecipeId] ON [dbo].[Steps]
(
	[RecipeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_UseCaseLogs_Username_UseCaseName_ExecutedAt]    Script Date: 6/16/2024 2:22:01 PM ******/
CREATE NONCLUSTERED INDEX [IX_UseCaseLogs_Username_UseCaseName_ExecutedAt] ON [dbo].[UseCaseLogs]
(
	[Username] ASC,
	[UseCaseName] ASC,
	[ExecutedAt] ASC
)
INCLUDE([UseCaseData]) WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_Email]    Script Date: 6/16/2024 2:22:01 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_Email] ON [dbo].[Users]
(
	[Email] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
SET ANSI_PADDING ON
GO
/****** Object:  Index [IX_Users_Username]    Script Date: 6/16/2024 2:22:01 PM ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_Users_Username] ON [dbo].[Users]
(
	[Username] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
GO
ALTER TABLE [dbo].[Categories] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Categories] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Comments] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Comments] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Follows] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Follows] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Images] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Images] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Ingredients] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Ingredients] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Ratings] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Ratings] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[RecipeIngredients] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[RecipeIngredients] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[RecipeRatings] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[RecipeRatings] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[RecipeRatings] ADD  DEFAULT ((0)) FOR [UserId]
GO
ALTER TABLE [dbo].[Recipes] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Recipes] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Steps] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Steps] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (getdate()) FOR [CreatedAt]
GO
ALTER TABLE [dbo].[Users] ADD  DEFAULT (CONVERT([bit],(1))) FOR [IsActive]
GO
ALTER TABLE [dbo].[Categories]  WITH CHECK ADD  CONSTRAINT [FK_Categories_Categories_ParentId] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Categories] CHECK CONSTRAINT [FK_Categories_Categories_ParentId]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Comments_ParentId] FOREIGN KEY([ParentId])
REFERENCES [dbo].[Comments] ([Id])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Comments_ParentId]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Recipes_RecipeId] FOREIGN KEY([RecipeId])
REFERENCES [dbo].[Recipes] ([Id])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Recipes_RecipeId]
GO
ALTER TABLE [dbo].[Comments]  WITH CHECK ADD  CONSTRAINT [FK_Comments_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Comments] CHECK CONSTRAINT [FK_Comments_Users_UserId]
GO
ALTER TABLE [dbo].[Follows]  WITH CHECK ADD  CONSTRAINT [FK_Follows_Users_FollowId] FOREIGN KEY([FollowId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Follows] CHECK CONSTRAINT [FK_Follows_Users_FollowId]
GO
ALTER TABLE [dbo].[Follows]  WITH CHECK ADD  CONSTRAINT [FK_Follows_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Follows] CHECK CONSTRAINT [FK_Follows_Users_UserId]
GO
ALTER TABLE [dbo].[Images]  WITH CHECK ADD  CONSTRAINT [FK_Images_Recipes_RecipeId] FOREIGN KEY([RecipeId])
REFERENCES [dbo].[Recipes] ([Id])
GO
ALTER TABLE [dbo].[Images] CHECK CONSTRAINT [FK_Images_Recipes_RecipeId]
GO
ALTER TABLE [dbo].[RecipeIngredients]  WITH CHECK ADD  CONSTRAINT [FK_RecipeIngredients_Ingredients_IngredientId] FOREIGN KEY([IngredientId])
REFERENCES [dbo].[Ingredients] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RecipeIngredients] CHECK CONSTRAINT [FK_RecipeIngredients_Ingredients_IngredientId]
GO
ALTER TABLE [dbo].[RecipeIngredients]  WITH CHECK ADD  CONSTRAINT [FK_RecipeIngredients_Recipes_RecipeId] FOREIGN KEY([RecipeId])
REFERENCES [dbo].[Recipes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RecipeIngredients] CHECK CONSTRAINT [FK_RecipeIngredients_Recipes_RecipeId]
GO
ALTER TABLE [dbo].[RecipeRatings]  WITH CHECK ADD  CONSTRAINT [FK_RecipeRatings_Ratings_RatingId] FOREIGN KEY([RatingId])
REFERENCES [dbo].[Ratings] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RecipeRatings] CHECK CONSTRAINT [FK_RecipeRatings_Ratings_RatingId]
GO
ALTER TABLE [dbo].[RecipeRatings]  WITH CHECK ADD  CONSTRAINT [FK_RecipeRatings_Recipes_RecipeId] FOREIGN KEY([RecipeId])
REFERENCES [dbo].[Recipes] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RecipeRatings] CHECK CONSTRAINT [FK_RecipeRatings_Recipes_RecipeId]
GO
ALTER TABLE [dbo].[RecipeRatings]  WITH CHECK ADD  CONSTRAINT [FK_RecipeRatings_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
ON DELETE CASCADE
GO
ALTER TABLE [dbo].[RecipeRatings] CHECK CONSTRAINT [FK_RecipeRatings_Users_UserId]
GO
ALTER TABLE [dbo].[Recipes]  WITH CHECK ADD  CONSTRAINT [FK_Recipes_Categories_CategoryId] FOREIGN KEY([CategoryId])
REFERENCES [dbo].[Categories] ([Id])
GO
ALTER TABLE [dbo].[Recipes] CHECK CONSTRAINT [FK_Recipes_Categories_CategoryId]
GO
ALTER TABLE [dbo].[Recipes]  WITH CHECK ADD  CONSTRAINT [FK_Recipes_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[Recipes] CHECK CONSTRAINT [FK_Recipes_Users_UserId]
GO
ALTER TABLE [dbo].[Steps]  WITH CHECK ADD  CONSTRAINT [FK_Steps_Recipes_RecipeId] FOREIGN KEY([RecipeId])
REFERENCES [dbo].[Recipes] ([Id])
GO
ALTER TABLE [dbo].[Steps] CHECK CONSTRAINT [FK_Steps_Recipes_RecipeId]
GO
ALTER TABLE [dbo].[UserUseCases]  WITH CHECK ADD  CONSTRAINT [FK_UserUseCases_Users_UserId] FOREIGN KEY([UserId])
REFERENCES [dbo].[Users] ([Id])
GO
ALTER TABLE [dbo].[UserUseCases] CHECK CONSTRAINT [FK_UserUseCases_Users_UserId]
GO
USE [master]
GO
ALTER DATABASE [Recipes] SET  READ_WRITE 
GO
