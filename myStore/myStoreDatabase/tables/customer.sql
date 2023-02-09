CREATE TABLE [dbo].[customer](
	[customerid] [int] IDENTITY(1,1) NOT NULL,
	[name] [varchar](100) NULL,
	[address] [varchar](100) NULL,
	[state] [varchar](2) NULL,
	[zipcode] [varchar](5) NULL,
	[phonenumber] [varchar](20) NULL, 
    [country] VARCHAR(30) NULL
) ON [PRIMARY]