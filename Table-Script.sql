USE [Company]
GO

 
CREATE TABLE [dbo].[ProductInfo](
	[ProductId] [char](20) Primary Key,
	[ProductName] [varchar](200) NOT NULL,
	[Manufacturer] [varchar](200) NOT NULL,
	[Description] [varchar](400) NOT NULL,
	[BasePrice] [decimal](18, 0) NOT NULL,
	[Tax] as ([BasePrice] * 0.2),
	[TotalPrice]  AS ([BasePrice]+([BasePrice] * 0.2)),
)
select * from ProductInfo

Insert into [ProductInfo] values('Prd-0001','Laptop','MS-IT','Gaming Laptop',120000)

Insert into [ProductInfo] values('Prd-0002','Iron','MS-Ect','Household Cotton Iron',2000)
Insert into [ProductInfo] values('Prd-0003','Water Bottle','MS-Home Appliances','2 Lts. Cold Storage',200)
Insert into [ProductInfo] values('Prd-0004','RAM','MS-IT','32 GB DDR 6 Fast Memory',20000)
Insert into [ProductInfo] values('Prd-0005','Mixer','MS-Ect','Kitchen Appliances',16000)
Insert into [ProductInfo] values('Prd-0006','Mouse','MS-IT','Optical USB Gaming Mouse',1000)
Insert into [ProductInfo] values('Prd-0007','Keyboard','MS-IT','Gaming Lights 110 Keys Stroke Kayboard',2000)




 


