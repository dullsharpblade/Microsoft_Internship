-- update customer set customerid = 2 where name = 'Jane Doe' 
--  SELECT *into customer1 from customer
-- truncate table customer
  insert into customer ([name]
      ,[address]
      ,[state]
      ,[zipcode])
	  select [name]
      ,[address]
      ,[state]
      ,[zipcode] from customer1