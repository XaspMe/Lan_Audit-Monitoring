
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 09/21/2019 20:04:31
-- Generated from EDMX file: C:\Users\Semen\source\repos\Lan_Audit (Monitoring)\Monitoring_DB\Monitoring.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Monitoring];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'HostSet'
CREATE TABLE [dbo].[HostSet] (
    [Host_ID] uniqueidentifier  NOT NULL,
    [IP] nvarchar(max)  NULL,
    [DNS_Name] nvarchar(max)  NULL,
    [Display_Name] nvarchar(max)  NULL,
    [State] bit  NOT NULL,
    [Last_Appeal] datetime  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Host_ID] in table 'HostSet'
ALTER TABLE [dbo].[HostSet]
ADD CONSTRAINT [PK_HostSet]
    PRIMARY KEY CLUSTERED ([Host_ID] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------