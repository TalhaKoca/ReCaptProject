CREATE TABLE [dbo].[Cars] (
    [CarId]       INT NOT NULL,
    [BrandId]     INT NULL,
    [ColorId]     INT NULL,
    [ModelYear]   INT           NULL,
    [DailyPrice]  DECIMAL  NULL,
    [Description] NVARCHAR(50) NULL,
    PRIMARY KEY CLUSTERED ([CarId] ASC)
);

