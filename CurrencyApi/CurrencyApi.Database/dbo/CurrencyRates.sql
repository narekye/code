CREATE TABLE [dbo].[CurrencyRates]
(
	[Id] INT NOT NULL PRIMARY KEY,
	[ToCurrencyAlias] VARCHAR(3) NOT NULL,
	[Rate] INT NOT NULL FOREIGN KEY REFERENCES [Currencies](CurrencyId)
)