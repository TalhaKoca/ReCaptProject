CREATE TABLE [dbo].[Users]
(
	[UserId] INT IDENTITY (1,1) NOT NULL,
    [FirstName] NVARCHAR(50) NULL, 
    [LastName] NVARCHAR(50) NULL,
    [Email] NVARCHAR(50) NULL, 
    [Password] CHAR(10) NULL
    CONSTRAINT [PK_Users] PRIMARY KEY CLUSTERED (UserId ASC)
)
