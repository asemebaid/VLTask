USE [master]
GO
/****** Object:  Database [RequestDB]    Script Date: 08/02/2021 10:30:59 م ******/
CREATE DATABASE [RequestDB]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'RequestDB', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\RequestDB.mdf' , SIZE = 5120KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'RequestDB_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL12.SQLEXPRESS\MSSQL\DATA\RequestDB_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
GO
ALTER DATABASE [RequestDB] SET COMPATIBILITY_LEVEL = 120
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [RequestDB].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [RequestDB] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [RequestDB] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [RequestDB] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [RequestDB] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [RequestDB] SET ARITHABORT OFF 
GO
ALTER DATABASE [RequestDB] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [RequestDB] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [RequestDB] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [RequestDB] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [RequestDB] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [RequestDB] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [RequestDB] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [RequestDB] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [RequestDB] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [RequestDB] SET  DISABLE_BROKER 
GO
ALTER DATABASE [RequestDB] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [RequestDB] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [RequestDB] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [RequestDB] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [RequestDB] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [RequestDB] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [RequestDB] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [RequestDB] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [RequestDB] SET  MULTI_USER 
GO
ALTER DATABASE [RequestDB] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [RequestDB] SET DB_CHAINING OFF 
GO
ALTER DATABASE [RequestDB] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [RequestDB] SET TARGET_RECOVERY_TIME = 0 SECONDS 
GO
ALTER DATABASE [RequestDB] SET DELAYED_DURABILITY = DISABLED 
GO
USE [RequestDB]
GO
/****** Object:  Table [dbo].[Request]    Script Date: 08/02/2021 10:30:59 م ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Request](
	[RequestId] [int] IDENTITY(1,1) NOT NULL,
	[MobileNumber] [int] NOT NULL,
	[Action] [nvarchar](50) NOT NULL,
	[Handled] [bit] NOT NULL,
	[RequestDate] [datetime] NOT NULL,
	[HandlingDate] [datetime] NULL,
 CONSTRAINT [PK_Request] PRIMARY KEY CLUSTERED 
(
	[RequestId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
USE [master]
GO
ALTER DATABASE [RequestDB] SET  READ_WRITE 
GO
