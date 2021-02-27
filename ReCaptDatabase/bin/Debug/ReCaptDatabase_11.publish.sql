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
PRINT N'Rename refactoring operation with key 17c79aa1-6e89-445c-a957-51916ef95176, 44a76132-f679-4225-be18-4c9d124a0857 is skipped, element [dbo].[Customers].[UserId] (SqlSimpleColumn) will not be renamed to CustomerId';


GO
PRINT N'Creating [dbo].[PK_Customers]...';


GO
ALTER TABLE [dbo].[Customers]
    ADD CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([CustomerId] ASC);


GO
-- Refactoring step to update target server with deployed transaction logs
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '17c79aa1-6e89-445c-a957-51916ef95176')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('17c79aa1-6e89-445c-a957-51916ef95176')
IF NOT EXISTS (SELECT OperationKey FROM [dbo].[__RefactorLog] WHERE OperationKey = '44a76132-f679-4225-be18-4c9d124a0857')
INSERT INTO [dbo].[__RefactorLog] (OperationKey) values ('44a76132-f679-4225-be18-4c9d124a0857')

GO

GO
PRINT N'Update complete.';


GO
