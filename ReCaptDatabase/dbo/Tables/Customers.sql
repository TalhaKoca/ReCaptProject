CREATE TABLE [dbo].[Customers]
(
	[CustomerId] INT IDENTITY (1,1) NOT NULL,
    [CompanyName] NVARCHAR(50) NULL,
	[UserId] INT NULL,
	CONSTRAINT [PK_Customers] PRIMARY KEY CLUSTERED ([CustomerId] ASC)
)
