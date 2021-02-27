CREATE TABLE [dbo].[Rentals]
(
	[RentalId] INT IDENTITY (1,1) NOT NULL,
    [CarId] INT NULL, 
    [CustomerId] INT NULL, 
    [RentDate] DATETIME2 NULL, 
    [ReturnDate] DATETIME2 NULL
    CONSTRAINT [PK_Rentals] PRIMARY KEY CLUSTERED ([RentalId] ASC) DEFAULT Nulls 
)
