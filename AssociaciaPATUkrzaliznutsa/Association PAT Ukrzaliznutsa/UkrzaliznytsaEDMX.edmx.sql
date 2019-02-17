
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 02/07/2019 21:13:19
-- Generated from EDMX file: D:\Progects\C-SHARP\Association-PAT-Ukrzaliznutsa\Association PAT Ukrzaliznutsa\Association PAT Ukrzaliznutsa\UkrzaliznytsaEDMX.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [UkrzaliznutsaDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ComentsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ComentsSet];
GO
IF OBJECT_ID(N'[dbo].[KlientsSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KlientsSet];
GO
IF OBJECT_ID(N'[dbo].[LokomotiveSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[LokomotiveSet];
GO
IF OBJECT_ID(N'[dbo].[MailSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MailSet];
GO
IF OBJECT_ID(N'[dbo].[MarshrutesSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MarshrutesSet];
GO
IF OBJECT_ID(N'[dbo].[NaselennuyPunktSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[NaselennuyPunktSet];
GO
IF OBJECT_ID(N'[dbo].[OrderSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[OrderSet];
GO
IF OBJECT_ID(N'[dbo].[ProdactionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ProdactionSet];
GO
IF OBJECT_ID(N'[dbo].[TicketSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TicketSet];
GO
IF OBJECT_ID(N'[dbo].[TrainsInfoSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TrainsInfoSet];
GO
IF OBJECT_ID(N'[dbo].[TrainTypeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TrainTypeSet];
GO
IF OBJECT_ID(N'[dbo].[TypeLocomotiveSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[TypeLocomotiveSet];
GO
IF OBJECT_ID(N'[dbo].[UsersSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UsersSet];
GO
IF OBJECT_ID(N'[dbo].[VagonTypeSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[VagonTypeSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'KlientsSet'
CREATE TABLE [dbo].[KlientsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NameKlient] nvarchar(max)  NOT NULL,
    [Prodaction] nvarchar(max)  NOT NULL,
    [VagonType] nvarchar(max)  NOT NULL,
    [User] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'LokomotiveSet'
CREATE TABLE [dbo].[LokomotiveSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Type] nvarchar(max)  NOT NULL,
    [Velocity] nvarchar(max)  NOT NULL,
    [PowerEngin] nvarchar(max)  NOT NULL,
    [Photo] varbinary(max)  NOT NULL,
    [PDF] varbinary(max)  NOT NULL,
    [Information] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MailSet'
CREATE TABLE [dbo].[MailSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [MailName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MarshrutesSet'
CREATE TABLE [dbo].[MarshrutesSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NumberTrain] nvarchar(max)  NOT NULL,
    [PointStart] nvarchar(max)  NOT NULL,
    [PointEnd] nvarchar(max)  NOT NULL,
    [TypeTrain] nvarchar(max)  NOT NULL,
    [TypeLocomotive] nvarchar(max)  NOT NULL,
    [Locomotive] nvarchar(max)  NOT NULL,
    [Photo] varbinary(max)  NOT NULL,
    [PDF] varbinary(max)  NOT NULL,
    [TypeVagon] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'NaselennuyPunktSet'
CREATE TABLE [dbo].[NaselennuyPunktSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [NamePunkt] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TicketSet'
CREATE TABLE [dbo].[TicketSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [User] nvarchar(max)  NOT NULL,
    [Number] nvarchar(max)  NOT NULL,
    [PointStart] nvarchar(max)  NOT NULL,
    [PointEnd] nvarchar(max)  NOT NULL,
    [TypeVagon] nvarchar(max)  NOT NULL,
    [Price] nvarchar(max)  NOT NULL,
    [Photo] varbinary(max)  NOT NULL,
    [Information] varbinary(max)  NOT NULL,
    [Marshrute] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TrainsInfoSet'
CREATE TABLE [dbo].[TrainsInfoSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Number] nvarchar(max)  NOT NULL,
    [Locomotive] nvarchar(max)  NOT NULL,
    [TypeLocomotive] nvarchar(max)  NOT NULL,
    [TypeVagon] nvarchar(max)  NOT NULL,
    [Length] nvarchar(max)  NOT NULL,
    [LocomotivePowerEngine] nvarchar(max)  NOT NULL,
    [Photo] varbinary(max)  NOT NULL,
    [PDF] varbinary(max)  NOT NULL
);
GO

-- Creating table 'TrainTypeSet'
CREATE TABLE [dbo].[TrainTypeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Type] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'TypeLocomotiveSet'
CREATE TABLE [dbo].[TypeLocomotiveSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Type] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UsersSet'
CREATE TABLE [dbo].[UsersSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'VagonTypeSet'
CREATE TABLE [dbo].[VagonTypeSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Type] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'OrderSet'
CREATE TABLE [dbo].[OrderSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [User] nvarchar(max)  NOT NULL,
    [Number] nvarchar(max)  NOT NULL,
    [ContragentFrom] nvarchar(max)  NOT NULL,
    [PointStart] nvarchar(max)  NOT NULL,
    [ContragentTo] nvarchar(max)  NOT NULL,
    [PointEnd] nvarchar(max)  NOT NULL,
    [TypeVagon] nvarchar(max)  NOT NULL,
    [PriceOfOrder] nvarchar(max)  NOT NULL,
    [Photo] varbinary(max)  NOT NULL,
    [OrderPhoto] varbinary(max)  NOT NULL,
    [InformationOfOrder] varbinary(max)  NOT NULL,
    [TypeLocomotive] nvarchar(max)  NOT NULL,
    [Locomotive] nvarchar(max)  NOT NULL,
    [Marshrute] nvarchar(max)  NOT NULL,
    [ProdactionInformation] nvarchar(max)  NOT NULL,
    [AllInformation] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ProdactionSet'
CREATE TABLE [dbo].[ProdactionSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ProdactionName] nvarchar(max)  NOT NULL,
    [ProdactionCount] nvarchar(max)  NOT NULL,
    [ProdactionCost] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'ComentsSet'
CREATE TABLE [dbo].[ComentsSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [User] nvarchar(max)  NOT NULL,
    [Marshrute] nvarchar(max)  NOT NULL,
    [Coment] nvarchar(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'KlientsSet'
ALTER TABLE [dbo].[KlientsSet]
ADD CONSTRAINT [PK_KlientsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LokomotiveSet'
ALTER TABLE [dbo].[LokomotiveSet]
ADD CONSTRAINT [PK_LokomotiveSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MailSet'
ALTER TABLE [dbo].[MailSet]
ADD CONSTRAINT [PK_MailSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'MarshrutesSet'
ALTER TABLE [dbo].[MarshrutesSet]
ADD CONSTRAINT [PK_MarshrutesSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'NaselennuyPunktSet'
ALTER TABLE [dbo].[NaselennuyPunktSet]
ADD CONSTRAINT [PK_NaselennuyPunktSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TicketSet'
ALTER TABLE [dbo].[TicketSet]
ADD CONSTRAINT [PK_TicketSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TrainsInfoSet'
ALTER TABLE [dbo].[TrainsInfoSet]
ADD CONSTRAINT [PK_TrainsInfoSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TrainTypeSet'
ALTER TABLE [dbo].[TrainTypeSet]
ADD CONSTRAINT [PK_TrainTypeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'TypeLocomotiveSet'
ALTER TABLE [dbo].[TypeLocomotiveSet]
ADD CONSTRAINT [PK_TypeLocomotiveSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UsersSet'
ALTER TABLE [dbo].[UsersSet]
ADD CONSTRAINT [PK_UsersSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'VagonTypeSet'
ALTER TABLE [dbo].[VagonTypeSet]
ADD CONSTRAINT [PK_VagonTypeSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OrderSet'
ALTER TABLE [dbo].[OrderSet]
ADD CONSTRAINT [PK_OrderSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ProdactionSet'
ALTER TABLE [dbo].[ProdactionSet]
ADD CONSTRAINT [PK_ProdactionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ComentsSet'
ALTER TABLE [dbo].[ComentsSet]
ADD CONSTRAINT [PK_ComentsSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------