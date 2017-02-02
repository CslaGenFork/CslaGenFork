USE [master]
GO
/****** Object:  Database [InvoiceTest]    Script Date: 02-02-2017 22:47:54 ******/
CREATE DATABASE [InvoiceTest] ON  PRIMARY 
( NAME = N'InvoiceTest', FILENAME = N'C:\MYDB\InvoiceTest.mdf' , SIZE = 3072KB , MAXSIZE = UNLIMITED, FILEGROWTH = 1024KB )
 LOG ON 
( NAME = N'InvoiceTest_log', FILENAME = N'C:\MYDB\InvoiceTest_log.ldf' , SIZE = 1024KB , MAXSIZE = 2048GB , FILEGROWTH = 10%)
 COLLATE Latin1_General_CI_AI
GO
ALTER DATABASE [InvoiceTest] SET COMPATIBILITY_LEVEL = 100
GO
IF (1 = FULLTEXTSERVICEPROPERTY('IsFullTextInstalled'))
begin
EXEC [InvoiceTest].[dbo].[sp_fulltext_database] @action = 'enable'
end
GO
ALTER DATABASE [InvoiceTest] SET ANSI_NULL_DEFAULT OFF 
GO
ALTER DATABASE [InvoiceTest] SET ANSI_NULLS OFF 
GO
ALTER DATABASE [InvoiceTest] SET ANSI_PADDING OFF 
GO
ALTER DATABASE [InvoiceTest] SET ANSI_WARNINGS OFF 
GO
ALTER DATABASE [InvoiceTest] SET ARITHABORT OFF 
GO
ALTER DATABASE [InvoiceTest] SET AUTO_CLOSE OFF 
GO
ALTER DATABASE [InvoiceTest] SET AUTO_SHRINK OFF 
GO
ALTER DATABASE [InvoiceTest] SET AUTO_UPDATE_STATISTICS ON 
GO
ALTER DATABASE [InvoiceTest] SET CURSOR_CLOSE_ON_COMMIT OFF 
GO
ALTER DATABASE [InvoiceTest] SET CURSOR_DEFAULT  GLOBAL 
GO
ALTER DATABASE [InvoiceTest] SET CONCAT_NULL_YIELDS_NULL OFF 
GO
ALTER DATABASE [InvoiceTest] SET NUMERIC_ROUNDABORT OFF 
GO
ALTER DATABASE [InvoiceTest] SET QUOTED_IDENTIFIER OFF 
GO
ALTER DATABASE [InvoiceTest] SET RECURSIVE_TRIGGERS OFF 
GO
ALTER DATABASE [InvoiceTest] SET  DISABLE_BROKER 
GO
ALTER DATABASE [InvoiceTest] SET AUTO_UPDATE_STATISTICS_ASYNC OFF 
GO
ALTER DATABASE [InvoiceTest] SET DATE_CORRELATION_OPTIMIZATION OFF 
GO
ALTER DATABASE [InvoiceTest] SET TRUSTWORTHY OFF 
GO
ALTER DATABASE [InvoiceTest] SET ALLOW_SNAPSHOT_ISOLATION OFF 
GO
ALTER DATABASE [InvoiceTest] SET PARAMETERIZATION SIMPLE 
GO
ALTER DATABASE [InvoiceTest] SET READ_COMMITTED_SNAPSHOT OFF 
GO
ALTER DATABASE [InvoiceTest] SET HONOR_BROKER_PRIORITY OFF 
GO
ALTER DATABASE [InvoiceTest] SET RECOVERY SIMPLE 
GO
ALTER DATABASE [InvoiceTest] SET  MULTI_USER 
GO
ALTER DATABASE [InvoiceTest] SET PAGE_VERIFY CHECKSUM  
GO
ALTER DATABASE [InvoiceTest] SET DB_CHAINING OFF 
GO
EXEC sys.sp_db_vardecimal_storage_format N'InvoiceTest', N'ON'
GO
USE [InvoiceTest]
GO
/****** Object:  Table [dbo].[InvoiceLines]    Script Date: 02-02-2017 22:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[InvoiceLines](
	[InvoiceLineId] [uniqueidentifier] NOT NULL,
	[InvoiceId] [uniqueidentifier] NOT NULL,
	[ProductId] [uniqueidentifier] NOT NULL,
	[Cost] [money] NOT NULL,
	[PercentDiscount] [tinyint] NOT NULL,
 CONSTRAINT [PK_InvoiceLines] PRIMARY KEY CLUSTERED 
(
	[InvoiceLineId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Invoices]    Script Date: 02-02-2017 22:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Invoices](
	[InvoiceId] [uniqueidentifier] NOT NULL,
	[InvoiceNumber] [varchar](20) COLLATE Latin1_General_CI_AI NOT NULL,
	[CustomerName] [nvarchar](50) COLLATE Latin1_General_CI_AI NOT NULL,
	[InvoiceDate] [date] NOT NULL,
	[IsActive] [bit] NOT NULL,
	[CreateDate] [datetime2](7) NOT NULL,
	[CreateUser] [int] NOT NULL,
	[ChangeDate] [datetime2](7) NOT NULL,
	[ChangeUser] [int] NOT NULL,
	[RowVersion] [timestamp] NOT NULL,
 CONSTRAINT [PK_Invoices] PRIMARY KEY CLUSTERED 
(
	[InvoiceId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[Products]    Script Date: 02-02-2017 22:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[Products](
	[ProductId] [uniqueidentifier] NOT NULL,
	[ProductCode] [nchar](10) COLLATE Latin1_General_CI_AI NULL,
	[Description] [varchar](50) COLLATE Latin1_General_CI_AI NOT NULL,
	[ProductTypeId] [int] NOT NULL,
	[StockByteNull] [tinyint] NULL,
	[StockByte] [tinyint] NOT NULL,
	[StockShortNull] [smallint] NULL,
	[StockShort] [smallint] NOT NULL,
	[StockIntNull] [int] NULL,
	[StockInt] [int] NOT NULL,
	[StockLongNull] [bigint] NULL,
	[StockLong] [bigint] NOT NULL,
 CONSTRAINT [PK_Products] PRIMARY KEY CLUSTERED 
(
	[ProductId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
/****** Object:  Table [dbo].[ProductTypes]    Script Date: 02-02-2017 22:47:54 ******/
SET ANSI_NULLS ON
GO
SET QUOTED_IDENTIFIER ON
GO
CREATE TABLE [dbo].[ProductTypes](
	[ProductTypeId] [int] IDENTITY(1,1) NOT NULL,
	[Description] [varchar](50) COLLATE Latin1_General_CI_AI NOT NULL,
 CONSTRAINT [PK_ProductTypes] PRIMARY KEY CLUSTERED 
(
	[ProductTypeId] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]

GO
SET ANSI_PADDING ON

GO
/****** Object:  Index [IX_InvoiceNumber]    Script Date: 02-02-2017 22:47:54 ******/
CREATE UNIQUE NONCLUSTERED INDEX [IX_InvoiceNumber] ON [dbo].[Invoices]
(
	[InvoiceNumber] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, SORT_IN_TEMPDB = OFF, IGNORE_DUP_KEY = OFF, DROP_EXISTING = OFF, ONLINE = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
GO
ALTER TABLE [dbo].[InvoiceLines]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceLines_Invoices] FOREIGN KEY([InvoiceId])
REFERENCES [dbo].[Invoices] ([InvoiceId])
GO
ALTER TABLE [dbo].[InvoiceLines] CHECK CONSTRAINT [FK_InvoiceLines_Invoices]
GO
ALTER TABLE [dbo].[InvoiceLines]  WITH CHECK ADD  CONSTRAINT [FK_InvoiceLines_Products] FOREIGN KEY([ProductId])
REFERENCES [dbo].[Products] ([ProductId])
GO
ALTER TABLE [dbo].[InvoiceLines] CHECK CONSTRAINT [FK_InvoiceLines_Products]
GO
ALTER TABLE [dbo].[Products]  WITH CHECK ADD  CONSTRAINT [FK_Products_ProductTypes] FOREIGN KEY([ProductTypeId])
REFERENCES [dbo].[ProductTypes] ([ProductTypeId])
GO
ALTER TABLE [dbo].[Products] CHECK CONSTRAINT [FK_Products_ProductTypes]
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The invoice internal identification' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Invoices', @level2type=N'COLUMN',@level2name=N'InvoiceId'
GO
EXEC sys.sp_addextendedproperty @name=N'MS_Description', @value=N'The public invoice number' , @level0type=N'SCHEMA',@level0name=N'dbo', @level1type=N'TABLE',@level1name=N'Invoices', @level2type=N'COLUMN',@level2name=N'InvoiceNumber'
GO
USE [master]
GO
ALTER DATABASE [InvoiceTest] SET  READ_WRITE 
GO
