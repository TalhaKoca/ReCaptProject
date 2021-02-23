CREATE TABLE [dbo].[Cars] (
    [CarId]       INT IDENTITY (1,1) NOT NULL,
    [BrandId]     INT NULL,
    [ColorId]     INT NULL,
    [ModelYear]   INT           NULL,
    [DailyPrice]  DECIMAL  NULL,
    [Description] NVARCHAR(50) NULL,
    CONSTRAINT [PK_Cars] PRIMARY KEY CLUSTERED ([CarId] ASC)
     
);

