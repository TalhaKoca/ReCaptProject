CREATE TABLE [dbo].[Brands] (
    [BrandId]   INT IDENTITY (1,1) NOT NULL,
    [BrandName] NVARCHAR (50) NULL,
    CONSTRAINT [PK_Brands] PRIMARY KEY CLUSTERED ([BrandId] ASC)
);

