USE [master]
GO
/****** Object:  Database [Words]    Script Date: 14.09.2018 13:53:21 ******/
CREATE DATABASE [Words]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'Words', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLVNEXT\MSSQL\DATA\Words.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'Words_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL14.SQLVNEXT\MSSQL\DATA\Words_log.ldf' , SIZE = 2048KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [Words] SET COMPATIBILITY_LEVEL = 110
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [Words].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [Words] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [Words] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [Words] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [Words] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [Words] SET ARITHABORT OFF 
GO
ALTER DATABASE [Words] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [Words] SET AUTO_CREATE_STATISTICS ON 
GO
ALTER DATABASE [Words] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [Words] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [Words] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [Words] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [Words] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [Words] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [Words] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [Words] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [Words] SET  DISABLE_BROKER 
GO
ALTER DATABASE [Words] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [Words] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [Words] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [Words] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [Words] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [Words] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [Words] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [Words] SET RECOVERY FULL 
GO
ALTER DATABASE [Words] SET  MULTI_USER 
GO
ALTER DATABASE [Words] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [Words] SET DB_CHAINING OFF 
GO
ALTER DATABASE [Words] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [Words] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
EXEC sys.sp_db_vardecimal_storage_format N'Words', N'ON'
GO
USE [Words]
GO
/****** Object:  Table [dbo].[Prohibited_words]    Script Date: 14.09.2018 13:53:21 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Prohibited_words](
	[word] [nvarchar](max) NOT NULL
) ON [PRIMARY] TEXTIMAGE_ON [PRIMARY]

GO
INSERT [dbo].[Prohibited_words] ([word]) VALUES (N'XXX')
INSERT [dbo].[Prohibited_words] ([word]) VALUES (N'вода')
INSERT [dbo].[Prohibited_words] ([word]) VALUES (N'смерть')
INSERT [dbo].[Prohibited_words] ([word]) VALUES (N'коммунизм')
INSERT [dbo].[Prohibited_words] ([word]) VALUES (N'фашизм')
INSERT [dbo].[Prohibited_words] ([word]) VALUES (N'для')
INSERT [dbo].[Prohibited_words] ([word]) VALUES (N'от')
INSERT [dbo].[Prohibited_words] ([word]) VALUES (N'используется')
INSERT [dbo].[Prohibited_words] ([word]) VALUES (N'открытие')
INSERT [dbo].[Prohibited_words] ([word]) VALUES (N'закрытие')
INSERT [dbo].[Prohibited_words] ([word]) VALUES (N'копирование')
INSERT [dbo].[Prohibited_words] ([word]) VALUES (N'рождение')
INSERT [dbo].[Prohibited_words] ([word]) VALUES (N'создание')
USE [master]
GO
ALTER DATABASE [Words] SET  READ_WRITE 
GO
