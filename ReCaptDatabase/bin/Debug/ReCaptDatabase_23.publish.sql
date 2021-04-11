﻿/*
Deployment script for ReCaptDatabase

This code was generated by a tool.
Changes to this file may cause incorrect behavior and will be lost if
the code is regenerated.
*/

GO
SET ANSI_NULLS, ANSI_PADDING, ANSI_WARNINGS, ARITHABORT, CONCAT_NULL_YIELDS_NULL, QUOTED_IDENTIFIER ON;

SET NUMERIC_ROUNDABORT OFF;


GO
:setvar DatabaseName "ReCaptDatabase"
:setvar DefaultFilePrefix "ReCaptDatabase"
:setvar DefaultDataPath "C:\Users\HP\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"
:setvar DefaultLogPath "C:\Users\HP\AppData\Local\Microsoft\Microsoft SQL Server Local DB\Instances\MSSQLLocalDB\"

GO
:on error exit
GO
/*
Detect SQLCMD mode and disable script execution if SQLCMD mode is not supported.
To re-enable the script after enabling SQLCMD mode, execute the following:
SET NOEXEC OFF; 
*/
:setvar __IsSqlCmdEnabled "True"
GO
IF N'$(__IsSqlCmdEnabled)' NOT LIKE N'True'
    BEGIN
        PRINT N'SQLCMD mode must be enabled to successfully execute this script.';
        SET NOEXEC ON;
    END


GO
USE [$(DatabaseName)];


GO
/*
The type for column ColorName in table [dbo].[Colors] is currently  NVARCHAR (50) NULL but is being changed to  NCHAR (10) NULL. Data loss could occur and deployment may fail if the column contains data that is incompatible with type  NCHAR (10) NULL.
*/

IF EXISTS (select top 1 1 from [dbo].[Colors])
    RAISERROR (N'Rows were detected. The schema update is terminating because data loss might occur.', 16, 127) WITH NOWAIT

GO
PRINT N'Rename refactoring operation with key 4cb9c568-124c-40b6-ab0d-8290993091ea is skipped, element [dbo].[Brands].[Id] (SqlSimpleColumn) will not be renamed to BrandId';


GO
PRINT N'Rename refactoring operation with key edbab4ec-1e8a-4c99-9ab4-5dce926797bf is skipped, element [dbo].[Colors].[Id] (SqlSimpleColumn) will not be renamed to ColorId';


GO
PRINT N'Altering [dbo].[Colors]...';


GO
ALTER TABLE [dbo].[Colors] ALTER COLUMN [ColorName] NCHAR (10) NULL;


GO
PRINT N'Creating unnamed constraint on [dbo].[Colors]...';


GO
ALTER TABLE [dbo].[Colors]
    ADD PRIMARY KEY CLUSTERED ([ColorId] ASC);


GO
PRINT N'Creating [dbo].[Payments]...';


GO
CREATE TABLE [dbo].[Payments] (
    [Id]             INT           IDENTITY (1, 1) NOT NULL,
    [CustomerId]     INT           NULL,
    [CardHolder]     NVARCHAR (50) NULL,
    [CardNumber]     NVARCHAR (50) NULL,
    [ExpiryDate]     NVARCHAR (50) NULL,
    [SecurityNumber] NVARCHAR (50) NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);


GO
PRINT N'Creating [dbo].[PK_Cars]...';


GO
ALTER TABLE [dbo].[Cars]
    ADD CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED ([CarId] ASC);


GO
PRINT N'Creating [dbo].[PK_CarsImages]...';


GO
ALTER TABLE [dbo].[CarsImages]
    ADD CONSTRAINT [PK_CarsImages] PRIMARY KEY CLUSTERED ([ImageId] ASC);


GO
PRINT N'Creating [dbo].[PK_Rentals]...';


GO
ALTER TABLE [dbo].[Rentals]
    ADD CONSTRAINT [PK_Rentals] PRIMARY KEY CLUSTERED ([RentalId] ASC);


GO
PRINT N'Creating [dbo].[PK_Users]...';


GO
ALTER TABLE [dbo].[Users]
    ADD CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC);


GO
-- Refactoring step to update target server with deployed transaction logs
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '4cb9c568-124c-40b6-ab0d-8290993091ea')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('4cb9c568-124c-40b6-ab0d-8290993091ea')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = 'edbab4ec-1e8a-4c99-9ab4-5dce926797bf')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('edbab4ec-1e8a-4c99-9ab4-5dce926797bf')

GO

GO
PRINT N'Update complete.';


GO
