CREATE TABLE [dbo].[Currencies]
(
	[CurrencyId] INT NOT NULL PRIMARY KEY,
	[CurrencyAlias] VARCHAR(3) NOT NULL,
	[CurrencyRateId] INT NOT NULL
)
