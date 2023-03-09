/****** Script for SelectTopNRows command from SSMS  ******/
/*SELECT TOP (1000) 
[customerid], [name], [address], [state], [zipcode], [phonenumber]
  FROM [myStore].[dbo].[customer]
  order by customerid asc
  SET identity_insert customer off
  go
  update customer set customerid = 2 where name = 'Jane Doe' 
  SELECT *into customer1 from customer
  truncate table customer
  insert into customer ([name]
      ,[address]
      ,[state]
      ,[zipcode])
	  select [name]
      ,[address]
      ,[state]
      ,[zipcode] from customer1
*/
SELECT * FROM product;
UPDATE product
SET "desc"= 'A traditional style classical guitar from the brand Cordoba.'
WHERE productid = 1;