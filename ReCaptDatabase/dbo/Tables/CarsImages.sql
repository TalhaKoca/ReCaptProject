CREATE TABLE [dbo].[CarsImages]
(
	[ImageId] INT IDENTITY (1,1) NOT NULL, 
    [CarId] INT NULL, 
    [ImagePath] NVARCHAR(MAX) NULL, 
    [Date] DATETIME2 NULL
    CONSTRAINT [PK_CarsImages] PRIMARY KEY CLUSTERED ([ImageId] ASC)
)
