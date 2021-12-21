Create Trigger KitapDurum
on Movements 
After Insert
As Declare @BookId Int 
Select @BookId =BookId From inserted 
Update Books Set BookStatus=0 Where BookId=@BookId