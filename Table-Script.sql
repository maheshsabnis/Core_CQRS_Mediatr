USE [Company]
GO

 

CREATE TABLE [dbo].[ProductInfo](
	[ProductRecordId] [int] IDENTITY(1,1) NOT NULL,
	[ProductId] [char](20) Primary Key,
	[ProductName] [varchar](200) NOT NULL,
	[Manufacturer] [varchar](200) NOT NULL,
	[Description] [varchar](400) NOT NULL,
	[BasePrice] [decimal](18, 0) NOT NULL,
	[Tax] as ([BasePrice] * 0.2),
	[TotalPrice]  AS ([BasePrice]+([BasePrice] * 0.2)),
)
 


