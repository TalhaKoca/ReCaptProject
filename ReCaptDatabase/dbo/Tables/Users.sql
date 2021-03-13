CREATE TABLE [dbo].[Users]
(
	[Id] INT IDENTITY (1,1) NOT NULL,
    [FirstName] VARCHAR(50) NOT NULL, 
    [LastName] VARCHAR(50) NOT NULL,
    [Email] VARCHAR(50) NOT NULL, 
    [PasswordHash] VARBINARY(500) NOT NULL,
    [PasswordSalt] VARBINARY(500) NOT NULL, 
    [Status] BIT NOT NULL,
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED ([Id] ASC)

)
