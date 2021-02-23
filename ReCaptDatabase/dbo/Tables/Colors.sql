CREATE TABLE [dbo].[Colors] (
    [ColorId]   INT IDENTITY (1,1) NOT NULL,
    [ColorName] NCHAR (10) NOT NULL,
    CONSTRAINT [PK_Colors] PRIMARY KEY CLUSTERED ([ColorId] ASC)
);
