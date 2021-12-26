Create trigger KitapDurum2 
on Movements 
after update
As
declare @BookId INT
select @BookId=BookId from inserted 
update Books Set BookStatus=1 Where BookId=@BookId