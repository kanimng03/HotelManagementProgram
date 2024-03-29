USE [master]
GO
/****** Object:  Database [dataHMP]    Script Date: 10/26/2023 5:30:27 PM ******/
CREATE DATABASE [dataHMP]
 CONTAINMENT = NONE
 ON  PRIMARY 
( NAME = N'dataHMP', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.KIMNGAN\MSSQL\DATA\dataHMP.mdf' , SIZE = 8192KB , MAXSIZE = UNLIMITED, FILEGROWTH = 65536KB )
 LOG ON 
( NAME = N'dataHMP_log', FILENAME = N'C:\Program Files\Microsoft SQL Server\MSSQL16.KIMNGAN\MSSQL\DATA\dataHMP_log.ldf' , SIZE = 8192KB , MAXSIZE = 2048GB , FILEGROWTH = 65536KB )
 WITH CATALOG_COLLATION = DATABASE_DEFAULT, LEDGER = OFF
GO
ALTER DATABASE [dataHMP] SET COMPATIBILITY_LEVEL = 160
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [dataHMP].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [dataHMP] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [dataHMP] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [dataHMP] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [dataHMP] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [dataHMP] SET ARITHABORT OFF 
GO
ALTER DATABASE [dataHMP] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [dataHMP] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [dataHMP] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [dataHMP] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [dataHMP] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [dataHMP] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [dataHMP] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [dataHMP] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [dataHMP] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [dataHMP] SET  ENABLE_BROKER 
GO
ALTER DATABASE [dataHMP] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [dataHMP] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [dataHMP] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [dataHMP] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [dataHMP] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [dataHMP] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [dataHMP] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [dataHMP] SET RECOVERY FULL 
GO
ALTER DATABASE [dataHMP] SET  MULTI_USER 
GO
ALTER DATABASE [dataHMP] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [dataHMP] SET DB_CHAINING OFF 
GO
ALTER DATABASE [dataHMP] SET FILESTREAM( NON_TRANSACTED_ACCESS = OFF ) 
GO
ALTER DATABASE [dataHMP] SET TARGET_RECOVERY_TIME = 60 SECONDS 
GO
ALTER DATABASE [dataHMP] SET DELAYED_DURABILITY = DISABLED 
GO
ALTER DATABASE [dataHMP] SET ACCELERATED_DATABASE_RECOVERY = OFF  
GO
EXEC sys.sp_db_vardecimal_storage_format N'dataHMP', N'ON'
GO
ALTER DATABASE [dataHMP] SET QUERY_STORE = ON
GO
ALTER DATABASE [dataHMP] SET QUERY_STORE (OPERATION_MODE = READ_WRITE, CLEANUP_POLICY = (STALE_QUERY_THRESHOLD_DAYS = 30), DATA_FLUSH_INTERVAL_SECONDS = 900, INTERVAL_LENGTH_MINUTES = 60, MAX_STORAGE_SIZE_MB = 1000, QUERY_CAPTURE_MODE = AUTO, SIZE_BASED_CLEANUP_MODE = AUTO, MAX_PLANS_PER_QUERY = 200, WAIT_STATS_CAPTURE_MODE = ON)
GO
USE [dataHMP]
GO
/****** Object:  Table [dbo].[customer]    Script Date: 10/26/2023 5:30:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[customer](
	[cid] [int] IDENTITY(1,1) NOT NULL,
	[cname] [varchar](250) NOT NULL,
	[mobile] [bigint] NOT NULL,
	[nationality] [varchar](250) NOT NULL,
	[gender] [varchar](50) NOT NULL,
	[dob] [date] NOT NULL,
	[idproof] [varchar](250) NOT NULL,
	[address] [varchar](350) NOT NULL,
	[checkin] [date] NOT NULL,
	[checkout_date] [date] NULL,
	[checkout_payment] [varchar](250) NULL,
	[roomid] [int] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[cid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[employee]    Script Date: 10/26/2023 5:30:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[employee](
	[eid] [int] IDENTITY(1,1) NOT NULL,
	[ename] [varchar](250) NOT NULL,
	[mobile] [bigint] NOT NULL,
	[gender] [varchar](50) NOT NULL,
	[emailid] [varchar](120) NOT NULL,
	[username] [varchar](150) NOT NULL,
	[pass] [varchar](150) NOT NULL,
	[role] [nvarchar](50) NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[eid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
/****** Object:  Table [dbo].[rooms]    Script Date: 10/26/2023 5:30:27 PM ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[rooms](
	[roomid] [int] IDENTITY(1,1) NOT NULL,
	[roomNo] [varchar](250) NOT NULL,
	[roomType] [varchar](250) NOT NULL,
	[bed] [varchar](250) NOT NULL,
	[price] [bigint] NOT NULL,
PRIMARY KEY CLUSTERED 
(
	[roomid] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON, OPTIMIZE_FOR_SEQUENTIAL_KEY = OFF) ON [PRIMARY]
) ON [PRIMARY]
GO
SET IDENTITY_INSERT [dbo].[employee] ON 

INSERT [dbo].[employee] ([eid], [ename], [mobile], [gender], [emailid], [username], [pass], [role]) VALUES (1, N'Admin', 889191029, N'female', N'kimngan160903@gmail.com', N'admin1', N'admin123', N'admin')
INSERT [dbo].[employee] ([eid], [ename], [mobile], [gender], [emailid], [username], [pass], [role]) VALUES (2, N'User1', 156465145, N'male', N'khaiuef@uef.com', N'user1', N'user123', N'user')
SET IDENTITY_INSERT [dbo].[employee] OFF
GO
SET IDENTITY_INSERT [dbo].[rooms] ON 

INSERT [dbo].[rooms] ([roomid], [roomNo], [roomType], [bed], [price]) VALUES (2, N'10', N'Standard', N'Double', 12345678)
INSERT [dbo].[rooms] ([roomid], [roomNo], [roomType], [bed], [price]) VALUES (3, N'7', N'Standard', N'Triple', 1000000)
INSERT [dbo].[rooms] ([roomid], [roomNo], [roomType], [bed], [price]) VALUES (4, N'4', N'Suite', N'Super King Size', 1000000000)
INSERT [dbo].[rooms] ([roomid], [roomNo], [roomType], [bed], [price]) VALUES (5, N'6', N'Standard', N'Single', 5000000)
SET IDENTITY_INSERT [dbo].[rooms] OFF
GO
ALTER TABLE [dbo].[customer] ADD  DEFAULT ('NO') FOR [checkout_payment]
GO
ALTER TABLE [dbo].[employee] ADD  DEFAULT ('user') FOR [role]
GO
ALTER TABLE [dbo].[customer]  WITH CHECK ADD FOREIGN KEY([roomid])
REFERENCES [dbo].[rooms] ([roomid])
GO
USE [master]
GO
ALTER DATABASE [dataHMP] SET  READ_WRITE 
GO
